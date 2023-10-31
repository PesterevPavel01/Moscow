Imports System.Security.Policy

Module spravka
    Sub spravka(argument As OrderArgument)
        Dim wordApp
        Dim wordDok, group
        Dim resourcesPath, ПутьКШаблону
        Dim dateMain As String
        Dim queryString, type As String

        If argument.selectedStudents(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If


        dateMain = Chr(34) & Format(argument.orderDate, "dd") & Chr(34) & " " & monthRP(Format(argument.orderDate, "MMMM")) & " " & Format(argument.orderDate, "yyyy")
        queryString = spravka__groupData(argument.orderIdGroup)
        group = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        resourcesPath = _technical.updateResourcesPath()
        ПутьКШаблону = resourcesPath & "Шаблоны\Справка об обучении.docx"

        wordApp = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(argument.selectedStudents, 2)

            type = "СправкаООбучении" & argument.selectedStudents(0, СчетчикСтрок)

            wordDok = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            _technical.savePrikazBlank(wordDok, argument.orderIdGroup, type, resourcesPath, "Справки", argument.mySqlConnector)

            Warning.content.Visible = False
            Warning.TextBox.Visible = True

            Warning.TextBox.Text = "Справки сохранены, Путь к каталогу:
" & BuildOrder.path

            _technical.replaceText_documentWordRange(wordDok.Range, "$СлушательИО$", _technical.ФамилияИОПоПолнойФИО(argument.selectedStudents(0, СчетчикСтрок)), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$ФИОСлушатель$", argument.selectedStudents(0, СчетчикСтрок), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$КоличествоСлушателей$", UBound(argument.selectedStudents, 2) + 1, 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$НомерГруппы$", argument.groupNumber, 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$УровеньКвалификации$", group(1, 0), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$Программа$", group(0, 0), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$ГруппаФинансирование$", group(2, 0), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$ДатаНЗ$", group(3, 0), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$ДатаКЗ$", group(4, 0), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$Приказ$", argument.practical, 2)

            _technical.replaceText_documentWordRange(wordDok.Range, "$И.О.Ответств$", rotate(argument.approves), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$Дата$", dateMain, 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$День$", Format(argument.orderDate, "dd"), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$Месяц$", monthRP(Format(argument.orderDate, "MMMM")), 2)
            _technical.replaceText_documentWordRange(wordDok.Range, "$Год$", Format(argument.orderDate, "yyyy"), 2)

            wordDok.Save
            wordDok.Close
        Next

        wordApp.Quit
        Warning.ShowDialog()
        Warning.content.Visible = True
        Warning.TextBox.Visible = False

    End Sub


End Module
