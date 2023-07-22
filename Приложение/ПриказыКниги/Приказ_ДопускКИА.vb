﻿Module Приказ_ДопускКИА

    Sub Приказ_ДопускКИА(ВидПриказа As String)
        Dim wordApp
        Dim wordDoc, studentsData, rangeObj, table
        Dim resourcesPath, ПутьКШаблону
        Dim queryString, ppOrStaj, ppOrStaj2 As String
        Dim tens, units As Integer

        queryString = dopusk_loadListStudents(ААОсновная.prikazKodGroup)
        studentsData = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        If studentsData(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        If АСформироватьПриказ.CheckBoxММС.Checked Then

            ppOrStaj = "практическая подготовка"
            ppOrStaj2 = "практической подготовки"
        Else

            ppOrStaj = "стажировка"
            ppOrStaj2 = "стажировки"

        End If



        resourcesPath = Запуск.ПутьКФайлуRes
        ПутьКШаблону = resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & ".docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        Вспомогательный.savePrikazBlank(wordDoc, ААОсновная.prikazKodGroup, ВидПриказа, resourcesPath, "Приказы")

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ДатаПриказа$", АСформироватьПриказ.ДатаПриказа.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ПП/Стаж$", ppOrStaj, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ПредседательИО$", АСформироватьПриказ.Ответственный.Text, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ПредседательДолжность$", АСформироватьПриказ.ОтветственныйДолжность.Text, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ЗПредседательИО$", АСформироватьПриказ.ЗамПредседателя.Text, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ЗПредседательДолжность$", АСформироватьПриказ.ЗамПредседателяДолжность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Комиссия1ИО$", АСформироватьПриказ.РуководительСтажировки.Text, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Комиссия1Должность$", АСформироватьПриказ.РуководительСтажировкиДолжность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Комиссия2ИО$", АСформироватьПриказ.Комиссия2.Text, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Комиссия2Должность$", АСформироватьПриказ.Комиссия2Должность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Комиссия3ИО$", АСформироватьПриказ.Комиссия3.Text, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Комиссия3Должность$", АСформироватьПриказ.Комиссия3Должность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$СКомиссииИО$", АСформироватьПриказ.СекретарьКомиссии.Text, 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$СКомиссииДолжность$", АСформироватьПриказ.СекретарьКомиссииДолжность.Text, 2)

        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$", True, "$ТаблицаСекретарь$")

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ТаблицаУтверждаю$", АСформироватьПриказ.УтверждаетДолжность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$УтверждаюИО$", АСформироватьПриказ.Утверждает.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ТаблицаСекретарь$", "Секретарь комиссии:")


        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ВноситДолжность$", АСформироватьПриказ.ПроектВноситДолжность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияВносит$", перевернуть(АСформироватьПриказ.ПроектВносит.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИсполнительДолжность$", АСформироватьПриказ.ИсполнительДолжность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияИсполнитель$", перевернуть(АСформироватьПриказ.Исполнитель.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Согласовано1Должность$", АСформироватьПриказ.Согласовано1Должность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияСогласовано1$", перевернуть(АСформироватьПриказ.Согласовано1.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$Согласовано2Должность$", АСформироватьПриказ.Согласовано2Должность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(wordDoc.Range, "$ИОФамилияСогласовано2$", перевернуть(АСформироватьПриказ.Согласовано2.Text))

        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

        rangeObj = wordDoc.Bookmarks("\EndOfDoc").Range

        СкопироватьДокументИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & "_Протокол.docx", 1)

        rangeObj.SetRange(Start:=rangeObj.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)

        Dim DATEq As Date = АСформироватьПриказ.ДатаПриказа.Text

        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$НомерПротокола$", studentsData(8, 0))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$Программа$", studentsData(1, 0))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$День$", Convert.ToDateTime(studentsData(3, 0)).Day)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$Месяц$", месяцРП(Format(Convert.ToDateTime(studentsData(3, 0)), "MMMM")), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$Год$", Convert.ToDateTime(studentsData(3, 0)).Year)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ДатаН$", studentsData(2, 0), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ДатаК$", studentsData(3, 0), 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ИОПредседатель$", перевернуть(АСформироватьПриказ.Ответственный.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ПредседательДолжность$", АСформироватьПриказ.ОтветственныйДолжность.Text)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ИОЗПредседатель$", перевернуть(АСформироватьПриказ.ЗамПредседателя.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ЗПредседательДолжность$", АСформироватьПриказ.ЗамПредседателяДолжность.Text)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ИОКомиссия1$", перевернуть(АСформироватьПриказ.РуководительСтажировки.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$Комиссия1Должность$", АСформироватьПриказ.РуководительСтажировкиДолжность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ИОКомиссия2$", перевернуть(АСформироватьПриказ.Комиссия2.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$Комиссия2Должность$", АСформироватьПриказ.Комиссия2Должность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ИОКомиссия3$", перевернуть(АСформироватьПриказ.Комиссия3.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$Комиссия3Должность$", АСформироватьПриказ.Комиссия3Должность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ИОСКомиссии$", перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$СКомиссииДолжность$", АСформироватьПриказ.СекретарьКомиссииДолжность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$Часы$", studentsData(4, 0), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(rangeObj, "$ПП/Стаж2$", ppOrStaj2, 2)

        table = НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc, "$СписокСлушателей$", 2, 3)

        units = (UBound(studentsData, 2) + 1) Mod 10
        tens = (UBound(studentsData, 2) + 1) \ 10

        For счетчик = 1 To tens
            For ячейка = 1 To table.Columns.Count
                table.Cell(3, ячейка).Split(NumRows:=10, NumColumns:=1)
            Next
        Next

        For счетчик = 1 To units - 1
            table.Rows.Add
        Next

        For Счетчик = 0 To UBound(studentsData, 2)
            table.Cell(Счетчик + 3, 2).Range.Text = studentsData(0, Счетчик)
            table.Cell(Счетчик + 3, 1).Range.Text = Счетчик + 1 & "."
            table.Cell(Счетчик + 3, 3).Range.Text = studentsData(5, Счетчик)
            table.Cell(Счетчик + 3, 4).Range.Text = studentsData(6, Счетчик)
            table.Cell(Счетчик + 3, 5).Range.Text = studentsData(7, Счетчик)
        Next

        If ВидПриказа = "ПО_ДопускКИА" Then
            ПО_ДопускКИАпродолжение(wordApp, wordDoc, studentsData, ВидПриказа)
        End If

        wordApp.Visible = True
        wordDoc.Save

    End Sub

    Sub ПО_ДопускКИАпродолжение(ПриложениеВорд As Object, ДокументВорд As Object, ДанныеСлушателей As Object, ВидПриказа As String)
        Dim НомерАбзаца As Integer
        Dim Область, Область2
        'ПриложениеВорд.Visible = True
        НомерАбзаца = ДокументВорд.Paragraphs.Count
        ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete
        ДокументВорд.Paragraphs(НомерАбзаца - 1).Range.Delete
        ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)
        Область = ДокументВорд.Bookmarks("\EndOfDoc").Range

        СкопироватьДокументИзШаблона(ПриложениеВорд, ДокументВорд, resourcesPath() & "Шаблоны\Приказы\" & ВидПриказа & "_Протокол_Слушатель.docx", 1)

        Область.SetRange(Start:=Область.Start,
        End:=ДокументВорд.Bookmarks("\EndOfDoc").Range.End)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$Программа$", ДанныеСлушателей(1, 0))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$День$", Format(АСформироватьПриказ.ДатаПриказа.Value, "dd"), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$Месяц$", месяцРП(Format(АСформироватьПриказ.ДатаПриказа.Value, "MMMM")), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$Год$", Format(АСформироватьПриказ.ДатаПриказа.Value, "yyyy"), 2)
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ДатаН$", ДанныеСлушателей(2, 0), 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ИОПредседатель$", перевернуть(АСформироватьПриказ.Ответственный.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ПредседательДолжность$", АСформироватьПриказ.ОтветственныйДолжность.Text)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ИОЗПредседатель$", перевернуть(АСформироватьПриказ.ЗамПредседателя.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ЗПредседательДолжность$", АСформироватьПриказ.ЗамПредседателяДолжность.Text)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ИОКомиссия1$", перевернуть(АСформироватьПриказ.РуководительСтажировки.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$Комиссия1Должность$", АСформироватьПриказ.РуководительСтажировкиДолжность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ИОКомиссия2$", перевернуть(АСформироватьПриказ.Комиссия2.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$Комиссия2Должность$", АСформироватьПриказ.Комиссия2Должность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ИОКомиссия3$", перевернуть(АСформироватьПриказ.Комиссия3.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$Комиссия3Должность$", АСформироватьПриказ.Комиссия3Должность.Text, 2)

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$ИОСКомиссии$", перевернуть(АСформироватьПриказ.СекретарьКомиссии.Text))
        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$СКомиссииДолжность$", АСформироватьПриказ.СекретарьКомиссииДолжность.Text, 2)

        For Счетчик = 1 To UBound(ДанныеСлушателей, 2)

            ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

            Область2 = ДокументВорд.Bookmarks("\EndOfDoc").Range
            Область.Copy

            ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)

            Область2.SetRange(Start:=Область2.Start,
        End:=ДокументВорд.Bookmarks("\EndOfDoc").Range.End)
            Вспомогательный.ЗаменитьТекстВДокументеВорд(Область2, "$СлушательИмяОтчество$", ДанныеСлушателей(0, Счетчик))

        Next

        Вспомогательный.ЗаменитьТекстВДокументеВорд(Область, "$СлушательИмяОтчество$", ДанныеСлушателей(0, 0))

    End Sub


End Module
