
Imports MySql.Data.MySqlClient

Public Class MySQLConnect

    Public mySqlSettings As ArgumentMySqlConnect
    Public adapter As MySqlDataAdapter
    Public dSet As DataSet
    Public mySqlCommand As MySqlCommand
    Public commandBuilder As MySqlCommandBuilder

    Sub opdateArgument()
        mySqlSettings.ИмяБазыДанныхА = "database"
        mySqlSettings.ИмяПользователя = "admin"
        mySqlSettings.пароль = "admin"
        mySqlSettings.ИсточникДанныхODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlSettings.НазваниеСервера = "localhost"
    End Sub


    Public Function dateToFormatMySQL(_date As DateTime) As String
        Dim resultDate As String = ""
        resultDate = _date.Year.ToString() + "-" + _date.Month.ToString() + "-" + _date.Day.ToString() + " " + _date.TimeOfDay.ToString()
        Return resultDate
    End Function
    Public Function ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса As String, numberBD As Int16) As Object(,)

        Dim СтрокаПодключения = "", АДОДБСтрокаПодключения As String
        Dim массив As Object(,)
        Dim КомандаАДОДБ As ADODB.Command = New ADODB.Command()
        Dim АДОДБСоединение As ADODB.Connection = New ADODB.Connection()
        Dim АДОДБКоманда As ADODB.Command = New ADODB.Command()
        Dim Рекордсет As ADODB.Recordset = New ADODB.Recordset()

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberBD = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА
        ElseIf (numberBD = 2) Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхБ
        End If

        АДОДБСтрокаПодключения = СтрокаПодключения + ";" + mySqlSettings.ИсточникДанныхODBC + ";Option=3;"

        АДОДБСоединение.ConnectionString = АДОДБСтрокаПодключения
        АДОДБСоединение.Open()
        Рекордсет.ActiveConnection = АДОДБСоединение
        Рекордсет.Open(СтрокаЗапроса)
        If (Рекордсет.BOF) Then
            ReDim массив(1, 1)
            массив(0, 0) = "нет записей"
            Рекордсет.Close()
            АДОДБСоединение.Close()
            Return массив
        End If
        массив = Рекордсет.GetRows()
        Рекордсет.Close()
        АДОДБСоединение.Close()
        массив = УбратьПустотыВМассиве.УбратьПустотыВМассиве(массив)

        Return массив
    End Function

    Public Function ОтправитьВбдЗапись(sqlString As String, numberDB As Int16) As Boolean
        Dim запрос As MySqlCommand
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()
        Dim result As Boolean = True

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        Else
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        End If

        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()
        запрос = New MySqlCommand()

        запрос.Connection = ПодключениеКБД
        запрос.CommandText = sqlString
        Try
            запрос.ExecuteNonQuery()
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function


    Public Function ОтправитьВбдListЗаписей(list As List(Of String), BazaNumber As Int16) As Boolean

        Dim status As Boolean = True
        Dim запрос As MySqlCommand
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If (BazaNumber = 1) Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        ElseIf (BazaNumber = 2) Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхБ + ";default command timeout=600;"
        End If
        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()

        запрос = New MySqlCommand()
        запрос.Connection = ПодключениеКБД

        For Each SQLString As String In list
            запрос.CommandText = SQLString
            Try
                запрос.ExecuteNonQuery()
            Catch ex As Exception
                status = False
            End Try

        Next

        ПодключениеКБД.Close()

        Return status
    End Function

    Public Function ЗагрузитьИзMySQLвDataTable(sqlString As String, numberDB As Int16) As DataTable
        Dim запрос As MySqlCommand
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()
        Dim Адаптер As MySqlDataAdapter
        Dim DSet As New DataSet

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        Else
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        End If

        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()
        запрос = New MySqlCommand(sqlString, ПодключениеКБД)
        Адаптер = New MySqlDataAdapter(запрос)
        Адаптер.Fill(DSet, "Result")
        ПодключениеКБД.Close()
        ЗагрузитьИзMySQLвDataTable = DSet.Tables(0)

    End Function

    Public Function ЗагрузитьИзMySQLвList(sqlString As String, numberDB As Int16, numberColumn As Integer) As List(Of String)
        Dim запрос As MySqlCommand
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()
        Dim Адаптер As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As List(Of String) = New List(Of String)

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        Else
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        End If

        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()
        запрос = New MySqlCommand(sqlString, ПодключениеКБД)
        Адаптер = New MySqlDataAdapter(запрос)
        Адаптер.Fill(DSet, "Result")
        ПодключениеКБД.Close()

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(row.Item(numberColumn))
        Next

        ЗагрузитьИзMySQLвList = list

    End Function

    Public Function ЗагрузитьИзMySQLвListAll(sqlString As String, numberDB As Int16) As List(Of List(Of String))
        Dim запрос As MySqlCommand
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()
        Dim Адаптер As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As New List(Of String)
        Dim listListov As New List(Of List(Of String))

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        Else
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        End If

        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()
        запрос = New MySqlCommand(sqlString, ПодключениеКБД)
        Адаптер = New MySqlDataAdapter(запрос)
        Адаптер.Fill(DSet, "Result")
        ПодключениеКБД.Close()

        Dim row As DataRow
        Dim count As Integer = 0
        For Each row In DSet.Tables(0).Rows
            listListov.Add(New List(Of String))
            For i = 0 To DSet.Tables(0).Columns.Count - 1
                listListov(count).Add(row.Item(i).ToString)
            Next
            count += 1
        Next

        ЗагрузитьИзMySQLвListAll = listListov

    End Function

    Public Function ЗагрузитьИзMySQLвОдномерныйМассив(sqlString As String, numberDB As Int16, numberColumn As Integer) As Object
        Dim запрос As MySqlCommand
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()
        Dim Адаптер As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As New List(Of String)

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        Else
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        End If

        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()
        запрос = New MySqlCommand(sqlString, ПодключениеКБД)
        Адаптер = New MySqlDataAdapter(запрос)
        Адаптер.Fill(DSet, "Result")
        ПодключениеКБД.Close()

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(row.Item(numberColumn))
        Next

        ЗагрузитьИзMySQLвОдномерныйМассив = list.ToArray

    End Function

    Public Function LoadToListString(sqlString As String, numberDB As Int16, numberColumn As Integer) As List(Of String)
        Dim запрос As MySqlCommand
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()
        Dim Адаптер As MySqlDataAdapter
        Dim DSet As New DataSet
        Dim list As New List(Of String)

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        Else
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        End If

        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()
        запрос = New MySqlCommand(sqlString, ПодключениеКБД)
        Адаптер = New MySqlDataAdapter(запрос)
        Адаптер.Fill(DSet, "Result")
        ПодключениеКБД.Close()

        Dim row As DataRow

        For Each row In DSet.Tables(0).Rows
            list.Add(Convert.ToString(row.Item(numberColumn)))
        Next

        LoadToListString = list

    End Function

    Public Function ЗагрузитьИзMySQLвDataTablePlAdapter(sqlString As String, numberDB As Int16) As DataTable
        Dim СтрокаПодключения As String
        Dim ПодключениеКБД = New MySqlConnection()
        dSet = New DataSet()

        If mySqlSettings.НазваниеСервера = "" Then
            opdateArgument()
        End If

        If numberDB = 1 Then
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        Else
            СтрокаПодключения = "server=" + mySqlSettings.НазваниеСервера + ";" + "User Id=" + mySqlSettings.ИмяПользователя + ";password=" + mySqlSettings.пароль + ";Persist Security Info=True;" + "database=" + mySqlSettings.ИмяБазыДанныхА + ";default command timeout=600;"
        End If

        ПодключениеКБД.ConnectionString = СтрокаПодключения
        ПодключениеКБД.Open()
        mySqlCommand = New MySqlCommand(sqlString, ПодключениеКБД)
        adapter = New MySqlDataAdapter(mySqlCommand)
        commandBuilder = New MySqlCommandBuilder(adapter)
        adapter.Fill(dSet, "Result")
        ПодключениеКБД.Close()
        ЗагрузитьИзMySQLвDataTablePlAdapter = dSet.Tables(0)

    End Function


End Class
Public Structure ArgumentMySqlConnect

    Public НазваниеСервера As String
    Public ИмяПользователя As String
    Public пароль As String
    Public ИмяБазыДанныхА As String
    Public ИмяБазыДанныхБ As String
    Public ИсточникДанныхODBC As String
End Structure