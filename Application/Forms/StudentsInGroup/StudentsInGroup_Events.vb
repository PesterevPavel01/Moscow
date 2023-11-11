Public Class StudentsInGroup_Events

    Public studentsInGroup As StudentsInGroup
    Public initializationСompleted As Boolean = False

    Public Sub init()

        If initializationСompleted Then Return
        initializationСompleted = True

        ' Событие при нажатии Esc закрывает открытый редактор, если закрыт, то закрывает форму

        AddHandler studentsInGroup.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                studentsInGroup.studentsInGroup_KeyDown(e)
            End Sub

        AddHandler studentsInGroup.FormClosing,
            Sub(sender As Object, e As FormClosingEventArgs)
                studentsInGroup.StudentList_FormClosing()
            End Sub

        AddHandler studentsInGroup.header.Enter,
            Sub()
                studentsInGroup.newStudent.Select()
            End Sub

        AddHandler studentsInGroup.header.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)

                If e.KeyCode = Keys.Escape Then
                    e.IsInputKey = True
                End If

            End Sub

        AddHandler studentsInGroup.toolOrders.Enter,
            Sub()
                studentsInGroup.toolOrders_Enter()
            End Sub

        AddHandler studentsInGroup.toolOrders.PreviewKeyDown,
            Sub(sender As Object, e As PreviewKeyDownEventArgs)
                studentsInGroup.toolOrders_PreviewKeyDown(e)
            End Sub

        AddHandler studentsInGroup.toolOrders.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                studentsInGroup.toolOrders_KeyDown(e)
            End Sub

        AddHandler studentsInGroup.orders.Click,
            Sub(sender As Object, e As EventArgs)
                studentsInGroup.orders_click()
            End Sub

        AddHandler studentsInGroup.studentsList.Click,
            Sub(sender As Object, e As EventArgs)
                studentsInGroup.studentsList_Click()
            End Sub

        AddHandler studentsInGroup.newStudent.Click,
            Sub(sender As Object, e As EventArgs)
                studentsInGroup.newStudent_Click()
            End Sub

        AddHandler studentsInGroup.allInfo.Click,
            Sub(sender As Object, e As EventArgs)
                studentsInGroup.allInfo_Click()
            End Sub

        AddHandler studentsInGroup.everyone.Click,
            Sub(sender As Object, e As EventArgs)
                studentsInGroup.everyone_Click()
            End Sub

        AddHandler studentsInGroup.closePanelOrders.Click,
            Sub(sender As Object, e As EventArgs)
                studentsInGroup.closePanelOrders_Click()
            End Sub

    End Sub


End Class
