Imports System.Threading

Public Class BookFRDO

    Public threadFlags = New Dictionary(Of String, Boolean)
    Dim booksFRDOThread As Thread
    Public bookArgument As New BooksArgument

    Sub run(argument As BooksArgument)
        Dim excellApp, excellObject, sample, ColumnSetts
        Dim excellBook, coordinates
        Dim excellSheet, array, Obl, mass
        Dim samplePath, newFilePath, resourcesPath, name, title, adress As String

        If argument.type = "Удостоверение" Then
            name = " удостоверений "
            title = "Книга учёта выданных удостоверений о повышении квалификации"
        End If

        If argument.type = "Диплом" Then
            name = " дипломов "
            title = "Книга учёта выданных дипломов о профессиональной переподготовке"
        End If

        If argument.type = "Свидетельство" Then
            name = " свидетельств "
            title = "Книга учёта выданных свидетельств о профессии рабочего, должности служащего"
        End If

        array = loadData(argument.type, argument.dateStart, argument.dateEnd)


        If array(0, 0).ToString = "нет записей" Then
            argument.SC.Send(AddressOf enabledButton, True)
            Exit Sub
        End If

        array = ДобавитьРубашкуСПробеломВКонцеВМассив(array, 16)

        resourcesPath = _technical.updateResourcesPath()
        samplePath = resourcesPath & "Шаблоны\Книга учёта выданных" & name & "ФРДО.xlsx"
        newFilePath = resourcesPath & "Отчеты\Книги Учета"
        excellObject = _technical.createExcellWorkBook(newFilePath, "Книга учёта выданных" & name & " ФРДО")

        If excellObject(0).ToString = "Ошибка" Then
            argument.SC.Send(AddressOf enabledButton, True)
            Exit Sub
        End If

        excellApp = excellObject(0)
        excellBook = excellObject(1)

        sample = excellApp.Workbooks.Open(samplePath, ReadOnly:=True)
        sample.Worksheets(1).copy(before:=excellBook.Worksheets(1))
        sample.Close

        excellSheet = excellBook.Worksheets(1)
        excellSheet.name = argument.type
        ColumnSetts = _technical.styleColumn(excellSheet, excellSheet.ListObjects("Таблица"))
        adress = excellSheet.ListObjects("Таблица").Range.Address
        coordinates = Split(adress, ":")
        array = addZerosIntoArray(array, 2, 5)
        array = arrayMethod.removeEmpty(rotateArray(array))
        excellSheet.Range("A1") = title
        excellSheet.Range("A2") = "за период с " & argument.dateStart & " по " & argument.dateEnd & "г."

        array = ЗаменитьДатуНаГод(array, 8)
        array = ЗаменитьДатуНаГод(array, 9)

        Dim i As Integer = UBound(array, 1) + 1
        Dim j As Integer = UBound(array, 2) + 1

        Dim count As Integer = 0
        Dim flag = True

        Obl = excellBook.Worksheets(2).Range("C1").Resize(UBound(array, 1) + 10, 1)
        Obl.NumberFormat = "@"

        mass = partArray(array, 0, i - 1)
        excellBook.Worksheets(2).Range("A1").Resize(i, UBound(array, 2) + 1) = mass
        excellBook.Worksheets(2).Range("A1").Resize(i, UBound(array, 2) + 1).cut(excellSheet.Range("A6"))

        НастроитьРедактированияСтолбца(excellSheet, excellSheet.ListObjects("Таблица"), ColumnSetts)

        With excellSheet.ListObjects("Таблица").Range
            .WrapText = True
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .HorizontalAlignment = -4131
        End With
        excellApp.visible = True
        Obl = excellSheet.ListObjects("Таблица")
        Obl = Obl.ListColumns(1).Range
        Obl.NumberFormat = "0.00"
        Obl.NumberFormat = "0"

        excellApp.visible = True
        excellBook.Save

        argument.SC.Send(AddressOf enabledButton, True)
    End Sub

    Private Sub setFlag()

        Dim status As Boolean = False

        For Each flag As KeyValuePair(Of String, Boolean) In threadFlags
            If flag.Key = "bookFRDO" Then status = True
        Next

        If Not status Then
            threadFlags.Add("bookFRDO", True)
        Else
            threadFlags("bookFRDO") = True
        End If

    End Sub

    Private Sub enabledButton(value As Boolean)

        enabledBooksFRDO(value)

    End Sub

    Public Sub bookFRDOClick()
        Dim datePicker As DateTimePicker
        Dim shortDateStart, shortDateEnd As String
        datePicker = mainFormBuilder.controls(mainFormBuilder.controlNames("reportStart"))
        shortDateStart = datePicker.Value.ToShortDateString
        datePicker = mainFormBuilder.controls(mainFormBuilder.controlNames("reportEnd"))
        shortDateEnd = datePicker.Value.ToShortDateString

        enabledBooksFRDO(False)
        bookArgument.SC = SynchronizationContext.Current
        bookArgument.dateStart = shortDateStart
        bookArgument.dateEnd = shortDateEnd
        booksFRDOThread = New Thread(AddressOf run)
        booksFRDOThread.IsBackground = True
        setFlag()
        booksFRDOThread.Start(bookArgument)

    End Sub
    Public Sub enabledBooksFRDO(value As Boolean)
        For Each button As Button In MainForm.booksFRDOSection.Controls.OfType(Of Button)
            button.Enabled = value
        Next
        If value Then threadFlags("bookFRDO") = False
    End Sub

    Function loadData(Критерий As String, dateStart As String, dateEnd As String) As Object
        Dim listResult
        Dim sqlQuery As String

        If Критерий = "Удостоверение" Then

            sqlQuery = accountingBook__loadListUdFRDO(MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateStart)), MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateEnd)))

        ElseIf Критерий = "Диплом" Then

            sqlQuery = accountingBook__loadListDipFRDO(MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateStart)), MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateEnd)))

        ElseIf Критерий = "Свидетельство" Then

            sqlQuery = accountingBook__loadListSvidFRDO(MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateStart)), MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateEnd)))

        End If

        listResult = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If listResult(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            loadData = listResult
            Exit Function

        End If
        loadData = listResult
    End Function

End Class
