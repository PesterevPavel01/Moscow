Public Class PanelOrders_Events

    Public orders As New Order
    Public Sub init(buttons As Dictionary(Of String, myButton))

        Dim button As myButton

        Select Case StudentsInGroup.cvalification

            Case MainForm.PO

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEnrollmentPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("practice")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createPracticalPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("finalExamination")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createFinalExaminationPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEndingPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("certificate")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createCertificate(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("certificationList")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createGradesIinterAPO(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

            Case MainForm.PP

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEnrollmentPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("practice")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createPracticalPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("finalExamination")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createFinalExaminationPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEndingPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("diplomaSupplement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createDiplomaSupplement(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("statement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createStatementPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("certificationList")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createGradesIinterAPP(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

            Case MainForm.PK

                button = buttons("enrollment")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEnrollmentPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("enrollment_pl")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEnrollmentPK_pl(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("expulsion")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createExpulsionPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEndingPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("ending_ud")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createEndingUdPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

                button = buttons("statement")

                AddHandler button.button.Click,
                    Sub(sender As Object, e As EventArgs)
                        BuildOrder.fromGroupp = True
                        orders.createStatementPK(sender, e)
                        BuildOrder.fromGroupp = False
                    End Sub

        End Select
    End Sub
End Class
