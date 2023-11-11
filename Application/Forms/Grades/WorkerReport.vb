Public Class WorkerReport

    Private dvgBuilderProg As DGVBuilder
    Private dvgBuilderHours As DGVBuilder
    Private dvgBuilderModuls As DGVBuilder
    Public kodGroup As Integer
    Private programTable As DataTable
    Private hoursTable As DataTable
    Private modulsTable As DataTable
    Dim queryString As String
    Private tables As List(Of DGVBuilder)

    Public myEvents As New Grades_events

    Public Sub loadTables()

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


        mainTable.Rows.Clear()
        programTable = New DataTable()

        queryString = workerReport__load(Convert.ToString(kodGroup))

        resultList = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
        pednagr__loadInfoTables()

        If resultList(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ActiveControl = mainTable
            Exit Sub

        End If

        RedactorDataGrid.arrayToDataGrid(mainTable, resultList)

    End Sub

    Private Sub pednagr__loadInfoTables()

        programTable = New DataTable()
        hoursTable = New DataTable()
        modulsTable = New DataTable()

        queryString = wr__loadProgram(Convert.ToString(kodGroup))
        programTable = MainForm.mySqlConnect.mySqlToDataTable(queryString, 1)
        wr__program.DataSource = programTable
        wr__program.ClearSelection()

        queryString = wr__loadHours(Convert.ToString(kodGroup))
        hoursTable = MainForm.mySqlConnect.mySqlToDataTable(queryString, 1)
        pednagr__infoTable.DataSource = hoursTable
        pednagr__infoTable.ClearSelection()

        queryString = wr__loadModulsAndHours(Convert.ToString(kodGroup))
        modulsTable = MainForm.mySqlConnect.mySqlToDataTable(queryString, 1)
        wr__moduls.DataSource = modulsTable
        wr__moduls.ClearSelection()

        wr_builder()

    End Sub

    Private Sub addSelectionClear(currentTable As DataGridView)

        AddHandler currentTable.Leave, Sub()
                                           currentTable.ClearSelection()
                                       End Sub

    End Sub

    Private Sub wr_builder()

        If IsNothing(dvgBuilderProg) Then Return
        If groupNumber.Text = "" Then Return

        dvgBuilderProg.resizeTables()
        dvgBuilderHours.resizeTables()
        dvgBuilderModuls.resizeTables()

        resizeHeightContainer()

    End Sub

    Private Sub wr__resizeInfoTables(currentTable As DataGridView, parent As Panel)

        If IsNothing(currentTable.DataSource) Then
            Return
        ElseIf currentTable.Columns.Count < 2 Then
            Return
        End If

        currentTable.Columns(0).Width = parent.Width * 1 / 3
        currentTable.Columns(1).Width = parent.Width * 2 / 3 - 4
        currentTable.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub resizeHeightContainer()

        pednagr_splitContainerInfo.SplitterDistance =
            wr__dataTools.Height +
            dGWTableSize(wr__program) +
            programHoursContainer.SplitterWidth +
            dGWTableSize(pednagr__infoTable) + 2
        programHoursContainer.SplitterDistance = dGWTableSize(wr__program)

    End Sub

    Private Function dGWTableSize(table As DataGridView)
        Dim heigth As Int16 = 0

        For Each row As DataGridViewRow In table.Rows
            heigth += row.Height
        Next

        If table.ColumnHeadersVisible Then
            heigth += table.ColumnHeadersHeight
        End If

        Return heigth

    End Function

    Private Sub ТаблицаВедомость_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles mainTable.CellValueChanged

        Dim value As Double

        If IsNothing(mainTable.Rows(0).Cells(0).Value) Or Trim(mainTable.Rows(0).Cells(0).Value) = "" Then
            Exit Sub
        End If

        Dim count As Short = 1

        For Each row As DataGridViewRow In pednagr__infoTable.Rows

            row.Cells(2).Value = sumInColumn(mainTable, count)

            If row.Cells(2).Value.ToString = "" Then
                row.Cells(2).Value = 0
            End If

            If row.Cells(1).Value.ToString = "" Then
                row.Cells(1).Value = 0
            End If

            row.Cells(3).Value = row.Cells(1).Value - row.Cells(2).Value

            If row.Cells(3).Value < 0 Then
                row.DefaultCellStyle.BackColor = Color.PaleVioletRed
            Else
                row.DefaultCellStyle.BackColor = SystemColors.Window
            End If

            count += 1

        Next

        sumResult.Text = sumInColumn(mainTable, 7)


        Dim счетчикСтрок As Integer = 0

        For Each строка In mainTable.Rows

            If IsNothing(строка.Cells(0).Value) Or Trim(mainTable.Rows(0).Cells(0).Value) = "" Then
                счетчикСтрок += 1
                Continue For
            End If

            count = mainTable.Columns.Count
            value = sumInRow(mainTable, счетчикСтрок, 1, mainTable.Columns.Count - 2)

            If value = -1 Then
                счетчикСтрок += 1
                Continue For
            End If

            строка.Cells(mainTable.Columns.Count - 1).Value = value
            счетчикСтрок += 1

        Next

    End Sub

    Public Sub save_Click()
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

        datagridInsertRowIntoDB(mainTable, "worker_report", arg, arrayNameAndType, 0, 6)

    End Sub

    'Private Sub WorkerReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    '    closeEsc(Me, e.KeyCode)
    'End Sub

    'Private Sub groupNumber_Click(sender As Object, e As EventArgs) Handles groupNumber.Click

    '    List.resultList.Columns(0).Width = 120
    '    List.resultList.Columns.Add("Год", 100)
    '    List.resultList.Columns.Add("Код", 100)
    '    List.textboxName = sender.Name
    '    List.currentFormName = "WorkerReport"

    '    List.ShowDialog()

    '    List.resultList.Columns.RemoveAt(1)
    '    List.resultList.Columns.RemoveAt(2)
    '    List.resultList.Columns(1).Width = 50
    '    List.resultList.Columns(1).Width = 620
    '    List.resultList.Columns(1).Text = "Наименование"

    '    loadTables()

    'End Sub

    Public Sub WorkerReport_Init()

        dvgBuilderProg = New DGVBuilder
        dvgBuilderHours = New DGVBuilder
        dvgBuilderModuls = New DGVBuilder

        tables = New List(Of DGVBuilder)

        tables.Add(dvgBuilderProg)
        tables.Add(dvgBuilderHours)
        tables.Add(dvgBuilderModuls)

        dvgBuilderProg.table = wr__program
        dvgBuilderProg.parent = pednagr__splitContainerMain.Panel2

        dvgBuilderHours.table = pednagr__infoTable
        dvgBuilderHours.parent = pednagr__splitContainerMain.Panel2

        dvgBuilderModuls.table = wr__moduls
        dvgBuilderModuls.parent = pednagr__splitContainerMain.Panel2


        dvgBuilderProg.columnWidht = New Dictionary(Of Short, Short)
        dvgBuilderModuls.columnWidht = New Dictionary(Of Short, Short)
        dvgBuilderHours.columnWidht = New Dictionary(Of Short, Short)

        dvgBuilderProg.columnAlignment = New Dictionary(Of Int16, DataGridViewContentAlignment)
        dvgBuilderModuls.columnAlignment = New Dictionary(Of Int16, DataGridViewContentAlignment)
        dvgBuilderHours.columnAlignment = New Dictionary(Of Int16, DataGridViewContentAlignment)

        dvgBuilderProg.columnAlignment.Add(0, DataGridViewContentAlignment.MiddleLeft)
        dvgBuilderModuls.columnAlignment.Add(0, DataGridViewContentAlignment.MiddleLeft)
        dvgBuilderHours.columnAlignment.Add(0, DataGridViewContentAlignment.MiddleLeft)

        dvgBuilderProg.columnWidht.Add(0, 33)
        dvgBuilderProg.columnWidht.Add(1, 66)

        dvgBuilderModuls.columnWidht.Add(0, 33)
        dvgBuilderModuls.columnWidht.Add(1, 66)

        For count As Short = 2 To 5
            dvgBuilderProg.columnWidht.Add(count, 0)
            dvgBuilderModuls.columnWidht.Add(count, 0)
            count += 1
        Next

        dvgBuilderHours.columnWidht.Add(0, 33)
        dvgBuilderHours.columnWidht.Add(1, 22)
        dvgBuilderHours.columnWidht.Add(2, 22)
        dvgBuilderHours.columnWidht.Add(3, 22)
        dvgBuilderHours.columnWidht.Add(4, 0)
        dvgBuilderHours.columnWidht.Add(5, 0)

        For count As Short = 1 To 5
            dvgBuilderProg.columnAlignment.Add(count, DataGridViewContentAlignment.MiddleLeft)
            dvgBuilderModuls.columnAlignment.Add(count, DataGridViewContentAlignment.MiddleRight)
            dvgBuilderHours.columnAlignment.Add(count, DataGridViewContentAlignment.MiddleRight)
        Next

        addSelectionClear(wr__moduls)
        addSelectionClear(wr__program)
        addSelectionClear(pednagr__infoTable)

    End Sub

    Private Sub pednagr__splitContainerMain_Panel2_SizeChanged(sender As Object, e As EventArgs) Handles pednagr__splitContainerMain.Panel2.SizeChanged
        wr_builder()
    End Sub

    Private Sub WorkerReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myEvents.currentForm = Me
        myEvents.header = header
        myEvents.groupNumber = groupNumber
        myEvents.saveButton = save
        myEvents.resultTable = mainTable
        myEvents.init()
    End Sub
End Class