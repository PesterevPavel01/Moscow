Imports System.Threading
Public Class НовыйСлушатель
    Public Press As Boolean
    Dim SC As SynchronizationContext
    Public ВызваноСФормыСписокСлушателей As Boolean = False
    Dim formSlushList As New Slushatel.formSlushatelLists
    Public slushatel As New Slushatel

    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        Dim ВторойПоток As Thread
        Dim ДлинаСнилс As Integer
        Dim СнилсЧисло As Long
        SC = SynchronizationContext.Current
        slushatel.clearStructSlushatel()
        ActiveControl = BtnFocus
        Сообщение.Visible = False
        ДлинаСнилс = Len(Снилс.Text)

        If ДлинаСнилс <> 14 Then
            MsgBox("Снилс введен некорректно")
            Exit Sub
        End If

        Try
            СнилсЧисло = ДобавитьРубашку.УдалитьРубашку(Снилс.Text)
        Catch ex As Exception
            MsgBox("Снилс введен некорректно")
            Exit Sub
        End Try

        If ValidOn.Checked Then
            If Not АнализСнилс.ПроверкаСнилс(ДобавитьРубашку.УдалитьРубашку(Снилс.Text)) Then
                MsgBox("Снилс не прошел проверку")
                Exit Sub
            End If
        End If

        If ДатаРождения.Value.ToShortDateString = "01.01.1753" Then
            MsgBox("Установите дату в поле Дата рождения")
            Exit Sub
        End If

        If Снилс.Text = "" Then
            MsgBox("Заполните поле 'СНИЛС'")
            Exit Sub
        End If

        If Фамилия.Text = "" Then
            MsgBox("Укажите Фамилию слушателя")
            Exit Sub
        End If

        If ИсточникФин.Text = "" Then
            MsgBox("Укажите источник финансирования")
            Exit Sub
        End If

        If Not Интерфейс.formStudentValidation(Me) Then
            Try
                предупреждение.ShowDialog()
            Catch ex As Exception
                предупреждение.Close()
                предупреждение.ShowDialog()
            End Try
            Exit Sub
        End If

        If ВызваноСФормыСписокСлушателей Then
            slushatel.structSlushatel.kodGroup = СправочникГруппы.kod
            ВызваноСФормыСписокСлушателей = False
        Else
            slushatel.structSlushatel.kodGroup = -1
        End If

        slushatel.structSlushatel.snils = ДобавитьРубашку.УдалитьРубашку(Снилс.Text)
        slushatel.structSlushatel.фамилия = Фамилия.Text
        slushatel.structSlushatel.имя = Имя.Text
        slushatel.structSlushatel.отчество = Отчество.Text
        slushatel.structSlushatel.датаР = MainForm.mySqlConnect.dateToFormatMySQL(ДатаРождения.Value.ToShortDateString)
        slushatel.structSlushatel.пол = Пол.Text
        slushatel.structSlushatel.уровеньОбразования = УровеньОбразования.Text
        slushatel.structSlushatel.образование = Образование.Text
        slushatel.structSlushatel.серияДокументаООбразовании = СерияДокументаООбразовании.Text
        slushatel.structSlushatel.номерДокументаООбразовании = НомерДокументаООбразовании.Text
        slushatel.structSlushatel.фамилияВДокОбОбразовании = ФамилияВДокОбОбразовании.Text
        slushatel.structSlushatel.адресРегистрации = АдресРегистрации.Text
        slushatel.structSlushatel.телефон = Телефон.Text
        slushatel.structSlushatel.гражданство = Гражданство.Text
        slushatel.structSlushatel.ДУЛ = ДУЛ.Text
        slushatel.structSlushatel.серияДУЛ = СерияДУЛ.Text
        slushatel.structSlushatel.номерДУЛ = НомерДУЛ.Text
        slushatel.structSlushatel.источникФин = ИсточникФин.Text
        slushatel.structSlushatel.направившаяОрг = НаправившаяОрг.Text
        slushatel.structSlushatel.номерНаправленияРосздравнадзора = НомерНаправленияРосздравнадзора.Text
        slushatel.structSlushatel.датаНаправленияРосздравнвдзора = MainForm.mySqlConnect.dateToFormatMySQL(ДатаНаправленияРосздравнвдзора.Value.ToShortDateString)
        slushatel.structSlushatel.датаРег = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)
        slushatel.structSlushatel.Email = Email.Text
        slushatel.structSlushatel.doo_vid_dok = doo_vid_dok.Text


        If ДатаВыдачиДУЛ.Value.ToShortDateString = "01.01.1753" Then

            slushatel.structSlushatel.датаВыдачиДУЛ = "null"
        Else
            slushatel.structSlushatel.датаВыдачиДУЛ = MainForm.mySqlConnect.dateToFormatMySQL(ДатаВыдачиДУЛ.Value.ToShortDateString)
        End If
        slushatel.structSlushatel.кемВыданДУЛ = КемВыданДУЛ.Text
        slushatel.structSlushatel.snilsRub = Снилс.Text
        ВторойПоток = New Thread(AddressOf ДобавитьСлушателя)
        ВторойПоток.IsBackground = True
        ВторойПоток.Start(slushatel)
    End Sub

    Sub ДобавитьСлушателя(slushatel As Slushatel)

        SC.Send(AddressOf ЗаблокироватьКнопки, 1)

        If slushatel.insertSlushatel() Then

            SC.Send(AddressOf ЗаписьВСтатус, ДобавитьРубашку.ДобавитьРубашку(slushatel.structSlushatel.snils))
            SC.Send(AddressOf ЗаполнитьФормуССлушВГруппе.updateFormStudentsList, slushatel.structSlushatel.kodGroup)

        End If

        SC.Send(AddressOf РазблокироватьКнопки, ДобавитьРубашку.ДобавитьРубашку(slushatel.structSlushatel.snils))

    End Sub
    Sub ЗаписьВСтатус(Слушатель As String)
        Сообщение.Visible = True
        Сообщение.Text = "Слушатель " & Слушатель & " успешно зарегистрирован"
    End Sub

    Sub ОбновлениеСнилс(текст As String)
        Снилс.Text = текст
    End Sub

    Sub РазблокироватьКнопки(Слушатель As String)
        Сохранить.Enabled = True
    End Sub

    Sub ЗаблокироватьКнопки(Слушатель As Integer)
        Сохранить.Enabled = False
    End Sub

    Private Sub Очистить_Click(sender As Object, e As EventArgs) Handles Очистить.Click
        Dim nameControl As String

        ActiveControl = BtnFocus

        Сообщение.Visible = False
        For Each i In Me.Controls
            nameControl = i.Name
            nameControl = Strings.Left(nameControl, 5)
            If i.Name <> "Сохранить" And i.Name <> "Очистить" And nameControl <> "Label" And nameControl <> "label" Then

                If i.Name = "ДатаРождения" Or i.Name = "ДатаОкончания" Or i.Name = "ДатаНаправленияРосздравнвдзора" Or i.Name = "ДатаВыдачиДУЛ" Then
                    i.Text = "01.01.1753"
                Else
                    i.Text = ""
                End If
            End If
        Next

        Сообщение.Visible = False

    End Sub

    Private Sub Снилс_TextChanged(sender As Object, e As EventArgs) Handles Снилс.TextChanged
        Dim snils As String
        If Not Press Then

            Снилс.Text = ДобавитьРубашку.РубашкаНаВвод(Снилс.Text, 3, 3, 3, 14)

        End If
        Press = False
        Снилс.SelectionStart = Len(Снилс.Text)
        snils = УдалитьРубашку(Снилс.Text)
        If Len(snils) = 11 Then

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "students"
            InsertIntoDataBase.argument.firstName = "Снилс"
            InsertIntoDataBase.argument.firstValue = snils

            If InsertIntoDataBase.checkDuplicates() Then
                Снилс.BackColor = Color.Pink
            Else
                Снилс.BackColor = SystemColors.Window
            End If
        Else
            Снилс.BackColor = SystemColors.Window
        End If


    End Sub

    Private Sub Снилс_KeyDown(sender As Object, e As KeyEventArgs) Handles Снилс.KeyDown

        Сообщение.Visible = False

        Dim str As String


        str = Снилс.Text


        If e.KeyCode = 8 Then
            Press = True
            Снилс.Text = ДобавитьРубашку.УдалитьДефисВРубашке(str)
        End If

        If e.KeyCode = 13 Then
            Снилс_Click(sender, e)
        End If


    End Sub

    Private Sub Снилс_Click(sender As Object, e As EventArgs) Handles Снилс.Click
        Сообщение.Visible = False
    End Sub

    Private Sub Фамилия_Click(sender As Object, e As EventArgs) Handles Фамилия.Click
        Сообщение.Visible = False
    End Sub

    Private Sub Имя_Click(sender As Object, e As EventArgs) Handles Имя.Click
        Сообщение.Visible = False
    End Sub

    Private Sub Отчество_Click(sender As Object, e As EventArgs) Handles Отчество.Click
        Сообщение.Visible = False
    End Sub

    Private Sub ДатаРождения_Click(sender As Object, e As EventArgs) Handles ДатаРождения.Click
        Сообщение.Visible = False
    End Sub

    Private Sub Образование_Click(sender As Object, e As EventArgs) Handles Образование.Click
        Сообщение.Visible = False
    End Sub

    Private Sub СерияДокументаООбразовании_Click(sender As Object, e As EventArgs) Handles СерияДокументаООбразовании.Click
        Сообщение.Visible = False
    End Sub

    Private Sub НомерДокументаООбразовании_Click(sender As Object, e As EventArgs) Handles НомерДокументаООбразовании.Click
        Сообщение.Visible = False
    End Sub

    Private Sub ФамилияВДокОбОбразовании_Click(sender As Object, e As EventArgs) Handles ФамилияВДокОбОбразовании.Click
        Сообщение.Visible = False
    End Sub

    Private Sub АдресРегистрации_Click(sender As Object, e As EventArgs) Handles АдресРегистрации.Click
        Сообщение.Visible = False
    End Sub

    Private Sub Телефон_Click(sender As Object, e As EventArgs) Handles Телефон.Click
        Сообщение.Visible = False
    End Sub

    Private Sub СерияДУЛ_Click(sender As Object, e As EventArgs) Handles СерияДУЛ.Click
        Сообщение.Visible = False
    End Sub

    Private Sub НомерДУЛ_Click(sender As Object, e As EventArgs) Handles НомерДУЛ.Click
        Сообщение.Visible = False
    End Sub

    Private Sub РегистрационныйНомерУдостоверения_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
    End Sub

    Private Sub НомерБланкаУдостоверения_Click(sender As Object, e As EventArgs) Handles НомерНаправленияРосздравнадзора.Click
        Сообщение.Visible = False
    End Sub

    Private Sub НомерБланкаДиплома_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
    End Sub

    Private Sub НовыйСлушатель_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CheckBox1.Checked = True
        Очистить_Click(sender, e)
        ActiveControl = Снилс
    End Sub

    Private Sub Фамилия_TextChanged(sender As Object, e As EventArgs) Handles Фамилия.TextChanged
        If CheckBox1.Checked = True Then

            ФамилияВДокОбОбразовании.Text = Фамилия.Text

        End If
    End Sub

    Private Sub Фамилия_KeyDown(sender As Object, e As KeyEventArgs) Handles Фамилия.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Имя_KeyDown(sender As Object, e As KeyEventArgs) Handles Имя.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Отчество_KeyDown(sender As Object, e As KeyEventArgs) Handles Отчество.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub ДатаРождения_KeyDown(sender As Object, e As KeyEventArgs) Handles ДатаРождения.KeyDown
        If e.KeyCode = 13 Then

            Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Образование_KeyDown(sender As Object, e As KeyEventArgs) Handles Образование.KeyDown
        If e.KeyCode = 13 Then

            Call Образование_Click(sender, e)

        End If
    End Sub

    Private Sub СерияДокументаООбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles СерияДокументаООбразовании.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub НомерДокументаООбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерДокументаООбразовании.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub ФамилияВДокОбОбразовании_KeyDown(sender As Object, e As KeyEventArgs) Handles ФамилияВДокОбОбразовании.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub АдресРегистрации_KeyDown(sender As Object, e As KeyEventArgs) Handles АдресРегистрации.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Телефон_KeyDown(sender As Object, e As KeyEventArgs) Handles Телефон.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub Гражданство_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then

            Call Гражданство_Click(sender, e)

        End If
    End Sub

    Private Sub СерияДУЛ_KeyDown(sender As Object, e As KeyEventArgs) Handles СерияДУЛ.KeyDown
        If e.KeyCode = 13 Then

            Call Фамилия_Click(sender, e)

        End If
    End Sub

    Private Sub НомерДУЛ_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерДУЛ.KeyDown
        If e.KeyCode = 13 Then
            Фамилия_Click(sender, e)
        End If
    End Sub

    Private Sub РегистрационныйНомерУдостоверения_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            Фамилия_Click(sender, e)
        End If

    End Sub

    Private Sub НомерБланкаУдостоверения_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерНаправленияРосздравнадзора.KeyDown

        If e.KeyCode = 13 Then
            Фамилия_Click(sender, e)
        End If

    End Sub

    Private Sub НомерБланкаДиплома_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            НомерБланкаДиплома_Click(sender, e)
        End If

    End Sub

    Private Sub НовыйСлушатель_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        closeEsc(Me, e.KeyCode)

        If e.KeyCode = 38 Or e.KeyCode = 40 Then
            pressTab(e.KeyCode, 40)
            up(Me, e.KeyCode, 38)
            e.Handled = True
        End If

    End Sub

    Private Sub НовыйСлушатель_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        slushatel.loadFormSlushLists()

        doo_vid_dok.Items.Clear()
        doo_vid_dok.Items.Add("")
        doo_vid_dok.Items.AddRange(slushatel.formSlushLists.doo_vid_dok)

        Пол.Items.Clear()
        Пол.Items.Add("")
        Пол.Items.AddRange(slushatel.formSlushLists.pol)

        УровеньОбразования.Items.Clear()
        УровеньОбразования.Items.Add("")
        УровеньОбразования.Items.AddRange(slushatel.formSlushLists.urovenObr)

        Гражданство.Items.Clear()
        Гражданство.Items.Add("")
        Гражданство.Items.AddRange(slushatel.formSlushLists.grajdanstvo)

        ДУЛ.Items.Clear()
        ДУЛ.Items.Add("")
        ДУЛ.Items.AddRange(slushatel.formSlushLists.dok_UL)

        ИсточникФин.Items.Clear()
        ИсточникФин.Items.Add("")
        ИсточникФин.Items.AddRange(slushatel.formSlushLists.ist_finans)

        НаправившаяОрг.Items.Clear()
        НаправившаяОрг.Items.Add("")
        НаправившаяОрг.Items.AddRange(slushatel.formSlushLists.napr_organization)

    End Sub

    Private Sub НаправившаяОрг_Enter(sender As Object, e As EventArgs) Handles НаправившаяОрг.Enter

        If slushatel.flagSlushatelForm.napr_organization Then
            НаправившаяОрг.DroppedDown = False
        Else
            НаправившаяОрг.DroppedDown = True
        End If

    End Sub

    Private Sub ИсточникФин_Enter(sender As Object, e As EventArgs) Handles ИсточникФин.Enter
        If slushatel.flagSlushatelForm.ist_finans Then
            ИсточникФин.DroppedDown = False
        Else
            ИсточникФин.DroppedDown = True
        End If
    End Sub

    Private Sub ИсточникФин_MouseMove(sender As Object, e As MouseEventArgs) Handles ИсточникФин.MouseMove
        slushatel.flagSlushatelForm.ist_finans = True
    End Sub

    Private Sub ИсточникФин_MouseLeave(sender As Object, e As EventArgs) Handles ИсточникФин.MouseLeave
        slushatel.flagSlushatelForm.ist_finans = False
    End Sub

    Private Sub Пол_MouseMove(sender As Object, e As MouseEventArgs) Handles Пол.MouseMove
        slushatel.flagSlushatelForm.pol = True
    End Sub

    Private Sub Пол_MouseLeave(sender As Object, e As EventArgs) Handles Пол.MouseLeave
        slushatel.flagSlushatelForm.pol = False
    End Sub

    Private Sub Пол_Enter(sender As Object, e As EventArgs) Handles Пол.Enter
        If slushatel.flagSlushatelForm.pol Then
            Пол.DroppedDown = False
        Else
            Пол.DroppedDown = True
        End If
    End Sub

    Private Sub УровеньОбразования_MouseLeave(sender As Object, e As EventArgs) Handles УровеньОбразования.MouseLeave
        slushatel.flagSlushatelForm.urovenObr = False
    End Sub

    Private Sub УровеньОбразования_MouseMove(sender As Object, e As MouseEventArgs) Handles УровеньОбразования.MouseMove
        slushatel.flagSlushatelForm.urovenObr = True
    End Sub

    Private Sub УровеньОбразования_Enter(sender As Object, e As EventArgs) Handles УровеньОбразования.Enter
        If slushatel.flagSlushatelForm.urovenObr Then
            УровеньОбразования.DroppedDown = False
        Else
            УровеньОбразования.DroppedDown = True
        End If
    End Sub

    Private Sub СтранаДОО_MouseLeave(sender As Object, e As EventArgs)
        slushatel.flagSlushatelForm.DOO_strana = False
    End Sub

    Private Sub СтранаДОО_MouseMove(sender As Object, e As MouseEventArgs)
        slushatel.flagSlushatelForm.DOO_strana = True
    End Sub

    Private Sub Гражданство_MouseLeave(sender As Object, e As EventArgs) Handles Гражданство.MouseLeave
        slushatel.flagSlushatelForm.grajdanstvo = False
    End Sub

    Private Sub Гражданство_MouseMove(sender As Object, e As MouseEventArgs) Handles Гражданство.MouseMove
        slushatel.flagSlushatelForm.grajdanstvo = True
    End Sub

    Private Sub Гражданство_Enter(sender As Object, e As EventArgs) Handles Гражданство.Enter
        If slushatel.flagSlushatelForm.grajdanstvo Then
            Гражданство.DroppedDown = False
        Else
            Гражданство.DroppedDown = True
        End If
    End Sub

    Private Sub ДУЛ_MouseLeave(sender As Object, e As EventArgs) Handles ДУЛ.MouseLeave
        slushatel.flagSlushatelForm.dok_UL = False
    End Sub

    Private Sub ДУЛ_MouseMove(sender As Object, e As MouseEventArgs) Handles ДУЛ.MouseMove
        slushatel.flagSlushatelForm.dok_UL = True
    End Sub

    Private Sub ДУЛ_Enter(sender As Object, e As EventArgs) Handles ДУЛ.Enter
        If slushatel.flagSlushatelForm.dok_UL Then
            ДУЛ.DroppedDown = False
        Else
            ДУЛ.DroppedDown = True
        End If
    End Sub

    Private Sub НаправившаяОрг_MouseLeave(sender As Object, e As EventArgs) Handles НаправившаяОрг.MouseLeave
        slushatel.flagSlushatelForm.napr_organization = False
    End Sub

    Private Sub НаправившаяОрг_MouseMove(sender As Object, e As MouseEventArgs) Handles НаправившаяОрг.MouseMove
        slushatel.flagSlushatelForm.napr_organization = True
    End Sub

    Private Sub Пол_Click(sender As Object, e As EventArgs) Handles Пол.Click
        Сообщение.Visible = False
    End Sub

    Private Sub УровеньОбразования_Click(sender As Object, e As EventArgs) Handles УровеньОбразования.Click
        Сообщение.Visible = False
    End Sub

    Private Sub Гражданство_Click(sender As Object, e As EventArgs) Handles Гражданство.Click
        Сообщение.Visible = False
    End Sub

    Private Sub ДУЛ_Click(sender As Object, e As EventArgs) Handles ДУЛ.Click
        Сообщение.Visible = False
    End Sub

    Private Sub ИсточникФин_Click(sender As Object, e As EventArgs) Handles ИсточникФин.Click
        Сообщение.Visible = False
    End Sub

    Private Sub НаправившаяОрг_Click(sender As Object, e As EventArgs) Handles НаправившаяОрг.Click
        Сообщение.Visible = False
    End Sub

    Private Sub ValidOn_KeyDown(sender As Object, e As KeyEventArgs) Handles ValidOn.KeyDown
        ЧекатьНаИнтер(ValidOn, e.KeyCode)
    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        ЧекатьНаИнтер(CheckBox1, e.KeyCode)
    End Sub

    Private Sub ValidOn_Enter(sender As Object, e As EventArgs) Handles ValidOn.Enter
        ValidOn.BackColor = Color.LightGray
    End Sub

    Private Sub ValidOn_Leave(sender As Object, e As EventArgs) Handles ValidOn.Leave
        ValidOn.BackColor = Color.Transparent
    End Sub

    Private Sub CheckBox1_Enter(sender As Object, e As EventArgs) Handles CheckBox1.Enter
        CheckBox1.BackColor = Color.LightGray
    End Sub

    Private Sub CheckBox1_Leave(sender As Object, e As EventArgs) Handles CheckBox1.Leave
        CheckBox1.BackColor = Color.Transparent
    End Sub

    Private Sub doo_vid_dok_MouseLeave(sender As Object, e As EventArgs) Handles doo_vid_dok.MouseLeave
        slushatel.flagSlushatelForm.doo_vid_dok = False
    End Sub

    Private Sub doo_vid_dok_MouseMove(sender As Object, e As MouseEventArgs) Handles doo_vid_dok.MouseMove
        slushatel.flagSlushatelForm.doo_vid_dok = True
    End Sub

    Private Sub doo_vid_dok_Enter(sender As Object, e As EventArgs) Handles doo_vid_dok.Enter

        If slushatel.flagSlushatelForm.doo_vid_dok Then
            doo_vid_dok.DroppedDown = False
        Else
            doo_vid_dok.DroppedDown = True
        End If

    End Sub

End Class