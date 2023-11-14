Public Class GroupList

    Public massiv
    Public numberGr As String
    Public kod As Integer
    Public year As Integer
    Public infoAboutGroup
    Public swichCvalification As SwitchCvalification
    Private search_events As New SearchSort_events
    Private sort_events As New SearchSort_events
    Public gruppaData As New Group.strGruppa

    Dim toolCboxReaction As New ToolComboBoxReaction
    Public dictionaryFlag As New Dictionary(Of String, Boolean)

    Sub search()

        Dim serchCol As String, sortCol As String

        sortCol = interfaceMod.nameCheckedCheckBox(sortSettsGroup)

        serchCol = interfaceMod.nameCheckedCheckBox(Group__serchSettings)

        If searchRow.Text = "" Then
            groupListTable.Items.Clear()
            updateGroupList()
        Else
            massiv = sqlSearch(searchRow.Text, "`group`", "Код, Номер, Программа, Куратор, ДатаНЗ, ДатаКЗ", serchCol, sortCol & interfaceMod.sortType(sort_events.sortSetts.flagSortUp))
            updateListView.updateListView(False, False, groupListTable, massiv, 0, 1, 2, 3, 4, 5)
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

        Dim sqlQuery As String

        If Not groupListTable.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

            numberGr = groupListTable.SelectedItems.Item(0).SubItems(1).Text
            StudentsInGroup.cvalification = MainForm.cvalific

            If groupListTable.SelectedItems.Item(0).SubItems(0).Text = "" Then
                Exit Sub
            End If

            kod = groupListTable.SelectedItems.Item(0).SubItems(0).Text
            MainForm.orderIdGroup = Convert.ToInt64(kod)

            Try
                year = Convert.ToDateTime(groupListTable.SelectedItems.Item(0).SubItems(4).Text).Year
            Catch ex As Exception
                Exit Sub
            End Try

            sqlQuery = checkGroup(kod)

            infoAboutGroup = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

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

                If yearSpravochnikGr.DroppedDown Then Return
                Close()

            Case Keys.Down

                dounPressed()

            Case Keys.Right

                rigthPressed()

            Case Keys.Left

                leftPressed(sender, e)

            Case Keys.Enter

                enterPressed(sender, e)

            Case Keys.F

                keyFPressed(sender, e)

            Case Keys.Tab

                tabPressed()

        End Select

    End Sub

    Private Sub tabPressed()

        If ActiveControl.Name = "groupListTable" Then

            header.Focus()
            searchRow.Select()
            searchRow.Focus()

        End If

    End Sub

    Private Sub leftPressed(sender As Object, e As KeyEventArgs)

        If searchRow.Selected Then

            BtnFocus.Focus()
            header.Focus()
            searchSettings.Select()

        ElseIf yearSpravochnikGr.Selected Then

            searchRow.Focus()
            searchRow.Select()

        End If

    End Sub

    Private Sub keyFPressed(sender As Object, e As KeyEventArgs)
        Dim year As String = ""
        If searchRow.Focused Then Return
        e.SuppressKeyPress = True
        BtnFocus.Focus()
        header.Focus()
        sortSettings.Select()

    End Sub

    Private Sub enterPressed(sender As Object, e As KeyEventArgs)

        If ActiveControl.Name = "groupListTable" Then

            Dim Str As String

            Try
                Str = groupListTable.SelectedItems.Item(0).SubItems(1).Text

            Catch ex As Exception

                Exit Sub

            End Try


            groupListTable_DoubleClick(sender, e)

        End If

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
            'SendKeys.Send("{tab}")
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
            Str = load_spr_group(swichCvalification.activeType, sortField & interfaceMod.sortType(sort_events.sortSetts.flagSortUp), yearSpravochnikGr.Text)
        Else
            Str = load_spr_group(swichCvalification.activeType, sortField & interfaceMod.sortType(sort_events.sortSetts.flagSortUp))
        End If
        massiv = MainForm.mySqlConnect.loadMySqlToArray(Str, 1)

        updateListView.updateListView(False, False, Me.groupListTable, Me.massiv, 0, 1, 2, 3, 4, 5)
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

        ActiveControl = BtnFocus
        searchRow.Clear()
        Group__serchSettings.ShowDialog()
        groupListTable.Focus()

    End Sub

    Private Sub sortSettings_Click(sender As Object, e As EventArgs) Handles sortSettings.Click

        ActiveControl = BtnFocus
        sortSettsGroup.ShowDialog()
        groupListTable.Focus()

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


        If Not search_events.initializationСompleted Then

            search_events.currentForm = Group__serchSettings
            search_events.init()

        End If

        If Not sort_events.initializationСompleted Then

            sort_events.currentForm = sortSettsGroup
            sort_events.pictures.Add(0, sortSettsGroup.sortUp)
            sort_events.pictures.Add(1, sortSettsGroup.sortDown)
            sort_events.buttons.Add(0, sortSettsGroup.sortUpFocus)
            sort_events.buttons.Add(1, sortSettsGroup.sortDounFocus)
            sort_events.buttonPictureBox.Add(sortSettsGroup.sortUpFocus, sortSettsGroup.sortUp)
            sort_events.buttonPictureBox.Add(sortSettsGroup.sortDounFocus, sortSettsGroup.sortDown)

            sort_events.init()

        End If

        swichCvalification = New SwitchCvalification
        swichCvalification.pp = ppOn
        swichCvalification.po = poOn
        swichCvalification.pk = pkOn
        swichCvalification.init()

        toolCboxReaction.init(dictionaryFlag, yearSpravochnikGr)

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

    Private Sub groupListTable_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles groupListTable.PreviewKeyDown

        Select Case e.KeyValue
            Case Keys.Enter
                e.IsInputKey = True
            Case Keys.Tab
                e.IsInputKey = True
        End Select

    End Sub

    'Private Sub yearSpravochnikGr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles yearSpravochnikGr.KeyPress
    '    If e.KeyChar = Convert.ToChar(Keys.Enter) Then
    '        If Not yearSpravochnikGr.DroppedDown Then
    '            yearSpravochnikGr.DroppedDown = Not yearSpravochnikGr.DroppedDown
    '        End If
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub groupListTable_Enter(sender As Object, e As EventArgs) Handles groupListTable.Enter

        If groupListTable.Items.Count < 1 Then Return
        If groupListTable.SelectedItems.Count = 0 Then
            groupListTable.Items(0).Selected = True
        End If

    End Sub
End Class