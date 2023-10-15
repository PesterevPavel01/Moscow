
Module OtchetExcell

    Public numberBVB As Integer
    Public numberOtchrtRuk As Integer
    Public adress As String
    Public array
    Public counterBudj As Integer, counterStudents As Integer

    Sub createMainDokument()

        Dim excellApp As Object
        Dim excellWorkBook As Object
        Dim excellSheet As Object
        Dim excellObjects
        ReDim excellObjects(1)
        Dim groupsArray
        Dim list
        Dim studentList
        Dim resultList
        Dim otchetList
        Dim listData As List(Of List(Of String))
        Dim hours
        Dim counter, counter2, counter3, СчетчикПр As Integer
        Dim sqlQuery, DateStart, DateEnd, path As String

        DateStart = MainForm.mySqlConnect.dateToFormatMySQL(MainForm.ДатаНачалаОтчета.Value.ToShortDateString)
        DateEnd = MainForm.mySqlConnect.dateToFormatMySQL(MainForm.ДатаКонцаОтчета.Value.ToShortDateString)

        sqlQuery = selectCol_otchet_info(DateStart, DateEnd)
        groupsArray = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        sqlQuery = selectNumberHours()
        hours = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)


        sqlQuery = SQLString_OtchetMassSlush(DateStart, DateEnd)
        list = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        '------------------------------------------------------------------------------------------------------

        If list(0, 0).ToString = "нет записей" Then
            MsgBox("Не найденно групп с зарегистрированными слушателями")
            Exit Sub
        End If
        sqlQuery = SQLString_OtchetMassDataSlush(DateStart, DateEnd)

        studentList = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        counter = 0

        ReDim resultList(50, UBound(list, 2))

        While counter <= UBound(resultList, 2)

            resultList(0, counter) = list(1, counter)
            resultList(1, counter) = list(2, counter)

            counter2 = 0
            СчетчикПр = UBound(studentList, 2)
            While counter2 <= UBound(studentList, 2)

                If resultList(0, counter) = studentList(1, counter2) Then

                    counter3 = 2
                    While counter3 <= UBound(studentList, 1)

                        resultList(counter3, counter) = studentList(counter3, counter2)
                        counter3 = counter3 + 1

                    End While

                End If

                counter2 = counter2 + 1
            End While

            counter = counter + 1

        End While

        counter = 0
        While counter <= UBound(resultList, 2)

            counter2 = 0
            СчетчикПр = UBound(groupsArray, 2)
            While counter2 <= UBound(groupsArray, 2)

                If resultList(1, counter) = groupsArray(1, counter2) Then

                    counter3 = 2
                    While counter3 <= UBound(groupsArray, 1)

                        resultList(counter3 + 25, counter) = groupsArray(counter3, counter2)
                        counter3 = counter3 + 1

                    End While

                End If


                counter2 = counter2 + 1
            End While

            counter = counter + 1

        End While

        resultList = arrayMethod.removeEmpty(resultList)

        MainForm.Name = "Отчет" & Date.Now.ToShortDateString & "_" & MainForm.orderNumber.ToString & ".xlsx"
        path = _technical.updateResourcesPath
        path = path & "Отчеты\"

        excellObjects = _technical.createExcellWorkBook(path, MainForm.Name, MainForm.orderNumber)

        If excellObjects(0).ToString = "Ошибка" Then
            Exit Sub
        End If
        excellApp = excellObjects(0)
        excellWorkBook = excellObjects(1)

        MainForm.orderNumber = MainForm.orderNumber + 1

        If MainForm.ОтчетРуководителя.Checked Then

            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "ОтчетРуководителя"
            sqlQuery = SQLString_managerOrder(DateStart, DateEnd)
            listData = MainForm.mySqlConnect.mySqlToListAll(sqlQuery, 1)

            If Not listData.Count = 0 Then
                createORuk(excellSheet, listData, resultList, groupsArray)
            Else
                Warning.content.Text = "Нет информации отвечающей условиям отбора для отчета руководителя"
                Warning.ShowDialog()
            End If

        End If

        If MainForm.ChРМАНПО.Checked Then
            sqlQuery = SQLString_OtchetRMANPO(DateStart, DateEnd)
            listData = MainForm.mySqlConnect.mySqlToListAll(sqlQuery, 1)

            If Not listData.Count = 0 Then
                CreateRMANPO(excellApp, excellWorkBook, listData, resultList, groupsArray, MonthName(MainForm.ДатаКонцаОтчета.Value.Month))
            Else
                Warning.content.Text = "Нет информации отвечающей условиям отбора для PVFYGJ"
                Warning.ShowDialog()
            End If
        End If

        If MainForm.ChСводПоКурсам.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "СводПоКурсам"
            sqlQuery = SQLString_OtchetKurs(DateStart, DateEnd, "курс")
            otchetList = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

            If Not otchetList(0, 0).ToString = "нет записей" Then
                createSPK(excellSheet, rotateArray(otchetList), "СводПоКурсам")
            Else
                Warning.content.Text = "Нет информации отвечающей условиям отбора для отчета Свод по курсам"
                Warning.ShowDialog()
            End If
        End If

        If MainForm.СводПоСпец.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "СводПоСпециальностям"
            sqlQuery = SQLString_OtchetKurs(DateStart, DateEnd, "специальность")
            otchetList = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

            If Not otchetList.ToString = "нет записей" Then
                createSPK(excellSheet, rotateArray(otchetList), "СводПоСпециальностям")
            Else
                Warning.content.Text = "Нет информации отвечающей условиям отбора для отчета Свод по специальностям"
                Warning.ShowDialog()
            End If
        End If

        If MainForm.СводПоОрганиз.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "ПереченьОрганизаций"
            sqlQuery = SQLString_organizationOrder(DateStart, DateEnd)
            otchetList = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

            If Not otchetList.ToString = "нет записей" Then
                createSPO(excellSheet, otchetList)
            Else
                Warning.content.Text = "Нет информации отвечающей условиям отбора для отчета Свод по организациям"
                Warning.ShowDialog()
            End If
        End If

        If MainForm.БюджетВбюдж.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "БюджетВнебюджет"

            ReDim otchetList(2)
            sqlQuery = SQLString_OtchetBud_Vbud(DateStart, DateEnd, "полный")
            listData = MainForm.mySqlConnect.mySqlToListAll(sqlQuery, 1)
            otchetList(0) = listData

            sqlQuery = SQLString_OtchetBud_Vbud(DateStart, DateEnd, "бюджет")
            otchetList(1) = MainForm.mySqlConnect.mySqlToListAll(sqlQuery, 1)

            sqlQuery = SQLString_OtchetBud_Vbud(DateStart, DateEnd, "внебюджет")
            otchetList(2) = MainForm.mySqlConnect.mySqlToListAll(sqlQuery, 1)

            If Not listData.Count = 0 Then
                createBVB(excellSheet, otchetList, hours)
            Else
                Warning.content.Text = "Нет информации отвечающей условиям отбора для отчета Бюджет/Внебюджет"
                Warning.ShowDialog()
            End If
        End If

        If MainForm.ОтчетПеднагрузка.Checked Then

            ПеднагрузкаОтчет.workerReport("Педнагрузка", excellApp, excellWorkBook, DateStart, DateEnd)

        End If

        If MainForm.chPednagrExt.Checked Then

            ПеднагрузкаОтчет.pednagrExtended(excellApp, excellWorkBook, DateStart, DateEnd)

        End If

        Try

            excellWorkBook.Save

        Catch ex As Exception

            Exit Sub

        End Try

        excellApp.DisplayAlerts = True
        excellApp.Visible = True

    End Sub

    Sub CreateRMANPO(Excell As Object, WBook As Object, listData As List(Of List(Of String)), Специальности As Object, Группы As Object, month As String)
        Dim Шаблон, Wsor
        Dim adressRow, spec, Val_A As String
        Dim count, countEnd As Integer, counterRows As Integer
        Dim ПутьКШаблону, resourcesPath As String
        Dim sum_d, sum_e, sum_f As Int64
        Val_A = ""
        sum_d = 0
        sum_e = 0
        sum_f = 0
        resourcesPath = _technical.updateResourcesPath()
        ПутьКШаблону = resourcesPath & "Шаблоны\Отчёт_РМАНПО.xlsx"

        Шаблон = Excell.Workbooks.Open(ПутьКШаблону, ReadOnly:=True)
        Шаблон.Worksheets(1).copy(before:=WBook.Worksheets(1))
        Шаблон.Close

        Wsor = WBook.Worksheets(1)
        Wsor.Name = "РМАНПО"
        counterRows = 7
        count = 0

        'Excell.Visible = True

        For Each Row In listData

            If Row(0) <> spec Then
                adressRow = "A" & counterRows
                If Row(0) <> "Без специальности" Then
                    Wsor.Range(adressRow).Value = "Специальность " + Row(0)
                Else
                    Wsor.Range(adressRow).Value = Row(0)
                End If
                adressRow += ":H" & counterRows
                Wsor.Range(adressRow).Merge
                counterRows += 1
            End If

            If Val_A <> Row(1) Then

                If count <> 0 And countEnd <> 0 And countEnd > count Then
                    adressRow = "A" & count & ":A" & countEnd
                    Wsor.Range(adressRow).Merge
                    'Wsor.Range(Строка).WrapText = True
                    adressRow = "B" & count & ":B" & countEnd
                    Wsor.Range(adressRow).Merge
                    adressRow = "C" & count & ":C" & countEnd
                    Wsor.Range(adressRow).Merge
                    adressRow = "D" & count & ":D" & countEnd
                    Wsor.Range(adressRow).Merge
                    adressRow = "E" & count & ":E" & countEnd
                    Wsor.Range(adressRow).Merge
                    adressRow = "F" & count & ":F" & countEnd
                    Wsor.Range(adressRow).Merge
                End If

                count = counterRows

                Val_A = Row(1)
                adressRow = "A" & counterRows
                Wsor.Range(adressRow).Value = Row(1)

                adressRow = "B" & counterRows
                Wsor.Range(adressRow).Value = Row(2)

                adressRow = "C" & counterRows
                Wsor.Range(adressRow).Value = Row(3)

                adressRow = "D" & counterRows
                Wsor.Range(adressRow).Value = Row(4)
                sum_d += Convert.ToInt64(Row(4))

                adressRow = "E" & counterRows
                Wsor.Range(adressRow).Value = Row(5)
                sum_e += Convert.ToInt64(Row(5))

                adressRow = "F" & counterRows
                Wsor.Range(adressRow).Value = Row(6)
                sum_f += Convert.ToInt64(Row(6))

            Else
                countEnd = counterRows
            End If

            adressRow = "G" & counterRows
            Wsor.Range(adressRow).Value = Row(7)

            adressRow = "H" & counterRows
            Wsor.Range(adressRow).Value = Row(8)

            counterRows += 1
            spec = Row(0)
        Next

        ' Для объединения последней группы

        If count <> 0 And countEnd <> 0 And countEnd > count Then
            adressRow = "A" & count & ":A" & countEnd
            Wsor.Range(adressRow).Merge
            'Wsor.Range(Строка).WrapText = True
            adressRow = "B" & count & ":B" & countEnd
            Wsor.Range(adressRow).Merge
            adressRow = "C" & count & ":C" & countEnd
            Wsor.Range(adressRow).Merge
            adressRow = "D" & count & ":D" & countEnd
            Wsor.Range(adressRow).Merge
            adressRow = "E" & count & ":E" & countEnd
            Wsor.Range(adressRow).Merge
            adressRow = "F" & count & ":F" & countEnd
            Wsor.Range(adressRow).Merge
        End If

        adressRow = "C" & counterRows
        Wsor.Range(adressRow).Value = "ИТОГО за " + month
        adressRow = "D" & counterRows
        Wsor.Range(adressRow).Value = Convert.ToString(sum_d)
        adressRow = "E" & counterRows
        Wsor.Range(adressRow).Value = Convert.ToString(sum_e)
        adressRow = "F" & counterRows
        Wsor.Range(adressRow).Value = Convert.ToString(sum_f)
        adressRow = "H" & counterRows
        Wsor.Range(adressRow).Value = Convert.ToString(sum_d)

        adressRow = "A7:H" & counterRows
        With Wsor.Range(adressRow)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .WrapText = True
            .Borders.LineStyle = True
            .VerticalAlignment = -4108
            '.EntireColumn.AutoFit
        End With

        Wsor.Activate

    End Sub

    Sub createORuk(Wsor As Object, listData As List(Of List(Of String)), specialitys As Object, groups As Object)
        Dim adressRow, spec As String
        Dim listValues
        Dim counterRows As Integer

        OtchetExcell.array = array

        ReDim listValues(1, 10)

        listValues(0, 0) = "№ Гр"
        listValues(0, 1) = "Курс"
        listValues(0, 2) = "Кол-во часов"
        listValues(0, 3) = "Период обучения"
        listValues(0, 4) = "Количество человек"
        listValues(0, 5) = ""
        listValues(0, 6) = ""
        listValues(0, 7) = "Кол-во групп"
        listValues(0, 8) = ""
        listValues(0, 9) = "Кол-во выполн."
        listValues(0, 10) = ""

        listValues(1, 0) = ""
        listValues(1, 1) = ""
        listValues(1, 2) = ""
        listValues(1, 3) = ""
        listValues(1, 4) = "Всего"
        listValues(1, 5) = "Бюджет"
        listValues(1, 6) = "Внебюджет"
        listValues(1, 7) = "Бюджет"
        listValues(1, 8) = "Внебюджет"
        listValues(1, 9) = "Бюджет"
        listValues(1, 10) = "Внебюджет"

        Wsor.Range("A1").Resize(2, 11) = listValues
        With Wsor.Range("A1").Resize(2, 11)
            .Font.Bold = True
        End With

        Wsor.Range("A1:A2").Merge
        Wsor.Range("B1:B2").Merge
        Wsor.Range("C1:C2").Merge
        Wsor.Range("D1:D2").Merge
        Wsor.Range("E1:G1").Merge
        Wsor.Range("H1:I1").Merge
        Wsor.Range("J1:K1").Merge

        counterRows = 3

        For Each row In listData
            If row(0) <> spec Then
                adressRow = "A" & counterRows
                Wsor.Range(adressRow).Value = row(0)
                adressRow += ":K" & counterRows
                Wsor.Range(adressRow).Merge
                counterRows += 1
            End If

            adressRow = "A" & counterRows
            Wsor.Range(adressRow).Value = row(1)

            adressRow = "B" & counterRows
            Wsor.Range(adressRow).Value = row(2)

            adressRow = "C" & counterRows
            Wsor.Range(adressRow).Value = row(3)

            adressRow = "D" & counterRows
            Wsor.Range(adressRow).Value = row(4)

            adressRow = "E" & counterRows
            Wsor.Range(adressRow).Value = row(5)

            adressRow = "F" & counterRows
            Wsor.Range(adressRow).Value = row(6)

            adressRow = "G" & counterRows
            Wsor.Range(adressRow).Value = row(7)

            adressRow = "H" & counterRows
            Wsor.Range(adressRow).Value = row(8)

            adressRow = "I" & counterRows
            Wsor.Range(adressRow).Value = row(9)

            adressRow = "J" & counterRows
            Wsor.Range(adressRow).Value = row(10)

            adressRow = "K" & counterRows
            Wsor.Range(adressRow).Value = row(11)

            counterRows += 1
            spec = row(0)
        Next


        adressRow = "A1:K" & counterRows - 1
        With Wsor.Range(adressRow)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .VerticalAlignment = -4108
            .EntireColumn.AutoFit
        End With

        Wsor.Activate

    End Sub

    Sub createSPK(WSOR As Object, listData As Object, arg As String)
        Dim result As Object
        Dim name As String
        Dim counter, counterRows, column As Integer
        OtchetExcell.array = array
        If arg = "СводПоКурсам" Then
            column = 6
            name = "Курс"
        End If
        If arg = "СводПоСпециальностям" Then
            column = 5
            name = "Специальность"
        End If

        counterRows = 2
        counter = 0

        ReDim result(0, 3)
        result(0, 0) = name
        result(0, 1) = "Количество человек"
        result(0, 2) = "Количество часов"
        result(0, 3) = "Итого"

        WSOR.Range("A1").Resize(1, 4) = result
        With WSOR.Range("A1").Resize(1, 4)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .Font.Bold = True
        End With

        WSOR.Range("A2").Resize(UBound(listData, 1) + 1, UBound(listData, 2) + 1) = listData

        With WSOR.Range("A2").Resize(UBound(listData, 1) + 1, UBound(listData, 2) + 1)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .WrapText = False
            .Orientation = 0
            .Font.Bold = True
            .EntireColumn.AutoFit
        End With

        WSOR.Activate

    End Sub


    Sub createSPO(WSOR As Object, array As Object)

        Dim result As Object


        ReDim result(0, 1)
        result(0, 0) = "Организация"
        result(0, 1) = "Количество человек"

        WSOR.Range("A1").Resize(1, 2) = result
        With WSOR.Range("A1").Resize(1, 2)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .Font.Bold = True

        End With

        array = rotateArray(array)
        WSOR.Range("A2").Resize(UBound(array, 1) + 1, 2) = array

        With WSOR.Range("A2").Resize(UBound(array, 1) + 1, 2)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True


        End With

        WSOR.Activate
    End Sub


    Sub createBVB(WSOR As Object, МассивОтчета As Object, часы As Object)
        Dim stat As Boolean = False
        Dim Шаблон
        Dim budjet
        Dim vBudjet
        Dim result
        Dim counter, counter2, counter3, counter4 As Integer
        Dim arg, cell As String
        Dim summB, summVB, summResult As Double
        Dim listData As List(Of List(Of String)) = МассивОтчета(0)
        Dim listDataB As List(Of List(Of String)) = МассивОтчета(1)
        Dim listDataVB As List(Of List(Of String)) = МассивОтчета(2)

        WSOR.Cells(1, 1) = "БЮДЖЕТ"
        WSOR.Cells(11, 1) = "ВНЕБЮДЖЕТ"
        WSOR.Cells(21, 1) = "ИТОГО"

        counter2 = 0

        While counter2 <= 2
            With WSOR.Cells((counter2 * 10 + 1), (counter + 1))
                .Font.Name = "Times New Roman"
                .Font.Size = 11
                .HorizontalAlignment = -4131
                .EntireColumn.AutoFit
                .WrapText = False
                .Orientation = 0
                .Font.Bold = True
                .EntireColumn.AutoFit

            End With
            counter2 = counter2 + 1
        End While

        counter = 0
        ReDim Шаблон(5, UBound(часы, 2) + 2)

        While counter <= UBound(часы, 2)

            Шаблон(0, counter + 1) = часы(1, counter) & " час."

            counter = counter + 1
        End While

        Шаблон(0, counter + 1) = "ИТОГО"
        Шаблон(1, 0) = "Кол-во человек"
        Шаблон(2, 0) = "из них мужчин"
        Шаблон(3, 0) = "из них старше 60 лет"
        Шаблон(4, 0) = "выполнено часов"
        Шаблон(5, 0) = "кол-во групп"



        counter2 = 0

        While counter2 <= 2
            cell = "A" & counter2 * 10 + 2
            WSOR.Range(cell).Resize(6, UBound(часы, 2) + 3) = Шаблон

            With WSOR.Range(cell).Resize(6, UBound(часы, 2) + 3)
                .Font.Name = "Times New Roman"
                .Font.Size = 11
                .HorizontalAlignment = -4131
                .EntireColumn.AutoFit
                .Borders.LineStyle = True
                .WrapText = False
                .Orientation = 0
                .Font.Bold = True
                .EntireColumn.AutoFit
            End With
            counter2 = counter2 + 1
        End While


        ReDim budjet(4, UBound(часы, 2) + 1)
        ReDim vBudjet(4, UBound(часы, 2) + 1)
        ReDim result(4, UBound(часы, 2) + 1)
        counter2 = 0


        While counter2 <= 2
            If counter2 = 0 Then arg = "бюджет"
            If counter2 = 1 Then arg = "внебюджет"

            counter = 0
            While counter <= UBound(часы, 2)

                If counter2 = 0 Then
                    For Each List As List(Of String) In listDataB
                        If List(0) = часы(1, counter) Then
                            budjet(0, counter) = List(1)
                            budjet(1, counter) = List(2)
                            budjet(2, counter) = List(3)
                            budjet(3, counter) = List(4)
                            budjet(4, counter) = List(5)
                        End If
                    Next
                ElseIf counter2 = 1 Then
                    For Each ListVB As List(Of String) In listDataVB
                        If ListVB(0) = часы(1, counter) Then
                            vBudjet(0, counter) = ListVB(1)
                            vBudjet(1, counter) = ListVB(2)
                            vBudjet(2, counter) = ListVB(3)
                            vBudjet(3, counter) = ListVB(4)
                            vBudjet(4, counter) = ListVB(5)
                        End If
                    Next
                Else
                    For Each List As List(Of String) In listData
                        If List(0) = часы(1, counter) Then
                            result(0, counter) = List(1)
                            result(1, counter) = List(2)
                            result(2, counter) = List(3)
                            result(3, counter) = List(4)
                            result(4, counter) = List(5)
                        End If
                    Next
                End If

                counter = counter + 1
            End While

            counter2 = counter2 + 1

        End While

        counter2 = 0
        counter4 = UBound(budjet, 1)
        While counter2 <= UBound(budjet, 1)
            summResult = 0
            summVB = 0
            summB = 0
            counter = 0
            While counter <= UBound(budjet, 2)
                counter3 = UBound(budjet, 2)
                If counter = UBound(budjet, 2) Then
                    vBudjet(counter2, counter) = Convert.ToString(summVB)
                    budjet(counter2, counter) = Convert.ToString(summB)
                    result(counter2, counter) = Convert.ToString(summResult)
                Else
                    If Strings.Trim(vBudjet(counter2, counter)) = "" Then
                        vBudjet(counter2, counter) = 0
                    End If
                    If Strings.Trim(budjet(counter2, counter)) = "" Then
                        budjet(counter2, counter) = 0
                    End If
                    If Strings.Trim(result(counter2, counter)) = "" Then
                        result(counter2, counter) = 0
                    End If
                    summVB = summVB + Convert.ToDouble(vBudjet(counter2, counter))
                    summB = summB + Convert.ToDouble(budjet(counter2, counter))
                    summResult = summResult + Convert.ToDouble(result(counter2, counter))
                End If

                counter = counter + 1

            End While

            counter2 = counter2 + 1
        End While

        WSOR.Range("B3").Resize(5, UBound(budjet, 2) + 1) = budjet

        WSOR.Range("B13").Resize(5, UBound(budjet, 2) + 1) = vBudjet

        WSOR.Range("B23").Resize(5, UBound(budjet, 2) + 1) = result

        WSOR.Activate
    End Sub

    Sub counterStudentsGroup(numberGroup As String)

        Dim counterRows As Integer, counter As Integer
        counterStudents = 0
        counterRows = 0
        counter = 0

        While counterRows <= UBound(array, 2)

            If numberGroup = array(1, counterRows) Then

                counter = counter + 1

                If array(18, counterRows) = "Федеральный бюджет" Then

                    counterBudj = counterBudj + 1

                End If



            End If

            counterRows = counterRows + 1
        End While

        counterStudents = counter
    End Sub

End Module
