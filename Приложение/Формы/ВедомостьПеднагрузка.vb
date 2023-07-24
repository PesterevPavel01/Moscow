Public Class ВедомостьПеднагрузка

    Public kodGroup As Integer

    Private Sub НомерГруппы_Click(sender As Object, e As EventArgs) Handles НомерГруппы.Click

        ФормаСписок.ListViewСписок.Columns(0).Width = 120
        ФормаСписок.ListViewСписок.Columns.Add("Год", 100)
        ФормаСписок.ListViewСписок.Columns.Add("Код", 100)
        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()
        ФормаСписок.ListViewСписок.Columns.RemoveAt(1)
        ФормаСписок.ListViewСписок.Columns.RemoveAt(2)
        ФормаСписок.ListViewСписок.Columns(1).Width = 50
        ФормаСписок.ListViewСписок.Columns(1).Width = 620
        ФормаСписок.ListViewСписок.Columns(1).Text = "Наименование"



        loadTables()

    End Sub

    Private Sub loadTables()
        Dim СтрокаЗапроса As String
        Dim Список
        If Trim(НомерГруппы.Text) = "" Then
            Exit Sub
        End If
        ТаблицаВедомость.Rows.Clear()

        СтрокаЗапроса = pednagruzkaload(Convert.ToString(kodGroup))

        Список = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Список(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Нет данных для отображения"
            ОткрытьФорму(предупреждение)
            ActiveControl = ТаблицаВедомость
            Exit Sub

        End If

        ДействияСДатаГрид.ЗаписьМассиваВДатаГрид(ТаблицаВедомость, Список)

    End Sub

    Private Sub ТаблицаВедомость_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles ТаблицаВедомость.CellValueChanged
        Dim Значение As Double


        If IsNothing(ТаблицаВедомость.Rows(0).Cells(0).Value) Or Trim(ТаблицаВедомость.Rows(0).Cells(0).Value) = "" Then
            Exit Sub
        End If

        ИтогоЛекции.Text = СуммаЗначенийВСтолбце(ТаблицаВедомость, 1)
        ИтогоПрактические.Text = СуммаЗначенийВСтолбце(ТаблицаВедомость, 2)
        ИтогоСтимулирующие.Text = СуммаЗначенийВСтолбце(ТаблицаВедомость, 3)
        ИтогоКонсультация.Text = СуммаЗначенийВСтолбце(ТаблицаВедомость, 4)
        ИтогоИА.Text = СуммаЗначенийВСтолбце(ТаблицаВедомость, 6)
        ИтогоПА.Text = СуммаЗначенийВСтолбце(ТаблицаВедомость, 5)
        ИтогоИтого.Text = СуммаЗначенийВСтолбце(ТаблицаВедомость, 7)
        Dim count As Integer
        Dim счетчикСтрок As Integer = 0
        For Each строка In ТаблицаВедомость.Rows

            If IsNothing(строка.Cells(0).Value) Or Trim(ТаблицаВедомость.Rows(0).Cells(0).Value) = "" Then
                счетчикСтрок += 1
                Continue For
            End If

            count = ТаблицаВедомость.Columns.Count
            Значение = СуммаЗначенийВСтроке(ТаблицаВедомость, счетчикСтрок, 1, ТаблицаВедомость.Columns.Count - 2)

            If Значение = -1 Then
                счетчикСтрок += 1
                Continue For
            End If

            строка.Cells(ТаблицаВедомость.Columns.Count - 1).Value = Значение
            счетчикСтрок += 1

        Next

    End Sub

    Private Sub Сохранить_Click(sender As Object, e As EventArgs) Handles Сохранить.Click

        Dim arg, arrayNameAndType
        ReDim arg(1)
        ReDim arrayNameAndType(1, 6)
        arg(0) = "Kod"
        arg(1) = kodGroup

        arrayNameAndType(0, 0) = "worker"
        arrayNameAndType(1, 0) = "String"

        arrayNameAndType(0, 1) = "lectures"
        arrayNameAndType(1, 1) = "Double"
        arrayNameAndType(0, 2) = "practical"
        arrayNameAndType(1, 2) = "Double"
        arrayNameAndType(0, 3) = "stimulating"
        arrayNameAndType(1, 3) = "Double"
        arrayNameAndType(0, 4) = "consultation"
        arrayNameAndType(1, 4) = "Double"
        arrayNameAndType(0, 5) = "PA"
        arrayNameAndType(1, 5) = "Double"
        arrayNameAndType(0, 6) = "IA"
        arrayNameAndType(1, 6) = "Double"

        datagridInsertRowIntoDB(ТаблицаВедомость, "pednagruzka", arg, arrayNameAndType, 0, 6)

    End Sub

    Private Sub ВедомостьПеднагрузка_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ЗакрытьEsc(Me, e.KeyCode)
    End Sub

End Class