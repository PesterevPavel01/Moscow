Imports System.IO

Public Class SwitchCvalification

    Public pk As ToolStripButton
    Public po As ToolStripButton
    Public pp As ToolStripButton
    Dim path As String
    Public images = New imagesStruct
    Public activeType As String

    Public type As Dictionary(Of String, Int16)
    Public name As Dictionary(Of Int16, String)

    Public Sub init()

        type = New Dictionary(Of String, Short)
        name = New Dictionary(Of Int16, String)

        type.Add("not", -1)
        type.Add("pk", 0)
        type.Add("pp", 1)
        type.Add("po", 2)

        name.Add(-1, "")
        name.Add(0, "повышение квалификации")
        name.Add(1, "профессиональная переподготовка")
        name.Add(2, "профессиональное обучение")

        path = resourcesPath() + "images//"

        images.PK = Image.FromFile(path + "PK.png")
        images.PP = Image.FromFile(path + "PP.png")
        images.PO = Image.FromFile(path + "PO.png")
        images.PKGreen = Image.FromFile(path + "PKGreen.png")
        images.PPGreen = Image.FromFile(path + "PPGreen.png")
        images.POGreen = Image.FromFile(path + "POGreen.png")

    End Sub

    Public Sub activate(valueType As String)

        images.activType = valueType
        changeType()

    End Sub

    Private Sub changeType()

        activeType = name(images.activType)

        Select Case images.activType
            Case -1
                pp.Image = images.PP
                po.Image = images.PO
                pk.Image = images.PK
            Case 0
                pp.Image = images.PP
                po.Image = images.PO
                pk.Image = images.PKGreen
            Case 1
                pk.Image = images.PK
                pp.Image = images.PPGreen
                po.Image = images.PO
            Case 2
                pk.Image = images.PK
                pp.Image = images.PP
                po.Image = images.POGreen
        End Select

    End Sub

End Class


Public Structure imagesStruct

    Dim PK As Image
    Dim PP As Image
    Dim PO As Image
    Dim PKGreen As Image
    Dim PPGreen As Image
    Dim POGreen As Image
    Dim activType As Int16

End Structure