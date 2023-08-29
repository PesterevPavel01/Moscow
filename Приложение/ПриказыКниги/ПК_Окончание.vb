Imports System.Threading

Module ПК_Окончание

    Dim SC As SynchronizationContext

    Sub ПК_Окончание_уд(ЧекнутыеСлушатели As Object, ВидПриказа As Object)

        Dim wordApp
        Dim wordDoc, listStudent
        Dim rangeObj
        Dim resourcesPath, ПутьКШаблону
        Dim cunterTAbles As Integer
        Dim sqlQuery As String
        Dim finishList, parametrs

        ReDim parametrs(2)

        If ЧекнутыеСлушатели(0, 0) = "нет записей" Then
            Warning.content.Text = "Укажите галочками слушателей без удостоверения"
            Warning.ShowDialog()
            Exit Sub
        End If

        SC = SynchronizationContext.Current
        Dim ВторойПоток As Thread

        sqlQuery = pkEndUd__loadListStudents(MainForm.orderIdGroup)

        listStudent = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

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

        finishList = _technical.УбратьНенужныеСтрокиИзМассива(listStudent, ЧекнутыеСлушатели)

        parametrs(0) = finishList
        parametrs(1) = MainForm.orderIdGroup

        ВторойПоток = New Thread(AddressOf ПрисвоитьНомера)
        ВторойПоток.IsBackground = True
        ВторойПоток.Start(parametrs)

        resourcesPath = startApp.ПутьКФайлуRes
        ПутьКШаблону = resourcesPath & "Шаблоны\ПК_Окончание\ПК_Окончание_уд.docx"

        wordApp = CreateObject("Word.Application")


        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, MainForm.orderIdGroup, ВидПриказа, resourcesPath, "Приказы")

        If ВидПриказа = "ПК_Зачисление" Then
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", ЧекнутыеСлушатели, wordApp)
        Else
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", finishList, wordApp)
        End If

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", BuildOrder.ДатаПриказа.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", finishList(7, 0), 2)


        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", BuildOrder.УтверждаетДолжность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", BuildOrder.Утверждает.Text)

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", BuildOrder.ПроектВноситДолжность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(BuildOrder.ПроектВносит.Text))
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", BuildOrder.ИсполнительДолжность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(BuildOrder.Исполнитель.Text))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", BuildOrder.Согласовано1Должность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(BuildOrder.Согласовано1.Text))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", BuildOrder.Согласовано2Должность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(BuildOrder.Согласовано2.Text))



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
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Фамилия$", finishList(1, СчетчикСлушателей))
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ИмяИОтчество$", finishList(2, СчетчикСлушателей))
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДНачало$", finishList(9, СчетчикСлушателей))
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДКонец$", finishList(10, СчетчикСлушателей))
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Программа$", finishList(8, СчетчикСлушателей))
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Часы$", finishList(11, СчетчикСлушателей))
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Номер$", finishList(4, СчетчикСлушателей) + СчетчикСлушателей)
            _technical.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДатаВ$", BuildOrder.ДатаПриказа.Value.ToShortDateString)
        Next

        wordApp.Visible = True
        wordDoc.Save



    End Sub

    Sub ПрисвоитьНомера(parametrs As Object)
        Dim массивЗапросов, Группа
        Dim Счетчик As Integer, Число
        Dim строкаЗапроса As String
        Dim kodGroup As Integer

        Группа = parametrs(0)
        kodGroup = parametrs(1)

        ReDim массивЗапросов(UBound(Группа, 2))
        Счетчик = 0
        Try
            Число = Группа(4, 0) + 1
        Catch ex As Exception
            Warning.content.Text = "Номер удостоверения группы не задан или не является числом"
            Warning.ShowDialog()

        End Try

        Try
            Число = Группа(5, 0) + 1
        Catch ex As Exception
            Warning.content.Text = "Регистрационный номер удостоверения группы не задан или не является числом"
            Warning.ShowDialog()

        End Try

        While Счетчик <= UBound(Группа, 2)
            Число = UBound(Группа, 2)
            строкаЗапроса = updateNumbersInGroup(Группа(4, 0) + Счетчик, Группа(5, 0) + Счетчик, kodGroup, Группа(1, Счетчик))
            InsertIntoDataBase.checkAndSendToDB(строкаЗапроса)
            массивЗапросов(Счетчик) = строкаЗапроса
            Счетчик = Счетчик + 1
        End While

    End Sub

End Module
