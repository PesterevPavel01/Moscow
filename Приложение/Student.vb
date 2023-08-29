Imports System.Data.SqlTypes

Public Class Student


    Public flagSlushatelForm As formSlushatelFlag
    Public structSlushatel As strSlushatel
    Public formSlushLists As formStudentsLists
    Dim mySQLConnector As New MySQLConnect

    Structure strSlushatel
        Dim idGroup As Integer
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

    Public Structure formStudentsLists
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
        structSlushatel.idGroup = 0
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

        queryString = loadDooVidDok()
        formSlushLists.doo_vid_dok = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = loadPol()
        formSlushLists.pol = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = loadUrovenObr()
        formSlushLists.urovenObr = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = loadDooCountry()
        formSlushLists.DOO_strana = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = loadGrajdanstvo()
        formSlushLists.grajdanstvo = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = loadDokUL()
        formSlushLists.dok_UL = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = loadIstFinans()
        formSlushLists.ist_finans = mySQLConnector.ЗагрузитьИзMySQLвОдномерныйМассив(queryString, 1, 0)

        queryString = loadNOrganization()
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

    Public Function insertSlushatel() As Boolean

        Dim queryString As String
        Dim listQuery

        ReDim listQuery(3)

        listQuery(0) = "Группа"

        listQuery(1) = SqlString__loadSlushList(structSlushatel.snils)

        listQuery(2) = SqlString__updateSlush(structSlushatel)

        listQuery(3) = SqlString__insertSlush(structSlushatel)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "students"
        InsertIntoDataBase.argument.firstName = "Снилс"
        InsertIntoDataBase.argument.firstValue = structSlushatel.snils

        If InsertIntoDataBase.checkDuplicates() Then

            ФормаДаНет.ShowDialog()

            If Not InsertIntoDataBase.removeDuplicates Then
                Return False
            End If

            queryString = listQuery(2)
            InsertIntoDataBase.removeDuplicates = False

        Else

            queryString = listQuery(3)

        End If

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        queryString = SqlString__deleteSlushFromGrouppList(structSlushatel.snils)

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        If structSlushatel.idGroup <> -1 Then
            addToGroupp(structSlushatel)
        End If

        Return True

    End Function

    Public Function insertSlushatelRedactor() As Boolean

        Dim queryString As String

        If Not structSlushatel.snils = structSlushatel.старыйСнилс Then

            queryString = SqlString__deleteSlush(structSlushatel.snils)
            MainForm.mySqlConnect.sendQuery(queryString, 1)
            queryString = SqlString__deleteSlushFromGrouppList(structSlushatel.snils)
            MainForm.mySqlConnect.sendQuery(queryString, 1)

        End If

        queryString = updateSlushatel(structSlushatel)

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "students"
        InsertIntoDataBase.argument.firstName = "Снилс"
        InsertIntoDataBase.argument.firstValue = structSlushatel.snils
        InsertIntoDataBase.argument.secondName = "ДатаРегистрации"
        InsertIntoDataBase.argument.secondValue = MainForm.mySqlConnect.dateToFormatMySQL(structSlushatel.датаРег)

        If InsertIntoDataBase.checkDuplicates() Then

            queryString = SqlString__updateSlushInListSlGroupp(structSlushatel.snils, structSlushatel.старыйСнилс)
            MainForm.mySqlConnect.sendQuery(queryString, 1)
            Return True

        Else

            Return False

        End If

    End Function

    Sub addToGroupp(slushatel As Student.strSlushatel)

        Dim queryString As String

        queryString = SqlString__insertIntoListGroupp(slushatel.snils, Convert.ToString(slushatel.idGroup))

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "group_list"
        InsertIntoDataBase.argument.firstName = "Kod"
        InsertIntoDataBase.argument.firstValue = slushatel.idGroup
        InsertIntoDataBase.argument.secondName = "students"
        InsertIntoDataBase.argument.secondValue = slushatel.snils

        If Not InsertIntoDataBase.checkUniq_No2() = 2 Then

            MainForm.mySqlConnect.sendQuery(queryString, 1)

        Else

            MsgBox("Слушатель уже добавлен в группу")

        End If

    End Sub

End Class

