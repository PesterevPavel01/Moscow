Imports WindowsApp2.Gruppa

Public Class Prikaz

    Private sqlQueryString As New SqlQueryString
    Private mySQLConnector As New MySQLConnect
    Public formPrikazList As FormPrikazLists
    Public formPrikazFlag As FormPrikazFlags
    Public kod_groupp As String

    Public Structure FormPrikazLists
        Public director() As String
        Public directorDoljnost() As String
        Public otv_attestat() As String
        Public proect_vnosit() As String
        Public ispolnitel() As String
        Public soglasovano() As String
        Public komissiya() As String
        Public prepod() As String
        Public ruk_staj() As String
        Public slushatelFio() As String
        Public doljnosti() As String
    End Structure

    Public Structure FormPrikazFlags
        Public director As Boolean
        Public directorDoljnost As Boolean
        Public otv_attestat As Boolean
        Public proekt_vnosit As Boolean
        Public ispolnitel As Boolean
        Public soglasovano As Boolean
        Public soglasovano2 As Boolean
        Public rukovoditelStaj As Boolean
        Public komissiya2 As Boolean
        Public komissiya3 As Boolean
        Public sekretar As Boolean
        Public zam_pred As Boolean
    End Structure

    Public Sub loadFormPrikazLists()

        Dim queryString As String

        mySQLConnector.opdateArgument()

        queryString = sqlQueryString.loadDirector()
        formPrikazList.director = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
        flipDirector()

        queryString = sqlQueryString.loadDirectorDoljnost()
        formPrikazList.directorDoljnost = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        loadOtv_attestat()
        load_proeсt_vnosit()
        load_ispolnitel()
        load_soglasovano()
        load_komissiya()
        load_list_prepod()
        load_ruk_staj()

        queryString = sqlQueryString.loadDoljnosti()
        formPrikazList.doljnosti = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        formPrikazFlag.director = False
        formPrikazFlag.directorDoljnost = False
        formPrikazFlag.otv_attestat = False

    End Sub

    Private Sub flipDirector()
        Dim result As List(Of String) = New List(Of String)
        For Each fio As String In formPrikazList.director
            fio = fio.Trim
            fio = Strings.Right(fio, 4) & " " & Strings.Left(fio, Strings.Len(fio) - 4)
            result.Add(fio)
        Next
        formPrikazList.director = result.ToArray
    End Sub

    Private Sub load_ruk_staj()
        Dim queryString As String
        queryString = sqlQueryString.load_ruk_staj()
        formPrikazList.ruk_staj = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub

    Private Sub load_list_prepod()
        Dim queryString As String
        queryString = sqlQueryString.load_komissiya()
        formPrikazList.komissiya = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub

    Private Sub load_komissiya()
        Dim queryString As String
        queryString = sqlQueryString.load_komissiya()
        formPrikazList.komissiya = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub

    Private Sub load_soglasovano()
        Dim queryString As String
        queryString = sqlQueryString.load_soglasovano()
        formPrikazList.soglasovano = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub

    Private Sub load_ispolnitel()
        Dim queryString As String
        queryString = sqlQueryString.load_ispolnitel()
        formPrikazList.ispolnitel = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub

    Private Sub load_proeсt_vnosit()
        Dim queryString As String
        queryString = sqlQueryString.load_proeсt_vnosit()
        formPrikazList.proect_vnosit = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub

    Public Sub loadOtv_attestat()
        Dim queryString As String
        queryString = sqlQueryString.loadOtv_attestat()
        formPrikazList.otv_attestat = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub

    Public Sub loadslushatelFio()
        Dim queryString As String
        queryString = sqlQueryString.slushatelFio(kod_groupp)
        formPrikazList.slushatelFio = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)
    End Sub


End Class
