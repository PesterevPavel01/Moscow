Imports System.Threading
Imports System.IO

Module Интерфейс

    Sub cursorStepLefth(textbox As TextBox)

        If textbox.SelectionStart > 0 Then
            textbox.SelectionStart -= 1
        End If

    End Sub

    Sub cursorStepRigth(textbox As TextBox)

        If textbox.SelectionStart < textbox.TextLength Then
            textbox.SelectionStart += 1
        End If

    End Sub

    Sub ЗакрытьEsc(Форма As Object, номерКлавиши As Integer)

        If номерКлавиши = 27 Then

            Форма.Close()

        End If

    End Sub

    Sub функционалТаб(номерНажатойКлавиши As Integer, НомерКлавишиСФункционаломТаб As Integer, Optional controlName As String = "")

        If номерНажатойКлавиши = НомерКлавишиСФункционаломТаб Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Sub перемещениеВверх(Форма As Object, номерНажатойКлавиши As Integer, Optional номерКлавишиСФункционаломВверх As Integer = 38)
        If номерНажатойКлавиши = номерКлавишиСФункционаломВверх Then

            If Форма.ActiveControl.TabIndex = 0 Then
                Exit Sub
            End If

            For Each i In Форма.Controls

                If i.tabIndex = Форма.ActiveControl.TabIndex - 1 Then

                    Форма.ActiveControl = i
                    Exit Sub

                End If
            Next

        End If
    End Sub

    Sub comboBoxStepBack(combobox As ComboBox, kodPushButton As Integer, kodButtonExp As Integer)

        If kodPushButton = kodButtonExp Then

            Dim selectInd As Int16
            selectInd = combobox.SelectedIndex

            If selectInd < 0 Then
                Exit Sub
            Else
                selectInd -= 1
                combobox.SelectedIndex = selectInd
                Dim s As String = combobox.Text
            End If

        End If
    End Sub

    Sub comboBoxStepForw(combobox As ComboBox, kodPushButton As Integer, kodButtonExp As Integer)

        If kodPushButton = kodButtonExp Then

            Dim selectInd As Int16
            selectInd = combobox.SelectedIndex

            If selectInd >= combobox.Items.Count - 1 Then
                Exit Sub
            Else
                If selectInd = -1 Then
                    Exit Sub
                Else
                    selectInd += 1
                End If
                combobox.SelectedIndex = selectInd
            End If

        End If
    End Sub

    Sub ШрифтКонтрола(контрол As Object, шрифтF As Object)

        контрол.Font = New Font("Microsoft Sans Serif", шрифтF, FontStyle.Regular)

    End Sub

    Sub ЧекатьНаИнтер(контрол As Object, номерНажатойКлавиши As Integer)

        If номерНажатойКлавиши = 13 Then
            If контрол.Checked Then
                контрол.Checked = False
            Else
                контрол.Checked = True
            End If
        End If

    End Sub

    Sub ПрикрепитьЧекбокс(Чекбокс1 As Object, Чекбокс2 As Object)

        If Чекбокс1.Checked Then
            Чекбокс2.Checked = False
        Else
            Чекбокс2.Checked = True
        End If



    End Sub

    Sub переключательВкладок(TabControl1 As Object)

        If TabControl1.SelectedIndex < TabControl1.TabCount - 1 Then

            TabControl1.SelectTab(TabControl1.SelectedIndex + 1)

        Else

            TabControl1.SelectTab(0)

        End If

    End Sub
    Sub обратныйПереключательВкладок(TabControl1 As Object)

        If TabControl1.SelectedIndex > 0 Then

            TabControl1.SelectTab(TabControl1.SelectedIndex - 1)

        Else

            TabControl1.SelectTab(6)

        End If

    End Sub

    Sub ЗаписьОшибокВТХТ(МестоВозникновения As String, ex As Object)
        Dim Path, ПутьКФайлуRes As String, mass As Object, счетчик As Integer = 0

        Path = Application.StartupPath
        mass = Path.Split("\")
        ПутьКФайлуRes = ""
        While счетчик < UBound(mass)

            If mass(счетчик).ToString = "bin" Then

                Exit While

            End If

            ПутьКФайлуRes = ПутьКФайлуRes & mass(счетчик) & "\"
            счетчик = счетчик + 1

        End While

        ПутьКФайлуRes = ПутьКФайлуRes & "Resources\"

        счетчик = 0

Переподключиться:
        If счетчик > 1 Then

            Exit Sub

        End If

        Try

            File.AppendAllText(ПутьКФайлуRes & "СписокОшибок.txt", МестоВозникновения & ", " & ex.HResult & " , Text: " & ex.Message & vbCrLf)

        Catch ex1 As Exception
            Thread.Sleep(200)
            счетчик = счетчик + 1
            GoTo Переподключиться
        End Try


    End Sub


    Sub НеперенесенныеЗапросВТХТ(СтрокаЗапроса As String, КоличествоПодключений As Integer)
        Dim Path, ПутьКФайлуRes As String, mass As Object, счетчик As Integer = 0

        Path = Application.StartupPath
        mass = Path.Split("\")
        ПутьКФайлуRes = ""
        While счетчик < UBound(mass)

            If mass(счетчик).ToString = "bin" Then

                Exit While

            End If

            ПутьКФайлуRes = ПутьКФайлуRes & mass(счетчик) & "\"
            счетчик = счетчик + 1

        End While

        ПутьКФайлуRes = ПутьКФайлуRes & "Resources\"

        счетчик = 0

Переподключиться:
        If счетчик > КоличествоПодключений Then

            предупреждение.текст.Text = "Недоступен файл" & ПутьКФайлуRes & "НеперенесенныеЗапросыВОбщуюБазу.txt Невозможно сохранить изменения!!!!"

            Exit Sub

        End If

        Try

            File.AppendAllText(ПутьКФайлуRes & "НеперенесенныеЗапросыВОбщуюБазу.txt", СтрокаЗапроса & "Время Запроса" & DateString & vbCrLf)

        Catch ex1 As Exception

            счетчик = счетчик + 1
            GoTo Переподключиться

        End Try


    End Sub

    Sub НеперенесенныеЗапросыВТХТ(СтрокаЗапроса As Object, КоличествоПодключений As Integer)
        Dim Path, ПутьКФайлуRes As String, счетчик As Integer = 0, СтрокаДляЗаписи As String
        Dim mass

        Path = Application.StartupPath
        mass = Path.Split("\")
        ПутьКФайлуRes = ""
        While счетчик < UBound(mass)

            If mass(счетчик).ToString = "bin" Then

                Exit While

            End If

            ПутьКФайлуRes = ПутьКФайлуRes & mass(счетчик) & "\"
            счетчик += 1

        End While

        ПутьКФайлуRes = ПутьКФайлуRes & "Resources\"

        счетчик = 0


Переподключиться:
        If счетчик > КоличествоПодключений Then

            предупреждение.текст.Text = "Недоступен файл" & ПутьКФайлуRes & "НеперенесенныеЗапросыВОбщуюБазу.txt Невозможно сохранить изменения!!!!"

            Exit Sub

        End If

        For Each item In СтрокаЗапроса

            СтрокаДляЗаписи += item & vbCrLf

        Next

        Try

            File.WriteAllText(ПутьКФайлуRes & "НеперенесенныеЗапросыВОбщуюБазу.txt", СтрокаДляЗаписи)

        Catch ex1 As Exception

            счетчик = счетчик + 1
            GoTo Переподключиться

        End Try


    End Sub

    Sub выключитьОстальныеЧекбоксыНаФорме(Форма As Form, ИмяВключенногоЧекбокса As String)

        For Each элемент In Форма.Controls

            Try
                If Not элемент.Name = ИмяВключенногоЧекбокса Then

                    элемент.Checked = False

                End If
            Catch ex As Exception

            End Try



        Next

    End Sub

    Function ИмяВключенногоЧекбоксыНаФорме(Форма As Form) As String

        For Each элемент In Форма.Controls

            Try


                If элемент.Checked = True Then

                    ИмяВключенногоЧекбоксыНаФорме = элемент.name

                End If
            Catch ex As Exception

            End Try

        Next

    End Function

    Function ОпроситьЧекбоксыНаФорме(Форма As Form) As Boolean

        ОпроситьЧекбоксыНаФорме = False

        For Each элемент In Форма.Controls

            Try
                If элемент.Checked = True Then

                    ОпроситьЧекбоксыНаФорме = True

                End If
            Catch ex As Exception

            End Try


        Next

    End Function

    Function ИмяАктивногоЧекбоксыНаФорме(Форма As Form) As String

        For Each элемент In Форма.Controls

            Try
                If элемент.Checked = True Then

                    ИмяАктивногоЧекбоксыНаФорме = элемент.Text

                End If
            Catch ex As Exception

            End Try



        Next

    End Function


    Sub ВключитьНастройкуПоиска(Форма As Form, ИмяЧекбокса As String)

        For Each элемент In Форма.Controls
            Try
                If элемент.name = ИмяЧекбокса Then

                    элемент.Checked = True

                End If
            Catch ex As Exception

            End Try


        Next

    End Sub

    Sub ЧекбоксПоведение(Форма As Form, Чекбокс As CheckBox)

        If Чекбокс.Checked = True Then

            Интерфейс.выключитьОстальныеЧекбоксыНаФорме(Форма, Чекбокс.Name)

        End If

        If Чекбокс.Checked = False Then

            If Not Интерфейс.ОпроситьЧекбоксыНаФорме(Форма) Then

                Чекбокс.Checked = True

            End If

        End If

    End Sub

    Function ВидСортировки(Форма As Form, Индикатор As Boolean) As String

        For Each элемент In Форма.Controls
            If элемент.Name = "PictureBox1" Then

                If Индикатор Then

                    ВидСортировки = " DESC "

                Else

                    ВидСортировки = ""

                End If

            End If
        Next

    End Function

    Function проверкаНомеровГруппы(Значение As Object, имя As String) As Boolean
        Dim число As Long
        проверкаНомеровГруппы = True

        Try
            число = Значение
        Catch ex As Exception

            проверкаНомеровГруппы = False
            предупреждение.текст.Text = имя & " не является числом"
            предупреждение.ShowDialog()

        End Try

    End Function


    Function проверитьЗаполненностьФормыСлушатели(Форма As Form) As Boolean

        Dim nameControl As String

        проверитьЗаполненностьФормыСлушатели = True

        For Each i In Форма.Controls

            nameControl = i.Name

            Dim t As String = i.GetType.ToString

            If i.GetType.ToString <> "System.Windows.Forms.ComboBox" And i.GetType.ToString <> "System.Windows.Forms.TextBox" Then

                Continue For

            End If

            If i.Visible = True Then

                Continue For

            End If

            Select Case nameControl

                Case "Телефон"
                    Continue For
                Case "ValidOn"
                    Continue For
                Case "Образование"
                    Continue For
                Case "КемВыданДУЛ"
                    Continue For
                Case "СтранаДОО"
                    Continue For
                Case "Email"
                    Continue For
                Case "Отчество"
                    Continue For
                Case "НомерДУЛ"
                    Continue For
                Case "СерияДУЛ"
                    Continue For
                Case "ДУЛ"
                    Continue For
                Case "ИсточникФин"
                    Continue For
                Case "СтранаДОО"
                    Continue For
                Case "НаправившаяОрг"
                    Continue For
                Case "ДатаНаправленияРосздравнвдзора"
                    Continue For
                Case "НомерНаправленияРосздравнадзора"
                    Continue For
                Case "СпециальностьСлушателя"
                    Continue For
                Case "АдресРегистрации"
                    Continue For
                Case "Образование"
                    Continue For
                Case "Выполнение"
                    Continue For
                Case "doo_vid_dok"
                    Continue For

            End Select

            If i.Text = "" Then

                Return False

            End If

        Next

    End Function


End Module
