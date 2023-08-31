Imports WindowsApp2.Student

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
        Dim list_types As String()
    End Structure

    Public Structure modul_struct
        Dim name As String
        Dim hours As Double
    End Structure

    Public Sub program_loadHoursList()

        Dim queryString As String
        queryString = sqlQueryString.program__loadHours(struct_progs.program_kod)
        struct_progs.list_hours = mySQLConnector.loadIntoarray(queryString, 1, 0)

    End Sub

    Public Sub program__loadTypelist()

        Dim queryString As String
        queryString = sqlQueryString.program__loadTypeList()
        struct_progs.list_types = mySQLConnector.loadIntoarray(queryString, 1, 0)

    End Sub

    Public Function program__loadTypes() As String
        Dim queryString As String
        queryString = sqlQueryString.program__loadTypes(struct_progs.program_kod)
        Return queryString
    End Function

    Public Function programm__loadProgramms() As String
        Dim queryString As String
        queryString = sqlQueryString.program__loadProgramms(uroven_cval)
        Return queryString
    End Function

    Public Sub program__loadModulAndHours()

        Dim result() As String

        Dim queryString As String
        queryString = sqlQueryString.program__loadModulsAndHours(struct_progs.program_kod)
        struct_progs.tbl_modulsInProgs = mySQLConnector.mySqlToDataTable(queryString, 1)

        queryString = sqlQueryString.load_sum_hours(struct_progs.program_kod)
        result = mySQLConnector.loadIntoarray(queryString, 1, 0)

        If result.Length = 0 Then
            struct_progs.sum_hours_programm = 0
            Return
        End If

        If IsNumeric(result(0)) Then

            struct_progs.sum_hours_programm = Convert.ToInt64(result(0))

        Else

            struct_progs.sum_hours_programm = 0

        End If

    End Sub

    Public Sub program__loadModul()

        Dim queryString As String
        queryString = sqlQueryString.program__loadModuls()
        struct_progs.tbl_moduls = mySQLConnector.mySqlToDataTable(queryString, 1)

    End Sub

    Public Sub program__updateModul(hours As String)
        Dim queryString As String
        If Not IsNumeric(struct_progs.modul_kod) Then
            Return
        End If
        queryString = sqlQueryString.updateModulHours(hours, struct_progs.modul_kod, struct_progs.program_kod)
        mySQLConnector.sendQuery(queryString, 1)
    End Sub

    Public Sub program__addProgramm(programm As String)
        Dim queryString As String
        queryString = sqlQueryString.addProgramm(programm, uroven_cval)
        mySQLConnector.sendQuery(queryString, 1)
    End Sub

    Public Function program__loadLastKodProgramm(programm As String) As String
        Dim queryString As String
        Dim result As List(Of String)
        Dim kod As String
        queryString = sqlQueryString.loadLastKodProgramm(programm, uroven_cval)
        result = mySQLConnector.mySqlToList(queryString, 1, 0)
        If result.Count = 1 Then
            kod = result(0)
        End If
        Return kod
    End Function

    Public Function program__loadLastKodModul(modul As String) As String
        Dim queryString As String
        Dim result As List(Of String)
        Dim kod As String
        queryString = sqlQueryString.loadLastKodModul(modul)
        result = mySQLConnector.mySqlToList(queryString, 1, 0)
        If result.Count = 1 Then
            kod = result(0)
        End If
        Return kod
    End Function

    Public Function program__loadLastKodModulInProgramm(modul As String) As String
        Dim queryString As String
        Dim result As List(Of String)
        Dim kod As String
        queryString = sqlQueryString.loadLastKodModul(modul)
        result = mySQLConnector.mySqlToList(queryString, 1, 0)
        If result.Count = 1 Then
            kod = result(0)
        End If
        Return kod
    End Function

    Public Sub program__deleteModul_prog()
        If Not IsNumeric(struct_progs.program_kod) Then
            Return
        End If
        Dim queryString As String
        queryString = sqlQueryString.deleteModul_prog(struct_progs.modul_kod, struct_progs.program_kod)
        mySQLConnector.sendQuery(queryString, 1)
    End Sub

    Public Sub program__updateProgramm(programm As String)
        Dim queryString As String
        queryString = sqlQueryString.updateProgramm(programm, struct_progs.program_kod_update)
        mySQLConnector.sendQuery(queryString, 1)
    End Sub

    Public Sub program__deleteProgramm()
        Dim queryString As String
        queryString = sqlQueryString.deleteProgramm(struct_progs.program_kod)
        mySQLConnector.sendQuery(queryString, 1)
    End Sub

    Public Function program__updateMudulsTop(modul_kod As String) As Boolean

        Dim status As Boolean = False
        Dim number As List(Of List(Of String))
        Dim QueryString As String
        QueryString = sqlQueryString.selectNumberModulTop(struct_progs.program_kod, modul_kod)
        number = mySQLConnector.mySqlToListAll(QueryString, 1)

        If Not number.Count = 2 Then
            Return status
        End If

        QueryString = sqlQueryString.updateModulnumber(number, struct_progs.program_kod)
        mySQLConnector.sendQuery(QueryString, 1)

        Return True
    End Function

    Public Function program__updateMudulsBottom(modul_kod As String) As Boolean

        Dim status As Boolean = False
        Dim number As List(Of List(Of String))
        Dim QueryString As String
        QueryString = sqlQueryString.selectNumberModulButtom(struct_progs.program_kod, modul_kod)
        number = mySQLConnector.mySqlToListAll(QueryString, 1)
        If Not number.Count = 2 Then
            Return status
        End If
        QueryString = sqlQueryString.updateModulnumber(number, struct_progs.program_kod)
        mySQLConnector.sendQuery(QueryString, 1)
        Return True

    End Function

    Public Sub program__updateMudulsInGroup(modul_kod As String)
        Dim QueryString As String
        QueryString = sqlQueryString.insertModulIntoProg(struct_progs.program_kod, modul_kod)
        mySQLConnector.sendQuery(QueryString, 1)
    End Sub

    Public Sub program__addNewModul(name As String, hours As String)

        Dim QueryString As String
        If Not IsNumeric(hours) Then
            Return
        End If
        QueryString = sqlQueryString.insertModul(name, hours)
        mySQLConnector.sendQuery(QueryString, 1)

    End Sub

    Public Sub program__updateModuliNModuls(name As String, hours As String)

        Dim queryString As String
        If Not IsNumeric(hours) Then
            Return
        End If
        queryString = sqlQueryString.updateModul(name, hours, struct_progs.modul_kod_inModuls)
        mySQLConnector.sendQuery(queryString, 1)

    End Sub

    Public Sub program__deleteModul(kod As String)

        Dim queryString As String
        queryString = sqlQueryString.deleteModul(kod)
        mySQLConnector.sendQuery(queryString, 1)

    End Sub

End Class
