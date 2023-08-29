Module Приказ_ДопускКИА

    Sub Приказ_ДопускКИА(ВидПриказа As String)
        Dim wordApp
        Dim wordDoc, studentsData, rangeObj, table
        Dim resourcesPath, ПутьКШаблону
        Dim sqlQuery, ppOrStaj, ppOrStaj2 As String
        Dim tens, units As Integer

        sqlQuery = dopusk_loadListStudents(MainForm.orderIdGroup)
        studentsData = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If BuildOrder.CheckBoxММС.Checked Then

            ppOrStaj = "практическая подготовка"
            ppOrStaj2 = "практической подготовки"
        Else

            ppOrStaj = "стажировка"
            ppOrStaj2 = "стажировки"

        End If



        resourcesPath = startApp.ПутьКФайлуRes
        ПутьКШаблону = resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & ".docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, MainForm.orderIdGroup, ВидПриказа, resourcesPath, "Приказы")

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", BuildOrder.ДатаПриказа.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ПП/Стаж$", ppOrStaj, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ПредседательИО$", BuildOrder.Ответственный.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ПредседательДолжность$", BuildOrder.ОтветственныйДолжность.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ЗПредседательИО$", BuildOrder.ЗамПредседателя.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ЗПредседательДолжность$", BuildOrder.ЗамПредседателяДолжность.Text, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия1ИО$", BuildOrder.РуководительСтажировки.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия1Должность$", BuildOrder.РуководительСтажировкиДолжность.Text, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия2ИО$", BuildOrder.Комиссия2.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия2Должность$", BuildOrder.Комиссия2Должность.Text, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия3ИО$", BuildOrder.Комиссия3.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия3Должность$", BuildOrder.Комиссия3Должность.Text, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$СКомиссииИО$", BuildOrder.СекретарьКомиссии.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$СКомиссииДолжность$", BuildOrder.СекретарьКомиссииДолжность.Text, 2)

        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$", True, "$ТаблицаСекретарь$")

        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", BuildOrder.УтверждаетДолжность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", BuildOrder.Утверждает.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаСекретарь$", "Секретарь комиссии:")


        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", BuildOrder.ПроектВноситДолжность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(BuildOrder.ПроектВносит.Text))
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", BuildOrder.ИсполнительДолжность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(BuildOrder.Исполнитель.Text))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", BuildOrder.Согласовано1Должность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(BuildOrder.Согласовано1.Text))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", BuildOrder.Согласовано2Должность.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(BuildOrder.Согласовано2.Text))

        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

        rangeObj = wordDoc.Bookmarks("\EndOfDoc").Range

        СкопироватьДокументИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & "_Протокол.docx", 1)

        rangeObj.SetRange(Start:=rangeObj.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)

        Dim DATEq As Date = BuildOrder.ДатаПриказа.Text

        _technical.replaceTextInWordApp(rangeObj, "$НомерПротокола$", studentsData(8, 0))
        _technical.replaceTextInWordApp(rangeObj, "$Программа$", studentsData(1, 0))
        _technical.replaceTextInWordApp(rangeObj, "$День$", Convert.ToDateTime(studentsData(3, 0)).Day)
        _technical.replaceTextInWordApp(rangeObj, "$Месяц$", месяцРП(Format(Convert.ToDateTime(studentsData(3, 0)), "MMMM")), 2)
        _technical.replaceTextInWordApp(rangeObj, "$Год$", Convert.ToDateTime(studentsData(3, 0)).Year)
        _technical.replaceTextInWordApp(rangeObj, "$ДатаН$", studentsData(2, 0), 2)
        _technical.replaceTextInWordApp(rangeObj, "$ДатаК$", studentsData(3, 0), 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОПредседатель$", rotate(BuildOrder.Ответственный.Text))
        _technical.replaceTextInWordApp(rangeObj, "$ПредседательДолжность$", BuildOrder.ОтветственныйДолжность.Text)
        _technical.replaceTextInWordApp(rangeObj, "$ИОЗПредседатель$", rotate(BuildOrder.ЗамПредседателя.Text))
        _technical.replaceTextInWordApp(rangeObj, "$ЗПредседательДолжность$", BuildOrder.ЗамПредседателяДолжность.Text)

        _technical.replaceTextInWordApp(rangeObj, "$ИОКомиссия1$", rotate(BuildOrder.РуководительСтажировки.Text))
        _technical.replaceTextInWordApp(rangeObj, "$Комиссия1Должность$", BuildOrder.РуководительСтажировкиДолжность.Text, 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОКомиссия2$", rotate(BuildOrder.Комиссия2.Text))
        _technical.replaceTextInWordApp(rangeObj, "$Комиссия2Должность$", BuildOrder.Комиссия2Должность.Text, 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОКомиссия3$", rotate(BuildOrder.Комиссия3.Text))
        _technical.replaceTextInWordApp(rangeObj, "$Комиссия3Должность$", BuildOrder.Комиссия3Должность.Text, 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОСКомиссии$", rotate(BuildOrder.СекретарьКомиссии.Text))
        _technical.replaceTextInWordApp(rangeObj, "$СКомиссииДолжность$", BuildOrder.СекретарьКомиссииДолжность.Text, 2)

        _technical.replaceTextInWordApp(rangeObj, "$Часы$", studentsData(4, 0), 2)
        _technical.replaceTextInWordApp(rangeObj, "$ПП/Стаж2$", ppOrStaj2, 2)

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

        _technical.replaceTextInWordApp(Область, "$Программа$", ДанныеСлушателей(1, 0))
        _technical.replaceTextInWordApp(Область, "$День$", Format(BuildOrder.ДатаПриказа.Value, "dd"), 2)
        _technical.replaceTextInWordApp(Область, "$Месяц$", месяцРП(Format(BuildOrder.ДатаПриказа.Value, "MMMM")), 2)
        _technical.replaceTextInWordApp(Область, "$Год$", Format(BuildOrder.ДатаПриказа.Value, "yyyy"), 2)
        _technical.replaceTextInWordApp(Область, "$ДатаН$", ДанныеСлушателей(2, 0), 2)

        _technical.replaceTextInWordApp(Область, "$ИОПредседатель$", rotate(BuildOrder.Ответственный.Text))
        _technical.replaceTextInWordApp(Область, "$ПредседательДолжность$", BuildOrder.ОтветственныйДолжность.Text)

        _technical.replaceTextInWordApp(Область, "$ИОЗПредседатель$", rotate(BuildOrder.ЗамПредседателя.Text))
        _technical.replaceTextInWordApp(Область, "$ЗПредседательДолжность$", BuildOrder.ЗамПредседателяДолжность.Text)

        _technical.replaceTextInWordApp(Область, "$ИОКомиссия1$", rotate(BuildOrder.РуководительСтажировки.Text))
        _technical.replaceTextInWordApp(Область, "$Комиссия1Должность$", BuildOrder.РуководительСтажировкиДолжность.Text, 2)

        _technical.replaceTextInWordApp(Область, "$ИОКомиссия2$", rotate(BuildOrder.Комиссия2.Text))
        _technical.replaceTextInWordApp(Область, "$Комиссия2Должность$", BuildOrder.Комиссия2Должность.Text, 2)

        _technical.replaceTextInWordApp(Область, "$ИОКомиссия3$", rotate(BuildOrder.Комиссия3.Text))
        _technical.replaceTextInWordApp(Область, "$Комиссия3Должность$", BuildOrder.Комиссия3Должность.Text, 2)

        _technical.replaceTextInWordApp(Область, "$ИОСКомиссии$", rotate(BuildOrder.СекретарьКомиссии.Text))
        _technical.replaceTextInWordApp(Область, "$СКомиссииДолжность$", BuildOrder.СекретарьКомиссииДолжность.Text, 2)

        For Счетчик = 1 To UBound(ДанныеСлушателей, 2)

            ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

            Область2 = ДокументВорд.Bookmarks("\EndOfDoc").Range
            Область.Copy

            ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)

            Область2.SetRange(Start:=Область2.Start,
        End:=ДокументВорд.Bookmarks("\EndOfDoc").Range.End)
            _technical.replaceTextInWordApp(Область2, "$СлушательИмяОтчество$", ДанныеСлушателей(0, Счетчик))

        Next

        _technical.replaceTextInWordApp(Область, "$СлушательИмяОтчество$", ДанныеСлушателей(0, 0))

    End Sub


End Module
