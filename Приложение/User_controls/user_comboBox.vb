Public Class user_comboBox

    Public settings As New Control_Settings

    Private flag_mous As Boolean = False
    Public Sub my_comboBox_Init()

        If IsNothing(settings.item_list) Then

            Return

        End If

        If settings.item_list.Count > 0 Then

            my_ComboBox.Items.Clear()
            my_ComboBox.Items.AddRange(settings.item_list)

        End If

    End Sub

    Public Sub set_color(color As Color)

        panel_control.BackColor = color
        my_ComboBox.BackColor = color

    End Sub

    Private Sub comboBox_MouseMove(sender As Object, e As MouseEventArgs) Handles my_ComboBox.MouseMove

        flag_mous = True

    End Sub

    Private Sub comboBox_MouseLeave(sender As Object, e As EventArgs) Handles my_ComboBox.MouseLeave

        flag_mous = False

    End Sub

    Private Sub comboBox_Enter(sender As Object, e As EventArgs) Handles my_ComboBox.Enter

        If flag_mous Then

            my_ComboBox.DroppedDown = False

        Else

            my_ComboBox.DroppedDown = True

        End If

    End Sub

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

    ' нужны ссылки на методы класса, которому пренадлежат контролы (предыдущий и следующий)

    Private Sub my_ComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles my_ComboBox.KeyDown

        If my_ComboBox.DroppedDown Then

            If e.KeyCode = Keys.Enter Then

                my_ComboBox.DroppedDown = True
                e.Handled = True

            End If

            Return

        End If

        If e.KeyCode = Keys.Down Then

            MainForm.prog_DataGridTablesResult_activate()

        ElseIf e.KeyCode = Keys.Up Then

            MainForm.prog_redactor_element_first_activate()

        End If

        e.Handled = True

    End Sub

    Private Sub my_ComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles my_ComboBox.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            If my_ComboBox.DroppedDown Then

                my_ComboBox.DroppedDown = False
                Return

            ElseIf Not MainForm.programs__progrs_tbl.redactor_element_first.Text.Trim = "" Then

                MainForm.programs__progrs_tbl.second_element_pressEnter(e)
                e.Handled = True
                Return

            End If

        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) Then

            MainForm.prog_DataGridTablesResult_activate()

        End If

        e.Handled = True

    End Sub

End Class

Public Structure Control_Settings

    Dim item_list() As String

End Structure
