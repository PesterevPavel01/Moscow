Module ДействияСДатаГрид

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
