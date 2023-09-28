Module ВедомостьСлушИОрг

    Sub orderStudentsAndOrg()

        Dim wordApp
        Dim documentWord, studentsData, table
        Dim resourcesPath, samplePath
        Dim sqlQuery, orderType As String


        sqlQuery = load_studentsAndOrg(MainForm.orderIdGroup)
        studentsData = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        resourcesPath = _technical.resourcesPath()
        samplePath = resourcesPath & "Шаблоны\Ведомость слушаетели и организации.docx"

        wordApp = CreateObject("Word.Application")


        documentWord = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(documentWord, MainForm.orderIdGroup, "ВедомостьСлушателиИОрганизации", resourcesPath, "Ведомости")

        _technical.replaceText_documentWordRange(documentWord.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)

        table = documentWord.Tables(1)
        buildTable(table, studentsData)
        documentWord.Save
        wordApp.visible = True


    End Sub

    Sub buildTable(table As Object, data As Object)
        Dim d
        For rowNumber = 0 To UBound(data, 2)
            If Not rowNumber = 0 Then
                table.Rows.add
            End If
            d = table.Columns.Count

            table.Cell(rowNumber + 2, 1).Range.text = rowNumber + 1 & "."
            table.Cell(rowNumber + 2, 2).Range.text = data(0, rowNumber)
            table.Cell(rowNumber + 2, 3).Range.text = data(1, rowNumber)
            table.Cell(rowNumber + 2, 4).Range.text = data(2, rowNumber)
        Next

        With table.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With
    End Sub

End Module
