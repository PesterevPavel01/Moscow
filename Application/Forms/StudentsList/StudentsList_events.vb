﻿
Public Class StudentsList_events
    Private flag_rowSelect As Boolean = False
    Public studentsList As StudentsList
    Private initializationСompleted As Boolean = False
    Public search_events As New SearchSort_events
    Public sort_events As New SearchSort_events

    Public Sub init()

        If initializationСompleted Then Return
        initializationСompleted = True

        AddHandler studentsList.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                             studentsList_KeyDown(sender, e)
                                         End Sub

        AddHandler studentsList.Load, Sub(sender As Object, e As EventArgs)
                                          load()
                                      End Sub

        AddHandler studentsList.ListViewСписокСлушателей.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                                             previewKeyDown(sender, e)
                                                                         End Sub

        AddHandler studentsList.ListViewСписокСлушателей.Enter, Sub(sender As Object, e As EventArgs)
                                                                    ListViewСписокСлушателей_Enter(sender, e)
                                                                End Sub

        AddHandler studentsList.ListViewСписокСлушателей.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                                      studentsListTbl_KeyDown(sender, e)
                                                                  End Sub

        AddHandler studentsList.ListViewСписокСлушателей.DoubleClick, Sub(sender As Object, e As EventArgs)
                                                                          doubleClick(sender, e)
                                                                      End Sub

        AddHandler studentsList.ListViewСписокСлушателей.SelectedIndexChanged, Sub(sender As Object, e As EventArgs)
                                                                                   studentList_SelectedIndexChanged(sender, e)
                                                                               End Sub


        AddHandler studentsList.ССлушТаблицаИнфСлушателя.SelectionChanged, Sub()
                                                                               ' Выделяет всю строку
                                                                               dataGridTables_SelectionChanged()
                                                                           End Sub

        AddHandler studentsList.sortSetts.Click, Sub(sender As Object, e As EventArgs)
                                                     sortSetts_Click(sender, e)
                                                 End Sub

        AddHandler studentsList.searchSetts.Click, Sub(sender As Object, e As EventArgs)
                                                       searchSetts_Click(sender, e)
                                                   End Sub

        AddHandler studentsList.insertIntoGroupList.Click, Sub(sender As Object, e As EventArgs)
                                                               insertIntoGroupList_Click(sender, e)
                                                           End Sub

    End Sub

    Private Sub load()

        If Not search_events.initializationСompleted Then

            search_events.currentForm = НастройкаПоискаСлушателей
            search_events.init()

        End If

        If Not sort_events.initializationСompleted Then

            sort_events.currentForm = sortSettsStudents
            sort_events.pictures.Add(0, sortSettsStudents.sortUp)
            sort_events.pictures.Add(1, sortSettsStudents.sortDown)
            sort_events.buttons.Add(0, sortSettsStudents.sortUpFocus)
            sort_events.buttons.Add(1, sortSettsStudents.sortDounFocus)
            sort_events.buttonPictureBox.Add(sortSettsStudents.sortUpFocus, sortSettsStudents.sortUp)
            sort_events.buttonPictureBox.Add(sortSettsStudents.sortDounFocus, sortSettsStudents.sortDown)

            sort_events.init()

        End If

    End Sub

    Private Sub studentList_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim Dtable As DataTable
        Dim Snils, SqlString As String

        Try

            Snils = addMask.deleteMask(studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)

        Catch ex As Exception

            Exit Sub

        End Try

        SqlString = sprSlushTblGroup(Snils)
        Dtable = MainForm.mySqlConnect.mySqlToDataTable(SqlString, 1)
        studentsList.ССлушТаблицаИнфСлушателя.DataSource = Dtable

        If studentsList.ССлушТаблицаИнфСлушателя.Columns.Count <> 5 Then

            Return

        End If

        studentsList.ССлушТаблицаИнфСлушателя.Columns(0).Width = studentsList.ССлушТаблицаИнфСлушателя.Width * 0.1
        studentsList.ССлушТаблицаИнфСлушателя.Columns(1).Width = studentsList.ССлушТаблицаИнфСлушателя.Width * 0.15
        studentsList.ССлушТаблицаИнфСлушателя.Columns(2).Width = studentsList.ССлушТаблицаИнфСлушателя.Width * 0.5
        studentsList.ССлушТаблицаИнфСлушателя.Columns(3).Width = studentsList.ССлушТаблицаИнфСлушателя.Width * 0.125
        studentsList.ССлушТаблицаИнфСлушателя.Columns(4).Width = studentsList.ССлушТаблицаИнфСлушателя.Width * 0.125

        studentsList.ССлушТаблицаИнфСлушателя.DefaultCellStyle.Font = New Font("Microsoft YaHei", 10)

    End Sub

    Private Sub ListViewСписокСлушателей_Enter(sender As Object, e As EventArgs)

        If IsNothing(studentsList.ListViewСписокСлушателей.Items(0)) Then Return
        If studentsList.ListViewСписокСлушателей.SelectedItems.Count = 0 Then
            studentsList.ListViewСписокСлушателей.Items(0).Selected = True
        End If

    End Sub

    Private Sub insertIntoGroupList_Click(sender As Object, e As EventArgs)

        Dim snils As String

        If IsNothing(studentsList.ListViewСписокСлушателей.SelectedItems.Item(0)) Then
            MsgBox("Слушатель не выбран")
            studentsList.ListViewСписокСлушателей.Focus()
            Return
        End If

        snils = studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
        snils = addMask.deleteMask(snils)
        _technical.insertIntoGroupList(snils)

        studentList_SelectedIndexChanged(sender, e)
        studentsList.ListViewСписокСлушателей.Focus()

    End Sub

    Private Sub searchSetts_Click(sender As Object, e As EventArgs)

        studentsList.ActiveControl = studentsList.BtnFocus
        studentsList.searchRow.Clear()
        НастройкаПоискаСлушателей.ShowDialog()
        studentsList.ListViewСписокСлушателей.Focus()

    End Sub

    Private Sub sortSetts_Click(sender As Object, e As EventArgs)

        studentsList.ActiveControl = studentsList.BtnFocus
        sortSettsStudents.ShowDialog()
        studentsList.ListViewСписокСлушателей.Focus()

    End Sub

    Private Sub studentsListTbl_KeyDown(sender As Object, e As KeyEventArgs)

        Dim element
        Dim ind As String
        Dim nomer As Integer, счетчик As Integer

        'Label2.Visible = False


        If e.KeyCode = Keys.Delete Then

            element = studentsList.ListViewСписокСлушателей.SelectedItems.Count

            ind = deleteMask(studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)
            nomer = studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(0).Text

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "students"
            InsertIntoDataBase.argument.firstName = "СНИЛС"
            InsertIntoDataBase.argument.firstValue = ind

            If Not InsertIntoDataBase.checkDuplicates() Then

                MsgBox("Ошибка. Запись уже удалена. Нажмите кнопку Загрузить из базы, чтобы обновить список")
                Return

            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Удалить запись?"
            ФормаДаНетУдалить.ShowDialog()


            If ФормаДаНетУдалить.НажатаКнопкаДа Then

                InsertIntoDataBase.argument.nameTable = "group_list"
                InsertIntoDataBase.argument.firstName = "students"
                InsertIntoDataBase.argument.firstValue = ind

                If InsertIntoDataBase.checkDuplicates() Then

                    InsertIntoDataBase.deleteFromDB()

                End If

                InsertIntoDataBase.argument.nameTable = "students"
                InsertIntoDataBase.argument.firstName = "СНИЛС"
                InsertIntoDataBase.argument.firstValue = ind

                InsertIntoDataBase.deleteFromDB()

                If Not InsertIntoDataBase.checkDuplicates() Then

                    If StudentsInGroup.tbl_studentsInGroup.flagInit Then
                        StudentsInGroup.tbl_studentsInGroup.load_table()
                        StudentsInGroup.updateStudentsCounter()
                    End If

                    счетчик = 0
                    While счетчик < UBound(studentsList.massiv, 1)

                        studentsList.massiv(счетчик, nomer - 1) = "удалено"
                        счетчик = счетчик + 1

                    End While

                End If

                studentsList.search()

            End If
        End If
    End Sub

    Public Sub dataGridTables_SelectionChanged()

        If IsNothing(studentsList.ССлушТаблицаИнфСлушателя.CurrentCell) Then Return

        If Not flag_rowSelect Then

            selectRow(studentsList.ССлушТаблицаИнфСлушателя.Rows(studentsList.ССлушТаблицаИнфСлушателя.CurrentCell.RowIndex))

        End If
    End Sub

    Public Sub selectRow(row As DataGridViewRow)

        If IsNothing(row) Then Return

        flag_rowSelect = True

        studentsList.ССлушТаблицаИнфСлушателя.ClearSelection()

        For Each cell As DataGridViewCell In row.Cells
            cell.Selected = True
        Next
        flag_rowSelect = False

    End Sub

    Private Sub previewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        Select Case e.KeyValue

            Case Keys.Tab

                e.IsInputKey = True

            Case Keys.Enter

                e.IsInputKey = True

            Case Keys.Left

                e.IsInputKey = True

            Case Keys.Right

                e.IsInputKey = True

            Case Keys.Up

                e.IsInputKey = True

            Case Keys.Down

                e.IsInputKey = True

        End Select

    End Sub

    Public Sub studentsList_KeyDown(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode

            Case Keys.Tab

                keyTabPressed(e)

            Case Keys.Escape

                studentsList.Close()

            Case Keys.Down

                keyDownPressed()

            Case Keys.Right

                keyRightPressed(e)

            Case Keys.Left

                keyLeftPressed(e)

            Case Keys.Enter

                keyEnterPressed(sender, e)

            Case Keys.F

                keyFPressed(sender, e)

        End Select

    End Sub

    Private Sub keyTabPressed(e As KeyEventArgs)

        If studentsList.ListViewСписокСлушателей.Focused Then

            studentsList.searchRow.Focus()

        ElseIf studentsList.ССлушТаблицаИнфСлушателя.Focused Or studentsList.BtnFocus.Focused Then

            studentsList.ListViewСписокСлушателей.Focus()

        End If
        e.Handled = True

    End Sub

    Private Sub keyLeftPressed(e As KeyEventArgs)

        If studentsList.ListViewСписокСлушателей.Focused Then

            studentsList.ССлушТаблицаИнфСлушателя.Focus()

        ElseIf studentsList.ССлушТаблицаИнфСлушателя.Focused Then

            studentsList.ListViewСписокСлушателей.Focus()
            e.Handled = True

        ElseIf studentsList.searchRow.Focused Then

            studentsList.BtnFocus.Focus()
            studentsList.header.Focus()
            studentsList.searchSetts.Select()

        End If

    End Sub

    Private Sub keyRightPressed(e As KeyEventArgs)

        If studentsList.ListViewСписокСлушателей.Focused Then

            studentsList.ССлушТаблицаИнфСлушателя.Focus()

        ElseIf studentsList.ССлушТаблицаИнфСлушателя.Focused Then

            studentsList.ListViewСписокСлушателей.Focus()
            e.Handled = True

        ElseIf studentsList.searchRow.Focused Then

            studentsList.BtnFocus.Focus()
            studentsList.header.Focus()
            studentsList.insertIntoGroupList.Select()

        End If

    End Sub
    Private Sub doubleClick(sender As Object, e As EventArgs)

        If IsNothing(studentsList.ListViewСписокСлушателей.SelectedItems) Then Return

        ListViewСписокСлушателей_DoubleClick(sender, e)

    End Sub

    Private Sub keyEnterPressed(sender As Object, e As KeyEventArgs)

        If IsNothing(studentsList.ListViewСписокСлушателей.SelectedItems) Then Return

        ListViewСписокСлушателей_DoubleClick(sender, e)

    End Sub

    Private Sub keyFPressed(sender As Object, e As KeyEventArgs)

        If studentsList.searchRow.Focused Then Return
        e.SuppressKeyPress = True
        studentsList.BtnFocus.Focus()
        studentsList.header.Focus()
        studentsList.sortSetts.Select()

    End Sub
    Private Sub ListViewСписокСлушателей_DoubleClick(sender As Object, e As EventArgs)

        Dim queryString As String
        Dim snils As String

        If Not studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

            snils = addMask.deleteMask(studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)

            newStudent.Text = studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(2).Text & " " & studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(3).Text & " " & studentsList.ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(4).Text & " "

            queryString = load_slushatel(snils)

            studentsList.studentsInfo = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
            studentsList.studentsInfo = arrayMethod.removeEmpty(studentsList.studentsInfo)
            newStudent.student.studentData.prevSnils = snils
            newStudent.flagRedactor = True
            newStudent.fromStudentsList = False
            newStudent.ShowDialog()
            newStudent.flagRedactor = False

        Else MsgBox("информация удалена")

        End If

    End Sub

    Private Sub keyDownPressed()

        If Not studentsList.ListViewСписокСлушателей.Focused Then

            studentsList.ListViewСписокСлушателей.Focus()

        End If

    End Sub

End Class
