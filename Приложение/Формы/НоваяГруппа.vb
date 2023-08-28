Imports System.Reflection.Emit
Imports System.Threading
Imports Google.Protobuf.Reflection.FieldDescriptorProto.Types

Public Class НоваяГруппа

    Dim grup As New Group
    Public zakr As Boolean = False
    Public alternateTab As Integer = Keys.Down
    Public alternateTab2 As Integer = Keys.Up
    Dim SC As SynchronizationContext
    Dim secondThread As Thread
    Public swichCvalification As SwitchCvalification
    Public swichNumbers As SwichNumbers

    Public Sub setProgKod(kod As Integer)

        grup.struct_grup.kodProgram = kod

        grup.struct_grup.flagAllListProgs = True

        activateModuls(Me, НоваяГруппаПрограмма.Text, grup.struct_grup.kodProgram)

        grup.load_kol_chas()

        НоваяГруппаКоличествоЧасов.Text = grup.struct_grup.kolChasov

    End Sub

    Public Function getProgKod() As Int16

        Return grup.struct_grup.kodProgram

    End Function

    Private Sub qualification_Click(sender As Object, e As EventArgs) Handles Квалификация.Click

        message.Visible = False

    End Sub

    Private Sub modul1_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul2_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul3_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub

    Private Sub modul4_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul5_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul6_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul7_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul8_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul9_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub
    Private Sub modul10_Click(sender As Object, e As EventArgs)

        message.Visible = False

    End Sub

    Private Sub numbersHourse_Click(sender As Object, e As EventArgs) Handles НоваяГруппаКоличествоЧасов.Click

        message.Visible = False

    End Sub


    Private Sub kurator_Click(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.Click

        message.Visible = False

    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_Click(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.Click

        message.Visible = False

    End Sub

    Private Sub speciality_Click(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.Click

        message.Visible = False

    End Sub


    Private Sub program_Click(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.Click

        message.Visible = False

    End Sub


    Private Sub formEducation_click(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.Click

        message.Visible = False

    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        SC = SynchronizationContext.Current

        saveButton.Enabled = False

        ActiveControl = BtnFocus
        message.Visible = False

        If Not grup.formGroupValidation(Me) Then
            saveButton.Enabled = True
            Return
        End If

        grup.struct_grup.nameForm = "НоваяГруппа"

        grup.saveParameters(Me)

        secondThread = New Thread(AddressOf addGroup)
        secondThread.IsBackground = True
        secondThread.Start(grup.struct_grup)

    End Sub

    Sub addGroup(grup As Group.strGruppa)

        Dim queryString As String
        Dim result
        Dim queryResult As Int16 = 0

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.firstValue = grup.yearNZ
        InsertIntoDataBase.argument.secondName = "Номер"
        InsertIntoDataBase.argument.secondValue = grup.number

        queryResult = InsertIntoDataBase.checkUniq_No2()

        If queryResult = 2 Then

            ФормаДаНет.ShowDialog()

            If Not InsertIntoDataBase.removeDuplicates Then

                SC.Send(AddressOf enabledButton, grup.number)
                Return

            End If

            queryString = group__loadKodGroup(grup.number, Convert.ToString(grup.yearNZ))
            result = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            grup.Kod = result(0, 0)

            queryString = "DELETE FROM group_list WHERE Kod = " & grup.Kod

            MainForm.mySqlConnect.sendQuery(queryString, 1)

            queryString = updateGroup(grup)

            If queryString = "" Then

                SC.Send(AddressOf enabledButton, grup.number)
                Exit Sub

            End If

            InsertIntoDataBase.removeDuplicates = False

        ElseIf queryResult = 1 Then

            queryString = insertIntoGroup(grup)

            If queryString = "" Then

                SC.Send(AddressOf enabledButton, grup.number)
                Exit Sub

            End If

        Else

            SC.Send(AddressOf enabledButton, grup.number)
            SC.Send(AddressOf endTreadErr, grup.number)

        End If

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Номер"
        InsertIntoDataBase.argument.firstValue = grup.number
        InsertIntoDataBase.argument.secondName = "датаСоздания"
        InsertIntoDataBase.argument.secondValue = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)
        InsertIntoDataBase.argument.thirdName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.thirdValue = grup.yearNZ


        If InsertIntoDataBase.checkDuplicates() Then

            SC.Send(AddressOf endTread, grup.number)

        End If

        SC.Send(AddressOf enabledButton, grup.number)

    End Sub

    Sub endTread(gruppa_number As String)
        Me.message.Text = "Группа № " & gruppa_number & " успешно создана, дата записи: " & Date.Now.ToShortDateString
        Me.message.Visible = True
    End Sub

    Sub endTreadErr(gruppa_number As String)
        Me.message.Text = "Ошибка. Повторите операцию"
        Me.message.Visible = True
    End Sub

    Sub enabledButton(gruppa_number As String)
        saveButton.Enabled = True
    End Sub

    Private Sub clear_Click(sender As Object, e As EventArgs) Handles clear.Click
        ActiveControl = BtnFocus
        message.Visible = False
        grup.cleaкForm(Me)
        message.Visible = False
    End Sub

    Private Sub newGroup_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        newGroup_Load(sender, e)
    End Sub


    Private Sub formEducation_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаФормаОбучения.KeyDown
        If e.KeyCode = Keys.Enter Then
            formEducation_click(sender, e)
        End If
    End Sub

    Private Sub program_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаПрограмма.KeyDown
        If e.KeyCode = Keys.Enter Then
            program_Click(sender, e)
        End If
    End Sub

    Private Sub speciality_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаСпециальность.KeyDown
        If e.KeyCode = Keys.Enter Then
            speciality_Click(sender, e)
        End If
    End Sub

    Private Sub numbersHours_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаКоличествоЧасов.KeyDown
        If e.KeyCode = Keys.Enter Then
            numbersHourse_Click(sender, e)
        End If
    End Sub

    Private Sub kurator_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаОтветственныйКуратор.KeyDown
        If e.KeyCode = Keys.Enter Then
            kurator_Click(sender, e)
        End If
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваягруппаОтветственныйЗаПрактику.KeyDown
        If e.KeyCode = Keys.Enter Then
            НоваягруппаОтветственныйЗаПрактику_Click(sender, e)
        End If
    End Sub

    Private Sub modul1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul1_Click(sender, e)
        End If
    End Sub

    Private Sub modul2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul2_Click(sender, e)
        End If
    End Sub

    Private Sub modul3_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul3_Click(sender, e)
        End If
    End Sub

    Private Sub modul4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul4_Click(sender, e)
        End If
    End Sub

    Private Sub modul5_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul5_Click(sender, e)
        End If
    End Sub
    Private Sub modul6_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Call modul6_Click(sender, e)
        End If
    End Sub

    Private Sub modul7_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul7_Click(sender, e)
        End If
    End Sub

    Private Sub modul8_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Call modul8_Click(sender, e)
        End If
    End Sub
    Private Sub modul9_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul9_Click(sender, e)
        End If
    End Sub

    Private Sub modul10_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            modul10_Click(sender, e)
        End If
    End Sub

    Private Sub qualificationLevel_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаУровеньКвалификации.KeyDown
        If e.KeyCode = Keys.Enter Then
            qualificationLevel_Click(sender, e)
        End If
    End Sub

    Private Sub financing_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаФинансирование.KeyDown
        If e.KeyCode = Keys.Enter Then
            financing_Click(sender, e)
        End If
    End Sub

    Private Sub qualification_KeyDown(sender As Object, e As KeyEventArgs) Handles Квалификация.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call qualification_Click(sender, e)
        End If
    End Sub

    Private Sub qualificationLevel_Click(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.Click
        message.Visible = False
    End Sub

    Private Sub financing_Click(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.Click
        message.Visible = False
    End Sub

    Private Sub newGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        closeEsc(Me, e.KeyCode)

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

            pressTab(e.KeyCode, Keys.Down)
            'up(Me, e.KeyCode, Keys.Up)
            e.Handled = True

        End If

        If e.KeyCode = Keys.Delete Then
            For Each element In Me.Controls
                If ActiveControl.Name = element.name Then
                    If element.ReadOnly Then
                        Try
                            element.Text = ""
                        Catch ex As Exception

                        End Try
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub numberUd_TextChanged(sender As Object, e As EventArgs) Handles НомерУд.TextChanged

        If НомерУд.Text = "" And РегНомерУд.Text = "" Then

            activateAllType()

        Else

            swichNumbers.activeType = "pk"
            activateLavel("pk")

        End If

    End Sub

    Private Sub regNumberUd_TextChanged(sender As Object, e As EventArgs) Handles РегНомерУд.TextChanged

        If НомерУд.Text = "" And РегНомерУд.Text = "" Then

            activateAllType()

        Else

            swichNumbers.activeType = "pk"
            activateLavel("pk")

        End If

    End Sub

    Private Sub numberD_TextChanged(sender As Object, e As EventArgs) Handles НомерДиплома.TextChanged

        If НомерДиплома.Text = "" And РегНомерДиплома.Text = "" Then

            activateAllType()

        Else

            swichNumbers.activeType = "pp"
            activateLavel("pp")

        End If

    End Sub

    Private Sub regNumberD_TextChanged(sender As Object, e As EventArgs) Handles РегНомерДиплома.TextChanged

        If НомерДиплома.Text = "" And РегНомерДиплома.Text = "" Then

            activateAllType()

        Else

            swichNumbers.activeType = "pp"
            activateLavel("pp")

        End If

    End Sub

    Private Sub numberSv_TextChanged(sender As Object, e As EventArgs) Handles НомерСвид.TextChanged

        If НомерСвид.Text = "" And РегНомерСвид.Text = "" Then

            activateAllType()

        Else

            swichNumbers.activeType = "pp"
            activateLavel("po")

        End If

    End Sub

    Private Sub regNumberSv_TextChanged(sender As Object, e As EventArgs) Handles РегНомерСвид.TextChanged

        If НомерСвид.Text = "" And РегНомерСвид.Text = "" Then

            activateAllType()

        Else

            swichNumbers.activeType = "pp"
            activateLavel("po")

        End If

    End Sub

    Private Sub qualificationLevel_TextChanged(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.TextChanged

        If НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then

            grup.struct_grup.urKvalific = "профессиональное обучение"

            activateLavel("po")

        ElseIf НоваяГруппаУровеньКвалификации.Text = "повышение квалификации" Then

            grup.struct_grup.urKvalific = "повышение квалификации"

            activateLavel("pk")

        ElseIf НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Then

            grup.struct_grup.urKvalific = "профессиональная переподготовка"

            activateLavel("pp")

        End If

        НоваяГруппаСпециальность.Text = ""
        НоваяГруппаКоличествоЧасов.Clear()
        НоваяГруппаПрограмма.Text = ""
        grup.updateProgramma()

    End Sub

    Private Sub program_TextChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.TextChanged

        activateModuls(Me, НоваяГруппаПрограмма.Text, grup.struct_grup.kodProgram)

    End Sub

    Private Sub qualificationLevel_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.MouseLeave
        grup.flagGrouppForm.ur_cvalifik = False
    End Sub

    Private Sub qualificationLevel_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаУровеньКвалификации.MouseMove
        grup.flagGrouppForm.ur_cvalifik = True
    End Sub

    Private Sub qualificationLevel_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.Enter

        comboBoxDrop(НоваяГруппаУровеньКвалификации, grup.flagGrouppForm.ur_cvalifik)

    End Sub

    Private Sub formEducation_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.MouseLeave
        grup.flagGrouppForm.forma_obuch = False
    End Sub

    Private Sub formEducation_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФормаОбучения.MouseMove
        grup.flagGrouppForm.forma_obuch = True
    End Sub

    Private Sub formEducation_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.Enter

        comboBoxDrop(НоваяГруппаФормаОбучения, grup.flagGrouppForm.forma_obuch)

    End Sub

    Private Sub formEducation_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.EnabledChanged
        If НоваяГруппаФормаОбучения.Enabled = False Then
            НоваяГруппаФормаОбучения.DroppedDown = False
        End If
    End Sub

    Private Sub program_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.MouseLeave
        grup.flagGrouppForm.programma = False
    End Sub

    Private Sub program_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаПрограмма.MouseMove
        grup.flagGrouppForm.programma = True
    End Sub

    Private Sub program_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.Enter

        comboBoxDrop(НоваяГруппаПрограмма, grup.flagGrouppForm.programma)

    End Sub

    Private Sub program_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.EnabledChanged
        If НоваяГруппаПрограмма.Enabled = False Then
            НоваяГруппаПрограмма.DroppedDown = False
        End If
    End Sub

    Private Sub speciality_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.MouseLeave
        grup.flagGrouppForm.specialnost = False
    End Sub

    Private Sub speciality_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаСпециальность.MouseMove
        grup.flagGrouppForm.specialnost = True
    End Sub

    Private Sub speciality_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.Enter

        comboBoxDrop(НоваяГруппаСпециальность, grup.flagGrouppForm.specialnost)

    End Sub

    Private Sub speciality_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.EnabledChanged
        If НоваяГруппаСпециальность.Enabled = False Then
            НоваяГруппаСпециальность.DroppedDown = False
        End If
    End Sub

    Private Sub kurator_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseLeave
        grup.flagGrouppForm.kurator = False
    End Sub

    Private Sub kurator_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseMove
        grup.flagGrouppForm.kurator = True
    End Sub

    Private Sub kurator_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.Enter

        comboBoxDrop(НоваяГруппаОтветственныйКуратор, grup.flagGrouppForm.kurator)

    End Sub

    Private Sub kurator_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.EnabledChanged
        If НоваяГруппаОтветственныйКуратор.Enabled = False Then
            НоваяГруппаОтветственныйКуратор.DroppedDown = False
        End If
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_MouseLeave(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.MouseLeave
        grup.flagGrouppForm.otvetstv_praktika = False
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваягруппаОтветственныйЗаПрактику.MouseMove
        grup.flagGrouppForm.otvetstv_praktika = True
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_Enter(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.Enter

        comboBoxDrop(НоваягруппаОтветственныйЗаПрактику, grup.flagGrouppForm.otvetstv_praktika)

    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_EnabledChanged(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.EnabledChanged
        If НоваягруппаОтветственныйЗаПрактику.Enabled = False Then
            НоваягруппаОтветственныйЗаПрактику.DroppedDown = False
        End If
    End Sub

    Private Sub modul1_MouseLeave(sender As Object, e As EventArgs) Handles Модуль1.MouseLeave
        grup.flagGrouppForm.modul_1 = False
    End Sub

    Private Sub modul1_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль1.MouseMove
        grup.flagGrouppForm.modul_1 = True
    End Sub

    Private Sub modul1_Enter(sender As Object, e As EventArgs) Handles Модуль1.Enter

        comboBoxDrop(Модуль1, grup.flagGrouppForm.modul_1)

    End Sub

    Private Sub modul1_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль1.EnabledChanged

        If Модуль1.Enabled = False Then
            Модуль1.DroppedDown = False
        End If

    End Sub

    Private Sub modul2_MouseLeave(sender As Object, e As EventArgs) Handles Модуль2.MouseLeave

        grup.flagGrouppForm.modul_2 = False

    End Sub

    Private Sub modul2_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль2.MouseMove

        grup.flagGrouppForm.modul_2 = True

    End Sub

    Private Sub modul2_Enter(sender As Object, e As EventArgs) Handles Модуль2.Enter

        comboBoxDrop(Модуль2, grup.flagGrouppForm.modul_2)

    End Sub

    Private Sub modul2_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль2.EnabledChanged

        If Модуль2.Enabled = False Then
            Модуль2.DroppedDown = False
        End If

    End Sub

    Private Sub modul3_MouseLeave(sender As Object, e As EventArgs) Handles Модуль3.MouseLeave
        grup.flagGrouppForm.modul_3 = False
    End Sub

    Private Sub modul3_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль3.MouseMove

        grup.flagGrouppForm.modul_3 = True

    End Sub

    Private Sub modul3_Enter(sender As Object, e As EventArgs) Handles Модуль3.Enter

        comboBoxDrop(Модуль3, grup.flagGrouppForm.modul_3)

    End Sub

    Private Sub modul3_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль3.EnabledChanged
        If Модуль3.Enabled = False Then
            Модуль3.DroppedDown = False
        End If
    End Sub

    Private Sub modul4_MouseLeave(sender As Object, e As EventArgs) Handles Модуль4.MouseLeave
        grup.flagGrouppForm.modul_4 = False
    End Sub

    Private Sub modul4_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль4.MouseMove
        grup.flagGrouppForm.modul_4 = True
    End Sub

    Private Sub modul4_Enter(sender As Object, e As EventArgs) Handles Модуль4.Enter

        comboBoxDrop(Модуль4, grup.flagGrouppForm.modul_4)

    End Sub

    Private Sub modul4_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль4.EnabledChanged
        If Модуль4.Enabled = False Then
            Модуль4.DroppedDown = False
        End If
    End Sub

    Private Sub modul5_MouseLeave(sender As Object, e As EventArgs) Handles Модуль5.MouseLeave
        grup.flagGrouppForm.modul_5 = False
    End Sub

    Private Sub modul5_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль5.MouseMove
        grup.flagGrouppForm.modul_5 = True
    End Sub

    Private Sub modul5_Enter(sender As Object, e As EventArgs) Handles Модуль5.Enter

        comboBoxDrop(Модуль5, grup.flagGrouppForm.modul_5)

    End Sub

    Private Sub modul5_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль5.EnabledChanged
        If Модуль5.Enabled = False Then
            Модуль5.DroppedDown = False
        End If
    End Sub

    Private Sub modul6_MouseLeave(sender As Object, e As EventArgs) Handles Модуль6.MouseLeave
        grup.flagGrouppForm.modul_6 = False
    End Sub

    Private Sub modul6_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль6.MouseMove
        grup.flagGrouppForm.modul_3 = True
    End Sub

    Private Sub modul6_Enter(sender As Object, e As EventArgs) Handles Модуль6.Enter

        comboBoxDrop(Модуль6, grup.flagGrouppForm.modul_6)

    End Sub

    Private Sub modul6_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль6.EnabledChanged
        If Модуль6.Enabled = False Then
            Модуль6.DroppedDown = False
        End If
    End Sub

    Private Sub modul7_MouseLeave(sender As Object, e As EventArgs) Handles Модуль7.MouseLeave
        grup.flagGrouppForm.modul_7 = False
    End Sub

    Private Sub modul7_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль7.MouseMove
        grup.flagGrouppForm.modul_7 = True
    End Sub

    Private Sub modul7_Enter(sender As Object, e As EventArgs) Handles Модуль7.Enter

        comboBoxDrop(Модуль7, grup.flagGrouppForm.modul_7)

    End Sub

    Private Sub modul7_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль7.EnabledChanged
        If Модуль7.Enabled = False Then
            Модуль7.DroppedDown = False
        End If
    End Sub

    Private Sub modul8_MouseLeave(sender As Object, e As EventArgs) Handles Модуль8.MouseLeave
        grup.flagGrouppForm.modul_8 = False
    End Sub

    Private Sub modul8_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль8.MouseMove
        grup.flagGrouppForm.modul_8 = True
    End Sub

    Private Sub modul8_Enter(sender As Object, e As EventArgs) Handles Модуль8.Enter

        comboBoxDrop(Модуль8, grup.flagGrouppForm.modul_8)

    End Sub

    Private Sub modul8_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль8.EnabledChanged
        If Модуль8.Enabled = False Then
            Модуль8.DroppedDown = False
        End If
    End Sub

    Private Sub modul9_MouseLeave(sender As Object, e As EventArgs) Handles Модуль9.MouseLeave
        grup.flagGrouppForm.modul_9 = False
    End Sub

    Private Sub modul9_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль9.MouseMove
        grup.flagGrouppForm.modul_9 = True
    End Sub

    Private Sub modul9_Enter(sender As Object, e As EventArgs) Handles Модуль9.Enter

        comboBoxDrop(Модуль9, grup.flagGrouppForm.modul_9)

    End Sub

    Private Sub modul9_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль9.EnabledChanged
        If Модуль9.Enabled = False Then
            Модуль9.DroppedDown = False
        End If
    End Sub

    Private Sub modul10_MouseLeave(sender As Object, e As EventArgs) Handles Модуль10.MouseLeave
        grup.flagGrouppForm.modul_10 = False
    End Sub

    Private Sub modul10_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль10.MouseMove
        grup.flagGrouppForm.modul_10 = True
    End Sub

    Private Sub modul10_Enter(sender As Object, e As EventArgs) Handles Модуль10.Enter

        comboBoxDrop(Модуль10, grup.flagGrouppForm.modul_10)

    End Sub

    Private Sub modul10_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль10.EnabledChanged
        If Модуль10.Enabled = False Then
            Модуль10.DroppedDown = False
        End If
    End Sub

    Private Sub financing_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.MouseLeave
        grup.flagGrouppForm.finansirovanie = False
    End Sub

    Private Sub financing_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФинансирование.MouseMove
        grup.flagGrouppForm.finansirovanie = True
    End Sub

    Private Sub financing_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.Enter

        comboBoxDrop(НоваяГруппаФинансирование, grup.flagGrouppForm.finansirovanie)

    End Sub

    Private Sub financing_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.EnabledChanged
        If НоваяГруппаФинансирование.Enabled = False Then
            НоваяГруппаФинансирование.DroppedDown = False
        End If
    End Sub

    Private Sub qualification_MouseLeave(sender As Object, e As EventArgs) Handles Квалификация.MouseLeave
        grup.flagGrouppForm.kvalifikaciya = False
    End Sub

    Private Sub qualification_MouseMove(sender As Object, e As MouseEventArgs) Handles Квалификация.MouseMove
        grup.flagGrouppForm.kvalifikaciya = True
    End Sub

    Private Sub qualification_Enter(sender As Object, e As EventArgs) Handles Квалификация.Enter

        comboBoxDrop(Квалификация, grup.flagGrouppForm.kvalifikaciya)

    End Sub

    Private Sub qualification_EnabledChanged(sender As Object, e As EventArgs) Handles Квалификация.EnabledChanged

        If Квалификация.Enabled = False Then

            Квалификация.DroppedDown = False

        End If

    End Sub

    Private Sub versProgs_Click(sender As Object, e As EventArgs) Handles versProgs.Click
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ФормаСписок.ShowDialog()
    End Sub

    Private Sub program_SelectedIndexChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.SelectedIndexChanged

        grup.struct_grup.programma = НоваяГруппаПрограмма.Text

        If НоваяГруппаПрограмма.Text = "" Then

            grup.struct_grup.kodProgram = -1
            НоваяГруппаКоличествоЧасов.Clear()

        Else

            If grup.struct_grup.flagAllListProgs Then

                grup.struct_grup.flagAllListProgs = False
                Return

            End If

            grup.updateKodProg()
            НоваяГруппаКоличествоЧасов.Text = grup.struct_grup.kolChasov

        End If

        activateModuls(Me, НоваяГруппаПрограмма.Text, grup.struct_grup.kodProgram)

    End Sub

    Private Sub comboBoxDrop(currentComboBox As ComboBox, flag As Boolean)

        If Not currentComboBox.Enabled Then

            Return

        End If

        If flag Then

            currentComboBox.DroppedDown = False

        Else

            currentComboBox.DroppedDown = True

        End If

    End Sub

    Private Sub controlActivate(currentControl As Control)

        If Not currentControl.Enabled Then

            For Each prevControl As Control In Me.Controls

                If prevControl.TabIndex = currentControl.TabIndex - 1 Then

                    prevControl.Focus()
                    Return
                End If

            Next

        End If

    End Sub

    Private Sub poOn_Click_1(sender As Object, e As EventArgs)
        message.Visible = False
    End Sub

    Private Sub pkOn_Click_1(sender As Object, e As EventArgs)
        message.Visible = False
    End Sub

    Private Sub ppOn_Click_1(sender As Object, e As EventArgs)
        message.Visible = False
    End Sub

    Private Sub ppOn_Click(sender As Object, e As EventArgs) Handles ppOn.Click, poOn.Click

        message.Visible = False
        MainForm.cvalific = swichCvalification.type("pp") + 1
        swichNumbers.activeType = "pp"
        updateCvalification()

    End Sub

    Private Sub poOn_Click(sender As Object, e As EventArgs) Handles poOn.Click

        message.Visible = False
        MainForm.cvalific = swichCvalification.type("po") + 1
        swichNumbers.activeType = "po"
        updateCvalification()

    End Sub

    Private Sub pkOn_Click(sender As Object, e As EventArgs) Handles pkOn.Click

        swichNumbers.activeType = "pk"
        activateLavel("pk")
        message.Visible = False

    End Sub

    Private Sub НоваяГруппа_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        activateAllType()

    End Sub

    Private Sub newGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        swichNumbers = New SwichNumbers
        swichNumbersInit()

        ActiveControl = BtnFocus
        grup.struct_grup.nameForm = "НоваяГруппа"
        grup.struct_grup.kodProgram = -1

        loadLists()

        swichCvalification = New SwitchCvalification
        swichCvalificationInit()

        updateCvalification()

        activateField(False)



    End Sub

    Private Sub updateCvalification()

        swichCvalification.activate(MainForm.cvalific - 1)
        НоваяГруппаУровеньКвалификации.Text = swichCvalification.activeType
        НоваяГруппаПрограмма.Items.Clear()
        НоваяГруппаПрограмма.Items.Add("")
        НоваяГруппаПрограмма.Items.AddRange(grup.formGrouppLists.programma)

    End Sub

    Private Sub loadLists()

        grup.loadFormGrouppLists()

        НоваяГруппаУровеньКвалификации.Items.Clear()
        НоваяГруппаУровеньКвалификации.Items.Add("")
        НоваяГруппаУровеньКвалификации.Items.AddRange(grup.formGrouppLists.ur_cvalifik)

        НоваяГруппаФормаОбучения.Items.Clear()
        НоваяГруппаФормаОбучения.Items.Add("")
        НоваяГруппаФормаОбучения.Items.AddRange(grup.formGrouppLists.forma_obuch)

        НоваяГруппаПрограмма.Items.Clear()
        НоваяГруппаПрограмма.Items.Add("")
        НоваяГруппаПрограмма.Items.AddRange(grup.formGrouppLists.programma)

        НоваяГруппаСпециальность.Items.Clear()
        НоваяГруппаСпециальность.Items.Add("")
        НоваяГруппаСпециальность.Items.AddRange(grup.formGrouppLists.specialnost)

        НоваяГруппаОтветственныйКуратор.Items.Clear()
        НоваяГруппаОтветственныйКуратор.Items.Add("")
        НоваяГруппаОтветственныйКуратор.Items.AddRange(grup.formGrouppLists.kurator)

        НоваягруппаОтветственныйЗаПрактику.Items.Clear()
        НоваягруппаОтветственныйЗаПрактику.Items.Add("")
        НоваягруппаОтветственныйЗаПрактику.Items.AddRange(grup.formGrouppLists.otvetstv_praktika)

        For Each element As ComboBox In Controls.OfType(Of ComboBox)
            If Strings.Left(element.Name, 6) = "Модуль" Then
                element.Items.Clear()
                element.Items.Add("")
                element.Items.AddRange(grup.formGrouppLists.otvetstv_praktika)
            End If
        Next

        НоваяГруппаФинансирование.Items.Clear()
        НоваяГруппаФинансирование.Items.Add("")
        НоваяГруппаФинансирование.Items.AddRange(grup.formGrouppLists.finansirovanie)

        Квалификация.Items.Clear()
        Квалификация.Items.Add("")
        Квалификация.Items.AddRange(grup.formGrouppLists.kvalifikaciya)

    End Sub

    Private Sub swichNumbersInit()

        swichNumbers.init()
        swichNumbers.activeType = "null"

        swichNumbers.pkList.Add(НомерУд)
        swichNumbers.pkList.Add(РегНомерУд)
        swichNumbers.pkList.Add(ДатаВыдачиУд)
        swichNumbers.pkList.Add(lblNumberUd)
        swichNumbers.pkList.Add(lblRegNumberUd)
        swichNumbers.pkList.Add(lblDateUd)

        swichNumbers.poList.Add(НомерСвид)
        swichNumbers.poList.Add(РегНомерСвид)
        swichNumbers.poList.Add(ДатаВСвид)
        swichNumbers.poList.Add(lblNumberSv)
        swichNumbers.poList.Add(lblRegNumberSv)
        swichNumbers.poList.Add(lblDateSv)

        swichNumbers.ppList.Add(НомерДиплома)
        swichNumbers.ppList.Add(РегНомерДиплома)
        swichNumbers.ppList.Add(ДатаВДиплома)
        swichNumbers.ppList.Add(lblNumberD)
        swichNumbers.ppList.Add(lblRegNumberD)
        swichNumbers.ppList.Add(lblDateD)

    End Sub

    Private Sub swichCvalificationInit()

        swichCvalification.pp = ppOn
        swichCvalification.po = poOn
        swichCvalification.pk = pkOn
        swichCvalification.init()
        MainForm.cvalific = 0

    End Sub

    Private Sub activateAllType()

        If swichNumbers.activeType = "null" Then
            Return
        End If


        swichNumbers.activateAll()
        MainForm.cvalific = swichCvalification.type("not") + 1
        updateCvalification()
        НоваяГруппаУровеньКвалификации.Text = ""
        activateField(False)

    End Sub

    Private Sub activateLavel(level As String)

        If swichNumbers.activeType = "null" Then

            Return

        End If

        activateField(True)
        MainForm.cvalific = swichCvalification.type(level) + 1
        updateCvalification()
        swichNumbers.activeType = level
        swichNumbers.activateLevel()

    End Sub

    Private Sub activateField(enabled As Boolean)

        If enabled Then

            НоваяГруппаПрограмма.Enabled = True
            lblProgram.Enabled = True
            НоваяГруппаСпециальность.Enabled = True
            lblSpeciality.Enabled = True
            versProgs.Enabled = True
            НоваяГруппаКоличествоЧасов.Enabled = True
            lblNumbersHours.Enabled = True
            statusType.Text = swichCvalification.activeType

            If swichNumbers.activeType <> "pk" Then

                НоваяГруппаНомерПротоколаИА.Enabled = True
                LblNumberIA.Enabled = True
                НоваягруппаОтветственныйЗаПрактику.Enabled = True
                lblPracticResponsible.Enabled = True
                Квалификация.Enabled = True
                lblCval.Enabled = True

            Else

                НоваяГруппаНомерПротоколаИА.Enabled = False
                LblNumberIA.Enabled = False
                НоваягруппаОтветственныйЗаПрактику.Enabled = False
                lblPracticResponsible.Enabled = False
                Квалификация.Enabled = False
                lblCval.Enabled = False


            End If

        Else

            НоваяГруппаПрограмма.Enabled = False
            lblProgram.Enabled = False
            НоваяГруппаСпециальность.Enabled = False
            lblSpeciality.Enabled = False
            versProgs.Enabled = False
            НоваяГруппаКоличествоЧасов.Enabled = False
            lblNumbersHours.Enabled = False
            НоваяГруппаНомерПротоколаИА.Enabled = False
            LblNumberIA.Enabled = False
            НоваягруппаОтветственныйЗаПрактику.Enabled = False
            lblPracticResponsible.Enabled = False
            Квалификация.Enabled = False
            lblCval.Enabled = False
            statusType.Text = "Необходимо выбрать уровень квалификации"

        End If

    End Sub

End Class