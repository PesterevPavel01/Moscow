Module ЗаписьВListView

    Public массивПуст As Boolean

    Sub listViewColoriz(ЛистВью As ListView, mass As Object)
        Dim count As Integer = 0
        For Each item In ЛистВью.Items
            For Each elem As String In mass
                Dim text As String = item.SubItems(3).Text
                If item.SubItems(3).Text = elem Then
                    item.BackColor = Color.LightGray
                End If
            Next
        Next


    End Sub

    Sub ЗаписьВListView(ВключитьLabelEdit As Boolean, ВключитьНумерацию As Boolean, ЛистВью As ListView, список As Object, Optional индексСТ1 As Integer = 11111111, Optional индексСТ2 As Integer = 11111111, Optional индексСТ3 As Integer = 11111111, Optional индексСТ4 As Integer = 11111111, Optional индексСТ5 As Integer = 11111111, Optional индексСТ6 As Integer = 11111111, Optional индексСТ7 As Integer = 11111111)
        Dim y As Long
        Dim x As Long, число As Long

        ЛистВью.Items.Clear()
        ЛистВью.LabelEdit = ВключитьLabelEdit

        Try
            If массивПуст Or список(0, 0).ToString = "нет записей" Or список(0, 0).ToString = "нет- за-пис-ей" Then
                массивПуст = False
                Exit Sub
            End If

        Catch ex As Exception
            массивПуст = False
            Exit Sub
        End Try

        y = UBound(список, 2)

        x = 0

        Try
            число = ААОсновная.КоличествоСтрокВТаблице.Text
        Catch ex As Exception

            предупреждение.текст.Text = "Настройки. Количество отображаемых строк в справочнике должно быть числом"
            ОткрытьФорму(предупреждение)
            Exit Sub

        End Try

        If y > ААОсновная.КоличествоСтрокВТаблице.Text Then y = ААОсновная.КоличествоСтрокВТаблице.Text


        While x <= y

            If ВключитьНумерацию Then

                ЛистВью.Items.Add(x + 1)

                ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ1, x))
                If Not индексСТ2 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ2, x))
                If Not индексСТ3 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ3, x))
                If Not индексСТ4 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ4, x))
                If Not индексСТ5 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ5, x))
                If Not индексСТ6 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ6, x))
                If Not индексСТ7 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ7, x))

            Else

                ЛистВью.Items.Add(список(индексСТ1, x))
                If Not индексСТ2 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ2, x))
                If Not индексСТ3 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ3, x))
                If Not индексСТ4 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ4, x))
                If Not индексСТ5 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ5, x))
                If Not индексСТ6 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ6, x))
                If Not индексСТ7 = 11111111 Then ЛистВью.Items(ЛистВью.Items.Count - 1).SubItems.Add(список(индексСТ7, x))


            End If

            x = x + 1

        End While

        массивПуст = False

    End Sub

    Sub chekAllItem(listV As ListView)

        For Each item As ListViewItem In listV.Items
            item.Checked = True
        Next

    End Sub

    Function ЗаписатьЧекнутыеСтроки(ЛистВью As ListView, НомерСтолбца1 As Integer, Optional НомерСтолбца2 As Integer = 1111111, Optional НомерСтолбца3 As Integer = 1111111) As Object
        Dim Список
        Dim счетчик As Integer = 0

        Try
            ЛистВью.Items(0).Selected = True
        Catch ex1 As Exception
            ReDim Список(1, 1)
            Список(0, 0) = "нет записей"
            ЗаписатьЧекнутыеСтроки = Список
            Exit Function
        End Try

        If ЛистВью.CheckedItems.Count = 0 Then
            ReDim Список(1, 1)
            Список(0, 0) = "нет записей"
            ЗаписатьЧекнутыеСтроки = Список
            Exit Function
        End If

        If ЛистВью.CheckedItems.Item(0).Text = "Выделить всех" Then
            If НомерСтолбца2 = 1111111 Then
                ReDim Список(0, ЛистВью.CheckedItems.Count - 2)
            ElseIf НомерСтолбца3 = 1111111 Then
                ReDim Список(1, ЛистВью.CheckedItems.Count - 2)
            Else
                ReDim Список(2, ЛистВью.CheckedItems.Count - 2)
            End If
        Else
            If НомерСтолбца2 = 1111111 Then
                ReDim Список(0, ЛистВью.CheckedItems.Count - 1)
            ElseIf НомерСтолбца3 = 1111111 Then
                ReDim Список(1, ЛистВью.CheckedItems.Count - 1)
            Else
                ReDim Список(2, ЛистВью.CheckedItems.Count - 1)
            End If
        End If


        For Each item In ЛистВью.CheckedItems

            If item.Text = "Выделить всех" Then
                Continue For
            End If

            If НомерСтолбца1 = 0 Then
                Список(0, счетчик) = item.Text
            Else
                Список(0, счетчик) = item.SubItems(НомерСтолбца1).Text
            End If

            If Not НомерСтолбца2 = 1111111 Then
                Список(1, счетчик) = item.SubItems(НомерСтолбца2).Text
            ElseIf Not НомерСтолбца3 = 1111111 Then
                Список(1, счетчик) = item.SubItems(НомерСтолбца3).Text
            End If
            счетчик += 1

        Next

        ЗаписатьЧекнутыеСтроки = Список

    End Function

    Sub ЗаписьВListView2Поток(Параметр As Object)

        Dim indForm As Form, ListV As ListView, список As Object, индексСТ1, индексСТ2, индексСТ3, индексСТ4, индексСТ5, индексСТ6, индексСТ7 As Integer
        Dim y As Long
        Dim x As Long, число As Long

        indForm = Параметр(0)
        ListV = Параметр(1)
        список = Параметр(2)
        индексСТ1 = Параметр(3)

        Try
            индексСТ2 = Параметр(4)
        Catch ex As Exception
            индексСТ2 = 11111111
        End Try

        Try
            индексСТ3 = Параметр(5)
        Catch ex As Exception
            индексСТ3 = 11111111
        End Try

        Try
            индексСТ4 = Параметр(6)
        Catch ex As Exception
            индексСТ4 = 11111111
        End Try

        Try
            индексСТ5 = Параметр(7)
        Catch ex As Exception
            индексСТ5 = 11111111
        End Try

        Try
            индексСТ6 = Параметр(8)
        Catch ex As Exception
            индексСТ6 = 11111111
        End Try

        Try
            индексСТ7 = Параметр(9)
        Catch ex As Exception
            индексСТ7 = 11111111
        End Try

        ListV.Items.Clear()

        Try
            If массивПуст Or список(0, 0).ToString = "нет записей" Or список(0, 0).ToString = "нет- за-пис-ей" Then
                массивПуст = False
                Exit Sub
            End If

        Catch ex As Exception
            массивПуст = False
            Exit Sub
        End Try

        y = UBound(список, 2)

        x = 0

        Try
            число = ААОсновная.КоличествоСтрокВТаблице.Text
        Catch ex As Exception

            предупреждение.текст.Text = "Настройки. Количество отображаемых строк в справочнике должно быть числом"
            ОткрытьФорму(предупреждение)
            Exit Sub

        End Try

        If y > ААОсновная.КоличествоСтрокВТаблице.Text Then y = ААОсновная.КоличествоСтрокВТаблице.Text


        While x <= y

            ListV.Items.Add(x + 1)

            ListV.Items(ListV.Items.Count - 1).SubItems.Add(список(индексСТ1, x))

            If Not индексСТ2 = 11111111 Then ListV.Items(ListV.Items.Count - 1).SubItems.Add(список(индексСТ2, x))
            If Not индексСТ3 = 11111111 Then ListV.Items(ListV.Items.Count - 1).SubItems.Add(список(индексСТ3, x))
            Try
                If Not индексСТ4 = 11111111 Then ListV.Items(ListV.Items.Count - 1).SubItems.Add(список(индексСТ4, x))
            Catch ex As Exception
                Dim i As Int16 = 1
            End Try
            If Not индексСТ5 = 11111111 Then ListV.Items(ListV.Items.Count - 1).SubItems.Add(список(индексСТ5, x))
            If Not индексСТ6 = 11111111 Then ListV.Items(ListV.Items.Count - 1).SubItems.Add(список(индексСТ6, x))
            If Not индексСТ7 = 11111111 Then ListV.Items(ListV.Items.Count - 1).SubItems.Add(список(индексСТ7, x))

            'СписокСлушателейВГруппе.ShowDialog()

            x += 1

        End While

Konec:
        массивПуст = False

    End Sub

End Module
