Public Class НастройкаПоискаГрупп

    Private Sub Куратор_CheckedChanged(sender As Object, e As EventArgs) Handles Куратор.CheckedChanged
        If Куратор.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Куратор.Name)

        End If

        If Куратор.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Куратор.Checked = True

            End If

        End If
    End Sub

    Private Sub Номер_CheckedChanged(sender As Object, e As EventArgs) Handles Номер.CheckedChanged
        If Номер.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Номер.Name)

        End If

        If Номер.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Номер.Checked = True

            End If

        End If
    End Sub

    Private Sub Программа_CheckedChanged(sender As Object, e As EventArgs) Handles Программа.CheckedChanged
        If Программа.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Программа.Name)

        End If

        If Программа.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Программа.Checked = True

            End If

        End If
    End Sub

    Private Sub Специальность_CheckedChanged(sender As Object, e As EventArgs) Handles Спец.CheckedChanged
        If Спец.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Спец.Name)

        End If

        If Спец.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Спец.Checked = True

            End If

        End If
    End Sub

    Private Sub УровеньКвалификации_CheckedChanged(sender As Object, e As EventArgs) Handles Квалификация.CheckedChanged
        If Квалификация.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Квалификация.Name)

        End If

        If Квалификация.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Квалификация.Checked = True

            End If

        End If
    End Sub

    Private Sub Финансирование_CheckedChanged(sender As Object, e As EventArgs) Handles Финансирование.CheckedChanged
        If Финансирование.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Me, Финансирование.Name)

        End If

        If Финансирование.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Me) Then

                Финансирование.Checked = True

            End If

        End If
    End Sub
    Public Sub checkedAnyValue(value As String)
        Select Case value
            Case "Номер"
                Номер.Checked = True
            Case "Программа"
                Программа.Checked = True
            Case "Специальность"
                Спец.Checked = True
        End Select
    End Sub
End Class