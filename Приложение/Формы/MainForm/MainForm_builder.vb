
Public Class MainForm_builder

    Public buttons As New Dictionary(Of Int16, Button)
    Public parents As New Dictionary(Of Int16, Control)
    Public buttonNames As New Dictionary(Of String, Int16)
    Public parentPage As New Dictionary(Of Int16, Int16)
    Public prevControl As New Dictionary(Of Int16, Control)
    Public nextControl As New Dictionary(Of Int16, Control)
    Public leftControl As New Dictionary(Of Int16, Control)
    Public rightControl As New Dictionary(Of Int16, Control)

    Public buttonHeigth As Integer = 50

    Public Sub init()

        Dim button As Button
        button = New Button
        button.Name = "openGroupListPK"
        button.Text = "Повышение Квалификации"
        button.TabIndex = 0
        buttons.Add(1, button)
        parents.Add(1, MainForm.groupListSection)
        parentPage.Add(1, 0)

        button = New Button
        button.Name = "openGroupListPP"
        button.Text = "Профессиональная Переподготовка"
        button.TabIndex = 1
        buttons.Add(2, button)
        parents.Add(2, MainForm.groupListSection)
        parentPage.Add(2, 0)

        button = New Button
        button.Name = "openGroupListPO"
        button.Text = "Профессиональное обучение"
        button.TabIndex = 2
        buttons.Add(3, button)
        parents.Add(3, MainForm.groupListSection)
        parentPage.Add(3, 0)

        button = New Button
        button.Name = "addGroup"
        button.Text = "Создать группу"
        button.TabIndex = 3
        buttons.Add(4, button)
        parents.Add(4, MainForm.groupListSection)
        parentPage.Add(4, 0)

        button = New Button
        button.Name = "studentsList"
        button.Text = "Справочник слушатели"
        button.TabIndex = 4
        buttons.Add(5, button)
        parents.Add(5, MainForm.studentsSection)
        parentPage.Add(5, 0)

        button = New Button
        button.Name = "addStudent"
        button.Text = "Создать слушателя"
        button.TabIndex = 5
        buttons.Add(6, button)
        parents.Add(6, MainForm.studentsSection)
        parentPage.Add(6, 0)

        button = New Button
        button.Name = "grades"
        button.Text = "Ведомость"
        button.TabIndex = 6
        buttons.Add(7, button)
        parents.Add(7, MainForm.gradesContainer)
        parentPage.Add(7, 0)

        button = New Button
        button.Name = "gradesIA"
        button.Text = "Итоговая аттестация"
        button.TabIndex = 7
        buttons.Add(8, button)
        parents.Add(8, MainForm.gradesContainer)
        parentPage.Add(8, 0)

        button = New Button
        button.Name = "workerReport"
        button.Text = "Педнагрузка"
        button.TabIndex = 8
        buttons.Add(9, button)
        parents.Add(9, MainForm.gradesContainer)
        parentPage.Add(9, 0)

        button = New Button
        button.Name = "enrollmentPK"
        button.Text = "ПК зачисление"
        button.TabIndex = 9
        buttons.Add(10, button)
        parents.Add(10, MainForm.ordersPKSection)
        parentPage.Add(10, 1)

        button = New Button
        button.Name = "enrollmentPK_pl"
        button.Text = "ПК зачисление"
        button.TabIndex = 10
        buttons.Add(11, button)
        parents.Add(11, MainForm.ordersPKSection)
        parentPage.Add(11, 1)

        button = New Button
        button.Name = "expulsionPK"
        button.Text = "ПК отчисление"
        button.TabIndex = 11
        buttons.Add(12, button)
        parents.Add(12, MainForm.ordersPKSection)
        parentPage.Add(12, 1)

        button = New Button
        button.Name = "endingPK"
        button.Text = "ПК окончание"
        button.TabIndex = 12
        buttons.Add(13, button)
        parents.Add(13, MainForm.ordersPKSection)
        parentPage.Add(13, 1)

        button = New Button
        button.Name = "endingUdPK"
        button.Text = "ПК окончание"
        button.TabIndex = 13
        buttons.Add(14, button)
        parents.Add(14, MainForm.ordersPKSection)
        parentPage.Add(14, 1)


        button = New Button
        button.Name = "enrollmentPP"
        button.Text = "ПП зачисление"
        button.TabIndex = 14
        buttons.Add(15, button)
        parents.Add(15, MainForm.ordersPPSection)
        parentPage.Add(15, 1)

        button = New Button
        button.Name = "practicalPP"
        button.Text = "ПП практика"
        button.TabIndex = 15
        buttons.Add(16, button)
        parents.Add(16, MainForm.ordersPPSection)
        parentPage.Add(16, 1)

        button = New Button
        button.Name = "finalExaminationPP"
        button.Text = "ПП допуск к ИА"
        button.TabIndex = 16
        buttons.Add(17, button)
        parents.Add(17, MainForm.ordersPPSection)
        parentPage.Add(17, 1)

        button = New Button
        button.Name = "endingPP"
        button.Text = "ПП окончание"
        button.TabIndex = 17
        buttons.Add(18, button)
        parents.Add(18, MainForm.ordersPPSection)
        parentPage.Add(18, 1)

        button = New Button
        button.Name = "enrollmentPO"
        button.Text = "ПП зачисление"
        button.TabIndex = 18
        buttons.Add(19, button)
        parents.Add(19, MainForm.ordersPOSection)
        parentPage.Add(19, 1)

        button = New Button
        button.Name = "practicalPO"
        button.Text = "ПП практика"
        button.TabIndex = 19
        buttons.Add(20, button)
        parents.Add(20, MainForm.ordersPOSection)
        parentPage.Add(20, 1)

        button = New Button
        button.Name = "finalExaminationPO"
        button.Text = "ПП допуск к ИА"
        button.TabIndex = 20
        buttons.Add(21, button)
        parents.Add(21, MainForm.ordersPOSection)
        parentPage.Add(21, 1)

        button = New Button
        button.Name = "endingPO"
        button.Text = "ПП окончание"
        button.TabIndex = 21
        buttons.Add(22, button)
        parents.Add(22, MainForm.ordersPOSection)
        parentPage.Add(22, 1)

        button = New Button
        button.Name = "diplomaSupplement"
        button.Text = "ПП приложение к диплому"
        button.TabIndex = 22
        buttons.Add(23, button)
        parents.Add(23, MainForm.sekshionsBlanks)
        parentPage.Add(23, 2)

        button = New Button
        button.Name = "certificate"
        button.Text = "ПО свидетельство"
        button.TabIndex = 23
        buttons.Add(24, button)
        parents.Add(24, MainForm.sekshionsBlanks)
        parentPage.Add(24, 2)

        button = New Button
        button.Name = "statementPK"
        button.Text = "ПК заявление"
        button.TabIndex = 24
        buttons.Add(25, button)
        parents.Add(25, MainForm.sekshionsBlanks)
        parentPage.Add(25, 2)

        button = New Button
        button.Name = "statementPP"
        button.Text = "ПП заявление"
        button.TabIndex = 25
        buttons.Add(26, button)
        parents.Add(26, MainForm.sekshionsBlanks)
        parentPage.Add(26, 2)

        button = New Button
        button.Name = "studentInformation"
        button.Text = "Карточка слушателя"
        button.TabIndex = 26
        buttons.Add(27, button)
        parents.Add(27, MainForm.sekshionsBlanks)
        parentPage.Add(27, 2)

        button = New Button
        button.Name = "studentAndOrganization"
        button.Text = "Ведомость слушатели и организации"
        button.TabIndex = 27
        buttons.Add(28, button)
        parents.Add(28, MainForm.sekshionsBlanks)
        parentPage.Add(28, 2)

        button = New Button
        button.Name = "getAllBlank"
        button.Text = "Доверенность получения бланков на группу"
        button.TabIndex = 28
        buttons.Add(29, button)
        parents.Add(29, MainForm.sekshionsBlanks)
        parentPage.Add(29, 2)

        button = New Button
        button.Name = "getSomeBlank"
        button.Text = "Доверенность получения бланков на слушателя"
        button.TabIndex = 29
        buttons.Add(30, button)
        parents.Add(30, MainForm.sekshionsBlanks)
        parentPage.Add(30, 2)

        button = New Button
        button.Name = "gradesIinterAPO"
        button.Text = "ПО ведомость промежуточной аттестации"
        button.TabIndex = 30
        buttons.Add(31, button)
        parents.Add(31, MainForm.sekshionsBlanks)
        parentPage.Add(31, 2)

        button = New Button
        button.Name = "gradesIinterAPP"
        button.Text = "ПП ведомость промежуточной аттестации"
        button.TabIndex = 31
        buttons.Add(32, button)
        parents.Add(32, MainForm.sekshionsBlanks)
        parentPage.Add(32, 2)

        button = New Button
        button.Name = "certificateStudy"
        button.Text = "Справка об обучении"
        button.TabIndex = 32
        buttons.Add(33, button)
        parents.Add(33, MainForm.sekshionsBlanks)
        parentPage.Add(33, 2)

        button = New Button
        button.Name = "certificateStudyOut"
        button.Text = "Справка об окончании без ИА"
        button.TabIndex = 33
        buttons.Add(34, button)
        parents.Add(34, MainForm.sekshionsBlanks)
        parentPage.Add(34, 2)

        button = New Button
        button.Name = "bookPK"
        button.Text = "Книга учета выданных удостоверений"
        button.TabIndex = 34
        buttons.Add(35, button)
        parents.Add(35, MainForm.booksSection)
        parentPage.Add(35, 3)

        button = New Button
        button.Name = "bookPP"
        button.Text = "Книга учета выданных дипломов"
        button.TabIndex = 35
        buttons.Add(36, button)
        parents.Add(36, MainForm.booksSection)
        parentPage.Add(36, 3)

        button = New Button
        button.Name = "bookPO"
        button.Text = "Книга учета выданных свидетельств"
        button.TabIndex = 36
        buttons.Add(37, button)
        parents.Add(37, MainForm.booksSection)
        parentPage.Add(37, 3)

        button = New Button
        button.Name = "bookFPK"
        button.Text = "Книга учета выданных удостоверений ФРДО"
        button.TabIndex = 37
        buttons.Add(38, button)
        parents.Add(38, MainForm.booksFRDOSection)
        parentPage.Add(38, 3)

        button = New Button
        button.Name = "bookFPP"
        button.Text = "Книга учета выданных дипломов ФРДО"
        button.TabIndex = 38
        buttons.Add(39, button)
        parents.Add(39, MainForm.booksFRDOSection)
        parentPage.Add(39, 3)

        button = New Button
        button.Name = "bookFPO"
        button.Text = "Книга учета выданных свидетельств ФРДО"
        button.TabIndex = 39
        buttons.Add(40, button)
        parents.Add(40, MainForm.booksFRDOSection)
        parentPage.Add(40, 3)

        buttonsInit()


    End Sub

    Public Sub adjacentButtons(numberButton As Int16)

        Dim nextNumber As Int16 = numberButton + 1
        Dim prevNumber As Int16 = numberButton - 1
        If prevNumber = 0 Then prevNumber = buttons.Count
        If nextNumber = buttons.Count + 1 Then nextNumber = 1

        If Not parentPage(prevNumber) = parentPage(numberButton) Then

            While parentPage(prevNumber) <> parentPage(numberButton)
                prevNumber -= 1
                If prevNumber = 0 Then prevNumber = buttons.Count
            End While

        End If

        If Not parentPage(nextNumber) = parentPage(numberButton) Then

            While parentPage(nextNumber) <> parentPage(numberButton)
                nextNumber += 1
                If nextNumber = buttons.Count + 1 Then nextNumber = 1
            End While

        End If

        prevControl.Add(numberButton, buttons(prevNumber))
        nextControl.Add(numberButton, buttons(nextNumber))

        Select Case parents(numberButton).Name

            Case "groupListSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(6))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(1))

            Case "studentsSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(6))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(1))

            Case "gradesSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(6))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(1))

            Case "ordersPKSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(0))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(2))

            Case "ordersPPSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(0))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(2))

            Case "ordersPOSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(0))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(2))

            Case "sekshionsBlanks"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(1))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(3))

            Case "booksSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(2))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(4))

            Case "booksFRDOSection"

                leftControl.Add(numberButton, MainForm.TabControlOther.TabPages(2))
                rightControl.Add(numberButton, MainForm.TabControlOther.TabPages(4))



        End Select

    End Sub

    Public Sub buttonsInit()

        Dim currentButton As Button
        Dim container As Control
        Dim prevContainer As String = ""
        Dim counter As Int16 = 1
        Dim location As Point

        For Each button As KeyValuePair(Of Short, Button) In buttons

            currentButton = button.Value

            container = parents(button.Key)
            container.Controls.Add(currentButton)

            If Not prevContainer = container.Name Then counter = 1

            If counter = 1 Then
                currentButton.Location = New Point(currentButton.Location.X + 5, currentButton.Location.Y + 14)
            Else
                currentButton.Location = New Point(Location.X, Location.Y + buttonHeigth + 2)
            End If

            currentButton.Size = New Size(container.Width - 6, buttonHeigth)
            currentButton.Font = New Font("Microsoft YaHei", 12)
            currentButton.FlatStyle = FlatStyle.Flat
            currentButton.FlatAppearance.BorderSize = 0
            currentButton.TextAlign = ContentAlignment.MiddleLeft
            prevContainer = container.Name

            buttonNames.Add(currentButton.Name, button.Key)
            adjacentButtons(button.Key)
            counter += 1
            location = currentButton.Location

        Next

    End Sub



End Class


