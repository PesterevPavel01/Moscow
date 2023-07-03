Imports MySql.Data.MySqlClient

Public Class Organization
    Dim mySQLConnector As New MySQLConnect
    Private sqlQueryString As New SqlQueryString
    Dim queryString As String = ""
    Public result As DataTable = New DataTable
    Public organization As String
    Public full_name As String
    Public flagUpdate As Boolean = False ' редактирование записей
    Public kod As Int64 = -1
    Sub New()
        mySQLConnector.opdateArgument()
    End Sub


    Function load_list_organizations()

        queryString = sqlQueryString.load_list_organization()
        result = mySQLConnector.ЗагрузитьИзMySQLвDataTable(queryString, 1)

    End Function

    Sub save_organization()

        Dim resAr() As String
        If organization.Trim = "" Then
            Return
        End If
        queryString = sqlQueryString.check_organization(organization, full_name)
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return
        End If

        queryString = sqlQueryString.save_organization(organization, full_name)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)

        queryString = sqlQueryString.load_kod_organization(organization)
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If IsNumeric(resAr(0)) Then
            kod = Convert.ToInt64(resAr(0))
        End If

    End Sub

    Function update_organization() As Boolean

        Dim resAr() As String
        If organization.Trim = "" Then
            Return False
        End If

        queryString = sqlQueryString.check_organization(organization, full_name)
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return False
        End If

        queryString = sqlQueryString.update_organization(organization, Convert.ToString(kod), full_name)
        If Not mySQLConnector.ОтправитьВбдЗапись(queryString, 1) Then
            Return False
        Else
            Return True
        End If

    End Function

    Function removeOrganization() As Boolean

        Dim resAr() As String
        If organization.Trim = "" Then
            Return False
        End If

        queryString = sqlQueryString.check_kod_organization(Convert.ToString(kod))
        resAr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If Not resAr(0) = "0" Then
            Return False
        End If

        If kod = -1 Then
            Return False
        End If

        queryString = sqlQueryString.delete_organization(Convert.ToString(kod))
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)

        Return True

    End Function
End Class
