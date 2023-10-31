Public Class user_comboBox
    Public nameParent As String
    Public settings As New Control_Settings
    Public adjacentControls = New Dictionary(Of String, Control)
    'Private flag_mous As Boolean = False
    Public flag_comboDroppedDown = False 'флаг нужен, чтобы глушить нажатие Esc, если выпадающий список раскрыт

    Public Sub my_comboBox_Init()

        If IsNothing(settings.item_list) Then

            Return

        End If

        If settings.item_list.Count > 0 Then

            my_ComboBox.Items.Clear()
            my_ComboBox.Items.Add("")
            my_ComboBox.Items.AddRange(settings.item_list)
            my_ComboBox.DropDownWidth = 200

        End If

    End Sub

    Public Sub set_color(color As Color)

        panel_control.BackColor = color
        my_ComboBox.BackColor = color

    End Sub

    'Private Sub comboBox_MouseMove(sender As Object, e As MouseEventArgs) Handles my_ComboBox.MouseMove

    '    flag_mous = True

    'End Sub

    'Private Sub comboBox_MouseLeave(sender As Object, e As EventArgs) Handles my_ComboBox.MouseLeave

    '    flag_mous = False

    'End Sub

    'Private Sub comboBox_Enter(sender As Object, e As EventArgs) Handles my_ComboBox.Enter

    '    If flag_mous Then

    '        my_ComboBox.DroppedDown = False

    '    Else

    '        my_ComboBox.DroppedDown = True

    '    End If

    'End Sub

    Private Sub my_ComboBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles my_ComboBox.PreviewKeyDown


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

        ElseIf e.KeyValue = Keys.Enter Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub user_comboBox_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter

        my_ComboBox.Focus()

    End Sub

    'нужны ссылки на методы класса, которому пренадлежат контролы (предыдущий и следующий)
    Public Sub my_ComboBox_enterDown(e As KeyEventArgs, saveKeyS As Boolean)

        If saveKeyS Then
            If my_ComboBox.DroppedDown Then
                'my_ComboBox.DroppedDown = False
                Return
            ElseIf nameParent = "group_list" Then
                groupListComboDown(e)
                e.Handled = True
            ElseIf Not MainForm.programs__progrs_tbl.redactor_element_first.Text.Trim = "" Then
                MainForm.programs__progrs_tbl.secondElement_enterDown(e)
                e.Handled = True
                Return
            End If
        Else
            If my_ComboBox.DroppedDown Then
                my_ComboBox.DroppedDown = True
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub my_ComboBox_pressEnter(e As KeyPressEventArgs)
        If my_ComboBox.DroppedDown Then
            my_ComboBox.DroppedDown = False
            Return
        ElseIf nameParent = "group_list" Then
            groupListComboPress(e)
            e.Handled = True
        ElseIf Not MainForm.programs__progrs_tbl.redactor_element_first.Text.Trim = "" Then
            MainForm.programs__progrs_tbl.secondElement_enterDown(e)
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub groupListComboDown(e As KeyEventArgs)
        For Each element As KeyValuePair(Of String, Control) In adjacentControls
            Dim control As Control = element.Value
            If control.GetType.ToString = "WindowsApp2.user_comboBox" Then

                Dim comboBox As user_comboBox = control

                If comboBox.my_ComboBox.Text.Trim = "" Then
                    Return
                End If
            End If
        Next
        StudentsInGroup.tbl_studentsInGroup.secondElement_enterDown(e)
    End Sub

    Private Sub groupListComboPress(e As KeyPressEventArgs)

        For Each element As KeyValuePair(Of String, Control) In adjacentControls

            Dim control As Control = element.Value

            If control.GetType.ToString = "WindowsApp2.user_comboBox" Then

                Dim comboBox As user_comboBox = control

                If comboBox.my_ComboBox.Text.Trim = "" Then
                    Return
                End If
            End If

        Next

        StudentsInGroup.tbl_studentsInGroup.secondElement_enterDown(e)


    End Sub

    Public Sub my_ComboBox_UpDown(e As KeyEventArgs)

        If my_ComboBox.DroppedDown Then
            Return
        End If

        If adjacentControls.count = 0 Then

            MainForm.prog_redactor_element_first_activate()

        Else
            Dim prevControl As Control
            prevControl = adjacentControls("prev")
            prevControl.Focus()
        End If
        flag_comboDroppedDown = False
        e.Handled = True
    End Sub

    Public Sub my_ComboBox_BottomDown(e As KeyEventArgs)

        If my_ComboBox.DroppedDown Then
            Return
        End If

        If adjacentControls.count = 0 Then
            MainForm.prog_DataGridTablesResult_activate()
        Else
            Dim nextControl As Control
            nextControl = adjacentControls("next")
            nextControl.Focus()
            flag_comboDroppedDown = False
        End If
        e.Handled = True
    End Sub

    Public Sub my_ComboBox_PressTab()
        If adjacentControls.count = 0 Then

            MainForm.prog_DataGridTablesResult_activate()

        Else

            Dim nextControl As Control
            nextControl = adjacentControls("next")
            nextControl.Focus()

        End If
    End Sub

End Class

Public Structure Control_Settings

    Dim item_list() As String

End Structure
