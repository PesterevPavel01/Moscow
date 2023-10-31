Public Class SearchSort_events

    Public currentForm As Form
    Public initializationСompleted As Boolean = False
    Private controls = New Dictionary(Of Int16, Control)
    Private names = New Dictionary(Of String, Int16)
    Public pictures = New Dictionary(Of Int16, PictureBox)
    Public buttonPictureBox As New Dictionary(Of Button, PictureBox)
    Public buttons As New Dictionary(Of Int16, Button)
    Public sortSetts = New SorterSetts()

    Public Sub init()

        If initializationСompleted Then Return

        If (pictures.Count > 0) Then sortSetts.init(pictures(0), pictures(1))

        AddHandler currentForm.FormClosed, Sub(sender As Object, e As EventArgs)
                                               currentForm.ActiveControl = controls(controls.Count - 1)
                                           End Sub

        Dim index As Int16 = 0

        For Each checkBox As CheckBox In currentForm.Controls.OfType(Of CheckBox)

            controls.Add(index, checkBox)
            names.add(checkBox.Name, index)

            AddHandler checkBox.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                    previewKeyDown(sender, e)
                                                End Sub

            AddHandler checkBox.CheckedChanged, Sub()
                                                    checkedChanged(checkBox)
                                                End Sub

            AddHandler checkBox.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                             checkBoxKeyDown(sender, e)
                                         End Sub
            AddHandler checkBox.Enter, Sub(sender As Object, e As EventArgs)
                                           checkBox.Font = New Font("Microsoft YaHei", 14)
                                       End Sub

            AddHandler checkBox.Leave, Sub(sender As Object, e As EventArgs)
                                           checkBox.Font = New Font("Microsoft YaHei", 12)
                                       End Sub

            index += 1

        Next

        For Each button As Button In currentForm.Controls.OfType(Of Button)

            AddHandler button.Enter, Sub(sender As Object, e As EventArgs)
                                         buttonPictureBox(button).BorderStyle = BorderStyle.FixedSingle
                                     End Sub

            AddHandler button.Leave, Sub(sender As Object, e As EventArgs)
                                         buttonPictureBox(button).BorderStyle = BorderStyle.None
                                     End Sub

            AddHandler button.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                  previewKeyDown(sender, e)
                                              End Sub

            AddHandler button.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                           pictureKeyDown(buttonPictureBox(button), e)
                                           buttonKeyDown(button, e)
                                       End Sub

        Next

        For Each picture As PictureBox In currentForm.Controls.OfType(Of PictureBox)

            AddHandler picture.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                            pictureKeyDown(picture, e)
                                        End Sub

            AddHandler picture.Click, Sub(sender As Object, e As EventArgs)
                                          picture_Click(sender)
                                          pictureBorderNone()
                                      End Sub
        Next

        initializationСompleted = True
    End Sub

    Private Sub checkedChanged(checkBox As CheckBox)

        interfaceMod.checkBoxReaction(currentForm, checkBox)

    End Sub

    Private Sub pictureBorderNone()

        For Each picture As KeyValuePair(Of Int16, PictureBox) In pictures
            picture.Value.BorderStyle = BorderStyle.None
        Next

    End Sub

    Private Sub picture_Click(picture As PictureBox)

        If picture.Name = "sortUp" Then

            sortSetts.sort("sortUpGr", "sortDown", True)

        Else

            sortSetts.sort("sortUp", "sortDownGr", False)

        End If

    End Sub

    Private Sub buttonKeyDown(button As Button, e As KeyEventArgs)

        Select Case e.KeyValue
            Case Keys.Left
                If numberButton(button) = 0 Then
                    currentForm.ActiveControl = controls(0)
                Else
                    currentForm.ActiveControl = buttons(0)
                End If

            Case Keys.Right
                If numberButton(button) = 1 Then
                    currentForm.ActiveControl = controls(0)
                Else
                    currentForm.ActiveControl = buttons(1)
                End If

        End Select

    End Sub
    Private Function numberButton(button As Button) As Int16
        For Each pair As KeyValuePair(Of Int16, Button) In buttons
            If pair.Value.Name = button.Name Then Return pair.Key
        Next
    End Function

    Private Sub pictureKeyDown(picture As PictureBox, e As KeyEventArgs)

        Select Case e.KeyValue
            Case Keys.Enter
                picture_Click(picture)
        End Select

    End Sub

    Private Sub checkBoxKeyDown(sender As Object, e As KeyEventArgs)

        Dim nextNumber As Int16 = names(sender.name) + 1
        Dim prevNumber As Int16 = names(sender.name) - 1
        If prevNumber = -1 Then prevNumber = controls.Count - 1
        If nextNumber = controls.Count Then nextNumber = 0

        Select Case e.KeyValue

            Case Keys.Enter

                If sender.GetType.ToString = "System.Windows.Forms.CheckBox" Then
                    checkedChange(sender, e.KeyValue)
                End If
                e.Handled = True

            Case Keys.Down

                If sender.GetType.ToString = "System.Windows.Forms.CheckBox" Then
                    currentForm.ActiveControl = controls(prevNumber)
                End If
                e.Handled = True

            Case Keys.Up

                If sender.GetType.ToString = "System.Windows.Forms.CheckBox" Then
                    currentForm.ActiveControl = controls(nextNumber)
                End If
                e.Handled = True

            Case Keys.Right
                If pictures.Count = 0 Then Return
                currentForm.ActiveControl = buttons(0)
                e.Handled = True

            Case Keys.Left
                If pictures.Count = 0 Then Return
                currentForm.ActiveControl = buttons(1)
                e.Handled = True

        End Select
    End Sub
    Private Sub previewKeyDown(sender, e)

        Select Case e.KeyValue
            Case Keys.Enter
                e.IsInputKey = True
            Case Keys.Up
                e.IsInputKey = True
            Case Keys.Down
                e.IsInputKey = True
            Case Keys.Left
                e.IsInputKey = True
            Case Keys.Right
                e.IsInputKey = True
        End Select

    End Sub
End Class
