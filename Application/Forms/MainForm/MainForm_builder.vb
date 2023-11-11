
Public Class MainForm_builder

    Public controls As New Dictionary(Of Int16, Control)
    Public parents As New Dictionary(Of Int16, Control)
    Public controlNames As New Dictionary(Of String, Int16)
    Public parentPage As New Dictionary(Of Int16, Int16)
    Public prevControl As New Dictionary(Of Int16, Control)
    Public nextControl As New Dictionary(Of Int16, Control)
    Public leftControl As New Dictionary(Of Int16, Control)
    Public rightControl As New Dictionary(Of Int16, Control)

    Public buttonHeigth As Integer = 50
    Public checkBoxHeigth As Integer = 35
    Public comboBoxHeigth As Integer = 28

    Public mySQLConnector As New MySQLConnect

    Public Sub init()

        Dim button As Button
        Dim checkBox As CheckBox
        Dim datePicker As DateTimePicker
        Dim comboBox As ComboBox

        button = New Button
        button.Name = "openGroupListPK"
        button.Text = "Повышение Квалификации"
        button.TabIndex = 0
        controls.Add(1, button)
        parents.Add(1, MainForm.groupListSection)
        parentPage.Add(1, 0)

        button = New Button
        button.Name = "openGroupListPP"
        button.Text = "Профессиональная Переподготовка"
        button.TabIndex = 1
        controls.Add(2, button)
        parents.Add(2, MainForm.groupListSection)
        parentPage.Add(2, 0)

        button = New Button
        button.Name = "openGroupListPO"
        button.Text = "Профессиональное обучение"
        button.TabIndex = 2
        controls.Add(3, button)
        parents.Add(3, MainForm.groupListSection)
        parentPage.Add(3, 0)

        button = New Button
        button.Name = "addGroup"
        button.Text = "Создать группу"
        button.TabIndex = 3
        controls.Add(4, button)
        parents.Add(4, MainForm.groupListSection)
        parentPage.Add(4, 0)

        button = New Button
        button.Name = "studentsList"
        button.Text = "Справочник слушатели"
        button.TabIndex = 4
        controls.Add(5, button)
        parents.Add(5, MainForm.studentsSection)
        parentPage.Add(5, 0)

        button = New Button
        button.Name = "addStudent"
        button.Text = "Создать слушателя"
        button.TabIndex = 5
        controls.Add(6, button)
        parents.Add(6, MainForm.studentsSection)
        parentPage.Add(6, 0)

        button = New Button
        button.Name = "grades"
        button.Text = "Ведомость"
        button.TabIndex = 6
        controls.Add(7, button)
        parents.Add(7, MainForm.gradesContainer)
        parentPage.Add(7, 0)

        button = New Button
        button.Name = "gradesIA"
        button.Text = "Итоговая аттестация"
        button.TabIndex = 7
        controls.Add(8, button)
        parents.Add(8, MainForm.gradesContainer)
        parentPage.Add(8, 0)

        button = New Button
        button.Name = "workerReport"
        button.Text = "Педнагрузка"
        button.TabIndex = 8
        controls.Add(9, button)
        parents.Add(9, MainForm.gradesContainer)
        parentPage.Add(9, 0)

        'Приказы

        button = New Button
        button.Name = "enrollmentPK"
        button.Text = "ПК зачисление"
        button.TabIndex = 9
        controls.Add(10, button)
        parents.Add(10, MainForm.ordersPKSection)
        parentPage.Add(10, 1)

        button = New Button
        button.Name = "enrollmentPK_pl"
        button.Text = "ПК зачисление доп"
        button.TabIndex = 10
        controls.Add(11, button)
        parents.Add(11, MainForm.ordersPKSection)
        parentPage.Add(11, 1)

        button = New Button
        button.Name = "expulsionPK"
        button.Text = "ПК отчисление"
        button.TabIndex = 11
        controls.Add(12, button)
        parents.Add(12, MainForm.ordersPKSection)
        parentPage.Add(12, 1)

        button = New Button
        button.Name = "endingPK"
        button.Text = "ПК окончание"
        button.TabIndex = 12
        controls.Add(13, button)
        parents.Add(13, MainForm.ordersPKSection)
        parentPage.Add(13, 1)

        button = New Button
        button.Name = "endingUdPK"
        button.Text = "ПК окончание уд"
        button.TabIndex = 13
        controls.Add(14, button)
        parents.Add(14, MainForm.ordersPKSection)
        parentPage.Add(14, 1)


        button = New Button
        button.Name = "enrollmentPP"
        button.Text = "ПП зачисление"
        button.TabIndex = 14
        controls.Add(15, button)
        parents.Add(15, MainForm.ordersPPSection)
        parentPage.Add(15, 1)

        button = New Button
        button.Name = "practicalPP"
        button.Text = "ПП практика"
        button.TabIndex = 15
        controls.Add(16, button)
        parents.Add(16, MainForm.ordersPPSection)
        parentPage.Add(16, 1)

        button = New Button
        button.Name = "finalExaminationPP"
        button.Text = "ПП допуск к ИА"
        button.TabIndex = 16
        controls.Add(17, button)
        parents.Add(17, MainForm.ordersPPSection)
        parentPage.Add(17, 1)

        button = New Button
        button.Name = "endingPP"
        button.Text = "ПП окончание"
        button.TabIndex = 17
        controls.Add(18, button)
        parents.Add(18, MainForm.ordersPPSection)
        parentPage.Add(18, 1)

        button = New Button
        button.Name = "enrollmentPO"
        button.Text = "ПП зачисление"
        button.TabIndex = 18
        controls.Add(19, button)
        parents.Add(19, MainForm.ordersPOSection)
        parentPage.Add(19, 1)

        button = New Button
        button.Name = "practicalPO"
        button.Text = "ПП практика"
        button.TabIndex = 19
        controls.Add(20, button)
        parents.Add(20, MainForm.ordersPOSection)
        parentPage.Add(20, 1)

        button = New Button
        button.Name = "finalExaminationPO"
        button.Text = "ПП допуск к ИА"
        button.TabIndex = 20
        controls.Add(21, button)
        parents.Add(21, MainForm.ordersPOSection)
        parentPage.Add(21, 1)

        button = New Button
        button.Name = "endingPO"
        button.Text = "ПП окончание"
        button.TabIndex = 21
        controls.Add(22, button)
        parents.Add(22, MainForm.ordersPOSection)
        parentPage.Add(22, 1)

        button = New Button
        button.Name = "diplomaSupplement"
        button.Text = "ПП приложение к диплому"
        button.TabIndex = 22
        controls.Add(23, button)
        parents.Add(23, MainForm.sekshionsBlanks)
        parentPage.Add(23, 2)

        button = New Button
        button.Name = "certificate"
        button.Text = "ПО свидетельство"
        button.TabIndex = 23
        controls.Add(24, button)
        parents.Add(24, MainForm.sekshionsBlanks)
        parentPage.Add(24, 2)

        button = New Button
        button.Name = "statementPK"
        button.Text = "ПК заявление"
        button.TabIndex = 24
        controls.Add(25, button)
        parents.Add(25, MainForm.sekshionsBlanks)
        parentPage.Add(25, 2)

        button = New Button
        button.Name = "statementPP"
        button.Text = "ПП заявление"
        button.TabIndex = 25
        controls.Add(26, button)
        parents.Add(26, MainForm.sekshionsBlanks)
        parentPage.Add(26, 2)

        button = New Button
        button.Name = "studentInformation"
        button.Text = "Карточка слушателя"
        button.TabIndex = 26
        controls.Add(27, button)
        parents.Add(27, MainForm.sekshionsBlanks)
        parentPage.Add(27, 2)

        button = New Button
        button.Name = "studentAndOrganization"
        button.Text = "Ведомость слушатели и организации"
        button.TabIndex = 27
        controls.Add(28, button)
        parents.Add(28, MainForm.sekshionsBlanks)
        parentPage.Add(28, 2)

        button = New Button
        button.Name = "getAllBlank"
        button.Text = "Доверенность получения бланков на группу"
        button.TabIndex = 28
        controls.Add(29, button)
        parents.Add(29, MainForm.sekshionsBlanks)
        parentPage.Add(29, 2)

        button = New Button
        button.Name = "getSomeBlank"
        button.Text = "Доверенность получения бланков на слушателя"
        button.TabIndex = 29
        controls.Add(30, button)
        parents.Add(30, MainForm.sekshionsBlanks)
        parentPage.Add(30, 2)

        button = New Button
        button.Name = "gradesIinterAPO"
        button.Text = "ПО ведомость промежуточной аттестации"
        button.TabIndex = 30
        controls.Add(31, button)
        parents.Add(31, MainForm.sekshionsBlanks)
        parentPage.Add(31, 2)

        button = New Button
        button.Name = "gradesIinterAPP"
        button.Text = "ПП ведомость промежуточной аттестации"
        button.TabIndex = 31
        controls.Add(32, button)
        parents.Add(32, MainForm.sekshionsBlanks)
        parentPage.Add(32, 2)

        button = New Button
        button.Name = "certificateStudy"
        button.Text = "Справка об обучении"
        button.TabIndex = 32
        controls.Add(33, button)
        parents.Add(33, MainForm.sekshionsBlanks)
        parentPage.Add(33, 2)

        button = New Button
        button.Name = "certificateStudyOut"
        button.Text = "Справка об окончании без ИА"
        button.TabIndex = 33
        controls.Add(34, button)
        parents.Add(34, MainForm.sekshionsBlanks)
        parentPage.Add(34, 2)

        datePicker = New DateTimePicker
        datePicker.Name = "reportStart"
        datePicker.TabIndex = 34
        controls.Add(35, datePicker)
        parents.Add(35, MainForm.TabControlOther.TabPages(3))
        parentPage.Add(35, 3)

        datePicker = New DateTimePicker
        datePicker.Name = "reportEnd"
        datePicker.TabIndex = 35
        controls.Add(36, datePicker)
        parents.Add(36, MainForm.TabControlOther.TabPages(3))
        parentPage.Add(36, 3)

        checkBox = New CheckBox
        checkBox.Name = "managerReport"
        checkBox.Text = "Отчет руководителя"
        checkBox.TabIndex = 36
        controls.Add(37, checkBox)
        parents.Add(37, MainForm.reportSection)
        parentPage.Add(37, 3)

        checkBox = New CheckBox
        checkBox.Name = "courseReport"
        checkBox.Text = "Свод по курсам"
        checkBox.TabIndex = 37
        controls.Add(38, checkBox)
        parents.Add(38, MainForm.reportSection)
        parentPage.Add(38, 3)

        checkBox = New CheckBox
        checkBox.Name = "specialityReport"
        checkBox.Text = "Свод по специальностям"
        checkBox.TabIndex = 38
        controls.Add(39, checkBox)
        parents.Add(39, MainForm.reportSection)
        parentPage.Add(39, 3)

        checkBox = New CheckBox
        checkBox.Name = "organizationReport"
        checkBox.Text = "Свод по организациям"
        checkBox.TabIndex = 39
        controls.Add(40, checkBox)
        parents.Add(40, MainForm.reportSection)
        parentPage.Add(40, 3)

        checkBox = New CheckBox
        checkBox.Name = "financingReport"
        checkBox.Text = "Бюджет/внебюджет"
        checkBox.TabIndex = 40
        controls.Add(41, checkBox)
        parents.Add(41, MainForm.reportSection)
        parentPage.Add(41, 3)

        checkBox = New CheckBox
        checkBox.Name = "workerReportC"
        checkBox.Text = "Педнагрузка"
        checkBox.TabIndex = 41
        controls.Add(42, checkBox)
        parents.Add(42, MainForm.reportSection)
        parentPage.Add(42, 3)

        checkBox = New CheckBox
        checkBox.Name = "workerReportPlus"
        checkBox.Text = "Педнагрузка расширенный"
        checkBox.TabIndex = 42
        controls.Add(43, checkBox)
        parents.Add(43, MainForm.reportSection)
        parentPage.Add(43, 3)

        checkBox = New CheckBox
        checkBox.Name = "RAMNPOReport"
        checkBox.Text = "РАМНПО"
        checkBox.TabIndex = 43
        controls.Add(44, checkBox)
        parents.Add(44, MainForm.reportSection)
        parentPage.Add(44, 3)

        button = New Button
        button.Name = "reportRun"
        button.Text = "Сформировать"
        button.TabIndex = 44
        controls.Add(45, button)
        parents.Add(45, MainForm.reportSection)
        parentPage.Add(45, 3)

        button = New Button
        button.Name = "bookPK"
        button.Text = "Книга учета выданных удостоверений"
        button.TabIndex = 45
        controls.Add(46, button)
        parents.Add(46, MainForm.booksSection)
        parentPage.Add(46, 3)

        button = New Button
        button.Name = "bookPP"
        button.Text = "Книга учета выданных дипломов"
        button.TabIndex = 46
        controls.Add(47, button)
        parents.Add(47, MainForm.booksSection)
        parentPage.Add(47, 3)

        button = New Button
        button.Name = "bookPO"
        button.Text = "Книга учета выданных свидетельств"
        button.TabIndex = 47
        controls.Add(48, button)
        parents.Add(48, MainForm.booksSection)
        parentPage.Add(48, 3)

        button = New Button
        button.Name = "bookFPK"
        button.Text = "Книга учета выданных удостоверений ФРДО"
        button.TabIndex = 48
        controls.Add(49, button)
        parents.Add(49, MainForm.booksFRDOSection)
        parentPage.Add(49, 3)

        button = New Button
        button.Name = "bookFPP"
        button.Text = "Книга учета выданных дипломов ФРДО"
        button.TabIndex = 49
        controls.Add(50, button)
        parents.Add(50, MainForm.booksFRDOSection)
        parentPage.Add(50, 3)

        button = New Button
        button.Name = "bookFPO"
        button.Text = "Книга учета выданных свидетельств ФРДО"
        button.TabIndex = 50
        controls.Add(51, button)
        parents.Add(51, MainForm.booksFRDOSection)
        parentPage.Add(51, 3)

        ' Настройки

        comboBox = New ComboBox
        comboBox.Name = "students_defaultSearchSetts"
        comboBox.TabIndex = 51
        controls.Add(52, comboBox)
        parents.Add(52, MainForm.panelSetts)
        parentPage.Add(52, 4)

        comboBox = New ComboBox
        comboBox.Name = "group_dafaultSearchSetts"
        comboBox.TabIndex = 52
        controls.Add(53, comboBox)
        parents.Add(53, MainForm.panelSetts)
        parentPage.Add(53, 4)

        comboBox = New ComboBox
        comboBox.Name = "students_defaultSortSetts"
        comboBox.TabIndex = 53
        controls.Add(54, comboBox)
        parents.Add(54, MainForm.panelSetts)
        parentPage.Add(54, 4)

        comboBox = New ComboBox
        comboBox.Name = "group_defaultSortSetts"
        comboBox.TabIndex = 54
        controls.Add(55, comboBox)
        parents.Add(55, MainForm.panelSetts)
        parentPage.Add(55, 4)

        comboBox = New ComboBox
        comboBox.Name = "maxNumberRows"
        comboBox.TabIndex = 55
        controls.Add(56, comboBox)
        parents.Add(56, MainForm.panelSetts)
        parentPage.Add(56, 4)

        comboBox = New ComboBox
        comboBox.Name = "directorName"
        comboBox.TabIndex = 56
        controls.Add(57, comboBox)
        parents.Add(57, MainForm.panelSetts)
        parentPage.Add(57, 4)

        comboBox = New ComboBox
        comboBox.Name = "directorPosition"
        comboBox.TabIndex = 57
        controls.Add(58, comboBox)
        parents.Add(58, MainForm.panelSetts)
        parentPage.Add(58, 4)

        comboBox = New ComboBox
        comboBox.Name = "Согласовано1ПУ"
        comboBox.TabIndex = 58
        controls.Add(59, comboBox)
        parents.Add(59, MainForm.panelSetts)
        parentPage.Add(59, 4)

        comboBox = New ComboBox
        comboBox.Name = "Согласовано1ДолжностьПУ"
        comboBox.TabIndex = 59
        controls.Add(60, comboBox)
        parents.Add(60, MainForm.panelSetts)
        parentPage.Add(60, 4)

        comboBox = New ComboBox
        comboBox.Name = "Согласовано2ПУ"
        comboBox.TabIndex = 60
        controls.Add(61, comboBox)
        parents.Add(61, MainForm.panelSetts)
        parentPage.Add(61, 4)

        comboBox = New ComboBox
        comboBox.Name = "Согласовано2ДолжностьПУ"
        comboBox.TabIndex = 61
        controls.Add(62, comboBox)
        parents.Add(62, MainForm.panelSetts)
        parentPage.Add(62, 4)

        controlsInit()


    End Sub

    Private Sub loadItems(comboBox As ComboBox)
        Dim values
        Dim sqlQueryString As New SqlQueryString
        Dim queryString As String

        Select Case comboBox.Name
            Case "students_defaultSearchSetts"
                comboBox.Items.AddRange(New String() {"Снилс", "Фамилия", "Имя", "Отчество"})
            Case "group_dafaultSearchSetts"
                comboBox.Items.AddRange(New String() {"Номер", "Программа", "Специальность"})
            Case "students_defaultSortSetts"
                comboBox.Items.AddRange(New String() {"Снилс", "Фамилия", "Имя"})
            Case "group_defaultSortSetts"
                comboBox.Items.AddRange(New String() {"Номер", "Программа", "Специальность"})
            Case "maxNumberRows"
                comboBox.Items.AddRange(New String() {"1000", "2000"})
            Case "directorName"
                queryString = sqlQueryString.loadDirector()
                values = mySQLConnector.loadIntoArray(queryString, 1, 0)
                values = flipDirector(values)
                comboBox.Items.AddRange(values)
            Case "directorPosition"
                queryString = sqlQueryString.loadDirectorPosition()
                values = mySQLConnector.loadIntoArray(queryString, 1, 0)
                comboBox.Items.AddRange(values)
            Case "Согласовано1ПУ"
                queryString = sqlQueryString.load_soglasovano()
                values = mySQLConnector.loadIntoArray(queryString, 1, 0)
                comboBox.Items.AddRange(values)
            Case "Согласовано2ПУ"
                queryString = sqlQueryString.load_soglasovano()
                values = mySQLConnector.loadIntoArray(queryString, 1, 0)
                comboBox.Items.AddRange(values)
            Case "Согласовано1ДолжностьПУ"
                queryString = sqlQueryString.loadPositions()
                values = mySQLConnector.loadIntoArray(queryString, 1, 0)
                comboBox.Items.AddRange(values)
            Case "Согласовано2ДолжностьПУ"
                queryString = sqlQueryString.loadPositions()
                values = mySQLConnector.loadIntoArray(queryString, 1, 0)
                comboBox.Items.AddRange(values)
        End Select


    End Sub

    Public Sub adjacentControls(numberControl As Int16)

        Dim nextNumber As Int16 = numberControl + 1
        Dim prevNumber As Int16 = numberControl - 1
        If prevNumber = 0 Then prevNumber = controls.Count
        If nextNumber = controls.Count + 1 Then nextNumber = 1

        If Not parentPage(prevNumber) = parentPage(numberControl) Then

            While parentPage(prevNumber) <> parentPage(numberControl)
                prevNumber -= 1
                If prevNumber = 0 Then prevNumber = controls.Count
            End While

        End If

        If Not parentPage(nextNumber) = parentPage(numberControl) Then

            While parentPage(nextNumber) <> parentPage(numberControl)
                nextNumber += 1
                If nextNumber = controls.Count + 1 Then nextNumber = 1
            End While

        End If

        prevControl.Add(numberControl, controls(prevNumber))
        nextControl.Add(numberControl, controls(nextNumber))

        Select Case parents(numberControl).Name

            Case "groupListSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(6))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(1))

            Case "studentsSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(6))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(1))

            Case "gradesSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(6))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(1))

            Case "ordersPKSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(0))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(2))

            Case "ordersPPSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(0))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(2))

            Case "ordersPOSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(0))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(2))

            Case "sekshionsBlanks"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(1))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(3))

            Case "booksSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(2))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(4))

            Case "booksFRDOSection"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(2))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(4))

            Case "panelSetts"

                leftControl.Add(numberControl, MainForm.TabControlOther.TabPages(3))
                rightControl.Add(numberControl, MainForm.TabControlOther.TabPages(5))



        End Select

    End Sub

    Public Sub controlsInit()

        Dim currentControl As Control
        Dim currentButton As Button
        Dim container As Control
        Dim prevContainer As String = ""
        Dim counter As Int16 = 1
        Dim location As Point
        Dim comboBox As ComboBox

        For Each control As KeyValuePair(Of Short, Control) In controls

            currentControl = control.Value

            container = parents(control.Key)
            container.Controls.Add(currentControl)

            If Not prevContainer = container.Name Then counter = 1

            If counter = 1 Then

                currentControl.Location = New Point(currentControl.Location.X + 5, currentControl.Location.Y + 14)
                If currentControl.GetType.ToString = "System.Windows.Forms.DateTimePicker" Then currentControl.Location = New Point(currentControl.Location.X + 90, currentControl.Location.Y)
                If currentControl.GetType.ToString = "System.Windows.Forms.ComboBox" Then currentControl.Location = New Point(currentControl.Location.X + 400, currentControl.Location.Y)

            Else

                If currentControl.GetType.ToString = "System.Windows.Forms.Button" Then

                    currentControl.Location = New Point(location.X, location.Y + buttonHeigth + 2)

                ElseIf currentControl.GetType.ToString = "System.Windows.Forms.CheckBox" Then

                    currentControl.Location = New Point(location.X, location.Y + checkBoxHeigth + 2)

                ElseIf currentControl.GetType.ToString = "System.Windows.Forms.DateTimePicker" Then

                    currentControl.Location = New Point(location.X + 135, location.Y)

                ElseIf currentControl.GetType.ToString = "System.Windows.Forms.ComboBox" Then

                    currentControl.Location = New Point(location.X, location.Y + comboBoxHeigth + 2)

                End If

            End If

            currentControl.Font = New Font("Microsoft YaHei", 12)


            If currentControl.GetType.ToString = "System.Windows.Forms.Button" Then

                currentButton = currentControl
                currentButton.FlatStyle = FlatStyle.Flat
                currentButton.FlatAppearance.BorderSize = 0
                currentButton.TextAlign = ContentAlignment.MiddleLeft
                currentControl.Size = New Size(container.Width - 6, buttonHeigth)

            ElseIf currentControl.GetType.ToString = "System.Windows.Forms.CheckBox" Then

                currentControl.Size = New Size(container.Width - 6, buttonHeigth)

            ElseIf currentControl.GetType.ToString = "System.Windows.Forms.DateTimePicker" Then

                Dim dPicker As DateTimePicker
                dPicker = currentControl
                dPicker.Format = DateTimePickerFormat.Short
                currentControl.Size = New Size(105, 26)

            ElseIf currentControl.GetType.ToString = "System.Windows.Forms.ComboBox" Then

                comboBox = currentControl
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList
                currentControl.Size = New Size(800, comboBoxHeigth)
                loadItems(currentControl)

            End If

            prevContainer = container.Name

            controlNames.Add(currentControl.Name, control.Key)
            adjacentControls(control.Key)
            counter += 1
            location = currentControl.Location

        Next

    End Sub



End Class


