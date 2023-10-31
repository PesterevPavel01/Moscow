Public Class Controls_events

    Public initFlag As Boolean = True
    Public blackMode As Boolean = True
    Private initializationСompleted As Boolean = False
    Public Sub controlsReaction(dictionaryFlag As Dictionary(Of String, Boolean), currentForm As Form)

        If initializationСompleted Then Return
        initializationСompleted = True

        dictionaryFlag = New Dictionary(Of String, Boolean)

        'обработка нажатия esc на форме
        AddHandler currentForm.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                            escDown(currentForm, e.KeyCode, dictionaryFlag)
                                        End Sub

        For Each currentCBox As ComboBox In currentForm.Controls.OfType(Of ComboBox)

            dictionaryFlag.Add(currentCBox.Name, False)

            AddHandler currentCBox.Enter, Sub()
                                              newGroup.message.Visible = False
                                              newStudent.message.Visible = False
                                          End Sub

            AddHandler currentCBox.EnabledChanged, Sub()
                                                       If currentCBox.Enabled = False Then
                                                           currentCBox.DroppedDown = False
                                                       End If
                                                       If blackMode Then activateBlackMode(currentCBox, currentCBox.Enabled, currentForm)
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

        Next

        For Each currentCBox As CheckBox In currentForm.Controls.OfType(Of CheckBox)

            AddHandler currentCBox.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                checkedChange(currentCBox, e.KeyCode)
                                            End Sub
            AddHandler currentCBox.GotFocus, Sub(sender As Object, e As EventArgs)
                                                 controlFont(currentCBox, 10.0F)
                                             End Sub
            AddHandler currentCBox.LostFocus, Sub(sender As Object, e As EventArgs)
                                                  controlFont(currentCBox, 8.25F)
                                              End Sub

        Next

        For Each currentListV As ListView In currentForm.Controls.OfType(Of ListView)

            AddHandler currentListV.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                 If e.KeyCode = Keys.Enter Then checkRow(currentListV)
                                             End Sub

        Next

        If blackMode Then

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

    Sub escDown(currentForm As Object, keyNumber As Integer, dictionaryFlag As Dictionary(Of String, Boolean))

        If keyNumber = Keys.Escape Then
            Dim flagDD As Boolean = True
            For Each flag As KeyValuePair(Of String, Boolean) In dictionaryFlag
                If flag.Value Then
                    flagDD = False
                    Exit For
                End If
            Next
            If flagDD Then currentForm.Close()
        End If

    End Sub

End Class
