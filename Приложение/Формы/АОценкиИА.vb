Public Class АОценкиИА

    Public kodGroup As Integer = -1

    Public Sub loadTables()

        Dim list
        Dim queryString As String
        Dim counter As Integer = 0, counterRows As Integer

        ТаблицаОценкиИА.Rows.Clear()

        queryString = loadIA(kodGroup)

        list = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If list(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            openForm(предупреждение)
            ActiveControl = ТаблицаОценкиИА
            Exit Sub

        End If
        АДействияСОценкиИА.ЗаписатьСписокСлушателей(list)
        counterRows = UBound(list, 2)

        ТаблицаОценкиИА.Rows.Add(UBound(list, 2) + 1)

        While counter <= UBound(list, 2)

            ТаблицаОценкиИА.Rows(counter).Cells(0).Value = CStr(counter + 1)
            ТаблицаОценкиИА.Rows(counter).Cells(1).Value = CStr(list(0, counter))

            ТаблицаОценкиИА.Rows(counter).Cells(2).Value = CStr(list(1, counter))
            ТаблицаОценкиИА.Rows(counter).Cells(3).Value = CStr(list(2, counter))
            ТаблицаОценкиИА.Rows(counter).Cells(4).Value = CStr(list(3, counter))

            counter = counter + 1

        End While

        ActiveControl = ТаблицаОценкиИА

    End Sub

    Private Sub groupNumber_Click(sender As Object, e As EventArgs) Handles groupNumber.Click

        ФормаСписок.ListViewСписок.Columns(0).Width = 120
        ФормаСписок.ListViewСписок.Columns.Add("Год", 100)
        ФормаСписок.ListViewСписок.Columns.Add("Код", 100)
        ФормаСписок.textboxName = ActiveControl.Name
        ФормаСписок.FormName = Name

        ФормаСписок.headerVisible = True
        kodGroup = -1

        ФормаСписок.ShowDialog()
        ФормаСписок.ListViewСписок.Columns.RemoveAt(1)
        ФормаСписок.ListViewСписок.Columns.RemoveAt(2)
        ФормаСписок.ListViewСписок.Columns(1).Width = 50
        ФормаСписок.ListViewСписок.Columns(1).Width = 620
        ФормаСписок.ListViewСписок.Columns(1).Text = "Наименование"

        If kodGroup <> -1 Then

            loadTables()

        End If

    End Sub

    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        ActiveControl = Button1

        If АДействияСОценкиИА.check(ТаблицаОценкиИА) Then

            Exit Sub

        End If

        АДействияСОценкиИА.СохранитьОценки(ТаблицаОценкиИА, kodGroup)

    End Sub

    Private Sub Группа_KeyDown(sender As Object, e As KeyEventArgs) Handles groupNumber.KeyDown

        If e.KeyCode = 13 Then

            Call groupNumber_Click(sender, e)

        End If

    End Sub

    Private Sub Сохранить_GotFocus(sender As Object, e As EventArgs) Handles Сохранить.GotFocus
        Call interfaceMod.controlFont(Сохранить, 14.0F)
    End Sub

    Private Sub Сохранить_LostFocus(sender As Object, e As EventArgs) Handles Сохранить.LostFocus
        Call interfaceMod.controlFont(Сохранить, 11.0F)
    End Sub

    Private Sub ЗагрузитьИнформацию_GotFocus(sender As Object, e As EventArgs) Handles ЗагрузитьИнформацию.GotFocus
        Call interfaceMod.controlFont(ЗагрузитьИнформацию, 14.0F)
    End Sub

    Private Sub ЗагрузитьИнформацию_LostFocus(sender As Object, e As EventArgs) Handles ЗагрузитьИнформацию.LostFocus
        Call interfaceMod.controlFont(ЗагрузитьИнформацию, 11.0F)
    End Sub

    Private Sub АОценкиИА_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        closeEsc(Me, e.KeyCode)
    End Sub

End Class