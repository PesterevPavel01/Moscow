Imports System.ComponentModel

Public Class НастройкаПоискаСлушателей
    Private Sub Снилс_CheckedChanged(sender As Object, e As EventArgs) Handles Снилс.CheckedChanged

        If Снилс.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Снилс.Name)

        End If
        If Снилс.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Снилс.Checked = True

            End If

        End If


    End Sub

    Private Sub Имя_CheckedChanged(sender As Object, e As EventArgs) Handles Имя.CheckedChanged

        If Имя.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Имя.Name)

        End If

        If Имя.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Имя.Checked = True

            End If

        End If



    End Sub

    Private Sub Отчество_CheckedChanged(sender As Object, e As EventArgs) Handles Отчество.CheckedChanged

        If Отчество.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Отчество.Name)

        End If

        If Отчество.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Отчество.Checked = True

            End If

        End If

    End Sub

    Private Sub Фамилия_CheckedChanged(sender As Object, e As EventArgs) Handles Фамилия.CheckedChanged

        If Фамилия.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Фамилия.Name)

        End If

        If Фамилия.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

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

End Class