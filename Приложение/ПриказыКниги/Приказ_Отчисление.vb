Module Приказ_Отчисление
    Sub Приказ_Отчисление(ВидПриказа As String)
        Dim wordApp
        Dim wordDoc, group
        Dim resourcesPath, samplePath, sqlQuery As String

        sqlQuery = expulsion__loadProgramm(MainForm.orderIdGroup)
        group = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        resourcesPath = startApp.ПутьКФайлуRes
        samplePath = resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & ".docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(samplePath, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, MainForm.orderIdGroup, ВидПриказа, resourcesPath, "Приказы")

        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", BuildOrder.ДатаПриказа.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", group(0, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$СлушательИмяОтчество$", BuildOrder.Ответственный.Text, 2)


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

        wordApp.Visible = True
        wordDoc.Save

    End Sub


End Module
