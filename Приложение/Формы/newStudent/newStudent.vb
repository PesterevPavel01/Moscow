Imports System.Threading
Public Class newStudent

    Public Press As Boolean
    Dim SC As SynchronizationContext
    Public fromStudentsList As Boolean = False
    Dim formSlushList As New Student.formStudentsLists
    Public student As New Student
    Public flagRedactor As Boolean = False
    Public dictionaryFlag As Dictionary(Of String, Boolean)
    Private controlsEvents As New Controls_events ' Задает повидение комбобоксов и текстбоксов

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim secondThread As Thread
        SC = SynchronizationContext.Current

        student.clearStudentData()

        ActiveControl = BtnFocus
        message.Visible = False

        updateStructStudent()

        If Not student.validationFirstLavel Then

            saveButton.Enabled = True
            Return

        End If

        If Not student.validationSecondLvl(Me) Then

            Try
                Warning.ShowDialog()
            Catch ex As Exception
                Warning.Close()
                Warning.ShowDialog()
            End Try

            saveButton.Enabled = True
            Return

        End If

        If flagRedactor Then
            secondThread = New Thread(AddressOf updateStudent)
        Else
            secondThread = New Thread(AddressOf addStudent)
        End If

        secondThread.IsBackground = True
        secondThread.Start(student)

    End Sub

    Private Sub updateStructStudent()

        If fromStudentsList Then
            student.studentData.idGroup = GroupList.kod
            fromStudentsList = False
        Else
            student.studentData.idGroup = -1
        End If

        student.studentData.checkSnils = ValidOn.Checked
        student.studentData.snils = addMask.deleteMask(snils.Text)
        student.studentData.secondName = Отчество.Text
        student.studentData.name = Имя.Text
        student.studentData.lastName = secondName.Text
        student.studentData.birthDay = MainForm.mySqlConnect.dateToFormatMySQL(birthDate.Value.ToShortDateString)
        student.studentData.gender = Пол.Text
        student.studentData.educationLevel = УровеньОбразования.Text
        student.studentData.education = Образование.Text
        student.studentData.seriesDOO = СерияДокументаООбразовании.Text
        student.studentData.numberDOO = НомерДокументаООбразовании.Text
        student.studentData.lastNameDOO = ФамилияВДокОбОбразовании.Text
        student.studentData.adress = АдресРегистрации.Text
        student.studentData.telephone = Телефон.Text
        student.studentData.citizenship = Гражданство.Text
        student.studentData.dUL = ДУЛ.Text
        student.studentData.seriesDUL = СерияДУЛ.Text
        student.studentData.numberDUL = НомерДУЛ.Text
        student.studentData.dateReg = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)
        student.studentData.email = Email.Text
        student.studentData.doo_doc_type = doo_vid_dok.Text


        If dateDUL.Value.ToShortDateString = "01.01.1753" Then

            student.studentData.dateDUL = "null"

        Else
            student.studentData.dateDUL = MainForm.mySqlConnect.dateToFormatMySQL(dateDUL.Value.ToShortDateString)
        End If
        student.studentData.autorDUL = КемВыданДУЛ.Text
        student.studentData.snilsMusked = snils.Text

    End Sub

    Sub updateStudent(student As Student)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "students"
        InsertIntoDataBase.argument.firstName = "Снилс"
        InsertIntoDataBase.argument.firstValue = student.studentData.snils

        If InsertIntoDataBase.checkDuplicates() Then

            ФормаДаНет.ShowDialog()

            If Not InsertIntoDataBase.removeDuplicates Then

                SC.Send(AddressOf enabledButton, addMask.addMask(student.studentData.snils))
                Return

            End If

            InsertIntoDataBase.removeDuplicates = False

        End If

        If student.insertStudentRedact Then

            SC.Send(AddressOf updateStatus, addMask.addMask(student.studentData.snils))
            student.studentData.prevSnils = student.studentData.snils
            SC.Send(AddressOf updateFormName, student.studentData)

        Else

            SC.Send(AddressOf showErrorMassege, "Произошла ошибка, слушатель не найден")

        End If

        student.studentData.prevSnils = student.studentData.snils

        SC.Send(AddressOf enabledButton, 1)

    End Sub
    Private Sub updateFormName(StudentData As Student.strStudent)
        Me.Text = StudentData.lastName & " " & StudentData.name & " " & StudentData.secondName
        StudentsInGroup.tbl_studentsInGroup.load_table()
    End Sub

    Private Sub showErrorMassege(content As String)

        message.Text = content

    End Sub

    Sub addStudent(student As Student)

        SC.Send(AddressOf blockButton, 1)

        If student.insertStudent() Then

            SC.Send(AddressOf updateStatus, addMask.addMask(student.studentData.snils))

            If Not student.studentData.idGroup = -1 Then
                SC.Send(AddressOf updateTableStudentsInGroup, 1)
            End If

        End If

        SC.Send(AddressOf blockButton, 0)

    End Sub

    Sub updateTableStudentsInGroup(arg As Integer)
        StudentsInGroup.tbl_studentsInGroup.load_table()
    End Sub

    Sub updateStatus(student As String)

        message.Visible = True
        message.Text = "Слушатель " & student & " успешно зарегистрирован"

    End Sub

    Sub updateSnils(content As String)
        snils.Text = content
    End Sub

    Sub enabledButton(Слушатель As Integer)

        saveButton.Enabled = True

    End Sub

    Sub blockButton(arg As Integer)
        If arg = 1 Then
            saveButton.Enabled = False
        Else
            saveButton.Enabled = True
        End If


    End Sub

    Private Sub snils_TextChanged(sender As Object, e As EventArgs) Handles snils.TextChanged
        Dim snilsVal As String
        If Not Press Then

            Me.snils.Text = addMask.РубашкаНаВвод(Me.snils.Text, 3, 3, 3, 14)

        End If
        Press = False
        snils.SelectionStart = Len(Me.snils.Text)
        snilsVal = deleteMask(Me.snils.Text)
        If Len(snilsVal) = 11 Then

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "students"
            InsertIntoDataBase.argument.firstName = "Снилс"
            InsertIntoDataBase.argument.firstValue = snilsVal

            If InsertIntoDataBase.checkDuplicates() Then
                Me.snils.BackColor = Color.Pink
            Else
                Me.snils.BackColor = SystemColors.Window
            End If
        Else
            Me.snils.BackColor = SystemColors.Window
        End If


    End Sub

    Private Sub snils_KeyDown(sender As Object, e As KeyEventArgs) Handles snils.KeyDown

        Dim str As String
        str = snils.Text

        message.Visible = False

        If e.KeyCode = Keys.Back Then
            Press = True
            snils.Text = addMask.УдалитьДефисВРубашке(str)
        End If

    End Sub

    Private Sub НовыйСлушатель_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CheckBox1.Checked = True

        clear_Click(sender, e)

        ActiveControl = snils

        If Not flagRedactor Then
            Me.Text = "Новый слушатель"
            Return
        End If

        If StudentsList.studentsInfo(0, 0).ToString = "нет записей" Then

            Me.Close()
            Warning.content.Text = "Ошибка. Некорректный СНИЛС в базе. Необходима ручная проверка базы!"
            openForm(Warning)

        Else

            message.Visible = False
            ActiveControl = BtnFocus

            student.loadFormSlushLists()

            studentBuilder.build()

        End If

        student.studentData.prevSnils = addMask.deleteMask(snils.Text)

    End Sub
    Private Sub updateStatus()
        If (Имя.Text.Trim = "" And Отчество.Text.Trim = "" And secondName.Text.Trim = "") Then
            status.Text = "Новый слушатель"
            Return
        End If
        status.Text = Имя.Text.Trim & " " & Отчество.Text.Trim & " " & secondName.Text.Trim
    End Sub
    Private Sub Фамилия_TextChanged(sender As Object, e As EventArgs) Handles secondName.TextChanged
        If CheckBox1.Checked = True Then
            ФамилияВДокОбОбразовании.Text = secondName.Text
        End If
        updateStatus()

    End Sub

    Private Sub newStudent_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        closeEsc(Me, e.KeyCode)

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

            If ActiveControl.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                Dim comboBox As ComboBox = ActiveControl
                If comboBox.DroppedDown Then Return
            End If

            If ActiveControl.TabIndex = 0 And e.KeyCode = Keys.Up Then
                header.Focus()
                saveButton.Select()
            Else
                pressTab(e.KeyCode, Keys.Down)
                up(Me, e.KeyCode, Keys.Up)
            End If
            e.Handled = True

        End If

    End Sub

    Private Sub newStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        student.loadFormSlushLists()

        doo_vid_dok.Items.Clear()
        doo_vid_dok.Items.Add("")
        doo_vid_dok.Items.AddRange(student.formSlushLists.doo_doc_type)

        Пол.Items.Clear()
        Пол.Items.Add("")
        Пол.Items.AddRange(student.formSlushLists.gender)

        УровеньОбразования.Items.Clear()
        УровеньОбразования.Items.Add("")
        УровеньОбразования.Items.AddRange(student.formSlushLists.urovenObr)

        Гражданство.Items.Clear()
        Гражданство.Items.Add("")
        Гражданство.Items.AddRange(student.formSlushLists.nationality)

        ДУЛ.Items.Clear()
        ДУЛ.Items.Add("")
        ДУЛ.Items.AddRange(student.formSlushLists.doc_UL)

        If controlsEvents.initFlag Then controlsEvents.controlsReaction(dictionaryFlag, Me)
        controlsEvents.initFlag = False

    End Sub

    Private Sub ValidOn_KeyDown(sender As Object, e As KeyEventArgs) Handles ValidOn.KeyDown
        checkedChange(ValidOn, e.KeyCode)
    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        checkedChange(CheckBox1, e.KeyCode)
    End Sub

    Private Sub ValidOn_Enter(sender As Object, e As EventArgs) Handles ValidOn.Enter
        ValidOn.BackColor = Color.LightGray
    End Sub

    Private Sub ValidOn_Leave(sender As Object, e As EventArgs) Handles ValidOn.Leave
        ValidOn.BackColor = Color.Transparent
    End Sub

    Private Sub CheckBox1_Enter(sender As Object, e As EventArgs) Handles CheckBox1.Enter
        CheckBox1.BackColor = Color.LightGray
    End Sub

    Private Sub CheckBox1_Leave(sender As Object, e As EventArgs) Handles CheckBox1.Leave
        CheckBox1.BackColor = Color.Transparent
    End Sub

    Private Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click

        ActiveControl = BtnFocus

        cleanForm(Me)
        updateStatus()
        message.Visible = False

    End Sub

    Private Sub Имя_TextChanged(sender As Object, e As EventArgs) Handles Имя.TextChanged
        updateStatus()
    End Sub

    Private Sub Отчество_TextChanged(sender As Object, e As EventArgs) Handles Отчество.TextChanged
        updateStatus()
    End Sub

    Private Sub newStudent_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown

        Select Case e.KeyValue

            Case Keys.Enter

                e.IsInputKey = True

            Case Keys.Left

                e.IsInputKey = True

            Case Keys.Right

                e.IsInputKey = True

            Case Keys.Up

                e.IsInputKey = True

            Case Keys.Down

                e.IsInputKey = True

            Case MainForm.switchPageKey

                e.IsInputKey = True

            Case MainForm.seitchPageKey_Inverse

                e.IsInputKey = True

        End Select

    End Sub
End Class