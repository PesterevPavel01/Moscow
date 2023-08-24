﻿Module ВедомостьСлушИОрг

    Sub ВедомостьСлушателиИОрганизации()

        Dim ПриложениеВорд
        Dim ДокументВорд, ДанныеСлушателей, Таблица
        Dim resourcesPath, ПутьКШаблону
        Dim sqlQuery, ВидПриказа As String


        sqlQuery = load_slushatel_and_org(MainForm.prikazKodGroup)
        ДанныеСлушателей = MainForm.mySqlConnect.loadMySqlToArray(sqlQuery, 1)

        If ДанныеСлушателей(0, 0) = "нет записей" Then
            предупреждение.текст.Text = "Нет данных для отображения"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        resourcesPath = Вспомогательный.resourcesPath()
        ПутьКШаблону = resourcesPath & "Шаблоны\Ведомость слушаетели и организации.docx"

        ПриложениеВорд = CreateObject("Word.Application")


        ДокументВорд = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)

        Вспомогательный.savePrikazBlank(ДокументВорд, MainForm.prikazKodGroup, "ВедомостьСлушателиИОрганизации", resourcesPath, "Ведомости")

        Вспомогательный.ЗаменитьТекстВОбластиДокументаВорд(ДокументВорд.Range, "$НомерГруппы$", АСформироватьПриказ.НомерГруппы.Text, 2)

        Таблица = ДокументВорд.Tables(1)
        ЗаполнитьТаблицу(Таблица, ДанныеСлушателей)
        ДокументВорд.Save
        ПриложениеВорд.visible = True


    End Sub

    Sub ЗаполнитьТаблицу(Таблица As Object, Массив As Object)
        Dim d
        For НомерСтроки = 0 To UBound(Массив, 2)
            If Not НомерСтроки = 0 Then
                Таблица.Rows.add
            End If
            d = Таблица.Columns.Count

            Таблица.Cell(НомерСтроки + 2, 1).Range.text = НомерСтроки + 1 & "."
            Таблица.Cell(НомерСтроки + 2, 2).Range.text = Массив(0, НомерСтроки)
            Таблица.Cell(НомерСтроки + 2, 3).Range.text = Массив(1, НомерСтроки)
            Таблица.Cell(НомерСтроки + 2, 4).Range.text = Массив(2, НомерСтроки)
        Next

        With Таблица.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With
    End Sub

End Module
