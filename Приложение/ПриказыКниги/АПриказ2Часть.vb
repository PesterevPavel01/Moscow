Module АПриказ2Часть
    Public слушателиПолный





    Sub ПО_Окончание(видПриказа As String)

        Dim MSWord
        Dim DOK, DOK2, Paragr
        Dim Группа, Tabl, слушатели
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String, path As String
        Dim НомерАбзаца As Integer, ТекущаяСтраница As Integer, строкДоСтраницы2 As Integer, номерТаблицы As Integer, счетчик As Integer
        Dim Дата As String, СтрокаЗапроса As String


        слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас,НомерСвид, РегНомерСвид, ДатаВыдачиСвид, НомерПротоколаИА, Квалификация FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)



        If ПрисвоитьНомераПО(АСформироватьПриказ.НомерГруппы.Text, Группа) Then

            Exit Sub

        End If

        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add
        'MSWord.Visible = True

        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub



        первыйПункт = "Об окончании"
        второйПункт = "обучающимися обучения"
        третийПункт = "На основании Положением о порядке и условиях профессионального обучения в ФГБУ ДПО ВУНМЦ Минздрава России, утверждённого __________, и на основании результатов итоговой аттестации"
        четвертыйПункт = "1. Считать нижеперечисленных слушателей группы № " & АСформироватьПриказ.НомерГруппы.Text & ", основной программы профессионального обучения «" & Группа(2, 0) & "» успешно завершившими обучение согласно списку:"
        пятыйПункт = "0"


        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)

        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, Tabl, слушатели)

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
        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Выдать перечисленным выше слушателям свидетельство о профессии рабоче-го, должности служащего.", "Times New Roman", 14, 3, 0, 1, 0, False)

        ТекущаяСтраница = DOK.Range.Information(3)

        строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)

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
        Call ВставитьПараграф(DOK, НомерАбзаца, "3. Отчислить вышеперечисленных слушателей.", "Times New Roman", 14, 3, 0, 1, 0, False)

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

        path = Application.StartupPath
        path = path & "\Не трогать\Таблица_ПО_Окончание.docx"

        DOK2 = MSWord.Documents.Open(path, ReadOnly:=True)

        счетчик = 0

        While счетчик < UBound(слушатели, 2) + 1

            DOK.Bookmarks("\EndOfDoc").Select

            MSWord.Selection.InsertBreak(2)

            DOK.Bookmarks("\EndOfDoc").Select





            DOK2.Tables(1).Range.Select
            MSWord.Selection.Copy

            DOK.Bookmarks("\EndofDoc").Select

            With MSWord.Selection.PageSetup

                .TopMargin = 15
                .LeftMargin = 12

            End With

            MSWord.Selection.PasteAndFormat(0)


            '  MSWord.Selection.PageSetup.Orientation = 1

            DOK.Bookmarks("\EndOfDoc").Select

            Tabl = DOK.Tables(5 + счетчик * 1)

            Tabl.Cell(1, 1).Range.text = "Федеральное государственное бюджетное учреждение дополнительного профессионального образования «Всероссийский учебно-научно-методический центр по непрерывному медицинскому и фармацевтическому образованию» Министерства здравоохранения Российской Федерации"
            Tabl.Cell(1, 3).Range.text = слушатели(0, счетчик)
            Tabl.Cell(2, 3).Range.text = "в период с " & Группа(0, 0) & " по " & Группа(1, 0)
            Tabl.Cell(3, 3).Range.text = "«" & Группа(2, 0) & "»"
            Tabl.Cell(3, 3).Range.Paragraphs.Add()
            Paragr = Tabl.Cell(3, 3).Range.Paragraphs.Add()
            Paragr.Range.Text = "в объёме"
            Paragr = Tabl.Cell(3, 3).Range.Paragraphs.Add()
            Paragr.Range.Text = Группа(3, 0) & " часов"
            Tabl.Cell(3, 3).Range.Paragraphs.Add()
            Paragr = Tabl.Cell(3, 3).Range.Paragraphs.Add()
            Paragr.Range.Text = "с присвоением квалификации"
            Paragr = Tabl.Cell(3, 3).Range.Paragraphs.Add()
            Paragr.Range.Text = "«" & Группа(8, 0) & "»"
            Tabl.Cell(4, 2).Range.Text = Группа(5, 0) + счетчик
            Tabl.Cell(5, 2).Range.Text = Группа(6, 0)

            счетчик = счетчик + 1

        End While

        DOK2.Close(SaveChanges:=0)

        Call сохранить(DOK, видПриказа)

        MSWord.Visible = True
    End Sub
    Function ПрисвоитьНомераПО(НомерГрупы As String, Группа As Object) As Boolean
        Dim Слушатели
        Dim МассивЗапросов
        Dim Счетчик As Integer, Число As Integer
        Dim строкаЗапроса As String
        Счетчик = 0
        строкаЗапроса = "SELECT Слушатель FROM СоставГрупп WHERE Группа= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)

        ReDim МассивЗапросов(0)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(строкаЗапроса)

        Try
            Число = Группа(4, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Номер свидетельства группы не задан или не является числом"
            предупреждение.ShowDialog()
            ПрисвоитьНомераПО = True
            Exit Function
        End Try

        Try
            Число = Группа(5, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Регистрационный номер свидетельства группы не задан или не является числом"
            предупреждение.ShowDialog()
            ПрисвоитьНомераПО = True
            Exit Function
        End Try


        While Счетчик <= UBound(Слушатели, 2)

            строкаЗапроса = "UPDATE СоставГрупп SET НомерСвид = " & Группа(4, 0) + Счетчик & " , РегНомерСвид= " & Группа(5, 0) + Счетчик & " WHERE Группа = " & Chr(39) & НомерГрупы & Chr(39) & " AND Слушатель = " & Chr(39) & Слушатели(0, Счетчик) & Chr(39)
            МассивЗапросов(0) = строкаЗапроса
            ЗаписьВБазу.ЗаписьВБазу(строкаЗапроса)
            Счетчик = Счетчик + 1

        End While

        ПрисвоитьНомераПО = False

    End Function

    Sub ПП_ПриложениеКДиплому()
        Dim MSWord
        Dim DOK1, DOK2
        Dim Группа, Tabl, слушатели, слушателиР, Программа
        Dim Число As Integer, счетчик As Integer, счетчикСтрок As Integer, счетчикЗаписей As Integer
        Dim СтрокаЗапроса As String, path As String, ДатаСтр As String



        слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

        слушатели = Тренеровочный.SQLзапрос(АСформироватьПриказ.НомерГруппы.Text)

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас,НомерДиплома, РегНомерДиплома, ДатаВыдачиДиплома, НомерПротоколаИА FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        Try
            Число = Группа(4, 0)
        Catch ex As Exception
            предупреждение.текст.Text = "В выбранной группе номер диплома не указан или не является числом"
            ОткрытьФорму(предупреждение)
            Exit Sub
        End Try

        СтрокаЗапроса = "SELECT Модуль, Часы FROM ПрограммаМодулиЧасы INNER JOIN Группа ON ПрограммаМодулиЧасы.Программа = Группа.Программа WHERE Группа.Номер = " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39) & " ORDER BY ПрограммаМодулиЧасы.НомерМодуля"
        Программа = перевернутьмассив(ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса))

        If Программа(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Не указаны модули для программы выбранной группы"
            ОткрытьФорму(предупреждение)
            Exit Sub

        End If

        For счетчик = 0 To UBound(Программа, 1)

            If Программа(счетчик, 1).ToString = "" Then

                ФормаДаНет.ТекстДаНет.Text = "У модуля " & Программа(счетчик, 0) & " не указано количество часов! Продолжить?"
                ФормаДаНет.ShowDialog()

                If ЗаписьВБазу.УдалитьСовпадения Then
                    ЗаписьВБазу.УдалитьСовпадения = False
                    Exit For
                Else
                    ЗаписьВБазу.УдалитьСовпадения = False
                    Exit Sub
                End If

                ФормаДаНет.ТекстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

            End If

        Next

        path = Application.StartupPath
        path = path & "\Не трогать\ПП_Приложение к диплому_1.docx"



        MSWord = CreateObject("Word.Application")

        MSWord.DisplayAlerts = False
        DOK1 = MSWord.Documents.add
        'MSWord.Visible = True

        Call сохранить(DOK1, "ПП_ПриложениеКДиплому")


        DOK2 = MSWord.Documents.Open(path, ReadOnly:=True)

        ' MSWord.Visible = True

        счетчик = 1

        While счетчик <= UBound(слушатели, 2) + 1

            DOK1.Bookmarks("\EndOfDoc").Select

            With MSWord.Selection.PageSetup

                .TopMargin = 21
                .LeftMargin = 120

            End With


            DOK2.Tables(1).Range.Select
            MSWord.Selection.Copy

            DOK1.Bookmarks("\EndofDoc").Select
            MSWord.Selection.PasteAndFormat(0)

            Tabl = DOK1.Tables(счетчик * 2 - 1)


            настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs(1), 0, "Times New Roman", 12, Группа(4, 0) + счетчик - 1)

            слушателиР = слушатели(0, счетчик - 1).split

            Tabl.Cell(2, 1).Range.text = слушателиР(0)
            Tabl.Cell(3, 1).Range.text = слушателиР(1) & " " & слушателиР(2)
            Tabl.Cell(4, 1).Range.text = слушатели(1, счетчик - 1)

            ДатаСтр = Format(Группа(0, 0), "dd MMMM yyyy")
            Dim split As String() = ДатаСтр.Split

            Tabl.Cell(5, 1).Range.text = split(0)
            Tabl.Cell(5, 2).Range.text = split(1)
            Tabl.Cell(5, 3).Range.text = split(2)

            ДатаСтр = Format(Группа(1, 0), "dd MMMM yyyy")
            split = ДатаСтр.Split

            Tabl.Cell(5, 4).Range.text = split(0)
            Tabl.Cell(5, 5).Range.text = split(1)
            Tabl.Cell(5, 6).Range.text = split(2)

            Tabl.Cell(6, 1).Range.text = "Федеральном государственном бюджетном учреждении дополнительного профессионального 
образования «Всероссийский учебно-научно-методический центр по непрерывному медицинскому 


и фармацевтическому образованию» Министерства здравоохранения Российской Федерации
"

            Tabl.Cell(7, 1).Range.text = "профессиональной переподготовки"
            Tabl.Cell(8, 1).Range.text = "по специальности"
            Tabl.Cell(9, 1).Range.text = "«" & Группа(2, 0) & "»"
            Tabl.Cell(10, 1).Range.text = "не предусмотрено"

            DOK1.Paragraphs.Add()

            DOK1.Bookmarks("\EndOfDoc").Select

            MSWord.Selection.InsertBreak(Type:=2)

            DOK1.Bookmarks("\EndOfDoc").Select

            With MSWord.Selection.PageSetup

                .TopMargin = 113
                .LeftMargin = 120

            End With

            DOK2.Tables(2).Range.Select
            MSWord.Selection.Copy

            DOK1.Bookmarks("\EndOfDoc").Select

            MSWord.Selection.PasteAndFormat(0)

            Tabl = DOK1.Tables(счетчик * 2)



            Tabl.Cell(2, 1).Range.text = слушателиР(0)


            DOK1.Bookmarks("\EndOfDoc").Select

            Call ВставитьПараграф(DOK1, DOK1.Paragraphs.Count, "", "Times New Roman", 11, 3, 0, 0, 8, False)
            DOK1.Paragraphs.Add()
            Call ВставитьПараграф(DOK1, DOK1.Paragraphs.Count, "", "Times New Roman", 11, 3, 0, 0, 8, False)
            DOK1.Paragraphs.Add()
            Call ВставитьПараграф(DOK1, DOK1.Paragraphs.Count, "", "Times New Roman", 11, 3, 0, 0, 8, False)
            DOK1.Paragraphs.Add()
            Call ВставитьПараграф(DOK1, DOK1.Paragraphs.Count, "", "Times New Roman", 11, 3, 0, 0, 8, False)
            DOK1.Paragraphs.Add()
            Call ВставитьПараграф(DOK1, DOK1.Paragraphs.Count, "", "Times New Roman", 11, 3, 0, 0, 8, False)
            DOK1.Paragraphs.Add()
            Call ВставитьПараграф(DOK1, DOK1.Paragraphs.Count, "", "Times New Roman", 11, 3, 0, 0, 8, False)
            DOK1.Paragraphs.Add()
            Call ВставитьПараграф(DOK1, DOK1.Paragraphs.Count, "			" & Группа(3, 0), "Times New Roman", 14, 3, 0, 0, 2, False)

            DOK1.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.InsertBreak(Type:=2)

            'СтрокаЗапроса = "SELECT программа.модуль1, программа.модуль2, программа.модуль3, программа.модуль4, программа.модуль5, программа.модуль6, программа.модуль7, программа.модуль8, программа.модуль9, программа.модуль10 FROM программа WHERE Программа =" & Chr(39) & Группа(2, 0) & Chr(39)
            'Программа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

            счетчикСтрок = 0
            счетчикЗаписей = UBound(Программа, 1)

            While счетчикСтрок <= UBound(Программа, 1)
                If Not Программа(счетчикСтрок, 0) = "" Then

                    If счетчикСтрок + 1 > Tabl.Rows.Count Then

                        Tabl.Rows.add

                    End If

                    If АСформироватьПриказ.CheckBox1.Checked And Программа(счетчикСтрок, 0) = "Производственная практика" Then

                        Tabl.Cell(счетчикСтрок + 1, 1).Range.text = счетчикСтрок + 1 & "."
                        Tabl.Cell(счетчикСтрок + 1, 2).Range.text = Программа(счетчикСтрок, 0)
                        Tabl.Cell(счетчикСтрок + 1, 3).Range.text = АСформироватьПриказ.ПрактическаяПодготовка.Text
                        Tabl.Cell(счетчикСтрок + 1, 4).Range.text = слушатели(2 + счетчикСтрок, счетчик - 1)

                    ElseIf АСформироватьПриказ.CheckBox1.Checked And Программа(счетчикСтрок, 0) = "Итоговая аттестация" Then

                        Tabl.Cell(счетчикСтрок + 1, 1).Range.text = счетчикСтрок + 1 & "."
                        Tabl.Cell(счетчикСтрок + 1, 2).Range.text = Программа(счетчикСтрок, 0)
                        Tabl.Cell(счетчикСтрок + 1, 3).Range.text = АСформироватьПриказ.ИтоговаяАттестация.Text
                        Tabl.Cell(счетчикСтрок + 1, 4).Range.text = слушатели(2 + счетчикСтрок, счетчик - 1)

                    Else

                        ' СтрокаЗапроса = "SELECT часы FROM модули WHERE наименование =" & Chr(39) & Программа(счетчикСтрок, 0) & Chr(39)
                        ' Модуль = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

                        Tabl.Cell(счетчикСтрок + 1, 1).Range.text = счетчикСтрок + 1 & "."


                        If Программа(счетчикСтрок, 0) = "Производственная практика" Or Программа(счетчикСтрок, 0) = "Итоговая аттестация" Then

                            Tabl.Cell(счетчикСтрок + 1, 2).Range.text = Программа(счетчикСтрок, 0)

                        Else Tabl.Cell(счетчикСтрок + 1, 2).Range.text = "УМ " & счетчикСтрок + 1 & " " & Программа(счетчикСтрок, 0)
                        End If

                        Tabl.Cell(счетчикСтрок + 1, 3).Range.text = "нет информации"
                        Tabl.Cell(счетчикСтрок + 1, 4).Range.text = "нет информации"

                        If Not Программа(счетчикСтрок, 1).ToString = "нет записей" Then

                            Tabl.Cell(счетчикСтрок + 1, 3).Range.text = Программа(счетчикСтрок, 1)
                            Tabl.Cell(счетчикСтрок + 1, 4).Range.text = слушатели(2 + счетчикСтрок, счетчик - 1)

                        Else

                            предупреждение.текст.Text = "Для модуля «" & Программа(счетчикСтрок, 1) & "» не указано количество часов"
                            ОткрытьФорму(предупреждение)

                        End If

                    End If


                ElseIf счетчикСтрок > 0 Then

                    While Tabl.Rows.Count > счетчикСтрок
                        счетчикЗаписей = Tabl.Rows.Count
                        Tabl.Rows(счетчикЗаписей).Delete

                    End While

                    Exit While

                Else

                    предупреждение.текст.Text = "Для программы «" & Группа(2, 0) & "» не указан модуль 1. Приложение сформировано некорректно!!!"
                    ОткрытьФорму(предупреждение)
                    Exit While

                End If

                счетчикСтрок = счетчикСтрок + 1

            End While



            счетчик = счетчик + 1

        End While
        DOK2.Close(SaveChanges:=0)
        DOK1.Save
        MSWord.Visible = True

    End Sub





    Sub ПП_Окончание(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Tabl, слушатели
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer, ТекущаяСтраница As Integer, строкДоСтраницы2 As Integer, номерТаблицы As Integer, счетчик As Integer
        Dim Дата As String, СтрокаЗапроса As String


        слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас,НомерДиплома, РегНомерДиплома, ДатаВыдачиДиплома, НомерПротоколаИА FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)



        If ПрисвоитьНомераПП(АСформироватьПриказ.НомерГруппы.Text, Группа) Then

            Exit Sub

        End If

        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add
        'MSWord.Visible = True




        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub



        первыйПункт = "Об окончании"
        второйПункт = "слушателями обучения"
        третийПункт = "В соответствии с Правилами приёма на обучение по программам дополнительного профессионального образования в ФГБУ ДПО ВУНМЦ Минздрава России, утверждёнными 21.06.2019"
        четвертыйПункт = "1. Считать нижеперечисленных слушателей группы № " & АСформироватьПриказ.НомерГруппы.Text & ", дополнительной профессиональной программы профессиональной переподготовки «" & Группа(2, 0) & "» успешно завершившими обучение согласно списку:"
        пятыйПункт = "0"


        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)




        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, Tabl, слушатели)

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
        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Выдать перечисленным выше слушателям диплом о профессиональной переподготовке.", "Times New Roman", 14, 3, 0, 1, 0, False)

        ТекущаяСтраница = DOK.Range.Information(3)
        строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
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
        Call ВставитьПараграф(DOK, НомерАбзаца, "3. Отчислить вышеперечисленных слушателей.", "Times New Roman", 14, 3, 0, 1, 0, False)

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




        счетчик = 0

        While счетчик < UBound(слушатели, 2) + 1

            DOK.Bookmarks("\EndOfDoc").Select

            MSWord.Selection.InsertBreak(2)

            DOK.Bookmarks("\EndOfDoc").Select

            MSWord.Selection.PageSetup.Orientation = 1

            DOK.Bookmarks("\EndOfDoc").Select

            Tabl = DOK.Tables.Add(DOK.Range(0, 0), 2, 3)

            Tabl.Range.Select
            MSWord.Selection.Cut

            НомерАбзаца = DOK.Paragraphs.Count
            Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 0, 0, False)

            НомерАбзаца = DOK.Paragraphs.Count
            DOK.Paragraphs(НомерАбзаца).Range.Select
            'DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.PageSetup.TopMargin = 14
            MSWord.Selection.PasteAndFormat(0)
            номерТаблицы = DOK.Tables.count
            Tabl = DOK.Tables(номерТаблицы)



            Call НастройкаТаблицыПП_О(MSWord, DOK, Tabl, слушателиПолный, Группа, счетчик + 1)

            счетчик = счетчик + 1
        End While
        Call сохранить(DOK, видПриказа)
        MSWord.Visible = True
    End Sub


    Sub ПК_Окончание(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Tabl, слушатели
        Dim первыйПункт As String, второйПункт As String, третийПункт As String, четвертыйПункт As String, пятыйПункт As String
        Dim НомерАбзаца As Integer, ТекущаяСтраница As Integer, строкДоСтраницы2 As Integer, номерТаблицы As Integer, счетчик As Integer
        Dim Дата As String, СтрокаЗапроса As String


        слушатели = СписокСлушателей(АСформироватьПриказ.НомерГруппы.Text)

        If слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

        СтрокаЗапроса = "SELECT ДатаНЗ, ДатаКЗ, Программа, КолЧас,НомерУд, РегНомерУд, ДатаВыдачиУд FROM Группа WHERE Номер= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)



        If ПрисвоитьНомера(АСформироватьПриказ.НомерГруппы.Text, Группа) Then

            Exit Sub

        End If

        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add
        'MSWord.Visible = True




        НомерАбзаца = вставитьШапку(MSWord, DOK, Дата, 1)
        If НомерАбзаца = 0 Then Exit Sub



        первыйПункт = "Об окончании"
        второйПункт = "слушателями обучения"
        третийПункт = "На основании Положения о повышении квалификации специалистов с медицинским и фармацевтическим образованием ФГБУ ДПО ВУНМЦ Минздрава России, утверждённого 21.06.2019, и на основании результатов итоговой аттестации"
        четвертыйПункт = "1. Считать нижеперечисленных слушателей группы № " & АСформироватьПриказ.НомерГруппы.Text & ", дополнительной профессиональной программы повышения квалификации «" & Группа(2, 0) & "» успешно завершившими обучение согласно списку:"
        пятыйПункт = "0"


        НомерАбзаца = ПерваяЧасть(DOK, НомерАбзаца, видПриказа, первыйПункт, второйПункт, третийПункт, четвертыйПункт, пятыйПункт)




        Tabl = DOK.Tables.Add(DOK.Range(0, 0), (UBound(слушатели, 2) + 1), 2)

        Call ТаблицаСоставГруппы(MSWord, DOK, Tabl, слушатели)

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
        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Выдать перечисленным выше слушателям удостоверения о повышении квалификации.", "Times New Roman", 14, 3, 0, 1, 0, False)

        ТекущаяСтраница = DOK.Range.Information(3)
        строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(DOK, НомерАбзаца, ТекущаяСтраница)
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
        Call ВставитьПараграф(DOK, НомерАбзаца, "3. Отчислить вышеперечисленных слушателей.", "Times New Roman", 14, 3, 0, 1, 0, False)

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




        счетчик = 0

        While счетчик < UBound(слушатели, 2)

            DOK.Bookmarks("\EndOfDoc").Select

            MSWord.Selection.InsertBreak(2)

            DOK.Bookmarks("\EndOfDoc").Select

            MSWord.Selection.PageSetup.Orientation = 1

            DOK.Bookmarks("\EndOfDoc").Select

            Tabl = DOK.Tables.Add(DOK.Range(0, 0), 2, 3)

            Tabl.Range.Select
            MSWord.Selection.Cut

            НомерАбзаца = DOK.Paragraphs.Count
            Call ВставитьПараграф(DOK, DOK.Paragraphs.Count, "", "Times New Roman", 14, 3, 0, 0, 0, False)

            НомерАбзаца = DOK.Paragraphs.Count
            DOK.Paragraphs(НомерАбзаца).Range.Select
            'DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.PageSetup.TopMargin = 14
            MSWord.Selection.PasteAndFormat(0)
            номерТаблицы = DOK.Tables.count
            Tabl = DOK.Tables(номерТаблицы)



            Call НастройкаТаблицы(MSWord, DOK, Tabl, слушателиПолный, Группа, счетчик + 1)

            счетчик = счетчик + 1
        End While
        Call сохранить(DOK, видПриказа)
        MSWord.Visible = True
    End Sub

    Function СписокСлушателей(Група As String) As Object

        Dim слушатели
        Dim НаВывод
        Dim СтрокаЗапроса As String
        Dim Счетчик As Integer

        СтрокаЗапроса = "SELECT Слушатель FROM СоставГрупп WHERE Группа= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)

        слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If слушатели(0, 0).ToString = "нет записей" Then

            СписокСлушателей = слушатели
            Exit Function

        End If

        СтрокаЗапроса = "SELECT Фамилия , Имя , Отчество, Снилс FROM Слушатель WHERE"

        Счетчик = 0

        While Счетчик <= UBound(слушатели, 2)

            СтрокаЗапроса = СтрокаЗапроса & " Снилс=" & Chr(39) & слушатели(0, Счетчик) & Chr(39) & " OR"
            Счетчик = Счетчик + 1
        End While

        СтрокаЗапроса = Left(СтрокаЗапроса, Len(СтрокаЗапроса) - 3) & "ORDER BY Фамилия"

        слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)


        If слушатели(0, 0).ToString = "нет записей" Then

            СписокСлушателей = слушатели
            Exit Function

        End If

        слушателиПолный = слушатели

        ReDim НаВывод(0, UBound(слушатели, 2))

        Счетчик = 0

        While Счетчик <= UBound(слушатели, 2)
            НаВывод(0, Счетчик) = слушатели(0, Счетчик) & " " & слушатели(1, Счетчик) & " " & слушатели(2, Счетчик)
            Счетчик = Счетчик + 1
        End While

        СписокСлушателей = НаВывод

    End Function

    Function ПрисвоитьНомера(НомерГрупы As String, Группа As Object) As Boolean
        Dim Слушатели, массивЗапросов
        Dim Счетчик As Integer, Число
        Dim строкаЗапроса As String

        ReDim массивЗапросов(0)
        Счетчик = 0
        строкаЗапроса = "SELECT Слушатель FROM СоставГрупп WHERE Группа= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(строкаЗапроса)

        Try
            Число = Группа(4, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Номер удостоверения группы не задан или не является числом"
            предупреждение.ShowDialog()
            ПрисвоитьНомера = True
            Exit Function
        End Try

        Try
            Число = Группа(5, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Регистрационный номер удостоверения группы не задан или не является числом"
            предупреждение.ShowDialog()
            ПрисвоитьНомера = True
            Exit Function
        End Try


        While Счетчик <= UBound(Слушатели, 2)

            строкаЗапроса = "UPDATE СоставГрупп SET НомерУд = " & Группа(4, 0) + Счетчик & " , РегНомерУд= " & Группа(5, 0) + Счетчик & " WHERE Группа = " & Chr(39) & НомерГрупы & Chr(39) & " AND Слушатель = " & Chr(39) & Слушатели(0, Счетчик) & Chr(39)
            ЗаписьВБазу.ЗаписьВБазу(строкаЗапроса)
            массивЗапросов(0) = строкаЗапроса
            Счетчик = Счетчик + 1

        End While

        ПрисвоитьНомера = False

    End Function


    Sub НастройкаТаблицы(MSWord As Object, DOK As Object, Tabl As Object, Слушатели As Object, группа As Object, номер As Integer)

        'Tabl.Rows.SetLeftIndent.LeftIndent(-51.3, 0)
        Tabl.Rows.LeftIndent = -51.3


        Tabl.Range.ParagraphFormat.LineSpacing = 14
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14

        Tabl.Columns(2).Width = 110
        Tabl.Columns(1).Width = 260
        Tabl.Columns(3).Width = 460

        Tabl.Columns(3).Select
        MSWord.Selection.ParagraphFormat.FirstLineIndent = 70


        Tabl.Cell(1, 1).Merge(Tabl.Cell(1, 2))

        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs(1), 1, "Times New Roman", 8, "")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 20, "")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Федеральное государственное бюджетное учреждение")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "дополнительного профессионального образования")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "«Всероссийский учебно-научно-методический центр")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "по непрерывному медицинскому и фармацевтическому образованию»")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Министерства здравоохранения Российской Федерации")

        Tabl.Rows(1).Height = 240
        Tabl.Rows(2).Height = 200

        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs(1), 1, "Times New Roman", 16, слушателиПолный(0, номер - 1))
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 16, слушателиПолный(1, номер - 1) & " " & слушателиПолный(2, номер - 1))
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 8, "")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 12, "в период с " & группа(0, 0) & " по " & группа(1, 0))
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 45, "")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Федеральном государственном бюджетном учреждении ")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "дополнительного профессионального образования")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "«Всероссийский учебно-научно-методический центр ")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "по непрерывному медицинскому и фармацевтическому образованию»")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Министерства здравоохранения Российской Федерации")

        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs(1), 1, "Times New Roman", 14, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 14, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 16, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, группа(5, 0) + номер)
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 16, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, "Москва")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 24, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, группа(6, 0))

        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs(1), 1, "Times New Roman", 12, группа(2, 0))
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, группа(3, 0) & " часов")


    End Sub


    Function ПрисвоитьНомераПП(НомерГрупы As String, Группа As Object) As Boolean
        Dim Слушатели, массивЗапросов
        Dim Счетчик As Integer, Число
        Dim строкаЗапроса As String
        ReDim массивЗапросов(0)
        Счетчик = 0
        строкаЗапроса = "SELECT Слушатель FROM СоставГрупп WHERE Группа= " & Chr(39) & АСформироватьПриказ.НомерГруппы.Text & Chr(39)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(строкаЗапроса)

        Try
            Число = Группа(4, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Номер диплома группы не задан или не является числом"
            предупреждение.ShowDialog()
            ПрисвоитьНомераПП = True
            Exit Function
        End Try

        Try
            Число = Группа(5, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Регистрационный номер диплома группы не задан или не является числом"
            предупреждение.ShowDialog()
            ПрисвоитьНомераПП = True
            Exit Function
        End Try


        While Счетчик <= UBound(Слушатели, 2)

            строкаЗапроса = "UPDATE СоставГрупп SET НомерДиплома = " & Группа(4, 0) + Счетчик & " , РегНомерДиплома= " & Группа(5, 0) + Счетчик & " WHERE Группа = " & Chr(39) & НомерГрупы & Chr(39) & " AND Слушатель = " & Chr(39) & Слушатели(0, Счетчик) & Chr(39)
            ЗаписьВБазу.ЗаписьВБазу(строкаЗапроса)
            массивЗапросов(0) = строкаЗапроса
            Счетчик = Счетчик + 1

        End While

        ПрисвоитьНомераПП = False

    End Function



    Sub НастройкаТаблицыПП_О(MSWord As Object, DOK As Object, Tabl As Object, Слушатели As Object, группа As Object, номер As Integer)

        'Tabl.Rows.SetLeftIndent.LeftIndent(-51.3, 0)

        Tabl.Rows.LeftIndent = -44.25
        '-51.3


        Tabl.Range.ParagraphFormat.LineSpacing = 14
        Tabl.Range.Font.Name = "Times New Roman"
        Tabl.Range.Font.Size = 14

        Tabl.Columns(2).Width = 113
        Tabl.Columns(1).Width = 260
        Tabl.Columns(3).Width = 450
        Tabl.Columns(3).Select
        MSWord.Selection.ParagraphFormat.FirstLineIndent = 70

        Tabl.Cell(1, 1).Merge(Tabl.Cell(1, 2))

        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs(1), 1, "Times New Roman", 8, "")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 20, "")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Федеральное государственное бюджетное учреждение")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "дополнительного профессионального образования")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "«Всероссийский учебно-научно-методический центр")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "по непрерывному медицинскому и фармацевтическому образованию»")
        настройкаПараграфа(Tabl.Cell(1, 1).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Министерства здравоохранения Российской Федерации")

        Tabl.Rows(1).Height = 250
        Tabl.Rows(2).Height = 200

        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs(1), 1, "Times New Roman", 16, слушателиПолный(0, номер - 1))
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 16, слушателиПолный(1, номер - 1) & " " & слушателиПолный(2, номер - 1))
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 8, "")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 12, "в период с " & группа(0, 0) & " по " & группа(1, 0))
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 45, "")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Федеральном государственном бюджетном учреждении ")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "дополнительного профессионального образования")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "«Всероссийский учебно-научно-методический центр ")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "по непрерывному медицинскому и фармацевтическому образованию»")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "Министерства здравоохранения Российской Федерации")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 14, "")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 14, "")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, группа(7, 0) & " № " & группа(6, 0))
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 11, "аттестационной комиссии")
        настройкаПараграфа(Tabl.Cell(1, 2).range.Paragraphs.Add(), 1, "Times New Roman", 14, "")


        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs(1), 0, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, группа(5, 0) + номер)
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 16, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, "Москва")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 24, "")
        настройкаПараграфа(Tabl.Cell(2, 2).range.Paragraphs.Add(), 0, "Times New Roman", 12, группа(6, 0))


        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs(1), 1, "Times New Roman", 11, "здравоохранения")
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, "", 1)
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 11, "по специальности")
        настройкаПараграфа(Tabl.Cell(2, 3).range.Paragraphs.Add(), 1, "Times New Roman", 12, "«" & группа(2, 0) & "»")

    End Sub

    Sub настройкаПараграфа(параграф As Object, Выравнивание As Double, Шрифт As String, РазмерШрифта As Integer, текст As String, Optional МежстрочныйИнтервал As Double = 0)

        параграф.Range.Font.Size = РазмерШрифта
        параграф.Format.Alignment = Выравнивание
        параграф.Range.Font.Name = Шрифт
        параграф.Range.Text = текст
        параграф.SpaceBefore = МежстрочныйИнтервал
        параграф.LineUnitAfter = 0
        параграф.LineUnitBefore = 0
        параграф.SpaceAfter = 0
        параграф.SpaceBeforeAuto = False
        параграф.SpaceAfterAuto = False
        параграф.Range.ParagraphFormat.LineSpacingRule = 0

    End Sub
    Sub ВставитьПараграф1(DOK As Object, номерАбзаца As Integer, текст As String, Шрифт As String, РазмерШрифта As Integer, Выравнивание As Double, ОтступКраснаяСтрока As Double, ОтступПередАбзацем As Double, МежстрочныйИнтервал As Double, Жирный As Boolean)

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
End Module
