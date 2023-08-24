Imports MySql.Data.MySqlClient.X.XDevAPI.Common
Imports Mysqlx.XDevAPI.Common

Public Class ОценочнаяВедомость

    Public kodGroup As Integer
    Private Sub loadTables()

        Dim list
        Dim queryString As String
        Dim counter As Integer = 0, counterRows As Integer
        Dim result As List(Of String)

        ТаблицаВедомость.Rows.Clear()

        queryString = loadVedomost(kodGroup)

        list = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        If list(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            ОткрытьФорму(предупреждение)
            ActiveControl = ТаблицаВедомость
            Exit Sub

        End If

        queryString = select_moduls_count(kodGroup)

        result = MainForm.mySqlConnect.LoadToListString(queryString, 1, 0)

        If Not (IsNumeric(result(0)) Or result(0) = "0") Then

            предупреждение.текст.Text = "Нет данных для отображения"
            ОткрытьФорму(предупреждение)
            ActiveControl = ТаблицаВедомость
            Return

        End If

        updateDataGreed(Convert.ToInt16(result(0)))

        list = УбратьПустотыВМассиве.УбратьПустотыВМассиве(list)

        АДействияСОВедомостью.ЗаписатьСписокСлушателей(list)

        counterRows = UBound(list, 2)

        ТаблицаВедомость.Rows.Add(UBound(list, 2) + 1)


        While counter <= UBound(list, 2)

            ТаблицаВедомость.Rows(counter).Cells(0).Value = CStr(counter + 1)
            ТаблицаВедомость.Rows(counter).Cells(1).Value = CStr(list(0, counter))

            ТаблицаВедомость.Rows(counter).Cells(2).Value = CStr(list(1, counter))
            ТаблицаВедомость.Rows(counter).Cells(3).Value = CStr(list(2, counter))
            ТаблицаВедомость.Rows(counter).Cells(4).Value = CStr(list(3, counter))
            ТаблицаВедомость.Rows(counter).Cells(5).Value = CStr(list(4, counter))
            ТаблицаВедомость.Rows(counter).Cells(6).Value = CStr(list(5, counter))
            ТаблицаВедомость.Rows(counter).Cells(7).Value = CStr(list(6, counter))
            ТаблицаВедомость.Rows(counter).Cells(8).Value = CStr(list(7, counter))
            ТаблицаВедомость.Rows(counter).Cells(9).Value = CStr(list(8, counter))
            ТаблицаВедомость.Rows(counter).Cells(10).Value = CStr(list(9, counter))
            ТаблицаВедомость.Rows(counter).Cells(11).Value = CStr(list(10, counter))
            counter = counter + 1

        End While

        ActiveControl = ТаблицаВедомость

    End Sub

    Private Sub Группа_Click(sender As Object, e As EventArgs) Handles НомерГруппы.Click

        ФормаСписок.ListViewСписок.Columns(0).Width = 120
        ФормаСписок.ListViewСписок.Columns.Add("Год", 100)
        ФормаСписок.ListViewСписок.Columns.Add("Код", 100)
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name

        ФормаСписок.headerVisible = True

        ФормаСписок.ShowDialog()
        ФормаСписок.ListViewСписок.Columns.RemoveAt(1)
        ФормаСписок.ListViewСписок.Columns.RemoveAt(2)
        ФормаСписок.ListViewСписок.Columns(1).Width = 50
        ФормаСписок.ListViewСписок.Columns(1).Width = 620
        ФормаСписок.ListViewСписок.Columns(1).Text = "Наименование"

        loadTables()

    End Sub

    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        ActiveControl = Button2

        If АДействияСОВедомостью.проверка(ТаблицаВедомость) Then

            Exit Sub

        End If

        АДействияСОВедомостью.СохранитьОценки(ТаблицаВедомость, kodGroup)

    End Sub

    Private Sub Сохранить_GotFocus(sender As Object, e As EventArgs) Handles Сохранить.GotFocus
        Call Интерфейс.ШрифтКонтрола(Сохранить, 14.0F)
    End Sub

    Private Sub Сохранить_LostFocus(sender As Object, e As EventArgs) Handles Сохранить.LostFocus
        Интерфейс.ШрифтКонтрола(Сохранить, 11.0F)
    End Sub

    Private Sub Button2_GotFocus(sender As Object, e As EventArgs) Handles Button2.GotFocus
        Call Интерфейс.ШрифтКонтрола(Button2, 14.0F)
    End Sub

    Private Sub Button2_LostFocus(sender As Object, e As EventArgs) Handles Button2.LostFocus
        Интерфейс.ШрифтКонтрола(Button2, 11.0F)
    End Sub

    Private Sub ОценочнаяВедомость_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Call pressTab(e.KeyCode, 40)
        Call pressTab(e.KeyCode, 39)
        Call closeEsc(Me, e.KeyCode)
    End Sub

    Private Sub Группа_KeyDown(sender As Object, e As KeyEventArgs) Handles НомерГруппы.KeyDown

        If e.KeyCode = 13 Then

            Call Группа_Click(sender, e)

        End If

    End Sub

    Sub updateDataGreed(numberColumns As Integer)


        For number As Int16 = 2 To 11

            If number <= numberColumns + 1 Then
                ТаблицаВедомость.Columns(number).ReadOnly = False
                ТаблицаВедомость.Columns(number).DefaultCellStyle.BackColor = Color.White
            Else
                ТаблицаВедомость.Columns(number).ReadOnly = True
                ТаблицаВедомость.Columns(number).DefaultCellStyle.BackColor = Color.Gray
            End If

        Next

    End Sub

End Class