Imports System.Data.SqlTypes

Public Class Student


    Public flagSlushatelForm As formSlushatelFlag
    Public studentData As strStudent
    Public formSlushLists As formStudentsLists
    Dim mySQLConnector As New MySQLConnect

    Structure strStudent
        Dim idGroup As Integer
        Dim snils As String
        Dim snilsMusked As String
        Dim prevSnils As String
        Dim secondName As String
        Dim name As String
        Dim lastName As String
        Dim birthDay As String
        Dim educationLevel As String
        Dim education As String
        Dim doo_doc_type As String
        Dim seriesDOO As String
        Dim numberDOO As String
        Dim lastNameDOO As String
        Dim adress As String
        Dim citizenship As String
        Dim telephone As String
        Dim dUL As String
        Dim seriesDUL As String
        Dim numberDUL As String
        Dim sourceOfFinansing As String
        Dim направившаяОрг As String
        Dim email As String
        Dim dateReg As String
        Dim dateDUL As String
        Dim autorDUL As String
        Dim gender As String
        Dim checkSnils As Boolean

    End Structure

    Public Structure formStudentsLists
        Public doo_doc_type() As String
        Public gender() As String
        Public urovenObr() As String
        Public DOO_strana() As String
        Public nationality() As String
        Public doc_UL() As String
        Public finSource() As String
        Public napr_organization() As String
    End Structure

    Public Structure formSlushatelFlag
        Public doo_doc_type As Boolean
        Public gender As Boolean
        Public urovenObr As Boolean
        Public DOO_strana As Boolean
        Public nationality As Boolean
        Public doc_UL As Boolean
        Public finSource As Boolean
        Public napr_organization As Boolean
    End Structure


    Public Sub clearStudentData()
        studentData.idGroup = 0
        studentData.snils = ""
        studentData.snilsMusked = ""
        studentData.secondName = ""
        studentData.name = ""
        studentData.lastName = ""
        studentData.birthDay = ""
        studentData.educationLevel = ""
        studentData.education = ""
        studentData.seriesDOO = ""
        studentData.numberDOO = ""
        studentData.lastNameDOO = ""
        studentData.adress = ""
        studentData.citizenship = ""
        studentData.telephone = ""
        studentData.dUL = ""
        studentData.seriesDUL = ""
        studentData.numberDUL = ""
        studentData.sourceOfFinansing = ""
        studentData.направившаяОрг = ""
        studentData.email = ""
        studentData.dateReg = ""
        studentData.dateDUL = ""
        studentData.autorDUL = ""
        studentData.gender = ""
    End Sub
    Function validationSecondLvl(currentForm As Form) As Boolean

        For Each element In currentForm.Controls.OfType(Of ComboBox)

            If Not checkControl(element) Then

                Dim s As String = element.Name
                Return False

            End If

        Next

        For Each element In currentForm.Controls.OfType(Of TextBox)

            If Not checkControl(element) Then

                Return False

            End If

        Next

        Return True

    End Function

    Private Function checkControl(element As Control) As Boolean

        If element.Visible = False Then

            Return True

        End If

        Select Case element.Name

            Case "Телефон"
                Return True
            Case "ValidOn"
                Return True
            Case "Образование"
                Return True
            Case "КемВыданДУЛ"
                Return True
            Case "СтранаДОО"
                Return True
            Case "Email"
                Return True
            Case "Отчество"
                Return True
            Case "НомерДУЛ"
                Return True
            Case "СерияДУЛ"
                Return True
            Case "ДУЛ"
                Return True
            Case "ИсточникФин"
                Return True
            Case "СтранаДОО"
                Return True
            Case "НаправившаяОрг"
                Return True
            Case "ДатаНаправленияРосздравнвдзора"
                Return True
            Case "НомерНаправленияРосздравнадзора"
                Return True
            Case "СпециальностьСлушателя"
                Return True
            Case "АдресРегистрации"
                Return True
            Case "Образование"
                Return True
            Case "Выполнение"
                Return True
            Case "doo_doc_type"
                Return True

        End Select

        If element.Text = "" Then

            Return False

        End If
        Return True
    End Function
    Public Function validationFirstLavel() As Boolean

        Dim snilsLen As Integer
        Dim snilsNumber As Long
        snilsLen = Len(studentData.snilsMusked)


        If snilsLen <> 14 Then

            MsgBox("Снилс введен некорректно", "Внимание")

            Return False

        End If

        Try
            snilsNumber = addMask.deleteMask(studentData.snilsMusked)
        Catch ex As Exception

            MsgBox("Снилс введен некорректно")
            Return False

        End Try

        If studentData.checkSnils Then
            If Not checkSnils(addMask.deleteMask(studentData.snilsMusked)) Then
                MsgBox("Снилс не прошел проверку", 10, "Внимание")
                Return False
            End If
        End If


        If studentData.snilsMusked = "" Then

            MsgBox("Заполните поле 'СНИЛС'", 10, "Внимание")
            Return False

        End If

        If studentData.birthDay = "01.01.1753" Then

            MsgBox("Установите дату в поле Дата рождения", 10, "Внимание")
            Return False

        End If

        If studentData.secondName = "" Then
            MsgBox("Укажите Фамилию слушателя", 10, "Внимание")
            Return False
        End If

        If studentData.sourceOfFinansing = "" Then
            MsgBox("Укажите источник финансирования", 10, "Внимание")
            Return False
        End If

        Return True

    End Function

    Function checkSnils(snils As String) As Boolean

        Dim array
        Dim Sum As Integer = 0
        Dim count As Integer
        count = 0
        Dim chr As Integer = 0
        Dim CheckNumbr As Integer
        Dim element As String

        checkSnils = False

        array = Strings.Left(snils, 9).ToCharArray
        CheckNumbr = Strings.Right(snils, 2)

        For Each i In array
            element = i
            chr = Convert.ToInt32(element)
            Sum += chr * (9 - count)
            count += 1
        Next

        If Sum = 100 Then
            Sum = 0
        ElseIf Sum > 100 Then
            Sum = Sum Mod 101

            If Sum = 100 Then
                Sum = 0
            End If

        End If

        If Sum = CheckNumbr Then
            checkSnils = True
        End If

    End Function

    Public Sub loadFormSlushLists()
        Dim queryString As String
        mySQLConnector.opdateArgument()

        queryString = loadDooVidDok()
        formSlushLists.doo_doc_type = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = loadGender()
        formSlushLists.gender = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = loadUrovenObr()
        formSlushLists.urovenObr = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = loadDooCountry()
        formSlushLists.DOO_strana = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = loadNationality()
        formSlushLists.nationality = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = loadDokUL()
        formSlushLists.doc_UL = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = loadIstFinans()
        formSlushLists.finSource = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = loadNOrganization()
        formSlushLists.napr_organization = mySQLConnector.loadIntoarray(queryString, 1, 0)

        flagSlushatelForm.doo_doc_type = False
        flagSlushatelForm.gender = False
        flagSlushatelForm.urovenObr = False
        flagSlushatelForm.DOO_strana = False
        flagSlushatelForm.nationality = False
        flagSlushatelForm.doc_UL = False
        flagSlushatelForm.finSource = False
        flagSlushatelForm.napr_organization = False

    End Sub

    Public Function insertStudent() As Boolean

        Dim queryString As String
        Dim listQuery

        ReDim listQuery(3)

        listQuery(1) = SqlString__loadSlushList(studentData.snils)

        listQuery(2) = SqlString__updateSlush(studentData)

        listQuery(3) = SqlString__insertSlush(studentData)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "students"
        InsertIntoDataBase.argument.firstName = "Снилс"
        InsertIntoDataBase.argument.firstValue = studentData.snils

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

        queryString = SqlString__deleteSlushFromGrouppList(studentData.snils)

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        If studentData.idGroup <> -1 Then
            addToGroupp(studentData)
        End If

        Return True

    End Function

    Public Function insertStudentRedact() As Boolean

        Dim queryString As String

        If Not studentData.snils = studentData.prevSnils Then

            queryString = SqlString__deleteSlush(studentData.snils)
            MainForm.mySqlConnect.sendQuery(queryString, 1)
            queryString = SqlString__deleteSlushFromGrouppList(studentData.snils)
            MainForm.mySqlConnect.sendQuery(queryString, 1)

        End If

        queryString = updateSlushatel(studentData)

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "students"
        InsertIntoDataBase.argument.firstName = "Снилс"
        InsertIntoDataBase.argument.firstValue = studentData.snils
        InsertIntoDataBase.argument.secondName = "ДатаРегистрации"
        InsertIntoDataBase.argument.secondValue = MainForm.mySqlConnect.dateToFormatMySQL(studentData.dateReg)

        If InsertIntoDataBase.checkDuplicates() Then

            queryString = SqlString__updateSlushInListSlGroupp(studentData.snils, studentData.prevSnils)
            MainForm.mySqlConnect.sendQuery(queryString, 1)
            Return True

        Else

            Return False

        End If

    End Function

    Sub addToGroupp(slushatel As Student.strStudent)

        Dim queryString As String

        queryString = SqlString__insertIntoListGroupp(slushatel.snils, Convert.ToString(slushatel.idGroup))

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "group_list"
        InsertIntoDataBase.argument.firstName = "Kod"
        InsertIntoDataBase.argument.firstValue = slushatel.idGroup
        InsertIntoDataBase.argument.secondName = "students"
        InsertIntoDataBase.argument.secondValue = slushatel.snils

        If InsertIntoDataBase.checkUniq_No2() = 1 Then

            MainForm.mySqlConnect.sendQuery(queryString, 1)

        Else

            MsgBox("Слушатель уже добавлен в группу")

        End If

    End Sub

End Class

