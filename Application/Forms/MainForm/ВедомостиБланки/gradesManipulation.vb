Module gradesManipulation

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
    Function loadSnils(номер As Integer) As String
        For СчетчикСтрок = 0 To UBound(СписокСлушателей, 2)
            If CDbl(СписокСлушателей(UBound(СписокСлушателей, 1), СчетчикСтрок)) = номер Then
                loadSnils = СписокСлушателей(UBound(СписокСлушателей, 1) - 1, СчетчикСтрок)
                Exit For
            End If
        Next
    End Function
    Sub saveVal(Ведомость As Object, kod As Integer)
        Dim querys, fio, checkArray
        Dim queryString, snils As String
        Dim counter As Integer = 0, rowsCounter As Integer
        ReDim querys(3)
        Dim argument As String()
        ReDim argument(12)

        rowsCounter = Ведомость.Rows.Count

        For counter = 0 To rowsCounter - 1
            If IsNothing(Grades.resultTable.Rows(counter).Cells(1).Value) Then
                Exit For
            End If
            snils = loadSnils(CDbl(Grades.resultTable.Rows(counter).Cells(0).Value))
            fio = Split(Grades.resultTable.Rows(counter).Cells(1).Value, " ")
            Try
                queryString = oVedom__checkStudent(Convert.ToString(kod), snils)
            Catch ex As Exception
                Continue For
            End Try
            checkArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
            If checkArray(0, 0) = "нет записей" Then
                Continue For
            End If

            For count As Int16 = 0 To 9

                argument(count) = Convert.ToString(Grades.resultTable.Rows(counter).Cells(count + 2).Value)

            Next

            argument(10) = snils
            argument(11) = Convert.ToString(kod)

            Try
                queryString = oVedom__updateOcenki(argument)
            Catch ex As Exception
                Warning.content.Text = "Информация не была сохранена"
                openForm(Warning)
                Exit Sub
            End Try
            MainForm.mySqlConnect.sendQuery(queryString, 1)
        Next


    End Sub

    Function check(Ведомость As Object) As Boolean

        If Ведомость.Rows.Count = 0 Then

            check = True

        ElseIf Ведомость.Rows(0).Cells(1).Value = "" Then

            check = True

        ElseIf IsNothing(Ведомость.Rows(0).Cells(1).Value) Then

            check = True

        Else check = False

        End If

    End Function


End Module
