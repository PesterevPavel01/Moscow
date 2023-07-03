Imports System.IO
Imports System.Reflection.Emit
Imports System.Threading

Module Вспомогательный

    Public массивЗапросов(0)
    Function новаяГруппаЗаполненность() As Boolean
        новаяГруппаЗаполненность = False
        Dim ОсновнойДокумент As String
        Dim НомераУДС

        НомераУДС = Вспомогательный.ОбнулениеНеактивныхНомеров(ОсновнойДокумент, НоваяГруппа)

        If Not НоваяГруппа.НоваяГруппаУровеньКвалификации.Text = "специальный экзамен" Then

            If НоваяГруппа.НоваяГруппаКоличествоЧасов.Text = "" Then

                MsgBox("Заполните поле 'количество часов'")
                Exit Function

            End If

            If НоваяГруппа.НоваяГруппаДатаНачалаЗанятий.Value.ToShortDateString = "01.01.1753" Then

                MsgBox("Установите дату в поле Дата начала занятий")
                Exit Function

            End If

            If НоваяГруппа.НоваяГруппаКонецЗанятий.Value.ToShortDateString = "01.01.1753" Then

                MsgBox("Установите дату в поле Дата окончания звнятий")
                Exit Function

            End If

            If Not Интерфейс.проверкаНомеровГруппы(НоваяГруппа.НоваяГруппаКоличествоЧасов.Text, "Количество часов") Then
                Exit Function
            End If

        End If

        If НоваяГруппа.НоваяГруппаНомер.Text = "" Then
            MsgBox("Укажите номер групппы")
            Exit Function
        End If

        If Not Вспомогательный.проверитьЗаполненность(НоваяГруппа) Then
            предупреждение.текст.Text = "Необходимо заполнить обязательные поля"
            Try
                предупреждение.ShowDialog()
            Catch ex As Exception
                предупреждение.Close()
                предупреждение.ShowDialog()
            End Try

            Exit Function
        End If
        If НоваяГруппа.НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Or НоваяГруппа.НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then
            If Not Интерфейс.проверкаНомеровГруппы(НоваяГруппа.НоваяГруппаНомерПротоколаИА.Text, "Номер протокола ИА") Then
                Exit Function
            End If
        End If

        If НоваяГруппа.НоваяГруппаУровеньКвалификации.Text = "повышение квалификации" Then
            If Not Интерфейс.проверкаНомеровГруппы(НомераУДС(0, 0), "Серия и номер удостоверения") Then
                Exit Function
            End If
            If Not Интерфейс.проверкаНомеровГруппы(НомераУДС(0, 1), "Регистрационный номер удостоверения") Then
                Exit Function
            End If
        End If

        If НоваяГруппа.НоваяГруппаУровеньКвалификации.Text = "профессиональная переподготовка" Then
            If Not Интерфейс.проверкаНомеровГруппы(НомераУДС(0, 2), "Серия и номер диплома") Then
                Exit Function
            End If
            If Not Интерфейс.проверкаНомеровГруппы(НомераУДС(0, 3), "Регистрационный номер диплома") Then
                Exit Function
            End If
        End If

        If НоваяГруппа.НоваяГруппаУровеньКвалификации.Text = "профессиональное обучение" Then
            If Not Интерфейс.проверкаНомеровГруппы(НомераУДС(0, 4), "Серия и номер свидетельства") Then
                Exit Function
            End If
            If Not Интерфейс.проверкаНомеровГруппы(НомераУДС(0, 5), "Регистрационный номер свидетельства") Then
                Exit Function
            End If
        End If

        If НоваяГруппа.НоваяГруппаУровеньКвалификации.Text = "специальный экзамен" Then
            If Not Интерфейс.проверкаНомеровГруппы(НоваяГруппа.НомерПротоколаСпецэкзамен.Text, "Номер протокола спецэкзамена") Then
                Exit Function
            End If
        End If

        новаяГруппаЗаполненность = True
    End Function


    Function проверитьЗаполненность(Форма As Form) As Boolean

        Dim nameControl As String

        проверитьЗаполненность = True

        For Each i In Форма.Controls
            nameControl = i.Name
            If Strings.Left(i.Name, 6) <> "Модуль" And i.Name <> "Квалификация" And i.Name <> "РегНомерСвид" And i.Name <> "НомерСвид" And i.Name <> "РегНомерДиплома" And i.Name <> "НомерДиплома" And i.Name <> "НомерУд" And i.Name <> "РегНомерУд" And i.Name <> "НоваягруппаОтветственныйЗаПрактику" And i.Name <> "НоваяГруппаНомерПротоколаИА" And i.Name <> "BtnFocus" And i.Name <> "Сохранить" And i.Name <> "Очистить" And Strings.Left(i.Name, 5) <> "Label" And Strings.Left(i.Name, 5) <> "label" And Strings.Left(i.Name, 5) <> "Check" And Strings.Left(i.Name, 8) <> "GroupBox" Then

                If i.Text = "" And i.Visible = True And i.Enabled = True Then
                    проверитьЗаполненность = False
                End If
            End If
        Next


    End Function

    Function ПроверитьЗаполненностьРедСлушателя() As Boolean
        Dim ДлинаСнилс As Integer
        Dim ДанныеСлушателя
        Dim СнилсЧисло As Long
        ДлинаСнилс = Len(РедакторСлушателя.Снилс.Text)


        If ДлинаСнилс <> 14 Then

            MsgBox("Снилс введен некорректно")

            Return False

        End If

        Try
            ДанныеСлушателя = ДобавитьРубашку.УдалитьРубашку(РедакторСлушателя.Снилс.Text)
            СнилсЧисло = ДанныеСлушателя
        Catch ex As Exception

            MsgBox("Снилс введен некорректно")
            Return False

        End Try

        If РедакторСлушателя.ValidOn.Checked Then
            If Not АнализСнилс.ПроверкаСнилс(ДобавитьРубашку.УдалитьРубашку(РедакторСлушателя.Снилс.Text)) Then
                MsgBox("Снилс не прошел проверку")
                Return False
            End If
        End If


        If РедакторСлушателя.Снилс.Text = "" Then

            MsgBox("Заполните поле 'СНИЛС'")
            Return False

        End If

        If РедакторСлушателя.ДатаРождения.Value.ToShortDateString = "01.01.1753" Then

            MsgBox("Установите дату в поле Дата рождения")
            Return False

        End If

        If РедакторСлушателя.Фамилия.Text = "" Then
            MsgBox("Укажите Фамилию слушателя")
            Return False
        End If

        If РедакторСлушателя.ИсточникФин.Text = "" Then
            MsgBox("Укажите источник финансирования")
            Return False
        End If

        If Not Интерфейс.проверитьЗаполненностьФормыСлушатели(РедакторСлушателя) Then

            предупреждение.текст.Text = "Заполните все обязательные поля"
            ОткрытьФорму(предупреждение)

            Return False

        End If

        Return True

    End Function

    Function ДобавитьНулиСпереди(номер As Integer, длина As Integer) As String
        Dim Result As String
        Result = номер.ToString
        Dim count As Integer
        count = длина - Strings.Len(Result)
        If Strings.Len(номер) < длина Then
            For i = 1 To count
                Result = 0 & Result
            Next
        End If
        ДобавитьНулиСпереди = Result
    End Function

    Function ДобавитьНулиСпередиМвссив(массив As Object, номерСтолбца As Integer, длина As Integer) As Object

        Dim Result = массив
        Dim ResultElement As String

        For Row = 0 To UBound(Result, 2)
            ResultElement = Result(номерСтолбца, Row).ToString
            Dim count As Integer
            count = длина - Strings.Len(ResultElement)
            If Strings.Len(ResultElement) < длина Then
                For i = 1 To count
                    ResultElement = 0 & ResultElement
                    Result(номерСтолбца, Row) = ResultElement
                Next
            End If
        Next
        ДобавитьНулиСпередиМвссив = Result
    End Function


    Function активироватьМодули(Форма As Form, Программа As String, Kod As String) As Object
        Dim СтрокаЗапроса As String
        Dim Модули
        Dim счетчикСтрок As Integer = 0
        Dim queryString As New SqlQueryString()

        счетчикСтрок = 0

        If Kod = -1 Then
            While счетчикСтрок <= 9
                For Each контрол In Форма.Controls
                    If контрол.name = "LabelМодуль" & счетчикСтрок + 1 Or контрол.name = "Модуль" & счетчикСтрок + 1 Then
                        контрол.Enabled = False
                        'контрол.Visible = False
                        If контрол.name = "Модуль" & счетчикСтрок + 1 Then
                            контрол.Text = ""
                        End If
                    End If
                Next
                счетчикСтрок += 1
            End While
            Exit Function
        End If

        While счетчикСтрок <= 9
            For Each контрол In Форма.Controls
                If контрол.name = "LabelМодуль" & счетчикСтрок + 1 Or контрол.name = "Модуль" & счетчикСтрок + 1 Then
                    контрол.Enabled = True
                    'контрол.Visible = True
                    'If контрол.name = "LabelМодуль" & счетчикСтрок + 1 Then
                    '    контрол.Text = "Модуль " & счетчикСтрок + 1
                    'End If
                End If
            Next
            счетчикСтрок += 1
        End While

        СтрокаЗапроса = queryString.selectModulInProg(Kod)
        Модули = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Модули(0, 0).ToString = "нет записей" Or Модули(0, 0).ToString = "" Then
            счетчикСтрок = 0
        Else
            счетчикСтрок = Модули(0, 0)
        End If

        If Not (Программа.Trim = "" Or Программа.Trim = "Спецэкзамен" Or Программа.Trim = "спецэкзамен") Then
            If Модули(0, 0).ToString = "нет записей" Then
                'предупреждение.текст.Text = "Не указаны модули для выбранной программы"
                'ОткрытьФорму(предупреждение)
                активироватьМодули = Модули
                Exit Function
            End If
        Else
            активироватьМодули = Модули
            Exit Function
        End If

        While счетчикСтрок <= 9
            For Each контрол In Форма.Controls

                If контрол.name = "LabelМодуль" & счетчикСтрок + 1 Or контрол.name = "Модуль" & счетчикСтрок + 1 Then
                    контрол.Enabled = False
                    If контрол.name = "Модуль" & счетчикСтрок + 1 Then
                        контрол.Text = ""
                    End If
                End If

            Next
            счетчикСтрок += 1
        End While
        активироватьМодули = Модули
    End Function

    Sub ДобавитьВГруппу(Снилс As String)

        Dim queryStr As String

        ФормаСправочникСлушатели.Label2.Visible = False

        Снилс = ДобавитьРубашку.УдалитьРубашку(Снилс)

        queryStr = "INSERT INTO СоставГрупп (Слушатель, Kod ) VALUES ( " & Chr(39) & Снилс & Chr(39) & " , " & СправочникГруппы.kod & ")"

        If Not ЗаписьВБазу.ПроверкаСовпаденийЧислоДА_2("СоставГрупп", "Kod", СправочникГруппы.kod, "Слушатель", Снилс) = 2 Then

            ЗаписьВБазу.ЗаписьВБазу(queryStr)

            ЗаполнитьФормуССлушВГруппе.ЗаполнитьФормуССлушВГруппе(СправочникГруппы.kod)

        Else MsgBox("Слушатель уже добавлен в группу")

        End If

    End Sub


    Function ФамилияИОПоПолнойФИО(ПолнаяФИО As String)
        Dim ФИО
        Dim Результат As String

        ФИО = Split(ПолнаяФИО)
        Try
            Результат = ФИО(0) & " "
        Catch ex As Exception

        End Try

        Try
            Результат = Результат & Left(ФИО(1), 1) & "."
        Catch ex As Exception

        End Try

        Try
            Результат = Результат & Left(ФИО(2), 1) & "."
        Catch ex As Exception

        End Try

        ФамилияИОПоПолнойФИО = Результат

    End Function
    Function УбратьНенужныеСтрокиИзМассива(Массив As Object, МассивНенужныхЗначений As Object) As Object
        Dim ИтоговыйМассив
        Dim Совпало As Boolean
        Dim С As Integer, СчетчикСтрок As Integer = 0
        С = UBound(МассивНенужныхЗначений, 2)
        С = UBound(Массив, 1)
        С = UBound(Массив, 2)
        ReDim ИтоговыйМассив(UBound(Массив, 1), UBound(Массив, 2) - UBound(МассивНенужныхЗначений, 2) - 1)

        If МассивНенужныхЗначений(0, 0).ToString = "нет записей" Then
            ReDim ИтоговыйМассив(UBound(Массив, 1), UBound(Массив, 2))
        End If
        For Счетчик = 0 To UBound(Массив, 2)
            Совпало = False
            For счетчик2 = 0 To UBound(МассивНенужныхЗначений, 2)
                If Массив(0, Счетчик) = МассивНенужныхЗначений(0, счетчик2) Then
                    Совпало = True
                End If
            Next
            If Совпало = False Then
                For счетчикСтолбцов = 0 To UBound(Массив, 1)
                    ИтоговыйМассив(счетчикСтолбцов, СчетчикСтрок) = Массив(счетчикСтолбцов, Счетчик)
                Next
                СчетчикСтрок += 1
            End If
        Next

        УбратьНенужныеСтрокиИзМассива = ИтоговыйМассив

    End Function

    Function УбратьПустыеСтрокиИзМассива(Массив As Object) As Object
        Dim ИтоговыйМассив
        Dim Совпало As Boolean
        Dim С As Integer, СчетчикСтрок As Integer = 0
        С = UBound(Массив)

        For Счетчик = 0 To UBound(Массив)

            If IsNothing(Массив(Счетчик)) Or Strings.Trim(Массив(Счетчик)) = "" Then
                Continue For
            End If
            СчетчикСтрок = СчетчикСтрок + 1
        Next

        ReDim ИтоговыйМассив(СчетчикСтрок - 1)
        С = 0

        For Счетчик = 0 To UBound(Массив)

            If IsNothing(Массив(Счетчик)) Or Strings.Trim(Массив(Счетчик)) = "" Then
                С += 1
                Continue For
            End If

            For СчетчикСтолбцов = 0 To UBound(Массив)
                ИтоговыйМассив(Счетчик - С) = Массив(Счетчик)
            Next

        Next

        УбратьПустыеСтрокиИзМассива = ИтоговыйМассив

    End Function

    Sub ЗаменитьТекстВДокументеВорд(ВесьТекст As Object, ЗаменяемыйТекст As String, ТекстНаКоторыйМеняем As String, Optional КоличествоЗамен As Integer = 2)

        ВесьТекст.Find.Execute(FindText:=ЗаменяемыйТекст, ReplaceWith:=ТекстНаКоторыйМеняем, Replace:=КоличествоЗамен)

    End Sub

    Function месяцРП(Месяц As String)
        Dim месяцРПадеж As String
        месяцРПадеж = LCase(Месяц)
        If Right$(месяцРПадеж, 1) = "т" Then
            месяцРПадеж = месяцРПадеж & "а"
        Else месяцРПадеж = Left$(месяцРПадеж, Len(месяцРПадеж) - 1) & "я"
        End If
        месяцРП = месяцРПадеж
    End Function
    Sub ЗаменитьТекстВОбластиДокументаВорд(Область As Object, ЗаменяемыйТекст As String, ТекстНаКоторыйМеняем As String, Optional КоличествоЗамен As Integer = 2)
        Область.Find.ClearFormatting
        Область.Find.Replacement.ClearFormatting
        With Область.Find
            .Text = ЗаменяемыйТекст
            .Replacement.Text = ТекстНаКоторыйМеняем
            .Forward = True
            .Wrap = 0
            .Format = False
            .MatchCase = False
            .MatchWholeWord = False
            .MatchWildcards = False
            .MatchSoundsLike = False
            .MatchAllWordForms = False
        End With
        Область.Find.Execute(Replace:=КоличествоЗамен)
    End Sub

    Function ОсновнойДокумент(Форма As Form) As String

        ОсновнойДокумент = "Не указан"

        For Each Элемент In Форма.Controls

            If Элемент.name = "НомерДиплома" Then
                If Элемент.text <> "" Then
                    ОсновнойДокумент = "Диплом"
                End If
            End If
            If Элемент.name = "РегНомерДиплома" Then
                If Элемент.text <> "" Then
                    ОсновнойДокумент = "Диплом"
                End If
            End If

            If Элемент.name = "НомерСвид" Then
                If Элемент.text <> "" Then
                    ОсновнойДокумент = "Свидетельство"
                End If
            End If
            If Элемент.name = "РегНомерСвид" Then
                If Элемент.text <> "" Then
                    ОсновнойДокумент = "Свидетельство"
                End If
            End If

            If Элемент.name = "НомерУд" Then
                If Элемент.text <> "" Then
                    ОсновнойДокумент = "Удостоверение"
                End If
            End If
            If Элемент.name = "РегНомерУд" Then
                If Элемент.text <> "" Then
                    ОсновнойДокумент = "Удостоверение"
                End If
            End If
            If Элемент.name = "НомерПротоколаСпецэкзамен" Then
                If Элемент.text <> "" Then
                    ОсновнойДокумент = "Спецэкзамен"
                End If
            End If

            If Not ОсновнойДокумент = "Не указан" Then
                Exit Function
            End If

        Next

    End Function

    Function ОбнулениеНеактивныхНомеров(ОсновнойДокумент As String, Форма As Form) As Object
        Dim Значения
        ReDim Значения(0, 6)

        If ОсновнойДокумент = "Не указан" Then
            Значения(0, 0) = 0
            Значения(0, 1) = 0
            Значения(0, 2) = 0
            Значения(0, 3) = 0
            Значения(0, 4) = 0
            Значения(0, 5) = 0
            Значения(0, 6) = 0
        Else

            If ОсновнойДокумент = "Удостоверение" Then
                For Each Контрол In Форма.Controls
                    If Контрол.name = "НомерУд" Then
                        Значения(0, 0) = Контрол.text
                    End If
                    If Контрол.name = "РегНомерУд" Then
                        Значения(0, 1) = Контрол.text
                    End If
                    Значения(0, 2) = 0
                    Значения(0, 3) = 0
                    Значения(0, 4) = 0
                    Значения(0, 5) = 0
                    Значения(0, 6) = 0
                Next
            End If
            If ОсновнойДокумент = "Диплом" Then
                For Each Контрол In Форма.Controls
                    If Контрол.name = "НомерДиплома" Then
                        Значения(0, 2) = Контрол.text
                    End If
                    If Контрол.name = "РегНомерДиплома" Then
                        Значения(0, 3) = Контрол.text
                    End If
                    Значения(0, 0) = 0
                    Значения(0, 1) = 0
                    Значения(0, 4) = 0
                    Значения(0, 5) = 0
                    Значения(0, 6) = 0
                Next
            End If
            If ОсновнойДокумент = "Свидетельство" Then
                For Each Контрол In Форма.Controls
                    If Контрол.name = "НомерСвид" Then
                        Значения(0, 4) = Контрол.text
                    End If
                    If Контрол.name = "РегНомерСвид" Then
                        Значения(0, 5) = Контрол.text
                    End If
                    Значения(0, 0) = 0
                    Значения(0, 1) = 0
                    Значения(0, 2) = 0
                    Значения(0, 3) = 0
                    Значения(0, 6) = 0
                Next
            End If
            If ОсновнойДокумент = "Спецэкзамен" Then
                For Each Контрол In Форма.Controls
                    If Контрол.name = "НомерПротоколаСпецэкзамен" Then
                        Значения(0, 6) = Контрол.text
                    End If
                    Значения(0, 0) = 0
                    Значения(0, 1) = 0
                    Значения(0, 2) = 0
                    Значения(0, 3) = 0
                    Значения(0, 4) = 0
                    Значения(0, 5) = 0
                Next
            End If

        End If
        ОбнулениеНеактивныхНомеров = Значения

    End Function
    Sub ОткрытьФорму(Form As Form)

        Try
            Form.ShowDialog()
        Catch ex As Exception
            Form.Close()
            Try
                Form.ShowDialog()
            Catch ex1 As Exception

            End Try

        End Try



    End Sub

    Function ЗаписьМассиваВКоллекцию(Массив As Object) As Collection
        Dim Список = New Collection
        Dim Номер As Integer



        Try
            For i = 0 To UBound(Массив, 1)
                Список.Add(Массив(i))
            Next
        Catch ex As Exception
            Список.Add(Массив)
        End Try

        Номер = Список.Count

        ЗаписьМассиваВКоллекцию = Список

    End Function
    Sub Коллекция()

        Dim massiv
        Dim Список = New Collection
        Dim Номер As Integer

        ReDim massiv(10)

        For i = 0 To UBound(massiv, 1)

            Список.Add(i)

        Next

        For Each ithem In Список

            Номер = ithem
            Список.Remove(1)

        Next

        Номер = Список.Count
    End Sub

    Function ПутьККаталогуСРесурсами() As String

        Dim ПутьКФайлуRes, Путь As String
        Dim Массив
        Dim счетчик As Integer

        Путь = Application.StartupPath
        Массив = Путь.Split("\")
        ПутьКФайлуRes = ""

        While счетчик < UBound(Массив)

            If Массив(счетчик).ToString = "bin" Then
                Exit While
            End If

            ПутьКФайлуRes = ПутьКФайлуRes & Массив(счетчик) & "\"
            счетчик += 1

        End While


        ПутьККаталогуСРесурсами = ПутьКФайлуRes & "Resources\"

    End Function
    Function ПутьКОбщейБазе() As String
        Dim ПутьКБазе, Путь As String
        Dim Массив
        Dim счетчик As Integer

        Путь = Application.StartupPath
        Массив = Путь.Split("\")
        ПутьКБазе = ""

        While счетчик < UBound(Массив)

            If Массив(счетчик).ToString = "bin" Then
                Exit While
            End If

            ПутьКБазе = ПутьКБазе & Массив(счетчик) & "\"
            счетчик += 1

        End While


        ПутьКОбщейБазе = ПутьКБазе & "Resources\ОсновнаяБД\БазаДанных.accdb"

    End Function

    Function СозданиеКнигиЭксельИЛИОшибкаВ0(Путь As String, ИмяДокумента As String, Optional НомерОтчета As Integer = 0) As Object
        Dim ПриложениеЭксель, КнигаЭксель
        Dim ОбъектыЭксель
        Dim Счетчик, Число As Integer
        Dim Имя As String
        ReDim ОбъектыЭксель(1)
        Dim Name As String
        Счетчик = 0

СоздатьПриложение:
        Try
            ПриложениеЭксель = CreateObject("Excel.Application")
            ПриложениеЭксель.DisplayAlerts = False
        Catch ex As Exception
            Thread.Sleep(500)
            If Счетчик < 10 Then
                Счетчик += 1
                GoTo СоздатьПриложение
            End If
            предупреждение.текст.Text = "Не удалось создать новое приложение эксель"
            предупреждение.ShowDialog()
            ОбъектыЭксель(0) = "Ошибка"
            ОбъектыЭксель(1) = "Ошибка"
            СозданиеКнигиЭксельИЛИОшибкаВ0 = ОбъектыЭксель
            Exit Function
        End Try
        Счетчик = 0
СоздатьКнигу:

        Try
            КнигаЭксель = ПриложениеЭксель.Workbooks.Add
        Catch ex As Exception
            Thread.Sleep(500)
            If Счетчик < 10 Then
                Счетчик += 1
                GoTo СоздатьКнигу
            End If

            предупреждение.текст.Text = "Не удалось создать книгу эксель"
            предупреждение.ShowDialog()
            ПриложениеЭксель.Exit
            ОбъектыЭксель(0) = "Ошибка"
            ОбъектыЭксель(1) = "Ошибка"
            СозданиеКнигиЭксельИЛИОшибкаВ0 = ОбъектыЭксель
            Exit Function
        End Try
        Имя = ИмяДокумента
        Счетчик = 0
СохранитьКнигу:

        Счетчик += 1

        Name = Путь & Имя & Date.Now.ToShortDateString & "_" & Счетчик.ToString & ".xlsx"


        If File.Exists(Name) Then

            GoTo СохранитьКнигу

        End If

        Try
            КнигаЭксель.SaveAs(Name)
        Catch ex As Exception

            предупреждение.текст.Text = "Не удалось сохранить книгу эксель " & ex.Message
            предупреждение.ShowDialog()
            ПриложениеЭксель.Quit
            ОбъектыЭксель(0) = "Ошибка"
            ОбъектыЭксель(1) = "Ошибка"

        End Try

        ОбъектыЭксель(0) = ПриложениеЭксель
        ОбъектыЭксель(1) = КнигаЭксель
        СозданиеКнигиЭксельИЛИОшибкаВ0 = ОбъектыЭксель
    End Function

    Sub сохранить(DOK As Object, видПриказа As String, Optional ПутьКПапке As String = "не указан")
        Dim Name As String, Путь As String, счетчик As Integer = 0

        видПриказа = Strings.Replace(видПриказа, "*", "")
        видПриказа = Strings.Replace(видПриказа, "/", "")
        видПриказа = Strings.Replace(видПриказа, "\", "")
        видПриказа = Strings.Replace(видПриказа, "?", "")
        видПриказа = Strings.Replace(видПриказа, Chr(34), "")
        видПриказа = Strings.Replace(видПриказа, ":", "")
        видПриказа = Strings.Replace(видПриказа, ">", "")
        видПриказа = Strings.Replace(видПриказа, "<", "")
        видПриказа = Strings.Replace(видПриказа, "|", "")


сохранить:

        счетчик += 1

        Name = видПриказа & Date.Now.ToShortDateString & "_" & счетчик.ToString

        If ПутьКПапке = "не указан" Then
            Путь = Application.StartupPath & "\Приказы\"
        Else Путь = ПутьКПапке
        End If

        АСформироватьПриказ.path = Путь

        Путь = Путь & Name & ".docx"

        If File.Exists(Путь) Then

            GoTo сохранить

        End If

        Try
            DOK.SaveAs(Путь)
        Catch ex As Exception
            предупреждение.текст.Text = "не удалось сохранить файл:" & Путь
            предупреждение.ShowDialog()
            АСформироватьПриказ.path = ""
        End Try



    End Sub

    Sub saveKniga(DOK As Object, vidDok As String, resourcesPath As String)
        Dim queryStr As String = ""
        Dim listFolder As List(Of String) = New List(Of String)
        Dim Gruppa

        queryStr = QueryString.SQLString_SELECT_dateAndKvalGrupp(ААОсновная.prikazKodGroup)
        Gruppa = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryStr)

        listFolder.Add("Отчеты")
        listFolder.Add("Книги")

        If checkDirectory(resourcesPath, listFolder) Then
            saveAS(DOK, listFolder, resourcesPath, checkName(vidDok))
        Else
            сохранить(DOK, vidDok, resourcesPath & "Нераспределенное\")
        End If

    End Sub
    Sub savePrikazBlank(DOK As Object, kodGroupp As String, vidDok As String, resourcesPath As String, grouppDok As String)
        Dim queryStr As String = ""
        Dim listFolder As List(Of String) = New List(Of String)
        Dim Gruppa

        queryStr = QueryString.SQLString_SELECT_dateAndKvalGrupp(ААОсновная.prikazKodGroup)
        Gruppa = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryStr)

        listFolder.Add("Приказы")
        listFolder.Add(Gruppa(0, 0))
        listFolder.Add(Gruppa(1, 0))
        listFolder.Add("Группа N" & checkName(АСформироватьПриказ.НомерГруппы.Text))
        listFolder.Add(grouppDok)

        If checkDirectory(resourcesPath, listFolder) Then
            saveAS(DOK, listFolder, resourcesPath, checkName(vidDok))
        Else
            сохранить(DOK, vidDok, resourcesPath & "Нераспределенное\")
        End If

    End Sub

    Function checkName(name As String)
        name = Strings.Replace(name, "*", "")
        name = Strings.Replace(name, "/", "")
        name = Strings.Replace(name, "\", "")
        name = Strings.Replace(name, "?", "")
        name = Strings.Replace(name, Chr(34), "")
        name = Strings.Replace(name, ":", "")
        name = Strings.Replace(name, ">", "")
        name = Strings.Replace(name, "<", "")
        name = Strings.Replace(name, "|", "")
        Return name
    End Function
    'сохранение



    Sub saveAS(DOK As Object, listFolder As List(Of String), resourcesPath As String, видПриказа As String)
        Dim Name As String, path As String, счетчик As Integer = 0

        видПриказа = Strings.Replace(видПриказа, "*", "")
        видПриказа = Strings.Replace(видПриказа, "/", "")
        видПриказа = Strings.Replace(видПриказа, "\", "")
        видПриказа = Strings.Replace(видПриказа, "?", "")
        видПриказа = Strings.Replace(видПриказа, Chr(34), "")
        видПриказа = Strings.Replace(видПриказа, ":", "")
        видПриказа = Strings.Replace(видПриказа, ">", "")
        видПриказа = Strings.Replace(видПриказа, "<", "")
        видПриказа = Strings.Replace(видПриказа, "|", "")

сохранить:

        счетчик += 1
        path = resourcesPath
        Name = Strings.Left(видПриказа, 30) & "_" & Date.Now.ToShortDateString & "_" & счетчик.ToString

        If listFolder.Count = 0 Then
            path = Application.StartupPath & "\Приказы\"
        Else
            For Each part As String In listFolder
                path += part + "\"
            Next
        End If

        АСформироватьПриказ.path = path

        path = path & Name & ".docx"

        If File.Exists(path) Then

            GoTo сохранить

        End If

        Try
            DOK.SaveAs(path)
        Catch ex As Exception
            Dim text1 As String = ex.Message
            Dim i As Integer = path.Length
            предупреждение.текст.Text = "не удалось сохранить файл:" & path
            предупреждение.ShowDialog()
            АСформироватьПриказ.path = ""
        End Try

    End Sub

    Function перевернутьмассив(массив As Object) As Object
        Dim строка, столбец As Long
        Dim перевернутыйМассив
        строка = UBound(массив, 1)
        столбец = UBound(массив, 2)
        ReDim перевернутыйМассив(UBound(массив, 2), UBound(массив, 1))
        For строка = 0 To UBound(массив, 1)
            For столбец = 0 To UBound(массив, 2)
                перевернутыйМассив(столбец, строка) = массив(строка, столбец)
            Next
        Next
        перевернутьмассив = перевернутыйМассив
    End Function

    Function ЗаменитьДатуНаГод(массив As Object, НомерСтолбца As Integer) As Object
        Dim строка, столбец As Long
        Dim ИзмененныйМассив
        строка = UBound(массив, 1)
        столбец = UBound(массив, 2)
        ReDim ИзмененныйМассив(UBound(массив, 1), UBound(массив, 2))
        For строка = 0 To UBound(массив, 1)
            For столбец = 0 To UBound(массив, 2)
                If столбец = НомерСтолбца Then
                    Try
                        ИзмененныйМассив(строка, НомерСтолбца) = Year(массив(строка, НомерСтолбца))
                    Catch
                    End Try
                Else
                    ИзмененныйМассив(строка, столбец) = массив(строка, столбец)
                End If
            Next
        Next

        ЗаменитьДатуНаГод = ИзмененныйМассив
    End Function

    Function НастройкиРедактированияСтолбца(Лист As Object, Таблица As Object) As Object
        Dim массивНастроек

        ReDim массивНастроек(Таблица.ListColumns.Count, 4)
        массивНастроек(0, 0) = "РазмерШрифта/.Font.Size"
        массивНастроек(0, 1) = "ИмяШрифта/.Font.Name"
        массивНастроек(0, 2) = "ВыравниваниеГоризонт/.HorizontalAlignment"
        массивНастроек(0, 3) = "ВыравниваниеВертикаль/.VerticalAlignment"
        массивНастроек(0, 4) = ".Orientation"


        For столбец = 1 To Таблица.ListColumns.Count
            массивНастроек(столбец, 0) = Лист.Range("Таблица[Столбец" & столбец & "]").Font.Size
            массивНастроек(столбец, 1) = Лист.Range("Таблица[Столбец" & столбец & "]").Font.Name
            массивНастроек(столбец, 2) = Лист.Range("Таблица[Столбец" & столбец & "]").HorizontalAlignment
            массивНастроек(столбец, 3) = Лист.Range("Таблица[Столбец" & столбец & "]").VerticalAlignment
            массивНастроек(столбец, 4) = Лист.Range("Таблица[Столбец" & столбец & "]").Orientation
        Next
        НастройкиРедактированияСтолбца = массивНастроек

    End Function

    Sub НастроитьРедактированияСтолбца(Лист As Object, Таблица As Object, МассивНастроек As Object)

        For столбец = 1 To Таблица.ListColumns.Count
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").Font.Size = МассивНастроек(столбец, 0)
            Catch ex As Exception
            End Try
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").Font.Name = МассивНастроек(столбец, 1)
            Catch ex As Exception
            End Try
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").HorizontalAlignment = МассивНастроек(столбец, 2)
            Catch ex As Exception
            End Try
            Try
                Лист.Range("Таблица[Столбец" & столбец & "]").VerticalAlignment = МассивНастроек(столбец, 3)
            Catch ex As Exception
            End Try
            Try

            Catch ex As Exception
                Лист.Range("Таблица[Столбец" & столбец & "]").Orientation = МассивНастроек(столбец, 4)
            End Try
        Next

    End Sub

    Function СоздатьПапку(ПутьКПапке) As Boolean
        СоздатьПапку = True
        If Not Directory.Exists(ПутьКПапке) Then
            Try
                Directory.CreateDirectory(ПутьКПапке)
            Catch ex As Exception
                предупреждение.текст.Text = "Не удалось создать папку: " & ПутьКПапке & " .Возможно нет нужных прав"
                СоздатьПапку = False
            End Try
        End If
    End Function

    Function checkDirectory(resourcesPath As String, listFolder As List(Of String)) As Boolean
        Dim folder As String = ""
        checkDirectory = True
        Dim resultPath As String = resourcesPath
        For Each folder In listFolder
            resultPath += folder + "\"
            If Not Directory.Exists(resultPath) Then
                Try
                    Directory.CreateDirectory(resultPath)
                Catch ex As Exception
                    предупреждение.текст.Text = "Не удалось создать папку: " & resultPath & " .Возможно нет нужных прав"
                    checkDirectory = False
                End Try
            End If
        Next
    End Function

    Sub ДеактивироватьКонтролПоЧастиИмени(Форма As Form, ЧастьИмени As String, показать As Boolean)

        For Each контрол In Форма.Controls
            If InStr(LCase(контрол.name), LCase(ЧастьИмени)) > 0 Then
                If показать Then
                    контрол.Enabled = True
                Else контрол.Enabled = False
                End If

            End If
        Next

    End Sub

    Function ДобавитьНумерациюВМассив(Массив As Object) As Object
        Dim ИтоговыйМассив

        Dim С As Integer, СчетчикСтрок As Integer = 0
        С = UBound(Массив, 1)

        ReDim ИтоговыйМассив(UBound(Массив, 1), UBound(Массив, 2) + 1)

        For СчетчикСтрок = 0 To UBound(Массив, 1)
            For Счетчик = 0 To UBound(Массив, 2) + 1
                If Счетчик = 0 Then
                    ИтоговыйМассив(СчетчикСтрок, 0) = СчетчикСтрок + 1
                Else
                    ИтоговыйМассив(СчетчикСтрок, Счетчик) = Массив(СчетчикСтрок, Счетчик - 1)
                End If
            Next
        Next
        ДобавитьНумерациюВМассив = ИтоговыйМассив
    End Function

    Function ДобавитьНумерациюВМассивПервымСт(Массив As Object) As Object
        Dim ИтоговыйМассив
        Dim Сount As Integer, СчетчикСтрок As Integer = 0
        Dim СountColumn As Integer
        Dim СountRow As Integer
        СountColumn = UBound(Массив, 1)
        СountRow = UBound(Массив, 2)

        If СountColumn = 0 Then
            СountColumn = 1
        End If

        ' If СountRow = 0 Then
        ' СountRow = 1
        ' End If

        ReDim ИтоговыйМассив(СountColumn, СountRow)

        For Счетчик = 0 To СountColumn
            For СчетчикСтрок = 0 To СountRow
                If Счетчик = 0 Then
                    ИтоговыйМассив(Счетчик, СчетчикСтрок) = СчетчикСтрок + 1
                Else
                    ИтоговыйМассив(Счетчик, СчетчикСтрок) = Массив(Счетчик - 1, СчетчикСтрок)
                End If
            Next
        Next
        Return ИтоговыйМассив
    End Function

    Function выделитьСтрокиИзМассиваПоКритерию(Массив As Object, Критерий As Object, НомерСтолбца As Integer) As Object
        Dim ИтоговыйМассив
        Dim счетчик As Integer = 0
        'счетчик = UBound(Массив, 1)
        For СчетчикСтрок = 0 To UBound(Массив, 2)
            If Массив(НомерСтолбца, СчетчикСтрок) = Критерий Then
                счетчик += 1
            End If
        Next

        If счетчик = 0 Then
            ReDim ИтоговыйМассив(0, 0)
            ИтоговыйМассив(0, 0) = "Нет записей"
            выделитьСтрокиИзМассиваПоКритерию = ИтоговыйМассив
            Exit Function
        End If

        ReDim ИтоговыйМассив(UBound(Массив, 1), счетчик - 1)
        выделитьСтрокиИзМассиваПоКритерию = ИтоговыйМассив
        счетчик = 0
        For СчетчикСтрок = 0 To UBound(Массив, 2)
            If Массив(НомерСтолбца, СчетчикСтрок) = Критерий Then
                For СчетчикСтолбцов = 0 To UBound(Массив, 1)
                    ИтоговыйМассив(СчетчикСтолбцов, счетчик) = Массив(СчетчикСтолбцов, СчетчикСтрок)
                Next
                счетчик += 1
            End If
        Next

    End Function

End Module
