Imports System.Threading
Public Class StudentsInGroup

    Dim SC As SynchronizationContext
    Public cvalification As Int16
    Public tbl_studentsInGroup As New Tables_control
    Dim studentsInGroup_builder As New StudentsInGroup_builder

    Private Sub loadStudentsInGroup()

        tbl_studentsInGroup.Parent = container
        tbl_studentsInGroup.Dock = DockStyle.Fill
        tbl_studentsInGroup.Visible = True
        tbl_studentsInGroup.number_column = 2
        tbl_studentsInGroup.flag_second_control_combo = True
        tbl_studentsInGroup.flag_first_control_combo = True
        tbl_studentsInGroup.comboBox_second_element.nameParent = "group_list"
        tbl_studentsInGroup.comboBox_first_element.nameParent = "group_list"
        tbl_studentsInGroup.add_on = False

        tbl_studentsInGroup.queryString_load = studentList__studentListInGroup(GroupList.kod)

        If (tbl_studentsInGroup.width_column.Count = 0) Then

            tbl_studentsInGroup.width_column.Add(0, 12)
            tbl_studentsInGroup.width_column.Add(1, 14)
            tbl_studentsInGroup.width_column.Add(2, 14)
            tbl_studentsInGroup.width_column.Add(3, 14)
            tbl_studentsInGroup.width_column.Add(4, 15)
            tbl_studentsInGroup.width_column.Add(5, 20)
            tbl_studentsInGroup.width_column.Add(6, 10)

        End If

        tbl_studentsInGroup.kod_number = 0
        tbl_studentsInGroup.numberElementFirst = 6
        tbl_studentsInGroup.numberElementSecond = 5
        tbl_studentsInGroup.names.redactor_element_first = "Финансирование"
        tbl_studentsInGroup.names.db_element_first = "source_financing"
        tbl_studentsInGroup.names.redactor_element_second = "Организация"
        tbl_studentsInGroup.names.db_element_second = "organization"
        tbl_studentsInGroup.name_table = "group_list"

        If tbl_studentsInGroup.comboBox_second_element.adjacentControls.count = 0 Then

            tbl_studentsInGroup.comboBox_second_element.adjacentControls.Add("next", tbl_studentsInGroup.DataGridTablesResult)
            tbl_studentsInGroup.comboBox_second_element.adjacentControls.Add("prev", tbl_studentsInGroup.comboBox_first_element)

            tbl_studentsInGroup.comboBox_first_element.adjacentControls.Add("next", tbl_studentsInGroup.comboBox_second_element)
            tbl_studentsInGroup.comboBox_first_element.adjacentControls.Add("prev", tbl_studentsInGroup.DataGridTablesResult)

        End If

        studentsInGroup_builder.load_listOrganization()
        studentsInGroup_builder.load_listFinancing()
        tbl_studentsInGroup.comboBox_second_element.settings.item_list = studentsInGroup_builder.listOrganization
        tbl_studentsInGroup.comboBox_first_element.settings.item_list = studentsInGroup_builder.listFinancing
        'tbl_studentInGroup.kod_number = 2
        tbl_studentsInGroup.table_init()

    End Sub

    Private Sub СписокСлушателейВГруппе_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'SC = SynchronizationContext.Current
        'Dim secondThread As Thread
        'Dim argument
        'ReDim argument(2)
        'argument(0) = GroupList.kod
        'argument(1) = MainForm.mySqlConnect.mySqlSettings

        'secondThread = New Thread(AddressOf studentListInGroup)
        'secondThread.IsBackground = True
        'secondThread.Start(argument)

    End Sub

    'Sub studentListInGroup(argument)

    '    Dim studentList
    '    Dim params
    '    Dim queryStr As String
    '    Dim mySqlConn As New MySQLConnect

    '    mySqlConn.mySqlSettings = argument(1)

    '    queryStr = studentList__studentListInGroup(argument(0))

    '    studentList = mySqlConn.loadMySqlToArray(queryStr, 1)

    '    If studentList(0, 0) = "Нет записей" Then

    '        Exit Sub

    '    End If

    'studentList = arrayMethod.removeEmpty(studentList)

    'ReDim params(7)
    'params(0) = Me
    'params(1) = ListViewStudentsList
    'params(2) = addMask.addMaskIntoArray(studentList, 0)
    'params(3) = 0
    'params(4) = 1
    'params(5) = 2
    'params(6) = 3
    'params(7) = 4

    'SC.Send(AddressOf UpdateListView.updateListV, params)

    'End Sub

    Public Sub dataGridTables_RemoveStudent(snils As String, name As String)

        ФормаДаНетУдалить.текстДаНет.Text = "Вы хотите удалить слушателя " + name + " из группы?"

        ФормаДаНетУдалить.ShowDialog()

        ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

        If Not ФормаДаНетУдалить.НажатаКнопкаДа Then

            Return

        End If

        Dim kod As Integer = GroupList.kod

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "group_list"
        InsertIntoDataBase.argument.firstName = "Kod"
        InsertIntoDataBase.argument.firstValue = GroupList.kod
        InsertIntoDataBase.argument.secondName = "students"
        InsertIntoDataBase.argument.secondValue = snils

        If InsertIntoDataBase.checkUniq_No2() = 2 Then
            InsertIntoDataBase.deleteFromDB_NumberArg()
            tbl_studentsInGroup.load_table()
        End If

    End Sub

    Public Sub tableListStudents_CellDoubleClick(sender As Object, e As EventArgs, name As String, snils As String)

        Dim sqlQuery As String

        WindowsApp2.newStudent.Text = name + " "

        sqlQuery = load_slushatel(snils)

        WindowsApp2.StudentsList.studentsInfo = arrayMethod.removeEmpty(MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1))

        WindowsApp2.newStudent.student.studentData.prevSnils = snils
        WindowsApp2.newStudent.flagRedactor = True
        WindowsApp2.newStudent.ShowDialog()
        WindowsApp2.newStudent.flagRedactor = False
        СписокСлушателейВГруппе_Shown(sender, e)

    End Sub

    Private Sub ДобавитьВГруппу_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        pressTab(e.KeyCode, 39)
    End Sub

    Private Sub ДобавитьВгруппуНового_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        pressTab(e.KeyCode, 39)
    End Sub

    Private Sub Прочее_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        pressTab(e.KeyCode, 39)
    End Sub

    Private Sub ListViewСписокСлушателей_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        pressTab(e.KeyCode, 39)
    End Sub

    Private Sub SplitContainer1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles SplitContainer1.PreviewKeyDown
        pressTab(e.KeyCode, 39)
    End Sub

    Private Sub SplitContainer2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        pressTab(e.KeyCode, 39)
    End Sub

    Private Sub SplitContainer3_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        pressTab(e.KeyCode, 39)
    End Sub

    Public Sub studentsInGroup_KeyDown(e As KeyEventArgs)

        If tbl_studentsInGroup.flag_active_control And tbl_studentsInGroup.flagUpdate Then

            If e.KeyCode = Keys.Escape Then

                tbl_studentsInGroup.builder.redactorClose()

            End If

        Else
            closeEsc(Me, e.KeyCode)
        End If
    End Sub
    Private Sub StudentsInGroup_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown

        If tbl_studentsInGroup.flag_active_control Then
            e.IsInputKey = True
        End If

    End Sub

    Private Sub studentsList_Click(sender As Object, e As EventArgs) Handles studentsList.Click

        WindowsApp2.StudentsList.showStudentsList()
        WindowsApp2.StudentsList.insertIntoGroupList.Visible = True
        WindowsApp2.StudentsList.ShowDialog()

    End Sub

    Private Sub newStudent_Click(sender As Object, e As EventArgs) Handles newStudent.Click
        WindowsApp2.newStudent.fromStudentsList = True
        WindowsApp2.newStudent.ShowDialog()
    End Sub

    Private Sub allInfo_Click(sender As Object, e As EventArgs) Handles allInfo.Click

        newGroup.Enabled = True
        newGroup.redactorMode = True
        newGroup.ShowDialog()

    End Sub

    Private Sub StudentList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        cleaner(newGroup)

    End Sub

    Private Sub StudentsInGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        studentsInGroup_builder.mySQLConnector = MainForm.mySqlConnect
        loadStudentsInGroup()
    End Sub
End Class