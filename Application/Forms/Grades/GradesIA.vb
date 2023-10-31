Public Class GradesIA

    'Public kodGroup As Integer = -1
    Public myEvents As New Grades_events

    Public Sub loadTables()

        Dim list
        Dim queryString As String
        Dim counter As Integer = 0, counterRows As Integer

        resultTable.Rows.Clear()

        queryString = loadIA(myEvents.kodGroup)

        list = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If list(0, 0).ToString = "нет записей" Then

            Warning.content.Text = "Нет данных для отображения"
            openForm(Warning)
            ActiveControl = resultTable
            Exit Sub

        End If
        gradesIAMAnipulation.ЗаписатьСписокСлушателей(list)
        counterRows = UBound(list, 2)

        resultTable.Rows.Add(UBound(list, 2) + 1)

        While counter <= UBound(list, 2)

            resultTable.Rows(counter).Cells(0).Value = CStr(counter + 1)
            resultTable.Rows(counter).Cells(1).Value = CStr(list(0, counter))

            resultTable.Rows(counter).Cells(2).Value = CStr(list(1, counter))
            resultTable.Rows(counter).Cells(3).Value = CStr(list(2, counter))
            resultTable.Rows(counter).Cells(4).Value = CStr(list(3, counter))

            counter = counter + 1

        End While

        ActiveControl = resultTable

    End Sub

    Private Sub GradesIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myEvents.currentForm = Me
        myEvents.header = header
        myEvents.groupNumber = groupNumber
        myEvents.saveButton = save
        myEvents.resultTable = resultTable
        myEvents.init()
    End Sub
End Class