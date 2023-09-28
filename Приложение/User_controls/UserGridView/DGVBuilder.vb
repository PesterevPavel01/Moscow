
Public Class DGVBuilder

    Public userDGV As Tables_control

    Public columnWidht As Dictionary(Of Int16, Int16)
    Public columnAlignment As Dictionary(Of Int16, DataGridViewContentAlignment)

    Public table As DataGridView
    Public parent As Control



    Public Sub resizeTables()

        If IsNothing(table.DataSource) Then
            Return
        ElseIf table.Columns.Count < 2 Then
            Return
        End If

        Dim count As Int16 = 0

        For Each column As DataGridViewColumn In table.Columns

            If columnWidht(count) = 0 Then Return
            table.Columns(count).Width = parent.Width * columnWidht(count) / 100
            table.Columns(count).DefaultCellStyle.Alignment = columnAlignment(count)
            table.Columns(count).HeaderCell.Style.Alignment = columnAlignment(count)
            count += 1

        Next

    End Sub

    Public Sub build_table()

        Dim number_col As Int16 = 0

        For Each dataGridViewColumn In userDGV.DataGridTablesResult.Columns

            If userDGV.width_column.Count < 1 Then Return

            If userDGV.width_column(number_col) <> -1 Then

                dataGridViewColumn.Width = userDGV.DataGridTablesResult.Width * userDGV.width_column(number_col) / 100
                dataGridViewColumn.DefaultCellStyle.Alignment = userDGV.aligment_column(number_col)

                If userDGV.width_column(number_col) = 0 Then dataGridViewColumn.Visible = False

                If number_col = userDGV.width_column.Count Then

                    Dim width As Int16 = 0

                    For Each ithem In userDGV.width_column
                        If ithem.Key = 0 Then Continue For
                        width += ithem.Value
                    Next
                    userDGV.DataGridTablesResult.Columns(0).Width = userDGV.DataGridTablesResult.Width
                    userDGV.DataGridTablesResult.Columns(0).Width -= userDGV.DataGridTablesResult.Width / (100 - width)

                    If (userDGV.DataGridTablesResult.DisplayedRowCount(True) = userDGV.DataGridTablesResult.Rows.Count) Then userDGV.DataGridTablesResult.Columns(0).Width -= 5

                End If

            End If

            number_col += 1

        Next

    End Sub

    Public Sub redactorOpen_update()

        If userDGV.DataGridTablesResult.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(userDGV.DataGridTablesResult.Rows(0).Cells(userDGV.numberElementFirst).Value) = "" And userDGV.name_table <> "group_list" Then
            Return
        End If

        Dim curNumber = userDGV.DataGridTablesResult.CurrentCell.RowIndex

        readValues()
        redactorOpen()
        updateRedactor()

    End Sub

    Private Sub updateRedactor()

        If userDGV.flag_first_control_combo Then
            userDGV.comboBox_first_element.my_ComboBox.Text = userDGV.values.element_first
            userDGV.comboBox_first_element.set_color(Color.AliceBlue)
        Else
            userDGV.redactor_element_first.Text = userDGV.values.element_first
            userDGV.redactor_element_first.BackColor = Color.AliceBlue
        End If

        If userDGV.flag_second_control_combo Then
            userDGV.comboBox_second_element.my_ComboBox.Text = userDGV.values.element_second
            userDGV.comboBox_second_element.set_color(Color.AliceBlue)
        Else
            userDGV.redactor_element_second.Text = userDGV.values.element_second
            userDGV.redactor_element_second.BackColor = Color.AliceBlue
        End If

    End Sub

    Private Sub readValues()

        Dim curNumber = userDGV.DataGridTablesResult.CurrentCell.RowIndex

        If userDGV.name_table = "group_list" Then
            userDGV.values.snils = addMask.deleteMask(Convert.ToString(userDGV.DataGridTablesResult.Rows(curNumber).Cells(userDGV.kod_number).Value))
            userDGV.values.kod = userDGV.values.snils
        Else
            userDGV.values.kod = userDGV.DataGridTablesResult.Rows(curNumber).Cells(userDGV.kod_number).Value
        End If

        If IsNumeric(userDGV.values.kod) Then
            userDGV.values.element_first = Convert.ToString(userDGV.DataGridTablesResult.Rows(curNumber).Cells(userDGV.numberElementFirst).Value)
            userDGV.values.element_second = Convert.ToString(userDGV.DataGridTablesResult.Rows(curNumber).Cells(userDGV.numberElementSecond).Value)
        Else
            Return
        End If

    End Sub

    Public Sub redactorOpen()

        clearRedactor()

        redactor_setWhiteColor()

        userDGV.SplitContainer_main.Panel2Collapsed = False

        redactor_firstControl_focus()

        userDGV.flagUpdate = True

    End Sub

    Public Sub redactorClose()

        If userDGV.comboBox_first_element.flag_comboDroppedDown Or userDGV.comboBox_second_element.flag_comboDroppedDown Then

            userDGV.comboBox_first_element.flag_comboDroppedDown = False
            userDGV.comboBox_second_element.flag_comboDroppedDown = False
            Return

        End If

        userDGV.active_last_element = True
        userDGV.SplitContainer_main.Panel2Collapsed = True

        userDGV.DataGridTablesResult.Focus()
        userDGV.ActiveControl = userDGV.DataGridTablesResult

        userDGV.flagUpdate = False

    End Sub

    Public Sub redactor_firstControl_focus()

        If userDGV.flag_first_control_combo Then
            userDGV.comboBox_first_element.Focus()

        Else
            userDGV.redactor_element_first.Focus()
            userDGV.redactor_element_first.Select(userDGV.redactor_element_first.Text.Length, 0)
        End If

    End Sub

    Private Sub redactor_setWhiteColor()

        If userDGV.flag_first_control_combo Then
            userDGV.comboBox_first_element.set_color(Color.White)
        Else
            userDGV.redactor_element_first.BackColor = Color.White
        End If

        If userDGV.width_column(1) <> -1 Then

            If userDGV.flag_second_control_combo Then
                userDGV.comboBox_second_element.set_color(Color.White)
            Else
                userDGV.redactor_element_second.BackColor = Color.White
            End If

        End If

    End Sub

    Private Sub clearRedactor()

        If userDGV.flag_first_control_combo Then

            userDGV.comboBox_first_element.my_ComboBox.SelectedIndex = 0

        Else

            userDGV.redactor_element_first.Clear()

        End If

        If userDGV.flag_second_control_combo Then

            userDGV.comboBox_second_element.my_ComboBox.SelectedIndex = 0

        Else

            userDGV.redactor_element_second.Clear()

        End If

    End Sub

End Class
