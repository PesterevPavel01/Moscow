Public Class ФормаСправочникСлушатели
    Public massiv
    Public Press As Boolean
    Public DelitMask As Boolean
    Public str As String
    Public РубашкаДобавлена = False

    Public Sub ПоказатьСправочникСлушатели()

        Dim Str As String, ПолеДляПоиска, ПолеДляСортировки As String

        ListViewСписокСлушателей.Visible = False

        ПолеДляСортировки = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаСортировкиСлушателей)
        ПолеДляПоиска = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаПоискаСлушателей)

        Label2.Visible = False

        СтрокаПоиска.Visible = True
        Label1.Visible = True
        PictureBox1.Visible = True

        Str = "SELECT Код, Снилс, Фамилия, Имя, Отчество FROM Слушатель ORDER BY " & ПолеДляСортировки & Интерфейс.ВидСортировки(Me, НастройкаСортировкиСлушателей.НажатПБСл)

        massiv = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(Str, 1)
        massiv = УбратьПустотыВМассиве.УбратьПустотыВМассиве(massiv)
        massiv = ДобавитьРубашку.ДобавитьРубашкуВМассив(massiv)

        Call ЗаписьВListView.ЗаписьВListView(False, True, ListViewСписокСлушателей, massiv, 1, 2, 3, 4)
        СтрокаПоиска.Text = ""
        ActiveControl = ListViewСписокСлушателей
        Try
            ListViewСписокСлушателей.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try
        ListViewСписокСлушателей.Visible = True

    End Sub

    Public ИнформацияОСлушателе

    Private Sub ListViewСписокСлушателей_DoubleClick(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.DoubleClick
        Dim СтрокаЗапроса As String
        Dim Снилс As String
        Label2.Visible = False

        If Not ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

            Label2.Visible = False

            Снилс = ДобавитьРубашку.УдалитьРубашку(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)

            РедакторСлушателя.Text = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(2).Text & " " & ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(3).Text & " " & ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(4).Text & " "

            СтрокаЗапроса = load_slushatel(Снилс)

            ИнформацияОСлушателе = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1)
            ИнформацияОСлушателе = УбратьПустотыВМассиве.УбратьПустотыВМассиве(ИнформацияОСлушателе)

            РедакторСлушателя.Show()

        Else MsgBox("информация удалена")

        End If
    End Sub

    Private Sub СтрокаПоиска_TextChanged(sender As Object, e As EventArgs) Handles СтрокаПоиска.TextChanged

        If РубашкаДобавлена Then
            СтрокаПоиска.SelectionStart = Len(СтрокаПоиска.Text)
            Exit Sub
        End If
        Me.ПоискПоСтрокеПоиска()

    End Sub

    Sub ПоискПоСтрокеПоиска()
        Label2.Visible = False
        Dim ПолеДляПоиска As String, ПолеДляСортировки As String

        ПолеДляСортировки = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаСортировкиСлушателей)
        ПолеДляПоиска = Интерфейс.ИмяВключенногоЧекбоксыНаФорме(НастройкаПоискаСлушателей)


        If ПолеДляПоиска = "Снилс" Then

            massiv = SQLПоиск(ДобавитьРубашку.УдалитьРубашку(СтрокаПоиска.Text), "Слушатель", "Снилс, Фамилия, Имя, Отчество, ДатаРождения", ПолеДляПоиска, ПолеДляСортировки & Интерфейс.ВидСортировки(НастройкаСортировкиСлушателей, НастройкаСортировкиСлушателей.НажатПБСл))

            If Not Press Then

                РубашкаДобавлена = True
                СтрокаПоиска.Text = ДобавитьРубашку.РубашкаНаВвод(СтрокаПоиска.Text, 3, 3, 3, 14)


            End If
            Press = True

            If Not massiv(0, 0) = "нет записей" Then

                massiv = ДобавитьРубашкуВМассив(massiv, 0)

            End If

        Else

            massiv = SQLПоиск(СтрокаПоиска.Text, "Слушатель", "Снилс, Фамилия, Имя, Отчество, ДатаРождения", ПолеДляПоиска, ПолеДляСортировки)
            massiv = ДобавитьРубашкуВМассив(massiv, 0)

        End If

        Call ЗаписьВListView.ЗаписьВListView(False, True, ListViewСписокСлушателей, massiv, 0, 1, 2, 3, 4)

        СтрокаПоиска.SelectionStart = Len(СтрокаПоиска.Text)

    End Sub

    Private Sub ФормаСправочникСлушатели_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        СтрокаПоиска.Visible = True
        Label1.Visible = False
        Label2.Visible = False

    End Sub

    Private Sub СтрокаПоиска_KeyDown(sender As Object, e As KeyEventArgs) Handles СтрокаПоиска.KeyDown

        Dim str As String


        str = СтрокаПоиска.Text


        If e.KeyCode = 8 Then

            Press = True
            СтрокаПоиска.Text = ДобавитьРубашку.УдалитьДефисВРубашке(str)

        End If

        Press = False
        РубашкаДобавлена = False

    End Sub

    Private Sub ListViewСписокСлушателей_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewСписокСлушателей.KeyDown
        Dim element
        Dim ind As String
        Dim nomer As Integer, счетчик As Integer

        Label2.Visible = False


        If e.KeyCode = Keys.Delete Then

            element = ListViewСписокСлушателей.SelectedItems.Count

            ind = УдалитьРубашку(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)
            nomer = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(0).Text

            If Not ЗаписьВБазу.ПроверкаСовпадений("Слушатель", "СНИЛС", ind) Then

                MsgBox("Ошибка. Запись уже удалена. Нажмите кнопку Загрузить из базы, чтобы обновить список")
                GoTo Конец

            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Удалить запись?"
            ФормаДаНетУдалить.ShowDialog()


            If ФормаДаНетУдалить.НажатаКнопкаДа Then

                If ЗаписьВБазу.ПроверкаСовпадений("group_list", "Слушатель", ind) Then

                    ЗаписьВБазу.УдалитьЗаписи("group_list", "Слушатель", ind)

                End If

                ЗаписьВБазу.УдалитьЗаписи("Слушатель", "СНИЛС", ind)

                If Not ЗаписьВБазу.ПроверкаСовпадений("Слушатель", "СНИЛС", ind) Then

                    Label2.Visible = True
                    Label2.Text = "Слушатель: Снилс №" & ind & " был удален."
                    Call ИзменениеВыделеннойСтрокиВListView.ИзменениеВыделеннойСтрокиВListView("СправочникСлушатели", 1, "удалено", 2, "удалено", 3, "удалено", 4, "удалено")
                    счетчик = 0
                    While счетчик < UBound(massiv, 1)

                        massiv(счетчик, nomer - 1) = "удалено"
                        счетчик = счетчик + 1

                    End While

                End If

            End If



        End If


Конец:
    End Sub

    Private Sub СтрокаПоиска_Click(sender As Object, e As EventArgs) Handles СтрокаПоиска.Click
        Label2.Visible = False
    End Sub


    Private Sub ListViewСписокСлушателей_Click(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.Click

        Label2.Visible = False

    End Sub

    Private Sub ДобавитьВГруппу_Click(sender As Object, e As EventArgs) Handles ДобавитьВГруппу.Click
        Dim Снилс As String, СтрокаЗапроса As String
        Dim Запросы
        Label2.Visible = False
        Try
            Снилс = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
        Catch ex As Exception
            MsgBox("Слушатель не выбран")
            Exit Sub
        End Try

        Снилс = ДобавитьРубашку.УдалитьРубашку(Снилс)

        Вспомогательный.ДобавитьВГруппу(Снилс)
        ActiveControl = BtnFocus
    End Sub

    Private Sub ListViewСписокСлушателей_GotFocus(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.GotFocus
        Dim str As String
        Try
            str = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
        Catch ex As Exception

            Try
                ListViewСписокСлушателей.Items(0).Selected = True
            Catch ex1 As Exception
                Exit Sub
            End Try

        End Try

    End Sub

    Private Sub ФормаСправочникСлушатели_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        '_________________________________________Esc
        If e.KeyCode = Keys.Escape Then

            Me.Close()

        End If


        '_________________________________________вниз
        If e.KeyCode = Keys.Down Then

            If Not ListViewСписокСлушателей.Focused Then

                SendKeys.Send("{tab}")

            Else

                Try
                    str = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
                Catch ex As Exception

                    Try
                        ListViewСписокСлушателей.Items(0).Selected = True
                    Catch ex1 As Exception
                        SendKeys.Send("{tab}")
                    End Try

                End Try


            End If

        End If
        '_________________________________________вправо
        If e.KeyCode = Keys.Right Then

            If Not ListViewСписокСлушателей.Focused Then

                SendKeys.Send("{tab}")

            End If

        End If

        '_________________________________________энтер

        If e.KeyCode = Keys.Enter Then

            Try
                str = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text

            Catch ex As Exception

                Exit Sub

            End Try


            Call ListViewСписокСлушателей_DoubleClick(sender, e)

        End If



    End Sub

    Private Sub Button1_GotFocus(sender As Object, e As EventArgs) Handles Button1.GotFocus
        Интерфейс.ШрифтКонтрола(Button1, 14.0F)
    End Sub

    Private Sub Button1_LostFocus(sender As Object, e As EventArgs) Handles Button1.LostFocus
        Интерфейс.ШрифтКонтрола(Button1, 11.0F)
    End Sub

    Private Sub ДобавитьВГруппу_GotFocus(sender As Object, e As EventArgs) Handles ДобавитьВГруппу.GotFocus
        Интерфейс.ШрифтКонтрола(ДобавитьВГруппу, 14.0F)
    End Sub

    Private Sub ДобавитьВГруппу_LostFocus(sender As Object, e As EventArgs) Handles ДобавитьВГруппу.LostFocus
        Интерфейс.ШрифтКонтрола(ДобавитьВГруппу, 11.0F)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.СтрокаПоиска.Clear()
        НастройкаПоискаСлушателей.ShowDialog()
    End Sub


    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        НастройкаСортировкиСлушателей.ShowDialog()
    End Sub

    Private Sub ListViewСписокСлушателей_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.SelectedIndexChanged
        Dim Dtable As DataTable
        Dim Snils, SqlString As String

        Try
            Snils = ДобавитьРубашку.УдалитьРубашку(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)
        Catch ex As Exception
            Exit Sub
        End Try

        SqlString = sprSlushTblGroup(Snils)
        Dtable = ААОсновная.mySqlConnect.ЗагрузитьИзMySQLвDataTable(SqlString, 1)
        ССлушТаблицаИнфСлушателя.DataSource = Dtable
        ''ССлушТаблицаИнфСлушателя.AutoResizeColumn(0)
        'ССлушТаблицаИнфСлушателя.AutoResizeColumn(1)

        If ССлушТаблицаИнфСлушателя.Columns.Count <> 5 Then
            Return
        End If

        ССлушТаблицаИнфСлушателя.Columns(0).Width = ССлушТаблицаИнфСлушателя.Width * 0.1
        ССлушТаблицаИнфСлушателя.Columns(1).Width = ССлушТаблицаИнфСлушателя.Width * 0.15
        ССлушТаблицаИнфСлушателя.Columns(2).Width = ССлушТаблицаИнфСлушателя.Width * 0.5
        ССлушТаблицаИнфСлушателя.Columns(3).Width = ССлушТаблицаИнфСлушателя.Width * 0.125
        ССлушТаблицаИнфСлушателя.Columns(4).Width = ССлушТаблицаИнфСлушателя.Width * 0.125

        ССлушТаблицаИнфСлушателя.DefaultCellStyle.Font = New Font("Microsoft YaHei", 10)

    End Sub
End Class