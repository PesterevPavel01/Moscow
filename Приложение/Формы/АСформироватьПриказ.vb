Public Class АСформироватьПриказ
    Public prikaz As New Prikaz
    Public flagLoad As Boolean = False
    Public orderType As String
    Public kodGroup As Integer
    Public path As String
    Public flagCheck As Boolean = False
    Public ЧекнутыеСлушатели
    Public komissiya As Boolean = False
    Public praktika As Boolean = False

    Private Sub ПОЗачисленииНомерГруппы_Click(sender As Object, e As EventArgs) Handles НомерГруппы.Click

        ФормаСписок.ListViewСписок.Columns.RemoveAt(0)
        ФормаСписок.ListViewСписок.Columns.Add("Программа", 500)
        ФормаСписок.ListViewСписок.Columns(0).Width = 200
        ФормаСписок.ListViewСписок.Columns.Add("Год", 100)
        ФормаСписок.ListViewСписок.Columns.Add("Код", 100)
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name

        If MainForm.prikazCvalif = MainForm.PK_PP_PO Then

            ФормаСписок.headerVisible = True

        End If

        ФормаСписок.ShowDialog()
        ФормаСписок.ListViewСписок.Columns.RemoveAt(1)
        ФормаСписок.ListViewСписок.Columns.RemoveAt(2)
        ФормаСписок.ListViewСписок.Columns(0).Width = 100
        ФормаСписок.ListViewСписок.Columns(1).Width = 620
        ФормаСписок.ListViewСписок.Columns(1).Text = "Наименование"

    End Sub

    Private Sub Директор_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub Ответственный_Click(sender As Object, e As EventArgs) Handles Ответственный.Click

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub


    Private Sub ОтветственныйДолжность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name


    End Sub

    Private Sub ПроектВносит_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub ПроектВноситДолжность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub Согласовано1_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name
    End Sub

    Private Sub Согласовано1Должность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub Согласовано2_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub Согласовано2Должность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub Исполнитель_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub ИсполнительДолжность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub
    Private Sub Утверждает_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub УтверждаетДолжность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub


    Private Sub ДолжностьРуководительСтажировки_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub
    Private Sub РуководительСтажировки_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub
    Private Sub Комиссия2_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub Сформировать_Click(sender As Object, e As EventArgs) Handles КнопкаСформировать.Click

        Dim checkContent As Boolean
        Dim selectedStudents
        Dim selectedModuls
        ActiveControl = Button1

        checkContent = checkSuff()

        If Not checkContent Then
            Try
                предупреждение.текст.Text = "Необходимо заполнить все обязательные поля!"
                ОткрытьФорму(предупреждение)
            Catch ex As Exception
                предупреждение.Close()
                предупреждение.текст.Text = "Необходимо заполнить все обязательные поля!"
                ОткрытьФорму(предупреждение)
            End Try
            Exit Sub
        End If

        Select Case orderType

            Case "Ведомость_слушателиИорганизации"

                ВедомостьСлушателиИОрганизации()

            Case "ВедомостьПромежуточнойАттестации"

                selectedModuls = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 1, 2)
                ВедомостьПромежуточнойАттестации.ВедомостьПромежуточнойАттестации(selectedModuls, orderType)

            Case "ПП_Ведомость"

                selectedModuls = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 1, 2)
                ВедомостьПромежуточнойАттестации.ВедомостьПромежуточнойАттестации(selectedModuls, orderType)

            Case "СправкаОбОкончании"

                selectedStudents = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 0)

                СправкаОбОкончании.СправкаОбОкончании(selectedStudents)

            Case "СправкаОбОбучении"

                selectedStudents = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 0)

                spravka.spravka(selectedStudents)

            Case "ДоверенностьПолученияБланковСлушателей"

                selectedStudents = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 0)

                ДоверенностьПолученияБланковНаСлушателя(selectedStudents)

            Case "ДоверенностьПолученияБланков"

                ДоверенностьПолученияБланковНаГруппу.ДоверенностьПолученияБланковНаГруппу()

            Case "ПО_Свидетельство"

                ПО_Свидетельство.po_svid(orderType)

            Case "ПП_ПриложениеКдиплому"

                ПП_ПриложениеКДиплому.ПП_ПриложениеКДиплому(orderType)

            Case "ПП_Практика"

                Приказ_Практика.Приказ_Практика(orderType)

            Case "ПО_Практика"

                Приказ_Практика.Приказ_Практика(orderType)

            Case "ПК_Заявление"

                Бланки.ПК_Заявление(orderType)

            Case "ПП_Заявление"

                Бланки.ПП_Заявление(orderType)

            Case "Карточка_слушателя"

                Бланки.Карточка_Слушателя(orderType)

            Case "ПК_Отчисление"

                Приказ_Отчисление.Приказ_Отчисление(orderType)

            Case "ПО_ДопускКИА"

                Приказ_ДопускКИА.Приказ_ДопускКИА(orderType)

            Case "ПП_ДопускКИА"

                Приказ_ДопускКИА.Приказ_ДопускКИА(orderType)

            Case "ПК_Окончание"

                Приказ_Окончание.Приказ_Окончание(orderType)

            Case "ПК_Окончание_уд"

                selectedStudents = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 0)

                ПК_Окончание.ПК_Окончание_уд(selectedStudents, orderType)

            Case "ПП_Окончание"

                Приказ_Окончание.Приказ_Окончание(orderType)

            Case "ПО_Окончание"

                Приказ_Окончание.Приказ_Окончание(orderType)

            Case "ПК_Зачисление_Доп"

                selectedStudents = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 0)
                Приказ_Зачисление.Приказ_Зачисление(orderType, selectedStudents)

            Case "ПК_Зачисление"

                selectedStudents = ЗаписатьЧекнутыеСтроки(ListViewСписокСлушателей, 0)
                Приказ_Зачисление.Приказ_Зачисление(orderType, selectedStudents)

            Case "ПП_Зачисление"

                Приказ_Зачисление.Приказ_Зачисление(orderType)

            Case "ПО_Зачисление"

                Приказ_Зачисление.Приказ_Зачисление(orderType)

        End Select
    End Sub

    Private Sub Очистить_Click(sender As Object, e As EventArgs) Handles КнопкаОчистить.Click
        Dim Форма

        ActiveControl = Button1
        Форма = New Form
        Форма = ActiveForm

        Call ОчиститьПоляФормы.Очиститьформу(Форма)
        ListViewСписокСлушателей.Items.Clear()

    End Sub

    Private Sub АСформироватьПриказОЗачислении_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        flagCheck = True

        ListViewСписокСлушателей.Items.Clear()

        ActiveControl = Button1

        If orderType = "Спецэкзамен_протокол" Then
            Exit Sub
        End If

        If MainForm.ДиректорДолжность.Text <> "" Then
            УтверждаетДолжность.Text = MainForm.ДиректорДолжность.Text
        End If

        If MainForm.Согласовано1ПУ.Text <> "" Then
            Согласовано1.Text = MainForm.Согласовано1ПУ.Text
        End If

        If MainForm.Согласовано2ПУ.Text <> "" Then
            Согласовано2.Text = MainForm.Согласовано2ПУ.Text
        End If

        If MainForm.Согласовано1ДолжностьПУ.Text <> "" Then
            Согласовано1Должность.Text = MainForm.Согласовано1ДолжностьПУ.Text
        End If

        If MainForm.Согласовано2ДолжностьПУ.Text <> "" Then
            Согласовано2Должность.Text = MainForm.Согласовано2ДолжностьПУ.Text
        End If

        If komissiya Then

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.komissiya)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.komissiya)

        ElseIf praktika Then

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.ruk_staj)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)

        Else

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.ruk_staj)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)

        End If



        If Label2.Text = "Ответственный" Then

            Утверждает.Items.Clear()
            Утверждает.Items.Add("")
            Утверждает.Items.AddRange(prikaz.formPrikazList.otv_attestat)

        Else

            Утверждает.Items.Clear()
            Утверждает.Items.Add("")
            Утверждает.Items.AddRange(prikaz.formPrikazList.director)

        End If

        If Not MainForm.directorOff Then

            If MainForm.ДиректорФИО.Text <> "" Then
                Утверждает.Text = MainForm.ДиректорФИО.Text
            End If

        End If

    End Sub

    Private Sub ПОЗачисленииНомерГруппы_TextChanged(sender As Object, e As EventArgs) Handles НомерГруппы.TextChanged

        Me.ListViewСписокСлушателей.Items.Clear()

        If orderType = "ПК_Отчисление" Then

            If Not НомерГруппы.Text = "" Then
                Label4.Visible = True
                Ответственный.Visible = True
            Else
                Label4.Visible = False
                Ответственный.Visible = False
            End If

        End If

        If orderType = "ПК_Окончание_уд" Or orderType = "СправкаОбОкончании" Or orderType = "ДоверенностьПолученияБланковСлушателей" Or orderType = "СправкаОбОбучении" Or orderType = "СправкаОбОкончании" Then

            If Not НомерГруппы.Text = "" Then
                loadStudentsList()
            End If

            If orderType = "СправкаОбОбучении" Then
                ListViewСписокСлушателей.Items.Insert(0, New ListViewItem("Выделить всех"))
            End If

        End If

        If orderType = "ВедомостьПромежуточнойАттестации" Or orderType = "ПП_Ведомость" Then

            If Not НомерГруппы.Text = "" Then
                loadModuls()
            End If

        End If

        If orderType = "ПК_Зачисление" Or orderType = "ПК_Зачисление_Доп" Then

            If Not НомерГруппы.Text = "" Then
                loadStudentsList()
                ListViewСписокСлушателей.Items.Insert(0, New ListViewItem("Выделить всех"))
                chekAllItem(ListViewСписокСлушателей)
            End If

        End If

    End Sub

    Sub loadModuls()

        Dim queryString As String
        Dim progs, teachers, result

        queryString = loadListModul(MainForm.prikazKodGroup)
        progs = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If progs(0, 0) = "нет записей" Then
            Exit Sub
        End If

        queryString = loadListSotrudnicModul(MainForm.prikazKodGroup)
        teachers = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If teachers(0, 0) = "нет записей" Then
            Exit Sub
        End If

        teachers = rotateArray(teachers)

        ReDim result(1, UBound(progs, 2))

        For i = 0 To UBound(progs, 2)
            result(0, i) = progs(0, i)
            result(1, i) = teachers(0, i)
        Next

        If ListViewСписокСлушателей.Columns.Count < 3 Then
            ListViewСписокСлушателей.Columns.Add("Преподаватель", 200)
        End If

        UpdateListView.updateListView(False, True, ListViewСписокСлушателей, result, 0, 1)

        Try
            ListViewСписокСлушателей.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

    End Sub

    Sub loadStudentsList()

        Dim queryString As String
        Dim students

        queryString = formOrder__loadStudentsList(MainForm.prikazKodGroup)

        students = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If students(0, 0) = "нет записей" Then
            Exit Sub
        End If

        UpdateListView.updateListView(True, False, ListViewСписокСлушателей, students, 0)

        Try
            ListViewСписокСлушателей.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub Комиссия3_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name
    End Sub

    Private Sub Комиссия2Должность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub СекретарьКомиссии_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub Комиссия3Должность_Click(sender As Object, e As EventArgs)
        ФормаСписок.textboxName = Me.ActiveControl.Name
        'ФормаСписок.FormName = Me.Name
        'ФормаСписок.ShowDialog()
    End Sub

    Private Sub СекретарьКомиссииДолжность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Private Sub ЗамПредседателя_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub
    Private Sub ЗамПредседателяДолжность_Click(sender As Object, e As EventArgs)

        ФормаСписок.textboxName = Me.ActiveControl.Name

    End Sub

    Function checkSuff() As Boolean

        Dim nameControl As String

        checkSuff = True

        For Each i In Me.Controls
            nameControl = i.Name
            If Strings.Left(i.Name, 8) <> "ListView" And Strings.Left(i.Name, 6) <> "Кнопка" And Strings.Left(i.Name, 8) <> "Включить" And i.Name <> "Сохранить" And i.Name <> "Очистить" And Strings.Left(i.Name, 5) <> "Label" And Strings.Left(i.Name, 5) <> "label" And Strings.Left(i.Name, 5) <> "Check" And Strings.Left(i.Name, 8) <> "GroupBox" Then

                If i.Text = "" And i.Visible = True And i.Enabled = True Then
                    checkSuff = False
                End If
            End If
        Next

    End Function
    Private Sub АСформироватьПриказ_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Call closeEsc(Me, e.KeyCode)

        If e.KeyCode = 38 Or e.KeyCode = 40 Then
            pressTab(e.KeyCode, 40)
            up(Me, e.KeyCode, 38)
            e.Handled = True
        End If

    End Sub
    Private Sub CheckBoxСанитар_GotFocus(sender As Object, e As EventArgs) Handles CheckBoxСанитар.GotFocus
        Call ШрифтКонтрола(ActiveControl, 10.0F)
    End Sub

    Private Sub CheckBoxСанитар_LostFocus(sender As Object, e As EventArgs) Handles CheckBoxСанитар.LostFocus
        Call ШрифтКонтрола(CheckBoxСанитар, 8.25F)
    End Sub
    Private Sub CheckBoxММС_GotFocus(sender As Object, e As EventArgs) Handles CheckBoxММС.GotFocus
        Call ШрифтКонтрола(ActiveControl, 10.0F)
    End Sub

    Private Sub CheckBoxММС_LostFocus(sender As Object, e As EventArgs) Handles CheckBoxММС.LostFocus
        Call ШрифтКонтрола(CheckBoxММС, 8.25F)
    End Sub

    Private Sub CheckBoxММС_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBoxММС.KeyDown
        ЧекатьНаИнтер(CheckBoxММС, e.KeyCode)
    End Sub

    Private Sub CheckBoxСанитар_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBoxСанитар.KeyDown
        ЧекатьНаИнтер(CheckBoxСанитар, e.KeyCode)
    End Sub

    Private Sub CheckBoxСанитар_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBoxСанитар.CheckedChanged
        ПрикрепитьЧекбокс(CheckBoxСанитар, CheckBoxММС)
    End Sub

    Private Sub CheckBoxММС_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxММС.CheckedChanged
        ПрикрепитьЧекбокс(CheckBoxММС, CheckBoxСанитар)
    End Sub

    Private Sub Утверждает_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Call Утверждает_Click(sender, e)

        End If
    End Sub


    Private Sub УтверждаетДолжность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            УтверждаетДолжность_Click(sender, e)

        End If
    End Sub

    Private Sub Ответственный_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Ответственный_Click(sender, e)

        End If
    End Sub

    Private Sub ОтветственныйДолжность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            ОтветственныйДолжность_Click(sender, e)

        End If
    End Sub

    Private Sub ПроектВносит_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            ПроектВносит_Click(sender, e)

        End If
    End Sub

    Private Sub ПроектВноситДолжность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            ПроектВноситДолжность_Click(sender, e)

        End If
    End Sub

    Private Sub Исполнитель_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Исполнитель_Click(sender, e)

        End If
    End Sub

    Private Sub ИсполнительДолжность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            ИсполнительДолжность_Click(sender, e)

        End If
    End Sub

    Private Sub Согласовано1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Согласовано1_Click(sender, e)

        End If
    End Sub

    Private Sub Согласовано1Должность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Согласовано1Должность_Click(sender, e)

        End If
    End Sub
    Private Sub Согласовано2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Согласовано2_Click(sender, e)

        End If
    End Sub

    Private Sub Согласовано2Должность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Согласовано2Должность_Click(sender, e)

        End If
    End Sub

    Private Sub РуководительСтажировки_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            РуководительСтажировки_Click(sender, e)

        End If
    End Sub
    Private Sub ДолжностьРуководительСтажировки_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            ДолжностьРуководительСтажировки_Click(sender, e)

        End If
    End Sub

    Private Sub Комиссия2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Комиссия2_Click(sender, e)

        End If
    End Sub

    Private Sub Комиссия2Должность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Комиссия2Должность_Click(sender, e)

        End If
    End Sub

    Private Sub Комиссия3Должность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Комиссия3Должность_Click(sender, e)

        End If
    End Sub
    Private Sub Комиссия3_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Комиссия3_Click(sender, e)

        End If
    End Sub
    Private Sub СекретарьКомиссии_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            СекретарьКомиссии_Click(sender, e)

        End If
    End Sub
    Private Sub СекретарьКомиссииДолжность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            СекретарьКомиссииДолжность_Click(sender, e)

        End If
    End Sub
    Private Sub ЗамПредседателя_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            ЗамПредседателя_Click(sender, e)

        End If
    End Sub
    Private Sub ЗамПредседателяДолжность_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            ЗамПредседателяДолжность_Click(sender, e)

        End If
    End Sub

    Private Sub ПОЗачисленииНомерГруппы_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерГруппы.KeyDown
        If e.KeyCode = 13 Then

            ПОЗачисленииНомерГруппы_Click(sender, e)

        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        ПрактическаяПодготовка.Text = ""
        ИтоговаяАттестация.Text = ""

        If Not CheckBox1.Checked Then

            Me.Size = New Size(840, 180)

            КнопкаСформировать.Location = New Point(135, 96)
            КнопкаОчистить.Location = New Point(2, 96)

            ПрактическаяПодготовка.Visible = False
            ИтоговаяАттестация.Visible = False

            Label24.Visible = False
            Label25.Visible = False

            ПрактическаяПодготовка.Location = New Point(260, 110)
            ИтоговаяАттестация.Location = New Point(260, 140)

            Label24.Location = New Point(20, 110)
            Label25.Location = New Point(20, 140)

        Else

            Me.Size = New Size(840, 300)
            КнопкаСформировать.Location = New Point(135, 215)
            КнопкаОчистить.Location = New Point(2, 215)

            ПрактическаяПодготовка.Location = New Point(260, 110)
            ИтоговаяАттестация.Location = New Point(260, 140)

            Label24.Location = New Point(20, 110)
            Label25.Location = New Point(20, 140)

            ПрактическаяПодготовка.Visible = True
            ИтоговаяАттестация.Visible = True

            Label24.Visible = True
            Label25.Visible = True

        End If

    End Sub

    Private Sub АСформироватьПриказ_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Утверждает.Visible = True
        УтверждаетДолжность.Visible = True
        Label2.Visible = True
        Label14.Visible = True
    End Sub

    Private Sub Включить5_CheckedChanged(sender As Object, e As EventArgs) Handles Включить5.CheckedChanged

        If Включить5.Checked = True Then
            Исполнитель.Enabled = True
        Else
            Исполнитель.Enabled = False
        End If

    End Sub

    Private Sub Включить6_CheckedChanged(sender As Object, e As EventArgs) Handles Включить6.CheckedChanged
        If Включить6.Checked = True Then
            Согласовано1.Enabled = True
        Else
            Согласовано1.Enabled = False
        End If
    End Sub

    Private Sub Ответственный_TextChanged(sender As Object, e As EventArgs) Handles Ответственный.TextChanged
        If Label4.Text <> "Слушатель(ФИО)" Then
            loadDolj(Ответственный, ОтветственныйДолжность)
        End If

    End Sub

    Private Sub ПроектВносит_TextChanged(sender As Object, e As EventArgs) Handles ПроектВносит.TextChanged
        If Not ПроектВносит.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(ПроектВносит, ПроектВноситДолжность)
        End If
    End Sub

    Private Sub Исполнитель_TextChanged(sender As Object, e As EventArgs) Handles Исполнитель.TextChanged
        If Not Исполнитель.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Исполнитель, ИсполнительДолжность)
        End If
    End Sub

    Private Sub Согласовано1_TextChanged(sender As Object, e As EventArgs) Handles Согласовано1.TextChanged
        If Not Согласовано1.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Согласовано1, Согласовано1Должность)
        End If
    End Sub

    Private Sub Согласовано2_TextChanged(sender As Object, e As EventArgs) Handles Согласовано2.TextChanged
        If Not Согласовано2.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Согласовано2, Согласовано2Должность)
        End If
    End Sub

    Private Sub РуководительСтажировки_TextChanged(sender As Object, e As EventArgs) Handles РуководительСтажировки.TextChanged
        If Not РуководительСтажировки.Text = "" Then
            loadDolj(РуководительСтажировки, РуководительСтажировкиДолжность)
        End If
    End Sub

    Private Sub Комиссия2_TextChanged(sender As Object, e As EventArgs) Handles Комиссия2.TextChanged
        If Not Комиссия2.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Комиссия2, Комиссия2Должность)
        End If
    End Sub

    Private Sub Комиссия3_TextChanged(sender As Object, e As EventArgs) Handles Комиссия3.TextChanged
        If Not Комиссия3.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(Комиссия3, Комиссия3Должность)
        End If
    End Sub

    Private Sub СекретарьКомиссии_TextChanged(sender As Object, e As EventArgs) Handles СекретарьКомиссии.TextChanged
        If Not СекретарьКомиссии.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(СекретарьКомиссии, СекретарьКомиссииДолжность)
        End If
    End Sub

    Private Sub ЗамПредседателя_TextChanged(sender As Object, e As EventArgs) Handles ЗамПредседателя.TextChanged
        If Not ЗамПредседателя.Text = "" And Me.Text <> "Спецэкзамен_протокол" Then
            loadDolj(ЗамПредседателя, ЗамПредседателяДолжность)
        End If
    End Sub

    Private Sub АСформироватьПриказ_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MainForm.prikazCvalif = 0
    End Sub

    Public Sub reload_lists()

        flagLoad = False
        АСформироватьПриказ_Load(New Object, New EventArgs)

    End Sub

    Private Sub АСформироватьПриказ_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not flagLoad Then

            prikaz.loadFormPrikazLists()

            LoadDoljnosti()

            Утверждает.Items.Clear()
            УтверждаетДолжность.Items.Add("")
            Утверждает.Items.AddRange(prikaz.formPrikazList.director)

            УтверждаетДолжность.Items.Clear()
            УтверждаетДолжность.Items.Add("")
            УтверждаетДолжность.Items.AddRange(prikaz.formPrikazList.directorDoljnost)

            Ответственный.Items.Clear()
            Ответственный.Items.Add("")
            Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)

            ПроектВносит.Items.Clear()
            ПроектВносит.Items.Add("")
            ПроектВносит.Items.AddRange(prikaz.formPrikazList.proect_vnosit)

            Исполнитель.Items.Clear()
            Исполнитель.Items.Add("")
            Исполнитель.Items.AddRange(prikaz.formPrikazList.ispolnitel)

            Согласовано1.Items.Clear()
            Согласовано1.Items.Add("")
            Согласовано1.Items.AddRange(prikaz.formPrikazList.soglasovano)

            Согласовано2.Items.Clear()
            Согласовано2.Items.Add("")
            Согласовано2.Items.AddRange(prikaz.formPrikazList.soglasovano)

            РуководительСтажировки.Items.Clear()
            РуководительСтажировки.Items.Add("")
            РуководительСтажировки.Items.AddRange(prikaz.formPrikazList.ruk_staj)

            Комиссия2.Items.Clear()
            Комиссия2.Items.Add("")
            Комиссия2.Items.AddRange(prikaz.formPrikazList.komissiya)

            Комиссия3.Items.Clear()
            Комиссия3.Items.Add("")
            Комиссия3.Items.AddRange(prikaz.formPrikazList.komissiya)

            СекретарьКомиссии.Items.Clear()
            СекретарьКомиссии.Items.Add("")
            СекретарьКомиссии.Items.AddRange(prikaz.formPrikazList.komissiya)

            ЗамПредседателя.Items.Clear()
            ЗамПредседателя.Items.Add("")
            ЗамПредседателя.Items.AddRange(prikaz.formPrikazList.komissiya)

            flagLoad = True

        End If

    End Sub

    Private Sub LoadDoljnosti()

        For Each control As Control In Me.Controls
            Dim type As String = control.GetType.ToString
            If (control.GetType.ToString <> "System.Windows.Forms.ComboBox") Then
                Continue For
            End If

            If Strings.Right(control.Name, 9) = "Должность" Then
                Dim comboB As ComboBox
                comboB = control
                comboB.Items.Clear()
                comboB.Items.Add("")
                comboB.Items.AddRange(prikaz.formPrikazList.doljnosti)
            End If
        Next
    End Sub


    Public Sub load_form()
        Dim sender As Object
        Dim e As EventArgs
        АСформироватьПриказ_Load(sender, e)
    End Sub

    Private Sub Ответственный_VisibleChanged(sender As Object, e As EventArgs) Handles Ответственный.VisibleChanged

        If Ответственный.Visible = True Then
            If Label4.Text = "Слушатель(ФИО)" Then
                prikaz.kod_groupp = Convert.ToString(kodGroup)
                prikaz.loadslushatelFio()
                Ответственный.Items.Clear()
                Ответственный.Items.Add("")
                Ответственный.Items.AddRange(prikaz.formPrikazList.slushatelFio)
            Else
                Ответственный.Items.Clear()
                Ответственный.Items.Add("")
                Ответственный.Items.AddRange(prikaz.formPrikazList.otv_attestat)
            End If
        End If

    End Sub

    Private Sub Утверждает_MouseLeave(sender As Object, e As EventArgs) Handles Утверждает.MouseLeave
        prikaz.formPrikazFlag.director = False
    End Sub

    Private Sub Утверждает_MouseMove(sender As Object, e As MouseEventArgs) Handles Утверждает.MouseMove
        prikaz.formPrikazFlag.director = True
    End Sub

    Private Sub Утверждает_Enter(sender As Object, e As EventArgs) Handles Утверждает.Enter
        If prikaz.formPrikazFlag.director Then
            Утверждает.DroppedDown = False
        Else
            Утверждает.DroppedDown = True
        End If
    End Sub

    Private Sub Ответственный_MouseLeave(sender As Object, e As EventArgs) Handles Ответственный.MouseLeave
        prikaz.formPrikazFlag.otv_attestat = False
    End Sub

    Private Sub Ответственный_MouseMove(sender As Object, e As MouseEventArgs) Handles Ответственный.MouseMove
        prikaz.formPrikazFlag.otv_attestat = True
    End Sub

    Private Sub Ответственный_Enter(sender As Object, e As EventArgs) Handles Ответственный.Enter
        If prikaz.formPrikazFlag.otv_attestat Then
            Ответственный.DroppedDown = False
        Else
            Ответственный.DroppedDown = True
        End If
    End Sub

    Private Sub ПроектВносит_MouseLeave(sender As Object, e As EventArgs) Handles ПроектВносит.MouseLeave
        prikaz.formPrikazFlag.proekt_vnosit = False
    End Sub

    Private Sub ПроектВносит_MouseMove(sender As Object, e As MouseEventArgs) Handles ПроектВносит.MouseMove
        prikaz.formPrikazFlag.proekt_vnosit = True
    End Sub

    Private Sub ПроектВносит_Enter(sender As Object, e As EventArgs) Handles ПроектВносит.Enter
        If prikaz.formPrikazFlag.proekt_vnosit Then
            ПроектВносит.DroppedDown = False
        Else
            ПроектВносит.DroppedDown = True
        End If
    End Sub

    Private Sub Исполнитель_MouseLeave(sender As Object, e As EventArgs) Handles Исполнитель.MouseLeave
        prikaz.formPrikazFlag.ispolnitel = False
    End Sub

    Private Sub Исполнитель_MouseMove(sender As Object, e As MouseEventArgs) Handles Исполнитель.MouseMove
        prikaz.formPrikazFlag.ispolnitel = True
    End Sub

    Private Sub Исполнитель_Enter(sender As Object, e As EventArgs) Handles Исполнитель.Enter
        If prikaz.formPrikazFlag.ispolnitel Then
            Исполнитель.DroppedDown = False
        Else
            Исполнитель.DroppedDown = True
        End If
    End Sub

    Private Sub Согласовано1_MouseLeave(sender As Object, e As EventArgs) Handles Согласовано1.MouseLeave
        prikaz.formPrikazFlag.soglasovano = False
    End Sub

    Private Sub Согласовано1_MouseMove(sender As Object, e As MouseEventArgs) Handles Согласовано1.MouseMove
        prikaz.formPrikazFlag.soglasovano = True
    End Sub

    Private Sub Согласовано1_Enter(sender As Object, e As EventArgs) Handles Согласовано1.Enter
        If prikaz.formPrikazFlag.soglasovano Then
            Согласовано1.DroppedDown = False
        Else
            Согласовано1.DroppedDown = True
        End If
    End Sub

    Private Sub Согласовано2_MouseLeave(sender As Object, e As EventArgs) Handles Согласовано2.MouseLeave
        prikaz.formPrikazFlag.soglasovano2 = False
    End Sub

    Private Sub Согласовано2_MouseMove(sender As Object, e As MouseEventArgs) Handles Согласовано2.MouseMove
        prikaz.formPrikazFlag.soglasovano2 = True
    End Sub

    Private Sub Согласовано2_Enter(sender As Object, e As EventArgs) Handles Согласовано2.Enter
        If prikaz.formPrikazFlag.soglasovano2 Then
            Согласовано2.DroppedDown = False
        Else
            Согласовано2.DroppedDown = True
        End If
    End Sub

    Private Sub РуководительСтажировки_MouseLeave(sender As Object, e As EventArgs) Handles РуководительСтажировки.MouseLeave
        prikaz.formPrikazFlag.rukovoditelStaj = False
    End Sub

    Private Sub РуководительСтажировки_MouseMove(sender As Object, e As MouseEventArgs) Handles РуководительСтажировки.MouseMove
        prikaz.formPrikazFlag.rukovoditelStaj = True
    End Sub

    Private Sub РуководительСтажировки_Enter(sender As Object, e As EventArgs) Handles РуководительСтажировки.Enter
        If prikaz.formPrikazFlag.rukovoditelStaj Then
            РуководительСтажировки.DroppedDown = False
        Else
            РуководительСтажировки.DroppedDown = True
        End If
    End Sub

    Private Sub Комиссия2_MouseLeave(sender As Object, e As EventArgs) Handles Комиссия2.MouseLeave
        prikaz.formPrikazFlag.komissiya2 = False
    End Sub

    Private Sub Комиссия2_MouseMove(sender As Object, e As MouseEventArgs) Handles Комиссия2.MouseMove
        prikaz.formPrikazFlag.komissiya2 = True
    End Sub

    Private Sub Комиссия2_Enter(sender As Object, e As EventArgs) Handles Комиссия2.Enter
        If prikaz.formPrikazFlag.komissiya2 Then
            Комиссия2.DroppedDown = False
        Else
            Комиссия2.DroppedDown = True
        End If
    End Sub

    Private Sub Комиссия3_MouseLeave(sender As Object, e As EventArgs) Handles Комиссия3.MouseLeave
        prikaz.formPrikazFlag.komissiya3 = False
    End Sub

    Private Sub Комиссия3_MouseMove(sender As Object, e As MouseEventArgs) Handles Комиссия3.MouseMove
        prikaz.formPrikazFlag.komissiya3 = True
    End Sub

    Private Sub Комиссия3_Enter(sender As Object, e As EventArgs) Handles Комиссия3.Enter
        If prikaz.formPrikazFlag.komissiya3 Then
            Комиссия3.DroppedDown = False
        Else
            Комиссия3.DroppedDown = True
        End If
    End Sub

    Private Sub СекретарьКомиссии_MouseLeave(sender As Object, e As EventArgs) Handles СекретарьКомиссии.MouseLeave
        prikaz.formPrikazFlag.sekretar = False
    End Sub

    Private Sub СекретарьКомиссии_MouseMove(sender As Object, e As MouseEventArgs) Handles СекретарьКомиссии.MouseMove
        prikaz.formPrikazFlag.sekretar = True
    End Sub

    Private Sub СекретарьКомиссии_Enter(sender As Object, e As EventArgs) Handles СекретарьКомиссии.Enter
        If prikaz.formPrikazFlag.sekretar Then
            СекретарьКомиссии.DroppedDown = False
        Else
            СекретарьКомиссии.DroppedDown = True
        End If
    End Sub

    Private Sub ЗамПредседателя_MouseLeave(sender As Object, e As EventArgs) Handles ЗамПредседателя.MouseLeave
        prikaz.formPrikazFlag.zam_pred = False
    End Sub

    Private Sub ЗамПредседателя_MouseMove(sender As Object, e As MouseEventArgs) Handles ЗамПредседателя.MouseMove
        prikaz.formPrikazFlag.zam_pred = True
    End Sub

    Private Sub ЗамПредседателя_Enter(sender As Object, e As EventArgs) Handles ЗамПредседателя.Enter
        If prikaz.formPrikazFlag.zam_pred Then
            ЗамПредседателя.DroppedDown = False
        Else
            ЗамПредседателя.DroppedDown = True
        End If
    End Sub

    Private Sub УтверждаетДолжность_MouseLeave(sender As Object, e As EventArgs) Handles УтверждаетДолжность.MouseLeave
        prikaz.formPrikazFlag.directorDoljnost = False
    End Sub

    Private Sub УтверждаетДолжность_MouseMove(sender As Object, e As MouseEventArgs) Handles УтверждаетДолжность.MouseMove
        prikaz.formPrikazFlag.directorDoljnost = True
    End Sub

    Private Sub УтверждаетДолжность_Enter(sender As Object, e As EventArgs) Handles УтверждаетДолжность.Enter
        If prikaz.formPrikazFlag.directorDoljnost Then
            УтверждаетДолжность.DroppedDown = False
        Else
            УтверждаетДолжность.DroppedDown = True
        End If
    End Sub

    Private Sub ListViewСписокСлушателей_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListViewСписокСлушателей.ItemChecked

        If orderType = "СправкаОбОбучении" Or orderType = "ПК_Зачисление" Or orderType = "ПК_Зачисление_Доп" Then
            If Not flagCheck Then
                flagCheck = True
                Return
            End If
            checkAllRow(ListViewСписокСлушателей, "Выделить всех", e.Item)
        End If

    End Sub

    Sub loadDolj(FIO As ComboBox, dolj As ComboBox)

        Dim queryString As String
        Dim quaryResult As Object

        Try
            If FIO.SelectedItem = "" Then
                Return
            End If
        Catch ex As Exception
            Dim message As String = ex.Message
        End Try


        queryString = formOrder__loadKodDolj(FIO.SelectedItem)

        quaryResult = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If quaryResult(0, 0).ToString = "нет записей" Or quaryResult(0, 0).ToString = "" Then

            Try
                FIO.SelectedItem = ""
            Catch ex As Exception
                Dim message As String = ex.Message
            End Try

            предупреждение.текст.Text = "Необходимо указать должность для этого сотрудника в БД!"
            ОткрытьФорму(предупреждение)
            Return

        End If

        queryString = formOrder__loadNameDolj(quaryResult(0, 0).ToString)
        quaryResult = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If quaryResult(0, 0).ToString = "нет записей" Or quaryResult(0, 0).ToString = "" Then

            FIO.SelectedItem = ""
            предупреждение.текст.Text = "Ошибка. Строка запроса " + queryString
            ОткрытьФорму(предупреждение)
            Return
        Else
            dolj.Text = quaryResult(0, 0)
        End If
    End Sub

End Class