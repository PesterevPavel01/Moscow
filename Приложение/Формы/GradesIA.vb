Public Class GradesIA

    Public kodGroup As Integer = -1

    Public Sub loadTables()

        Dim list
        Dim queryString As String
        Dim counter As Integer = 0, counterRows As Integer

        iaTAble.Rows.Clear()

        queryString = loadIA(kodGroup)

        list = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If list(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ActiveControl = iaTAble
            Exit Sub

        End If
        АДействияСОценкиИА.ЗаписатьСписокСлушателей(list)
        counterRows = UBound(list, 2)

        iaTAble.Rows.Add(UBound(list, 2) + 1)

        While counter <= UBound(list, 2)

            iaTAble.Rows(counter).Cells(0).Value = CStr(counter + 1)
            iaTAble.Rows(counter).Cells(1).Value = CStr(list(0, counter))

            iaTAble.Rows(counter).Cells(2).Value = CStr(list(1, counter))
            iaTAble.Rows(counter).Cells(3).Value = CStr(list(2, counter))
            iaTAble.Rows(counter).Cells(4).Value = CStr(list(3, counter))

            counter = counter + 1

        End While

        ActiveControl = iaTAble

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

    Private Sub groupNumber_Click(sender As Object, e As EventArgs) Handles groupNumber.Click
        List.resultList.Columns(0).Width = 120
        List.resultList.Columns.Add("Год", 100)
        List.resultList.Columns.Add("Код", 100)
        List.textboxName = "groupNumber"
        List.currentFormName = Name

        kodGroup = -1

        List.ShowDialog()
        List.resultList.Columns.RemoveAt(1)
        List.resultList.Columns.RemoveAt(2)
        List.resultList.Columns(1).Width = 50
        List.resultList.Columns(1).Width = 620
        List.resultList.Columns(1).Text = "Наименование"

        If kodGroup <> -1 Then

            loadTables()

        End If
    End Sub

    Private Sub groupNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles groupNumber.KeyDown
        If e.KeyCode = Keys.Enter Then

            groupNumber_Click(sender, e)

        End If
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        ActiveControl = Button1

        If АДействияСОценкиИА.check(iaTAble) Then

            Exit Sub

        End If

        АДействияСОценкиИА.СохранитьОценки(iaTAble, kodGroup)
    End Sub
End Class