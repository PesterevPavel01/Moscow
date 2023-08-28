﻿Imports System.Threading
Imports System.IO
Public Class StudentList

    Dim SC As SynchronizationContext

    Sub ЗагрузитьРедакторГруппы()
        РедакторГруппы.loadFormGruppa()
        ЗаполнитьРедакторГруппы.ЗаполнитьРедакторГруппы(СправочникГруппы.numberGr)
    End Sub

    Private Sub СписокСлушателейВГруппе_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        SC = SynchronizationContext.Current
        Dim secondThread As Thread
        Dim argument
        ReDim argument(2)
        argument(0) = СправочникГруппы.kod
        argument(1) = MainForm.mySqlConnect.mySqlSettings

        secondThread = New Thread(AddressOf studentListInGroup)
        secondThread.IsBackground = True
        secondThread.Start(argument)

        ActiveControl = ListViewStudentsList

    End Sub

    Sub studentListInGroup(argument)

        Dim studentList
        Dim params
        Dim queryStr As String
        Dim mySqlConn As New MySQLConnect

        mySqlConn.mySqlSettings = argument(1)

        queryStr = studentList__studentListInGroup(argument(0))

        studentList = mySqlConn.loadMySqlToArray(queryStr, 1)

        If studentList(0, 0) = "Нет записей" Then

            Exit Sub

        End If

        studentList = УбратьПустотыВМассиве.УбратьПустотыВМассиве(studentList)

        ReDim params(7)
        params(0) = Me
        params(1) = ListViewStudentsList
        params(2) = addMask.addMask(studentList, 0)
        params(3) = 0
        params(4) = 1
        params(5) = 2
        params(6) = 3
        params(7) = 4

        SC.Send(AddressOf UpdateListView.updateListV, params)

    End Sub

    Private Sub ListViewСписокСлушателей_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewStudentsList.KeyDown

        If e.KeyCode = Keys.Delete Then

            ФормаДаНетУдалить.текстДаНет.Text = "Вы хотите удалить слушателя " + ListViewStudentsList.SelectedItems.Item(0).SubItems(2).Text + " из группы?"

            ФормаДаНетУдалить.ShowDialog()

            ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

            If Not ФормаДаНетУдалить.НажатаКнопкаДа Then

                Return

            End If

            Dim kod As Integer = СправочникГруппы.kod
            Dim snils As String

            Try

                snils = ListViewStudentsList.SelectedItems.Item(0).SubItems(1).Text

            Catch ex As Exception

                MsgBox("Слушатель не выбран")

            End Try

            snils = deleteMasck(snils)

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "group_list"
            InsertIntoDataBase.argument.firstName = "Kod"
            InsertIntoDataBase.argument.firstValue = СправочникГруппы.kod
            InsertIntoDataBase.argument.secondName = "students"
            InsertIntoDataBase.argument.secondValue = snils

            If InsertIntoDataBase.checkUniq_No2() = 2 Then
                InsertIntoDataBase.deleteFromDB_NumberArg()
                ЗаполнитьФормуССлушВГруппе.updateFormStudentsList(СправочникГруппы.kod)
            End If



        End If


    End Sub


    Private Sub ListViewСписокСлушателей_DoubleClick(sender As Object, e As EventArgs) Handles ListViewStudentsList.DoubleClick

        Dim queryString As String
        Dim snils As String

        Try

            If Not ListViewStudentsList.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

                snils = addMask.deleteMasck(ListViewStudentsList.SelectedItems.Item(0).SubItems(1).Text)

                РедакторСлушателя.Text = ListViewStudentsList.SelectedItems.Item(0).SubItems(2).Text & " " & ListViewStudentsList.SelectedItems.Item(0).SubItems(3).Text & " " & ListViewStudentsList.SelectedItems.Item(0).SubItems(4).Text & " "

                queryString = load_slushatel(snils)

                ФормаСправочникСлушатели.studentsInfo = УбратьПустотыВМассиве.УбратьПустотыВМассиве(MainForm.mySqlConnect.loadMySqlToArray(queryString, 1))

                '                РедакторСлушателя.prevFormSpisSlushVGr = True

                РедакторСлушателя.ShowDialog()

                СписокСлушателейВГруппе_Shown(sender, e)

            Else MsgBox("информация удалена")

            End If
        Catch ex As Exception

        End Try

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

    Private Sub ListViewСписокСлушателей_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ListViewStudentsList.PreviewKeyDown
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

    Private Sub СписокСлушателейВГруппе_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        closeEsc(Me, e.KeyCode)
    End Sub

    Private Sub studentsList_Click(sender As Object, e As EventArgs) Handles studentsList.Click

        ФормаСправочникСлушатели.showStudentsList()
        ФормаСправочникСлушатели.insertIntoGroupList.Visible = True
        ФормаСправочникСлушатели.ShowDialog()

    End Sub

    Private Sub newStudent_Click(sender As Object, e As EventArgs) Handles newStudent.Click
        НовыйСлушатель.ВызваноСФормыСписокСлушателей = True
        НовыйСлушатель.ShowDialog()
    End Sub

    Private Sub allInfo_Click(sender As Object, e As EventArgs) Handles allInfo.Click
        ЗагрузитьРедакторГруппы()
        РедакторГруппы.ShowDialog()
        Очиститьформу(РедакторГруппы)
    End Sub
End Class