Imports WindowsApp2.Slushatel

Public Class Programm
    Dim mySQLConnector As New MySQLConnect
    Private sqlQueryString As New SqlQueryString
    Public uroven_cval As String
    Public struct_progs As Programm_struct

    Public Structure Programm_struct
        Dim flagEscape As Boolean
        Dim flag_update_modul As Boolean
        Dim flagProgTbl As Boolean
        Dim flag_update As Boolean
        Dim flag_update_modInProg As Boolean
        Dim modul_kod_inModuls As String
        Dim modul_kod As String
        Dim sum_hours_programm As Int64
        Dim name_current_modul As String
        Dim program_kod As String
        Dim program_kod_update As String
        'Dim list_progs As List(Of String)
        Dim tbl_progs As DataTable
        Dim tbl_modulsInProgs As DataTable
        Dim tbl_moduls As DataTable
        Dim list_moduls As List(Of modul_struct)
        Dim list_hours As String()
    End Structure

    Public Structure modul_struct
        Dim name As String
        Dim hours As Double
    End Structure

    Public Sub load_hours_list()

        Dim queryString As String
        queryString = sqlQueryString.loadHours(struct_progs.program_kod)
        struct_progs.list_hours = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

    End Sub

    Public Function loadProgramms() As String
        Dim queryString As String
        queryString = sqlQueryString.loadProgramms(uroven_cval)
        Return queryString
    End Function

    Public Sub loadModulAndHours()

        Dim result() As String

        Dim queryString As String
        queryString = sqlQueryString.loadModulsAndHours(struct_progs.program_kod)
        struct_progs.tbl_modulsInProgs = mySQLConnector.ЗагрузитьИзMySQLвDataTable(queryString, 1)

        queryString = sqlQueryString.load_sum_hours(struct_progs.program_kod)
        result = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If IsNumeric(result(0)) Then

            struct_progs.sum_hours_programm = Convert.ToInt64(result(0))

        Else

            struct_progs.sum_hours_programm = 0

        End If

    End Sub

    Public Sub loadModul()
        Dim queryString As String
        queryString = sqlQueryString.loadModuls()
        struct_progs.tbl_moduls = mySQLConnector.ЗагрузитьИзMySQLвDataTable(queryString, 1)
    End Sub

    Public Sub updateModul(hours As String)
        Dim queryString As String
        If Not IsNumeric(struct_progs.modul_kod) Then
            Return
        End If
        queryString = sqlQueryString.updateModulHours(hours, struct_progs.modul_kod, struct_progs.program_kod)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Public Sub addProgramm(programm As String)
        Dim queryString As String
        queryString = sqlQueryString.addProgramm(programm, uroven_cval)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Public Function loadLastKodProgramm(programm As String) As String
        Dim queryString As String
        Dim result As List(Of String)
        Dim kod As String
        queryString = sqlQueryString.loadLastKodProgramm(programm, uroven_cval)
        result = mySQLConnector.ЗагрузитьИзMySQLвList(queryString, 1, 0)
        If result.Count = 1 Then
            kod = result(0)
        End If
        Return kod
    End Function

    Public Function loadLastKodModul(modul As String) As String
        Dim queryString As String
        Dim result As List(Of String)
        Dim kod As String
        queryString = sqlQueryString.loadLastKodModul(modul)
        result = mySQLConnector.ЗагрузитьИзMySQLвList(queryString, 1, 0)
        If result.Count = 1 Then
            kod = result(0)
        End If
        Return kod
    End Function

    Public Function loadLastKodModulInProgramm(modul As String) As String
        Dim queryString As String
        Dim result As List(Of String)
        Dim kod As String
        queryString = sqlQueryString.loadLastKodModul(modul)
        result = mySQLConnector.ЗагрузитьИзMySQLвList(queryString, 1, 0)
        If result.Count = 1 Then
            kod = result(0)
        End If
        Return kod
    End Function

    Public Sub deleteModul_prog()
        If Not IsNumeric(struct_progs.program_kod) Then
            Return
        End If
        Dim queryString As String
        queryString = sqlQueryString.deleteModul_prog(struct_progs.modul_kod, struct_progs.program_kod)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Public Sub updateProgramm(programm As String)
        Dim queryString As String
        queryString = sqlQueryString.updateProgramm(programm, struct_progs.program_kod_update)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Public Sub deleteProgramm()
        Dim queryString As String
        queryString = sqlQueryString.deleteProgramm(struct_progs.program_kod)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Public Function updateMudulsTop(modul_kod As String) As Boolean
        Dim status As Boolean = False
        Dim number As List(Of List(Of String))
        Dim QueryString As String
        QueryString = sqlQueryString.selectNumberModulTop(struct_progs.program_kod, modul_kod)
        number = mySQLConnector.ЗагрузитьИзMySQLвListAll(QueryString, 1)

        If Not number.Count = 2 Then
            Return status
        End If

        QueryString = sqlQueryString.updateModulnumber(number, struct_progs.program_kod)
        mySQLConnector.ОтправитьВбдЗапись(QueryString, 1)

        Return True
    End Function

    Public Function updateMudulsBottom(modul_kod As String) As Boolean
        Dim status As Boolean = False
        Dim number As List(Of List(Of String))
        Dim QueryString As String
        QueryString = sqlQueryString.selectNumberModulButtom(struct_progs.program_kod, modul_kod)
        number = mySQLConnector.ЗагрузитьИзMySQLвListAll(QueryString, 1)
        If Not number.Count = 2 Then
            Return status
        End If
        QueryString = sqlQueryString.updateModulnumber(number, struct_progs.program_kod)
        mySQLConnector.ОтправитьВбдЗапись(QueryString, 1)
        Return True
    End Function

    Public Sub updateMudulsInGroup(modul_kod As String)
        Dim QueryString As String
        QueryString = sqlQueryString.insertModulIntoProg(struct_progs.program_kod, modul_kod)
        mySQLConnector.ОтправитьВбдЗапись(QueryString, 1)
    End Sub

    Public Sub addNewModul(name As String, hours As String)
        Dim QueryString As String
        If Not IsNumeric(hours) Then
            Return
        End If
        QueryString = sqlQueryString.insertModul(name, hours)
        mySQLConnector.ОтправитьВбдЗапись(QueryString, 1)
    End Sub

    Public Sub updateModuliNModuls(name As String, hours As String)
        Dim QueryString As String
        If Not IsNumeric(hours) Then
            Return
        End If
        QueryString = sqlQueryString.updateModul(name, hours, struct_progs.modul_kod_inModuls)
        mySQLConnector.ОтправитьВбдЗапись(QueryString, 1)
    End Sub

    Public Sub deleteModul(kod As String)
        Dim queryString As String
        queryString = sqlQueryString.deleteModul(kod)
        mySQLConnector.ОтправитьВбдЗапись(queryString, 1)
    End Sub

End Class
