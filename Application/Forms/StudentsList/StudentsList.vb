Public Class StudentsList
    Public massiv
    Public Press As Boolean
    Public DelitMask As Boolean
    Public masckAdded = False
    Public studentsInfo
    Private formEvents As New StudentsList_events

    Public Sub showStudentsList()

        Dim queryString As String, columnSearch, columnSort As String

        ListViewСписокСлушателей.Visible = False

        columnSort = interfaceMod.nameCheckedCheckBox(sortSettsStudents)
        columnSearch = interfaceMod.nameCheckedCheckBox(НастройкаПоискаСлушателей)

        searchRow.Visible = True
        searchSetts.Visible = True

        queryString = studentsList__loadStudentsList(columnSort, interfaceMod.sortType(formEvents.sort_events.sortSetts.flagSortUp))

        massiv = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
        massiv = arrayMethod.removeEmpty(massiv)
        massiv = addMask.addMaskIntoArray(massiv, 1)

        updateListView.updateListView(False, True, ListViewСписокСлушателей, massiv, 1, 2, 3, 4)
        searchRow.Text = ""
        ActiveControl = ListViewСписокСлушателей
        Try
            ListViewСписокСлушателей.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try
        ListViewСписокСлушателей.Visible = True

        formEvents.studentsList = Me
        formEvents.init()

    End Sub

    Private Sub СтрокаПоиска_TextChanged(sender As Object, e As EventArgs) Handles searchRow.TextChanged

        If masckAdded Then

            searchRow.SelectionStart = Len(searchRow.Text)
            Exit Sub

        End If

        search()

    End Sub

    Sub search()

        Dim searchField As String, sortField As String

        sortField = interfaceMod.nameCheckedCheckBox(sortSettsStudents)
        searchField = interfaceMod.nameCheckedCheckBox(НастройкаПоискаСлушателей)


        If searchField = "Снилс" Then

            massiv = sqlSearch(addMask.deleteMask(searchRow.Text), "students", "Снилс, Фамилия, Имя, Отчество, ДатаРождения", searchField, sortField & interfaceMod.sortType(formEvents.sort_events.sortSetts.flagSortUp))

            If Not Press Then

                masckAdded = True
                searchRow.Text = addMask.РубашкаНаВвод(searchRow.Text, 3, 3, 3, 14)


            End If
            Press = True

            If Not massiv(0, 0) = "нет записей" Then

                massiv = addMask.addMaskIntoArray(massiv, 0)

            End If

        Else

            massiv = sqlSearch(searchRow.Text, "students", "Снилс, Фамилия, Имя, Отчество, ДатаРождения", searchField, sortField & interfaceMod.sortType(formEvents.sort_events.sortSetts.flagSortUp))
            massiv = addMask.addMaskIntoArray(massiv, 0)

        End If

        UpdateListView.updateListView(False, True, ListViewСписокСлушателей, massiv, 0, 1, 2, 3, 4)

        searchRow.SelectionStart = Len(searchRow.Text)

    End Sub

    Private Sub searchField_KeyDown(sender As Object, e As KeyEventArgs) Handles searchRow.KeyDown

        Dim str As String


        str = searchRow.Text


        If e.KeyCode = Keys.Back Then

            Press = True
            searchRow.Text = addMask.removeLastChar(str)

        End If

        Press = False
        masckAdded = False

    End Sub

    Private Sub studentList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.SelectedIndexChanged

        Dim Dtable As DataTable
        Dim Snils, SqlString As String

        Try

            Snils = addMask.deleteMask(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)

        Catch ex As Exception

            Exit Sub

        End Try

        SqlString = sprSlushTblGroup(Snils)
        Dtable = MainForm.mySqlConnect.mySqlToDataTable(SqlString, 1)
        ССлушТаблицаИнфСлушателя.DataSource = Dtable

        If ССлушТаблицаИнфСлушателя.Columns.Count <> 5 Then

            Return

        End If

        ССлушТаблицаИнфСлушателя.Columns(0).Width = ССлушТаблицаИнфСлушателя.Width * 0.1
        ССлушТаблицаИнфСлушателя.Columns(1).Width = ССлушТаблицаИнфСлушателя.Width * 0.15
        ССлушТаблицаИнфСлушателя.Columns(2).Width = ССлушТаблицаИнфСлушателя.Width * 0.5
        ССлушТаблицаИнфСлушателя.Columns(3).Width = ССлушТаблицаИнфСлушателя.Width * 0.125
        ССлушТаблицаИнфСлушателя.Columns(4).Width = ССлушТаблицаИнфСлушателя.Width * 0.125

        ССлушТаблицаИнфСлушателя.DefaultCellStyle.Font = New Font("Microsoft YaHei", 10)

    End Sub

End Class