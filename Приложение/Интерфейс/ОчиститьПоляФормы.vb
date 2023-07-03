Module ОчиститьПоляФормы
    Sub Очиститьформу(Форма As Object)

        Dim nameControl As String

        For Each i In Форма.Controls
            nameControl = i.Name
            If Strings.Left(i.Name, 6) <> "Кнопка" And i.Name <> "НоваяГруппаКонецЗанятий" And i.Name <> "versProgs" And i.Name <> "НоваяГруппаДатаНачалаЗанятий" And i.Name <> "ТаблицаВедомость" And i.Name <> "ПодписьИтого" And i.Name <> "Сохранить" And i.Name <> "Очистить" And Strings.Left(i.Name, 5) <> "Label" And Strings.Left(i.Name, 5) <> "Check" And Strings.Left(i.Name, 8) <> "GroupBox" And Strings.Left(i.Name, 5) <> "label" Then

                If Strings.Left(i.Name, 4) = "Дата" Then
                    i.Text = "01.01.1753"
                    'i.Text = Date.Now
                Else
                    i.Text = ""
                End If
            End If
        Next


    End Sub


End Module
