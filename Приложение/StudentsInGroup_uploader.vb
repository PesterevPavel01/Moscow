
Public Class StudentsInGroup_uploader

    Public listOrganization As String()
    Public listFinancing As String()
    Dim queryString As String
    Public mySQLConnector As New MySQLConnect

    Public Sub load_listOrganization()

        queryString = loadOrganization()
        listOrganization = mySQLConnector.loadIntoArray(queryString, 1, 0)

    End Sub

    Public Sub load_listFinancing()

        queryString = loadFinancing()
        listFinancing = mySQLConnector.loadIntoArray(queryString, 1, 0)

    End Sub

    Public Sub copyOrgAndFinEveryone(groupNumber As String, currentFinancing As String, currentOrganization As String)

        queryString = updateOrgAndFinEveryone(groupNumber, currentFinancing, currentOrganization)
        mySQLConnector.sendQuery(queryString, 1)

    End Sub

End Class
