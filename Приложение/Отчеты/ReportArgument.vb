Imports System.Threading

Public Class ReportArgument
    Public reportFlags = New Dictionary(Of String, Boolean)
    Public shortDateStart, shortDateEnd As String
    Public orderNumber As Integer
    Public month As Int16
    Public SC As New SynchronizationContext
    Public mySqlConnector As MySQLConnect
End Class
