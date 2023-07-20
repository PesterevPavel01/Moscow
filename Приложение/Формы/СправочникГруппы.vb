Public Class СправочникГруппы

    Public massiv
    Public numberGr As String
    Public kod As Integer
    Public year As Integer
    Public ИнформацияОГруппе

    Public gruppaData As New Gruppa.strGruppa


    Private Sub СтрокаПоиска_TextChanged(sender As Object, e As EventArgs) Handles СтрокаПоиска.TextChanged

        Me.ПоискПоСтрокеПоиска()

    End Sub

    Sub ПоискПоСтрокеПоиска()

        Label2.Visible = False
        Dim ПолеДляПоиска As String, ПолеДляСортировки As String

        ПолеДляСортировки = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаСортировкиГрупп)

        ПолеДляПоиска = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаПоискаГрупп)

        If СтрокаПоиска.Text = "" Then
            ListViewСписокГрупп.Items.Clear()
            ОбновитьГруппы()
        Else
            Label3.Visible = False
            massiv = SQLПоиск(СтрокаПоиска.Text, "`group`", "Код, Номер, Программа, Куратор, ДатаНЗ, ДатаКЗ", ПолеДляПоиска, ПолеДляСортировки & Интерфейс.ВидСортировки(Me, НастройкаСортировкиГрупп.НажатПБГр))
            Call ЗаписьВListView.ЗаписьВListView(False, False, ListViewСписокГрупп, massiv, 0, 1, 2, 3, 4, 5)
        End If

        СтрокаПоиска.TabIndex = Len(СтрокаПоиска.Text)



    End Sub


    Private Sub ListViewСписокГрупп_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewСписокГрупп.KeyDown
        Dim element
        Dim ind As String
        Dim kod As Integer, счетчик As Integer

        Label2.Visible = False


        '_________________________________________делит
        If e.KeyCode = 46 Then

            element = ListViewСписокГрупп.SelectedItems.Count

            ind = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(1).Text
            kod = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(0).Text

            If Not ЗаписьВБазу.ПроверкаСовпаденийЧислоДА_2("`group`", "Код", kod) = 2 Then

                MsgBox("Ошибка. Запись уже удалена. Нажмите кнопку Загрузить из базы, чтобы обновить список")
                GoTo Конец

            End If

            'ФормаДаНетУдалить.Label1.Text = "`group` № " & ind
            ФормаДаНетУдалить.текстДаНет.Text = "Удалить запись?"
            ФормаДаНетУдалить.ShowDialog()


            If ФормаДаНетУдалить.НажатаКнопкаДа Then

                If ЗаписьВБазу.ПроверкаСовпаденийЧислоДА_2("педнагрузка", "Kod", kod) = 2 Then

                    ЗаписьВБазу.УдалитьЗаписиСЧислом("педнагрузка", "Kod", kod)

                End If

                If ЗаписьВБазу.ПроверкаСовпаденийЧислоДА_2("group_list", "Kod", kod) = 2 Then

                    ЗаписьВБазу.УдалитьЗаписиСЧислом("group_list", "Kod", kod)

                End If

                ЗаписьВБазу.УдалитьЗаписиСЧислом("`group`", "Код", kod)

                If Not ЗаписьВБазу.ПроверкаСовпаденийЧислоДА_2("`group`", "Код", kod) = 2 Then

                    Label2.Visible = True
                    Label2.Text = "Группа № " & ind & " была удалена"

                End If

                ОбновитьГруппы()


            End If



        End If


        '_________________________________________вправо

        If e.KeyCode = 39 Then

            SendKeys.Send("{tab}")

        End If


Конец:
    End Sub

    Private Sub СтрокаПоиска_Click(sender As Object, e As EventArgs) Handles СтрокаПоиска.Click
        Label2.Visible = False
    End Sub

    Private Sub ListViewСписокГрупп_DoubleClick(sender As Object, e As EventArgs) Handles ListViewСписокГрупп.DoubleClick

        Dim СтрокаЗапроса As String

        Label2.Visible = False

        If Not ListViewСписокГрупп.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

            СписокСлушателейВГруппе.ListViewСписокСлушателей.Items.Clear()

            numberGr = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(1).Text

            If ListViewСписокГрупп.SelectedItems.Item(0).SubItems(0).Text = "" Then
                Exit Sub
            End If

            kod = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(0).Text
            Try
                year = Convert.ToDateTime(ListViewСписокГрупп.SelectedItems.Item(0).SubItems(4).Text).Year
            Catch ex As Exception
                Exit Sub
            End Try

            СтрокаЗапроса = checkGroup(kod)

            Label2.Visible = False

            ИнформацияОГруппе = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1)
            If CStr(ИнформацияОГруппе(0, 0)) = "нет записей" Then
                MsgBox("Группа была изменена, обновите данные нажатием кнопки 'Загрузить из базы' ")
                Exit Sub
            End If
            СписокСлушателейВГруппе.Text = "Группа № " & numberGr
            РедакторГруппы.Text = "Группа № " & numberGr
            СписокСлушателейВГруппе.ShowDialog()

        Else MsgBox("информация удалена")
        End If

    End Sub

    Private Sub BtnFocus_Click(sender As Object, e As EventArgs) Handles BtnFocus.Click
        Dim ind As Integer
        Dim yas As Boolean
        For Each item In ListViewСписокГрупп.Items

            yas = item.Equals(ListViewСписокГрупп.SelectedItems(0))

        Next

        ind = ListViewСписокГрупп.Items.Count
        ind = ListViewСписокГрупп.SelectedItems.IndexOfKey(ind)
        ListViewСписокГрупп.Items(0).SubItems.Item(1).Text = "Вова"
    End Sub

    Private Sub ListViewСписокГрупп_Click(sender As Object, e As EventArgs) Handles ListViewСписокГрупп.Click
        Label2.Visible = False
    End Sub

    Private Sub СправочникГруппы_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim name As String
        Dim str As String

        '_________________________________________Esc
        If e.KeyCode = 27 Then

            Me.Close()

        End If


        '_________________________________________вниз
        If e.KeyCode = 40 Then

            name = ActiveControl.Name
            If Not ActiveControl.Name = "ListViewСписокГрупп" Then

                SendKeys.Send("{tab}")
            Else


                Try
                    str = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(1).Text
                Catch ex As Exception

                    Try
                        ListViewСписокГрупп.Items(0).Selected = True
                    Catch ex1 As Exception
                        SendKeys.Send("{tab}")
                    End Try

                End Try


            End If

        End If
        '_________________________________________вправо
        If e.KeyCode = 39 Then

            If Not ActiveControl.Name = "ListViewСписокГрупп" Then

                SendKeys.Send("{tab}")
            End If

        End If

        '_________________________________________энтер

        If e.KeyCode = 13 Then

            Try
                str = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(1).Text

            Catch ex As Exception

                Exit Sub

            End Try


            ListViewСписокГрупп_DoubleClick(sender, e)

        End If


    End Sub

    Private Sub СправочникГруппы_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        openFormGroupp()
        ОбновитьГруппы()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.СтрокаПоиска.Clear()
        НастройкаПоискаГрупп.ShowDialog()
    End Sub


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        НастройкаСортировкиГрупп.ShowDialog()

    End Sub

    Private Sub СГУровеньКвалификации_SelectedIndexChanged(sender As Object, e As EventArgs) Handles СГУровеньКвалификации.SelectedIndexChanged
        If СГУровеньКвалификации.Text = "повышение квалификации" Then
            ААОсновная.cvalific = ААОсновная.PK
        ElseIf СГУровеньКвалификации.Text = "профессиональное обучение" Then
            ААОсновная.cvalific = ААОсновная.PO
        ElseIf СГУровеньКвалификации.Text = "профессиональная переподготовка" Then
            ААОсновная.cvalific = ААОсновная.PP
        End If
        openFormGroupp()
        ОбновитьГруппы()
    End Sub

    Public Sub ОбновитьГруппы()

        Dim Str As String, ПолеДляПоиска, ПолеДляСортировки As String

        ПолеДляСортировки = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаСортировкиГрупп)
        ПолеДляПоиска = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаПоискаГрупп)

        If ААОсновная.cvalific = ААОсновная.PK Then
            Me.СГУровеньКвалификации.Text = "повышение квалификации"
        ElseIf ААОсновная.cvalific = ААОсновная.PO Then
            Me.СГУровеньКвалификации.Text = "профессиональное обучение"
        ElseIf ААОсновная.cvalific = ААОсновная.PP Then
            Me.СГУровеньКвалификации.Text = "профессиональная переподготовка"
        End If

        Me.Label2.Visible = False
        Me.СтрокаПоиска.Visible = True
        Me.Label1.Visible = True

        If ААОсновная.cvalific = ААОсновная.PK Or ААОсновная.cvalific = ААОсновная.PP Then
            Str = load_spr_group(Me.СГУровеньКвалификации.Text, ПолеДляСортировки & Интерфейс.ВидСортировки(Me, НастройкаСортировкиГрупп.НажатПБГр), Me.yearSpravochnikGr.Text)
        Else
            Str = load_spr_group(Me.СГУровеньКвалификации.Text, ПолеДляСортировки & Интерфейс.ВидСортировки(Me, НастройкаСортировкиГрупп.НажатПБГр))
        End If

        Me.massiv = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(Str, 1)

        ЗаписьВListView.ЗаписьВListView(False, False, Me.ListViewСписокГрупп, Me.massiv, 0, 1, 2, 3, 4, 5)
        Me.СтрокаПоиска.Text = ""

        Try
            Me.ListViewСписокГрупп.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

    End Sub
    Sub openFormGroupp()
        If ААОсновная.cvalific = ААОсновная.PO Then
            Me.yearSpravochnikGr.Visible = False
        Else
            Me.yearSpravochnikGr.Visible = True
            Me.yearSpravochnikGr.Text = DateAndTime.Year(Date.Now())
        End If
    End Sub

    Private Sub yearSpravochnikGr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles yearSpravochnikGr.SelectedIndexChanged
        ОбновитьГруппы()
    End Sub

    Private Sub yearSpravochnikGr_TextChanged(sender As Object, e As EventArgs) Handles yearSpravochnikGr.TextChanged
        ОбновитьГруппы()
    End Sub
End Class