Imports Org.BouncyCastle.Crypto

Public Class ФормаСписок
    Public textboxName As String
    Public FormName As String
    Public massiv
    Public вклЧекбоксы As String
    Public sort As UInt16 = 0
    Public sortColumn As Integer = -1
    Public Const PoVozr = 1
    Public Const PoUb = 2

    'Private Sub SelectRow(kod As String)
    '    Dim numberRow As Integer = ДействияСДатаГрид.dataGridViewSearchRow(ListViewСписок.Rows, 0, newProgramm.Text)
    '    dataGridProgs.CurrentCell = dataGridProgs.Rows(numberRow).Cells(0)
    '    dataGridProgs.Rows(numberRow).Cells(0).Selected = True
    'End Sub

    Private Sub Список_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim nameTbl As String
        Dim СтрокаЗапроса As String
        Dim prikaz As String = ""

        ListViewСписок.Sorting = SortOrder.None

        If Strings.Left(textboxName, 7) = "CheckBox" Or textboxName = "НоваяГруппаДатаНачалаЗанятий" Or textboxName = "НоваяГруппаКонецЗанятий" Or Strings.Left(textboxName, 4) = "Дата" Or Strings.Left(textboxName, 4) = "дата" Then
            Me.Close()
        End If

        СтрокаПоиска.Text = ""

        nameTbl = ИдентифицироватьБазу.ИдентифицироватьБазу(textboxName)

        Text = textboxName

        If textboxName = "НоваяГруппаПрограмма" Or textboxName = "versProgs" Then

            If FormName = "НоваяГруппа" And НоваяГруппа.НоваяГруппаУровеньКвалификации.Text <> "" Then

                СтрокаЗапроса = ProgrammPoUKvalifik(НоваяГруппа.НоваяГруппаУровеньКвалификации.Text)

            ElseIf FormName = "РедакторГруппы" And РедакторГруппы.НоваяГруппаУровеньКвалификации.Text <> "" Then

                СтрокаЗапроса = ProgrammPoUKvalifik(РедакторГруппы.НоваяГруппаУровеньКвалификации.Text)

            Else

                СтрокаЗапроса = formList__loadProgramms()

            End If

            ListViewСписок.Columns(0).Width = 500
            ListViewСписок.Columns(1).Width = 100
            ListViewСписок.Columns(0).Text = "Программа"
            ListViewСписок.Columns(1).Text = "Дата"
            ListViewСписок.Columns.Add("Код", 1)
            Me.Text = "Программа. Расширенный список"

        ElseIf textboxName = "НоваяГруппаУровеньКвалификации" Then

            СтрокаЗапроса = formList__loadProfLevel(nameTbl)

        Else

            If (nameTbl = "`group`") Then

                СтрокаЗапроса = formList__loadKodGroup(ААОсновная.mySqlConnect.dateToFormatMySQL(Date.Now.AddMonths(-6)))
            Else

                СтрокаЗапроса = "SELECT * FROM " & nameTbl

            End If

        End If

        If textboxName = "ПОЗачисленииНомерГруппы" Or textboxName = "НомерГруппы" Or textboxName = "ГруппаОценочнаяВедомость" Or textboxName = "ГруппаОценкиИА" Then

            СтрокаЗапроса = SQLString_loadGruppa()

        End If

        If textboxName = "Ответственный" And АСформироватьПриказ.Label4.Text = "Слушатель(ФИО)" Then

            СтрокаЗапроса = formList__loadOtvOrSlush(Convert.ToString(ААОсновная.prikazKodGroup))

        End If

        If СтрокаЗапроса = "SELECT * FROM " Then

            Return

        End If

        massiv = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Not massiv(0, 0).ToString = "ошибка" Then

            If textboxName = "ПОЗачисленииНомерГруппы" Or textboxName = "НомерГруппы" Or textboxName = "ГруппаОценочнаяВедомость" Or textboxName = "ГруппаОценкиИА" Then

                ЗаписьВListView.ЗаписьВListView(False, False, ListViewСписок, massiv, 0, 1, 2, 3)
                Dim QueryString As String
                QueryString = formList__loadKodGroupPP()
                listViewColoriz(ListViewСписок, ЗагрузитьИзБазы.ЗагрузитьИзБазы(QueryString))

            ElseIf textboxName = "versProgs" Then

                ЗаписьВListView.ЗаписьВListView(False, False, ListViewСписок, massiv, 0, 1, 2)

            Else

                ЗаписьВListView.ЗаписьВListView(False, True, ListViewСписок, massiv, 1)

            End If

        Else

            MsgBox("ошибка, повторите последнее действие")
            Exit Sub

        End If

        ActiveControl = ListViewСписок

        Try
            ListViewСписок.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

        If textboxName = "versProgs" And FormName = "НоваяГруппа" Then

            SelectedRow(2, НоваяГруппа.getProgKod())
            textboxName = "НоваяГруппаПрограмма"

        ElseIf textboxName = "versProgs" And FormName = "РедакторГруппы" Then

            SelectedRow(2, РедакторГруппы.getProgKod())
            textboxName = "НоваяГруппаПрограмма"

        End If


    End Sub
    Private Sub НаименованиеФормы(textboxName As String, prikaz As String)
        If textboxName = "Ответственный" And АСформироватьПриказ.Label4.Text = "Слушатель(ФИО)" Then
            Me.Text = "Список слушателей группы"
        End If
        If prikaz = "спецэкзамен" Then

            If textboxName = "ПОЗачисленииНомерГруппы" Then
                Me.Text = "Список групп"
            End If
            If textboxName = "РуководительСтажировки" Then
                Me.Text = "Комиссия 1"
            End If
            If textboxName = "Комиссия2" Then
                Me.Text = "Комиссия 2"
            End If
            If textboxName = "Комиссия3" Then
                Me.Text = "Комиссия 3"
            End If
            If textboxName = "ПроектВносит" Then
                Me.Text = "Комиссия 4"
            End If
            If textboxName = "Исполнитель" Then
                Me.Text = "Комиссия 5"
            End If
            If textboxName = "Согласовано1" Then
                Me.Text = "Комиссия 6"
            End If
            If textboxName = "Ответственный" Then
                Me.Text = "Зам председателя комиссии"
            End If
            If textboxName = "Утверждает" Then
                Me.Text = "Председатель комиссии"
            End If

        End If

    End Sub
    Private Sub ListViewСписок_DoubleClick(sender As Object, e As EventArgs) Handles ListViewСписок.DoubleClick

        Dim ind As String

        If textboxName = "НомерГруппы" Or textboxName = "НоваяГруппаПрограмма" Then

            ind = ListViewСписок.SelectedItems(0).SubItems(0).Text

        Else

            ind = ListViewСписок.SelectedItems(0).SubItems(1).Text

        End If


        If FormName = "ВедомостьПеднагрузка" Then

            If textboxName = "НомерГруппы" Then
                ВедомостьПеднагрузка.kodGroup = ListViewСписок.SelectedItems(0).SubItems(3).Text
            End If

            For Each i In ВедомостьПеднагрузка.Controls

                If i.Name = textboxName Then

                    i.Text = ind

                End If

            Next

        End If

        If FormName = "ААОсновная" Then
            For Each Вкладки In ААОсновная.TabControlOther.Controls
                For Each Элемент In Вкладки.Controls
                    If Элемент.Name = textboxName Then
                        If Элемент.Name = "ДиректорФИО" Then
                            ind = ind.Trim
                            ind = Strings.Right(ind, 4) & " " & Strings.Left(ind, Strings.Len(ind) - 4)
                            If Strings.Right(Strings.Left(ind, 4), 1) = "." And Strings.Right(Strings.Left(ind, 2), 1) = "." Then
                            Else
                                предупреждение.текст.Text = "Ошибка в ФИО"
                                ОткрытьФорму(предупреждение)
                                Exit Sub
                            End If
                        End If
                        Элемент.Text = ind
                        Me.Close()
                        Return
                    End If
                Next
            Next
        End If

        If FormName = "АОценкиИА" Then
            If textboxName = "НомерГруппы" Then
                АОценкиИА.kodGroup = ListViewСписок.SelectedItems(0).SubItems(3).Text
            End If
            For Each i In АОценкиИА.Controls
                If i.Name = textboxName Then
                    i.Text = ind
                End If
            Next
        End If


        If FormName = "ОценочнаяВедомость" Then
            If textboxName = "НомерГруппы" Then
                ОценочнаяВедомость.kodGroup = ListViewСписок.SelectedItems(0).SubItems(3).Text
            End If
            For Each i In ОценочнаяВедомость.Controls
                If i.Name = textboxName Then
                    i.Text = ind
                End If
            Next
        End If


        If FormName = "НоваяГруппа" Then

            If (textboxName = "НоваяГруппаУровеньКвалификации") Then
                НоваяГруппа.НомерДиплома.Clear()
                НоваяГруппа.РегНомерДиплома.Clear()
                НоваяГруппа.НомерСвид.Clear()
                НоваяГруппа.РегНомерСвид.Clear()
                НоваяГруппа.НомерУд.Clear()
                НоваяГруппа.РегНомерУд.Clear()
                НоваяГруппа.НомерПротоколаСпецэкзамен.Clear()
            End If

            If (textboxName = "НоваяГруппаПрограмма") Then

                НоваяГруппа.setProgKod(Convert.ToInt32(ListViewСписок.SelectedItems(0).SubItems(2).Text))

            End If


            For Each i In НоваяГруппа.Controls
                If i.Name = textboxName Then
                    i.Text = ind
                End If
            Next
        End If

        If FormName = "РедакторГруппы" Then

            If (textboxName = "НоваяГруппаУровеньКвалификации") Then
                РедакторГруппы.НомерДиплома.Clear()
                РедакторГруппы.РегНомерДиплома.Clear()
                РедакторГруппы.НомерСвид.Clear()
                РедакторГруппы.РегНомерСвид.Clear()
                РедакторГруппы.НомерУд.Clear()
                РедакторГруппы.РегНомерУд.Clear()
                РедакторГруппы.НомерПротоколаСпецэкзамен.Clear()

            End If

            If (textboxName = "НоваяГруппаПрограмма") Then

                РедакторГруппы.setProgKod(Convert.ToInt32(ListViewСписок.SelectedItems(0).SubItems(2).Text))

            End If

            For Each i In РедакторГруппы.Controls
                If i.Name = textboxName Then
                    i.Text = ind
                End If
            Next
        End If

        If FormName = "РедакторСлушателя" Then
            For Each i In РедакторСлушателя.Controls
                If i.Name = textboxName Then
                    i.Text = ind
                End If
            Next
        End If

        If FormName = "НовыйСлушатель" Then
            For Each i In НовыйСлушатель.Controls
                If i.Name = textboxName Then
                    i.Text = ind
                End If
            Next
        End If

        If FormName = "АСформироватьПриказ" Then
            If textboxName = "НомерГруппы" Then
                ААОсновная.prikazKodGroup = ListViewСписок.SelectedItems(0).SubItems(3).Text
            End If
            For Each i In АСформироватьПриказ.Controls
                If i.Name = textboxName Then
                    If (i.Name = "Утверждает" And АСформироватьПриказ.Label2.Text = "Директор") Or i.Name = "ДиректорФИО" Then
                        ind = ind.Trim
                        ind = Strings.Right(ind, 4) & " " & Strings.Left(ind, Strings.Len(ind) - 4)
                        If Strings.Right(Strings.Left(ind, 4), 1) = "." And Strings.Right(Strings.Left(ind, 2), 1) = "." Then
                        Else
                            предупреждение.текст.Text = "Ошибка в ФИО"
                            ОткрытьФорму(предупреждение)
                            Exit Sub
                        End If
                    End If
                    i.Text = ind
                    If i.name = "ПОЗачисленииНомерГруппы" Then
                        проверитьГруппу()
                    End If
                End If
            Next
        End If

        Me.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles СтрокаПоиска.TextChanged
        Dim mass

        If СтрокаПоиска.Text = "" Then


            If textboxName = "ПОЗачисленииНомерГруппы" Then
                ЗаписьВListView.ЗаписьВListView(False, True, ListViewСписок, massiv, 0)
            Else ЗаписьВListView.ЗаписьВListView(False, True, ListViewСписок, massiv, 0)
            End If
        Else
            If textboxName = "ПОЗачисленииНомерГруппы" Then
                mass = SQLПоиск(СтрокаПоиска.Text, "`group`", "Номер", "Номер", "Номер")
                ЗаписьВListView.ЗаписьВListView(False, True, ListViewСписок, mass, 0)
            Else mass = Поиск.Поиск(СтрокаПоиска.Text, massiv, 1)
                ЗаписьВListView.ЗаписьВListView(False, True, ListViewСписок, mass, 1)
            End If


        End If
    End Sub

    Sub проверитьГруппу()
        Dim строкаЗапроса, Слушатели
        строкаЗапроса = formList__checkGroup(ААОсновная.prikazKodGroup)
        Слушатели = ЗагрузитьИзБазы.ЗагрузитьИзБазы(строкаЗапроса)
        If Слушатели(0, 0).ToString = "нет записей" Then
            предупреждение.текст.Text = "В выбранной группе нет слушателей"
            ОткрытьФорму(предупреждение)
            If АСформироватьПриказ.Label4.Text = "Слушатель(ФИО)" Then
                АСформироватьПриказ.Ответственный.Text = ""
            End If
        End If


    End Sub

    Private Sub ФормаСписок_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim str As String
        Call ЗакрытьEsc(Me, e.KeyCode)
        If e.KeyCode = 40 Then
            If ActiveControl.Name = "ListViewСписок" Then
                Try
                    str = ListViewСписок.SelectedItems.Item(0).SubItems(1).Text
                Catch ex As Exception
                    Call функционалТаб(e.KeyCode, 40)
                End Try
                Exit Sub
            Else Call функционалТаб(e.KeyCode, 40)
            End If
        End If

        функционалТаб(e.KeyCode, 39)

        If e.KeyCode = 13 Then
            Try
                str = ListViewСписок.SelectedItems.Item(0).SubItems(1).Text
            Catch ex As Exception
                Exit Sub
            End Try
            Call ListViewСписок_DoubleClick(sender, e)
        End If


    End Sub

    Private Sub ListViewСписок_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListViewСписок.ColumnClick

        If (Me.Text = "Группа" Or Me.Text = "ГруппаНомер" Or Me.Text = "НомерГруппы") And ListViewСписок.Columns(e.Column).Text = "Номер" And ААОсновная.prikazCvalif = ААОсновная.PK Then
            If e.Column <> sortColumn Then
                sort = PoUb
            Else
                If sort = PoUb Then
                    sort = PoVozr
                Else
                    sort = PoUb
                End If
            End If
            sortColumn = e.Column

            Список_Shown(sender, e)

            Dim QueryString As String
            QueryString = formList__loadKodGroupPP()
            listViewColoriz(ListViewСписок, ЗагрузитьИзБазы.ЗагрузитьИзБазы(QueryString))

            Return

        End If

        If e.Column <> sortColumn Then

            sortColumn = e.Column
            ListViewСписок.Sorting = SortOrder.Ascending
            ListViewСписок.Sort()
            ListViewСписок.ListViewItemSorter = New ListViewItemComparer(e.Column, SortOrder.Ascending)

        Else

            If ListViewСписок.Sorting = SortOrder.Ascending Then

                ListViewСписок.Sorting = SortOrder.Descending
                ListViewСписок.Sort()
                ListViewСписок.ListViewItemSorter = New ListViewItemComparer(e.Column, SortOrder.Descending)

            Else

                ListViewСписок.Sorting = SortOrder.Ascending
                ListViewСписок.Sort()
                ListViewСписок.ListViewItemSorter = New ListViewItemComparer(e.Column, SortOrder.Ascending)

            End If

        End If

    End Sub

    Private Sub ФормаСписок_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If textboxName = "НоваяГруппаПрограмма" Or textboxName = "versProgs" Then
            ListViewСписок.Columns.RemoveAt(2)
        End If

    End Sub

    Private Sub SelectedRow(numberColumns As Int16, value As String)
        'Dim countRow As Integer
        'countRow = ListViewСписок.Items.Count
        'If countRow < 1 Then
        '    Return
        'End If
        'countRow = 0
        For Each item In ListViewСписок.Items
            If item.SubItems(numberColumns).Text = value Then
                item.Selected = True
                Return
            End If
        Next

    End Sub
End Class