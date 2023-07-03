Module АДействияСОценкиИА
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
        Dim ФИО, Проверочный
        Dim СтрокаЗапроса, Снилс As String
        Dim СчетчикСтрок As Integer
        СчетчикСтрок = Ведомость.Rows.Count
        СтрокаЗапроса = АОценкиИА.ТаблицаОценкиИА.Rows(СчетчикСтрок - 1).Cells(1).Value


        For Each row As DataGridViewRow In АОценкиИА.ТаблицаОценкиИА.Rows

            If IsNothing(row.Cells(1).Value) Then

                Exit For

            End If

            ФИО = Split(row.Cells(1).Value, " ")
            Снилс = ОпределитьСНИЛС(CDbl(row.Cells(0).Value))
            Try

                СтрокаЗапроса = "SELECT СоставГрупп.Слушатель FROM СоставГрупп WHERE СоставГрупп.Слушатель = " & Chr(39) & Снилс & Chr(39) & " AND СоставГрупп.Kod = " & kod

            Catch ex As Exception

                Continue For

            End Try


            Проверочный = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)


            If Проверочный(0, 0) = "нет записей" Then

                Continue For

            End If

            Try

                СтрокаЗапроса = "UPDATE СоставГрупп SET ИАТестирование= " & Chr(39) & row.Cells(2).Value & Chr(39) & ",ИАПрактическиеНавыки= " & Chr(39) & row.Cells(3).Value & Chr(39) & ",ИАИтог= " & Chr(39) & row.Cells(4).Value & Chr(39) & " WHERE СоставГрупп.Слушатель = " & Chr(39) & Снилс & Chr(39) & "  AND СоставГрупп.Kod = " & kod

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

        Else проверка = False

        End If

    End Function

End Module
