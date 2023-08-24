Public Class sortSetts

    Public НажатПБГр As Boolean = False

    Private Sub Программа_CheckedChanged(sender As Object, e As EventArgs) Handles Программа.CheckedChanged

        Интерфейс.checkBoxReaction(Me, Программа)

    End Sub

    Private Sub Спец_CheckedChanged(sender As Object, e As EventArgs) Handles Спец.CheckedChanged

        Интерфейс.checkBoxReaction(Me, Спец)

    End Sub


    Private Sub Номер_CheckedChanged(sender As Object, e As EventArgs) Handles Номер.CheckedChanged

        Интерфейс.checkBoxReaction(Me, Номер)

    End Sub

    Private Sub ПоУбыванию_Click(sender As Object, e As EventArgs)

        PictureBox1.BorderStyle = 1
        ПоВозростанию.BorderStyle = 0

    End Sub

    Private Sub ПоВозростанию_Click(sender As Object, e As EventArgs) Handles ПоВозростанию.Click

        PictureBox1.BorderStyle = 0
        НажатПБГр = False
        ПоВозростанию.BorderStyle = 1

    End Sub

    Private Sub ПоУбыванию_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click

        PictureBox1.BorderStyle = 1
        НажатПБГр = True
        ПоВозростанию.BorderStyle = 0

    End Sub

    Private Sub НастройкаСортировкиГрупп_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        СправочникГруппы.search()

    End Sub

    Private Sub Куратор_CheckedChanged(sender As Object, e As EventArgs) Handles Куратор.CheckedChanged
        Интерфейс.checkBoxReaction(Me, Куратор)
    End Sub

    Public Sub checkedAnyValue(value As String)
        Select Case value
            Case "Номер"
                Номер.Checked = True
            Case "Специальность"
                Спец.Checked = True
            Case "Программа"
                Программа.Checked = True
            Case "Куратор"
                Куратор.Checked = True
        End Select
    End Sub

End Class