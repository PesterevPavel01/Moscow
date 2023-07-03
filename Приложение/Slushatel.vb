Public Class Slushatel


    Public flagSlushatelForm As formSlushatelFlag
    Public structSlushatel As strSlushatel
    Public formSlushLists As formSlushatelLists
    Dim mySQLConnector As New MySQLConnect

    Structure strSlushatel
        Dim kodGroup As Integer
        Dim snils As String
        Dim snilsRub As String
        Dim старыйСнилс As String
        Dim фамилия As String
        Dim имя As String
        Dim отчество As String
        Dim датаР As String
        Dim уровеньОбразования As String
        Dim образование As String
        Dim doo_vid_dok As String
        Dim серияДокументаООбразовании As String
        Dim номерДокументаООбразовании As String
        Dim фамилияВДокОбОбразовании As String
        Dim адресРегистрации As String
        Dim гражданство As String
        Dim телефон As String
        Dim ДУЛ As String
        Dim серияДУЛ As String
        Dim номерДУЛ As String
        Dim источникФин As String
        Dim направившаяОрг As String
        Dim номерНаправленияРосздравнадзора As String
        Dim датаНаправленияРосздравнвдзора As String
        Dim специальностьСлушателя As String
        Dim Email As String
        Dim датаРег As String
        Dim датаВыдачиДУЛ As String
        Dim кемВыданДУЛ As String
        Dim пол As String

    End Structure

    Public Structure formSlushatelLists
        Public doo_vid_dok() As String
        Public pol() As String
        Public urovenObr() As String
        Public DOO_strana() As String
        Public grajdanstvo() As String
        Public dok_UL() As String
        Public ist_finans() As String
        Public napr_organization() As String
    End Structure

    Public Structure formSlushatelFlag
        Public doo_vid_dok As Boolean
        Public pol As Boolean
        Public urovenObr As Boolean
        Public DOO_strana As Boolean
        Public grajdanstvo As Boolean
        Public dok_UL As Boolean
        Public ist_finans As Boolean
        Public napr_organization As Boolean
    End Structure


    Public Sub clearStructSlushatel()
        structSlushatel.kodGroup = 0
        structSlushatel.snils = ""
        structSlushatel.snilsRub = ""
        structSlushatel.старыйСнилс = ""
        structSlushatel.фамилия = ""
        structSlushatel.имя = ""
        structSlushatel.отчество = ""
        structSlushatel.датаР = ""
        structSlushatel.уровеньОбразования = ""
        structSlushatel.образование = ""
        structSlushatel.серияДокументаООбразовании = ""
        structSlushatel.номерДокументаООбразовании = ""
        structSlushatel.фамилияВДокОбОбразовании = ""
        structSlushatel.адресРегистрации = ""
        structSlushatel.гражданство = ""
        structSlushatel.телефон = ""
        structSlushatel.ДУЛ = ""
        structSlushatel.серияДУЛ = ""
        structSlushatel.номерДУЛ = ""
        structSlushatel.источникФин = ""
        structSlushatel.направившаяОрг = ""
        structSlushatel.номерНаправленияРосздравнадзора = ""
        structSlushatel.датаНаправленияРосздравнвдзора = ""
        structSlushatel.специальностьСлушателя = ""
        structSlushatel.Email = ""
        structSlushatel.датаРег = ""
        structSlushatel.датаВыдачиДУЛ = ""
        structSlushatel.кемВыданДУЛ = ""
        structSlushatel.пол = ""
    End Sub

    Public Sub loadFormSlushLists()
        Dim queryString As String
        mySQLConnector.opdateArgument()

        queryString = "SELECT name FROM doo_vid_dok ORDER BY name"
        formSlushLists.doo_vid_dok = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT pol FROM pol ORDER BY kod"
        formSlushLists.pol = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT name FROM uroven_obr ORDER BY kod"
        formSlushLists.urovenObr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT name FROM DOO_country ORDER BY kod"
        formSlushLists.DOO_strana = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT name FROM grajdanstvo ORDER BY kod"
        formSlushLists.grajdanstvo = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT name FROM dok_UL ORDER BY kod"
        formSlushLists.dok_UL = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT name FROM ist_finans ORDER BY kod"
        formSlushLists.ist_finans = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT name FROM napr_organization ORDER BY kod"
        formSlushLists.napr_organization = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = "SELECT name FROM napr_organization ORDER BY kod"
        formSlushLists.napr_organization = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        flagSlushatelForm.doo_vid_dok = False
        flagSlushatelForm.pol = False
        flagSlushatelForm.urovenObr = False
        flagSlushatelForm.DOO_strana = False
        flagSlushatelForm.grajdanstvo = False
        flagSlushatelForm.dok_UL = False
        flagSlushatelForm.ist_finans = False
        flagSlushatelForm.napr_organization = False

    End Sub
End Class

