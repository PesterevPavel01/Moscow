Public Class НастройкаСортировкиСлушателей
    Public НажатПБСл As Boolean = False
    Private Sub Имя_CheckedChanged(sender As Object, e As EventArgs) Handles Имя.CheckedChanged

        Интерфейс.checkBoxReaction(Me, Имя)

    End Sub

    Private Sub Снилс_CheckedChanged(sender As Object, e As EventArgs) Handles Снилс.CheckedChanged

        Интерфейс.checkBoxReaction(Me, Снилс)

    End Sub

    Private Sub Фамилия_CheckedChanged(sender As Object, e As EventArgs) Handles Фамилия.CheckedChanged

        Интерфейс.checkBoxReaction(Me, Фамилия)

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        PictureBox1.BorderStyle = 1
        НажатПБСл = True
        ПоВозростанию.BorderStyle = 0

    End Sub

    Private Sub ПоВозростанию_Click(sender As Object, e As EventArgs) Handles ПоВозростанию.Click

        PictureBox1.BorderStyle = 0
        НажатПБСл = False
        ПоВозростанию.BorderStyle = 1

    End Sub

    Private Sub НастройкаСортировкиСлушателей_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ФормаСправочникСлушатели.ПоискПоСтрокеПоиска()
    End Sub

    Public Sub checkedAnyValue(value As String)
        Select Case value
            Case "Снилс"
                Снилс.Checked = True
            Case "Фамилия"
                Фамилия.Checked = True
            Case "Имя"
                Имя.Checked = True
        End Select
    End Sub
End Class