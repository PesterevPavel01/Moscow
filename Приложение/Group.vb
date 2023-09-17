Imports WindowsApp2.Group

Public Class Group

    Private sqlQueryString As New SqlQueryString
    Private mySQLConnector As New MySQLConnect
    Public struct_grup As New strGruppa
    Public flagGrouppForm As FormGrouppFlag
    Public formGrouppLists As FormGroupplLists

    Public Structure strGruppa

        Dim flagAllListProgs As Boolean
        Dim kodProgram As Integer
        Dim Kod As Int32
        Dim yearNZ As Int32
        Dim oldYearNZ As Int32
        Dim oldNumber As String
        Dim nameForm As String
        Dim dataNZ As String
        Dim dataKZ As String
        Dim dataVUd As String
        Dim dataVD As String
        Dim dataVSv As String
        Dim number As String
        Dim formaObuch As String
        Dim speciality As String
        Dim program As String
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
        'Dim nomerProtIA As String
        'Dim nomerUd As String
        'Dim regNomerUd As String
        Dim dateVUd As String
        'Dim nomerDiploma As String
        'Dim regNomerDiploma As String
        Dim DateVDiploma As String
        'Dim nomerSvid As String
        'Dim regNomerSvid As String
        Dim dateVSvid As String
        Dim qualification As String
        Dim numbersUDS As Numbers
        Dim mainDocument As String


    End Structure
    Public Structure Numbers

        Public numberUd As Int64
        Public regNumberUd As Int64
        Public numberD As Int64
        Public regNumberD As Int64
        Public numberSv As Int64
        Public regNumberSv As Int64
        Public numberIA As Int64

    End Structure

    Public Structure FormGroupplLists
        Public ur_cvalifik() As String
        Public form_education() As String
        Public program() As String
        Public speciality() As String
        Public kol_chasov() As String
        Public kurator() As String
        Public otvetstv_praktika() As String
        Public financing() As String
        Public qualification() As String

    End Structure

    Public Structure FormGrouppFlag
        Public ur_cvalifik As Boolean
        Public form_education As Boolean
        Public program As Boolean
        Public speciality As Boolean
        Public kurator As Boolean
        Public otvetstv_praktika As Boolean
        Public financing As Boolean
        Public qualification As Boolean
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

    Public Sub saveParameters(currentForm As Form)

        For Each element As TextBox In currentForm.Controls.OfType(Of TextBox)

            Select Case element.Name

                Case "НоваяГруппаНомер"
                    struct_grup.number = element.Text
                Case "НоваяГруппаКоличествоЧасов"
                    struct_grup.kolChasov = element.Text
            End Select

        Next

        For Each element As ComboBox In currentForm.Controls.OfType(Of ComboBox)

            Select Case element.Name

                Case "НоваяГруппаФормаОбучения"
                    struct_grup.formaObuch = element.Text
                Case "НоваяГруппаСпециальность"
                    struct_grup.speciality = element.Text
                Case "НоваяГруппаОтветственныйКуратор"
                    struct_grup.kurator = element.Text
                Case "НоваягруппаОтветственныйЗаПрактику"
                    struct_grup.otvZaPraktiku = element.Text
                Case "Модуль1"
                    struct_grup.modul1 = element.Text
                Case "Модуль2"
                    struct_grup.modul2 = element.Text
                Case "Модуль3"
                    struct_grup.modul3 = element.Text
                Case "Модуль4"
                    struct_grup.modul4 = element.Text
                Case "Модуль5"
                    struct_grup.modul5 = element.Text
                Case "Модуль6"
                    struct_grup.modul6 = element.Text
                Case "Модуль7"
                    struct_grup.modul7 = element.Text
                Case "Модуль8"
                    struct_grup.modul8 = element.Text
                Case "Модуль9"
                    struct_grup.modul9 = element.Text
                Case "Модуль10"
                    struct_grup.modul10 = element.Text
                Case "НоваяГруппаУровеньКвалификации"
                    struct_grup.urKvalific = element.Text
                Case "НоваяГруппаФинансирование"
                    struct_grup.financir = element.Text
                Case "Квалификация"
                    struct_grup.qualification = element.Text
            End Select

        Next

        For Each element As DateTimePicker In currentForm.Controls.OfType(Of DateTimePicker)

            Select Case element.Name

                Case "НоваяГруппаДатаНачалаЗанятий"
                    struct_grup.yearNZ = element.Value.Year
                    struct_grup.dataNZ = MainForm.mySqlConnect.dateToFormatMySQL(element.Value.ToShortDateString)
                Case "НоваяГруппаКонецЗанятий"
                    struct_grup.dataKZ = MainForm.mySqlConnect.dateToFormatMySQL(element.Value.ToShortDateString)
                Case "ДатаВыдачиУд"
                    struct_grup.dataVUd = MainForm.mySqlConnect.dateToFormatMySQL(element.Value.ToShortDateString)
                Case "ДатаВДиплома"
                    struct_grup.dataVD = MainForm.mySqlConnect.dateToFormatMySQL(element.Value.ToShortDateString)
                Case "ДатаВСвид"
                    struct_grup.dataVSv = MainForm.mySqlConnect.dateToFormatMySQL(element.Value.ToShortDateString)

            End Select

        Next

    End Sub


    Public Sub loadFormGrouppLists()

        Dim queryString As String

        mySQLConnector.opdateArgument()

        queryString = sqlQueryString.loadUrovenKvalifikacii
        formGrouppLists.ur_cvalifik = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = sqlQueryString.loadFormEducation()
        formGrouppLists.form_education = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = ProgramPoUKvalifikLimit1(struct_grup.urKvalific)
        formGrouppLists.program = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = sqlQueryString.loadSpeciality()
        formGrouppLists.speciality = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = sqlQueryString.loadKurator()
        formGrouppLists.kurator = mySQLConnector.loadIntoarray(queryString, 1, 0)

        formGrouppLists.otvetstv_praktika = formGrouppLists.kurator

        queryString = sqlQueryString.loadFinansing()
        formGrouppLists.financing = mySQLConnector.loadIntoarray(queryString, 1, 0)

        queryString = sqlQueryString.loadQualification()
        formGrouppLists.qualification = mySQLConnector.loadIntoarray(queryString, 1, 0)

        flagGrouppForm.ur_cvalifik = False
        flagGrouppForm.form_education = False
        flagGrouppForm.program = False
        flagGrouppForm.speciality = False
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

    Public Sub updateProgram()

        Dim queryString As String
        queryString = ProgramPoUKvalifikLimit1(struct_grup.urKvalific)
        formGrouppLists.program = mySQLConnector.loadIntoarray(queryString, 1, 0)

    End Sub

    Public Sub updateKodProg()

        Dim result As Object(,)
        Dim queryString As String

        queryString = sqlQueryString.loadKogProgram(struct_grup.urKvalific, struct_grup.program)

        result = mySQLConnector.loadMySqlToArray(queryString, 1)

        If result.Length < 2 Then

            Return

        End If

        struct_grup.kodProgram = result(0, 0)
        struct_grup.kolChasov = result(1, 0)

    End Sub

    Public Sub loadNumberHours()

        Dim result As String()
        Dim queryString As String

        queryString = sqlQueryString.loadNumberHours(struct_grup.kodProgram)

        result = mySQLConnector.loadIntoarray(queryString, 1, 0)

        If result.Length < 1 Then

            Return

        End If

        struct_grup.kolChasov = result(0)

    End Sub

    Function formGroupValidation(currentForm As Form) As Boolean

        struct_grup.mainDocument = mainDocument(currentForm)

        For Each element As Control In currentForm.Controls.OfType(Of TextBox)

            If Not checkTextBoxFromGruppa(element) Then
                Return False
            End If

        Next

        For Each element As Control In currentForm.Controls.OfType(Of DateTimePicker)

            If Not checkDateFromGruppa(element) Then
                Return False
            End If

        Next


        If Not checkRequiredField(currentForm) Then

            Warning.content.Text = "Необходимо заполнить обязательные поля"

            Try
                Warning.ShowDialog()
            Catch ex As Exception
                Warning.Close()
                Warning.ShowDialog()
            End Try

            Return False

        End If

        If Not refreshNumbers(struct_grup.mainDocument, currentForm) Then

            Return False

        End If

        For Each element As Control In currentForm.Controls.OfType(Of ComboBox)

            If Not checkComboFromGruppa(element) Then
                Return False
            End If

        Next

        Return True

    End Function

    Function checkRequiredField(currentForm As Form) As Boolean

        For Each element In currentForm.Controls.OfType(Of ComboBox)
            If validationField(element.Name) Then
                If element.Text = "" And element.Visible = True And element.Enabled = True Then

                    Return False

                End If
            End If
        Next

        For Each element In currentForm.Controls.OfType(Of TextBox)
            If validationField(element.Name) Then
                If element.Text = "" And element.Visible = True And element.Enabled = True Then

                    Return False

                End If
            End If
        Next

        Return True

    End Function

    Function checkComboFromGruppa(combo As ComboBox) As Boolean

        Select Case combo.Name

            Case "повышение квалификации"

                Select Case combo.Text

                    Case "повышение квалификации"
                        If Not checkNumber(struct_grup.numbersUDS.numberUd, "Серия и номер удостоверения") Then
                            Return False
                        End If

                        If Not checkNumber(struct_grup.numbersUDS.regNumberUd, "Регистрационный номер удостоверения") Then
                            Return False
                        End If

                    Case "профессиональная переподготовка"

                        If newGroup.statusType.Text = "профессиональная переподготовка" Then
                            If Not checkNumber(struct_grup.numbersUDS.numberD, "Серия и номер диплома") Then
                                Return False
                            End If
                            If Not checkNumber(struct_grup.numbersUDS.regNumberD, "Регистрационный номер диплома") Then
                                Return False
                            End If
                            If Not checkNumber(struct_grup.numbersUDS.numberIA, "Номер протокола ИА") Then
                                Return False
                            End If

                        End If

                    Case "профессиональное обучение"

                        If newGroup.statusType.Text = "профессиональное обучение" Then

                            If Not checkNumber(struct_grup.numbersUDS.regNumberSv, "Серия и номер свидетельства") Then
                                Return False
                            End If

                            If Not checkNumber(struct_grup.numbersUDS.numberSv, "Регистрационный номер свидетельства") Then
                                Return False
                            End If

                            If Not checkNumber(struct_grup.numbersUDS.numberIA, "Номер протокола ИА") Then
                                Return False
                            End If

                        End If

                End Select

        End Select

        Return True

    End Function

    Function checkDateFromGruppa(picker As DateTimePicker) As Boolean

        Select Case picker.Name

            Case "НоваяГруппаДатаНачалаЗанятий"

                If picker.Value.ToShortDateString = "01.01.1753" Then

                    MsgBox("Установите дату в поле Дата начала занятий")
                    Return False

                End If

            Case "НоваяГруппаКонецЗанятий"

                If picker.Value.ToShortDateString = "01.01.1753" Then

                    MsgBox("Установите дату в поле Дата окончания звнятий")
                    Return False

                End If

        End Select

        Return True

    End Function

    Function checkTextBoxFromGruppa(textBox As TextBox) As Boolean

        Select Case textBox.Name

            Case "НоваяГруппаКоличествоЧасов"

                If textBox.Text = "" Then

                    MsgBox("Заполните поле 'количество часов'")
                    Return False

                End If

                If Not checkNumber(textBox.Text, "Количество часов") Then

                    Return False

                End If

            Case "НоваяГруппаНомер"

                If textBox.Text = "" Then

                    MsgBox("Укажите номер групппы")
                    Return False

                End If

        End Select

        Return True

    End Function

    Function mainDocument(currentForm As Form) As String

        mainDocument = "Не указан"

        For Each element In currentForm.Controls

            If element.name = "НомерДиплома" Then
                If element.text <> "" Then
                    mainDocument = "Диплом"
                End If
            End If
            If element.name = "РегНомерДиплома" Then
                If element.text <> "" Then
                    mainDocument = "Диплом"
                End If
            End If

            If element.name = "НомерСвид" Then
                If element.text <> "" Then
                    mainDocument = "Свидетельство"
                End If
            End If
            If element.name = "РегНомерСвид" Then
                If element.text <> "" Then
                    mainDocument = "Свидетельство"
                End If
            End If

            If element.name = "НомерУд" Then
                If element.text <> "" Then
                    mainDocument = "Удостоверение"
                End If
            End If
            If element.name = "РегНомерУд" Then
                If element.text <> "" Then
                    mainDocument = "Удостоверение"
                End If
            End If
            If element.name = "НомерПротоколаСпецэкзамен" Then
                If element.text <> "" Then
                    mainDocument = "Спецэкзамен"
                End If
            End If

        Next

        Return mainDocument

    End Function

    Function refreshNumbers(mainDocument As String, currentForm As Form) As Boolean

        struct_grup.numbersUDS.numberUd = 0
        struct_grup.numbersUDS.regNumberUd = 0
        struct_grup.numbersUDS.numberD = 0
        struct_grup.numbersUDS.regNumberD = 0
        struct_grup.numbersUDS.numberSv = 0
        struct_grup.numbersUDS.regNumberSv = 0
        struct_grup.numbersUDS.numberIA = 0

        Select Case mainDocument

            Case "Не указан"

                Return True

            Case "Удостоверение"

                For Each element In currentForm.Controls.OfType(Of TextBox)

                    If element.Text.Trim = "" Then
                        Continue For
                    End If

                    If element.Name = "НомерУд" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If

                        struct_grup.numbersUDS.numberUd = element.Text

                    End If

                    If element.Name = "РегНомерУд" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If

                        struct_grup.numbersUDS.regNumberUd = element.Text

                    End If

                Next

                Return True

            Case "Диплом"

                For Each element In currentForm.Controls.OfType(Of TextBox)

                    If element.Text.Trim = "" Then
                        Continue For
                    End If

                    If element.Name = "НомерДиплома" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If

                        struct_grup.numbersUDS.numberD = element.Text

                    End If

                    If element.Name = "РегНомерДиплома" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If

                        struct_grup.numbersUDS.regNumberD = element.Text

                    End If

                    If element.Name = "НоваяГруппаНомерПротоколаИА" Or element.Name = "НомерПротоколаИА" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If

                        struct_grup.numbersUDS.numberIA = element.Text

                    End If

                Next

                Return True

            Case "Свидетельство"

                For Each element In currentForm.Controls.OfType(Of TextBox)

                    If element.Text.Trim = "" Then
                        Continue For
                    End If

                    If element.Name = "НомерСвид" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If


                        struct_grup.numbersUDS.numberSv = element.Text

                    End If

                    If element.Name = "РегНомерСвид" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If

                        struct_grup.numbersUDS.regNumberSv = element.Text

                    End If

                    If element.Name = "НоваяГруппаНомерПротоколаИА" Or element.Name = "НомерПротоколаИА" Then

                        If Not checkNumberDok(element) Then
                            Return False
                        End If

                        struct_grup.numbersUDS.numberIA = element.Text

                    End If

                Next

        End Select

        Return True

    End Function

    Private Function checkNumberDok(element As TextBox)

        If Not checkNumber(element.Text, element.Name) Then
            Return False
        End If

        Return True

    End Function


End Class