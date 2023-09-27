
Imports System.Windows.Forms.VisualStyles

Public Class Tables_control

    Public kod_number As Int16
    Public remove_kod As Int64
    Public name_table As String

    Public program_on As Boolean
    Public type_progs_on As Boolean
    Public add_on As Boolean = True

    Public selected_row As Integer = -1
    Private flag_rowSelect As Boolean = False
    'Private flag_responceProg As Boolean = False

    Public flag_active_control As Boolean = False
    Public active_last_element As Boolean = False

    Public numberElementFirst As Int16 = 0
    Public numberElementSecond As Int16 = 1

    Public queryString_load As String

    Public flag_first_control_combo As Boolean = False
    Public flag_second_control_combo As Boolean = False

    Public result As DataTable

    Public number_column As Int16 'количество столбцов в таблице

    Public width_column As New Dictionary(Of Int16, Int16)

    Public aligment_column As New Dictionary(Of Int16, Int16)


    Public names As New Names
    Public values As New Values

    Public flagUpdate As Boolean = False

    Public mySQLConnector As New MySQLConnect
    Dim keyboardEvents As New DGV_Events
    Dim tableRedactor As New DGVRedactorTable
    Public builder As New DGVBuilder

    Public Sub table_init()

        keyboardEvents.userDGV = Me
        keyboardEvents.formParent = StudentsInGroup
        builder.userDGV = Me
        tableRedactor.userDGV = Me

        keyboardEvents.listCombo.Add(comboBox_first_element)
        keyboardEvents.listCombo.Add(comboBox_second_element)

        keyboardEvents.userDGV_init()

        aligment_column.Clear()

        aligment_column.Add(0, DataGridViewContentAlignment.MiddleLeft)
        aligment_column.Add(1, DataGridViewContentAlignment.MiddleLeft)
        aligment_column.Add(2, DataGridViewContentAlignment.MiddleLeft)
        aligment_column.Add(3, DataGridViewContentAlignment.MiddleLeft)
        aligment_column.Add(4, DataGridViewContentAlignment.MiddleLeft)
        aligment_column.Add(5, DataGridViewContentAlignment.MiddleLeft)
        aligment_column.Add(6, DataGridViewContentAlignment.MiddleLeft)

        If number_column = 2 Then

            SplitContainer_second.Panel2Collapsed = False
            redactor_name_element_second.Text = names.redactor_element_second

            If flag_second_control_combo Then

                redactor_element_second.Visible = False
                comboBox_second_element.Visible = True

                comboBox_second_element.Parent = panel_second_element
                comboBox_second_element.Parent = panel_second_element
                comboBox_second_element.Dock = DockStyle.Fill
                comboBox_second_element.my_comboBox_Init()

            Else

                redactor_element_second.Visible = True
                comboBox_second_element.Visible = False

            End If

            If flag_first_control_combo Then

                redactor_element_first.Visible = False
                comboBox_first_element.Visible = True

                comboBox_first_element.Parent = panel_first_element
                comboBox_first_element.Parent = panel_first_element
                comboBox_first_element.Dock = DockStyle.Fill
                comboBox_first_element.my_comboBox_Init()

            Else

                redactor_element_first.Visible = True
                comboBox_first_element.Visible = False

            End If

        Else

            redactor_element_second.Visible = True
            SplitContainer_second.Panel2Collapsed = True

        End If

        redactor_name_element_first.Text = names.redactor_element_first

        SplitContainer_main.Panel2Collapsed = True

        result = New DataTable

        DataGridTablesResult.DataSource = result

        load_table()

    End Sub

    Public Sub tables_control_Activate()

        flag_active_control = True

        If program_on Then

            MainForm.progsIndicator.Image = MainForm.iconsList.Images(9)

        End If

    End Sub

    Public Sub tables_control_Leave()

        flag_active_control = False

        If program_on Then

            MainForm.progsIndicator.Image = MainForm.iconsList.Images(8)

        End If

    End Sub

    Public Sub load_table()

        result = mySQLConnector.mySqlToDataTable(queryString_load, 1)

        DataGridTablesResult.DataSource = result

        builder.build_table()

    End Sub

    Public Sub dataGridTables_activate()

        If SplitContainer_main.Panel2Collapsed Then

            active_last_element = True

        End If

    End Sub

    Public Sub table_tabDown(e As KeyEventArgs)

        If Not SplitContainer_main.Panel2Collapsed Then

            builder.redactor_firstControl_focus()

            e.Handled = True

        End If

    End Sub

    Public Sub table_addDown()

        If Not add_on Then
            Return
        End If

        builder.redactorOpen()

    End Sub

    Public Sub dataGridTables_deleteDown()

        If name_table = "group_list" Then

            If IsNothing(DataGridTablesResult.CurrentRow) Then Return
            Dim name As String
            name = DataGridTablesResult.CurrentRow.Cells(1).Value + " " + DataGridTablesResult.CurrentRow.Cells(2).Value
            StudentsInGroup.dataGridTables_RemoveStudent(addMask.deleteMask(DataGridTablesResult.CurrentRow.Cells(0).Value), name)
            load_table()

        Else
            tableRedactor.removeRow()
        End If

    End Sub

    Public Sub dataGridTables_CellDoubleClick(sender As Object, e As EventArgs)

        If name_table = "group_list" Then
            Dim name As String
            name = DataGridTablesResult.CurrentRow.Cells(1).Value + " " + DataGridTablesResult.CurrentRow.Cells(2).Value + " " + DataGridTablesResult.CurrentRow.Cells(3).Value
            Dim snils As String = addMask.deleteMask(DataGridTablesResult.CurrentRow.Cells(0).Value)
            StudentsInGroup.tableListStudents_CellDoubleClick(sender, e, name, snils)
        Else
            builder.redactorOpen_update()
        End If

    End Sub

    Public Sub dataGridTables_rDown()

        builder.redactorOpen_update()

    End Sub

    Public Sub dataGridTables_SizeChanged()

        builder.build_table()

    End Sub

    Public Sub dataGridTables_Leave()

        active_last_element = False

    End Sub

    Public Sub dataGridTables_SelectionChanged()

        If IsNothing(DataGridTablesResult.CurrentCell) Then Return

        If Not flag_rowSelect Then

            selectRow(DataGridTablesResult.Rows(DataGridTablesResult.CurrentCell.RowIndex))
            selected_row = DataGridTablesResult.CurrentCell.RowIndex

            If program_on Then

                response_programms()

            End If

        End If

    End Sub

    Public Sub redactorElementFirst_bottomDown(e As KeyEventArgs)

        If number_column = 2 Then
            If flag_second_control_combo Then
                comboBox_second_element.Focus()
            Else
                redactor_element_second.Focus()
                redactor_element_second.Select(redactor_element_second.Text.Length, 0)
            End If
        Else
            ActiveControl = DataGridTablesResult
        End If
        e.Handled = True

    End Sub

    Public Sub redactorElementFirst_upDown(e As KeyEventArgs)

        ActiveControl = DataGridTablesResult
        e.Handled = True

    End Sub

    Public Sub redactorElementSecond_bottomDown(e As KeyEventArgs)

        ActiveControl = DataGridTablesResult
        e.Handled = True

    End Sub

    Public Sub redactorElementSecond_upDown(e As KeyEventArgs)

        redactor_element_first.Focus()
        redactor_element_first.Select(redactor_element_first.Text.Length, 0)
        e.Handled = True

    End Sub

    Public Sub secondElement_enterPress(e As KeyPressEventArgs)

        readFromRedactor()

        If flagUpdate Then
            tableRedactor.updateRow()
        Else
            tableRedactor.addRow()
        End If

        load_table()

        selectRowInList(values.kod, kod_number)

        e.Handled = True

    End Sub

    Public Sub secondElement_pressTab(e As KeyPressEventArgs)

        ActiveControl = DataGridTablesResult

        e.Handled = True

    End Sub

    Public Sub redactorElementFirst_tabDown(e As KeyPressEventArgs)

        If number_column = 2 Then

            If flag_second_control_combo Then
                comboBox_second_element.Focus()
            Else
                redactor_element_second.Focus()
                redactor_element_second.Select(redactor_element_second.Text.Length, 0)
            End If

        ElseIf number_column = 1 Then

            ActiveControl = DataGridTablesResult

        End If

        e.Handled = True

    End Sub

    Private Sub redactor_element_second_Leave(sender As Object, e As EventArgs) Handles redactor_element_second.Leave

        If number_column = 2 Then

            active_last_element = False

        End If

    End Sub


    Private Sub redactor_element_first_Leave(sender As Object, e As EventArgs) Handles redactor_element_first.Leave

        If number_column = 1 Then

            active_last_element = False

        End If

    End Sub

    Public Sub selectRowInList(kod As Int64, columnNumber As Int16)

        Dim numberRow As Integer = -1

        If kod = -1 Then
            Return
        End If

        If name_table = "group_list" Then
            numberRow = dataGridViewSearchRow(DataGridTablesResult.Rows, columnNumber, Convert.ToString(addMask.addMask(values.snils)))
        Else
            numberRow = dataGridViewSearchRow(DataGridTablesResult.Rows, columnNumber, Convert.ToString(kod))
        End If

        'DataGridTablesResult.ClearSelection()

        'selected_row = numberRow

        DataGridTablesResult.CurrentCell = DataGridTablesResult.Rows(numberRow).Cells(0)
        DataGridTablesResult.CurrentCell.Selected = True

    End Sub

    Function dataGridViewSearchRow(dataGridViewRows As DataGridViewRowCollection, columnNumber As Integer, value As String) As Integer

        Dim number As Integer
        For Each row As DataGridViewRow In dataGridViewRows
            If Convert.ToString(row.Cells(columnNumber).Value) = value Then
                number = row.Index
                Return number
            End If
        Next
        Return number

    End Function

    Private Sub SplitContainer_main_SizeChanged(sender As Object, e As EventArgs) Handles SplitContainer_main.SizeChanged

        If Not IsNothing(builder.userDGV) Then
            builder.build_table()
        End If
        redactor_element_second.Dock = DockStyle.Fill

    End Sub

    Private Sub response_programms()

        MainForm.programs__loadModulsInProgramm()
        MainForm.programs__tblTypeUpdateContent()

    End Sub

    Public Sub selectRow(row As DataGridViewRow)

        If IsNothing(row) Then Return

        flag_rowSelect = True

        DataGridTablesResult.ClearSelection()

        For Each cell As DataGridViewCell In row.Cells
            cell.Selected = True
        Next
        flag_rowSelect = False

    End Sub

    Public Sub readFromRedactor()

        If flag_first_control_combo Then
            values.element_first = comboBox_first_element.my_ComboBox.Text.Trim
        Else
            values.element_first = redactor_element_first.Text.Trim
        End If

        If flag_second_control_combo Then
            values.element_second = comboBox_second_element.my_ComboBox.Text.Trim
        Else
            values.element_second = redactor_element_second.Text.Trim
        End If

    End Sub

    Private Sub DataGridTablesResult_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridTablesResult.CurrentCellChanged
        Dim s As Integer
        's = DataGridTablesResult.CurrentCell.RowIndex
    End Sub
End Class

Public Structure Values

    Dim kod As Int64
    Dim snils As String
    Dim element_first As String
    Dim element_second As String

End Structure

Public Structure Names

    Dim redactor_element_first As String
    Dim redactor_element_second As String
    Dim db_element_first As String
    Dim db_element_second As String

End Structure
