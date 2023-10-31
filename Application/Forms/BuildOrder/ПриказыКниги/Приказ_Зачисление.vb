Module Приказ_Зачисление
    Sub Приказ_Зачисление(argument As OrderArgument)
        Dim wordApp
        Dim wordDoc, studentsData
        Dim resourcesPath, samplePath
        Dim sqlQuery, arg As String

        If argument.orderType = "ПК_Зачисление" Or argument.orderType = "ПК_Зачисление_Доп" Then
            If argument.selectedStudents(0, 0) = "нет записей" Then
                Return
            End If
        End If

        sqlQuery = loadListStudents(argument.orderIdGroup)
        studentsData = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If argument.studentPosition Then

            arg = argument.studentPositionName

        Else

            arg = argument.studentAlterPos

        End If

        resourcesPath = startApp.resourcesPath
        samplePath = resourcesPath & "Шаблоны\Приказы\" & argument.orderType & ".docx"

        wordApp = CreateObject("Word.Application")
        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, MainForm.orderIdGroup, argument.orderType, resourcesPath, "Приказы", MainForm.mySqlConnect)

        If argument.orderType = "ПК_Зачисление" Or argument.orderType = "ПК_Зачисление_Доп" Then
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", argument.selectedStudents, wordApp)
        Else
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)
        End If

        _technical.replaceTextInWordApp(wordDoc.Range, "$Приказ$", argument.practical)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ОтвЗаАттестацию$", argument.responsible)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", argument.orderDate.ToShortDateString)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", argument.groupNumber)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ВидСредств$", arg, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$РуководительСтажировкиДолжность$", argument.internshipChiefPosition, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$РуководительСтажировки$", argument.internshipChief, 2)


        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        _technical.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", argument.approvesPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", argument.approves)



        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", argument.initiatorPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(argument.initiator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", argument.initiatorPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(argument.realisator))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", argument.inspectorFirstPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(argument.inspectorFirst))
        _technical.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", argument.inspectorSecPosition)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(argument.inspectorSec))

        wordApp.Visible = True
        wordDoc.Save

    End Sub



End Module
