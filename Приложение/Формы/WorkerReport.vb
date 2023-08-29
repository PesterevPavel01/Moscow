Public Class WorkerReport

    Public kodGroup As Integer
    Private infoDataTable As DataTable
    Dim queryString As String

    Private Sub loadTables()

        Dim resultList

        If Trim(groupNumber.Text) = "" Then

            Return

        End If

        sumLectures.Clear()
        sumPracticals.Clear()
        sumStimul.Clear()
        sumConsultations.Clear()
        sumPA.Clear()
        sumIA.Clear()
        sumResult.Clear()


        pednagr__mainTable.Rows.Clear()
        infoDataTable = New DataTable()

        queryString = pednagruzka__load(Convert.ToString(kodGroup))

        resultList = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If resultList(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ActiveControl = pednagr__mainTable
            Exit Sub

        End If

        RedactorDataGrid.arrayToDataGrid(pednagr__mainTable, resultList)

        pednagr__loadInfoTables()

    End Sub

    Private Sub pednagr__loadInfoTables()

        infoDataTable = New DataTable()

        queryString = pednagruzka__loadProgramm(Convert.ToString(kodGroup))

        infoDataTable = MainForm.mySqlConnect.mySqlToDataTable(queryString, 1)
        pednagr__infoTable.DataSource = infoDataTable

        pednagr__resizeInfoTables()

    End Sub

    Private Sub pednagr__resizeInfoTables()

        If IsNothing(infoDataTable) Then
            Return
        ElseIf pednagr__infoTable.Columns.Count < 2 Then
            Return
        End If

        pednagr__infoTable.Columns(0).Width = pednagr__infoTable.Width * 1 / 3
        pednagr__infoTable.Columns(1).Width = pednagr__infoTable.Width * 2 / 3 - 4
        pednagr__infoTable.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub ТаблицаВедомость_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles pednagr__mainTable.CellValueChanged
        Dim Значение As Double


        If IsNothing(pednagr__mainTable.Rows(0).Cells(0).Value) Or Trim(pednagr__mainTable.Rows(0).Cells(0).Value) = "" Then
            Exit Sub
        End If

        sumLectures.Text = sumInColumn(pednagr__mainTable, 1)
        sumPracticals.Text = sumInColumn(pednagr__mainTable, 2)
        sumStimul.Text = sumInColumn(pednagr__mainTable, 3)
        sumConsultations.Text = sumInColumn(pednagr__mainTable, 4)
        sumIA.Text = sumInColumn(pednagr__mainTable, 6)
        sumPA.Text = sumInColumn(pednagr__mainTable, 5)
        sumResult.Text = sumInColumn(pednagr__mainTable, 7)
        Dim count As Integer
        Dim счетчикСтрок As Integer = 0
        For Each строка In pednagr__mainTable.Rows

            If IsNothing(строка.Cells(0).Value) Or Trim(pednagr__mainTable.Rows(0).Cells(0).Value) = "" Then
                счетчикСтрок += 1
                Continue For
            End If

            count = pednagr__mainTable.Columns.Count
            Значение = sumInRow(pednagr__mainTable, счетчикСтрок, 1, pednagr__mainTable.Columns.Count - 2)

            If Значение = -1 Then
                счетчикСтрок += 1
                Continue For
            End If

            строка.Cells(pednagr__mainTable.Columns.Count - 1).Value = Значение
            счетчикСтрок += 1

        Next

    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        Dim arg, arrayNameAndType
        ReDim arg(1)
        ReDim arrayNameAndType(1, 6)
        arg(0) = "Kod"
        arg(1) = kodGroup

        arrayNameAndType(0, 0) = "worker"
        arrayNameAndType(1, 0) = "String"

        arrayNameAndType(0, 1) = "lectures"
        arrayNameAndType(1, 1) = "Double"
        arrayNameAndType(0, 2) = "practical"
        arrayNameAndType(1, 2) = "Double"
        arrayNameAndType(0, 3) = "stimulating"
        arrayNameAndType(1, 3) = "Double"
        arrayNameAndType(0, 4) = "consultation"
        arrayNameAndType(1, 4) = "Double"
        arrayNameAndType(0, 5) = "PA"
        arrayNameAndType(1, 5) = "Double"
        arrayNameAndType(0, 6) = "IA"
        arrayNameAndType(1, 6) = "Double"

        datagridInsertRowIntoDB(pednagr__mainTable, "pednagruzka", arg, arrayNameAndType, 0, 6)
    End Sub

    Private Sub ВедомостьПеднагрузка_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        closeEsc(Me, e.KeyCode)
    End Sub

    Private Sub pednagr__splitContainerMain_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles pednagr__splitContainerMain.SplitterMoved

        pednagr__resizeInfoTables()

    End Sub

    Private Sub groupNumber_Click(sender As Object, e As EventArgs) Handles groupNumber.Click
        List.resultList.Columns(0).Width = 120
        List.resultList.Columns.Add("Год", 100)
        List.resultList.Columns.Add("Код", 100)
        List.textboxName = sender.Name
        List.currentFormName = "WorkerReport"

        List.ShowDialog()

        List.resultList.Columns.RemoveAt(1)
        List.resultList.Columns.RemoveAt(2)
        List.resultList.Columns(1).Width = 50
        List.resultList.Columns(1).Width = 620
        List.resultList.Columns(1).Text = "Наименование"

        loadTables()
    End Sub
End Class