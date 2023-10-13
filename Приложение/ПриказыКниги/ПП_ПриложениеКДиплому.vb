Imports System.Threading
Module ПП_ПриложениеКДиплому
    Dim SC As SynchronizationContext

    Dim ГотовностьОбратнойСтороны As Boolean = False
    Sub ПП_ПриложениеКДиплому(видПриказа As String)

        Dim ВторойПоток As Thread

        Dim ПриложениеВорд
        Dim ДокументВорд, Координаты, Область
        Dim Группа, слушатели
        Dim Число As Long
        Dim sqlQuery As String, ПутьККаталогуСРесурсами, ПутьКШаблону As String
        Dim Параметр
        ReDim Параметр(5)
        Параметр(2) = BuildOrder.groupNumber.Text
        Параметр(3) = BuildOrder.CheckBox1.Checked
        Параметр(4) = BuildOrder.ПрактическаяПодготовка.Text
        Параметр(5) = BuildOrder.ИтоговаяАттестация.Text

        sqlQuery = prilDiplomLoadData(MainForm.orderIdGroup)
        слушатели = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)
        SC = SynchronizationContext.Current
        If слушатели(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        sqlQuery = selectMassForPrilDiplom(MainForm.orderIdGroup)
        Группа = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If Группа(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If Not Группа(9, 0) = "профессиональная переподготовка" Then
            Warning.content.Text = "Уровень квалификации группы: " & Группа(9, 0)
            Warning.ShowDialog()
            Exit Sub
        End If

        Try
            Число = Группа(6, 0)
        Catch ex As Exception
            Warning.content.Text = "В выбранной группе номер диплома не указан или не является числом"
            openForm(Warning)
            Exit Sub
        End Try

        ПутьККаталогуСРесурсами = startApp.resourcesPath
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\ПК_Окончание\ПП_ПриложениеКДиплому.docx"

        ПриложениеВорд = CreateObject("Word.Application")

        ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        _technical.savePrikazBlank(ДокументВорд, MainForm.orderIdGroup, видПриказа, ПутьККаталогуСРесурсами, "Приложение")

        Параметр(0) = слушатели
        Параметр(1) = Группа

        ВторойПоток = New Thread(AddressOf ОбработкаОбратнойСтороны)
        ВторойПоток.IsBackground = True
        ВторойПоток.Start(Параметр)

        ПриложениеВорд.DisplayAlerts = False
        'ПриложениеВорд.Visible = True

        replaceTextInWordApp(ДокументВорд.Range, "$ДКонец$", слушатели(18, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$ДатаВ$", слушатели(17, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$Квалификация$", слушатели(20, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$Часы$", слушатели(21, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$ДНачало$", слушатели(22, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$Программа$", слушатели(23, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$Специальность$", слушатели(24, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$ДНачалоДень$", DateAndTime.Day(слушатели(22, 0)))
        replaceTextInWordApp(ДокументВорд.Range, "$ДНачалоМесяц$", month(DateAndTime.Month(слушатели(22, 0))))
        replaceTextInWordApp(ДокументВорд.Range, "$ДНачалоГод$", DateAndTime.Year(слушатели(22, 0)))
        replaceTextInWordApp(ДокументВорд.Range, "$Таблица2$", "")

        replaceTextInWordApp(ДокументВорд.Range, "$ДКонецДень$", DateAndTime.Day(слушатели(18, 0)))
        replaceTextInWordApp(ДокументВорд.Range, "$ДКонецМесяц$", month(DateAndTime.Month(слушатели(18, 0))))
        replaceTextInWordApp(ДокументВорд.Range, "$ДКонецГод$", DateAndTime.Year(слушатели(18, 0)))

        ReDim Координаты(1, UBound(слушатели, 2))
        Координаты(0, 0) = 1
        Координаты(1, 0) = ДокументВорд.Paragraphs.Count

        Область = ДокументВорд.Paragraphs(1).Range
        Область.SetRange(Start:=Область.Start,
        End:=ДокументВорд.Paragraphs(Координаты(1, 0)).Range.End)
        Область.Copy

        For счетчикСлушателей = 1 To UBound(слушатели, 2)

            Координаты(0, счетчикСлушателей) = ДокументВорд.Paragraphs().Count - 1

            ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
            ДокументВорд.Bookmarks("\EndOfDoc").Range.Delete
            Координаты(1, счетчикСлушателей) = ДокументВорд.Paragraphs.Count
        Next

        For счетчикСлушателей = 0 To UBound(слушатели, 2)
            Область = ДокументВорд.Paragraphs(Координаты(0, счетчикСлушателей)).Range
            Область.SetRange(Start:=Область.Start,
                                 End:=ДокументВорд.Paragraphs(Координаты(1, счетчикСлушателей)).Range.End)

            replaceTextInWordApp(Область, "$Фамилия$", слушатели(0, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Имя$", слушатели(1, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Отчество$", слушатели(2, счетчикСлушателей))
            replaceTextInWordApp(Область, "$НаимДОО$", слушатели(19, счетчикСлушателей))
            replaceTextInWordApp(Область, "$НомерДиплома$", слушатели(16, счетчикСлушателей))
        Next

        ПриложениеВорд.Visible = True
        ДокументВорд.Save

        While ГотовностьОбратнойСтороны = False
            Thread.Sleep(50)
        End While

        ГотовностьОбратнойСтороны = False

    End Sub

    Function ОбработкаОбратнойСтороны(Параметр As Object) As Object
        Dim Результат
        Dim ДокументВорд, ПриложениеВорд, Таблица, Координаты, Область
        Dim Группа, слушатели
        Dim ПутьККаталогуСРесурсами, ПутьКШаблону As String
        ReDim Результат(1)
        ОбработкаОбратнойСтороны = "Ошибка"
        слушатели = Параметр(0)
        Группа = Параметр(1)

        ПутьККаталогуСРесурсами = startApp.resourcesPath
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\ПК_Окончание\ПП_ПриложениеКДипломуОбратнаяСторона.docx"

        ПриложениеВорд = CreateObject("Word.Application")

        ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        If _technical.СоздатьПапку(ПутьККаталогуСРесурсами & "Группы\Группа N" & BuildOrder.groupNumber.Text & "\Приказы") Then
            _technical.сохранить(ДокументВорд, "ПриложениеДипломОбратнаяСторона", ПутьККаталогуСРесурсами & "Группы\Группа N" & BuildOrder.groupNumber.Text & "\Приказы\")
        Else
            _technical.сохранить(ДокументВорд, "ПриложениеДипломОбратнаяСторона", ПутьККаталогуСРесурсами & "Группы\Нераспределенное\")
        End If

        ПриложениеВорд.DisplayAlerts = False
        'ПриложениеВорд.Visible = True

        Таблица = НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, "$Таблица2$", 1, 1)

        Try
            If Таблица(0, 0).ToString = "не найдена" Then
                ПриложениеВорд.Visible = True
                sendReady(True)
                SC.Send(AddressOf openWarning, "Обратная сторона не сформирована!!Не найдена таблица с меткой $Таблица2$ в ячейке (1,1). Путь к шаблону: " & ПутьКШаблону)
                Exit Function
            End If
        Catch ex As Exception

        End Try

        ШаблонТаблицыN2(Таблица, Группа, ПутьКШаблону, Параметр(3), Параметр(4), Параметр(5))

        replaceTextInWordApp(ДокументВорд.Range, "$Часы$", слушатели(21, 0))
        replaceTextInWordApp(ДокументВорд.Range, "$Таблица2$", "")

        ReDim Координаты(1, UBound(слушатели, 2))
        Координаты(0, 0) = 1
        Координаты(1, 0) = ДокументВорд.Paragraphs.Count

        Область = ДокументВорд.Paragraphs(1).Range
        Область.SetRange(Start:=Область.Start,
        End:=ДокументВорд.Paragraphs(Координаты(1, 0)).Range.End)
        Область.Copy

        For счетчикСлушателей = 1 To UBound(слушатели, 2)

            ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

            Координаты(0, счетчикСлушателей) = ДокументВорд.Paragraphs().Count - 1

            ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
            ДокументВорд.Bookmarks("\EndOfDoc").Range.Delete
            Координаты(1, счетчикСлушателей) = ДокументВорд.Paragraphs.Count
        Next

        For счетчикСлушателей = 0 To UBound(слушатели, 2)
            Область = ДокументВорд.Paragraphs(Координаты(0, счетчикСлушателей)).Range
            Область.SetRange(Start:=Область.Start,
                                 End:=ДокументВорд.Paragraphs(Координаты(1, счетчикСлушателей)).Range.End)
            replaceTextInWordApp(Область, "$Модуль1$", слушатели(4, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль2$", слушатели(5, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль3$", слушатели(6, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль4$", слушатели(7, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль5$", слушатели(8, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль6$", слушатели(9, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль7$", слушатели(10, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль8$", слушатели(11, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль9$", слушатели(12, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Модуль10$", слушатели(13, счетчикСлушателей))
            replaceTextInWordApp(Область, "$ПП$", слушатели(14, счетчикСлушателей))
            replaceTextInWordApp(Область, "$ИА$", слушатели(15, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Фамилия$", слушатели(0, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Имя$", слушатели(1, счетчикСлушателей))
            replaceTextInWordApp(Область, "$Отчество$", слушатели(2, счетчикСлушателей))
            replaceTextInWordApp(Область, "$НаимДОО$", слушатели(19, счетчикСлушателей))
            replaceTextInWordApp(Область, "$НомерДиплома$", слушатели(16, счетчикСлушателей))
        Next
        ПриложениеВорд.Visible = True
        ДокументВорд.Save
        sendReady(True)
        ОбработкаОбратнойСтороны = "Готово"

    End Function
    Sub sendReady(статус As Boolean)
        ГотовностьОбратнойСтороны = статус
    End Sub

    Sub openWarning(текст As String)
        Warning.content.Text = текст
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
