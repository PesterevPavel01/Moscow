Imports System.Threading

Module Приказ_Окончание
    Dim SC As SynchronizationContext
    Sub Приказ_Окончание(argument As OrderArgument)

        Dim wordApp, wordDoc
        Dim params, studentList
        Dim rangeObj, number, table, student
        Dim resuorcesPath, samplePath
        Dim counterTables As Integer
        Dim queryString As String = ""

        ReDim params(3)
        params(3) = argument.mySqlConnector.mySqlSettings

        SC = SynchronizationContext.Current
        Dim secondThread As Thread

        If argument.orderType = "ПО_Окончание" Then

            queryString = load_poOk_group(argument.orderIdGroup)
            params(0) = "Свидетельство"

        ElseIf argument.orderType = "ПК_Окончание" Then

            queryString = load_pkOk_group(argument.orderIdGroup)
            params(0) = "Удостоверение"

        ElseIf argument.orderType = "ПП_Окончание" Then

            queryString = load_ppOk_group(argument.orderIdGroup)
            params(0) = "Диплом"

        End If

        studentList = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If studentList(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If argument.orderType = "ПК_Окончание" Then
            If Not studentList(6, 0) = "Удостоверение" Then
                Warning.content.Text = "Основной документ группы " & studentList(6, 0)
                Warning.ShowDialog()
                Exit Sub
            End If
        ElseIf argument.orderType = "ПО_Окончание" Then
            If Not studentList(6, 0) = "Свидетельство" Then
                Warning.content.Text = "Основной документ группы " & studentList(6, 0)
                Warning.ShowDialog()
                Exit Sub
            End If
        ElseIf argument.orderType = "ПП_Окончание" Then
            If Not studentList(6, 0) = "Диплом" Then
                Warning.content.Text = "Основной документ группы " & studentList(6, 0)
                Warning.ShowDialog()
                Exit Sub
            End If
        End If

        Try
            number = studentList(4, 0) + 1
        Catch ex As Exception
            Warning.content.Text = "Номер удостоверения/свидетельства/диплома группы не задан или не является числом"
            Warning.ShowDialog()
            Exit Sub
        End Try

        Try
            number = studentList(5, 0) + 1
        Catch ex As Exception
            Warning.content.Text = "Регистрационный номер удостоверения/свидетельства/диплома группы не задан или не является числом"
            Warning.ShowDialog()
            Exit Sub
        End Try

        params(1) = studentList
        params(2) = argument.orderIdGroup

        secondThread = New Thread(AddressOf createNumbers)
        secondThread.IsBackground = True
        secondThread.Start(params)

        resuorcesPath = startApp.resourcesPath
        samplePath = resuorcesPath & "Шаблоны\ПК_Окончание\" & argument.orderType & ".docx"

        wordApp = CreateObject("Word.Application")
        'ПриложениеВорд.Visible = True

        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)
        _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, argument.orderType, resuorcesPath, "Приказы", argument.mySqlConnector)

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentList, wordApp)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", argument.orderDate.ToShortDateString)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", argument.groupNumber)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentList(7, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДКонец$", studentList(10, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentList(11, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$КураторГруппы$", studentList(14, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", argument.initiator)

        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", argument.approvesPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", argument.approves)

        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resuorcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", argument.approvesPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(argument.initiator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", argument.realisatorPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(argument.realisator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", argument.inspectorFirstPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(argument.inspectorFirst))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", argument.inspectorSecPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(argument.inspectorSec))

        If argument.orderType = "ПК_Окончание" Then

            table = МСВорд.НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc, "$Таблица$", 2, 2)

            Try
                If table(0, 0) = "не найдена" Then
                    Warning.content.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                    Warning.ShowDialog()
                    wordApp.Visible = True
                    wordDoc.Save
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            queryString = pkEnd__loadShortListStudents(argument.orderIdGroup)
            student = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

            If student(0, 0) = "нет записей" Then
                Warning.content.Text = "Нет данных для отображения"
                Warning.ShowDialog()
                wordApp.Visible = True
                wordDoc.Save
                Exit Sub
            End If

            МСВорд.ЗаполнитьТаблицуПКОк(table, student, 2, True)

        Else

            queryString = poPpEnd__loadShortListStudents(argument.orderIdGroup)
            student = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentList, wordApp)

        End If


        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        If Not argument.orderType = "ПО_Окончание" Then
            wordDoc.Bookmarks("\EndOfDoc").Range.PageSetup.Orientation = 1
        End If

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resuorcesPath & "Шаблоны\ПК_Окончание\" & argument.orderType & "_Таблица.docx", 1)
        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        counterTables = wordDoc.Tables.Count

        rangeObj = wordDoc.Tables(counterTables).Range
        rangeObj.SetRange(Start:=rangeObj.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)


        For СчетчикСлушателей = 1 To UBound(studentList, 2)
            rangeObj.Copy
            wordDoc.Bookmarks("\EndOfDoc").Range.Paste
        Next

        For СчетчикСлушателей = 0 To UBound(studentList, 2)
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$НомерПротоколаИА$", studentList(13, 0))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Квалификация$", studentList(12, 0))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$СлушательИмяОтчество$", studentList(0, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Фамилия$", studentList(1, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ИмяИОтчество$", studentList(2, СчетчикСлушателей))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ДНачало$", studentList(9, 0))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ДКонец$", studentList(10, 0))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Программа$", studentList(7, 0))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Часы$", studentList(11, 0))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Номер$", _technical.addZeros(studentList(5, СчетчикСлушателей) + СчетчикСлушателей, 5))
            _technical.replaceText_documentWordRange(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ДатаВ$", studentList(8, 0))
        Next

        wordApp.Visible = True
        wordDoc.Save



    End Sub

    Sub createNumbers(params As Object)

        Dim mySqlConnectThr As New MySQLConnect()
        Dim ListSQLString As New List(Of String)

        mySqlConnectThr.mySqlSettings = params(3)

        ListSQLString = pkEnd__insertNumbers(params(1), params(0), Convert.ToString(params(2)))
        mySqlConnectThr.sendListToMySql(ListSQLString, 1)

    End Sub

End Module
