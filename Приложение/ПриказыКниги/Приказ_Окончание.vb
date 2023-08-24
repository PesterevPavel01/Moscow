﻿Imports System.Threading

Module Приказ_Окончание
    Dim SC As SynchronizationContext
    Sub Приказ_Окончание(ВидПриказа)

        Dim wordApp, wordDoc
        Dim params, studentList
        Dim rangeObj, number, table, student
        Dim resuorcesPath, ПутьКШаблону
        Dim counterTables As Integer
        Dim queryString As String

        ReDim params(3)
        params(3) = MainForm.mySqlConnect.mySqlSettings

        SC = SynchronizationContext.Current
        Dim ВторойПоток As Thread

        If ВидПриказа = "ПО_Окончание" Then

            queryString = load_poOk_group(MainForm.prikazKodGroup)
            params(0) = "Свидетельство"

        ElseIf ВидПриказа = "ПК_Окончание" Then

            queryString = load_pkOk_group(MainForm.prikazKodGroup)
            params(0) = "Удостоверение"

        ElseIf ВидПриказа = "ПП_Окончание" Then

            queryString = load_ppOk_group(MainForm.prikazKodGroup)
            params(0) = "Диплом"

        End If

        studentList = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If studentList(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        If ВидПриказа = "ПК_Окончание" Then
            If Not studentList(6, 0) = "Удостоверение" Then
                предупреждение.текст.Text = "Основной документ группы " & studentList(6, 0)
                предупреждение.ShowDialog()
                Exit Sub
            End If
        ElseIf ВидПриказа = "ПО_Окончание" Then
            If Not studentList(6, 0) = "Свидетельство" Then
                предупреждение.текст.Text = "Основной документ группы " & studentList(6, 0)
                предупреждение.ShowDialog()
                Exit Sub
            End If
        ElseIf ВидПриказа = "ПП_Окончание" Then
            If Not studentList(6, 0) = "Диплом" Then
                предупреждение.текст.Text = "Основной документ группы " & studentList(6, 0)
                предупреждение.ShowDialog()
                Exit Sub
            End If
        End If

        Try
            number = studentList(4, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Номер удостоверения/свидетельства/диплома группы не задан или не является числом"
            предупреждение.ShowDialog()
            Exit Sub
        End Try

        Try
            number = studentList(5, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Регистрационный номер удостоверения/свидетельства/диплома группы не задан или не является числом"
            предупреждение.ShowDialog()
            Exit Sub
        End Try

        params(1) = studentList
        params(2) = MainForm.prikazKodGroup

        ВторойПоток = New Thread(AddressOf ПрисвоитьНомера)
        ВторойПоток.IsBackground = True
        ВторойПоток.Start(params)

        resuorcesPath = Запуск.ПутьКФайлуRes
        ПутьКШаблону = resuorcesPath & "Шаблоны\ПК_Окончание\" & ВидПриказа & ".docx"

        wordApp = CreateObject("Word.Application")
        'ПриложениеВорд.Visible = True

        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        Вспомогательный.savePrikazBlank(wordDoc, MainForm.prikazKodGroup, ВидПриказа, resuorcesPath, "Приказы")

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentList, wordApp)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", АСформироватьПриказ.ДатаПриказа.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentList(7, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДКонец$", studentList(10, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentList(11, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$КураторГруппы$", studentList(14, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", АСформироватьПриказ.ПроектВносит.Text)

        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", АСформироватьПриказ.УтверждаетДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", АСформироватьПриказ.Утверждает.Text)

        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resuorcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", АСформироватьПриказ.ПроектВноситДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(АСформироватьПриказ.ПроектВносит.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", АСформироватьПриказ.ИсполнительДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(АСформироватьПриказ.Исполнитель.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", АСформироватьПриказ.Согласовано1Должность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(АСформироватьПриказ.Согласовано1.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", АСформироватьПриказ.Согласовано2Должность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(АСформироватьПриказ.Согласовано2.Text))

        If ВидПриказа = "ПК_Окончание" Then

            table = МСВорд.НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc, "$Таблица$", 2, 2)

            Try
                If table(0, 0) = "не найдена" Then
                    предупреждение.текст.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                    предупреждение.ShowDialog()
                    wordApp.Visible = True
                    wordDoc.Save
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            queryString = pkEnd__loadShortListStudents(MainForm.prikazKodGroup)
            student = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            If student(0, 0) = "нет записей" Then
                предупреждение.текст.Text = "Нет данных для отображения"
                предупреждение.ShowDialog()
                wordApp.Visible = True
                wordDoc.Save
                Exit Sub
            End If

            МСВорд.ЗаполнитьТаблицуПКОк(table, student, 2, True)

        Else

            queryString = poPpEnd__loadShortListStudents(MainForm.prikazKodGroup)
            student = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentList, wordApp)

        End If


        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        If Not ВидПриказа = "ПО_Окончание" Then
            wordDoc.Bookmarks("\EndOfDoc").Range.PageSetup.Orientation = 1
        End If

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resuorcesPath & "Шаблоны\ПК_Окончание\" & ВидПриказа & "_Таблица.docx", 1)
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
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$НомерПротоколаИА$", studentList(13, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Квалификация$", studentList(12, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$СлушательИмяОтчество$", studentList(0, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Фамилия$", studentList(1, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ИмяИОтчество$", studentList(2, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ДНачало$", studentList(9, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ДКонец$", studentList(10, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Программа$", studentList(7, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Часы$", studentList(11, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$Номер$", Вспомогательный.addZeros(studentList(5, СчетчикСлушателей) + СчетчикСлушателей, 5))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(counterTables + СчетчикСлушателей).Range, "$ДатаВ$", studentList(8, 0))
        Next

        wordApp.Visible = True
        wordDoc.Save



    End Sub

    Sub ПрисвоитьНомера(params As Object)

        Dim mySqlConnectThr As New MySQLConnect()
        Dim ListSQLString As New List(Of String)

        mySqlConnectThr.mySqlSettings = params(3)

        ListSQLString = pkEnd__insertNumbers(params(1), params(0), Convert.ToString(params(2)))
        mySqlConnectThr.sendListToMySql(ListSQLString, 1)

    End Sub

    Sub ПО_Свидетельство(ВидПриказа)

        Dim ПриложениеВорд, ДокументВорд
        Dim Параметры, ДанныеСлушателей
        Dim Область, Число
        Dim ПутьККаталогуСРесурсами, ПутьКШаблону
        Dim счетчикТаблиц As Integer
        Dim queryString As String

        ReDim Параметры(2)

        Параметры(2) = MainForm.prikazKodGroup


        If ВидПриказа = "ПО_Окончание" Then
            queryString = "SELECT Слушатель.Фамилия+' '+ Слушатель.Имя+' '+IFNULL(слушатель.Отчество,' '),Слушатель.Фамилия,Слушатель.Имя+' '+IFNULL(слушатель.Отчество,' '),Слушатель.Снилс,Группа.НомерСвид, Группа.РегНомерСвид,Группа.ОсновнойДокумент,Программа , ДатаВыдачиУд, ДатаНЗ, ДатаКЗ, КолЧас, Квалификация,НомерПротоколаИА FROM (group_list INNER JOIN Слушатель ON group_list.Слушатель = Слушатель.Снилс) INNER JOIN Группа ON group_list.Kod = Группа.Код WHERE Группа.Код = " & Параметры(2) & " ORDER BY Слушатель.Фамилия"
            Параметры(0) = "Свидетельство"
        End If

        ДанныеСлушателей = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If ДанныеСлушателей(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        If Not ДанныеСлушателей(6, 0) = "Свидетельство" Then
            предупреждение.текст.Text = "Основной документ группы " & ДанныеСлушателей(6, 0)
            предупреждение.ShowDialog()
            Exit Sub
        End If

        Try
            Число = ДанныеСлушателей(4, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Номер удостоверения/свидетельства/диплома группы не задан или не является числом"
            предупреждение.ShowDialog()
            Exit Sub
        End Try

        Try
            Число = ДанныеСлушателей(5, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Регистрационный номер удостоверения/свидетельства/диплома группы не задан или не является числом"
            предупреждение.ShowDialog()
            Exit Sub
        End Try

        ПутьККаталогуСРесурсами = Запуск.ПутьКФайлуRes
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\ПК_Окончание\" & ВидПриказа & ".docx"

        ПриложениеВорд = CreateObject("Word.Application")

        ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        If Вспомогательный.СоздатьПапку(ПутьККаталогуСРесурсами & "Группы\Группа N" & АСформироватьПриказ.НомерГруппы.Text & "_" & Year(ДанныеСлушателей(9, 0)) & "\Приказы") Then
            Вспомогательный.сохранить(ДокументВорд, ВидПриказа, ПутьККаталогуСРесурсами & "Группы\Группа N" & АСформироватьПриказ.НомерГруппы.Text & "_" & Year(ДанныеСлушателей(9, 0)) & "\Приказы\")
        Else
            Вспомогательный.сохранить(ДокументВорд, ВидПриказа, ПутьККаталогуСРесурсами & "Группы\Нераспределенное\")
        End If

        МСВорд.ДобавитьСписокПоМеткеСтрокой(ДокументВорд, "$СписокСлушателей$", ДанныеСлушателей, ПриложениеВорд)

        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ДатаПриказа$", АСформироватьПриказ.ДатаПриказа.Text)
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text)
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$Программа$", ДанныеСлушателей(7, 0), 2)

        ТаблицаУтверждаю(ПриложениеВорд, ДокументВорд, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ТаблицаУтверждаю$", АСформироватьПриказ.УтверждаетДолжность.Text)
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$УтверждаюИО$", АСформироватьПриказ.Утверждает.Text)

        ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        СкопироватьТаблицуИзШаблона(ПриложениеВорд, ДокументВорд, ПутьККаталогуСРесурсами & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ВноситДолжность$", АСформироватьПриказ.ПроектВноситДолжность.Text)
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ИОФамилияВносит$", rotate(АСформироватьПриказ.ПроектВносит.Text))
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ИсполнительДолжность$", АСформироватьПриказ.ИсполнительДолжность.Text)
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ИОФамилияИсполнитель$", rotate(АСформироватьПриказ.Исполнитель.Text))
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$Согласовано1Должность$", АСформироватьПриказ.Согласовано1Должность.Text)
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ИОФамилияСогласовано1$", rotate(АСформироватьПриказ.Согласовано1.Text))
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$Согласовано2Должность$", АСформироватьПриказ.Согласовано2Должность.Text)
        Вспомогательный.replaceTextInWordApp(ДокументВорд.Range, "$ИОФамилияСогласовано2$", rotate(АСформироватьПриказ.Согласовано2.Text))



        ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        If Not ВидПриказа = "ПО_Окончание" Then
            ДокументВорд.Bookmarks("\EndOfDoc").Range.PageSetup.Orientation = 1
        End If

        СкопироватьТаблицуИзШаблона(ПриложениеВорд, ДокументВорд, ПутьККаталогуСРесурсами & "Шаблоны\ПК_Окончание\" & ВидПриказа & "_Таблица.docx", 1)
        ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(2)

        счетчикТаблиц = ДокументВорд.Tables.Count

        Область = ДокументВорд.Tables(счетчикТаблиц).Range
        Область.SetRange(Start:=Область.Start,
        End:=ДокументВорд.Bookmarks("\EndOfDoc").Range.End)


        For СчетчикСлушателей = 1 To UBound(ДанныеСлушателей, 2)
            Область.Copy
            ДокументВорд.Bookmarks("\EndOfDoc").Range.Paste
        Next

        For СчетчикСлушателей = 0 To UBound(ДанныеСлушателей, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$НомерПротоколаИА$", ДанныеСлушателей(13, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$Квалификация$", ДанныеСлушателей(12, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$СлушательИмяОтчество$", ДанныеСлушателей(0, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$Фамилия$", ДанныеСлушателей(1, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$ИмяИОтчество$", ДанныеСлушателей(2, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$ДНачало$", ДанныеСлушателей(9, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$ДКонец$", ДанныеСлушателей(10, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$Программа$", ДанныеСлушателей(7, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$Часы$", ДанныеСлушателей(11, 0))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$Номер$", ДанныеСлушателей(4, СчетчикСлушателей) + СчетчикСлушателей)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Tables(счетчикТаблиц + СчетчикСлушателей).Range, "$ДатаВ$", ДанныеСлушателей(8, 0))
        Next

        ПриложениеВорд.Visible = True
        ДокументВорд.Save

    End Sub

End Module
