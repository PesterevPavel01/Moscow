Public Class АОценкиИА

    Public kodGroup As Integer

    Public Sub loadTables()

        Dim Список
        Dim СтрокаЗапроса As String
        Dim Счетчик As Integer = 0, СчетчикСтрок As Integer

        ТаблицаОценкиИА.Rows.Clear()

        СтрокаЗапроса = loadIA(kodGroup)

        Список = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Список(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            ОткрытьФорму(предупреждение)
            ActiveControl = ТаблицаОценкиИА
            Exit Sub

        End If
        АДействияСОценкиИА.ЗаписатьСписокСлушателей(Список)
        СчетчикСтрок = UBound(Список, 2)

        ТаблицаОценкиИА.Rows.Add(UBound(Список, 2) + 1)

        While Счетчик <= UBound(Список, 2)

            ТаблицаОценкиИА.Rows(Счетчик).Cells(0).Value = CStr(Счетчик + 1)
            ТаблицаОценкиИА.Rows(Счетчик).Cells(1).Value = CStr(Список(0, Счетчик))

            ТаблицаОценкиИА.Rows(Счетчик).Cells(2).Value = CStr(Список(1, Счетчик))
            ТаблицаОценкиИА.Rows(Счетчик).Cells(3).Value = CStr(Список(2, Счетчик))
            ТаблицаОценкиИА.Rows(Счетчик).Cells(4).Value = CStr(Список(3, Счетчик))

            Счетчик = Счетчик + 1

        End While

        ActiveControl = ТаблицаОценкиИА
    End Sub

    Private Sub Группа_Click(sender As Object, e As EventArgs) Handles НомерГруппы.Click

        ФормаСписок.ListViewСписок.Columns(0).Width = 120
        ФормаСписок.ListViewСписок.Columns.Add("Год", 100)
        ФормаСписок.ListViewСписок.Columns.Add("Код", 100)
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()
        ФормаСписок.ListViewСписок.Columns.RemoveAt(1)
        ФормаСписок.ListViewСписок.Columns.RemoveAt(2)
        ФормаСписок.ListViewСписок.Columns(1).Width = 50
        ФормаСписок.ListViewСписок.Columns(1).Width = 620
        ФормаСписок.ListViewСписок.Columns(1).Text = "Наименование"

        loadTables()
    End Sub

    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click
        ActiveControl = Button1

        If АДействияСОценкиИА.проверка(ТаблицаОценкиИА) Then

            Exit Sub

        End If

        АДействияСОценкиИА.СохранитьОценки(ТаблицаОценкиИА, kodGroup)

    End Sub

    Private Sub Группа_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерГруппы.KeyDown
        If e.KeyCode = 13 Then

            Call Группа_Click(sender, e)

        End If
    End Sub

    Private Sub Сохранить_GotFocus(sender As Object, e As EventArgs) Handles Сохранить.GotFocus
        Call Интерфейс.ШрифтКонтрола(Сохранить, 14.0F)
    End Sub

    Private Sub Сохранить_LostFocus(sender As Object, e As EventArgs) Handles Сохранить.LostFocus
        Call Интерфейс.ШрифтКонтрола(Сохранить, 11.0F)
    End Sub

    Private Sub ЗагрузитьИнформацию_GotFocus(sender As Object, e As EventArgs) Handles ЗагрузитьИнформацию.GotFocus
        Call Интерфейс.ШрифтКонтрола(ЗагрузитьИнформацию, 14.0F)
    End Sub

    Private Sub ЗагрузитьИнформацию_LostFocus(sender As Object, e As EventArgs) Handles ЗагрузитьИнформацию.LostFocus
        Call Интерфейс.ШрифтКонтрола(ЗагрузитьИнформацию, 11.0F)
    End Sub

    Private Sub АОценкиИА_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ЗакрытьEsc(Me, e.KeyCode)
    End Sub

End Class