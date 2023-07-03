
Imports System.Threading
Public Class РедакторСлушателя
    Public Press As Boolean
    Public СтарыйСнилс As String
    Public prevFormSpisSlushVGr As Boolean = False
    Dim slushatel As New Slushatel
    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        Dim Часть1 As String, Часть2 As String, Часть3 As String, Часть4 As String
        Dim Data, sqlString As String
        Dim DataString As String, ДатаВыдачиДул, СтрокаЗапроса As String

        ActiveControl = BtnFocus
        Сообщение.Visible = False
        slushatel.clearStructSlushatel()
        slushatel.structSlushatel.snils = ДобавитьРубашку.УдалитьРубашку(Снилс.Text)
        slushatel.structSlushatel.старыйСнилс = СтарыйСнилс
        slushatel.structSlushatel.фамилия = Фамилия.Text
        slushatel.structSlushatel.имя = Имя.Text
        slushatel.structSlushatel.отчество = Отчество.Text
        slushatel.structSlushatel.датаР = ДатаРождения.Value.ToShortDateString
        slushatel.structSlushatel.уровеньОбразования = УровеньОбразования.Text
        slushatel.structSlushatel.образование = Образование.Text
        slushatel.structSlushatel.серияДокументаООбразовании = СерияДокументаООбразовании.Text
        slushatel.structSlushatel.номерДокументаООбразовании = НомерДокументаООбразовании.Text
        slushatel.structSlushatel.фамилияВДокОбОбразовании = ФамилияВДокОбОбразовании.Text
        slushatel.structSlushatel.адресРегистрации = АдресРегистрации.Text
        slushatel.structSlushatel.гражданство = Гражданство.Text
        slushatel.structSlushatel.телефон = Телефон.Text
        slushatel.structSlushatel.ДУЛ = ДУЛ.Text
        slushatel.structSlushatel.серияДУЛ = СерияДУЛ.Text
        slushatel.structSlushatel.номерДУЛ = НомерДУЛ.Text
        slushatel.structSlushatel.источникФин = ИсточникФин.Text
        slushatel.structSlushatel.направившаяОрг = НаправившаяОрг.Text
        slushatel.structSlushatel.номерНаправленияРосздравнадзора = НомерНаправленияРосздравнадзора.Text
        slushatel.structSlushatel.датаНаправленияРосздравнвдзора = ДатаНаправленияРосздравнвдзора.Value.ToShortDateString
        slushatel.structSlushatel.Email = Email.Text
        slushatel.structSlushatel.датаРег = Date.Now.ToShortDateString
        slushatel.structSlushatel.датаВыдачиДУЛ = Me.ДатаВыдачиДУЛ.Value.ToShortDateString
        slushatel.structSlushatel.кемВыданДУЛ = КемВыданДУЛ.Text
        slushatel.structSlushatel.пол = Пол.Text
        slushatel.structSlushatel.doo_vid_dok = doo_vid_dok.Text

        If Not ПроверитьЗаполненностьРедСлушателя() Then
            Exit Sub
        End If

        If Me.ДатаВыдачиДУЛ.Value.ToShortDateString = "01.01.1753" Then
            slushatel.structSlushatel.датаВыдачиДУЛ = "null"
        Else
            slushatel.structSlushatel.датаВыдачиДУЛ = Me.ДатаВыдачиДУЛ.Value.ToShortDateString
        End If

        If ЗаписьВБазу.ПроверкаСовпадений("Слушатель", "Снилс", slushatel.structSlushatel.snils) Then
            ФормаДаНет.ShowDialog()
            If Not ЗаписьВБазу.УдалитьСовпадения Then
                Exit Sub
            End If
            ЗаписьВБазу.УдалитьСовпадения = False
        End If

        If Not slushatel.structSlushatel.snils = slushatel.structSlushatel.старыйСнилс Then
            sqlString = "DELETE FROM Слушатель WHERE Снилс= " & Chr(39) & slushatel.structSlushatel.snils & Chr(39)
            ААОсновная.mySqlConnect.ОтправитьВбдЗапись(sqlString, 1)

            sqlString = "DELETE FROM СоставГрупп WHERE Слушатель= " & Chr(39) & slushatel.structSlushatel.snils & Chr(39)
            ААОсновная.mySqlConnect.ОтправитьВбдЗапись(sqlString, 1)
            prevFormSpisSlushVGr = False
        End If

        СтарыйСнилс = slushatel.structSlushatel.snils

        sqlString = updateSlushatel(slushatel.structSlushatel)
        ААОсновная.mySqlConnect.ОтправитьВбдЗапись(sqlString, 1)

        If ЗаписьВБазу.ПроверкаСовпадений("Слушатель", "Снилс", slushatel.structSlushatel.snils, "ДатаРегистрации", ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.structSlushatel.датаРег)) Then

            Сообщение.Text = "Слушатель " & slushatel.structSlushatel.snils & " успешно зарегистрирован, дата записи: " & slushatel.structSlushatel.датаРег
            Сообщение.Visible = True
            СтарыйСнилс = slushatel.structSlushatel.snils
            Me.Text = slushatel.structSlushatel.фамилия & " " & slushatel.structSlushatel.имя & " " & slushatel.structSlushatel.отчество

            Call ИзменениеВыделеннойСтрокиВListView.ИзменениеВыделеннойСтрокиВListView("СправочникСлушатели", 1, ДобавитьРубашку.ДобавитьРубашку(slushatel.structSlushatel.snils), 2, slushatel.structSlushatel.фамилия, 3, slushatel.structSlushatel.имя, 4, slushatel.structSlushatel.отчество)

            sqlString = " UPDATE СоставГрупп SET Слушатель = " & Chr(39) & slushatel.structSlushatel.snils & Chr(39) & " WHERE Слушатель = " & Chr(39) & slushatel.structSlushatel.старыйСнилс & Chr(39)
            ААОсновная.mySqlConnect.ОтправитьВбдЗапись(sqlString, 1)

        Else Сообщение.Text = "Произошла ошибка, слушатель не найден"


        End If
    End Sub

    Private Sub Пол_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ОткрытьФорму(ФормаСписок)

    End Sub


    Private Sub УровеньОбразования_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ОткрытьФорму(ФормаСписок)

    End Sub

    Private Sub ИсточникФин_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ОткрытьФорму(ФормаСписок)

    End Sub

    Private Sub ДУЛ_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ОткрытьФорму(ФормаСписок)

    End Sub


    Private Sub Гражданство_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ОткрытьФорму(ФормаСписок)


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
            If ЗаписьВБазу.ПроверкаСовпадений("Слушатель", "Снилс", snils) And СтарыйСнилс <> snils Then
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


    Private Sub НаправившаяОрг_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ОткрытьФорму(ФормаСписок)

    End Sub

    Private Sub РегистрационныйНомерУдостоверения_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
    End Sub

    Private Sub НомерБланкаУдостоверения_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
    End Sub

    Private Sub РегНомерДиплома_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
    End Sub

    Private Sub НомерБланкаДиплома_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
    End Sub

    Private Sub РедакторСлушателя_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If ФормаСправочникСлушатели.ИнформацияОСлушателе(0, 0).ToString = "нет записей" Then
            Me.Close()
            предупреждение.текст.Text = "Ошибка. Некорректный СНИЛС в базе. Необходима ручная проверка базы!"
            ОткрытьФорму(предупреждение)
        Else
            СтарыйСнилс = УдалитьРубашку(ФормаСправочникСлушатели.ИнформацияОСлушателе(1, 0))
            Сообщение.Visible = False
            ActiveControl = BtnFocus

            slushatel.loadFormSlushLists()

            loadLists()

            ЗаполнитьРедакторСлушателя.ЗаполнитьРедакторСлушателя()

        End If

        ActiveControl = Снилс

    End Sub

    Private Sub Фамилия_TextChanged(sender As Object, e As EventArgs) Handles Фамилия.TextChanged

        If CheckBox1.Checked = True Then
            ФамилияВДокОбОбразовании.Text = Фамилия.Text
        End If

    End Sub

    Private Sub Пол_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            Пол_Click(sender, e)
        End If

    End Sub

    Private Sub УровеньОбразования_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            УровеньОбразования_Click(sender, e)
        End If

    End Sub

    Private Sub Образование_KeyDown(sender As Object, e As KeyEventArgs) Handles Образование.KeyDown

        If e.KeyCode = 13 Then
            Образование_Click(sender, e)
        End If

    End Sub

    Private Sub Гражданство_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            Гражданство_Click(sender, e)
        End If

    End Sub

    Private Sub ИсточникФин_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            ИсточникФин_Click(sender, e)
        End If

    End Sub

    Private Sub НаправившаяОрг_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            НаправившаяОрг_Click(sender, e)
        End If

    End Sub

    Private Sub ДУЛ_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = 13 Then
            ДУЛ_Click(sender, e)
        End If

    End Sub


    Private Sub РедакторСлушателя_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        ЗакрытьEsc(Me, e.KeyCode)
        If e.KeyCode = 38 Or e.KeyCode = 40 Then
            функционалТаб(e.KeyCode, 40)
            перемещениеВверх(Me, e.KeyCode, 38)
            e.Handled = True
        End If

    End Sub

    Private Sub СпециальностьСлушателя_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ОткрытьФорму(ФормаСписок)
    End Sub

    Private Sub СтранаДОО_Click(sender As Object, e As EventArgs)
        Сообщение.Visible = False
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ОткрытьФорму(ФормаСписок)
    End Sub

    Private Sub СтранаДОО_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            СтранаДОО_Click(sender, e)
        End If
    End Sub

    Private Sub loadLists()

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

    Private Sub Пол_MouseLeave(sender As Object, e As EventArgs) Handles Пол.MouseLeave
        slushatel.flagSlushatelForm.pol = False
    End Sub

    Private Sub Пол_MouseMove(sender As Object, e As MouseEventArgs) Handles Пол.MouseMove
        slushatel.flagSlushatelForm.pol = True
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

    Private Sub ИсточникФин_MouseLeave(sender As Object, e As EventArgs) Handles ИсточникФин.MouseLeave
        slushatel.flagSlushatelForm.ist_finans = False
    End Sub

    Private Sub ИсточникФин_MouseMove(sender As Object, e As MouseEventArgs) Handles ИсточникФин.MouseMove
        slushatel.flagSlushatelForm.ist_finans = True
    End Sub

    Private Sub ИсточникФин_Enter(sender As Object, e As EventArgs) Handles ИсточникФин.Enter
        If slushatel.flagSlushatelForm.ist_finans Then
            ИсточникФин.DroppedDown = False
        Else
            ИсточникФин.DroppedDown = True
        End If
    End Sub

    Private Sub НаправившаяОрг_MouseLeave(sender As Object, e As EventArgs) Handles НаправившаяОрг.MouseLeave
        slushatel.flagSlushatelForm.napr_organization = False
    End Sub

    Private Sub НаправившаяОрг_MouseMove(sender As Object, e As MouseEventArgs) Handles НаправившаяОрг.MouseMove
        slushatel.flagSlushatelForm.napr_organization = True
    End Sub

    Private Sub НаправившаяОрг_Enter(sender As Object, e As EventArgs) Handles НаправившаяОрг.Enter
        If slushatel.flagSlushatelForm.napr_organization Then
            НаправившаяОрг.DroppedDown = False
        Else
            НаправившаяОрг.DroppedDown = True
        End If
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