Imports System.Threading
Imports System.IO

Module startApp

    Public resourcesPath As String
    Public mainFormBuilder As New MainForm_builder
    Dim mySqlConnector As New MySQLConnect

    Sub ЗапускПриложения()

        resourcesPath = updateResourcesPath()
        mySqlConnectorInit()
        mainFormBuilder.mySQLConnector = mySqlConnector
        mainFormBuilder.init()
        work()
        MainForm.Show()

    End Sub
    Sub mySqlConnectorInit()
        mySqlConnector.mySqlSettings.nameFirstDB = "database"
        mySqlConnector.mySqlSettings.userName = "admin"
        mySqlConnector.mySqlSettings.password = "admin"
        mySqlConnector.mySqlSettings.ODBC = "Dsn=mySQLConnection;uid={admin}"
        mySqlConnector.mySqlSettings.server = "localhost"
    End Sub

    Sub work()

        Dim defaultSettings
        defaultSettings = loadParams()
        saveSetts(defaultSettings)

    End Sub
    Function loadParams() As Object

        Dim params
        Dim sqlQuery As String

        sqlQuery = loadSettings()
        params = mySqlConnector.loadMySqlToArray(sqlQuery, 1)
        Return params

    End Function

    Sub saveSetts(params As Object)

        Dim comboBox As ComboBox

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("directorName"))
        If Not paramsValue(params, "ДиректорФИО") = "Не найден" Then
            comboBox.Text = paramsValue(params, "ДиректорФИО")
        End If

        If Not paramsValue(params, "0") = "Не найден" Then
            MainForm.password0 = paramsValue(params, "0")
        End If

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("directorPosition"))
        If Not paramsValue(params, "ДиректорДолжность") = "Не найден" Then
            comboBox.Text = paramsValue(params, "ДиректорДолжность")
        End If

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано1ПУ"))
        If Not paramsValue(params, "Согласовано1ПУ") = "Не найден" Then
            comboBox.Text = paramsValue(params, "Согласовано1ПУ")
        End If

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано2ПУ"))
        If Not paramsValue(params, "Согласовано2ПУ") = "Не найден" Then
            comboBox.Text = paramsValue(params, "Согласовано2ПУ")
        End If

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано1ДолжностьПУ"))
        If Not paramsValue(params, "Согласовано1ДолжностьПУ") = "Не найден" Then
            comboBox.Text = paramsValue(params, "Согласовано1ДолжностьПУ")
        End If

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("Согласовано2ДолжностьПУ"))
        If Not paramsValue(params, "Согласовано2ДолжностьПУ") = "Не найден" Then
            comboBox.Text = paramsValue(params, "Согласовано2ДолжностьПУ")
        End If

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("students_defaultSearchSetts"))
        If Not paramsValue(params, "ПоискСлушателейПоУм") = "Не найден" Then
            comboBox.Text = paramsValue(params, "ПоискСлушателейПоУм")
        Else
            comboBox.Text = "Снилс"
        End If

        searchInit(НастройкаПоискаСлушателей, comboBox.Text)

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("group_dafaultSearchSetts"))
        If Not paramsValue(params, "ПоискГруппПоУм") = "Не найден" Then
            comboBox.Text = paramsValue(params, "ПоискГруппПоУм")
        Else
            comboBox.Text = "Номер"
        End If
        searchInit(Group__serchSettings, comboBox.Text)

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("group_defaultSortSetts"))
        If Not paramsValue(params, "НастройкаСортировкиГрупп") = "Не найден" Then
            comboBox.Text = paramsValue(params, "НастройкаСортировкиГрупп")
        Else
            comboBox.Text = "Номер"
        End If
        searchInit(sortSettsGroup, comboBox.Text)

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("students_defaultSortSetts"))
        If Not paramsValue(params, "НастройкаСортировкиСлушателей") = "Не найден" Then
            comboBox.Text = paramsValue(params, "НастройкаСортировкиСлушателей")
        Else
            comboBox.Text = "Снилс"
        End If
        searchInit(sortSettsStudents, comboBox.Text)

        comboBox = mainFormBuilder.controls(mainFormBuilder.controlNames("maxNumberRows"))
        If Not paramsValue(params, "КоличествоСтрокВТаблице") = "Не найден" Then
            comboBox.Text = paramsValue(params, "КоличествоСтрокВТаблице")
        Else
            comboBox.Text = 1000
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
