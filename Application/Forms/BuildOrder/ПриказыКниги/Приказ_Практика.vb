Module Приказ_Практика
    Sub Приказ_Практика(argument As OrderArgument)
        Dim wordApp
        Dim wordDoc, studentsData
        Dim resourcesPath, templatePath
        Dim queryString As String

        queryString = loadListStudents(argument.orderIdGroup)
        studentsData = argument.mySqlConnector.loadMySqlToArray(queryString, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        resourcesPath = startApp.resourcesPath
        templatePath = resourcesPath & "Шаблоны\Приказы\" & argument.orderType & ".docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(templatePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, argument.orderType, resourcesPath, "Приказы", argument.mySqlConnector)

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", argument.orderDate)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", argument.groupNumber)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$РуководительППДолжность$", argument.responsiblePosition, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$РуководительПП$", argument.responsible, 2)

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

        wordApp.Visible = True
        wordDoc.Save

    End Sub
End Module
