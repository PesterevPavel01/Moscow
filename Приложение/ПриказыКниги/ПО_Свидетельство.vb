﻿Module ПО_Свидетельство
    Sub po_svid(видПриказа As String)

        Dim WordApp
        Dim wordDok, table, Координаты, rangeObj
        Dim group, students
        Dim number As Int64
        Dim queryString As String, resorsesPath, ПутьКШаблону As String

        queryString = poSvid__loadListSvid(ААОсновная.prikazKodGroup)
        students = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        If students(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        queryString = selectMassForPrilSvidetelstvo(ААОсновная.prikazKodGroup)
        group = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        If group(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        Try
            number = group(7, 0)
        Catch ex As Exception
            предупреждение.текст.Text = "В выбранной группе номер свидетельства не указан или не является числом"
            ОткрытьФорму(предупреждение)
            Exit Sub
        End Try

        resorsesPath = Запуск.ПутьКФайлуRes
        ПутьКШаблону = resorsesPath & "Шаблоны\ПК_Окончание\Таблицы_ПО_Св-во.docx"

        WordApp = CreateObject("Word.Application")

        wordDok = WordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        Вспомогательный.savePrikazBlank(wordDok, ААОсновная.prikazKodGroup, видПриказа, resorsesPath, "Приказы")

        'If Вспомогательный.СоздатьПапку(ПутьККаталогуСРесурсами & "Группы\Группа N" & АСформироватьПриказ.НомерГруппы.Text & "\Приказы") Then
        '    Вспомогательный.сохранить(ДокументВорд, видПриказа, ПутьККаталогуСРесурсами & "Группы\Группа N" & АСформироватьПриказ.НомерГруппы.Text & "\Приказы\")
        'Else
        '    Вспомогательный.сохранить(ДокументВорд, видПриказа, ПутьККаталогуСРесурсами & "Группы\Нераспределенное\")
        'End If

        WordApp.DisplayAlerts = False
        ' ПриложениеВорд.Visible = True

        table = НайтиТаблицуПоМеткеИлиНеНайдена(wordDok, "$Таблица2$", 1, 1)

        Try
            If table(0, 0).ToString = "не найдена" Then
                предупреждение.текст.Text = "Не найдена таблица с меткой $Таблица2$ в ячейке (1,1). Путь к шаблону: " & ПутьКШаблону
                ОткрытьФорму(предупреждение)
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        ШаблонТаблицыN2(table, group, ПутьКШаблону)

        ReDim Координаты(1, UBound(students, 2))
        Координаты(0, 0) = 1
        Координаты(1, 0) = wordDok.Paragraphs.Count

        For счетчикСлушателей = 1 To UBound(students, 2)

            wordDok.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

            Координаты(0, счетчикСлушателей) = wordDok.Paragraphs().Count - 1

            rangeObj = wordDok.Paragraphs(1).Range
            rangeObj.SetRange(Start:=rangeObj.Start,
                                 End:=wordDok.Paragraphs(Координаты(1, 0)).Range.End)
            rangeObj.Copy
            wordDok.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
            wordDok.Bookmarks("\EndOfDoc").Range.Delete
            Координаты(1, счетчикСлушателей) = wordDok.Paragraphs.Count
        Next
        For счетчикСлушателей = 0 To UBound(students, 2)
            rangeObj = wordDok.Paragraphs(Координаты(0, счетчикСлушателей)).Range
            rangeObj.SetRange(Start:=rangeObj.Start,
                                 End:=wordDok.Paragraphs(Координаты(1, счетчикСлушателей)).Range.End)
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Таблица2$", "")
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль1$", students(4, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль2$", students(5, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль3$", students(6, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль4$", students(7, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль5$", students(8, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль6$", students(9, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль7$", students(10, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль8$", students(11, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль9$", students(12, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Модуль10$", students(13, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$ПП$", students(14, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$ИА$", students(15, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Фамилия$", students(0, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Имя$", students(1, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Отчество$", students(2, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$ДатаРождения$", students(3, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$НаимДОО$", students(19, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$НомерСвид$", students(16, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$ДКонец$", students(18, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$ДатаВ$", students(17, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Квалификация$", students(20, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Часы$", students(21, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$ДНачало$", students(22, счетчикСлушателей))
            ЗаменитьТекстВДокументеВорд(rangeObj, "$Программа$", students(23, счетчикСлушателей))

        Next
        WordApp.Visible = True
        wordDok.Save
    End Sub

    Sub ШаблонТаблицыN2(Таблица As Object, Программа As Object, ПутьКШаблону As String)

        Dim счетчикСтрок, СчетчикЗаписей, НомерСтроки As Integer
        Dim Координаты, Метка, Значение
        ReDim Метка(3)

        НомерСтроки = НомерСтрокиТаблицыПоМеткеПереборомЯчеекСтолбцаИли11111(Таблица, "$НачалоСписка$", 2)
        Метка(0) = "$Номер$"
        Метка(1) = "$НачалоСписка$"
        Метка(2) = "$ЧасыМ$"
        Метка(3) = "$ОценкаМ$"

        Координаты = НомерЯчейкиТаблицыПоМеткеПереборомВсехЯчеекИли11111(Таблица, Метка)
        Значение = Таблица.Cell(7, 1).Range.Text
        НомерСтроки = Координаты(1, 1)

        For Счетчик = 0 To UBound(Координаты, 2)
            If IsNothing(Координаты(1, Счетчик)) Then
                предупреждение.текст.Text = "В Таблице2 не обнаружены метка" & Координаты(0, Счетчик) & ". Путь к шаблону: " & ПутьКШаблону
                ОткрытьФорму(предупреждение)
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

                If АСформироватьПриказ.CheckBox1.Checked And Программа(0, счетчикСтрок) = "Практическая подготовка" Then

                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 0)).Range.text = счетчикСтрок + 1 & "."
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = АСформироватьПриказ.ПрактическаяПодготовка.Text
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ПП$"
                ElseIf АСформироватьПриказ.CheckBox1.Checked And Программа(0, счетчикСтрок) = "Итоговая аттестация" Then

                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 0)).Range.text = счетчикСтрок + 1 & "."
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = АСформироватьПриказ.ИтоговаяАттестация.Text
                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ИА$"
                Else

                    Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 0)).Range.text = счетчикСтрок + 1 & "."
                    If Программа(0, счетчикСтрок) = "Практическая подготовка" Then

                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ПП$"
                    ElseIf Программа(0, счетчикСтрок) = "Итоговая аттестация" Then

                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = Программа(0, счетчикСтрок)
                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$" '"$ИА$"

                    Else Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = "Модуль " & счетчикСтрок + 1 & " «" & Программа(0, счетчикСтрок) & "»"
                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 3)).Range.text = "$Модуль" & счетчикСтрок + 1 & "$"
                    End If

                    If Not Программа(счетчикСтрок, 1).ToString = "нет записей" Then

                        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = Программа(1, счетчикСтрок)

                    Else

                        предупреждение.текст.Text = "Для модуля «" & Программа(0, счетчикСтрок) & "» не указано количество часов"
                        ОткрытьФорму(предупреждение)

                    End If

                End If


            ElseIf счетчикСтрок > 0 Then

                Exit While

            Else

                предупреждение.текст.Text = "Для программы «" & Программа(4, 0) & "» не указан модуль 1. Приложение сформировано некорректно!!!"
                ОткрытьФорму(предупреждение)
                Exit While

            End If

            счетчикСтрок = счетчикСтрок + 1

        End While

        If счетчикСтрок + НомерСтроки > Таблица.Rows.Count Then

            Таблица.Rows.add

        End If

        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 1)).Range.text = "Итого"
        Таблица.Cell(счетчикСтрок + НомерСтроки, Координаты(2, 2)).Range.text = Программа(5, 0)
    End Sub
End Module
