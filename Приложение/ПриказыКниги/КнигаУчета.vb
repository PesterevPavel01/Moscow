Module КнигаУчета
    Sub КнигаУчета(Критерий As String)
        Dim ПриложениеВорд
        Dim ДокументВорд
        Dim Таблица, Массив
        Dim ПутьКШаблону, ПутьКНовомуФайлу, ПутьККаталогуСРесурсами, Название As String

        If Критерий = "Удостоверение" Then
            Название = " удостоверений "
        End If

        If Критерий = "Диплом" Then
            Название = " дипломов "
        End If

        If Критерий = "Свидетельство" Then
            Название = " свидетельств "
        End If

        Массив = ЗагрузитьСписок(Критерий, ААОсновная.ДатаНачалаОтчета.Value.ToShortDateString, ААОсновная.ДатаКонцаОтчета.Value.ToShortDateString)

        If Массив(0, 0).ToString = "нет записей" Then
            Exit Sub
        End If

        Массив = ДобавитьНулиСпередиМвссив(Массив, 0, 5)

        ПутьККаталогуСРесурсами = Вспомогательный.ПутьККаталогуСРесурсами()
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны/Книга учёта выданных" & Название & "о повышении квалификации.docx"
        ПутьКНовомуФайлу = ПутьККаталогуСРесурсами & "Отчеты/КнигиУчета/Книга учёта выданных удостоверений о повышении квалификации.docx"

        ПриложениеВорд = CreateObject("Word.Application")
        ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        Вспомогательный.saveKniga(ДокументВорд, "Книга учета " & Критерий, ПутьККаталогуСРесурсами)

        'ПриложениеВорд.Visible = True
        Таблица = ДокументВорд.Tables(1)
        ЗаполнитьТаблицу(ПриложениеВорд, Таблица, Массив, ААОсновная.ДатаНачалаОтчета.Value.ToShortDateString, ААОсновная.ДатаКонцаОтчета.Value.ToShortDateString)
        ДокументВорд.Save
        ПриложениеВорд.Visible = True
    End Sub

    Function ЗагрузитьСписок(Критерий As String, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String) As Object
        Dim listResult
        Dim queryString As String

        If Критерий = "Удостоверение" Then

            queryString = accountingBook__loadListUd(ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаНачалаОтчета)), ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаКонцаОтчета)))

        ElseIf Критерий = "Диплом" Then

            queryString = accountingBook__loadListDip(ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаНачалаОтчета)), ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаКонцаОтчета)))

        ElseIf Критерий = "Свидетельство" Then

            queryString = accountingBook__loadListSvid(ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаНачалаОтчета)), ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаКонцаОтчета)))

        End If

        listResult = УбратьПустотыВМассиве.УбратьПустотыВМассиве(ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString))

        If listResult(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            ОткрытьФорму(предупреждение)
            ЗагрузитьСписок = listResult
            Exit Function

        End If
        ЗагрузитьСписок = listResult
    End Function

    Sub ЗаполнитьТаблицу(wordApp As Object, Таблица As Object, Массив As Object, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String)

        Dim СчетчикСтрок As Integer

        Таблица.Cell(2, 1).Range.text = "за период с " & ДатаНачалаОтчета & " по " & ДатаКонцаОтчета

        СчетчикСтрок = UBound(Массив, 2)

        Таблица.Rows(6).Select

        wordApp.Selection.InsertRows(СчетчикСтрок)

        For НомерСтолбца = 1 To Таблица.Columns.Count - 2
            Таблица.Cell(6, НомерСтолбца).Range.text = Массив(НомерСтолбца - 1, 0)
        Next

        For НомерСтроки = 1 To UBound(Массив, 2)
            For НомерСтолбца = 1 To Таблица.Columns.Count - 2
                Таблица.Cell(6 + НомерСтроки, НомерСтолбца).Range.text = Массив(НомерСтолбца - 1, НомерСтроки)
            Next
        Next

        With Таблица.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With
        With Таблица.Rows(1).Borders
            .InsideLineStyle = 0
            .OutsideLineStyle = 0
        End With
        With Таблица.Rows(2).Borders
            .InsideLineStyle = 0
            .OutsideLineStyle = 0
        End With
        With Таблица.Rows(3).Borders
            .InsideLineStyle = 0
            .OutsideLineStyle = 0
        End With
        With Таблица.Rows(4).Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With

    End Sub

End Module
