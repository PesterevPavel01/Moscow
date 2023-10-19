
Public Class sortSettsGroup
    Private Sub НастройкаСортировкиГрупп_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        GroupList.search()

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

    Private Sub sortSettsGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Close()

        End Select

    End Sub

End Class