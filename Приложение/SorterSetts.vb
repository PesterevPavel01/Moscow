Public Class SorterSetts

    Dim images As New Dictionary(Of String, Image)
    Dim sortUpBox As PictureBox
    Dim sortDownBox As PictureBox
    Public flagSortUp As Boolean = False


    Sub New()

        Dim path As String = resourcesPath() + "images//"
        images.Add("sortUp", Image.FromFile(path + "sortUp.png"))
        images.Add("sortUpGr", Image.FromFile(path + "sortUpGr.png"))
        images.Add("sortDown", Image.FromFile(path + "sortDown.png"))
        images.Add("sortDownGr", Image.FromFile(path + "sortDownGr.png"))

    End Sub

    Sub sort(imageFirstKey As String, imageSecondKey As String, flagUp As Boolean)

        sortUpBox.Image = images(imageFirstKey)
        flagSortUp = flagUp
        sortDownBox.Image = images(imageSecondKey)

    End Sub

    Sub init(sortUp As PictureBox, sortDown As PictureBox)

        sortUpBox = sortUp
        sortDownBox = sortDown

    End Sub

End Class
