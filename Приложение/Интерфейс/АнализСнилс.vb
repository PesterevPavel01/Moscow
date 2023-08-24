Module АнализСнилс

    Sub ShowForm2()

        MainForm.Show()

    End Sub

    Function ПроверкаСнилс(Снилс As String) As Boolean
        Dim НомерСнилс As Long
        Dim МассивЭлементов
        Dim Sum As Integer = 0
        Dim count As Integer
        count = 0
        Dim chr As Integer = 0
        Dim CheckNumbr As Integer
        Dim element As String

        ПроверкаСнилс = False

        МассивЭлементов = Strings.Left(Снилс, 9).ToCharArray
        CheckNumbr = Strings.Right(Снилс, 2)

        For Each i In МассивЭлементов
            element = i
            chr = Convert.ToInt32(element)
            Sum += chr * (9 - count)
            count += 1
        Next

        If Sum = 100 Then
            Sum = 0
        ElseIf Sum > 100 Then
            Sum = Sum Mod 101

            If Sum = 100 Then
                Sum = 0
            End If

        End If

        If Sum = CheckNumbr Then
            ПроверкаСнилс = True
        End If



    End Function


End Module
