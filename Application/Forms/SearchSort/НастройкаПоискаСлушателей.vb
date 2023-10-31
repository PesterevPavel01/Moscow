Imports System.ComponentModel

Public Class НастройкаПоискаСлушателей
    Private Sub Снилс_CheckedChanged(sender As Object, e As EventArgs) Handles Снилс.CheckedChanged

        If Снилс.Checked = True Then

            interfaceMod.enableOneCheckbox(Me, Снилс.Name)

        End If
        If Снилс.Checked = False Then

            If Not interfaceMod.statusCheckBoxes(Me) Then

                Снилс.Checked = True

            End If

        End If


    End Sub

    Private Sub Имя_CheckedChanged(sender As Object, e As EventArgs) Handles Имя.CheckedChanged

        If Имя.Checked = True Then

            interfaceMod.enableOneCheckbox(Me, Имя.Name)

        End If

        If Имя.Checked = False Then

            If Not interfaceMod.statusCheckBoxes(Me) Then

                Имя.Checked = True

            End If

        End If



    End Sub

    Private Sub Отчество_CheckedChanged(sender As Object, e As EventArgs) Handles Отчество.CheckedChanged

        If Отчество.Checked = True Then

            interfaceMod.enableOneCheckbox(Me, Отчество.Name)

        End If

        If Отчество.Checked = False Then

            If Not interfaceMod.statusCheckBoxes(Me) Then

                Отчество.Checked = True

            End If

        End If

    End Sub

    Private Sub Фамилия_CheckedChanged(sender As Object, e As EventArgs) Handles Фамилия.CheckedChanged

        If Фамилия.Checked = True Then

            interfaceMod.enableOneCheckbox(Me, Фамилия.Name)

        End If

        If Фамилия.Checked = False Then

            If Not interfaceMod.statusCheckBoxes(Me) Then

                Фамилия.Checked = True

            End If

        End If

    End Sub

    Public Sub checkedAnyValue(value As String)
        Select Case value
            Case "Фамилия"
                Фамилия.Checked = True
            Case "Имя"
                Имя.Checked = True
            Case "Отчество"
                Отчество.Checked = True
            Case "Снилс"
                Снилс.Checked = True
        End Select
    End Sub

    Private Sub НастройкаПоискаСлушателей_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Close()

        End Select

    End Sub
End Class