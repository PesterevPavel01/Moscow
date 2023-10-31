
Public Class DGVRedactorTable

    Public userDGV As Tables_control
    Dim result
    Dim sqlQuery As String

    Public Sub removeRow()

        Dim curNumber = userDGV.DataGridTablesResult.CurrentCell.RowIndex
        ФормаДаНетУдалить.текстДаНет.Text = "Удалить " + userDGV.DataGridTablesResult.Rows(curNumber).Cells(userDGV.numberElementFirst).Value + "?"
        ФормаДаНетУдалить.ShowDialog()

        If Not ФормаДаНетУдалить.НажатаКнопкаДа Then
            Return
        End If

        ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

        userDGV.remove_kod = Convert.ToInt64(userDGV.DataGridTablesResult.Rows(curNumber).Cells(userDGV.kod_number).Value)

        If userDGV.program_on Then
            sqlQuery = MainForm.sqlQueryString.programs__checkKodGrouppBusy(userDGV.remove_kod)
            result = userDGV.mySQLConnector.loadIntoArray(sqlQuery, 1, 0)

            If Convert.ToInt16(result(0)) > 0 Then

                MsgBox("Программа не может быть удалена, т.к. закреплена за группой", 0, "Внимание")
                Return
            End If
        End If

        sqlQuery = MainForm.sqlQueryString.update_delete_query(userDGV.program_on, userDGV.name_table, MainForm.comboBoxProgramms.Text, userDGV.remove_kod)

        userDGV.mySQLConnector.sendQuery(sqlQuery, 1)

        If userDGV.redactor_element_first.Text.Trim = Convert.ToString(userDGV.DataGridTablesResult.Rows(curNumber).Cells(userDGV.numberElementFirst).Value) Then

            SendKeys.Send("{ESC}")

        End If

        userDGV.load_table()

        If (curNumber <> 0) Then

            userDGV.DataGridTablesResult.CurrentCell = userDGV.DataGridTablesResult.Rows(curNumber - 1).Cells(userDGV.numberElementFirst)

        End If

    End Sub

    Public Sub updateRow()

        Dim resAr() As String

        If userDGV.program_on Then

            If userDGV.values.element_first = "" Or userDGV.values.element_second = "" Then Return
            sqlQuery = MainForm.sqlQueryString.update_prog_check_query(userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second, MainForm.comboBoxProgramms.Text)

        ElseIf userDGV.type_progs_on Then

            sqlQuery = MainForm.sqlQueryString.update_typeProgs_check_query(Convert.ToString(MainForm.program.struct_progs.program_kod), Convert.ToString(userDGV.values.kod), userDGV.values.element_first)
        Else
            sqlQuery = MainForm.sqlQueryString.update_check_query(userDGV.number_column, userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second)
        End If

        resAr = userDGV.mySQLConnector.loadIntoArray(sqlQuery, 1, 0)

        If Not resAr(0) = "0" Then
            Return
        End If
        If userDGV.program_on Then

            sqlQuery = MainForm.sqlQueryString.update_prog_update_query(userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second, userDGV.values.kod)

        ElseIf userDGV.type_progs_on Then

            sqlQuery = MainForm.sqlQueryString.update_typeProgs_update_query(Convert.ToString(MainForm.program.struct_progs.program_kod), Convert.ToString(userDGV.values.kod), Convert.ToString(userDGV.values.element_first))

        ElseIf userDGV.name_table = "group_list" Then

            sqlQuery = MainForm.sqlQueryString.update_updateStudentsInGroup(userDGV.values.element_first, userDGV.values.element_second, userDGV.values.snils, GroupList.kod)
        Else

            sqlQuery = MainForm.sqlQueryString.update_update_query(userDGV.number_column, userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second, userDGV.values.kod)

        End If

        userDGV.mySQLConnector.sendQuery(sqlQuery, 1)

    End Sub

    Public Sub addRow()

        Dim resAr() As String

        If userDGV.program_on Then

            If userDGV.values.element_first = "" Or userDGV.values.element_second = "" Then Return
            sqlQuery = MainForm.sqlQueryString.update_prog_check_query(userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second, MainForm.comboBoxProgramms.Text)

        ElseIf userDGV.type_progs_on Then

            Return

        Else

            sqlQuery = MainForm.sqlQueryString.update_check_query(userDGV.number_column, userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second)

        End If

        resAr = userDGV.mySQLConnector.loadIntoArray(sqlQuery, 1, 0)

        If Not resAr(0) = "0" Then

            Return

        End If

        If userDGV.program_on Then

            sqlQuery = MainForm.sqlQueryString.update_prog_insert_query(userDGV.number_column, userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second, MainForm.comboBoxProgramms.Text)

        Else

            sqlQuery = MainForm.sqlQueryString.update_insert_query(userDGV.number_column, userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second)

        End If

        userDGV.mySQLConnector.sendQuery(sqlQuery, 1)

        If userDGV.program_on Then

            sqlQuery = MainForm.sqlQueryString.update_prog_load_kod_query(userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, MainForm.comboBoxProgramms.Text)

        Else

            sqlQuery = MainForm.sqlQueryString.update_load_kod_query(userDGV.number_column, userDGV.name_table, userDGV.names.db_element_first, userDGV.values.element_first, userDGV.names.db_element_second, userDGV.values.element_second)

        End If

        resAr = userDGV.mySQLConnector.loadIntoArray(sqlQuery, 1, 0)

        userDGV.values.kod = resAr(0)

    End Sub

End Class
