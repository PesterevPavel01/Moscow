Imports System.Threading

Public Class newGroup

    Public cover_image As Image
    Dim group As Group
    Public zakr As Boolean = False
    Public alternateTab As Integer = Keys.Down
    Public alternateTab2 As Integer = Keys.Up
    Dim SC As SynchronizationContext
    Dim secondThread As Thread
    Public swichCvalification As SwitchCvalification
    Public swichNumbers As SwichNumbers
    Public dictionaryFlag As Dictionary(Of String, Boolean)
    Public redactorMode As Boolean = False

    Public Sub setProgKod(kod As Integer)

        group.struct_grup.kodProgram = kod

        group.struct_grup.flagAllListProgs = True

        activateModuls(Me, НоваяГруппаПрограмма.Text, group.struct_grup.kodProgram)

        group.loadNumberHours()

        НоваяГруппаКоличествоЧасов.Text = group.struct_grup.kolChasov

    End Sub

    Public Function getProgKod() As Int16

        Return group.struct_grup.kodProgram

    End Function

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

        StudentsInGroup.cvalification = MainForm.cvalific

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

        cleanForm(Me)

        If redactorMode Then
            redactorGroupInit()
        Else
            newGroupInit()
        End If
    End Sub

    Private Sub newGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        closeEsc(Me, e.KeyCode)

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

            pressTab(e.KeyCode, Keys.Down)
            up(Me, e.KeyCode, Keys.Up)
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
        'если это при переключении, то он не выполняется!
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

        group.struct_grup.program = НоваяГруппаПрограмма.Text

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
            Dim number As Int16 = MainForm.cvalific
            StudentsInGroup.ordersBuilder.init()
        End If

    End Sub

    Private Sub newGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim path As String = resourcesPath() + "images//"
        cover_image = Image.FromFile(path + "deactivate.png")
        controlsReaction(dictionaryFlag, Me)
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

        MainForm.cvalific = StudentsInGroup.cvalification

        Dim number As Int16 = MainForm.cvalific - 1

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
        group.updateProgram()

        НоваяГруппаПрограмма.Items.AddRange(group.formGrouppLists.program)
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
        НоваяГруппаФормаОбучения.Items.AddRange(group.formGrouppLists.form_education)

        НоваяГруппаПрограмма.Items.Clear()
        НоваяГруппаПрограмма.Items.Add("")
        НоваяГруппаПрограмма.Items.AddRange(group.formGrouppLists.program)

        НоваяГруппаСпециальность.Items.Clear()
        НоваяГруппаСпециальность.Items.Add("")
        НоваяГруппаСпециальность.Items.AddRange(group.formGrouppLists.speciality)

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
        НоваяГруппаФинансирование.Items.AddRange(group.formGrouppLists.financing)

        Квалификация.Items.Clear()
        Квалификация.Items.Add("")
        Квалификация.Items.AddRange(group.formGrouppLists.qualification)

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