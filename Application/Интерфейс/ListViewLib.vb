Module ListViewLib
    Sub checkAllRow(listV As ListView, textItemFlag As String, checkedItem As ListViewItem)

        If Not textItemFlag = checkedItem.Text Then

            If checkedItem.Checked = False Then

                For Each listViewItem As ListViewItem In listV.Items

                    If listViewItem.Text = textItemFlag Then
                        If listViewItem.Checked Then
                            BuildOrder.flagCheck = False
                            listViewItem.Checked = False
                            Return
                        End If
                    End If

                Next

            End If

            Return

        End If

        Dim flag As Boolean = checkedItem.Checked

        For Each listViewItem As ListViewItem In listV.Items

            listViewItem.Checked = flag

        Next

        Return

    End Sub

    Sub checkRow(listV As ListView)

        If listV.SelectedItems.Count <= 0 Then Return
        listV.SelectedItems(0).Checked = Not listV.SelectedItems(0).Checked

    End Sub
End Module
