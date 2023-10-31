Module СправкаОбОкончании

    Sub СправкаОбОкончании(argument As OrderArgument)
        Dim wordApp
        Dim wordDoc, moduls, group, table
        Dim resourcesPath, ПутьКШаблону
        Dim dateString As String
        Dim queryString, type As String

        If argument.selectedStudents(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        dateString = Chr(34) & Format(argument.orderDate, "dd") & Chr(34) & " " & monthRP(Format(argument.orderDate, "MMMM")) & " " & Format(argument.orderDate, "yyyy")
        queryString = selectSpravkaIA_group(argument.orderIdGroup)
        group = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        queryString = selectSpravka_moduls_hours(argument.orderIdGroup)
        moduls = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If moduls(0, 0) = "нет записей" Then
            Warning.content.Text = "Отсутствуют модули в программе!"
            Warning.ShowDialog()
            Warning.content.Text = "Нет данных для отображения"
            Exit Sub
        End If

        resourcesPath = _technical.updateResourcesPath()
        ПутьКШаблону = resourcesPath & "Шаблоны\Справка об окончании без ИА.docx"

        wordApp = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(argument.selectedStudents, 2)

            type = "Справка об окончании без ИА" & argument.selectedStudents(0, СчетчикСтрок)

            wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, type, resourcesPath, "Справки", argument.mySqlConnector)

            Warning.content.Visible = False
            Warning.TextBox.Visible = True

            Warning.TextBox.Text = "Справки сохранены, Путь к каталогу:
" & BuildOrder.path

            _technical.replaceText_documentWordRange(wordDoc.Range, "$СлушательИО$", _technical.ФамилияИОПоПолнойФИО(argument.selectedStudents(0, СчетчикСтрок)), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ФИОСлушатель$", argument.selectedStudents(0, СчетчикСтрок), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$КоличествоСлушателей$", UBound(argument.selectedStudents, 2) + 1, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$УровеньКвалификации$", group(1, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Программа$", group(0, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ГруппаФинансирование$", group(2, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ДатаНЗ$", group(3, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ДатаКЗ$", group(4, 0), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$ГруппаЧасы$", group(5, 0), 2)

            _technical.replaceText_documentWordRange(wordDoc.Range, "$И.О.Ответств$", rotate(BuildOrder.Утверждает.Text), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Дата$", dateString, 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$День$", Format(argument.orderDate, "dd"), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Месяц$", monthRP(Format(argument.orderDate, "MMMM")), 2)
            _technical.replaceText_documentWordRange(wordDoc.Range, "$Год$", Format(argument.orderDate, "yyyy"), 2)


            table = НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc.Range, "$Таблица$", 2, 2)

            Try
                If table(0, 0) = "Не найдено" Then
                    Warning.content.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                    Warning.ShowDialog()
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            МСВорд.ЗаполнитьТаблицу(table, moduls, 2, False)

            wordDoc.Save
            wordDoc.Close
        Next

        wordApp.Quit
        Warning.ShowDialog()
        Warning.content.Visible = True
        Warning.TextBox.Visible = False

    End Sub

End Module
