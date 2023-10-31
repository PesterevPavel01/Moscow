Imports System.Threading

Public Class BuildOrder

    Public prikaz As New Prikaz
    Public fromGroupp As Boolean = False  ' true если отркрывается через группу
    Public flagLoad As Boolean = False
    Public kodGroup As Integer
    Public path As String
    Public flagCheck As Boolean = False
    Public checkedStudents
    Public comission As Boolean = False
    Public practical As Boolean = False
    Public cvalification As Int16
    Dim orderThread As Thread
    Public orderArgument As New OrderArgument
    Public dictionaryFlag As Dictionary(Of String, Boolean)
    Private controlsEvents As New Controls_events ' Задает повидение комбобоксов

    Private Sub build_Click(sender As Object, e As EventArgs) Handles КнопкаСформировать.Click

        enabledRun(False)
        Dim checkContent As Boolean

        checkContent = checkField(Me)

        If Not checkContent Then

            Try
                Warning.content.Text = "Необходимо заполнить все обязательные поля!"
                openForm(Warning)
            Catch ex As Exception
                Warning.Close()
                Warning.content.Text = "Необходимо заполнить все обязательные поля!"
                openForm(Warning)
            End Try
            Exit Sub

        End If

        Select Case orderArgument.orderType

            Case "Ведомость_слушателиИорганизации"
            Case "ВедомостьПромежуточнойАттестации"
                orderArgument.selectedModuls = checkedRows(tableStudentsList, 1, 2)
            Case "ПП_Ведомость"
                orderArgument.selectedModuls = checkedRows(tableStudentsList, 1, 2)
            Case "СправкаОбОкончании"
                orderArgument.selectedStudents = checkedRows(tableStudentsList, 0)
            Case "СправкаОбОбучении"
                orderArgument.selectedStudents = checkedRows(tableStudentsList, 0)
            Case "ДоверенностьПолученияБланковСлушателей"
                orderArgument.selectedStudents = checkedRows(tableStudentsList, 0)
            Case "ДоверенностьПолученияБланков"
            Case "ПО_Свидетельство"
            Case "ПП_ПриложениеКдиплому"
            Case "ПП_Практика"
            Case "ПО_Практика"
            Case "ПК_Заявление"
            Case "ПП_Заявление"
            Case "Карточка_слушателя"
            Case "ПК_Отчисление"
            Case "ПО_ДопускКИА"
            Case "ПП_ДопускКИА"
            Case "ПК_Окончание"
            Case "ПК_Окончание_уд"
                orderArgument.selectedStudents = checkedRows(tableStudentsList, 0)
            Case "ПП_Окончание"
            Case "ПО_Окончание"
            Case "ПК_Зачисление_Доп"
                orderArgument.selectedStudents = checkedRows(tableStudentsList, 0)
            Case "ПК_Зачисление"
                orderArgument.selectedStudents = checkedRows(tableStudentsList, 0)
            Case "ПП_Зачисление"
            Case "ПО_Зачисление"

        End Select

        orderArgument.orderIdGroup = MainForm.orderIdGroup
        orderArgument.groupNumber = groupNumber.Text
        orderArgument.mySqlConnector = MainForm.mySqlConnect
        orderArgument.orderDate = ДатаПриказа.Value
        orderArgument.practical = ПрактическаяПодготовка.Text
        orderArgument.approves = Утверждает.Text
        orderArgument.approvesPosition = УтверждаетДолжность.Text
        orderArgument.initiator = ПроектВносит.Text
        orderArgument.initiatorPosition = ПроектВноситДолжность.Text
        orderArgument.realisatorPosition = ИсполнительДолжность.Text
        orderArgument.realisator = Исполнитель.Text
        orderArgument.inspectorFirst = Согласовано1.Text
        orderArgument.inspectorFirstPosition = Согласовано1Должность.Text
        orderArgument.inspectorSec = Согласовано2.Text
        orderArgument.inspectorSecPosition = Согласовано2Должность.Text
        orderArgument.manualMode = CheckBox1.Checked
        orderArgument.gradesIA = ИтоговаяАттестация.Text
        orderArgument.responsible = Ответственный.Text
        orderArgument.responsiblePosition = ОтветственныйДолжность.Text
        orderArgument.studentPosition = CheckBoxММС.Checked
        orderArgument.studentPositionName = CheckBoxММС.Text
        orderArgument.studentAlterPos = CheckBoxСанитар.Text
        orderArgument.deputyChiefComission = ЗамПредседателя.Text
        orderArgument.deputyPosition = ЗамПредседателяДолжность.Text
        orderArgument.internshipChief = РуководительСтажировки.Text
        orderArgument.internshipChiefPosition = РуководительСтажировкиДолжность.Text
        orderArgument.comissionThird = Комиссия3.Text
        orderArgument.comissionThirdPosition = Комиссия3Должность.Text
        orderArgument.comissionSec = Комиссия2.Text
        orderArgument.comissionSecPosition = Комиссия2Должность.Text
        orderArgument.secretary = СекретарьКомиссии.Text
        orderArgument.secretaryPosition = СекретарьКомиссииДолжность.Text

        ActiveControl = Button1

        orderArgument.SC = SynchronizationContext.Current
        orderThread = New Thread(AddressOf orderRun)
        orderThread.IsBackground = True
        setFlag()
        orderThread.Start(orderArgument)

    End Sub
    Private Sub setFlag()

        Dim status As Boolean = False

        For Each flag As KeyValuePair(Of String, Boolean) In threadFlags
            If flag.Key = "orders" Then status = True
        Next

        If Not status Then
            threadFlags.Add("orders", True)
        Else
            threadFlags("orders") = True
        End If

    End Sub

    Public Sub enabledRun(value As Boolean)

        КнопкаСформировать.Enabled = value
        If value Then orderArgument.threadFlags("orders") = False

    End Sub

    Private Sub orderRun(argument As OrderArgument)

        Select Case argument.orderType

            Case "Ведомость_слушателиИорганизации"
                orderStudentsAndOrg(argument)
            Case "ВедомостьПромежуточнойАттестации"
                ВедомостьПромежуточнойАттестации.ВедомостьПромежуточнойАттестации(argument)
            Case "ПП_Ведомость"
                ВедомостьПромежуточнойАттестации.ВедомостьПромежуточнойАттестации(argument)
            Case "СправкаОбОкончании"
                СправкаОбОкончании.СправкаОбОкончании(argument)
            Case "СправкаОбОбучении"
                spravka.spravka(argument)
            Case "ДоверенностьПолученияБланковСлушателей"
                ДоверенностьПолученияБланковНаСлушателя(argument)
            Case "ДоверенностьПолученияБланков"
                ДоверенностьПолученияБланковНаГруппу.ДоверенностьПолученияБланковНаГруппу(argument)
            Case "ПО_Свидетельство"
                ПО_Свидетельство.po_svid(argument)
            Case "ПП_ПриложениеКдиплому"
                ПП_ПриложениеКДиплому.ПП_ПриложениеКДиплому(argument)
            Case "ПП_Практика"
                Приказ_Практика.Приказ_Практика(argument)
            Case "ПО_Практика"
                Приказ_Практика.Приказ_Практика(argument)
            Case "ПК_Заявление"
                Blank.ПК_Заявление(argument)
            Case "ПП_Заявление"
                Blank.ПП_Заявление(argument)
            Case "Карточка_слушателя"
                Blank.Карточка_Слушателя(argument)
            Case "ПК_Отчисление"
                Приказ_Отчисление.Приказ_Отчисление(argument)
            Case "ПО_ДопускКИА"
                Приказ_ДопускКИА.Приказ_ДопускКИА(argument)
            Case "ПП_ДопускКИА"
                Приказ_ДопускКИА.Приказ_ДопускКИА(argument)
            Case "ПК_Окончание"
                Приказ_Окончание.Приказ_Окончание(argument)
            Case "ПК_Окончание_уд"
                ПК_Окончание.ПК_Окончание_уд(argument)
            Case "ПП_Окончание"
                Приказ_Окончание.Приказ_Окончание(argument)
            Case "ПО_Окончание"
                Приказ_Окончание.Приказ_Окончание(argument)
            Case "ПК_Зачисление_Доп"
                Приказ_Зачисление.Приказ_Зачисление(argument)
            Case "ПК_Зачисление"
                Приказ_Зачисление.Приказ_Зачисление(argument)
            Case "ПП_Зачисление"
                Приказ_Зачисление.Приказ_Зачисление(argument)
            Case "ПО_Зачисление"
                Приказ_Зачисление.Приказ_Зачисление(argument)

        End Select

        argument.SC.Send(AddressOf enabledRun, True)

    End Sub

    Private Sub Очистить_Click(sender As Object, e As EventArgs) Handles КнопкаОчистить.Click

        _formCleaner.cleaner(Me)
        tableStudentsList.Items.Clear()

    End Sub

    Private Sub createBuildOrder(sender As Object, e As EventArgs) Handles Me.Shown

        flagCheck = True
        tableStudentsList.Items.Clear()
        ActiveControl = Button1

        If mainFormBuilder.controls(mainFormBuilder.controlNames("directorPosition")).Text <> "" Then
            УтверждаетДолжность.Text = mainFormBuilder.controls(mainFormBuilder.controlNames("directorPosition")).Text
        End If

        If mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано1ПУ")).Text <> "" Then
            Согласовано1.Text = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано1ПУ")).Text
        End If

        If mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано2ПУ")).Text <> "" Then
            Согласовано2.Text = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано2ПУ")).Text
        End If

        If mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано1ДолжностьПУ")).Text <> "" Then
            Согласовано1Должность.Text = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано1ДолжностьПУ")).Text
        End If

        If mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано2ДолжностьПУ")).Text <> "" Then
            Согласовано2Должность.Text = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано2ДолжностьПУ")).Text
        End If

        If comission Then

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.comission)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.comission)

        ElseIf practical Then

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.ruk_staj)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)

        Else

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.ruk_staj)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)

        End If



        If Label2.Text = "Ответственный" Then

            Утверждает.Items.Clear()
            Утверждает.Items.Add("")
            Утверждает.Items.AddRange(prikaz.formPrikazList.otv_attestat)

        Else

            Утверждает.Items.Clear()
            Утверждает.Items.Add("")
            Утверждает.Items.AddRange(prikaz.formPrikazList.director)

        End If

        If Not MainForm.directorOff Then

            If mainFormBuilder.controls(mainFormBuilder.controlNames("directorName")).Text <> "" Then
                Утверждает.Text = mainFormBuilder.controls(mainFormBuilder.controlNames("directorName")).Text
            End If

        End If

        If fromGroupp Then groupNumber.SelectedText = GroupList.numberGr

    End Sub

    Sub loadModuls()

        Dim queryString As String
        Dim progs, teachers, result

        queryString = loadListModul(MainForm.orderIdGroup)
        progs = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If progs(0, 0) = "нет записей" Then
            Exit Sub
        End If

        queryString = loadListSotrudnicModul(MainForm.orderIdGroup)
        teachers = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If teachers(0, 0) = "нет записей" Then
            Exit Sub
        End If

        teachers = rotateArray(teachers)

        ReDim result(1, UBound(progs, 2))

        For i = 0 To UBound(progs, 2)
            result(0, i) = progs(0, i)
            result(1, i) = teachers(0, i)
        Next

        If tableStudentsList.Columns.Count < 3 Then
            tableStudentsList.Columns.Add("Преподаватель", 200)
        End If

        updateListView.updateListView(False, True, tableStudentsList, result, 0, 1)

        Try
            tableStudentsList.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

    End Sub

    Sub loadStudentsList()

        Dim queryString As String
        Dim students

        queryString = formOrder__loadStudentsList(MainForm.orderIdGroup)

        students = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If students(0, 0) = "нет записей" Then
            Exit Sub
        End If

        updateListView.updateListView(True, False, tableStudentsList, students, 0)

        Try
            tableStudentsList.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub Комиссия3_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name
    End Sub

    Private Sub Комиссия2Должность_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name

    End Sub

    Private Sub СекретарьКомиссии_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name

    End Sub

    Private Sub Комиссия3Должность_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name

    End Sub

    Private Sub СекретарьКомиссииДолжность_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name

    End Sub

    Private Sub ЗамПредседателя_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name

    End Sub

    Private Sub ЗамПредседателяДолжность_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name

    End Sub

    Private Sub BuildOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If ActiveControl.GetType.ToString = "System.Windows.Forms.ComboBox" Then
            Dim comboBox As ComboBox = ActiveControl
            If comboBox.DroppedDown Then Return
        End If

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If ActiveControl.Name = "tableStudentsList" And tableStudentsList.Items.Count > 0 Then Return
            pressTab(e.KeyCode, Keys.Down)
                up(Me, e.KeyCode, Keys.Up)
                e.Handled = True
            End If

    End Sub

    Private Sub CheckBoxСанитар_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBoxСанитар.CheckedChanged
        ПрикрепитьЧекбокс(CheckBoxСанитар, CheckBoxММС)
    End Sub

    Private Sub CheckBoxММС_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxММС.CheckedChanged
        ПрикрепитьЧекбокс(CheckBoxММС, CheckBoxСанитар)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        ПрактическаяПодготовка.Text = ""
        ИтоговаяАттестация.Text = ""

        If Not CheckBox1.Checked Then

            Me.Size = New Size(840, 180)

            КнопкаСформировать.Location = New Point(135, 96)
            КнопкаОчистить.Location = New Point(2, 96)

            ПрактическаяПодготовка.Visible = False
            ИтоговаяАттестация.Visible = False

            Label24.Visible = False
            Label25.Visible = False

            ПрактическаяПодготовка.Location = New Point(260, 110)
            ИтоговаяАттестация.Location = New Point(260, 140)

            Label24.Location = New Point(20, 110)
            Label25.Location = New Point(20, 140)

        Else

            Me.Size = New Size(840, 300)
            КнопкаСформировать.Location = New Point(135, 215)
            КнопкаОчистить.Location = New Point(2, 215)

            ПрактическаяПодготовка.Location = New Point(260, 110)
            ИтоговаяАттестация.Location = New Point(260, 140)

            Label24.Location = New Point(20, 110)
            Label25.Location = New Point(20, 140)

            ПрактическаяПодготовка.Visible = True
            ИтоговаяАттестация.Visible = True

            Label24.Visible = True
            Label25.Visible = True

        End If

    End Sub

    Private Sub BuildOrder_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Утверждает.Visible = True
        УтверждаетДолжность.Visible = True
        Label2.Visible = True
        Label14.Visible = True
    End Sub

    Private Sub Включить5_CheckedChanged(sender As Object, e As EventArgs) Handles Включить5.CheckedChanged

        If Включить5.Checked = True Then
            Исполнитель.Enabled = True
        Else
            Исполнитель.Enabled = False
        End If

    End Sub

    Private Sub Включить6_CheckedChanged(sender As Object, e As EventArgs) Handles Включить6.CheckedChanged
        If Включить6.Checked = True Then
            Согласовано1.Enabled = True
        Else
            Согласовано1.Enabled = False
        End If
    End Sub

    Private Sub Ответственный_TextChanged(sender As Object, e As EventArgs) Handles Ответственный.TextChanged
        If Label4.Text <> "Слушатель(ФИО)" Then
            loadDolj(Ответственный, ОтветственныйДолжность)
        End If

    End Sub

    Private Sub ПроектВносит_TextChanged(sender As Object, e As EventArgs) Handles ПроектВносит.TextChanged
        If Not ПроектВносит.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(ПроектВносит, ПроектВноситДолжность)
        End If
    End Sub

    Private Sub Исполнитель_TextChanged(sender As Object, e As EventArgs) Handles Исполнитель.TextChanged
        If Not Исполнитель.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Исполнитель, ИсполнительДолжность)
        End If
    End Sub

    Private Sub Согласовано1_TextChanged(sender As Object, e As EventArgs) Handles Согласовано1.TextChanged
        If Not Согласовано1.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Согласовано1, Согласовано1Должность)
        End If
    End Sub

    Private Sub Согласовано2_TextChanged(sender As Object, e As EventArgs) Handles Согласовано2.TextChanged
        If Not Согласовано2.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Согласовано2, Согласовано2Должность)
        End If
    End Sub

    Private Sub РуководительСтажировки_TextChanged(sender As Object, e As EventArgs) Handles РуководительСтажировки.TextChanged
        If Not РуководительСтажировки.Text = "" Then
            loadDolj(РуководительСтажировки, РуководительСтажировкиДолжность)
        End If
    End Sub

    Private Sub Комиссия2_TextChanged(sender As Object, e As EventArgs) Handles Комиссия2.TextChanged
        If Not Комиссия2.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Комиссия2, Комиссия2Должность)
        End If
    End Sub

    Private Sub Комиссия3_TextChanged(sender As Object, e As EventArgs) Handles Комиссия3.TextChanged
        If Not Комиссия3.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Комиссия3, Комиссия3Должность)
        End If
    End Sub

    Private Sub СекретарьКомиссии_TextChanged(sender As Object, e As EventArgs) Handles СекретарьКомиссии.TextChanged
        If Not СекретарьКомиссии.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(СекретарьКомиссии, СекретарьКомиссииДолжность)
        End If
    End Sub

    Private Sub ЗамПредседателя_TextChanged(sender As Object, e As EventArgs) Handles ЗамПредседателя.TextChanged
        If Not ЗамПредседателя.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(ЗамПредседателя, ЗамПредседателяДолжность)
        End If
    End Sub

    Private Sub BuildOrder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MainForm.orderCvalif = 0
        fromGroupp = False
    End Sub

    Public Sub reload_lists()

        flagLoad = False
        BuildOrder_Load(New Object, New EventArgs)

    End Sub

    Private Sub BuildOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        controlsEvents.blackMode = False
        controlsEvents.controlsReaction(dictionaryFlag, Me)

        If Not flagLoad Then

            prikaz.loadFormPrikazLists()

            LoadDoljnosti()

            Утверждает.Items.Clear()
            УтверждаетДолжность.Items.Add("")
            Утверждает.Items.AddRange(prikaz.formPrikazList.director)

            УтверждаетДолжность.Items.Clear()
            УтверждаетДолжность.Items.Add("")
            УтверждаетДолжность.Items.AddRange(prikaz.formPrikazList.Position)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)

            ПроектВносит.Items.Clear()
            ПроектВносит.Items.Add("")
            ПроектВносит.Items.AddRange(prikaz.formPrikazList.proect_vnosit)

            Исполнитель.Items.Clear()
            Исполнитель.Items.Add("")
            Исполнитель.Items.AddRange(prikaz.formPrikazList.ispolnitel)

            Согласовано1.Items.Clear()
            Согласовано1.Items.Add("")
            Согласовано1.Items.AddRange(prikaz.formPrikazList.soglasovano)

            Согласовано2.Items.Clear()
            Согласовано2.Items.Add("")
            Согласовано2.Items.AddRange(prikaz.formPrikazList.soglasovano)

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.ruk_staj)

            Комиссия2.Items.Clear()
            Комиссия2.Items.Add("")
            Комиссия2.Items.AddRange(prikaz.formPrikazList.comission)

            Комиссия3.Items.Clear()
            Комиссия3.Items.Add("")
            Комиссия3.Items.AddRange(prikaz.formPrikazList.comission)

            СекретарьКомиссии.Items.Clear()
            СекретарьКомиссии.Items.Add("")
            СекретарьКомиссии.Items.AddRange(prikaz.formPrikazList.comission)

            ЗамПредседателя.Items.Clear()
            ЗамПредседателя.Items.Add("")
            ЗамПредседателя.Items.AddRange(prikaz.formPrikazList.comission)

            flagLoad = True

        End If

    End Sub

    Private Sub LoadDoljnosti()

        For Each control As Control In Me.Controls
            Dim type As String = control.GetType.ToString
            If (control.GetType.ToString <> "System.Windows.Forms.ComboBox") Then
                Continue For
            End If

            If Strings.Right(control.Name, 9) = "Должность" Then
                Dim comboB As ComboBox
                comboB = control
                comboB.Items.Clear()
                comboB.Items.Add("")
                comboB.Items.AddRange(prikaz.formPrikazList.positions)
            End If
        Next
    End Sub


    Public Sub load_form()
        Dim sender As Object
        Dim e As EventArgs
        BuildOrder_Load(sender, e)
    End Sub

    Private Sub Ответственный_VisibleChanged(sender As Object, e As EventArgs) Handles Ответственный.VisibleChanged

        If Ответственный.Visible = True Then
            If Label4.Text = "Слушатель(ФИО)" Then
                prikaz.kod_groupp = Convert.ToString(kodGroup)
                prikaz.loadslushatelFio()
                Ответственный.Items.Clear()
                Ответственный.Items.Add("")
                Ответственный.Items.AddRange(prikaz.formPrikazList.slushatelFio)
            Else
                Ответственный.Items.Clear()
                Ответственный.Items.Add("")
                Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)
            End If
        End If

    End Sub

    Private Sub ListViewСписокСлушателей_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles tableStudentsList.ItemChecked

        If orderArgument.orderType = "СправкаОбОбучении" Or orderArgument.orderType = "ПК_Зачисление" Or orderArgument.orderType = "ПК_Зачисление_Доп" Then
            If Not flagCheck Then
                flagCheck = True
                Return
            End If
            checkAllRow(tableStudentsList, "Выделить всех", e.Item)
        End If

    End Sub

    Sub loadDolj(FIO As ComboBox, dolj As ComboBox)

        Dim queryString As String
        Dim quaryResult As Object

        Try
            If FIO.SelectedItem = "" Then
                Return
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
        End Try


        queryString = formOrder__loadKodDolj(FIO.SelectedItem)

        quaryResult = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If quaryResult(0, 0).ToString = "нет записей" Or quaryResult(0, 0).ToString = "" Then

            Try
                FIO.SelectedItem = ""
            Catch ex As Exception
                Dim message As String = ex.Message
            End Try

            Warning.content.Text = "Необходимо указать должность для этого сотрудника в БД!"
            openForm(Warning)
            Return

        End If

        queryString = formOrder__loadNameDolj(quaryResult(0, 0).ToString)
        quaryResult = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If quaryResult(0, 0).ToString = "нет записей" Or quaryResult(0, 0).ToString = "" Then

            FIO.SelectedItem = ""
            Warning.content.Text = "Ошибка. Строка запроса " + queryString
            openForm(Warning)
            Return
        Else
            dolj.Text = quaryResult(0, 0)
        End If
    End Sub

    Private Sub groupNumber_TextChanged(sender As Object, e As EventArgs) Handles groupNumber.TextChanged

        tableStudentsList.Items.Clear()

        If orderArgument.orderType = "ПК_Отчисление" Then

            If Not groupNumber.Text = "" Then
                Label4.Visible = True
                Ответственный.Visible = True
            Else
                Label4.Visible = False
                Ответственный.Visible = False
            End If

        End If

        If orderArgument.orderType = "ПК_Окончание_уд" Or orderArgument.orderType = "СправкаОбОкончании" Or orderArgument.orderType = "ДоверенностьПолученияБланковСлушателей" Or orderArgument.orderType = "СправкаОбОбучении" Or orderArgument.orderType = "СправкаОбОкончании" Then

            If Not groupNumber.Text = "" Then
                loadStudentsList()
            End If

            If orderArgument.orderType = "СправкаОбОбучении" Then
                tableStudentsList.Items.Insert(0, New ListViewItem("Выделить всех"))
            End If

        End If

        If orderArgument.orderType = "ВедомостьПромежуточнойАттестации" Or orderArgument.orderType = "ПП_Ведомость" Then

            If Not groupNumber.Text = "" Then
                loadModuls()
            End If

        End If

        If orderArgument.orderType = "ПК_Зачисление" Or orderArgument.orderType = "ПК_Зачисление_Доп" Then

            If Not groupNumber.Text = "" Then
                loadStudentsList()
                tableStudentsList.Items.Insert(0, New ListViewItem("Выделить всех"))
                chekAllItem(tableStudentsList)
            End If

        End If

    End Sub

    Private Sub groupNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles groupNumber.KeyDown

        If e.KeyCode = Keys.Enter Then

            groupNumber_Click(sender, e)

        End If

    End Sub

    Private Sub groupNumber_Click(sender As Object, e As EventArgs) Handles groupNumber.Click

        List.resultList.Columns.RemoveAt(0)
        List.resultList.Columns.Add("Программа", 500)
        List.resultList.Columns(0).Width = 200
        List.resultList.Columns.Add("Год", 100)
        List.resultList.Columns.Add("Код", 100)
        List.textboxName = "groupNumber"
        List.currentFormName = "BuildOrder"

        List.ShowDialog()

        List.resultList.Columns.RemoveAt(1)
        List.resultList.Columns.RemoveAt(2)
        List.resultList.Columns(0).Width = 100
        List.resultList.Columns(1).Width = 620
        List.resultList.Columns(1).Text = "Наименование"

    End Sub

End Class