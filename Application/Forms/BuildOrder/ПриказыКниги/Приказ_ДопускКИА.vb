Module Приказ_ДопускКИА

    Sub Приказ_ДопускКИА(argument As OrderArgument)
        Dim wordApp
        Dim wordDoc, studentsData, rangeObj, table
        Dim resourcesPath, samplePath
        Dim sqlQuery, ppOrStaj, ppOrStaj2 As String
        Dim tens, units As Integer

        sqlQuery = dopusk_loadListStudents(argument.orderIdGroup)
        studentsData = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If argument.studentPosition Then

            ppOrStaj = "практическая подготовка"
            ppOrStaj2 = "практической подготовки"
        Else

            ppOrStaj = "стажировка"
            ppOrStaj2 = "стажировки"

        End If



        resourcesPath = startApp.resourcesPath
        samplePath = resourcesPath & "Шаблоны\Приказы\" & argument.orderType & ".docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, MainForm.orderIdGroup, argument.orderType, resourcesPath, "Приказы", argument.mySqlConnector)

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", argument.orderDate.ToShortDateString)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", argument.groupNumber)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ПП/Стаж$", ppOrStaj, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ПредседательИО$", argument.responsible, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ПредседательДолжность$", argument.responsiblePosition, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ЗПредседательИО$", argument.deputyChiefComission, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ЗПредседательДолжность$", argument.deputyPosition, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия1ИО$", argument.internshipChief, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия1Должность$", argument.internshipChiefPosition, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия2ИО$", argument.comissionSec, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия2Должность$", argument.comissionSecPosition, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия3ИО$", argument.comissionThird, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Комиссия3Должность$", argument.comissionThirdPosition, 2)

        _technical.replaceTextInWordApp(wordDoc.Range, "$СКомиссииИО$", argument.secretary, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$СКомиссииДолжность$", argument.secretaryPosition, 2)

        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$", True, "$ТаблицаСекретарь$")

        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", argument.approvesPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", argument.approves)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаСекретарь$", "Секретарь комиссии:")


        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", argument.initiatorPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(argument.initiator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", argument.realisatorPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(argument.realisator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", argument.inspectorFirstPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(argument.inspectorFirst))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", argument.inspectorSecPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(argument.inspectorSec))

        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

        rangeObj = wordDoc.Bookmarks("\EndOfDoc").Range

        СкопироватьДокументИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\Приказы\" & argument.orderType & "_Протокол.docx", 1)

        rangeObj.SetRange(Start:=rangeObj.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)

        _technical.replaceTextInWordApp(rangeObj, "$НомерПротокола$", studentsData(8, 0))
        _technical.replaceTextInWordApp(rangeObj, "$Программа$", studentsData(1, 0))
        _technical.replaceTextInWordApp(rangeObj, "$День$", Convert.ToDateTime(studentsData(3, 0)).Day)
        _technical.replaceTextInWordApp(rangeObj, "$Месяц$", monthRP(Format(Convert.ToDateTime(studentsData(3, 0)), "MMMM")), 2)
        _technical.replaceTextInWordApp(rangeObj, "$Год$", Convert.ToDateTime(studentsData(3, 0)).Year)
        _technical.replaceTextInWordApp(rangeObj, "$ДатаН$", studentsData(2, 0), 2)
        _technical.replaceTextInWordApp(rangeObj, "$ДатаК$", studentsData(3, 0), 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОПредседатель$", rotate(argument.responsible))
        _technical.replaceTextInWordApp(rangeObj, "$ПредседательДолжность$", argument.responsiblePosition)
        _technical.replaceTextInWordApp(rangeObj, "$ИОЗПредседатель$", rotate(argument.deputyChiefComission))
        _technical.replaceTextInWordApp(rangeObj, "$ЗПредседательДолжность$", argument.deputyPosition)

        _technical.replaceTextInWordApp(rangeObj, "$ИОКомиссия1$", rotate(argument.internshipChief))
        _technical.replaceTextInWordApp(rangeObj, "$Комиссия1Должность$", argument.internshipChiefPosition, 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОКомиссия2$", rotate(argument.comissionSec))
        _technical.replaceTextInWordApp(rangeObj, "$Комиссия2Должность$", argument.comissionSecPosition, 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОКомиссия3$", rotate(argument.comissionThird))
        _technical.replaceTextInWordApp(rangeObj, "$Комиссия3Должность$", argument.comissionThirdPosition, 2)

        _technical.replaceTextInWordApp(rangeObj, "$ИОСКомиссии$", rotate(argument.secretary))
        _technical.replaceTextInWordApp(rangeObj, "$СКомиссииДолжность$", argument.secretaryPosition, 2)

        _technical.replaceTextInWordApp(rangeObj, "$Часы$", studentsData(4, 0), 2)
        _technical.replaceTextInWordApp(rangeObj, "$ПП/Стаж2$", ppOrStaj2, 2)

        table = НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc, "$СписокСлушателей$", 2, 3)

        units = (UBound(studentsData, 2) + 1) Mod 10
        tens = (UBound(studentsData, 2) + 1) \ 10

        For counter = 1 To tens
            For cell = 1 To table.Columns.Count
                table.Cell(3, cell).Split(NumRows:=10, NumColumns:=1)
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

        If argument.orderType = "ПО_ДопускКИА" Then
            ПО_ДопускКИАпродолжение(wordApp, wordDoc, studentsData, argument)
        End If

        wordApp.Visible = True
        wordDoc.Save

    End Sub

    Sub ПО_ДопускКИАпродолжение(wordApp As Object, wordDoc As Object, studentsData As Object, argument As OrderArgument)
        Dim НомерАбзаца As Integer
        Dim Область, Область2
        'ПриложениеВорд.Visible = True
        НомерАбзаца = wordDoc.Paragraphs.Count
        wordDoc.Paragraphs(НомерАбзаца).Range.Delete
        wordDoc.Paragraphs(НомерАбзаца - 1).Range.Delete
        wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)
        Область = wordDoc.Bookmarks("\EndOfDoc").Range

        СкопироватьДокументИзШаблона(wordApp, wordDoc, updateResourcesPath() & "Шаблоны\Приказы\" & argument.orderType & "_Протокол_Слушатель.docx", 1)

        Область.SetRange(Start:=Область.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)

        _technical.replaceTextInWordApp(Область, "$Программа$", studentsData(1, 0))
        _technical.replaceTextInWordApp(Область, "$День$", Format(argument.orderDate, "dd"), 2)
        _technical.replaceTextInWordApp(Область, "$Месяц$", monthRP(Format(argument.orderDate, "MMMM")), 2)
        _technical.replaceTextInWordApp(Область, "$Год$", Format(argument.orderDate, "yyyy"), 2)
        _technical.replaceTextInWordApp(Область, "$ДатаН$", studentsData(2, 0), 2)

        _technical.replaceTextInWordApp(Область, "$ИОПредседатель$", rotate(argument.responsible))
        _technical.replaceTextInWordApp(Область, "$ПредседательДолжность$", argument.responsiblePosition)

        _technical.replaceTextInWordApp(Область, "$ИОЗПредседатель$", rotate(argument.deputyChiefComission))
        _technical.replaceTextInWordApp(Область, "$ЗПредседательДолжность$", argument.deputyPosition)

        _technical.replaceTextInWordApp(Область, "$ИОКомиссия1$", rotate(argument.internshipChief))
        _technical.replaceTextInWordApp(Область, "$Комиссия1Должность$", argument.internshipChiefPosition, 2)

        _technical.replaceTextInWordApp(Область, "$ИОКомиссия2$", rotate(argument.comissionSec))
        _technical.replaceTextInWordApp(Область, "$Комиссия2Должность$", argument.comissionSecPosition, 2)

        _technical.replaceTextInWordApp(Область, "$ИОКомиссия3$", rotate(argument.comissionThird))
        _technical.replaceTextInWordApp(Область, "$Комиссия3Должность$", argument.comissionThirdPosition, 2)

        _technical.replaceTextInWordApp(Область, "$ИОСКомиссии$", rotate(argument.secretary))
        _technical.replaceTextInWordApp(Область, "$СКомиссииДолжность$", argument.secretaryPosition, 2)

        For Счетчик = 1 To UBound(studentsData, 2)

            wordDoc.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

            Область2 = wordDoc.Bookmarks("\EndOfDoc").Range
            Область.Copy

            wordDoc.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)

            Область2.SetRange(Start:=Область2.Start,
        End:=wordDoc.Bookmarks("\EndOfDoc").Range.End)
            _technical.replaceTextInWordApp(Область2, "$СлушательИмяОтчество$", studentsData(0, Счетчик))

        Next

        _technical.replaceTextInWordApp(Область, "$СлушательИмяОтчество$", studentsData(0, 0))

    End Sub


End Module
