Imports System.Net.Mime.MediaTypeNames

Public Class GroupList

    Public massiv
    Public numberGr As String
    Public kod As Integer
    Public year As Integer
    Public infoAboutGroup
    Public swichCvalification As SwitchCvalification

    Public gruppaData As New Group.strGruppa

    Sub search()

        Dim serchCol As String, sortCol As String

        sortCol = interfaceMod.nameCheckedCheckBox(sortSettsGroup)

        serchCol = interfaceMod.nameCheckedCheckBox(Group__serchSettings)

        If searchRow.Text = "" Then
            groupListTable.Items.Clear()
            updateGroupList()
        Else
            massiv = sqlSearch(searchRow.Text, "`group`", "Код, Номер, Программа, Куратор, ДатаНЗ, ДатаКЗ", serchCol, sortCol & interfaceMod.sortType(sortSettsGroup.sortSetts.flagSortUp))
            UpdateListView.updateListView(False, False, groupListTable, massiv, 0, 1, 2, 3, 4, 5)
        End If

    End Sub


    Private Sub groupListTable_KeyDown(sender As Object, e As KeyEventArgs) Handles groupListTable.KeyDown
        Dim element
        Dim ind As String
        Dim kod As Integer


        '_________________________________________делит
        If e.KeyCode = Keys.Delete Then

            element = groupListTable.SelectedItems.Count

            ind = groupListTable.SelectedItems.Item(0).SubItems(1).Text
            kod = groupListTable.SelectedItems.Item(0).SubItems(0).Text

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "`group`"
            InsertIntoDataBase.argument.firstName = "Код"
            InsertIntoDataBase.argument.firstValue = kod

            If Not InsertIntoDataBase.checkUniq_No2() = 2 Then

                MsgBox("Ошибка. Запись уже удалена. Нажмите кнопку Загрузить из базы, чтобы обновить список")
                Return

            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Удалить запись?"
            ФормаДаНетУдалить.ShowDialog()


            If ФормаДаНетУдалить.НажатаКнопкаДа Then

                InsertIntoDataBase.argumentClear()
                InsertIntoDataBase.argument.nameTable = "worker_report"
                InsertIntoDataBase.argument.firstName = "Kod"
                InsertIntoDataBase.argument.firstValue = kod

                If InsertIntoDataBase.checkUniq_No2() = 2 Then

                    InsertIntoDataBase.deleteFromDB_NumberArg()

                End If

                InsertIntoDataBase.argumentClear()
                InsertIntoDataBase.argument.nameTable = "group_list"
                InsertIntoDataBase.argument.firstName = "Kod"
                InsertIntoDataBase.argument.firstValue = kod

                If InsertIntoDataBase.checkUniq_No2() = 2 Then

                    InsertIntoDataBase.deleteFromDB_NumberArg()

                End If

                InsertIntoDataBase.argumentClear()
                InsertIntoDataBase.argument.nameTable = "`group`"
                InsertIntoDataBase.argument.firstName = "Код"
                InsertIntoDataBase.argument.firstValue = kod

                InsertIntoDataBase.deleteFromDB_NumberArg()

                updateGroupList()

            End If



        End If


        '_________________________________________вправо

        If e.KeyCode = 39 Then

            SendKeys.Send("{tab}")

        End If

    End Sub
    Private Sub groupListTable_DoubleClick(sender As Object, e As EventArgs) Handles groupListTable.DoubleClick

        Dim sqiQuery As String

        If Not groupListTable.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

            'StudentsInGroup.ListViewStudentsList.Items.Clear()

            numberGr = groupListTable.SelectedItems.Item(0).SubItems(1).Text
            StudentsInGroup.cvalification = MainForm.cvalific

            If groupListTable.SelectedItems.Item(0).SubItems(0).Text = "" Then
                Exit Sub
            End If

            kod = groupListTable.SelectedItems.Item(0).SubItems(0).Text

            Try
                year = Convert.ToDateTime(groupListTable.SelectedItems.Item(0).SubItems(4).Text).Year
            Catch ex As Exception
                Exit Sub
            End Try

            sqiQuery = checkGroup(kod)

            infoAboutGroup = MainForm.mySqlConnect.loadMySqlToArray(sqiQuery, 1)

            If CStr(infoAboutGroup(0, 0)) = "нет записей" Then
                MsgBox("Группа была изменена, обновите данные нажатием кнопки 'Загрузить из базы' ")
                Exit Sub
            End If

            StudentsInGroup.Text = "Группа № " & numberGr
            newGroup.Text = "Группа № " & numberGr

            StudentsInGroup.ShowDialog()

            MainForm.cvalific = StudentsInGroup.cvalification
            updateCvalification()
        Else
            MsgBox("информация удалена")
        End If

    End Sub

    Private Sub groupList_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode

            Case Keys.Escape

                Close()

            Case Keys.Down

                dounPressed()

            Case Keys.Right

                rigthPressed()

            Case Keys.Enter

                enterPressed(sender, e)

        End Select

    End Sub

    Private Sub enterPressed(sender As Object, e As KeyEventArgs)

        Dim Str As String

        Try
            Str = groupListTable.SelectedItems.Item(0).SubItems(1).Text

        Catch ex As Exception

            Exit Sub

        End Try


        groupListTable_DoubleClick(sender, e)

    End Sub

    Private Sub rigthPressed()

        If Not ActiveControl.Name = "groupListTable" Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub dounPressed()

        Dim Str As String
        Name = ActiveControl.Name

        If Not ActiveControl.Name = "groupListTable" Then
            SendKeys.Send("{tab}")
        Else
            Try
                Str = groupListTable.SelectedItems.Item(0).SubItems(1).Text
            Catch ex As Exception

                Try
                    groupListTable.Items(0).Selected = True
                Catch ex1 As Exception
                    SendKeys.Send("{tab}")
                End Try

            End Try
        End If

    End Sub

    Private Sub СправочникГруппы_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        openFormGroupp()
        updateCvalification()

    End Sub

    Public Sub updateGroupList()

        Dim Str As String, searchField, sortField As String

        sortField = interfaceMod.nameCheckedCheckBox(sortSettsGroup)
        searchField = interfaceMod.nameCheckedCheckBox(Group__serchSettings)

        If IsNothing(sortField) Or IsNothing(searchField) Then
            Return
        End If

        searchRow.Visible = True

        If MainForm.cvalific = MainForm.PK Or MainForm.cvalific = MainForm.PP Then
            Str = load_spr_group(swichCvalification.activeType, sortField & interfaceMod.sortType(sortSettsGroup.sortSetts.flagSortUp), yearSpravochnikGr.Text)
        Else
            Str = load_spr_group(swichCvalification.activeType, sortField & interfaceMod.sortType(sortSettsGroup.sortSetts.flagSortUp))
        End If

        massiv = MainForm.mySqlConnect.loadMySqlToArray(Str, 1)

        UpdateListView.updateListView(False, False, Me.groupListTable, Me.massiv, 0, 1, 2, 3, 4, 5)
        Me.searchRow.Text = ""

        Try
            Me.groupListTable.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

    End Sub
    Sub openFormGroupp()

        If MainForm.cvalific = MainForm.PO Then

            yearSpravochnikGr.Visible = False

        Else

            yearSpravochnikGr.Visible = True
            yearSpravochnikGr.Text = DateAndTime.Year(Date.Now())

        End If

    End Sub

    Private Sub searchSettings_Click(sender As Object, e As EventArgs) Handles searchSettings.Click

        searchRow.Clear()
        group__serchSettings.ShowDialog()

    End Sub

    Private Sub sortSettings_Click(sender As Object, e As EventArgs) Handles sortSettings.Click

        sortSettsGroup.ShowDialog()

    End Sub

    Private Sub searchRow_TextChanged(sender As Object, e As EventArgs) Handles searchRow.TextChanged

        search()

    End Sub

    Private Sub yearSpravochnikGr_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles yearSpravochnikGr.SelectedIndexChanged

        updateGroupList()

    End Sub

    Private Sub yearSpravochnikGr_TextUpdate(sender As Object, e As EventArgs) Handles yearSpravochnikGr.TextUpdate

        updateGroupList()

    End Sub

    Private Sub СправочникГруппы_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        swichCvalification = New SwitchCvalification
        swichCvalification.pp = ppOn
        swichCvalification.po = poOn
        swichCvalification.pk = pkOn
        swichCvalification.init()

    End Sub

    Private Sub ppOn_Click(sender As Object, e As EventArgs) Handles ppOn.Click

        MainForm.cvalific = swichCvalification.type("pp") + 1
        updateCvalification()

    End Sub

    Private Sub poOn_Click(sender As Object, e As EventArgs) Handles poOn.Click

        MainForm.cvalific = swichCvalification.type("po") + 1
        updateCvalification()

    End Sub

    Private Sub pkOn_Click(sender As Object, e As EventArgs) Handles pkOn.Click

        MainForm.cvalific = swichCvalification.type("pk") + 1
        updateCvalification()

    End Sub

    Private Sub updateCvalification()

        swichCvalification.activate(MainForm.cvalific - 1)
        openFormGroupp()
        updateGroupList()

    End Sub

End Class