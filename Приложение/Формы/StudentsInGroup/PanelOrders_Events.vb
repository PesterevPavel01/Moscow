Public Class PanelOrders_Events

    Public Sub init(buttons As Dictionary(Of String, myButton))

        Dim button As myButton

        Select Case StudentsInGroup.cvalification

            Case MainForm.PO

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПО_Зачисление_Click(sender, e)
                    End Sub

                button = buttons("practice")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПО_Практика_Click(sender, e)
                    End Sub

                button = buttons("finalExamination")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПО_ДопускКИА_Click(sender, e)
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПО_Окончание_Click(sender, e)
                    End Sub

                button = buttons("certificate")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПО_Свидетельство_Click(sender, e)
                    End Sub

                button = buttons("certificationList")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ВедомостьПромежуточнойАттестации_Click(sender, e)
                    End Sub

            Case MainForm.PP

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ППЗачисление_Click(sender, e)
                    End Sub

                button = buttons("practice")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПП_Практика_Click(sender, e)
                    End Sub

                button = buttons("finalExamination")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПП_ДопускКИА_Click(sender, e)
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПП_Окончание_Click(sender, e)
                    End Sub

                button = buttons("diplomaSupplement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПП_ПриложениеКдиплому_Click(sender, e)
                    End Sub

                button = buttons("statement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПП_Заявление_Click(sender, e)
                    End Sub

                button = buttons("certificationList")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПП_Ведомость_Click(sender, e)
                    End Sub

            Case MainForm.PK

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПриказОЗачислении_Click(sender, e)
                    End Sub

                button = buttons("enrollment_pl")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПриказОЗачислении_Доп_Click(sender, e)
                    End Sub

                button = buttons("expulsion")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПК_Отчисление_Click(sender, e)
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПК_Окончание_Click(sender, e)
                    End Sub

                button = buttons("ending_ud")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПК_Окончание_уд_Click(sender, e)
                    End Sub

                button = buttons("statement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        MainForm.ПК_Заявление_Click(sender, e)
                    End Sub

        End Select
    End Sub
End Class
