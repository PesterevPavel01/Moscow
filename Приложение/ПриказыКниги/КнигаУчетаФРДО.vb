﻿Module КнигаУчетаФРДО

    Sub КнигаУчета(Критерий As String)
        Dim ПриложениеЭксель, ОбъектыЭксель, Шаблон, ФорматированиеСтолбцов
        Dim КнигаЭксель, Координаты
        Dim ЛистЭксель, Массив, Obl, mass
        Dim ПутьКШаблону, ПутьКНовомуФайлу, ПутьККаталогуСРесурсами, Название, ТитульнаяСтрока, Адресс As String

        If Критерий = "Удостоверение" Then
            Название = " удостоверений "
            ТитульнаяСтрока = "Книга учёта выданных удостоверений о повышении квалификации"
        End If

        If Критерий = "Диплом" Then
            Название = " дипломов "
            ТитульнаяСтрока = "Книга учёта выданных дипломов о профессиональной переподготовке"
        End If

        If Критерий = "Свидетельство" Then
            Название = " свидетельств "
            ТитульнаяСтрока = "Книга учёта выданных свидетельств о профессии рабочего, должности служащего"
        End If

        Массив = ЗагрузитьСписок(Критерий, ААОсновная.mySqlConnect.dateToFormatMySQL(ААОсновная.ДатаНачалаОтчета.Value.ToShortDateString), ААОсновная.mySqlConnect.dateToFormatMySQL(ААОсновная.ДатаКонцаОтчета.Value.ToShortDateString))


        If Массив(0, 0).ToString = "нет записей" Then
            Exit Sub
        End If

        Массив = ДобавитьРубашкуСПробеломВКонцеВМассив(Массив, 16)

        ПутьККаталогуСРесурсами = Вспомогательный.ПутьККаталогуСРесурсами()
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\Книга учёта выданных" & Название & "ФРДО.xlsx"
        ПутьКНовомуФайлу = ПутьККаталогуСРесурсами & "Отчеты\Книги Учета"
        ОбъектыЭксель = Вспомогательный.СозданиеКнигиЭксельИЛИОшибкаВ0(ПутьКНовомуФайлу, "Книга учёта выданных" & Название & " ФРДО")

        If ОбъектыЭксель(0).ToString = "Ошибка" Then
            Exit Sub
        End If

        ПриложениеЭксель = ОбъектыЭксель(0)
        КнигаЭксель = ОбъектыЭксель(1)

        Шаблон = ПриложениеЭксель.Workbooks.Open(ПутьКШаблону, ReadOnly:=True)
        Шаблон.Worksheets(1).copy(before:=КнигаЭксель.Worksheets(1))
        Шаблон.Close

        ЛистЭксель = КнигаЭксель.Worksheets(1)
        ЛистЭксель.name = Критерий
        ФорматированиеСтолбцов = Вспомогательный.НастройкиРедактированияСтолбца(ЛистЭксель, ЛистЭксель.ListObjects("Таблица"))
        Адресс = ЛистЭксель.ListObjects("Таблица").Range.Address
        Координаты = Split(Адресс, ":")
        Массив = ДобавитьНулиСпередиМвссив(Массив, 2, 5)
        Массив = УбратьПустотыВМассиве.УбратьПустотыВМассиве(перевернутьмассив(Массив))
        ЛистЭксель.Range("A1") = ТитульнаяСтрока
        ЛистЭксель.Range("A2") = "за период с " & ААОсновная.ДатаНачалаОтчета.Value.ToShortDateString & " по " & ААОсновная.ДатаКонцаОтчета.Value.ToShortDateString & "г."

        Массив = ЗаменитьДатуНаГод(Массив, 8)
        Массив = ЗаменитьДатуНаГод(Массив, 9)

        Dim i As Integer = UBound(Массив, 1) + 1
        Dim j As Integer = UBound(Массив, 2) + 1

        Dim count As Integer = 0
        Dim flag = True

        Obl = КнигаЭксель.Worksheets(2).Range("C1").Resize(UBound(Массив, 1) + 10, 1)
        Obl.NumberFormat = "@"

        mass = ВзятьЧастьМассива(Массив, 0, i - 1)
        КнигаЭксель.Worksheets(2).Range("A1").Resize(i, UBound(Массив, 2) + 1) = mass
        КнигаЭксель.Worksheets(2).Range("A1").Resize(i, UBound(Массив, 2) + 1).cut(ЛистЭксель.Range("A6"))

        НастроитьРедактированияСтолбца(ЛистЭксель, ЛистЭксель.ListObjects("Таблица"), ФорматированиеСтолбцов)

        With ЛистЭксель.ListObjects("Таблица").Range
            .WrapText = True
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .HorizontalAlignment = -4131
        End With
        ПриложениеЭксель.visible = True
        Obl = ЛистЭксель.ListObjects("Таблица")
        Obl = Obl.ListColumns(1).Range
        Obl.NumberFormat = "0.00"
        Obl.NumberFormat = "0"

        ПриложениеЭксель.visible = True
        КнигаЭксель.Save
    End Sub

    Function ЗагрузитьСписок(Критерий As String, ДатаНачалаОтчета As String, ДатаКонцаОтчета As String) As Object
        Dim Список
        Dim СтрокаЗапроса As String

        If Критерий = "Удостоверение" Then
            СтрокаЗапроса = "SELECT СоставГрупп.НомерУд, ДатаВыдачиУд, СоставГрупп.РегНомерУд, Программа, Слушатель.УОбразования, ФамилияДОО, СерияДОО, НомерДОО, ДатаНЗ, ДатаКЗ, КолЧас, Фамилия, Имя, Отчество, ДатаРождения, Пол, СНИЛС, ФормаО, ИФин, Гражданство  FROM (СоставГрупп INNER JOIN Слушатель On СоставГрупп.Слушатель = Слушатель.Снилс) INNER JOIN Группа On СоставГрупп.Kod = Группа.Код WHERE Группа.ОсновнойДокумент= 'Удостоверение'   AND NOT ISNULL(составгрупп.РегНомерУд) AND составгрупп.РегНомерУд<>0 AND ДатаВыдачиУд BETWEEN '" & ДатаНачалаОтчета & "' and '" & ДатаКонцаОтчета & " ' ORDER BY СоставГрупп.РегНомерУд"
        End If

        If Критерий = "Диплом" Then
            СтрокаЗапроса = "SELECT СоставГрупп.НомерДиплома ,ДатаВыдачиДиплома,СоставГрупп.РегНомерДиплома, Программа,Слушатель.УОбразования, ФамилияДОО, СерияДОО, НомерДОО, ДатаНЗ, ДатаКЗ, КолЧас, Фамилия, Имя, Отчество, ДатаРождения, Пол, СНИЛС, ФормаО, ИФин, Гражданство FROM (СоставГрупп INNER JOIN Слушатель On СоставГрупп.Слушатель = Слушатель.Снилс) INNER JOIN Группа On СоставГрупп.Kod = Группа.Код WHERE Группа.ОсновнойДокумент= 'Диплом'  AND NOT ISNULL(составгрупп.РегНомерДиплома) AND составгрупп.РегНомерДиплома<>0 AND ДатаВыдачиДиплома BETWEEN '" & ДатаНачалаОтчета & "' and '" & ДатаКонцаОтчета & " ' and ОсновнойДокумент= 'Диплом' ORDER BY СоставГрупп.РегНомерДиплома"
        End If

        If Критерий = "Свидетельство" Then
            СтрокаЗапроса = "SELECT  СоставГрупп.НомерСвид ,ДатаВыдачиСвид,СоставГрупп.РегНомерСвид, Программа,Слушатель.УОбразования, ФамилияДОО, СерияДОО, НомерДОО, ДатаНЗ, ДатаКЗ, КолЧас, Фамилия, Имя, Отчество, ДатаРождения, Пол, СНИЛС, ФормаО, ИФин, Гражданство FROM (СоставГрупп INNER JOIN Слушатель On СоставГрупп.Слушатель = Слушатель.Снилс) INNER JOIN Группа On СоставГрупп.Kod = Группа.Код WHERE  Группа.ОсновнойДокумент= 'Свидетельство' AND NOT ISNULL(составгрупп.РегНомерСвид) AND составгрупп.РегНомерСвид<>0 AND ДатаВыдачиСвид BETWEEN '" & ДатаНачалаОтчета & "' and '" & ДатаКонцаОтчета & " ' and ОсновнойДокумент= 'Свидетельство' ORDER BY СоставГрупп.РегНомерСвид"
        End If

        Список = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Список(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            ОткрытьФорму(предупреждение)
            ЗагрузитьСписок = Список
            Exit Function

        End If
        ЗагрузитьСписок = Список
    End Function

End Module
