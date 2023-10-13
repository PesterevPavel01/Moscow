Public Class PanelOrders_Events

    Public Sub init(buttons As Dictionary(Of String, myButton))

        Dim button As myButton

        Select Case StudentsInGroup.cvalification

            Case MainForm.PO

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEnrollmentPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("practice")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createPracticalPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("finalExamination")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createFinalExaminationPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEndingPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("certificate")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createCertificate(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("certificationList")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createGradesIinterAPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

            Case MainForm.PP

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEnrollmentPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("practice")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createPracticalPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("finalExamination")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createFinalExaminationPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEndingPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("diplomaSupplement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createDiplomaSupplement(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("statement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createStatementPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("certificationList")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createGradesIinterAPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

            Case MainForm.PK

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEnrollmentPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("enrollment_pl")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEnrollmentPK_pl(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("expulsion")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createExpulsionPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEndingPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending_ud")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createEndingUdPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("statement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        createStatementPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

        End Select
    End Sub
End Class
