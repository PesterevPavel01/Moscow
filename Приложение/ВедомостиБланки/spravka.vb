Imports System.Security.Policy

Module spravka
    Sub spravka(ЧекнутыеСлушатели As Object)
        Dim wordApp
        Dim wordDok, group
        Dim resourcesPath, ПутьКШаблону
        Dim dateVal As Date, dateMain As String
        Dim queryString, type As String

        If ЧекнутыеСлушатели(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If


        dateVal = BuildOrder.ДатаПриказа.Value

        dateMain = Chr(34) & Format(dateVal, "dd") & Chr(34) & " " & месяцРП(Format(dateVal, "MMMM")) & " " & Format(dateVal, "yyyy")
        queryString = spravka__groupData(MainForm.orderIdGroup)
        group = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        resourcesPath = _technical.resourcesPath()
        ПутьКШаблону = resourcesPath & "Шаблоны\Справка об обучении.docx"

        wordApp = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(ЧекнутыеСлушатели, 2)

            type = "СправкаООбучении" & ЧекнутыеСлушатели(0, СчетчикСтрок)

            wordDok = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            _technical.savePrikazBlank(wordDok, MainForm.orderIdGroup, type, resourcesPath, "Справки")

            Warning.content.Visible = False
            Warning.TextBox.Visible = True

            Warning.TextBox.Text = "Справки сохранены, Путь к каталогу:
" & BuildOrder.path

            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$СлушательИО$", _technical.ФамилияИОПоПолнойФИО(ЧекнутыеСлушатели(0, СчетчикСтрок)), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ФИОСлушатель$", ЧекнутыеСлушатели(0, СчетчикСтрок), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$КоличествоСлушателей$", UBound(ЧекнутыеСлушатели, 2) + 1, 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$УровеньКвалификации$", group(1, 0), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Программа$", group(0, 0), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ГруппаФинансирование$", group(2, 0), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ДатаНЗ$", group(3, 0), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ДатаКЗ$", group(4, 0), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Приказ$", BuildOrder.ПрактическаяПодготовка.Text, 2)

            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$И.О.Ответств$", rotate(BuildOrder.Утверждает.Text), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Дата$", dateMain, 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$День$", Format(dateVal, "dd"), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Месяц$", месяцРП(Format(dateVal, "MMMM")), 2)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Год$", Format(dateVal, "yyyy"), 2)

            wordDok.Save
            wordDok.Close
        Next

        wordApp.Quit
        Warning.ShowDialog()
        Warning.content.Visible = True
        Warning.TextBox.Visible = False

    End Sub


End Module
