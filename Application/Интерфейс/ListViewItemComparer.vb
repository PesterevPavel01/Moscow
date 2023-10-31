Public Class ListViewItemComparer
    Implements IComparer

    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub

    Public Sub New(column As Integer,sortOrder As SortOrder)
        col = column
        order = SortOrder
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        'Throw New NotImplementedException()
        Dim returnVal As Integer = -1
        If IsDate(CType(x, ListViewItem).SubItems(col).Text) And IsDate(CType(y, ListViewItem).SubItems(col).Text) Then

            Dim firstDate As DateTime = DateTime.Parse(CType(x, ListViewItem).SubItems(col).Text)
            Dim secondDate As DateTime = DateTime.Parse(CType(y, ListViewItem).SubItems(col).Text)
            returnVal = DateTime.Compare(firstDate, secondDate)

        ElseIf IsNumeric(CType(x, ListViewItem).SubItems(col).Text) And IsNumeric(CType(y, ListViewItem).SubItems(col).Text) Then

            Try
                returnVal = Val(CType(x, ListViewItem).SubItems(col).Text).CompareTo(Val(CType(y, ListViewItem).SubItems(col).Text))
            Catch ex As Exception
            End Try

        Else

            Try
                returnVal = [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
            Catch ex1 As Exception
            End Try

        End If

        If order = SortOrder.Descending Then
            returnVal *= -1
        End If


        Return returnVal

    End Function
End Class
