Imports System.Threading
Imports System.IO

Module startApp

    Public resourcesPath As String
    Public mainFormBuilder As New MainForm_builder

    Sub ЗапускПриложения()

        resourcesPath = updateResourcesPath()
        work()
        mainFormBuilder.init()
        MainForm.Show()

    End Sub

    Sub work()

        Dim defaultSettings
        defaultSettings = loadParams()
        saveSetts(defaultSettings)

    End Sub
    Function loadParams() As Object
        Dim params
        Dim sqlQuery As String
        Dim mySqlConnector As New MySQLConnect

        mySqlConnector.mySqlSettings.nameFirstDB = "database"
        mySqlConnector.mySqlSettings.userName = "admin"
        mySqlConnector.mySqlSettings.password = "admin"
        mySqlConnector.mySqlSettings.ODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlConnector.mySqlSettings.server = "localhost"

        sqlQuery = loadSettings()
        params = mySqlConnector.loadMySqlToArray(sqlQuery, 1)
        loadParams = params
    End Function

    Sub saveSetts(params As Object)

        If Not paramsValue(params, "ДиректорФИО") = "Не найден" Then
            MainForm.directorName.Text = paramsValue(params, "ДиректорФИО")
        End If

        If Not paramsValue(params, "0") = "Не найден" Then
            MainForm.password0 = paramsValue(params, "0")
        End If

        If Not paramsValue(params, "ДиректорДолжность") = "Не найден" Then
            MainForm.directorPosition.Text = paramsValue(params, "ДиректорДолжность")
        End If

        If Not paramsValue(params, "Согласовано1ПУ") = "Не найден" Then
            MainForm.Согласовано1ПУ.Text = paramsValue(params, "Согласовано1ПУ")
        End If

        If Not paramsValue(params, "Согласовано2ПУ") = "Не найден" Then
            MainForm.Согласовано2ПУ.Text = paramsValue(params, "Согласовано2ПУ")
        End If

        If Not paramsValue(params, "Согласовано1ДолжностьПУ") = "Не найден" Then
            MainForm.Согласовано1ДолжностьПУ.Text = paramsValue(params, "Согласовано1ДолжностьПУ")
        End If

        If Not paramsValue(params, "Согласовано2ДолжностьПУ") = "Не найден" Then
            MainForm.Согласовано2ДолжностьПУ.Text = paramsValue(params, "Согласовано2ДолжностьПУ")
        End If

        If Not paramsValue(params, "ПоискСлушателейПоУм") = "Не найден" Then
            MainForm.students__defaultSearchSetts.Text = paramsValue(params, "ПоискСлушателейПоУм")
        Else
            MainForm.students__defaultSearchSetts.Text = "Снилс"
        End If

        searchInit(НастройкаПоискаСлушателей, MainForm.students__defaultSearchSetts.Text)

        If Not paramsValue(params, "ПоискГруппПоУм") = "Не найден" Then
            MainForm.group_dafaultSearchSetts.Text = paramsValue(params, "ПоискГруппПоУм")
        Else
            MainForm.group_dafaultSearchSetts.Text = "Номер"
        End If
        searchInit(Group__serchSettings, MainForm.group_dafaultSearchSetts.Text)

        If Not paramsValue(params, "НастройкаСортировкиГрупп") = "Не найден" Then
            MainForm.group__dafaultSortSetts.Text = paramsValue(params, "НастройкаСортировкиГрупп")
        Else
            MainForm.group__dafaultSortSetts.Text = "Номер"
        End If
        searchInit(sortSettsGroup, MainForm.group__dafaultSortSetts.Text)

        If Not paramsValue(params, "НастройкаСортировкиСлушателей") = "Не найден" Then
            MainForm.students__defaultSortSetts.Text = paramsValue(params, "НастройкаСортировкиСлушателей")
        Else
            MainForm.students__defaultSortSetts.Text = "Снилс"
        End If
        searchInit(sortSettsStudents, MainForm.students__defaultSortSetts.Text)

        If Not paramsValue(params, "КоличествоСтрокВТаблице") = "Не найден" Then
            MainForm.maxNumberRows.Text = paramsValue(params, "КоличествоСтрокВТаблице")
        Else
            MainForm.maxNumberRows.Text = 1000
        End If

    End Sub
    Function paramsValue(params As Object, currentParam As String) As String
        If params(0, 0) = "нет записей" Then
            paramsValue = "Не найден"
            Exit Function
        End If

        For counter = 0 To UBound(params, 2)

            If params(0, counter) = currentParam Then

                If params(1, counter) = "" Then
                    paramsValue = "Не найден"
                    Exit Function
                Else
                    paramsValue = params(1, counter)
                End If
                Exit Function

            End If

        Next

        paramsValue = "Не найден"

    End Function

End Module
