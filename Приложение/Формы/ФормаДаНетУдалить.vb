﻿Public Class ФормаДаНетУдалить

    Public НажатаКнопкаДа As Boolean = False
    Public НажатаКнопкаНет As Boolean = False
    Private Sub КнопкаДа_Click(sender As Object, e As EventArgs) Handles КнопкаДа.Click
        НажатаКнопкаДа = True
        Me.Close()
    End Sub

    Private Sub КнопкаНет_Click(sender As Object, e As EventArgs) Handles КнопкаНет.Click
        НажатаКнопкаНет = True
        Me.Close()
    End Sub

    Private Sub ФормаДаНетУдалить_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        НажатаКнопкаДа = False
        НажатаКнопкаНет = False
    End Sub

    Private Sub КнопкаДа_GotFocus(sender As Object, e As EventArgs) Handles КнопкаДа.GotFocus

        interfaceMod.controlFont(КнопкаДа, 14.0F)

    End Sub

    Private Sub КнопкаДа_LostFocus(sender As Object, e As EventArgs) Handles КнопкаДа.LostFocus

        interfaceMod.controlFont(КнопкаДа, 8.0F)

    End Sub

    Private Sub КнопкаНет_GotFocus(sender As Object, e As EventArgs) Handles КнопкаНет.GotFocus

        interfaceMod.controlFont(КнопкаНет, 14.0F)

    End Sub

    Private Sub КнопкаНет_LostFocus(sender As Object, e As EventArgs) Handles КнопкаНет.LostFocus

        interfaceMod.controlFont(КнопкаНет, 8.0F)

    End Sub

End Class