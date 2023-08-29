Public Class sortSettsStudents

    Public sortSetts = New SorterSetts()

    Private Sub Имя_CheckedChanged(sender As Object, e As EventArgs) Handles nameStudent.CheckedChanged

        interfaceMod.checkBoxReaction(Me, nameStudent)

    End Sub

    Private Sub Снилс_CheckedChanged(sender As Object, e As EventArgs) Handles snils.CheckedChanged

        interfaceMod.checkBoxReaction(Me, snils)

    End Sub

    Private Sub Фамилия_CheckedChanged(sender As Object, e As EventArgs) Handles secName.CheckedChanged

        interfaceMod.checkBoxReaction(Me, secName)

    End Sub


    Private Sub sortUp_Click(sender As Object, e As EventArgs) Handles sortUp.Click

        sortSetts.sort("sortUpGr", "sortDown", True)

    End Sub

    Private Sub sortDown_Click(sender As Object, e As EventArgs) Handles sortDown.Click

        sortSetts.sort("sortUp", "sortDownGr", False)


    End Sub

    Private Sub НастройкаСортировкиСлушателей_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        studentsList.search()
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

    Private Sub sortSettsStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sortSetts.init(sortUp, sortDown)

    End Sub
End Class