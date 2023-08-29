Module _formCleaner

    Sub cleaner(currentForm As Form)

        Dim nameControl As String

        For Each element In currentForm.Controls.OfType(Of TextBox)
            element.Text = ""
        Next
        For Each element In currentForm.Controls.OfType(Of ComboBox)
            element.Text = ""
        Next
        For Each element In currentForm.Controls.OfType(Of DateTimePicker)
            element.Value = "01.01.1753"
        Next


    End Sub


End Module
