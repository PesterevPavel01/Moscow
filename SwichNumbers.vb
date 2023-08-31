Imports Org.BouncyCastle.Asn1.Crmf

Public Class SwichNumbers

    Public controlList As New Dictionary(Of String, List(Of Control))
    Public pkList As New List(Of Control)
    Public poList As New List(Of Control)
    Public ppList As New List(Of Control)
    Public typeCval As New List(Of String)

    Public activeType As String

    Public Sub init()

        controlList.Add("pk", pkList)
        controlList.Add("pp", ppList)
        controlList.Add("po", poList)

        typeCval.Add("pk")
        typeCval.Add("pp")
        typeCval.Add("po")

    End Sub

    Public Sub activateLevel()

        For Each cvalType As String In typeCval

            If cvalType = activeType Then

                For Each element As TextBox In controlList(cvalType).OfType(Of TextBox)
                    element.Enabled = True
                    Dim n As String = element.Name
                Next
                For Each element As Label In controlList(cvalType).OfType(Of Label)
                    element.Enabled = True
                Next
                For Each element As DateTimePicker In controlList(cvalType).OfType(Of DateTimePicker)
                    element.Enabled = True
                Next
            Else
                For Each element As TextBox In controlList(cvalType).OfType(Of TextBox)
                    element.Enabled = False
                    element.Clear()
                Next
                For Each element As Label In controlList(cvalType).OfType(Of Label)
                    element.Enabled = False
                Next
                For Each element As DateTimePicker In controlList(cvalType).OfType(Of DateTimePicker)
                    element.Enabled = False
                    element.Value = "01.01.1753"
                Next
            End If

        Next

    End Sub

    Public Sub activateAll()

        activeType = "null"

        For Each cvalType As String In typeCval

            For Each element As Label In controlList(cvalType).OfType(Of Label)
                element.Enabled = True
            Next
            For Each element As TextBox In controlList(cvalType).OfType(Of TextBox)
                element.Clear()
                element.Enabled = True
            Next
            For Each element As DateTimePicker In controlList(cvalType).OfType(Of DateTimePicker)
                element.Enabled = True
                element.Value = "01.01.1753"
            Next

        Next

    End Sub



End Class
