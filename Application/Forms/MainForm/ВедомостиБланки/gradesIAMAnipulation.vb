Module gradesIAMAnipulation
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
    Sub saveVal(Ведомость As Object, kod As Integer)
        Dim fio, array
        Dim queryString, snils As String
        Dim rowCounter As Integer
        rowCounter = Ведомость.Rows.Count
        queryString = GradesIA.resultTable.Rows(rowCounter - 1).Cells(1).Value


        For Each row As DataGridViewRow In GradesIA.resultTable.Rows

            If IsNothing(row.Cells(1).Value) Then

                Exit For

            End If

            fio = Split(row.Cells(1).Value, " ")
            snils = ОпределитьСНИЛС(CDbl(row.Cells(0).Value))

            Try

                queryString = oVedom__checkStudent(Convert.ToString(kod), snils)

            Catch ex As Exception

                Continue For

            End Try


            array = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)


            If array(0, 0) = "нет записей" Then

                Continue For

            End If

            Try

                queryString = ia__updateResult(kod, snils, row.Cells(2).Value & Chr(39), row.Cells(3).Value, row.Cells(4).Value)

            Catch ex As Exception

                Warning.content.Text = "Информация не была сохранена"
                openForm(Warning)

                Exit Sub

            End Try

            MainForm.mySqlConnect.sendQuery(queryString, 1)

        Next

    End Sub

    Function check(Ведомость As Object) As Boolean

        If Ведомость.Rows.Count = 1 Then

            Return True

        ElseIf Ведомость.Rows(0).Cells(1).Value = "" Then

            Return True

        Else

            Return False

        End If

    End Function

End Module
