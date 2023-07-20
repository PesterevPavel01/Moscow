Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar

Module АДействияСОВедомостью

    Public СписокСлушателей
    Sub ЗаписатьСписокСлушателей(Список As Object)
        Dim индикатор
        ReDim СписокСлушателей(UBound(Список, 1) + 1, UBound(Список, 2))
        For СчетчикСтолбцов = 0 To UBound(Список, 1)
            For СчетчикСтрок = 0 To UBound(Список, 2)
                СписокСлушателей(СчетчикСтолбцов, СчетчикСтрок) = Список(СчетчикСтолбцов, СчетчикСтрок)
            Next
        Next
        индикатор = UBound(Список, 1) + 1
        For счетчикСтрок = 0 To UBound(Список, 2)
            СписокСлушателей(UBound(Список, 1) + 1, счетчикСтрок) = счетчикСтрок + 1
        Next

    End Sub
    Function ОпределитьСНИЛС(номер As Integer) As String
        For СчетчикСтрок = 0 To UBound(СписокСлушателей, 2)
            If CDbl(СписокСлушателей(UBound(СписокСлушателей, 1), СчетчикСтрок)) = номер Then
                ОпределитьСНИЛС = СписокСлушателей(UBound(СписокСлушателей, 1) - 1, СчетчикСтрок)
                Exit For
            End If
        Next
    End Function
    Sub СохранитьОценки(Ведомость As Object, kod As Integer)
        Dim Запросы, ФИО, Проверочный
        Dim СтрокаЗапроса, Снилс As String
        Dim Счетчик As Integer = 0, СчетчикСтрок As Integer
        ReDim Запросы(3)
        Dim argument As String()
        ReDim argument(12)

        СчетчикСтрок = Ведомость.Rows.Count
        For Счетчик = 0 To СчетчикСтрок - 1
            If IsNothing(ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(1).Value) Then
                Exit For
            End If
            Снилс = ОпределитьСНИЛС(CDbl(ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(0).Value))
            ФИО = Split(ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(1).Value, " ")
            Try
                СтрокаЗапроса = oVedom__checkSlush(Снилс, Convert.ToString(kod))
            Catch ex As Exception
                Continue For
            End Try
            Проверочный = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)
            If Проверочный(0, 0) = "нет записей" Then
                Continue For
            End If

            For count As Int16 = 0 To 9

                argument(count) = Convert.ToString(ОценочнаяВедомость.ТаблицаВедомость.Rows(Счетчик).Cells(count + 2).Value)

            Next

            argument(10) = Снилс
            argument(11) = Convert.ToString(kod)

            Try
                СтрокаЗапроса = oVedom__updateOcenki(argument)
            Catch ex As Exception
                предупреждение.текст.Text = "Информация не была сохранена"
                ОткрытьФорму(предупреждение)
                Exit Sub
            End Try
            ЗаписьВБазу.ЗаписьВБазу(СтрокаЗапроса)
        Next


    End Sub

    Function проверка(Ведомость As Object) As Boolean

        If Ведомость.Rows.Count = 1 Then

            проверка = True

        ElseIf Ведомость.Rows(0).Cells(1).Value = "" Then

            проверка = True

        ElseIf IsNothing(Ведомость.Rows(0).Cells(1).Value) Then

            проверка = True

        Else проверка = False

        End If

    End Function


End Module
