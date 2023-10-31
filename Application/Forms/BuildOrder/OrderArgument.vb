Imports System.Threading

Public Class OrderArgument
    Public SC As New SynchronizationContext
    Public mySqlConnector As MySQLConnect
    Public selectedStudents
    Public selectedModuls
    Public orderType As String
    Public groupNumber As String
    Public orderIdGroup As Int64
    Public orderDate As Date
    Public practical As String
    Public approves As String  'Утверждает
    Public approvesPosition As String
    Public initiator As String
    Public initiatorPosition As String
    Public realisator As String
    Public realisatorPosition As String
    Public inspectorFirst As String
    Public inspectorFirstPosition As String
    Public inspectorSec As String
    Public inspectorSecPosition As String
    Public studentPosition As Boolean
    Public studentPositionName As String
    Public studentAlterPos As String
    Public studentSecPosition As Boolean
    Public manualMode As Boolean
    Public gradesIA As String 'итоговая аттестация
    Public responsible As String
    Public responsiblePosition As String
    Public deputyChiefComission As String
    Public deputyPosition As String
    Public internshipChief As String
    Public internshipChiefPosition As String
    Public comissionSec As String
    Public comissionSecPosition As String
    Public comissionThird As String
    Public comissionThirdPosition As String
    Public secretary As String
    Public secretaryPosition As String

    Public threadFlags As Dictionary(Of String, Boolean)
End Class
