Imports Google.Protobuf.WellKnownTypes

Module InsertIntoDataBase
    Public sleep As Boolean = False
    Public removeDuplicates As Boolean = False
    Public ready As Boolean = False
    Public errorPS As Boolean = False
    Public writError As Boolean = False
    Dim queryString As String
    Dim resultArray
    Public argument As New Arg

    Public Sub argumentClear()

        argument.nameTable = "Not"
        argument.firstName = "Not"
        argument.firstValue = "Not"
        argument.secondName = "Not"
        argument.secondValue = "Not"
        argument.thirdName = "Not"

    End Sub

    Sub checkAndSendToDB(queryString As String)
        Dim checkStatus As Boolean = False
        Dim counterConnect As Integer = 0
        writError = False
        checkStatus = False

        If Not argument.nameTable = "Not" Then

            If Not argument.firstName = "Not" Or argument.firstValue = "Not" Then

                checkStatus = checkDuplicates()

                If errorPS Then

                    Exit Sub

                End If

                If checkStatus Then

                    ФормаДаНет.ShowDialog()
                    checkStatus = False
                    If Not removeDuplicates Then
                        НоваяГруппа.zakr = True
                        Exit Sub
                    End If

                End If

            Else

                MsgBox("Введи все критерии, необходимые для процедуры проверки совпадений")
                Exit Sub

            End If

        End If



        If removeDuplicates Then

            deleteFromDB()
            removeDuplicates = False

        End If

        MainForm.mySqlConnect.sendQuery(queryString, 1)

    End Sub

    Function checkDuplicates() As Boolean

        Dim resultArray

        If argument.secondName = "Not" Or argument.secondValue = "Not" Then

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & Chr(39) & argument.firstValue & Chr(39)

        ElseIf argument.thirdName = "Not" Or argument.thirdValue = "Not" Then

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & Chr(39) & argument.firstValue & Chr(39) & " AND " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39)

        Else

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & Chr(39) & argument.firstValue & Chr(39) & " And " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39) & " And " & argument.thirdName & " = " & Chr(39) & argument.thirdValue & Chr(39)

        End If

        resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If resultArray(0, 0).ToString = "нет записей" Then

            Return False

        End If

        Return True

    End Function
    Function checkUniq_No2() As Integer

        Dim result As Integer = 0

        If argument.secondName = "Not" Or argument.secondValue = "Not" Then

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & argument.firstValue

        ElseIf argument.thirdName = "Not" Or argument.thirdValue = "Not" Then

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & argument.firstValue & " AND " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39)

        Else

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & argument.firstValue & " And " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39) & " And " & argument.thirdName & " = " & Chr(39) & argument.thirdValue & Chr(39)

        End If

        resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If resultArray(0, 0).ToString = "нет записей" Then

            Return 1

        End If

        Return 2

    End Function
    Function checkUniqGroup() As Boolean

        If argument.secondName = "Not" Or argument.secondValue = "Not" Then

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & Chr(39) & argument.firstValue & Chr(39)

        ElseIf argument.thirdName = "Not" Or argument.thirdValue = "Not" Then

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & Chr(39) & argument.firstValue & Chr(39) & " AND " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39)

        Else

            queryString = "SELECT * FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & Chr(39) & argument.firstValue & Chr(39) & " And " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39) & " And " & argument.thirdName & " = " & Chr(39) & argument.thirdValue & Chr(39)

        End If

        resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If resultArray(0, 0).ToString = "нет записей" Then

            Return False

        End If

        Return True

    End Function

    Sub deleteFromDB()

        queryString = "DELETE FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & Chr(39) & argument.firstValue & Chr(39)

        If Not argument.secondName = "Not" Then

            queryString += " AND " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39)

        End If

        If Not MainForm.mySqlConnect.sendQuery(queryString, 1) Then

            предупреждение.текст.Text = "не удалось удалить запись!"
            ОткрытьФорму(предупреждение)

        End If

    End Sub
    Sub deleteFromDB_NumberArg()

        Dim sqlQuery As String

        sqlQuery = "DELETE FROM " & argument.nameTable & " WHERE " & argument.firstName & " = " & argument.firstValue

        If Not argument.secondName = "Not" Then
            sqlQuery += " AND " & argument.secondName & " = " & Chr(39) & argument.secondValue & Chr(39)
        End If

        If Not MainForm.mySqlConnect.sendQuery(sqlQuery, 1) Then
            предупреждение.текст.Text = "не удалось удалить запись!"
            ОткрытьФорму(предупреждение)
        End If

    End Sub

    Public Class Arg

        Public nameTable As String
        Public firstName As String
        Public firstValue As String
        Public secondName As String
        Public secondValue As String
        Public thirdName As String
        Public thirdValue As String

    End Class

End Module
