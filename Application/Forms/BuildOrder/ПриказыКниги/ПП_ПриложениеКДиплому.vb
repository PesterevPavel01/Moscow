Imports System.Threading
Imports Microsoft.Office.Interop.Word

Module ПП_ПриложениеКДиплому

    Dim SC As SynchronizationContext

    Dim readyBackSide As Boolean = False
    Sub ПП_ПриложениеКДиплому(argument As OrderArgument)

        Dim secondThread As Thread

        Dim wordApp
        Dim wordDoc, location, range
        Dim group, students
        Dim number As Long
        Dim sqlQuery As String, resourcesPath, samplePath As String
        Dim params
        ReDim params(6)
        params(2) = argument.groupNumber
        params(3) = argument.manualMode
        params(4) = argument.practical
        params(5) = argument.gradesIA
        params(6) = argument

        sqlQuery = prilDiplomLoadData(argument.orderIdGroup)
        students = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)
        SC = SynchronizationContext.Current
        If students(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        sqlQuery = selectMassForPrilDiplom(argument.orderIdGroup)
        group = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If group(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If Not group(9, 0) = "профессиональная переподготовка" Then
            Warning.content.Text = "Уровень квалификации группы: " & group(9, 0)
            Warning.ShowDialog()
            Exit Sub
        End If

        Try
            number = group(6, 0)
        Catch ex As Exception
            Warning.content.Text = "В выбранной группе номер диплома не указан или не является числом"
            openForm(Warning)
            Exit Sub
        End Try

        resourcesPath = startApp.resourcesPath
        samplePath = resourcesPath & "Шаблоны\ПК_Окончание\ПП_ПриложениеКДиплому.docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, argument.orderType, resourcesPath, "Приложение", argument.mySqlConnector)

        params(0) = students
        params(1) = group

        secondThread = New Thread(AddressOf createBackSide)
        secondThread.IsBackground = True
        secondThread.Start(params)

        wordApp.DisplayAlerts = False
        'wordApp.Visible = True

        replaceTextInWordApp(wordDoc.Range, "$ДКонец$", students(18, 0))
        replaceTextInWordApp(wordDoc.Range, "$ДатаВ$", students(17, 0))
        replaceTextInWordApp(wordDoc.Range, "$Квалификация$", students(20, 0))
        replaceTextInWordApp(wordDoc.Range, "$Часы$", students(21, 0))
        replaceTextInWordApp(wordDoc.Range, "$ДНачало$", students(22, 0))
        replaceTextInWordApp(wordDoc.Range, "$Программа$", students(23, 0))
        replaceTextInWordApp(wordDoc.Range, "$Специальность$", students(24, 0))
        replaceTextInWordApp(wordDoc.Range, "$ДНачалоДень$", DateAndTime.Day(students(22, 0)))
        replaceTextInWordApp(wordDoc.Range, "$ДНачалоМесяц$", month(DateAndTime.Month(students(22, 0))))
        replaceTextInWordApp(wordDoc.Range, "$ДНачалоГод$", DateAndTime.Year(students(22, 0)))
        replaceTextInWordApp(wordDoc.Range, "$Таблица2$", "")

        replaceTextInWordApp(wordDoc.Range, "$ДКонецДень$", DateAndTime.Day(students(18, 0)))
        replaceTextInWordApp(wordDoc.Range, "$ДКонецМесяц$", month(DateAndTime.Month(students(18, 0))))
        replaceTextInWordApp(wordDoc.Range, "$ДКонецГод$", DateAndTime.Year(students(18, 0)))

        ReDim location(1, UBound(students, 2))
        location(0, 0) = 1
        location(1, 0) = wordDoc.Paragraphs.Count

        range = wordDoc.Paragraphs(1).Range
        range.SetRange(Start:=range.Start,
        End:=wordDoc.Paragraphs(location(1, 0)).Range.End)
        range.Copy

        For счетчикСлушателей = 1 To UBound(students, 2)

            '    location(0, счетчикСлушателей) = wordDoc.Paragraphs().Count - 1

            wordDoc.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
            wordDoc.Bookmarks("\EndOfDoc").Range.Delete
            '    location(1, счетчикСлушателей) = wordDoc.Paragraphs.Count
        Next

        For счетчикСлушателей = 0 To UBound(students, 2)
            'range.SetRange(Start:=range.Start,
            '                     End:=wordDoc.Paragraphs(location(1, счетчикСлушателей)).Range.End)
            replaceTextInWordApp(wordDoc.Range, "$Фамилия$", students(0, счетчикСлушателей), WdReplace.wdReplaceOne)
            replaceTextInWordApp(wordDoc.Range, "$Имя$", students(1, счетчикСлушателей), WdReplace.wdReplaceOne)
            replaceTextInWordApp(wordDoc.Range, "$Отчество$", students(2, счетчикСлушателей), WdReplace.wdReplaceOne)
            replaceTextInWordApp(wordDoc.Range, "$НаимДОО$", students(19, счетчикСлушателей), WdReplace.wdReplaceOne)
            replaceTextInWordApp(wordDoc.Range, "$НомерДиплома$", students(16, счетчикСлушателей), WdReplace.wdReplaceOne)
        Next

        wordApp.Visible = True
        wordDoc.Save

        While readyBackSide = False
            Thread.Sleep(50)
        End While

        readyBackSide = False

    End Sub

    Function createBackSide(params As Object) As Object
        Dim result
        Dim argument As OrderArgument = params(6)
        Dim wordDoc, wordApp, table, location, range
        Dim group, student
        Dim resourcePath, samplePath As String
        ReDim result(1)
        createBackSide = "Ошибка"
        student = params(0)
        group = params(1)

        resourcePath = startApp.resourcesPath
        samplePath = resourcePath & "Шаблоны\ПК_Окончание\ПП_ПриложениеКДипломуОбратнаяСторона.docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        If _technical.СоздатьПапку(resourcePath & "Группы\Группа N" & argument.groupNumber & "\Приказы") Then
            _technical.сохранить(wordDoc, "ПриложениеДипломОбратнаяСторона", resourcePath & "Группы\Группа N" & argument.groupNumber & "\Приказы\")
        Else
            _technical.сохранить(wordDoc, "ПриложениеДипломОбратнаяСторона", resourcePath & "Группы\Нераспределенное\")
        End If

        wordApp.DisplayAlerts = False
        'ПриложениеВорд.Visible = True

        table = НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc, "$Таблица2$", 1, 1)

        Try
            If table(0, 0).ToString = "не найдена" Then
                wordApp.Visible = True
                sendReady(True)
                SC.Send(AddressOf openWarning, "Обратная сторона не сформирована!!Не найдена таблица с меткой $Таблица2$ в ячейке (1,1). Путь к шаблону: " & samplePath)
                Exit Function
            End If
        Catch ex As Exception

        End Try

        ШаблонТаблицыN2(table, group, samplePath, params(3), params(4), params(5))

        replaceTextInWordApp(wordDoc.Range, "$Часы$", student(21, 0))
        replaceTextInWordApp(wordDoc.Range, "$Таблица2$", "")

        ReDim location(1, UBound(student, 2))
        location(0, 0) = 1
        location(1, 0) = wordDoc.Paragraphs.Count

        range = wordDoc.Paragraphs(1).Range
        range.SetRange(Start:=range.Start,
        End:=wordDoc.Paragraphs(location(1, 0)).Range.End)
        range.Copy

        For счетчикСлушателей = 1 To UBound(student, 2)

            wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

            location(0, счетчикСлушателей) = wordDoc.Paragraphs().Count - 1

            wordDoc.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
            wordDoc.Bookmarks("\EndOfDoc").Range.Delete
            location(1, счетчикСлушателей) = wordDoc.Paragraphs.Count
        Next

        For счетчикСлушателей = 0 To UBound(student, 2)
            range = wordDoc.Paragraphs(location(0, счетчикСлушателей)).Range
            range.SetRange(Start:=range.Start,
                                 End:=wordDoc.Paragraphs(location(1, счетчикСлушателей)).Range.End)
            replaceTextInWordApp(range, "$Модуль1$", student(4, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль2$", student(5, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль3$", student(6, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль4$", student(7, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль5$", student(8, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль6$", student(9, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль7$", student(10, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль8$", student(11, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль9$", student(12, счетчикСлушателей))
            replaceTextInWordApp(range, "$Модуль10$", student(13, счетчикСлушателей))
            replaceTextInWordApp(range, "$ПП$", student(14, счетчикСлушателей))
            replaceTextInWordApp(range, "$ИА$", student(15, счетчикСлушателей))
            replaceTextInWordApp(range, "$Фамилия$", student(0, счетчикСлушателей))
            replaceTextInWordApp(range, "$Имя$", student(1, счетчикСлушателей))
            replaceTextInWordApp(range, "$Отчество$", student(2, счетчикСлушателей))
            replaceTextInWordApp(range, "$НаимДОО$", student(19, счетчикСлушателей))
            replaceTextInWordApp(range, "$НомерДиплома$", student(16, счетчикСлушателей))
        Next
        wordApp.Visible = True
        wordDoc.Save
        sendReady(True)
        createBackSide = "Готово"

    End Function
    Sub sendReady(status As Boolean)
        readyBackSide = status
    End Sub

    Sub openWarning(content As String)
        Warning.content.Text = content
        openForm(Warning)
    End Sub


    Sub ШаблонТаблицыN2(Таблица As Object, Программа As Object, ПутьКШаблону As String, СтатусЧекбокса As Boolean, ЧасыПП As String, ЧасаИА As String)

        Dim счетчикСтрок, СчетчикЗаписей, НомерСтроки As Integer
        Dim Координаты, Метка, Значение
        ReDim Метка(3)

        НомерСтроки = НомерСтрокиТаблицыПоМеткеПереборомЯчеекСтолбцаИли11111(Таблица, "$НачалоСпискаМодуль$", 2)
        Метка(0) = "$Таблица2$"
        Метка(1) = "$НачалоСпискаМодуль$"
        Метка(2) = "$ЧасыМ$"
        Метка(3) = "$ОценкаМ$"

        Координаты = НомерЯчейкиТаблицыПоМеткеПереборомВсехЯчеекИли11111(Таблица, Метка)
        Значение = Таблица.Cell(7, 1).Range.Text
        НомерСтроки = Координаты(1, 1)

        For Счетчик = 0 To UBound(Координаты, 2)
            If IsNothing(Координаты(1, Счетчик)) Then
                SC.Send(AddressOf openWarning, "В Таблице2 не обнаружены метка" & Координаты(0, Счетчик) & ". Путь к шаблону: " & ПутьКШаблону)
                Exit Sub
            End If
        Next
        счетчикСтрок = 0
        СчетчикЗаписей = UBound(Программа, 2)

        While счетчикСтрок <= UBound(Программа, 2)
            If Not Программа(0, счетчикСтрок).ToString = "" Then

                If счетчикСтрок + НомерСтроки > Таблица.Rows.Count Then

                    Таблица.Rows.add

                End If

                If СтатусЧекбокса And Программа(0, счетчикСтрок) = "Производственная практика" Then

                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 0)).Range.text = счетчикСтрок + 1 & "."
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = ЧасыПП
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ПП$"

                ElseIf СтатусЧекбокса And Программа(0, счетчикСтрок) = "Итоговая аттестация" Then

                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 0)).Range.text = счетчикСтрок + 1 & "."
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = ЧасаИА
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ИА$"
                Else

                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 0)).Range.text = счетчикСтрок + 1 & "."
                    If Программа(0, счетчикСтрок) = "Производственная практика" Then

                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ПП$"

                    ElseIf Программа(0, счетчикСтрок) = "Итоговая аттестация" Then

                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ИА$"

                    ElseIf Программа(0, счетчикСтрок) = "Практическая подготовка" Then

                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$"

                    Else Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = "УМ " & счетчикСтрок + 1 & " «" & Программа(0, счетчикСтрок) & "»"
                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$"
                    End If

                    If Not Программа(счетчикСтрок, 1).ToString = "нет записей" Then

                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = Программа(1, счетчикСтрок)

                    Else

                        Warning.content.Text = "Для модуля «" & Программа(0, счетчикСтрок) & "» не указано количество часов"
                        openForm(Warning)

                    End If

                End If


            ElseIf счетчикСтрок > 0 Then

                Exit While

            Else
                SC.Send(AddressOf openWarning, "Для программы «" & Программа(4, 0) & "» не указан модуль 1. Приложение сформировано некорректно!!!")
                Exit While

            End If

            счетчикСтрок = счетчикСтрок + 1

        End While

        If счетчикСтрок + НомерСтроки > Таблица.Rows.Count Then

            Таблица.Rows.add

        End If

        'Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = "Итого"
        'Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = Программа(5, 0)
    End Sub
End Module
