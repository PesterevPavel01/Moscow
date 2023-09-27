Module updateStudentsInGroup

    'Sub updateFormStudentsInGroup(kod As String)

    '    Dim studentsList
    '    Dim queryString As String

    '    InsertIntoDataBase.argumentClear()
    '    InsertIntoDataBase.argument.nameTable = "group_list"
    '    InsertIntoDataBase.argument.firstName = "Kod"
    '    InsertIntoDataBase.argument.firstValue = kod

    '    If InsertIntoDataBase.checkUniq_No2() = 2 Then

    '        queryString = redactorFormListGroup__loadData(kod)

    '        studentsList = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

    '        If studentsList(0, 0) = "нет записей" Then
    '            StudentsInGroup.ListViewStudentsList.Items.Clear()
    '            Exit Sub
    '        End If

    '        updateListView.updateListView(False, True, StudentsInGroup.ListViewStudentsList, addMask.addMaskIntoArray(studentsList, 0), 0, 1, 2, 3, 4)

    '    Else
    '        StudentsInGroup.ListViewStudentsList.Items.Clear()
    '    End If

    'End Sub



End Module
