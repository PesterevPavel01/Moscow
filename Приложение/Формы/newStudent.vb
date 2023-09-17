Imports System.Threading
Public Class newStudent

    Public Press As Boolean
    Dim SC As SynchronizationContext
    Public fromStudentsList As Boolean = False
    Dim formSlushList As New Student.formStudentsLists
    Public student As New Student
    Public flagRedactor As Boolean = False

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
        student.studentData.sourceOfFinansing = ИсточникФин.Text
        student.studentData.направившаяОрг = НаправившаяОрг.Text
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

        SC.Send(AddressOf enabledButton, "")

    End Sub
    Private Sub updateFormName(StudentData As Student.strStudent)
        Me.Text = StudentData.lastName & " " & StudentData.name & " " & StudentData.secondName
        updateListView.updateRow("СправочникСлушатели", 1, addMask.addMask(StudentData.snils), 2, StudentData.lastName, 3, StudentData.name, 4, StudentData.secondName)
    End Sub

    Private Sub showErrorMassege(content As String)

        message.Text = content

    End Sub

    Sub addStudent(student As Student)

        SC.Send(AddressOf blockButton, 1)

        If student.insertStudent() Then

            SC.Send(AddressOf updateStatus, addMask.addMask(student.studentData.snils))

            If Not student.studentData.idGroup = -1 Then
                SC.Send(AddressOf updateStudentsInGroup.updateFormStudentsInGroup, student.studentData.idGroup)
            End If

        End If

        SC.Send(AddressOf enabledButton, addMask.addMask(student.studentData.snils))

    End Sub
    Sub updateStatus(student As String)

        message.Visible = True
        message.Text = "Слушатель " & student & " успешно зарегистрирован"

    End Sub

    Sub updateSnils(content As String)
        snils.Text = content
    End Sub

    Sub enabledButton(student As String)

        saveButton.Enabled = True

    End Sub

    Sub blockButton(Слушатель As Integer)

        saveButton.Enabled = False

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

        message.Visible = False

        Dim str As String
        str = snils.Text


        If e.KeyCode = Keys.Back Then
            Press = True
            snils.Text = addMask.УдалитьДефисВРубашке(str)
        End If

        If e.KeyCode = Keys.Enter Then
            snils_Click(sender, e)
        End If


    End Sub

    Private Sub snils_Click(sender As Object, e As EventArgs) Handles snils.Click
        message.Visible = False
    End Sub

    Private Sub Фамилия_Click(sender As Object, e As EventArgs) Handles secondName.Click
        message.Visible = False
    End Sub

    Private Sub name_Click(sender As Object, e As EventArgs) Handles Имя.Click
        message.Visible = False
    End Sub

    Private Sub secondName_Click(sender As Object, e As EventArgs) Handles Отчество.Click
        message.Visible = False
    End Sub

    Private Sub birthDate_Click(sender As Object, e As EventArgs) Handles birthDate.Click
        message.Visible = False
    End Sub

    Private Sub education_Click(sender As Object, e As EventArgs) Handles Образование.Click
        message.Visible = False
    End Sub

    Private Sub СерияДокументаООбразовании_Click(sender As Object, e As EventArgs) Handles СерияДокументаООбразовании.Click
        message.Visible = False
    End Sub

    Private Sub НомерДокументаООбразовании_Click(sender As Object, e As EventArgs) Handles НомерДокументаООбразовании.Click
        message.Visible = False
    End Sub

    Private Sub ФамилияВДокОбОбразовании_Click(sender As Object, e As EventArgs) Handles ФамилияВДокОбОбразовании.Click
        message.Visible = False
    End Sub

    Private Sub АдресРегистрации_Click(sender As Object, e As EventArgs) Handles АдресРегистрации.Click
        message.Visible = False
    End Sub

    Private Sub Телефон_Click(sender As Object, e As EventArgs) Handles Телефон.Click
        message.Visible = False
    End Sub

    Private Sub СерияДУЛ_Click(sender As Object, e As EventArgs) Handles СерияДУЛ.Click
        message.Visible = False
    End Sub

    Private Sub НомерДУЛ_Click(sender As Object, e As EventArgs) Handles НомерДУЛ.Click
        message.Visible = False
    End Sub

    Private Sub РегистрационныйНомерУдостоверения_Click(sender As Object, e As EventArgs)
        message.Visible = False
    End Sub

    Private Sub НомерБланкаУдостоверения_Click(sender As Object, e As EventArgs)
        message.Visible = False
    End Sub

    Private Sub НомерБланкаДиплома_Click(sender As Object, e As EventArgs)
        message.Visible = False
    End Sub

    Private Sub НовыйСлушатель_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        CheckBox1.Checked = True

        clear_Click(sender, e)

        ActiveControl = snils

        If Not flagRedactor Then
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

    Private Sub Фамилия_KeyDown(sender As Object, e As KeyEventArgs) Handles secondName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub Имя_KeyDown(sender As Object, e As KeyEventArgs) Handles Имя.KeyDown
        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub Отчество_KeyDown(sender As Object, e As KeyEventArgs) Handles Отчество.KeyDown
        If e.KeyCode = Keys.Enter Then

            Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub ДатаРождения_KeyDown(sender As Object, e As KeyEventArgs) Handles birthDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub Образование_KeyDown(sender As Object, e As KeyEventArgs) Handles Образование.KeyDown
        If e.KeyCode = Keys.Enter Then
            education_Click(sender, e)

        End If
    End Sub

    Private Sub СерияДокументаООбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles СерияДокументаООбразовании.KeyDown
        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub НомерДокументаООбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерДокументаООбразовании.KeyDown
        If e.KeyCode = Keys.Enter Then

            Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub ФамилияВДокОбОбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles ФамилияВДокОбОбразовании.KeyDown
        If e.KeyCode = Keys.Enter Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub АдресРегистрации_KeyDown(sender As Object, e As KeyEventArgs) Handles АдресРегистрации.KeyDown
        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub Телефон_KeyDown(sender As Object, e As KeyEventArgs) Handles Телефон.KeyDown
        If e.KeyCode = Keys.Enter Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Гражданство_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

            Call Гражданство_Click(sender, e)

        End If
    End Sub

    Private Sub СерияДУЛ_KeyDown(sender As Object, e As KeyEventArgs) Handles СерияДУЛ.KeyDown
        If e.KeyCode = Keys.Enter Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub НомерДУЛ_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерДУЛ.KeyDown
        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub РегистрационныйНомерУдостоверения_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If

    End Sub

    Private Sub НомерБланкаУдостоверения_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            Фамилия_Click(sender, e)
        End If

    End Sub

    Private Sub НомерБланкаДиплома_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            НомерБланкаДиплома_Click(sender, e)
        End If

    End Sub

    Private Sub НовыйСлушатель_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        closeEsc(Me, e.KeyCode)

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            pressTab(e.KeyCode, Keys.Down)
            up(Me, e.KeyCode, Keys.Up)
            e.Handled = True
        End If

    End Sub

    Private Sub НовыйСлушатель_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        ИсточникФин.Items.Clear()
        ИсточникФин.Items.Add("")
        ИсточникФин.Items.AddRange(student.formSlushLists.finSource)

        НаправившаяОрг.Items.Clear()
        НаправившаяОрг.Items.Add("")
        НаправившаяОрг.Items.AddRange(student.formSlushLists.napr_organization)

    End Sub

    Private Sub НаправившаяОрг_Enter(sender As Object, e As EventArgs) Handles НаправившаяОрг.Enter

        If student.flagSlushatelForm.napr_organization Then
            НаправившаяОрг.DroppedDown = False
        Else
            НаправившаяОрг.DroppedDown = True
        End If

    End Sub

    Private Sub ИсточникФин_Enter(sender As Object, e As EventArgs) Handles ИсточникФин.Enter
        If student.flagSlushatelForm.finSource Then
            ИсточникФин.DroppedDown = False
        Else
            ИсточникФин.DroppedDown = True
        End If
    End Sub

    Private Sub ИсточникФин_MouseMove(sender As Object, e As MouseEventArgs) Handles ИсточникФин.MouseMove
        student.flagSlushatelForm.finSource = True
    End Sub

    Private Sub ИсточникФин_MouseLeave(sender As Object, e As EventArgs) Handles ИсточникФин.MouseLeave
        student.flagSlushatelForm.finSource = False
    End Sub

    Private Sub Пол_MouseMove(sender As Object, e As MouseEventArgs) Handles Пол.MouseMove
        student.flagSlushatelForm.gender = True
    End Sub

    Private Sub Пол_MouseLeave(sender As Object, e As EventArgs) Handles Пол.MouseLeave
        student.flagSlushatelForm.gender = False
    End Sub

    Private Sub Пол_Enter(sender As Object, e As EventArgs) Handles Пол.Enter
        If student.flagSlushatelForm.gender Then
            Пол.DroppedDown = False
        Else
            Пол.DroppedDown = True
        End If
    End Sub

    Private Sub УровеньОбразования_MouseLeave(sender As Object, e As EventArgs) Handles УровеньОбразования.MouseLeave
        student.flagSlushatelForm.urovenObr = False
    End Sub

    Private Sub УровеньОбразования_MouseMove(sender As Object, e As MouseEventArgs) Handles УровеньОбразования.MouseMove
        student.flagSlushatelForm.urovenObr = True
    End Sub

    Private Sub УровеньОбразования_Enter(sender As Object, e As EventArgs) Handles УровеньОбразования.Enter
        If student.flagSlushatelForm.urovenObr Then
            УровеньОбразования.DroppedDown = False
        Else
            УровеньОбразования.DroppedDown = True
        End If
    End Sub

    Private Sub СтранаДОО_MouseLeave(sender As Object, e As EventArgs)
        student.flagSlushatelForm.DOO_strana = False
    End Sub

    Private Sub СтранаДОО_MouseMove(sender As Object, e As MouseEventArgs)
        student.flagSlushatelForm.DOO_strana = True
    End Sub

    Private Sub Гражданство_MouseLeave(sender As Object, e As EventArgs) Handles Гражданство.MouseLeave
        student.flagSlushatelForm.nationality = False
    End Sub

    Private Sub Гражданство_MouseMove(sender As Object, e As MouseEventArgs) Handles Гражданство.MouseMove
        student.flagSlushatelForm.nationality = True
    End Sub

    Private Sub Гражданство_Enter(sender As Object, e As EventArgs) Handles Гражданство.Enter
        If student.flagSlushatelForm.nationality Then
            Гражданство.DroppedDown = False
        Else
            Гражданство.DroppedDown = True
        End If
    End Sub

    Private Sub ДУЛ_MouseLeave(sender As Object, e As EventArgs) Handles ДУЛ.MouseLeave
        student.flagSlushatelForm.doc_UL = False
    End Sub

    Private Sub ДУЛ_MouseMove(sender As Object, e As MouseEventArgs) Handles ДУЛ.MouseMove
        student.flagSlushatelForm.doc_UL = True
    End Sub

    Private Sub ДУЛ_Enter(sender As Object, e As EventArgs) Handles ДУЛ.Enter
        If student.flagSlushatelForm.doc_UL Then
            ДУЛ.DroppedDown = False
        Else
            ДУЛ.DroppedDown = True
        End If
    End Sub

    Private Sub НаправившаяОрг_MouseLeave(sender As Object, e As EventArgs) Handles НаправившаяОрг.MouseLeave
        student.flagSlushatelForm.napr_organization = False
    End Sub

    Private Sub НаправившаяОрг_MouseMove(sender As Object, e As MouseEventArgs) Handles НаправившаяОрг.MouseMove
        student.flagSlushatelForm.napr_organization = True
    End Sub

    Private Sub Пол_Click(sender As Object, e As EventArgs) Handles Пол.Click
        message.Visible = False
    End Sub

    Private Sub УровеньОбразования_Click(sender As Object, e As EventArgs) Handles УровеньОбразования.Click
        message.Visible = False
    End Sub

    Private Sub Гражданство_Click(sender As Object, e As EventArgs) Handles Гражданство.Click
        message.Visible = False
    End Sub

    Private Sub ДУЛ_Click(sender As Object, e As EventArgs) Handles ДУЛ.Click
        message.Visible = False
    End Sub

    Private Sub ИсточникФин_Click(sender As Object, e As EventArgs) Handles ИсточникФин.Click
        message.Visible = False
    End Sub

    Private Sub НаправившаяОрг_Click(sender As Object, e As EventArgs) Handles НаправившаяОрг.Click
        message.Visible = False
    End Sub

    Private Sub ValidOn_KeyDown(sender As Object, e As KeyEventArgs) Handles ValidOn.KeyDown
        ЧекатьНаИнтер(ValidOn, e.KeyCode)
    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        ЧекатьНаИнтер(CheckBox1, e.KeyCode)
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

    Private Sub doo_vid_dok_MouseLeave(sender As Object, e As EventArgs) Handles doo_vid_dok.MouseLeave
        student.flagSlushatelForm.doo_doc_type = False
    End Sub

    Private Sub doo_vid_dok_MouseMove(sender As Object, e As MouseEventArgs) Handles doo_vid_dok.MouseMove
        student.flagSlushatelForm.doo_doc_type = True
    End Sub

    Private Sub doo_vid_dok_Enter(sender As Object, e As EventArgs) Handles doo_vid_dok.Enter

        If student.flagSlushatelForm.doo_doc_type Then
            doo_vid_dok.DroppedDown = False
        Else
            doo_vid_dok.DroppedDown = True
        End If

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
End Class