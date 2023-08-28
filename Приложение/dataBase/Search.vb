Module Search
    Function search(str As String, mass As Object, Optional ПоискПоСтолбцуНомер As Integer = 0) As Object
        Dim schet1 As Long
        Dim schet2 As Long
        Dim schet3 As Long
        Dim ChMass As Object
        Dim Dlina As Integer
        Dim stroka As String
        Dlina = Len(str)
        schet1 = UBound(mass, 2)

        schet2 = 0
        schet3 = 0

        If mass(0, 0).ToString = "нет записей" Then
            search = mass
            Exit Function
        End If

        While schet2 <= schet1

            stroka = Left(mass(ПоискПоСтолбцуНомер, schet2), Dlina)

            If Not str = "" Then

                If LCase(str) = LCase(stroka) Then

                    schet3 = schet3 + 1

                End If


            End If


            schet2 = schet2 + 1


        End While

        If schet3 = 1 Then
            ReDim ChMass(UBound(mass, 1), schet3 - 1)
            UpdateListView.arrayEmpty = False
        ElseIf schet3 = 0 Then
            ReDim ChMass(1, 1)
            ChMass(0, 0) = "нет записей"
            UpdateListView.arrayEmpty = True
        Else ReDim ChMass(UBound(mass, 1), schet3 - 1)
            UpdateListView.arrayEmpty = False
        End If

        schet3 = 0
        schet2 = 0

        While schet2 <= schet1

            stroka = Left(mass(ПоискПоСтолбцуНомер, schet2), Dlina)

            If Not str = "" Then


                If LCase(str) = LCase(stroka) Then
                    ChMass(0, schet3) = mass(0, schet2)
                    If UBound(mass, 1) >= 1 Then ChMass(1, schet3) = mass(1, schet2)
                    If UBound(mass, 1) >= 2 Then ChMass(2, schet3) = mass(2, schet2)
                    If UBound(mass, 1) >= 3 Then ChMass(3, schet3) = mass(3, schet2)
                    If UBound(mass, 1) >= 4 Then ChMass(4, schet3) = mass(4, schet2)
                    If UBound(mass, 1) >= 5 Then ChMass(5, schet3) = mass(5, schet2)
                    If UBound(mass, 1) >= 6 Then ChMass(6, schet3) = mass(6, schet2)
                    schet3 = schet3 + 1

                End If

            End If


            schet2 = schet2 + 1


        End While

        search = ChMass


    End Function

End Module
