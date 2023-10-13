Module ПеднагрузкаОтчет
    Sub workerReport(arg As String, excellApp As Object, excellWorkbook As Object, DateStart As String, DateEnd As String)

        Dim sample, ФорматированиеСтолбцов, excellSheet
        Dim adress
        Dim list
        Dim samplePath, pathNewFile, resourcesPath, name, titleRow, adressTbl As String

        If arg = "Педнагрузка" Then

            name = "педнагрузка"
            titleRow = "Книга учёта выданных свидетельств о профессии рабочего, должности служащего"

        End If

        'excellApp.Visible = True
        resourcesPath = _technical.updateResourcesPath()
        samplePath = resourcesPath & "Шаблоны\Педнагрузка.xlsx"
        pathNewFile = resourcesPath & "Отчеты\"

        sample = excellApp.Workbooks.Open(samplePath, ReadOnly:=True)
        sample.Worksheets(1).copy(before:=excellWorkbook.Worksheets(1))
        sample.Close
        list = loadListData(arg, DateStart, DateEnd)

        If list(0, 0).ToString = "нет записей" Then
            Exit Sub
        End If

        excellSheet = excellWorkbook.Worksheets(1)
        excellSheet.name = arg
        ФорматированиеСтолбцов = _technical.styleColumn(excellSheet, excellSheet.ListObjects("Таблица"))
        adressTbl = excellSheet.ListObjects("Таблица").Range.Address
        adress = Split(adressTbl, ":")
        list = rotateArray(list)
        list = ДобавитьНумерациюВМассив(list)

        titleRow = Strings.Replace(excellSheet.Range("A1").Value, "$ДатаНачала$", MainForm.ДатаНачалаОтчета.Value.ToShortDateString)
        titleRow = Strings.Replace(titleRow, "$ДатаОкончания$", MainForm.ДатаКонцаОтчета.Value.ToShortDateString)
        excellSheet.Range("A1") = titleRow


        excellSheet.Range(adress(0)).Resize(UBound(list, 1) + 1, UBound(list, 2) + 1) = list
        excellSheet.Range(adress(0)).Resize(UBound(list, 1) + 1, UBound(list, 2) + 1).cut(excellSheet.Range(adress(0)))

        НастроитьРедактированияСтолбца(excellSheet, excellSheet.ListObjects("Таблица"), ФорматированиеСтолбцов)

        With excellSheet.ListObjects("Таблица").Range
            .WrapText = True
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
        End With

    End Sub

    Function loadListData(arg As String, DateStart As String, DateEnd As String, Optional kod As String = "-1") As Object

        Dim resultList
        Dim resultArr
        Dim queryString As String = ""

        If arg = "Педнагрузка" Then

            queryString = workerReportLoad(DateStart, DateEnd)
            resultArr = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        ElseIf arg = "listWorker" Then

            queryString = pednagrExtended__loadListWorker(DateStart, DateEnd)
            resultList = MainForm.mySqlConnect.mySqlToListAll(queryString, 1)

        ElseIf arg = "listWorkerData" Then

            queryString = pednagrExtended__loadListWorkerData(DateStart, DateEnd, kod)
            resultList = MainForm.mySqlConnect.mySqlToListAll(queryString, 1)

        End If

        If IsNothing(resultArr) Then

            If resultList.Count = 0 Then

                Warning.content.Text = "Нет данных для отображения"
                openForm(Warning)

                Return resultList

            End If

            Return resultList

        ElseIf resultArr(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)

        End If


        Return resultArr

    End Function

    Sub pednagrExtended(excellApp As Object, excellWorkbook As Object, DateStart As String, DateEnd As String)

        Dim sample, columnStyle, excellSheet
        Dim listWorker, resultList As New List(Of List(Of String))
        Dim adress
        Dim rangeObj, rangeTblTilte
        Dim workerDataList
        Dim samplePath, pathNewFile, resourcesPath, titleRow, adressTbl As String
        Dim numberRow, numberColumnTitle, numberColumnTbl, counterRows As Integer
        Dim listTitelAdress As New List(Of String)

        counterRows = 0

        listWorker = loadListData("listWorker", DateStart, DateEnd)

        If listWorker.Count = 0 Then

            Exit Sub

        End If

        resourcesPath = _technical.updateResourcesPath()
        samplePath = resourcesPath & "Шаблоны\Педнагрузка.xlsx"
        pathNewFile = resourcesPath & "Отчеты\"

        sample = excellApp.Workbooks.Open(samplePath, ReadOnly:=True)
        sample.Worksheets(2).copy(before:=excellWorkbook.Worksheets(1))
        sample.Close

        excellSheet = excellWorkbook.Worksheets(1)
        excellSheet.name = "педнагрузка_расш"
        columnStyle = _technical.styleColumnRange(excellSheet, excellSheet.Range("firstRow"))

        titleRow = Strings.Replace(excellSheet.Range("title").Value, "$ДатаНачала$", MainForm.ДатаНачалаОтчета.Value.ToShortDateString)
        titleRow = Strings.Replace(titleRow, "$ДатаОкончания$", MainForm.ДатаКонцаОтчета.Value.ToShortDateString)
        excellSheet.Range("title") = titleRow

        numberRow = excellSheet.Range("title").Row
        numberColumnTitle = excellSheet.Range("title").Column

        adressTbl = excellSheet.Range("tblPednagrExtended").Address

        adress = Split(adressTbl, ":")

        numberColumnTbl = excellSheet.Range(adress(0)).Column

        numberRow = excellSheet.Range(adress(0)).Row

        rangeTblTilte = excellSheet.Cells(numberRow, numberColumnTbl).Resize(1, 8)

        For Each worker As List(Of String) In listWorker

            If counterRows = 0 Then

                listTitelAdress.Add(0)

            Else

                resultList.Add(New List(Of String)({"", "", "", "", "", "", "", ""}))
                resultList.Add(New List(Of String)({worker(1), "", "", "", "", "", "", ""}))
                resultList.Add(New List(Of String)({"", "", "", "", "", "", "", ""}))
                resultList.Add(New List(Of String)({"", "", "", "", "", "", "", ""}))

                counterRows += 4
                listTitelAdress.Add(counterRows)

            End If

            workerDataList = loadListData("listWorkerData", DateStart, DateEnd, Convert.ToString(worker(0)))
            counterRows += workerDataList.count

            resultList.AddRange(workerDataList)

        Next

        workerDataList = list2ToArray2(resultList)

        rangeObj = excellSheet.Cells(numberRow + 1, numberColumnTbl)

        rangeObj.Resize(resultList.Count, resultList(0).Count) = workerDataList
        rangeObj = rangeObj.Resize(resultList.Count, resultList(0).Count)
        excellSheet.Range(adress(0)).Resize(UBound(workerDataList, 1) + 1, UBound(workerDataList, 2) + 1).cut(excellSheet.Range(adress(0)))


        excell__setStyleRenge(excellSheet, rangeObj, columnStyle)

        With rangeObj

            .WrapText = True
            .EntireColumn.AutoFit

        End With

        For Each title As String In listTitelAdress

            rangeTblTilte.Copy()
            rangeObj = excellSheet.Cells(Convert.ToInt32(title) + numberRow, numberColumnTbl)
            rangeObj.PasteSpecial(-4104)

            adressTbl = rangeObj.Address
            adress = Split(adressTbl, ":")
            rangeObj = excellSheet.Range(adress(0), rangeObj.End(-4161))
            rangeObj = rangeObj.End(-4161)


            With excellSheet.Range(adress(0), rangeObj.End(-4121))
                .Borders.LineStyle = True
            End With


        Next

    End Sub


End Module
