﻿Public Class Grades_events

    Public resultTable As DataGridView
    Public header As ToolStrip
    Public groupNumber As ToolStripTextBox
    Public saveButton As ToolStripButton
    Public currentForm As Form
    Public kodGroup As Integer

    Public flagCellEvent = False
    Private flagDropDown = False
    Private initializationСompleted As Boolean = False
    Private flagMouse As Boolean
    Private locate As String
    Private flagMouseClick As Boolean = False

    Public Sub init()

        If initializationСompleted Then Return
        initializationСompleted = True

        groupNumber.ReadOnly = True

        AddHandler currentForm.Shown, Sub()
                                          headerFocus()
                                      End Sub

        AddHandler currentForm.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                            formKeyDown(e, sender)
                                        End Sub

        AddHandler currentForm.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                   e.IsInputKey = True
                                                   formPreviewKeyDown(e, sender)
                                               End Sub

        AddHandler groupNumber.Click, Sub(sender As Object, e As EventArgs)
                                          groupNumberClick()
                                      End Sub

        AddHandler saveButton.Click, Sub(sender As Object, e As EventArgs)
                                         save_Click()
                                     End Sub

        AddHandler header.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                              If e.KeyCode = Keys.Enter Then e.IsInputKey = True
                                          End Sub

        AddHandler header.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                       headerKeyDown(e, sender)
                                   End Sub

        AddHandler resultTable.Enter, Sub()
                                          resultTable_Enter()
                                      End Sub

        AddHandler resultTable.CellMouseMove, Sub(sender As Object, e As DataGridViewCellMouseEventArgs)
                                                  flagMouse = True
                                                  locate = Convert.ToString(e.RowIndex) + Convert.ToString(e.ColumnIndex)
                                              End Sub
        AddHandler resultTable.CellMouseLeave, Sub()
                                                   flagMouse = False
                                                   locate = ""
                                               End Sub
        AddHandler resultTable.CellEnter, Sub(sender As Object, e As DataGridViewCellEventArgs)
                                              If Not flagMouse Then
                                                  flagMouseClick = False
                                                  Return
                                              End If
                                              If locate = Convert.ToString(e.RowIndex) + Convert.ToString(e.ColumnIndex) Then
                                                  flagMouseClick = True
                                              Else
                                                  flagMouseClick = False
                                              End If
                                          End Sub

        If currentForm.Name = "WorkerReport" Then
            AddHandler resultTable.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                textBoxCell_KeyDown(e)
                                            End Sub

        End If


    End Sub

    Private Sub resultTable_addCellHandler()

        Dim s As String = ""

        If flagCellEvent Then Return

        Dim count As Int16 = resultTable.Rows.Count

        If resultTable.Rows.Count < 1 Then Return

        For Each cell As DataGridViewCell In resultTable.Rows(0).Cells.OfType(Of System.Windows.Forms.DataGridViewComboBoxCell)

            Dim type As String = cell.GetType.ToString

            If cell.GetType.ToString = "System.Windows.Forms.DataGridViewComboBoxCell" Then

                resultTable.CurrentCell = cell
                resultTable.BeginEdit(True)

                If IsNothing(resultTable.EditingControl) Then
                    Continue For
                End If

                Dim combo As New ComboBox
                combo = CType(resultTable.EditingControl, ComboBox)

                AddHandler combo.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                              combo_KeyDown(combo, e, resultTable.CurrentCell)
                                          End Sub
                AddHandler combo.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                               combo_KeyPress(combo, e)
                                           End Sub
                AddHandler combo.DropDown, Sub(sender As Object, e As EventArgs)
                                               flagDropDown = True
                                           End Sub
                AddHandler combo.DropDownClosed, Sub(sender As Object, e As EventArgs)
                                                     flagDropDown = False
                                                 End Sub
                AddHandler combo.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                     e.IsInputKey = True
                                                 End Sub
                AddHandler combo.Enter, Sub()
                                            If flagMouseClick Then
                                                combo.DroppedDown = True
                                            End If
                                        End Sub
                flagCellEvent = True
                Exit For
            End If

        Next

        For Each cell As DataGridViewCell In resultTable.Rows(0).Cells.OfType(Of System.Windows.Forms.DataGridViewComboBoxCell)
            resultTable.CurrentCell = cell
            resultTable.BeginEdit(True)

            If IsNothing(resultTable.EditingControl) Then
                Continue For
            End If
            Dim combo As New ComboBox
            combo = CType(resultTable.EditingControl, ComboBox)
        Next

        flagCellEvent = True
    End Sub

    Private Sub textBoxCell_KeyDown(e As KeyEventArgs)
        Dim typeCell As String
        Dim s As String
        If IsNothing(resultTable.CurrentCell) Then Return
        If resultTable.CurrentCell.RowIndex = resultTable.RowCount - 1 Then Return
        typeCell = resultTable.CurrentCell.GetType.ToString
        s = e.KeyCode.ToString

        If typeCell = "System.Windows.Forms.DataGridViewTextBoxCell" Then

            If (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) Or (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) Or e.KeyCode = Keys.Decimal Then

                If Len(resultTable.CurrentCell.Value) = 1 And resultTable.CurrentCell.Value = "0" Then resultTable.CurrentCell.Value = ""
                resultTable.CurrentCell.Value += Convert.ToString(e.KeyCode.ToString.Replace("NumPad", "").Replace("Decimal", ",").Replace("D", ""))

            ElseIf e.KeyCode = Keys.Back Then

                If resultTable.CurrentCell.Value = "" Then Return
                resultTable.CurrentCell.Value = Left(resultTable.CurrentCell.Value, Len(resultTable.CurrentCell.Value) - 1)

            ElseIf e.KeyCode = 188 Or e.KeyCode = 190 Then

                resultTable.CurrentCell.Value += ","

            End If
        End If

    End Sub

    Private Sub resultTable_Enter()
        If resultTable.Rows.Count < 1 Or groupNumber.Text.Trim = "" Then
            headerFocus()
            Return
        End If
    End Sub

    Private Sub groupNumberClick()
        Select Case currentForm.Name
            Case "Grades"
                gradesGroupNumberClick()
            Case "GradesIA"
                gradesGroupNumberClick()
            Case "WorkerReport"
                gradesGroupNumberClick()
        End Select
    End Sub

    Private Sub save_Click()

        Select Case currentForm.Name
            Case "Grades"
                gradesSaveClick()
            Case "GradesIA"
                gradesIASaveClick()
            Case "WorkerReport"
                WorkerReport.save_Click()
        End Select

    End Sub

    Private Sub gradesIASaveClick()
        If gradesIAMAnipulation.check(resultTable) Then
            headerFocus()
            Return
        End If
        gradesIAMAnipulation.saveVal(resultTable, kodGroup)
        headerFocus()
    End Sub

    Private Sub gradesSaveClick()
        If gradesManipulation.check(resultTable) Then
            headerFocus()
            Return
        End If
        gradesManipulation.saveVal(resultTable, kodGroup)
        headerFocus()
    End Sub

    Private Sub combo_KeyPress(combo As ComboBox, e As KeyPressEventArgs)

        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Tab)
                e.Handled = True
                headerFocus()
        End Select


    End Sub

    Private Sub combo_KeyDown(combo As ComboBox, e As KeyEventArgs, sender As DataGridViewCell)

        Select Case e.KeyCode
            Case Keys.Enter
                combo.DroppedDown = Not combo.DroppedDown
                e.Handled = True
            Case Keys.Escape
                combo.DroppedDown = False
                resultTable.BeginEdit(False)
                e.Handled = True
            Case Keys.Up
                comboPressUp(combo, e, sender)
            Case Keys.Down
                comboPressDown(combo, e, sender)
        End Select


    End Sub

    Private Sub comboPressUp(combo As ComboBox, e As KeyEventArgs, sender As DataGridViewCell)

        If combo.DroppedDown = True Then Return

        If sender.RowIndex = 0 Then
            headerFocus()
            e.Handled = True
            Return
        End If
        resultTable.CurrentCell = resultTable.Rows(sender.RowIndex - 1).Cells(sender.ColumnIndex)
        e.Handled = True

    End Sub

    Private Sub comboPressDown(combo As ComboBox, e As KeyEventArgs, sender As DataGridViewCell)

        If combo.DroppedDown = True Then Return

        If sender.RowIndex = resultTable.Rows.Count - 1 Then
            headerFocus()
            e.Handled = True
            Return
        End If

        resultTable.CurrentCell = resultTable.Rows(sender.RowIndex + 1).Cells(sender.ColumnIndex)
        e.Handled = True

    End Sub

    Private Sub gradesGroupNumberClick()

        List.resultList.Columns(0).Width = 120
        List.resultList.Columns.Add("Год", 100)
        List.resultList.Columns.Add("Код", 100)
        List.textboxName = "groupNumber"
        List.currentFormName = currentForm.Name

        Grades.myEvents.kodGroup = -1

        List.ShowDialog()

        List.resultList.Columns.RemoveAt(1)
        List.resultList.Columns.RemoveAt(2)
        List.resultList.Columns(1).Width = 50
        List.resultList.Columns(1).Width = 620
        List.resultList.Columns(1).Text = "Наименование"

        resultTable.Visible = False

        If kodGroup <> -1 Then

            Select Case currentForm.Name
                Case "Grades"
                    Grades.loadTables()
                Case "GradesIA"
                    GradesIA.loadTables()
                Case "WorkerReport"
                    WorkerReport.loadTables()
            End Select

            resultTable_addCellHandler()

        End If

        resultTable.Visible = True

        If currentForm.Name = "WorkerReport" And resultTable.Rows.Count > 0 Then
            resultTable.CurrentCell = resultTable.Rows(0).Cells(1)
            resultTable.Focus()
        Else
            If resultTable.Rows.Count < 1 Then
                headerFocus()
            Else
                resultTable.CurrentCell = resultTable.Rows(0).Cells(0)
                resultTable.Focus()
            End If
        End If


    End Sub

    Private Sub formPreviewKeyDown(e As PreviewKeyDownEventArgs, sender As Object)

        If Not flagDropDown Then
            closeEsc(currentForm, e.KeyCode)
        End If

    End Sub

    Private Sub headerKeyDown(e As KeyEventArgs, sender As Object)

        gradesPressDown(e)
        gradesPressUp(e)
        gradesPressTab(e)
        gradesPressRight(e)
        gradesPressLeft(e)

        If Not flagDropDown Then
            closeEsc(currentForm, e.KeyCode)
        End If

    End Sub

    Private Sub formKeyDown(e As KeyEventArgs, sender As Object)

        gradesPressDown(e)
        gradesPressUp(e)
        gradesPressTab(e)
        gradesPressEnter(e)
        gradesPressRight(e)

        If e.KeyCode = Keys.F Then
            header.Focus()
            groupNumber.Focus()
        End If

        If Not flagDropDown Then
            closeEsc(currentForm, e.KeyCode)
        End If

    End Sub
    Private Sub gradesPressLeft(e As KeyEventArgs)

        If e.KeyCode = Keys.Left Then
            If saveButton.Selected Then
                header.Focus()
                groupNumber.Focus()
            End If
        End If
    End Sub
    Private Sub gradesPressRight(e As KeyEventArgs)

        If e.KeyCode = Keys.Right Then
            If groupNumber.Focused Then
                header.Focus()
                saveButton.Select()
            End If
        End If
    End Sub

    Private Sub gradesPressEnter(e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then

            If resultTable.Focused Then

            ElseIf saveButton.Selected Then
                save_Click()
            ElseIf groupNumber.Focused Then
                e.SuppressKeyPress = True
                e.Handled = True
                gradesGroupNumberClick()
            End If
        End If

    End Sub

    Private Sub gradesPressTab(e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            If resultTable.Focused Then
                headerFocus()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub gradesPressUp(e As KeyEventArgs)

        If e.KeyCode = Keys.Up Then
            If resultTable.Focused Then
                If rowSelected(resultTable.Rows(0).Cells) Then headerFocus()
                Return
            ElseIf header.Focused Or groupNumber.Focused Or saveButton.Selected Or groupNumber.Text.Trim = "" Then
                If resultTable.Rows.Count < 1 Or groupNumber.Text.Trim = "" Then
                    headerFocus()
                    Return
                End If
                resultTable.Focus()
            End If
        End If

    End Sub

    Private Function rowSelected(row As DataGridViewCellCollection) As Boolean
        For Each cell As DataGridViewCell In row
            If cell.Selected Then Return True
        Next
        Return False
    End Function

    Private Sub gradesPressDown(e As KeyEventArgs)

        If e.KeyCode = Keys.Down Then
            If resultTable.Focused Then

                Return

            ElseIf header.Focused Or groupNumber.Focused Or saveButton.Selected Or groupNumber.Text.Trim = "" Then
                If resultTable.Rows.Count < 1 Or groupNumber.Text.Trim = "" Then
                    headerFocus()
                    Return
                End If
                resultTable.Focus()
            End If
        End If

    End Sub

    Public Sub headerFocus()
        header.Focus()
        groupNumber.Focus()
    End Sub

End Class
