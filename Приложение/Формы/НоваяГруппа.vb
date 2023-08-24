Imports System.Threading
Public Class НоваяГруппа

    Dim gruppa As New Group
    Public zakr As Boolean = False
    Public вместоТаб As Integer = Keys.Down
    Public вместоТаб2 As Integer = Keys.Up
    Dim SC As SynchronizationContext
    Dim secondThread As Thread

    Public Sub setProgKod(kod As Integer)

        gruppa.struct_gruppa.kodProgramm = kod

        gruppa.struct_gruppa.flagAllListProgs = True

        activateModuls(Me, НоваяГруппаПрограмма.Text, gruppa.struct_gruppa.kodProgramm)

        gruppa.load_kol_chas()

        НоваяГруппаКоличествоЧасов.Text = gruppa.struct_gruppa.kolChasov

    End Sub

    Public Function getProgKod() As Int16

        Return gruppa.struct_gruppa.kodProgramm

    End Function

    Private Sub qualification_Click(sender As Object, e As EventArgs) Handles Квалификация.Click

        Сообщение.Visible = False

    End Sub

    Private Sub modul1_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul2_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul3_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub

    Private Sub modul4_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul5_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul6_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul7_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul8_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul9_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub modul10_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub

    Private Sub numbersHourse_Click(sender As Object, e As EventArgs) Handles НоваяГруппаКоличествоЧасов.Click

        Сообщение.Visible = False

    End Sub


    Private Sub kurator_Click(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.Click

        Сообщение.Visible = False

    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_Click(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.Click

        Сообщение.Visible = False

    End Sub

    Private Sub speciality_Click(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.Click

        Сообщение.Visible = False

    End Sub


    Private Sub program_Click(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.Click

        Сообщение.Visible = False

    End Sub


    Private Sub formEducation_click(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.Click

        Сообщение.Visible = False

    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        SC = SynchronizationContext.Current

        Сохранить.Enabled = False

        ActiveControl = BtnFocus
        Сообщение.Visible = False

        If Not gruppa.formGroupValidation(Me) Then
            Сохранить.Enabled = True
            Return
        End If

        gruppa.struct_gruppa.nameForma = "НоваяГруппа"

        gruppa.saveParameters(Me)

        secondThread = New Thread(AddressOf addGroup)
        secondThread.IsBackground = True
        secondThread.Start(gruppa.struct_gruppa)

    End Sub

    Sub addGroup(gruppa As Group.strGruppa)
        Dim queryString As String
        Dim result
        Dim queryResult As Int16 = 0

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.firstValue = gruppa.yearNZ
        InsertIntoDataBase.argument.secondName = "Номер"
        InsertIntoDataBase.argument.secondValue = gruppa.number

        queryResult = InsertIntoDataBase.checkUniq_No2()

        If queryResult = 2 Then

            ФормаДаНет.ShowDialog()

            If Not InsertIntoDataBase.removeDuplicates Then

                SC.Send(AddressOf enabledButton, gruppa.number)
                Return

            End If

            queryString = "SELECT Код FROM `group` WHERE Номер='" & gruppa.number & "' AND Year(ДатаНЗ) = " & gruppa.yearNZ
            result = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

            gruppa.Kod = result(0, 0)

            queryString = "DELETE FROM group_list WHERE Kod = " & gruppa.Kod

            MainForm.mySqlConnect.sendQuery(queryString, 1)

            queryString = WindowsApp2.updateGroup(gruppa)

            If queryString = "" Then

                SC.Send(AddressOf enabledButton, gruppa.number)
                Exit Sub

            End If

            InsertIntoDataBase.removeDuplicates = False

        ElseIf queryResult = 1 Then

            queryString = WindowsApp2.insertIntoGroup(gruppa)

            If queryString = "" Then

                SC.Send(AddressOf enabledButton, gruppa.number)
                Exit Sub

            End If

        Else

            SC.Send(AddressOf enabledButton, gruppa.number)
            SC.Send(AddressOf endTreadErr, gruppa.number)

        End If

        MainForm.mySqlConnect.sendQuery(queryString, 1)

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = "`group`"
        InsertIntoDataBase.argument.firstName = "Номер"
        InsertIntoDataBase.argument.firstValue = gruppa.number
        InsertIntoDataBase.argument.secondName = "датаСоздания"
        InsertIntoDataBase.argument.secondValue = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)
        InsertIntoDataBase.argument.thirdName = "Year(ДатаНЗ)"
        InsertIntoDataBase.argument.thirdValue = gruppa.yearNZ


        If InsertIntoDataBase.checkDuplicates() Then

            SC.Send(AddressOf endTread, gruppa.number)

        End If

        SC.Send(AddressOf enabledButton, gruppa.number)

    End Sub

    Sub endTread(gruppa_number As String)
        Me.Сообщение.Text = "Группа № " & gruppa_number & " успешно создана, дата записи: " & Date.Now.ToShortDateString
        Me.Сообщение.Visible = True
        СправочникГруппы.Label2.Text = "В базу внесена информация, неотображенная в таблице. Обновите данные"
        СправочникГруппы.Label2.Visible = True
    End Sub

    Sub endTreadErr(gruppa_number As String)
        Me.Сообщение.Text = "Ошибка. Повторите операцию"
        Me.Сообщение.Visible = True
    End Sub

    Sub enabledButton(gruppa_number As String)
        Me.Сохранить.Enabled = True
    End Sub

    Private Sub clean_Click(sender As Object, e As EventArgs) Handles Очистить.Click
        Dim nameControl As String
        ActiveControl = BtnFocus
        Сообщение.Visible = False
        For Each i In Me.Controls
            nameControl = i.Name
            nameControl = Strings.Left(nameControl, 5)
            If i.Name <> "Сохранить" And i.Name <> "Очистить" And Strings.Left(nameControl, 5) <> "Label" And i.Name <> "versProgs" Then

                If i.Name = "НоваяГруппаДатаНачалаЗанятий" Or i.Name = "НоваяГруппаКонецЗанятий" Or i.Name = "ДатаСпецэкзамен" Or Strings.Left(i.Name, 4) = "Дата" Then
                    i.Text = "01.01.1753"
                Else
                    i.Text = ""
                End If
            End If
        Next
        Сообщение.Visible = False
    End Sub

    Private Sub newGroup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Сообщение.Visible = False
        clean_Click(sender, e)
        ActiveControl = BtnFocus
    End Sub


    Private Sub formEducation_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаФормаОбучения.KeyDown
        If e.KeyCode = 13 Then
            formEducation_click(sender, e)
        End If
    End Sub

    Private Sub program_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаПрограмма.KeyDown
        If e.KeyCode = 13 Then
            program_Click(sender, e)
        End If
    End Sub

    Private Sub speciality_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаСпециальность.KeyDown
        If e.KeyCode = 13 Then
            speciality_Click(sender, e)
        End If
    End Sub

    Private Sub numbersHours_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаКоличествоЧасов.KeyDown
        If e.KeyCode = 13 Then
            numbersHourse_Click(sender, e)
        End If
    End Sub

    Private Sub kurator_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаОтветственныйКуратор.KeyDown
        If e.KeyCode = 13 Then
            kurator_Click(sender, e)
        End If
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваягруппаОтветственныйЗаПрактику.KeyDown
        If e.KeyCode = 13 Then
            НоваягруппаОтветственныйЗаПрактику_Click(sender, e)
        End If
    End Sub

    Private Sub modul1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul1_Click(sender, e)
        End If
    End Sub

    Private Sub modul2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul2_Click(sender, e)
        End If
    End Sub

    Private Sub modul3_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul3_Click(sender, e)
        End If
    End Sub

    Private Sub modul4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul4_Click(sender, e)
        End If
    End Sub

    Private Sub modul5_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul5_Click(sender, e)
        End If
    End Sub
    Private Sub modul6_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Call modul6_Click(sender, e)
        End If
    End Sub

    Private Sub modul7_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul7_Click(sender, e)
        End If
    End Sub

    Private Sub modul8_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Call modul8_Click(sender, e)
        End If
    End Sub
    Private Sub modul9_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul9_Click(sender, e)
        End If
    End Sub

    Private Sub modul10_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            modul10_Click(sender, e)
        End If
    End Sub

    Private Sub qualificationLevel_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаУровеньКвалификации.KeyDown
        If e.KeyCode = 13 Then
            qualificationLevel_Click(sender, e)
        End If
    End Sub

    Private Sub financing_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаФинансирование.KeyDown
        If e.KeyCode = 13 Then
            financing_Click(sender, e)
        End If
    End Sub

    Private Sub qualification_KeyDown(sender As Object, e As KeyEventArgs) Handles Квалификация.KeyDown
        If e.KeyCode = 13 Then
            Call qualification_Click(sender, e)
        End If
    End Sub

    Private Sub qualificationLevel_Click(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.Click
        Сообщение.Visible = False
    End Sub

    Private Sub financing_Click(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.Click
        Сообщение.Visible = False
    End Sub

    Private Sub newGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        closeEsc(Me, e.KeyCode)

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

            pressTab(e.KeyCode, Keys.Down)
            up(Me, e.KeyCode, Keys.Up)
            e.Handled = True

        End If

        If e.KeyCode = Keys.Delete Then
            For Each контрол In Me.Controls
                If ActiveControl.Name = контрол.name Then
                    If контрол.ReadOnly Then
                        Try
                            контрол.Text = ""
                        Catch ex As Exception

                        End Try
                        Exit For
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub numberUd_TextChanged(sender As Object, e As EventArgs) Handles НомерУд.TextChanged

        If НомерУд.Text = "" And РегНомерУд.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "повышение квалификации" Then
                НоваяГруппаУровеньКвалификации.Text = ""
                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

            End If

        Else

            НоваяГруппаУровеньКвалификации.Text = "повышение квалификации"

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

        End If

    End Sub

    Private Sub regNumberUd_TextChanged(sender As Object, e As EventArgs) Handles РегНомерУд.TextChanged
        If НомерУд.Text = "" And РегНомерУд.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "повышение квалификации" Then

                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "повышение квалификации"

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

        End If
    End Sub

    Private Sub numberD_TextChanged(sender As Object, e As EventArgs) Handles НомерДиплома.TextChanged

        If НомерДиплома.Text = "" And РегНомерДиплома.Text = "" Then
            If НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Then
                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка"

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

        End If
    End Sub

    Private Sub regNumberD_TextChanged(sender As Object, e As EventArgs) Handles РегНомерДиплома.TextChanged
        If НомерДиплома.Text = "" And РегНомерДиплома.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Then

                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка"

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

        End If
    End Sub

    Private Sub numberSv_TextChanged(sender As Object, e As EventArgs) Handles НомерСвид.TextChanged
        If НомерСвид.Text = "" And РегНомерСвид.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then
                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение"

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

        End If
    End Sub

    Private Sub regNumberSv_TextChanged(sender As Object, e As EventArgs) Handles РегНомерСвид.TextChanged
        If НомерСвид.Text = "" And РегНомерСвид.Text = "" Then
            If НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then

                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение"

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

        End If
    End Sub

    Private Sub qualificationLevel_TextChanged(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.TextChanged

        If НоваяГруппаУровеньКвалификации.Text = "специальный экзамен" Then

            gruppa.struct_gruppa.urKvalific = "специальный экзамен"

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False


            НоваяГруппаФормаОбучения.Enabled = False
            НоваяГруппаДатаНачалаЗанятий.Enabled = False
            НоваяГруппаКонецЗанятий.Enabled = False
            НоваяГруппаНомерПротоколаИА.Enabled = False
            НоваяГруппаПрограмма.Enabled = False
            НоваяГруппаСпециальность.Enabled = False
            НоваяГруппаКоличествоЧасов.Enabled = False
            НоваяГруппаОтветственныйКуратор.Enabled = False
            НоваягруппаОтветственныйЗаПрактику.Enabled = False
            Модуль1.Enabled = False
            Модуль2.Enabled = False
            Модуль3.Enabled = False
            Модуль4.Enabled = False
            Модуль5.Enabled = False
            Модуль6.Enabled = False
            Модуль7.Enabled = False
            Модуль8.Enabled = False
            Модуль9.Enabled = False
            Модуль10.Enabled = False
            Квалификация.Enabled = False

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НоваяГруппаПрограмма.Text = "Спецэкзамен"
            НоваяГруппаСпециальность.Text = "Без специальности"

        ElseIf НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then

            gruppa.struct_gruppa.urKvalific = "профессиональное обучение"

            НомерСвид.Enabled = True
            РегНомерСвид.Enabled = True
            ДатаВСвид.Enabled = True

            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НоваяГруппаФормаОбучения.Enabled = True
            НоваяГруппаДатаНачалаЗанятий.Enabled = True
            НоваяГруппаКонецЗанятий.Enabled = True
            НоваяГруппаНомерПротоколаИА.Enabled = True
            НоваяГруппаПрограмма.Enabled = True
            НоваяГруппаСпециальность.Enabled = True
            НоваяГруппаКоличествоЧасов.Enabled = True
            НоваяГруппаОтветственныйКуратор.Enabled = True
            НоваягруппаОтветственныйЗаПрактику.Enabled = True
            Модуль1.Enabled = True
            Модуль2.Enabled = True
            Модуль3.Enabled = True
            Модуль4.Enabled = True
            Модуль5.Enabled = True
            Модуль6.Enabled = True
            Модуль7.Enabled = True
            Модуль8.Enabled = True
            Модуль9.Enabled = True
            Модуль10.Enabled = True
            Квалификация.Enabled = True


            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

            НоваяГруппаПрограмма.Text = ""
            НоваяГруппаСпециальность.Text = ""

        ElseIf НоваяГруппаУровеньКвалификации.Text = "повышение квалификации" Then

            gruppa.struct_gruppa.urKvalific = "повышение квалификации"

            НомерУд.Enabled = True
            РегНомерУд.Enabled = True
            ДатаВыдачиУд.Enabled = True

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НоваяГруппаФормаОбучения.Enabled = True
            НоваяГруппаДатаНачалаЗанятий.Enabled = True
            НоваяГруппаКонецЗанятий.Enabled = True
            НоваяГруппаНомерПротоколаИА.Enabled = False
            НоваяГруппаПрограмма.Enabled = True
            НоваяГруппаСпециальность.Enabled = True
            НоваяГруппаКоличествоЧасов.Enabled = True
            НоваяГруппаОтветственныйКуратор.Enabled = True
            НоваягруппаОтветственныйЗаПрактику.Enabled = False
            Модуль1.Enabled = False
            Модуль2.Enabled = False
            Модуль3.Enabled = False
            Модуль4.Enabled = False
            Модуль5.Enabled = False
            Модуль6.Enabled = False
            Модуль7.Enabled = False
            Модуль8.Enabled = False
            Модуль9.Enabled = False
            Модуль10.Enabled = False
            Квалификация.Enabled = False

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НоваяГруппаПрограмма.Text = ""
            НоваяГруппаСпециальность.Text = ""

        ElseIf НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Then

            gruppa.struct_gruppa.urKvalific = "профессиональная переподготовка"

            НоваяГруппаФормаОбучения.Enabled = True
            НоваяГруппаДатаНачалаЗанятий.Enabled = True
            НоваяГруппаКонецЗанятий.Enabled = True
            НоваяГруппаНомерПротоколаИА.Enabled = True
            НоваяГруппаПрограмма.Enabled = True
            НоваяГруппаСпециальность.Enabled = True
            НоваяГруппаКоличествоЧасов.Enabled = True
            НоваяГруппаОтветственныйКуратор.Enabled = True
            НоваягруппаОтветственныйЗаПрактику.Enabled = True
            Модуль1.Enabled = True
            Модуль2.Enabled = True
            Модуль3.Enabled = True
            Модуль4.Enabled = True
            Модуль5.Enabled = True
            Модуль6.Enabled = True
            Модуль7.Enabled = True
            Модуль8.Enabled = True
            Модуль9.Enabled = True
            Модуль10.Enabled = True
            Квалификация.Enabled = True

            НомерДиплома.Enabled = True
            РегНомерДиплома.Enabled = True
            ДатаВДиплома.Enabled = True

            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НоваяГруппаПрограмма.Text = ""
            НоваяГруппаСпециальность.Text = ""
        Else

            gruppa.struct_gruppa.urKvalific = ""

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НомерДиплома.Enabled = True
            РегНомерДиплома.Enabled = True
            ДатаВДиплома.Enabled = True

            НомерУд.Enabled = True
            РегНомерУд.Enabled = True
            ДатаВыдачиУд.Enabled = True

            НомерСвид.Enabled = True
            РегНомерСвид.Enabled = True
            ДатаВСвид.Enabled = True

            НоваяГруппаФормаОбучения.Enabled = True
            НоваяГруппаДатаНачалаЗанятий.Enabled = True
            НоваяГруппаКонецЗанятий.Enabled = True
            НоваяГруппаНомерПротоколаИА.Enabled = True
            НоваяГруппаПрограмма.Enabled = True
            НоваяГруппаСпециальность.Enabled = True
            НоваяГруппаКоличествоЧасов.Enabled = True
            НоваяГруппаОтветственныйКуратор.Enabled = True
            НоваягруппаОтветственныйЗаПрактику.Enabled = True
            Модуль1.Enabled = False
            Модуль2.Enabled = False
            Модуль3.Enabled = False
            Модуль4.Enabled = False
            Модуль5.Enabled = False
            Модуль6.Enabled = False
            Модуль7.Enabled = False
            Модуль8.Enabled = False
            Модуль9.Enabled = False
            Модуль10.Enabled = False
            Квалификация.Enabled = True

            НоваяГруппаПрограмма.Text = ""
            НоваяГруппаСпециальность.Text = ""

        End If

        НоваяГруппаПрограмма.Items.Clear()
        НоваяГруппаПрограмма.Items.Add("")
        gruppa.updateProgramma()
        НоваяГруппаПрограмма.Items.AddRange(gruppa.formGrouppLists.programma)

    End Sub

    Private Sub program_TextChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.TextChanged

        activateModuls(Me, НоваяГруппаПрограмма.Text, gruppa.struct_gruppa.kodProgramm)

    End Sub

    Private Sub newGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ActiveControl = BtnFocus
        gruppa.struct_gruppa.nameForma = "НоваяГруппа"
        gruppa.struct_gruppa.kodProgramm = -1
        gruppa.loadFormGrouppLists()

        НоваяГруппаУровеньКвалификации.Items.Clear()
        НоваяГруппаУровеньКвалификации.Items.Add("")
        НоваяГруппаУровеньКвалификации.Items.AddRange(gruppa.formGrouppLists.ur_cvalifik)

        НоваяГруппаФормаОбучения.Items.Clear()
        НоваяГруппаФормаОбучения.Items.Add("")
        НоваяГруппаФормаОбучения.Items.AddRange(gruppa.formGrouppLists.forma_obuch)

        НоваяГруппаПрограмма.Items.Clear()
        НоваяГруппаПрограмма.Items.Add("")
        НоваяГруппаПрограмма.Items.AddRange(gruppa.formGrouppLists.programma)

        НоваяГруппаСпециальность.Items.Clear()
        НоваяГруппаСпециальность.Items.Add("")
        НоваяГруппаСпециальность.Items.AddRange(gruppa.formGrouppLists.specialnost)

        НоваяГруппаОтветственныйКуратор.Items.Clear()
        НоваяГруппаОтветственныйКуратор.Items.Add("")
        НоваяГруппаОтветственныйКуратор.Items.AddRange(gruppa.formGrouppLists.kurator)

        НоваягруппаОтветственныйЗаПрактику.Items.Clear()
        НоваягруппаОтветственныйЗаПрактику.Items.Add("")
        НоваягруппаОтветственныйЗаПрактику.Items.AddRange(gruppa.formGrouppLists.otvetstv_praktika)

        For Each element As Control In Me.Controls
            If Strings.Left(element.Name, 6) = "Модуль" Then
                Dim com As ComboBox = element
                com.Items.Clear()
                com.Items.Add("")
                com.Items.AddRange(gruppa.formGrouppLists.otvetstv_praktika)
            End If
        Next

        НоваяГруппаФинансирование.Items.Clear()
        НоваяГруппаФинансирование.Items.Add("")
        НоваяГруппаФинансирование.Items.AddRange(gruppa.formGrouppLists.finansirovanie)

        Квалификация.Items.Clear()
        Квалификация.Items.Add("")
        Квалификация.Items.AddRange(gruppa.formGrouppLists.kvalifikaciya)

    End Sub

    Private Sub qualificationLevel_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.MouseLeave
        gruppa.flagGrouppForm.ur_cvalifik = False
    End Sub

    Private Sub qualificationLevel_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаУровеньКвалификации.MouseMove
        gruppa.flagGrouppForm.ur_cvalifik = True
    End Sub

    Private Sub qualificationLevel_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.Enter

        comboBoxDrop(НоваяГруппаУровеньКвалификации, gruppa.flagGrouppForm.ur_cvalifik)

    End Sub

    Private Sub formEducation_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.MouseLeave
        gruppa.flagGrouppForm.forma_obuch = False
    End Sub

    Private Sub formEducation_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФормаОбучения.MouseMove
        gruppa.flagGrouppForm.forma_obuch = True
    End Sub

    Private Sub formEducation_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.Enter

        comboBoxDrop(НоваяГруппаФормаОбучения, gruppa.flagGrouppForm.forma_obuch)

    End Sub

    Private Sub formEducation_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.EnabledChanged
        If НоваяГруппаФормаОбучения.Enabled = False Then
            НоваяГруппаФормаОбучения.DroppedDown = False
        End If
    End Sub

    Private Sub program_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.MouseLeave
        gruppa.flagGrouppForm.programma = False
    End Sub

    Private Sub program_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаПрограмма.MouseMove
        gruppa.flagGrouppForm.programma = True
    End Sub

    Private Sub program_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.Enter

        comboBoxDrop(НоваяГруппаПрограмма, gruppa.flagGrouppForm.programma)

    End Sub

    Private Sub program_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.EnabledChanged
        If НоваяГруппаПрограмма.Enabled = False Then
            НоваяГруппаПрограмма.DroppedDown = False
        End If
    End Sub

    Private Sub speciality_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.MouseLeave
        gruppa.flagGrouppForm.specialnost = False
    End Sub

    Private Sub speciality_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаСпециальность.MouseMove
        gruppa.flagGrouppForm.specialnost = True
    End Sub

    Private Sub speciality_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.Enter

        comboBoxDrop(НоваяГруппаСпециальность, gruppa.flagGrouppForm.specialnost)

    End Sub

    Private Sub speciality_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.EnabledChanged
        If НоваяГруппаСпециальность.Enabled = False Then
            НоваяГруппаСпециальность.DroppedDown = False
        End If
    End Sub

    Private Sub kurator_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseLeave
        gruppa.flagGrouppForm.kurator = False
    End Sub

    Private Sub kurator_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseMove
        gruppa.flagGrouppForm.kurator = True
    End Sub

    Private Sub kurator_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.Enter

        comboBoxDrop(НоваяГруппаОтветственныйКуратор, gruppa.flagGrouppForm.kurator)

    End Sub

    Private Sub kurator_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.EnabledChanged
        If НоваяГруппаОтветственныйКуратор.Enabled = False Then
            НоваяГруппаОтветственныйКуратор.DroppedDown = False
        End If
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_MouseLeave(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.MouseLeave
        gruppa.flagGrouppForm.otvetstv_praktika = False
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваягруппаОтветственныйЗаПрактику.MouseMove
        gruppa.flagGrouppForm.otvetstv_praktika = True
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_Enter(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.Enter

        comboBoxDrop(НоваягруппаОтветственныйЗаПрактику, gruppa.flagGrouppForm.otvetstv_praktika)

    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_EnabledChanged(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.EnabledChanged
        If НоваягруппаОтветственныйЗаПрактику.Enabled = False Then
            НоваягруппаОтветственныйЗаПрактику.DroppedDown = False
        End If
    End Sub

    Private Sub modul1_MouseLeave(sender As Object, e As EventArgs) Handles Модуль1.MouseLeave
        gruppa.flagGrouppForm.modul_1 = False
    End Sub

    Private Sub modul1_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль1.MouseMove
        gruppa.flagGrouppForm.modul_1 = True
    End Sub

    Private Sub modul1_Enter(sender As Object, e As EventArgs) Handles Модуль1.Enter

        comboBoxDrop(Модуль1, gruppa.flagGrouppForm.modul_1)

    End Sub

    Private Sub modul1_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль1.EnabledChanged

        If Модуль1.Enabled = False Then
            Модуль1.DroppedDown = False
        End If

    End Sub

    Private Sub modul2_MouseLeave(sender As Object, e As EventArgs) Handles Модуль2.MouseLeave

        gruppa.flagGrouppForm.modul_2 = False

    End Sub

    Private Sub modul2_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль2.MouseMove

        gruppa.flagGrouppForm.modul_2 = True

    End Sub

    Private Sub modul2_Enter(sender As Object, e As EventArgs) Handles Модуль2.Enter

        comboBoxDrop(Модуль2, gruppa.flagGrouppForm.modul_2)

    End Sub

    Private Sub modul2_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль2.EnabledChanged

        If Модуль2.Enabled = False Then
            Модуль2.DroppedDown = False
        End If

    End Sub

    Private Sub modul3_MouseLeave(sender As Object, e As EventArgs) Handles Модуль3.MouseLeave
        gruppa.flagGrouppForm.modul_3 = False
    End Sub

    Private Sub modul3_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль3.MouseMove

        gruppa.flagGrouppForm.modul_3 = True

    End Sub

    Private Sub modul3_Enter(sender As Object, e As EventArgs) Handles Модуль3.Enter

        comboBoxDrop(Модуль3, gruppa.flagGrouppForm.modul_3)

    End Sub

    Private Sub modul3_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль3.EnabledChanged
        If Модуль3.Enabled = False Then
            Модуль3.DroppedDown = False
        End If
    End Sub

    Private Sub modul4_MouseLeave(sender As Object, e As EventArgs) Handles Модуль4.MouseLeave
        gruppa.flagGrouppForm.modul_4 = False
    End Sub

    Private Sub modul4_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль4.MouseMove
        gruppa.flagGrouppForm.modul_4 = True
    End Sub

    Private Sub modul4_Enter(sender As Object, e As EventArgs) Handles Модуль4.Enter

        comboBoxDrop(Модуль4, gruppa.flagGrouppForm.modul_4)

    End Sub

    Private Sub modul4_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль4.EnabledChanged
        If Модуль4.Enabled = False Then
            Модуль4.DroppedDown = False
        End If
    End Sub

    Private Sub modul5_MouseLeave(sender As Object, e As EventArgs) Handles Модуль5.MouseLeave
        gruppa.flagGrouppForm.modul_5 = False
    End Sub

    Private Sub modul5_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль5.MouseMove
        gruppa.flagGrouppForm.modul_5 = True
    End Sub

    Private Sub modul5_Enter(sender As Object, e As EventArgs) Handles Модуль5.Enter

        comboBoxDrop(Модуль5, gruppa.flagGrouppForm.modul_5)

    End Sub

    Private Sub modul5_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль5.EnabledChanged
        If Модуль5.Enabled = False Then
            Модуль5.DroppedDown = False
        End If
    End Sub

    Private Sub modul6_MouseLeave(sender As Object, e As EventArgs) Handles Модуль6.MouseLeave
        gruppa.flagGrouppForm.modul_6 = False
    End Sub

    Private Sub modul6_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль6.MouseMove
        gruppa.flagGrouppForm.modul_3 = True
    End Sub

    Private Sub modul6_Enter(sender As Object, e As EventArgs) Handles Модуль6.Enter

        comboBoxDrop(Модуль6, gruppa.flagGrouppForm.modul_6)

    End Sub

    Private Sub modul6_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль6.EnabledChanged
        If Модуль6.Enabled = False Then
            Модуль6.DroppedDown = False
        End If
    End Sub

    Private Sub modul7_MouseLeave(sender As Object, e As EventArgs) Handles Модуль7.MouseLeave
        gruppa.flagGrouppForm.modul_7 = False
    End Sub

    Private Sub modul7_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль7.MouseMove
        gruppa.flagGrouppForm.modul_7 = True
    End Sub

    Private Sub modul7_Enter(sender As Object, e As EventArgs) Handles Модуль7.Enter

        comboBoxDrop(Модуль7, gruppa.flagGrouppForm.modul_7)

    End Sub

    Private Sub modul7_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль7.EnabledChanged
        If Модуль7.Enabled = False Then
            Модуль7.DroppedDown = False
        End If
    End Sub

    Private Sub modul8_MouseLeave(sender As Object, e As EventArgs) Handles Модуль8.MouseLeave
        gruppa.flagGrouppForm.modul_8 = False
    End Sub

    Private Sub modul8_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль8.MouseMove
        gruppa.flagGrouppForm.modul_8 = True
    End Sub

    Private Sub modul8_Enter(sender As Object, e As EventArgs) Handles Модуль8.Enter

        comboBoxDrop(Модуль8, gruppa.flagGrouppForm.modul_8)

    End Sub

    Private Sub modul8_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль8.EnabledChanged
        If Модуль8.Enabled = False Then
            Модуль8.DroppedDown = False
        End If
    End Sub

    Private Sub modul9_MouseLeave(sender As Object, e As EventArgs) Handles Модуль9.MouseLeave
        gruppa.flagGrouppForm.modul_9 = False
    End Sub

    Private Sub modul9_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль9.MouseMove
        gruppa.flagGrouppForm.modul_9 = True
    End Sub

    Private Sub modul9_Enter(sender As Object, e As EventArgs) Handles Модуль9.Enter

        comboBoxDrop(Модуль9, gruppa.flagGrouppForm.modul_9)

    End Sub

    Private Sub modul9_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль9.EnabledChanged
        If Модуль9.Enabled = False Then
            Модуль9.DroppedDown = False
        End If
    End Sub

    Private Sub modul10_MouseLeave(sender As Object, e As EventArgs) Handles Модуль10.MouseLeave
        gruppa.flagGrouppForm.modul_10 = False
    End Sub

    Private Sub modul10_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль10.MouseMove
        gruppa.flagGrouppForm.modul_10 = True
    End Sub

    Private Sub modul10_Enter(sender As Object, e As EventArgs) Handles Модуль10.Enter

        comboBoxDrop(Модуль10, gruppa.flagGrouppForm.modul_10)

    End Sub

    Private Sub modul10_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль10.EnabledChanged
        If Модуль10.Enabled = False Then
            Модуль10.DroppedDown = False
        End If
    End Sub

    Private Sub financing_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.MouseLeave
        gruppa.flagGrouppForm.finansirovanie = False
    End Sub

    Private Sub financing_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФинансирование.MouseMove
        gruppa.flagGrouppForm.finansirovanie = True
    End Sub

    Private Sub financing_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.Enter

        comboBoxDrop(НоваяГруппаФинансирование, gruppa.flagGrouppForm.finansirovanie)

    End Sub

    Private Sub financing_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.EnabledChanged
        If НоваяГруппаФинансирование.Enabled = False Then
            НоваяГруппаФинансирование.DroppedDown = False
        End If
    End Sub

    Private Sub qualification_MouseLeave(sender As Object, e As EventArgs) Handles Квалификация.MouseLeave
        gruppa.flagGrouppForm.kvalifikaciya = False
    End Sub

    Private Sub qualification_MouseMove(sender As Object, e As MouseEventArgs) Handles Квалификация.MouseMove
        gruppa.flagGrouppForm.kvalifikaciya = True
    End Sub

    Private Sub qualification_Enter(sender As Object, e As EventArgs) Handles Квалификация.Enter

        comboBoxDrop(Квалификация, gruppa.flagGrouppForm.kvalifikaciya)

    End Sub

    Private Sub qualification_EnabledChanged(sender As Object, e As EventArgs) Handles Квалификация.EnabledChanged

        If Квалификация.Enabled = False Then

            Квалификация.DroppedDown = False

        End If

    End Sub

    Private Sub versProgs_Click(sender As Object, e As EventArgs) Handles versProgs.Click
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ФормаСписок.ShowDialog()
    End Sub

    Private Sub program_SelectedIndexChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.SelectedIndexChanged

        gruppa.struct_gruppa.programma = НоваяГруппаПрограмма.Text

        If НоваяГруппаПрограмма.Text = "" Then

            gruppa.struct_gruppa.kodProgramm = -1

        Else

            If gruppa.struct_gruppa.flagAllListProgs Then

                gruppa.struct_gruppa.flagAllListProgs = False
                Return

            End If

            gruppa.updateKodProg()
            НоваяГруппаКоличествоЧасов.Text = gruppa.struct_gruppa.kolChasov

        End If

        activateModuls(Me, НоваяГруппаПрограмма.Text, gruppa.struct_gruppa.kodProgramm)

    End Sub

    Private Sub comboBoxDrop(currentComboBox As ComboBox, flag As Boolean)

        If Not currentComboBox.Enabled Then

            Return

        End If

        If flag Then

            currentComboBox.DroppedDown = False

        Else

            currentComboBox.DroppedDown = True

        End If

    End Sub

    Private Sub controlActivate(currentControl As Control)

        If Not currentControl.Enabled Then

            For Each prevControl As Control In Me.Controls

                If prevControl.TabIndex = currentControl.TabIndex - 1 Then

                    prevControl.Focus()
                    Return
                End If

            Next

        End If

    End Sub

End Class