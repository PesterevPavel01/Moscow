Module Приказ_ДопускКИА

    Sub Приказ_ДопускКИА(ВидПриказа As String)
        Dim wordApp
        Dim wordDoc, studentsData, rangeObj, table
        Dim resourcesPath, ПутьКШаблону
        Dim sqlQuery, ppOrStaj, ppOrStaj2 As String
        Dim tens, units As Integer

        sqlQuery = dopusk_loadListStudents(MainForm.prikazKodGroup)
        studentsData = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

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

        Вспомогательный.savePrikazBlank(wordDoc, MainForm.prikazKodGroup, ВидПриказа, resourcesPath, "Приказы")

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", АСформироватьПриказ.ДатаПриказа.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ПП/Стаж$", ppOrStaj, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ПредседательИО$", АСформироватьПриказ.Ответственный.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ПредседательДолжность$", АСформироватьПриказ.ОтветственныйДолжность.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ЗПредседательИО$", АСформироватьПриказ.ЗамПредседателя.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ЗПредседательДолжность$", АСформироватьПриказ.ЗамПредседателяДолжность.Text, 2)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Комиссия1ИО$", АСформироватьПриказ.РуководительСтажировки.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Комиссия1Должность$", АСформироватьПриказ.РуководительСтажировкиДолжность.Text, 2)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Комиссия2ИО$", АСформироватьПриказ.Комиссия2.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Комиссия2Должность$", АСформироватьПриказ.Комиссия2Должность.Text, 2)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Комиссия3ИО$", АСформироватьПриказ.Комиссия3.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Комиссия3Должность$", АСформироватьПриказ.Комиссия3Должность.Text, 2)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$СКомиссииИО$", АСформироватьПриказ.СекретарьКомиссии.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$СКомиссииДолжность$", АСформироватьПриказ.СекретарьКомиссииДолжность.Text, 2)

        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$", True, "$ТаблицаСекретарь$")

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", АСформироватьПриказ.УтверждаетДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", АСформироватьПриказ.Утверждает.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ТаблицаСекретарь$", "Секретарь комиссии:")


        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", АСформироватьПриказ.ПроектВноситДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(АСформироватьПриказ.ПроектВносит.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", АСформироватьПриказ.ИсполнительДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(АСформироватьПриказ.Исполнитель.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", АСформироватьПриказ.Согласовано1Должность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(АСформироватьПриказ.Согласовано1.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", АСформироватьПриказ.Согласовано2Должность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(АСформироватьПриказ.Согласовано2.Text))

        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

        rangeObj = wordDoc.Bookmarks("\EndOfDoc").Range

        СкопироватьДокументИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & "_Протокол.docx", 1)

        rangeObj.SetRange(Start:=rangeObj.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)

        Dim DATEq As Date = АСформироватьПриказ.ДатаПриказа.Text

        Вспомогательный.replaceTextInWordApp(rangeObj, "$НомерПротокола$", studentsData(8, 0))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$Программа$", studentsData(1, 0))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$День$", Convert.ToDateTime(studentsData(3, 0)).Day)
        Вспомогательный.replaceTextInWordApp(rangeObj, "$Месяц$", месяцРП(Format(Convert.ToDateTime(studentsData(3, 0)), "MMMM")), 2)
        Вспомогательный.replaceTextInWordApp(rangeObj, "$Год$", Convert.ToDateTime(studentsData(3, 0)).Year)
        Вспомогательный.replaceTextInWordApp(rangeObj, "$ДатаН$", studentsData(2, 0), 2)
        Вспомогательный.replaceTextInWordApp(rangeObj, "$ДатаК$", studentsData(3, 0), 2)

        Вспомогательный.replaceTextInWordApp(rangeObj, "$ИОПредседатель$", rotate(АСформироватьПриказ.Ответственный.Text))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$ПредседательДолжность$", АСформироватьПриказ.ОтветственныйДолжность.Text)
        Вспомогательный.replaceTextInWordApp(rangeObj, "$ИОЗПредседатель$", rotate(АСформироватьПриказ.ЗамПредседателя.Text))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$ЗПредседательДолжность$", АСформироватьПриказ.ЗамПредседателяДолжность.Text)

        Вспомогательный.replaceTextInWordApp(rangeObj, "$ИОКомиссия1$", rotate(АСформироватьПриказ.РуководительСтажировки.Text))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$Комиссия1Должность$", АСформироватьПриказ.РуководительСтажировкиДолжность.Text, 2)

        Вспомогательный.replaceTextInWordApp(rangeObj, "$ИОКомиссия2$", rotate(АСформироватьПриказ.Комиссия2.Text))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$Комиссия2Должность$", АСформироватьПриказ.Комиссия2Должность.Text, 2)

        Вспомогательный.replaceTextInWordApp(rangeObj, "$ИОКомиссия3$", rotate(АСформироватьПриказ.Комиссия3.Text))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$Комиссия3Должность$", АСформироватьПриказ.Комиссия3Должность.Text, 2)

        Вспомогательный.replaceTextInWordApp(rangeObj, "$ИОСКомиссии$", rotate(АСформироватьПриказ.СекретарьКомиссии.Text))
        Вспомогательный.replaceTextInWordApp(rangeObj, "$СКомиссииДолжность$", АСформироватьПриказ.СекретарьКомиссииДолжность.Text, 2)

        Вспомогательный.replaceTextInWordApp(rangeObj, "$Часы$", studentsData(4, 0), 2)
        Вспомогательный.replaceTextInWordApp(rangeObj, "$ПП/Стаж2$", ppOrStaj2, 2)

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

        Вспомогательный.replaceTextInWordApp(Область, "$Программа$", ДанныеСлушателей(1, 0))
        Вспомогательный.replaceTextInWordApp(Область, "$День$", Format(АСформироватьПриказ.ДатаПриказа.Value, "dd"), 2)
        Вспомогательный.replaceTextInWordApp(Область, "$Месяц$", месяцРП(Format(АСформироватьПриказ.ДатаПриказа.Value, "MMMM")), 2)
        Вспомогательный.replaceTextInWordApp(Область, "$Год$", Format(АСформироватьПриказ.ДатаПриказа.Value, "yyyy"), 2)
        Вспомогательный.replaceTextInWordApp(Область, "$ДатаН$", ДанныеСлушателей(2, 0), 2)

        Вспомогательный.replaceTextInWordApp(Область, "$ИОПредседатель$", rotate(АСформироватьПриказ.Ответственный.Text))
        Вспомогательный.replaceTextInWordApp(Область, "$ПредседательДолжность$", АСформироватьПриказ.ОтветственныйДолжность.Text)

        Вспомогательный.replaceTextInWordApp(Область, "$ИОЗПредседатель$", rotate(АСформироватьПриказ.ЗамПредседателя.Text))
        Вспомогательный.replaceTextInWordApp(Область, "$ЗПредседательДолжность$", АСформироватьПриказ.ЗамПредседателяДолжность.Text)

        Вспомогательный.replaceTextInWordApp(Область, "$ИОКомиссия1$", rotate(АСформироватьПриказ.РуководительСтажировки.Text))
        Вспомогательный.replaceTextInWordApp(Область, "$Комиссия1Должность$", АСформироватьПриказ.РуководительСтажировкиДолжность.Text, 2)

        Вспомогательный.replaceTextInWordApp(Область, "$ИОКомиссия2$", rotate(АСформироватьПриказ.Комиссия2.Text))
        Вспомогательный.replaceTextInWordApp(Область, "$Комиссия2Должность$", АСформироватьПриказ.Комиссия2Должность.Text, 2)

        Вспомогательный.replaceTextInWordApp(Область, "$ИОКомиссия3$", rotate(АСформироватьПриказ.Комиссия3.Text))
        Вспомогательный.replaceTextInWordApp(Область, "$Комиссия3Должность$", АСформироватьПриказ.Комиссия3Должность.Text, 2)

        Вспомогательный.replaceTextInWordApp(Область, "$ИОСКомиссии$", rotate(АСформироватьПриказ.СекретарьКомиссии.Text))
        Вспомогательный.replaceTextInWordApp(Область, "$СКомиссииДолжность$", АСформироватьПриказ.СекретарьКомиссииДолжность.Text, 2)

        For Счетчик = 1 To UBound(ДанныеСлушателей, 2)

            ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

            Область2 = ДокументВорд.Bookmarks("\EndOfDoc").Range
            Область.Copy

            ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)

            Область2.SetRange(Start:=Область2.Start,
        End:=ДокументВорд.Bookmarks("\EndOfDoc").Range.End)
            Вспомогательный.replaceTextInWordApp(Область2, "$СлушательИмяОтчество$", ДанныеСлушателей(0, Счетчик))

        Next

        Вспомогательный.replaceTextInWordApp(Область, "$СлушательИмяОтчество$", ДанныеСлушателей(0, 0))

    End Sub


End Module
