Imports System.Threading

Module ПК_Окончание

    Dim SC As SynchronizationContext

    Sub ПК_Окончание_уд(ЧекнутыеСлушатели As Object, ВидПриказа As Object)

        Dim wordApp
        Dim wordDoc, listStudent
        Dim rangeObj
        Dim resourcesPath, ПутьКШаблону
        Dim cunterTAbles As Integer
        Dim queryString As String
        Dim finishList, parametrs

        ReDim parametrs(2)

        If ЧекнутыеСлушатели(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Укажите галочками слушателей без удостоверения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        SC = SynchronizationContext.Current
        Dim ВторойПоток As Thread

        queryString = pkEndUd__loadListStudents(ААОсновная.prikazKodGroup)

        listStudent = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        If listStudent(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        If Not listStudent(6, 0) = "Удостоверение" Then
            предупреждение.текст.Text = "Основной документ группы " & listStudent(6, 0)
            предупреждение.ShowDialog()
            Exit Sub
        End If

        finishList = Вспомогательный.УбратьНенужныеСтрокиИзМассива(listStudent, ЧекнутыеСлушатели)

        parametrs(0) = finishList
        parametrs(1) = ААОсновная.prikazKodGroup

        ВторойПоток = New Thread(AddressOf ПрисвоитьНомера)
        ВторойПоток.IsBackground = True
        ВторойПоток.Start(parametrs)

        resourcesPath = Запуск.ПутьКФайлуRes
        ПутьКШаблону = resourcesPath & "Шаблоны\ПК_Окончание\ПК_Окончание_уд.docx"

        wordApp = CreateObject("Word.Application")


        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        Вспомогательный.savePrikazBlank(wordDoc, ААОсновная.prikazKodGroup, ВидПриказа, resourcesPath, "Приказы")

        If ВидПриказа = "ПК_Зачисление" Then
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", ЧекнутыеСлушатели, wordApp)
        Else
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", finishList, wordApp)
        End If

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ДатаПриказа$", АСформироватьПриказ.ДатаПриказа.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Программа$", finishList(7, 0), 2)


        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ТаблицаУтверждаю$", АСформироватьПриказ.УтверждаетДолжность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$УтверждаюИО$", АСформироватьПриказ.Утверждает.Text)

        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ВноситДолжность$", АСформироватьПриказ.ПроектВноситДолжность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияВносит$", перевернуть(АСформироватьПриказ.ПроектВносит.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИсполнительДолжность$", АСформироватьПриказ.ИсполнительДолжность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияИсполнитель$", перевернуть(АСформироватьПриказ.Исполнитель.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Согласовано1Должность$", АСформироватьПриказ.Согласовано1Должность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияСогласовано1$", перевернуть(АСформироватьПриказ.Согласовано1.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Согласовано2Должность$", АСформироватьПриказ.Согласовано2Должность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияСогласовано2$", перевернуть(АСформироватьПриказ.Согласовано2.Text))



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
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Фамилия$", finishList(1, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ИмяИОтчество$", finishList(2, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДНачало$", finishList(9, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДКонец$", finishList(10, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Программа$", finishList(8, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Часы$", finishList(11, СчетчикСлушателей))
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$Номер$", finishList(4, СчетчикСлушателей) + СчетчикСлушателей)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Tables(cunterTAbles + СчетчикСлушателей).Range, "$ДатаВ$", АСформироватьПриказ.ДатаПриказа.Value.ToShortDateString)
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
            предупреждение.текст.Text = "Номер удостоверения группы не задан или не является числом"
            предупреждение.ShowDialog()

        End Try

        Try
            Число = Группа(5, 0) + 1
        Catch ex As Exception
            предупреждение.текст.Text = "Регистрационный номер удостоверения группы не задан или не является числом"
            предупреждение.ShowDialog()

        End Try

        While Счетчик <= UBound(Группа, 2)
            Число = UBound(Группа, 2)
            строкаЗапроса = updateNumbersInGroup(Группа(4, 0) + Счетчик, Группа(5, 0) + Счетчик, kodGroup, Группа(1, Счетчик))
            ЗаписьВБазу.ЗаписьВБазу(строкаЗапроса)
            массивЗапросов(Счетчик) = строкаЗапроса
            Счетчик = Счетчик + 1
        End While

    End Sub

End Module
