Public Class DGVBuilder

    Public columnWidht As Dictionary(Of Int16, Int16)
    Public columnAlignment As Dictionary(Of Int16, DataGridViewContentAlignment)

    Public table As DataGridView
    Public parent As Control

    Public Sub resizeTables()

        If IsNothing(table.DataSource) Then
            Return
        ElseIf table.Columns.Count < 2 Then
            Return
        End If

        Dim count As Int16 = 0

        For Each column As DataGridViewColumn In table.Columns

            If columnWidht(count) = 0 Then Return
            table.Columns(count).Width = parent.Width * columnWidht(count) / 100
            table.Columns(count).DefaultCellStyle.Alignment = columnAlignment(count)
            table.Columns(count).HeaderCell.Style.Alignment = columnAlignment(count)
            count += 1

        Next

    End Sub

End Class
