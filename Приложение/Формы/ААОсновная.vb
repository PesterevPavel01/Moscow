﻿Imports System.ComponentModel
Imports System.Reflection.Emit
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports Google.Protobuf.WellKnownTypes
Imports Org.BouncyCastle.Asn1.X509
Imports System.Text.RegularExpressions
Imports System.Data.SqlTypes
Imports System.Xml

Public Class ААОсновная

    Private redactor_enter As Boolean
    Public password0 As String
    Public Запросы
    Public КлавишаПереключенияВкладок As Integer = 39 ' 34
    Public КлавишаОбратногоПереключенияВкладок As Integer = 37 '35
    Public вместоТаб As Integer = 40
    Public вместоТаб2 As Integer = 39
    Public НомерОтчета As Integer
    Public ЗагруженСправочникГруппы As Boolean = False
    Public РазрешитьЗапускПриложения As Boolean = True
    Public отключитьДиректора As Boolean = False
    Public Стаж_окончание As Boolean = False
    Public mySqlConnect As New MySQLConnect
    Public prikazKodGroup As Integer = 0
    Public activeTables As String = "Не загружено"
    Public settsStatus As Boolean = True
    Public cvalific As UInt16 = 0
    Public Const PK = 1
    Public Const PP = 2
    Public Const PO = 3
    Public Const PK_PP_PO = 0
    Public Const PK_PP = 4
    Public prikazCvalif As UInt16 = 0
    Private programm As New Programm
    Private worker As New Worker
    Private flag_ToolStrip_name_list As Boolean
    Private flag_worker_dolgnost As Boolean
    Private flag_worker_type As Boolean
    Public tbl_obrazovanie As New Tables_control
    Public programms_tbl As New Tables_control
    Public sqlQueryString As New SqlQueryString

    Private Sub Основная_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ЗаписьВListView.массивПуст = False
        mySqlConnect.mySqlSettings.ИмяБазыДанныхА = "database"
        mySqlConnect.mySqlSettings.ИмяПользователя = "admin"
        mySqlConnect.mySqlSettings.пароль = "admin"
        mySqlConnect.mySqlSettings.ИсточникДанныхODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlConnect.mySqlSettings.НазваниеСервера = "localhost"
        progsIndicator.Image = ImageList1.Images(8)
        modulInProgsIndicator.Image = ImageList1.Images(8)
        modulIndicator.Image = ImageList1.Images(8)
        panel_worker.Parent = SplitContainerOtherList.Panel2

        DataGridView_list.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft YaHei", 12)
        DataGridView_list.DefaultCellStyle.Font = New Font("Microsoft YaHei", 12)

        DataGridAllModuls.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft YaHei", 12)
        DataGridAllModuls.DefaultCellStyle.Font = New Font("Microsoft YaHei", 12)

        dataGridModuls.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft YaHei", 12)
        dataGridModuls.DefaultCellStyle.Font = New Font("Microsoft YaHei", 12)

    End Sub

    Public Sub prog_DataGridTablesResult_activate()

        ActiveControl = programms_tbl.DataGridTablesResult

    End Sub

    Public Sub prog_redactor_element_first_activate()

        ActiveControl = programms_tbl.redactor_element_first
        select_textBox(programms_tbl.redactor_element_first)

    End Sub

    Private Sub select_textBox(control As Control)

        If control.GetType.ToString = "System.Windows.Forms.TextBox" Then

            Dim lenght As Integer = control.Text.Length
            Dim s_control As TextBox = control
            s_control.Select(lenght, 0)

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        ActiveControl = Button2
        ФормаСправочникСлушатели.ДобавитьВГруппу.Visible = False
        ФормаСправочникСлушатели.ShowDialog()

    End Sub

    Private Sub ОткрытьСправочникГруппы_Click(sender As Object, e As EventArgs) Handles СправочникГруппыПК.Click

        cvalific = PK
        ActiveControl = Button2
        СправочникГруппы.ShowDialog()

    End Sub

    Private Sub СправочникГруппыПП_Click(sender As Object, e As EventArgs) Handles СправочникГруппыПП.Click

        cvalific = PP
        ActiveControl = Button2
        СправочникГруппы.ShowDialog()

    End Sub

    Private Sub СправочникГруппыПО_Click(sender As Object, e As EventArgs) Handles СправочникГруппыПО.Click

        cvalific = PO
        ActiveControl = Button2
        СправочникГруппы.ShowDialog()

    End Sub

    Private Sub ИтоговаяАттествцияОценки_Click(sender As Object, e As EventArgs) Handles ИтоговаяАттествцияОценки.Click

        ActiveControl = Button2
        АОценкиИА.НомерГруппы.Clear()
        АОценкиИА.ТаблицаОценкиИА.Rows.Clear()
        АОценкиИА.ShowDialog()

    End Sub

    Private Sub Ведомость_Click(sender As Object, e As EventArgs) Handles Ведомость.Click

        ActiveControl = Button2
        ОценочнаяВедомость.НомерГруппы.Clear()
        ОценочнаяВедомость.ТаблицаВедомость.Rows.Clear()
        ОценочнаяВедомость.ShowDialog()

    End Sub

    Private Sub ДобавитьСлушателя_Click(sender As Object, e As EventArgs)

        ActiveControl = Button2
        НовыйСлушатель.ShowDialog()

    End Sub

    Private Sub КнопкаСоздатьГруппу_Click(sender As Object, e As EventArgs) Handles КнопкаСоздатьГруппу.Click

        ActiveControl = Button2
        НоваяГруппа.ShowDialog()

    End Sub

    Private Sub СправочникСлушатели_Click(sender As Object, e As EventArgs) Handles СправочникСлушатели.Click

        If ПоискСлушателейПоУм.Text = "" Then
            НастройкаПоискаСлушателей.Снилс.Checked = True
        End If

        ActiveControl = Button2
        ФормаСправочникСлушатели.ДобавитьВГруппу.Visible = False
        ФормаСправочникСлушатели.ПоказатьСправочникСлушатели()
        ФормаСправочникСлушатели.ShowDialog()

    End Sub

    Private Sub ДобавитьСлушателя_Click_1(sender As Object, e As EventArgs) Handles ДобавитьСлушателя.Click

        ActiveControl = Button2
        НовыйСлушатель.ShowDialog()

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim excellApp As Object
        Dim excellWorkBook As Object
        Dim excellSheet As Object
        Dim excellObjects
        ReDim excellObjects(1)
        Dim groupsArray
        Dim list
        Dim studentList
        Dim resultList
        Dim otchetList
        Dim listData As List(Of List(Of String))
        Dim hours
        Dim counter, counter2, counter3, СчетчикПр As Integer
        Dim queryString, DateStart, DateEnd, path As String

        ActiveControl = Button2

        DateStart = mySqlConnect.dateToFormatMySQL(ДатаНачалаОтчета.Value.ToShortDateString)
        DateEnd = mySqlConnect.dateToFormatMySQL(ДатаКонцаОтчета.Value.ToShortDateString)

        queryString = selectCol_otchet_info(DateStart, DateEnd)
        groupsArray = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        queryString = selectCol_chas()
        hours = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)


        queryString = SQLString_OtchetMassSlush(DateStart, DateEnd)
        list = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        '------------------------------------------------------------------------------------------------------

        If list(0, 0).ToString = "нет записей" Then
            MsgBox("Не найденно групп с зарегистрированными слушателями")
            Exit Sub
        End If
        queryString = SQLString_OtchetMassDataSlush(DateStart, DateEnd)

        studentList = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        counter = 0

        ReDim resultList(50, UBound(list, 2))

        While counter <= UBound(resultList, 2)

            resultList(0, counter) = list(1, counter)
            resultList(1, counter) = list(2, counter)

            counter2 = 0
            СчетчикПр = UBound(studentList, 2)
            While counter2 <= UBound(studentList, 2)

                If resultList(0, counter) = studentList(1, counter2) Then

                    counter3 = 2
                    While counter3 <= UBound(studentList, 1)

                        resultList(counter3, counter) = studentList(counter3, counter2)
                        counter3 = counter3 + 1

                    End While

                End If

                counter2 = counter2 + 1
            End While

            counter = counter + 1

        End While

        counter = 0
        While counter <= UBound(resultList, 2)

            counter2 = 0
            СчетчикПр = UBound(groupsArray, 2)
            While counter2 <= UBound(groupsArray, 2)

                If resultList(1, counter) = groupsArray(1, counter2) Then

                    counter3 = 2
                    While counter3 <= UBound(groupsArray, 1)

                        resultList(counter3 + 25, counter) = groupsArray(counter3, counter2)
                        counter3 = counter3 + 1

                    End While

                End If


                counter2 = counter2 + 1
            End While

            counter = counter + 1

        End While

        resultList = УбратьПустотыВМассиве.УбратьПустотыВМассиве(resultList)

        Name = "Отчет" & Date.Now.ToShortDateString & "_" & НомерОтчета.ToString & ".xlsx"
        path = Вспомогательный.ПутьККаталогуСРесурсами
        path = path & "Отчеты\"

        excellObjects = Вспомогательный.СозданиеКнигиЭксельИЛИОшибкаВ0(path, Name, НомерОтчета)

        If excellObjects(0).ToString = "Ошибка" Then
            Exit Sub
        End If
        excellApp = excellObjects(0)
        excellWorkBook = excellObjects(1)
        'ПриложениеЭксель.Visible = True

ПослеСохранения:

        НомерОтчета = НомерОтчета + 1

        If ОтчетРуководителя.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "ОтчетРуководителя"
            queryString = WindowsApp2.SQLString_OtchetRuk(DateStart, DateEnd)
            listData = mySqlConnect.ЗагрузитьИзMySQLвListAll(queryString, 1)

            If Not listData.Count = 0 Then
                ЗаписьИнформацииДляОтчетаExcell.СозданиеОтчетаРуководителя(excellSheet, listData, resultList, groupsArray)
            Else
                предупреждение.текст.Text = "Нет информации отвечающей условиям отбора для отчета руководителя"
                предупреждение.ShowDialog()
            End If

        End If

        If ChРМАНПО.Checked Then
            queryString = WindowsApp2.SQLString_OtchetRMANPO(DateStart, DateEnd)
            listData = mySqlConnect.ЗагрузитьИзMySQLвListAll(queryString, 1)

            If Not listData.Count = 0 Then
                ЗаписьИнформацииДляОтчетаExcell.CreateRMANPO(excellApp, excellWorkBook, listData, resultList, groupsArray, MonthName(ДатаКонцаОтчета.Value.Month))
            Else
                предупреждение.текст.Text = "Нет информации отвечающей условиям отбора для отчета руководителя"
                предупреждение.ShowDialog()
            End If
        End If

        If ChСводПоКурсам.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "СводПоКурсам"
            queryString = WindowsApp2.SQLString_OtchetKurs(DateStart, DateEnd, "курс")
            otchetList = mySqlConnect.ЗагрузитьИзБДMySQLвМассив(queryString, 1)

            If Not otchetList(0, 0).ToString = "нет записей" Then
                ЗаписьИнформацииДляОтчетаExcell.СозданиеСводаПоКурсамСпециальностям(excellSheet, перевернутьмассив(otchetList), "СводПоКурсам")
            Else
                предупреждение.текст.Text = "Нет информации отвечающей условиям отбора для отчета Свод по курсам"
                предупреждение.ShowDialog()
            End If
        End If

        If СводПоСпец.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "СводПоСпециальностям"
            queryString = WindowsApp2.SQLString_OtchetKurs(DateStart, DateEnd, "специальность")
            otchetList = mySqlConnect.ЗагрузитьИзБДMySQLвМассив(queryString, 1)

            If Not otchetList.ToString = "нет записей" Then
                ЗаписьИнформацииДляОтчетаExcell.СозданиеСводаПоКурсамСпециальностям(excellSheet, перевернутьмассив(otchetList), "СводПоСпециальностям")
            Else
                предупреждение.текст.Text = "Нет информации отвечающей условиям отбора для отчета Свод по специальностям"
                предупреждение.ShowDialog()
            End If
        End If

        If СводПоОрганиз.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "ПереченьОрганизаций"
            queryString = SQLString_OtchetOrg(DateStart, DateEnd)
            otchetList = mySqlConnect.ЗагрузитьИзБДMySQLвМассив(queryString, 1)

            If Not otchetList.ToString = "нет записей" Then
                ЗаписьИнформацииДляОтчетаExcell.СозданиеСводаПоОрганизациям(excellSheet, otchetList)
            Else
                предупреждение.текст.Text = "Нет информации отвечающей условиям отбора для отчета Свод по организациям"
                предупреждение.ShowDialog()
            End If
        End If

        If БюджетВбюдж.Checked Then
            excellSheet = excellWorkBook.Worksheets.Add
            excellSheet.Name = "БюджетВнебюджет"

            ReDim otchetList(2)
            queryString = SQLString_OtchetBud_Vbud(DateStart, DateEnd, "полный")
            listData = mySqlConnect.ЗагрузитьИзMySQLвListAll(queryString, 1)
            otchetList(0) = listData

            queryString = SQLString_OtchetBud_Vbud(DateStart, DateEnd, "бюджет")
            otchetList(1) = mySqlConnect.ЗагрузитьИзMySQLвListAll(queryString, 1)

            queryString = SQLString_OtchetBud_Vbud(DateStart, DateEnd, "внебюджет")
            otchetList(2) = mySqlConnect.ЗагрузитьИзMySQLвListAll(queryString, 1)

            If Not listData.Count = 0 Then
                ЗаписьИнформацииДляОтчетаExcell.СозданиеОтчетаБюджетВнебюджет(excellSheet, otchetList, hours)
            Else
                предупреждение.текст.Text = "Нет информации отвечающей условиям отбора для отчета Бюджет/Внебюджет"
                предупреждение.ShowDialog()
            End If
        End If

        If ОтчетПеднагрузка.Checked Then
            ПеднагрузкаОтчет.Педнагрузка("Педнагрузка", excellApp, excellWorkBook, DateStart, DateEnd)
        End If

        Try
            excellWorkBook.Save
        Catch ex As Exception
            Exit Sub
        End Try

        excellApp.DisplayAlerts = True
        excellApp.Visible = True

    End Sub

    Sub waitResponse(n As Integer)

        Dim counter As Integer
Повтор:
        counter = 0
        Thread.Sleep(50)
        counter = counter + 1
        If counter < n Then
            GoTo Повтор
        Else
            Exit Sub
        End If

    End Sub

    Private Sub ПриказОЗачислении_Доп_Click(sender As Object, e As EventArgs) Handles ПриказОЗачислении_Доп.Click

        prikazCvalif = PK
        АСформироватьПриказ.Text = "ПК_Зачисление_Доп"
        АСформироватьПриказ.ВидПриказа = "ПК_Зачисление_Доп"

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 320)

        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count > 1
            АСформироватьПриказ.ListViewСписокСлушателей.Columns.RemoveAt(1)
        End While

        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 805
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "ФИО"

        ОтветственныйЗаАттестацию(False)

        чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 1000)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 915)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 915)
        ДиректорДолжность.Visible = True
        ActiveControl = Button2

        'местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        'showPoleVvoda(True, 70, 30)

        АСформироватьПриказ.ShowDialog()

        'Чтобы вернуть на место, т.к. сбивается форма на справке о обучении
        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False
        showPoleVvoda(False)

    End Sub

    Private Sub standard_location(Optional arg As Integer = 0)

        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)

        If arg = 1 Then
            Return
        End If

        местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(6, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

    End Sub

    Private Sub ПриказОЗачислении_Click(sender As Object, e As EventArgs) Handles ПриказОЗачислении.Click

        prikazCvalif = PK
        АСформироватьПриказ.Text = "ПК_Зачисление"
        АСформироватьПриказ.ВидПриказа = "ПК_Зачисление"

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 350)

        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count > 1
            АСформироватьПриказ.ListViewСписокСлушателей.Columns.RemoveAt(1)
        End While

        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 805
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "ФИО"

        ОтветственныйЗаАттестацию(True)

        чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 1020)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 935)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 935)
        ДиректорДолжность.Visible = True
        ActiveControl = Button2

        standard_location()

        АСформироватьПриказ.ShowDialog()

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False

    End Sub

    Private Sub ППЗачисление_Click(sender As Object, e As EventArgs) Handles ППЗачисление.Click
        prikazCvalif = PP
        АСформироватьПриказ.Text = "ПП_Зачисление"
        АСформироватьПриказ.ВидПриказа = "ПП_Зачисление"

        ОтветственныйЗаАттестацию(False)
        чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 590)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 505)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 505)

        ActiveControl = Button2

        'Call местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

    End Sub

    Private Sub ПО_Зачисление_Click(sender As Object, e As EventArgs) Handles ПО_Зачисление.Click
        prikazCvalif = PO
        АСформироватьПриказ.Text = "ПО_Зачисление"
        АСформироватьПриказ.ВидПриказа = "ПО_Зачисление"

        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(True, "иной приносящей доход деятельности", "федерального бюджета", "за счет средств")
        Call ПроектВносит(True)
        Call Исполнитель(True)
        Call Согласовано1(True)
        Call Согласовано2(True)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)

        ActiveControl = Button2

        'Call местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        Call местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        Call местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        Call местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        Call местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        Call местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

    End Sub

    Private Sub ПП_Практика_Click(sender As Object, e As EventArgs) Handles ПП_Практика.Click
        prikazCvalif = PP
        АСформироватьПриказ.Text = "ПП_Практика"
        АСформироватьПриказ.ВидПриказа = "ПП_Практика"

        Call ОтветственныйЗаАттестацию(True, "Руководитель ПП")
        Call чекбоксы(False, "", "", "")
        Call ПроектВносит(True)
        Call Исполнитель(True)
        Call Согласовано1(True)
        Call Согласовано2(True)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)

        ActiveControl = Button2

        Call местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        Call местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        Call местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        Call местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        Call местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        Call местоНаФормеПослеДиректора(6, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

    End Sub

    Private Sub ПО_Практика_Click(sender As Object, e As EventArgs) Handles ПО_Практика.Click
        prikazCvalif = PO
        АСформироватьПриказ.Text = "ПО_Практика"
        АСформироватьПриказ.ВидПриказа = "ПО_Практика"

        ОтветственныйЗаАттестацию(True, "Руководитель ПО")
        АСформироватьПриказ.praktika = True

        чекбоксы(False, "", "", "")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)

        ActiveControl = Button2

        местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(6, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

        АСформироватьПриказ.praktika = False

    End Sub

    Private Sub ПК_Отчисление_Click(sender As Object, e As EventArgs) Handles ПК_Отчисление.Click
        prikazCvalif = PK
        АСформироватьПриказ.Text = "ПК_Отчисление"
        АСформироватьПриказ.ВидПриказа = "ПК_Отчисление"

        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "", "", "")
        Call ПроектВносит(True)
        Call Исполнитель(True)
        Call Согласовано1(True)
        Call Согласовано2(True)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Label4.Text = "Слушатель(ФИО)"
        АСформироватьПриказ.GroupBox5.Visible = True

        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)

        ActiveControl = Button2

        Call местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        Call местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        Call местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        Call местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        Call местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        Call местоНаФормеПослеДиректора(6, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

    End Sub

    Private Sub ПО_ДопускКИА_Click(sender As Object, e As EventArgs) Handles ПО_ДопускКИА.Click

        prikazCvalif = PO
        АСформироватьПриказ.Text = "ПО_Допуск к ИА"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        ОтветственныйЗаАттестацию(True, "Председатель комиссии")
        чекбоксы(True, "ММС", "санитар", "должность слушателей")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(True, "Комиссия 1")
        Комиссия2(True)
        Комиссия3(True)
        СекретарьКомиссии(True)
        ЗаместительРПК(False)

        АСформироватьПриказ.komissiya = True

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 883)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 800)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 800)

        ActiveControl = Button2

        местоНаФорме(1, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(2, АСформироватьПриказ.LabelРуководительСтажировки, АСформироватьПриказ.Label16, АСформироватьПриказ.РуководительСтажировки, АСформироватьПриказ.РуководительСтажировкиДолжность, АСформироватьПриказ.GroupBox7)
        местоНаФорме(3, АСформироватьПриказ.label20, АСформироватьПриказ.Label17, АСформироватьПриказ.Комиссия2, АСформироватьПриказ.Комиссия2Должность, АСформироватьПриказ.GroupBox8)
        местоНаФорме(4, АСформироватьПриказ.Label18, АСформироватьПриказ.Label19, АСформироватьПриказ.Комиссия3, АСформироватьПриказ.Комиссия3Должность, АСформироватьПриказ.GroupBox9)
        местоНаФорме(5, АСформироватьПриказ.Label15, АСформироватьПриказ.Label21, АСформироватьПриказ.СекретарьКомиссии, АСформироватьПриказ.СекретарьКомиссииДолжность, АСформироватьПриказ.GroupBox10)
        местоНаФорме(6, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(7, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(8, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(9, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(10, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

        АСформироватьПриказ.komissiya = False

    End Sub

    Private Sub ПП_ДопускКИА_Click(sender As Object, e As EventArgs) Handles ПП_ДопускКИА.Click

        prikazCvalif = PP
        АСформироватьПриказ.Text = "ПП_Допуск к ИА"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.komissiya = True
        ОтветственныйЗаАттестацию(True, "Председатель комиссии")
        чекбоксы(True, "ПП", "стажировка", "Практическая подготовка/стажировка")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(True, "Комиссия №1")
        Комиссия2(True)
        Комиссия3(True)
        СекретарьКомиссии(True)
        ЗаместительРПК(True)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 960)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 877)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 877)

        ActiveControl = Button2

        местоНаФорме(1, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(2, АСформироватьПриказ.Label22, АСформироватьПриказ.Label23, АСформироватьПриказ.ЗамПредседателя, АСформироватьПриказ.ЗамПредседателяДолжность, АСформироватьПриказ.GroupBox12)
        местоНаФорме(3, АСформироватьПриказ.LabelРуководительСтажировки, АСформироватьПриказ.Label16, АСформироватьПриказ.РуководительСтажировки, АСформироватьПриказ.РуководительСтажировкиДолжность, АСформироватьПриказ.GroupBox7)
        местоНаФорме(4, АСформироватьПриказ.label20, АСформироватьПриказ.Label17, АСформироватьПриказ.Комиссия2, АСформироватьПриказ.Комиссия2Должность, АСформироватьПриказ.GroupBox8)
        местоНаФорме(5, АСформироватьПриказ.Label18, АСформироватьПриказ.Label19, АСформироватьПриказ.Комиссия3, АСформироватьПриказ.Комиссия3Должность, АСформироватьПриказ.GroupBox9)
        местоНаФорме(6, АСформироватьПриказ.Label15, АСформироватьПриказ.Label21, АСформироватьПриказ.СекретарьКомиссии, АСформироватьПриказ.СекретарьКомиссииДолжность, АСформироватьПриказ.GroupBox10)
        местоНаФорме(7, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(8, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(9, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(10, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(11, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

        АСформироватьПриказ.komissiya = False

    End Sub

    Private Sub ПК_Заявление_Click(sender As Object, e As EventArgs) Handles ПК_Заявление.Click

        prikazCvalif = PK
        АСформироватьПриказ.Text = "ПК_Заявление"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False


        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "ММС", "санитар", "должность слушателей")
        Call ПроектВносит(False)
        Call Исполнитель(False)
        Call Согласовано1(False)
        Call Согласовано2(False)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        standard_location(1)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)


        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()


    End Sub


    Private Sub ПП_Заявление_Click(sender As Object, e As EventArgs) Handles ПП_Заявление.Click

        prikazCvalif = PP
        АСформироватьПриказ.Text = "ПП_Заявление"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False


        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "ММС", "санитар", "должность слушателей")
        Call ПроектВносит(False)
        Call Исполнитель(False)
        Call Согласовано1(False)
        Call Согласовано2(False)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        standard_location(1)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)


        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()
    End Sub

    Private Sub Карточка_слушателя_Click(sender As Object, e As EventArgs) Handles Карточка_слушателя.Click

        prikazCvalif = PK_PP_PO
        АСформироватьПриказ.Text = "Карточка слушателя"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False


        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "ММС", "санитар", "должность слушателей")
        ПроектВносит(False)
        Исполнитель(False)
        Согласовано1(False)
        Согласовано2(False)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        standard_location(1)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)


        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()
    End Sub


    Private Sub ПК_Окончание_Click(sender As Object, e As EventArgs) Handles ПК_Окончание.Click

        If Стаж_окончание Then
            prikazCvalif = PK
            АСформироватьПриказ.Text = "Стаж_окончание"
        Else
            prikazCvalif = PK
            АСформироватьПриказ.Text = "ПК_Окончание"
        End If

        АСформироватьПриказ.Label2.Visible = True
        АСформироватьПриказ.Label14.Visible = True
        АСформироватьПриказ.ВидПриказа = "ПК_Окончание"

        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "", "", "")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)

        ActiveControl = Button2

        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()


    End Sub


    Sub ОтветственныйЗаАттестацию(Видимость As Boolean, Optional Подпись1текстБ As String = "Ответственный за аттестацию")
        '----------------Ответственный за аттестацию------------
        АСформироватьПриказ.load_form()

        АСформироватьПриказ.GroupBox5.Visible = Видимость
        АСформироватьПриказ.Label4.Visible = Видимость ' ответственный за аттестацию
        АСформироватьПриказ.Label13.Visible = False ' должность

        АСформироватьПриказ.Label4.Text = Подпись1текстБ

        АСформироватьПриказ.Ответственный.Items.Clear()
        АСформироватьПриказ.Ответственный.Items.AddRange(АСформироватьПриказ.prikaz.formPrikazList.otv_attestat)

        АСформироватьПриказ.Ответственный.Visible = Видимость
        АСформироватьПриказ.ОтветственныйДолжность.Visible = False

    End Sub
    Sub чекбоксы(Видимость As Boolean, ИмяПервый As String, ИмяВторой As String, ПодписьКонтейнера As String)

        АСформироватьПриказ.CheckBoxММС.Visible = Видимость
        АСформироватьПриказ.CheckBoxСанитар.Visible = Видимость
        АСформироватьПриказ.GroupBox11.Visible = Видимость
        АСформироватьПриказ.CheckBoxММС.Text = ИмяПервый
        АСформироватьПриказ.CheckBoxСанитар.Text = ИмяВторой
        АСформироватьПриказ.GroupBox11.Text = ПодписьКонтейнера

    End Sub


    Sub Утверждает(Видимость As Boolean)

        АСформироватьПриказ.GroupBox6.Visible = Видимость
        АСформироватьПриказ.Label2.Visible = Видимость
        АСформироватьПриказ.Label14.Visible = False

        АСформироватьПриказ.Утверждает.Visible = Видимость
        АСформироватьПриказ.УтверждаетДолжность.Visible = False

    End Sub

    Sub ПроектВносит(Видимость As Boolean, Optional Название As String = "Без изменений")

        If Название = "Без изменений" Then
        Else
            АСформироватьПриказ.Label5.Text = Название
        End If

        АСформироватьПриказ.GroupBox1.Visible = Видимость
        АСформироватьПриказ.Label5.Visible = Видимость
        АСформироватьПриказ.Label6.Visible = False

        АСформироватьПриказ.ПроектВносит.Visible = Видимость
        АСформироватьПриказ.ПроектВноситДолжность.Visible = False

    End Sub

    Sub Исполнитель(Видимость As Boolean, Optional Название As String = "Без изменений")

        If Название = "Без изменений" Then
        Else
            АСформироватьПриказ.Label7.Text = Название
        End If

        АСформироватьПриказ.GroupBox2.Visible = Видимость
        АСформироватьПриказ.Label7.Visible = Видимость
        АСформироватьПриказ.Label8.Visible = False

        АСформироватьПриказ.Исполнитель.Visible = Видимость
        АСформироватьПриказ.ИсполнительДолжность.Visible = False

    End Sub

    Sub Согласовано1(Видимость As Boolean, Optional Название As String = "Без изменений")

        If Название = "Без изменений" Then
            АСформироватьПриказ.Label9.Text = "Согласовано"
        Else
            АСформироватьПриказ.Label9.Text = Название
        End If
        АСформироватьПриказ.GroupBox3.Visible = Видимость
        АСформироватьПриказ.Label9.Visible = Видимость
        АСформироватьПриказ.Label10.Visible = False

        АСформироватьПриказ.Согласовано1.Visible = Видимость
        АСформироватьПриказ.Согласовано1Должность.Visible = False

    End Sub

    Sub Согласовано2(Видимость As Boolean)

        АСформироватьПриказ.GroupBox4.Visible = Видимость
        АСформироватьПриказ.Label11.Visible = Видимость
        АСформироватьПриказ.Label12.Visible = False

        АСформироватьПриказ.Согласовано2.Visible = Видимость
        АСформироватьПриказ.Согласовано2Должность.Visible = False

    End Sub

    Sub РуководительСтажировки(Видимость As Boolean, Optional ПодписьТекстБ As String = "Руководитель стажировки")

        АСформироватьПриказ.GroupBox7.Visible = Видимость
        АСформироватьПриказ.LabelРуководительСтажировки.Visible = Видимость
        АСформироватьПриказ.Label16.Visible = False

        АСформироватьПриказ.LabelРуководительСтажировки.Text = ПодписьТекстБ

        АСформироватьПриказ.РуководительСтажировки.Visible = Видимость
        АСформироватьПриказ.РуководительСтажировкиДолжность.Visible = False

    End Sub

    Sub Комиссия2(Видимость As Boolean, Optional ПодписьТекстБ As String = "Комиссия 2")

        АСформироватьПриказ.GroupBox8.Visible = Видимость
        АСформироватьПриказ.label20.Visible = Видимость
        АСформироватьПриказ.Label17.Visible = False

        АСформироватьПриказ.label20.Text = ПодписьТекстБ

        АСформироватьПриказ.Комиссия2.Visible = Видимость
        АСформироватьПриказ.Комиссия2Должность.Visible = False

    End Sub

    Sub Комиссия3(Видимость As Boolean, Optional ПодписьТекстБ As String = "Комиссия 3")

        АСформироватьПриказ.GroupBox9.Visible = Видимость
        АСформироватьПриказ.Label18.Visible = Видимость
        АСформироватьПриказ.Label19.Visible = False

        АСформироватьПриказ.Label18.Text = ПодписьТекстБ

        АСформироватьПриказ.Комиссия3.Visible = Видимость
        АСформироватьПриказ.Комиссия3Должность.Visible = False

    End Sub

    Sub СекретарьКомиссии(Видимость As Boolean, Optional ПодписьТекстБ As String = "Секретарь комиссии")

        АСформироватьПриказ.GroupBox10.Visible = Видимость
        АСформироватьПриказ.Label15.Visible = Видимость
        АСформироватьПриказ.Label21.Visible = False

        АСформироватьПриказ.Label15.Text = ПодписьТекстБ

        АСформироватьПриказ.СекретарьКомиссии.Visible = Видимость
        АСформироватьПриказ.СекретарьКомиссииДолжность.Visible = False

    End Sub

    Sub ЗаместительРПК(Видимость As Boolean, Optional ПодписьТекстБ As String = "Зам председателя комиссии")

        АСформироватьПриказ.GroupBox12.Visible = Видимость
        АСформироватьПриказ.Label22.Visible = Видимость
        АСформироватьПриказ.Label23.Visible = False

        АСформироватьПриказ.Label22.Text = ПодписьТекстБ

        АСформироватьПриказ.ЗамПредседателя.Visible = Видимость
        АСформироватьПриказ.ЗамПредседателяДолжность.Visible = False

    End Sub

    Sub местоНаФорме(номерНаФорме As Integer, лэйбл1 As Object, лэйбл2 As Object, бокс1 As Object, бокс2 As Object, ГруппБокс As Object)

        Dim координата0Х As Integer, координата0У As Integer

        координата0Х = 20
        координата0У = 60 + 40 * (номерНаФорме - 1)

        ГруппБокс.Location = New Point(координата0Х, координата0У)

        лэйбл1.Location = New Point(координата0Х + 1, координата0У + 19)
        лэйбл2.Location = New Point(координата0Х + 1, координата0У + 46)

        бокс1.Location = New Point(координата0Х + 240, координата0У + 19)
        бокс2.Location = New Point(координата0Х + 240, координата0У + 46)

        бокс1.TabIndex = номерНаФорме * 2 + 3
        бокс2.TabIndex = номерНаФорме * 2 + 4

    End Sub

    Sub местоНаФормеПослеДиректора(номерНаФорме As Integer, лэйбл1 As Object, лэйбл2 As Object, бокс1 As Object, бокс2 As Object, ГруппБокс As Object)

        Dim координата0Х As Integer, координата0У As Integer

        координата0Х = 20
        координата0У = 60 + 40 * (номерНаФорме)

        ГруппБокс.Location = New Point(координата0Х, координата0У)

        лэйбл1.Location = New Point(координата0Х + 1, координата0У + 19)
        лэйбл2.Location = New Point(координата0Х + 1, координата0У + 46)

        бокс1.Location = New Point(координата0Х + 240, координата0У + 19)
        бокс2.Location = New Point(координата0Х + 240, координата0У + 46)

        бокс1.TabIndex = номерНаФорме * 2 + 3
        бокс2.TabIndex = номерНаФорме * 2 + 4

    End Sub

    Private Sub TabPage1_GotFocus(sender As Object, e As EventArgs) Handles TabPage1.GotFocus

        ActiveControl = ПриказОЗачислении

    End Sub

    Private Sub ААОсновная_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If TabControlOther.SelectedIndex = 6 Then

            If tbl_obrazovanie.flag_active_control Then

                tbl_obrazovanie_keyDown(e)
                Return

            ElseIf DataGridView_list.Visible Then

                If e.KeyValue = Keys.Escape Then

                    closeRedactorWorker(sender, e)
                    ActiveControl = DataGridView_list

                ElseIf e.KeyValue = Keys.Enter Then

                    worker_EnterDown()

                ElseIf e.KeyValue = Keys.Escape Then

                    closeRedactorWorker(sender, e)

                End If

            End If

            If ToolStrip1.Focused() Or ToolStrip_name_list.Focused Then

                Return

            ElseIf (DataGridView_list.Focused Or ActiveControl.Name = "TabControlOther" Or passwordOther.Focused) And SplitContainerOtherList.Panel2Collapsed Then

                If e.KeyCode = КлавишаПереключенияВкладок Then

                    переключательВкладок(TabControlOther)

                End If

                If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then

                    обратныйПереключательВкладок(TabControlOther)

                End If

            End If

            Return

        End If



        If TabControlOther.SelectedIndex = 5 And password.Focused = False Then

            If ToolStrip3.Focused() Or ToolStrip2.Focused() Then

                Return

            End If

            If programms_tbl.flag_active_control Then

                programms_tbl_keyDown(e)
                Return

            End If

            If e.KeyCode = КлавишаПереключенияВкладок Then

                Dim ac As Control = ActiveControl
                Dim name As String = ac.Name

                If DataGridAllModuls.Focused Or ActiveControl.Name = "TabControlOther" Then

                    переключательВкладок(TabControlOther)

                ElseIf ActiveControl.Name = "SplitContainer4" Or ActiveControl.Name = "dataGridModuls" Or ActiveControl.Name = "ToolStrip3" Then

                    Return

                End If

                e.Handled = True
                Return

            ElseIf e.KeyCode = 37 Then

                If ActiveControl.Name = "TabControlOther" Then

                    обратныйПереключательВкладок(TabControlOther)

                ElseIf DataGridAllModuls.Focused Or dataGridModuls.Focused Then

                    Return

                End If

                e.Handled = True
                Return

            ElseIf e.KeyCode = 38 Or e.KeyCode = 40 Then

                Return

            End If

        End If

        If e.KeyCode = КлавишаПереключенияВкладок Then

            If red_moduls.Focused Or newModAddName.Focused Or newModAddHour.Focused Or worker_name.Focused Or worker_name_full.Focused Or worker_name_pad.Focused Then
                Return
            End If
            переключательВкладок(TabControlOther)
            e.Handled = True

        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            If red_moduls.Focused Or newModAddName.Focused Or newModAddHour.Focused Or worker_name.Focused Or worker_name_full.Focused Or worker_name_pad.Focused Then
                Return
            End If
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = 38 Or e.KeyCode = 40 Then
            функционалТаб(e.KeyCode, вместоТаб)
            ААперемещениеВверх(e.KeyCode, 38)
            e.Handled = True
        End If

    End Sub

    Private Sub redactor_full_name_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub ААОсновная_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown

        If tbl_obrazovanie.Focused Then

            If e.KeyValue = Keys.Tab Then

                e.IsInputKey = True

            End If

        End If

    End Sub

    Private Sub tbl_obrazovanie_keyDown(e As KeyEventArgs)

        If e.KeyValue = Keys.Tab Then

            If tbl_obrazovanie.active_last_element Then

                ToolStrip_name_list.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Right Then

            If tbl_obrazovanie.active_last_element Then

                переключательВкладок(TabControlOther)
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Left Then

            If tbl_obrazovanie.active_last_element Then

                обратныйПереключательВкладок(TabControlOther)
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Escape Then

            tbl_obrazovanie.redactorClose()
            e.Handled = True

        End If

    End Sub

    Private Sub programms_tbl_keyDown(e As KeyEventArgs)

        If e.KeyValue = Keys.Tab Then

            If programms_tbl.active_last_element Then

                dataGridModuls.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Right Then

            If programms_tbl.active_last_element Then

                dataGridModuls.Focus()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Left Then

            If programms_tbl.active_last_element Then

                обратныйПереключательВкладок(TabControlOther)
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Escape Then

            If Not programms_tbl.comboBox_second_element.my_ComboBox.DroppedDown Then

                programms_tbl.redactorClose()

            Else

                programms_tbl.comboBox_second_element.my_ComboBox.DroppedDown = False

            End If
            e.Handled = True

        End If

    End Sub

    Sub ААперемещениеВверх(номерНажатойКлавиши As Integer, Optional номерКлавишиСФункционаломВверх As Integer = 38)
        If номерНажатойКлавиши = номерКлавишиСФункционаломВверх Then

            If Me.ActiveControl.TabIndex = 0 Then
                Exit Sub
            End If
            For Each i In Me.TabPage4.Controls
                If i.tabIndex = Me.ActiveControl.TabIndex - 1 Then
                    Me.ActiveControl = i
                    Exit Sub
                End If
            Next

        End If
    End Sub


    Private Sub ОткрытьСправочникГруппы_KeyDown(sender As Object, e As KeyEventArgs) Handles СправочникГруппыПК.KeyDown
        If e.KeyValue = 13 Then
            Call ОткрытьСправочникГруппы_Click(sender, e)
        End If
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub СправочникГруппыПП_KeyDown(sender As Object, e As KeyEventArgs) Handles СправочникГруппыПП.KeyDown
        If e.KeyValue = 13 Then
            Call СправочникГруппыПП_Click(sender, e)
        End If
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub СправочникГруппыПО_KeyDown(sender As Object, e As KeyEventArgs) Handles СправочникГруппыПО.KeyDown
        If e.KeyValue = 13 Then
            Call СправочникГруппыПО_Click(sender, e)
        End If
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub КнопкаСоздатьГруппу_KeyDown(sender As Object, e As KeyEventArgs) Handles КнопкаСоздатьГруппу.KeyDown
        If e.KeyCode = 13 Then
            Call КнопкаСоздатьГруппу_Click(sender, e)
        End If
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ДобавитьСлушателя_KeyDown(sender As Object, e As KeyEventArgs) Handles ДобавитьСлушателя.KeyDown
        If e.KeyCode = 13 Then
            Call ДобавитьСлушателя_Click(sender, e)
        End If
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub
    Private Sub СправочникСлушатели_KeyDown(sender As Object, e As KeyEventArgs) Handles СправочникСлушатели.KeyDown

        If e.KeyCode = 13 Then
            Call СправочникСлушатели_Click(sender, e)
        End If
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If

    End Sub

    Private Sub ОтчетРуководителя_KeyDown(sender As Object, e As KeyEventArgs) Handles ОтчетРуководителя.KeyDown
        ЧекатьНаИнтер(ОтчетРуководителя, e.KeyCode)
    End Sub

    Private Sub ChСводПоКурсам_KeyDown(sender As Object, e As KeyEventArgs) Handles ChСводПоКурсам.KeyDown
        If e.KeyCode = 13 Then
            If ChСводПоКурсам.Checked Then
                ChСводПоКурсам.Checked = False
            Else
                ChСводПоКурсам.Checked = True
            End If
        End If
    End Sub


    Private Sub СводПоСпец_KeyDown(sender As Object, e As KeyEventArgs) Handles СводПоСпец.KeyDown
        ЧекатьНаИнтер(СводПоСпец, e.KeyCode)
    End Sub


    Private Sub СводПоОрганиз_KeyDown(sender As Object, e As KeyEventArgs) Handles СводПоОрганиз.KeyDown
        ЧекатьНаИнтер(СводПоОрганиз, e.KeyCode)
    End Sub

    Private Sub БюджетВбюдж_KeyDown(sender As Object, e As KeyEventArgs) Handles БюджетВбюдж.KeyDown
        ЧекатьНаИнтер(БюджетВбюдж, e.KeyCode)
    End Sub

    Private Sub ОтчетПеднагрузка_KeyDown(sender As Object, e As KeyEventArgs) Handles ОтчетПеднагрузка.KeyDown
        ЧекатьНаИнтер(ОтчетПеднагрузка, e.KeyCode)
    End Sub

    Private Sub CheckBoxРМАНПО_KeyDown(sender As Object, e As KeyEventArgs)
        ЧекатьНаИнтер(ChРМАНПО, e.KeyCode)
    End Sub

    Private Sub СправочникГруппыПП_GotFocus(sender As Object, e As EventArgs) Handles СправочникГруппыПП.GotFocus
        увеличитьШрифт(СправочникГруппыПП)
    End Sub

    Private Sub СправочникГруппыПП_LostFocus(sender As Object, e As EventArgs) Handles СправочникГруппыПП.LostFocus
        СправочникГруппыПП.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular)
    End Sub

    Private Sub СправочникГруппыПО_GotFocus(sender As Object, e As EventArgs) Handles СправочникГруппыПО.GotFocus
        увеличитьШрифт(СправочникГруппыПО)
    End Sub

    Private Sub СправочникГруппыПО_LostFocus(sender As Object, e As EventArgs) Handles СправочникГруппыПО.LostFocus
        СправочникГруппыПО.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular)
    End Sub

    Private Sub ОткрытьСправочникГруппы_GotFocus(sender As Object, e As EventArgs) Handles СправочникГруппыПК.GotFocus
        увеличитьШрифт(СправочникГруппыПК)
    End Sub

    Private Sub ОткрытьСправочникГруппы_LostFocus(sender As Object, e As EventArgs) Handles СправочникГруппыПК.LostFocus
        СправочникГруппыПК.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular)
    End Sub

    Private Sub КнопкаСоздатьГруппу_GotFocus(sender As Object, e As EventArgs) Handles КнопкаСоздатьГруппу.GotFocus
        Call увеличитьШрифт(КнопкаСоздатьГруппу)
    End Sub

    Private Sub КнопкаСоздатьГруппу_LostFocus(sender As Object, e As EventArgs) Handles КнопкаСоздатьГруппу.LostFocus

        КнопкаСоздатьГруппу.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular)

    End Sub

    Private Sub СправочникСлушатели_GotFocus(sender As Object, e As EventArgs) Handles СправочникСлушатели.GotFocus
        Call увеличитьШрифт(СправочникСлушатели)
    End Sub

    Private Sub СправочникСлушатели_LostFocus(sender As Object, e As EventArgs) Handles СправочникСлушатели.LostFocus

        СправочникСлушатели.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular)

    End Sub


    Private Sub ДобавитьСлушателя_GotFocus(sender As Object, e As EventArgs) Handles ДобавитьСлушателя.GotFocus
        Call увеличитьШрифт(ДобавитьСлушателя)
    End Sub

    Private Sub ДобавитьСлушателя_LostFocus(sender As Object, e As EventArgs) Handles ДобавитьСлушателя.LostFocus

        ДобавитьСлушателя.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular)

    End Sub

    Sub НормальныйШрифт(контрол As Object)

        контрол.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular)

    End Sub
    Sub увеличитьШрифт(контрол As Object)

        контрол.Font = New Font("Microsoft Sans Serif", 14.0F, FontStyle.Regular)

    End Sub
    Private Sub ПриказОЗачислении_Доп_GotFocus(sender As Object, e As EventArgs) Handles ПриказОЗачислении_Доп.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub
    Private Sub ПриказОЗачислении_Доп_LostFocus(sender As Object, e As EventArgs) Handles ПриказОЗачислении_Доп.LostFocus
        Call НормальныйШрифт(ПриказОЗачислении_Доп)
    End Sub

    Private Sub ПриказОЗачислении_GotFocus(sender As Object, e As EventArgs) Handles ПриказОЗачислении.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПриказОЗачислении_LostFocus(sender As Object, e As EventArgs) Handles ПриказОЗачислении.LostFocus
        Call НормальныйШрифт(ПриказОЗачислении)
    End Sub

    Private Sub ПК_Отчисление_GotFocus(sender As Object, e As EventArgs) Handles ПК_Отчисление.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПК_Отчисление_LostFocus(sender As Object, e As EventArgs) Handles ПК_Отчисление.LostFocus
        Call НормальныйШрифт(ПК_Отчисление)
    End Sub

    Private Sub ППЗачисление_GotFocus(sender As Object, e As EventArgs) Handles ППЗачисление.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ППЗачисление_LostFocus(sender As Object, e As EventArgs) Handles ППЗачисление.LostFocus
        Call НормальныйШрифт(ППЗачисление)
    End Sub

    Private Sub ПП_Практика_GotFocus(sender As Object, e As EventArgs) Handles ПП_Практика.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПП_Практика_LostFocus(sender As Object, e As EventArgs) Handles ПП_Практика.LostFocus
        Call НормальныйШрифт(ПП_Практика)
    End Sub

    Private Sub ПП_ДопускКИА_GotFocus(sender As Object, e As EventArgs) Handles ПП_ДопускКИА.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПП_ДопускКИА_LostFocus(sender As Object, e As EventArgs) Handles ПП_ДопускКИА.LostFocus
        Call НормальныйШрифт(ПП_ДопускКИА)
    End Sub

    Private Sub ПО_Зачисление_GotFocus(sender As Object, e As EventArgs) Handles ПО_Зачисление.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПО_Зачисление_LostFocus(sender As Object, e As EventArgs) Handles ПО_Зачисление.LostFocus
        Call НормальныйШрифт(ПО_Зачисление)
    End Sub

    Private Sub ПО_Практика_GotFocus(sender As Object, e As EventArgs) Handles ПО_Практика.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПО_Практика_LostFocus(sender As Object, e As EventArgs) Handles ПО_Практика.LostFocus
        Call НормальныйШрифт(ПО_Практика)
    End Sub

    Private Sub ПО_ДопускКИА_GotFocus(sender As Object, e As EventArgs) Handles ПО_ДопускКИА.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПО_ДопускКИА_LostFocus(sender As Object, e As EventArgs) Handles ПО_ДопускКИА.LostFocus
        Call НормальныйШрифт(ПО_ДопускКИА)
    End Sub

    Private Sub Button1_GotFocus(sender As Object, e As EventArgs) Handles Button1.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub Button1_LostFocus(sender As Object, e As EventArgs) Handles Button1.LostFocus
        Call НормальныйШрифт(Button1)
    End Sub

    Private Sub ОтчетРуководителя_GotFocus(sender As Object, e As EventArgs) Handles ОтчетРуководителя.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ОтчетРуководителя_LostFocus(sender As Object, e As EventArgs) Handles ОтчетРуководителя.LostFocus
        Call НормальныйШрифт(ОтчетРуководителя)
    End Sub

    Private Sub ChРМАНПО_GotFocus(sender As Object, e As EventArgs) Handles ChРМАНПО.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ChРМАНПО_LostFocus(sender As Object, e As EventArgs) Handles ChРМАНПО.LostFocus
        Call НормальныйШрифт(ChРМАНПО)
    End Sub

    Private Sub ChСводПоКурсам_GotFocus(sender As Object, e As EventArgs) Handles ChСводПоКурсам.GotFocus
        Call увеличитьШрифт(ChСводПоКурсам)
    End Sub

    Private Sub ChСводПоКурсам_LostFocus(sender As Object, e As EventArgs) Handles ChСводПоКурсам.LostFocus
        Call НормальныйШрифт(ChСводПоКурсам)
    End Sub

    Private Sub СводПоСпец_CheckedChanged(sender As Object, e As EventArgs) Handles СводПоСпец.CheckedChanged

    End Sub

    Private Sub СводПоСпец_GotFocus(sender As Object, e As EventArgs) Handles СводПоСпец.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub СводПоСпец_LostFocus(sender As Object, e As EventArgs) Handles СводПоСпец.LostFocus
        Call НормальныйШрифт(СводПоСпец)
    End Sub


    Private Sub СводПоОрганиз_GotFocus(sender As Object, e As EventArgs) Handles СводПоОрганиз.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub СводПоОрганиз_LostFocus(sender As Object, e As EventArgs) Handles СводПоОрганиз.LostFocus
        Call НормальныйШрифт(СводПоОрганиз)
    End Sub

    Private Sub БюджетВбюдж_GotFocus(sender As Object, e As EventArgs) Handles БюджетВбюдж.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub БюджетВбюдж_LostFocus(sender As Object, e As EventArgs) Handles БюджетВбюдж.LostFocus
        Call НормальныйШрифт(БюджетВбюдж)
    End Sub

    Private Sub Педнагрузка_GotFocus(sender As Object, e As EventArgs) Handles Педнагрузка.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub Педнагрузка_LostFocus(sender As Object, e As EventArgs) Handles Педнагрузка.LostFocus
        Call НормальныйШрифт(Педнагрузка)
    End Sub

    Private Sub ОтчетПеднагрузка_GotFocus(sender As Object, e As EventArgs) Handles ОтчетПеднагрузка.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ОтчетПеднагрузка_LostFocus(sender As Object, e As EventArgs) Handles ОтчетПеднагрузка.LostFocus
        Call НормальныйШрифт(ОтчетПеднагрузка)
    End Sub

    Private Sub ПК_Заявление_LostFocus(sender As Object, e As EventArgs) Handles ПК_Заявление.LostFocus
        Call НормальныйШрифт(ПК_Заявление)
    End Sub

    Private Sub ПК_Заявление_GotFocus(sender As Object, e As EventArgs) Handles ПК_Заявление.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub


    Private Sub ПП_Заявление_LostFocus(sender As Object, e As EventArgs) Handles ПП_Заявление.LostFocus
        Call НормальныйШрифт(ПП_Заявление)
    End Sub

    Private Sub ПП_Заявление_GotFocus(sender As Object, e As EventArgs) Handles ПП_Заявление.GotFocus
        Call увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub Карточка_слушателя_LostFocus(sender As Object, e As EventArgs) Handles Карточка_слушателя.LostFocus
        Call НормальныйШрифт(Карточка_слушателя)
    End Sub

    Private Sub Карточка_слушателя_GotFocus(sender As Object, e As EventArgs) Handles Карточка_слушателя.GotFocus
        увеличитьШрифт(ActiveControl)
    End Sub

    Private Sub ПК_Окончание_LostFocus(sender As Object, e As EventArgs) Handles ПК_Окончание.LostFocus
        НормальныйШрифт(ПК_Окончание)
    End Sub

    Private Sub ПК_Окончание_GotFocus(sender As Object, e As EventArgs) Handles ПК_Окончание.GotFocus
        увеличитьШрифт(ПК_Окончание)
    End Sub

    Private Sub ИтоговаяАттествцияОценки_GotFocus(sender As Object, e As EventArgs) Handles ИтоговаяАттествцияОценки.GotFocus
        увеличитьШрифт(ИтоговаяАттествцияОценки)
    End Sub
    Private Sub ИтоговаяАттествцияОценки_LostFocus(sender As Object, e As EventArgs) Handles ИтоговаяАттествцияОценки.LostFocus
        НормальныйШрифт(ИтоговаяАттествцияОценки)
    End Sub
    Private Sub Ведомость_LostFocus(sender As Object, e As EventArgs) Handles Ведомость.LostFocus
        НормальныйШрифт(Ведомость)
    End Sub
    Private Sub Ведомость_GotFocus(sender As Object, e As EventArgs) Handles Ведомость.GotFocus
        увеличитьШрифт(Ведомость)
    End Sub



    Private Sub ПП_Окончание_Click(sender As Object, e As EventArgs) Handles ПП_Окончание.Click
        prikazCvalif = PP
        АСформироватьПриказ.Text = "ПП_Окончание"
        АСформироватьПриказ.ВидПриказа = "ПП_Окончание"

        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "", "", "")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)

        ActiveControl = Button2

        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

    End Sub

    Private Sub ПП_Окончание_GotFocus(sender As Object, e As EventArgs) Handles ПП_Окончание.GotFocus
        увеличитьШрифт(ПП_Окончание)
    End Sub

    Private Sub ПП_Окончание_LostFocus(sender As Object, e As EventArgs) Handles ПП_Окончание.LostFocus
        НормальныйШрифт(ПП_Окончание)
    End Sub

    Private Sub ПП_ПриложениеКдиплому_Click(sender As Object, e As EventArgs) Handles ПП_ПриложениеКдиплому.Click

        prikazCvalif = PP
        АСформироватьПриказ.Text = "ПП_Приложение к диплому"
        АСформироватьПриказ.ВидПриказа = "ПП_ПриложениеКдиплому"

        АСформироватьПриказ.Label24.Text = "Производственная практика"

        АСформироватьПриказ.CheckBox1.Visible = True
        АСформироватьПриказ.CheckBox1.Location = New Point(20, 76)
        АСформироватьПриказ.CheckBox1.Checked = False

        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "", "", "")
        ПроектВносит(False)
        Исполнитель(False)
        Согласовано1(False)
        Согласовано2(False)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 180)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 96)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 96)

        ActiveControl = Button2

        местоНаФорме(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФорме(3, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФорме(4, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФорме(5, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФорме(6, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        Утверждает(False)

        АСформироватьПриказ.ShowDialog()
        АСформироватьПриказ.CheckBox1.Visible = False
        АСформироватьПриказ.ПрактическаяПодготовка.Visible = False
        АСформироватьПриказ.ИтоговаяАттестация.Visible = False
        АСформироватьПриказ.Label24.Visible = False
        АСформироватьПриказ.Label25.Visible = False
        АСформироватьПриказ.Text = "Приказ"

        Утверждает(True)

    End Sub

    Private Sub ПП_ПриложениеКдиплому_GotFocus(sender As Object, e As EventArgs) Handles ПП_ПриложениеКдиплому.GotFocus
        Call увеличитьШрифт(ПП_ПриложениеКдиплому)
    End Sub

    Private Sub ПП_ПриложениеКдиплому_LostFocus(sender As Object, e As EventArgs) Handles ПП_ПриложениеКдиплому.LostFocus
        Call НормальныйШрифт(ПП_ПриложениеКдиплому)
    End Sub

    Private Sub ПО_Окончание_Click(sender As Object, e As EventArgs) Handles ПО_Окончание.Click

        prikazCvalif = PO
        АСформироватьПриказ.Text = "ПО_Окончание"
        АСформироватьПриказ.ВидПриказа = "ПО_Окончание"

        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "", "", "")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 665)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 580)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 580)

        ActiveControl = Button2

        местоНаФорме(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФорме(3, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФорме(4, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФорме(5, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФорме(6, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()
    End Sub

    Private Sub ПО_Окончание_GotFocus(sender As Object, e As EventArgs) Handles ПО_Окончание.GotFocus
        увеличитьШрифт(ПО_Окончание)
    End Sub

    Private Sub ПО_Окончание_LostFocus(sender As Object, e As EventArgs) Handles ПО_Окончание.LostFocus
        НормальныйШрифт(ПО_Окончание)
    End Sub

    Private Sub ПО_Свидетельство_Click(sender As Object, e As EventArgs) Handles ПО_Свидетельство.Click

        prikazCvalif = PO
        АСформироватьПриказ.Text = "ПО_Свидетельство"
        АСформироватьПриказ.ВидПриказа = "ПО_Свидетельство"

        АСформироватьПриказ.Label24.Text = "Практическая подготовка"

        АСформироватьПриказ.CheckBox1.Visible = True
        АСформироватьПриказ.CheckBox1.Location = New Point(20, 76)
        АСформироватьПриказ.CheckBox1.Checked = False

        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "", "", "")
        ПроектВносит(False)
        Исполнитель(False)
        Согласовано1(False)
        Согласовано2(False)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Size = New Size(840, 180)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 96)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 96)

        ActiveControl = Button2

        местоНаФорме(2, АСформироватьПриказ.Label4, АСформироватьПриказ.Label13, АСформироватьПриказ.Ответственный, АСформироватьПриказ.ОтветственныйДолжность, АСформироватьПриказ.GroupBox5)
        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФорме(3, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФорме(4, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФорме(5, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФорме(6, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)
        Утверждает(False)

        АСформироватьПриказ.ShowDialog()
        АСформироватьПриказ.CheckBox1.Visible = False
        АСформироватьПриказ.ПрактическаяПодготовка.Visible = False
        АСформироватьПриказ.ИтоговаяАттестация.Visible = False
        АСформироватьПриказ.Label24.Visible = False
        АСформироватьПриказ.Label25.Visible = False
        АСформироватьПриказ.Text = "Приказ"

        Call Утверждает(True)

    End Sub

    Private Sub ПО_Свидетельство_GotFocus(sender As Object, e As EventArgs) Handles ПО_Свидетельство.GotFocus
        Call увеличитьШрифт(ПО_Свидетельство)
    End Sub

    Private Sub ПО_Свидетельство_LostFocus(sender As Object, e As EventArgs) Handles ПО_Свидетельство.LostFocus
        Call НормальныйШрифт(ПО_Свидетельство)
    End Sub


    Private Sub ААОсновная_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Запуск.Открыть Then

            Запуск.Открыть = False
            Me.Close()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Коллекция()
        Dim form1 As New ФормаСписок
        form1.Show()

    End Sub

    Private Sub ААОсновная_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
    End Sub

    Private Sub ДиректорФИО_Click(sender As Object, e As EventArgs) Handles ДиректорФИО.Click

        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()

    End Sub

    Private Sub ДиректорДолжность_Click(sender As Object, e As EventArgs) Handles ДиректорДолжность.Click

        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()

    End Sub

    Private Sub Согласовано1ДолжностьПУ_Click(sender As Object, e As EventArgs) Handles Согласовано1ДолжностьПУ.Click

        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()

    End Sub

    Private Sub Согласовано2ДолжностьПУ_Click(sender As Object, e As EventArgs) Handles Согласовано2ДолжностьПУ.Click

        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()

    End Sub

    Private Sub Согласовано1ПУ_Click(sender As Object, e As EventArgs) Handles Согласовано1ПУ.Click

        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()

    End Sub

    Private Sub Согласовано2ПУ_Click(sender As Object, e As EventArgs) Handles Согласовано2ПУ.Click

        ФормаСписок.textboxName = Me.ActiveControl.Name
        ФормаСписок.FormName = Me.Name
        ФормаСписок.ShowDialog()

    End Sub

    Private Sub КнигаУчетаУдостоверений_Click(sender As Object, e As EventArgs) Handles КнигаУчетаУдостоверений.Click
        ActiveControl = Button2
        КнигаУчета.КнигаУчета("Удостоверение")

    End Sub

    Private Sub КнигаУчетаДипломов_Click(sender As Object, e As EventArgs) Handles КнигаУчетаДипломов.Click
        ActiveControl = Button2
        КнигаУчета.КнигаУчета("Диплом")

    End Sub

    Private Sub КнигаУчетаСвидетельств_Click(sender As Object, e As EventArgs) Handles КнигаУчетаСвидетельств.Click
        ActiveControl = Button2
        КнигаУчета.КнигаУчета("Свидетельство")
    End Sub

    Private Sub КнигаУчетаУдостоверенийФРДО_Click(sender As Object, e As EventArgs) Handles КнигаУчетаУдостоверенийФРДО.Click
        ActiveControl = Button2
        КнигаУчетаФРДО.КнигаУчета("Удостоверение")
    End Sub

    Private Sub КнигаДипломовФРДО_Click(sender As Object, e As EventArgs) Handles КнигаДипломовФРДО.Click
        ActiveControl = Button2
        КнигаУчетаФРДО.КнигаУчета("Диплом")
    End Sub

    Private Sub КнигаСвидетельствФРДО_Click(sender As Object, e As EventArgs) Handles КнигаСвидетельствФРДО.Click
        ActiveControl = Button2
        КнигаУчетаФРДО.КнигаУчета("Свидетельство")
    End Sub

    Private Sub Книга_учета_протоколов_спецэкзамен_Click(sender As Object, e As EventArgs)
        ActiveControl = Button2
        КнигаУчетаСпецэкзамен.КнигаУчетаСпецэкзамен()
    End Sub

    Private Sub Ведомость_слушателиИорганизации_Click(sender As Object, e As EventArgs) Handles Ведомость_слушателиИорганизации.Click

        prikazCvalif = PK_PP
        АСформироватьПриказ.Text = "Ведомость слушатели и организации"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name
        ActiveControl = Button2

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False


        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "ММС", "санитар", "должность слушателей")
        Call ПроектВносит(False)
        Call Исполнитель(False)
        Call Согласовано1(False)
        Call Согласовано2(False)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 150)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 65)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 65)

        ActiveControl = Button2
        АСформироватьПриказ.ДатаПриказа.Enabled = False
        АСформироватьПриказ.ShowDialog()
        АСформироватьПриказ.ДатаПриказа.Enabled = True

    End Sub

    Private Sub ДоверенностьПолученияБланков_Click(sender As Object, e As EventArgs) Handles ДоверенностьПолученияБланков.Click

        prikazCvalif = PK_PP_PO
        АСформироватьПриказ.Text = "Доверенность получения бланков на группу"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.Утверждает.Visible = True
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = True
        АСформироватьПриказ.Label14.Visible = False

        АСформироватьПриказ.Label2.Text = "Ответственный"


        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "ММС", "санитар", "должность слушателей")
        ПроектВносит(False)
        Исполнитель(False)
        Согласовано1(False)
        Согласовано2(False)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        standard_location(1)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 190)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 107)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 107)

        отключитьДиректора = True
        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()
        отключитьДиректора = False
        АСформироватьПриказ.Label2.Text = "Директор ФИО"

    End Sub

    Private Sub ДоверенностьПолученияБланковСлушателей_Click(sender As Object, e As EventArgs) Handles ДоверенностьПолученияБланковСлушателей.Click

        prikazCvalif = PK_PP_PO
        АСформироватьПриказ.Text = "Доверенность получения бланков на слушателя"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 120)

        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False

        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count > 1

            АСформироватьПриказ.ListViewСписокСлушателей.Columns.RemoveAt(1)

        End While

        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 805
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "ФИО"

        АСформироватьПриказ.LabelИзмениПадеж.Location = New Point(9, 99)
        АСформироватьПриказ.LabelИзмениПадеж.Visible = True
        АСформироватьПриказ.Утверждает.Visible = True
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = True
        АСформироватьПриказ.Label14.Visible = False

        АСформироватьПриказ.Label2.Text = "Ответственный"


        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "ММС", "санитар", "должность слушателей")
        ПроектВносит(False)
        Исполнитель(False)
        Согласовано1(False)
        Согласовано2(False)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        standard_location(1)

        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 790)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 700)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 700)

        отключитьДиректора = True
        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()

        отключитьДиректора = False
        АСформироватьПриказ.Label2.Text = "Директор ФИО"
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False
        АСформироватьПриказ.LabelИзмениПадеж.Visible = False
    End Sub

    Private Sub ВедомостьПромежуточнойАттестации_Click(sender As Object, e As EventArgs) Handles ВедомостьПромежуточнойАттестации.Click

        prikazCvalif = PO
        АСформироватьПриказ.Text = "Ведомость промежуточной аттестации"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count < 3
            АСформироватьПриказ.ListViewСписокСлушателей.Columns.Add("Преподаватель", 200)
        End While
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "Номер"
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 50
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Width = 550
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Text = "Наименование модуля"



        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 120)

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False


        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "ММС", "санитар", "должность слушателей")
        Call ПроектВносит(False)
        Call Исполнитель(False)
        Call Согласовано1(False)
        Call Согласовано2(False)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 790)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 700)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 700)

        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False


    End Sub

    Private Sub ПП_Ведомость_Click(sender As Object, e As EventArgs) Handles ПП_Ведомость.Click

        prikazCvalif = PP
        АСформироватьПриказ.Text = "ПП Ведомость промежуточной аттестации"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count < 3
            АСформироватьПриказ.ListViewСписокСлушателей.Columns.Add("Преподаватель", 200)
        End While

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 120)
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "Номер"
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 50
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Width = 550
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Text = "Наименование модуля"

        'АСформироватьПриказ.ListViewСписокСлушателей.Columns(2).Width = 300
        'АСформироватьПриказ.ListViewСписокСлушателей.Columns(2).Text = "Преподаватель"

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False


        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "ММС", "санитар", "должность слушателей")
        Call ПроектВносит(False)
        Call Исполнитель(False)
        Call Согласовано1(False)
        Call Согласовано2(False)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 790)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 700)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 700)

        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False

    End Sub
    Private Sub ПК_Окончание_уд_Click(sender As Object, e As EventArgs) Handles ПК_Окончание_уд.Click

        prikazCvalif = PK
        АСформироватьПриказ.ВидПриказа = "ПК_Окончание_уд"
        АСформироватьПриказ.Text = "ПК_Окончание_уд"
        ActiveControl = Button2

        ОтветственныйЗаАттестацию(False)
        чекбоксы(False, "", "", "")
        ПроектВносит(True)
        Исполнитель(True)
        Согласовано1(True)
        Согласовано2(True)
        РуководительСтажировки(False)
        Комиссия2(False)
        Комиссия3(False)
        СекретарьКомиссии(False)
        ЗаместительРПК(False)

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count > 1
            АСформироватьПриказ.ListViewСписокСлушателей.Columns.RemoveAt(1)
        End While
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 805
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "ФИО"

        АСформироватьПриказ.LabelИзмениПадеж.Location = New Point(9, 98)
        ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)
        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 330)

        АСформироватьПриказ.Size = New Size(840, 990)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 907)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 907)

        ActiveControl = Button2

        местоНаФорме(1, АСформироватьПриказ.Label2, АСформироватьПриказ.Label14, АСформироватьПриказ.Утверждает, АСформироватьПриказ.УтверждаетДолжность, АСформироватьПриказ.GroupBox6)
        местоНаФормеПослеДиректора(2, АСформироватьПриказ.Label5, АСформироватьПриказ.Label6, АСформироватьПриказ.ПроектВносит, АСформироватьПриказ.ПроектВноситДолжность, АСформироватьПриказ.GroupBox1)
        местоНаФормеПослеДиректора(3, АСформироватьПриказ.Label7, АСформироватьПриказ.Label8, АСформироватьПриказ.Исполнитель, АСформироватьПриказ.ИсполнительДолжность, АСформироватьПриказ.GroupBox2)
        местоНаФормеПослеДиректора(4, АСформироватьПриказ.Label9, АСформироватьПриказ.Label10, АСформироватьПриказ.Согласовано1, АСформироватьПриказ.Согласовано1Должность, АСформироватьПриказ.GroupBox3)
        местоНаФормеПослеДиректора(5, АСформироватьПриказ.Label11, АСформироватьПриказ.Label12, АСформироватьПриказ.Согласовано2, АСформироватьПриказ.Согласовано2Должность, АСформироватьПриказ.GroupBox4)

        АСформироватьПриказ.ShowDialog()

        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False
    End Sub
    Private Sub СправкаОбОбучении_Click(sender As Object, e As EventArgs) Handles СправкаОбОбучении.Click

        prikazCvalif = PK_PP_PO
        АСформироватьПриказ.Text = "СправкаОбОбучении"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.LabelИзмениПадеж.Visible = True
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        АСформироватьПриказ.LabelИзмениПадеж.Location = New Point(9, 152)
        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 180)

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False

        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count > 1
            АСформироватьПриказ.ListViewСписокСлушателей.Columns.RemoveAt(1)
        End While

        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 805
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "ФИО"


        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "ММС", "санитар", "должность слушателей")
        Call ПроектВносит(False)
        Call Исполнитель(False)
        Call Согласовано1(False)
        Call Согласовано2(False)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        standard_location(1)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 843)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 760)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 760)

        showPoleVvoda(True)

        АСформироватьПриказ.ДатаПриказа.Enabled = False
        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()
        АСформироватьПриказ.ДатаПриказа.Enabled = True

        showPoleVvoda(False)

        АСформироватьПриказ.LabelИзмениПадеж.Visible = False
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False
        АСформироватьПриказ.ListViewСписокСлушателей.Columns.Add(1)
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "Номер"
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Text = "ФИО"
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Width = 120
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 50


    End Sub

    Sub showPoleVvoda(onOff As Boolean, Optional x As Integer = 90, Optional heightText As Integer = 42)

        If Not onOff Then

            АСформироватьПриказ.ПрактическаяПодготовка.Text = ""
            АСформироватьПриказ.Label24.Text = "Практическая подготовка"
            АСформироватьПриказ.ПрактическаяПодготовка.Visible = False
            АСформироватьПриказ.Label24.Visible = False
            АСформироватьПриказ.ПрактическаяПодготовка.Multiline = False
            АСформироватьПриказ.ПрактическаяПодготовка.Location = New Point(260, 110)
            АСформироватьПриказ.Label24.Location = New Point(20, 110)
            АСформироватьПриказ.ПрактическаяПодготовка.Size = New Size(546, 20)

        Else

            АСформироватьПриказ.ПрактическаяПодготовка.Location = New Point(260, x)
            АСформироватьПриказ.Label24.Text = "приказ о зачислении"
            АСформироватьПриказ.Label24.Location = New Point(20, x)
            АСформироватьПриказ.ПрактическаяПодготовка.Visible = True
            АСформироватьПриказ.ПрактическаяПодготовка.Multiline = True
            АСформироватьПриказ.ПрактическаяПодготовка.Size = New Size(546, heightText)
            АСформироватьПриказ.Label24.Visible = True

        End If
    End Sub
    Private Sub СправкаОбОкончании_Click(sender As Object, e As EventArgs) Handles СправкаОбОкончании.Click

        prikazCvalif = PK_PP_PO
        АСформироватьПриказ.Text = "Справка об окончании без ИА"
        АСформироватьПриказ.ВидПриказа = ActiveControl.Name

        АСформироватьПриказ.LabelИзмениПадеж.Visible = True
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = True
        АСформироватьПриказ.LabelИзмениПадеж.Location = New Point(9, 92)
        АСформироватьПриказ.ListViewСписокСлушателей.Location = New Point(9, 120)

        АСформироватьПриказ.Утверждает.Visible = False
        АСформироватьПриказ.УтверждаетДолжность.Visible = False
        АСформироватьПриказ.Label2.Visible = False
        АСформироватьПриказ.Label14.Visible = False

        While АСформироватьПриказ.ListViewСписокСлушателей.Columns.Count > 1
            АСформироватьПриказ.ListViewСписокСлушателей.Columns.RemoveAt(1)
        End While
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 805
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "ФИО"

        Call ОтветственныйЗаАттестацию(False)
        Call чекбоксы(False, "ММС", "санитар", "должность слушателей")
        Call ПроектВносит(False)
        Call Исполнитель(False)
        Call Согласовано1(False)
        Call Согласовано2(False)
        Call РуководительСтажировки(False)
        Call Комиссия2(False)
        Call Комиссия3(False)
        Call СекретарьКомиссии(False)
        Call ЗаместительРПК(False)

        standard_location(1)

        Call ОчиститьПоляФормы.Очиститьформу(АСформироватьПриказ)

        АСформироватьПриказ.Button1.Visible = False
        АСформироватьПриказ.Size = New Size(840, 790)
        АСформироватьПриказ.КнопкаСформировать.Location = New Point(135, 700)
        АСформироватьПриказ.КнопкаОчистить.Location = New Point(2, 700)
        АСформироватьПриказ.ДатаПриказа.Enabled = False
        ActiveControl = Button2
        АСформироватьПриказ.ShowDialog()
        АСформироватьПриказ.ДатаПриказа.Enabled = True

        АСформироватьПриказ.LabelИзмениПадеж.Visible = False
        АСформироватьПриказ.ListViewСписокСлушателей.Visible = False
        АСформироватьПриказ.ListViewСписокСлушателей.Columns.Add(1)
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Text = "Номер"
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Text = "ФИО"
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(1).Width = 120
        АСформироватьПриказ.ListViewСписокСлушателей.Columns(0).Width = 50

    End Sub

    Private Sub ПК_Окончание_уд_GotFocus(sender As Object, e As EventArgs) Handles ПК_Окончание_уд.GotFocus
        увеличитьШрифт(ПК_Окончание_уд)
    End Sub

    Private Sub ПК_Окончание_уд_LostFocus(sender As Object, e As EventArgs) Handles ПК_Окончание_уд.LostFocus
        НормальныйШрифт(ПК_Окончание_уд)
    End Sub

    Private Sub КнигаДипломовФРДО_GotFocus(sender As Object, e As EventArgs) Handles КнигаДипломовФРДО.GotFocus
        увеличитьШрифт(КнигаДипломовФРДО)
    End Sub

    Private Sub КнигаДипломовФРДО_LostFocus(sender As Object, e As EventArgs) Handles КнигаДипломовФРДО.LostFocus
        НормальныйШрифт(КнигаДипломовФРДО)
    End Sub

    Private Sub КнигаСвидетельствФРДО_GotFocus(sender As Object, e As EventArgs) Handles КнигаСвидетельствФРДО.GotFocus
        увеличитьШрифт(КнигаСвидетельствФРДО)
    End Sub

    Private Sub КнигаСвидетельствФРДО_LostFocus(sender As Object, e As EventArgs) Handles КнигаСвидетельствФРДО.LostFocus
        НормальныйШрифт(КнигаСвидетельствФРДО)
    End Sub
    Private Sub КнигаУчетаУдостоверенийФРДО_GotFocus(sender As Object, e As EventArgs) Handles КнигаУчетаУдостоверенийФРДО.GotFocus
        увеличитьШрифт(КнигаУчетаУдостоверенийФРДО)
    End Sub

    Private Sub КнигаУчетаУдостоверенийФРДО_LostFocus(sender As Object, e As EventArgs) Handles КнигаУчетаУдостоверенийФРДО.LostFocus
        НормальныйШрифт(КнигаУчетаУдостоверенийФРДО)
    End Sub
    Private Sub КнигаУчетаДипломов_GotFocus(sender As Object, e As EventArgs) Handles КнигаУчетаДипломов.GotFocus
        увеличитьШрифт(КнигаУчетаДипломов)
    End Sub

    Private Sub КнигаУчетаДипломов_LostFocus(sender As Object, e As EventArgs) Handles КнигаУчетаДипломов.LostFocus
        НормальныйШрифт(КнигаУчетаДипломов)
    End Sub

    Private Sub КнигаУчетаСвидетельств_GotFocus(sender As Object, e As EventArgs) Handles КнигаУчетаСвидетельств.GotFocus
        увеличитьШрифт(КнигаУчетаСвидетельств)
    End Sub

    Private Sub КнигаУчетаСвидетельств_LostFocus(sender As Object, e As EventArgs) Handles КнигаУчетаСвидетельств.LostFocus
        НормальныйШрифт(КнигаУчетаСвидетельств)
    End Sub

    Private Sub КнигаУчетаУдостоверений_GotFocus(sender As Object, e As EventArgs) Handles КнигаУчетаУдостоверений.GotFocus
        увеличитьШрифт(КнигаУчетаУдостоверений)
    End Sub

    Private Sub КнигаУчетаУдостоверений_LostFocus(sender As Object, e As EventArgs) Handles КнигаУчетаУдостоверений.LostFocus
        НормальныйШрифт(КнигаУчетаУдостоверений)
    End Sub
    Private Sub Ведомость_слушателиИорганизации_GotFocus(sender As Object, e As EventArgs) Handles Ведомость_слушателиИорганизации.GotFocus
        увеличитьШрифт(Ведомость_слушателиИорганизации)
    End Sub
    Private Sub Ведомость_слушателиИорганизации_LostFocus(sender As Object, e As EventArgs) Handles Ведомость_слушателиИорганизации.LostFocus
        НормальныйШрифт(Ведомость_слушателиИорганизации)
    End Sub
    Private Sub ДоверенностьПолученияБланков_GotFocus(sender As Object, e As EventArgs) Handles ДоверенностьПолученияБланков.GotFocus
        увеличитьШрифт(ДоверенностьПолученияБланков)
    End Sub
    Private Sub ДоверенностьПолученияБланков_LostFocus(sender As Object, e As EventArgs) Handles ДоверенностьПолученияБланков.LostFocus
        НормальныйШрифт(ДоверенностьПолученияБланков)
    End Sub
    Private Sub ДоверенностьПолученияБланковСлушателей_GotFocus(sender As Object, e As EventArgs) Handles ДоверенностьПолученияБланковСлушателей.GotFocus
        увеличитьШрифт(ДоверенностьПолученияБланковСлушателей)
    End Sub
    Private Sub ДоверенностьПолученияБланковСлушателей_LostFocus(sender As Object, e As EventArgs) Handles ДоверенностьПолученияБланковСлушателей.LostFocus
        НормальныйШрифт(ДоверенностьПолученияБланковСлушателей)
    End Sub
    Private Sub ВедомостьПромежуточнойАттестации_GotFocus(sender As Object, e As EventArgs) Handles ВедомостьПромежуточнойАттестации.GotFocus
        увеличитьШрифт(ВедомостьПромежуточнойАттестации)
    End Sub
    Private Sub ВедомостьПромежуточнойАттестации_LostFocus(sender As Object, e As EventArgs) Handles ВедомостьПромежуточнойАттестации.LostFocus
        НормальныйШрифт(ВедомостьПромежуточнойАттестации)
    End Sub
    Private Sub ПП_Ведомость_GotFocus(sender As Object, e As EventArgs) Handles ПП_Ведомость.GotFocus
        увеличитьШрифт(ПП_Ведомость)
    End Sub
    Private Sub ПП_Ведомость_LostFocus(sender As Object, e As EventArgs) Handles ПП_Ведомость.LostFocus
        НормальныйШрифт(ПП_Ведомость)
    End Sub
    Private Sub СправкаОбОбучении_GotFocus(sender As Object, e As EventArgs) Handles СправкаОбОбучении.GotFocus
        увеличитьШрифт(СправкаОбОбучении)
    End Sub
    Private Sub СправкаОбОбучении_LostFocus(sender As Object, e As EventArgs) Handles СправкаОбОбучении.LostFocus
        НормальныйШрифт(СправкаОбОбучении)
    End Sub
    Private Sub СправкаОбОкончании_GotFocus(sender As Object, e As EventArgs) Handles СправкаОбОкончании.GotFocus
        увеличитьШрифт(СправкаОбОкончании)
    End Sub
    Private Sub СправкаОбОкончании_LostFocus(sender As Object, e As EventArgs) Handles СправкаОбОкончании.LostFocus
        НормальныйШрифт(СправкаОбОкончании)
    End Sub

    Private Sub Педнагрузка_Click(sender As Object, e As EventArgs) Handles Педнагрузка.Click
        Dim Список
        Dim СтрокаЗапроса As String
        ActiveControl = Button2
        ВедомостьПеднагрузка.ТаблицаВедомость.Rows.Clear()
        ВедомостьПеднагрузка.НомерГруппы.Clear()

        ОчиститьПоляФормы.Очиститьформу(ВедомостьПеднагрузка)

        СтрокаЗапроса = load_prepod()
        Список = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Список(0, 0).ToString = "нет записей" Then

            предупреждение.текст.Text = "Не удалось загрузить список преподавателей"
            ОткрытьФорму(предупреждение)

            Exit Sub

        End If

        ЗагрузитьСписокВКомбоБокс(ВедомостьПеднагрузка.ТаблицаВедомость, Список, "ФИО")
        ВедомостьПеднагрузка.ShowDialog()

    End Sub


    Private Sub СправочникГруппыПК_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles СправочникГруппыПК.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Ведомость_KeyDown(sender As Object, e As KeyEventArgs) Handles Ведомость.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ИтоговаяАттествцияОценки_KeyDown(sender As Object, e As KeyEventArgs) Handles ИтоговаяАттествцияОценки.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Педнагрузка_KeyDown(sender As Object, e As KeyEventArgs) Handles Педнагрузка.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПриказОЗачислении_KeyDown(sender As Object, e As KeyEventArgs) Handles ПриказОЗачислении.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПК_Отчисление_KeyDown(sender As Object, e As KeyEventArgs) Handles ПК_Отчисление.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПК_Окончание_KeyDown(sender As Object, e As KeyEventArgs) Handles ПК_Окончание.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ППЗачисление_KeyDown(sender As Object, e As KeyEventArgs) Handles ППЗачисление.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПП_Практика_KeyDown(sender As Object, e As KeyEventArgs) Handles ПП_Практика.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПП_ДопускКИА_KeyDown(sender As Object, e As KeyEventArgs) Handles ПП_ДопускКИА.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПП_Окончание_KeyDown(sender As Object, e As KeyEventArgs) Handles ПП_Окончание.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПО_Зачисление_KeyDown(sender As Object, e As KeyEventArgs) Handles ПО_Зачисление.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПО_Практика_KeyDown(sender As Object, e As KeyEventArgs) Handles ПО_Практика.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПО_ДопускКИА_KeyDown(sender As Object, e As KeyEventArgs) Handles ПО_ДопускКИА.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПО_Окончание_KeyDown(sender As Object, e As KeyEventArgs) Handles ПО_Окончание.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    'Private Sub Стаж_зачисление_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = КлавишаПереключенияВкладок Then
    '        переключательВкладок(TabControlOther)
    '        e.Handled = True
    '    End If

    '    If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
    '        обратныйПереключательВкладок(TabControlOther)
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub Стаж_ДопускКИА_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub СтажОкончание_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПК_Окончание_уд_KeyDown(sender As Object, e As KeyEventArgs) Handles ПК_Окончание_уд.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Спецэкзамен_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПП_ПриложениеКдиплому_KeyDown(sender As Object, e As KeyEventArgs) Handles ПП_ПриложениеКдиплому.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПО_Свидетельство_KeyDown(sender As Object, e As KeyEventArgs) Handles ПО_Свидетельство.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПК_Заявление_KeyDown(sender As Object, e As KeyEventArgs) Handles ПК_Заявление.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПП_Заявление_KeyDown(sender As Object, e As KeyEventArgs) Handles ПП_Заявление.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Карточка_слушателя_KeyDown(sender As Object, e As KeyEventArgs) Handles Карточка_слушателя.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Спецэкзамен_договор_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Спецэкзамен_протокол_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Ведомость_слушателиИорганизации_KeyDown(sender As Object, e As KeyEventArgs) Handles Ведомость_слушателиИорганизации.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ДоверенностьПолученияБланков_KeyDown(sender As Object, e As KeyEventArgs) Handles ДоверенностьПолученияБланков.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ДоверенностьПолученияБланковСлушателей_KeyDown(sender As Object, e As KeyEventArgs) Handles ДоверенностьПолученияБланковСлушателей.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ВедомостьПромежуточнойАттестации_KeyDown(sender As Object, e As KeyEventArgs) Handles ВедомостьПромежуточнойАттестации.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub ПП_Ведомость_KeyDown(sender As Object, e As KeyEventArgs) Handles ПП_Ведомость.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub СправкаОбОбучении_KeyDown(sender As Object, e As KeyEventArgs) Handles СправкаОбОбучении.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub СправкаОбОкончании_KeyDown(sender As Object, e As KeyEventArgs) Handles СправкаОбОкончании.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub КнигаУчетаУдостоверений_KeyDown(sender As Object, e As KeyEventArgs) Handles КнигаУчетаУдостоверений.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub КнигаУчетаДипломов_KeyDown(sender As Object, e As KeyEventArgs) Handles КнигаУчетаДипломов.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub КнигаУчетаСвидетельств_KeyDown(sender As Object, e As KeyEventArgs) Handles КнигаУчетаСвидетельств.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub КнигаУчетаУдостоверенийФРДО_KeyDown(sender As Object, e As KeyEventArgs) Handles КнигаУчетаУдостоверенийФРДО.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub КнигаДипломовФРДО_KeyDown(sender As Object, e As KeyEventArgs) Handles КнигаДипломовФРДО.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub КнигаСвидетельствФРДО_KeyDown(sender As Object, e As KeyEventArgs) Handles КнигаСвидетельствФРДО.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_KeyDown(sender As Object, e As KeyEventArgs) Handles Button2.KeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            переключательВкладок(TabControlOther)
            e.Handled = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            обратныйПереключательВкладок(TabControlOther)
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Button2.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub СправочникГруппыПП_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles СправочникГруппыПП.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub СправочникГруппыПО_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles СправочникГруппыПО.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub КнопкаСоздатьГруппу_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles КнопкаСоздатьГруппу.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub СправочникСлушатели_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles СправочникСлушатели.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ДобавитьСлушателя_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ДобавитьСлушателя.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Ведомость_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Ведомость.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ИтоговаяАттествцияОценки_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ИтоговаяАттествцияОценки.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Педнагрузка_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Педнагрузка.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПриказОЗачислении_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПриказОЗачислении.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПК_Отчисление_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПК_Отчисление.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПК_Окончание_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПК_Окончание.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ППЗачисление_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ППЗачисление.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПП_Практика_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПП_Практика.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПП_ДопускКИА_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПП_ДопускКИА.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПП_Окончание_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПП_Окончание.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПО_Зачисление_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПО_Зачисление.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПО_Практика_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПО_Практика.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПО_ДопускКИА_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПО_ДопускКИА.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПО_Окончание_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПО_Окончание.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Стаж_зачисление_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Стаж_ДопускКИА_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub СтажОкончание_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПК_Окончание_уд_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПК_Окончание_уд.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Спецэкзамен_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПП_ПриложениеКдиплому_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПП_ПриложениеКдиплому.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПО_Свидетельство_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПО_Свидетельство.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПК_Заявление_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПК_Заявление.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПП_Заявление_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПП_Заявление.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Карточка_слушателя_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Карточка_слушателя.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Спецэкзамен_договор_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Спецэкзамен_протокол_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Ведомость_слушателиИорганизации_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Ведомость_слушателиИорганизации.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ДоверенностьПолученияБланков_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ДоверенностьПолученияБланков.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ДоверенностьПолученияБланковСлушателей_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ДоверенностьПолученияБланковСлушателей.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ВедомостьПромежуточнойАттестации_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ВедомостьПромежуточнойАттестации.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ПП_Ведомость_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ПП_Ведомость.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub СправкаОбОбучении_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles СправкаОбОбучении.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub СправкаОбОкончании_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles СправкаОбОкончании.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub Button1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Button1.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub КнигаУчетаУдостоверений_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles КнигаУчетаУдостоверений.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub КнигаУчетаДипломов_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles КнигаУчетаДипломов.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub КнигаУчетаСвидетельств_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles КнигаУчетаСвидетельств.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub КнигаУчетаУдостоверенийФРДО_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles КнигаУчетаУдостоверенийФРДО.PreviewKeyDown
        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub КнигаДипломовФРДО_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles КнигаДипломовФРДО.PreviewKeyDown

        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If

    End Sub

    Private Sub КнигаСвидетельствФРДО_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles КнигаСвидетельствФРДО.PreviewKeyDown

        If e.KeyCode = КлавишаПереключенияВкладок Then
            e.IsInputKey = True
        End If

        If e.KeyCode = КлавишаОбратногоПереключенияВкладок Then
            e.IsInputKey = True
        End If

    End Sub

    Private Sub loadProgramms()

        programms_tbl.Parent = programms_tbl_parent
        programms_tbl.Dock = DockStyle.Fill
        programms_tbl.Visible = True
        programms_tbl.number_column = 2

        programms_tbl.flag_second_control_combo = True

        programms_tbl.programm_on = True

        programms_tbl.queryString_load = programm.loadProgramms()

        programms_tbl.persent_width_column_0 = 65
        programms_tbl.persent_width_column_1 = 10
        programms_tbl.persent_width_column_2 = 0
        programms_tbl.persent_width_column_3 = 20


        programms_tbl.names.redactor_element_first = "Наименование"
        programms_tbl.names.db_element_first = "name"
        programms_tbl.names.redactor_element_second = "Часы"
        programms_tbl.names.db_element_second = "hours"
        programms_tbl.name_table = "programm"

        programm.load_hours_list()

        programms_tbl.comboBox_second_element.settings.item_list = programm.struct_progs.list_hours

        programms_tbl.kod_number = 2
        programms_tbl.table_init()

    End Sub

    Private Sub ToolStripAddProg_Click(sender As Object, e As EventArgs) Handles ToolStripAddProg.Click

        If comboBoxProgramms.Text = "" Then
            Return
        End If

        programms_tbl.add_Down()

    End Sub

    Private Sub ToolStripUpdate_Click(sender As Object, e As EventArgs)

        SplitModulsInProg.SplitterDistance = 540

    End Sub

    Private Sub ToolStripAddModul_Click(sender As Object, e As EventArgs) Handles ToolStripAddModul.Click

        If comboBoxProgramms.Text = "" Then
            Return
        End If

        SplitContainerModuls.Panel2Collapsed = False
        SplitContainerModuls.SplitterDistance = SplitContainerModuls.Height * 2 / 3
        programm.struct_progs.flag_update_modul = False

        newModAddName.Clear()
        newModAddHour.Clear()
        newModAddName.BackColor = Color.White
        newModAddHour.BackColor = Color.White

        newModAddName.Focus()

    End Sub

    Public Sub loadModulsInProgramm()


        If IsNothing(programms_tbl.selected_row) Then

            Return

        End If
        If Convert.ToString(programms_tbl.selected_row.Cells(0).Value).Trim = "" Then

            Return

        End If

        Try
            programm.struct_progs.program_kod = Convert.ToString(programms_tbl.selected_row.Cells(2).Value)
        Catch ex As Exception
            Return
        End Try

        programm.loadModulAndHours()

        tbl_moduls_sum_hours.Text = programm.struct_progs.sum_hours_programm

        dataGridModuls.DataSource = programm.struct_progs.tbl_modulsInProgs
        dataGridModuls.Columns(0).Width = dataGridModuls.Width - 70
        dataGridModuls.Columns(1).Width = 70

    End Sub

    Private Sub newProgramm_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If
    End Sub

    Private Sub dataGridProgs_MouseEnter(sender As Object, e As EventArgs)
        programm.struct_progs.flagProgTbl = True
    End Sub

    Private Sub dataGridProgs_MouseLeave(sender As Object, e As EventArgs)
        programm.struct_progs.flagProgTbl = False
    End Sub

    Private Sub comboBoxProgramms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxProgramms.SelectedIndexChanged

        If comboBoxProgramms.Text = "" Then
            Return
        End If

        programm.uroven_cval = comboBoxProgramms.Text

        loadProgramms()

        loadModul()

        loadModulsInProgramm()

    End Sub

    Private Sub loadModul()

        programm.loadModul()

        DataGridAllModuls.DataSource = programm.struct_progs.tbl_moduls
        DataGridAllModuls.Columns(0).Width = DataGridAllModuls.Width - 70
        DataGridAllModuls.Columns(1).Width = 70
        DataGridAllModuls.Columns(2).Width = 70

    End Sub

    Private Sub ToolStripTop_Click(sender As Object, e As EventArgs) Handles ToolStripTop.Click

        dataGridModuls.Focus()

        If IsNothing(dataGridModuls.CurrentCell) Then
            Return
        End If
        Dim selectedRow As Int32
        selectedRow = dataGridModuls.CurrentCell.RowIndex
        If selectedRow < 1 Then
            Return
        End If

        programm.updateMudulsTop(Convert.ToString(dataGridModuls.Rows(selectedRow).Cells(2).Value))

        loadModulsInProgramm()

        If IsNothing(dataGridModuls.Rows(selectedRow - 1)) Then
            Return
        End If

        dataGridModuls.CurrentCell = dataGridModuls.Rows(selectedRow - 1).Cells(0)

    End Sub

    Private Sub ToolStripBottom_Click(sender As Object, e As EventArgs) Handles ToolStripBottom.Click
        dataGridModuls.Focus()
        Dim selectedRow As Int32
        If IsNothing(dataGridModuls.CurrentCell) Then
            Return
        End If
        selectedRow = dataGridModuls.CurrentCell.RowIndex
        If selectedRow >= dataGridModuls.Rows.Count - 1 Then
            Return
        End If

        programm.updateMudulsBottom(Convert.ToString(dataGridModuls.Rows(selectedRow).Cells(2).Value))

        loadModulsInProgramm()

        If IsNothing(dataGridModuls.Rows(selectedRow + 1)) Then
            Return
        End If

        dataGridModuls.CurrentCell = dataGridModuls.Rows(selectedRow + 1).Cells(0)

    End Sub

    Private Sub addMidulInGroupp_Click(sender As Object, e As EventArgs) Handles addMidulInGroupp.Click
        dataGridModuls.Focus()

        If IsNothing(DataGridAllModuls.CurrentCell) Then
            Return
        End If

        Dim selectedRow As Int32
        selectedRow = DataGridAllModuls.CurrentCell.RowIndex

        If Not (IsNumeric(DataGridAllModuls.Rows(selectedRow).Cells(2).Value)) Then
            Return
        End If
        programm.updateMudulsInGroup(Convert.ToString(DataGridAllModuls.Rows(selectedRow).Cells(2).Value))

        loadModulsInProgramm()

    End Sub

    Private Sub dataGridModuls_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridModuls.CellDoubleClick

        If dataGridModuls.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(dataGridModuls.Rows(0).Cells(0).Value) = "" Then
            Return
        End If

        Dim curNumber = dataGridModuls.CurrentCell.RowIndex

        red_moduls.Text = Convert.ToString(dataGridModuls.Rows(curNumber).Cells(1).Value)
        red_moduls.BackColor = Color.AliceBlue
        programm.struct_progs.flag_update_modInProg = True
        programm.struct_progs.name_current_modul = Convert.ToString(dataGridModuls.Rows(curNumber).Cells(0).Value)
        programm.struct_progs.modul_kod = Convert.ToString(dataGridModuls.Rows(curNumber).Cells(2).Value)

        SplitModulsInProg.Panel2Collapsed = False
        SplitModulsInProg.SplitterDistance = SplitModulsInProg.Height * 2 / 3
        red_moduls.Focus()

    End Sub

    Private Sub red_moduls_KeyDown(sender As Object, e As KeyEventArgs) Handles red_moduls.KeyDown

        If e.KeyValue = Keys.Enter Then

            Dim numberRow As String
            red_moduls.Select(red_moduls.Text.Length, 0)
            SendKeys.Send("{BACKSPACE}")
            If red_moduls.Text = "" Then
                Return
            End If

            If Not IsNumeric(red_moduls.Text.Trim) Then
                Return
            End If

            If programm.struct_progs.flag_update_modInProg Then
                programm.updateModul(red_moduls.Text)
            End If

            loadModulsInProgramm()

            numberRow = ДействияСДатаГрид.dataGridViewSearchRow(dataGridModuls.Rows, 2, programm.struct_progs.modul_kod)
            dataGridModuls.CurrentCell = dataGridModuls.Rows(numberRow).Cells(0)
            dataGridModuls.Rows(numberRow).Cells(0).Selected = True

        End If

        If e.KeyValue = Keys.Escape Then

            programm.struct_progs.flagEscape = True
            programm.struct_progs.flag_update_modInProg = False
            red_moduls.Clear()
            red_moduls.BackColor = Color.White
            SplitModulsInProg.Panel2Collapsed = True
            dataGridModuls.Focus()

        End If

    End Sub

    Private Sub dataGridModuls_KeyDown(sender As Object, e As KeyEventArgs) Handles dataGridModuls.KeyDown

        If e.KeyValue = Keys.Tab Then

            ToolStrip3.Focus()
            ToolStripTop.Select()
            e.Handled = True

        ElseIf e.KeyValue = Keys.Right Then

            ToolStrip3.Focus()
            ToolStripTop.Select()
            e.Handled = True

        ElseIf e.KeyValue = Keys.Left Then

            programms_tbl.Focus()
            e.Handled = True

        ElseIf e.KeyValue = Keys.R Then

            Dim e1 As DataGridViewCellEventArgs

            dataGridModuls_CellDoubleClick(sender, e1)

        Else

            red_moduls_KeyDown(sender, e)

        End If


    End Sub

    Private Sub dataGridModuls_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles dataGridModuls.PreviewKeyDown

        If e.KeyValue = Keys.Delete Then

            Dim curNumber = dataGridModuls.CurrentCell.RowIndex
            programm.struct_progs.modul_kod = Convert.ToString(dataGridModuls.Rows(curNumber).Cells(2).Value)

            programm.deleteModul_prog()
            loadModulsInProgramm()

            If (curNumber <> 0) Then
                dataGridModuls.CurrentCell = dataGridModuls.Rows(curNumber - 1).Cells(0)
            End If

        ElseIf e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If
    End Sub

    Private Sub red_moduls_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles red_moduls.PreviewKeyDown

        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If

    End Sub

    Public Sub SplitContainerProgs_Leave(sender As Object, e As EventArgs)
        progsIndicator.Image = ImageList1.Images(8)
        programm.struct_progs.flag_update = False
        programm.struct_progs.flagEscape = True

    End Sub

    Public Sub SplitModulsInProg_Leave(sender As Object, e As EventArgs) Handles SplitModulsInProg.Leave
        modulInProgsIndicator.Image = ImageList1.Images(8)
        programm.struct_progs.flagEscape = True
        SplitModulsInProg.Panel2Collapsed = True
        red_moduls.Clear()
        red_moduls.BackColor = Color.White

    End Sub

    Private Sub newModAddName_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles newModAddName.PreviewKeyDown

        If e.KeyValue = Keys.Enter Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub newModAddHour_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles newModAddHour.PreviewKeyDown

        If e.KeyValue = Keys.Enter Or e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub newModAddName_KeyDown(sender As Object, e As KeyEventArgs) Handles newModAddName.KeyDown

        If e.KeyValue = Keys.Enter Then

            Dim kodModul As String = "0"

            newModAddName.Select(newModAddName.Text.Length, 0)
            SendKeys.Send("{BACKSPACE}")

            If Not programm.struct_progs.flag_update_modul Then
                programm.addNewModul(newModAddName.Text, newModAddHour.Text)
                loadModul()
                programm.struct_progs.modul_kod_inModuls = programm.loadLastKodModul(newModAddName.Text)
            Else
                programm.updateModuliNModuls(newModAddName.Text, newModAddHour.Text)
                loadModul()
            End If

            Dim numberRow As String = ДействияСДатаГрид.dataGridViewSearchRow(DataGridAllModuls.Rows, 2, programm.struct_progs.modul_kod_inModuls)
            DataGridAllModuls.CurrentCell = DataGridAllModuls.Rows(numberRow).Cells(0)
            DataGridAllModuls.Rows(numberRow).Cells(0).Selected = True

        End If

        If e.KeyValue = Keys.Escape Then

            programm.struct_progs.flagEscape = True
            programm.struct_progs.flag_update_modul = False

            newModAddName.Clear()
            newModAddHour.Clear()
            newModAddName.BackColor = Color.White
            newModAddHour.BackColor = Color.White

            SplitContainerModuls.Panel2Collapsed = True
            DataGridAllModuls.Focus()

        End If

    End Sub

    Private Sub newModAddHour_KeyDown(sender As Object, e As KeyEventArgs) Handles newModAddHour.KeyDown

        If e.KeyValue = Keys.Enter Then
            Dim numberRow As String

            newModAddHour.Select(newModAddHour.Text.Length, 0)
            SendKeys.Send("{BACKSPACE}")

            If Not programm.struct_progs.flag_update_modul Then
                programm.addNewModul(newModAddName.Text, newModAddHour.Text)
                loadModul()
                programm.struct_progs.modul_kod_inModuls = programm.loadLastKodModul(newModAddName.Text)
            Else
                programm.updateModuliNModuls(newModAddName.Text, newModAddHour.Text)
                loadModul()
            End If

            numberRow = ДействияСДатаГрид.dataGridViewSearchRow(DataGridAllModuls.Rows, 2, programm.struct_progs.modul_kod_inModuls)
            DataGridAllModuls.CurrentCell = DataGridAllModuls.Rows(numberRow).Cells(0)
            DataGridAllModuls.Rows(numberRow).Cells(0).Selected = True

        ElseIf e.KeyValue = Keys.Escape Then

            programm.struct_progs.flagEscape = True
            programm.struct_progs.flag_update_modul = False

            newModAddName.Clear()
            newModAddHour.Clear()
            newModAddName.BackColor = Color.White
            newModAddHour.BackColor = Color.White

            SplitContainerModuls.Panel1.Focus()
            SplitContainerModuls.Panel2Collapsed = True

        ElseIf e.KeyValue = Keys.Tab Then

            DataGridAllModuls.Focus()

        End If

    End Sub

    Private Sub DataGridAllModuls_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridAllModuls.CellDoubleClick

        If DataGridAllModuls.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(DataGridAllModuls.Rows(0).Cells(0).Value) = "" Then
            Return
        End If

        Dim curNumber = DataGridAllModuls.CurrentCell.RowIndex

        If Not IsNumeric(DataGridAllModuls.Rows(curNumber).Cells(2).Value) Then
            Return
        End If

        programm.struct_progs.modul_kod_inModuls = Convert.ToString(DataGridAllModuls.Rows(curNumber).Cells(2).Value)

        newModAddName.Text = Convert.ToString(DataGridAllModuls.Rows(curNumber).Cells(0).Value)
        newModAddName.BackColor = Color.AliceBlue
        newModAddHour.Text = Convert.ToString(DataGridAllModuls.Rows(curNumber).Cells(1).Value)
        newModAddHour.BackColor = Color.AliceBlue

        programm.struct_progs.flag_update_modul = True

        SplitContainerModuls.Panel2Collapsed = False
        SplitContainerModuls.SplitterDistance = SplitContainerModuls.Height * 2 / 3
        newModAddName.Focus()

    End Sub

    Private Sub SplitContainerModuls_Leave(sender As Object, e As EventArgs) Handles SplitContainerModuls.Leave
        modulIndicator.Image = ImageList1.Images(8)
        programm.struct_progs.flag_update_modul = False

        newModAddName.Clear()
        newModAddHour.Clear()
        newModAddName.BackColor = Color.White
        newModAddHour.BackColor = Color.White

        SplitContainerModuls.Panel2Collapsed = True

    End Sub

    Private Sub SplitModulsInProg_KeyDown(sender As Object, e As KeyEventArgs) Handles SplitModulsInProg.KeyDown

        red_moduls_KeyDown(sender, e)

    End Sub

    Private Sub DataGridAllModuls_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridAllModuls.PreviewKeyDown

        If e.KeyValue = Keys.Delete Then

            If DataGridAllModuls.Rows.Count < 0 Then
                Return
            End If

            Dim curNumber = DataGridAllModuls.CurrentCell.RowIndex

            If Not IsNumeric(DataGridAllModuls.Rows(curNumber).Cells(2).Value) Then
                Return
            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Удалить модуль: " + DataGridAllModuls.Rows(curNumber).Cells(0).Value + "?"
            ФормаДаНетУдалить.ShowDialog()

            If Not ФормаДаНетУдалить.НажатаКнопкаДа Then
                Return
            End If

            ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

            programm.deleteModul(DataGridAllModuls.Rows(curNumber).Cells(2).Value)
            loadModul()
            loadModulsInProgramm()

            If (curNumber <> 0) Then
                DataGridAllModuls.CurrentCell = DataGridAllModuls.Rows(curNumber - 1).Cells(0)
            End If

        ElseIf e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

        If password.Text = password0 Then

            SplitContainer4.Visible = True
            password.Visible = False
            comboBoxProgramms.Focus()

        End If

    End Sub

    Private Sub dataGridProgs_SelectionChanged(sender As Object, e As EventArgs)

        loadModulsInProgramm()

    End Sub

    Private Sub SplitContainerProgs_Enter(sender As Object, e As EventArgs)
        progsIndicator.Image = ImageList1.Images(9)
    End Sub

    Private Sub SplitContainerModuls_Enter(sender As Object, e As EventArgs) Handles SplitContainerModuls.Enter
        modulIndicator.Image = ImageList1.Images(9)
    End Sub

    Private Sub SplitModulsInProg_Enter(sender As Object, e As EventArgs) Handles SplitModulsInProg.Enter
        modulInProgsIndicator.Image = ImageList1.Images(9)
    End Sub

    Private Sub ДиректорФИО_TextChanged(sender As Object, e As EventArgs) Handles ДиректорФИО.TextChanged
        Dim queryString As String = ""
        queryString = updateSettings("ДиректорФИО", ДиректорФИО.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Private Sub ДиректорДолжность_TextChanged(sender As Object, e As EventArgs) Handles ДиректорДолжность.TextChanged
        Dim queryString As String = ""
        queryString = updateSettings("ДиректорДолжность", ДиректорДолжность.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Private Sub Согласовано1ПУ_TextChanged(sender As Object, e As EventArgs) Handles Согласовано1ПУ.TextChanged
        Dim queryString As String = ""
        queryString = updateSettings("Согласовано1ПУ", Согласовано1ПУ.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Private Sub Согласовано1ДолжностьПУ_TextChanged(sender As Object, e As EventArgs) Handles Согласовано1ДолжностьПУ.TextChanged
        Dim queryString As String = ""
        queryString = updateSettings("Согласовано1ДолжностьПУ", Согласовано1ДолжностьПУ.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Private Sub Согласовано2ПУ_TextChanged(sender As Object, e As EventArgs) Handles Согласовано2ПУ.TextChanged
        Dim queryString As String = ""
        queryString = updateSettings("Согласовано2ПУ", Согласовано2ПУ.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Private Sub Согласовано2ДолжностьПУ_TextChanged(sender As Object, e As EventArgs) Handles Согласовано2ДолжностьПУ.TextChanged
        Dim queryString As String = ""
        queryString = updateSettings("Согласовано2ДолжностьПУ", Согласовано2ДолжностьПУ.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Private Sub КоличествоСтрокВТаблице_TextChanged(sender As Object, e As EventArgs) Handles КоличествоСтрокВТаблице.TextChanged
        Dim queryString As String = ""
        queryString = updateSettings("КоличествоСтрокВТаблице", КоличествоСтрокВТаблице.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
    End Sub

    Private Sub ПоискСлушателейПоУм_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ПоискСлушателейПоУм.SelectedIndexChanged

        Dim queryString As String = ""
        queryString = updateSettings("ПоискСлушателейПоУм", ПоискСлушателейПоУм.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
        If ПоискСлушателейПоУм.Text <> "" Then
            НастройкаПоискаСлушателей.checkedAnyValue(ПоискСлушателейПоУм.Text)
        End If

    End Sub

    Private Sub ПоискГруппПоУм_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ПоискГруппПоУм.SelectedIndexChanged

        Dim queryString As String = ""
        queryString = updateSettings("ПоискГруппПоУм", ПоискГруппПоУм.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
        If ПоискГруппПоУм.Text <> "" Then
            НастройкаПоискаГрупп.checkedAnyValue(ПоискГруппПоУм.Text)
        End If

    End Sub

    Private Sub НастройкаСортировкиСлушателей_SelectedIndexChanged(sender As Object, e As EventArgs) Handles НастройкаСортировкиСлушателей.SelectedIndexChanged

        Dim queryString As String = ""
        queryString = updateSettings("НастройкаСортировкиСлушателей", НастройкаСортировкиСлушателей.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
        If НастройкаСортировкиСлушателей.Text <> "" Then
            WindowsApp2.НастройкаСортировкиСлушателей.checkedAnyValue(НастройкаСортировкиСлушателей.Text)
        End If

    End Sub

    Private Sub НастройкаСортировкиГрупп_SelectedIndexChanged(sender As Object, e As EventArgs) Handles НастройкаСортировкиГрупп.SelectedIndexChanged
        Dim queryString As String = ""
        queryString = updateSettings("НастройкаСортировкиГрупп", НастройкаСортировкиГрупп.Text)
        mySqlConnect.ОтправитьВбдЗапись(queryString, 1)
        If НастройкаСортировкиГрупп.Text <> "" Then
            WindowsApp2.НастройкаСортировкиГрупп.checkedAnyValue(НастройкаСортировкиГрупп.Text)
        End If

    End Sub

    Private Sub passwordOther_TextChanged(sender As Object, e As EventArgs) Handles passwordOther.TextChanged

        If passwordOther.Text = password0 Then

            SplitContainerOther.Visible = True
            passwordOther.Visible = False
            ToolStrip_name_list.Focus()
            worker.loadLists()
            worker_dolgnost.Items.AddRange(worker.worker_struct.worker_dolj)
            worker_type.Items.AddRange(worker.worker_struct.worker_type_list)

        End If

    End Sub

    Private Sub ToolStrip_name_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStrip_name_list.SelectedIndexChanged

        If ToolStrip_name_list.Text = "" Then

            Return

        End If

        If ToolStrip_name_list.Text = "Преподаватели" Then

            tbl_obrazovanie.Visible = False
            SplitContainerOtherList.Visible = True
            ToolStripButton1.Visible = True
            SplitContainerOtherList.Panel2Collapsed = True
            DataGridView_list.Visible = True
            loadTblWorker()

        ElseIf ToolStrip_name_list.Text = "Должности" Then

            SplitContainerOtherList.Visible = False
            ToolStripButton1.Visible = False
            connect_table_doljnosti()

        ElseIf ToolStrip_name_list.Text = "Организации" Then

            SplitContainerOtherList.Visible = False
            ToolStripButton1.Visible = False
            connect_table_organization()

        ElseIf ToolStrip_name_list.Text = "Образование" Then

            SplitContainerOtherList.Visible = False
            ToolStripButton1.Visible = False
            connect_table_obrazovanie()

        End If

    End Sub

    Private Sub connect_table_doljnosti()

        tbl_obrazovanie.Parent = Panel_main
        tbl_obrazovanie.Visible = True
        tbl_obrazovanie.Dock = DockStyle.Fill
        tbl_obrazovanie.number_column = 1

        tbl_obrazovanie.queryString_load = sqlQueryString.load_list_doljnosti()

        tbl_obrazovanie.persent_width_column_0 = 100
        tbl_obrazovanie.persent_width_column_1 = 0

        tbl_obrazovanie.names.redactor_element_first = "Наименование"
        tbl_obrazovanie.names.db_element_first = "name"
        tbl_obrazovanie.name_table = "doljnost"

        tbl_obrazovanie.kod_number = 1

        tbl_obrazovanie.table_init()

    End Sub

    Private Sub connect_table_obrazovanie()

        tbl_obrazovanie.Parent = Panel_main
        tbl_obrazovanie.Visible = True
        tbl_obrazovanie.Dock = DockStyle.Fill
        tbl_obrazovanie.number_column = 1

        tbl_obrazovanie.queryString_load =
            "SELECT
                  name AS 'Вид документа',
                  kod
                FROM doo_vid_dok
                ORDER BY name"

        tbl_obrazovanie.persent_width_column_0 = 100
        tbl_obrazovanie.persent_width_column_1 = 0

        tbl_obrazovanie.names.redactor_element_first = "Наименование"
        tbl_obrazovanie.names.db_element_first = "name"
        tbl_obrazovanie.name_table = "doo_vid_dok"

        tbl_obrazovanie.kod_number = 1

        tbl_obrazovanie.table_init()

    End Sub

    Private Sub connect_table_organization()

        tbl_obrazovanie.Parent = Panel_main
        tbl_obrazovanie.Visible = True
        tbl_obrazovanie.Dock = DockStyle.Fill
        tbl_obrazovanie.number_column = 2

        tbl_obrazovanie.queryString_load = sqlQueryString.load_list_organization()

        tbl_obrazovanie.persent_width_column_0 = 30
        tbl_obrazovanie.persent_width_column_1 = 70
        tbl_obrazovanie.persent_width_column_2 = 0

        tbl_obrazovanie.names.redactor_element_first = "Наименование"
        tbl_obrazovanie.names.redactor_element_second = "Полное наименование"
        tbl_obrazovanie.names.db_element_first = "name"
        tbl_obrazovanie.names.db_element_second = "full_name"
        tbl_obrazovanie.name_table = "napr_organization"

        tbl_obrazovanie.kod_number = 2

        tbl_obrazovanie.table_init()

    End Sub


    Private Sub loadTblWorker()

        worker.loadWorker()

        DataGridView_list.Rows.Clear()

        Dim count As Integer = 0
        For Each row As List(Of String) In worker.listWorkers

            count = DataGridView_list.Rows.Add()
            DataGridView_list.Rows(count).Cells(0).Value = Convert.ToBoolean(row(0))
            DataGridView_list.Rows(count).Cells(1).Value = row(1)
            DataGridView_list.Rows(count).Cells(2).Value = row(2)
            DataGridView_list.Rows(count).Cells(3).Value = row(3)
            DataGridView_list.Rows(count).Cells(4).Value = row(4)
            DataGridView_list.Rows(count).Cells(5).Value = row(5)
            DataGridView_list.Rows(count).Cells(6).Value = row(6)

        Next

        DataGridView_list.Columns(0).Width = 40
        DataGridView_list.Columns(1).Width = 200
        DataGridView_list.Columns(2).Width = 300
        DataGridView_list.Columns(3).Width = 300
        DataGridView_list.Columns(5).Width = 100
        DataGridView_list.Columns(4).Width = DataGridView_list.Width - DataGridView_list.Columns(0).Width -
        DataGridView_list.Columns(1).Width - DataGridView_list.Columns(2).Width - DataGridView_list.Columns(3).Width - DataGridView_list.Columns(5).Width
        DataGridView_list.Columns(6).Visible = False

    End Sub

    Private Sub other_add_Click(sender As Object, e As EventArgs) Handles other_add.Click

        If DataGridView_list.Visible Then

            redactorOpen(sender, e)

        ElseIf tbl_obrazovanie.Visible Then

            tbl_obrazovanie.redactorOpen()
            SplitContainerOtherList.Panel2Collapsed = True

        End If



    End Sub

    Private Sub redactorOpen(sender As Object, e As EventArgs)

        If ToolStrip_name_list.Text = "" Then

            Return

        ElseIf ToolStrip_name_list.Text = "Преподаватели" Then

            SplitContainerOtherList.Panel2Collapsed = False
            SplitContainerOtherList.SplitterDistance = SplitContainerOtherList.Height - 205
            ButtonFK.Focus()
            clear_panel_worker(sender, e)
            ActiveControl = ButtonFK

        End If

    End Sub

    Private Sub clear_panel_worker(sender As Object, e As EventArgs)

        worker_name.Clear()
        worker_name.BackColor = Color.White
        worker_name.Focus()

        For Each element As TextBox In panel_worker.Controls.OfType(Of TextBox)
            If element.Name <> "TextBoxS" Then
                element.Clear()
                element.BackColor = Color.White
            End If
        Next

        worker_dolgnost.Text = "нет"
        worker_type.Text = worker.default_type

        worker_name_Leave(sender, e)
        worker_name_pad_Leave(sender, e)
        worker_name_full_Leave(sender, e)

    End Sub

    Private Sub selectRowInListWorker()
        Dim numberRow As Integer = -1
        If worker.worker_struct.kod = -1 Then
            Return
        End If
        numberRow = ДействияСДатаГрид.dataGridViewSearchRow(DataGridView_list.Rows, 6, Convert.ToString(worker.worker_struct.kod))
        DataGridView_list.CurrentCell = DataGridView_list.Rows(numberRow).Cells(0)
        DataGridView_list.Rows(numberRow).Cells(0).Selected = True
    End Sub

    Private Sub closeRedactorWorker(sender As Object, e As KeyEventArgs)

        If redactor_enter = False Or SplitContainerOtherList.Panel2Collapsed Then

            Return

        End If

        clear_panel_worker(sender, e)
        worker.flagUpdate = False
        SplitContainerOtherList.Panel2Collapsed = True
        SplitContainerOtherList.Focus()

    End Sub

    Private Sub worker_DeleteDown(sender, e)

        Dim curNumber = DataGridView_list.CurrentCell.RowIndex
        ФормаДаНетУдалить.текстДаНет.Text = "Удалить " + DataGridView_list.Rows(curNumber).Cells(1).Value + "?"
        ФормаДаНетУдалить.ShowDialog()

        If Not ФормаДаНетУдалить.НажатаКнопкаДа Then
            Return
        End If

        ФормаДаНетУдалить.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"

        worker.worker_struct.kod = Convert.ToInt64(DataGridView_list.Rows(curNumber).Cells(6).Value)

        If Not worker.removeWorker() Then
            предупреждение.TextBox.Visible = False
            предупреждение.текст.Visible = True
            предупреждение.текст.Text = "Сотрудник не может быть удален"
            предупреждение.ShowDialog()
            Return
        End If

        If worker_name.Text.Trim = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(1).Value) Then
            SendKeys.Send("{ESC}")
        End If

        ToolStrip_name_list_SelectedIndexChanged(sender, e)

        If (curNumber <> 0) Then
            DataGridView_list.CurrentCell = DataGridView_list.Rows(curNumber - 1).Cells(0)
        End If

        АСформироватьПриказ.reload_lists()

    End Sub

    Private Sub worker_EnterDown()

        If redactor_enter = False Or SplitContainerOtherList.Panel2Collapsed Or worker_dolgnost.DroppedDown Or worker_type.DroppedDown Then

            Return

        End If

        saveWorker()
        selectRowInListWorker()

    End Sub

    Private Sub saveWorker()

        Dim message As String

        If worker_name.Text.Trim = "ФИО" Or worker_name.Text.Trim = "" Or ToolStrip_name_list.Text.Trim = "" Then
            Return
        End If

        Dim result() As String
        message = worker_name.Text.Trim
        result = message.Split(" ")

        If result.Count = 1 Then
            message = "Введите ФИО в форме 'Фамилия И.О.' (один пробел после фамилии)"
        ElseIf result.Count > 2 Then
            message = "Удалите лишние пробелы! Введите ФИО в форме 'Фамилия И.О.' (один пробел после фамилии)"
        End If

        If Not result.Count = 2 Then

            предупреждение.TextBox.Visible = False
            предупреждение.текст.Text = message
            предупреждение.ShowDialog()
            worker_name.Select(worker_name.Text.Length, 0)

        End If


        worker.worker_struct.name = worker_name.Text.Trim

        If worker_name_full.Text.Trim <> "Фамилия Имя Отчество" Then
            worker.worker_struct.name_full = worker_name_full.Text.Trim
        Else
            worker.worker_struct.name_full = ""
        End If

        If worker_name_pad.Text.Trim <> "Фамилия Имя Отчество РП" Then
            worker.worker_struct.name_pad = worker_name_pad.Text.Trim
        Else
            worker.worker_struct.name_pad = ""
        End If

        worker.worker_struct.worker_doljnost = worker_dolgnost.Text
        worker.worker_struct.worker_type = worker_type.Text

        If worker.flagUpdate Then

            worker.updateWorker()

        Else

            If Not worker.checkWorker() Then

                Return

            End If

            worker.addWorker()

        End If

        loadTblWorker()
        АСформироватьПриказ.reload_lists()

    End Sub

    Private Sub worker_name_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles worker_name.PreviewKeyDown
        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub worker_name_full_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles worker_name_full.PreviewKeyDown
        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub worker_name_pad_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles worker_name_pad.PreviewKeyDown
        If e.KeyValue = Keys.Enter Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub worker_name_Leave(sender As Object, e As EventArgs) Handles worker_name.Leave
        If worker_name.Text.Trim = "" Then
            worker_name.Text = "ФИО"
            worker_name.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub worker_name_Enter(sender As Object, e As EventArgs) Handles worker_name.Enter
        If worker_name.Text.Trim = "ФИО" Then
            worker_name.Text = ""
            worker_name.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_full_Enter(sender As Object, e As EventArgs) Handles worker_name_full.Enter
        If worker_name_full.Text.Trim = "Фамилия Имя Отчество" Then
            worker_name_full.Text = ""
            worker_name_full.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_full_Leave(sender As Object, e As EventArgs) Handles worker_name_full.Leave
        If worker_name_full.Text.Trim = "" Then
            worker_name_full.Text = "Фамилия Имя Отчество"
            worker_name_full.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub worker_name_pad_Enter(sender As Object, e As EventArgs) Handles worker_name_pad.Enter
        If worker_name_pad.Text.Trim = "Фамилия Имя Отчество РП" Then
            worker_name_pad.Text = ""
            worker_name_pad.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_pad_Leave(sender As Object, e As EventArgs) Handles worker_name_pad.Leave
        If worker_name_pad.Text.Trim = "" Then
            worker_name_pad.Text = "Фамилия Имя Отчество РП"
            worker_name_pad.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub DataGridView_list_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView_list.KeyDown

        If e.KeyValue = Keys.Delete Then

            worker_DeleteDown(sender, e)

        ElseIf e.KeyValue = Keys.Add Then

            If Not ToolStrip_name_list.Text.Trim = "" Then
                other_add_Click(sender, e)
            End If

        ElseIf e.KeyValue = Keys.R Then

            If Not ToolStrip_name_list.Text.Trim = "" Then

                Dim e1 As DataGridViewCellEventArgs
                DataGridView_list_CellDoubleClick(sender, e1)

            End If

        ElseIf e.KeyValue = Keys.Tab Then

            If SplitContainerOtherList.Panel2Collapsed Then

                ToolStrip_name_list.Focus()
                e.Handled = True

            Else

                panel_worker.Select()
                e.Handled = True

            End If

        ElseIf e.KeyValue = Keys.Enter Then

            If Not DataGridView_list.ReadOnly Then

                If DataGridView_list.RowCount < 1 Then

                    Return

                ElseIf DataGridView_list.SelectedRows.Count < 1 Then

                    Return

                ElseIf DataGridView_list.SelectedRows(0).Cells(1).Value.Trim = "" Then

                    Return

                End If

                DataGridView_list.SelectedRows(0).Cells(0).Value = Not DataGridView_list.SelectedRows(0).Cells(0).Value

            End If

        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If DataGridView_list.ReadOnly Then

            DataGridView_list.ReadOnly = False
            ToolStripButton1.Image = ImageList40.Images(3)
            worker.flagRedactor = True
            ActiveControl = DataGridView_list

        Else

            DataGridView_list.ReadOnly = True
            ToolStripButton1.Image = ImageList40.Images(2)
            worker.flagRedactor = False
            ActiveControl = DataGridView_list

        End If

    End Sub

    Private Sub DataGridView_list_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_list.CellEndEdit
        If e.ColumnIndex = 0 Then
            If worker.flagRedactor Then
                worker.worker_struct.kod = Convert.ToInt64(DataGridView_list.Rows(e.RowIndex).Cells(6).Value)
                worker.worker_struct.worker_check = Convert.ToInt16(DataGridView_list.Rows(e.RowIndex).Cells(0).Value)
                worker.update_status_list()
            End If
        End If
    End Sub

    Private Sub DataGridView_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_list.CellDoubleClick

        If DataGridView_list.Rows.Count < 0 Then
            Return
        ElseIf Convert.ToString(DataGridView_list.Rows(0).Cells(0).Value) = "" Then
            Return
        End If

        Dim curNumber = DataGridView_list.CurrentCell.RowIndex

        If IsNumeric(DataGridView_list.Rows(curNumber).Cells(6).Value) Then
            worker.worker_struct.kod = Convert.ToInt64(DataGridView_list.Rows(curNumber).Cells(6).Value)
        Else
            Return
        End If

        SplitContainerOtherList.Panel2Collapsed = False

        redactorOpen(sender, e)

        worker_name.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(1).Value)
        worker_name.BackColor = Color.AliceBlue
        worker_name_Leave(sender, e)
        worker_name_full.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(2).Value)
        worker_name_full.BackColor = Color.AliceBlue
        worker_name_full_Leave(sender, e)
        worker_name_pad.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(3).Value)
        worker_name_pad.BackColor = Color.AliceBlue
        worker_name_pad_Leave(sender, e)
        worker_dolgnost.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(4).Value)
        worker_type.Text = Convert.ToString(DataGridView_list.Rows(curNumber).Cells(5).Value)

        worker.flagUpdate = True
        ButtonFK.Focus()

    End Sub

    Private Sub worker_name_TextChanged(sender As Object, e As EventArgs) Handles worker_name.TextChanged
        If Not worker_name.Text.Trim = "ФИО" Then
            worker_name.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_full_TextChanged(sender As Object, e As EventArgs) Handles worker_name_full.TextChanged
        If Not worker_name_full.Text.Trim = "Фамилия Имя Отчество" Then
            worker_name_full.ForeColor = Color.Black
        End If
    End Sub

    Private Sub worker_name_pad_TextChanged(sender As Object, e As EventArgs) Handles worker_name_pad.TextChanged
        If Not worker_name_pad.Text.Trim = "Фамилия Имя Отчество РП" Then
            worker_name_pad.ForeColor = Color.Black
        End If
    End Sub

    Private Sub passwrdSetts_TextChanged(sender As Object, e As EventArgs) Handles passwrdSetts.TextChanged

        If passwrdSetts.Text = password0 Then
            PanelSetts.Visible = True
            passwrdSetts.Visible = False
        End If

    End Sub

    Private Sub DataGridAllModuls_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridAllModuls.KeyDown

        If e.KeyValue = Keys.Tab Then

            comboBoxProgramms.Focus()
            e.Handled = True

        ElseIf e.KeyValue = Keys.Add Then

            If Not comboBoxProgramms.Text.Trim = "" Then

                ToolStripAddModul_Click(sender, e)

            End If

        ElseIf e.KeyValue = Keys.Left Then

            ToolStrip3.Focus()
            addMidulInGroupp.Select()

        ElseIf e.KeyValue = Keys.R Then

            Dim e1 As DataGridViewCellEventArgs

            DataGridAllModuls_CellDoubleClick(sender, e1)

        End If

    End Sub

    Private Sub ToolStrip2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ToolStrip2.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub ToolStrip2_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStrip2.KeyDown

        If e.KeyValue = Keys.Tab Then

            ActiveControl = programms_tbl
            e.Handled = True

        End If

    End Sub

    Private Sub comboBoxProgramms_Enter(sender As Object, e As EventArgs) Handles comboBoxProgramms.Enter

        comboBoxProgramms.DroppedDown = True

    End Sub

    Private Sub comboBoxProgramms_Leave(sender As Object, e As EventArgs) Handles comboBoxProgramms.Leave

        comboBoxProgramms.DroppedDown = False

    End Sub

    Private Sub ToolStrip3_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ToolStrip3.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If


    End Sub

    Private Sub ToolStrip3_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStrip3.KeyDown

        If e.KeyValue = Keys.Tab Then

            ActiveControl = DataGridAllModuls
            e.Handled = True

        ElseIf e.KeyValue = Keys.Left Then

            ActiveControl = dataGridModuls
            e.Handled = True

        ElseIf e.KeyValue = Keys.Right Then

            ActiveControl = DataGridAllModuls
            e.Handled = True

        End If

    End Sub

    Private Sub ToolStrip_name_list_Enter(sender As Object, e As EventArgs) Handles ToolStrip_name_list.Enter

        If flag_ToolStrip_name_list Then
            ToolStrip_name_list.DroppedDown = False
        Else
            ToolStrip_name_list.DroppedDown = True
        End If

    End Sub

    Private Sub ToolStrip_name_list_Leave(sender As Object, e As EventArgs) Handles ToolStrip_name_list.Leave

        ToolStrip_name_list.DroppedDown = False

    End Sub

    Private Sub ToolStrip1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ToolStrip1.PreviewKeyDown
        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        End If
    End Sub

    Private Sub DataGridDoljnost_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub ToolStrip1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStrip1.KeyDown

        If e.KeyValue = Keys.Tab Then

            If tbl_obrazovanie.Visible Then

                ActiveControl = tbl_obrazovanie

            ElseIf DataGridView_list.Visible Then

                ActiveControl = DataGridView_list
                e.Handled = True
            End If

        End If

    End Sub

    Private Sub DataGridView_list_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridView_list.PreviewKeyDown

        If e.KeyValue = Keys.Tab Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Left Then

            e.IsInputKey = True

        ElseIf e.KeyValue = Keys.Right Then

            e.IsInputKey = True

        End If

    End Sub

    Private Sub worker_dolgnost_Enter(sender As Object, e As EventArgs) Handles worker_dolgnost.Enter

        If flag_worker_dolgnost Then
            worker_dolgnost.DroppedDown = False
        Else
            worker_dolgnost.DroppedDown = True
        End If

    End Sub

    Private Sub worker_dolgnost_Leave(sender As Object, e As EventArgs) Handles worker_dolgnost.Leave

        worker_dolgnost.DroppedDown = False

    End Sub

    Private Sub worker_type_Enter(sender As Object, e As EventArgs) Handles worker_type.Enter

        If flag_worker_type Then
            worker_type.DroppedDown = False
        Else
            worker_type.DroppedDown = True
        End If

    End Sub

    Private Sub worker_type_Leave(sender As Object, e As EventArgs) Handles worker_type.Leave

        worker_type.DroppedDown = False

    End Sub

    Private Sub ToolStrip_name_list_MouseMove(sender As Object, e As MouseEventArgs) Handles ToolStrip_name_list.MouseMove

        flag_ToolStrip_name_list = True

    End Sub

    Private Sub ToolStrip_name_list_MouseLeave(sender As Object, e As EventArgs) Handles ToolStrip_name_list.MouseLeave

        flag_ToolStrip_name_list = False

    End Sub

    Private Sub worker_dolgnost_MouseMove(sender As Object, e As MouseEventArgs) Handles worker_dolgnost.MouseMove

        flag_worker_dolgnost = True

    End Sub

    Private Sub worker_dolgnost_MouseLeave(sender As Object, e As EventArgs) Handles worker_dolgnost.MouseLeave

        flag_worker_dolgnost = False

    End Sub

    Private Sub worker_type_MouseMove(sender As Object, e As MouseEventArgs) Handles worker_type.MouseMove

        flag_worker_type = True

    End Sub

    Private Sub worker_type_MouseLeave(sender As Object, e As EventArgs) Handles worker_type.MouseLeave

        flag_worker_type = False

    End Sub

    Private Sub SplitContainerOtherList_Enter(sender As Object, e As EventArgs) Handles SplitContainerOtherList.Enter

        redactor_enter = True

    End Sub

    Private Sub SplitContainerOtherList_Leave(sender As Object, e As EventArgs) Handles SplitContainerOtherList.Leave

        redactor_enter = False

    End Sub

    Private Sub worker_name_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_name.KeyDown

        redactor_worker_activator(sender, e)

    End Sub

    Private Sub worker_name_full_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_name_full.KeyDown

        redactor_worker_activator(sender, e)

    End Sub

    Private Sub worker_name_pad_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_name_pad.KeyDown

        redactor_worker_activator(sender, e)

    End Sub

    Private Sub worker_dolgnost_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_dolgnost.KeyDown

        If Not worker_dolgnost.DroppedDown Then

            redactor_worker_activator(sender, e)

        End If

    End Sub

    Private Sub worker_type_KeyDown(sender As Object, e As KeyEventArgs) Handles worker_type.KeyDown

        If Not worker_type.DroppedDown Then

            redactor_worker_activator(sender, e)

        End If

    End Sub

    Sub redactor_worker_activator(control As Control, e As KeyEventArgs)

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then

            Dim index As Integer = control.TabIndex
            Dim flag_ok As Boolean = False

            For Each element As Control In panel_worker.Controls

                If element.GetType.ToString <> "System.Windows.Forms.TextBox" And element.GetType.ToString <> "System.Windows.Forms.ComboBox" Then

                    Continue For

                End If

                If e.KeyCode = Keys.Down Then

                    If element.TabIndex = index + 1 And element.Name <> "spravka" Then

                        ActiveControl = element
                        element.Select()
                        element.Focus()
                        flag_ok = True
                        Exit For

                    End If

                Else

                    If element.TabIndex = index - 1 And element.Name <> "spravka" Then

                        ActiveControl = element
                        flag_ok = True
                        Exit For

                    End If

                End If

            Next

            If Not flag_ok Then

                ActiveControl = DataGridView_list

            End If

            e.Handled = True

        End If

    End Sub

    Private Sub programms_tbl_Click(sender As Object, e As EventArgs)

    End Sub
End Class