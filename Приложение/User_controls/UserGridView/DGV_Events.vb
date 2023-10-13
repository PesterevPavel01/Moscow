
Public Class DGV_Events
    Public userDGV As Tables_control
    Public listCombo As New List(Of user_comboBox)
    Public formParent As Form

    Public Sub userDGV_init()

        ' События родительских форм

        If userDGV.name_table = "group_list" Then

            ' Событие при нажатии Esc закрывает открытый редактор, если закрыт, то закрывает форму
            Dim form As StudentsInGroup = formParent
            AddHandler form.KeyDown,
                Sub(sender As Object, e As KeyEventArgs)
                    form.studentsInGroup_KeyDown(e)
                End Sub

        End If

        ' События контрола Пользовательская таблица

        AddHandler userDGV.Enter,
            Sub()
                ' Событие у Слушателей в группе только ставит флаг flag_active_control = True, у программы зажигает индикатор
                userDGV.tables_control_Activate()
            End Sub

        AddHandler userDGV.Leave,
            Sub()
                ' Событие у Слушателей в группе только ставит флаг flag_active_control = False, у программы зажигает индикатор
                userDGV.tables_control_Leave()
            End Sub

        'События Дата грид

        AddHandler userDGV.DataGridTablesResult.Leave,
            Sub()
                ' Событие только ставит флаг active_last_element = False
                userDGV.dataGridTables_Leave()
            End Sub

        AddHandler userDGV.DataGridTablesResult.Enter,
            Sub()
                ' Если редактор закрыт, ставит флаг active_last_element = True
                userDGV.dataGridTables_activate()
            End Sub

        AddHandler userDGV.DataGridTablesResult.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                ' Обрабатывает нажатие +, R, Delete, вправо и Tab
                DataGridTables_KeyDown(sender, e)
            End Sub

        AddHandler userDGV.DataGridTablesResult.KeyPress,
            Sub(sender As Object, e As KeyPressEventArgs)
                ' Обрабатывает нажатие Enter
                DataGridTables_KeyPress(sender, e)
            End Sub

        AddHandler userDGV.DataGridTablesResult.CellDoubleClick,
            Sub(sender As Object, e As EventArgs)
                ' Открывает и обновляет редактор
                userDGV.dataGridTables_CellDoubleClick(sender, e)
            End Sub

        AddHandler userDGV.DataGridTablesResult.SizeChanged,
            Sub()
                ' Адаптирует ширину столбцов
                userDGV.dataGridTables_SizeChanged()
            End Sub

        AddHandler userDGV.DataGridTablesResult.SelectionChanged,
            Sub()
                ' Выделяет всю строку
                userDGV.dataGridTables_SelectionChanged()
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

            AddHandler myCombo.my_ComboBox.PreviewKeyDown,
                Sub(sender As Object, e As PreviewKeyDownEventArgs)
                    ' IsInputKey
                    redactor_element_first_PreviewKeyDown(sender, e)
                End Sub

            AddHandler myCombo.my_ComboBox.KeyPress, 'нужно т.к. KeyDown не отменит
                Sub(sender As Object, e As KeyPressEventArgs)
                    my_ComboBox_KeyPress(e, myCombo)
                End Sub

            AddHandler myCombo.my_ComboBox.KeyDown, 'нужно т.к. KeyPress не ловит стрелки
                Sub(sender As Object, e As KeyEventArgs)
                    my_ComboBox_KeyDown(e, myCombo)
                End Sub

            AddHandler myCombo.my_ComboBox.DropDown,
                Sub()
                    myCombo.flag_comboDroppedDown = True
                End Sub

            AddHandler myCombo.my_ComboBox.DropDownClosed,
                Sub()
                    myCombo.flag_comboDroppedDown = False
                End Sub
        Next

    End Sub

    Private Sub DataGridTables_KeyPress(sender As Object, e As KeyPressEventArgs)

        Select Case e.KeyChar

            Case Convert.ToChar(Keys.Enter)
                userDGV.table_enterPress(sender, e)

        End Select

    End Sub

    Private Sub DataGridTables_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyValue = Keys.Delete Then

            userDGV.dataGridTables_deleteDown()

        ElseIf e.KeyValue = Keys.Add Then

            userDGV.table_addDown()

        ElseIf e.KeyValue = Keys.R Then

            userDGV.dataGridTables_rDown()

        ElseIf e.KeyValue = Keys.Tab Then

            userDGV.table_tabDown(e)

        ElseIf e.KeyValue = Keys.Right Then

            userDGV.table_tabRight(e)

        End If

    End Sub

    Private Sub my_ComboBox_KeyPress(e As KeyPressEventArgs, myCombo As user_comboBox)

        Select Case e.KeyChar

            Case Convert.ToChar(Keys.Enter)

                myCombo.my_ComboBox_PressEnter(e)

            Case Convert.ToChar(Keys.Tab)

                myCombo.my_ComboBox_PressTab()

        End Select
    End Sub

    Private Sub my_ComboBox_KeyDown(e As KeyEventArgs, myCombo As user_comboBox)

        Select Case e.KeyCode

            Case Keys.Down

                myCombo.my_ComboBox_BottomDown(e)

            Case Keys.Up

                myCombo.my_ComboBox_UpDown(e)

            Case Keys.Enter

                myCombo.my_ComboBox_EnterDown(e)

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

        End If

    End Sub

    Private Sub redactor_element_first_KeyPress(sender As Object, e As KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            userDGV.secondElement_enterPress(e)

            e.Handled = True

        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) Then

            userDGV.redactorElementFirst_tabDown(e)

        End If

    End Sub

    Private Sub redactor_element_second_PreviewKeyDown(e As PreviewKeyDownEventArgs)

        keyDown_isInputKey(e)

    End Sub
    Private Sub redactor_element_second_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Down Then

            userDGV.redactorElementSecond_bottomDown(e)

        ElseIf e.KeyCode = Keys.Up Then

            userDGV.redactorElementSecond_upDown(e)

        End If

    End Sub
    Private Sub redactor_element_second_KeyPress(sender As Object, e As KeyPressEventArgs)

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            userDGV.secondElement_enterPress(e)

        ElseIf e.KeyChar = Convert.ToChar(Keys.Tab) Then

            userDGV.secondElement_pressTab(e)

        End If

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
