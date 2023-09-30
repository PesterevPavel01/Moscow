Public Class myButton

    Public prevControl As Control
    Public nextControl As Control

    Private Sub button_Enter(sender As Object, e As EventArgs) Handles button.Enter
        button.BackColor = SystemColors.ControlLight
    End Sub

    Private Sub button_Leave(sender As Object, e As EventArgs) Handles button.Leave
        button.BackColor = SystemColors.Window
    End Sub

    Private Sub button_KeyDown(sender As Object, e As KeyEventArgs) Handles button.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                prevControl.Focus()
            Case Keys.Down
                nextControl.Focus()
                e.Handled = True
        End Select
    End Sub

    Private Sub button_KeyPress(sender As Object, e As KeyPressEventArgs) Handles button.KeyPress

    End Sub

    Private Sub button_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles button.PreviewKeyDown
        e.IsInputKey = True
    End Sub
End Class
