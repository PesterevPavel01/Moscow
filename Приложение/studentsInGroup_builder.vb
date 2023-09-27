Imports MySql.Data.MySqlClient

Public Class StudentsInGroup_builder

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

End Class
