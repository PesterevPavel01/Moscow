Public Class Doljnosti
    Dim mySQLConnector As New MySQLConnect
    Private sqlQueryString As New SqlQueryString
    Dim queryString As String = ""
    Public result As DataTable = New DataTable
    Public doljnost As String
    Public flagUpdate As Boolean = False ' редактирование записей
    Public kod As Int64 = -1

    Sub New()
        mySQLConnector.opdateArgument()
    End Sub


    Function load_list_doljnosti()

        queryString = sqlQueryString.load_list_doljnosti()
        result = mySQLConnector.ЗагрузитьИзMySQLвDataTable(queryString, 1)

    End Function

    Sub save_doljnost()

        Dim resAr() As String
        If doljnost.Trim = "" Then
            Return
        End If
        queryString = sqlQueryString.check_doljnost(doljnost)
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return
        End If

        queryString = sqlQueryString.save_doljnost(doljnost)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)

        queryString = sqlQueryString.load_kod_doljnost(doljnost)
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If IsNumeric(resAr(0)) Then
            kod = Convert.ToInt64(resAr(0))
        End If

    End Sub

    Function update_doljnost() As Boolean

        Dim resAr() As String
        If doljnost.Trim = "" Then
            Return False
        End If

        queryString = sqlQueryString.check_doljnost(doljnost)
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return False
        End If

        queryString = sqlQueryString.update_doljnost(doljnost, Convert.ToString(kod))
        If Not mySQLConnector.ОтправитьВбдЗапись(queryString, 1) Then
            Return False
        Else
            Return True
        End If

    End Function

    Function removeDoljnost() As Boolean

        Dim resAr() As String
        If kod = -1 Then
            Return False
        End If

        queryString = sqlQueryString.check_kod_doljnost(kod)
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return False
        End If

        queryString = sqlQueryString.delete_doljnost(Convert.ToString(kod))
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)

        Return True

    End Function



End Class
