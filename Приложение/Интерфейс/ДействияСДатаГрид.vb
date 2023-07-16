﻿Module ДействияСДатаГрид

    Function dataGridViewSearchRow(dataGridViewRows As DataGridViewRowCollection, columnNumber As Integer, value As String) As Integer
        Dim number As Integer
        For Each row As DataGridViewRow In dataGridViewRows
            If Convert.ToString(row.Cells(columnNumber).Value) = value Then
                number = row.Index
                Return number
            End If
        Next
        Return number
    End Function

    Sub ЗагрузитьСписокВКомбоБокс(ДатаГрид As DataGridView, Список As Object, Имя As String)
        Dim Массив
        Dim КомбоБоксСписок As New DataGridViewComboBoxColumn
        ReDim Массив(UBound(Список, 2))
        КомбоБоксСписок.Items.AddRange(Список)

        For i = 0 To UBound(Список, 2)
            Массив(i) = Список(0, i)
        Next


        For Each Колонка In ДатаГрид.Columns
            If Колонка.name = Имя Then
                Колонка.items.AddRange(Массив)
                Exit Sub
            End If
        Next
    End Sub
    Function СуммаЗначенийВСтолбце(ДатаГрид As DataGridView, НомерСтолбца As Integer) As Double
        Dim Сумма As Double = 0
        Dim СчетчикСтрок As Integer = 0
        Dim Значение As String

        For Each Строка In ДатаГрид.Rows

            Значение = Strings.Replace(Строка.Cells(НомерСтолбца).Value, ".", ",")
            Try
                Сумма += CDbl(Strings.Replace(Строка.Cells(НомерСтолбца).Value, ".", ","))
            Catch ex As Exception

            End Try
            СчетчикСтрок += 1
        Next
        СуммаЗначенийВСтолбце = Сумма
    End Function
    Function СуммаЗначенийВСтроке(ДатаГрид As DataGridView, НомерСтроки As Integer, НомерПервогоСтолбца As Integer, НомерПоследнегоСтолбца As Integer) As Double
        Dim Сумма As Double = 0
        Dim СчетчикСтолбцов As Integer = НомерПервогоСтолбца

        While СчетчикСтолбцов <= НомерПоследнегоСтолбца
            Try
                Сумма += CDbl(Strings.Replace(ДатаГрид.Rows(НомерСтроки).Cells(СчетчикСтолбцов).Value, ".", ","))
            Catch ex As Exception
                предупреждение.текст.Text = "Значение ячейки (" & СчетчикСтолбцов + 1 & "," & НомерСтроки + 1 & ") не является числом"
                ОткрытьФорму(предупреждение)
                СуммаЗначенийВСтроке = -1
                Exit Function
            End Try
            СчетчикСтолбцов += 1
        End While
        СуммаЗначенийВСтроке = Сумма
    End Function
    Sub СохранитьПеднагрузку(Ведомость As Object, группа As String)
        Dim Запросы, ФИО, Проверочный
        Dim СтрокаЗапроса, Снилс As String
        Dim Счетчик As Integer = 0, СчетчикСтрок As Integer
        ReDim Запросы(3)

        СчетчикСтрок = Ведомость.Rows.Count
        For i = 0 To СчетчикСтрок
            If IsNothing(ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(1).Value) Then
                Exit For
            End If
            Try
                СтрокаЗапроса = "SELECT СоставГрупп.Слушатель FROM СоставГрупп WHERE СоставГрупп.Слушатель = " & Chr(39) & Снилс & Chr(39) & " AND СоставГрупп.Группа = " & Chr(39) & группа & Chr(39)
            Catch ex As Exception
                Continue For
            End Try
            Проверочный = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)
            If Проверочный(0, 0) = "нет записей" Then
                Continue For
            End If
            Try
                СтрокаЗапроса = "UPDATE СоставГрупп SET ОценкаМодуль1= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(2).Value & Chr(39) & ",ОценкаМодуль2= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(3).Value & Chr(39) & ",ОценкаМодуль3= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(4).Value & Chr(39) & ",ОценкаМодуль4= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(5).Value & Chr(39) & ",ОценкаМодуль5= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(6).Value & Chr(39) & ",ОценкаМодуль6= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(7).Value & Chr(39) & ",ОценкаМодуль7= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(8).Value & Chr(39) & ",ОценкаМодуль8= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(9).Value & Chr(39) & ",ОценкаМодуль9= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(10).Value & Chr(39) & ",ОценкаМодуль10= " & Chr(39) & ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(11).Value & Chr(39) & " WHERE СоставГрупп.Слушатель = " & Chr(39) & Снилс & Chr(39) & " AND СоставГрупп.Группа = " & Chr(39) & группа & Chr(39)
            Catch ex As Exception
                предупреждение.текст.Text = "Информация не была сохранена"
                ОткрытьФорму(предупреждение)
                Exit Sub
            End Try
            ЗаписьВБазу.ЗаписьВБазу(СтрокаЗапроса)
            ReDim Запросы(3)
            Запросы(0) = "Группа"
            Запросы(1) = "SELECT * FROM СоставГрупп WHERE СоставГрупп.Слушатель = " & Chr(39) & Снилс & Chr(39) & " AND СоставГрупп.Группа = " & Chr(39) & группа & Chr(39)
            Запросы(2) = СтрокаЗапроса
            Запросы(3) = СтрокаЗапроса
            Счетчик = Счетчик + 1
        Next


    End Sub

    Sub ЗаписьМассиваВДатаГрид(ДатаГрид As DataGridView, Массив As Object)
        Dim СчетчикСтрок As Integer

        ДатаГрид.Rows.Clear()

        СчетчикСтрок = UBound(Массив, 2)

        ДатаГрид.Rows.Add(UBound(Массив, 2) + 1)

        For Счетчик = 0 To UBound(Массив, 2)

            For счетчикСтолбцов = 0 To UBound(Массив, 1)
                ДатаГрид.Rows(Счетчик).Cells(счетчикСтолбцов).Value = CStr(Массив(счетчикСтолбцов, Счетчик))
            Next
        Next
    End Sub



End Module
