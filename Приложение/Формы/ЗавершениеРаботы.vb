Imports System.ComponentModel

Public Class ЗавершениеРаботы

    Private Sub ЗавершениеРаботы_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If РазрешитьЗавершениеРаботы = False Then

            e.Cancel = True

        End If
    End Sub

End Class