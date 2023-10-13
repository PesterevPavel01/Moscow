Public Class Grades

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

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ActiveControl = resultTable
            Exit Sub

        End If

        queryString = select_moduls_count(kodGroup)

        result = MainForm.mySqlConnect.LoadToListString(queryString, 1, 0)

        If Not (IsNumeric(result(0)) Or result(0) = "0") Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ActiveControl = resultTable
            Return

        End If

        updateDataGreed(Convert.ToInt16(result(0)))

        list = arrayMethod.removeEmpty(list)

        gradesManipulation.ЗаписатьСписокСлушателей(list)

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

    Private Sub save_GotFocus(sender As Object, e As EventArgs)
        Call interfaceMod.controlFont(save, 14.0F)
    End Sub

    Private Sub save_LostFocus(sender As Object, e As EventArgs)
        interfaceMod.controlFont(save, 11.0F)
    End Sub

    Private Sub Button2_GotFocus(sender As Object, e As EventArgs) Handles Button2.GotFocus
        Call interfaceMod.controlFont(Button2, 14.0F)
    End Sub

    Private Sub Button2_LostFocus(sender As Object, e As EventArgs) Handles Button2.LostFocus
        interfaceMod.controlFont(Button2, 11.0F)
    End Sub

    Private Sub Grades_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        pressTab(e.KeyCode, 40)
        pressTab(e.KeyCode, 39)
        closeEsc(Me, e.KeyCode)
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

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click

        ActiveControl = Button2

        If gradesManipulation.check(resultTable) Then
            Return
        End If
        gradesManipulation.saveVal(resultTable, kodGroup)

    End Sub

    Private Sub groupNumber_Click(sender As Object, e As EventArgs) Handles groupNumber.Click

        List.resultList.Columns(0).Width = 120
        List.resultList.Columns.Add("Год", 100)
        List.resultList.Columns.Add("Код", 100)
        List.textboxName = "groupNumber"
        List.currentFormName = "Grades"

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

            Call groupNumber_Click(sender, e)

        End If
    End Sub
End Class