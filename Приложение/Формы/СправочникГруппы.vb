Public Class СправочникГруппы

    Public massiv
    Public numberGr As String
    Public kod As Integer
    Public year As Integer
    Public infoAboutGroup

    Public gruppaData As New Group.strGruppa


    Private Sub searchRow_TextChanged(sender As Object, e As EventArgs) Handles СтрокаПоиска.TextChanged

        search()

    End Sub

    Sub search()

        Label2.Visible = False
        Dim serchCol As String, sortCol As String

        sortCol = Интерфейс.nameCheckedCheckBox(sortSetts)

        serchCol = Интерфейс.nameCheckedCheckBox(НастройкаПоискаГрупп)

        If СтрокаПоиска.Text = "" Then
            ListViewСписокГрупп.Items.Clear()
            updateGroupList()
        Else
            Label3.Visible = False
            massiv = sqlSearch(СтрокаПоиска.Text, "`group`", "Код, Номер, Программа, Куратор, ДатаНЗ, ДатаКЗ", serchCol, sortCol & Интерфейс.sortType(sortSetts.НажатПБГр))
            Call UpdateListView.updateListView(False, False, ListViewСписокГрупп, massiv, 0, 1, 2, 3, 4, 5)
        End If

        СтрокаПоиска.TabIndex = Len(СтрокаПоиска.Text)



    End Sub


    Private Sub ListViewСписокГрупп_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewСписокГрупп.KeyDown
        Dim element
        Dim ind As String
        Dim kod As Integer, счетчик As Integer

        Label2.Visible = False


        '_________________________________________делит
        If e.KeyCode = Keys.Delete Then

            element = ListViewСписокГрупп.SelectedItems.Count

            ind = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(1).Text
            kod = ListViewСписокГрупп.SelectedItems.Item(0).SubItems(0).Text

            InsertIntoDataBase.argumentClear()
            InsertIntoDataBase.argument.nameTable = "`group`"
            InsertIntoDataBase.argument.firstName = "Код"
            InsertIntoDataBase.argument.firstValue = kod

            If Not InsertIntoDataBase.checkUniq_No2() = 2 Then

                MsgBox("Ошибка. Запись уже удалена. Нажмите кнопку Загрузить из базы, чтобы обновить список")
                GoTo Конец

            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Удалить запись?"
            ФормаДаНетУдалить.ShowDialog()


            If ФормаДаНетУдалить.НажатаКнопкаДа Then

                InsertIntoDataBase.argumentClear()
                InsertIntoDataBase.argument.nameTable = "pednagruzka"
                InsertIntoDataBase.argument.firstName = "Kod"
                InsertIntoDataBase.argument.firstValue = kod

                If InsertIntoDataBase.checkUniq_No2() = 2 Then

                    InsertIntoDataBase.deleteFromDB_NumberArg()

                End If

                InsertIntoDataBase.argumentClear()
                InsertIntoDataBase.argument.nameTable = "group_list"
                InsertIntoDataBase.argument.firstName = "Kod"
                InsertIntoDataBase.argument.firstValue = kod

                If InsertIntoDataBase.checkUniq_No2() = 2 Then

                    InsertIntoDataBase.deleteFromDB_NumberArg()

                End If

                InsertIntoDataBase.argumentClear()
                InsertIntoDataBase.argument.nameTable = "`group`"
                InsertIntoDataBase.argument.firstName = "Код"
                InsertIntoDataBase.argument.firstValue = kod

                InsertIntoDataBase.deleteFromDB_NumberArg()

                If Not InsertIntoDataBase.checkUniq_No2() = 2 Then

                    Label2.Visible = True
                    Label2.Text = "Группа № " & ind & " была удалена"

                End If

                updateGroupList()


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

            СписокСлушателейВГруппе.ListViewStudentsList.Items.Clear()

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

            infoAboutGroup = MainForm.mySqlConnect.loadMySqlToArray(СтрокаЗапроса, 1)
            If CStr(infoAboutGroup(0, 0)) = "нет записей" Then
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
        updateGroupList()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.СтрокаПоиска.Clear()
        НастройкаПоискаГрупп.ShowDialog()
    End Sub


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        sortSetts.ShowDialog()

    End Sub

    Private Sub СГУровеньКвалификации_SelectedIndexChanged(sender As Object, e As EventArgs) Handles СГУровеньКвалификации.SelectedIndexChanged
        If СГУровеньКвалификации.Text = "повышение квалификации" Then
            MainForm.cvalific = MainForm.PK
        ElseIf СГУровеньКвалификации.Text = "профессиональное обучение" Then
            MainForm.cvalific = MainForm.PO
        ElseIf СГУровеньКвалификации.Text = "профессиональная переподготовка" Then
            MainForm.cvalific = MainForm.PP
        End If
        openFormGroupp()
        updateGroupList()
    End Sub

    Public Sub updateGroupList()

        Dim Str As String, ПолеДляПоиска, ПолеДляСортировки As String

        ПолеДляСортировки = Интерфейс.nameCheckedCheckBox(sortSetts)
        ПолеДляПоиска = Интерфейс.nameCheckedCheckBox(НастройкаПоискаГрупп)

        If MainForm.cvalific = MainForm.PK Then
            Me.СГУровеньКвалификации.Text = "повышение квалификации"
        ElseIf MainForm.cvalific = MainForm.PO Then
            Me.СГУровеньКвалификации.Text = "профессиональное обучение"
        ElseIf MainForm.cvalific = MainForm.PP Then
            Me.СГУровеньКвалификации.Text = "профессиональная переподготовка"
        End If

        Me.Label2.Visible = False
        Me.СтрокаПоиска.Visible = True
        Me.Label1.Visible = True

        If MainForm.cvalific = MainForm.PK Or MainForm.cvalific = MainForm.PP Then
            Str = load_spr_group(Me.СГУровеньКвалификации.Text, ПолеДляСортировки & Интерфейс.sortType(sortSetts.НажатПБГр), Me.yearSpravochnikGr.Text)
        Else
            Str = load_spr_group(Me.СГУровеньКвалификации.Text, ПолеДляСортировки & Интерфейс.sortType(sortSetts.НажатПБГр))
        End If

        massiv = MainForm.mySqlConnect.loadMySqlToArray(Str, 1)

        UpdateListView.updateListView(False, False, Me.ListViewСписокГрупп, Me.massiv, 0, 1, 2, 3, 4, 5)
        Me.СтрокаПоиска.Text = ""

        Try
            Me.ListViewСписокГрупп.Items(0).Selected = True
        Catch ex1 As Exception
            Exit Sub
        End Try

    End Sub
    Sub openFormGroupp()
        If MainForm.cvalific = MainForm.PO Then
            Me.yearSpravochnikGr.Visible = False
        Else
            Me.yearSpravochnikGr.Visible = True
            Me.yearSpravochnikGr.Text = DateAndTime.Year(Date.Now())
        End If
    End Sub

    Private Sub yearSpravochnikGr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles yearSpravochnikGr.SelectedIndexChanged
        updateGroupList()
    End Sub

    Private Sub yearSpravochnikGr_TextChanged(sender As Object, e As EventArgs) Handles yearSpravochnikGr.TextChanged
        updateGroupList()
    End Sub
End Class