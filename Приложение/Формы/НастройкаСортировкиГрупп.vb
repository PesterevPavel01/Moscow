Imports System.IO

Public Class sortSettsGroup

    Public sortSetts = New SorterSetts()

    Private Sub Программа_CheckedChanged(sender As Object, e As EventArgs) Handles Программа.CheckedChanged

        interfaceMod.checkBoxReaction(Me, Программа)

    End Sub

    Private Sub Спец_CheckedChanged(sender As Object, e As EventArgs) Handles Спец.CheckedChanged

        interfaceMod.checkBoxReaction(Me, Спец)

    End Sub


    Private Sub Номер_CheckedChanged(sender As Object, e As EventArgs) Handles Номер.CheckedChanged

        interfaceMod.checkBoxReaction(Me, Номер)

    End Sub

    Private Sub sortUp_Click(sender As Object, e As EventArgs) Handles sortDown.Click

        sortSetts.sort("sortUp", "sortDownGr", False)

    End Sub

    Private Sub sortDown_Click(sender As Object, e As EventArgs) Handles sortUp.Click

        sortSetts.sort("sortUpGr", "sortDown", True)

    End Sub

    Private Sub НастройкаСортировкиГрупп_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        GroupList.search()

    End Sub

    Private Sub Куратор_CheckedChanged(sender As Object, e As EventArgs) Handles Куратор.CheckedChanged

        interfaceMod.checkBoxReaction(Me, Куратор)

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

    Private Sub sortSettsGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sortSetts.init(sortUp, sortDown)

    End Sub
End Class