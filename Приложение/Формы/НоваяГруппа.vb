Imports System.Threading
Public Class НоваяГруппа

    Dim gruppa As New Gruppa
    Public zakr As Boolean = False
    Public вместоТаб As Integer = 40
    Public вместоТаб2 As Integer = 39
    Dim SC As SynchronizationContext
    Dim secondThread As Thread
    Public Sub setProgKod(kod As Integer)
        gruppa.struct_gruppa.kodProgramm = kod
        gruppa.struct_gruppa.flagAllListProgs = True
        активироватьМодули(Me, НоваяГруппаПрограмма.Text, gruppa.struct_gruppa.kodProgramm)
    End Sub
    Public Function getProgKod() As Int16
        Return gruppa.struct_gruppa.kodProgramm
    End Function

    Private Sub Квалификация_Click(sender As Object, e As EventArgs) Handles Квалификация.Click

        Сообщение.Visible = False

    End Sub

    Private Sub Модуль1_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль2_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль3_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub

    Private Sub Модуль4_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль5_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль6_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль7_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль8_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль9_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub
    Private Sub Модуль10_Click(sender As Object, e As EventArgs)

        Сообщение.Visible = False

    End Sub

    Private Sub НоваяГруппаКоличествоЧасов_Click(sender As Object, e As EventArgs) Handles НоваяГруппаКоличествоЧасов.Click

        Сообщение.Visible = False

    End Sub


    Private Sub НоваяГруппаОтветственныйКуратор_Click(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.Click

        Сообщение.Visible = False

    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_Click(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.Click

        Сообщение.Visible = False

    End Sub

    Private Sub НоваяГруппаСпециальность_Click(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.Click

        Сообщение.Visible = False

    End Sub


    Private Sub НоваяГруппаПрограмма_Click(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.Click

        Сообщение.Visible = False

    End Sub


    Private Sub НоваяГруппаФормаОбучения_Click(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.Click

        Сообщение.Visible = False

    End Sub

    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click
        Dim СтрокаЗапроса As String
        Dim DataString As String

        SC = SynchronizationContext.Current

        Сохранить.Enabled = False

        ActiveControl = BtnFocus
        Сообщение.Visible = False

        If Not Вспомогательный.новаяГруппаЗаполненность() Then
            Сохранить.Enabled = True
            Exit Sub
        End If

        gruppa.struct_gruppa.yearNZ = Me.НоваяГруппаДатаНачалаЗанятий.Value.Year
        gruppa.struct_gruppa.dataNZ = ААОсновная.mySqlConnect.dateToFormatMySQL(Me.НоваяГруппаДатаНачалаЗанятий.Value.ToShortDateString)
        gruppa.struct_gruppa.dataKZ = ААОсновная.mySqlConnect.dateToFormatMySQL(Me.НоваяГруппаКонецЗанятий.Value.ToShortDateString)
        gruppa.struct_gruppa.dataVUd = ААОсновная.mySqlConnect.dateToFormatMySQL(Me.ДатаВыдачиУд.Value.ToShortDateString)
        gruppa.struct_gruppa.dataVD = ААОсновная.mySqlConnect.dateToFormatMySQL(Me.ДатаВДиплома.Value.ToShortDateString)
        gruppa.struct_gruppa.dataVSv = ААОсновная.mySqlConnect.dateToFormatMySQL(Me.ДатаВСвид.Value.ToShortDateString)
        gruppa.struct_gruppa.dataSpec = ААОсновная.mySqlConnect.dateToFormatMySQL(Me.ДатаСпецэкзамен.Value.ToShortDateString)
        gruppa.struct_gruppa.number = Me.НоваяГруппаНомер.Text
        gruppa.struct_gruppa.formaObuch = Me.НоваяГруппаФормаОбучения.Text
        gruppa.struct_gruppa.specialnost = Me.НоваяГруппаСпециальность.Text
        gruppa.struct_gruppa.programma = Me.НоваяГруппаПрограмма.Text
        gruppa.struct_gruppa.kolChasov = Me.НоваяГруппаКоличествоЧасов.Text
        gruppa.struct_gruppa.kurator = Me.НоваяГруппаОтветственныйКуратор.Text
        gruppa.struct_gruppa.otvZaPraktiku = Me.НоваягруппаОтветственныйЗаПрактику.Text

        gruppa.struct_gruppa.nomerSvid = Me.НомерСвид.Text
        gruppa.struct_gruppa.regNomerSvid = Me.РегНомерСвид.Text

        gruppa.struct_gruppa.nomerDiploma = Me.НомерДиплома.Text
        gruppa.struct_gruppa.regNomerDiploma = Me.РегНомерДиплома.Text

        gruppa.struct_gruppa.nomerUd = Me.НомерУд.Text
        gruppa.struct_gruppa.regNomerUd = Me.РегНомерУд.Text

        gruppa.struct_gruppa.OsnDocument = Вспомогательный.ОсновнойДокумент(Me)
        gruppa.struct_gruppa.NumbersUDS = Вспомогательный.ОбнулениеНеактивныхНомеров(gruppa.struct_gruppa.OsnDocument, Me)

        gruppa.struct_gruppa.modul1 = Me.Модуль1.Text
        gruppa.struct_gruppa.modul2 = Me.Модуль2.Text
        gruppa.struct_gruppa.modul3 = Me.Модуль3.Text
        gruppa.struct_gruppa.modul4 = Me.Модуль4.Text
        gruppa.struct_gruppa.modul5 = Me.Модуль5.Text
        gruppa.struct_gruppa.modul6 = Me.Модуль6.Text
        gruppa.struct_gruppa.modul7 = Me.Модуль7.Text
        gruppa.struct_gruppa.modul8 = Me.Модуль8.Text
        gruppa.struct_gruppa.modul9 = Me.Модуль9.Text
        gruppa.struct_gruppa.modul10 = Me.Модуль10.Text
        gruppa.struct_gruppa.urKvalific = Me.НоваяГруппаУровеньКвалификации.Text
        gruppa.struct_gruppa.osnovnoyDok = Вспомогательный.ОсновнойДокумент(Me)
        gruppa.struct_gruppa.financir = Me.НоваяГруппаФинансирование.Text
        gruppa.struct_gruppa.nomerProtIA = Me.НоваяГруппаНомерПротоколаИА.Text
        gruppa.struct_gruppa.kvalifikaciya = Me.Квалификация.Text
        gruppa.struct_gruppa.nomerProtokolaSpec = НомерПротоколаСпецэкзамен.Text
        gruppa.struct_gruppa.nameForma = "НоваяГруппа"

        secondThread = New Thread(AddressOf addGroup)
        secondThread.IsBackground = True
        secondThread.Start(gruppa.struct_gruppa)

    End Sub
    Sub addGroup(gruppa As Gruppa.strGruppa)
        Dim SQLString As String
        Dim Data As String
        Dim result
        Dim queryResult As Int16 = 0

        queryResult = ЗаписьВБазу.ПроверкаСовпаденийЧислоДА_2("Группа", "Year(ДатаНЗ)", gruppa.yearNZ, "Номер", gruppa.number)

        If queryResult = 2 Then
            ФормаДаНет.ShowDialog()
            If Not ЗаписьВБазу.УдалитьСовпадения Then
                SC.Send(AddressOf enabledButton, gruppa.number)
                Exit Sub
            End If
            SQLString = "SELECT Код FROM Группа WHERE Номер='" & gruppa.number & "' AND Year(ДатаНЗ) = " & gruppa.yearNZ
            result = ЗагрузитьИзБазы.ЗагрузитьИзБазы(SQLString)
            gruppa.Kod = result(0, 0)

            SQLString = "DELETE FROM СоставГрупп WHERE Kod = " & gruppa.Kod
            ЗаписьВБазу.УдалитьСовпадения = False
            ЗаписьВБазу.ЗаписьВБазу(SQLString)

            SQLString = QueryString.updateGroup(gruppa)

            If SQLString = "" Then
                SC.Send(AddressOf enabledButton, gruppa.number)
                Exit Sub
            End If
            ЗаписьВБазу.УдалитьСовпадения = False

        ElseIf queryResult = 1 Then

            SQLString = QueryString.insertIntoGroup(gruppa)
            If SQLString = "" Then
                SC.Send(AddressOf enabledButton, gruppa.number)
                Exit Sub
            End If
        Else
            SC.Send(AddressOf enabledButton, gruppa.number)
            SC.Send(AddressOf endTreadErr, gruppa.number)
        End If

        ЗаписьВБазу.ЗаписьВБазу(SQLString)

        Data = ААОсновная.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)

        If ЗаписьВБазу.ПроверкаСовпадений("Группа", "Номер", gruppa.number, "датаСоздания", Data, "Year(ДатаНЗ)", gruppa.yearNZ) Then
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

    Private Sub Очистить_Click(sender As Object, e As EventArgs) Handles Очистить.Click
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

    Private Sub НоваяГруппа_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Сообщение.Visible = False
        Очистить_Click(sender, e)
        ActiveControl = BtnFocus
    End Sub


    Private Sub НоваяГруппаФормаОбучения_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаФормаОбучения.KeyDown
        If e.KeyCode = 13 Then
            НоваяГруппаФормаОбучения_Click(sender, e)
        End If
    End Sub

    Private Sub НоваяГруппаПрограмма_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаПрограмма.KeyDown
        If e.KeyCode = 13 Then
            НоваяГруппаПрограмма_Click(sender, e)
        End If
    End Sub

    Private Sub НоваяГруппаСпециальность_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаСпециальность.KeyDown
        If e.KeyCode = 13 Then
            НоваяГруппаСпециальность_Click(sender, e)
        End If
    End Sub

    Private Sub НоваяГруппаКоличествоЧасов_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаКоличествоЧасов.KeyDown
        If e.KeyCode = 13 Then
            НоваяГруппаКоличествоЧасов_Click(sender, e)
        End If
    End Sub

    Private Sub НоваяГруппаОтветственныйКуратор_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаОтветственныйКуратор.KeyDown
        If e.KeyCode = 13 Then
            НоваяГруппаОтветственныйКуратор_Click(sender, e)
        End If
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваягруппаОтветственныйЗаПрактику.KeyDown
        If e.KeyCode = 13 Then
            НоваягруппаОтветственныйЗаПрактику_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль1_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль2_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль3_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль3_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль4_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль5_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль5_Click(sender, e)
        End If
    End Sub
    Private Sub Модуль6_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Call Модуль6_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль7_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль7_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль8_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Call Модуль8_Click(sender, e)
        End If
    End Sub
    Private Sub Модуль9_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль9_Click(sender, e)
        End If
    End Sub

    Private Sub Модуль10_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            Модуль10_Click(sender, e)
        End If
    End Sub

    Private Sub НоваяГруппаУровеньКвалификации_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаУровеньКвалификации.KeyDown
        If e.KeyCode = 13 Then
            НоваяГруппаУровеньКвалификации_Click(sender, e)
        End If
    End Sub

    Private Sub НоваяГруппаФинансирование_KeyDown(sender As Object, e As KeyEventArgs) Handles НоваяГруппаФинансирование.KeyDown
        If e.KeyCode = 13 Then
            НоваяГруппаФинансирование_Click(sender, e)
        End If
    End Sub

    Private Sub Квалификация_KeyDown(sender As Object, e As KeyEventArgs) Handles Квалификация.KeyDown
        If e.KeyCode = 13 Then
            Call Квалификация_Click(sender, e)
        End If
    End Sub

    Private Sub НоваяГруппаУровеньКвалификации_Click(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.Click
        Сообщение.Visible = False
    End Sub

    Private Sub НоваяГруппаФинансирование_Click(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.Click
        Сообщение.Visible = False
    End Sub

    Private Sub НоваяГруппа_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        ЗакрытьEsc(Me, e.KeyCode)

        If e.KeyCode = 38 Or e.KeyCode = 40 Then
            функционалТаб(e.KeyCode, 40)
            перемещениеВверх(Me, e.KeyCode, 38)
            e.Handled = True
        End If

        If e.KeyCode = 46 Then
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

    Private Sub НомерУд_TextChanged(sender As Object, e As EventArgs) Handles НомерУд.TextChanged

        If НомерУд.Text = "" And РегНомерУд.Text = "" Then
            If НоваяГруппаУровеньКвалификации.Text = "повышение квалификации" Then
                НоваяГруппаУровеньКвалификации.Text = ""
                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

                НомерПротоколаСпецэкзамен.Enabled = True
                ДатаСпецэкзамен.Enabled = True


            End If


        Else
            НоваяГруппаУровеньКвалификации.Text = "повышение квалификации"

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НомерПротоколаСпецэкзамен.Clear()
        End If



    End Sub

    Private Sub РегНомерУд_TextChanged(sender As Object, e As EventArgs) Handles РегНомерУд.TextChanged
        If НомерУд.Text = "" And РегНомерУд.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "повышение квалификации" Then

                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

                НомерПротоколаСпецэкзамен.Enabled = True
                ДатаСпецэкзамен.Enabled = True

                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False
            НоваяГруппаУровеньКвалификации.Text = "повышение квалификации"

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НомерПротоколаСпецэкзамен.Clear()
        End If
    End Sub

    Private Sub НомерДиплома_TextChanged(sender As Object, e As EventArgs) Handles НомерДиплома.TextChanged
        If НомерДиплома.Text = "" And РегНомерДиплома.Text = "" Then
            If НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Then
                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

                НомерПротоколаСпецэкзамен.Enabled = True
                ДатаСпецэкзамен.Enabled = True


                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка"

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НомерПротоколаСпецэкзамен.Clear()
        End If
    End Sub

    Private Sub РегНомерДиплома_TextChanged(sender As Object, e As EventArgs) Handles РегНомерДиплома.TextChanged
        If НомерДиплома.Text = "" And РегНомерДиплома.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Then

                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерСвид.Enabled = True
                РегНомерСвид.Enabled = True
                ДатаВСвид.Enabled = True

                НомерПротоколаСпецэкзамен.Enabled = True
                ДатаСпецэкзамен.Enabled = True

                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерСвид.Enabled = False
            РегНомерСвид.Enabled = False
            ДатаВСвид.Enabled = False

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка"

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НомерПротоколаСпецэкзамен.Clear()
        End If
    End Sub

    Private Sub НомерСвид_TextChanged(sender As Object, e As EventArgs) Handles НомерСвид.TextChanged
        If НомерСвид.Text = "" And РегНомерСвид.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then
                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НомерПротоколаСпецэкзамен.Enabled = True
                ДатаСпецэкзамен.Enabled = True


                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение"

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерПротоколаСпецэкзамен.Clear()
        End If
    End Sub

    Private Sub РегНомерСвид_TextChanged(sender As Object, e As EventArgs) Handles РегНомерСвид.TextChanged
        If НомерСвид.Text = "" And РегНомерСвид.Text = "" Then
            If НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then

                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

                НомерДиплома.Enabled = True
                РегНомерДиплома.Enabled = True
                ДатаВДиплома.Enabled = True

                НомерПротоколаСпецэкзамен.Enabled = True
                ДатаСпецэкзамен.Enabled = True


                НоваяГруппаУровеньКвалификации.Text = ""
            End If
        Else
            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НомерДиплома.Enabled = False
            РегНомерДиплома.Enabled = False
            ДатаВДиплома.Enabled = False

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение"

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерПротоколаСпецэкзамен.Clear()
        End If
    End Sub

    Private Sub НомерПротоколаСпецэкзамен_TextChanged(sender As Object, e As EventArgs) Handles НомерПротоколаСпецэкзамен.TextChanged
        If НомерПротоколаСпецэкзамен.Text = "" Then

            If НоваяГруппаУровеньКвалификации.Text = "специальный экзамен" Then

                НомерУд.Enabled = True
                РегНомерУд.Enabled = True
                ДатаВыдачиУд.Enabled = True

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

            НомерУд.Enabled = False
            РегНомерУд.Enabled = False
            ДатаВыдачиУд.Enabled = False

            НоваяГруппаУровеньКвалификации.Text = "специальный экзамен"

            НомерДиплома.Clear()
            РегНомерДиплома.Clear()

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()
        End If
    End Sub

    Private Sub НоваяГруппаУровеньКвалификации_TextChanged(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.TextChanged
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

            НомерПротоколаСпецэкзамен.Enabled = True
            ДатаСпецэкзамен.Enabled = True

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

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

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

            НомерПротоколаСпецэкзамен.Clear()

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

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

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

            НомерПротоколаСпецэкзамен.Clear()

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

            НомерПротоколаСпецэкзамен.Enabled = False
            ДатаСпецэкзамен.Enabled = False

            НомерУд.Clear()
            РегНомерУд.Clear()

            НомерСвид.Clear()
            РегНомерСвид.Clear()

            НомерПротоколаСпецэкзамен.Clear()

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

            НомерПротоколаСпецэкзамен.Clear()

            НомерДиплома.Enabled = True
            РегНомерДиплома.Enabled = True
            ДатаВДиплома.Enabled = True

            НомерУд.Enabled = True
            РегНомерУд.Enabled = True
            ДатаВыдачиУд.Enabled = True

            НомерСвид.Enabled = True
            РегНомерСвид.Enabled = True
            ДатаВСвид.Enabled = True

            НомерПротоколаСпецэкзамен.Enabled = True
            ДатаСпецэкзамен.Enabled = True

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

    Private Sub НоваяГруппаПрограмма_TextChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.TextChanged
        активироватьМодули(Me, НоваяГруппаПрограмма.Text, gruppa.struct_gruppa.kodProgramm)
    End Sub

    Private Sub НоваяГруппа_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        НоваяГруппаКоличествоЧасов.Items.Clear()
        НоваяГруппаКоличествоЧасов.Items.Add("")
        НоваяГруппаКоличествоЧасов.Items.AddRange(gruppa.formGrouppLists.kol_chasov)

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

    Private Sub НоваяГруппаУровеньКвалификации_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.MouseLeave
        gruppa.flagGrouppForm.ur_cvalifik = False
    End Sub

    Private Sub НоваяГруппаУровеньКвалификации_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаУровеньКвалификации.MouseMove
        gruppa.flagGrouppForm.ur_cvalifik = True
    End Sub

    Private Sub НоваяГруппаУровеньКвалификации_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаУровеньКвалификации.Enter
        If gruppa.flagGrouppForm.ur_cvalifik Then
            НоваяГруппаУровеньКвалификации.DroppedDown = False
        Else
            НоваяГруппаУровеньКвалификации.DroppedDown = True
        End If
    End Sub

    Private Sub НоваяГруппаФормаОбучения_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.MouseLeave
        gruppa.flagGrouppForm.forma_obuch = False
    End Sub

    Private Sub НоваяГруппаФормаОбучения_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФормаОбучения.MouseMove
        gruppa.flagGrouppForm.forma_obuch = True
    End Sub

    Private Sub НоваяГруппаФормаОбучения_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.Enter
        If gruppa.flagGrouppForm.forma_obuch Then
            НоваяГруппаФормаОбучения.DroppedDown = False
        Else
            НоваяГруппаФормаОбучения.DroppedDown = True
        End If
    End Sub

    Private Sub НоваяГруппаФормаОбучения_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФормаОбучения.EnabledChanged
        If НоваяГруппаФормаОбучения.Enabled = False Then
            НоваяГруппаФормаОбучения.DroppedDown = False
        End If
    End Sub

    Private Sub НоваяГруппаПрограмма_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.MouseLeave
        gruppa.flagGrouppForm.programma = False
    End Sub

    Private Sub НоваяГруппаПрограмма_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаПрограмма.MouseMove
        gruppa.flagGrouppForm.programma = True
    End Sub

    Private Sub НоваяГруппаПрограмма_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.Enter
        If gruppa.flagGrouppForm.programma Then
            НоваяГруппаПрограмма.DroppedDown = False
        Else
            НоваяГруппаПрограмма.DroppedDown = True
        End If
    End Sub

    Private Sub НоваяГруппаПрограмма_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.EnabledChanged
        If НоваяГруппаПрограмма.Enabled = False Then
            НоваяГруппаПрограмма.DroppedDown = False
        End If
    End Sub

    Private Sub НоваяГруппаСпециальность_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.MouseLeave
        gruppa.flagGrouppForm.specialnost = False
    End Sub

    Private Sub НоваяГруппаСпециальность_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаСпециальность.MouseMove
        gruppa.flagGrouppForm.specialnost = True
    End Sub

    Private Sub НоваяГруппаСпециальность_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.Enter
        If gruppa.flagGrouppForm.specialnost Then
            НоваяГруппаСпециальность.DroppedDown = False
        Else
            НоваяГруппаСпециальность.DroppedDown = True
        End If
    End Sub

    Private Sub НоваяГруппаСпециальность_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаСпециальность.EnabledChanged
        If НоваяГруппаСпециальность.Enabled = False Then
            НоваяГруппаСпециальность.DroppedDown = False
        End If
    End Sub

    Private Sub НоваяГруппаКоличествоЧасов_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаКоличествоЧасов.MouseLeave
        gruppa.flagGrouppForm.kol_chasov = False
    End Sub

    Private Sub НоваяГруппаКоличествоЧасов_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаКоличествоЧасов.MouseMove
        gruppa.flagGrouppForm.kol_chasov = True
    End Sub

    Private Sub НоваяГруппаКоличествоЧасов_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаКоличествоЧасов.Enter
        If gruppa.flagGrouppForm.kol_chasov Then
            НоваяГруппаКоличествоЧасов.DroppedDown = False
        Else
            НоваяГруппаКоличествоЧасов.DroppedDown = True
        End If
    End Sub

    Private Sub НоваяГруппаКоличествоЧасов_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаКоличествоЧасов.EnabledChanged
        If НоваяГруппаКоличествоЧасов.Enabled = False Then
            НоваяГруппаКоличествоЧасов.DroppedDown = False
        End If
    End Sub

    Private Sub НоваяГруппаОтветственныйКуратор_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseLeave
        gruppa.flagGrouppForm.kurator = False
    End Sub

    Private Sub НоваяГруппаОтветственныйКуратор_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаОтветственныйКуратор.MouseMove
        gruppa.flagGrouppForm.kurator = True
    End Sub

    Private Sub НоваяГруппаОтветственныйКуратор_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.Enter
        If gruppa.flagGrouppForm.kurator Then
            НоваяГруппаОтветственныйКуратор.DroppedDown = False
        Else
            НоваяГруппаОтветственныйКуратор.DroppedDown = True
        End If
    End Sub

    Private Sub НоваяГруппаОтветственныйКуратор_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаОтветственныйКуратор.EnabledChanged
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
        If gruppa.flagGrouppForm.otvetstv_praktika Then
            НоваягруппаОтветственныйЗаПрактику.DroppedDown = False
        Else
            НоваягруппаОтветственныйЗаПрактику.DroppedDown = True
        End If
    End Sub

    Private Sub НоваягруппаОтветственныйЗаПрактику_EnabledChanged(sender As Object, e As EventArgs) Handles НоваягруппаОтветственныйЗаПрактику.EnabledChanged
        If НоваягруппаОтветственныйЗаПрактику.Enabled = False Then
            НоваягруппаОтветственныйЗаПрактику.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль1_MouseLeave(sender As Object, e As EventArgs) Handles Модуль1.MouseLeave
        gruppa.flagGrouppForm.modul_1 = False
    End Sub

    Private Sub Модуль1_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль1.MouseMove
        gruppa.flagGrouppForm.modul_1 = True
    End Sub

    Private Sub Модуль1_Enter(sender As Object, e As EventArgs) Handles Модуль1.Enter
        If gruppa.flagGrouppForm.modul_1 Then
            Модуль1.DroppedDown = False
        Else
            Модуль1.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль1_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль1.EnabledChanged
        If Модуль1.Enabled = False Then
            Модуль1.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль2_MouseLeave(sender As Object, e As EventArgs) Handles Модуль2.MouseLeave
        gruppa.flagGrouppForm.modul_2 = False
    End Sub

    Private Sub Модуль2_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль2.MouseMove
        gruppa.flagGrouppForm.modul_2 = True
    End Sub

    Private Sub Модуль2_Enter(sender As Object, e As EventArgs) Handles Модуль2.Enter
        If gruppa.flagGrouppForm.modul_2 Then
            Модуль2.DroppedDown = False
        Else
            Модуль2.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль2_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль2.EnabledChanged
        If Модуль2.Enabled = False Then
            Модуль2.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль3_MouseLeave(sender As Object, e As EventArgs) Handles Модуль3.MouseLeave
        gruppa.flagGrouppForm.modul_3 = False
    End Sub

    Private Sub Модуль3_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль3.MouseMove
        gruppa.flagGrouppForm.modul_3 = True
    End Sub

    Private Sub Модуль3_Enter(sender As Object, e As EventArgs) Handles Модуль3.Enter
        If gruppa.flagGrouppForm.modul_3 Then
            Модуль3.DroppedDown = False
        Else
            Модуль3.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль3_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль3.EnabledChanged
        If Модуль3.Enabled = False Then
            Модуль3.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль4_MouseLeave(sender As Object, e As EventArgs) Handles Модуль4.MouseLeave
        gruppa.flagGrouppForm.modul_4 = False
    End Sub

    Private Sub Модуль4_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль4.MouseMove
        gruppa.flagGrouppForm.modul_4 = True
    End Sub

    Private Sub Модуль4_Enter(sender As Object, e As EventArgs) Handles Модуль4.Enter
        If gruppa.flagGrouppForm.modul_4 Then
            Модуль4.DroppedDown = False
        Else
            Модуль4.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль4_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль4.EnabledChanged
        If Модуль4.Enabled = False Then
            Модуль4.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль5_MouseLeave(sender As Object, e As EventArgs) Handles Модуль5.MouseLeave
        gruppa.flagGrouppForm.modul_5 = False
    End Sub

    Private Sub Модуль5_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль5.MouseMove
        gruppa.flagGrouppForm.modul_5 = True
    End Sub

    Private Sub Модуль5_Enter(sender As Object, e As EventArgs) Handles Модуль5.Enter
        If gruppa.flagGrouppForm.modul_5 Then
            Модуль5.DroppedDown = False
        Else
            Модуль5.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль5_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль5.EnabledChanged
        If Модуль5.Enabled = False Then
            Модуль5.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль6_MouseLeave(sender As Object, e As EventArgs) Handles Модуль6.MouseLeave
        gruppa.flagGrouppForm.modul_6 = False
    End Sub

    Private Sub Модуль6_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль6.MouseMove
        gruppa.flagGrouppForm.modul_3 = True
    End Sub

    Private Sub Модуль6_Enter(sender As Object, e As EventArgs) Handles Модуль6.Enter
        If gruppa.flagGrouppForm.modul_6 Then
            Модуль6.DroppedDown = False
        Else
            Модуль6.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль6_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль6.EnabledChanged
        If Модуль6.Enabled = False Then
            Модуль6.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль7_MouseLeave(sender As Object, e As EventArgs) Handles Модуль7.MouseLeave
        gruppa.flagGrouppForm.modul_7 = False
    End Sub

    Private Sub Модуль7_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль7.MouseMove
        gruppa.flagGrouppForm.modul_7 = True
    End Sub

    Private Sub Модуль7_Enter(sender As Object, e As EventArgs) Handles Модуль7.Enter
        If gruppa.flagGrouppForm.modul_7 Then
            Модуль7.DroppedDown = False
        Else
            Модуль7.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль7_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль7.EnabledChanged
        If Модуль7.Enabled = False Then
            Модуль7.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль8_MouseLeave(sender As Object, e As EventArgs) Handles Модуль8.MouseLeave
        gruppa.flagGrouppForm.modul_8 = False
    End Sub

    Private Sub Модуль8_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль8.MouseMove
        gruppa.flagGrouppForm.modul_8 = True
    End Sub

    Private Sub Модуль8_Enter(sender As Object, e As EventArgs) Handles Модуль8.Enter
        If gruppa.flagGrouppForm.modul_8 Then
            Модуль8.DroppedDown = False
        Else
            Модуль8.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль8_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль8.EnabledChanged
        If Модуль8.Enabled = False Then
            Модуль8.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль9_MouseLeave(sender As Object, e As EventArgs) Handles Модуль9.MouseLeave
        gruppa.flagGrouppForm.modul_9 = False
    End Sub

    Private Sub Модуль9_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль9.MouseMove
        gruppa.flagGrouppForm.modul_9 = True
    End Sub

    Private Sub Модуль9_Enter(sender As Object, e As EventArgs) Handles Модуль9.Enter
        If gruppa.flagGrouppForm.modul_9 Then
            Модуль9.DroppedDown = False
        Else
            Модуль9.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль9_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль9.EnabledChanged
        If Модуль9.Enabled = False Then
            Модуль9.DroppedDown = False
        End If
    End Sub

    Private Sub Модуль10_MouseLeave(sender As Object, e As EventArgs) Handles Модуль10.MouseLeave
        gruppa.flagGrouppForm.modul_10 = False
    End Sub

    Private Sub Модуль10_MouseMove(sender As Object, e As MouseEventArgs) Handles Модуль10.MouseMove
        gruppa.flagGrouppForm.modul_10 = True
    End Sub

    Private Sub Модуль10_Enter(sender As Object, e As EventArgs) Handles Модуль10.Enter
        If gruppa.flagGrouppForm.modul_10 Then
            Модуль10.DroppedDown = False
        Else
            Модуль10.DroppedDown = True
        End If
    End Sub

    Private Sub Модуль10_EnabledChanged(sender As Object, e As EventArgs) Handles Модуль10.EnabledChanged
        If Модуль10.Enabled = False Then
            Модуль10.DroppedDown = False
        End If
    End Sub

    Private Sub НоваяГруппаФинансирование_MouseLeave(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.MouseLeave
        gruppa.flagGrouppForm.finansirovanie = False
    End Sub

    Private Sub НоваяГруппаФинансирование_MouseMove(sender As Object, e As MouseEventArgs) Handles НоваяГруппаФинансирование.MouseMove
        gruppa.flagGrouppForm.finansirovanie = True
    End Sub

    Private Sub НоваяГруппаФинансирование_Enter(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.Enter
        If gruppa.flagGrouppForm.finansirovanie Then
            НоваяГруппаФинансирование.DroppedDown = False
        Else
            НоваяГруппаФинансирование.DroppedDown = True
        End If
    End Sub

    Private Sub НоваяГруппаФинансирование_EnabledChanged(sender As Object, e As EventArgs) Handles НоваяГруппаФинансирование.EnabledChanged
        If НоваяГруппаФинансирование.Enabled = False Then
            НоваяГруппаФинансирование.DroppedDown = False
        End If
    End Sub

    Private Sub Квалификация_MouseLeave(sender As Object, e As EventArgs) Handles Квалификация.MouseLeave
        gruppa.flagGrouppForm.kvalifikaciya = False
    End Sub

    Private Sub Квалификация_MouseMove(sender As Object, e As MouseEventArgs) Handles Квалификация.MouseMove
        gruppa.flagGrouppForm.kvalifikaciya = True
    End Sub

    Private Sub Квалификация_Enter(sender As Object, e As EventArgs) Handles Квалификация.Enter
        If gruppa.flagGrouppForm.kvalifikaciya Then
            Квалификация.DroppedDown = False
        Else
            Квалификация.DroppedDown = True
        End If
    End Sub

    Private Sub Квалификация_EnabledChanged(sender As Object, e As EventArgs) Handles Квалификация.EnabledChanged
        If Квалификация.Enabled = False Then
            Квалификация.DroppedDown = False
        End If
    End Sub

    Private Sub versProgs_Click(sender As Object, e As EventArgs) Handles versProgs.Click
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = ActiveForm.Name
        ФормаСписок.ShowDialog()
    End Sub

    Private Sub НоваяГруппаПрограмма_SelectedIndexChanged(sender As Object, e As EventArgs) Handles НоваяГруппаПрограмма.SelectedIndexChanged
        gruppa.struct_gruppa.programma = НоваяГруппаПрограмма.Text
        If НоваяГруппаПрограмма.Text = "" Then
            gruppa.struct_gruppa.kodProgramm = -1
        Else
            If gruppa.struct_gruppa.flagAllListProgs Then
                gruppa.struct_gruppa.flagAllListProgs = False
                Return
            End If
            gruppa.updateKodProg()
        End If
        активироватьМодули(Me, НоваяГруппаПрограмма.Text, gruppa.struct_gruppa.kodProgramm)
    End Sub
End Class