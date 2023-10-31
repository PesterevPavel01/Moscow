Module ДоверенностьПолученияБланковНаГруппу

    Sub ДоверенностьПолученияБланковНаГруппу(argument As OrderArgument)
        Dim wordApp
        Dim wordDoc, studentsData, group, table
        Dim resourcesPath, samplePath
        Dim dateInOrder As String
        Dim queryString As String

        dateInOrder = Chr(34) & Format(argument.orderDate, "dd") & Chr(34) & " " & monthRP(Format(argument.orderDate, "MMMM")) & " " & Format(argument.orderDate, "yyyy")

        argument.orderType = "ДоверенностьПолученияБланковНаГруппу"

        queryString = selectDover_slush(argument.orderIdGroup)
        studentsData = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        queryString = selectDoverKval(argument.orderIdGroup)
        group = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        resourcesPath = _technical.updateResourcesPath()
        samplePath = resourcesPath & "Шаблоны\Доверенность получения бланков на группу.docx"

        wordApp = CreateObject("Word.Application")


        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, argument.orderType, resourcesPath, "Доверенности", argument.mySqlConnector)

        _technical.replaceText_documentWordRange(wordDoc.Range, "$НомерГруппы$", argument.groupNumber, 2)

        table = МСВорд.НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc, "$Таблица$", 2, 2)

        Try
            If table(0, 0) = "Не найдено" Then
                Warning.content.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                Warning.ShowDialog()
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        _technical.replaceText_documentWordRange(wordDoc.Range, "$КоличествоСлушателей$", UBound(studentsData, 2) + 1, 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$НомерГруппы$", argument.groupNumber, 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$УровеньКвалификации$", group(1, 0), 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$Программа$", group(0, 0), 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$ГруппаФинансирование$", group(2, 0), 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$И.О.Ответств$", rotate(argument.approves), 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$Дата$", dateInOrder, 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$День$", Format(argument.orderDate, "dd"), 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$Месяц$", monthRP(Format(argument.orderDate, "MMMM")), 2)
        _technical.replaceText_documentWordRange(wordDoc.Range, "$Год$", Format(argument.orderDate, "yyyy"), 2)

        МСВорд.ЗаполнитьТаблицу(table, studentsData, 2, True)
        wordDoc.Save
        wordApp.visible = True
    End Sub

    Sub ДоверенностьПолученияБланковНаСлушателя(argument As OrderArgument)
        Dim wordApp
        Dim wordDoc, group
        Dim resourcesPath, samplePath
        Dim dateInOrder As String
        Dim queryString As String

        If argument.selectedStudents(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        queryString = selectDoverKval(argument.orderIdGroup)
        group = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        argument.orderDate = group(3, 0)
        dateInOrder = Chr(34) & Format(argument.orderDate, "dd") & Chr(34) & " " & monthRP(Format(argument.orderDate, "MMMM")) & " " & Format(argument.orderDate, "yyyy")

        resourcesPath = _technical.updateResourcesPath()
        samplePath = resourcesPath & "Шаблоны\Доверенность получения бланков на каждого человека группы.docx"

        wordApp = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(argument.selectedStudents, 2)

            argument.orderType = "ДоверенностьПолученияБланковНаСлушателя" & argument.selectedStudents(0, СчетчикСтрок)

            wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

            _technical.savePrikazBlank(wordDoc, MainForm.orderIdGroup, argument.orderType, resourcesPath, "Доверенности", argument.mySqlConnector)

            _technical.replaceText_documentWordRange(wordDoc.Range, "$СлушательИО$", _technical.ФамилияИОПоПолнойФИО(argument.selectedStudents(0, СчетчикСтрок)), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ФИОСлушатель$", argument.selectedStudents(0, СчетчикСтрок), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$КоличествоСлушателей$", UBound(argument.selectedStudents, 2) + 1, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$УровеньКвалификации$", group(1, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Программа$", group(0, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ГруппаФинансирование$", group(2, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$И.О.Ответств$", rotate(BuildOrder.Утверждает.Text), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ДатаК$", dateInOrder, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$День$", Format(argument.orderDate, "dd"), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Месяц$", monthRP(Format(argument.orderDate, "MMMM")), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Год$", Format(argument.orderDate, "yyyy"), 2)

            wordDoc.Save
            wordDoc.Close
        Next

        wordApp.Quit

        Warning.TextBox.Text = BuildOrder.path
        Warning.TextBox.Visible = True
        Warning.content.Visible = False
        Warning.ShowDialog()
        Warning.TextBox.Visible = False
        Warning.content.Visible = True
    End Sub

End Module
