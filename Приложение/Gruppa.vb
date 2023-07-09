Public Class Gruppa
    Private sqlQueryString As New SqlQueryString
    Private mySQLConnector As New MySQLConnect
    Public struct_gruppa As strGruppa
    Public flagGrouppForm As FormGrouppFlag
    Public formGrouppLists As FormGroupplLists
    Structure strGruppa

        Dim flagAllListProgs As Boolean
        Dim kodProgramm As Integer
        Dim Kod As Int32
        Dim yearNZ As Int32
        Dim oldYearNZ As Int32
        Dim oldNumber As String
        Dim nameForma As String
        Dim dataNZ As String
        Dim dataKZ As String
        Dim dataVUd As String
        Dim dataVD As String
        Dim dataVSv As String
        Dim dataSpec As String
        Dim number As String
        Dim formaObuch As String
        Dim specialnost As String
        Dim programma As String
        Dim kolChasov As String
        Dim kurator As String
        Dim otvZaPraktiku As String
        Dim dateSozdaniya As String
        Dim modul1 As String
        Dim modul2 As String
        Dim modul3 As String
        Dim modul4 As String
        Dim modul5 As String
        Dim modul6 As String
        Dim modul7 As String
        Dim modul8 As String
        Dim modul9 As String
        Dim modul10 As String
        Dim urKvalific As String
        Dim financir As String
        Dim nomerProtIA As String
        Dim nomerUd As String
        Dim regNomerUd As String
        Dim dateVUd As String
        Dim nomerDiploma As String
        Dim regNomerDiploma As String
        Dim DateVDiploma As String
        Dim nomerSvid As String
        Dim regNomerSvid As String
        Dim dateVSvid As String
        Dim kvalifikaciya As String
        Dim osnovnoyDok As String
        Dim nomerProtokolaSpec As String
        Dim NumbersUDS
        Dim OsnDocument As String


    End Structure

    Public Structure FormGroupplLists
        Public ur_cvalifik() As String
        Public forma_obuch() As String
        Public programma() As String
        Public specialnost() As String
        Public kol_chasov() As String
        Public kurator() As String
        Public otvetstv_praktika() As String
        Public finansirovanie() As String
        Public kvalifikaciya() As String

    End Structure

    Public Structure FormGrouppFlag
        Public ur_cvalifik As Boolean
        Public forma_obuch As Boolean
        Public programma As Boolean
        Public specialnost As Boolean
        Public kurator As Boolean
        Public otvetstv_praktika As Boolean
        Public finansirovanie As Boolean
        Public kvalifikaciya As Boolean
        Public modul_1 As Boolean
        Public modul_2 As Boolean
        Public modul_3 As Boolean
        Public modul_4 As Boolean
        Public modul_5 As Boolean
        Public modul_6 As Boolean
        Public modul_7 As Boolean
        Public modul_8 As Boolean
        Public modul_9 As Boolean
        Public modul_10 As Boolean
    End Structure

    Public Sub loadFormGrouppLists()

        Dim queryString As String

        mySQLConnector.opdateArgument()

        queryString = sqlQueryString.loadUrovenKvalifikacii
        formGrouppLists.ur_cvalifik = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = sqlQueryString.loadForma_obuch()
        formGrouppLists.forma_obuch = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = ProgrammPoUKvalifikLimit1(struct_gruppa.urKvalific)
        formGrouppLists.programma = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = sqlQueryString.loadSpecialnost()
        formGrouppLists.specialnost = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = sqlQueryString.loadKurator()
        formGrouppLists.kurator = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        formGrouppLists.otvetstv_praktika = formGrouppLists.kurator

        queryString = sqlQueryString.loadFinansirovanie()
        formGrouppLists.finansirovanie = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = sqlQueryString.loadKvalifikaciya()
        formGrouppLists.kvalifikaciya = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        flagGrouppForm.ur_cvalifik = False
        flagGrouppForm.forma_obuch = False
        flagGrouppForm.programma = False
        flagGrouppForm.specialnost = False
        flagGrouppForm.kurator = False
        flagGrouppForm.otvetstv_praktika = False
        flagGrouppForm.modul_1 = False
        flagGrouppForm.modul_2 = False
        flagGrouppForm.modul_3 = False
        flagGrouppForm.modul_4 = False
        flagGrouppForm.modul_5 = False
        flagGrouppForm.modul_6 = False
        flagGrouppForm.modul_7 = False
        flagGrouppForm.modul_8 = False
        flagGrouppForm.modul_9 = False
        flagGrouppForm.modul_10 = False

    End Sub

    Public Sub updateProgramma()
        Dim queryString As String
        queryString = ProgrammPoUKvalifikLimit1(struct_gruppa.urKvalific)
        formGrouppLists.programma = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(QueryString, 1, 0)
    End Sub

    Public Sub updateKodProg()

        Dim result As Object(,)
        Dim queryString As String

        queryString = sqlQueryString.loadKogProgramm(struct_gruppa.urKvalific, struct_gruppa.programma)

        result = mySQLConnector.ЗагрузитьИзБДMySQLвМассив(queryString, 1)

        If result.Length < 2 Then

            Return

        End If

        struct_gruppa.kodProgramm = result(0, 0)
        struct_gruppa.kolChasov = result(1, 0)

    End Sub

    Public Sub load_kol_chas()

        Dim result As String()
        Dim queryString As String

        queryString = sqlQueryString.load_kol_chas(struct_gruppa.kodProgramm)

        result = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        If result.Length < 1 Then

            Return

        End If

        struct_gruppa.kolChasov = result(0)
    End Sub

    Public Sub Clear()

    End Sub

End Class
