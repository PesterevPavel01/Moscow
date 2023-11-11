
Public Class MainForm_events

    Public mainForm As MainForm
    Public book As New Book
    Public bookFRDO As New BookFRDO
    Private initializationСompleted As Boolean = False
    Private button As Button
    Public order As New Order

    Public mySQLConnector As New MySQLConnect
    Private dictionaryFlags = New Dictionary(Of String, Boolean)
    Private threadFlags = New Dictionary(Of String, Boolean)

    Public Sub init()

        If initializationСompleted Then Return
        initializationСompleted = True

        AddHandler mainForm.FormClosing, Sub(sender As Object, e As FormClosingEventArgs)
                                             checkThread(e)
                                         End Sub

        AddHandler mainForm.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)
                MainForm_PreviewKeyDown(sender, e)
            End Sub

        AddHandler mainForm.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                MainForm_KeyDown(sender, e)
            End Sub

        controlClick_event()

        controlKeyDown_event()

        controlKeyPress_event()

        controlPrev_PreviewKeyDown_event()

        controlEnter()

        comboBox_event()

        AddHandler mainForm.TabControlOther.SelectedIndexChanged,
            Sub(sender As Object, e As EventArgs)
                tabPageActivate()
            End Sub


        AddHandler mainForm.worker_name.Leave,
            Sub(sender As Object, e As EventArgs)
                worker_name_Leave(sender, e)
            End Sub

        AddHandler mainForm.worker_name.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)
                worker_name_PreviewKeyDown(sender, e)
            End Sub

        AddHandler mainForm.worker_name_full.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)
                worker_name_full_PreviewKeyDown(sender, e)
            End Sub

        AddHandler mainForm.worker_name_pad.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)
                worker_name_pad_PreviewKeyDown(sender, e)
            End Sub

        AddHandler mainForm.worker_name.Enter,
            Sub(sender As Object, e As EventArgs)
                worker_name_Enter(sender, e)
            End Sub

        AddHandler mainForm.worker_name_full.Enter,
            Sub(sender As Object, e As EventArgs)
                worker_name_full_Enter(sender, e)
            End Sub

        AddHandler mainForm.worker_name_full.Leave,
            Sub(sender As Object, e As EventArgs)
                worker_name_full_Leave(sender, e)
            End Sub

        AddHandler mainForm.worker_name_pad.Enter,
            Sub(sender As Object, e As EventArgs)
                worker_name_pad_Enter(sender, e)
            End Sub

        AddHandler mainForm.worker_name_pad.Leave,
            Sub(sender As Object, e As EventArgs)
                worker_name_pad_Leave(sender, e)
            End Sub

        BuildOrder.orderArgument.threadFlags = threadFlags
        book.threadFlags = threadFlags
        bookFRDO.threadFlags = threadFlags
        Report.threadFlags = threadFlags

    End Sub

    Private Sub checkThread(e As FormClosingEventArgs)

        Try
            For Each flag As KeyValuePair(Of String, Boolean) In threadFlags
                If flag.Value Then
                    MsgBox("Дождитесь завершения всех задач", 12, "Внимание")
                    e.Cancel = True
                    Return
                End If
            Next
        Catch ex As Exception
            e.Cancel = True
        End Try


    End Sub

    Private Sub comboBox_event()

        For Each control As KeyValuePair(Of Short, Control) In mainFormBuilder.controls

            If Not control.Value.GetType.ToString = "System.Windows.Forms.ComboBox" Then Continue For

            Dim currentCBox As ComboBox
            currentCBox = control.Value

            AddHandler currentCBox.SelectedIndexChanged, Sub(sender As Object, e As EventArgs)
                                                             comboBox_SelectedIndexChanged(sender, e)
                                                         End Sub

            AddHandler currentCBox.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                       If e.KeyCode = Keys.Enter Then
                                                           If Not currentCBox.DroppedDown Then
                                                               dictionaryFlags(currentCBox.Name) = True
                                                               e.IsInputKey = True
                                                           Else
                                                               dictionaryFlags(currentCBox.Name) = False
                                                           End If
                                                       End If
                                                   End Sub

            AddHandler currentCBox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                                 If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                                                     If dictionaryFlags(currentCBox.Name) Then
                                                         currentCBox.DroppedDown = Not currentCBox.DroppedDown
                                                         e.Handled = True
                                                         dictionaryFlags(currentCBox.Name) = False
                                                     End If
                                                 End If
                                             End Sub


        Next

    End Sub

    Private Sub tabPageActivate()

        If mainForm.TabControlOther.SelectedIndex = 6 Then
            mainForm.ToolStrip1.Focus()
            mainForm.ToolStrip_name_list.Focus()
            Return
        End If

        If mainForm.TabControlOther.SelectedIndex = 3 Then
            mainForm.ActiveControl = startApp.mainFormBuilder.controls(startApp.mainFormBuilder.controlNames("managerReport"))
            Return
        End If

        For Each control As KeyValuePair(Of Short, Short) In mainFormBuilder.parentPage

            If control.Value = mainForm.TabControlOther.SelectedIndex Then
                mainFormBuilder.controls(control.Key).Focus()
                Return
            End If

        Next

    End Sub

    Private Sub controlClick_event()

        For Each control As KeyValuePair(Of Short, Control) In mainFormBuilder.controls

            If control.Value.GetType.ToString = "System.Windows.Forms.DateTimePicker" Or control.Value.GetType.ToString = "System.Windows.Forms.ComboBox" Then Continue For

            AddHandler control.Value.Click,
                Sub(sender As Object, e As EventArgs)
                    controlClick(control.Value.Name, sender, e)
                End Sub
        Next

    End Sub

    Private Sub controlEnter()

        For Each control As KeyValuePair(Of Short, Control) In mainFormBuilder.controls

            If control.Value.GetType.ToString = "System.Windows.Forms.DateTimePicker" Or control.Value.GetType.ToString = "System.Windows.Forms.ComboBox" Then Continue For

            AddHandler control.Value.Enter,
                Sub(sender As Object, e As EventArgs)
                    control.Value.Font = New Font("Microsoft YaHei", 14)
                End Sub

            AddHandler control.Value.Leave,
                Sub(sender As Object, e As EventArgs)
                    control.Value.Font = New Font("Microsoft YaHei", 12)
                End Sub
        Next

    End Sub

    Private Sub comboBox_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim queryString As String = ""

        Select Case sender.name

            Case "students_defaultSearchSetts"

                queryString = updateSettings("ПоискСлушателейПоУм", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)
                If sender.Text <> "" Then
                    НастройкаПоискаСлушателей.checkedAnyValue(sender.Text)
                End If

            Case "group_dafaultSearchSetts"

                queryString = updateSettings("ПоискГруппПоУм", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

                If sender.Text <> "" Then
                    Group__serchSettings.checkedAnyValue(sender.Text)
                End If

            Case "students_defaultSortSetts"

                queryString = updateSettings("НастройкаСортировкиСлушателей", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)
                If sender.Text <> "" Then
                    sortSettsStudents.checkedAnyValue(sender.Text)
                End If

            Case "group_defaultSortSetts"

                queryString = updateSettings("НастройкаСортировкиГрупп", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

                If sender.Text <> "" Then
                    sortSettsGroup.checkedAnyValue(sender.Text)
                End If

            Case "maxNumberRows"

                queryString = updateSettings("КоличествоСтрокВТаблице", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

            Case "directorName"

                queryString = updateSettings("ДиректорФИО", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

            Case "directorPosition"

                queryString = updateSettings("ДиректорДолжность", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

            Case "Согласовано1ПУ"

                queryString = updateSettings("Согласовано1ПУ", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

            Case "Согласовано1ДолжностьПУ"

                queryString = updateSettings("Согласовано1ДолжностьПУ", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

            Case "Согласовано2ПУ"

                queryString = updateSettings("Согласовано2ПУ", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

            Case "Согласовано2ДолжностьПУ"

                queryString = updateSettings("Согласовано2ДолжностьПУ", sender.Text)
                mySQLConnector.sendQuery(queryString, 1)

        End Select

    End Sub

    Private Sub controlKeyDown_event()

        For Each control As KeyValuePair(Of Short, Control) In mainFormBuilder.controls

            AddHandler control.Value.KeyDown,
                Sub(sender As Object, e As KeyEventArgs)
                    controlKeyDown(control.Value.Name, sender, e)
                End Sub
        Next

    End Sub

    Private Sub controlKeyPress_event()

        For Each button As KeyValuePair(Of Short, Control) In mainFormBuilder.controls
            AddHandler button.Value.KeyPress,
                Sub(sender As Object, e As KeyPressEventArgs)
                    buttonKeyPress(button.Value.Name, sender, e)
                End Sub
        Next

    End Sub

    Private Sub controlPrev_PreviewKeyDown_event()
        For Each control As KeyValuePair(Of Short, Control) In mainFormBuilder.controls
            AddHandler control.Value.PreviewKeyDown,
                Sub(sender As Object, e As PreviewKeyDownEventArgs)
                    controlPreviewKeyDown(control.Value.Name, sender, e)
                End Sub
        Next
    End Sub

    Private Sub controlPreviewKeyDown(controlName As String, sender As Object, e As PreviewKeyDownEventArgs)

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

            Case mainForm.switchPageKey

                e.IsInputKey = True

            Case mainForm.seitchPageKey_Inverse

                e.IsInputKey = True

        End Select

    End Sub

    Private Sub controlKeyDown(controlName As String, sender As Object, e As KeyEventArgs)

        Select Case e.KeyValue

            Case Keys.Enter

                If sender.GetType.ToString = "System.Windows.Forms.Button" Then
                    controlClick(controlName, sender, e)
                ElseIf sender.GetType.ToString = "System.Windows.Forms.CheckBox" Then
                    checkedChange(sender, e.KeyValue)
                End If
                e.Handled = True

            Case Keys.Up

                If sender.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                    Dim comboBox As ComboBox
                    comboBox = sender
                    If comboBox.DroppedDown Then
                        Return
                    End If
                End If
                mainFormBuilder.prevControl(mainFormBuilder.controlNames(controlName)).Focus()
                e.Handled = True

            Case Keys.Down

                If sender.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                    Dim comboBox As ComboBox
                    comboBox = sender
                    If comboBox.DroppedDown Then
                        Return
                    End If
                End If
                mainFormBuilder.nextControl(mainFormBuilder.controlNames(controlName)).Focus()
                e.Handled = True

        End Select

    End Sub

    Private Sub buttonKeyPress(buttonName As String, sender As Object, e As KeyPressEventArgs)

        If sender.GetType.ToString = "System.Windows.Forms.DateTimePicker" Then Return

        If e.KeyChar = Convert.ToChar(mainForm.switchPageKey) Then

            openNextPage(mainFormBuilder.nextControl(mainFormBuilder.controlNames(buttonName)))
            e.Handled = True

        End If

        If e.KeyChar = Convert.ToChar(mainForm.seitchPageKey_Inverse) Then

            openPrevPage(mainFormBuilder.prevControl(mainFormBuilder.controlNames(buttonName)))
            e.Handled = True

        End If

    End Sub

    Private Sub controlClick(controlName As String, sender As Object, e As EventArgs)

        Select Case controlName

            Case "openGroupListPK"
                openGroupListPK(sender, e)
            Case "openGroupListPP"
                openGroupListPP(sender, e)
            Case "openGroupListPO"
                openGroupListPO(sender, e)
            Case "addGroup"
                createGroup_Click(sender, e)
            Case "studentsList"
                openStudentList(sender, e)
            Case "addStudent"
                addStudent(sender, e)
            Case "grades"
                openGgrades(sender, e)
            Case "gradesIA"
                openGgradesIA(sender, e)
            Case "workerReport"
                openWorkerReport(sender, e)
            Case "enrollmentPK"
                order.createEnrollmentPK(sender, e)
            Case "enrollmentPK_pl"
                order.createEnrollmentPK_pl(sender, e)
            Case "expulsionPK"
                order.createExpulsionPK(sender, e)
            Case "endingPK"
                order.createEndingPK(sender, e)
            Case "endingUdPK"
                order.createEndingUdPK(sender, e)
            Case "enrollmentPP"
                order.createEnrollmentPP(sender, e)
            Case "practicalPP"
                order.createPracticalPP(sender, e)
            Case "finalExaminationPP"
                order.createFinalExaminationPP(sender, e)
            Case "endingPP"
                order.createEndingPP(sender, e)
            Case "enrollmentPO"
                order.createEnrollmentPO(sender, e)
            Case "practicalPO"
                order.createPracticalPO(sender, e)
            Case "finalExaminationPO"
                order.createFinalExaminationPO(sender, e)
            Case "endingPO"
                order.createEndingPO(sender, e)
            Case "diplomaSupplement"
                order.createDiplomaSupplement(sender, e)
            Case "certificate"
                order.createCertificate(sender, e)
            Case "statementPK"
                order.createStatementPK(sender, e)
            Case "statementPP"
                order.createStatementPP(sender, e)
            Case "studentInformation"
                order.createStudentInformation(sender, e)
            Case "studentAndOrganization"
                order.createStudentAndOrganization(sender, e)
            Case "getAllBlank"
                order.getAllBlank(sender, e)
            Case "getSomeBlank"
                order.getAllBlank(sender, e)
            Case "gradesIinterAPO"
                order.createGradesIinterAPO(sender, e)
            Case "gradesIinterAPP"
                order.createGradesIinterAPP(sender, e)
            Case "certificateStudy"
                order.createCertificateStudy(sender, e)
            Case "certificateStudyOut"
                order.createCertificateStudyOut(sender, e)
            Case "bookPK"
                book.bookArgument.type = "Удостоверение"
                book.bookClick()
            Case "bookPP"
                book.bookArgument.type = "Диплом"
                book.bookClick()
            Case "bookPO"
                book.bookArgument.type = "Свидетельство"
                book.bookClick()
            Case "bookFPK"
                bookFRDO.bookArgument.type = "Удостоверение"
                bookFRDO.bookFRDOClick()
            Case "bookFPP"
                bookFRDO.bookArgument.type = "Диплом"
                bookFRDO.bookFRDOClick()
            Case "bookFPO"
                bookFRDO.bookArgument.type = "Свидетельство"
                bookFRDO.bookFRDOClick()
            Case "reportRun"
                Report.run()

        End Select

    End Sub

    Private Sub MainForm_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        If mainForm.tbl_education.Focused Then

            If e.KeyValue = Keys.Tab Then

                e.IsInputKey = True

            End If

        End If

    End Sub

    Public Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs)

        If mainForm.TabControlOther.SelectedIndex = 6 Then

            tabPageOther_KeyDown(sender, e)

            Return

        ElseIf mainForm.TabControlOther.SelectedIndex = 5 And mainForm.password.Focused = False Then

            tabPagePrograms_KeyDown(sender, e)

            Return

        End If

        If e.KeyCode = mainForm.switchPageKey Then

            If sender.ActiveControl.GetType.ToString = "System.Windows.Forms.DateTimePicker" Then Return
            If mainForm.red_moduls.Focused Or mainForm.newModAddName.Focused Or mainForm.newModAddHour.Focused Or mainForm.worker_name.Focused Or mainForm.worker_name_full.Focused Or mainForm.worker_name_pad.Focused Then
                Return
            End If
            openNextPage(mainForm.TabControlOther)
            e.Handled = True

        End If

        If e.KeyCode = mainForm.seitchPageKey_Inverse Then
            If sender.ActiveControl.GetType.ToString = "System.Windows.Forms.DateTimePicker" Then Return
            If mainForm.red_moduls.Focused Or mainForm.newModAddName.Focused Or mainForm.newModAddHour.Focused Or mainForm.worker_name.Focused Or mainForm.worker_name_full.Focused Or mainForm.worker_name_pad.Focused Then
                Return
            End If

            openPrevPage(mainForm.TabControlOther)
            e.Handled = True

        End If

    End Sub

    Private Sub openGroupListPK(sender As Object, e As EventArgs)

        mainForm.cvalific = MainForm.PK
        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        GroupList.ShowDialog()

    End Sub

    Private Sub openGroupListPP(sender As Object, e As EventArgs)

        mainForm.cvalific = MainForm.PP
        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        GroupList.ShowDialog()

    End Sub
    Private Sub createGroup_Click(sender As Object, e As EventArgs)

        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        newGroup.redactorMode = False
        newGroup.ShowDialog()


    End Sub

    Private Sub openGroupListPO(sender As Object, e As EventArgs)

        mainForm.cvalific = MainForm.PO
        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        GroupList.ShowDialog()

    End Sub

    Private Sub openStudentList(sender As Object, e As EventArgs)

        If mainFormBuilder.controls(mainFormBuilder.controlNames("students_defaultSearchSetts")).Text = "" Then
            НастройкаПоискаСлушателей.Снилс.Checked = True
        End If

        StudentsList.insertIntoGroupList.Visible = False
        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        StudentsList.searchSetts.Visible = False
        StudentsList.showStudentsList()
        StudentsList.ShowDialog()

    End Sub

    Private Sub addStudent(sender As Object, e As EventArgs)

        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        newStudent.ShowDialog()

    End Sub

    Private Sub openGgrades(sender As Object, e As EventArgs)

        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        Grades.groupNumber.Clear()
        Grades.resultTable.Rows.Clear()
        Grades.ShowDialog()

    End Sub
    Private Sub openGgradesIA(sender As Object, e As EventArgs)

        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)
        GradesIA.groupNumber.Clear()
        GradesIA.resultTable.Rows.Clear()
        GradesIA.ShowDialog()

    End Sub

    Private Sub openWorkerReport(sender As Object, e As EventArgs)

        Dim List
        Dim queryString As String

        WorkerReport.WorkerReport_Init()

        mainForm.ActiveControl = mainForm.TabControlOther.TabPages(0)

        WorkerReport.mainTable.Rows.Clear()
        WorkerReport.groupNumber.Clear()

        _formCleaner.cleaner(WorkerReport)

        queryString = load_prepod()
        List = mainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If List(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Не удалось загрузить список преподавателей"
            openForm(Warning)

            Return

        End If

        listIntoComboBox(WorkerReport.mainTable, List, "ФИО")
        WorkerReport.ShowDialog()

    End Sub

    Private Sub tabPageOther_KeyDown(sender As Object, e As KeyEventArgs)

        If mainForm.tbl_education.flag_active_control Then

            tbl_obrazovanie_keyDown(e)
            Return

        ElseIf mainForm.DataGridView_list.Visible Then

            If e.KeyValue = Keys.Escape Then

                closeRedactorWorker(sender, e)

                If mainForm.worker.flagTextBox Then
                    e.SuppressKeyPress = True
                End If

                mainForm.ActiveControl = mainForm.DataGridView_list

            ElseIf e.KeyValue = Keys.Enter Then

                worker_EnterDown()

                If mainForm.worker.flagTextBox Then
                    e.SuppressKeyPress = True
                End If

            End If

        End If

        If mainForm.ToolStrip1.Focused() Or mainForm.ToolStrip_name_list.Focused Then

            Return

        ElseIf (mainForm.DataGridView_list.Focused Or mainForm.ActiveControl.Name = "TabControlOther" Or mainForm.passwordOther.Focused) And mainForm.SplitContainerOtherList.Panel2Collapsed Then

            If e.KeyCode = mainForm.switchPageKey Then

                openNextPage(mainForm.TabControlOther)

            End If

            If e.KeyCode = mainForm.seitchPageKey_Inverse Then

                openPrevPage(mainForm.TabControlOther)

            End If

        End If

    End Sub
    Private Sub DataGridAllModuls_keyDown(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode

            Case Keys.Tab
                If mainForm.DataGridAllModuls.Focused Then
                    If mainForm.programms__SplitContainerModuls.Panel2Collapsed = True Then
                        mainForm.toolStripProgram.Focus()
                        mainForm.comboBoxProgramms.Focus()
                    Else
                        mainForm.newModAddName.Focus()
                    End If
                ElseIf mainForm.newModAddName.Focused() Then
                    mainForm.newModAddHour.Focus()
                Else
                    mainForm.DataGridAllModuls.Focus()
                End If
                e.Handled = True

            Case Keys.Add

                If Not mainForm.comboBoxProgramms.Text.Trim = "" Then
                    mainForm.ToolStripAddModul_Click(sender, e)
                End If

            Case Keys.Left

                If mainForm.DataGridAllModuls.Focused Then
                    If mainForm.programms__SplitContainerModuls.Panel2Collapsed = True Then
                        Return
                    Else
                        mainForm.toolStripModulsInProg.Focus()
                        mainForm.addModulInGroupSelect()
                    End If
                ElseIf mainForm.newModAddHour.Focused() Then
                    mainForm.newModAddName.Focus()
                End If

            Case Keys.Right

                If mainForm.newModAddName.Focused() Then
                    mainForm.newModAddHour.Focus()
                End If

            Case Keys.Up

                If mainForm.newModAddName.Focused() Or mainForm.newModAddHour.Focused() Then
                    mainForm.DataGridAllModuls.Focus()
                    e.Handled = True
                End If

            Case Keys.R

                Dim e1 As DataGridViewCellEventArgs
                mainForm.DataGridAllModuls_CellDoubleClick(sender, e1)

            Case Keys.Escape
                If mainForm.programms__SplitContainerModuls.Panel2Collapsed = False Then
                    mainForm.programms__SplitContainerModuls.Panel2Collapsed = True
                Else
                    mainForm.toolStripProgram.Focus()
                    mainForm.comboBoxProgramms.Focus()
                End If

        End Select

    End Sub
    Private Sub tabPagePrograms_KeyDown(sender As Object, e As KeyEventArgs)

        If mainForm.toolStripModulsInProg.Focused() Or mainForm.toolStripProgram.Focused() Then

            Return

        End If

        If mainForm.programs__progrs_tbl.flag_active_control Then

            programs_tbl_keyDown(e)
            Return

        ElseIf mainForm.programs_type_tbl.flag_active_control Then

            progsType_tbl_keyDown(e)
            Return

        ElseIf mainForm.DataGridAllModuls.Focused Or mainForm.newModAddName.Focused Or mainForm.newModAddHour.Focused Then
            DataGridAllModuls_keyDown(sender, e)
        End If

            If e.KeyCode = Keys.Down And mainForm.dataGridModulsInProgram.Focused() Then

            progsType_tbl()
            Return

        ElseIf e.KeyCode = mainForm.switchPageKey Then

            If mainForm.DataGridAllModuls.Focused Or mainForm.ActiveControl.Name = "TabControlOther" Then

                openNextPage(mainForm.TabControlOther)

            ElseIf mainForm.dataGridModulsInProgram.Focused Then

                Return

            ElseIf mainForm.ActiveControl.Name = "SplitContainer4" Or mainForm.ActiveControl.Name = "dataGridModuls" Or mainForm.ActiveControl.Name = "ToolStrip3" Then

                Return

            End If

            e.Handled = True
            Return

        ElseIf e.KeyCode = Keys.Left Then

            If mainForm.ActiveControl.Name = "TabControlOther" Then

                openPrevPage(mainForm.TabControlOther)

            ElseIf mainForm.DataGridAllModuls.Focused Or mainForm.dataGridModulsInProgram.Focused Then

                Return

            End If

            e.Handled = True
            Return

        ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

            Return

        End If

    End Sub

    Private Sub tbl_obrazovanie_keyDown(e As KeyEventArgs)

        If e.KeyValue = Keys.Tab Then

            If mainForm.tbl_education.active_last_element Then

                mainForm.ToolStrip_name_list.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Right Then

            If mainForm.tbl_education.active_last_element Then

                openNextPage(mainForm.TabControlOther)
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Left Then

            If mainForm.tbl_education.active_last_element Then

                openPrevPage(mainForm.TabControlOther)
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Escape Then

            mainForm.tbl_education.builder.redactorClose()
            e.Handled = True

        End If

    End Sub

    Private Sub closeRedactorWorker(sender As Object, e As KeyEventArgs)

        If mainForm.redactor_enter = False Or mainForm.SplitContainerOtherList.Panel2Collapsed Then

            Return

        End If

        clear_panel_worker(sender, e)
        mainForm.worker.flagUpdate = False
        mainForm.SplitContainerOtherList.Panel2Collapsed = True
        mainForm.SplitContainerOtherList.Focus()

    End Sub

    Private Sub worker_EnterDown()

        If mainForm.redactor_enter = False Or mainForm.SplitContainerOtherList.Panel2Collapsed Or mainForm.worker_dolgnost.DroppedDown Or mainForm.worker_type.DroppedDown Then

            Return

        End If

        saveWorker()
        selectRowInListWorker()

    End Sub
    Private Sub programs_tbl_keyDown(e As KeyEventArgs)

        If e.KeyValue = Keys.Tab Then

            If mainForm.programs__progrs_tbl.active_last_element Then

                mainForm.dataGridModulsInProgram.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Right Then

            If mainForm.programs__progrs_tbl.active_last_element Then

                mainForm.dataGridModulsInProgram.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Left Then

            If mainForm.programs__progrs_tbl.active_last_element Then

                openPrevPage(mainForm.TabControlOther)
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Escape Then

            If mainForm.programs__progrs_tbl.flag_active_control And mainForm.programs__progrs_tbl.flagRedactorOpen Then

                mainForm.programs__progrs_tbl.builder.redactorClose()

            ElseIf mainForm.programs__progrs_tbl.flag_active_control Then

                mainForm.toolStripProgram.Focus()
                mainForm.comboBoxProgramms.Focus()


            End If

            'If mainForm.programs__progrs_tbl.comboBox_second_element.my_ComboBox.DroppedDown Then

            '    mainForm.programs__progrs_tbl.comboBox_second_element.my_ComboBox.DroppedDown = False

            'End If

            e.Handled = True

        End If

    End Sub

    Private Sub progsType_tbl_keyDown(e As KeyEventArgs)

        If e.KeyValue = Keys.Tab Then

            If mainForm.programs_type_tbl.active_last_element Then

                mainForm.dataGridModulsInProgram.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Right Then

            If mainForm.programs_type_tbl.active_last_element Then

                mainForm.DataGridAllModuls.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Left Then

            If mainForm.programs_type_tbl.active_last_element Then

                mainForm.programs__progrs_tbl.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Escape Then

            mainForm.programs_type_tbl.builder.redactorClose()

            e.Handled = True

        ElseIf e.KeyValue = Keys.Up Then

            progsType_keyDownUp(e)

        End If

    End Sub

    Private Sub progsType_tbl()

        If mainForm.dataGridModulsInProgram.Rows.Count = 0 Then Return

        If mainForm.dataGridModulsInProgram.CurrentCell.RowIndex = (mainForm.dataGridModulsInProgram.Rows.Count - 1) Then

            mainForm.programs_type_tbl.Focus()

        End If

    End Sub

    Public Sub clear_panel_worker(sender As Object, e As EventArgs)

        mainForm.worker_name.Clear()
        mainForm.worker_name.BackColor = Color.White
        mainForm.worker_name.Focus()

        For Each element As TextBox In mainForm.panel_worker.Controls.OfType(Of TextBox)
            If element.Name <> "TextBoxS" Then
                element.Clear()
                element.BackColor = Color.White
            End If
        Next

        mainForm.worker_dolgnost.Text = "нет"
        mainForm.worker_type.Text = mainForm.worker.default_type

        worker_name_Leave(sender, e)
        worker_name_pad_Leave(sender, e)
        worker_name_full_Leave(sender, e)

    End Sub

    Private Sub saveWorker()

        Dim message As String

        If mainForm.worker_name.Text.Trim = "ФИО" Or mainForm.worker_name.Text.Trim = "" Or mainForm.ToolStrip_name_list.Text.Trim = "" Then
            Return
        End If

        Dim result() As String
        message = mainForm.worker_name.Text.Trim
        result = message.Split(" ")

        If result.Count = 1 Then
            message = "Введите ФИО в форме 'Фамилия И.О.' (один пробел после фамилии)"
        ElseIf result.Count > 2 Then
            message = "Удалите лишние пробелы! Введите ФИО в форме 'Фамилия И.О.' (один пробел после фамилии)"
        End If

        If Not result.Count = 2 Then

            Warning.TextBox.Visible = False
            Warning.content.Text = message
            Warning.ShowDialog()
            mainForm.worker_name.Select(mainForm.worker_name.Text.Length, 0)
            Return

        End If


        mainForm.worker.worker_struct.name = mainForm.worker_name.Text.Trim

        If mainForm.worker_name_full.Text.Trim <> "Фамилия Имя Отчество" Then
            mainForm.worker.worker_struct.name_full = mainForm.worker_name_full.Text.Trim
        Else
            mainForm.worker.worker_struct.name_full = ""
        End If

        If mainForm.worker_name_pad.Text.Trim <> "Фамилия Имя Отчество РП" Then
            mainForm.worker.worker_struct.name_pad = mainForm.worker_name_pad.Text.Trim
        Else
            mainForm.worker.worker_struct.name_pad = ""
        End If

        mainForm.worker.worker_struct.worker_position = mainForm.worker_dolgnost.Text
        mainForm.worker.worker_struct.worker_type = mainForm.worker_type.Text

        If mainForm.worker.flagUpdate Then

            mainForm.worker.updateWorker()

        Else

            If Not mainForm.worker.checkWorker() Then

                Return

            End If

            mainForm.worker.addWorker()

        End If

        mainForm.loadTblWorker()
        BuildOrder.reload_lists()

    End Sub

    Private Sub selectRowInListWorker()

        Dim numberRow As Integer = -1
        If mainForm.worker.worker_struct.kod = -1 Then
            Return
        End If
        numberRow = RedactorDataGrid.dataGridViewSearchRow(mainForm.DataGridView_list.Rows, 6, Convert.ToString(mainForm.worker.worker_struct.kod))
        mainForm.DataGridView_list.CurrentCell = mainForm.DataGridView_list.Rows(numberRow).Cells(0)
        mainForm.DataGridView_list.Rows(numberRow).Cells(0).Selected = True

    End Sub

    Private Sub progsType_keyDownUp(e As KeyEventArgs)

        If IsNothing(mainForm.programs_type_tbl.DataGridTablesResult.CurrentCell) Then

            mainForm.dataGridModulsInProgram.Focus()
            e.Handled = True

        ElseIf mainForm.programs_type_tbl.DataGridTablesResult.CurrentCell.RowIndex < 1 And mainForm.programs_type_tbl.active_last_element Then  'Если выделенна первая строчка в таблице и не активен редактор

            mainForm.dataGridModulsInProgram.Focus()
            e.Handled = True

        End If

    End Sub

    Public Sub worker_name_Leave(sender As Object, e As EventArgs)
        If mainForm.worker_name.Text.Trim = "" Then
            mainForm.worker_name.Text = "ФИО"
            mainForm.worker_name.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub worker_name_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub worker_name_full_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub worker_name_pad_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub worker_name_Enter(sender As Object, e As EventArgs)
        If mainForm.worker_name.Text.Trim = "ФИО" Then
            mainForm.worker_name.Text = ""
            mainForm.worker_name.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_full_Enter(sender As Object, e As EventArgs)
        If mainForm.worker_name_full.Text.Trim = "Фамилия Имя Отчество" Then
            mainForm.worker_name_full.Text = ""
            mainForm.worker_name_full.ForeColor = Color.Black
        End If
    End Sub

    Public Sub worker_name_full_Leave(sender As Object, e As EventArgs)
        If mainForm.worker_name_full.Text.Trim = "" Then
            mainForm.worker_name_full.Text = "Фамилия Имя Отчество"
            mainForm.worker_name_full.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub worker_name_pad_Enter(sender As Object, e As EventArgs)
        If mainForm.worker_name_pad.Text.Trim = "Фамилия Имя Отчество РП" Then
            mainForm.worker_name_pad.Text = ""
            mainForm.worker_name_pad.ForeColor = Color.Black
        End If
    End Sub

    Public Sub worker_name_pad_Leave(sender As Object, e As EventArgs)
        If mainForm.worker_name_pad.Text.Trim = "" Then
            mainForm.worker_name_pad.Text = "Фамилия Имя Отчество РП"
            mainForm.worker_name_pad.ForeColor = Color.LightGray
        End If
    End Sub

End Class
