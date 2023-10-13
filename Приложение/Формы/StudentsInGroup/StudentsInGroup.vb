Imports System.Threading
Public Class StudentsInGroup

    Dim SC As SynchronizationContext
    Public cvalification As Int16
    Public tbl_studentsInGroup As New Tables_control
    Dim uploader As New StudentsInGroup_uploader
    Public organization As String
    Public finansing As String
    Public ordersBuilder As New PanelOrders_builder
    Public formEvents As New StudentsInGroup_Events

    Public Sub loadStudentsInGroup()

        container.Controls.Add(tbl_studentsInGroup)
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

            tbl_studentsInGroup.adjacentControls.Add("next", header)

            tbl_studentsInGroup.comboBox_second_element.adjacentControls.Add("next", tbl_studentsInGroup.DataGridTablesResult)
            tbl_studentsInGroup.comboBox_second_element.adjacentControls.Add("prev", tbl_studentsInGroup.comboBox_first_element)

            tbl_studentsInGroup.comboBox_first_element.adjacentControls.Add("next", tbl_studentsInGroup.comboBox_second_element)
            tbl_studentsInGroup.comboBox_first_element.adjacentControls.Add("prev", tbl_studentsInGroup.DataGridTablesResult)

        End If

        uploader.load_listOrganization()
        uploader.load_listFinancing()
        tbl_studentsInGroup.comboBox_second_element.settings.item_list = uploader.listOrganization
        tbl_studentsInGroup.comboBox_first_element.settings.item_list = uploader.listFinancing
        tbl_studentsInGroup.table_init()
        tbl_studentsInGroup.Dock = DockStyle.Fill

        formEvents.studentsInGroup = Me
        formEvents.init()

    End Sub

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

    Public Sub StudentsInGroup_PreviewKeyDown(e As PreviewKeyDownEventArgs)

        If tbl_studentsInGroup.flag_active_control Then
            e.IsInputKey = True
        End If

    End Sub

    Public Sub studentsList_Click()

        WindowsApp2.StudentsList.showStudentsList()
        WindowsApp2.StudentsList.insertIntoGroupList.Visible = True
        WindowsApp2.StudentsList.ShowDialog()

    End Sub

    Public Sub newStudent_Click()
        WindowsApp2.newStudent.fromStudentsList = True
        WindowsApp2.newStudent.ShowDialog()
    End Sub

    Public Sub allInfo_Click()

        newGroup.Enabled = True
        newGroup.redactorMode = True
        newGroup.ShowDialog()

    End Sub

    Private Sub StudentsInGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ordersBuilder.panelOrders = panelOrders
        ordersBuilder.buttonHeigth = 50
        uploader.mySQLConnector = MainForm.mySqlConnect
        loadStudentsInGroup()

    End Sub

    Public Sub everyone_Click()

        uploader.copyOrgAndFinEveryone(GroupList.kod, finansing, organization)
        tbl_studentsInGroup.load_table()

    End Sub

    Public Sub everyoneVisible(status As Boolean, currentFinSource As String, currentOrganization As String)

        everyone.Visible = status
        finansing = ""
        organization = ""

        If status Then
            finansing = currentFinSource
            organization = currentOrganization
        End If


    End Sub

    Public Sub orders_click()

        mainConteiner.Panel2Collapsed = False
        ordersBuilder.init()
        Dim control As Control = ordersBuilder.buttons.ElementAt(0).Value
        control.Focus()

    End Sub

    Public Sub StudentList_FormClosing()

        cleaner(newGroup)
        mainConteiner.Panel2Collapsed = True

    End Sub

    Public Sub closePanelOrders_Click()

        mainConteiner.Panel2Collapsed = True
        header.Focus()

    End Sub

    Public Sub toolOrders_Enter()
        closePanelOrders.Select()
    End Sub

    Public Sub toolOrders_PreviewKeyDown(e As PreviewKeyDownEventArgs)

        e.IsInputKey = True

    End Sub

    Public Sub toolOrders_KeyDown(e As KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.Enter
                closePanelOrders_Click()
            Case Keys.Up
                header.Focus()
                newStudent.Select()
            Case Keys.Down
                Dim control As Control = ordersBuilder.buttons.ElementAt(0).Value
                control.Focus()
        End Select

    End Sub

    Private Sub header_Enter()

        newStudent.Select()

    End Sub
End Class