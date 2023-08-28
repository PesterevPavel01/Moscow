Imports System.Threading
Imports System.IO

Module Запуск
    Public Открыть As Boolean = False
    Public АдрессОбщейБазы As String
    Dim SC As SynchronizationContext
    Public АдрессЛичнойКопииБазы, ПутьКФайлуRes As String
    Public МассивЗапросов
    Public РазрешитьЗавершениеРаботы As Boolean = False
    Sub ЗапускПриложения()

        ПутьКФайлуRes = resourcesPath()
        work()
        MainForm.Show()

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

        mySqlConnector.mySqlSettings.nameFirstDB = "database"
        mySqlConnector.mySqlSettings.userName = "admin"
        mySqlConnector.mySqlSettings.password = "admin"
        mySqlConnector.mySqlSettings.ODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlConnector.mySqlSettings.server = "localhost"

        СтрокаЗапроса = loadSettings()
        Параметры = mySqlConnector.loadMySqlToArray(СтрокаЗапроса, 1)
        Параметры = УбратьПустотыВМассиве.УбратьПустотыВМассиве(Параметры)
        ЗагрузкаПараметровПриложения = Параметры
    End Function

    Sub ЗаписьСохраненныхНастроек(параметры As Object)

        If Not ЗначениеПараметра(параметры, "ДиректорФИО") = "Не найден" Then
            MainForm.ДиректорФИО.Text = ЗначениеПараметра(параметры, "ДиректорФИО")
        End If

        If Not ЗначениеПараметра(параметры, "0") = "Не найден" Then
            MainForm.password0 = ЗначениеПараметра(параметры, "0")
        End If

        If Not ЗначениеПараметра(параметры, "ДиректорДолжность") = "Не найден" Then
            MainForm.ДиректорДолжность.Text = ЗначениеПараметра(параметры, "ДиректорДолжность")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано1ПУ") = "Не найден" Then
            MainForm.Согласовано1ПУ.Text = ЗначениеПараметра(параметры, "Согласовано1ПУ")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано2ПУ") = "Не найден" Then
            MainForm.Согласовано2ПУ.Text = ЗначениеПараметра(параметры, "Согласовано2ПУ")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано1ДолжностьПУ") = "Не найден" Then
            MainForm.Согласовано1ДолжностьПУ.Text = ЗначениеПараметра(параметры, "Согласовано1ДолжностьПУ")
        End If

        If Not ЗначениеПараметра(параметры, "Согласовано2ДолжностьПУ") = "Не найден" Then
            MainForm.Согласовано2ДолжностьПУ.Text = ЗначениеПараметра(параметры, "Согласовано2ДолжностьПУ")
        End If

        If Not ЗначениеПараметра(параметры, "ПоискСлушателейПоУм") = "Не найден" Then
            MainForm.students__defaultSearchSetts.Text = ЗначениеПараметра(параметры, "ПоискСлушателейПоУм")
        Else
            MainForm.students__defaultSearchSetts.Text = "Снилс"
        End If

        searchInit(НастройкаПоискаСлушателей, MainForm.students__defaultSearchSetts.Text)

        If Not ЗначениеПараметра(параметры, "ПоискГруппПоУм") = "Не найден" Then
            MainForm.group_dafaultSearchSetts.Text = ЗначениеПараметра(параметры, "ПоискГруппПоУм")
        Else
            MainForm.group_dafaultSearchSetts.Text = "Номер"
        End If
        searchInit(group__serchSettings, MainForm.group_dafaultSearchSetts.Text)

        If Not ЗначениеПараметра(параметры, "НастройкаСортировкиГрупп") = "Не найден" Then
            MainForm.group__dafaultSortSetts.Text = ЗначениеПараметра(параметры, "НастройкаСортировкиГрупп")
        Else
            MainForm.group__dafaultSortSetts.Text = "Номер"
        End If
        searchInit(sortSettsGroup, MainForm.group__dafaultSortSetts.Text)

        If Not ЗначениеПараметра(параметры, "НастройкаСортировкиСлушателей") = "Не найден" Then
            MainForm.students__defaultSortSetts.Text = ЗначениеПараметра(параметры, "НастройкаСортировкиСлушателей")
        Else
            MainForm.students__defaultSortSetts.Text = "Снилс"
        End If
        searchInit(sortSettsStudents, MainForm.students__defaultSortSetts.Text)

        If Not ЗначениеПараметра(параметры, "КоличествоСтрокВТаблице") = "Не найден" Then
            MainForm.КоличествоСтрокВТаблице.Text = ЗначениеПараметра(параметры, "КоличествоСтрокВТаблице")
        Else
            MainForm.КоличествоСтрокВТаблице.Text = 1000
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
