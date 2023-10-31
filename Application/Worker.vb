Imports WindowsApp2.Programm

Public Class Worker

    Dim mySQLConnector As New MySQLConnect
    Private sqlQueryString As New SqlQueryString
    Dim queryString As String = ""
    Public listWorkers As List(Of List(Of String))
    Public worker_struct As Worker_structure
    Public flagRedactor As Boolean = False ' редактирование чекбоксов
    Public flagTextBox As Boolean = False ' активен текстбокс
    Public flagUpdate As Boolean = False ' редактирование записей
    Public default_type As String ' тип работника поумолчанию
    'Public activTextBox As String ' имя текстбокса на котором была нажата клавиша enter
    Public Structure Worker_structure

        Dim kod As Int64
        Dim name As String
        Dim name_full As String
        Dim name_pad As String
        Dim worker_position As String
        Dim worker_type As String
        Dim worker_dolj() As String
        Dim worker_type_list() As String
        Dim worker_check As Int16

    End Structure

    Private Sub load_default_type()

        Dim result() As String
        queryString = sqlQueryString.loadDefaultType()
        result = mySQLConnector.loadIntoArray(queryString, 1, 0)

        If result.Length < 1 Then

            Return

        End If

        default_type = result(0)

    End Sub

    Public Sub update_status_list()

        queryString = ""
        queryString = sqlQueryString.update_status_list(Convert.ToString(worker_struct.kod), Convert.ToString(worker_struct.worker_check))
        mySQLConnector.sendQuery(queryString, 1)

    End Sub

    Public Sub loadLists()

        queryString = ""
        queryString = sqlQueryString.loadListPosition()
        worker_struct.worker_dolj = mySQLConnector.loadIntoArray(queryString, 1, 0)

        queryString = sqlQueryString.loadListWorkerType()
        worker_struct.worker_type_list = mySQLConnector.loadIntoArray(queryString, 1, 0)

        load_default_type()

    End Sub

    Public Sub loadWorker()

        mySQLConnector.opdateArgument()
        queryString = ""
        queryString = sqlQueryString.loadWorker()
        listWorkers = mySQLConnector.mySqlToListAll(queryString, 1)

    End Sub

    Function removeWorker() As Boolean

        Dim result() As String
        queryString = ""
        queryString = sqlQueryString.checkWorker(Convert.ToString(worker_struct.kod))
        result = mySQLConnector.loadIntoArray(queryString, 1, 0)
        If Not result(0) = "0" Then
            Return False
        End If
        queryString = sqlQueryString.removeWorker(Convert.ToString(worker_struct.kod))
        mySQLConnector.sendQuery(queryString, 1)
        Return True

    End Function

    Public Function checkWorker() As Boolean

        Dim result() As String

        queryString = sqlQueryString.loadNumberWorker(worker_struct.name)
        result = mySQLConnector.loadIntoArray(queryString, 1, 0)

        If result(0) = "0" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub addWorker()

        'Dim worker_type() As String
        Dim result() As String
        'worker_type = worker_struct.worker_type.Split("-")
        'If worker_type.Count <> 2 Then
        '    Return
        'End If
        queryString = ""
        queryString = sqlQueryString.addWorker(worker_struct, worker_struct.worker_type)
        mySQLConnector.sendQuery(queryString, 1)

        queryString = sqlQueryString.loadKodWorker(worker_struct.name)
        result = mySQLConnector.loadIntoArray(queryString, 1, 0)
        If IsNumeric(result(0)) Then
            worker_struct.kod = Convert.ToInt32(result(0))
        Else
            worker_struct.kod = -1
        End If
    End Sub

    Public Sub updateWorker()

        Dim worker_type() As String

        'worker_type = worker_struct.worker_type.Split("-")
        'If worker_type.Count <> 2 Then
        '    Return
        'End If
        queryString = ""
        queryString = sqlQueryString.updateWorker(worker_struct, worker_struct.worker_type)
        mySQLConnector.sendQuery(queryString, 1)

    End Sub

End Class
