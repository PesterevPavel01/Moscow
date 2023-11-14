Public Class ToolComboBoxReaction

    Private initializationСompleted As Boolean = False

    Public Sub init(dictionaryFlag As Dictionary(Of String, Boolean), toolCBox As ToolStripComboBox)

        If initializationСompleted Then Return
        initializationСompleted = True

        Dim currentCBox As ComboBox
        currentCBox = toolCBox.ComboBox
        'currentCBox.DropDownStyle = ComboBoxStyle.DropDown
        'currentCBox.FlatStyle = FlatStyle.Standard
        'currentCBox.AutoCompleteMode = AutoCompleteMode.None
        'currentCBox.AutoCompleteSource = AutoCompleteSource.None

        dictionaryFlag = New Dictionary(Of String, Boolean)

        dictionaryFlag.Add(currentCBox.Name, False)

        AddHandler currentCBox.Enter, Sub()
                                          newGroup.message.Visible = False
                                          newStudent.message.Visible = False
                                      End Sub

        AddHandler currentCBox.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)

                                                   If e.KeyCode = Keys.Down Then

                                                       e.IsInputKey = True

                                                   ElseIf e.KeyCode = Keys.Up Then

                                                       e.IsInputKey = True

                                                   ElseIf e.KeyCode = Keys.Enter Then
                                                       If Not currentCBox.DroppedDown Then
                                                           dictionaryFlag(currentCBox.Name) = True
                                                           e.IsInputKey = True
                                                       Else
                                                           dictionaryFlag(currentCBox.Name) = False
                                                       End If
                                                   End If
                                               End Sub

        AddHandler currentCBox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)

                                             If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                                                 If dictionaryFlag(currentCBox.Name) Then
                                                     currentCBox.DroppedDown = True
                                                     e.Handled = True
                                                     'dictionaryFlag(currentCBox.Name) = False
                                                 End If
                                             End If
                                         End Sub

        AddHandler currentCBox.DropDown, Sub(sender As Object, e As EventArgs)
                                             dictionaryFlag(currentCBox.Name) = True
                                         End Sub

        AddHandler currentCBox.DropDownClosed, Sub(sender As Object, e As EventArgs)
                                                   dictionaryFlag(currentCBox.Name) = False
                                               End Sub
    End Sub

End Class
