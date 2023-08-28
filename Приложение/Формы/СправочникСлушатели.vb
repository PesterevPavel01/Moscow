Public Class ФормаСправочникСлушатели
    Public massiv
    Public Press As Boolean
    Public DelitMask As Boolean
    Public str As String
    Public masckAdded = False
    Public studentsInfo

    Public Sub showStudentsList()

        Dim queryString As String, columnSearch, columnSort As String

        ListViewСписокСлушателей.Visible = False

        columnSort = interfaceMod.nameCheckedCheckBox(sortSettsStudents)
        columnSearch = interfaceMod.nameCheckedCheckBox(НастройкаПоискаСлушателей)

        searchRow.Visible = True
        searchSetts.Visible = True

        queryString = studentsList__loadStudentsList(columnSort, interfaceMod.sortType(sortSettsStudents.sortSetts.flagSortUp))

        massiv = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
        massiv = УбратьПустотыВМассиве.УбратьПустотыВМассиве(massiv)
        massiv = addMask.addMask(massiv)

        Call UpdateListView.updateListView(False, True, ListViewСписокСлушателей, massiv, 1, 2, 3, 4)
        searchRow.Text = ""
        ActiveControl = ListViewСписокСлушателей
        Try
            ListViewСписокСлушателей.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try
        ListViewСписокСлушателей.Visible = True

    End Sub

    Private Sub ListViewСписокСлушателей_DoubleClick(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.DoubleClick

        Dim queryString As String
        Dim snils As String

        If Not ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

            snils = addMask.deleteMasck(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)

            РедакторСлушателя.Text = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(2).Text & " " & ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(3).Text & " " & ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(4).Text & " "

            queryString = load_slushatel(snils)

            studentsInfo = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
            studentsInfo = УбратьПустотыВМассиве.УбратьПустотыВМассиве(studentsInfo)

            РедакторСлушателя.Show()

        Else MsgBox("информация удалена")

        End If

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

            massiv = sqlSearch(addMask.deleteMasck(searchRow.Text), "students", "Снилс, Фамилия, Имя, Отчество, ДатаРождения", searchField, sortField & interfaceMod.sortType(sortSettsStudents.sortSetts.flagSortUp))

            If Not Press Then

                masckAdded = True
                searchRow.Text = addMask.РубашкаНаВвод(searchRow.Text, 3, 3, 3, 14)


            End If
            Press = True

            If Not massiv(0, 0) = "нет записей" Then

                massiv = addMask.addMask(massiv, 0)

            End If

        Else

            massiv = sqlSearch(searchRow.Text, "students", "Снилс, Фамилия, Имя, Отчество, ДатаРождения", searchField, sortField)
            massiv = addMask.addMask(massiv, 0)

        End If

        UpdateListView.updateListView(False, True, ListViewСписокСлушателей, massiv, 0, 1, 2, 3, 4)

        searchRow.SelectionStart = Len(searchRow.Text)

    End Sub

    Private Sub ФормаСправочникСлушатели_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        searchRow.Visible = True

    End Sub

    Private Sub СтрокаПоиска_KeyDown(sender As Object, e As KeyEventArgs) Handles searchRow.KeyDown

        Dim str As String


        str = searchRow.Text


        If e.KeyCode = 8 Then

            Press = True
            searchRow.Text = addMask.УдалитьДефисВРубашке(str)

        End If

        Press = False
        masckAdded = False

    End Sub

    Private Sub ListViewСписокСлушателей_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewСписокСлушателей.KeyDown
        Dim element
        Dim ind As String
        Dim nomer As Integer, счетчик As Integer

        'Label2.Visible = False


        If e.KeyCode = Keys.Delete Then

            element = ListViewСписокСлушателей.SelectedItems.Count

            ind = deleteMasck(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)
            nomer = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(0).Text

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "students"
            InsertIntoDataBase.argument.firstName = "СНИЛС"
            InsertIntoDataBase.argument.firstValue = ind

            If Not InsertIntoDataBase.checkDuplicates() Then

                MsgBox("Ошибка. Запись уже удалена. Нажмите кнопку Загрузить из базы, чтобы обновить список")
                GoTo Конец

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

                    'Label2.Visible = True
                    'Label2.Text = "Слушатель: Снилс №" & ind & " был удален."
                    Call ИзменениеВыделеннойСтрокиВListView.ИзменениеВыделеннойСтрокиВListView("СправочникСлушатели", 1, "удалено", 2, "удалено", 3, "удалено", 4, "удалено")
                    счетчик = 0
                    While счетчик < UBound(massiv, 1)

                        massiv(счетчик, nomer - 1) = "удалено"
                        счетчик = счетчик + 1

                    End While

                End If

            End If



        End If


Конец:
    End Sub

    Private Sub ListViewСписокСлушателей_GotFocus(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.GotFocus
        Dim str As String
        Try
            str = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
        Catch ex As Exception

            Try
                ListViewСписокСлушателей.Items(0).Selected = True
            Catch ex1 As Exception
                Exit Sub
            End Try

        End Try

    End Sub

    Private Sub ФормаСправочникСлушатели_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        '_________________________________________Esc
        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If


        '_________________________________________вниз
        If e.KeyCode = Keys.Down Then

            If Not ListViewСписокСлушателей.Focused Then

                SendKeys.Send("{tab}")

            Else

                Try
                    str = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
                Catch ex As Exception

                    Try
                        ListViewСписокСлушателей.Items(0).Selected = True
                    Catch ex1 As Exception
                        SendKeys.Send("{tab}")
                    End Try

                End Try


            End If

        End If
        '_________________________________________вправо
        If e.KeyCode = Keys.Right Then

            If Not ListViewСписокСлушателей.Focused Then

                SendKeys.Send("{tab}")

            End If

        End If

        '_________________________________________энтер

        If e.KeyCode = Keys.Enter Then

            Try
                str = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text

            Catch ex As Exception

                Exit Sub

            End Try


            ListViewСписокСлушателей_DoubleClick(sender, e)

        End If



    End Sub

    Private Sub ДобавитьВГруппу_GotFocus(sender As Object, e As EventArgs)

        interfaceMod.controlFont(searchSetts, 14.0F)

    End Sub

    Private Sub ДобавитьВГруппу_LostFocus(sender As Object, e As EventArgs)

        interfaceMod.controlFont(searchSetts, 11.0F)

    End Sub

    Private Sub searchSetts_Click(sender As Object, e As EventArgs) Handles searchSetts.Click

        searchRow.Clear()
        НастройкаПоискаСлушателей.ShowDialog()

    End Sub

    Private Sub studentList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.SelectedIndexChanged

        Dim Dtable As DataTable
        Dim Snils, SqlString As String

        Try

            Snils = addMask.deleteMasck(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)

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

    Private Sub insertIntoGroupList_Click(sender As Object, e As EventArgs) Handles insertIntoGroupList.Click

        Dim snils As String

        Try
            snils = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
        Catch ex As Exception
            MsgBox("Слушатель не выбран")
            Exit Sub
        End Try

        snils = addMask.deleteMasck(snils)

        Вспомогательный.insertIntoGroupList(snils)
        ActiveControl = BtnFocus
    End Sub

    Private Sub sortSetts_Click(sender As Object, e As EventArgs) Handles sortSetts.Click

        sortSettsStudents.ShowDialog()

    End Sub
End Class