Imports System.Reflection.Emit
Imports System.Threading
Imports Google.Protobuf.Reflection.FieldDescriptorProto.Types

Public Class newGroup

    Dim group As Group
    Public zakr As Boolean = False
    Public alternateTab As Integer = Keys.Down
    Public alternateTab2 As Integer = Keys.Up
    Dim SC As SynchronizationContext
    Dim secondThread As Thread
    Public swichCvalification As SwitchCvalification
    Public swichNumbers As SwichNumbers

    Public Sub setProgKod(kod As Integer)

        group.struct_grup.kodProgram = kod

        group.struct_grup.flagAllListProgs = True

        activateModuls(Me, НоваяГруппаПрограмма.Text, group.struct_grup.kodProgram)

        group.load_kol_chas()

        НоваяГруппаКоличествоЧасов.Text = group.struct_grup.kolChasov

    End Sub

    Public Function getProgKod() As Int16

        Return group.struct_grup.kodProgram

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

        Select Case group.struct_grup.nameForm

            Case "Новая группа"

                saveNewGroup()

            Case "Редактор группы"

                saveRedactorGroup()

        End Select



    End Sub

    Private Sub saveNewGroup()

        If Not group.formGroupValidation(Me) Then
            saveButton.Enabled = True
            Return
        End If

        group.saveParameters(Me)

        secondThread = New Thread(AddressOf addGroup)
        secondThread.IsBackground = True
        secondThread.Start(group.struct_grup)

    End Sub

    Private Sub saveRedactorGroup()

        Dim argument
        ReDim argument(2)

        argument(0) = GroupList.gruppaData

        If Not group.formGroupValidation(Me) Then
            saveButton.Enabled = True
            Return
        End If

        group.struct_grup.Kod = GroupList.kod
        group.saveParameters(Me)

        group.struct_grup.oldNumber = GroupList.numberGr
        group.struct_grup.oldYearNZ = GroupList.year

        argument(1) = group.struct_grup

        secondThread = New Thread(AddressOf updateGroup)
        secondThread.IsBackground = True
        secondThread.Start(argument)

    End Sub
    Sub updateGroup(argument)

        Dim SQLString As String
        Dim gruppaOld As Group.strGruppa = argument(0)
        Dim gruppa As Group.strGruppa = argument(1)

        If gruppa.number <> gruppa.oldNumber Or gruppa.yearNZ <> gruppa.oldYearNZ Then

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "`group`"
            InsertIntoDataBase.argument.firstName = "Номер"
            InsertIntoDataBase.argument.firstValue = gruppa.number
            InsertIntoDataBase.argument.secondName = "Year(ДатаНЗ)"
            InsertIntoDataBase.argument.secondValue = gruppa.yearNZ

            If InsertIntoDataBase.checkDuplicates() Then

                ФормаДаНетУдалить.текстДаНет.Text = "Группа " + gruppa.number + " уже существует, удалить старую запись?"
                ФормаДаНетУдалить.ShowDialog()

                If ФормаДаНетУдалить.НажатаКнопкаНет Then
                    SC.Send(AddressOf enabledButton, gruppa.number)
                    Exit Sub
                End If

                SQLString = redactorGroup__deleteGroupInGroupList(gruppa.number, gruppa.yearNZ)
                MainForm.mySqlConnect.sendQuery(SQLString, 1)

                SQLString = redactorGroup__deketeGroupInGroup(gruppa.number, gruppa.yearNZ)
                MainForm.mySqlConnect.sendQuery(SQLString, 1)

                SC.Send(AddressOf updateNomberGroup, gruppa)

            End If
        End If

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Номер"
        InsertIntoDataBase.argument.firstValue = gruppa.oldNumber
        InsertIntoDataBase.argument.secondName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.secondValue = gruppa.oldYearNZ

        If InsertIntoDataBase.checkDuplicates() Then

            SQLString = QueryString.updateGroup(gruppa)
            If SQLString = "" Then
                SC.Send(AddressOf enabledButton, gruppa.number)
                Exit Sub
            End If
            InsertIntoDataBase.removeDuplicates = False  '??????

        Else

            SQLString = QueryString.insertIntoGroup(gruppa)
            If SQLString = "" Then
                SC.Send(AddressOf enabledButton, gruppa.number)
                Exit Sub
            End If

        End If

        MainForm.mySqlConnect.sendQuery(SQLString, 1)

        If gruppaOld.numbersUDS.regNumberD <> gruppa.numbersUDS.regNumberD Or gruppaOld.numbersUDS.numberD <> gruppa.numbersUDS.numberD Or gruppaOld.numbersUDS.regNumberSv <> gruppaOld.numbersUDS.regNumberSv Or gruppaOld.numbersUDS.numberSv <> gruppa.numbersUDS.numberSv Or gruppaOld.numbersUDS.regNumberUd <> gruppa.numbersUDS.regNumberUd Or gruppaOld.numbersUDS.numberUd <> gruppa.numbersUDS.numberUd Then

            SQLString = SQLString_UpdateNumbersSGrupp(gruppa.Kod)

        End If

        SC.Send(AddressOf updateSpravGroup, gruppa)
        SC.Send(AddressOf enabledButton, gruppa.number)
    End Sub

    Sub updateSpravGroup(gruppa As Group.strGruppa)

        Dim queryString As String
        Dim DataString As String
        Dim mySqlConnect As New MySQLConnect()

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Номер"
        InsertIntoDataBase.argument.firstValue = gruppa.number
        InsertIntoDataBase.argument.secondName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.secondValue = gruppa.yearNZ

        If InsertIntoDataBase.checkDuplicates() Then

            DataString = mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)
            message.Text = "Группа № " & GroupList.numberGr & " успешно изменена, дата записи: " & DataString
            message.Visible = True
            GroupList.updateGroupList()
            StudentsInGroup.Text = "Группа № " & gruppa.number
            GroupList.infoAboutGroup(1, 0) = gruppa.number
            Me.Text = "Группа № " & gruppa.number

            If gruppa.number <> gruppa.oldNumber Then

                queryString = redactorGroup__updateGroupList(gruppa.number, gruppa.yearNZ)
                GroupList.numberGr = gruppa.number

                MainForm.mySqlConnect.sendQuery(queryString, 1)

            End If
        End If

    End Sub

    Sub updateNomberGroup(gruppa As Group.strGruppa)
        GroupList.numberGr = gruppa.number
        GroupList.year = gruppa.yearNZ
    End Sub

    Sub addGroup(grupStr As Group.strGruppa)

        Dim queryString As String
        Dim result
        Dim queryResult As Int16 = 0

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.firstValue = grupStr.yearNZ
        InsertIntoDataBase.argument.secondName = "Номер"
        InsertIntoDataBase.argument.secondValue = grupStr.number

        queryResult = InsertIntoDataBase.checkUniq_No2()

        If queryResult = 2 Then

            ФормаДаНет.ShowDialog()

            If Not InsertIntoDataBase.removeDuplicates Then

                SC.Send(AddressOf enabledButton, grupStr.number)
                Return

            End If

            queryString = group__loadKodGroup(grupStr.number, Convert.ToString(grupStr.yearNZ))
            result = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            grupStr.Kod = result(0, 0)

            queryString = group__deleteFromGroupList(grupStr.Kod)

            MainForm.mySqlConnect.sendQuery(queryString, 1)

            queryString = WindowsApp2.QueryString.updateGroup(grupStr)

            If queryString = "" Then

                SC.Send(AddressOf enabledButton, grupStr.number)
                Return

            End If

            InsertIntoDataBase.removeDuplicates = False

        ElseIf queryResult = 1 Then

            queryString = insertIntoGroup(grupStr)

            If queryString = "" Then

                SC.Send(AddressOf enabledButton, grupStr.number)
                Exit Sub

            End If

        Else

            SC.Send(AddressOf enabledButton, grupStr.number)
            SC.Send(AddressOf endTreadErr, grupStr.number)

        End If

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Номер"
        InsertIntoDataBase.argument.firstValue = grupStr.number
        InsertIntoDataBase.argument.secondName = "датаСоздания"
        InsertIntoDataBase.argument.secondValue = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)
        InsertIntoDataBase.argument.thirdName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.thirdValue = grupStr.yearNZ


        If InsertIntoDataBase.checkDuplicates() Then

            SC.Send(AddressOf endTread, grupStr.number)

        End If

        SC.Send(AddressOf enabledButton, grupStr.number)

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
        cleanForm(Me)
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

    Private Sub qualificationLevel_KeyDown(sender As Object, e As KeyEventArgs)
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

    Private Sub qualificationLevel_Click(sender As Object, e As EventArgs)
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

        numberChanged(НомерУд, РегНомерУд, "pk")

    End Sub

    Private Sub regNumberUd_TextChanged(sender As Object, e As EventArgs) Handles РегНомерУд.TextChanged

        numberChanged(РегНомерУд, НомерУд, "pk")

    End Sub

    Private Sub numberD_TextChanged(sender As Object, e As EventArgs) Handles НомерДиплома.TextChanged

        numberChanged(НомерДиплома, РегНомерДиплома, "pp")

    End Sub

    Private Sub regNumberD_TextChanged(sender As Object, e As EventArgs) Handles РегНомерДиплома.TextChanged

        numberChanged(РегНомерДиплома, НомерДиплома, "pp")

    End Sub

    Private Sub numberSv_TextChanged(sender As Object, e As EventArgs) Handles НомерСвид.TextChanged

        numberChanged(НомерСвид, РегНомерСвид, "po")

    End Sub

    Private Sub regNumberSv_TextChanged(sender As Object, e As EventArgs) Handles РегНомерСвид.TextChanged

        numberChanged(РегНомерСвид, НомерСвид, "po")

    End Sub

    Private Sub numberChanged(firstTextBox As TextBox, secondTextBox As TextBox, typeCval As String)
        'если это пи переключении, то он не выполняется!
        If firstTextBox.Enabled = False Then

            Return

        End If

        If firstTextBox.Text = "" And secondTextBox.Text = "" Then

            activateAllType()

        Else

            If firstTextBox.Text.Length = 1 And swichNumbers.activeType <> typeCval Then

                updateTypeCval(typeCval)

            End If

        End If
    End Sub

    Private Sub program_TextChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.TextChanged

        activateModuls(Me, НоваяГруппаПрограмма.Text, group.struct_grup.kodProgram)

    End Sub

    Private Sub qualificationLevel_MouseLeave(sender As Object, e As EventArgs)
        group.flagGrouppForm.ur_cvalifik = False
    End Sub

    Private Sub qualificationLevel_MouseMove(sender As Object, e As MouseEventArgs)
        group.flagGrouppForm.ur_cvalifik = True
    End Sub

    Private Sub formEducation_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.MouseLeave
        group.flagGrouppForm.forma_obuch = False
    End Sub

    Private Sub formEducation_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФормаОбучения.MouseMove
        group.flagGrouppForm.forma_obuch = True
    End Sub

    Private Sub formEducation_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.Enter

        comboBoxDrop(НоваяГруппаФормаОбучения, group.flagGrouppForm.forma_obuch)

    End Sub

    Private Sub formEducation_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.EnabledChanged
        If НоваяГруппаФормаОбучения.Enabled = False Then
            НоваяГруппаФормаОбучения.DroppedDown = False
        End If
    End Sub

    Private Sub program_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.MouseLeave
        group.flagGrouppForm.programma = False
    End Sub

    Private Sub program_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаПрограмма.MouseMove
        group.flagGrouppForm.programma = True
    End Sub

    Private Sub program_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.Enter

        comboBoxDrop(НоваяГруппаПрограмма, group.flagGrouppForm.programma)

    End Sub

    Private Sub program_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.EnabledChanged
        If НоваяГруппаПрограмма.Enabled = False Then
            НоваяГруппаПрограмма.DroppedDown = False
        End If
    End Sub

    Private Sub speciality_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.MouseLeave
        group.flagGrouppForm.specialnost = False
    End Sub

    Private Sub speciality_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаСпециальность.MouseMove
        group.flagGrouppForm.specialnost = True
    End Sub

    Private Sub speciality_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.Enter

        comboBoxDrop(НоваяГруппаСпециальность, group.flagGrouppForm.specialnost)

    End Sub

    Private Sub speciality_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.EnabledChanged
        If НоваяГруппаСпециальность.Enabled = False Then
            НоваяГруппаСпециальность.DroppedDown = False
        End If
    End Sub

    Private Sub kurator_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseLeave
        group.flagGrouppForm.kurator = False
    End Sub

    Private Sub kurator_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseMove
        group.flagGrouppForm.kurator = True
    End Sub

    Private Sub kurator_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.Enter

        comboBoxDrop(НоваяГруппаОтветственныйКуратор, group.flagGrouppForm.kurator)

    End Sub

    Private Sub kurator_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.EnabledChanged
        If НоваяГруппаОтветственныйКуратор.Enabled = False Then
            НоваяГруппаОтветственныйКуратор.DroppedDown = False
        End If
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_MouseLeave(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.MouseLeave
        group.flagGrouppForm.otvetstv_praktika = False
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваягруппаОтветственныйЗаПрактику.MouseMove
        group.flagGrouppForm.otvetstv_praktika = True
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_Enter(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.Enter

        comboBoxDrop(НоваягруппаОтветственныйЗаПрактику, group.flagGrouppForm.otvetstv_praktika)

    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_EnabledChanged(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.EnabledChanged
        If НоваягруппаОтветственныйЗаПрактику.Enabled = False Then
            НоваягруппаОтветственныйЗаПрактику.DroppedDown = False
        End If
    End Sub

    Private Sub modul1_MouseLeave(sender As Object, e As EventArgs) Handles Модуль1.MouseLeave
        group.flagGrouppForm.modul_1 = False
    End Sub

    Private Sub modul1_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль1.MouseMove
        group.flagGrouppForm.modul_1 = True
    End Sub

    Private Sub modul1_Enter(sender As Object, e As EventArgs) Handles Модуль1.Enter

        comboBoxDrop(Модуль1, group.flagGrouppForm.modul_1)

    End Sub

    Private Sub modul1_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль1.EnabledChanged

        If Модуль1.Enabled = False Then
            Модуль1.DroppedDown = False
        End If

    End Sub

    Private Sub modul2_MouseLeave(sender As Object, e As EventArgs) Handles Модуль2.MouseLeave

        group.flagGrouppForm.modul_2 = False

    End Sub

    Private Sub modul2_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль2.MouseMove

        group.flagGrouppForm.modul_2 = True

    End Sub

    Private Sub modul2_Enter(sender As Object, e As EventArgs) Handles Модуль2.Enter

        comboBoxDrop(Модуль2, group.flagGrouppForm.modul_2)

    End Sub

    Private Sub modul2_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль2.EnabledChanged

        If Модуль2.Enabled = False Then
            Модуль2.DroppedDown = False
        End If

    End Sub

    Private Sub modul3_MouseLeave(sender As Object, e As EventArgs) Handles Модуль3.MouseLeave
        group.flagGrouppForm.modul_3 = False
    End Sub

    Private Sub modul3_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль3.MouseMove

        group.flagGrouppForm.modul_3 = True

    End Sub

    Private Sub modul3_Enter(sender As Object, e As EventArgs) Handles Модуль3.Enter

        comboBoxDrop(Модуль3, group.flagGrouppForm.modul_3)

    End Sub

    Private Sub modul3_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль3.EnabledChanged
        If Модуль3.Enabled = False Then
            Модуль3.DroppedDown = False
        End If
    End Sub

    Private Sub modul4_MouseLeave(sender As Object, e As EventArgs) Handles Модуль4.MouseLeave
        group.flagGrouppForm.modul_4 = False
    End Sub

    Private Sub modul4_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль4.MouseMove
        group.flagGrouppForm.modul_4 = True
    End Sub

    Private Sub modul4_Enter(sender As Object, e As EventArgs) Handles Модуль4.Enter

        comboBoxDrop(Модуль4, group.flagGrouppForm.modul_4)

    End Sub

    Private Sub modul4_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль4.EnabledChanged
        If Модуль4.Enabled = False Then
            Модуль4.DroppedDown = False
        End If
    End Sub

    Private Sub modul5_MouseLeave(sender As Object, e As EventArgs) Handles Модуль5.MouseLeave
        group.flagGrouppForm.modul_5 = False
    End Sub

    Private Sub modul5_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль5.MouseMove
        group.flagGrouppForm.modul_5 = True
    End Sub

    Private Sub modul5_Enter(sender As Object, e As EventArgs) Handles Модуль5.Enter

        comboBoxDrop(Модуль5, group.flagGrouppForm.modul_5)

    End Sub

    Private Sub modul5_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль5.EnabledChanged
        If Модуль5.Enabled = False Then
            Модуль5.DroppedDown = False
        End If
    End Sub

    Private Sub modul6_MouseLeave(sender As Object, e As EventArgs) Handles Модуль6.MouseLeave
        group.flagGrouppForm.modul_6 = False
    End Sub

    Private Sub modul6_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль6.MouseMove
        group.flagGrouppForm.modul_3 = True
    End Sub

    Private Sub modul6_Enter(sender As Object, e As EventArgs) Handles Модуль6.Enter

        comboBoxDrop(Модуль6, group.flagGrouppForm.modul_6)

    End Sub

    Private Sub modul6_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль6.EnabledChanged
        If Модуль6.Enabled = False Then
            Модуль6.DroppedDown = False
        End If
    End Sub

    Private Sub modul7_MouseLeave(sender As Object, e As EventArgs) Handles Модуль7.MouseLeave
        group.flagGrouppForm.modul_7 = False
    End Sub

    Private Sub modul7_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль7.MouseMove
        group.flagGrouppForm.modul_7 = True
    End Sub

    Private Sub modul7_Enter(sender As Object, e As EventArgs) Handles Модуль7.Enter

        comboBoxDrop(Модуль7, group.flagGrouppForm.modul_7)

    End Sub

    Private Sub modul7_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль7.EnabledChanged
        If Модуль7.Enabled = False Then
            Модуль7.DroppedDown = False
        End If
    End Sub

    Private Sub modul8_MouseLeave(sender As Object, e As EventArgs) Handles Модуль8.MouseLeave
        group.flagGrouppForm.modul_8 = False
    End Sub

    Private Sub modul8_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль8.MouseMove
        group.flagGrouppForm.modul_8 = True
    End Sub

    Private Sub modul8_Enter(sender As Object, e As EventArgs) Handles Модуль8.Enter

        comboBoxDrop(Модуль8, group.flagGrouppForm.modul_8)

    End Sub

    Private Sub modul8_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль8.EnabledChanged
        If Модуль8.Enabled = False Then
            Модуль8.DroppedDown = False
        End If
    End Sub

    Private Sub modul9_MouseLeave(sender As Object, e As EventArgs) Handles Модуль9.MouseLeave
        group.flagGrouppForm.modul_9 = False
    End Sub

    Private Sub modul9_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль9.MouseMove
        group.flagGrouppForm.modul_9 = True
    End Sub

    Private Sub modul9_Enter(sender As Object, e As EventArgs) Handles Модуль9.Enter

        comboBoxDrop(Модуль9, group.flagGrouppForm.modul_9)

    End Sub

    Private Sub modul9_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль9.EnabledChanged
        If Модуль9.Enabled = False Then
            Модуль9.DroppedDown = False
        End If
    End Sub

    Private Sub modul10_MouseLeave(sender As Object, e As EventArgs) Handles Модуль10.MouseLeave
        group.flagGrouppForm.modul_10 = False
    End Sub

    Private Sub modul10_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль10.MouseMove
        group.flagGrouppForm.modul_10 = True
    End Sub

    Private Sub modul10_Enter(sender As Object, e As EventArgs) Handles Модуль10.Enter

        comboBoxDrop(Модуль10, group.flagGrouppForm.modul_10)

    End Sub

    Private Sub modul10_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль10.EnabledChanged
        If Модуль10.Enabled = False Then
            Модуль10.DroppedDown = False
        End If
    End Sub

    Private Sub financing_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.MouseLeave
        group.flagGrouppForm.finansirovanie = False
    End Sub

    Private Sub financing_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФинансирование.MouseMove
        group.flagGrouppForm.finansirovanie = True
    End Sub

    Private Sub financing_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.Enter

        comboBoxDrop(НоваяГруппаФинансирование, group.flagGrouppForm.finansirovanie)

    End Sub

    Private Sub financing_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.EnabledChanged
        If НоваяГруппаФинансирование.Enabled = False Then
            НоваяГруппаФинансирование.DroppedDown = False
        End If
    End Sub

    Private Sub qualification_MouseLeave(sender As Object, e As EventArgs) Handles Квалификация.MouseLeave
        group.flagGrouppForm.kvalifikaciya = False
    End Sub

    Private Sub qualification_MouseMove(sender As Object, e As MouseEventArgs) Handles Квалификация.MouseMove
        group.flagGrouppForm.kvalifikaciya = True
    End Sub

    Private Sub qualification_Enter(sender As Object, e As EventArgs) Handles Квалификация.Enter

        comboBoxDrop(Квалификация, group.flagGrouppForm.kvalifikaciya)

    End Sub

    Private Sub qualification_EnabledChanged(sender As Object, e As EventArgs) Handles Квалификация.EnabledChanged

        If Квалификация.Enabled = False Then

            Квалификация.DroppedDown = False

        End If

    End Sub

    Private Sub versProgs_Click(sender As Object, e As EventArgs) Handles versProgs.Click

        List.textboxName = НоваяГруппаПрограмма.Name
        List.currentFormName = "NewGroup"
        List.ShowDialog()

    End Sub
    Public Sub setflagAllListProgs(val As Boolean)
        group.struct_grup.flagAllListProgs = val
    End Sub

    Private Sub program_SelectedIndexChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.SelectedIndexChanged

        group.struct_grup.programma = НоваяГруппаПрограмма.Text

        If НоваяГруппаПрограмма.Text = "" Then

            group.struct_grup.kodProgram = -1
            НоваяГруппаКоличествоЧасов.Clear()

        Else

            If group.struct_grup.flagAllListProgs Then

                group.struct_grup.flagAllListProgs = False
                Return

            End If

            group.updateKodProg()
            НоваяГруппаКоличествоЧасов.Text = group.struct_grup.kolChasov

        End If

        activateModuls(Me, НоваяГруппаПрограмма.Text, group.struct_grup.kodProgram)

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

            For Each prevControl As Control In Controls

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

        updateTypeCval("pp")
        НоваяГруппаНомер.Focus()

    End Sub

    Private Sub poOn_Click(sender As Object, e As EventArgs) Handles poOn.Click

        updateTypeCval("po")
        НоваяГруппаНомер.Focus()

    End Sub

    Private Sub pkOn_Click(sender As Object, e As EventArgs) Handles pkOn.Click

        updateTypeCval("pk")
        НоваяГруппаНомер.Focus()

    End Sub

    Private Sub НоваяГруппа_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        message.Visible = False

        If group.struct_grup.nameForm = "Редактор группы" Then
            MainForm.cvalific = StudentsInGroup.cvalification
        End If

    End Sub

    Private Sub newGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ActiveControl = BtnFocus

    End Sub

    Public Sub newGroupInit()

        group = New Group()
        group.struct_grup.nameForm = "Новая группа"
        swichNumbers = New SwichNumbers
        swichNumbersInit()
        swichCvalification = New SwitchCvalification
        swichCvalificationInit()
        MainForm.cvalific = 0

        loadLists()

        group.struct_grup.kodProgram = -1
        activateAllType()

    End Sub
    Public Sub redactorGroupInit()

        group = New Group()
        group.struct_grup.nameForm = "Редактор группы"
        swichNumbers = New SwichNumbers
        swichNumbersInit()
        swichCvalification = New SwitchCvalification
        swichCvalificationInit()

        loadLists()

        swichNumbers.activeType = swichNumbers.typeCval(MainForm.cvalific - 1)

        updateCvalification()

        updateGroupRedactor.update(GroupList.numberGr)

    End Sub

    Private Sub updateTypeCval(resultingType As String)

        If swichNumbers.activeType = resultingType Then
            Return
        End If

        message.Visible = False
        MainForm.cvalific = swichCvalification.type(resultingType) + 1
        swichNumbers.activeType = resultingType

        updateCvalification()

    End Sub
    Private Sub updateCvalification()

        swichCvalification.activate(MainForm.cvalific - 1)
        statusType.Text = swichCvalification.activeType
        НоваяГруппаПрограмма.Items.Clear()
        НоваяГруппаПрограмма.Items.Add("")

        group.struct_grup.urKvalific = swichCvalification.activeType
        group.updateProgramm()

        НоваяГруппаПрограмма.Items.AddRange(group.formGrouppLists.programma)
        НоваяГруппаСпециальность.Text = ""
        НоваяГруппаКоличествоЧасов.Clear()
        НоваяГруппаПрограмма.Text = ""

        activateLavel(swichNumbers.activeType)

    End Sub

    Private Sub activateLavel(level As String)

        If swichNumbers.activeType = "null" Then
            Return
        End If

        activateField(True)
        swichNumbers.activateLevel()

    End Sub
    Private Sub activateAllType()

        swichNumbers.activateAll()
        MainForm.cvalific = swichCvalification.type("not") + 1
        updateCvalification()
        activateField(False)

    End Sub

    Private Sub loadLists()

        group.loadFormGrouppLists()

        НоваяГруппаФормаОбучения.Items.Clear()
        НоваяГруппаФормаОбучения.Items.Add("")
        НоваяГруппаФормаОбучения.Items.AddRange(group.formGrouppLists.forma_obuch)

        НоваяГруппаПрограмма.Items.Clear()
        НоваяГруппаПрограмма.Items.Add("")
        НоваяГруппаПрограмма.Items.AddRange(group.formGrouppLists.programma)

        НоваяГруппаСпециальность.Items.Clear()
        НоваяГруппаСпециальность.Items.Add("")
        НоваяГруппаСпециальность.Items.AddRange(group.formGrouppLists.specialnost)

        НоваяГруппаОтветственныйКуратор.Items.Clear()
        НоваяГруппаОтветственныйКуратор.Items.Add("")
        НоваяГруппаОтветственныйКуратор.Items.AddRange(group.formGrouppLists.kurator)

        НоваягруппаОтветственныйЗаПрактику.Items.Clear()
        НоваягруппаОтветственныйЗаПрактику.Items.Add("")
        НоваягруппаОтветственныйЗаПрактику.Items.AddRange(group.formGrouppLists.otvetstv_praktika)

        For Each element As ComboBox In Controls.OfType(Of ComboBox)
            If Strings.Left(element.Name, 6) = "Модуль" Then
                element.Items.Clear()
                element.Items.Add("")
                element.Items.AddRange(group.formGrouppLists.otvetstv_praktika)
            End If
        Next

        НоваяГруппаФинансирование.Items.Clear()
        НоваяГруппаФинансирование.Items.Add("")
        НоваяГруппаФинансирование.Items.AddRange(group.formGrouppLists.finansirovanie)

        Квалификация.Items.Clear()
        Квалификация.Items.Add("")
        Квалификация.Items.AddRange(group.formGrouppLists.kvalifikaciya)

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

        If group.struct_grup.nameForm = "Новая Группа" Then
            MainForm.cvalific = 0
        End If


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
                НоваяГруппаНомерПротоколаИА.Clear()
                LblNumberIA.Enabled = False
                НоваягруппаОтветственныйЗаПрактику.Enabled = False
                НоваягруппаОтветственныйЗаПрактику.Text = ""
                lblPracticResponsible.Enabled = False
                Квалификация.Enabled = False
                Квалификация.Text = ""
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