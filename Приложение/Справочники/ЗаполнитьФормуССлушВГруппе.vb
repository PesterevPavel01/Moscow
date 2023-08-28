Module ЗаполнитьФормуССлушВГруппе

    Sub updateFormStudentsList(kod As String)

        Dim studentsList
        Dim queryString As String

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "group_list"
        InsertIntoDataBase.argument.firstName = "Kod"
        InsertIntoDataBase.argument.firstValue = kod

        If InsertIntoDataBase.checkUniq_No2() = 2 Then

            queryString = redactorFormListGroup__loadData(kod)

            studentsList = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            If studentsList(0, 0) = "Нет записей" Then
                StudentList.ListViewStudentsList.Items.Clear()
                Exit Sub
            End If

            UpdateListView.updateListView(False, True, StudentList.ListViewStudentsList, addMask.addMask(studentsList, 0), 0, 1, 2, 3, 4)

        Else
            StudentList.ListViewStudentsList.Items.Clear()
        End If

    End Sub



End Module
