Imports System.IO
Imports System.Threading

Module _technical

    Public Sub activateBlackMode(currentControl As Control, flagOn As Boolean, currentForm As Form)

        Dim cont As String = currentControl.Name

        If Not flagOn Then

            Dim cover As New PictureBox
            currentForm.Controls.Add(cover)
            cover.Location = New Point(currentControl.Location.X, currentControl.Location.Y)
            cover.Size = New Size(729, 25)
            cover.Image = newGroup.cover_image
            cover.SizeMode = PictureBoxSizeMode.StretchImage
            cover.Name = currentControl.Name + "_cover"
            cover.BringToFront()

        Else

            removeCover(currentControl.Name + "_cover", currentForm)

        End If

    End Sub

    Private Sub removeCover(name As String, currentForm As Form)
        For Each cover As PictureBox In currentForm.Controls.OfType(Of PictureBox)
            If cover.Name = name Then
                currentForm.Controls.Remove(cover)
            End If
        Next
    End Sub

    Public Sub comboBoxDrop(currentComboBox As ComboBox, flag As Boolean)

        If Not currentComboBox.Enabled Then

            Return

        End If

        If flag Then

            currentComboBox.DroppedDown = False

        Else

            currentComboBox.DroppedDown = True

        End If

    End Sub

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

    Function checkField(currentForm As Form) As Boolean

        For Each element In currentForm.Controls.OfType(Of ComboBox)
            If element.Text.Trim = "" And element.Visible = True And element.Enabled = True Then
                Return False
            End If
        Next

        For Each element In currentForm.Controls.OfType(Of TextBox)
            If element.Text.Trim = "" And element.Visible = True And element.Enabled = True Then
                Return False
            End If
        Next

        Return True

    End Function
    Public Sub cleanForm(currentForm As Form)

        For Each element As TextBox In currentForm.Controls.OfType(Of TextBox)

            element.Clear()

        Next

        For Each element As MaskedTextBox In currentForm.Controls.OfType(Of MaskedTextBox)

            element.Clear()

        Next

        For Each element As ComboBox In currentForm.Controls.OfType(Of ComboBox)

            element.Text = ""

        Next

        For Each element As DateTimePicker In currentForm.Controls.OfType(Of DateTimePicker)

            element.Value = "01.01.1753"

        Next

    End Sub

    Function month(nomber As String)

        If nomber = "01" Or nomber = "1" Then month = "января"
        If nomber = "02" Or nomber = "2" Then month = "февраля"
        If nomber = "03" Or nomber = "3" Then month = "марта"
        If nomber = "04" Or nomber = "4" Then month = "апреля"
        If nomber = "05" Or nomber = "5" Then month = "мая"
        If nomber = "06" Or nomber = "6" Then month = "июня"
        If nomber = "07" Or nomber = "7" Then month = "июля"
        If nomber = "08" Or nomber = "8" Then month = "августа"
        If nomber = "09" Or nomber = "9" Then month = "сентября"
        If nomber = "10" Then month = "октября"
        If nomber = "11" Then month = "ноября"
        If nomber = "12" Then month = "декабря"

    End Function

    Public Function checkNumber(value As String, Optional name As String = "non", Optional showMessage As Boolean = True) As Boolean

        If value.Trim = "" Then

            Return False

        End If

        If Not IsNumeric(value) Then

            If showMessage Then
                Warning.content.Text = name & " не является числом"
                Warning.ShowDialog()
            End If

            Return False

        End If

        Return True

    End Function

    Function rotate(text As String) As String

        Dim parth As String
        If Len(text) < 4 Then
            rotate = ""
            Exit Function
        End If
        parth = Right(text, 4)
        text = Left(text, Len(text) - 4)
        text = parth & " " & text
        text = Left(text, Len(text) - 1)
        rotate = text

    End Function

    'Function formStudentsValidation() As Boolean

    '    Dim snilsLen As Integer
    '    Dim snilsNumber As Long
    '    snilsLen = Len(newStudent.snils.Text)


    '    If snilsLen <> 14 Then

    '        MsgBox("Снилс введен некорректно")

    '        Return False

    '    End If

    '    Try
    '        snilsNumber = addMask.deleteMask(newStudent.snils.Text)
    '    Catch ex As Exception

    '        MsgBox("Снилс введен некорректно")
    '        Return False

    '    End Try

    '    If newStudent.ValidOn.Checked Then
    '        If Not checkSnils(addMask.deleteMask(newStudent.snils.Text)) Then
    '            MsgBox("Снилс не прошел проверку")
    '            Return False
    '        End If
    '    End If


    '    If newStudent.snils.Text = "" Then

    '        MsgBox("Заполните поле 'СНИЛС'")
    '        Return False

    '    End If

    '    If newStudent.birthDate.Value.ToShortDateString = "01.01.1753" Then

    '        MsgBox("Установите дату в поле Дата рождения")
    '        Return False

    '    End If

    '    If newStudent.secondName.Text = "" Then
    '        MsgBox("Укажите Фамилию слушателя")
    '        Return False
    '    End If

    '    If newStudent.ИсточникФин.Text = "" Then
    '        MsgBox("Укажите источник финансирования")
    '        Return False
    '    End If

    '    If Not interfaceMod.formStudentValidation(newStudent) Then

    '        Warning.content.Text = "Заполните все обязательные поля"
    '        openForm(Warning)

    '        Return False

    '    End If

    '    Return True

    'End Function

    Function addZeros(value As Integer, length As Integer) As String
        Dim Result As String
        Result = value.ToString
        Dim count As Integer
        count = length - Strings.Len(Result)
        If Strings.Len(value) < length Then
            For i = 1 To count
                Result = 0 & Result
            Next
        End If
        addZeros = Result
    End Function

    Function addZerosIntoArray(array As Object, rowNumber As Integer, length As Integer) As Object

        Dim Result = array
        Dim ResultElement As String

        For Row = 0 To UBound(Result, 2)
            ResultElement = Result(rowNumber, Row).ToString
            Dim count As Integer
            count = length - Strings.Len(ResultElement)
            If Strings.Len(ResultElement) < length Then
                For i = 1 To count
                    ResultElement = 0 & ResultElement
                    Result(rowNumber, Row) = ResultElement
                Next
            End If
        Next
        addZerosIntoArray = Result
    End Function


    Function activateModuls(currentForm As Form, programName As String, kod As String) As Object
        Dim sqlQuery As String
        Dim moduls
        Dim rowsCounter As Integer = 0
        Dim queryString As New SqlQueryString()

        rowsCounter = 0

        If kod = -1 Then

            While rowsCounter <= 9
                For Each element In currentForm.Controls.OfType(Of System.Windows.Forms.Label)

                    If element.Name = "LabelМодуль" & rowsCounter + 1 Then
                        element.Enabled = False
                        If element.Name = "Модуль" & rowsCounter + 1 Then
                            element.Text = ""
                        End If
                    End If

                Next

                For Each element In currentForm.Controls.OfType(Of ComboBox)

                    If element.Name = "Модуль" & rowsCounter + 1 Then
                        element.Enabled = False
                        If element.Name = "Модуль" & rowsCounter + 1 Then
                            element.Text = ""
                        End If
                    End If

                Next

                rowsCounter += 1

            End While

            Exit Function

        End If


        While rowsCounter <= 9

            For Each element In currentForm.Controls.OfType(Of System.Windows.Forms.Label)
                If element.Name = "LabelМодуль" & rowsCounter + 1 Then
                    element.Enabled = True
                End If
            Next

            For Each element In currentForm.Controls.OfType(Of ComboBox)
                If element.Name = "Модуль" & rowsCounter + 1 Then
                    element.Enabled = True
                End If
            Next

            rowsCounter += 1

        End While

        sqlQuery = queryString.selectModulInProg(kod)
        moduls = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If moduls(0, 0).ToString = "нет записей" Or moduls(0, 0).ToString = "" Then
            rowsCounter = 0
        Else
            rowsCounter = moduls(0, 0)
        End If

        If Not (programName.Trim = "") Then

            If moduls(0, 0).ToString = "нет записей" Then

                Return moduls

            End If

        Else

            Return moduls

        End If

        While rowsCounter <= 9

            For Each element In currentForm.Controls.OfType(Of System.Windows.Forms.Label)
                If element.Name = "LabelМодуль" & rowsCounter + 1 Then
                    element.Enabled = False
                End If
            Next

            For Each element In currentForm.Controls.OfType(Of ComboBox)
                If element.Name = "Модуль" & rowsCounter + 1 Then
                    element.Enabled = False
                    element.Text = ""
                End If
            Next

            rowsCounter += 1
        End While

        Return moduls

    End Function

    Sub insertIntoGroupList(snils As String)

        Dim queryString As String

        'ФормаСправочникСлушатели.Label2.Visible = False

        queryString = MainForm.sqlQueryString.insertIntoGroupList(snils, GroupList.kod)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "group_list"
        InsertIntoDataBase.argument.firstName = "Kod"
        InsertIntoDataBase.argument.firstValue = Convert.ToString(GroupList.kod)
        InsertIntoDataBase.argument.secondName = "students"
        InsertIntoDataBase.argument.secondValue = snils

        If Not InsertIntoDataBase.checkUniq_No2() = 2 Then

            MainForm.mySqlConnect.sendQuery(queryString, 1)

            'updateStudentsInGroup.updateFormStudentsInGroup(GroupList.kod)
            StudentsInGroup.tbl_studentsInGroup.load_table()

        Else MsgBox("Слушатель уже добавлен в группу")

        End If

    End Sub


    Function ФамилияИОПоПолнойФИО(ПолнаяФИО As String)
        Dim ФИО
        Dim Результат As String

        ФИО = Split(ПолнаяФИО)
        Try
            Результат = ФИО(0) & " "
        Catch ex As Exception

        End Try

        Try
            Результат = Результат & Left(ФИО(1), 1) & "."
        Catch ex As Exception

        End Try

        Try
            Результат = Результат & Left(ФИО(2), 1) & "."
        Catch ex As Exception

        End Try

        ФамилияИОПоПолнойФИО = Результат

    End Function
    Function УбратьНенужныеСтрокиИзМассива(Массив As Object, МассивНенужныхЗначений As Object) As Object
        Dim ИтоговыйМассив
        Dim Совпало As Boolean
        Dim С As Integer, СчетчикСтрок As Integer = 0
        С = UBound(МассивНенужныхЗначений, 2)
        С = UBound(Массив, 1)
        С = UBound(Массив, 2)
        ReDim ИтоговыйМассив(UBound(Массив, 1), UBound(Массив, 2) - UBound(МассивНенужныхЗначений, 2) - 1)

        If МассивНенужныхЗначений(0, 0).ToString = "нет записей" Then
            ReDim ИтоговыйМассив(UBound(Массив, 1), UBound(Массив, 2))
        End If
        For Счетчик = 0 To UBound(Массив, 2)
            Совпало = False
            For счетчик2 = 0 To UBound(МассивНенужныхЗначений, 2)
                If Массив(0, Счетчик) = МассивНенужныхЗначений(0, счетчик2) Then
                    Совпало = True
                End If
            Next
            If Совпало = False Then
                For счетчикСтолбцов = 0 To UBound(Массив, 1)
                    ИтоговыйМассив(счетчикСтолбцов, СчетчикСтрок) = Массив(счетчикСтолбцов, Счетчик)
                Next
                СчетчикСтрок += 1
            End If
        Next

        УбратьНенужныеСтрокиИзМассива = ИтоговыйМассив

    End Function

    Function УбратьПустыеСтрокиИзМассива(Массив As Object) As Object
        Dim ИтоговыйМассив
        Dim Совпало As Boolean
        Dim С As Integer, СчетчикСтрок As Integer = 0
        С = UBound(Массив)

        For Счетчик = 0 To UBound(Массив)

            If IsNothing(Массив(Счетчик)) Or Strings.Trim(Массив(Счетчик)) = "" Then
                Continue For
            End If
            СчетчикСтрок = СчетчикСтрок + 1
        Next

        ReDim ИтоговыйМассив(СчетчикСтрок - 1)
        С = 0

        For Счетчик = 0 To UBound(Массив)

            If IsNothing(Массив(Счетчик)) Or Strings.Trim(Массив(Счетчик)) = "" Then
                С += 1
                Continue For
            End If

            For СчетчикСтолбцов = 0 To UBound(Массив)
                ИтоговыйМассив(Счетчик - С) = Массив(Счетчик)
            Next

        Next

        УбратьПустыеСтрокиИзМассива = ИтоговыйМассив

    End Function

    Sub replaceTextInWordApp(ВесьТекст As Object, ЗаменяемыйТекст As String, ТекстНаКоторыйМеняем As String, Optional КоличествоЗамен As Integer = 2)

        ВесьТекст.Find.Execute(FindText:=ЗаменяемыйТекст, ReplaceWith:=ТекстНаКоторыйМеняем, Replace:=КоличествоЗамен)

    End Sub

    Function monthRP(Месяц As String)
        Dim месяцРПадеж As String
        месяцРПадеж = LCase(Месяц)
        If Right$(месяцРПадеж, 1) = "т" Then
            месяцРПадеж = месяцРПадеж & "а"
        Else месяцРПадеж = Left$(месяцРПадеж, Len(месяцРПадеж) - 1) & "я"
        End If
        monthRP = месяцРПадеж
    End Function
    Sub replaceText_documentWordRange(Область As Object, ЗаменяемыйТекст As String, ТекстНаКоторыйМеняем As String, Optional КоличествоЗамен As Integer = 2)
        Область.Find.ClearFormatting
        Область.Find.Replacement.ClearFormatting
        With Область.Find
            .Text = ЗаменяемыйТекст
            .Replacement.Text = ТекстНаКоторыйМеняем
            .Forward = True
            .Wrap = 0
            .Format = False
            .MatchCase = False
            .MatchWholeWord = False
            .MatchWildcards = False
            .MatchSoundsLike = False
            .MatchAllWordForms = False
        End With
        Область.Find.Execute(Replace:=КоличествоЗамен)
    End Sub

    Sub openForm(Form As Form)

        Try
            Form.ShowDialog()
        Catch ex As Exception
            Form.Close()
            Try
                Form.ShowDialog()
            Catch ex1 As Exception

            End Try

        End Try



    End Sub

    Function list2ToArray2(list As List(Of List(Of String))) As String(,)

        Dim array As String(,)
        Dim countRow As Integer = 0
        Dim countCol As Integer = 0

        If (IsNothing(list)) Then
            Return array
        End If

        If list.Count = 0 Then
            Return array
        End If

        If list(0).Count = 0 Then
            Return array
        End If

        ReDim array(list.Count - 1, list(0).Count - 1)

        For Each row As List(Of String) In list

            countCol = 0
            For Each value As String In row

                array(countRow, countCol) = value
                countCol += 1

            Next

            countRow += 1


        Next

        Return array
    End Function

    Function ЗаписьМассиваВКоллекцию(Массив As Object) As Collection

        Dim Список = New Collection
        Dim Номер As Integer

        Try
            For i = 0 To UBound(Массив, 1)
                Список.Add(Массив(i))
            Next
        Catch ex As Exception
            Список.Add(Массив)
        End Try

        Номер = Список.Count

        ЗаписьМассиваВКоллекцию = Список

    End Function
    Sub Коллекция()

        Dim massiv
        Dim Список = New Collection
        Dim Номер As Integer

        ReDim massiv(10)

        For i = 0 To UBound(massiv, 1)

            Список.Add(i)

        Next

        For Each ithem In Список

            Номер = ithem
            Список.Remove(1)

        Next

        Номер = Список.Count
    End Sub

    Function updateResourcesPath() As String

        Dim ПутьКФайлуRes, Путь As String
        Dim Массив
        Dim счетчик As Integer

        Путь = Application.StartupPath
        Массив = Путь.Split("\")
        ПутьКФайлуRes = ""

        While счетчик < UBound(Массив)

            If Массив(счетчик).ToString = "bin" Then
                Exit While
            End If

            ПутьКФайлуRes = ПутьКФайлуRes & Массив(счетчик) & "\"
            счетчик += 1

        End While


        updateResourcesPath = ПутьКФайлуRes & "Resources\"

    End Function

    Function createExcellWorkBook(Путь As String, ИмяДокумента As String, Optional НомерОтчета As Integer = 0) As Object
        Dim ПриложениеЭксель, КнигаЭксель
        Dim ОбъектыЭксель
        Dim Счетчик, Число As Integer
        Dim Имя As String
        ReDim ОбъектыЭксель(1)
        Dim Name As String
        Счетчик = 0

СоздатьПриложение:
        Try
            ПриложениеЭксель = CreateObject("Excel.Application")
            ПриложениеЭксель.DisplayAlerts = False
        Catch ex As Exception
            Thread.Sleep(500)
            If Счетчик < 10 Then
                Счетчик += 1
                GoTo СоздатьПриложение
            End If
            Warning.content.Text = "Не удалось создать новое приложение эксель"
            Warning.ShowDialog()
            ОбъектыЭксель(0) = "Ошибка"
            ОбъектыЭксель(1) = "Ошибка"
            createExcellWorkBook = ОбъектыЭксель
            Exit Function
        End Try
        Счетчик = 0
СоздатьКнигу:

        Try
            КнигаЭксель = ПриложениеЭксель.Workbooks.Add
        Catch ex As Exception
            Thread.Sleep(500)
            If Счетчик < 10 Then
                Счетчик += 1
                GoTo СоздатьКнигу
            End If

            Warning.content.Text = "Не удалось создать книгу эксель"
            Warning.ShowDialog()
            ПриложениеЭксель.Exit
            ОбъектыЭксель(0) = "Ошибка"
            ОбъектыЭксель(1) = "Ошибка"
            createExcellWorkBook = ОбъектыЭксель
            Exit Function
        End Try
        Имя = ИмяДокумента
        Счетчик = 0
СохранитьКнигу:

        Счетчик += 1

        Name = Путь & Имя & Date.Now.ToShortDateString & "_" & Счетчик.ToString & ".xlsx"


        If File.Exists(Name) Then

            GoTo СохранитьКнигу

        End If

        Try
            КнигаЭксель.SaveAs(Name)
        Catch ex As Exception

            Warning.content.Text = "Не удалось сохранить книгу эксель " & ex.Message
            Warning.ShowDialog()
            ПриложениеЭксель.Quit
            ОбъектыЭксель(0) = "Ошибка"
            ОбъектыЭксель(1) = "Ошибка"

        End Try

        ОбъектыЭксель(0) = ПриложениеЭксель
        ОбъектыЭксель(1) = КнигаЭксель
        Return ОбъектыЭксель
    End Function

    Function createNameExcellWorkBook(path As String, name As String) As String
        Dim counter As Integer = 0
        name = path & name & Date.Now.ToShortDateString & "_" & counter.ToString & ".xlsx"
        While File.Exists(name)
            counter += 1
            name = path & name & Date.Now.ToShortDateString & "_" & counter.ToString & ".xlsx"
        End While

        Return name
    End Function

    Sub сохранить(DOK As Object, видПриказа As String, Optional ПутьКПапке As String = "не указан")
        Dim Name As String, Путь As String, счетчик As Integer = 0

        видПриказа = Strings.Replace(видПриказа, "*", "")
        видПриказа = Strings.Replace(видПриказа, "/", "")
        видПриказа = Strings.Replace(видПриказа, "\", "")
        видПриказа = Strings.Replace(видПриказа, "?", "")
        видПриказа = Strings.Replace(видПриказа, Chr(34), "")
        видПриказа = Strings.Replace(видПриказа, ":", "")
        видПриказа = Strings.Replace(видПриказа, ">", "")
        видПриказа = Strings.Replace(видПриказа, "<", "")
        видПриказа = Strings.Replace(видПриказа, "|", "")


сохранить:

        счетчик += 1

        Name = видПриказа & Date.Now.ToShortDateString & "_" & счетчик.ToString

        If ПутьКПапке = "не указан" Then
            Путь = Application.StartupPath & "\Приказы\"
        Else Путь = ПутьКПапке
        End If

        BuildOrder.path = Путь

        Путь = Путь & Name & ".docx"

        If File.Exists(Путь) Then

            GoTo сохранить

        End If

        Try
            DOK.SaveAs(Путь)
        Catch ex As Exception
            Warning.content.Text = "не удалось сохранить файл:" & Путь
            Warning.ShowDialog()
            BuildOrder.path = ""
        End Try



    End Sub

    Sub saveBook(DOK As Object, vidDok As String, resourcesPath As String)
        Dim sqlQuery As String = ""
        Dim listFolder As List(Of String) = New List(Of String)
        Dim gruppa

        sqlQuery = QueryString.SQLString_SELECT_dateAndKvalGrupp(MainForm.orderIdGroup)
        gruppa = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        listFolder.Add("Отчеты")
        listFolder.Add("Книги")

        If checkDirectory(resourcesPath, listFolder) Then
            saveAS(DOK, listFolder, resourcesPath, checkName(vidDok))
        Else
            сохранить(DOK, vidDok, resourcesPath & "Нераспределенное\")
        End If

    End Sub
    Sub savePrikazBlank(DOK As Object, kodGroupp As String, vidDok As String, resourcesPath As String, grouppDok As String, mySqlConnector As MySQLConnect)
        Dim sqlQuery As String = ""
        Dim listFolder As List(Of String) = New List(Of String)
        Dim gruppa

        sqlQuery = QueryString.SQLString_SELECT_dateAndKvalGrupp(MainForm.orderIdGroup)
        gruppa = mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        listFolder.Add("Приказы")
        listFolder.Add(gruppa(0, 0))
        listFolder.Add(gruppa(1, 0))
        listFolder.Add("Группа N" & checkName(BuildOrder.groupNumber.Text))
        listFolder.Add(grouppDok)

        If checkDirectory(resourcesPath, listFolder) Then
            saveAS(DOK, listFolder, resourcesPath, checkName(vidDok))
        Else
            сохранить(DOK, vidDok, resourcesPath & "Нераспределенное\")
        End If

    End Sub

    Function checkName(name As String)
        name = Strings.Replace(name, "*", "")
        name = Strings.Replace(name, "/", "")
        name = Strings.Replace(name, "\", "")
        name = Strings.Replace(name, "?", "")
        name = Strings.Replace(name, Chr(34), "")
        name = Strings.Replace(name, ":", "")
        name = Strings.Replace(name, ">", "")
        name = Strings.Replace(name, "<", "")
        name = Strings.Replace(name, "|", "")
        Return name
    End Function
    'сохранение



    Sub saveAS(DOK As Object, listFolder As List(Of String), resourcesPath As String, видПриказа As String)
        Dim Name As String, path As String, счетчик As Integer = 0

        видПриказа = Strings.Replace(видПриказа, "*", "")
        видПриказа = Strings.Replace(видПриказа, "/", "")
        видПриказа = Strings.Replace(видПриказа, "\", "")
        видПриказа = Strings.Replace(видПриказа, "?", "")
        видПриказа = Strings.Replace(видПриказа, Chr(34), "")
        видПриказа = Strings.Replace(видПриказа, ":", "")
        видПриказа = Strings.Replace(видПриказа, ">", "")
        видПриказа = Strings.Replace(видПриказа, "<", "")
        видПриказа = Strings.Replace(видПриказа, "|", "")

сохранить:

        счетчик += 1
        path = resourcesPath
        Name = Strings.Left(видПриказа, 30) & "_" & Date.Now.ToShortDateString & "_" & счетчик.ToString

        If listFolder.Count = 0 Then
            path = Application.StartupPath & "\Приказы\"
        Else
            For Each part As String In listFolder
                path += part + "\"
            Next
        End If

        BuildOrder.path = path

        path = path & Name & ".docx"

        If File.Exists(path) Then

            GoTo сохранить

        End If

        Try
            DOK.SaveAs(path)
        Catch ex As Exception
            Dim text1 As String = ex.Message
            Dim i As Integer = path.Length
            Warning.content.Text = "не удалось сохранить файл:" & path
            Warning.ShowDialog()
            BuildOrder.path = ""
        End Try

    End Sub

    Function rotateArray(array As Object) As Object

        Dim row, column As Long
        Dim resultArr
        row = UBound(array, 1)
        column = UBound(array, 2)

        ReDim resultArr(UBound(array, 2), UBound(array, 1))

        For row = 0 To UBound(array, 1)
            For column = 0 To UBound(array, 2)
                resultArr(column, row) = array(row, column)
            Next
        Next

        rotateArray = resultArr

    End Function

    Function ЗаменитьДатуНаГод(массив As Object, НомерСтолбца As Integer) As Object
        Dim строка, столбец As Long
        Dim ИзмененныйМассив
        строка = UBound(массив, 1)
        столбец = UBound(массив, 2)
        ReDim ИзмененныйМассив(UBound(массив, 1), UBound(массив, 2))
        For строка = 0 To UBound(массив, 1)
            For столбец = 0 To UBound(массив, 2)
                If столбец = НомерСтолбца Then
                    Try
                        ИзмененныйМассив(строка, НомерСтолбца) = Year(массив(строка, НомерСтолбца))
                    Catch
                    End Try
                Else
                    ИзмененныйМассив(строка, столбец) = массив(строка, столбец)
                End If
            Next
        Next

        ЗаменитьДатуНаГод = ИзмененныйМассив
    End Function

    Function styleColumn(workSheet As Object, tables As Object) As Object

        Dim listSettings

        ReDim listSettings(tables.ListColumns.Count, 4)

        listSettings(0, 0) = "РазмерШрифта/.Font.Size"
        listSettings(0, 1) = "ИмяШрифта/.Font.Name"
        listSettings(0, 2) = "ВыравниваниеГоризонт/.HorizontalAlignment"
        listSettings(0, 3) = "ВыравниваниеВертикаль/.VerticalAlignment"
        listSettings(0, 4) = ".Orientation"

        For column = 1 To tables.ListColumns.Count

            Dim nameColumn As String = tables.name + "[" + tables.ListColumns(column).name + "]"

            With workSheet.Range(nameColumn)

                listSettings(column, 0) = .Font.Size
                listSettings(column, 1) = .Font.Name
                listSettings(column, 2) = .HorizontalAlignment
                listSettings(column, 3) = .VerticalAlignment
                listSettings(column, 4) = .Orientation

            End With

        Next

        styleColumn = listSettings

    End Function

    Function styleColumnRange(workSheet As Object, tables As Object) As Object

        Dim listSettings

        Dim adressRange As String
        Dim numberFerstRow, numberFerstCol, numberLastRow, numberLastCol As Int32
        Dim adress As String()
        Dim colRange

        adressRange = tables.Address
        adress = Split(adressRange, ":")
        numberFerstRow = workSheet.Range(adress(0)).Row
        numberFerstCol = workSheet.Range(adress(0)).Column

        If adress.Count > 1 Then

            numberLastRow = workSheet.Range(adress(1)).Row
            numberLastCol = workSheet.Range(adress(1)).Column

        Else

            numberLastRow = numberFerstRow
            numberLastCol = numberFerstCol

        End If

        ReDim listSettings(numberLastCol - numberFerstCol + 1, 4)

        listSettings(0, 0) = "РазмерШрифта/.Font.Size"
        listSettings(0, 1) = "ИмяШрифта/.Font.Name"
        listSettings(0, 2) = "ВыравниваниеГоризонт/.HorizontalAlignment"
        listSettings(0, 3) = "ВыравниваниеВертикаль/.VerticalAlignment"
        listSettings(0, 4) = ".Orientation"

        For count = 1 To numberLastCol - numberFerstCol + 1

            colRange = workSheet.Cells(numberFerstRow, count)
            colRange = colRange.Resize(1, numberLastRow - numberFerstRow + 1)

            With colRange

                listSettings(count, 0) = .Font.Size
                listSettings(count, 1) = .Font.Name
                listSettings(count, 2) = .HorizontalAlignment
                listSettings(count, 3) = .VerticalAlignment
                listSettings(count, 4) = .Orientation

            End With

        Next

        Return listSettings

    End Function

    Sub excell__setStyleRenge(workSheet As Object, rangeObj As Object, style As Object(,))

        Dim adressRange As String
        Dim numberFerstRow, numberFerstCol, numberLastRow, numberLastCol As Int32
        Dim adress As String()
        Dim colRange

        adressRange = rangeObj.Address
        adress = Split(adressRange, ":")
        numberFerstRow = workSheet.Range(adress(0)).Row
        numberFerstCol = workSheet.Range(adress(0)).Column

        If adress.Count > 1 Then

            numberLastRow = workSheet.Range(adress(1)).Row
            numberLastCol = workSheet.Range(adress(1)).Column

        Else

            numberLastRow = numberFerstRow
            numberLastCol = numberFerstCol

        End If

        For count As Integer = numberFerstCol To numberLastCol

            colRange = workSheet.Cells(numberFerstRow, count)
            colRange = colRange.Resize(1, numberLastRow - numberFerstRow + 1)

            With colRange

                .Font.Size = style(count - numberFerstCol + 1, 0)
                .Font.Name = style(count - numberFerstCol + 1, 1)
                .HorizontalAlignment = style(count - numberFerstCol + 1, 2)
                .VerticalAlignment = style(count - numberFerstCol + 1, 3)
                .Orientation = style(count - numberFerstCol + 1, 4)

            End With

        Next

    End Sub

    Sub НастроитьРедактированияСтолбца(Лист As Object, Таблица As Object, МассивНастроек As Object)

        For столбец = 1 To Таблица.ListColumns.Count
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").Font.Size = МассивНастроек(столбец, 0)
            Catch ex As Exception
            End Try
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").Font.Name = МассивНастроек(столбец, 1)
            Catch ex As Exception
            End Try
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").HorizontalAlignment = МассивНастроек(столбец, 2)
            Catch ex As Exception
            End Try
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").VerticalAlignment = МассивНастроек(столбец, 3)
            Catch ex As Exception
            End Try
            Try

            Catch ex As Exception
                Лист.Range("Таблица[Столбец" & столбец & "]").Orientation = МассивНастроек(столбец, 4)
            End Try
        Next

    End Sub

    Function СоздатьПапку(ПутьКПапке) As Boolean
        СоздатьПапку = True
        If Not Directory.Exists(ПутьКПапке) Then
            Try
                Directory.CreateDirectory(ПутьКПапке)
            Catch ex As Exception
                Warning.content.Text = "Не удалось создать папку: " & ПутьКПапке & " .Возможно нет нужных прав"
                СоздатьПапку = False
            End Try
        End If
    End Function

    Function checkDirectory(resourcesPath As String, listFolder As List(Of String)) As Boolean
        Dim folder As String = ""
        checkDirectory = True
        Dim resultPath As String = resourcesPath
        For Each folder In listFolder
            resultPath += folder + "\"
            If Not Directory.Exists(resultPath) Then
                Try
                    Directory.CreateDirectory(resultPath)
                Catch ex As Exception
                    Warning.content.Text = "Не удалось создать папку: " & resultPath & " .Возможно нет нужных прав"
                    checkDirectory = False
                End Try
            End If
        Next
    End Function

    Sub ДеактивироватьКонтролПоЧастиИмени(Форма As Form, ЧастьИмени As String, показать As Boolean)

        For Each контрол In Форма.Controls
            If InStr(LCase(контрол.name), LCase(ЧастьИмени)) > 0 Then
                If показать Then
                    контрол.Enabled = True
                Else контрол.Enabled = False
                End If

            End If
        Next

    End Sub

    Function ДобавитьНумерациюВМассив(Массив As Object) As Object
        Dim ИтоговыйМассив

        Dim С As Integer, СчетчикСтрок As Integer = 0
        С = UBound(Массив, 1)

        ReDim ИтоговыйМассив(UBound(Массив, 1), UBound(Массив, 2) + 1)

        For СчетчикСтрок = 0 To UBound(Массив, 1)
            For Счетчик = 0 To UBound(Массив, 2) + 1
                If Счетчик = 0 Then
                    ИтоговыйМассив(СчетчикСтрок, 0) = СчетчикСтрок + 1
                Else
                    ИтоговыйМассив(СчетчикСтрок, Счетчик) = Массив(СчетчикСтрок, Счетчик - 1)
                End If
            Next
        Next
        ДобавитьНумерациюВМассив = ИтоговыйМассив
    End Function

    Function ДобавитьНумерациюВМассивПервымСт(Массив As Object) As Object
        Dim ИтоговыйМассив
        Dim Сount As Integer, СчетчикСтрок As Integer = 0
        Dim СountColumn As Integer
        Dim СountRow As Integer
        СountColumn = UBound(Массив, 1)
        СountRow = UBound(Массив, 2)

        If СountColumn = 0 Then
            СountColumn = 1
        End If

        ' If СountRow = 0 Then
        ' СountRow = 1
        ' End If

        ReDim ИтоговыйМассив(СountColumn, СountRow)

        For Счетчик = 0 To СountColumn
            For СчетчикСтрок = 0 To СountRow
                If Счетчик = 0 Then
                    ИтоговыйМассив(Счетчик, СчетчикСтрок) = СчетчикСтрок + 1
                Else
                    ИтоговыйМассив(Счетчик, СчетчикСтрок) = Массив(Счетчик - 1, СчетчикСтрок)
                End If
            Next
        Next
        Return ИтоговыйМассив
    End Function

    Function выделитьСтрокиИзМассиваПоКритерию(Массив As Object, Критерий As Object, НомерСтолбца As Integer) As Object
        Dim ИтоговыйМассив
        Dim счетчик As Integer = 0
        'счетчик = UBound(Массив, 1)
        For СчетчикСтрок = 0 To UBound(Массив, 2)
            If Массив(НомерСтолбца, СчетчикСтрок) = Критерий Then
                счетчик += 1
            End If
        Next

        If счетчик = 0 Then
            ReDim ИтоговыйМассив(0, 0)
            ИтоговыйМассив(0, 0) = "Нет записей"
            выделитьСтрокиИзМассиваПоКритерию = ИтоговыйМассив
            Exit Function
        End If

        ReDim ИтоговыйМассив(UBound(Массив, 1), счетчик - 1)
        выделитьСтрокиИзМассиваПоКритерию = ИтоговыйМассив
        счетчик = 0
        For СчетчикСтрок = 0 To UBound(Массив, 2)
            If Массив(НомерСтолбца, СчетчикСтрок) = Критерий Then
                For СчетчикСтолбцов = 0 To UBound(Массив, 1)
                    ИтоговыйМассив(СчетчикСтолбцов, счетчик) = Массив(СчетчикСтолбцов, СчетчикСтрок)
                Next
                счетчик += 1
            End If
        Next

    End Function


End Module
