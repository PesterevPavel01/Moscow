﻿Imports System.Threading
Imports System.IO

Module Запуск
    Public Открыть As Boolean = False
    Public АдрессОбщейБазы As String
    Dim SC As SynchronizationContext
    Public АдрессЛичнойКопииБазы, ПутьКФайлуRes As String
    Public МассивЗапросов
    Public РазрешитьЗавершениеРаботы As Boolean = False
    Sub ЗапускПриложения()

        ПутьКФайлуRes = ПутьККаталогуСРесурсами()
        work()
        ААОсновная.Show()

    End Sub
    Sub work()

        Dim НастройкиПоУм

        НастройкиПоУм = ЗагрузкаПараметровПриложения()
        ЗаписьСохраненныхНастроек(НастройкиПоУм)

    End Sub
    Function ЗагрузкаПараметровПриложения() As Object
        Dim Параметры
        Dim СтрокаЗапроса As String
        Dim mySqlConnector As New MySQLConnect

        mySqlConnector.mySqlSettings.ИмяБазыДанныхА = "database"
        mySqlConnector.mySqlSettings.ИмяПользователя = "admin"
        mySqlConnector.mySqlSettings.пароль = "admin"
        mySqlConnector.mySqlSettings.ИсточникДанныхODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlConnector.mySqlSettings.НазваниеСервера = "localhost"

        СтрокаЗапроса = loadSettings()
        Параметры = mySqlConnector.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1)
        Параметры = УбратьПустотыВМассиве.УбратьПустотыВМассиве(Параметры)
        ЗагрузкаПараметровПриложения = Параметры
    End Function

    Sub ЗаписьСохраненныхНастроек(параметры As Object)

        If Not ЗначениеПараметра(параметры, "ДиректорФИО") = "Не найден" Then
            ААОсновная.ДиректорФИО.Text = ЗначениеПараметра(параметры, "ДиректорФИО")
        End If

        If Not ЗначениеПараметра(параметры, "0") = "Не найден" Then
            ААОсновная.password0 = ЗначениеПараметра(параметры, "0")
        End If

        If Not ЗначениеПараметра(параметры, "ДиректорДолжность") = "Не найден" Then
            ААОсновная.ДиректорДолжность.Text = ЗначениеПараметра(параметры, "ДиректорДолжность")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано1ПУ") = "Не найден" Then
            ААОсновная.Согласовано1ПУ.Text = ЗначениеПараметра(параметры, "Согласовано1ПУ")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано2ПУ") = "Не найден" Then
            ААОсновная.Согласовано2ПУ.Text = ЗначениеПараметра(параметры, "Согласовано2ПУ")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано1ДолжностьПУ") = "Не найден" Then
            ААОсновная.Согласовано1ДолжностьПУ.Text = ЗначениеПараметра(параметры, "Согласовано1ДолжностьПУ")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано2ДолжностьПУ") = "Не найден" Then
            ААОсновная.Согласовано2ДолжностьПУ.Text = ЗначениеПараметра(параметры, "Согласовано2ДолжностьПУ")
        End If

        If Not ЗначениеПараметра(параметры, "ПоискСлушателейПоУм") = "Не найден" Then
            ААОсновная.ПоискСлушателейПоУм.Text = ЗначениеПараметра(параметры, "ПоискСлушателейПоУм")
        Else
            ААОсновная.ПоискСлушателейПоУм.Text = "Снилс"
        End If

        ВключитьНастройкуПоиска(НастройкаПоискаСлушателей, ААОсновная.ПоискСлушателейПоУм.Text)

        If Not ЗначениеПараметра(параметры, "ПоискГруппПоУм") = "Не найден" Then
            ААОсновная.ПоискГруппПоУм.Text = ЗначениеПараметра(параметры, "ПоискГруппПоУм")
        Else
            ААОсновная.ПоискГруппПоУм.Text = "Номер"
        End If
        ВключитьНастройкуПоиска(НастройкаПоискаГрупп, ААОсновная.ПоискГруппПоУм.Text)

        If Not ЗначениеПараметра(параметры, "НастройкаСортировкиГрупп") = "Не найден" Then
            ААОсновная.НастройкаСортировкиГрупп.Text = ЗначениеПараметра(параметры, "НастройкаСортировкиГрупп")
        Else
            ААОсновная.НастройкаСортировкиГрупп.Text = "Номер"
        End If
        ВключитьНастройкуПоиска(НастройкаСортировкиГрупп, ААОсновная.НастройкаСортировкиГрупп.Text)

        If Not ЗначениеПараметра(параметры, "НастройкаСортировкиСлушателей") = "Не найден" Then
            ААОсновная.НастройкаСортировкиСлушателей.Text = ЗначениеПараметра(параметры, "НастройкаСортировкиСлушателей")
        Else
            ААОсновная.НастройкаСортировкиСлушателей.Text = "Снилс"
        End If
        ВключитьНастройкуПоиска(НастройкаСортировкиСлушателей, ААОсновная.НастройкаСортировкиСлушателей.Text)

        If Not ЗначениеПараметра(параметры, "КоличествоСтрокВТаблице") = "Не найден" Then
            ААОсновная.КоличествоСтрокВТаблице.Text = ЗначениеПараметра(параметры, "КоличествоСтрокВТаблице")
        Else
            ААОсновная.КоличествоСтрокВТаблице.Text = 1000
        End If

    End Sub
    Function ЗначениеПараметра(Параметры As Object, Параметр As String) As String
        If Параметры(0, 0) = "нет записей" Then
            ЗначениеПараметра = "Не найден"
            Exit Function
        End If

        For счетчик = 0 To UBound(Параметры, 2)

            If Параметры(0, счетчик) = Параметр Then

                If Параметры(1, счетчик) = "" Then
                    ЗначениеПараметра = "Не найден"
                    Exit Function
                Else
                    ЗначениеПараметра = Параметры(1, счетчик)
                End If
                Exit Function

            End If

        Next

        ЗначениеПараметра = "Не найден"

    End Function

End Module
