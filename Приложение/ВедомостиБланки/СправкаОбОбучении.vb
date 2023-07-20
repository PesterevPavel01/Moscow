﻿Imports System.Security.Policy

Module СправкаОбОбучении
    Sub СправкаОбОбучении(ЧекнутыеСлушатели As Object)
        Dim ПриложениеВорд, Область
        Dim ДокументВорд, ДанныеСлушателей, Группа, Таблица
        Dim ПутьККаталогуСРесурсами, ПутьКШаблону
        Dim Дата As Date, ДатаВПриказ As String, НомерАбзаца As Integer
        Dim СтрокаЗапроса, ВидПриказа As String

        If ЧекнутыеСлушатели(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If


        Дата = АСформироватьПриказ.ДатаПриказа.Value

        ДатаВПриказ = Chr(34) & Format(Дата, "dd") & Chr(34) & " " & месяцРП(Format(Дата, "MMMM")) & " " & Format(Дата, "yyyy")
        СтрокаЗапроса = selectSpravka_group(ААОсновная.prikazKodGroup)
        Группа = ЗагрузитьИзБазы.ЗагрузитьИзБазы(СтрокаЗапроса)

        If Группа(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        ПутьККаталогуСРесурсами = Вспомогательный.ПутьККаталогуСРесурсами()
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\Справка об обучении.docx"

        ПриложениеВорд = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(ЧекнутыеСлушатели, 2)

            ВидПриказа = "СправкаООбучении" & ЧекнутыеСлушатели(0, СчетчикСтрок)

            ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            Вспомогательный.savePrikazBlank(ДокументВорд, ААОсновная.prikazKodGroup, ВидПриказа, ПутьККаталогуСРесурсами, "Справки")

            предупреждение.текст.Visible = False
            предупреждение.TextBox.Visible = True

            предупреждение.TextBox.Text = "Справки сохранены, Путь к каталогу:
" & АСформироватьПриказ.path

            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$СлушательИО$", Вспомогательный.ФамилияИОПоПолнойФИО(ЧекнутыеСлушатели(0, СчетчикСтрок)), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$ФИОСлушатель$", ЧекнутыеСлушатели(0, СчетчикСтрок), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$КоличествоСлушателей$", UBound(ЧекнутыеСлушатели, 2) + 1, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$УровеньКвалификации$", Группа(1, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$Программа$", Группа(0, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$ГруппаФинансирование$", Группа(2, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$ДатаНЗ$", Группа(3, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$ДатаКЗ$", Группа(4, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$Приказ$", АСформироватьПриказ.ПрактическаяПодготовка.Text, 2)

            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$И.О.Ответств$", перевернуть(АСформироватьПриказ.Утверждает.Text), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$Дата$", ДатаВПриказ, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$День$", Format(Дата, "dd"), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$Месяц$", месяцРП(Format(Дата, "MMMM")), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$Год$", Format(Дата, "yyyy"), 2)

            ДокументВорд.Save
            ДокументВорд.Close
        Next

        ПриложениеВорд.Quit
        предупреждение.ShowDialog()
        предупреждение.текст.Visible = True
        предупреждение.TextBox.Visible = False

    End Sub


End Module
