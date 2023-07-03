﻿Module КнигаУчета
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


        Таблица = ДокументВорд.Tables(1)
        ЗаполнитьТаблицу(Таблица, Массив, ААОсновная.ДатаНачалаОтчета.Value.ToShortDateString, ААОсновная.ДатаКонцаОтчета.Value.ToShortDateString)
        ДокументВорд.Save
        ПриложениеВорд.Visible = True
    End Sub

    Function ЗагрузитьСписок(Критерий As String, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String) As Object
        Dim Список
        Dim СтрокаЗапроса As String

        If Критерий = "Удостоверение" Then
            СтрокаЗапроса = "SELECT  СоставГрупп.РегНомерУд, СоставГрупп.НомерУд,Группа.Номер, Фамилия,Имя, Отчество, Программа, КолЧас, ДатаКЗ, ДатаВыдачиУд FROM (СоставГрупп INNER JOIN Слушатель On СоставГрупп.Слушатель = Слушатель.Снилс) INNER JOIN Группа On СоставГрупп.Kod = Группа.Код WHERE Группа.ОсновнойДокумент= 'Удостоверение' AND NOT ISNULL(составгрупп.РегНомерУд) AND составгрупп.РегНомерУд<>0 AND ДатаВыдачиУд BETWEEN '" & ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаНачалаОтчета)) & "' and  '" & ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаКонцаОтчета)) & " ' ORDER BY СоставГрупп.РегНомерУд"
        End If

        If Критерий = "Диплом" Then
            СтрокаЗапроса = "SELECT СоставГрупп.РегНомерДиплома, СоставГрупп.НомерДиплома,Группа.Номер, Фамилия,Имя, Отчество, Программа, КолЧас, ДатаКЗ, ДатаВыдачиДиплома FROM (СоставГрупп INNER JOIN Слушатель On СоставГрупп.Слушатель = Слушатель.Снилс) INNER JOIN Группа On СоставГрупп.Kod = Группа.Код WHERE Группа.ОсновнойДокумент= 'Диплом' AND NOT ISNULL(составгрупп.РегНомерДиплома) AND составгрупп.РегНомерДиплома<>0 AND составгрупп.РегНомерДиплома<>0 AND ДатаВыдачиДиплома BETWEEN '" & ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаНачалаОтчета)) & "' and  '" & ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаКонцаОтчета)) & " '  and ОсновнойДокумент= 'Диплом' ORDER BY СоставГрупп.РегНомерДиплома"
        End If

        If Критерий = "Свидетельство" Then
            СтрокаЗапроса = "SELECT  СоставГрупп.РегНомерСвид, СоставГрупп.НомерСвид,Группа.Номер, Фамилия,Имя, Отчество, Программа, КолЧас, ДатаКЗ, ДатаВыдачиСвид FROM (СоставГрупп INNER JOIN Слушатель On СоставГрупп.Слушатель = Слушатель.Снилс) INNER JOIN Группа On СоставГрупп.Kod = Группа.Код WHERE  Группа.ОсновнойДокумент= 'Свидетельство' AND NOT ISNULL(составгрупп.РегНомерСвид) AND составгрупп.РегНомерСвид<>0 AND ДатаВыдачиСвид BETWEEN '" & ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаНачалаОтчета)) & "' and  '" & ААОсновная.mySqlConnect.dateToFormatMySQL(Convert.ToDateTime(ДатаКонцаОтчета)) & " '  and ОсновнойДокумент= 'Свидетельство' ORDER BY СоставГрупп.РегНомерСвид"
        End If

        Список = УбратьПустотыВМассиве.УбратьПустотыВМассиве(ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса))

        If Список(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            ОткрытьФорму(предупреждение)
            ЗагрузитьСписок = Список
            Exit Function

        End If
        ЗагрузитьСписок = Список
    End Function

    Sub ЗаполнитьТаблицу(Таблица As Object, Массив As Object, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String)

        Dim СчетчикСтрок As Integer

        Таблица.Cell(2, 1).Range.text = "за период с " & ДатаНачалаОтчета & " по " & ДатаКонцаОтчета

        For НомерСтолбца = 1 To Таблица.Columns.Count - 2
            Таблица.Cell(6, НомерСтолбца).Range.text = Массив(НомерСтолбца - 1, 0)
        Next
        СчетчикСтрок = UBound(Массив, 2)


        For НомерСтроки = 1 To UBound(Массив, 2)
            Таблица.Rows.add
            For НомерСтолбца = 1 To Таблица.Columns.Count - 2
                'If НомерСтолбца = 1 Then
                'Таблица.Cell(6 + НомерСтроки, НомерСтолбца).Range.text = НомерСтроки + 1
                'Else
                Таблица.Cell(6 + НомерСтроки, НомерСтолбца).Range.text = Массив(НомерСтолбца - 1, НомерСтроки)
                'End If
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
