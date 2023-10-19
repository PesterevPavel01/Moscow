Public Class sortSettsStudents

    Private Sub НастройкаСортировкиСлушателей_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        StudentsList.search()


    End Sub

    Public Sub checkedAnyValue(value As String)

        Select Case value
            Case "Снилс"
                snils.Checked = True
            Case "Фамилия"
                secName.Checked = True
            Case "Имя"
                nameStudent.Checked = True
        End Select

    End Sub

    Private Sub sortSettsStudents_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Close()

        End Select

    End Sub
End Class