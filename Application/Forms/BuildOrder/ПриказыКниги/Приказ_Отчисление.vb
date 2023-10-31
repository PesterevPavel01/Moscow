Module Приказ_Отчисление
    Sub Приказ_Отчисление(argument As OrderArgument)
        Dim wordApp
        Dim wordDoc, group
        Dim resourcesPath, samplePath, sqlQuery As String

        sqlQuery = expulsion__loadProgram(argument.orderIdGroup)
        group = argument.mySqlConnector.loadMySqlToArray(sqlQuery, 1)

        resourcesPath = startApp.resourcesPath
        samplePath = resourcesPath & "Шаблоны\Приказы\" & argument.orderType & ".docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, argument.orderIdGroup, argument.orderType, resourcesPath, "Приказы", argument.mySqlConnector)

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", argument.orderDate.ToShortDateString)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", argument.groupNumber)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", group(0, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$СлушательИмяОтчество$", argument.responsible, 2)


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
