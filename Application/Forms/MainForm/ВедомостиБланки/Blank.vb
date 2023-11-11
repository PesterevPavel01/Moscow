Module Blank
    Sub Карточка_Слушателя(argument As OrderArgument)

        Dim MSWord
        Dim DOK
        Dim group, students
        Dim numberParagraph As Integer, counter As Integer
        Dim queryString As String, year As String

        queryString = blanki_loadSlush(argument.orderIdGroup)

        students = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If students(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "В выбранной группе нет слушателей!"
            openForm(Warning)
            Exit Sub

        End If

        queryString = blanki_loadProgAndDateTFromGroup(argument.orderIdGroup)

        group = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        queryString = WindowsApp2.QueryString.SQLSTring_KartSlushatel(argument.orderIdGroup)

        students = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If students(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Ошибка загрузки информации о слушателях, возможно у одного из слушателей указан некорректный СНИЛС!"
            openForm(Warning)
            Exit Sub

        End If

        MSWord = CreateObject("Word.Application")

        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add

        addHeader(MSWord, DOK, argument.orderDate.ToShortDateString, 1)

        DOK.Paragraphs.Add()

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "1. Наименование курса: «" & group(0, 0) & "»", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "2. Дата начала обучения: " & group(1, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "3. ФИО (по паспорту) " & students(0, 0) & " " & students(1, 0) & " " & students(2, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "4. Дата рождения: " & students(3, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "5. Место рождения: ", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Try
            year = Right(students(5, 0).ToShortDateString, 4)

        Catch ex As Exception

            year = ""

        End Try

        addParagraph(DOK, numberParagraph, "6. Сведения о высшем/ среднем образовании: окончил(а) " & students(4, 0) & " в " & year & " году ", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "Диплом: серия " & students(6, 0) & " номер диплома " & students(7, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "Специальность по диплому: ________________________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "7. Стаж работы: специальность (по сертификату): «____________________»; ____лет;", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "8. Сведения о прохождении профессиональной переподготовки (специализации).", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "Наименование программы: «_________________________________________ ____________________»; год_____", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "Диплом: серия___________ номер _____________", "Times New Roman", 14, 3, 0, 1, 0, False)


        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "9. Сведения о прохождении повышения квалификации", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "Наименование программы: «________________________________________» год__________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "10. Предыдущий сертификат специалиста", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "Наименование специальности «___________________________»; год________.", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "11. Наименование организации работодателя _________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "_________________________________________________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "12. Занимаемая должность: _________________________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "«____»_____________					Подпись____________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "Ответственный за обучение от организации работодателя_____________________		_____________________________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        addParagraph(DOK, numberParagraph, "			(подпись)					(ФИО ответственного лица)", "Times New Roman", 12, 3, 0, 1, 0, False)
        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)


        counter = 1

        While counter <= UBound(students, 2)

            КопироватьВставить(MSWord, DOK, 1, 10)


            numberParagraph = DOK.Paragraphs.count

            addParagraph(DOK, numberParagraph, "3. ФИО (по паспорту) " & students(0, counter) & " " & students(1, counter) & " " & students(2, counter), "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            addParagraph(DOK, numberParagraph, "4. Дата рождения: " & students(3, counter), "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            addParagraph(DOK, numberParagraph, "5. Место рождения: ", "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Try
                year = Right(students(5, counter).ToShortDateString, 4)

            Catch ex As Exception

                year = ""

            End Try

            addParagraph(DOK, numberParagraph, "6. Сведения о высшем/ среднем образовании: окончил(а) " & students(4, counter) & " в " & year & " году ", "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            addParagraph(DOK, numberParagraph, "Диплом: серия " & students(6, counter) & " номер диплома " & students(7, counter), "Times New Roman", 14, 3, 0, 1, 0, False)

            DOK.Paragraphs.Add()
            КопироватьВставить(MSWord, DOK, 16, 33)
            DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.InsertBreak(Type:=7)
            counter = counter + 1

        End While

        _technical.savePrikazBlank(DOK, argument.orderIdGroup, argument.orderType, updateResourcesPath, "Карточки", argument.mySqlConnector)
        MSWord.Visible = True

    End Sub



    Sub addHeader(MSWord As Object, DOK As Object, Дата As String, НомерАбзаца As Integer)


        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With


        Call addParagraph(DOK, НомерАбзаца, "Федеральное государственное бюджетное учреждение", "Times New Roman", 10, 1, 0, 1, 0, False)
        DOK.Paragraphs.Add()
        НомерАбзаца = DOK.Paragraphs.count
        Call addParagraph(DOK, НомерАбзаца, "дополнительного профессионального образования", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call addParagraph(DOK, НомерАбзаца, "«Всероссийский учебно-научно-методический центр по непрерывному медицинскому ", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call addParagraph(DOK, НомерАбзаца, "и фармацевтическому образованию» Министерства здравоохранения Российской Федерации", "Times New Roman", 10, 1, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call addParagraph(DOK, НомерАбзаца, "(ФГБУ ДПО ВУНМЦ Минздрава России)", "Times New Roman", 10, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call addParagraph(DOK, НомерАбзаца, "", "Times New Roman", 14, 1, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        НомерАбзаца = 1 + НомерАбзаца
        Call addParagraph(DOK, НомерАбзаца, "Карточка слушателя", "Times New Roman", 14, 1, 0, 1, 2, True)

    End Sub


    Sub ПК_Заявление(argument As OrderArgument)

        Dim MSWord
        Dim DOK
        Dim group, students
        Dim numberParagraph As Integer, counter As Integer
        Dim sqlQuery As String

        sqlQuery = blanki_loadSlush(Convert.ToString(argument.orderIdGroup))

        students = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If students(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "В выбранной группе нет слушателей!"
            openForm(Warning)

            Exit Sub

        End If

        sqlQuery = blanki_loadProgram(argument.orderIdGroup)

        group = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        sqlQuery = QueryString.SQLSTring_PKZayavlenie(argument.orderIdGroup)

        students = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If students(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Ошибка загрузки информации о слушателях, возможно у одного из слушателей указан некорректный СНИЛС!"
            openForm(Warning)
            Exit Sub

        End If

        students = arrayMethod.removeEmpty(students)

        MSWord = CreateObject("Word.Application")

        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add


        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "Директору", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "ФГБУ ДПО ВУНМЦ", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "Минздрава России", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "Н.В. Зеленской", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "от " & students(0, 0) & " " & students(1, 0) & " " & students(2, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, students(3, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "Контактный телефон: " & students(4, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "E-mail: " & students(5, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "ЗАЯВЛЕНИЕ", "Times New Roman", 14, 1, 0, 1, 2, True)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "Прошу зачислить меня слушателем ФГБУ ДПО ВУНМЦ Минздрава России на обучение по дополнительной профессиональной программе повышения квалификации " & group(0, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "С государственной лицензией на осуществление образовательной деятельности, Уставом и Правилами внутреннего распорядка обучающихся ФГБУ ДПО ВУНМЦ Минздрава России, Правилами приёма, а также с информацией об ответственности за подлинность документов, подаваемых при поступлении, ознакомлен(а).", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "В соответствие со статьёй 9 Федерального закона от 27.07.2006 № 152-ФЗ «О персональных данных» даю своё согласие ФГБУ ДПО ВУНМЦ Минздрава России, расположенного по адресу: г. Москва, ул. Лосиноостровская, д.2, на сбор, обработку и хранение моих персональных данных на период обучения в ФГБУ ДПО ВУНМЦ Минздрава России, а именно:", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- мои фамилия, имя, отчество, дата рождения;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- иные паспортные данные, в том числе адрес регистрации и проживания;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- контактные телефоны;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- сведения о месте работы (учёбы).", "Times New Roman", 12, 3, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)



        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)


        counter = 1

        While counter <= UBound(students, 2)

            КопироватьВставить(MSWord, DOK, 1, 4)

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "от " & students(0, counter) & " " & students(1, counter) & " " & students(2, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, students(3, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "Контактный телефон: " & students(4, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "E-mail: " & students(5, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()

            КопироватьВставить(MSWord, DOK, 12, 28)
            DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.InsertBreak(Type:=7)
            counter = counter + 1
        End While

        _technical.savePrikazBlank(DOK, argument.orderIdGroup, argument.orderType, updateResourcesPath, "Заявления", argument.mySqlConnector)

        MSWord.Visible = True



    End Sub

    Sub ПП_Заявление(argument As OrderArgument)

        Dim MSWord
        Dim DOK
        Dim group, students
        Dim numberParagraph As Integer, counter As Integer
        Dim sqlQuery As String

        sqlQuery = blanki_loadSlush(argument.orderIdGroup)

        students = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If students(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "В выбранной группе нет слушателей!"
            openForm(Warning)

            Exit Sub

        End If

        sqlQuery = blanki_loadSpesh(argument.orderIdGroup)

        group = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        sqlQuery = SQLSTring_PKZayavlenie(argument.orderIdGroup)

        students = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If students(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Проверьте данные слушателей этой группы, возможно у одного из слушателей указан некорректный СНИЛС!"
            openForm(Warning)
            Exit Sub

        End If

        students = arrayMethod.removeEmpty(students)

        MSWord = CreateObject("Word.Application")

        MSWord.DisplayAlerts = False
        DOK = MSWord.Documents.Add

        With DOK.PageSetup

            .TopMargin = 28.34646 * 2
            .BottomMargin = 28.34646 * 2
            .LeftMargin = 28.34646 * 2.75
            .RightMargin = 28.34646 * 1


        End With

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "Директору", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "ФГБУ ДПО ВУНМЦ", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "Минздрава России", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "Н.В. Зеленской", "Times New Roman", 14, 3, 8.5, 0, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "от " & students(0, 0) & " " & students(1, 0) & " " & students(2, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, students(3, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "Контактный телефон: " & students(4, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "E-mail: " & students(5, 0), "Times New Roman", 14, 3, 8, 0.5, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count


        Call addParagraph(DOK, numberParagraph, "ЗАЯВЛЕНИЕ", "Times New Roman", 14, 1, 0, 1, 2, True)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "Прошу зачислить меня слушателем ФГБУ ДПО ВУНМЦ Минздрава России на обучение по дополнительной профессиональной программе профессиональной переподготовки по специальности " & group(0, 0), "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "О себе сообщаю:", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "Общий трудовой стаж ________ лет", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "Общий медицинский стаж ________ лет", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "Не работаю по специальности более ________ лет", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "(нужное подчеркнуть)", "Times New Roman", 10, 3, 0, 1, 0, False)

        DOK.Paragraphs(numberParagraph).Range.Select

        MSWord.Selection.Cut

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "В общежитии нуждаюсь/не нуждаюсь ", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "С государственной лицензией на осуществление образовательной деятельности, Уставом и Правилами внутреннего распорядка обучающихся ФГБУ ДПО ВУНМЦ Минздрава России, Правилами приёма, а также с информацией об ответственности за подлинность документов, подаваемых при поступлении, ознакомлен(а).", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        DOK.Paragraphs.Add()

        numberParagraph = DOK.Paragraphs.count

        Call addParagraph(DOK, numberParagraph, "В соответствие со статьёй 9 Федерального закона от 27.07.2006 № 152-ФЗ «О персональных данных» даю своё согласие ФГБУ ДПО ВУНМЦ Минздрава России, расположенного по адресу: г. Москва, ул. Лосиноостровская, д.2, на сбор, обработку и хранение моих персональных данных на период обучения в ФГБУ ДПО ВУНМЦ Минздрава России, а именно:", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- мои фамилия, имя, отчество, дата рождения;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- иные паспортные данные, в том числе адрес регистрации и проживания;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- контактные телефоны;", "Times New Roman", 12, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "- сведения о месте работы (учёбы).", "Times New Roman", 12, 3, 0, 1, 0, False)


        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "", "Times New Roman", 14, 3, 0, 1, 0, False)

        DOK.Paragraphs.Add()
        numberParagraph = DOK.Paragraphs.count
        Call addParagraph(DOK, numberParagraph, "Дата _______________			Подпись _______________", "Times New Roman", 14, 3, 0, 1, 0, False)



        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.InsertBreak(Type:=7)


        counter = 1

        While counter <= UBound(students, 2)

            КопироватьВставить(MSWord, DOK, 1, 4)

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "от " & students(0, counter) & " " & students(1, counter) & " " & students(2, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "Зарегистрирован по адресу: ", "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, students(3, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "Контактный телефон: " & students(4, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()

            numberParagraph = DOK.Paragraphs.count

            Call addParagraph(DOK, numberParagraph, "E-mail: " & students(5, counter), "Times New Roman", 14, 3, 8, 0.5, 0, False)

            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()
            DOK.Paragraphs.Add()

            КопироватьВставить(MSWord, DOK, 12, 31)
            DOK.Bookmarks("\EndOfDoc").Select
            MSWord.Selection.InsertBreak(Type:=7)
            counter = counter + 1
        End While

        _technical.savePrikazBlank(DOK, argument.orderIdGroup, argument.orderType, updateResourcesPath, "Заявления", argument.mySqlConnector)
        MSWord.Visible = True

        'Call сохранить(DOK, видПриказа)



    End Sub

End Module
