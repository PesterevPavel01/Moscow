Imports System.Threading

Module ПК_Окончание

    Dim SC As SynchronizationContext

    Sub ПК_Окончание_уд(argument As OrderArgument)

        Dim wordApp
        Dim wordDoc, listStudent
        Dim rangeObj
        Dim resourcesPath, ПутьКШаблону
        Dim cunterTAbles As Integer
        Dim sqlQuery As String
        Dim finishList, parametrs

        ReDim parametrs(3)

        If argument.selectedStudents(0, 0) = "нет записей" Then
            Warning.content.Text = "Укажите галочками слушателей без удостоверения"
            Warning.ShowDialog()
            Exit Sub
        End If

        SC = SynchronizationContext.Current
        Dim ВторойПоток As Thread

        sqlQuery = pkEndUd__loadListStudents(argument.orderIdGroup)

        listStudent = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If listStudent(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If Not listStudent(6, 0) = "Удостоверение" Then
            Warning.content.Text = "Основной документ группы " & listStudent(6, 0)
            Warning.ShowDialog()
            Exit Sub
        End If

        finishList = _technical.УбратьНенужныеСтрокиИзМассива(listStudent, argument.selectedStudents)

        parametrs(0) = finishList
        parametrs(1) = argument.orderIdGroup
        parametrs(3) = argument.mySqlConnector

        ВторойПоток = New Thread(AddressOf createNumbers)
        ВторойПоток.IsBackground = True
        ВторойПоток.Start(parametrs)

        resourcesPath = startApp.resourcesPath
        ПутьКШаблону = resourcesPath & "Шаблоны\ПК_Окончание\ПК_Окончание_уд.docx"

        wordApp = CreateObject("Word.Application")


        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, argument.orderType, resourcesPath, "Приказы", argument.mySqlConnector)

        If argument.orderType = "ПК_Зачисление" Then
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", argument.selectedStudents, wordApp)
        Else
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", finishList, wordApp)
        End If

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", argument.orderDate.ToShortDateString)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", argument.groupNumber)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", finishList(7, 0), 2)


        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", argument.approvesPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", argument.approves)

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", argument.initiatorPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(argument.initiator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", argument.realisatorPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(argument.realisator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", argument.inspectorFirstPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(argument.inspectorFirst))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", argument.inspectorSecPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(argument.inspectorSec))



        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        wordDoc.Bookmarks("\EndOfDoc").Range.PageSetup.Orientation = 1

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ПК_Окончание_ТаблицаУдостоверение.docx", 1)
        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        cunterTAbles = wordDoc.Tables.Count

        rangeObj = wordDoc.Tables(cunterTAbles).Range
        rangeObj.SetRange(Start:=rangeObj.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)


        For СчетчикСлушателей = 1 To UBound(finishList, 2)
            rangeObj.Copy
            wordDoc.Bookmarks("\EndOfDoc").Range.Paste
        Next

        For СчетчикСлушателей = 0 To UBound(finishList, 2)
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Фамилия$", finishList(1, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ИмяИОтчество$", finishList(2, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДНачало$", finishList(9, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДКонец$", finishList(10, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Программа$", finishList(8, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Часы$", finishList(11, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Номер$", finishList(4, СчетчикСлушателей) + СчетчикСлушателей)
            _technical.replaceText_documentWordRange(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДатаВ$", argument.orderDate.ToShortDateString)
        Next

        wordApp.Visible = True
        wordDoc.Save



    End Sub

    Sub createNumbers(parametrs As Object)
        Dim querysList As New List(Of String), group
        Dim counter As Integer, Число
        Dim queryString As String
        Dim kodGroup As Integer
        Dim mySqlConnector As MySQLConnect

        group = parametrs(0)
        kodGroup = parametrs(1)
        mySqlConnector = parametrs(2)

        counter = 0

        If Not IsNumeric(group(4, 0)) Then
            Warning.content.Text = "Номер удостоверения группы не задан или не является числом"
            Warning.ShowDialog()
            Return
        End If

        If Not IsNumeric(group(5, 0)) Then
            Warning.content.Text = "Регистрационный номер удостоверения группы не задан или не является числом"
            Warning.ShowDialog()
            Return
        End If

        While counter <= UBound(group, 2)
            Число = UBound(group, 2)
            queryString = updateNumbersInGroup(group(4, 0) + counter, group(5, 0) + counter, kodGroup, group(1, counter))
            querysList.Add(queryString)
            counter = counter + 1
        End While


        If querysList.Count > 0 Then mySqlConnector.sendListToMySql(querysList, 1)

    End Sub

End Module
