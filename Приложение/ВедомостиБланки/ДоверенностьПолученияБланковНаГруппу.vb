Module ДоверенностьПолученияБланковНаГруппу

    Sub ДоверенностьПолученияБланковНаГруппу()
        Dim ПриложениеВорд
        Dim ДокументВорд, ДанныеСлушателей, Группа, Таблица
        Dim ПутьККаталогуСРесурсами, ПутьКШаблону
        Dim Дата As Date, ДатаВПриказ As String
        Dim queryString, ВидПриказа As String

        Дата = BuildOrder.ДатаПриказа.Value

        ДатаВПриказ = Chr(34) & Format(Дата, "dd") & Chr(34) & " " & месяцРП(Format(Дата, "MMMM")) & " " & Format(Дата, "yyyy")



        ВидПриказа = "ДоверенностьПолученияБланковНаГруппу"

        queryString = selectDover_slush(MainForm.orderIdGroup)
        ДанныеСлушателей = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If ДанныеСлушателей(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        ВидПриказа = "ДоверенностьПолученияБланковНаГруппу"

        queryString = selectDoverKval(MainForm.orderIdGroup)
        Группа = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If Группа(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        ПутьККаталогуСРесурсами = _technical.updateResourcesPath()
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\Доверенность получения бланков на группу.docx"

        ПриложениеВорд = CreateObject("Word.Application")


        ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        _technical.savePrikazBlank(ДокументВорд, MainForm.orderIdGroup, ВидПриказа, ПутьККаталогуСРесурсами, "Доверенности")

        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)

        Таблица = МСВорд.НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, "$Таблица$", 2, 2)

        Try
            If Таблица(0, 0) = "Не найдено" Then
                Warning.content.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                Warning.ShowDialog()
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$КоличествоСлушателей$", UBound(ДанныеСлушателей, 2) + 1, 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$УровеньКвалификации$", Группа(1, 0), 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Программа$", Группа(0, 0), 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$ГруппаФинансирование$", Группа(2, 0), 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$И.О.Ответств$", rotate(BuildOrder.Утверждает.Text), 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Дата$", ДатаВПриказ, 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$День$", Format(Дата, "dd"), 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Месяц$", месяцРП(Format(Дата, "MMMM")), 2)
        _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Год$", Format(Дата, "yyyy"), 2)

        МСВорд.ЗаполнитьТаблицу(Таблица, ДанныеСлушателей, 2, True)
        ДокументВорд.Save
        ПриложениеВорд.visible = True
    End Sub

    Sub ДоверенностьПолученияБланковНаСлушателя(ЧекнутыеСлушатели As Object)
        Dim ПриложениеВорд, Область
        Dim ДокументВорд, ДанныеСлушателей, Группа, Таблица
        Dim ПутьККаталогуСРесурсами, ПутьКШаблону
        Dim Дата As Date, ДатаВПриказ As String, НомерАбзаца As Integer
        Dim queryString, ВидПриказа As String

        If ЧекнутыеСлушатели(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If


        Дата = BuildOrder.ДатаПриказа.Value

        queryString = selectDoverKval(MainForm.orderIdGroup)
        Группа = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If Группа(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        Дата = Группа(3, 0)
        ДатаВПриказ = Chr(34) & Format(Дата, "dd") & Chr(34) & " " & месяцРП(Format(Дата, "MMMM")) & " " & Format(Дата, "yyyy")

        ПутьККаталогуСРесурсами = _technical.updateResourcesPath()
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\Доверенность получения бланков на каждого человека группы.docx"

        ПриложениеВорд = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(ЧекнутыеСлушатели, 2)

            ВидПриказа = "ДоверенностьПолученияБланковНаСлушателя" & ЧекнутыеСлушатели(0, СчетчикСтрок)

            ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            _technical.savePrikazBlank(ДокументВорд, MainForm.orderIdGroup, ВидПриказа, ПутьККаталогуСРесурсами, "Доверенности")

            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$СлушательИО$", _technical.ФамилияИОПоПолнойФИО(ЧекнутыеСлушатели(0, СчетчикСтрок)), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$ФИОСлушатель$", ЧекнутыеСлушатели(0, СчетчикСтрок), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$КоличествоСлушателей$", UBound(ЧекнутыеСлушатели, 2) + 1, 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$УровеньКвалификации$", Группа(1, 0), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Программа$", Группа(0, 0), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$ГруппаФинансирование$", Группа(2, 0), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$И.О.Ответств$", rotate(BuildOrder.Утверждает.Text), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$ДатаК$", ДатаВПриказ, 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$День$", Format(Дата, "dd"), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Месяц$", месяцРП(Format(Дата, "MMMM")), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Год$", Format(Дата, "yyyy"), 2)

            ДокументВорд.Save
            ДокументВорд.Close
        Next

        ПриложениеВорд.Quit

        Warning.TextBox.Text = BuildOrder.path
        Warning.TextBox.Visible = True
        Warning.content.Visible = False
        Warning.ShowDialog()
        Warning.TextBox.Visible = False
        Warning.content.Visible = True
    End Sub

End Module
