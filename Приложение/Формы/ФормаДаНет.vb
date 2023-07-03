Public Class ФормаДаНет
    Private Sub КнопкаДа_Click(sender As Object, e As EventArgs) Handles КнопкаДа.Click
        ЗаписьВБазу.УдалитьСовпадения = True
        Me.Close()
    End Sub

    Private Sub КнопкаНет_Click(sender As Object, e As EventArgs) Handles КнопкаНет.Click
        Me.Close()
    End Sub

    Private Sub ФормаДаНет_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Call ЗакрытьEsc(Me, e.KeyCode)
        Call функционалТаб(e.KeyCode, 40)
        Call функционалТаб(e.KeyCode, 39)
        Call перемещениеВверх(Me, e.KeyCode)
    End Sub

    Private Sub КнопкаДа_GotFocus(sender As Object, e As EventArgs) Handles КнопкаДа.GotFocus

        Интерфейс.ШрифтКонтрола(КнопкаДа, 14.0F)

    End Sub

    Private Sub КнопкаДа_LostFocus(sender As Object, e As EventArgs) Handles КнопкаДа.LostFocus

        Интерфейс.ШрифтКонтрола(КнопкаДа, 8.0F)

    End Sub

    Private Sub КнопкаНет_GotFocus(sender As Object, e As EventArgs) Handles КнопкаНет.GotFocus

        Интерфейс.ШрифтКонтрола(КнопкаНет, 14.0F)

    End Sub

    Private Sub КнопкаНет_LostFocus(sender As Object, e As EventArgs) Handles КнопкаНет.LostFocus

        Интерфейс.ШрифтКонтрола(КнопкаНет, 8.0F)

    End Sub
End Class