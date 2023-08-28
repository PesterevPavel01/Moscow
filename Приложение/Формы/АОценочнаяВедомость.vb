Public Class ОценочнаяВедомость

    Public kodGroup As Integer
    Private Sub loadTables()

        Dim list
        Dim queryString As String
        Dim counter As Integer = 0, counterRows As Integer
        Dim result As List(Of String)

        resultTable.Rows.Clear()

        queryString = loadVedomost(kodGroup)

        list = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If list(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            openForm(предупреждение)
            ActiveControl = resultTable
            Exit Sub

        End If

        queryString = select_moduls_count(kodGroup)

        result = MainForm.mySqlConnect.LoadToListString(queryString, 1, 0)

        If Not (IsNumeric(result(0)) Or result(0) = "0") Then

            предупреждение.текст.Text = "Нет данных для отображения"
            openForm(предупреждение)
            ActiveControl = resultTable
            Return

        End If

        updateDataGreed(Convert.ToInt16(result(0)))

        list = УбратьПустотыВМассиве.УбратьПустотыВМассиве(list)

        АДействияСОВедомостью.ЗаписатьСписокСлушателей(list)

        counterRows = UBound(list, 2)

        resultTable.Rows.Add(UBound(list, 2) + 1)


        While counter <= UBound(list, 2)

            resultTable.Rows(counter).Cells(0).Value = CStr(counter + 1)
            resultTable.Rows(counter).Cells(1).Value = CStr(list(0, counter))

            resultTable.Rows(counter).Cells(2).Value = CStr(list(1, counter))
            resultTable.Rows(counter).Cells(3).Value = CStr(list(2, counter))
            resultTable.Rows(counter).Cells(4).Value = CStr(list(3, counter))
            resultTable.Rows(counter).Cells(5).Value = CStr(list(4, counter))
            resultTable.Rows(counter).Cells(6).Value = CStr(list(5, counter))
            resultTable.Rows(counter).Cells(7).Value = CStr(list(6, counter))
            resultTable.Rows(counter).Cells(8).Value = CStr(list(7, counter))
            resultTable.Rows(counter).Cells(9).Value = CStr(list(8, counter))
            resultTable.Rows(counter).Cells(10).Value = CStr(list(9, counter))
            resultTable.Rows(counter).Cells(11).Value = CStr(list(10, counter))
            counter = counter + 1

        End While

        ActiveControl = resultTable

    End Sub

    Private Sub groupNumber_Click(sender As Object, e As EventArgs) Handles groupNumber.Click

        ФормаСписок.ListViewСписок.Columns(0).Width = 120
        ФормаСписок.ListViewСписок.Columns.Add("Год", 100)
        ФормаСписок.ListViewСписок.Columns.Add("Код", 100)
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name

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

    Private Sub save_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        ActiveControl = Button2

        If АДействияСОВедомостью.проверка(resultTable) Then

            Exit Sub

        End If

        АДействияСОВедомостью.СохранитьОценки(resultTable, kodGroup)

    End Sub

    Private Sub save_GotFocus(sender As Object, e As EventArgs) Handles Сохранить.GotFocus
        Call interfaceMod.controlFont(Сохранить, 14.0F)
    End Sub

    Private Sub save_LostFocus(sender As Object, e As EventArgs) Handles Сохранить.LostFocus
        interfaceMod.controlFont(Сохранить, 11.0F)
    End Sub

    Private Sub Button2_GotFocus(sender As Object, e As EventArgs) Handles Button2.GotFocus
        Call interfaceMod.controlFont(Button2, 14.0F)
    End Sub

    Private Sub Button2_LostFocus(sender As Object, e As EventArgs) Handles Button2.LostFocus
        interfaceMod.controlFont(Button2, 11.0F)
    End Sub

    Private Sub ОценочнаяВедомость_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Call pressTab(e.KeyCode, 40)
        Call pressTab(e.KeyCode, 39)
        Call closeEsc(Me, e.KeyCode)
    End Sub

    Private Sub Группа_KeyDown(sender As Object, e As KeyEventArgs) Handles groupNumber.KeyDown

        If e.KeyCode = 13 Then

            Call groupNumber_Click(sender, e)

        End If

    End Sub

    Sub updateDataGreed(numberColumns As Integer)


        For number As Int16 = 2 To 11

            If number <= numberColumns + 1 Then
                resultTable.Columns(number).ReadOnly = False
                resultTable.Columns(number).DefaultCellStyle.BackColor = Color.White
            Else
                resultTable.Columns(number).ReadOnly = True
                resultTable.Columns(number).DefaultCellStyle.BackColor = Color.Gray
            End If

        Next

    End Sub

End Class