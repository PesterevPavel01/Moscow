Module ИзменениеВыделеннойСтрокиВListView

    Sub ИзменениеВыделеннойСтрокиВListView(indForm As String, Optional индексСТ1 As Integer = 11111111, Optional ЗначениеСТ1 As String = "11111111", Optional индексСТ2 As Integer = 11111111, Optional ЗначениеСТ2 As String = "11111111", Optional индексСТ3 As Integer = 11111111, Optional ЗначениеСТ3 As String = "11111111", Optional индексСТ4 As Integer = 11111111, Optional ЗначениеСТ4 As String = "11111111", Optional индексСТ5 As Integer = 11111111, Optional ЗначениеСТ5 As String = "11111111", Optional индексСТ6 As Integer = 11111111, Optional индексСТ7 As Integer = 11111111, Optional ЗначениеСТ6 As String = "11111111")
        Dim ListV As ListView
        Dim y As Integer
        Dim nomer As Integer

        If indForm = "СправочникГруппы" Then

            ListV = GroupList.groupListTable

        End If

        If indForm = "СправочникСлушатели" Then

            ListV = studentsList.ListViewСписокСлушателей

        End If

        If indForm = "List" Then

            ListV = List.resultList

        End If

        If indForm = "СписокСлушателейВГруппе" Then

            ListV = StudentList.ListViewStudentsList

        End If
        Try
            nomer = CInt(ListV.SelectedItems.Item(0).SubItems(0).Text)
        Catch ex As Exception
            Exit Sub
        End Try

        ListV.Items(nomer - 1).SubItems.Item(индексСТ1).Text = ЗначениеСТ1
        If Not индексСТ2 = 11111111 Then ListV.Items(nomer - 1).SubItems.Item(индексСТ2).Text = ЗначениеСТ2
        If Not индексСТ3 = 11111111 Then ListV.Items(nomer - 1).SubItems.Item(индексСТ3).Text = ЗначениеСТ3
        If Not индексСТ4 = 11111111 Then ListV.Items(nomer - 1).SubItems.Item(индексСТ4).Text = ЗначениеСТ4
        If Not индексСТ5 = 11111111 Then ListV.Items(nomer - 1).SubItems.Item(индексСТ5).Text = ЗначениеСТ5
        If Not индексСТ6 = 11111111 Then ListV.Items(nomer - 1).SubItems.Item(индексСТ6).Text = ЗначениеСТ6

    End Sub




End Module
