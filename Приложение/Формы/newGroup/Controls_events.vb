Public Class Controls_events
    Public initFlag As Boolean = True
    Public Sub controlsReaction(dictionaryFlag As Dictionary(Of String, Boolean), currentForm As Form)

        If IsNothing(dictionaryFlag) Then

            dictionaryFlag = New Dictionary(Of String, Boolean)

            For Each currentCBox As ComboBox In currentForm.Controls.OfType(Of ComboBox)

                dictionaryFlag.Add(currentCBox.Name, False)

                'AddHandler currentCBox.MouseLeave, Sub()
                '                                       dictionaryFlag(currentCBox.Name) = False
                '                                   End Sub

                'AddHandler currentCBox.MouseMove, Sub()
                '                                      dictionaryFlag(currentCBox.Name) = True
                '                                  End Sub

                AddHandler currentCBox.Enter, Sub()
                                                  '_technical.comboBoxDrop(currentCBox, dictionaryFlag(currentCBox.Name))
                                                  newGroup.message.Visible = False
                                                  newStudent.message.Visible = False
                                              End Sub

                AddHandler currentCBox.EnabledChanged, Sub()
                                                           If currentCBox.Enabled = False Then
                                                               currentCBox.DroppedDown = False
                                                           End If
                                                           activateBlackMode(currentCBox, currentCBox.Enabled, currentForm)
                                                       End Sub

                AddHandler currentCBox.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                           If e.KeyCode = Keys.Enter Then
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
                                                             currentCBox.DroppedDown = Not currentCBox.DroppedDown
                                                             e.Handled = True
                                                             dictionaryFlag(currentCBox.Name) = False
                                                         End If
                                                     End If
                                                 End Sub


            Next

            For Each textBox As TextBox In currentForm.Controls.OfType(Of TextBox)
                AddHandler textBox.EnabledChanged, Sub()
                                                       activateBlackMode(textBox, textBox.Enabled, currentForm)
                                                   End Sub
                AddHandler textBox.Enter, Sub()
                                              newGroup.message.Visible = False
                                              newStudent.message.Visible = False
                                          End Sub
            Next

            For Each datePicker As DateTimePicker In currentForm.Controls.OfType(Of DateTimePicker)

                AddHandler datePicker.EnabledChanged, Sub()
                                                          activateBlackMode(datePicker, datePicker.Enabled, currentForm)
                                                      End Sub
                AddHandler datePicker.Enter, Sub()
                                                 newGroup.message.Visible = False
                                                 newStudent.message.Visible = False
                                             End Sub

            Next

        End If
    End Sub
End Class
