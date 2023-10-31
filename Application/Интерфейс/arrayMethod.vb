Module arrayMethod
    Function removeEmpty(array As Object) As Object
        Dim resultArray
        Dim counter As Integer, counterSecond As Integer
        ReDim resultArray(UBound(array, 1), UBound(array, 2))

        counter = 0

        While counter <= UBound(array, 1)
            counterSecond = 0
            While counterSecond <= UBound(array, 2)

                If IsDBNull(array(counter, counterSecond)) Then
                    resultArray(counter, counterSecond) = ""
                ElseIf array(counter, counterSecond) = Nothing Then
                    resultArray(counter, counterSecond) = ""
                Else
                    resultArray(counter, counterSecond) = array(counter, counterSecond)
                End If

                counterSecond = counterSecond + 1

            End While

            counter = counter + 1
        End While

        removeEmpty = resultArray
    End Function

    Function removeEmptyInGrades(array As Object) As Object
        Dim resultArray
        Dim counter As Integer, counterSecond As Integer
        ReDim resultArray(UBound(array, 1), UBound(array, 2))

        counter = 0


        While counter <= UBound(array, 1)
            counterSecond = 0
            While counterSecond <= UBound(array, 2)

                If IsDBNull(array(counter, counterSecond)) Then
                    resultArray(counter, counterSecond) = " "
                ElseIf array(counter, counterSecond) = Nothing Then
                    resultArray(counter, counterSecond) = " "
                Else
                    resultArray(counter, counterSecond) = array(counter, counterSecond)
                End If

                counterSecond = counterSecond + 1

            End While

            counter = counter + 1
        End While

        removeEmptyInGrades = resultArray
    End Function

    Function partArray(array As Object, numberStartRow As Integer, numberEndRow As Integer) As Object

        Dim resultArray
        Dim type
        Dim dateTimeVal As DateTime
        Dim counter As Integer, counterSecond As Integer
        ReDim resultArray(numberEndRow - numberStartRow, UBound(array, 2))
        counter = 0
        While counter <= (numberEndRow - numberStartRow)
            counterSecond = 0
            While counterSecond <= UBound(array, 2)
                type = array(counter + numberStartRow, counterSecond).GetType.ToString
                If array(counter + numberStartRow, counterSecond).GetType.ToString = "System.DateTime" Then
                    dateTimeVal = array(counter + numberStartRow, counterSecond)
                    resultArray(counter, counterSecond) = dateTimeVal.ToString("dd.MM.yyyy")
                    counterSecond = counterSecond + 1
                Else
                    resultArray(counter, counterSecond) = Convert.ToString(array(counter + numberStartRow, counterSecond))
                    counterSecond = counterSecond + 1
                End If

            End While

            counter = counter + 1
        End While

        Return resultArray

    End Function

End Module
