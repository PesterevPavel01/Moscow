Imports System.Threading
Public Class newStudent
    Public Press As Boolean
    Dim SC As SynchronizationContext
    Public fromStudentsList As Boolean = False
    Dim formSlushList As New Student.formStudentsLists
    Public slushatel As New Student

    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        Dim secondThread As Thread
        Dim snilsLen As Integer
        SC = SynchronizationContext.Current
        slushatel.clearStructSlushatel()
        ActiveControl = BtnFocus
        message.Visible = False
        snilsLen = Len(snils.Text)

        If snilsLen <> 14 Then
            MsgBox("Снилс введен некорректно")
            Exit Sub
        End If

        If Not IsNumeric(addMask.deleteMasck(snils.Text)) Then
            MsgBox("Снилс введен некорректно")
            Return
        End If

        If ValidOn.Checked Then
            If Not checkSnils(addMask.deleteMasck(snils.Text)) Then
                MsgBox("Снилс не прошел проверку")
                Exit Sub
            End If
        End If

        If birthDate.Value.ToShortDateString = "01.01.1753" Then
            MsgBox("Установите дату в поле Дата рождения")
            Exit Sub
        End If

        If snils.Text = "" Then
            MsgBox("Заполните поле 'СНИЛС'")
            Exit Sub
        End If

        If secondName.Text = "" Then
            MsgBox("Укажите Фамилию слушателя")
            Exit Sub
        End If

        If ИсточникФин.Text = "" Then
            MsgBox("Укажите источник финансирования")
            Exit Sub
        End If

        If Not interfaceMod.formStudentValidation(Me) Then
            Try
                Warning.ShowDialog()
            Catch ex As Exception
                Warning.Close()
                Warning.ShowDialog()
            End Try
            Exit Sub
        End If

        If fromStudentsList Then
            slushatel.structSlushatel.idGroup = СправочникГруппы.kod
            fromStudentsList = False
        Else
            slushatel.structSlushatel.idGroup = -1
        End If

        slushatel.structSlushatel.snils = addMask.deleteMasck(snils.Text)
        slushatel.structSlushatel.фамилия = secondName.Text
        slushatel.structSlushatel.имя = Имя.Text
        slushatel.structSlushatel.отчество = Отчество.Text
        slushatel.structSlushatel.датаР = MainForm.mySqlConnect.dateToFormatMySQL(birthDate.Value.ToShortDateString)
        slushatel.structSlushatel.пол = Пол.Text
        slushatel.structSlushatel.уровеньОбразования = УровеньОбразования.Text
        slushatel.structSlushatel.образование = Образование.Text
        slushatel.structSlushatel.серияДокументаООбразовании = СерияДокументаООбразовании.Text
        slushatel.structSlushatel.номерДокументаООбразовании = НомерДокументаООбразовании.Text
        slushatel.structSlushatel.фамилияВДокОбОбразовании = ФамилияВДокОбОбразовании.Text
        slushatel.structSlushatel.адресРегистрации = АдресРегистрации.Text
        slushatel.structSlushatel.телефон = Телефон.Text
        slushatel.structSlushatel.гражданство = Гражданство.Text
        slushatel.structSlushatel.ДУЛ = ДУЛ.Text
        slushatel.structSlushatel.серияДУЛ = СерияДУЛ.Text
        slushatel.structSlushatel.номерДУЛ = НомерДУЛ.Text
        slushatel.structSlushatel.источникФин = ИсточникФин.Text
        slushatel.structSlushatel.направившаяОрг = НаправившаяОрг.Text
        slushatel.structSlushatel.номерНаправленияРосздравнадзора = НомерНаправленияРосздравнадзора.Text
        slushatel.structSlushatel.датаНаправленияРосздравнвдзора = MainForm.mySqlConnect.dateToFormatMySQL(ДатаНаправленияРосздравнвдзора.Value.ToShortDateString)
        slushatel.structSlushatel.датаРег = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)
        slushatel.structSlushatel.Email = Email.Text
        slushatel.structSlushatel.doo_vid_dok = doo_vid_dok.Text


        If dateDUL.Value.ToShortDateString = "01.01.1753" Then

            slushatel.structSlushatel.датаВыдачиДУЛ = "null"
        Else
            slushatel.structSlushatel.датаВыдачиДУЛ = MainForm.mySqlConnect.dateToFormatMySQL(dateDUL.Value.ToShortDateString)
        End If
        slushatel.structSlushatel.кемВыданДУЛ = КемВыданДУЛ.Text
        slushatel.structSlushatel.snilsRub = snils.Text
        secondThread = New Thread(AddressOf addStudent)
        secondThread.IsBackground = True
        secondThread.Start(slushatel)

    End Sub

    Sub addStudent(slushatel As Student)

        SC.Send(AddressOf blockButton, 1)

        If slushatel.insertSlushatel() Then

            SC.Send(AddressOf updateStatus, addMask.ДобавитьРубашку(slushatel.structSlushatel.snils))
            SC.Send(AddressOf ЗаполнитьФормуССлушВГруппе.updateFormStudentsList, slushatel.structSlushatel.idGroup)

        End If

        SC.Send(AddressOf enabledButton, addMask.ДобавитьРубашку(slushatel.structSlushatel.snils))

    End Sub
    Sub updateStatus(student As String)

        message.Visible = True
        message.Text = "Слушатель " & student & " успешно зарегистрирован"

    End Sub

    Sub updateSnils(content As String)
        snils.Text = content
    End Sub

    Sub enabledButton(student As String)

        Сохранить.Enabled = True

    End Sub

    Sub blockButton(Слушатель As Integer)

        Сохранить.Enabled = False

    End Sub

    Private Sub cleaning_Click(sender As Object, e As EventArgs) Handles Очистить.Click
        Dim nameControl As String

        ActiveControl = BtnFocus

        message.Visible = False
        For Each i In Me.Controls
            nameControl = i.Name
            nameControl = Strings.Left(nameControl, 5)
            If i.Name <> "Сохранить" And i.Name <> "Очистить" And nameControl <> "Label" And nameControl <> "label" Then

                If i.Name = "ДатаРождения" Or i.Name = "ДатаОкончания" Or i.Name = "ДатаНаправленияРосздравнвдзора" Or i.Name = "ДатаВыдачиДУЛ" Then
                    i.Text = "01.01.1753"
                Else
                    i.Text = ""
                End If
            End If
        Next

        message.Visible = False

    End Sub

    Private Sub snils_TextChanged(sender As Object, e As EventArgs) Handles snils.TextChanged
        Dim snilsVal As String
        If Not Press Then

            Me.snils.Text = addMask.РубашкаНаВвод(Me.snils.Text, 3, 3, 3, 14)

        End If
        Press = False
        snils.SelectionStart = Len(Me.snils.Text)
        snilsVal = deleteMasck(Me.snils.Text)
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

    Private Sub НомерБланкаУдостоверения_Click(sender As Object, e As EventArgs) Handles НомерНаправленияРосздравнадзора.Click
        message.Visible = False
    End Sub

    Private Sub НомерБланкаДиплома_Click(sender As Object, e As EventArgs)
        message.Visible = False
    End Sub

    Private Sub НовыйСлушатель_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CheckBox1.Checked = True
        cleaning_Click(sender, e)
        ActiveControl = snils
    End Sub

    Private Sub Фамилия_TextChanged(sender As Object, e As EventArgs) Handles secondName.TextChanged
        If CheckBox1.Checked = True Then

            ФамилияВДокОбОбразовании.Text = secondName.Text

        End If
    End Sub

    Private Sub Фамилия_KeyDown(sender As Object, e As KeyEventArgs) Handles secondName.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Имя_KeyDown(sender As Object, e As KeyEventArgs) Handles Имя.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Отчество_KeyDown(sender As Object, e As KeyEventArgs) Handles Отчество.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub ДатаРождения_KeyDown(sender As Object, e As KeyEventArgs) Handles birthDate.KeyDown
        If e.KeyCode = 13 Then

            Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Образование_KeyDown(sender As Object, e As KeyEventArgs) Handles Образование.KeyDown
        If e.KeyCode = 13 Then

            Call education_Click(sender, e)

        End If
    End Sub

    Private Sub СерияДокументаООбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles СерияДокументаООбразовании.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub НомерДокументаООбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерДокументаООбразовании.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub ФамилияВДокОбОбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles ФамилияВДокОбОбразовании.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub АдресРегистрации_KeyDown(sender As Object, e As KeyEventArgs) Handles АдресРегистрации.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Телефон_KeyDown(sender As Object, e As KeyEventArgs) Handles Телефон.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Гражданство_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Call Гражданство_Click(sender, e)

        End If
    End Sub

    Private Sub СерияДУЛ_KeyDown(sender As Object, e As KeyEventArgs) Handles СерияДУЛ.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub НомерДУЛ_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерДУЛ.KeyDown
        If e.KeyCode = 13 Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub РегистрационныйНомерУдостоверения_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            Фамилия_Click(sender, e)
        End If

    End Sub

    Private Sub НомерБланкаУдостоверения_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерНаправленияРосздравнадзора.KeyDown

        If e.KeyCode = 13 Then
            Фамилия_Click(sender, e)
        End If

    End Sub

    Private Sub НомерБланкаДиплома_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            НомерБланкаДиплома_Click(sender, e)
        End If

    End Sub

    Private Sub НовыйСлушатель_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        closeEsc(Me, e.KeyCode)

        If e.KeyCode = 38 Or e.KeyCode = 40 Then
            pressTab(e.KeyCode, 40)
            up(Me, e.KeyCode, 38)
            e.Handled = True
        End If

    End Sub

    Private Sub НовыйСлушатель_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        slushatel.loadFormSlushLists()

        doo_vid_dok.Items.Clear()
        doo_vid_dok.Items.Add("")
        doo_vid_dok.Items.AddRange(slushatel.formSlushLists.doo_vid_dok)

        Пол.Items.Clear()
        Пол.Items.Add("")
        Пол.Items.AddRange(slushatel.formSlushLists.pol)

        УровеньОбразования.Items.Clear()
        УровеньОбразования.Items.Add("")
        УровеньОбразования.Items.AddRange(slushatel.formSlushLists.urovenObr)

        Гражданство.Items.Clear()
        Гражданство.Items.Add("")
        Гражданство.Items.AddRange(slushatel.formSlushLists.grajdanstvo)

        ДУЛ.Items.Clear()
        ДУЛ.Items.Add("")
        ДУЛ.Items.AddRange(slushatel.formSlushLists.dok_UL)

        ИсточникФин.Items.Clear()
        ИсточникФин.Items.Add("")
        ИсточникФин.Items.AddRange(slushatel.formSlushLists.ist_finans)

        НаправившаяОрг.Items.Clear()
        НаправившаяОрг.Items.Add("")
        НаправившаяОрг.Items.AddRange(slushatel.formSlushLists.napr_organization)

    End Sub

    Private Sub НаправившаяОрг_Enter(sender As Object, e As EventArgs) Handles НаправившаяОрг.Enter

        If slushatel.flagSlushatelForm.napr_organization Then
            НаправившаяОрг.DroppedDown = False
        Else
            НаправившаяОрг.DroppedDown = True
        End If

    End Sub

    Private Sub ИсточникФин_Enter(sender As Object, e As EventArgs) Handles ИсточникФин.Enter
        If slushatel.flagSlushatelForm.ist_finans Then
            ИсточникФин.DroppedDown = False
        Else
            ИсточникФин.DroppedDown = True
        End If
    End Sub

    Private Sub ИсточникФин_MouseMove(sender As Object, e As MouseEventArgs) Handles ИсточникФин.MouseMove
        slushatel.flagSlushatelForm.ist_finans = True
    End Sub

    Private Sub ИсточникФин_MouseLeave(sender As Object, e As EventArgs) Handles ИсточникФин.MouseLeave
        slushatel.flagSlushatelForm.ist_finans = False
    End Sub

    Private Sub Пол_MouseMove(sender As Object, e As MouseEventArgs) Handles Пол.MouseMove
        slushatel.flagSlushatelForm.pol = True
    End Sub

    Private Sub Пол_MouseLeave(sender As Object, e As EventArgs) Handles Пол.MouseLeave
        slushatel.flagSlushatelForm.pol = False
    End Sub

    Private Sub Пол_Enter(sender As Object, e As EventArgs) Handles Пол.Enter
        If slushatel.flagSlushatelForm.pol Then
            Пол.DroppedDown = False
        Else
            Пол.DroppedDown = True
        End If
    End Sub

    Private Sub УровеньОбразования_MouseLeave(sender As Object, e As EventArgs) Handles УровеньОбразования.MouseLeave
        slushatel.flagSlushatelForm.urovenObr = False
    End Sub

    Private Sub УровеньОбразования_MouseMove(sender As Object, e As MouseEventArgs) Handles УровеньОбразования.MouseMove
        slushatel.flagSlushatelForm.urovenObr = True
    End Sub

    Private Sub УровеньОбразования_Enter(sender As Object, e As EventArgs) Handles УровеньОбразования.Enter
        If slushatel.flagSlushatelForm.urovenObr Then
            УровеньОбразования.DroppedDown = False
        Else
            УровеньОбразования.DroppedDown = True
        End If
    End Sub

    Private Sub СтранаДОО_MouseLeave(sender As Object, e As EventArgs)
        slushatel.flagSlushatelForm.DOO_strana = False
    End Sub

    Private Sub СтранаДОО_MouseMove(sender As Object, e As MouseEventArgs)
        slushatel.flagSlushatelForm.DOO_strana = True
    End Sub

    Private Sub Гражданство_MouseLeave(sender As Object, e As EventArgs) Handles Гражданство.MouseLeave
        slushatel.flagSlushatelForm.grajdanstvo = False
    End Sub

    Private Sub Гражданство_MouseMove(sender As Object, e As MouseEventArgs) Handles Гражданство.MouseMove
        slushatel.flagSlushatelForm.grajdanstvo = True
    End Sub

    Private Sub Гражданство_Enter(sender As Object, e As EventArgs) Handles Гражданство.Enter
        If slushatel.flagSlushatelForm.grajdanstvo Then
            Гражданство.DroppedDown = False
        Else
            Гражданство.DroppedDown = True
        End If
    End Sub

    Private Sub ДУЛ_MouseLeave(sender As Object, e As EventArgs) Handles ДУЛ.MouseLeave
        slushatel.flagSlushatelForm.dok_UL = False
    End Sub

    Private Sub ДУЛ_MouseMove(sender As Object, e As MouseEventArgs) Handles ДУЛ.MouseMove
        slushatel.flagSlushatelForm.dok_UL = True
    End Sub

    Private Sub ДУЛ_Enter(sender As Object, e As EventArgs) Handles ДУЛ.Enter
        If slushatel.flagSlushatelForm.dok_UL Then
            ДУЛ.DroppedDown = False
        Else
            ДУЛ.DroppedDown = True
        End If
    End Sub

    Private Sub НаправившаяОрг_MouseLeave(sender As Object, e As EventArgs) Handles НаправившаяОрг.MouseLeave
        slushatel.flagSlushatelForm.napr_organization = False
    End Sub

    Private Sub НаправившаяОрг_MouseMove(sender As Object, e As MouseEventArgs) Handles НаправившаяОрг.MouseMove
        slushatel.flagSlushatelForm.napr_organization = True
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
        slushatel.flagSlushatelForm.doo_vid_dok = False
    End Sub

    Private Sub doo_vid_dok_MouseMove(sender As Object, e As MouseEventArgs) Handles doo_vid_dok.MouseMove
        slushatel.flagSlushatelForm.doo_vid_dok = True
    End Sub

    Private Sub doo_vid_dok_Enter(sender As Object, e As EventArgs) Handles doo_vid_dok.Enter

        If slushatel.flagSlushatelForm.doo_vid_dok Then
            doo_vid_dok.DroppedDown = False
        Else
            doo_vid_dok.DroppedDown = True
        End If

    End Sub

End Class