Imports System.Security.Policy

Module spravka
    Sub spravka(ЧекнутыеСлушатели As Object)
        Dim wordApp
        Dim wordDok, group
        Dim resourcesPath, ПутьКШаблону
        Dim dateVal As Date, dateMain As String
        Dim queryString, type As String

        If ЧекнутыеСлушатели(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If


        dateVal = АСформироватьПриказ.ДатаПриказа.Value

        dateMain = Chr(34) & Format(dateVal, "dd") & Chr(34) & " " & месяцРП(Format(dateVal, "MMMM")) & " " & Format(dateVal, "yyyy")
        queryString = spravka__groupData(MainForm.prikazKodGroup)
        group = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If group(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        resourcesPath = Вспомогательный.resourcesPath()
        ПутьКШаблону = resourcesPath & "Шаблоны\Справка об обучении.docx"

        wordApp = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(ЧекнутыеСлушатели, 2)

            type = "СправкаООбучении" & ЧекнутыеСлушатели(0, СчетчикСтрок)

            wordDok = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            Вспомогательный.savePrikazBlank(wordDok, MainForm.prikazKodGroup, type, resourcesPath, "Справки")

            предупреждение.текст.Visible = False
            предупреждение.TextBox.Visible = True

            предупреждение.TextBox.Text = "Справки сохранены, Путь к каталогу:
" & АСформироватьПриказ.path

            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$СлушательИО$", Вспомогательный.ФамилияИОПоПолнойФИО(ЧекнутыеСлушатели(0, СчетчикСтрок)), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ФИОСлушатель$", ЧекнутыеСлушатели(0, СчетчикСтрок), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$КоличествоСлушателей$", UBound(ЧекнутыеСлушатели, 2) + 1, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$УровеньКвалификации$", group(1, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Программа$", group(0, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ГруппаФинансирование$", group(2, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ДатаНЗ$", group(3, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$ДатаКЗ$", group(4, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Приказ$", АСформироватьПриказ.ПрактическаяПодготовка.Text, 2)

            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$И.О.Ответств$", rotate(АСформироватьПриказ.Утверждает.Text), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Дата$", dateMain, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$День$", Format(dateVal, "dd"), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Месяц$", месяцРП(Format(dateVal, "MMMM")), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDok.Range, "$Год$", Format(dateVal, "yyyy"), 2)

            wordDok.Save
            wordDok.Close
        Next

        wordApp.Quit
        предупреждение.ShowDialog()
        предупреждение.текст.Visible = True
        предупреждение.TextBox.Visible = False

    End Sub


End Module
