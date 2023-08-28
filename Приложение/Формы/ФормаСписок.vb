
Public Class ФормаСписок
    Public currentControl As Control
    Public headerVisible As Boolean
    Dim queryString As String
    Public textboxName As String
    Public FormName As String
    Public resultArray
    Public onCheckboxes As String
    Public sort As UInt16 = 0
    Public sortColumn As Integer = -1
    Public Const poVozr = 1
    Public Const poUb = 2
    Public images As imagesStruct
    Dim path As String
    Dim swichKvalification As SwitchCvalification

    Private Sub FormList_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim nameTbl As String
        Dim prikaz As String = ""

        ListViewСписок.Sorting = SortOrder.None
        header.Visible = False

        If Strings.Left(textboxName, 7) = "CheckBox" Or textboxName = "НоваяГруппаДатаНачалаЗанятий" Or textboxName = "НоваяГруппаКонецЗанятий" Or Strings.Left(textboxName, 4) = "Дата" Or Strings.Left(textboxName, 4) = "дата" Then
            Me.Close()
        End If

        searchValue.Text = ""

        nameTbl = ИдентифицироватьБазу.ИдентифицироватьБазу(textboxName)

        If textboxName = "НомерГруппы" Or textboxName = "groupNumber" Then

            If headerVisible Then

                header.Visible = True
                pkOn_Click(sender, e)

            Else

                header.Visible = False
                loadListGroup()

            End If

            Return

        ElseIf textboxName = "НоваяГруппаПрограмма" Or textboxName = "versProgs" Then

            If FormName = "НоваяГруппа" And MainForm.cvalific > 0 Then

                queryString = ProgramPoUKvalifik(НоваяГруппа.swichCvalification.activeType)

            ElseIf FormName = "РедакторГруппы" And РедакторГруппы.НоваяГруппаУровеньКвалификации.Text <> "" Then

                queryString = ProgramPoUKvalifik(РедакторГруппы.НоваяГруппаУровеньКвалификации.Text)

            Else

                queryString = formList__loadProgramms()

            End If

            ListViewСписок.Columns(0).Width = ListViewСписок.Width - 150
            ListViewСписок.Columns(1).Width = 150
            ListViewСписок.Columns(0).Text = "Программа"
            ListViewСписок.Columns(1).Text = "Дата"
            ListViewСписок.Columns.Add("Код", 1)
            Text = "Программа. Расширенный список"

        ElseIf textboxName = "НоваяГруппаУровеньКвалификации" Then

            queryString = formList__loadProfLevel(nameTbl)

        Else

            queryString = "SELECT * FROM " & nameTbl

        End If

        If textboxName = "Ответственный" And АСформироватьПриказ.Label4.Text = "Слушатель(ФИО)" Then

            queryString = formList__loadOtvOrSlush(Convert.ToString(MainForm.prikazKodGroup))

        End If

        If queryString = "SELECT * FROM " Then

            Return

        End If

        resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If resultArray(0, 0).ToString = "ошибка" Then

            MsgBox("ошибка, повторите последнее действие")
            Exit Sub

        End If

        If textboxName = "versProgs" Then

            UpdateListView.updateListView(False, False, ListViewСписок, resultArray, 0, 1, 2)

        Else

            UpdateListView.updateListView(False, True, ListViewСписок, resultArray, 1)

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

    Private Sub loadListGroup()

        queryString = SQLString_loadGruppa()

        resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        UpdateListView.updateListView(False, False, ListViewСписок, resultArray, 0, 1, 2, 3)

        queryString = formList__loadKodGroupPP()

        listViewColoriz(ListViewСписок, MainForm.mySqlConnect.loadMySqlToArray(queryString, 1))

    End Sub

    Private Sub updateFormName(textboxName As String, prikaz As String)

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

        If textboxName = "НомерГруппы" Or textboxName = "НоваяГруппаПрограмма" Or textboxName = "GroupNumber" Then

            ind = ListViewСписок.SelectedItems(0).SubItems(0).Text

        Else

            ind = ListViewСписок.SelectedItems(0).SubItems(1).Text

        End If


        If FormName = "ВедомостьПеднагрузка" Then

            If textboxName = "groupNumber" Then
                ВедомостьПеднагрузка.kodGroup = ListViewСписок.SelectedItems(0).SubItems(3).Text
            End If

            ВедомостьПеднагрузка.groupNumber.Text = ind

        End If

        If FormName = "MainForm" Then

            If currentControl.Name = "ДиректорФИО" Then
                ind = ind.Trim
                ind = Strings.Right(ind, 4) & " " & Strings.Left(ind, Strings.Len(ind) - 4)

                If Strings.Right(Strings.Left(ind, 4), 1) = "." And Strings.Right(Strings.Left(ind, 2), 1) = "." Then
                Else
                    предупреждение.текст.Text = "Ошибка в ФИО"
                    openForm(предупреждение)
                    Exit Sub
                End If

            End If

            currentControl.Text = ind
            Me.Close()

            Return

            For Each page In MainForm.TabControlOther.Controls

                For Each element In page.Controls

                    If element.Name = textboxName Then

                        If element.Name = "ДиректорФИО" Then
                            ind = ind.Trim
                            ind = Strings.Right(ind, 4) & " " & Strings.Left(ind, Strings.Len(ind) - 4)

                            If Strings.Right(Strings.Left(ind, 4), 1) = "." And Strings.Right(Strings.Left(ind, 2), 1) = "." Then
                            Else
                                предупреждение.текст.Text = "Ошибка в ФИО"
                                openForm(предупреждение)
                                Exit Sub
                            End If

                        End If

                        element.Text = ind
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
                MainForm.prikazKodGroup = ListViewСписок.SelectedItems(0).SubItems(3).Text
            End If
            For Each i In АСформироватьПриказ.Controls
                If i.Name = textboxName Then
                    If (i.Name = "Утверждает" And АСформироватьПриказ.Label2.Text = "Директор") Or i.Name = "ДиректорФИО" Then
                        ind = ind.Trim
                        ind = Strings.Right(ind, 4) & " " & Strings.Left(ind, Strings.Len(ind) - 4)
                        If Strings.Right(Strings.Left(ind, 4), 1) = "." And Strings.Right(Strings.Left(ind, 2), 1) = "." Then
                        Else
                            предупреждение.текст.Text = "Ошибка в ФИО"
                            openForm(предупреждение)
                            Exit Sub
                        End If
                    End If
                    i.Text = ind
                    If i.name = "ПОЗачисленииНомерГруппы" Then
                        checkGroup()
                    End If
                End If
            Next
        End If

        Me.Close()

    End Sub

    Private Sub searchValue_TextChanged(sender As Object, e As EventArgs) Handles searchValue.TextChanged

        Dim queryString As String

        If searchValue.Text = "" Then

            If textboxName = "ПОЗачисленииНомерГруппы" Then
                UpdateListView.updateListView(False, True, ListViewСписок, resultArray, 0)
            Else
                FormList_Shown(sender, e)
            End If

        Else

            If textboxName.IndexOf("НомерГруппы") >= 0 Then

                queryString = SQLString_loadGruppa(True, "Номер", searchValue.Text, True)
                resultArray = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)
                UpdateListView.updateListView(False, False, ListViewСписок, resultArray, 0, 1, 2, 3)
                queryString = formList__loadKodGroupPP()
                listViewColoriz(ListViewСписок, MainForm.mySqlConnect.loadMySqlToArray(queryString, 1))

            Else resultArray = Search.search(searchValue.Text, resultArray, 1)

                UpdateListView.updateListView(False, True, ListViewСписок, resultArray, 1)

            End If

        End If
    End Sub

    Sub checkGroup()

        Dim sqlQuery, students
        sqlQuery = formList__checkGroup(MainForm.prikazKodGroup)
        students = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)
        If students(0, 0).ToString = "нет записей" Then
            предупреждение.текст.Text = "В выбранной группе нет слушателей"
            openForm(предупреждение)
            If АСформироватьПриказ.Label4.Text = "Слушатель(ФИО)" Then
                АСформироватьПриказ.Ответственный.Text = ""
            End If
        End If


    End Sub

    Private Sub ФормаСписок_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim str As String
        Call closeEsc(Me, e.KeyCode)
        If e.KeyCode = 40 Then
            If ActiveControl.Name = "ListViewСписок" Then
                Try
                    str = ListViewСписок.SelectedItems.Item(0).SubItems(1).Text
                Catch ex As Exception
                    Call pressTab(e.KeyCode, 40)
                End Try
                Exit Sub
            Else Call pressTab(e.KeyCode, 40)
            End If
        End If

        pressTab(e.KeyCode, 39)

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

        If (Me.Text = "Группа" Or Me.Text = "ГруппаНомер" Or Me.Text = "НомерГруппы") And ListViewСписок.Columns(e.Column).Text = "Номер" And MainForm.prikazCvalif = MainForm.PK Then
            If e.Column <> sortColumn Then
                sort = poUb
            Else
                If sort = poUb Then
                    sort = poVozr
                Else
                    sort = poUb
                End If
            End If
            sortColumn = e.Column

            FormList_Shown(sender, e)

            Dim sqlQuery As String
            sqlQuery = formList__loadKodGroupPP()
            listViewColoriz(ListViewСписок, MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1))

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

        headerVisible = False
        header.Visible = False

    End Sub

    Private Sub SelectedRow(numberColumns As Int16, value As String)

        For Each item In ListViewСписок.Items
            If item.SubItems(numberColumns).Text = value Then
                item.Selected = True
                Return
            End If
        Next

    End Sub

    Private Sub ФормаСписок_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        swichKvalification = New SwitchCvalification
        swichKvalification.pp = ppOn
        swichKvalification.po = poOn
        swichKvalification.pk = pkOn
        swichKvalification.init()

    End Sub

    Private Sub pkOn_Click(sender As Object, e As EventArgs) Handles pkOn.Click

        swichKvalification.activate(swichKvalification.type("pk"))
        MainForm.prikazCvalif = MainForm.PK
        loadListGroup()
    End Sub

    Private Sub poOn_Click(sender As Object, e As EventArgs) Handles poOn.Click
        swichKvalification.activate(swichKvalification.type("po"))
        MainForm.prikazCvalif = MainForm.PO
        loadListGroup()
    End Sub

    Private Sub ppOn_Click(sender As Object, e As EventArgs) Handles ppOn.Click
        swichKvalification.activate(swichKvalification.type("pp"))
        MainForm.prikazCvalif = MainForm.PP
        loadListGroup()
    End Sub

End Class


