Imports System.Threading
Imports System.IO
Public Class СписокСлушателейВГруппе

    Dim SC As SynchronizationContext

    Private Sub Прочее_Click(sender As Object, e As EventArgs) Handles Прочее.Click
        ЗагрузитьРедакторГруппы()
        РедакторГруппы.ShowDialog()
        Очиститьформу(РедакторГруппы)
    End Sub

    Sub ЗагрузитьРедакторГруппы()
        РедакторГруппы.loadFormGruppa()
        ЗаполнитьРедакторГруппы.ЗаполнитьРедакторГруппы(СправочникГруппы.numberGr)
    End Sub

    Private Sub СписокСлушателейВГруппе_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SC = SynchronizationContext.Current
        Dim ВторойПоток As Thread
        Dim argument
        ReDim argument(2)
        argument(0) = СправочникГруппы.kod
        argument(1) = ААОсновная.mySqlConnect.mySqlSettings

        ВторойПоток = New Thread(AddressOf СписокСлушВГруппе)
        ВторойПоток.IsBackground = True
        ВторойПоток.Start(argument)

        ActiveControl = ListViewСписокСлушателей

        Try
            ListViewСписокСлушателей.Items(0).Selected = True
        Catch ex1 As Exception
            ActiveControl = ДобавитьВГруппу
            Exit Sub
        End Try

    End Sub

    Sub СписокСлушВГруппе(argument)

        Dim СписокСлушателей
        Dim Параметр
        Dim queryStr As String
        Dim mySqlConn As New MySQLConnect

        mySqlConn.mySqlSettings = argument(1)

        queryStr = "SELECT Слушатель.Снилс, Слушатель.Фамилия, Слушатель.Имя, IFNULL(слушатель.Отчество,' '), Слушатель.ДатаРождения FROM group_list INNER JOIN Слушатель ON group_list.Слушатель = Слушатель.Снилс WHERE group_list.Kod = " & argument(0) & " ORDER BY Слушатель.Фамилия"

        СписокСлушателей = mySqlConn.ЗагрузитьИзБДMySQLвМассив(queryStr, 1)

        If СписокСлушателей(0, 0) = "Нет записей" Then
            Exit Sub
        End If
        СписокСлушателей = УбратьПустотыВМассиве.УбратьПустотыВМассиве(СписокСлушателей)

        ReDim Параметр(7)
        Параметр(0) = Me
        Параметр(1) = ListViewСписокСлушателей
        Параметр(2) = ДобавитьРубашку.ДобавитьРубашкуВМассив(СписокСлушателей, 0)
        Параметр(3) = 0
        Параметр(4) = 1
        Параметр(5) = 2
        Параметр(6) = 3
        Параметр(7) = 4

        queryStr = "SELECT Слушатель.Снилс, Слушатель.Фамилия, Слушатель.Имя, IFNULL(слушатель.Отчество,' '), Слушатель.ДатаРождения FROM group_list INNER JOIN Слушатель ON group_list.Слушатель = Слушатель.Снилс WHERE group_list.Kod = " & argument(0) & " ORDER BY Слушатель.Фамилия"

        СписокСлушателей = mySqlConn.ЗагрузитьИзБДMySQLвМассив(queryStr, 1)

        If СписокСлушателей(0, 0) = "Нет записей" Then
            Exit Sub
        End If

        SC.Send(AddressOf ЗаписьВListView.ЗаписьВListView2Поток, Параметр)

    End Sub

    Private Sub ДобавитьВГруппу_Click(sender As Object, e As EventArgs) Handles ДобавитьВГруппу.Click
        ФормаСправочникСлушатели.ПоказатьСправочникСлушатели()
        ФормаСправочникСлушатели.ДобавитьВГруппу.Visible = True
        ФормаСправочникСлушатели.ShowDialog()
    End Sub

    Private Sub ListViewСписокСлушателей_KeyDown(sender As Object, e As KeyEventArgs) Handles ListViewСписокСлушателей.KeyDown

        If e.KeyCode = 46 Then

            ФормаДаНетУдалить.текстДаНет.Text = "Вы хотите удалить слушателя " + ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(2).Text + " из группы?"

            ФормаДаНетУдалить.ShowDialog()

            ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

            If Not ФормаДаНетУдалить.НажатаКнопкаДа Then

                Return

            End If

            Dim kod As Integer = СправочникГруппы.kod
            Dim Снилс As String
            Try
                Снилс = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text
            Catch ex As Exception
                MsgBox("Слушатель не выбран")
            End Try
            Снилс = УдалитьРубашку(Снилс)
            If ЗаписьВБазу.ПроверкаСовпаденийЧислоДА_2("group_list", "Kod", СправочникГруппы.kod, "Слушатель", Снилс) = 2 Then
                ЗаписьВБазу.УдалитьЗаписиСЧислом("group_list", "Kod", СправочникГруппы.kod, "Слушатель", Снилс)
                ЗаполнитьФормуССлушВГруппе.ЗаполнитьФормуССлушВГруппе(СправочникГруппы.kod)
            End If



        End If


    End Sub


    Private Sub ListViewСписокСлушателей_DoubleClick(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.DoubleClick

        Dim СтрокаЗапроса As String
        Dim Снилс As String

        Try

            If Not ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text = "удалено" Then

                Снилс = ДобавитьРубашку.УдалитьРубашку(ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(1).Text)

                РедакторСлушателя.Text = ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(2).Text & " " & ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(3).Text & " " & ListViewСписокСлушателей.SelectedItems.Item(0).SubItems(4).Text & " "

                СтрокаЗапроса = load_slushatel(Снилс)

                ФормаСправочникСлушатели.ИнформацияОСлушателе = УбратьПустотыВМассиве.УбратьПустотыВМассиве(ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1))

                '                РедакторСлушателя.prevFormSpisSlushVGr = True

                РедакторСлушателя.ShowDialog()

                СписокСлушателейВГруппе_Shown(sender, e)

            Else MsgBox("информация удалена")

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListViewСписокСлушателей_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewСписокСлушателей.SelectedIndexChanged

    End Sub

    Private Sub ДобавитьВгруппуНового_Click(sender As Object, e As EventArgs) Handles ДобавитьВгруппуНового.Click
        НовыйСлушатель.ВызваноСФормыСписокСлушателей = True
        НовыйСлушатель.ShowDialog()
    End Sub

    Private Sub ДобавитьВГруппу_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ДобавитьВГруппу.PreviewKeyDown
        функционалТаб(e.KeyCode, 39)
    End Sub

    Private Sub ДобавитьВгруппуНового_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ДобавитьВгруппуНового.PreviewKeyDown
        функционалТаб(e.KeyCode, 39)
    End Sub

    Private Sub Прочее_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Прочее.PreviewKeyDown
        функционалТаб(e.KeyCode, 39)
    End Sub

    Private Sub ListViewСписокСлушателей_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ListViewСписокСлушателей.PreviewKeyDown
        функционалТаб(e.KeyCode, 39)
    End Sub

    Private Sub SplitContainer1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles SplitContainer1.PreviewKeyDown
        функционалТаб(e.KeyCode, 39)
    End Sub

    Private Sub SplitContainer2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles SplitContainer2.PreviewKeyDown
        функционалТаб(e.KeyCode, 39)
    End Sub

    Private Sub SplitContainer3_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles SplitContainer3.PreviewKeyDown
        функционалТаб(e.KeyCode, 39)
    End Sub

    Private Sub СписокСлушателейВГруппе_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ЗакрытьEsc(Me, e.KeyCode)
    End Sub
End Class