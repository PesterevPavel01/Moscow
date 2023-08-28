
Imports MySql.Data.MySqlClient

Public Class MySQLConnect

    Public mySqlSettings As ArgumentMySqlConnect
    Public adapter As MySqlDataAdapter
    Public dSet As DataSet
    Public mySqlCommand As MySqlCommand
    Public commandBuilder As MySqlCommandBuilder

    Sub opdateArgument()
        mySqlSettings.nameFirstDB = "database"
        mySqlSettings.userName = "admin"
        mySqlSettings.password = "admin"
        mySqlSettings.ODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlSettings.server = "localhost"
    End Sub


    Public Function dateToFormatMySQL(_date As DateTime) As String
        Dim resultDate As String = ""
        resultDate = _date.Year.ToString() + "-" + _date.Month.ToString() + "-" + _date.Day.ToString() + " " + _date.TimeOfDay.ToString()
        Return resultDate
    End Function
    Public Function loadMySqlToArray(СтрокаЗапроса As String, numberBD As Int16) As Object(,)

        Dim connectionString = "", ADODBConnString As String
        Dim array As Object(,)
        Dim AdodbConnection As ADODB.Connection = New ADODB.Connection()
        Dim recordset As ADODB.Recordset = New ADODB.Recordset()

        If mySqlSettings.server = "" Then
            opdateArgument()
        End If

        If numberBD = 1 Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB
        ElseIf (numberBD = 2) Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхБ
        End If

        ADODBConnString = connectionString + ";" + mySqlSettings.ODBC + ";Option=3;"

        AdodbConnection.ConnectionString = ADODBConnString
        AdodbConnection.Open()
        recordset.ActiveConnection = AdodbConnection
        recordset.Open(СтрокаЗапроса)
        If (recordset.BOF) Then
            ReDim array(1, 1)
            array(0, 0) = "нет записей"
            recordset.Close()
            AdodbConnection.Close()
            Return array
        End If
        array = recordset.GetRows()
        recordset.Close()
        AdodbConnection.Close()
        array = УбратьПустотыВМассиве.УбратьПустотыВМассиве(array)

        Return array
    End Function

    Public Function sendQuery(sqlString As String, numberDB As Int16) As Boolean
        Dim command As MySqlCommand
        Dim connectionString As String
        Dim result As Boolean = True

        Using mySqlConnection = New MySqlConnection()

            If mySqlSettings.server = "" Then
                opdateArgument()
            End If

            If numberDB = 1 Then
                connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
            Else
                connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
            End If

            mySqlConnection.ConnectionString = connectionString
            mySqlConnection.Open()
            command = New MySqlCommand()

            command.Connection = mySqlConnection
            command.CommandText = sqlString
            Try
                command.ExecuteNonQuery()
            Catch ex As Exception
                result = False
            End Try
            mySqlConnection.Close()

        End Using

        Return result

    End Function


    Public Function sendListToMySql(list As List(Of String), BazaNumber As Int16) As Boolean

        Dim status As Boolean = True
        Dim command As MySqlCommand
        Dim connectionString As String

        If mySqlSettings.server = "" Then
            opdateArgument()
        End If

        If (BazaNumber = 1) Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        ElseIf (BazaNumber = 2) Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхБ + ";default command timeout=600;"
        End If

        Using connection = New MySqlConnection()

            connection.ConnectionString = connectionString
            connection.Open()

            command = New MySqlCommand()
            command.Connection = connection

            For Each SQLString As String In list
                command.CommandText = SQLString
                Try
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    status = False
                End Try

            Next

            connection.Close()

        End Using

        Return status
    End Function

    Public Function mySqlToDataTable(sqlString As String, numberDB As Int16) As DataTable
        Dim command As MySqlCommand
        Dim connectionString As String
        Dim adapter As MySqlDataAdapter
        Dim DSet As New DataSet

        If mySqlSettings.server = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        Else
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        End If

        Using connection = New MySqlConnection()

            connection.ConnectionString = connectionString
            connection.Open()
            command = New MySqlCommand(sqlString, connection)
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DSet, "Result")
            connection.Close()
            mySqlToDataTable = DSet.Tables(0)

        End Using

    End Function

    Public Function mySqlToList(sqlString As String, numberDB As Int16, numberColumn As Integer) As List(Of String)
        Dim command As MySqlCommand
        Dim connectionString As String
        Dim adapter As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As List(Of String) = New List(Of String)

        If mySqlSettings.server = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        Else
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        End If

        Using connection = New MySqlConnection()

            connection.ConnectionString = connectionString
            connection.Open()
            command = New MySqlCommand(sqlString, connection)
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DSet, "Result")
            connection.Close()

        End Using

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(row.Item(numberColumn))
        Next

        Return list

    End Function

    Public Function mySqlToListAll(sqlString As String, numberDB As Int16) As List(Of List(Of String))
        Dim запрос As MySqlCommand
        Dim connectionString As String
        Dim adapter As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As New List(Of String)
        Dim resultList As New List(Of List(Of String))

        If mySqlSettings.server = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        Else
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        End If

        Using connection = New MySqlConnection()

            connection.ConnectionString = connectionString
            connection.Open()
            запрос = New MySqlCommand(sqlString, connection)
            adapter = New MySqlDataAdapter(запрос)
            adapter.Fill(DSet, "Result")
            connection.Close()

        End Using

        Dim row As DataRow
        Dim count As Integer = 0
        For Each row In DSet.Tables(0).Rows
            resultList.Add(New List(Of String))
            For i = 0 To DSet.Tables(0).Columns.Count - 1
                resultList(count).Add(row.Item(i).ToString)
            Next
            count += 1
        Next

        Return resultList

    End Function

    Public Function ЗагрузитьИзMySQLвОдномерныйМассив(sqlString As String, numberDB As Int16, numberColumn As Integer) As Object
        Dim command As MySqlCommand
        Dim connectionString As String
        Dim adapter As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As New List(Of String)

        If mySqlSettings.server = "" Then
            opdateArgument()
        End If

        Using mySqlCunnection = New MySqlConnection()

            If numberDB = 1 Then
                connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
            Else
                connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
            End If

            mySqlCunnection.ConnectionString = connectionString
            mySqlCunnection.Open()

            command = New MySqlCommand(sqlString, mySqlCunnection)
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DSet, "Result")
            mySqlCunnection.Close()


        End Using

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(row.Item(numberColumn))
        Next

        ЗагрузитьИзMySQLвОдномерныйМассив = list.ToArray

    End Function

    Public Function LoadToListString(sqlString As String, numberDB As Int16, numberColumn As Integer) As List(Of String)
        Dim command As MySqlCommand
        Dim connectionString As String
        Dim adapter As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As New List(Of String)

        If mySqlSettings.server = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        Else
            connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
        End If

        Using connection = New MySqlConnection()

            connection.ConnectionString = connectionString
            connection.Open()
            command = New MySqlCommand(sqlString, connection)
            adapter = New MySqlDataAdapter(command)
            adapter.Fill(DSet, "Result")
            connection.Close()

        End Using

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(Convert.ToString(row.Item(numberColumn)))
        Next

        Return list

    End Function

    'Public Function ЗагрузитьИзMySQLвDataTablePlAdapter(sqlString As String, numberDB As Int16) As DataTable
    '    Dim connectionString As String
    '    Dim connection = New MySqlConnection()
    '    dSet = New DataSet()

    '    If mySqlSettings.server = "" Then
    '        opdateArgument()
    '    End If

    '    If numberDB = 1 Then
    '        connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
    '    Else
    '        connectionString = "server=" + mySqlSettings.server + ";" + "User Id=" + mySqlSettings.userName + ";password=" + mySqlSettings.password + ";Persist Security Info=True;" + "database=" + mySqlSettings.nameFirstDB + ";default command timeout=600;"
    '    End If

    '    connection.ConnectionString = connectionString
    '    connection.Open()
    '    mySqlCommand = New MySqlCommand(sqlString, connection)
    '    adapter = New MySqlDataAdapter(mySqlCommand)
    '    commandBuilder = New MySqlCommandBuilder(adapter)
    '    adapter.Fill(dSet, "Result")
    '    connection.Close()
    '    ЗагрузитьИзMySQLвDataTablePlAdapter = dSet.Tables(0)

    'End Function


End Class
Public Structure ArgumentMySqlConnect

    Public server As String
    Public userName As String
    Public password As String
    Public nameFirstDB As String
    Public ИмяБазыДанныхБ As String
    Public ODBC As String
End Structure