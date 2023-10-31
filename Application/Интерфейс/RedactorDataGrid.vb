Module RedactorDataGrid

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

    Sub listIntoComboBox(table As DataGridView, ist As Object, name As String)
        Dim array
        'Dim listComboBox As New DataGridViewComboBoxColumn
        ReDim array(UBound(ist, 2))
        'Dim count As Int16 = listComboBox.Items.Count
        'listComboBox.Items.Clear()
        'listComboBox.Items.AddRange(ist)

        For i = 0 To UBound(ist, 2)
            array(i) = ist(0, i)
        Next

        For Each column In table.Columns
            If column.name = name Then
                column.items.Clear()
                column.items.AddRange(array)
                Exit Sub
            End If
        Next
    End Sub
    Function sumInColumn(ДатаГрид As DataGridView, НомерСтолбца As Integer) As Double
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
        sumInColumn = Сумма
    End Function

    Function sumInRow(ДатаГрид As DataGridView, НомерСтроки As Integer, НомерПервогоСтолбца As Integer, НомерПоследнегоСтолбца As Integer) As Double
        Dim Сумма As Double = 0
        Dim СчетчикСтолбцов As Integer = НомерПервогоСтолбца

        While СчетчикСтолбцов <= НомерПоследнегоСтолбца
            Try
                Сумма += CDbl(Strings.Replace(ДатаГрид.Rows(НомерСтроки).Cells(СчетчикСтолбцов).Value, ".", ","))
            Catch ex As Exception
                Warning.content.Text = "Значение ячейки (" & СчетчикСтолбцов + 1 & "," & НомерСтроки + 1 & ") не является числом"
                openForm(Warning)
                sumInRow = -1
                Exit Function
            End Try
            СчетчикСтолбцов += 1
        End While
        sumInRow = Сумма
    End Function

    Sub arrayToDataGrid(ДатаГрид As DataGridView, Массив As Object)

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
