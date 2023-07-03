Imports System.Data.SqlTypes

Public Class Tables_control

    Public kod_number As Int16
    Private remove_kod As Int64
    Public name_table As String
    Public queryString_load As String
    Private result As New DataTable
    Public persent_width_column_0 As Int16
    Public persent_width_column_1 As Int16 = -1
    Public persent_width_column_2 As Int16 = -1

    Dim mySQLConnector As New MySQLConnect


    Private Sub DataGridTables_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridTables.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Public Sub load_table()

        result = mySQLConnector.ЗагрузитьИзMySQLвDataTable(queryString_load, 1)

        DataGridTables.DataSource = result

        bild_table()

    End Sub

    Private Sub bild_table()

        If persent_width_column_2 <> -1 Then

            If persent_width_column_2 = 1 Then

                DataGridTables.Columns(2).Width = 1

            Else

                DataGridTables.Columns(2).Width = DataGridTables.Width * persent_width_column_2 / 100

            End If

            DataGridTables.Columns(0).Width = DataGridTables.Width * persent_width_column_0 / 100
            DataGridTables.Columns(1).Width = DataGridTables.Width * persent_width_column_1 / 100

        ElseIf persent_width_column_1 <> -1 Then

            DataGridTables.Columns(0).Width = DataGridTables.Width * persent_width_column_0 / 100
            DataGridTables.Columns(1).Width = DataGridTables.Width * persent_width_column_1 / 100

        Else

            DataGridTables.Columns(0).Width = DataGridTables.Width * persent_width_column_0 / 100

        End If

    End Sub


    Private Function update_delete_query() As String

        Dim queryString As String = ""
        queryString = "DELETE FROM " + name_table + " WHERE kod=" + remove_kod
        Return queryString

    End Function

    Private Sub DataGridTables_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridTables.KeyDown

        If e.KeyValue = Keys.Delete Then

            Dim curNumber = DataGridTables.CurrentCell.RowIndex
            ФормаДаНетУдалить.текстДаНет.Text = "Удалить " + DataGridTables.Rows(curNumber).Cells(0).Value + "?"
            ФормаДаНетУдалить.ShowDialog()

            If Not ФормаДаНетУдалить.НажатаКнопкаДа Then
                Return
            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

            remove_kod = Convert.ToInt64(DataGridTables.Rows(curNumber).Cells(1).Value)



            '    If Not Doljnosti.removeDoljnost() Then

            '        предупреждение.TextBox.Visible = False
            '        предупреждение.текст.Visible = True
            '        предупреждение.текст.Text = "Должность не может быть удалена"
            '        предупреждение.ShowDialog()
            '        Return

            '    End If


            '    If redactor_doljnost.Text.Trim = Convert.ToString(DataGridDoljnost.Rows(curNumber).Cells(0).Value) Then

            '        SendKeys.Send("{ESC}")

            '    End If

            '    ToolStrip_name_list_SelectedIndexChanged(sender, e)

            '    If (curNumber <> 0) Then

            '        DataGridDoljnost.CurrentCell = DataGridDoljnost.Rows(curNumber - 1).Cells(0)

            '    End If

            'ElseIf e.KeyValue = Keys.Add Then

            '    If Not ToolStrip_name_list.Text.Trim = "" Then

            '        redactor_doljnost.Clear()
            '        redactor_full_name.Clear()
            '        other_add_Click(sender, e)

            '    End If

            'ElseIf e.KeyValue = Keys.R Then

            '    If Not ToolStrip_name_list.Text.Trim = "" Then

            '        Dim e1 As DataGridViewCellEventArgs
            '        DataGridDoljnost_CellDoubleClick(sender, e1)

            '    End If

            'ElseIf e.KeyValue = Keys.Tab Then

            '    If SplitContainerOtherList.Panel2Collapsed Then

            '        ToolStrip_name_list.Focus()
            '        e.Handled = True

            '    Else

            '        redactor_doljnost.Focus()
            '        e.Handled = True

            '    End If

        End If

    End Sub

    Private Sub DataGridTables_SizeChanged(sender As Object, e As EventArgs) Handles DataGridTables.SizeChanged

        bild_table()

    End Sub
End Class
