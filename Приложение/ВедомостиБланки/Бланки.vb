Module Бланки
    Sub Карточка_Слушателя(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Слушатели
        Dim НомерАбзаца As Integer, счетчик As Integer
        Dim Дата As String, СтрокаЗапроса As String, год As String

        СтрокаЗапроса = blanki_loadSlush(ААОсновная.prikazKodGroup)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)
            Exit Sub

        End If

        СтрокаЗапроса = blanki_loadProgAndDateTFromGroup(ААОсновная.prikazKodGroup)

        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        СтрокаЗапроса = QueryString.SQLSTring_KartSlushatel(ААОсновная.prikazKodGroup)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Ошибка загрузки информации о слушателях, возможно у одного из слушателей указан некорректный СНИЛС!"
            ОткрытьФорму(предупреждение)
            Exit Sub

        End If

        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add

        Call вставитьШапку2(MSWord, DOK, Дата, 1)

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "1. Наименование курса: «" & Группа(0, 0) & "»", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "2. Дата начала обучения: " & Группа(1, 0).ToShortDateString, "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "3. ФИО (по паспорту) " & Слушатели(0, 0) & " " & Слушатели(1, 0) & " " & Слушатели(2, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "4. Дата рождения: " & Слушатели(3, 0).ToShortDateString, "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "5. Место рождения: ", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Try
            год = Right(Слушатели(5, 0).ToShortDateString, 4)

        Catch ex As Exception

            год = ""

        End Try

        Call ВставитьПараграф(DOK, НомерАбзаца, "6. Сведения о высшем/ среднем образовании: окончил(а) " & Слушатели(4, 0) & " в " & год & " году ", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Диплом: серия " & Слушатели(6, 0) & " номер диплома " & Слушатели(7, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Специальность по диплому: ________________________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "7. Стаж работы: специальность (по сертификату): «____________________»; ____лет;", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "8. Сведения о прохождении профессиональной переподготовки (специализации).", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Наименование программы: «_________________________________________ ____________________»; год_____", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Диплом: серия___________ номер _____________", "Times New Roman", 14, 3, 0, 1, 0, False)


        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "9. Сведения о прохождении повышения квалификации", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Наименование программы: «________________________________________» год__________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "10. Предыдущий сертификат специалиста", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Наименование специальности «___________________________»; год________.", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "11. Наименование организации работодателя _________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "_________________________________________________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "12. Занимаемая должность: _________________________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "«____»_____________					Подпись____________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Ответственный за обучение от организации работодателя_____________________		_____________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "			(подпись)					(ФИО ответственного лица)", "Times New Roman", 12, 3, 0, 1, 0, False)
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)


        счетчик = 1

        While счетчик <= UBound(Слушатели, 2)

            КопироватьВставить(MSWord, DOK, 1, 10)


            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "3. ФИО (по паспорту) " & Слушатели(0, счетчик) & " " & Слушатели(1, счетчик) & " " & Слушатели(2, счетчик), "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "4. Дата рождения: " & Слушатели(3, счетчик).ToShortDateString, "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "5. Место рождения: ", "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Try
                год = Right(Слушатели(5, счетчик).ToShortDateString, 4)

            Catch ex As Exception

                год = ""

            End Try

            Call ВставитьПараграф(DOK, НомерАбзаца, "6. Сведения о высшем/ среднем образовании: окончил(а) " & Слушатели(4, счетчик) & " в " & год & " году ", "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "Диплом: серия " & Слушатели(6, счетчик) & " номер диплома " & Слушатели(7, счетчик), "Times New Roman", 14, 3, 0, 1, 0, False)


            DOK.Paragraphs.Add()
            КопироватьВставить(MSWord, DOK, 16, 33)
            DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.InsertBreak(Type:=7)
            счетчик = счетчик + 1
        End While

        Вспомогательный.savePrikazBlank(DOK, ААОсновная.prikazKodGroup, видПриказа, resourcesPath, "Карточки")
        MSWord.Visible = True

        'Call сохранить(DOK, видПриказа)



    End Sub



    Sub вставитьШапку2(MSWord As Object, DOK As Object, Дата As String, НомерАбзаца As Integer)


        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With


        Call ВставитьПараграф(DOK, НомерАбзаца, "Федеральное государственное бюджетное учреждение", "Times New Roman", 10, 1, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
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
        Call ВставитьПараграф(DOK, НомерАбзаца, "Карточка слушателя", "Times New Roman", 14, 1, 0, 1, 2, True)

    End Sub


    Sub ПК_Заявление(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Слушатели
        Dim НомерАбзаца As Integer, счетчик As Integer
        Dim Дата As String, СтрокаЗапроса As String

        СтрокаЗапроса = blanki_loadSlush(Convert.ToString(ААОсновная.prikazKodGroup))

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

        СтрокаЗапроса = blanki_loadProgram(ААОсновная.prikazKodGroup)

        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        СтрокаЗапроса = QueryString.SQLSTring_PKZayavlenie(ААОсновная.prikazKodGroup)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Ошибка загрузки информации о слушателях, возможно у одного из слушателей указан некорректный СНИЛС!"
            ОткрытьФорму(предупреждение)
            Exit Sub

        End If

        Слушатели = УбратьПустотыВМассиве.УбратьПустотыВМассиве(Слушатели)

        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add


        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "Директору", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "ФГБУ ДПО ВУНМЦ", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "Минздрава России", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "Н.В. Зеленской", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "от " & Слушатели(0, 0) & " " & Слушатели(1, 0) & " " & Слушатели(2, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, Слушатели(3, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Контактный телефон: " & Слушатели(4, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "E-mail: " & Слушатели(5, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "ЗАЯВЛЕНИЕ", "Times New Roman", 14, 1, 0, 1, 2, True)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Прошу зачислить меня слушателем ФГБУ ДПО ВУНМЦ Минздрава России на обучение по дополнительной профессиональной программе повышения квалификации " & Группа(0, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "С государственной лицензией на осуществление образовательной деятельности, Уставом и Правилами внутреннего распорядка обучающихся ФГБУ ДПО ВУНМЦ Минздрава России, Правилами приёма, а также с информацией об ответственности за подлинность документов, подаваемых при поступлении, ознакомлен(а).", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "В соответствие со статьёй 9 Федерального закона от 27.07.2006 № 152-ФЗ «О персональных данных» даю своё согласие ФГБУ ДПО ВУНМЦ Минздрава России, расположенного по адресу: г. Москва, ул. Лосиноостровская, д.2, на сбор, обработку и хранение моих персональных данных на период обучения в ФГБУ ДПО ВУНМЦ Минздрава России, а именно:", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- мои фамилия, имя, отчество, дата рождения;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- иные паспортные данные, в том числе адрес регистрации и проживания;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- контактные телефоны;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- сведения о месте работы (учёбы).", "Times New Roman", 12, 3, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)



        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)


        счетчик = 1

        While счетчик <= UBound(Слушатели, 2)

            КопироватьВставить(MSWord, DOK, 1, 4)

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "от " & Слушатели(0, счетчик) & " " & Слушатели(1, счетчик) & " " & Слушатели(2, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, Слушатели(3, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "Контактный телефон: " & Слушатели(4, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "E-mail: " & Слушатели(5, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()

            КопироватьВставить(MSWord, DOK, 12, 28)
            DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.InsertBreak(Type:=7)
            счетчик = счетчик + 1
        End While

        Вспомогательный.savePrikazBlank(DOK, ААОсновная.prikazKodGroup, видПриказа, resourcesPath, "Заявления")

        MSWord.Visible = True

        'Call сохранить(DOK, видПриказа)



    End Sub

    Sub ПП_Заявление(видПриказа As String)

        Dim MSWord
        Dim DOK
        Dim Группа, Слушатели
        Dim НомерАбзаца As Integer, счетчик As Integer
        Dim Дата As String, СтрокаЗапроса As String

        СтрокаЗапроса = blanki_loadSlush(ААОсновная.prikazKodGroup)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "В выбранной группе нет слушателей!"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

        СтрокаЗапроса = blanki_loadSpesh(ААОсновная.prikazKodGroup)

        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        СтрокаЗапроса = SQLSTring_PKZayavlenie(ААОсновная.prikazKodGroup)

        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Слушатели(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Проверьте данные слушателей этой группы, возможно у одного из слушателей указан некорректный СНИЛС!"
            ОткрытьФорму(предупреждение)
            Exit Sub

        End If

        Слушатели = УбратьПустотыВМассиве.УбратьПустотыВМассиве(Слушатели)

        MSWord = CreateObject("Word.Application")

        Дата = АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString
        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add
        'MSWord.Visible = True


        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "Директору", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "ФГБУ ДПО ВУНМЦ", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "Минздрава России", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "Н.В. Зеленской", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "от " & Слушатели(0, 0) & " " & Слушатели(1, 0) & " " & Слушатели(2, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, Слушатели(3, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Контактный телефон: " & Слушатели(4, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "E-mail: " & Слушатели(5, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count


        Call ВставитьПараграф(DOK, НомерАбзаца, "ЗАЯВЛЕНИЕ", "Times New Roman", 14, 1, 0, 1, 2, True)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "Прошу зачислить меня слушателем ФГБУ ДПО ВУНМЦ Минздрава России на обучение по дополнительной профессиональной программе профессиональной переподготовки по специальности " & Группа(0, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "О себе сообщаю:", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "Общий трудовой стаж ________ лет", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "Общий медицинский стаж ________ лет", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "Не работаю по специальности более ________ лет", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "(нужное подчеркнуть)", "Times New Roman", 10, 3, 0, 1, 0, False)

        DOK.Paragraphs(НомерАбзаца).Range.Select

        MSWord.Selection.Cut

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "В общежитии нуждаюсь/не нуждаюсь ", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "С государственной лицензией на осуществление образовательной деятельности, Уставом и Правилами внутреннего распорядка обучающихся ФГБУ ДПО ВУНМЦ Минздрава России, Правилами приёма, а также с информацией об ответственности за подлинность документов, подаваемых при поступлении, ознакомлен(а).", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        НомерАбзаца = DOK.Paragraphs.count

        Call ВставитьПараграф(DOK, НомерАбзаца, "В соответствие со статьёй 9 Федерального закона от 27.07.2006 № 152-ФЗ «О персональных данных» даю своё согласие ФГБУ ДПО ВУНМЦ Минздрава России, расположенного по адресу: г. Москва, ул. Лосиноостровская, д.2, на сбор, обработку и хранение моих персональных данных на период обучения в ФГБУ ДПО ВУНМЦ Минздрава России, а именно:", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- мои фамилия, имя, отчество, дата рождения;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- иные паспортные данные, в том числе адрес регистрации и проживания;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- контактные телефоны;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "- сведения о месте работы (учёбы).", "Times New Roman", 12, 3, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call ВставитьПараграф(DOK, НомерАбзаца, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)



        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)


        счетчик = 1

        While счетчик <= UBound(Слушатели, 2)

            КопироватьВставить(MSWord, DOK, 1, 4)

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "от " & Слушатели(0, счетчик) & " " & Слушатели(1, счетчик) & " " & Слушатели(2, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, Слушатели(3, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "Контактный телефон: " & Слушатели(4, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            НомерАбзаца = DOK.Paragraphs.count

            Call ВставитьПараграф(DOK, НомерАбзаца, "E-mail: " & Слушатели(5, счетчик), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()

            КопироватьВставить(MSWord, DOK, 12, 31)
            DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.InsertBreak(Type:=7)
            счетчик = счетчик + 1
        End While

        Вспомогательный.savePrikazBlank(DOK, ААОсновная.prikazKodGroup, видПриказа, resourcesPath, "Заявления")
        MSWord.Visible = True

        'Call сохранить(DOK, видПриказа)



    End Sub

End Module
