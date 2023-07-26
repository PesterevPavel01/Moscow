Imports System.Data.SqlTypes
Imports System.ComponentModel

Public Class Tables_control

    Public kod_number As Int16
    Private remove_kod As Int64
    Public name_table As String

    Public programm_on As Boolean
    Public type_progs_on As Boolean
    Public add_on As Boolean = True

    Public selected_row As DataGridViewRow

    Public flag_active_control As Boolean = False
    Public active_last_element As Boolean = False

    Public numberElementFirst As Int16 = 0
    Public numberElementSecond As Int16 = 1

    Public queryString_load As String
    Private queryString As String

    Public flag_second_control_combo As Boolean = False

    Private result As DataTable

    Public number_column As Int16 'количество столбцов в таблице

    Public persent_width_column_0 As Int16
    Public persent_width_column_1 As Int16 = -1
    Public persent_width_column_2 As Int16 = -1
    Public persent_width_column_3 As Int16 = -1

    Public names As New Names
    Public values As New Values

    Private flagUpdate As Boolean = False

    Dim mySQLConnector As New MySQLConnect

    Public Sub table_init()

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

        Else

            redactor_element_second.Visible = True
            SplitContainer_second.Panel2Collapsed = True

        End If

        redactor_name_element_first.Text = names.redactor_element_first

        SplitContainer_main.Panel2Collapsed = True

        result = New DataTable

        DataGridTablesResult.DataSource = result

        load_table()

        'DataGridTablesResult.ClearSelection()

    End Sub

    Private Sub bild_table()

        Dim number_row As Int16 = 0

        For Each dataGridViewColumn In DataGridTablesResult.Columns

            If number_row = 0 And persent_width_column_0 <> -1 Then

                dataGridViewColumn.Width = DataGridTablesResult.Width * persent_width_column_0 / 100

            ElseIf number_row = 1 And persent_width_column_1 <> -1 Then

                If persent_width_column_1 = 0 Then

                    dataGridViewColumn.Visible = False

                Else

                    dataGridViewColumn.Width = DataGridTablesResult.Width * persent_width_column_1 / 100

                End If


            ElseIf number_row = 2 And persent_width_column_2 <> -1 Then

                If persent_width_column_2 = 0 Then

                    dataGridViewColumn.Visible = False

                Else

                    dataGridViewColumn.Width = DataGridTablesResult.Width * persent_width_column_2 / 100

                End If

            ElseIf number_row = 3 And persent_width_column_3 <> -1 Then

                If persent_width_column_3 = 0 Then

                    dataGridViewColumn.Visible = False

                Else

                    dataGridViewColumn.Width = DataGridTablesResult.Width * persent_width_column_3 / 100

                End If

            End If

            number_row += 1

        Next

    End Sub

    Public Sub load_table()

        result = mySQLConnector.ЗагрузитьИзMySQLвDataTable(queryString_load, 1)

        DataGridTablesResult.DataSource = result

        bild_table()

        DataGridTablesResult.DefaultCellStyle.Font = New Font("Microsoft YaHei", 12)
        DataGridTablesResult.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft YaHei", 12)


    End Sub

    Public Sub redactorOpen()

        SplitContainer_main.Panel2Collapsed = False
        redactor_element_first.BackColor = Color.White
        redactor_element_first.Select()
        redactor_element_first.Select(redactor_element_first.Text.Length, 0)

        If persent_width_column_1 <> -1 Then

            If flag_second_control_combo Then

                comboBox_second_element.set_color(Color.White)

            Else

                redactor_element_second.BackColor = Color.White

            End If


        End If

        flagUpdate = False

    End Sub

    Public Sub redactorClose()

        active_last_element = True
        SplitContainer_main.Panel2Collapsed = True

        DataGridTablesResult.Focus()
        ActiveControl = DataGridTablesResult

        flagUpdate = False

    End Sub

    Private Sub DataGridTables_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridTablesResult.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub redactor_element_second_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles redactor_element_second.PreviewKeyDown

        second_element_PreviewKeyDown(e)

    End Sub

    Private Sub second_element_PreviewKeyDown(e As PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Down Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Up Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub redactor_element_first_KeyDown(sender As Object, e As KeyEventArgs) Handles redactor_element_first.KeyDown

        If e.KeyCode = Keys.Down Then

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

        ElseIf e.KeyCode = Keys.Up Then

            ActiveControl = DataGridTablesResult
            e.Handled = True

        End If

    End Sub

    Private Sub redactor_element_second_KeyDown(sender As Object, e As KeyEventArgs) Handles redactor_element_second.KeyDown

        If e.KeyCode = Keys.Down Then

            ActiveControl = DataGridTablesResult
            e.Handled = True

        ElseIf e.KeyCode = Keys.Up Then

            redactor_element_first.Focus()
            redactor_element_first.Select(redactor_element_first.Text.Length, 0)
            e.Handled = True

        End If

    End Sub


    Private Sub redactor_element_first_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles redactor_element_first.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Down Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Up Then

            e.IsInputKey = True

        End If

    End Sub

    Public Sub second_element_pressEnter(e As KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            If redactor_element_first.Text.Trim = "" Then

                e.Handled = True
                Return

            End If

            values.element_first = redactor_element_first.Text.Trim

            If flag_second_control_combo Then

                values.element_second = comboBox_second_element.my_ComboBox.Text.Trim

            Else

                values.element_second = redactor_element_second.Text.Trim

            End If


            If flagUpdate Then

                updateRow()

            Else

                saveRow()

            End If

            load_table()

            selectRowInList(values.kod, kod_number)

            e.Handled = True

        End If

    End Sub

    Private Sub redactor_element_first_KeyPress(sender As Object, e As KeyPressEventArgs) Handles redactor_element_first.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            second_element_pressEnter(e)

        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) Then

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

        End If

    End Sub

    Private Sub DataGridTables_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridTablesResult.KeyDown

        If e.KeyValue = Keys.Delete Then

            Dim curNumber = DataGridTablesResult.CurrentCell.RowIndex
            ФормаДаНетУдалить.текстДаНет.Text = "Удалить " + DataGridTablesResult.Rows(curNumber).Cells(numberElementFirst).Value + "?"
            ФормаДаНетУдалить.ShowDialog()

            If Not ФормаДаНетУдалить.НажатаКнопкаДа Then
                Return
            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

            remove_kod = Convert.ToInt64(DataGridTablesResult.Rows(curNumber).Cells(kod_number).Value)

            queryString = ААОсновная.program__sqlQueryString.update_delete_query(programm_on, name_table, ААОсновная.comboBoxProgramms.Text, remove_kod)

            mySQLConnector.ОтправитьВбдЗапись(queryString, 1)

            If redactor_element_first.Text.Trim = Convert.ToString(DataGridTablesResult.Rows(curNumber).Cells(numberElementFirst).Value) Then

                SendKeys.Send("{ESC}")

            End If

            load_table()

            If (curNumber <> 0) Then

                DataGridTablesResult.CurrentCell = DataGridTablesResult.Rows(curNumber - 1).Cells(numberElementFirst)

            End If

        ElseIf e.KeyValue = Keys.Add Then

            If add_on Then

                add_Down()

            End If

            Return

        ElseIf e.KeyValue = Keys.R Then

            redactorOpen_update()

        ElseIf e.KeyValue = Keys.Tab Then

            If SplitContainer_main.Panel2Collapsed Then


            Else

                redactor_element_first.Focus()
                redactor_element_first.Select(redactor_element_first.Text.Length, 0)
                e.Handled = True

            End If

        End If

    End Sub

    Public Sub add_Down()

        redactor_element_first.Clear()

        If flag_second_control_combo Then

            comboBox_second_element.my_ComboBox.SelectedIndex = 0

        Else

            redactor_element_second.Clear()

        End If

        redactorOpen()

    End Sub

    Public Sub DataGridTables_SizeChanged(sender As Object, e As EventArgs) Handles DataGridTablesResult.SizeChanged

        bild_table()

    End Sub

    Private Sub DataGridTablesResult_Enter(sender As Object, e As EventArgs) Handles DataGridTablesResult.Enter

        If SplitContainer_main.Panel2Collapsed Then

            active_last_element = True

        End If

        DataGridTablesResult.CurrentCell.Selected = True

    End Sub

    Private Sub DataGridTablesResult_Leave(sender As Object, e As EventArgs) Handles DataGridTablesResult.Leave

        active_last_element = False

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

    Private Sub DataGridTablesResult_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridTablesResult.CellDoubleClick

        redactorOpen_update()

    End Sub

    Public Sub redactorOpen_update()

        If DataGridTablesResult.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(DataGridTablesResult.Rows(0).Cells(numberElementFirst).Value) = "" Then
            Return
        End If

        Dim curNumber = DataGridTablesResult.CurrentCell.RowIndex

        If IsNumeric(DataGridTablesResult.Rows(curNumber).Cells(kod_number).Value) Then

            values.kod = Convert.ToInt64(DataGridTablesResult.Rows(curNumber).Cells(kod_number).Value)
            values.element_first = Convert.ToString(DataGridTablesResult.Rows(curNumber).Cells(numberElementFirst).Value)
            values.element_second = Convert.ToString(DataGridTablesResult.Rows(curNumber).Cells(numberElementSecond).Value)

        Else

            Return

        End If

        redactor_element_first.Text = DataGridTablesResult.Rows(curNumber).Cells(numberElementFirst).Value

        If flag_second_control_combo Then

            comboBox_second_element.my_ComboBox.Text = Convert.ToString(DataGridTablesResult.Rows(curNumber).Cells(numberElementSecond).Value)

        Else

            redactor_element_second.Text = Convert.ToString(DataGridTablesResult.Rows(curNumber).Cells(numberElementSecond).Value)

        End If

        redactorOpen()
        redactor_element_first.BackColor = Color.AliceBlue

        If flag_second_control_combo Then

            comboBox_second_element.set_color(Color.AliceBlue)

        Else

            redactor_element_second.BackColor = Color.AliceBlue

        End If

        flagUpdate = True

    End Sub

    Private Sub updateRow()

        Dim resAr() As String

        If programm_on Then

            queryString = ААОсновная.program__sqlQueryString.update_prog_check_query(name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second, ААОсновная.comboBoxProgramms.Text)

        ElseIf type_progs_on Then

            queryString = ААОсновная.program__sqlQueryString.update_typeProgs_check_query(Convert.ToString(ААОсновная.program.struct_progs.program_kod), Convert.ToString(values.kod), values.element_first)

        Else

            queryString = ААОсновная.program__sqlQueryString.update_check_query(number_column, name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second)

        End If

        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return
        End If

        If programm_on Then

            queryString = ААОсновная.program__sqlQueryString.update_prog_update_query(name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second, values.kod)

        ElseIf type_progs_on Then

            queryString = ААОсновная.program__sqlQueryString.update_typeProgs_update_query(Convert.ToString(ААОсновная.program.struct_progs.program_kod), Convert.ToString(values.kod), Convert.ToString(values.element_first))

        Else

            queryString = ААОсновная.program__sqlQueryString.update_update_query(number_column, name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second, values.kod)

        End If

        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)

    End Sub

    Private Sub saveRow()

        Dim resAr() As String

        If programm_on Then

            queryString = ААОсновная.program__sqlQueryString.update_prog_check_query(name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second, ААОсновная.comboBoxProgramms.Text)

        ElseIf type_progs_on Then

            Return

        Else

            queryString = ААОсновная.program__sqlQueryString.update_check_query(number_column, name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second)

        End If

        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return
        End If

        If programm_on Then

            queryString = ААОсновная.program__sqlQueryString.update_prog_insert_query(number_column, name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second, ААОсновная.comboBoxProgramms.Text)

        Else

            queryString = ААОсновная.program__sqlQueryString.update_insert_query(number_column, name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second)

        End If


        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)

        If programm_on Then

            queryString = ААОсновная.program__sqlQueryString.update_prog_load_kod_query(name_table, names.db_element_first, values.element_first, ААОсновная.comboBoxProgramms.Text)

        Else

            queryString = ААОсновная.program__sqlQueryString.update_load_kod_query(number_column, name_table, names.db_element_first, values.element_first, names.db_element_second, values.element_second)

        End If

        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        values.kod = resAr(0)

    End Sub

    Private Sub selectRowInList(kod As Int64, columnNumber As Int16)

        Dim numberRow As Integer = -1
        If kod = -1 Then
            Return
        End If
        numberRow = dataGridViewSearchRow(DataGridTablesResult.Rows, columnNumber, Convert.ToString(kod))
        DataGridTablesResult.CurrentCell = DataGridTablesResult.Rows(numberRow).Cells(numberElementFirst)
        DataGridTablesResult.Rows(numberRow).Cells(numberElementFirst).Selected = True

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

        bild_table()
        redactor_element_second.Dock = DockStyle.Fill

    End Sub

    Private Sub Tables_control_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter

        ActiveControl = DataGridTablesResult
        flag_active_control = True

        If programm_on Then

            ААОсновная.progsIndicator.Image = ААОсновная.ImageList1.Images(9)

        End If

    End Sub

    Private Sub Tables_control_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave

        flag_active_control = False

        If programm_on Then

            ААОсновная.progsIndicator.Image = ААОсновная.ImageList1.Images(8)

        End If

    End Sub

    Private Sub response_programms()

        If DataGridTablesResult.SelectedRows.Count > 0 Then

            ААОсновная.programs__loadModulsInProgramm()

        End If

    End Sub

    Private Sub DataGridTablesResult_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridTablesResult.SelectionChanged

        If programm_on Then

            If IsNothing(DataGridTablesResult.CurrentCell) Then
                Return
            End If

            selected_row = DataGridTablesResult.Rows(DataGridTablesResult.CurrentCell.RowIndex)
            response_programms()

        End If

    End Sub

    Private Sub Tables_control_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
    End Sub

    Private Sub second_element_keyPress(e As KeyPressEventArgs)

        Dim second_element As Control = redactor_element_second

        If flag_second_control_combo Then

            second_element = comboBox_second_element

        End If

        If Not second_element.Focused Then

            Return

        End If

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            If flag_second_control_combo And comboBox_second_element.my_ComboBox.DroppedDown Then

                Return

            End If

            If redactor_element_first.Text.Trim = "" Then

                e.Handled = True
                Return

            End If

            values.element_first = redactor_element_first.Text.Trim
            values.element_second = redactor_element_second.Text.Trim

            If flagUpdate Then

                updateRow()

            Else

                saveRow()

            End If

            load_table()

            selectRowInList(values.kod, kod_number)

            e.Handled = True

        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) Or e.KeyChar = Convert.ToChar(Keys.Down) Then

            ActiveControl = DataGridTablesResult
            e.Handled = True

        End If

    End Sub

    'Private Sub DataGridTablesResult_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridTablesResult.CurrentCellChanged

    '    Dim currentRow As DataGridViewRow

    '    If IsNothing(DataGridTablesResult.CurrentCell) Then

    '        Return

    '    End If

    '    currentRow = DataGridTablesResult.Rows(DataGridTablesResult.CurrentCell.RowIndex)

    '    For Each cell As DataGridViewCell In currentRow.Cells

    '        DataGridTablesResult.Rows(DataGridTablesResult.CurrentCell.RowIndex).Cells(0).Style.BackColor = SystemColors.ControlLight

    '    Next

    'End Sub

    'Private Sub DataGridTablesResult_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridTablesResult.CellLeave

    '    Dim currentRow As DataGridViewRow

    '    currentRow = DataGridTablesResult.Rows(DataGridTablesResult.CurrentCell.RowIndex)

    '    For Each cell As DataGridViewCell In currentRow.Cells

    '        DataGridTablesResult.Rows(DataGridTablesResult.CurrentCell.RowIndex).Cells(0).Style.BackColor = SystemColors.Window

    '    Next

    'End Sub
End Class

Public Structure Values

    Dim kod As Int64
    Dim element_first As String
    Dim element_second As String

End Structure

Public Structure Names

    Dim redactor_element_first As String
    Dim redactor_element_second As String
    Dim db_element_first As String
    Dim db_element_second As String

End Structure
