
Public Class DGV_Events
    Public dictionaryFlag As Dictionary(Of String, Boolean)
    Public userDGV As Tables_control
    Public listCombo As New List(Of user_comboBox)
    Public formParent As Form
    Public saveKeyS = False
    Private flagInitComplete = False

    Public Sub userDGV_init()

        If flagInitComplete Then Return
        flagInitComplete = True

        dictionaryFlag = New Dictionary(Of String, Boolean)

        ' События контрола Пользовательская таблица

        AddHandler userDGV.Enter, Sub()
                                      ' Событие у Слушателей в группе только ставит флаг flag_active_control = True, у программы зажигает индикатор
                                      userDGV.tables_control_Activate()
                                  End Sub

        AddHandler userDGV.Enter, Sub()
                                      ' Событие у Слушателей в группе только ставит флаг flag_active_control = True, у программы зажигает индикатор
                                      userDGV.tables_control_Activate()
                                  End Sub

        'События Дата грид

        AddHandler userDGV.DataGridTablesResult.Leave, Sub()
                                                           ' Событие только ставит флаг active_last_element = False
                                                           userDGV.dataGridTables_Leave()
                                                       End Sub

        AddHandler userDGV.DataGridTablesResult.Enter, Sub()
                                                           ' Если редактор закрыт, ставит флаг active_last_element = True
                                                           userDGV.dataGridTables_activate()
                                                       End Sub

        AddHandler userDGV.DataGridTablesResult.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                                    ' Обрабатывает нажатие +, R, Delete, вправо и Tab
                                                                    DataGridTables_PreviewKeyDown(sender, e)
                                                                End Sub

        AddHandler userDGV.DataGridTablesResult.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                             ' Обрабатывает нажатие +, R, Delete, вправо и Tab
                                                             DataGridTables_KeyDown(sender, e)
                                                         End Sub

        AddHandler userDGV.DataGridTablesResult.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                                              ' Обрабатывает нажатие Enter

                                                              DataGridTables_KeyPress(sender, e)
                                                          End Sub

        AddHandler userDGV.DataGridTablesResult.CellDoubleClick, Sub(sender As Object, e As EventArgs)
                                                                     ' Открывает и обновляет редактор
                                                                     userDGV.dataGridTables_CellDoubleClick(sender, e)
                                                                 End Sub

        AddHandler userDGV.DataGridTablesResult.SelectionChanged, Sub(sender As Object, e As EventArgs)
                                                                      ' Открывает и обновляет редактор
                                                                      userDGV.dataGridTables_SelectionChanged()
                                                                      If Not userDGV.redactor_autoUpdate Then Return
                                                                      If userDGV.flagRedactorOpen Then userDGV.dataGridTables_rDown()
                                                                  End Sub

        AddHandler userDGV.DataGridTablesResult.SizeChanged,
            Sub()
                ' Адаптирует ширину столбцов
                userDGV.dataGridTables_SizeChanged()
            End Sub

        ' События пользовательского контрола

        AddHandler userDGV.redactor_element_second.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)
                ' IsInputKey
                redactor_element_second_PreviewKeyDown(e)
            End Sub

        AddHandler userDGV.redactor_element_second.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                'Обработка нажатий вверх-вниз
                redactor_element_second_KeyDown(sender, e)
            End Sub

        AddHandler userDGV.redactor_element_first.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                'Обработка нажатий вверх-вниз
                redactor_element_first_KeyDown(sender, e)
            End Sub

        AddHandler userDGV.redactor_element_second.KeyPress,
            Sub(sender As Object, e As KeyPressEventArgs)
                'Обработка нажатий Enter и Tab
                redactor_element_second_KeyPress(sender, e)
            End Sub

        AddHandler userDGV.redactor_element_first.KeyPress,
            Sub(sender As Object, e As KeyPressEventArgs)
                'Обработка нажатий Enter и Tab
                redactor_element_first_KeyPress(sender, e)
            End Sub

        AddHandler userDGV.redactor_element_first.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)
                ' IsInputKey
                redactor_element_first_PreviewKeyDown(sender, e)
            End Sub

        ' События комбобокса


        For Each myCombo As user_comboBox In listCombo

            dictionaryFlag.Add(myCombo.Name, False)
            'нужно т.к. KeyDown не отменит
            AddHandler myCombo.my_ComboBox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                                         my_ComboBox_KeyPress(e, myCombo)
                                                     End Sub
            'нужно т.к. KeyPress не ловит стрелки
            AddHandler myCombo.my_ComboBox.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                        my_ComboBox_KeyDown(e, myCombo)
                                                    End Sub

            If Not saveKeyS Then

                AddHandler myCombo.my_ComboBox.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                                   redactor_element_first_PreviewKeyDown(sender, e)
                                                               End Sub

                AddHandler myCombo.my_ComboBox.DropDown, Sub()
                                                             dictionaryFlag(myCombo.Name) = True
                                                         End Sub

                AddHandler myCombo.my_ComboBox.DropDownClosed, Sub()
                                                                   dictionaryFlag(myCombo.Name) = False
                                                               End Sub

                AddHandler myCombo.my_ComboBox.MouseMove, Sub()
                                                              dictionaryFlag(myCombo.Name) = True
                                                          End Sub

                AddHandler myCombo.my_ComboBox.MouseLeave, Sub()
                                                               dictionaryFlag(myCombo.Name) = False
                                                           End Sub


                AddHandler myCombo.my_ComboBox.Enter, Sub()
                                                          If dictionaryFlag(myCombo.Name) Then
                                                              myCombo.my_ComboBox.DroppedDown = False
                                                          Else
                                                              myCombo.my_ComboBox.DroppedDown = True
                                                          End If
                                                      End Sub

            Else

                AddHandler myCombo.my_ComboBox.PreviewKeyDown, Sub(sender As Object, e As PreviewKeyDownEventArgs)
                                                                   If e.KeyCode = Keys.Enter Then
                                                                       If Not myCombo.my_ComboBox.DroppedDown Then
                                                                           dictionaryFlag(myCombo.Name) = True
                                                                           e.IsInputKey = True
                                                                       Else
                                                                           dictionaryFlag(myCombo.Name) = False
                                                                       End If
                                                                   End If
                                                               End Sub

                AddHandler myCombo.my_ComboBox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                                             If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                                                                 If dictionaryFlag(myCombo.Name) Then
                                                                     myCombo.my_ComboBox.DroppedDown = True
                                                                     e.Handled = True
                                                                 End If
                                                             End If
                                                         End Sub

                AddHandler myCombo.my_ComboBox.DropDown, Sub(sender As Object, e As EventArgs)
                                                             dictionaryFlag(myCombo.Name) = True
                                                         End Sub

                AddHandler myCombo.my_ComboBox.DropDownClosed, Sub(sender As Object, e As EventArgs)
                                                                   dictionaryFlag(myCombo.Name) = False
                                                               End Sub

            End If
        Next

    End Sub
    Private Sub DataGridTables_KeyPress(sender As Object, e As KeyPressEventArgs)
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)
                If saveKeyS Then Return
                userDGV.table_enterPress(sender, e)
        End Select
    End Sub

    Private Sub DataGridTables_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        e.IsInputKey = True

    End Sub

    Private Sub DataGridTables_KeyDown(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.S
                If Not saveKeyS Then Return
                userDGV.table_enterDown(sender, e)
            Case Keys.Delete
                userDGV.dataGridTables_deleteDown()
            Case Keys.Add
                userDGV.table_addDown()
            Case Keys.R
                userDGV.dataGridTables_rDown()
            Case Keys.Tab
                userDGV.table_tabDown(e)
            Case Keys.Right
                userDGV.table_tabRight(e)
        End Select

    End Sub

    Private Sub my_ComboBox_KeyPress(e As KeyPressEventArgs, myCombo As user_comboBox)
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Tab)
                myCombo.my_ComboBox_PressTab()
            Case Convert.ToChar(Keys.Enter)
                If saveKeyS Then Return
                myCombo.my_ComboBox_pressEnter(e)
                'Case Convert.ToChar(Keys.Escape)
                '    If myCombo.my_ComboBox.DroppedDown Then
                '        myCombo.my_ComboBox.DroppedDown = False
                '        e.Handled = True
                '    End If
        End Select
    End Sub

    Private Sub my_ComboBox_KeyDown(e As KeyEventArgs, myCombo As user_comboBox)

        Select Case e.KeyCode
            Case Keys.Down
                myCombo.my_ComboBox_BottomDown(e)
            Case Keys.Up
                myCombo.my_ComboBox_UpDown(e)
            Case Keys.Enter
                If saveKeyS Then Return
                myCombo.my_ComboBox_enterDown(e, saveKeyS)
            Case Keys.S
                If Not saveKeyS Then Return
                myCombo.my_ComboBox_enterDown(e, saveKeyS)

        End Select
    End Sub


    Private Sub redactor_element_first_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        keyDown_isInputKey(e)

    End Sub

    Private Sub redactor_element_first_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Down Then
            userDGV.redactorElementFirst_bottomDown(e)
        ElseIf e.KeyCode = Keys.Up Then
            userDGV.redactorElementFirst_upDown(e)
        ElseIf e.KeyCode = Keys.S Then
            userDGV.secondElement_enterDown(e)
            e.Handled = True
        End If

    End Sub

    Private Sub redactor_element_second_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Down Then
            userDGV.redactorElementSecond_bottomDown(e)
        ElseIf e.KeyCode = Keys.Up Then
            userDGV.redactorElementSecond_upDown(e)
        ElseIf e.KeyCode = Keys.S Then
            userDGV.secondElement_enterDown(e)
            e.Handled = True
        End If

    End Sub

    Private Sub redactor_element_first_KeyPress(sender As Object, e As KeyPressEventArgs)
        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)
                If saveKeyS Then Return
                userDGV.secondElement_enterPress(e)
                e.Handled = True
            Case Convert.ToChar(Keys.Tab)
                userDGV.redactorElementFirst_tabDown(e)
        End Select
    End Sub

    Private Sub redactor_element_second_KeyPress(sender As Object, e As KeyPressEventArgs)

        Select Case e.KeyChar
            Case Convert.ToChar(Keys.Enter)
                If saveKeyS Then Return
                userDGV.secondElement_enterPress(e)
                e.Handled = True
            Case Convert.ToChar(Keys.Tab)
                userDGV.secondElement_pressTab(e)
        End Select

    End Sub

    Private Sub redactor_element_second_PreviewKeyDown(e As PreviewKeyDownEventArgs)

        keyDown_isInputKey(e)

    End Sub

    Private Sub keyDown_isInputKey(e As PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Enter Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Down Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Up Then

            e.IsInputKey = True

        End If
    End Sub

End Class
