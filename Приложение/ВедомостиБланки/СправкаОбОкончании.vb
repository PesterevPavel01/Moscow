Module СправкаОбОкончании

    Sub СправкаОбОкончании(checkedStudents As Object)
        Dim wordApp
        Dim wordDoc, moduls, group, table
        Dim resourcesPath, ПутьКШаблону
        Dim dateVal As Date, dateString As String
        Dim queryString, type As String

        If checkedStudents(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        dateVal = АСформироватьПриказ.ДатаПриказа.Value

        dateString = Chr(34) & Format(dateVal, "dd") & Chr(34) & " " & месяцРП(Format(dateVal, "MMMM")) & " " & Format(dateVal, "yyyy")
        queryString = selectSpravkaIA_group(ААОсновная.prikazKodGroup)
        group = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        If group(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        queryString = selectSpravka_moduls_hours(ААОсновная.prikazKodGroup)
        moduls = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        If moduls(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Отсутствуют модули в программе!"
            предупреждение.ShowDialog()
            предупреждение.текст.Text = "Нет данных для отображения"
            Exit Sub
        End If

        resourcesPath = Вспомогательный.ПутьККаталогуСРесурсами()
        ПутьКШаблону = resourcesPath & "Шаблоны\Справка об окончании без ИА.docx"

        wordApp = CreateObject("Word.Application")

        For СчетчикСтрок = 0 To UBound(checkedStudents, 2)

            type = "Справка об окончании без ИА" & checkedStudents(0, СчетчикСтрок)

            wordDoc = wordApp.Documents.Open(ПутьКШаблону, ReadOnly:=True)

            Вспомогательный.savePrikazBlank(wordDoc, ААОсновная.prikazKodGroup, type, resourcesPath, "Справки")

            предупреждение.текст.Visible = False
            предупреждение.TextBox.Visible = True

            предупреждение.TextBox.Text = "Справки сохранены, Путь к каталогу:
" & АСформироватьПриказ.path

            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$СлушательИО$", Вспомогательный.ФамилияИОПоПолнойФИО(checkedStudents(0, СчетчикСтрок)), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$ФИОСлушатель$", checkedStudents(0, СчетчикСтрок), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$КоличествоСлушателей$", UBound(checkedStudents, 2) + 1, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$УровеньКвалификации$", group(1, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$Программа$", group(0, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$ГруппаФинансирование$", group(2, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$ДатаНЗ$", group(3, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$ДатаКЗ$", group(4, 0), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$ГруппаЧасы$", group(5, 0), 2)

            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$И.О.Ответств$", перевернуть(АСформироватьПриказ.Утверждает.Text), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$Дата$", dateString, 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$День$", Format(dateVal, "dd"), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$Месяц$", месяцРП(Format(dateVal, "MMMM")), 2)
            Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(wordDoc.Range, "$Год$", Format(dateVal, "yyyy"), 2)


            table = НайтиТаблицуПоМеткеИлиНеНайдена(wordDoc.Range, "$Таблица$", 2, 2)

            Try
                If table(0, 0) = "Не найдено" Then
                    предупреждение.текст.Text = "Не найдена метка $Таблица$ в ячейке (2,2) таблицы"
                    предупреждение.ShowDialog()
                    Exit Sub
                End If
            Catch ex As Exception

            End Try

            МСВорд.ЗаполнитьТаблицу(table, moduls, 2, False)

            wordDoc.Save
            wordDoc.Close
        Next

        wordApp.Quit
        предупреждение.ShowDialog()
        предупреждение.текст.Visible = True
        предупреждение.TextBox.Visible = False

    End Sub

End Module
