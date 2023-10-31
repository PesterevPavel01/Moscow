Public Class ФормаДаНет
    Private Sub КнопкаДа_Click(sender As Object, e As EventArgs) Handles КнопкаДа.Click
        InsertIntoDataBase.removeDuplicates = True
        Me.Close()
    End Sub

    Private Sub КнопкаНет_Click(sender As Object, e As EventArgs) Handles КнопкаНет.Click
        Me.Close()
    End Sub

    Private Sub ФормаДаНет_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        closeEsc(Me, e.KeyCode)
        pressTab(e.KeyCode, 40)
        pressTab(e.KeyCode, 39)
        up(Me, e.KeyCode)
    End Sub

    Private Sub КнопкаДа_GotFocus(sender As Object, e As EventArgs) Handles КнопкаДа.GotFocus

        interfaceMod.controlFont(КнопкаДа, 14.0F)

    End Sub

    Private Sub КнопкаДа_LostFocus(sender As Object, e As EventArgs) Handles КнопкаДа.LostFocus

        interfaceMod.controlFont(КнопкаДа, 8.0F)

    End Sub

    Private Sub КнопкаНет_GotFocus(sender As Object, e As EventArgs) Handles КнопкаНет.GotFocus

        interfaceMod.controlFont(КнопкаНет, 14.0F)

    End Sub

    Private Sub КнопкаНет_LostFocus(sender As Object, e As EventArgs) Handles КнопкаНет.LostFocus

        interfaceMod.controlFont(КнопкаНет, 8.0F)

    End Sub
End Class