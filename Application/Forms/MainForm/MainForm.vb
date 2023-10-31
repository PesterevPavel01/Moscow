
Public Class MainForm

    Public redactor_enter As Boolean
    Public password0 As String
    Public query
    Public switchPageKey As Integer = Keys.Right
    Public seitchPageKey_Inverse As Integer = Keys.Left

    Public directorOff As Boolean = False
    Public mySqlConnect As New MySQLConnect
    Public orderIdGroup As Int64 = 0
    Public activeTables As String = "Не загружено"
    Public settsStatus As Boolean = True
    Public cvalific As UInt16 = 0

    Public Const PK = 1
    Public Const PP = 2
    Public Const PO = 3
    Public Const PK_PP_PO = 0
    Public Const PK_PP = 4

    Public orderCvalif As UInt16 = 0
    Public program As New Programm
    Public worker As New Worker
    Private flag_ToolStrip_name_list As Boolean
    Private flag_worker_dolgnost As Boolean
    Private flag_worker_type As Boolean
    Public tbl_education As New Tables_control
    Public programs__progrs_tbl As New Tables_control
    Public programs_type_tbl As New Tables_control
    Public sqlQueryString As New SqlQueryString
    Public formEvents As New MainForm_events

    Public Sub formLoad(sender As Object, e As EventArgs) Handles MyBase.Load

        formEvents.mainForm = Me
        formEvents.init()

        updateListView.arrayEmpty = False

        mySqlConnect.mySqlSettings.nameFirstDB = "database"
        mySqlConnect.mySqlSettings.userName = "admin"
        mySqlConnect.mySqlSettings.password = "admin"
        mySqlConnect.mySqlSettings.ODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlConnect.mySqlSettings.server = "localhost"
        progsIndicator.Image = iconsList.Images(8)

        modulInProgsIndicatorOn(False)

        modulIndicator.Image = iconsList.Images(8)
        panel_worker.Parent = SplitContainerOtherList.Panel2

        DataGridView_list.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft YaHei", 12)
        DataGridView_list.DefaultCellStyle.Font = New Font("Microsoft YaHei", 12)

        DataGridAllModuls.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft YaHei", 12)
        DataGridAllModuls.DefaultCellStyle.Font = New Font("Microsoft YaHei", 12)

        dataGridModulsInProgram.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft YaHei", 12)
        dataGridModulsInProgram.DefaultCellStyle.Font = New Font("Microsoft YaHei", 12)

        StudentsInGroup.tbl_studentsInGroup.studentInGroupSettings_init()
        StudentsInGroup.tbl_studentsInGroup.keyboardEvents.userDGV_init()

        mainFormBuilder.controls(1).Focus()
        mainFormBuilder.controls(1).Select()

    End Sub

    Public Sub prog_DataGridTablesResult_activate()

        ActiveControl = programs__progrs_tbl.DataGridTablesResult

    End Sub

    Public Sub prog_redactor_element_first_activate()

        ActiveControl = programs__progrs_tbl.redactor_element_first
        select_textBox(programs__progrs_tbl.redactor_element_first)

    End Sub

    Private Sub select_textBox(control As Control)

        If control.GetType.ToString = "System.Windows.Forms.TextBox" Then

            Dim lenght As Integer = control.Text.Length
            Dim s_control As TextBox = control
            s_control.Select(lenght, 0)

        End If

    End Sub

    Public Sub standard_location(Optional arg As Integer = 0)

        местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        местоНаФормеПослеДиректора(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)

        If arg = 1 Then

            Return

        End If

        местоНаФормеПослеДиректора(3, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        местоНаФормеПослеДиректора(4, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        местоНаФормеПослеДиректора(5, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        местоНаФормеПослеДиректора(6, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

    End Sub

    Sub ОтветственныйЗаАттестацию(Видимость As Boolean, Optional Подпись1текстБ As String = "Ответственный за аттестацию")

        '----------------Ответственный за аттестацию------------
        BuildOrder.load_form()

        BuildOrder.GroupBox5.Visible = Видимость
        BuildOrder.Label4.Visible = Видимость ' ответственный за аттестацию
        BuildOrder.Label13.Visible = False ' должность

        BuildOrder.Label4.Text = Подпись1текстБ

        BuildOrder.Ответственный.Items.Clear()
        BuildOrder.Ответственный.Items.AddRange(BuildOrder.prikaz.formPrikazList.otv_attestat)

        BuildOrder.Ответственный.Visible = Видимость
        BuildOrder.ОтветственныйДолжность.Visible = False

    End Sub
    Sub чекбоксы(Видимость As Boolean, ИмяПервый As String, ИмяВторой As String, ПодписьКонтейнера As String)

        BuildOrder.CheckBoxММС.Visible = Видимость
        BuildOrder.CheckBoxСанитар.Visible = Видимость
        BuildOrder.GroupBox11.Visible = Видимость
        BuildOrder.CheckBoxММС.Text = ИмяПервый
        BuildOrder.CheckBoxСанитар.Text = ИмяВторой
        BuildOrder.GroupBox11.Text = ПодписьКонтейнера

    End Sub


    Sub Утверждает(Видимость As Boolean)

        BuildOrder.GroupBox6.Visible = Видимость
        BuildOrder.Label2.Visible = Видимость
        BuildOrder.Label14.Visible = False

        BuildOrder.Утверждает.Visible = Видимость
        BuildOrder.УтверждаетДолжность.Visible = False

    End Sub

    Sub ПроектВносит(Видимость As Boolean, Optional Название As String = "Без изменений")

        If Название = "Без изменений" Then
        Else
            BuildOrder.Label5.Text = Название
        End If

        BuildOrder.GroupBox1.Visible = Видимость
        BuildOrder.Label5.Visible = Видимость
        BuildOrder.Label6.Visible = False

        BuildOrder.ПроектВносит.Visible = Видимость
        BuildOrder.ПроектВноситДолжность.Visible = False

    End Sub

    Sub Исполнитель(Видимость As Boolean, Optional Название As String = "Без изменений")

        If Название = "Без изменений" Then
        Else
            BuildOrder.Label7.Text = Название
        End If

        BuildOrder.GroupBox2.Visible = Видимость
        BuildOrder.Label7.Visible = Видимость
        BuildOrder.Label8.Visible = False

        BuildOrder.Исполнитель.Visible = Видимость
        BuildOrder.ИсполнительДолжность.Visible = False

    End Sub

    Sub Согласовано1(Видимость As Boolean, Optional Название As String = "Без изменений")

        If Название = "Без изменений" Then
            BuildOrder.Label9.Text = "Согласовано"
        Else
            BuildOrder.Label9.Text = Название
        End If
        BuildOrder.GroupBox3.Visible = Видимость
        BuildOrder.Label9.Visible = Видимость
        BuildOrder.Label10.Visible = False

        BuildOrder.Согласовано1.Visible = Видимость
        BuildOrder.Согласовано1Должность.Visible = False

    End Sub

    Sub Согласовано2(Видимость As Boolean)

        BuildOrder.GroupBox4.Visible = Видимость
        BuildOrder.Label11.Visible = Видимость
        BuildOrder.Label12.Visible = False

        BuildOrder.Согласовано2.Visible = Видимость
        BuildOrder.Согласовано2Должность.Visible = False

    End Sub

    Sub РуководительСтажировки(Видимость As Boolean, Optional ПодписьТекстБ As String = "Руководитель стажировки")

        BuildOrder.GroupBox7.Visible = Видимость
        BuildOrder.LabelРуководительСтажировки.Visible = Видимость
        BuildOrder.Label16.Visible = False

        BuildOrder.LabelРуководительСтажировки.Text = ПодписьТекстБ

        BuildOrder.РуководительСтажировки.Visible = Видимость
        BuildOrder.РуководительСтажировкиДолжность.Visible = False

    End Sub

    Sub Комиссия2(Видимость As Boolean, Optional ПодписьТекстБ As String = "Комиссия 2")

        BuildOrder.GroupBox8.Visible = Видимость
        BuildOrder.label20.Visible = Видимость
        BuildOrder.Label17.Visible = False

        BuildOrder.label20.Text = ПодписьТекстБ

        BuildOrder.Комиссия2.Visible = Видимость
        BuildOrder.Комиссия2Должность.Visible = False

    End Sub

    Sub Комиссия3(Видимость As Boolean, Optional ПодписьТекстБ As String = "Комиссия 3")

        BuildOrder.GroupBox9.Visible = Видимость
        BuildOrder.Label18.Visible = Видимость
        BuildOrder.Label19.Visible = False

        BuildOrder.Label18.Text = ПодписьТекстБ

        BuildOrder.Комиссия3.Visible = Видимость
        BuildOrder.Комиссия3Должность.Visible = False

    End Sub

    Sub СекретарьКомиссии(Видимость As Boolean, Optional ПодписьТекстБ As String = "Секретарь комиссии")

        BuildOrder.GroupBox10.Visible = Видимость
        BuildOrder.Label15.Visible = Видимость
        BuildOrder.Label21.Visible = False

        BuildOrder.Label15.Text = ПодписьТекстБ

        BuildOrder.СекретарьКомиссии.Visible = Видимость
        BuildOrder.СекретарьКомиссииДолжность.Visible = False

    End Sub

    Sub ЗаместительРПК(Видимость As Boolean, Optional ПодписьТекстБ As String = "Зам председателя комиссии")

        BuildOrder.GroupBox12.Visible = Видимость
        BuildOrder.Label22.Visible = Видимость
        BuildOrder.Label23.Visible = False

        BuildOrder.Label22.Text = ПодписьТекстБ

        BuildOrder.ЗамПредседателя.Visible = Видимость
        BuildOrder.ЗамПредседателяДолжность.Visible = False

    End Sub

    Sub местоНаФорме(номерНаФорме As Integer, лэйбл1 As Object, лэйбл2 As Object, бокс1 As Object, бокс2 As Object, ГруппБокс As Object)

        Dim координата0Х As Integer, координата0У As Integer

        координата0Х = 20
        координата0У = 60 + 40 * (номерНаФорме - 1)

        ГруппБокс.Location = New Point(координата0Х, координата0У)

        лэйбл1.Location = New Point(координата0Х + 1, координата0У + 19)
        лэйбл2.Location = New Point(координата0Х + 1, координата0У + 46)

        бокс1.Location = New Point(координата0Х + 240, координата0У + 19)
        бокс2.Location = New Point(координата0Х + 240, координата0У + 46)

        бокс1.TabIndex = номерНаФорме * 2 + 3
        бокс2.TabIndex = номерНаФорме * 2 + 4

    End Sub

    Sub местоНаФормеПослеДиректора(номерНаФорме As Integer, лэйбл1 As Object, лэйбл2 As Object, бокс1 As Object, бокс2 As Object, ГруппБокс As Object)

        Dim координата0Х As Integer, координата0У As Integer

        координата0Х = 20
        координата0У = 60 + 40 * (номерНаФорме)

        ГруппБокс.Location = New Point(координата0Х, координата0У)

        лэйбл1.Location = New Point(координата0Х + 1, координата0У + 19)
        лэйбл2.Location = New Point(координата0Х + 1, координата0У + 46)

        бокс1.Location = New Point(координата0Х + 240, координата0У + 19)
        бокс2.Location = New Point(координата0Х + 240, координата0У + 46)

        бокс1.TabIndex = номерНаФорме * 2 + 3
        бокс2.TabIndex = номерНаФорме * 2 + 4

    End Sub

    Private Sub redactor_full_name_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Sub НормальныйШрифт(контрол As Object)

        контрол.Font = New Font("Microsoft YaHei", 12.0F, FontStyle.Regular)

    End Sub
    Sub увеличитьШрифт(контрол As Object)

        контрол.Font = New Font("Microsoft YaHei", 14.0F, FontStyle.Regular)

    End Sub

    Private Sub directorName_Click(sender As Object, e As EventArgs)
        List.textboxName = Me.ActiveControl.Name
        List.currentFormName = Me.Name
        List.ShowDialog()

    End Sub

    Private Sub directorPosition_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name
        List.currentFormName = Name
        List.ShowDialog()

    End Sub

    Private Sub Согласовано1ДолжностьПУ_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name
        List.currentFormName = Name
        List.ShowDialog()

    End Sub

    Private Sub Согласовано2ДолжностьПУ_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name
        List.currentFormName = Name
        List.ShowDialog()

    End Sub

    Private Sub Согласовано1ПУ_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name
        List.currentFormName = Name
        List.ShowDialog()

    End Sub

    Private Sub Согласовано2ПУ_Click(sender As Object, e As EventArgs)

        List.textboxName = ActiveControl.Name
        List.currentFormName = Name
        List.ShowDialog()

    End Sub

    Sub inputField(onOff As Boolean, Optional x As Integer = 90, Optional heightText As Integer = 42)

        If Not onOff Then

            BuildOrder.ПрактическаяПодготовка.Text = ""
            BuildOrder.Label24.Text = "Практическая подготовка"
            BuildOrder.ПрактическаяПодготовка.Visible = False
            BuildOrder.Label24.Visible = False
            BuildOrder.ПрактическаяПодготовка.Multiline = False
            BuildOrder.ПрактическаяПодготовка.Location = New Point(260, 110)
            BuildOrder.Label24.Location = New Point(20, 110)
            BuildOrder.ПрактическаяПодготовка.Size = New Size(546, 20)

        Else

            BuildOrder.ПрактическаяПодготовка.Location = New Point(260, x)
            BuildOrder.Label24.Text = "приказ о зачислении"
            BuildOrder.Label24.Location = New Point(20, x)
            BuildOrder.ПрактическаяПодготовка.Visible = True
            BuildOrder.ПрактическаяПодготовка.Multiline = True
            BuildOrder.ПрактическаяПодготовка.Size = New Size(546, heightText)
            BuildOrder.Label24.Visible = True

        End If
    End Sub

    Private Sub Button2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = switchPageKey Then
            openNextPage(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = seitchPageKey_Inverse Then
            openPrevPage(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = switchPageKey Then
            e.IsInputKey = True
        End If

        If e.KeyCode = seitchPageKey_Inverse Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub programs__loadPrograms()

        programs__progrs_tbl.Parent = programs_tbl_parent
        programs__progrs_tbl.Dock = DockStyle.Fill
        programs__progrs_tbl.Visible = True
        programs__progrs_tbl.number_column = 2

        programs__progrs_tbl.flag_second_control_combo = True

        programs__progrs_tbl.program_on = True


        programs__progrs_tbl.queryString_load = program.program__loadPrograms()

        programs__progrs_tbl.width_column.Clear()
        programs__progrs_tbl.width_column.Add(0, 65)
        programs__progrs_tbl.width_column.Add(1, 10)
        programs__progrs_tbl.width_column.Add(2, 0)
        programs__progrs_tbl.width_column.Add(3, 20)


        programs__progrs_tbl.names.redactor_element_first = "Наименование"
        programs__progrs_tbl.names.db_element_first = "name"
        programs__progrs_tbl.names.redactor_element_second = "Часы"
        programs__progrs_tbl.names.db_element_second = "hours"
        programs__progrs_tbl.name_table = "program"

        program.program_loadHoursList()

        programs__progrs_tbl.comboBox_second_element.settings.item_list = program.struct_progs.list_hours

        programs__progrs_tbl.kod_number = 2
        programs__progrs_tbl.table_init()

    End Sub

    Private Sub programs__loadType()

        programs_type_tbl.Parent = programs__SplitContainerModulsType.Panel2
        programs_type_tbl.Dock = DockStyle.Fill
        programs_type_tbl.Visible = True
        programs_type_tbl.number_column = 1
        programs_type_tbl.kod_number = 2

        programs_type_tbl.type_progs_on = True
        programs_type_tbl.add_on = False

        If programs_type_tbl.width_column.Count = 0 Then

            programs_type_tbl.width_column.Add(0, 78)
            programs_type_tbl.width_column.Add(1, 20)
            programs_type_tbl.width_column.Add(2, 0)
            programs_type_tbl.width_column.Add(3, -1)

        End If

        programs_type_tbl.numberElementFirst = 1
        programs_type_tbl.numberElementSecond = 0

        programs_type_tbl.names.redactor_element_first = "Часы"
        programs_type_tbl.names.db_element_first = "hours"
        programs_type_tbl.name_table = "progs_type_hours"

        AddHandler programs_type_tbl.Enter, AddressOf programs__type_tbl_Enter
        AddHandler programs_type_tbl.Leave, AddressOf programs__type_tbl_Leave

        programs__tblTypeUpdateContent()

    End Sub

    Public Sub programs__tblTypeUpdateContent()

        programs_type_tbl.queryString_load = program.program__loadTypes()
        programs_type_tbl.table_init()
        programs_type_tbl.DataGridTablesResult.ClearSelection()

    End Sub

    Private Sub programs__type_tbl_Leave(sender As Object, e As EventArgs)

        modulInProgsIndicatorOn(False)
        programs_type_tbl.DataGridTablesResult.ClearSelection()

    End Sub

    Private Sub programs__type_tbl_Enter(sender As Object, e As EventArgs)

        modulInProgsIndicatorOn(True)
        dataGridModulsInProgram.ClearSelection()

    End Sub

    Private Sub ToolStripAddProg_Click(sender As Object, e As EventArgs) Handles ToolStripAddProg.Click

        If comboBoxProgramms.Text = "" Then
            Return
        End If

        programs__progrs_tbl.table_addDown()

    End Sub

    Private Sub ToolStripUpdate_Click(sender As Object, e As EventArgs)

        programms__SplitModulsInProg.SplitterDistance = 540

    End Sub

    Public Sub addModulInGroupSelect()
        addMidulInGroupp.Select()
    End Sub

    Public Sub ToolStripAddModul_Click(sender As Object, e As EventArgs) Handles ToolStripAddModul.Click

        If comboBoxProgramms.Text = "" Then
            Return
        End If

        programms__SplitContainerModuls.Panel2Collapsed = False
        programms__SplitContainerModuls.SplitterDistance = programms__SplitContainerModuls.Height * 2 / 3
        program.struct_progs.flag_update_modul = False

        newModAddName.Clear()
        newModAddHour.Clear()
        newModAddName.BackColor = Color.White
        newModAddHour.BackColor = Color.White

        newModAddName.Focus()

    End Sub

    Private Sub newProgramm_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub dataGridProgs_MouseEnter(sender As Object, e As EventArgs)
        program.struct_progs.flagProgTbl = True
    End Sub

    Private Sub dataGridProgs_MouseLeave(sender As Object, e As EventArgs)
        program.struct_progs.flagProgTbl = False
    End Sub

    Private Sub comboBoxProgramms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxProgramms.SelectedIndexChanged

        If comboBoxProgramms.Text = "" Then
            Return
        End If

        programs__loadTables()


    End Sub

    Private Sub programs__loadTables()


        program.uroven_cval = comboBoxProgramms.Text

        programs__loadPrograms()

        programs__loadModul()

        programs__loadModulsInProgramm()

        programs__loadType()

        programs__panelProgs.Visible = False
        programs__panelType.Visible = False

    End Sub

    Public Sub programs__loadModulsInProgramm()



        If IsNothing(programs__progrs_tbl.selected_row) Then

            Return

        End If

        If programs__progrs_tbl.selected_row = -1 Then

            programs__progrs_tbl.selected_row = 0

        End If

        If Convert.ToString(programs__progrs_tbl.DataGridTablesResult.Rows(programs__progrs_tbl.selected_row).Cells(0).Value).Trim = "" Then

            Return

        End If

        Try
            program.struct_progs.program_kod = Convert.ToString(programs__progrs_tbl.DataGridTablesResult.Rows(programs__progrs_tbl.selected_row).Cells(2).Value)
        Catch ex As Exception
            Return
        End Try

        program.program__loadModulAndHours()

        tbl_moduls_sum_hours.Text = program.struct_progs.sum_hours_programm

        dataGridModulsInProgram.DataSource = program.struct_progs.tbl_modulsInProgs

        programs__tblModulInProgramResize()

    End Sub

    Private Sub programs__tblModulInProgramResize()

        If dataGridModulsInProgram.Columns.Count < 3 Then

            Return

        End If

        dataGridModulsInProgram.Columns(0).Width = dataGridModulsInProgram.Width - 140
        dataGridModulsInProgram.Columns(1).Width = 70
        dataGridModulsInProgram.Columns(2).Width = 68

    End Sub

    Private Sub programs__loadModul()

        program.program__loadModul()
        DataGridAllModuls.DataSource = program.struct_progs.tbl_moduls
        programs__tblAllModulsResize()

    End Sub

    Private Sub programs__tblAllModulsResize()

        If DataGridAllModuls.Columns.Count < 3 Then

            Return

        End If

        DataGridAllModuls.Columns(0).Width = DataGridAllModuls.Width - 130
        DataGridAllModuls.Columns(1).Width = 70
        DataGridAllModuls.Columns(2).Width = 70

    End Sub

    Private Sub DataGridAllModuls_Resize(sender As Object, e As EventArgs) Handles DataGridAllModuls.Resize

        programs__tblAllModulsResize()

    End Sub

    Private Sub dataGridModuls_Resize(sender As Object, e As EventArgs) Handles dataGridModulsInProgram.Resize

        programs__tblModulInProgramResize()

    End Sub

    Private Sub ToolStripTop_Click(sender As Object, e As EventArgs) Handles ToolStripTop.Click

        dataGridModulsInProgram.Focus()

        If IsNothing(dataGridModulsInProgram.CurrentCell) Then
            Return
        End If
        Dim selectedRow As Int32
        selectedRow = dataGridModulsInProgram.CurrentCell.RowIndex
        If selectedRow < 1 Then
            Return
        End If

        program.program__updateMudulsTop(Convert.ToString(dataGridModulsInProgram.Rows(selectedRow).Cells(2).Value))

        programs__loadModulsInProgramm()

        If IsNothing(dataGridModulsInProgram.Rows(selectedRow - 1)) Then
            Return
        End If

        dataGridModulsInProgram.CurrentCell = dataGridModulsInProgram.Rows(selectedRow - 1).Cells(0)

    End Sub

    Private Sub ToolStripBottom_Click(sender As Object, e As EventArgs) Handles ToolStripBottom.Click
        dataGridModulsInProgram.Focus()
        Dim selectedRow As Int32
        If IsNothing(dataGridModulsInProgram.CurrentCell) Then
            Return
        End If
        selectedRow = dataGridModulsInProgram.CurrentCell.RowIndex
        If selectedRow >= dataGridModulsInProgram.Rows.Count - 1 Then
            Return
        End If

        program.program__updateMudulsBottom(Convert.ToString(dataGridModulsInProgram.Rows(selectedRow).Cells(2).Value))

        programs__loadModulsInProgramm()

        If IsNothing(dataGridModulsInProgram.Rows(selectedRow + 1)) Then
            Return
        End If

        dataGridModulsInProgram.CurrentCell = dataGridModulsInProgram.Rows(selectedRow + 1).Cells(0)

    End Sub

    Private Sub addMidulInGroupp_Click(sender As Object, e As EventArgs) Handles addMidulInGroupp.Click
        dataGridModulsInProgram.Focus()

        If IsNothing(DataGridAllModuls.CurrentCell) Then
            Return
        End If

        Dim selectedRow As Int32
        selectedRow = DataGridAllModuls.CurrentCell.RowIndex

        If Not (IsNumeric(DataGridAllModuls.Rows(selectedRow).Cells(2).Value)) Then
            Return
        End If
        program.program__updateMudulsInGroup(Convert.ToString(DataGridAllModuls.Rows(selectedRow).Cells(2).Value))

        programs__loadModulsInProgramm()

    End Sub

    Private Sub dataGridModuls_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridModulsInProgram.CellDoubleClick

        If dataGridModulsInProgram.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(dataGridModulsInProgram.Rows(0).Cells(0).Value) = "" Then
            Return
        End If

        Dim curNumber = dataGridModulsInProgram.CurrentCell.RowIndex

        red_moduls.Text = Convert.ToString(dataGridModulsInProgram.Rows(curNumber).Cells(1).Value)
        red_moduls.BackColor = Color.AliceBlue
        program.struct_progs.flag_update_modInProg = True
        program.struct_progs.name_current_modul = Convert.ToString(dataGridModulsInProgram.Rows(curNumber).Cells(0).Value)
        program.struct_progs.modul_kod = Convert.ToString(dataGridModulsInProgram.Rows(curNumber).Cells(2).Value)

        programms__SplitModulsInProg.Panel2Collapsed = False
        programms__SplitModulsInProg.SplitterDistance = programms__SplitModulsInProg.Height * 2 / 3
        red_moduls.Focus()

    End Sub

    Private Sub red_moduls_KeyDown(sender As Object, e As KeyEventArgs) Handles red_moduls.KeyDown

        If e.KeyValue = Keys.Enter Then

            Dim numberRow As String

            e.Handled = True
            e.SuppressKeyPress = True
            If red_moduls.Text = "" Then Return

            If Not IsNumeric(red_moduls.Text.Trim) Then
                Return
            End If

            If program.struct_progs.flag_update_modInProg Then
                program.program__updateModul(red_moduls.Text)
            End If

            programs__loadModulsInProgramm()

            numberRow = RedactorDataGrid.dataGridViewSearchRow(dataGridModulsInProgram.Rows, 2, program.struct_progs.modul_kod)
            dataGridModulsInProgram.CurrentCell = dataGridModulsInProgram.Rows(numberRow).Cells(0)
            dataGridModulsInProgram.Rows(numberRow).Cells(0).Selected = True

        ElseIf e.KeyValue = Keys.Escape Then

            If programms__SplitModulsInProg.Panel2Collapsed Then
                comboBoxProgramms.Focus()
                Return
            End If

            program.struct_progs.flagEscape = True
            program.struct_progs.flag_update_modInProg = False
            red_moduls.Clear()
            red_moduls.BackColor = Color.White
            programms__SplitModulsInProg.Panel2Collapsed = True
            dataGridModulsInProgram.Focus()

        End If

    End Sub

    Private Sub dataGridModuls_KeyDown(sender As Object, e As KeyEventArgs) Handles dataGridModulsInProgram.KeyDown

        If e.KeyValue = Keys.Tab Then

            toolStripModulsInProg.Focus()
            ToolStripTop.Select()
            e.Handled = True

        ElseIf e.KeyValue = Keys.Right Then

            toolStripModulsInProg.Focus()
            ToolStripTop.Select()
            e.Handled = True

        ElseIf e.KeyValue = Keys.Left Then

            programs__progrs_tbl.Focus()
            e.Handled = True

        ElseIf e.KeyValue = Keys.R Then

            Dim e1 As DataGridViewCellEventArgs

            dataGridModuls_CellDoubleClick(sender, e1)

        Else

            red_moduls_KeyDown(sender, e)

        End If


    End Sub

    Private Sub dataGridModuls_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles dataGridModulsInProgram.PreviewKeyDown

        If e.KeyValue = Keys.Delete Then

            Dim curNumber = dataGridModulsInProgram.CurrentCell.RowIndex
            program.struct_progs.modul_kod = Convert.ToString(dataGridModulsInProgram.Rows(curNumber).Cells(2).Value)

            program.program__deleteModul_prog()
            programs__loadModulsInProgramm()

            If (curNumber <> 0) Then
                dataGridModulsInProgram.CurrentCell = dataGridModulsInProgram.Rows(curNumber - 1).Cells(0)
            End If

        ElseIf e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If
    End Sub

    Private Sub red_moduls_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles red_moduls.PreviewKeyDown

        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If

    End Sub

    Public Sub SplitContainerProgs_Leave(sender As Object, e As EventArgs)

        progsIndicator.Image = iconsList.Images(8)
        program.struct_progs.flag_update = False
        program.struct_progs.flagEscape = True

    End Sub

    Public Sub SplitModulsInProg_Leave(sender As Object, e As EventArgs) Handles programms__SplitModulsInProg.Leave

        modulInProgsIndicatorOn(False)
        program.struct_progs.flagEscape = True
        programms__SplitModulsInProg.Panel2Collapsed = True
        red_moduls.Clear()
        red_moduls.BackColor = Color.White
        programs_type_tbl.DataGridTablesResult.ClearSelection()

    End Sub

    Private Sub modulInProgsIndicatorOn(val As Boolean)

        If val Then
            modulInProgsIndicator.Image = iconsList.Images(9)
        Else
            modulInProgsIndicator.Image = iconsList.Images(8)
        End If


    End Sub

    Private Sub newModAddName_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles newModAddName.PreviewKeyDown

        If e.KeyValue = Keys.Enter Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub newModAddHour_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles newModAddHour.PreviewKeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub newModAddName_KeyDown(sender As Object, e As KeyEventArgs) Handles newModAddName.KeyDown

        If e.KeyValue = Keys.Enter Then

            e.Handled = True
            e.SuppressKeyPress = True
            If newModAddName.Text.Trim = "" Or newModAddHour.Text.Trim = "" Then Return

            If Not program.struct_progs.flag_update_modul Then
                program.program__addNewModul(newModAddName.Text, newModAddHour.Text)
                programs__loadModul()
                program.struct_progs.modul_kod_inModuls = program.program__loadLastKodModul(newModAddName.Text)
            Else
                program.program__updateModuliNModuls(newModAddName.Text, newModAddHour.Text)
                programs__loadModul()
            End If

            Dim numberRow As String = RedactorDataGrid.dataGridViewSearchRow(DataGridAllModuls.Rows, 2, program.struct_progs.modul_kod_inModuls)
            DataGridAllModuls.CurrentCell = DataGridAllModuls.Rows(numberRow).Cells(0)
            DataGridAllModuls.Rows(numberRow).Cells(0).Selected = True

        End If

        If e.KeyValue = Keys.Escape Then

            program.struct_progs.flagEscape = True
            program.struct_progs.flag_update_modul = False

            newModAddName.Clear()
            newModAddHour.Clear()
            newModAddName.BackColor = Color.White
            newModAddHour.BackColor = Color.White

            programms__SplitContainerModuls.Panel2Collapsed = True
            DataGridAllModuls.Focus()

        End If

    End Sub

    Private Sub newModAddHour_KeyDown(sender As Object, e As KeyEventArgs) Handles newModAddHour.KeyDown

        If e.KeyValue = Keys.Enter Then
            Dim numberRow As String

            e.Handled = True
            e.SuppressKeyPress = True
            If newModAddName.Text.Trim = "" Or newModAddHour.Text.Trim = "" Then Return

            If Not program.struct_progs.flag_update_modul Then
                program.program__addNewModul(newModAddName.Text, newModAddHour.Text)
                programs__loadModul()
                program.struct_progs.modul_kod_inModuls = program.program__loadLastKodModul(newModAddName.Text)
            Else
                program.program__updateModuliNModuls(newModAddName.Text, newModAddHour.Text)
                programs__loadModul()
            End If

            numberRow = RedactorDataGrid.dataGridViewSearchRow(DataGridAllModuls.Rows, 2, program.struct_progs.modul_kod_inModuls)
            DataGridAllModuls.CurrentCell = DataGridAllModuls.Rows(numberRow).Cells(0)
            DataGridAllModuls.Rows(numberRow).Cells(0).Selected = True

        ElseIf e.KeyValue = Keys.Escape Then

            program.struct_progs.flagEscape = True
            program.struct_progs.flag_update_modul = False

            newModAddName.Clear()
            newModAddHour.Clear()
            newModAddName.BackColor = Color.White
            newModAddHour.BackColor = Color.White

            programms__SplitContainerModuls.Panel1.Focus()
            programms__SplitContainerModuls.Panel2Collapsed = True

        ElseIf e.KeyValue = Keys.Tab Then

            DataGridAllModuls.Focus()

        End If

    End Sub

    Public Sub DataGridAllModuls_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridAllModuls.CellDoubleClick

        If DataGridAllModuls.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(DataGridAllModuls.Rows(0).Cells(0).Value) = "" Then
            Return
        End If

        Dim curNumber = DataGridAllModuls.CurrentCell.RowIndex

        If Not IsNumeric(DataGridAllModuls.Rows(curNumber).Cells(2).Value) Then
            Return
        End If

        program.struct_progs.modul_kod_inModuls = Convert.ToString(DataGridAllModuls.Rows(curNumber).Cells(2).Value)

        newModAddName.Text = Convert.ToString(DataGridAllModuls.Rows(curNumber).Cells(0).Value)
        newModAddName.BackColor = Color.AliceBlue
        newModAddHour.Text = Convert.ToString(DataGridAllModuls.Rows(curNumber).Cells(1).Value)
        newModAddHour.BackColor = Color.AliceBlue

        program.struct_progs.flag_update_modul = True

        programms__SplitContainerModuls.Panel2Collapsed = False
        programms__SplitContainerModuls.SplitterDistance = programms__SplitContainerModuls.Height * 2 / 3
        newModAddName.Focus()

    End Sub

    Private Sub SplitContainerModuls_Leave(sender As Object, e As EventArgs) Handles programms__SplitContainerModuls.Leave
        modulIndicator.Image = iconsList.Images(8)
        program.struct_progs.flag_update_modul = False

        newModAddName.Clear()
        newModAddHour.Clear()
        newModAddName.BackColor = Color.White
        newModAddHour.BackColor = Color.White

        programms__SplitContainerModuls.Panel2Collapsed = True

    End Sub

    Private Sub SplitModulsInProg_KeyDown(sender As Object, e As KeyEventArgs) Handles programms__SplitModulsInProg.KeyDown

        red_moduls_KeyDown(sender, e)

    End Sub

    Private Sub DataGridAllModuls_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridAllModuls.PreviewKeyDown

        If e.KeyValue = Keys.Delete Then

            If DataGridAllModuls.Rows.Count < 0 Then
                Return
            End If

            Dim curNumber = DataGridAllModuls.CurrentCell.RowIndex

            If Not IsNumeric(DataGridAllModuls.Rows(curNumber).Cells(2).Value) Then
                Return
            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Удалить модуль: " + DataGridAllModuls.Rows(curNumber).Cells(0).Value + "?"
            ФормаДаНетУдалить.ShowDialog()

            If Not ФормаДаНетУдалить.НажатаКнопкаДа Then
                Return
            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

            program.program__deleteModul(DataGridAllModuls.Rows(curNumber).Cells(2).Value)
            programs__loadModul()
            programs__loadModulsInProgramm()

            If (curNumber <> 0) Then
                DataGridAllModuls.CurrentCell = DataGridAllModuls.Rows(curNumber - 1).Cells(0)
            End If

        ElseIf e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

        If password.Text = password0 Then
            programms__splitMainConteiner.Visible = True
            password.Visible = False
            comboBoxProgramms.Focus()
        End If

    End Sub

    Private Sub SplitContainerProgs_Enter(sender As Object, e As EventArgs)

        progsIndicator.Image = iconsList.Images(9)

    End Sub

    Private Sub SplitContainerModuls_Enter(sender As Object, e As EventArgs) Handles programms__SplitContainerModuls.Enter
        modulIndicator.Image = iconsList.Images(9)
    End Sub

    Private Sub SplitModulsInProg_Enter(sender As Object, e As EventArgs) Handles programms__SplitModulsInProg.Enter

        modulInProgsIndicatorOn(True)

    End Sub

    Private Sub passwordOther_TextChanged(sender As Object, e As EventArgs) Handles passwordOther.TextChanged

        If passwordOther.Text = password0 Then

            SplitContainerOther.Visible = True
            passwordOther.Visible = False
            ToolStrip_name_list.Focus()
            worker.loadLists()
            worker_dolgnost.Items.AddRange(worker.worker_struct.worker_dolj)
            worker_type.Items.AddRange(worker.worker_struct.worker_type_list)

            textBoxSignalOff()

        End If

    End Sub

    Private Sub textBoxSignalOff()
        For Each currentTBox As TextBox In panel_worker.Controls.OfType(Of TextBox)

            AddHandler currentTBox.Leave, Sub()
                                              worker.flagTextBox = False
                                          End Sub
            AddHandler currentTBox.Enter, Sub()
                                              worker.flagTextBox = True
                                          End Sub

        Next
    End Sub

    Private Sub ToolStrip_name_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStrip_name_list.SelectedIndexChanged

        If ToolStrip_name_list.Text = "" Then

            Return

        End If

        If ToolStrip_name_list.Text = "Преподаватели" Then

            tbl_education.Visible = False
            SplitContainerOtherList.Visible = True
            ToolStripButton1.Visible = True
            SplitContainerOtherList.Panel2Collapsed = True
            DataGridView_list.Visible = True
            loadTblWorker()

        ElseIf ToolStrip_name_list.Text = "Должности" Then

            SplitContainerOtherList.Visible = False
            ToolStripButton1.Visible = False
            connect_table_positions()

        ElseIf ToolStrip_name_list.Text = "Организации" Then

            SplitContainerOtherList.Visible = False
            ToolStripButton1.Visible = False
            connect_table_organization()

        ElseIf ToolStrip_name_list.Text = "Образование" Then

            SplitContainerOtherList.Visible = False
            ToolStripButton1.Visible = False
            connect_table_education()

        End If

    End Sub

    Private Sub connect_table_positions()

        tbl_education.Parent = Panel_main
        tbl_education.Visible = True
        tbl_education.Dock = DockStyle.Fill
        tbl_education.number_column = 1

        tbl_education.queryString_load = sqlQueryString.load_list_positions()

        tbl_education.width_column.Clear()

        tbl_education.width_column.Add(0, 100)
        tbl_education.width_column.Add(1, 0)
        tbl_education.width_column.Add(2, -1)
        tbl_education.width_column.Add(3, -1)


        tbl_education.names.redactor_element_first = "Наименование"
        tbl_education.names.db_element_first = "name"
        tbl_education.name_table = "position"

        tbl_education.kod_number = 1

        tbl_education.table_init()

    End Sub

    Private Sub connect_table_education()

        tbl_education.Parent = Panel_main
        tbl_education.Visible = True
        tbl_education.Dock = DockStyle.Fill
        tbl_education.number_column = 1

        tbl_education.queryString_load =
            "SELECT
                  name AS 'Вид документа',
                  kod
                FROM doo_doc_type
                ORDER BY name"

        tbl_education.width_column.Clear()

        tbl_education.width_column.Add(0, 100)
        tbl_education.width_column.Add(1, 0)
        tbl_education.width_column.Add(2, -1)
        tbl_education.width_column.Add(3, -1)

        tbl_education.names.redactor_element_first = "Наименование"
        tbl_education.names.db_element_first = "name"
        tbl_education.name_table = "doo_doc_type"

        tbl_education.kod_number = 1

        tbl_education.table_init()

    End Sub

    Private Sub connect_table_organization()

        tbl_education.Parent = Panel_main
        tbl_education.Visible = True
        tbl_education.Dock = DockStyle.Fill
        tbl_education.number_column = 2

        tbl_education.queryString_load = sqlQueryString.load_list_organization()

        tbl_education.width_column.Clear()

        tbl_education.width_column.Add(0, 30)
        tbl_education.width_column.Add(1, 69)
        tbl_education.width_column.Add(2, 0)
        tbl_education.width_column.Add(3, -1)

        tbl_education.names.redactor_element_first = "Наименование"
        tbl_education.names.redactor_element_second = "Полное наименование"
        tbl_education.names.db_element_first = "name"
        tbl_education.names.db_element_second = "full_name"
        tbl_education.name_table = "napr_organization"

        tbl_education.kod_number = 2

        tbl_education.table_init()

    End Sub


    Public Sub loadTblWorker()

        worker.loadWorker()

        DataGridView_list.Rows.Clear()

        Dim count As Integer = 0
        For Each row As List(Of String) In worker.listWorkers

            count = DataGridView_list.Rows.Add()
            DataGridView_list.Rows(count).Cells(0).Value = Convert.ToBoolean(row(0))
            DataGridView_list.Rows(count).Cells(1).Value = row(1)
            DataGridView_list.Rows(count).Cells(2).Value = row(2)
            DataGridView_list.Rows(count).Cells(3).Value = row(3)
            DataGridView_list.Rows(count).Cells(4).Value = row(4)
            DataGridView_list.Rows(count).Cells(5).Value = row(5)
            DataGridView_list.Rows(count).Cells(6).Value = row(6)

        Next

        DataGridView_list.Columns(0).Width = 40
        DataGridView_list.Columns(1).Width = 200
        DataGridView_list.Columns(2).Width = 300
        DataGridView_list.Columns(3).Width = 300
        DataGridView_list.Columns(5).Width = 100
        DataGridView_list.Columns(4).Width = DataGridView_list.Width - DataGridView_list.Columns(0).Width -
        DataGridView_list.Columns(1).Width - DataGridView_list.Columns(2).Width - DataGridView_list.Columns(3).Width - DataGridView_list.Columns(5).Width
        DataGridView_list.Columns(6).Visible = False

    End Sub

    Private Sub other_add_Click(sender As Object, e As EventArgs) Handles other_add.Click

        If DataGridView_list.Visible Then

            redactorOpen(sender, e)

        ElseIf tbl_education.Visible Then

            tbl_education.builder.redactorOpen()
            SplitContainerOtherList.Panel2Collapsed = True

        End If

    End Sub

    Private Sub redactorOpen(sender As Object, e As EventArgs)

        If ToolStrip_name_list.Text = "" Then

            Return

        ElseIf ToolStrip_name_list.Text = "Преподаватели" Then

            SplitContainerOtherList.Panel2Collapsed = False
            SplitContainerOtherList.SplitterDistance = SplitContainerOtherList.Height - 205
            ButtonFK.Focus()
            formEvents.clear_panel_worker(sender, e)
            ActiveControl = ButtonFK

        End If

    End Sub

    Private Sub worker_DeleteDown(sender, e)

        Dim curNumber = DataGridView_list.CurrentCell.RowIndex
        ФормаДаНетУдалить.текстДаНет.Text = "Удалить " + DataGridView_list.Rows(curNumber).Cells(1).Value + "?"
        ФормаДаНетУдалить.ShowDialog()

        If Not ФормаДаНетУдалить.НажатаКнопкаДа Then
            Return
        End If

        ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

        worker.worker_struct.kod = Convert.ToInt64(DataGridView_list.Rows(curNumber).Cells(6).Value)

        If Not worker.removeWorker() Then
            Warning.TextBox.Visible = False
            Warning.content.Visible = True
            Warning.content.Text = "Сотрудник не может быть удален"
            Warning.ShowDialog()
            Return
        End If

        If worker_name.Text.Trim = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(1).Value) Then
            SendKeys.Send("{ESC}")
        End If

        ToolStrip_name_list_SelectedIndexChanged(sender, e)

        If (curNumber <> 0) Then
            DataGridView_list.CurrentCell = DataGridView_list.Rows(curNumber - 1).Cells(0)
        End If

        BuildOrder.reload_lists()

    End Sub

    Private Sub DataGridView_list_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView_list.KeyDown

        If e.KeyValue = Keys.Delete Then

            worker_DeleteDown(sender, e)

        ElseIf e.KeyValue = Keys.Add Then

            If Not ToolStrip_name_list.Text.Trim = "" Then
                other_add_Click(sender, e)
            End If

        ElseIf e.KeyValue = Keys.R Then

            If Not ToolStrip_name_list.Text.Trim = "" Then

                Dim e1 As DataGridViewCellEventArgs
                DataGridView_list_CellDoubleClick(sender, e1)

            End If

        ElseIf e.KeyValue = Keys.Tab Then

            If SplitContainerOtherList.Panel2Collapsed Then

                ToolStrip_name_list.Focus()
                e.Handled = True

            Else

                panel_worker.Select()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Enter Then

            If Not DataGridView_list.ReadOnly Then

                If DataGridView_list.RowCount < 1 Then

                    Return

                ElseIf DataGridView_list.SelectedRows.Count < 1 Then

                    Return

                ElseIf DataGridView_list.SelectedRows(0).Cells(1).Value.Trim = "" Then

                    Return

                End If

                DataGridView_list.SelectedRows(0).Cells(0).Value = Not DataGridView_list.SelectedRows(0).Cells(0).Value

            End If

        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If DataGridView_list.ReadOnly Then

            DataGridView_list.ReadOnly = False
            ToolStripButton1.Image = icons40pxList.Images(3)
            worker.flagRedactor = True
            ActiveControl = DataGridView_list

        Else

            DataGridView_list.ReadOnly = True
            ToolStripButton1.Image = icons40pxList.Images(2)
            worker.flagRedactor = False
            ActiveControl = DataGridView_list

        End If

    End Sub

    Private Sub DataGridView_list_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_list.CellEndEdit
        If e.ColumnIndex = 0 Then
            If worker.flagRedactor Then
                worker.worker_struct.kod = Convert.ToInt64(DataGridView_list.Rows(e.RowIndex).Cells(6).Value)
                worker.worker_struct.worker_check = Convert.ToInt16(DataGridView_list.Rows(e.RowIndex).Cells(0).Value)
                worker.update_status_list()
            End If
        End If
    End Sub

    Private Sub DataGridView_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_list.CellDoubleClick

        If DataGridView_list.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(DataGridView_list.Rows(0).Cells(0).Value) = "" Then
            Return
        End If

        Dim curNumber = DataGridView_list.CurrentCell.RowIndex

        If IsNumeric(DataGridView_list.Rows(curNumber).Cells(6).Value) Then
            worker.worker_struct.kod = Convert.ToInt64(DataGridView_list.Rows(curNumber).Cells(6).Value)
        Else
            Return
        End If

        SplitContainerOtherList.Panel2Collapsed = False

        redactorOpen(sender, e)

        worker_name.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(1).Value)
        worker_name.BackColor = Color.AliceBlue
        formEvents.worker_name_Leave(sender, e)
        worker_name_full.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(2).Value)
        worker_name_full.BackColor = Color.AliceBlue
        formEvents.worker_name_full_Leave(sender, e)
        worker_name_pad.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(3).Value)
        worker_name_pad.BackColor = Color.AliceBlue
        formEvents.worker_name_pad_Leave(sender, e)
        worker_dolgnost.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(4).Value)
        worker_type.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(5).Value)

        worker.flagUpdate = True
        ButtonFK.Focus()

    End Sub

    Private Sub worker_name_TextChanged(sender As Object, e As EventArgs) Handles worker_name.TextChanged
        If Not worker_name.Text.Trim = "ФИО" Then
            worker_name.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_full_TextChanged(sender As Object, e As EventArgs) Handles worker_name_full.TextChanged
        If Not worker_name_full.Text.Trim = "Фамилия Имя Отчество" Then
            worker_name_full.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_pad_TextChanged(sender As Object, e As EventArgs) Handles worker_name_pad.TextChanged
        If Not worker_name_pad.Text.Trim = "Фамилия Имя Отчество РП" Then
            worker_name_pad.ForeColor = Color.Black
        End If
    End Sub

    Private Sub passwrdSetts_TextChanged(sender As Object, e As EventArgs) Handles passwrdSetts.TextChanged

        If passwrdSetts.Text = password0 Then
            panelSetts.Visible = True
            passwrdSetts.Visible = False
        End If

    End Sub

    Private Sub DataGridAllModuls_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridAllModuls.KeyDown

        If e.KeyValue = Keys.Tab Then

            comboBoxProgramms.Focus()
            e.Handled = True

        ElseIf e.KeyValue = Keys.Add Then

            If Not comboBoxProgramms.Text.Trim = "" Then

                ToolStripAddModul_Click(sender, e)

            End If

        ElseIf e.KeyValue = Keys.Left Then

            toolStripModulsInProg.Focus()
            addMidulInGroupp.Select()

        ElseIf e.KeyValue = Keys.R Then

            Dim e1 As DataGridViewCellEventArgs

            DataGridAllModuls_CellDoubleClick(sender, e1)

        End If

    End Sub

    Private Sub program_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles toolStripProgram.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub program_KeyDown(sender As Object, e As KeyEventArgs) Handles toolStripProgram.KeyDown

        If e.KeyValue = Keys.Tab Then

            If comboBoxProgramms.Text = "" Then
                comboBoxProgramms.Focus()
                Return
            End If

            ActiveControl = programs__progrs_tbl
            e.Handled = True

        End If

    End Sub

    Private Sub comboBoxProgramms_Enter(sender As Object, e As EventArgs) Handles comboBoxProgramms.Enter

        comboBoxProgramms.DroppedDown = True

    End Sub

    Private Sub comboBoxProgramms_Leave(sender As Object, e As EventArgs) Handles comboBoxProgramms.Leave

        comboBoxProgramms.DroppedDown = False

    End Sub

    Private Sub modulsInProg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles toolStripModulsInProg.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If


    End Sub

    Private Sub modulsInProg_KeyDown(sender As Object, e As KeyEventArgs) Handles toolStripModulsInProg.KeyDown

        If e.KeyValue = Keys.Tab Then

            ActiveControl = DataGridAllModuls
            e.Handled = True

        ElseIf e.KeyValue = Keys.Left Then

            ActiveControl = dataGridModulsInProgram
            e.Handled = True

        ElseIf e.KeyValue = Keys.Right Then

            ActiveControl = DataGridAllModuls
            e.Handled = True

        End If

    End Sub

    Private Sub ToolStrip_name_list_Enter(sender As Object, e As EventArgs) Handles ToolStrip_name_list.Enter

        If flag_ToolStrip_name_list Then
            ToolStrip_name_list.DroppedDown = False
        Else
            ToolStrip_name_list.DroppedDown = True
        End If

    End Sub

    Private Sub ToolStrip_name_list_Leave(sender As Object, e As EventArgs) Handles ToolStrip_name_list.Leave

        ToolStrip_name_list.DroppedDown = False

    End Sub

    Private Sub ToolStrip1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ToolStrip1.PreviewKeyDown
        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If
    End Sub

    Private Sub DataGridDoljnost_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub ToolStrip1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStrip1.KeyDown

        If e.KeyValue = Keys.Tab Then

            If tbl_education.Visible Then

                ActiveControl = tbl_education

            ElseIf DataGridView_list.Visible Then

                ActiveControl = DataGridView_list
                e.Handled = True
            End If

        End If

    End Sub

    Private Sub DataGridView_list_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridView_list.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub worker_dolgnost_Enter(sender As Object, e As EventArgs) Handles worker_dolgnost.Enter

        If flag_worker_dolgnost Then
            worker_dolgnost.DroppedDown = False
        Else
            worker_dolgnost.DroppedDown = True
        End If

    End Sub

    Private Sub worker_dolgnost_Leave(sender As Object, e As EventArgs) Handles worker_dolgnost.Leave

        worker_dolgnost.DroppedDown = False

    End Sub

    Private Sub worker_type_Enter(sender As Object, e As EventArgs) Handles worker_type.Enter

        If flag_worker_type Then
            worker_type.DroppedDown = False
        Else
            worker_type.DroppedDown = True
        End If

    End Sub

    Private Sub worker_type_Leave(sender As Object, e As EventArgs) Handles worker_type.Leave

        worker_type.DroppedDown = False

    End Sub

    Private Sub ToolStrip_name_list_MouseMove(sender As Object, e As MouseEventArgs) Handles ToolStrip_name_list.MouseMove

        flag_ToolStrip_name_list = True

    End Sub

    Private Sub ToolStrip_name_list_MouseLeave(sender As Object, e As EventArgs) Handles ToolStrip_name_list.MouseLeave

        flag_ToolStrip_name_list = False

    End Sub

    Private Sub worker_dolgnost_MouseMove(sender As Object, e As MouseEventArgs) Handles worker_dolgnost.MouseMove

        flag_worker_dolgnost = True

    End Sub

    Private Sub worker_dolgnost_MouseLeave(sender As Object, e As EventArgs) Handles worker_dolgnost.MouseLeave

        flag_worker_dolgnost = False

    End Sub

    Private Sub worker_type_MouseMove(sender As Object, e As MouseEventArgs) Handles worker_type.MouseMove

        flag_worker_type = True

    End Sub

    Private Sub worker_type_MouseLeave(sender As Object, e As EventArgs) Handles worker_type.MouseLeave

        flag_worker_type = False

    End Sub

    Private Sub SplitContainerOtherList_Enter(sender As Object, e As EventArgs) Handles SplitContainerOtherList.Enter

        redactor_enter = True

    End Sub

    Private Sub SplitContainerOtherList_Leave(sender As Object, e As EventArgs) Handles SplitContainerOtherList.Leave

        redactor_enter = False

    End Sub

    Private Sub worker_name_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_name.KeyDown

        redactor_worker_activator(sender, e)

    End Sub

    Private Sub worker_name_full_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_name_full.KeyDown

        redactor_worker_activator(sender, e)

    End Sub

    Private Sub worker_name_pad_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_name_pad.KeyDown

        redactor_worker_activator(sender, e)

    End Sub

    Private Sub worker_dolgnost_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_dolgnost.KeyDown

        If Not worker_dolgnost.DroppedDown Then

            redactor_worker_activator(sender, e)

        End If

    End Sub

    Private Sub worker_type_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_type.KeyDown

        If Not worker_type.DroppedDown Then

            redactor_worker_activator(sender, e)

        End If

    End Sub

    Sub redactor_worker_activator(control As Control, e As KeyEventArgs)

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then

            Dim index As Integer = control.TabIndex
            Dim flag_ok As Boolean = False

            For Each element As Control In panel_worker.Controls

                If element.GetType.ToString <> "System.Windows.Forms.TextBox" And element.GetType.ToString <> "System.Windows.Forms.ComboBox" Then

                    Continue For

                End If

                If e.KeyCode = Keys.Down Then

                    If element.TabIndex = index + 1 And element.Name <> "spravka" Then

                        ActiveControl = element
                        element.Select()
                        element.Focus()
                        flag_ok = True
                        Exit For

                    End If

                Else

                    If element.TabIndex = index - 1 And element.Name <> "spravka" Then

                        ActiveControl = element
                        flag_ok = True
                        Exit For

                    End If

                End If

            Next

            If Not flag_ok Then

                ActiveControl = DataGridView_list

            End If

            e.Handled = True

        End If

    End Sub

    Private Sub dataGridModuls_Enter(sender As Object, e As EventArgs) Handles dataGridModulsInProgram.Enter

        If Not IsNothing(dataGridModulsInProgram.CurrentCell) Then

            dataGridModulsInProgram.CurrentCell.Selected = True

        End If

    End Sub

    Private Sub DataGridAllModuls_Enter(sender As Object, e As EventArgs) Handles DataGridAllModuls.Enter

        DataGridAllModuls.CurrentCell.Selected = True

    End Sub

    Private Sub comboBoxProgramms_KeyDown(sender As Object, e As KeyEventArgs) Handles comboBoxProgramms.KeyDown

    End Sub
End Class