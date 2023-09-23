
Imports MySql.Data.MySqlClient

Public Class MySQLConnect

    Public mySqlSettings As ArgumentMySqlConnect
    Public dSet As DataSet

    Sub opdateArgument()
        mySqlSettings.nameFirstDB = "database"
        mySqlSettings.userName = "admin"
        mySqlSettings.password = "admin"
        mySqlSettings.ODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlSettings.server = "localhost"
    End Sub


    Public Function dateToFormatMySQL(_date As String) As String

        If _date = "null" Or _date = "" Then
            Return "null"
        Else
            Dim dateD As DateTime = Convert.ToDateTime(_date)
            Return dateD.Year.ToString() + "-" + dateD.Month.ToString() + "-" + dateD.Day.ToString() + " " + dateD.TimeOfDay.ToString()
        End If
    End Function

    Public Function loadMySqlToArray(sqlString As String, numberDB As Int16) As Object(,)

        Dim result As Object(,)
        Dim list As New List(Of String)
        Dim resultList As New List(Of List(Of String))

        databaseQuery(sqlString, numberDB)

        Dim row As DataRow
        Dim rowCount As Integer = 0

        ReDim result(dSet.Tables(0).Columns.Count, dSet.Tables(0).Rows.Count - 1)

        If (dSet.Tables(0).Rows.Count = 0) Then
            ReDim result(1, 1)
            result(0, 0) = "нет записей"
            Return result
        End If

        For Each row In dSet.Tables(0).Rows
            For i = 0 To dSet.Tables(0).Columns.Count - 1
                result(i, rowCount) = row.Item(i).ToString
            Next
            rowCount += 1
        Next

        Return arrayMethod.removeEmpty(result)
        dSet.Dispose()

    End Function

    Public Function sendQuery(sqlString As String, numberDB As Int16) As Boolean

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

            Using command = New MySqlCommand()

                command.Connection = mySqlConnection
                command.CommandText = sqlString
                Try
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    result = False
                End Try

                mySqlConnection.Close()

            End Using
        End Using

        Return result

    End Function


    Public Function sendListToMySql(list As List(Of String), BazaNumber As Int16) As Boolean

        Dim status As Boolean = True
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

            Using command = New MySqlCommand()
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
        End Using

        Return status

    End Function

    Public Function mySqlToDataTable(sqlString As String, numberDB As Int16) As DataTable

        databaseQuery(sqlString, numberDB)
        Return dSet.Tables(0)

    End Function

    Public Function mySqlToList(sqlString As String, numberDB As Int16, numberColumn As Integer) As List(Of String)

        Dim list As List(Of String) = New List(Of String)

        databaseQuery(sqlString, numberDB)

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(row.Item(numberColumn))
        Next

        DSet.Dispose()

        Return list

    End Function

    Public Function mySqlToListAll(sqlString As String, numberDB As Int16) As List(Of List(Of String))

        Dim list As New List(Of String)
        Dim resultList As New List(Of List(Of String))

        databaseQuery(sqlString, numberDB)

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
        dSet.Dispose()

    End Function

    Public Function loadIntoarray(sqlString As String, numberDB As Int16, numberColumn As Integer) As Object

        Dim list As New List(Of String)

        databaseQuery(sqlString, numberDB)

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(Convert.ToString(row.Item(numberColumn)))
        Next
        Return list.ToArray
        dSet.Dispose()

    End Function

    Public Function LoadToListString(sqlString As String, numberDB As Int16, numberColumn As Integer) As List(Of String)

        Dim list As New List(Of String)

        databaseQuery(sqlString, numberDB)

        Dim row As DataRow

        For Each row In dSet.Tables(0).Rows
            list.Add(Convert.ToString(row.Item(numberColumn)))
        Next

        Return list
        dSet.Dispose()

    End Function

    Private Sub databaseQuery(sqlString As String, numberDB As Int16)

        Dim connectionString As String
        dSet = New DataSet

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
            Using command = New MySqlCommand(sqlString, connection)
                Using adapter = New MySqlDataAdapter(command)

                    adapter.Fill(dSet, "Result")
                    connection.Close()

                End Using
            End Using
        End Using

    End Sub

End Class
Public Structure ArgumentMySqlConnect

    Public server As String
    Public userName As String
    Public password As String
    Public nameFirstDB As String
    Public ИмяБазыДанныхБ As String
    Public ODBC As String
End Structure