
Module interfaceMod

    Sub cursorStepLefth(textbox As TextBox)

        If textbox.SelectionStart > 0 Then
            textbox.SelectionStart -= 1
        End If

    End Sub

    Sub cursorStepRigth(textbox As TextBox)

        If textbox.SelectionStart < textbox.TextLength Then
            textbox.SelectionStart += 1
        End If

    End Sub

    Sub closeEsc(currentForm As Object, keyNumber As Integer)

        If keyNumber = Keys.Escape Then

            currentForm.Close()

        End If

    End Sub

    Sub pressTab(numberPushKey As Integer, requiredKey As Integer, Optional controlName As String = "")

        If numberPushKey = requiredKey Then

            SendKeys.Send("{tab}")

        End If

    End Sub

    Sub up(currentForm As Object, currentKey As Integer, Optional waitingKey As Integer = 38)

        If currentKey = waitingKey Then

            If currentForm.ActiveControl.TabIndex = 0 Then

                Return

            End If

            Dim flag = True
            Dim currentControl As Control = currentForm.ActiveControl

            While flag

                For Each i In currentForm.Controls

                    If i.tabIndex = currentControl.TabIndex - 1 Then

                        currentControl = i
                        Exit For

                    End If
                Next

                If (currentControl.Enabled = True And currentControl.Visible = True) Then

                    Exit While

                End If

            End While

            currentControl.Focus()

        End If

    End Sub

    Sub comboBoxStepBack(combobox As ComboBox, kodPushButton As Integer, kodButtonExp As Integer)

        If kodPushButton = kodButtonExp Then

            Dim selectInd As Int16
            selectInd = combobox.SelectedIndex

            If selectInd < 0 Then
                Exit Sub
            Else
                selectInd -= 1
                combobox.SelectedIndex = selectInd
                Dim s As String = combobox.Text
            End If

        End If
    End Sub

    Sub comboBoxStepForw(combobox As ComboBox, kodPushButton As Integer, kodButtonExp As Integer)

        If kodPushButton = kodButtonExp Then

            Dim selectInd As Int16
            selectInd = combobox.SelectedIndex

            If selectInd >= combobox.Items.Count - 1 Then
                Exit Sub
            Else
                If selectInd = -1 Then
                    Exit Sub
                Else
                    selectInd += 1
                End If
                combobox.SelectedIndex = selectInd
            End If

        End If
    End Sub

    Sub controlFont(контрол As Object, шрифтF As Object)

        контрол.Font = New Font("Microsoft Sans Serif", шрифтF, FontStyle.Regular)

    End Sub

    Sub checkedChange(currentChBox As Object, currentKeyCode As Integer)

        If currentKeyCode = Keys.Enter Then
            If currentChBox.Checked Then
                currentChBox.Checked = False
            Else
                currentChBox.Checked = True
            End If
        End If

    End Sub

    Sub ПрикрепитьЧекбокс(Чекбокс1 As Object, Чекбокс2 As Object)

        If Чекбокс1.Checked Then
            Чекбокс2.Checked = False
        Else
            Чекбокс2.Checked = True
        End If



    End Sub

    Sub openNextPage(TabControl1 As Object)

        If TabControl1.SelectedIndex < TabControl1.TabCount - 1 Then

            TabControl1.SelectTab(TabControl1.SelectedIndex + 1)

        Else

            TabControl1.SelectTab(0)

        End If

    End Sub
    Sub openPrevPage(TabControl1 As Object)

        If TabControl1.SelectedIndex > 0 Then

            TabControl1.SelectTab(TabControl1.SelectedIndex - 1)

        Else

            TabControl1.SelectTab(6)

        End If

    End Sub

    Sub enableOneCheckbox(currentForm As Form, activeCheckBox As String)

        For Each element In currentForm.Controls.OfType(Of CheckBox)

            Try

                If Not element.Name = activeCheckBox Then

                    element.Checked = False

                Else

                    element.Checked = True

                End If

            Catch ex As Exception

            End Try

        Next

    End Sub

    Function nameCheckedCheckBox(currentForm As Form) As String

        For Each element In currentForm.Controls.OfType(Of CheckBox)

            Try

                If element.Checked = True Then

                    Return element.Text

                End If

            Catch ex As Exception

            End Try

        Next

    End Function

    Function statusCheckBoxes(currentForm As Form) As Boolean

        statusCheckBoxes = False

        For Each element In currentForm.Controls.OfType(Of CheckBox)

            If element.Checked = True Then

                Return True

            End If

        Next

    End Function

    Sub searchInit(currentForm As Form, nameCheckBox As String)

        For Each element In currentForm.Controls.OfType(Of CheckBox)

            If element.Text = nameCheckBox Then

                element.Checked = True
                Return

            End If

        Next

    End Sub

    Sub checkBoxReaction(currentForm As Form, currentCheckBox As CheckBox)

        If currentCheckBox.Checked = True Then

            interfaceMod.enableOneCheckbox(currentForm, currentCheckBox.Name)

        ElseIf currentCheckBox.Checked = False Then

            If Not interfaceMod.statusCheckBoxes(currentForm) Then

                currentCheckBox.Checked = True

            End If

        End If

    End Sub

    Function sortType(status As Boolean) As String

        If status Then

            Return " DESC "

        Else

            Return ""

        End If

    End Function

    Function validationField(fildName As String)

        Select Case fildName

            Case "Квалификация"
                Return False
            Case "РегНомерСвид"
                Return False
            Case "НомерСвид"
                Return False
            Case "РегНомерДиплома"
                Return False
            Case "НомерДиплома"
                Return False
            Case "РегНомерУд"
                Return False
            Case "НомерУд"
                Return False
            Case "НоваягруппаОтветственныйЗаПрактику"
                Return False

        End Select

        If Strings.Left(fildName, 6) = "Модуль" Then

            Return False

        End If

        Return True

    End Function





End Module
