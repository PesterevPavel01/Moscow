Module ВедомостьПромежуточнойАттестации

    Sub ВедомостьПромежуточнойАттестации(argument As OrderArgument)

        If argument.selectedModuls(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        Dim wordApp
        Dim wordDoc, studentsData, group, table
        Dim resourcesPath, samplePath
        Dim dateInOrder As String
        Dim queryString As String

        dateInOrder = Chr(34) & Format(argument.orderDate, "dd") & Chr(34) & " " & monthRP(Format(argument.orderDate, "MMMM")) & " " & Format(argument.orderDate, "yyyy")

        queryString = vedomPromAtt__loadListSlush(MainForm.orderIdGroup)

        studentsData = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        queryString = load_prog_kurator(MainForm.orderIdGroup)
        group = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        resourcesPath = _technical.updateResourcesPath()

        If argument.orderType = "ВедомостьПромежуточнойАттестации" Then

            samplePath = resourcesPath & "Шаблоны\Ведомость промежуточной аттестации.docx"

        ElseIf argument.orderType = "ПП_Ведомость" Then

            samplePath = resourcesPath & "Шаблоны\ПП_Ведомость.docx"

        End If



        wordApp = CreateObject("Word.Application")

        For i = 0 To UBound(argument.selectedModuls, 2)
            Dim value
            queryString = select_moduls_ocenka(argument.orderIdGroup, argument.selectedModuls(0, i))

            value = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

            wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

            _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, argument.selectedModuls & " " & argument.selectedModuls(0, i), resourcesPath, "Ведомости", argument.mySqlConnector)

            Warning.content.Visible = False
            Warning.TextBox.Visible = True

            Warning.TextBox.Text = "Документы сохранены, Путь к каталогу:
" & BuildOrder.path

            _technical.replaceText_documentWordRange(wordDoc.Range, "$НомерГруппы$", argument.groupNumber, 2)

            table = МСВорд.НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc, "$Таблица$", 2, 2)

            Try
                If table(0, 0) = "не найдена" Then
                    Warning.content.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                    Warning.ShowDialog()
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
            _technical.replaceText_documentWordRange(wordDoc.Range, "$КоличествоСлушателей$", UBound(studentsData, 2) + 1, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$НомерГруппы$", argument.groupNumber, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$КураторГруппы$", group(1, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Программа$", group(0, 0), 2)

            If Not Len(argument.selectedModuls(1, i)) < 5 Then
                _technical.replaceText_documentWordRange(wordDoc.Range, "$И.О.Ответств$", rotate(argument.selectedModuls(1, i)), 2)
            End If

            _technical.replaceText_documentWordRange(wordDoc.Range, "$Модуль$", argument.selectedModuls(0, i), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Дата$", dateInOrder, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$День$", Format(argument.orderDate, "dd"), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Месяц$", monthRP(Format(argument.orderDate, "MMMM")), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Год$", Format(argument.orderDate, "yyyy"), 2)

            МСВорд.ЗаполнитьТаблицуВедомости(table, studentsData, value, 2, True)

            wordDoc.Save
            wordDoc.Close
        Next

        wordApp.Quit
        Warning.ShowDialog()
        Warning.content.Visible = True
        Warning.TextBox.Visible = False

    End Sub

End Module
