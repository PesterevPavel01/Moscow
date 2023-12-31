﻿Module КнигаУчетаСпецэкзамен

    Sub КнигаУчетаСпецэкзамен()
        Dim ПриложениеВорд
        Dim ДокументВорд
        Dim Таблица, Массив
        Dim ПутьКШаблону, ПутьККаталогуСРесурсами, Название As String
        Dim datePicker As DateTimePicker
        Dim shortDateStart, shortDateEnd As String
        datePicker = mainFormBuilder.controls(mainFormBuilder.controlNames("reportStart"))
        shortDateStart = datePicker.Value.ToShortDateString
        datePicker = mainFormBuilder.controls(mainFormBuilder.controlNames("reportEnd"))
        shortDateEnd = datePicker.Value.ToShortDateString

        Название = "Спецэкзамен"

        Массив = ЗагрузитьСписок("SELECT Фамилия,Имя, Отчество, Специальность,group_list.НомерПротоколаСпецэкзамен,Группа.ДатаСпецЭкзамен, Группа.ДатаСпецЭкзамен FROM (group_list INNER JOIN Слушатель On group_list.Слушатель = Слушатель.Снилс) INNER JOIN Группа On group_list.Kod = Группа.Код WHERE Группа.УровеньКвалификации= 'специальный экзамен' and Группа.ДатаСпецЭкзамен BETWEEN  '" & MainForm.mySqlConnect.dateToFormatMySQL(shortDateStart) & "'  and '" & MainForm.mySqlConnect.dateToFormatMySQL(shortDateEnd) & " ' ORDER BY group_list.Группа")

        If Массив(0, 0).ToString = "нет записей" Then
            Exit Sub
        End If

        ПутьККаталогуСРесурсами = _technical.updateResourcesPath()
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\Спецэкзамен\Книга учёта протоколов Спецэкзамен.docx"

        ПриложениеВорд = CreateObject("Word.Application")
        ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        If _technical.СоздатьПапку(ПутьККаталогуСРесурсами & "\Отчеты\Книги Учета") Then
            _technical.сохранить(ДокументВорд, "Спецэкзамен", ПутьККаталогуСРесурсами & "\Отчеты\Книги Учета\")
        Else
            _technical.сохранить(ДокументВорд, "Спецэкзамен", ПутьККаталогуСРесурсами & "\Отчеты\Книги Учета\")
        End If
        'ПриложениеВорд.Visible = True
        _technical.replaceTextInWordApp(ДокументВорд.Range, "$ДатаН$", shortDateStart)
        _technical.replaceTextInWordApp(ДокументВорд.Range, "$ДатаК$", shortDateEnd)

        Таблица = НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, "$ТаблицаКУВП$", 2, 3)

        Try
            If Таблица(0, 0) = "не найдена" Then
                Warning.content.Text = "В шаблоне ( " & ПутьКШаблону & " ) не найдена таблица $ТаблицаКУВП$ (если таблица находится в шаблоне, проверьте наличие метки в ячейке (2,3))"
                openForm(Warning)
                Exit Sub
            End If
        Catch ex As Exception

        End Try


        ЗаполнитьТаблицу(Таблица, Массив, shortDateStart, shortDateEnd)

        Таблица = НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, "$ТаблицаЖВД$", 2, 3)

        Try
            If Таблица(0, 0) = "не найдена" Then
                Warning.content.Text = "В шаблоне ( " & ПутьКШаблону & " ) не найдена таблица $ТаблицаЖВД$ (если таблица находится в шаблоне, проверьте наличие метки в ячейке (2,3))"
                openForm(Warning)
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        Массив = ЗагрузитьСписок("SELECT Фамилия,Имя, Отчество, Специальность,Группа.ДатаСпецЭкзамен FROM (group_list INNER JOIN Слушатель On group_list.Слушатель = Слушатель.Снилс) INNER JOIN Группа On group_list.Kod = Группа.Код WHERE Группа.УровеньКвалификации= 'специальный экзамен' and Группа.ДатаСпецЭкзамен BETWEEN '" & MainForm.mySqlConnect.dateToFormatMySQL(shortDateStart) & "'and '" & MainForm.mySqlConnect.dateToFormatMySQL(shortDateEnd) & " ' ORDER BY group_list.Группа")

        If Массив(0, 0).ToString = "нет записей" Then
            Exit Sub
        End If

        ЗаполнитьТаблицуТаблицаЖВД(Таблица, Массив, shortDateStart, shortDateEnd)

        ДокументВорд.Save
        ПриложениеВорд.Visible = True
    End Sub
    Function ЗагрузитьСписок(sqlQuery As String) As Object
        Dim Список

        MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If Список(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ЗагрузитьСписок = Список
            Exit Function

        End If
        ЗагрузитьСписок = Список
    End Function

    Sub ЗаполнитьТаблицу(Таблица As Object, Массив As Object, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String)

        Dim СчетчикСтрок As Integer
        Таблица.Cell(3, 1).Range.text = 1

        For НомерСтолбца = 1 To Таблица.Columns.Count - 3
            Таблица.Cell(3, НомерСтолбца + 1).Range.text = Массив(НомерСтолбца - 1, 0)
        Next
        СчетчикСтрок = UBound(Массив, 2)


        For НомерСтроки = 1 To UBound(Массив, 2)
            Таблица.Rows.add
            Таблица.Cell(3 + НомерСтроки, 1).Range.text = НомерСтроки + 1
            For НомерСтолбца = 1 To Таблица.Columns.Count - 3
                Таблица.Cell(3 + НомерСтроки, НомерСтолбца + 1).Range.text = Массив(НомерСтолбца - 1, НомерСтроки)
            Next
        Next

    End Sub

    Sub ЗаполнитьТаблицуТаблицаЖВД(Таблица As Object, Массив As Object, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String)

        Dim СчетчикСтрок As Integer
        Таблица.Cell(3, 1).Range.text = 1

        For НомерСтолбца = 1 To Таблица.Columns.Count - 4
            Таблица.Cell(3, НомерСтолбца + 1).Range.text = Массив(НомерСтолбца - 1, 0)
        Next
        СчетчикСтрок = UBound(Массив, 2)


        For НомерСтроки = 1 To UBound(Массив, 2)
            Таблица.Rows.add
            Таблица.Cell(3 + НомерСтроки, 1).Range.text = НомерСтроки + 1
            For НомерСтолбца = 1 To Таблица.Columns.Count - 4
                Таблица.Cell(3 + НомерСтроки, НомерСтолбца + 1).Range.text = Массив(НомерСтолбца - 1, НомерСтроки)
            Next
        Next

    End Sub
End Module
