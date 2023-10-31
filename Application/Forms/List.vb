Public Class List
    Dim queryString As String
    Public textboxName As String
    Public currentFormName As String
    Public resultArray
    Public onCheckboxes As String
    Public sort As UInt16 = 0
    Public sortColumn As Integer = -1
    Public Const poVozr = 1
    Public Const poUb = 2
    Public images As imagesStruct
    Dim path As String
    Dim swichKvalification As SwitchCvalification

    Private Sub FormList_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim prikaz As String = ""

        resultList.Sorting = SortOrder.None
        header.Visible = False

        searchValue.Text = ""

        If textboxName = "НомерГруппы" Or textboxName = "groupNumber" Then

            showGroupNumber(sender, e)

        ElseIf textboxName = "НоваяГруппаПрограмма" Or textboxName = "versProgs" Then

            showProgram()
            Return

        Else

            queryString = formList__loadList(textboxName)
            resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            If resultArray(0, 0).ToString = "ошибка" Then

                MsgBox("ошибка, повторите последнее действие")
                Exit Sub

            End If

            UpdateListView.updateListView(False, True, resultList, resultArray, 1)

        End If

        ActiveControl = resultList

        Try

            resultList.Items(0).Selected = True

        Catch ex1 As Exception

            Exit Sub

        End Try


    End Sub
    Private Sub showProgram()

        If currentFormName = "NewGroup" And MainForm.cvalific > 0 Then

            queryString = ProgramPoUKvalifik(newGroup.swichCvalification.activeType)

        Else

            queryString = formList__loadPrograms()

        End If

        resultList.Columns(0).Width = resultList.Width - 150
        resultList.Columns(1).Width = 150
        resultList.Columns(0).Text = "Программа"
        resultList.Columns(1).Text = "Дата"
        resultList.Columns.Add("Код", 1)
        Text = "Программа. Расширенный список"

        resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        UpdateListView.updateListView(False, False, resultList, resultArray, 0, 1, 2)

        If currentFormName = "NewGroup" Then

            SelectedRow(2, newGroup.getProgKod())

        End If

    End Sub


    Private Sub showGroupNumber(sender As Object, e As EventArgs)

        If currentFormName = "BuildOrder" And BuildOrder.cvalification > 0 Then

            MainForm.orderCvalif = BuildOrder.cvalification
            header.Visible = False
            loadListGroup()

        Else

            MainForm.orderCvalif = MainForm.PK
            header.Visible = True
            pkOn_Click(sender, e)

        End If

    End Sub

    Private Sub loadListGroup()

        queryString = SQLString_loadGruppa()

        resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        UpdateListView.updateListView(False, False, resultList, resultArray, 0, 1, 2, 3)

        queryString = formList__loadKodGroupPP()

        listViewColoriz(resultList, MainForm.mySqlConnect.loadMySqlToArray(queryString, 1))

    End Sub

    Private Sub updateFormName(textboxName As String, prikaz As String)

        If textboxName = "Ответственный" And BuildOrder.Label4.Text = "Слушатель(ФИО)" Then

            Me.Text = "Список слушателей группы"

        End If

    End Sub
    Private Sub ListViewСписок_DoubleClick(sender As Object, e As EventArgs) Handles resultList.DoubleClick

        Dim ind As String

        If textboxName = "НомерГруппы" Or textboxName = "НоваяГруппаПрограмма" Or textboxName = "groupNumber" Then
            ind = resultList.SelectedItems(0).SubItems(0).Text
        Else
            ind = resultList.SelectedItems(0).SubItems(1).Text
        End If


        Select Case currentFormName

            Case "WorkerReport"

                If textboxName = "groupNumber" Then
                    WorkerReport.kodGroup = resultList.SelectedItems(0).SubItems(3).Text
                    WorkerReport.groupNumber.Text = ind
                End If

            Case "MainForm"

                If textboxName = "directorName" Then

                    ind = ind.Trim
                    ind = Strings.Right(ind, 4) & " " & Strings.Left(ind, Strings.Len(ind) - 4)
                    If Strings.Right(Strings.Left(ind, 4), 1) = "." And Strings.Right(Strings.Left(ind, 2), 1) = "." Then
                    Else
                        Warning.content.Text = "Ошибка в ФИО"
                        openForm(Warning)
                        Exit Sub
                    End If
                End If
                writeIntoTextBox(MainForm.panelSetts, ind)

            Case "GradesIA"

                If textboxName = "groupNumber" Then
                    GradesIA.myEvents.kodGroup = resultList.SelectedItems(0).SubItems(3).Text
                    GradesIA.groupNumber.Text = ind
                End If

            Case "Grades"

                If textboxName = "groupNumber" Then
                    Grades.myEvents.kodGroup = resultList.SelectedItems(0).SubItems(3).Text
                    Grades.groupNumber.Text = ind
                End If

            Case "NewGroup"

                If (textboxName = "НоваяГруппаПрограмма") Then
                    newGroup.setProgKod(Convert.ToInt32(resultList.SelectedItems(0).SubItems(2).Text))
                    newGroup.НоваяГруппаПрограмма.Text = ind
                End If

            Case "BuildOrder"

                If textboxName = "groupNumber" Then
                    MainForm.orderIdGroup = resultList.SelectedItems(0).SubItems(3).Text
                    BuildOrder.groupNumber.Text = ind
                End If
                checkGroup()

        End Select

        Close()

    End Sub

    Private Sub writeIntoCurrentTextBox(currentForm As Form, result As String)

        For Each textBox In currentForm.Controls.OfType(Of TextBox)
            If textBox.Name = textboxName Then
                textBox.Text = result
            End If
        Next

    End Sub

    Private Sub writeIntoTextBox(currentPanel As Panel, result As String)

        For Each textBox In currentPanel.Controls.OfType(Of TextBox)
            If textBox.Name = textboxName Then
                textBox.Text = result
            End If
        Next

    End Sub

    Private Sub writeIntoCurrentComboBox(currentForm As Form, result As String)

        For Each textBox In currentForm.Controls.OfType(Of ComboBox)
            If textBox.Name = textboxName Then
                textBox.Text = result
            End If
        Next

    End Sub

    Private Sub searchValue_TextChanged(sender As Object, e As EventArgs) Handles searchValue.TextChanged

        Dim queryString As String

        If textboxName = "groupNumber" Then

            queryString = SQLString_loadGruppa(True, "Номер", searchValue.Text, True)
            resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
            UpdateListView.updateListView(False, False, resultList, resultArray, 0, 1, 2, 3)
            queryString = formList__loadKodGroupPP()
            listViewColoriz(resultList, MainForm.mySqlConnect.loadMySqlToArray(queryString, 1))

        ElseIf currentFormName = "NewGroup" And MainForm.cvalific > 0 Then

            queryString = ProgramPoUKvalifik(newGroup.swichCvalification.activeType, searchValue.Text)
            resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
            UpdateListView.updateListView(False, False, resultList, resultArray, 0, 1, 2)

        End If

    End Sub

    Sub checkGroup()

        Dim sqlQuery, students
        sqlQuery = formList__checkGroup(MainForm.orderIdGroup)
        students = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)
        If students(0, 0).ToString = "нет записей" Then
            Warning.content.Text = "В выбранной группе нет слушателей"
            openForm(Warning)
            If BuildOrder.Label4.Text = "Слушатель(ФИО)" Then
                BuildOrder.Ответственный.Text = ""
            End If
        End If


    End Sub

    Private Sub form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim str As String

        closeEsc(Me, e.KeyCode)
        If e.KeyCode = Keys.Enter Then
            Try
                str = resultList.SelectedItems.Item(0).SubItems(1).Text
            Catch ex As Exception
                Exit Sub
            End Try
            ListViewСписок_DoubleClick(sender, e)
        End If

        If resultList.Focused And resultList.Items.Count > 0 Then
            If Not (resultList.Items(0).Selected And e.KeyCode = Keys.Up) Then
                Return
            End If
        End If

        pressDown(e)
        pressUp(e)

    End Sub
    Private Sub pressDown(e As KeyEventArgs)

        If e.KeyCode = Keys.Down Then
            If resultList.Focused Then
                If header.Visible Then
                    header.Focus()
                    pkOn.Select()
                Else
                    ActiveControl = searchValue
                End If
            ElseIf searchValue.Focused Then
                ActiveControl = resultList
            ElseIf header.Focused Then
                ActiveControl = searchValue
            End If
        End If
    End Sub

    Private Sub pressUp(e As KeyEventArgs)

        If e.KeyCode = Keys.Up Then
            If resultList.Focused Then

                ActiveControl = searchValue

            ElseIf searchValue.Focused Then

                If header.Visible Then
                    header.Focus()
                    pkOn.Select()
                Else
                    ActiveControl = resultList
                End If

            ElseIf header.Focused Then
                ActiveControl = resultList
            End If

        End If
    End Sub

    Private Sub resultTable_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles resultList.ColumnClick

        If (Me.Text = "Группа" Or Me.Text = "ГруппаНомер" Or Me.Text = "НомерГруппы") And resultList.Columns(e.Column).Text = "Номер" And MainForm.orderCvalif = MainForm.PK Then
            If e.Column <> sortColumn Then
                sort = poUb
            Else
                If sort = poUb Then
                    sort = poVozr
                Else
                    sort = poUb
                End If
            End If
            sortColumn = e.Column

            FormList_Shown(sender, e)

            Dim sqlQuery As String
            sqlQuery = formList__loadKodGroupPP()
            listViewColoriz(resultList, MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1))

            Return

        End If

        If e.Column <> sortColumn Then

            sortColumn = e.Column
            resultList.Sorting = SortOrder.Ascending
            resultList.Sort()
            resultList.ListViewItemSorter = New ListViewItemComparer(e.Column, SortOrder.Ascending)

        Else

            If resultList.Sorting = SortOrder.Ascending Then

                resultList.Sorting = SortOrder.Descending
                resultList.Sort()
                resultList.ListViewItemSorter = New ListViewItemComparer(e.Column, SortOrder.Descending)

            Else

                resultList.Sorting = SortOrder.Ascending
                resultList.Sort()
                resultList.ListViewItemSorter = New ListViewItemComparer(e.Column, SortOrder.Ascending)

            End If

        End If

    End Sub

    Private Sub form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If textboxName = "НоваяГруппаПрограмма" Or textboxName = "versProgs" Then
            resultList.Columns.RemoveAt(2)
        End If

        'headerVisible = False
        header.Visible = False

    End Sub

    Private Sub SelectedRow(numberColumns As Int16, value As String)

        For Each item In resultList.Items
            If item.SubItems(numberColumns).Text = value Then
                item.Selected = True
                Return
            End If
        Next

    End Sub

    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        swichKvalification = New SwitchCvalification
        swichKvalification.pp = ppOn
        swichKvalification.po = poOn
        swichKvalification.pk = pkOn
        swichKvalification.init()

    End Sub

    Private Sub pkOn_Click(sender As Object, e As EventArgs) Handles pkOn.Click

        swichKvalification.activate(swichKvalification.type("pk"))
        MainForm.orderCvalif = MainForm.PK
        loadListGroup()
    End Sub

    Private Sub poOn_Click(sender As Object, e As EventArgs) Handles poOn.Click
        swichKvalification.activate(swichKvalification.type("po"))
        MainForm.orderCvalif = MainForm.PO
        loadListGroup()
    End Sub

    Private Sub ppOn_Click(sender As Object, e As EventArgs) Handles ppOn.Click
        swichKvalification.activate(swichKvalification.type("pp"))
        MainForm.orderCvalif = MainForm.PP
        loadListGroup()
    End Sub

End Class


