Module Module2
    Sub ПриказСтаж_ДопускКИА(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Tabl, Слушатели
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer, Счетчик As Integer, строкДоСтраницы2 As Integer, ТекущаяСтраница As Integer, ПроверкаСтраницы As Integer
        Dim Дата As String, СтрокаЗапроса As String, Слушатель As String, ПП_Стажировка As String

        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add
        'MSWord.Visible = True

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас, Финансирование FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)


        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub



        первыйПункт = "О допуске слушателей "
        второйПункт = "к итоговой аттестации"
        третийПункт = "В соответствии с Положением о  повышении квалификации специалистов с медицинским и фармацевтическим образованием ФГБУ ДПО ВУНМЦ Минздрава России, утверждённым 21.06.2019"
        четвертыйПункт = "1. Допустить к итоговой аттестации следующих слушателей группы № «" & АСформироватьПриказ.НомерГруппы.Text & "», аттестованных по всем модулям и успешно прошедших производственную практику, полностью выполнивших учебный план:"
        пятыйПункт = "0"


        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)

        Слушатели = АПриказ.СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)


        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(Слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, Tabl, Слушатели)

        Tabl.Range.Select
        MSWord.Selection.Cut
        НомерАбзаца = DOK.Paragraphs.Count

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.Count
        DOK.Paragraphs(НомерАбзаца).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Утвердить аттестационную комиссию по дополнительной профессиональной программе повышения квалификации «" & Группа(2, 0) & "» в составе:", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьСоставКомиссии(MSWord, DOK, Дата, НомерАбзаца)


        ТекущаяСтраница = DOK.Range.Information(3)

        НомерАбзаца = DOK.Paragraphs.Count
        DOK.Paragraphs(НомерАбзаца).Range.Delete
        НомерАбзаца = НомерАбзаца - 1
        НомерАбзаца = вставитьСекретаряКомиссии(MSWord, DOK, Дата, НомерАбзаца)

        ПроверкаСтраницы = DOK.Range.Information(3)

        If ТекущаяСтраница = ПроверкаСтраницы Then


            строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
            НомерАбзаца = DOK.Paragraphs.Count

            If строкДоСтраницы2 <= 3 And строкДоСтраницы2 >= 0 Then

                DOK.Tables(4).Range.Select

                MSWord.Selection.Cut

                НомерАбзаца = DOK.Paragraphs.Count

                строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)

                While строкДоСтраницы2 + 1 > 0

                    НомерАбзаца = 1 + НомерАбзаца
                    Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                    строкДоСтраницы2 = строкДоСтраницы2 - 1
                End While

                DOK.Paragraphs(НомерАбзаца).Range.Select
                MSWord.Selection.PasteAndFormat(0)
                НомерАбзаца = DOK.Paragraphs.Count
            End If

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = 1 + НомерАбзаца

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = 1 + НомерАбзаца

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = DOK.Paragraphs.Count

        Else


            DOK.Tables(4).Range.Select

            MSWord.Selection.Cut

            НомерАбзаца = DOK.Paragraphs.Count
            строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)


            While строкДоСтраницы2 + 1 > 0

                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                строкДоСтраницы2 = строкДоСтраницы2 - 1
            End While
            DOK.Paragraphs(НомерАбзаца).Range.Select

            MSWord.Selection.PasteAndFormat(0)

            DOK.Bookmarks("\EndOfDoc").Select

            НомерАбзаца = DOK.Paragraphs.Count
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)


        End If

        НомерАбзаца = вставитьУтверждающего(MSWord, DOK, НомерАбзаца, видПриказа)

        НомерАбзаца = DOK.Paragraphs.Count
        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = вставитьЛистСогласования(MSWord, DOK, Дата, НомерАбзаца, видПриказа)

        DOK.Bookmarks("\EndOfDoc").Select


        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.Count


        Call вставитьКороткуюШапку(MSWord, DOK, НомерАбзаца)

        НомерАбзаца = DOK.Paragraphs.Count


        НомерАбзаца = DOK.Paragraphs.Count

        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 2, 0, 1, 0, False)


        Call вставитьПротоколСтаж(MSWord, DOK, Группа(2, 0).ToString, Группа)


        MSWord.Visible = True

        Call сохранить(DOK, видПриказа)

    End Sub


    Sub вставитьПротоколСтаж(MSWord As Object, DOK As Object, Программа As String, Группа As Object)

        Dim НомерАбзаца As Integer, НомерПротокола As Integer
        Dim Слушатели
        Dim Tabl
        Dim ТаблицаПодписиКомиссии
        Dim Дата As String

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.Count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Протокол №" & НомерПротокола, "Times New Roman", 14, 1, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "заседания аттестационной комиссии по рассмотрению результатов итоговых ", "Times New Roman", 14, 1, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "испытаний слушателей программы профессиональной переподготовки ", "Times New Roman", 14, 1, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Программа & " » ", "Times New Roman", 14, 1, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Left(Дата, 2) & "» " & month(Right(Left(Дата, 5), 2)) & " " & Right(Дата, 4), "Times New Roman", 14, 1, 0, 1, 0, False)

        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРИСУТСТВОВАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Председатель комиссии: " & перевернуть(АСформироватьПриказ.Ответственный.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Члены комиссии: " & перевернуть(АСформироватьПриказ.РуководительСтажировки.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия2.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия3.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Секретарь комиссии – " & перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "СЛУШАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "О результатах прохождения итоговой аттестации слушателей, обучавшихся в ФГБУ ДПО ВУНМЦ Минздрава России по дополнительной профессиональной программе профессиональной переподготовки «" & Программа & " » в объёме " & Группа(3, 0) & " час. в период с " & Группа(0, 0) & " по " & Группа(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "ПОСТАНОВИЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "О результатах прохождения итоговой аттестации слушателей, обучавшихся в ФГБУ ДПО ВУНМЦ Минздрава России по дополнительной профессиональной программе повышения квалификации «" & Программа & " » в объёме " & Группа(3, 0) & " учебных час. с " & Группа(0, 0) & " по " & Группа(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = 1 + НомерАбзаца

        Слушатели = МассивСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), UBound(Слушатели, 2) + 3, 5)

        Call НастройкаТаблицыПП(MSWord, DOK, Tabl, Слушатели)

        Tabl.Range.Select
        MSWord.Selection.Cut
        НомерАбзаца = НомерАбзаца + 1

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.Count
        DOK.Paragraphs(НомерАбзаца).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "2. Установить, что в результате обучения слушателями достигнуты запланированные дополнительной профессиональной программой цели.", "Times New Roman", 14, 3, 0, 1, 0, False)

        ТаблицаПодписиКомиссии = DOK.Tables.Add(DOK.Range(0, 0), 5, 2)

        Call НастройкаТаблицыПодписиКомиссии(DOK, ТаблицаПодписиКомиссии)

        ТаблицаПодписиКомиссии.Range.Select

        MSWord.Selection.Cut

        НомерАбзаца = DOK.Paragraphs.Count

        DOK.Paragraphs(НомерАбзаца).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)


    End Sub

End Module


