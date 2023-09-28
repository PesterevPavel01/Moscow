Module ВедомостьПромежуточнойАттестации

    Sub ВедомостьПромежуточнойАттестации(ЧекнутыеМодули As Object, ВидПриказа As String)

        If ЧекнутыеМодули(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        Dim ПриложениеВорд
        Dim ДокументВорд, ДанныеСлушателей, Группа, Таблица
        Dim ПутьККаталогуСРесурсами, ПутьКШаблону
        Dim Дата As Date, ДатаВПриказ As String
        Dim queryString As String

        Дата = BuildOrder.ДатаПриказа.Value

        ДатаВПриказ = Chr(34) & Format(Дата, "dd") & Chr(34) & " " & месяцРП(Format(Дата, "MMMM")) & " " & Format(Дата, "yyyy")

        queryString = vedomPromAtt__loadListSlush(MainForm.orderIdGroup)

        ДанныеСлушателей = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If ДанныеСлушателей(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        queryString = load_prog_kurator(MainForm.orderIdGroup)
        Группа = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If Группа(0, 0) = "нет записей" Then
            Warning.content.Text = "Нет данных для отображения"
            Warning.ShowDialog()
            Exit Sub
        End If

        ПутьККаталогуСРесурсами = _technical.resourcesPath()

        If ВидПриказа = "ВедомостьПромежуточнойАттестации" Then

            ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\Ведомость промежуточной аттестации.docx"

        ElseIf ВидПриказа = "ПП_Ведомость" Then

            ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\ПП_Ведомость.docx"

        End If



        ПриложениеВорд = CreateObject("Word.Application")

        For i = 0 To UBound(ЧекнутыеМодули, 2)
            Dim ocenka
            queryString = select_moduls_ocenka(MainForm.orderIdGroup, ЧекнутыеМодули(0, i))

            ocenka = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            _technical.savePrikazBlank(ДокументВорд, MainForm.orderIdGroup, ВидПриказа & " " & ЧекнутыеМодули(0, i), ПутьККаталогуСРесурсами, "Ведомости")

            Warning.content.Visible = False
            Warning.TextBox.Visible = True

            Warning.TextBox.Text = "Документы сохранены, Путь к каталогу:
" & BuildOrder.path

            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)

            Таблица = МСВорд.НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, "$Таблица$", 2, 2)

            Try
                If Таблица(0, 0) = "не найдена" Then
                    Warning.content.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                    Warning.ShowDialog()
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$КоличествоСлушателей$", UBound(ДанныеСлушателей, 2) + 1, 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$НомерГруппы$", BuildOrder.groupNumber.Text, 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$КураторГруппы$", Группа(1, 0), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Программа$", Группа(0, 0), 2)

            If Not Len(ЧекнутыеМодули(1, i)) < 5 Then
                _technical.replaceText_documentWordRange(ДокументВорд.Range, "$И.О.Ответств$", rotate(ЧекнутыеМодули(1, i)), 2)
            End If

            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Модуль$", ЧекнутыеМодули(0, i), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Дата$", ДатаВПриказ, 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$День$", Format(Дата, "dd"), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Месяц$", месяцРП(Format(Дата, "MMMM")), 2)
            _technical.replaceText_documentWordRange(ДокументВорд.Range, "$Год$", Format(Дата, "yyyy"), 2)

            МСВорд.ЗаполнитьТаблицуВедомости(Таблица, ДанныеСлушателей, ocenka, 2, True)

            ДокументВорд.Save
            ДокументВорд.Close
        Next

        ПриложениеВорд.Quit
        Warning.ShowDialog()
        Warning.content.Visible = True
        Warning.TextBox.Visible = False

    End Sub

End Module
