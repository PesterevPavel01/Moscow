Module КнигаУчетаФРДО

    Sub КнигаУчета(argument As String)
        Dim excellApp, excellObject, sample, ColumnSetts
        Dim excellBook, coordinates
        Dim excellSheet, array, Obl, mass
        Dim samplePath, newFilePath, resourcesPath, name, title, adress As String

        If argument = "Удостоверение" Then
            name = " удостоверений "
            title = "Книга учёта выданных удостоверений о повышении квалификации"
        End If

        If argument = "Диплом" Then
            name = " дипломов "
            title = "Книга учёта выданных дипломов о профессиональной переподготовке"
        End If

        If argument = "Свидетельство" Then
            name = " свидетельств "
            title = "Книга учёта выданных свидетельств о профессии рабочего, должности служащего"
        End If

        array = ЗагрузитьСписок(argument, MainForm.mySqlConnect.dateToFormatMySQL(MainForm.ДатаНачалаОтчета.Value.ToShortDateString), MainForm.mySqlConnect.dateToFormatMySQL(MainForm.ДатаКонцаОтчета.Value.ToShortDateString))


        If array(0, 0).ToString = "нет записей" Then
            Exit Sub
        End If

        array = ДобавитьРубашкуСПробеломВКонцеВМассив(array, 16)

        resourcesPath = _technical.updateResourcesPath()
        samplePath = resourcesPath & "Шаблоны\Книга учёта выданных" & name & "ФРДО.xlsx"
        newFilePath = resourcesPath & "Отчеты\Книги Учета"
        excellObject = _technical.СозданиеКнигиЭксельИЛИОшибкаВ0(newFilePath, "Книга учёта выданных" & name & " ФРДО")

        If excellObject(0).ToString = "Ошибка" Then
            Exit Sub
        End If

        excellApp = excellObject(0)
        excellBook = excellObject(1)

        sample = excellApp.Workbooks.Open(samplePath, ReadOnly:=True)
        sample.Worksheets(1).copy(before:=excellBook.Worksheets(1))
        sample.Close

        excellSheet = excellBook.Worksheets(1)
        excellSheet.name = argument
        ColumnSetts = _technical.styleColumn(excellSheet, excellSheet.ListObjects("Таблица"))
        adress = excellSheet.ListObjects("Таблица").Range.Address
        coordinates = Split(adress, ":")
        array = addZerosIntoArray(array, 2, 5)
        array = arrayMethod.removeEmpty(rotateArray(array))
        excellSheet.Range("A1") = title
        excellSheet.Range("A2") = "за период с " & MainForm.ДатаНачалаОтчета.Value.ToShortDateString & " по " & MainForm.ДатаКонцаОтчета.Value.ToShortDateString & "г."

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
    End Sub

    Function ЗагрузитьСписок(Критерий As String, dateStart As String, dateEnd As String) As Object
        Dim listResult
        Dim sqlQuery As String

        If Критерий = "Удостоверение" Then

            sqlQuery = accountingBook__loadListUdFRDO(dateStart, dateEnd)

        ElseIf Критерий = "Диплом" Then

            sqlQuery = accountingBook__loadListDipFRDO(dateStart, dateEnd)

        ElseIf Критерий = "Свидетельство" Then

            sqlQuery = accountingBook__loadListSvidFRDO(dateStart, dateEnd)

        End If

        listResult = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If listResult(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ЗагрузитьСписок = listResult
            Exit Function

        End If
        ЗагрузитьСписок = listResult
    End Function

End Module
