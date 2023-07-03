Module ДобавитьРубашку
    Function ДобавитьРубашку(str As String) As String

        Dim Строка As String
        Dim Начало As String
        Dim Конец As String
        Dim Первая As String
        Dim Вторая As String


        Начало = Left(str, 3)
        Конец = Right(str, 2)
        Первая = Left(Right(str, 8), 3)
        Вторая = Right(Left(str, 9), 3)


        Строка = Начало & Chr(45) & Первая & Chr(45) & Вторая & Chr(45) & Конец

        ДобавитьРубашку = Строка


    End Function

    Function РубашкаНаВвод(str As String, ch1 As Integer, ch2 As Integer, ch3 As Integer, dl As Integer) As String
        Dim длина As Integer

        str = УдалитьРубашку(str)

        If Len(str) >= ch1 Then

            str = Left(str, ch1) & "-" & Right(str, Len(str) - ch1)

        End If

        If Len(str) >= ch1 + ch2 + 1 Then

            str = Left(str, ch1 + ch2 + 1) & "-" & Right(str, Len(str) - (ch1 + ch2 + 1))

        End If

        If Len(str) >= ch1 + 1 + ch2 + 1 + ch3 Then

            str = Left(str, ch1 + 1 + ch2 + 1 + ch3) & "-" & Right(str, Len(str) - (ch1 + 1 + ch2 + 1 + ch3))

        End If

        длина = Len(str)

        If Len(str) > dl Then
            str = Left(str, dl)
            MsgBox("Превышено максимальное количество символов")
        End If

        РубашкаНаВвод = str

    End Function

    Function УдалитьРубашку(str As String) As String

        Dim sc As Integer
        Dim rez As String, т As String

        sc = 1
        While sc <= Len(str)

            т = Right(Left(str, sc), 1)
            If Right(Left(str, sc), 1) = "-" Then

                GoTo NextIteration

            Else : rez = rez & т

            End If
NextIteration:
            sc = sc + 1
        End While

        УдалитьРубашку = rez

    End Function

    Function УдалитьДефисВРубашке(str As String) As String

        If Right(str, 1) = "-" Then

            str = Left(str, Len(str) - 1)

        End If

        УдалитьДефисВРубашке = str

    End Function


    Function ДобавитьРубашкуВМассив(massiv As Object, Optional номерСтолбца As Integer = 1) As Object

        Dim massivListView
        Dim column As Integer, row As Byte

        ReDim massivListView(UBound(massiv, 1), UBound(massiv, 2))


        row = 0

        While row <= UBound(massiv, 1)
            column = 0
            While column <= UBound(massiv, 2)

                massivListView(row, column) = massiv(row, column)
                If row = номерСтолбца Then

                    'massivListView(row, column) = УдалитьРубашку(massiv(row, column))
                    massivListView(row, column) = ДобавитьРубашку(massiv(row, column))

                End If

                column = column + 1
            End While

            row = row + 1
        End While

        ДобавитьРубашкуВМассив = massivListView

    End Function

    Function ДобавитьРубашкуСПробеломВКонцеВМассив(massiv As Object, Optional номерСтолбца As Integer = 1) As Object

        Dim massivListView
        Dim column As Integer, row As Byte

        ReDim massivListView(UBound(massiv, 1), UBound(massiv, 2))


        row = 0

        While row <= UBound(massiv, 1)
            column = 0
            While column <= UBound(massiv, 2)

                massivListView(row, column) = massiv(row, column)
                If row = номерСтолбца Then

                    'massivListView(row, column) = УдалитьРубашку(massiv(row, column))
                    massivListView(row, column) = ДобавитьРубашку(massiv(row, column))
                    massivListView(row, column) = Strings.Left(massivListView(row, column), 11) + " " + Strings.Right(massivListView(row, column), 2)
                End If

                column = column + 1
            End While

            row = row + 1
        End While

        ДобавитьРубашкуСПробеломВКонцеВМассив = massivListView

    End Function

End Module
