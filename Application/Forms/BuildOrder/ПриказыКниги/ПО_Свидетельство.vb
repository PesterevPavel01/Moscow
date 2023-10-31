Module ПО_Свидетельство
    Sub po_svid(argument As OrderArgument)

        Dim WordApp
        Dim wordDok, table, coordinates, rangeObj
        Dim group, students
        Dim number As Int64
        Dim sqlQuery As String, resorsesPath, samplePath As String

        sqlQuery = poSvid__loadListSvid(MainForm.orderIdGroup)
        students = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If students(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        sqlQuery = selectMassForPrilSvidetelstvo(MainForm.orderIdGroup)
        group = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        Try
            number = group(7, 0)
        Catch ex As Exception
            Warning.content.Text = "В выбранной группе номер свидетельства не указан или не является числом"
            openForm(Warning)
            Exit Sub
        End Try

        resorsesPath = startApp.resourcesPath
        samplePath = resorsesPath & "Шаблоны\ПК_Окончание\Таблицы_ПО_Св-во.docx"

        WordApp = CreateObject("Word.Application")

        wordDok = WordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDok, MainForm.orderIdGroup, argument.orderType, resorsesPath, "Приказы", argument.mySqlConnector)

        WordApp.DisplayAlerts = False

        table = НайтиТаблицуПоМеткеИлиНеНайдена(wordDok, "$Таблица2$", 1, 1)

        Try
            If table(0, 0).ToString = "не найдена" Then
                Warning.content.Text = "Не найдена таблица с меткой $Таблица2$ в ячейке (1,1). Путь к шаблону: " & samplePath
                openForm(Warning)
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        secondTableSample(table, group, samplePath)

        ReDim coordinates(1, UBound(students, 2))
        coordinates(0, 0) = 1
        coordinates(1, 0) = wordDok.Paragraphs.Count

        For счетчикСлушателей = 1 To UBound(students, 2)

            wordDok.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

            coordinates(0, счетчикСлушателей) = wordDok.Paragraphs().Count - 1

            rangeObj = wordDok.Paragraphs(1).Range
            rangeObj.SetRange(Start:=rangeObj.Start,
                                 End:=wordDok.Paragraphs(coordinates(1, 0)).Range.End)
            rangeObj.Copy
            wordDok.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
            wordDok.Bookmarks("\EndOfDoc").Range.Delete
            coordinates(1, счетчикСлушателей) = wordDok.Paragraphs.Count
        Next

        students = addZerosIntoArray(students, 16, 5)

        For studentsCounter = 0 To UBound(students, 2)

            rangeObj = wordDok.Paragraphs(coordinates(0, studentsCounter)).Range
            rangeObj.SetRange(Start:=rangeObj.Start,
                                 End:=wordDok.Paragraphs(coordinates(1, studentsCounter)).Range.End)
            replaceTextInWordApp(rangeObj, "$Таблица2$", "")
            replaceTextInWordApp(rangeObj, "$Модуль1$", students(4, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль2$", students(5, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль3$", students(6, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль4$", students(7, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль5$", students(8, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль6$", students(9, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль7$", students(10, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль8$", students(11, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль9$", students(12, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Модуль10$", students(13, studentsCounter))
            replaceTextInWordApp(rangeObj, "$ПП$", students(14, studentsCounter))
            replaceTextInWordApp(rangeObj, "$ИА$", students(15, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Фамилия$", students(0, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Имя$", students(1, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Отчество$", students(2, studentsCounter))
            replaceTextInWordApp(rangeObj, "$ДатаРождения$", students(3, studentsCounter))
            replaceTextInWordApp(rangeObj, "$НаимДОО$", students(19, studentsCounter))
            replaceTextInWordApp(rangeObj, "$НомерСвид$", students(16, studentsCounter))
            replaceTextInWordApp(rangeObj, "$ДКонец$", students(18, studentsCounter))
            replaceTextInWordApp(rangeObj, "$ДатаВ$", students(17, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Квалификация$", students(20, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Часы$", students(21, studentsCounter))
            replaceTextInWordApp(rangeObj, "$ДНачало$", students(22, studentsCounter))
            replaceTextInWordApp(rangeObj, "$Программа$", students(23, studentsCounter))

        Next

        WordApp.Visible = True
        wordDok.Save
    End Sub

    Sub secondTableSample(table As Object, program As Object, samplePath As String)

        Dim rowCounter, entryCounter, numberRow As Integer
        Dim coordinates, label, value
        ReDim label(3)

        numberRow = НомерСтрокиТаблицыПоМеткеПереборомЯчеекСтолбцаИли11111(table, "$НачалоСписка$", 2)
        label(0) = "$Номер$"
        label(1) = "$НачалоСписка$"
        label(2) = "$ЧасыМ$"
        label(3) = "$ОценкаМ$"

        coordinates = НомерЯчейкиТаблицыПоМеткеПереборомВсехЯчеекИли11111(table, label)
        value = table.Cell(7, 1).Range.Text
        numberRow = coordinates(1, 1)

        For Счетчик = 0 To UBound(coordinates, 2)
            If IsNothing(coordinates(1, Счетчик)) Then
                Warning.content.Text = "В Таблице2 не обнаружены метка" & coordinates(0, Счетчик) & ". Путь к шаблону: " & samplePath
                openForm(Warning)
                Exit Sub
            End If
        Next
        rowCounter = 0
        entryCounter = UBound(program, 2)

        While rowCounter <= UBound(program, 2)
            If Not program(0, rowCounter).ToString = "" Then

                If rowCounter + numberRow > table.Rows.Count Then

                    table.Rows.add

                End If

                If BuildOrder.CheckBox1.Checked And program(0, rowCounter) = "Практическая подготовка" Then

                    table.Cell(rowCounter + numberRow, coordinates(2, 0)).Range.text = rowCounter + 1 & "."
                    table.Cell(rowCounter + numberRow, coordinates(2, 1)).Range.text = program(0, rowCounter)
                    table.Cell(rowCounter + numberRow, coordinates(2, 2)).Range.text = BuildOrder.ПрактическаяПодготовка.Text
                    table.Cell(rowCounter + numberRow, coordinates(2, 3)).Range.text = "$Модуль" & rowCounter + 1 & "$" '"$ПП$"
                ElseIf BuildOrder.CheckBox1.Checked And program(0, rowCounter) = "Итоговая аттестация" Then

                    table.Cell(rowCounter + numberRow, coordinates(2, 0)).Range.text = rowCounter + 1 & "."
                    table.Cell(rowCounter + numberRow, coordinates(2, 1)).Range.text = program(0, rowCounter)
                    table.Cell(rowCounter + numberRow, coordinates(2, 2)).Range.text = BuildOrder.ИтоговаяАттестация.Text
                    table.Cell(rowCounter + numberRow, coordinates(2, 3)).Range.text = "$Модуль" & rowCounter + 1 & "$" '"$ИА$"
                Else

                    table.Cell(rowCounter + numberRow, coordinates(2, 0)).Range.text = rowCounter + 1 & "."
                    If program(0, rowCounter) = "Практическая подготовка" Then

                        table.Cell(rowCounter + numberRow, coordinates(2, 1)).Range.text = program(0, rowCounter)
                        table.Cell(rowCounter + numberRow, coordinates(2, 3)).Range.text = "$Модуль" & rowCounter + 1 & "$" '"$ПП$"
                    ElseIf program(0, rowCounter) = "Итоговая аттестация" Then

                        table.Cell(rowCounter + numberRow, coordinates(2, 1)).Range.text = program(0, rowCounter)
                        table.Cell(rowCounter + numberRow, coordinates(2, 3)).Range.text = "$Модуль" & rowCounter + 1 & "$" '"$ИА$"

                    Else table.Cell(rowCounter + numberRow, coordinates(2, 1)).Range.text = "Модуль " & rowCounter + 1 & " «" & program(0, rowCounter) & "»"
                        table.Cell(rowCounter + numberRow, coordinates(2, 3)).Range.text = "$Модуль" & rowCounter + 1 & "$"
                    End If

                    If Not program(rowCounter, 1).ToString = "нет записей" Then

                        table.Cell(rowCounter + numberRow, coordinates(2, 2)).Range.text = program(1, rowCounter)

                    Else

                        Warning.content.Text = "Для модуля «" & program(0, rowCounter) & "» не указано количество часов"
                        openForm(Warning)

                    End If

                End If


            ElseIf rowCounter > 0 Then

                Exit While

            Else

                Warning.content.Text = "Для программы «" & program(4, 0) & "» не указан модуль 1. Приложение сформировано некорректно!!!"
                openForm(Warning)
                Exit While

            End If

            rowCounter = rowCounter + 1

        End While

        If rowCounter + numberRow > table.Rows.Count Then

            table.Rows.add

        End If

        table.Cell(rowCounter + numberRow, coordinates(2, 1)).Range.text = "Итого"
        table.Cell(rowCounter + numberRow, coordinates(2, 2)).Range.text = program(5, 0)
    End Sub
End Module
