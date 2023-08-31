Module updateListView

    Public arrayEmpty As Boolean

    Sub listViewColoriz(listV As ListView, array As Object)

        Dim count As Integer = 0
        For Each item In listV.Items
            For Each elem As String In array
                Dim text As String = item.SubItems(3).Text
                If item.SubItems(3).Text = elem Then
                    item.BackColor = Color.LightGray
                End If
            Next
        Next

    End Sub

    Sub updateListView(labelEditOn As Boolean, addNumbers As Boolean, listV As ListView, array As Object, Optional indexFirstCol As Integer = 11111111, Optional indexSecondCol As Integer = 11111111, Optional indexThirdCol As Integer = 11111111, Optional indexFourRCol As Integer = 11111111, Optional indexFifthCol As Integer = 11111111, Optional indexSixthCol As Integer = 11111111, Optional indexSeventhCol As Integer = 11111111)
        Dim y As Long
        Dim x As Long, number As Long

        listV.Items.Clear()
        listV.LabelEdit = labelEditOn

        Try
            If arrayEmpty Or array(0, 0).ToString = "нет записей" Or array(0, 0).ToString = "нет- за-пис-ей" Then
                arrayEmpty = False
                Exit Sub
            End If

        Catch ex As Exception
            arrayEmpty = False
            Exit Sub
        End Try

        y = UBound(array, 2)

        x = 0

        Try
            number = MainForm.maxNumberRows.Text
        Catch ex As Exception

            Warning.content.Text = "Настройки. Количество отображаемых строк в справочнике должно быть числом"
            openForm(Warning)
            Exit Sub

        End Try

        If y > MainForm.maxNumberRows.Text Then y = MainForm.maxNumberRows.Text


        While x <= y

            If addNumbers Then

                listV.Items.Add(x + 1)

                listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexFirstCol, x))
                If Not indexSecondCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexSecondCol, x))
                If Not indexThirdCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexThirdCol, x))
                If Not indexFourRCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexFourRCol, x))
                If Not indexFifthCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexFifthCol, x))
                If Not indexSixthCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexSixthCol, x))
                If Not indexSeventhCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexSeventhCol, x))

            Else

                listV.Items.Add(array(indexFirstCol, x))
                If Not indexSecondCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexSecondCol, x))
                If Not indexThirdCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexThirdCol, x))
                If Not indexFourRCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexFourRCol, x))
                If Not indexFifthCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexFifthCol, x))
                If Not indexSixthCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexSixthCol, x))
                If Not indexSeventhCol = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(array(indexSeventhCol, x))


            End If

            x = x + 1

        End While

        arrayEmpty = False

    End Sub

    Sub chekAllItem(listV As ListView)

        For Each item As ListViewItem In listV.Items
            item.Checked = True
        Next

    End Sub

    Function ЗаписатьЧекнутыеСтроки(listV As ListView, numberFirstCol As Integer, Optional numberSecondCol As Integer = 1111111, Optional numberThirdCol As Integer = 1111111) As Object
        Dim Список
        Dim счетчик As Integer = 0

        Try
            listV.Items(0).Selected = True
        Catch ex1 As Exception
            ReDim Список(1, 1)
            Список(0, 0) = "нет записей"
            ЗаписатьЧекнутыеСтроки = Список
            Exit Function
        End Try

        If listV.CheckedItems.Count = 0 Then
            ReDim Список(1, 1)
            Список(0, 0) = "нет записей"
            ЗаписатьЧекнутыеСтроки = Список
            Exit Function
        End If

        If listV.CheckedItems.Item(0).Text = "Выделить всех" Then
            If numberSecondCol = 1111111 Then
                ReDim Список(0, listV.CheckedItems.Count - 2)
            ElseIf numberThirdCol = 1111111 Then
                ReDim Список(1, listV.CheckedItems.Count - 2)
            Else
                ReDim Список(2, listV.CheckedItems.Count - 2)
            End If
        Else
            If numberSecondCol = 1111111 Then
                ReDim Список(0, listV.CheckedItems.Count - 1)
            ElseIf numberThirdCol = 1111111 Then
                ReDim Список(1, listV.CheckedItems.Count - 1)
            Else
                ReDim Список(2, listV.CheckedItems.Count - 1)
            End If
        End If


        For Each item In listV.CheckedItems

            If item.Text = "Выделить всех" Then
                Continue For
            End If

            If numberFirstCol = 0 Then
                Список(0, счетчик) = item.Text
            Else
                Список(0, счетчик) = item.SubItems(numberFirstCol).Text
            End If

            If Not numberSecondCol = 1111111 Then
                Список(1, счетчик) = item.SubItems(numberSecondCol).Text
            ElseIf Not numberThirdCol = 1111111 Then
                Список(1, счетчик) = item.SubItems(numberThirdCol).Text
            End If
            счетчик += 1

        Next

        ЗаписатьЧекнутыеСтроки = Список

    End Function

    Sub updateListV(argument As Object)

        Dim indForm As Form, listV As ListView, list As Object, индексСТ1, индексСТ2, индексСТ3, индексСТ4, индексСТ5, индексСТ6, индексСТ7 As Integer
        Dim y As Long
        Dim x As Long, число As Long

        indForm = argument(0)
        listV = argument(1)
        list = argument(2)
        индексСТ1 = argument(3)

        Try
            индексСТ2 = argument(4)
        Catch ex As Exception
            индексСТ2 = 11111111
        End Try

        Try
            индексСТ3 = argument(5)
        Catch ex As Exception
            индексСТ3 = 11111111
        End Try

        Try
            индексСТ4 = argument(6)
        Catch ex As Exception
            индексСТ4 = 11111111
        End Try

        Try
            индексСТ5 = argument(7)
        Catch ex As Exception
            индексСТ5 = 11111111
        End Try

        Try
            индексСТ6 = argument(8)
        Catch ex As Exception
            индексСТ6 = 11111111
        End Try

        Try
            индексСТ7 = argument(9)
        Catch ex As Exception
            индексСТ7 = 11111111
        End Try

        listV.Items.Clear()

        Try
            If arrayEmpty Or list(0, 0).ToString = "нет записей" Or list(0, 0).ToString = "нет- за-пис-ей" Then
                arrayEmpty = False
                Exit Sub
            End If

        Catch ex As Exception
            arrayEmpty = False
            Exit Sub
        End Try

        y = UBound(list, 2)

        x = 0

        Try
            число = MainForm.maxNumberRows.Text
        Catch ex As Exception

            Warning.content.Text = "Настройки. Количество отображаемых строк в справочнике должно быть числом"
            openForm(Warning)
            Exit Sub

        End Try

        If y > MainForm.maxNumberRows.Text Then y = MainForm.maxNumberRows.Text


        While x <= y

            listV.Items.Add(x + 1)

            listV.Items(listV.Items.Count - 1).SubItems.Add(list(индексСТ1, x))

            If Not индексСТ2 = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(list(индексСТ2, x))
            If Not индексСТ3 = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(list(индексСТ3, x))
            Try
                If Not индексСТ4 = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(list(индексСТ4, x))
            Catch ex As Exception
                Dim i As Int16 = 1
            End Try
            If Not индексСТ5 = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(list(индексСТ5, x))
            If Not индексСТ6 = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(list(индексСТ6, x))
            If Not индексСТ7 = 11111111 Then listV.Items(listV.Items.Count - 1).SubItems.Add(list(индексСТ7, x))

            x += 1

        End While

        If listV.Columns.Count > 0 Then
            listV.Items(0).Selected = True
        End If

        arrayEmpty = False

    End Sub

    Sub updateRow(indForm As String, Optional индексСТ1 As Integer = 11111111, Optional ЗначениеСТ1 As String = "11111111", Optional индексСТ2 As Integer = 11111111, Optional ЗначениеСТ2 As String = "11111111", Optional индексСТ3 As Integer = 11111111, Optional ЗначениеСТ3 As String = "11111111", Optional индексСТ4 As Integer = 11111111, Optional ЗначениеСТ4 As String = "11111111", Optional индексСТ5 As Integer = 11111111, Optional ЗначениеСТ5 As String = "11111111", Optional индексСТ6 As Integer = 11111111, Optional индексСТ7 As Integer = 11111111, Optional ЗначениеСТ6 As String = "11111111")
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

            ListV = StudentsInGroup.ListViewStudentsList

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
