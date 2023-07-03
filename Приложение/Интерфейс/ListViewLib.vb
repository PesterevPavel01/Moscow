Module ListViewLib
    Sub checkAllRow(listV As ListView, textItemFlag As String, checkedItem As ListViewItem)

        If Not textItemFlag = checkedItem.Text Then

            If checkedItem.Checked = False Then

                For Each listViewItem As ListViewItem In listV.Items

                    If listViewItem.Text = textItemFlag Then
                        If listViewItem.Checked Then
                            АСформироватьПриказ.flagCheck = False
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
End Module
