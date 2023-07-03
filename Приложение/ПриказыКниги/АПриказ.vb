Module АПриказ

    Sub ПриказСтаж_ДопускКИА(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Tabl, Слушатели
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer, строкДоСтраницы2 As Integer, ТекущаяСтраница As Integer, ПроверкаСтраницы As Integer
        Dim Дата As String, СтрокаЗапроса As String


        Слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

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
        четвертыйПункт = "1. Допустить к итоговой аттестации следующих слушателей группы № " & АСформироватьПриказ.НомерГруппы.Text & ", аттестованных по всем модулям и успешно прошедших производственную практику, полностью выполнивших учебный план:"
        пятыйПункт = "0"


        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)




        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(Слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, Tabl, Слушатели)

        Tabl.Range.Select
        MSWord.Selection.Cut

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = DOK.Paragraphs.Count
        DOK.Paragraphs(НомерАбзаца).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Утвердить аттестационную комиссию по дополнительной профессиональной программе повышения квалификации «" & Группа(2, 0) & "» в составе:", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
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


            строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
            НомерАбзаца = DOK.Paragraphs.Count

            If строкДоСтраницы2 <= 3 And строкДоСтраницы2 >= 0 Then

                DOK.Tables(4).Range.Select

                MSWord.Selection.Cut

                НомерАбзаца = DOK.Paragraphs.Count

                строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)

                While строкДоСтраницы2 + 1 > 0

                    DOK.Paragraphs.Add()
                    НомерАбзаца = DOK.Paragraphs.Count
                    Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                    строкДоСтраницы2 = строкДоСтраницы2 - 1
                End While

                DOK.Paragraphs(НомерАбзаца).Range.Select
                MSWord.Selection.PasteAndFormat(0)
                НомерАбзаца = DOK.Paragraphs.Count
            End If

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = 1 + НомерАбзаца
            DOK.Paragraphs.Add()

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = 1 + НомерАбзаца
            DOK.Paragraphs.Add()

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = DOK.Paragraphs.Count

        Else


            DOK.Tables(4).Range.Select

            MSWord.Selection.Cut

            НомерАбзаца = DOK.Paragraphs.Count
            строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)


            While строкДоСтраницы2 + 1 > 0

                DOK.Paragraphs.Add()
                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                строкДоСтраницы2 = строкДоСтраницы2 - 1

            End While

            DOK.Paragraphs(НомерАбзаца).Range.Select

            MSWord.Selection.PasteAndFormat(0)

            DOK.Bookmarks("\EndOfDoc").Select

            НомерАбзаца = DOK.Paragraphs.Count
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)


        End If

        НомерАбзаца = вставитьУтверждающего(MSWord, DOK, НомерАбзаца, видПриказа)

        НомерАбзаца = DOK.Paragraphs.Count
        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Bookmarks("\EndOfDoc").Select

        MSWord.Selection.InsertBreak(Type:=7)

        НомерАбзаца = вставитьЛистСогласования(MSWord, DOK, Дата, НомерАбзаца, видПриказа)

        DOK.Bookmarks("\EndOfDoc").Select

        MSWord.Selection.InsertBreak(Type:=7)

        НомерАбзаца = DOK.Paragraphs.Count


        Call вставитьКороткуюШапку(MSWord, DOK, НомерАбзаца)

        НомерАбзаца = DOK.Paragraphs.Count

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count

        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 2, 0, 1, 0, False)


        Call вставитьПротоколСтаж(MSWord, DOK, Группа(2, 0).ToString, Группа)


        MSWord.Visible = True

        Call сохранить(DOK, видПриказа)

    End Sub


    Sub вставитьПротоколСтаж(MSWord As Object, DOK As Object, Программа As String, Группа As Object)

        Dim НомерАбзаца As Integer, НомерПротокола
        Dim Слушатели
        Dim Tabl
        Dim ТаблицаПодписиКомиссии
        Dim Дата As String, строкаЗапроса As String

        строкаЗапроса = "SELECT НомерПротоколаИА FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)

        НомерПротокола = ЗагрузитьИзБазы.ЗагрузитьИзБазы(строкаЗапроса)

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString

        DOK.Bookmarks("\EndOfDoc").Select

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Протокол №" & НомерПротокола(0, 0), "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "заседания аттестационной комиссии по рассмотрению результатов итоговых ", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "испытаний слушателей программы повышения квалификации", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Программа & "» ", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Left(Дата, 2) & "» " & month(Right(Left(Дата, 5), 2)) & " " & Right(Дата, 4), "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРИСУТСТВОВАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Председатель комиссии: " & перевернуть(АСформироватьПриказ.Ответственный.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Члены комиссии: " & перевернуть(АСформироватьПриказ.РуководительСтажировки.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия2.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия3.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Секретарь комиссии – " & перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count
        Call ВставитьПараграф(DOK, НомерАбзаца, "СЛУШАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "О результатах прохождения итоговой аттестации слушателей, обучавшихся в ФГБУ ДПО ВУНМЦ Минздрава России по дополнительной профессиональной программе повышения квалификации «" & Программа & "» в объёме " & Группа(3, 0) & " час. в период с " & Группа(0, 0) & " по " & Группа(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "ПОСТАНОВИЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "1. Утвердить результаты итоговой аттестации слушателей дополнительной профессиональной программы повышения квалификации «" & Программа & "»", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца

        Слушатели = МассивСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), UBound(Слушатели, 2) + 3, 5)

        Call НастройкаТаблицыПП(MSWord, DOK, Tabl, Слушатели)

        Tabl.Range.Select
        MSWord.Selection.Cut

        DOK.Paragraphs.Add()
        НомерАбзаца = НомерАбзаца + 1

        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.Count
        DOK.Paragraphs(НомерАбзаца).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "2. Установить, что в результате обучения слушателями достигнуты запланированные дополнительной профессиональной программой цели.", "Times New Roman", 14, 3, 0, 1, 0, False)

        ТаблицаПодписиКомиссии = DOK.Tables.Add(DOK.Range(0, 0), 5, 2)

        Call НастройкаТаблицыПодписиКомиссии(DOK, ТаблицаПодписиКомиссии)

        ТаблицаПодписиКомиссии.Range.Select

        MSWord.Selection.Cut
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.Count

        DOK.Paragraphs(НомерАбзаца).Range.Select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)


    End Sub


    Sub КопироватьВставить(MSWord As Object, DOK As Object, НачальныйАбзац As Integer, КонечныйАбзац As Integer)

        Dim Начало, Конец

        Начало = DOK.Paragraphs(НачальныйАбзац).Range.Start
        Конец = DOK.Paragraphs(КонечныйАбзац).Range.End
        DOK.Range(Начало, Конец).Select
        MSWord.Selection.Copy

        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

    End Sub




    Sub ПриказПП_ДопускКИА(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Tabl, Слушатели
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer, строкДоСтраницы2 As Integer, ТекущаяСтраница As Integer, ПроверкаСтраницы As Integer
        Dim Дата As String, СтрокаЗапроса As String, ПП_Стажировка As String

        Слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If


        MSWord = CreateObject("Word.Application")

        If АСформироватьПриказ.CheckBoxММС.Checked = True Then
            ПП_Стажировка = "практическую подготовку"
        Else ПП_Стажировка = "стажировку"
        End If


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
        третийПункт = "В соответствии с Положением о порядке и условиях профессионального обучения в ФГБУ ДПО ВУНМЦ Минздрава России, утверждённым 21.06.2019"
        четвертыйПункт = "1. Допустить к итоговой аттестации следующих слушателей группы № " & АСформироватьПриказ.НомерГруппы.Text & ", аттестованных по всем дисциплинам, модулям и успешно прошедших аттестованных по всем модулям и успешно прошедших " & ПП_Стажировка & ", полностью выполнивших учебный план:"
        пятыйПункт = "0"


        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(Слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, Tabl, Слушатели)

        Tabl.Range.select
        MSWord.Selection.Cut
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Утвердить аттестационную комиссию по дополнительной профессиональной программе профессиональной переподготовки «" & Группа(2, 0) & "» в составе:", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьСоставКомиссииПП(MSWord, DOK, Дата, НомерАбзаца)


        ТекущаяСтраница = DOK.Range.Information(3)

        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.Delete
        НомерАбзаца = НомерАбзаца - 1
        НомерАбзаца = вставитьСекретаряКомиссии(MSWord, DOK, Дата, НомерАбзаца)

        ПроверкаСтраницы = DOK.Range.Information(3)

        If ТекущаяСтраница = ПроверкаСтраницы Then


            строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
            НомерАбзаца = DOK.Paragraphs.count

            If строкДоСтраницы2 <= 3 And строкДоСтраницы2 >= 0 Then

                DOK.Tables(4).Range.select

                MSWord.Selection.Cut

                НомерАбзаца = DOK.Paragraphs.count

                строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
                'Call ВставитьПараграф(DOK, 50, "57", "Times New Roman", 14, 3, 0, 1, 0, False

                While строкДоСтраницы2 + 1 > 0

                    DOK.Paragraphs.Add()
                    НомерАбзаца = 1 + НомерАбзаца
                    Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                    строкДоСтраницы2 = строкДоСтраницы2 - 1

                End While
                'Call ВставитьПараграф(DOK, 55, "55", "Times New Roman", 14, 3, 0, 1, 0, False)
                DOK.Paragraphs(НомерАбзаца).Range.select
                MSWord.Selection.PasteAndFormat(0)
                НомерАбзаца = DOK.Paragraphs.count
            End If
            'Call ВставитьПараграф(DOK, 61, "61", "Times New Roman", 14, 3, 0, 1, 0, False)

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = DOK.Paragraphs.count

        Else


            DOK.Tables(4).Range.select

            MSWord.Selection.Cut

            НомерАбзаца = DOK.Paragraphs.count
            'Call ВставитьПараграф(DOK, 49, "49", "Times New Roman", 14, 3, 0, 1, 0, False)
            строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)


            While строкДоСтраницы2 + 1 > 0

                DOK.Paragraphs.Add()
                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                строкДоСтраницы2 = строкДоСтраницы2 - 1

            End While

            'Call ВставитьПараграф(DOK, 55, "55", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs(НомерАбзаца).Range.select

            MSWord.Selection.PasteAndFormat(0)

            DOK.Bookmarks("\EndOfDoc").Select

            НомерАбзаца = DOK.Paragraphs.count
            'Call ВставитьПараграф(DOK, 59, "55", "Times New Roman", 14, 3, 0, 1, 0, False)
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)


        End If

        НомерАбзаца = вставитьУтверждающего(MSWord, DOK, НомерАбзаца, видПриказа)

        НомерАбзаца = DOK.Paragraphs.count
        DOK.Bookmarks("\EndOfDoc").Select

        MSWord.Selection.InsertBreak(Type:=7)


        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = вставитьЛистСогласования(MSWord, DOK, Дата, НомерАбзаца, видПриказа)

        DOK.Bookmarks("\EndOfDoc").Select

        MSWord.Selection.InsertBreak(Type:=7)

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.count


        Call вставитьКороткуюШапку(MSWord, DOK, НомерАбзаца)

        НомерАбзаца = DOK.Paragraphs.count

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 2, 0, 1, 0, False)


        DOK.Paragraphs.Add()



        Call вставитьПротоколПП(MSWord, DOK, Группа(2, 0).ToString, Группа)

        MSWord.Selection.InsertBreak(Type:=7)

        MSWord.Visible = True

        Call сохранить(DOK, видПриказа)





    End Sub


    Function вставитьСоставКомиссииПП(MSWord As Object, DOK As Object, Дата As String, НомерАбзаца As Integer) As Integer
        Dim Tabl

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), 10, 2)

        Tabl.Cell(1, 1).Range.Text = "Председатель комиссии:"
        'Tabl.Cell(1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(2, 2).Range.Text = АСформироватьПриказ.ОтветственныйДолжность.Text
        'Tabl.Cell(2, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(2, 1).Range.Text = АСформироватьПриказ.Ответственный.Text


        Tabl.Cell(4, 1).Range.Text = "Зам. председателя комиссии:"
        'Tabl.Cell(4, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(5, 2).Range.Text = АСформироватьПриказ.ЗамПредседателяДолжность.Text
        'Tabl.Cell(5, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(5, 1).Range.Text = АСформироватьПриказ.ЗамПредседателя.Text

        Tabl.Cell(7, 1).Range.Text = "Члены комиссии:"
        'Tabl.Cell(7, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(8, 2).Range.Text = АСформироватьПриказ.РуководительСтажировкиДолжность.Text
        Tabl.Cell(8, 1).Range.Text = АСформироватьПриказ.РуководительСтажировки.Text
        'Tabl.Cell(8, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(9, 2).Range.Text = АСформироватьПриказ.Комиссия2Должность.Text
        Tabl.Cell(9, 1).Range.Text = АСформироватьПриказ.Комиссия2.Text
        'Tabl.Cell(9, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(10, 2).Range.Text = АСформироватьПриказ.Комиссия3Должность.Text
        Tabl.Cell(10, 1).Range.Text = АСформироватьПриказ.Комиссия3.Text
        'Tabl.Cell(10, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(2, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(2, 1).Range.ParagraphFormat.Alignment = 0


        Tabl.Cell(4, 1).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(5, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(5, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(7, 1).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(8, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(8, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(9, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(9, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(10, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(10, 1).Range.ParagraphFormat.Alignment = 0

        DOK.Paragraphs(НомерАбзаца).LeftIndent = 28.34646
        Tabl.Range.ParagraphFormat.LineSpacing = 12
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14
        Tabl.Columns(2).Width = 270
        Tabl.Columns(1).Width = 220

        'Нулевой отступ от левого края
        Tabl.Range.ParagraphFormat.LeftIndent = 0

        Tabl.Range.select
        MSWord.Selection.Cut
        'DOK.Paragraphs(НомерАбзаца - 1).LeftIndent = 28.34646
        НомерАбзаца = НомерАбзаца + 1
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs(НомерАбзаца).Range.select
        MSWord.Selection.PasteAndFormat(0)


        НомерАбзаца = DOK.Paragraphs.count

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        вставитьСоставКомиссииПП = DOK.Paragraphs.count

    End Function

    Sub вставитьПротоколПП(MSWord As Object, DOK As Object, Программа As String, Группа As Object)
        Dim НомерАбзаца As Integer, НомерПротокола
        Dim Слушатели
        Dim Tabl
        Dim ТаблицаПодписиКомиссии
        Dim Дата As String, строкаЗапроса As String

        строкаЗапроса = "SELECT НомерПротоколаИА FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)

        НомерПротокола = ЗагрузитьИзБазы.ЗагрузитьИзБазы(строкаЗапроса)

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Протокол №" & НомерПротокола(0, 0), "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "заседания аттестационной комиссии по рассмотрению результатов итоговых ", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "испытаний слушателей программы профессиональной переподготовки ", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Программа & "» ", "Times New Roman", 14, 1, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Left(Дата, 2) & "» " & month(Right(Left(Дата, 5), 2)) & " " & Right(Дата, 4), "Times New Roman", 14, 1, 0, 1, 0, False)
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРИСУТСТВОВАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Председатель комиссии: " & перевернуть(АСформироватьПриказ.Ответственный.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Зам. председателя комиссии: " & перевернуть(АСформироватьПриказ.ЗамПредседателя.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Члены комиссии: " & перевернуть(АСформироватьПриказ.РуководительСтажировки.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия2.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия3.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Секретарь комиссии – " & перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text), "Times New Roman", 14, 0, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "СЛУШАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "О результатах прохождения итоговой аттестации слушателей, обучавшихся в ФГБУ ДПО ВУНМЦ Минздрава России по дополнительной профессиональной программе профессиональной переподготовки «" & Программа & "» в объёме " & Группа(3, 0) & " час. в период с " & Группа(0, 0) & " по " & Группа(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "ПОСТАНОВИЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "1. Утвердить результаты итоговой аттестации слушателей дополнительной профессиональной программы профессиональной переподготовки  «" & Программа & "»", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца

        Слушатели = МассивСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), UBound(Слушатели, 2) + 3, 5)

        Call НастройкаТаблицыПП(MSWord, DOK, Tabl, Слушатели)



        Tabl.Range.select
        MSWord.Selection.Cut
        НомерАбзаца = НомерАбзаца + 1
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "2. Установить, что в результате обучения слушателями достигнуты запланированные дополнительной профессиональной программой цели.", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()

        ТаблицаПодписиКомиссии = DOK.Tables.Add(DOK.Range(0, 0), 6, 2)

        Call НастройкаТаблицыПодписиКомиссииПП(DOK, ТаблицаПодписиКомиссии)

        ТаблицаПодписиКомиссии.Range.select

        MSWord.Selection.Cut

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count

        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)


    End Sub

    Sub НастройкаТаблицыПодписиКомиссииПП(DOK As Object, Tabl As Object)
        Dim СчетчикСтрок As Integer

        Tabl.Columns(1).Width = 220
        Tabl.Columns(2).Width = 280
        Tabl.Range.Font.Size = 14
        Tabl.Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(1, 1).Range.Text = "Председатель комиссии:"
        'Tabl.Cell(1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        'Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(2, 1).Range.Text = "Зам. председателя комиссии:"
        'Tabl.Cell(2, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        'Tabl.Cell(2, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(3, 1).Range.Text = "Члены комиссии:"
        'Tabl.Cell(3, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        'Tabl.Cell(2, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(6, 1).Range.Text = "Секретарь комиссии:"
        'Tabl.Cell(6, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        'Tabl.Cell(5, 1).Range.ParagraphFormat.Alignment = 0

        СчетчикСтрок = СчетчикСтрок + 1
        Tabl.Cell(1, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.Ответственный.Text)
        Tabl.Cell(2, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.ЗамПредседателя.Text)
        Tabl.Cell(3, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.РуководительСтажировки.Text)
        Tabl.Cell(4, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.Комиссия2.Text)
        Tabl.Cell(5, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.Комиссия3.Text)
        Tabl.Cell(6, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text)

    End Sub

    Sub НастройкаТаблицыПП(MSWord As Object, DOK As Object, Tabl As Object, Слушатели As Object)
        Dim Счетчик As Integer
        Dim начало, конец

        With Tabl.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With

        Счетчик = 1

        While Счетчик <= UBound(Слушатели, 2) + 3
            Tabl.Rows(Счетчик).Cells.VerticalAlignment = 1
            Счетчик = Счетчик + 1
        End While

        Tabl.Range.ParagraphFormat.LineSpacing = 14
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14

        Tabl.Columns(2).Width = 230
        Tabl.Columns(1).Width = 30
        Tabl.Columns(3).Width = 75
        Tabl.Columns(4).Width = 90
        Tabl.Columns(5).Width = 75

        Счетчик = 0

        While Счетчик <= UBound(Слушатели, 2)
            Tabl.Cell(Счетчик + 3, 2).Range.Text = Слушатели(0, Счетчик) & " " & Слушатели(1, Счетчик) & " " & Слушатели(2, Счетчик)
            Tabl.Cell(Счетчик + 3, 2).Range.ParagraphFormat.Alignment = 0
            Счетчик = Счетчик + 1
        End While
        Счетчик = 0
        While Счетчик <= UBound(Слушатели, 2)
            Tabl.Cell(Счетчик + 3, 1).Range.Text = Счетчик + 1 & "."
            Tabl.Cell(Счетчик + 3, 1).Range.ParagraphFormat.Alignment = 0
            Счетчик = Счетчик + 1
        End While
        начало = Tabl.cell(2, 2).Range.Start
        конец = Tabl.cell(UBound(Слушатели, 2) + 3, 2).Range.End
        DOK.Range(начало, конец).Select
        MSWord.Selection.Range.Sort



        Tabl.Cell(1, 1).Merge(DOK.Tables(1).Cell(2, 1))
        Tabl.Cell(1, 2).Merge(DOK.Tables(1).Cell(2, 2))
        Tabl.Cell(1, 3).Merge(DOK.Tables(1).Cell(1, 5))

        Tabl.Cell(1, 1).Range.Text = "№ п/п"
        Tabl.Cell(1, 1).Range.Font.Size = 12

        Tabl.Cell(1, 2).Range.Text = "Фамилия имя отчество"
        Tabl.Cell(1, 2).Range.Font.Size = 13

        Tabl.Cell(1, 3).Range.Text = "Оценка"
        Tabl.Cell(1, 3).Range.Font.Size = 13

        Tabl.Cell(2, 3).Range.Text = "Тестирование"
        Tabl.Cell(2, 3).Range.Font.Size = 10

        Tabl.Cell(2, 4).Range.Text = "Практич. навыки"
        Tabl.Cell(2, 4).Range.Font.Size = 10

        Tabl.Cell(2, 5).Range.Text = "Итоговая оценка"
        Tabl.Cell(2, 5).Range.Font.Size = 10

        Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(1, 1).Range.Font.Bold = True

        Tabl.Cell(1, 2).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(1, 2).Range.Font.Bold = True

        Tabl.Cell(1, 3).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(1, 3).Range.Font.Bold = True

        Tabl.Cell(2, 3).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(2, 3).Range.Font.Bold = True

        Tabl.Cell(2, 4).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(2, 4).Range.Font.Bold = True

        Tabl.Cell(2, 5).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(2, 5).Range.Font.Bold = True


    End Sub




    Sub ПриказПО_ДопускКИА(видПриказа As String)
        Dim MSWord
        Dim DOK
        Dim НачальныйАбзац As Integer, КонечныйАбзац As Integer, НачальныйАбзац2 As Integer, КонечныйАбзац2 As Integer
        Dim Группа, Tabl, Слушатели
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer, счетчик As Integer, строкДоСтраницы2 As Integer, ТекущаяСтраница As Integer, ПроверкаСтраницы As Integer
        Dim Дата As String, СтрокаЗапроса As String, Слушатель As String

        Слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If


        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add
        'MSWord.Visible = True

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас, Финансирование FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)


        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub

        If видПриказа = "ПО_ДопускКИА" Then

            первыйПункт = "О допуске обучающихся "
            второйПункт = "к итоговой аттестации"
            третийПункт = "В соответствии с Положением о порядке и условиях профессионального обучения в ФГБУ ДПО ВУНМЦ Минздрава России, утверждённым 21.06.2019"
            четвертыйПункт = "1. Допустить к итоговой аттестации следующих обучающихся группы № " & АСформироватьПриказ.НомерГруппы.Text & ", аттестованных по всем дисциплинам, модулям и успешно прошедших практическое обучение, полностью выполнивших учебный план:"
            пятыйПункт = "0"

        End If

        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(Слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, Tabl, Слушатели)

        Tabl.Range.select
        MSWord.Selection.Cut
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)


        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        If видПриказа = "ПО_ДопускКИА" Then

            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()
            Call ВставитьПараграф(DOK, НомерАбзаца, "2. Утвердить аттестационную комиссию по основной программе профессионального обучения «" & Группа(2, 0) & "» в составе:", "Times New Roman", 14, 3, 0, 1, 0, False)

        End If

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьСоставКомиссии(MSWord, DOK, Дата, НомерАбзаца)


        ТекущаяСтраница = DOK.Range.Information(3)

        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.Delete
        НомерАбзаца = НомерАбзаца - 1

        НомерАбзаца = вставитьСекретаряКомиссии(MSWord, DOK, Дата, НомерАбзаца)

        ПроверкаСтраницы = DOK.Range.Information(3)

        If ТекущаяСтраница = ПроверкаСтраницы Then


            строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
            НомерАбзаца = DOK.Paragraphs.count

            If строкДоСтраницы2 <= 3 And строкДоСтраницы2 >= 0 Then

                DOK.Tables(4).Range.select

                MSWord.Selection.Cut

                НомерАбзаца = DOK.Paragraphs.count

                строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
                'Call ВставитьПараграф(DOK, 50, "57", "Times New Roman", 14, 3, 0, 1, 0, False

                While строкДоСтраницы2 + 1 > 0

                    DOK.Paragraphs.Add()
                    НомерАбзаца = 1 + НомерАбзаца
                    Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                    строкДоСтраницы2 = строкДоСтраницы2 - 1

                End While
                'Call ВставитьПараграф(DOK, 55, "55", "Times New Roman", 14, 3, 0, 1, 0, False)
                DOK.Paragraphs(НомерАбзаца).Range.select
                MSWord.Selection.PasteAndFormat(0)
                НомерАбзаца = DOK.Paragraphs.count
            End If
            'Call ВставитьПараграф(DOK, 61, "61", "Times New Roman", 14, 3, 0, 1, 0, False)

            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = DOK.Paragraphs.count

        Else


            DOK.Tables(4).Range.select

            MSWord.Selection.Cut

            НомерАбзаца = DOK.Paragraphs.count
            'Call ВставитьПараграф(DOK, 49, "49", "Times New Roman", 14, 3, 0, 1, 0, False)
            строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)


            While строкДоСтраницы2 + 1 > 0

                DOK.Paragraphs.Add()
                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                строкДоСтраницы2 = строкДоСтраницы2 - 1

            End While

            'Call ВставитьПараграф(DOK, 55, "55", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs(НомерАбзаца).Range.select

            MSWord.Selection.PasteAndFormat(0)

            DOK.Bookmarks("\EndOfDoc").Select

            НомерАбзаца = DOK.Paragraphs.count
            'Call ВставитьПараграф(DOK, 59, "55", "Times New Roman", 14, 3, 0, 1, 0, False)
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)


        End If

        НомерАбзаца = вставитьУтверждающего(MSWord, DOK, НомерАбзаца, видПриказа)

        НомерАбзаца = DOK.Paragraphs.count
        DOK.Bookmarks("\EndOfDoc").Select

        MSWord.Selection.InsertBreak(Type:=7)

        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = вставитьЛистСогласования(MSWord, DOK, Дата, НомерАбзаца, видПриказа)

        DOK.Bookmarks("\EndOfDoc").Select

        MSWord.Selection.InsertBreak(Type:=7)

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.count


        Call вставитьКороткуюШапку(MSWord, DOK, НомерАбзаца)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 2, 0, 1, 0, False)


        DOK.Paragraphs.Add()



        Call вставитьПротокол(MSWord, DOK, Группа(2, 0).ToString, Группа)

        MSWord.Selection.InsertBreak(Type:=7)

        Слушатели = МассивСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        Слушатель = Слушатели(0, 0) & " " & Слушатели(1, 0) & " " & Слушатели(2, 0)

        НачальныйАбзац = DOK.Paragraphs.count

        Call ПРОТОКОЛоценкиИтоговойАттестации(MSWord, DOK, Группа, Дата, Слушатель)

        КонечныйАбзац = DOK.Paragraphs.count

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, Слушатели(0, 0) & " " & Слушатели(1, 0) & " " & Слушатели(2, 0), "Times New Roman", 14, 1, 0, 1, 0, False)

        НачальныйАбзац2 = DOK.Paragraphs.count + 1

        Call ПРОТОКОЛоценкиИтоговойАттестации2Часть(MSWord, DOK, Группа, Дата, Слушатель)

        КонечныйАбзац2 = DOK.Paragraphs.count + 1


        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)
        счетчик = 1

        While счетчик <= UBound(Слушатели, 2)
            Слушатель = Слушатели(0, счетчик) & " " & Слушатели(1, счетчик) & " " & Слушатели(2, счетчик)

            КопироватьВставить(MSWord, DOK, НачальныйАбзац, КонечныйАбзац)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count
            Call ВставитьПараграф(DOK, НомерАбзаца, Слушатель, "Times New Roman", 14, 1, 0, 1, 0, False)
            DOK.Paragraphs.Add()
            КопироватьВставить(MSWord, DOK, НачальныйАбзац2, КонечныйАбзац2)
            счетчик = счетчик + 1
        End While
        MSWord.Visible = True

        Call сохранить(DOK, видПриказа)


    End Sub

    Sub ПРОТОКОЛоценкиИтоговойАттестации(MSWord As Object, DOK As Object, Группа As Object, Дата As String, Слушатель As String)
        Dim НомерАбзаца As Integer

        DOK.Bookmarks("\EndOfDoc").Select
        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРОТОКОЛ", "Times New Roman", 14, 1, 0, 1, 0, True)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "оценки итоговой аттестации", "Times New Roman", 14, 1, 0, 1, 0, True)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Группа(2, 0).ToString & "»", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Left(Дата, 2) & "» " & month(Right(Left(Дата, 5), 2)) & " " & Right(Дата, 4), "Times New Roman", 14, 1, 0, 1, 0, False)

    End Sub

    Sub ПРОТОКОЛоценкиИтоговойАттестации2Часть(MSWord As Object, DOK As Object, Группа As Object, Дата As String, Слушатель As String)
        Dim НомерАбзаца As Integer
        Dim Tabl
        Dim Должность As String

        If АСформироватьПриказ.CheckBoxММС.Checked = True Then
            Должность = "Младшая медицинская сестра по уходу за больными"
        Else Должность = "Санитар"
        End If

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "I этап – тестовый контроль знаний", "Times New Roman", 14, 3, 0, 1, 0, True)

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "1. Доля правильно решенных заданий __________, что соответствует оценке", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "	□ зачтено				□ не зачтено", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "	(от 70% и выше)			(ниже 70%)", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "II этап – практическая квалификационная работа по должности " & Должность, "Times New Roman", 14, 3, 0, 1, 0, True)

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Заключение: практическая квалификационная работа выполнена по технологии _________________________________________________________________________________________________________________________________________ с результатом ____ баллов", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "	□ зачтено				□ не зачтено", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count

        If АСформироватьПриказ.CheckBoxММС.Checked = True Then
            Call ВставитьПараграф(DOK, НомерАбзаца, "	(8-16 баллов)				(0-7 баллов)", "Times New Roman", 12, 3, 0, 1, 0, False)
        Else
            Call ВставитьПараграф(DOK, НомерАбзаца, "	(10-19 баллов)			(0-9 баллов)", "Times New Roman", 12, 3, 0, 1, 0, False)
        End If

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), 12, 3)

        Call НастройкаТаблицыПРОТОКОЛоценкиИтоговойАттестации(DOK, Tabl)

        Tabl.Range.select
        MSWord.Selection.Cut
        НомерАбзаца = НомерАбзаца + 1
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)





    End Sub
    Sub НастройкаТаблицыПРОТОКОЛоценкиИтоговойАттестации(DOK As Object, Tabl As Object)

        Tabl.Columns(1).Width = 210
        Tabl.Columns(2).Width = 135
        Tabl.Columns(3).Width = 155
        Tabl.Range.Font.Size = 14
        Tabl.Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(1, 1).Range.Text = "Председатель комиссии:"
        'Tabl.Cell(1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(1, 2).Range.Text = "______________"
        Tabl.Cell(1, 3).Range.Text = перевернуть(АСформироватьПриказ.Ответственный.Text)
        Tabl.Cell(2, 2).Range.Text = "	(подпись)	"
        Tabl.Cell(2, 2).Range.Font.Size = 10
        Tabl.Cell(2, 1).Range.Font.Size = 10
        Tabl.Cell(2, 3).Range.Font.Size = 10
        Tabl.Cell(2, 2).Range.Font.Italic = 9999998

        Tabl.Cell(4, 1).Range.Text = "Члены комиссии:"
        'Tabl.Cell(4, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(4, 2).Range.Text = "______________"
        Tabl.Cell(4, 3).Range.Text = перевернуть(АСформироватьПриказ.РуководительСтажировки.Text)
        Tabl.Cell(5, 2).Range.Text = "	(подпись)	"
        Tabl.Cell(5, 2).Range.Font.Size = 10
        Tabl.Cell(5, 1).Range.Font.Size = 10
        Tabl.Cell(5, 3).Range.Font.Size = 10
        Tabl.Cell(5, 2).Range.Font.Italic = 9999998

        Tabl.Cell(6, 2).Range.Text = "______________"
        Tabl.Cell(6, 3).Range.Text = перевернуть(АСформироватьПриказ.Комиссия2.Text)
        Tabl.Cell(7, 2).Range.Text = "	(подпись)	"
        Tabl.Cell(7, 2).Range.Font.Size = 10
        Tabl.Cell(7, 1).Range.Font.Size = 10
        Tabl.Cell(7, 3).Range.Font.Size = 10
        Tabl.Cell(7, 2).Range.Font.Italic = 9999998

        Tabl.Cell(8, 2).Range.Text = "______________"
        Tabl.Cell(8, 3).Range.Text = перевернуть(АСформироватьПриказ.Комиссия2.Text)
        Tabl.Cell(9, 2).Range.Text = "	(подпись)	"
        Tabl.Cell(9, 2).Range.Font.Size = 10
        Tabl.Cell(9, 1).Range.Font.Size = 10
        Tabl.Cell(9, 3).Range.Font.Size = 10
        Tabl.Cell(9, 2).Range.Font.Italic = 9999998


        Tabl.Cell(11, 1).Range.Text = "Секретарь комиссии:"
        'Tabl.Cell(11, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(11, 2).Range.Text = "______________"
        Tabl.Cell(11, 3).Range.Text = перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text)
        Tabl.Cell(12, 2).Range.Text = "	(подпись)	"
        Tabl.Cell(12, 2).Range.Font.Size = 10
        Tabl.Cell(12, 1).Range.Font.Size = 10
        Tabl.Cell(12, 3).Range.Font.Size = 10
        Tabl.Cell(12, 2).Range.Font.Italic = 9999998





    End Sub

    Sub ТаблицаСоставГруппы(MSWord As Object, DOK As Object, Tabl As Object, Слушатели As Object)

        Dim СчетчикСтрок As Integer

        Tabl.Columns(1).Width = 60
        Tabl.Columns(2).Width = 450
        Tabl.Range.Font.Size = 14
        Tabl.Range.ParagraphFormat.Alignment = 0

        СчетчикСтрок = 0

        While СчетчикСтрок <= UBound(Слушатели, 2)

            Tabl.Cell(СчетчикСтрок + 1, 2).Range.Text = Слушатели(0, СчетчикСтрок)
            СчетчикСтрок = СчетчикСтрок + 1
        End While

        Tabl.Cell(1, 2).Select
        MSWord.Selection.SelectColumn

        If СчетчикСтрок > 1 Then MSWord.Selection.Range.Sort

        СчетчикСтрок = 0

        While СчетчикСтрок <= UBound(Слушатели, 2)
            Tabl.Cell(СчетчикСтрок + 1, 1).Range.Text = СчетчикСтрок + 1 & "."
            Tabl.Cell(СчетчикСтрок + 1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
            СчетчикСтрок = СчетчикСтрок + 1
        End While

    End Sub



    Sub НастройкаТаблицыПодписиКомиссии(DOK As Object, Tabl As Object)
        Dim СчетчикСтрок As Integer

        Tabl.Columns(1).Width = 200
        Tabl.Columns(2).Width = 300
        Tabl.Range.Font.Size = 14
        Tabl.Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(1, 1).Range.Text = "Председатель комиссии:"
        'Tabl.Cell(1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(2, 1).Range.Text = "Члены комиссии:"
        'Tabl.Cell(2, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(5, 1).Range.Text = "Секретарь комиссии:"
        'Tabl.Cell(5, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        СчетчикСтрок = СчетчикСтрок + 1
        Tabl.Cell(1, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.Ответственный.Text)
        Tabl.Cell(2, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.РуководительСтажировки.Text)
        Tabl.Cell(3, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.Комиссия2.Text)
        Tabl.Cell(4, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.Комиссия3.Text)
        Tabl.Cell(5, 2).Range.Text = "______________ " & перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text)

    End Sub


    Function month(nomber As String)
        If nomber = "01" Or nomber = "1" Then month = "января"
        If nomber = "02" Or nomber = "2" Then month = "февраля"
        If nomber = "03" Or nomber = "3" Then month = "марта"
        If nomber = "04" Or nomber = "4" Then month = "апреля"
        If nomber = "05" Or nomber = "5" Then month = "мая"
        If nomber = "06" Or nomber = "6" Then month = "июня"
        If nomber = "07" Or nomber = "7" Then month = "июля"
        If nomber = "08" Or nomber = "8" Then month = "августа"
        If nomber = "09" Or nomber = "9" Then month = "сентября"
        If nomber = "10" Then month = "октября"
        If nomber = "11" Then month = "ноября"
        If nomber = "12" Then month = "декабря"
    End Function




    Sub вставитьПротокол(MSWord As Object, DOK As Object, Программа As String, Группа As Object)
        Dim НомерАбзаца As Integer, НомерПротокола
        Dim Слушатели
        Dim Tabl
        Dim ТаблицаПодписиКомиссии
        Dim Дата As String, строкаЗапроса As String

        строкаЗапроса = "SELECT НомерПротоколаИА FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)

        НомерПротокола = ЗагрузитьИзБазы.ЗагрузитьИзБазы(строкаЗапроса)

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString

        DOK.Bookmarks("\EndOfDoc").Select

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Протокол №" & НомерПротокола(0, 0), "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "заседания аттестационной комиссии по рассмотрению результатов ", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "квалификационного экзамена по основной программе профессионального", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "обучения «" & Программа & "» ", "Times New Roman", 14, 1, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«" & Left(Дата, 2) & "» " & month(Right(Left(Дата, 5), 2)) & " " & Right(Дата, 4), "Times New Roman", 14, 1, 0, 1, 0, False)
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРИСУТСТВОВАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Председатель комиссии: " & перевернуть(АСформироватьПриказ.Ответственный.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Члены комиссии: " & перевернуть(АСформироватьПриказ.РуководительСтажировки.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия2.Text) & ", " & перевернуть(АСформироватьПриказ.Комиссия3.Text), "Times New Roman", 14, 0, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "Секретарь комиссии – " & перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text), "Times New Roman", 14, 0, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "СЛУШАЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "О результатах прохождения квалификационного экзамена слушателей, обучавшихся в ФГБУ ДПО ВУНМЦ Минздрава России по основной программе профессионального обучения «" & Программа & "» в объёме " & Группа(3, 0) & " час. в период с " & Группа(0, 0) & " по " & Группа(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "ПОСТАНОВИЛИ:", "Times New Roman", 14, 0, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "1. Утвердить результаты квалификационного экзамена слушателей основной программы профессионального обучения «" & Программа & "»", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца

        Слушатели = МассивСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), UBound(Слушатели, 2) + 3, 5)

        Call НастройкаТаблицы(MSWord, DOK, Tabl, Слушатели)

        Tabl.Range.select
        MSWord.Selection.Cut
        НомерАбзаца = НомерАбзаца + 1
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "2. Установить, что в результате обучения слушателями достигнуты запланированные основной программой профессионального обучения уровень теоретической и практической подготовки обучающегося.", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()

        ТаблицаПодписиКомиссии = DOK.Tables.Add(DOK.Range(0, 0), 5, 2)

        Call НастройкаТаблицыПодписиКомиссии(DOK, ТаблицаПодписиКомиссии)

        ТаблицаПодписиКомиссии.Range.select

        MSWord.Selection.Cut

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count

        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)


    End Sub

    Sub НастройкаТаблицы(MSWord As Object, DOK As Object, Tabl As Object, Слушатели As Object)
        Dim Счетчик As Integer, начало, конец

        With Tabl.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With

        Счетчик = 1

        While Счетчик <= UBound(Слушатели, 2) + 3
            Tabl.Rows(Счетчик).Cells.VerticalAlignment = 1
            Счетчик = Счетчик + 1
        End While

        Tabl.Range.ParagraphFormat.LineSpacing = 14
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14

        Tabl.Columns(2).Width = 230
        Tabl.Columns(1).Width = 30
        Tabl.Columns(3).Width = 75
        Tabl.Columns(4).Width = 90
        Tabl.Columns(5).Width = 75

        Счетчик = 0

        While Счетчик <= UBound(Слушатели, 2)
            Tabl.Cell(Счетчик + 3, 2).Range.Text = Слушатели(0, Счетчик) & " " & Слушатели(1, Счетчик) & " " & Слушатели(2, Счетчик)
            Tabl.Cell(Счетчик + 3, 2).Range.ParagraphFormat.Alignment = 0
            Счетчик = Счетчик + 1
        End While

        начало = Tabl.cell(2, 2).Range.Start
        конец = Tabl.cell(UBound(Слушатели, 2) + 3, 2).Range.End
        DOK.Range(начало, конец).Select
        MSWord.Selection.Range.Sort

        Счетчик = 0
        While Счетчик <= UBound(Слушатели, 2)
            Tabl.Cell(Счетчик + 3, 1).Range.Text = Счетчик + 1 & "."
            Tabl.Cell(Счетчик + 3, 1).Range.ParagraphFormat.Alignment = 0
            Счетчик = Счетчик + 1
        End While


        Tabl.Cell(1, 1).Merge(DOK.Tables(1).Cell(2, 1))
        Tabl.Cell(1, 2).Merge(DOK.Tables(1).Cell(2, 2))
        Tabl.Cell(1, 3).Merge(DOK.Tables(1).Cell(1, 5))

        Tabl.Cell(1, 1).Range.Text = "№ п/п"
        Tabl.Cell(1, 1).Range.Font.Size = 12

        Tabl.Cell(1, 2).Range.Text = "Фамилия имя отчество"
        Tabl.Cell(1, 2).Range.Font.Size = 13

        Tabl.Cell(1, 3).Range.Text = "Оценка"
        Tabl.Cell(1, 3).Range.Font.Size = 13

        Tabl.Cell(2, 3).Range.Text = "Тестирование"
        Tabl.Cell(2, 3).Range.Font.Size = 10

        Tabl.Cell(2, 4).Range.Text = "Практич. квалиф. работа"
        Tabl.Cell(2, 4).Range.Font.Size = 10

        Tabl.Cell(2, 5).Range.Text = "Итоговая оценка"
        Tabl.Cell(2, 5).Range.Font.Size = 10

        Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(1, 1).Range.Font.Bold = True

        Tabl.Cell(1, 2).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(1, 2).Range.Font.Bold = True

        Tabl.Cell(1, 3).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(1, 3).Range.Font.Bold = True

        Tabl.Cell(2, 3).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(2, 3).Range.Font.Bold = True

        Tabl.Cell(2, 4).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(2, 4).Range.Font.Bold = True

        Tabl.Cell(2, 5).Range.ParagraphFormat.Alignment = 1
        Tabl.Cell(2, 5).Range.Font.Bold = True








    End Sub


    Function МассивСлушателей(Группа As String) As Object
        Dim СтрокаЗапроса As String
        Dim Слушатели
        Dim НаВывод
        Dim Счетчик As Integer


        СтрокаЗапроса = "SELECT Слушатель FROM СоставГрупп WHERE Группа= " & Chr(39) & Группа & Chr(39)
        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            MsgBox("В выбранной группе нет слушателей")
            МассивСлушателей = 0
            Exit Function

        End If

        ReDim НаВывод(3, UBound(Слушатели, 2))

        СтрокаЗапроса = "SELECT Фамилия , Имя , Отчество FROM Слушатель WHERE"
        Счетчик = 0
        While Счетчик <= UBound(Слушатели, 2)

            СтрокаЗапроса = СтрокаЗапроса & " Снилс=" & Chr(39) & Слушатели(0, Счетчик) & Chr(39) & " OR"
            Счетчик = Счетчик + 1
        End While

        СтрокаЗапроса = Left(СтрокаЗапроса, Len(СтрокаЗапроса) - 3)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        МассивСлушателей = Слушатели

    End Function


    Sub ПриказПП_Практика(видПриказа As String)
        Dim MSWord
        Dim DOK
        Dim Группа
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer, счетчик As Integer, строкДоСтраницы2 As Integer, ТекущаяСтраница As Integer
        Dim Дата As String, СтрокаЗапроса As String
        Dim Слушатели
        Слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If



        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас, Финансирование FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)


        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub

        If видПриказа = "ПП_Практика" Then

            первыйПункт = "О прохождении слушателями "
            второйПункт = "практической подготовки"
            третийПункт = "В соответствии с Положением о порядке и условиях профессиональной переподготовки медицинских и фармацевтических работников в ФГБУ ДПО ВУНМЦ Минздрава России, утверждённым 21.06.2019"
            четвертыйПункт = "1. Провести практическую подготовку по дополнительной профессиональной программе профессиональной переподготовки  «" & Группа(2, 0) & "» в медицинских организациях:"
            пятыйПункт = "2. Направить в вышеуказанные медицинские организации для прохождения практической подготовки следующих слушателей группы № " & АСформироватьПриказ.НомерГруппы.Text & " согласно списку:"

        End If

        If видПриказа = "ПО_Практика" Then

            первыйПункт = "О прохождении обучающимися"
            второйПункт = "практического обучения"
            третийПункт = "В соответствии с Положением о порядке и условиях профессионального обучения в ФГБУ ДПО ВУНМЦ Минздрава России, утверждённым 21.06.2019"
            четвертыйПункт = "1. Провести практическое обучение по основной программе профессионального обучения   «" & Группа(2, 0) & "» в медицинских организациях:"
            пятыйПункт = "2. Направить в вышеуказанные медицинские организации для прохождения практического обучения следующих обучающихся группы №" & АСформироватьПриказ.НомерГруппы.Text & " согласно списку:"

        End If

        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)

        счетчик = ВывестиCписокСлушателей(DOK, АСформироватьПриказ.НомерГруппы.Text, НомерАбзаца)
        НомерАбзаца = НомерАбзаца + счетчик
        ТекущаяСтраница = DOK.Range.Information(3)
        строкДоСтраницы2 = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
        If строкДоСтраницы2 <= 5 And строкДоСтраницы2 > 0 Then
            While строкДоСтраницы2 < 0

                DOK.Paragraphs.Add()
                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                строкДоСтраницы2 = строкДоСтраницы2 - 1

            End While

        End If

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "3. Назначить руководителем практической подготовки от Центра " & АСформироватьПриказ.ОтветственныйДолжность.Text & " " & перевернуть(АСформироватьПриказ.Ответственный.Text), "Times New Roman", 14, 3, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьУтверждающего(MSWord, DOK, НомерАбзаца, видПриказа)

        MSWord.Selection.InsertBreak(Type:=7)


        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьЛистСогласования(MSWord, DOK, Дата, НомерАбзаца, видПриказа)



        MSWord.Visible = True

        Call сохранить(DOK, видПриказа)


    End Sub

    Function ПерваяЧасть(DOK As Object, НомерАбзаца As Integer, видПриказа As String, первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String) As Integer

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, первыйПункт, "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца

        Call ВставитьПараграф(DOK, НомерАбзаца, второйПункт, "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, третийПункт, "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРИКАЗЫВАЮ:", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца

        Call ВставитьПараграф(DOK, НомерАбзаца, четвертыйПункт, "Times New Roman", 14, 3, 0, 1, 0, False)

        If Not пятыйПункт = "0" Then
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, пятыйПункт, "Times New Roman", 14, 3, 0, 1, 0, False)
        End If
        ПерваяЧасть = НомерАбзаца

    End Function



    Sub ПриказОЗачислении(видПриказа As String)
        Dim MSWord, tabl
        Dim DOK
        Dim Группа, слушатели
        Dim НомерАбзаца As Integer, строкДоСлСтраницы As Integer, ТекущаяСтраница As Integer, ПроверкаСтраницы As Integer
        Dim Дата As String, СтрокаЗапроса As String, средства As String

        слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If


        MSWord = CreateObject("Word.Application")

        If АСформироватьПриказ.CheckBoxММС.Checked Then

            средства = АСформироватьПриказ.CheckBoxММС.Text & " слушателей"

        Else

            средства = АСформироватьПриказ.CheckBoxСанитар.Text

        End If

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас, Финансирование FROM Группа WHERE Код= " & ААОсновная.prikazKodGroup
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)


        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "О зачислении", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        If Not видПриказа = "ПО_Зачисление" Then
            Call ВставитьПараграф(DOK, НомерАбзаца, "слушателей на обучение", "Times New Roman", 14, 3, 0, 1, 0, False)
        Else Call ВставитьПараграф(DOK, НомерАбзаца, "обучающихся на обучение", "Times New Roman", 14, 3, 0, 1, 0, False)
        End If

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "В соответствии с Правилами приёма на обучение по программам дополнительного профессионального образования в ФГБУ ДПО ВУНМЦ Минздрава России, утверждёнными 21.06.2019", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРИКАЗЫВАЮ:", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца


        If видПриказа = "Стаж_зачисление" Then
            Call ВставитьПараграф(DOK, НомерАбзаца, "1. Зачислить на обучение по дополнительной профессиональной программе профессиональной переподготовки «" & Группа(2, 0) & "» в форме стажировки в объеме " & Группа(3, 0) & " учебных час. с " & Группа(0, 0) & " по " & Группа(1, 0) & " за счет средств " & средства & " согласно следующему списку:", "Times New Roman", 14, 3, 0, 1, 0, False)
        End If


        If видПриказа = "Приказ_Исп" Then
            Call ВставитьПараграф(DOK, НомерАбзаца, "1. Зачислить на обучение по дополнительной профессиональной программе повышения квалификации «" & Группа(2, 0) & "» в объеме " & Группа(3, 0) & " учебных час. с " & Группа(0, 0) & " по " & Группа(1, 0) & " за счет средств " & средства & " согласно следующему списку:", "Times New Roman", 14, 3, 0, 1, 0, False)
        End If

        If видПриказа = "ППЗачисление" Then
            Call ВставитьПараграф(DOK, НомерАбзаца, "1. Зачислить на обучение по дополнительной профессиональной программе профессиональной переподготовки «" & Группа(2, 0) & "» в объеме " & Группа(3, 0) & " учебных час. с " & Группа(0, 0) & " по " & Группа(1, 0) & " за счет средств " & средства & " согласно следующему списку:", "Times New Roman", 14, 3, 0, 1, 0, False)
        End If

        If видПриказа = "ПО_Зачисление" Then
            Call ВставитьПараграф(DOK, НомерАбзаца, "1. Зачислить на обучение по основной программе профессионального обучения «" & Группа(2, 0) & "» в объеме " & Группа(3, 0) & " учебных час. с " & Группа(0, 0) & " по " & Группа(1, 0) & " за счет " & средства & " согласно следующему списку:", "Times New Roman", 14, 3, 0, 1, 0, False)
        End If

        слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, tabl, слушатели)

        tabl.Range.select
        MSWord.Selection.Cut
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, DOK.Paragraphs.count, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        If видПриказа = "Стаж_зачисление" Then

            DOK.Paragraphs.Add()
            НомерАбзаца = DOK.Paragraphs.count
            Call ВставитьПараграф(DOK, НомерАбзаца, "2. Сформировать из вышеуказанных слушателей группу № " & АСформироватьПриказ.НомерГруппы.Text & ".", "Times New Roman", 14, 3, 0, 1, 0, False)
            НомерАбзаца = DOK.Paragraphs.count

        End If



        ТекущаяСтраница = DOK.Range.Information(3)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs.Add()
        ПроверкаСтраницы = DOK.Range.Information(3)
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.Delete
        'MSWord.Visible = True
        If ТекущаяСтраница = ПроверкаСтраницы Then

            НомерАбзаца = DOK.Paragraphs.count
            строкДоСлСтраницы = строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
            НомерАбзаца = DOK.Paragraphs.count

            If видПриказа = "Стаж_зачисление" Then

                If строкДоСлСтраницы <= 5 And строкДоСлСтраницы >= 0 Then

                    While строкДоСлСтраницы > 0

                        DOK.Paragraphs.Add()
                        НомерАбзаца = 1 + НомерАбзаца
                        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                        строкДоСлСтраницы = строкДоСлСтраницы - 1

                    End While

                End If



            Else

                If строкДоСлСтраницы < 5 And строкДоСлСтраницы >= 0 Then

                    While строкДоСлСтраницы > 0

                        DOK.Paragraphs.Add()
                        НомерАбзаца = 1 + НомерАбзаца
                        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                        строкДоСлСтраницы = строкДоСлСтраницы - 1

                    End While

                End If


            End If

        End If



        If видПриказа = "Стаж_зачисление" Then

            DOK.Paragraphs.Add()
            НомерАбзаца = DOK.Paragraphs.count
            СтрокаЗапроса = АСформироватьПриказ.РуководительСтажировки.Text
            Call ВставитьПараграф(DOK, НомерАбзаца, "3. Назначить руководителем стажировки " & АСформироватьПриказ.РуководительСтажировки.Text & ", " & АСформироватьПриказ.РуководительСтажировкиДолжность.Text & ".", "Times New Roman", 14, 3, 0, 1, 0, False)

        Else
            DOK.Paragraphs.Add()
            НомерАбзаца = DOK.Paragraphs.count
            Call ВставитьПараграф(DOK, НомерАбзаца, "2. Сформировать из вышеуказанных слушателей группу № " & АСформироватьПриказ.НомерГруппы.Text & ".", "Times New Roman", 14, 3, 0, 1, 0, False)
        End If


        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьУтверждающего(MSWord, DOK, НомерАбзаца, видПриказа)

        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.Delete

        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)
        НомерАбзаца = DOK.Paragraphs.count

        НомерАбзаца = вставитьЛистСогласования(MSWord, DOK, Дата, НомерАбзаца, видПриказа)

        Вспомогательный.savePrikazBlank(DOK, ААОсновная.prikazKodGroup, видПриказа, ПутьККаталогуСРесурсами, "Приказы")
        MSWord.Visible = True

        'Call сохранить(DOK, видПриказа)




    End Sub

    Sub ПриказПК_Отчисление(видПриказа As String)
        Dim MSWord
        Dim DOK
        Dim Группа
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer
        Dim Дата As String, СтрокаЗапроса As String



        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас, Финансирование FROM Группа WHERE Код = " & ААОсновная.prikazKodGroup & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub

        первыйПункт = "Об отчислении"
        второйПункт = "слушателя"
        третийПункт = "На основании Положения о повышении квалификации специалистов с медицинским и фармацевтическим образованием ФГБУ ДПО ВУНМЦ Минздрава России, утверждённым 21.06.2019, и на основании неудовлетворительных результатов итоговой аттестации"
        четвертыйПункт = "1. Считать слушателя группы № " & АСформироватьПриказ.НомерГруппы.Text & ", дополнительной профессиональной программы повышения квалификации «" & Группа(2, 0) & "» " & АСформироватьПриказ.Ответственный.Text & ", не выполнившим учебный план."
        пятыйПункт = "2. Выдать указанному выше слушателю справку установленного образца."

        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "3. Отчислить вышеперечисленного слушателя.", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьУтверждающего(MSWord, DOK, НомерАбзаца, видПриказа)

        MSWord.Selection.InsertBreak(Type:=7)

        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        НомерАбзаца = вставитьЛистСогласования(MSWord, DOK, Дата, НомерАбзаца, видПриказа)


        MSWord.Visible = True

        Call сохранить(DOK, видПриказа)


    End Sub
    Function вставитьСоставКомиссии(MSWord As Object, DOK As Object, Дата As String, НомерАбзаца As Integer) As Integer
        Dim Tabl

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), 7, 2)

        Tabl.Cell(1, 1).Range.Text = "Председатель комиссии:"
        Tabl.Cell(2, 2).Range.Text = АСформироватьПриказ.ОтветственныйДолжность.Text
        'Tabl.Cell(2, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(2, 1).Range.Text = АСформироватьПриказ.Ответственный.Text

        Tabl.Cell(4, 1).Range.Text = "Члены комиссии:"
        'Tabl.Cell(4, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(5, 2).Range.Text = АСформироватьПриказ.РуководительСтажировкиДолжность.Text
        Tabl.Cell(5, 1).Range.Text = АСформироватьПриказ.РуководительСтажировки.Text
        'Tabl.Cell(5, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(6, 2).Range.Text = АСформироватьПриказ.Комиссия2Должность.Text
        Tabl.Cell(6, 1).Range.Text = АСформироватьПриказ.Комиссия2.Text
        'Tabl.Cell(6, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(7, 2).Range.Text = АСформироватьПриказ.Комиссия3Должность.Text
        Tabl.Cell(7, 1).Range.Text = АСформироватьПриказ.Комиссия3.Text
        'Tabl.Cell(7, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(2, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(2, 1).Range.ParagraphFormat.Alignment = 0


        Tabl.Cell(4, 1).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(5, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(5, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(6, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(6, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(7, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(7, 1).Range.ParagraphFormat.Alignment = 0

        'DOK.Paragraphs(НомерАбзаца).LeftIndent = 28.34646
        Tabl.Range.ParagraphFormat.LineSpacing = 12
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14
        Tabl.Columns(2).Width = 270
        Tabl.Columns(1).Width = 220

        Tabl.Range.select
        MSWord.Selection.Cut
        'DOK.Paragraphs(НомерАбзаца - 1).LeftIndent = 28.34646
        НомерАбзаца = НомерАбзаца + 1
        DOK.Paragraphs.Add()
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
        DOK.Paragraphs(НомерАбзаца).Range.select
        MSWord.Selection.PasteAndFormat(0)


        НомерАбзаца = DOK.Paragraphs.count

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        вставитьСоставКомиссии = DOK.Paragraphs.count

    End Function

    Function вставитьСекретаряКомиссии(MSWord As Object, DOK As Object, Дата As String, НомерАбзаца As Integer) As Integer
        Dim Tabl

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), 2, 2)



        Tabl.Cell(1, 1).Range.Text = "Секретарь комиссии:"
        'Tabl.Cell(1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(2, 2).Range.Text = АСформироватьПриказ.СекретарьКомиссииДолжность.Text
        Tabl.Cell(2, 1).Range.Text = АСформироватьПриказ.СекретарьКомиссии.Text
        'Tabl.Cell(2, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(2, 2).Range.ParagraphFormat.Alignment = 3
        Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 0
        ' DOK.Tables(3).Cell(1, 1).Range.Font.Bold = True
        Tabl.Cell(2, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Range.ParagraphFormat.LineSpacing = 12
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14
        Tabl.Columns(1).Width = 220
        Tabl.Columns(2).Width = 270

        Tabl.Range.select
        MSWord.Selection.Cut
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        MSWord.Selection.PasteAndFormat(0)

        вставитьСекретаряКомиссии = DOK.Paragraphs.count

    End Function


    Function вставитьУтверждающего(MSWord As Object, DOK As Object, НомерАбзаца As Integer, видПриказа As String) As Integer
        Dim номерТаблицы As Integer
        Dim Tabl

        If видПриказа = "ПО_ДопускКИА" Then
            номерТаблицы = 4
        Else
            номерТаблицы = 2
        End If

        DOK.Paragraphs.Add()

        НомерАбзаца = 1 + НомерАбзаца

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), 1, 2)


        Tabl.Cell(1, 1).Range.Text = АСформироватьПриказ.УтверждаетДолжность.Text
        'Tabl.Cell(1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(1, 2).Range.Text = перевернуть(АСформироватьПриказ.Утверждает.Text)

        Tabl.Cell(1, 2).Range.ParagraphFormat.Alignment = 2
        Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 3
        Tabl.Range.ParagraphFormat.LineSpacing = 12
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14
        Tabl.Columns(1).Width = 320
        Tabl.Columns(2).Width = 170
        ' DOK.Paragraphs(НомерАбзаца).LeftIndent = 28.34646
        НомерАбзаца = DOK.Paragraphs.count

        Tabl.Range.select
        MSWord.Selection.Cut
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        MSWord.Selection.PasteAndFormat(0)
        вставитьУтверждающего = DOK.Paragraphs.count

    End Function
    Sub ВставитьПараграф(DOK As Object, номерАбзаца As Integer, текст As String, Шрифт As String, РазмерШрифта As Integer, Выравнивание As Double, ОтступКраснаяСтрока As Double, ОтступПередАбзацем As Double, МежстрочныйИнтервал As Double, Жирный As Boolean)

        DOK.Paragraphs(номерАбзаца).Range.Font.Name = Шрифт
        DOK.Paragraphs(номерАбзаца).Range.Font.Size = РазмерШрифта
        DOK.Paragraphs(номерАбзаца).Range.Text = текст
        DOK.Paragraphs(номерАбзаца).Format.Alignment = Выравнивание
        DOK.Paragraphs(номерАбзаца).LeftIndent = 28.34646 * ОтступКраснаяСтрока
        DOK.Paragraphs(номерАбзаца).FirstLineIndent = 28.34646 * ОтступПередАбзацем
        DOK.Paragraphs(номерАбзаца).LineUnitAfter = 0
        DOK.Paragraphs(номерАбзаца).LineUnitBefore = 0
        DOK.Paragraphs(номерАбзаца).SpaceAfter = 0
        DOK.Paragraphs(номерАбзаца).SpaceBefore = МежстрочныйИнтервал
        DOK.Paragraphs(номерАбзаца).Range.Font.Bold = Жирный
        DOK.Paragraphs(номерАбзаца).Range.ParagraphFormat.LineSpacing = 12
    End Sub

    Function перевернуть(строка As String) As String
        Dim часть As String
        If Len(строка) < 4 Then
            перевернуть = ""
            Exit Function
        End If
        часть = Right(строка, 4)
        строка = Left(строка, Len(строка) - 4)
        строка = часть & " " & строка
        строка = Left(строка, Len(строка) - 1)
        перевернуть = строка

    End Function


    Function перенос(DOK As Object, НомерАбзаца As Integer, видПриказа As String, счетчик As Integer) As Integer
        If счетчик = 15 Then

            счетчик = 1
            While счетчик <= 4
                DOK.Paragraphs.Add()
                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                счетчик = счетчик + 1
            End While

        End If

        If счетчик = 16 Then

            счетчик = 1
            While счетчик <= 3
                DOK.Paragraphs.Add()
                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                счетчик = счетчик + 1
            End While
        End If

        If счетчик = 17 Then

            счетчик = 1
            While счетчик <= 2
                DOK.Paragraphs.Add()
                НомерАбзаца = 1 + НомерАбзаца
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)
                счетчик = счетчик + 1
            End While
        End If

        If счетчик = 18 Then

            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца
            Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        End If

        If Not видПриказа = "Стаж_зачисление" Then

            If Not счетчик = 20 Then
                НомерАбзаца = 1 + НомерАбзаца
                DOK.Paragraphs.Add()
                Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

            End If
            DOK.Paragraphs.Add()
            НомерАбзаца = 1 + НомерАбзаца

            If видПриказа = "ПП_Практика" Then
                Call ВставитьПараграф(DOK, НомерАбзаца, "3. Назначить руководителем практической подготовки от Центра " & АСформироватьПриказ.ОтветственныйДолжность.Text & " " & перевернуть(АСформироватьПриказ.Ответственный.Text), "Times New Roman", 14, 3, 0, 1, 0, False)
            Else
                Call ВставитьПараграф(DOK, НомерАбзаца, "2. Сформировать из вышеуказанных слушателей группу № " & АСформироватьПриказ.НомерГруппы.Text, "Times New Roman", 14, 3, 0, 1, 0, False)
            End If
        End If

        перенос = НомерАбзаца
    End Function
    Function ВывестиCписокСлушателей(DOK As Object, Группа As String, номерАбзаца As Integer) As Integer
        Dim СтрокаЗапроса As String
        Dim Слушатели
        Dim НаВывод
        Dim Счетчик As Integer

        СтрокаЗапроса = "SELECT Слушатель FROM СоставГрупп WHERE Группа= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            MsgBox("В выбранной группе нет слушателей")
            ВывестиCписокСлушателей = 0
            Exit Function

        End If

        ReDim НаВывод(3, UBound(Слушатели, 2))

        СтрокаЗапроса = "SELECT Фамилия , Имя , Отчество FROM Слушатель WHERE"
        Счетчик = 0
        While Счетчик <= UBound(Слушатели, 2)

            СтрокаЗапроса = СтрокаЗапроса & " Снилс=" & Chr(39) & Слушатели(0, Счетчик) & Chr(39) & " OR"
            Счетчик = Счетчик + 1
        End While

        СтрокаЗапроса = Left(СтрокаЗапроса, Len(СтрокаЗапроса) - 3)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        Счетчик = 0

        While Счетчик <= UBound(Слушатели, 2)

            DOK.Paragraphs.Add()
            номерАбзаца = 1 + номерАбзаца
            Call ВставитьПараграф(DOK, номерАбзаца, Счетчик + 1 & ". " & Слушатели(0, Счетчик) & " " & Слушатели(1, Счетчик) & " " & Слушатели(2, Счетчик), "Times New Roman", 14, 3, 0, 1, 0, False)
            Счетчик = Счетчик + 1
        End While

        ВывестиCписокСлушателей = Счетчик

    End Function

    Function СписокСлушателей(Група As String) As Object
        Dim Слушатели
        Dim НаВывод
        Dim СтрокаЗапроса As String
        Dim Счетчик As Integer

        СтрокаЗапроса = "SELECT Слушатель FROM СоставГрупп WHERE Группа= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            СписокСлушателей = Слушатели
            Exit Function

        End If

        СтрокаЗапроса = "SELECT Фамилия , Имя , Отчество FROM Слушатель WHERE"
        Счетчик = 0
        While Счетчик <= UBound(Слушатели, 2)

            СтрокаЗапроса = СтрокаЗапроса & " Снилс=" & Chr(39) & Слушатели(0, Счетчик) & Chr(39) & " OR"
            Счетчик = Счетчик + 1
        End While

        СтрокаЗапроса = Left(СтрокаЗапроса, Len(СтрокаЗапроса) - 3)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            СписокСлушателей = Слушатели
            Exit Function

        End If

        ReDim НаВывод(0, UBound(Слушатели, 2))

        Счетчик = 0

        While Счетчик <= UBound(Слушатели, 2)
            НаВывод(0, Счетчик) = Слушатели(0, Счетчик) & " " & Слушатели(1, Счетчик) & " " & Слушатели(2, Счетчик)
            Счетчик = Счетчик + 1
        End While

        СписокСлушателей = НаВывод

    End Function


    Sub вставитьКороткуюШапку(MSWord As Object, DOK As Object, НомерАбзаца As Integer)


        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With


        Call ВставитьПараграф(DOK, НомерАбзаца, "Федеральное государственное бюджетное учреждение", "Times New Roman", 10, 1, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "дополнительного профессионального образования", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«Всероссийский учебно-научно-методический центр по непрерывному медицинскому ", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "и фармацевтическому образованию» Министерства здравоохранения Российской Федерации", "Times New Roman", 10, 1, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "(ФГБУ ДПО ВУНМЦ Минздрава России)", "Times New Roman", 10, 1, 0, 1, 0, False)

    End Sub

    Function вставитьШапку(MSWord As Object, DOK As Object, Дата As String, НомерАбзаца As Integer) As Integer


        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With


        Call ВставитьПараграф(DOK, НомерАбзаца, "Федеральное государственное бюджетное учреждение", "Times New Roman", 10, 1, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "дополнительного профессионального образования", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "«Всероссийский учебно-научно-методический центр по непрерывному медицинскому ", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "и фармацевтическому образованию» Министерства здравоохранения Российской Федерации", "Times New Roman", 10, 1, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "(ФГБУ ДПО ВУНМЦ Минздрава России)", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "ПРИКАЗ", "Times New Roman", 14, 1, 0, 1, 2, True)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        DOK.Tables.Add(DOK.Range(0, 0), 1, 2)

        DOK.Tables(1).Range.select
        MSWord.Selection.Cut

        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        MSWord.Selection.PasteAndFormat(0)

        DOK.Tables(1).Cell(1, 1).Range.Text = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        DOK.Tables(1).Cell(1, 2).Range.Text = " № _______________"
        DOK.Tables(1).Cell(1, 2).Range.ParagraphFormat.Alignment = 2
        DOK.Tables(1).Cell(1, 1).Range.ParagraphFormat.Alignment = 0
        DOK.Tables(1).Range.ParagraphFormat.LineSpacing = 12
        DOK.Tables(1).Range.Font.Name = "Times New Roman"
        DOK.Tables(1).Range.Font.Size = 14
        DOK.Paragraphs(НомерАбзаца).LeftIndent = 28.34646

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "г. Москва", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 0, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 0, 0, False)

        вставитьШапку = НомерАбзаца

    End Function


    Function вставитьЛистСогласования(MSWord As Object, DOK As Object, Дата As String, НомерАбзаца As Integer, видПриказа As String) As Integer
        Dim номерТаблицы As Integer
        Dim Tabl

        If видПриказа = "ПО_ДопускКИА" Then
            номерТаблицы = 5
        Else
            номерТаблицы = 3
        End If
        Tabl = DOK.Tables.Add(DOK.Range(0, 0), 13, 3)

        Tabl.Cell(1, 1).Range.Text = "Проект вносит:"
        'Tabl.Cell(1, 1).Range.ParagraphFormat.FirstLineIndent = 28.35
        Tabl.Cell(3, 1).Range.Text = АСформироватьПриказ.ПроектВноситДолжность.Text
        Tabl.Cell(3, 3).Range.Text = перевернуть(АСформироватьПриказ.ПроектВносит.Text)
        'Tabl.Cell(3, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(5, 1).Range.Text = "Исполнитель:"
        'Tabl.Cell(5, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(7, 3).Range.Text = перевернуть(АСформироватьПриказ.Исполнитель.Text)
        Tabl.Cell(7, 1).Range.Text = АСформироватьПриказ.ИсполнительДолжность.Text
        'Tabl.Cell(7, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(9, 1).Range.Text = "Согласовано:"
        'Tabl.Cell(9, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(11, 3).Range.Text = перевернуть(АСформироватьПриказ.Согласовано1.Text)
        Tabl.Cell(11, 1).Range.Text = АСформироватьПриказ.Согласовано1Должность.Text
        'Tabl.Cell(11, 1).Range.ParagraphFormat.FirstLineIndent = 28.35

        Tabl.Cell(13, 3).Range.Text = перевернуть(АСформироватьПриказ.Согласовано2.Text)
        Tabl.Cell(13, 1).Range.Text = АСформироватьПриказ.Согласовано2Должность.Text
        'Tabl.Cell(13, 1).Range.ParagraphFormat.FirstLineIndent = 28.35


        Tabl.Cell(3, 3).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(1, 1).Range.ParagraphFormat.Alignment = 0
        ' DOK.Tables(3).Cell(1, 1).Range.Font.Bold = True
        Tabl.Cell(3, 1).Range.ParagraphFormat.Alignment = 0


        Tabl.Cell(5, 1).Range.ParagraphFormat.Alignment = 0
        ' DOK.Tables(3).Cell(5, 1).Range.Font.Bold = True
        Tabl.Cell(7, 3).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(7, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(9, 1).Range.ParagraphFormat.Alignment = 0
        'DOK.Tables(3).Cell(9, 1).Range.Font.Bold = True
        Tabl.Cell(11, 3).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(11, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Cell(13, 3).Range.ParagraphFormat.Alignment = 0
        Tabl.Cell(13, 1).Range.ParagraphFormat.Alignment = 0

        Tabl.Range.ParagraphFormat.LineSpacing = 12
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14
        Tabl.Columns(1).Width = 250
        Tabl.Columns(2).Width = 90
        Tabl.Columns(3).Width = 150
        НомерАбзаца = 1 + НомерАбзаца

        Tabl.Cell(4, 1).Range.select
        MSWord.selection.TypeParagraph

        Tabl.Cell(8, 1).Range.select
        MSWord.selection.TypeParagraph
        MSWord.selection.TypeParagraph

        Tabl.Cell(12, 1).Range.select
        MSWord.selection.TypeParagraph

        Tabl.Range.select
        MSWord.Selection.Cut
        'DOK.Paragraphs(НомерАбзаца - 1).LeftIndent = 28.34646
        'DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        DOK.Paragraphs(НомерАбзаца).Range.select
        MSWord.Selection.PasteAndFormat(0)
        НомерАбзаца = DOK.Paragraphs.count
        вставитьЛистСогласования = НомерАбзаца

    End Function

    Function строкДоСледующейСтраницы(DOK As Object, номерАбзаца As Integer, ТекущаяСтраница As Integer)

        Dim КоличествоСтраниц As Integer, стрДоСледующейСтраницы As Integer

        стрДоСледующейСтраницы = 0
        КоличествоСтраниц = DOK.Range.Information(3)
        While КоличествоСтраниц <> ТекущаяСтраница + 1
            КоличествоСтраниц = DOK.Range.Information(3)
            DOK.Paragraphs.Add
            стрДоСледующейСтраницы = стрДоСледующейСтраницы + 1
        End While

        строкДоСледующейСтраницы = стрДоСледующейСтраницы - 2

        While стрДоСледующейСтраницы > 0
            DOK.Paragraphs(стрДоСледующейСтраницы + номерАбзаца).Range.Delete
            стрДоСледующейСтраницы = стрДоСледующейСтраницы - 1
        End While


    End Function


End Module
