Module Приказ_Зачисление
    Sub Приказ_Зачисление(ВидПриказа As String, Optional ЧекнутыеСлушатели As Object = "")
        Dim wordApp
        Dim wordDoc, studentsData
        Dim resourcesPath, ПутьКШаблону
        Dim sqlQuery, arg As String

        If ВидПриказа = "ПК_Зачисление" Or ВидПриказа = "ПК_Зачисление_Доп" Then
            If ЧекнутыеСлушатели(0, 0) = "нет записей" Then
                Return
            End If
        End If

        sqlQuery = loadListStudents(MainForm.prikazKodGroup)
        studentsData = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If studentsData(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        If АСформироватьПриказ.CheckBoxММС.Checked Then

            arg = АСформироватьПриказ.CheckBoxММС.Text

        Else

            arg = АСформироватьПриказ.CheckBoxСанитар.Text

        End If

        resourcesPath = Запуск.ПутьКФайлуRes
        ПутьКШаблону = resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & ".docx"

        wordApp = CreateObject("Word.Application")
        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        Вспомогательный.savePrikazBlank(wordDoc, MainForm.prikazKodGroup, ВидПриказа, resourcesPath, "Приказы")

        If ВидПриказа = "ПК_Зачисление" Or ВидПриказа = "ПК_Зачисление_Доп" Then
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", ЧекнутыеСлушатели, wordApp)
        Else
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)
        End If

        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Приказ$", АСформироватьПриказ.ПрактическаяПодготовка.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ОтвЗаАттестацию$", АСформироватьПриказ.Ответственный.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", АСформироватьПриказ.ДатаПриказа.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$ВидСредств$", arg, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$РуководительСтажировкиДолжность$", АСформироватьПриказ.РуководительСтажировкиДолжность.Text, 2)
        Вспомогательный.replaceTextInWordApp(wordDoc.Range, "$РуководительСтажировки$", АСформироватьПриказ.РуководительСтажировки.Text, 2)


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
