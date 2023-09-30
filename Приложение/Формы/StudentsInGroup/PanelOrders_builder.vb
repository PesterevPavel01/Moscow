
Imports WindowsApp2.Group

Public Class PanelOrders_builder
    Public panelOrders As Panel
    Public buttons As New Dictionary(Of String, myButton)
    Public buttonHeigth As Integer
    Public panelEvents As New PanelOrders_Events
    Dim location As Point

    Public Sub init()

        For Each button As KeyValuePair(Of String, myButton) In buttons

            Dim myButton As Control = button.Value
            panelOrders.Controls.Remove(myButton)
            myButton.Dispose()

        Next

        buttonAdd()
        panelEvents.init(buttons)

    End Sub

    Public Sub buttonAdd()

        Select Case StudentsInGroup.cvalification
            Case MainForm.PK
                buildPK()
            Case MainForm.PP
                buildPP()
            Case MainForm.PO
                buildPO()
        End Select

        Dim number As Int16 = 0

        For Each pair As KeyValuePair(Of String, myButton) In buttons

            Dim currentButton As myButton = pair.Value
            If Number = 0 Then
                currentButton.prevControl = StudentsInGroup.toolOrders
            Else
                currentButton.prevControl = buttons.ElementAt(Number - 1).Value
            End If

            If Number = buttons.Count - 1 Then
                currentButton.nextControl = buttons.ElementAt(0).Value
            Else
                currentButton.nextControl = buttons.ElementAt(Number + 1).Value
            End If

            Number += 1
        Next

    End Sub

    Private Sub buildPO()

        Dim button As myButton

        buttons.Clear()

        button = New myButton
        button.Name = "enrollment"
        button.button.Text = "ПО зачисление"
        buttonInit(button)


        button = New myButton
        button.Name = "practice"
        button.button.Text = "ПО практика"
        buttonInit(button)

        button = New myButton
        button.Name = "finalExamination"
        button.button.Text = "ПО допуск к ИА"
        buttonInit(button)

        button = New myButton
        button.Name = "ending"
        button.button.Text = "ПО окончание"
        buttonInit(button)

        button = New myButton
        button.Name = "certificate"
        button.button.Text = "ПО свидетельство"
        buttonInit(button)

        button = New myButton
        button.Name = "certificationList"
        button.button.Text = "ПО ведомость ПА"
        buttonInit(button)

    End Sub

    Private Sub buttonInit(currentButton As myButton)

        currentButton.Height = buttonHeigth
        panelOrders.Controls.Add(currentButton)
        buttons.Add(currentButton.Name, currentButton)
        If buttons.Count = 1 Then
            currentButton.Location = New Point(currentButton.Location.X + 2, currentButton.Location.Y + 2)
        Else
            currentButton.Location = New Point(location.X, location.Y + buttonHeigth + 2)
        End If

        location = currentButton.Location
        currentButton.Width = panelOrders.Width - 10
    End Sub

    Private Sub buildPP()

        Dim button As myButton

        buttons.Clear()

        button = New myButton
        button.Name = "enrollment"
        button.button.Text = "ПП зачисление"
        buttonInit(button)

        button = New myButton
        button.Name = "practice"
        button.button.Text = "ПП практика"
        buttonInit(button)

        button = New myButton
        button.Name = "finalExamination"
        button.button.Text = "ПП допуск к ИА"
        buttonInit(button)

        button = New myButton
        button.Name = "ending"
        button.button.Text = "ПП окончание"
        buttonInit(button)

        button = New myButton
        button.Name = "diplomaSupplement"
        button.button.Text = "ПП приложение"
        buttonInit(button)

        button = New myButton
        button.Name = "statement"
        button.button.Text = "ПП заявление"
        buttonInit(button)

        button = New myButton
        button.Name = "certificationList"
        button.button.Text = "ПП ведомость ПА"
        buttonInit(button)

    End Sub


    Private Sub buildPK()

        Dim button As myButton

        buttons.Clear()

        button = New myButton
        button.Name = "enrollment"
        button.button.Text = "ПК зачисление"
        buttonInit(button)

        button = New myButton
        button.Name = "enrollment_pl"
        button.button.Text = "ПК зачисление доп"
        buttonInit(button)

        button = New myButton
        button.Name = "expulsion"
        button.button.Text = "ПК отчисление"
        buttonInit(button)

        button = New myButton
        button.Name = "ending"
        button.button.Text = "ПК окончание"
        buttonInit(button)

        button = New myButton
        button.Name = "ending_ud"
        button.button.Text = "ПК окончание уд"
        buttonInit(button)

        button = New myButton
        button.Name = "statement"
        button.button.Text = "ПК заявление"
        buttonInit(button)

    End Sub

End Class
