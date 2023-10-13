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

        sqlQuery = loadListStudents(MainForm.orderIdGroup)
        studentsData = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If studentsData(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        If BuildOrder.CheckBoxММС.Checked Then

            arg = BuildOrder.CheckBoxММС.Text

        Else

            arg = BuildOrder.CheckBoxСанитар.Text

        End If

        resourcesPath = startApp.resourcesPath
        ПутьКШаблону = resourcesPath & "Шаблоны\Приказы\" & ВидПриказа & ".docx"

        wordApp = CreateObject("Word.Application")
        wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        _technical.savePrikazBlank(wordDoc, MainForm.orderIdGroup, ВидПриказа, resourcesPath, "Приказы")

        If ВидПриказа = "ПК_Зачисление" Or ВидПриказа = "ПК_Зачисление_Доп" Then
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", ЧекнутыеСлушатели, wordApp)
        Else
            МСВорд.ДобавитьСписокПоМеткеСтрокой(wordDoc, "$СписокСлушателей$", studentsData, wordApp)
        End If

        _technical.replaceTextInWordApp(wordDoc.Range, "$Приказ$", BuildOrder.ПрактическаяПодготовка.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ОтвЗаАттестацию$", BuildOrder.Ответственный.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаПриказа$", BuildOrder.ДатаПриказа.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Программа$", studentsData(1, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$Часы$", studentsData(4, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаН$", studentsData(2, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ДатаК$", studentsData(3, 0), 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$ВидСредств$", arg, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$РуководительСтажировкиДолжность$", BuildOrder.РуководительСтажировкиДолжность.Text, 2)
        _technical.replaceTextInWordApp(wordDoc.Range, "$РуководительСтажировки$", BuildOrder.РуководительСтажировки.Text, 2)


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
