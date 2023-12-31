﻿Imports System.IO
Imports System.Threading
Imports Microsoft.Office.Interop.Word

Module books
    Dim SC As SynchronizationContext
    Sub run(argument As String)
        Dim wordApp
        Dim wordDoc, endDoc
        Dim excellApp, excellTemplate, excellWorkBook, excellSheet
        Dim listData
        Dim templatePath, newFilePath, resourcesPath, name As String


        If argument = "Удостоверение" Then
            name = "удостоверений"
        End If

        If argument = "Диплом" Then
            name = "дипломов"
        End If

        If argument = "Свидетельство" Then
            name = "свидетельств"
        End If

        listData = loadData(argument, MainForm.ДатаНачалаОтчета.Value.ToShortDateString, MainForm.ДатаКонцаОтчета.Value.ToShortDateString)

        If listData(0, 0).ToString = "нет записей" Then
            Exit Sub
        End If

        listData = addZerosIntoArray(listData, 0, 5)

        resourcesPath = _technical.updateResourcesPath()
        templatePath = resourcesPath & "Шаблоны/Книги учета/Книга учета выданных " & name & ".docx"
        newFilePath = resourcesPath & "Отчеты/КнигиУчета/Книга учёта выданных " & name & ".docx"

        wordApp = CreateObject("Word.Application")
        wordDoc = wordApp.Documents.Open(templatePath, ReadOnly:=True)
        Dim numberPar = wordDoc.Paragraphs.Count
        ВставитьПараграф(wordDoc, 2, "за период с " & MainForm.ДатаНачалаОтчета.Value.ToShortDateString & " по " & MainForm.ДатаКонцаОтчета.Value.ToShortDateString, "Times New Roman", 14, 1, 0, 1, 0, False)
        wordDoc.Paragraphs.Add()
        excellApp = CreateObject("Excel.Application")

        excellApp.DisplayAlerts = False
        excellTemplate = excellApp.Workbooks.Open(resourcesPath & "Шаблоны/Книги учета/Книга учета выданных " & name & ".xlsx", ReadOnly:=True)
        excellWorkBook = excellApp.Workbooks.Add
        excellTemplate.Worksheets(1).copy(before:=excellWorkBook.Worksheets(1))
        excellTemplate.Close
        excellSheet = excellWorkBook.Worksheets(1)

        listData = rotateArray(listData)

        excellSheet.Range("A3").Resize(UBound(listData, 1) + 1, UBound(listData, 2) + 1) = listData

        With excellSheet.Range("A3").Resize(UBound(listData, 1) + 1, UBound(listData, 2) + 1)
            .EntireRow.AutoFit
        End With


        excellSheet.Columns("B:B").Select
        excellApp.Selection.NumberFormat = "0"

        numberPar = wordDoc.Paragraphs.Count

        excellSheet.Range("A1").Resize(UBound(listData, 1) + 1, 12).Copy
        endDoc = wordDoc.Paragraphs(numberPar)
        endDoc.Range.Select
        wordApp.Selection.paste

        _technical.saveBook(wordDoc, "Книга учета " & argument, resourcesPath)

        excellWorkBook.close(SaveChanges:=False)

        'отступ у таблицы
        wordApp.Selection.Tables(1).Rows.SetLeftIndent(LeftIndent:=-42.55, RulerStyle:=0)

        wordApp.Visible = True
        excellApp.Quit

        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excellWorkBook)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excellApp)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excellTemplate)
        Catch ex As Exception

        End Try

        wordDoc.Save
        wordApp.Visible = True

    End Sub

    Function loadData(argument As String, dateStart As String, dateEnd As String) As Object

        Dim listResult
        Dim sqlQuery As String

        If argument = "Удостоверение" Then

            sqlQuery = accountingBook__loadListUd(MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateStart)), MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateEnd)))

        ElseIf argument = "Диплом" Then

            sqlQuery = accountingBook__loadListDip(MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateStart)), MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateEnd)))

        ElseIf argument = "Свидетельство" Then

            sqlQuery = accountingBook__loadListSvid(MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateStart)), MainForm.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(dateEnd)))

        End If

        listResult = arrayMethod.removeEmpty(MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1))

        If listResult(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            loadData = listResult
            Exit Function

        End If
        loadData = listResult
    End Function

    Sub fullOutTable(wordApp As Object, Таблица As Object, Массив As Object, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String)

        Dim СчетчикСтрок As Integer

        Таблица.Cell(2, 1).Range.text = "за период с " & ДатаНачалаОтчета & " по " & ДатаКонцаОтчета

        СчетчикСтрок = UBound(Массив, 2)

        Таблица.Rows(6).Select

        wordApp.Selection.InsertRows(СчетчикСтрок)

        For НомерСтолбца = 1 To Таблица.Columns.Count - 2
            Таблица.Cell(6, НомерСтолбца).Range.text = Массив(НомерСтолбца - 1, 0)
        Next

        For НомерСтроки = 1 To UBound(Массив, 2)
            For НомерСтолбца = 1 To Таблица.Columns.Count - 2
                Таблица.Cell(6 + НомерСтроки, НомерСтолбца).Range.text = Массив(НомерСтолбца - 1, НомерСтроки)
            Next
        Next

        With Таблица.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With
        With Таблица.Rows(1).Borders
            .InsideLineStyle = 0
            .OutsideLineStyle = 0
        End With
        With Таблица.Rows(2).Borders
            .InsideLineStyle = 0
            .OutsideLineStyle = 0
        End With
        With Таблица.Rows(3).Borders
            .InsideLineStyle = 0
            .OutsideLineStyle = 0
        End With
        With Таблица.Rows(4).Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With

    End Sub

End Module
