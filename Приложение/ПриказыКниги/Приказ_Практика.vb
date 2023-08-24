Module Приказ_Практика
    Sub Приказ_Практика(ВидПриказа As String)
        Dim wordApp
        Dim wordDoc, studentsData
        Dim resourcesPath, templatePath
        Dim queryString As String

        queryString = loadListStudents(MainForm.prikazKodGroup)
        studentsData = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If studentsData(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        resourcesPath = Запуск.ПутьКФайлуRes
        templatePath = resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & ".docx"

        wordApp = CreateObject("Word.Application")

        wordDoc = wordApp.Documents.Open(templatePath, ReadOnly:=True)

        Вспомогательный.savePrikazBlank(wordDoc, MainForm.prikazKodGroup, ВидПриказа, resourcesPath, "Приказы")

        МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", АСформироватьПриказ.ДатаПриказа.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$РуководительППДолжность$", АСформироватьПриказ.ОтветственныйДолжность.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$РуководительПП$", АСформироватьПриказ.Ответственный.Text, 2)

        ТаблицаУтверждаю(wordApp, wordDoc, "$ТаблицаУтверждаю$", "$КонецОсновногоРаздела$")

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ТаблицаУтверждаю$", АСформироватьПриказ.УтверждаетДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$УтверждаюИО$", АСформироватьПриказ.Утверждает.Text)



        СкопироватьТаблицуИзШаблона(wordApp, wordDoc, resourcesPath & "Шаблоны\ПК_Окончание\ТаблицаСогласование.docx", 1)

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ВноситДолжность$", АСформироватьПриказ.ПроектВноситДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияВносит$", rotate(АСформироватьПриказ.ПроектВносит.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИсполнительДолжность$", АСформироватьПриказ.ИсполнительДолжность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияИсполнитель$", rotate(АСформироватьПриказ.Исполнитель.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Согласовано1Должность$", АСформироватьПриказ.Согласовано1Должность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано1$", rotate(АСформироватьПриказ.Согласовано1.Text))
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Согласовано2Должность$", АСформироватьПриказ.Согласовано2Должность.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ИОФамилияСогласовано2$", rotate(АСформироватьПриказ.Согласовано2.Text))

        wordApp.Visible = True
        wordDoc.Save

    End Sub
End Module
