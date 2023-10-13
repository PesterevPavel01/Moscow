Public Class myButton
    Public mainForm As Boolean = False
    Public prevControl As Control
    Public nextControl As Control
    Public leftControl As Control

    Private Sub button_Enter(sender As Object, e As EventArgs) Handles button.Enter

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
            Case Keys.Left
                If IsNothing(leftControl) Then Return
                leftControl.Focus()
                e.Handled = True
            Case Keys.Enter
                button.PerformClick()

        End Select
    End Sub

    Private Sub button_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles button.PreviewKeyDown
        e.IsInputKey = True
    End Sub
End Class
