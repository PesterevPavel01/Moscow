Public Class StudentsList_events

    Public studentsList As StudentsList
    Private initializationСompleted As Boolean = False

    Public Sub init()

        If initializationСompleted Then Return
        initializationСompleted = True

        AddHandler studentsList.Load,
            Sub(sender As Object, e As FormClosingEventArgs)
                studentsList.studentsList_Load()
            End Sub

        AddHandler studentsList.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                studentsList.studentsList_KeyDown(sender, e)
            End Sub

    End Sub

End Class
