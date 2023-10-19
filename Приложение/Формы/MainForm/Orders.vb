
Public Class Orders

    Public Sub createEnrollmentPK(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK
        BuildOrder.Text = "ПК Зачисление"
        BuildOrder.orderType = "ПК_Зачисление"

        BuildOrder.tableStudentsList.Visible = True
        BuildOrder.tableStudentsList.Location = New Point(9, 350)

        While BuildOrder.tableStudentsList.Columns.Count > 1
            BuildOrder.tableStudentsList.Columns.RemoveAt(1)
        End While

        BuildOrder.tableStudentsList.Columns(0).Width = 805
        BuildOrder.tableStudentsList.Columns(0).Text = "ФИО"

        MainForm.ОтветственныйЗаАттестацию(True)

        MainForm.чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 1020)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 935)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 935)
        'MainForm.directorPosition.Visible = True
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.standard_location()

        BuildOrder.ShowDialog()

        BuildOrder.tableStudentsList.Visible = False
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createEnrollmentPK_pl(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK
        BuildOrder.Text = "ПК зачисление доп"
        BuildOrder.orderType = "ПК_Зачисление_Доп"

        BuildOrder.tableStudentsList.Visible = True
        BuildOrder.tableStudentsList.Location = New Point(9, 320)

        While BuildOrder.tableStudentsList.Columns.Count > 1

            BuildOrder.tableStudentsList.Columns.RemoveAt(1)

        End While

        BuildOrder.tableStudentsList.Columns(0).Width = 805
        BuildOrder.tableStudentsList.Columns(0).Text = "ФИО"

        MainForm.ОтветственныйЗаАттестацию(False)

        MainForm.чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 1000)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 915)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 915)
        'MainForm.directorPosition.Visible = True
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        'местоНаФормеПослеДиректора(3, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        'showPoleVvoda(True, 70, 30)

        BuildOrder.ShowDialog()

        'Чтобы вернуть на место, т.к. сбивается форма на справке о обучении
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        BuildOrder.tableStudentsList.Visible = False
        MainForm.inputField(False)
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createExpulsionPK(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK
        BuildOrder.Text = "ПК отчисление"
        BuildOrder.orderType = "ПК_Отчисление"

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Label4.Text = "Слушатель(ФИО)"
        BuildOrder.GroupBox5.Visible = True

        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(6, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createEndingPK(sender As Object, e As EventArgs)

        BuildOrder.Text = "ПК окончание"

        BuildOrder.cvalification = MainForm.PK

        BuildOrder.Label2.Visible = True
        BuildOrder.Label14.Visible = True
        BuildOrder.orderType = "ПК_Окончание"

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createEndingUdPK(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK
        BuildOrder.orderType = "ПК окончание уд"
        BuildOrder.Text = "ПК_Окончание_уд"
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        BuildOrder.tableStudentsList.Visible = True
        While BuildOrder.tableStudentsList.Columns.Count > 1
            BuildOrder.tableStudentsList.Columns.RemoveAt(1)
        End While
        BuildOrder.tableStudentsList.Columns(0).Width = 805
        BuildOrder.tableStudentsList.Columns(0).Text = "ФИО"

        BuildOrder.LabelИзмениПадеж.Location = New Point(9, 98)
        _formCleaner.cleaner(BuildOrder)
        BuildOrder.tableStudentsList.Location = New Point(9, 330)

        BuildOrder.Size = New Size(840, 990)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 907)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 907)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        BuildOrder.tableStudentsList.Visible = False

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createEnrollmentPP(sender As Object, e As EventArgs)
        BuildOrder.cvalification = MainForm.PP
        BuildOrder.Text = "ПП зачисление"
        BuildOrder.orderType = "ПП_Зачисление"

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 590)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 505)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 505)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        'Call местоНаФормеПослеДиректора(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createPracticalPP(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PP
        BuildOrder.Text = "ПП практика"
        BuildOrder.orderType = "ПП_Практика"

        MainForm.ОтветственныйЗаАттестацию(True, "Руководитель ПП")
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(6, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createFinalExaminationPP(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PP
        BuildOrder.Text = "ПП допуск к ИА"
        BuildOrder.orderType = "ПП_ДопускКИА"

        BuildOrder.comission = True
        MainForm.ОтветственныйЗаАттестацию(True, "Председатель комиссии")
        MainForm.чекбоксы(True, "ПП", "стажировка", "Практическая подготовка/стажировка")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(True, "Комиссия №1")
        MainForm.Комиссия2(True)
        MainForm.Комиссия3(True)
        MainForm.СекретарьКомиссии(True)
        MainForm.ЗаместительРПК(True)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 960)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 877)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 877)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(1, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(2, BuildOrder.Label22, BuildOrder.Label23, BuildOrder.ЗамПредседателя, BuildOrder.ЗамПредседателяДолжность, BuildOrder.GroupBox12)
        MainForm.местоНаФорме(3, BuildOrder.LabelРуководительСтажировки, BuildOrder.Label16, BuildOrder.РуководительСтажировки, BuildOrder.РуководительСтажировкиДолжность, BuildOrder.GroupBox7)
        MainForm.местоНаФорме(4, BuildOrder.label20, BuildOrder.Label17, BuildOrder.Комиссия2, BuildOrder.Комиссия2Должность, BuildOrder.GroupBox8)
        MainForm.местоНаФорме(5, BuildOrder.Label18, BuildOrder.Label19, BuildOrder.Комиссия3, BuildOrder.Комиссия3Должность, BuildOrder.GroupBox9)
        MainForm.местоНаФорме(6, BuildOrder.Label15, BuildOrder.Label21, BuildOrder.СекретарьКомиссии, BuildOrder.СекретарьКомиссииДолжность, BuildOrder.GroupBox10)
        MainForm.местоНаФорме(7, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(8, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(9, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(10, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(11, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        BuildOrder.comission = False

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createEndingPP(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PP
        BuildOrder.Text = "ПП окончание"
        BuildOrder.orderType = "ПП_Окончание"

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createEnrollmentPO(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PO
        BuildOrder.Text = "ПО зачисление"
        BuildOrder.orderType = "ПО_Зачисление"

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        'Call местоНаФормеПослеДиректора(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createPracticalPO(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PO
        BuildOrder.Text = "ПО практика"
        BuildOrder.orderType = "ПО_Практика"

        MainForm.ОтветственныйЗаАттестацию(True, "Руководитель ПО")
        BuildOrder.practical = True

        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФормеПослеДиректора(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(3, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(4, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(5, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(6, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        BuildOrder.practical = False

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createFinalExaminationPO(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PO
        BuildOrder.Text = "ПО допуск к ИА"
        BuildOrder.orderType = "ПО_ДопускКИА"

        MainForm.ОтветственныйЗаАттестацию(True, "Председатель комиссии")
        MainForm.чекбоксы(True, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(True, "Комиссия 1")
        MainForm.Комиссия2(True)
        MainForm.Комиссия3(True)
        MainForm.СекретарьКомиссии(True)
        MainForm.ЗаместительРПК(False)

        BuildOrder.comission = True

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 883)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 800)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 800)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(1, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(2, BuildOrder.LabelРуководительСтажировки, BuildOrder.Label16, BuildOrder.РуководительСтажировки, BuildOrder.РуководительСтажировкиДолжность, BuildOrder.GroupBox7)
        MainForm.местоНаФорме(3, BuildOrder.label20, BuildOrder.Label17, BuildOrder.Комиссия2, BuildOrder.Комиссия2Должность, BuildOrder.GroupBox8)
        MainForm.местоНаФорме(4, BuildOrder.Label18, BuildOrder.Label19, BuildOrder.Комиссия3, BuildOrder.Комиссия3Должность, BuildOrder.GroupBox9)
        MainForm.местоНаФорме(5, BuildOrder.Label15, BuildOrder.Label21, BuildOrder.СекретарьКомиссии, BuildOrder.СекретарьКомиссииДолжность, BuildOrder.GroupBox10)
        MainForm.местоНаФорме(6, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФормеПослеДиректора(7, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФормеПослеДиректора(8, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФормеПослеДиректора(9, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФормеПослеДиректора(10, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        BuildOrder.comission = False

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)

    End Sub

    Public Sub createEndingPO(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PO
        BuildOrder.Text = "ПО_Окончание"
        BuildOrder.orderType = "ПО_Окончание"

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(True)
        MainForm.Исполнитель(True)
        MainForm.Согласовано1(True)
        MainForm.Согласовано2(True)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФорме(3, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФорме(4, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФорме(5, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФорме(6, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        BuildOrder.ShowDialog()

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(1)
    End Sub

    Public Sub createDiplomaSupplement(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PP
        BuildOrder.Text = "ПП приложение к диплому"
        BuildOrder.orderType = "ПП_ПриложениеКдиплому"

        BuildOrder.Label24.Text = "Производственная практика"

        BuildOrder.CheckBox1.Visible = True
        BuildOrder.CheckBox1.Location = New Point(20, 76)
        BuildOrder.CheckBox1.Checked = False

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 180)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 96)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 96)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФорме(3, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФорме(4, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФорме(5, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФорме(6, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)

        MainForm.Утверждает(False)

        BuildOrder.ShowDialog()
        BuildOrder.CheckBox1.Visible = False
        BuildOrder.ПрактическаяПодготовка.Visible = False
        BuildOrder.ИтоговаяАттестация.Visible = False
        BuildOrder.Label24.Visible = False
        BuildOrder.Label25.Visible = False
        BuildOrder.Text = "Приказ"

        MainForm.Утверждает(True)

    End Sub

    Public Sub createCertificate(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PO
        BuildOrder.Text = "ПО свидетельство"
        BuildOrder.orderType = "ПО_Свидетельство"

        BuildOrder.Label24.Text = "Практическая подготовка"

        BuildOrder.CheckBox1.Visible = True
        BuildOrder.CheckBox1.Location = New Point(20, 76)
        BuildOrder.CheckBox1.Checked = False

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "", "", "")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Size = New Size(840, 180)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 96)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 96)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)

        MainForm.местоНаФорме(2, BuildOrder.Label4, BuildOrder.Label13, BuildOrder.Ответственный, BuildOrder.ОтветственныйДолжность, BuildOrder.GroupBox5)
        MainForm.местоНаФорме(1, BuildOrder.Label2, BuildOrder.Label14, BuildOrder.Утверждает, BuildOrder.УтверждаетДолжность, BuildOrder.GroupBox6)
        MainForm.местоНаФорме(3, BuildOrder.Label5, BuildOrder.Label6, BuildOrder.ПроектВносит, BuildOrder.ПроектВноситДолжность, BuildOrder.GroupBox1)
        MainForm.местоНаФорме(4, BuildOrder.Label7, BuildOrder.Label8, BuildOrder.Исполнитель, BuildOrder.ИсполнительДолжность, BuildOrder.GroupBox2)
        MainForm.местоНаФорме(5, BuildOrder.Label9, BuildOrder.Label10, BuildOrder.Согласовано1, BuildOrder.Согласовано1Должность, BuildOrder.GroupBox3)
        MainForm.местоНаФорме(6, BuildOrder.Label11, BuildOrder.Label12, BuildOrder.Согласовано2, BuildOrder.Согласовано2Должность, BuildOrder.GroupBox4)
        MainForm.Утверждает(False)

        BuildOrder.ShowDialog()
        BuildOrder.CheckBox1.Visible = False
        BuildOrder.ПрактическаяПодготовка.Visible = False
        BuildOrder.ИтоговаяАттестация.Visible = False
        BuildOrder.Label24.Visible = False
        BuildOrder.Label25.Visible = False
        BuildOrder.Text = "Приказ"

        MainForm.Утверждает(True)

    End Sub

    Public Sub createStatementPK(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK
        BuildOrder.Text = "ПК заявление"
        BuildOrder.orderType = "ПК_Заявление"

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        MainForm.standard_location(1)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)


        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)
        BuildOrder.ShowDialog()

    End Sub

    Public Sub createStatementPP(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PP
        BuildOrder.Text = "ПП заявление"
        BuildOrder.orderType = "ПП_Заявление"

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        MainForm.standard_location(1)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)


        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(2)
        BuildOrder.ShowDialog()

    End Sub

    Public Sub createStudentInformation(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK_PP_PO
        BuildOrder.Text = "Карточка слушателя"
        BuildOrder.orderType = "Карточка_слушателя"

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        MainForm.standard_location(1)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 665)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 580)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 580)


        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ShowDialog()

    End Sub

    Public Sub createStudentAndOrganization(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK_PP
        BuildOrder.Text = "Ведомость слушатели и организации"
        BuildOrder.orderType = "Ведомость_слушателиИорганизации"
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 150)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 65)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 65)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ДатаПриказа.Enabled = False
        BuildOrder.ShowDialog()
        BuildOrder.ДатаПриказа.Enabled = True

    End Sub

    Public Sub getAllBlank(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK_PP_PO
        BuildOrder.Text = "Доверенность получения бланков на группу"
        BuildOrder.orderType = "ДоверенностьПолученияБланков"

        BuildOrder.Утверждает.Visible = True
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = True
        BuildOrder.Label14.Visible = False

        BuildOrder.Label2.Text = "Ответственный"


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        MainForm.standard_location(1)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 190)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 107)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 107)

        MainForm.directorOff = True
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ShowDialog()
        MainForm.directorOff = False
        BuildOrder.Label2.Text = "Директор ФИО"

    End Sub

    Public Sub getSomeBlank(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK_PP_PO
        BuildOrder.Text = "Доверенность получения бланков на слушателя"
        BuildOrder.orderType = "ДоверенностьПолученияБланковСлушателей"

        BuildOrder.tableStudentsList.Visible = True
        BuildOrder.tableStudentsList.Location = New Point(9, 120)

        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False

        While BuildOrder.tableStudentsList.Columns.Count > 1

            BuildOrder.tableStudentsList.Columns.RemoveAt(1)

        End While

        BuildOrder.tableStudentsList.Columns(0).Width = 805
        BuildOrder.tableStudentsList.Columns(0).Text = "ФИО"

        BuildOrder.LabelИзмениПадеж.Location = New Point(9, 99)
        BuildOrder.LabelИзмениПадеж.Visible = True
        BuildOrder.Утверждает.Visible = True
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = True
        BuildOrder.Label14.Visible = False

        BuildOrder.Label2.Text = "Ответственный"


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        MainForm.standard_location(1)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 790)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 700)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 700)

        MainForm.directorOff = True
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ShowDialog()

        MainForm.directorOff = False
        BuildOrder.Label2.Text = "Директор ФИО"
        BuildOrder.tableStudentsList.Visible = False
        BuildOrder.LabelИзмениПадеж.Visible = False

    End Sub

    Public Sub createGradesIinterAPO(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PO
        BuildOrder.Text = "Ведомость промежуточной аттестации"
        BuildOrder.orderType = "ВедомостьПромежуточнойАттестации"

        While BuildOrder.tableStudentsList.Columns.Count < 3
            BuildOrder.tableStudentsList.Columns.Add("Преподаватель", 200)
        End While
        BuildOrder.tableStudentsList.Columns(0).Text = "Номер"
        BuildOrder.tableStudentsList.Columns(0).Width = 50
        BuildOrder.tableStudentsList.Visible = True
        BuildOrder.tableStudentsList.Columns(1).Width = 550
        BuildOrder.tableStudentsList.Columns(1).Text = "Наименование модуля"



        BuildOrder.tableStudentsList.Location = New Point(9, 120)

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 790)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 700)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 700)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ShowDialog()
        BuildOrder.tableStudentsList.Visible = False

    End Sub

    Public Sub createGradesIinterAPP(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PP
        BuildOrder.Text = "ПП Ведомость промежуточной аттестации"
        BuildOrder.orderType = "ПП_Ведомость"

        While BuildOrder.tableStudentsList.Columns.Count < 3
            BuildOrder.tableStudentsList.Columns.Add("Преподаватель", 200)
        End While

        BuildOrder.tableStudentsList.Visible = True
        BuildOrder.tableStudentsList.Location = New Point(9, 120)
        BuildOrder.tableStudentsList.Columns(0).Text = "Номер"
        BuildOrder.tableStudentsList.Columns(0).Width = 50
        BuildOrder.tableStudentsList.Columns(1).Width = 550
        BuildOrder.tableStudentsList.Columns(1).Text = "Наименование модуля"

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 790)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 700)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 700)

        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ShowDialog()

        BuildOrder.tableStudentsList.Visible = False

    End Sub

    Public Sub createCertificateStudy(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK_PP_PO
        BuildOrder.Text = "Справка об обучении"
        BuildOrder.orderType = "СправкаОбОбучении"

        BuildOrder.LabelИзмениПадеж.Visible = True
        BuildOrder.tableStudentsList.Visible = True
        BuildOrder.LabelИзмениПадеж.Location = New Point(9, 152)
        BuildOrder.tableStudentsList.Location = New Point(9, 180)

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False

        While BuildOrder.tableStudentsList.Columns.Count > 1
            BuildOrder.tableStudentsList.Columns.RemoveAt(1)
        End While

        BuildOrder.tableStudentsList.Columns(0).Width = 805
        BuildOrder.tableStudentsList.Columns(0).Text = "ФИО"


        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        MainForm.standard_location(1)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 843)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 760)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 760)

        MainForm.inputField(True)

        BuildOrder.ДатаПриказа.Enabled = False
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ShowDialog()
        BuildOrder.ДатаПриказа.Enabled = True

        MainForm.inputField(False)

        BuildOrder.LabelИзмениПадеж.Visible = False
        BuildOrder.tableStudentsList.Visible = False
        BuildOrder.tableStudentsList.Columns.Add(1)
        BuildOrder.tableStudentsList.Columns(0).Text = "Номер"
        BuildOrder.tableStudentsList.Columns(1).Text = "ФИО"
        BuildOrder.tableStudentsList.Columns(1).Width = 120
        BuildOrder.tableStudentsList.Columns(0).Width = 50

    End Sub

    Public Sub createCertificateStudyOut(sender As Object, e As EventArgs)

        BuildOrder.cvalification = MainForm.PK_PP_PO
        BuildOrder.Text = "Справка об окончании без ИА"
        BuildOrder.orderType = "СправкаОбОкончании"

        BuildOrder.LabelИзмениПадеж.Visible = True
        BuildOrder.tableStudentsList.Visible = True
        BuildOrder.LabelИзмениПадеж.Location = New Point(9, 92)
        BuildOrder.tableStudentsList.Location = New Point(9, 120)

        BuildOrder.Утверждает.Visible = False
        BuildOrder.УтверждаетДолжность.Visible = False
        BuildOrder.Label2.Visible = False
        BuildOrder.Label14.Visible = False

        While BuildOrder.tableStudentsList.Columns.Count > 1
            BuildOrder.tableStudentsList.Columns.RemoveAt(1)
        End While
        BuildOrder.tableStudentsList.Columns(0).Width = 805
        BuildOrder.tableStudentsList.Columns(0).Text = "ФИО"

        MainForm.ОтветственныйЗаАттестацию(False)
        MainForm.чекбоксы(False, "ММС", "санитар", "должность слушателей")
        MainForm.ПроектВносит(False)
        MainForm.Исполнитель(False)
        MainForm.Согласовано1(False)
        MainForm.Согласовано2(False)
        MainForm.РуководительСтажировки(False)
        MainForm.Комиссия2(False)
        MainForm.Комиссия3(False)
        MainForm.СекретарьКомиссии(False)
        MainForm.ЗаместительРПК(False)

        MainForm.standard_location(1)

        _formCleaner.cleaner(BuildOrder)

        BuildOrder.Button1.Visible = False
        BuildOrder.Size = New Size(840, 790)
        BuildOrder.КнопкаСформировать.Location = New Point(135, 700)
        BuildOrder.КнопкаОчистить.Location = New Point(2, 700)
        BuildOrder.ДатаПриказа.Enabled = False
        MainForm.ActiveControl = MainForm.TabControlOther.TabPages(3)
        BuildOrder.ShowDialog()
        BuildOrder.ДатаПриказа.Enabled = True

        BuildOrder.LabelИзмениПадеж.Visible = False
        BuildOrder.tableStudentsList.Visible = False
        BuildOrder.tableStudentsList.Columns.Add(1)
        BuildOrder.tableStudentsList.Columns(0).Text = "Номер"
        BuildOrder.tableStudentsList.Columns(1).Text = "ФИО"
        BuildOrder.tableStudentsList.Columns(1).Width = 120
        BuildOrder.tableStudentsList.Columns(0).Width = 50

    End Sub

End Class
