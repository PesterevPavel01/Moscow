Module МСВорд

    Sub КопироватьВставить(MSWord As Object, DOK As Object, НачальныйАбзац As Integer, КонечныйАбзац As Integer)

        Dim Начало, Конец

        Начало = DOK.Paragraphs(НачальныйАбзац).Range.Start
        Конец = DOK.Paragraphs(КонечныйАбзац).Range.End
        DOK.Range(Начало, Конец).Select
        MSWord.Selection.Copy

        DOK.Bookmarks("\EndOfDoc").Select
        MSWord.Selection.PasteAndFormat(0)

    End Sub
    Sub ВставитьПараграф(DOK As Object, номерАбзаца As Integer, текст As String, Шрифт As String, РазмерШрифта As Integer, Выравнивание As Double, ОтступКраснаяСтрока As Double, ОтступПередАбзацем As Double, МежстрочныйИнтервал As Double, Жирный As Boolean)

        DOK.Paragraphs(номерАбзаца).Range.Font.Name = Шрифт
        DOK.Paragraphs(номерАбзаца).Range.Font.Size = РазмерШрифта
        DOK.Paragraphs(номерАбзаца).Range.Text = текст
        DOK.Paragraphs(номерАбзаца).Format.Alignment = Выравнивание
        DOK.Paragraphs(номерАбзаца).LeftIndent = 28.34646 * ОтступКраснаяСтрока
        DOK.Paragraphs(номерАбзаца).FirstLineIndent = 28.34646 * ОтступПередАбзацем
        DOK.Paragraphs(номерАбзаца).LineUnitAfter = 0
        DOK.Paragraphs(номерАбзаца).LineUnitBefore = 0
        DOK.Paragraphs(номерАбзаца).SpaceAfter = 0
        DOK.Paragraphs(номерАбзаца).SpaceBefore = МежстрочныйИнтервал
        DOK.Paragraphs(номерАбзаца).Range.Font.Bold = Жирный
        DOK.Paragraphs(номерАбзаца).Range.ParagraphFormat.LineSpacing = 12

    End Sub

    Sub ЗаполнитьТаблицу(Таблица As Object, Массив As Object, номерПервойСтроки As Integer, ВключитьНумерацию As Boolean)
        Dim количествоСтолбцов
        Dim номерПервогоСтолбца As Integer = 0

        количествоСтолбцов = UBound(Массив, 1) + 1

        For НомерСтроки = 0 To UBound(Массив, 2)
            If Not НомерСтроки = 0 Then
                Таблица.Rows.add
            End If

            If ВключитьНумерацию Then
                номерПервогоСтолбца = 1
                Таблица.Cell(НомерСтроки + номерПервойСтроки, 1).Range.text = НомерСтроки + 1 & "."
            End If


            Таблица.Cell(НомерСтроки + номерПервойСтроки, 1 + номерПервогоСтолбца).Range.text = Массив(0, НомерСтроки)

            For i = 1 + номерПервогоСтолбца To количествоСтолбцов
                Таблица.Cell(НомерСтроки + номерПервойСтроки, i).Range.text = Массив(i - номерПервогоСтолбца - 1, НомерСтроки)
            Next

        Next
        With Таблица.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With
    End Sub

    Sub ЗаполнитьТаблицуВедомости(Таблица As Object, Массив As Object, Массив_оценок As Object, номерПервойСтроки As Integer, ВключитьНумерацию As Boolean)
        Dim количествоСтолбцов
        Dim номерПервогоСтолбца As Integer = 0

        количествоСтолбцов = UBound(Массив, 1) + 1

        For НомерСтроки = 0 To UBound(Массив, 2)
            If Not НомерСтроки = 0 Then
                Таблица.Rows.add
            End If

            If ВключитьНумерацию Then
                номерПервогоСтолбца = 1
                Таблица.Cell(НомерСтроки + номерПервойСтроки, 1).Range.text = НомерСтроки + 1 & "."
            End If

            Таблица.Cell(НомерСтроки + номерПервойСтроки, 1 + номерПервогоСтолбца).Range.text = Массив(0, НомерСтроки)

            For rowNumber = 0 To UBound(Массив, 2)
                If Массив_оценок(0, rowNumber) = Массив(1, НомерСтроки) Then
                    Таблица.Cell(НомерСтроки + номерПервойСтроки, 2 + номерПервогоСтолбца).Range.text = Массив_оценок(1, rowNumber)
                    Exit For
                End If
            Next
        Next
        With Таблица.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With
    End Sub

    Sub ЗаполнитьТаблицуПКОк(Таблица As Object, Массив As Object, номерПервойСтроки As Integer, ВключитьНумерацию As Boolean)
        Dim количествоСтолбцов
        Dim номерПервогоСтолбца As Integer = 0

        количествоСтолбцов = UBound(Массив, 1) + 1

        For НомерСтроки = 0 To UBound(Массив, 2)
            If Not НомерСтроки = 0 Then
                Таблица.Rows.add
            End If

            If ВключитьНумерацию Then
                номерПервогоСтолбца = 1
                Таблица.Cell(НомерСтроки + номерПервойСтроки, 1).Range.text = НомерСтроки + 1 & "."
            End If


            Таблица.Cell(НомерСтроки + номерПервойСтроки, 1 + номерПервогоСтолбца).Range.text = Массив(0, НомерСтроки)

            For i = 1 + номерПервогоСтолбца To количествоСтолбцов + 1
                Таблица.Cell(НомерСтроки + номерПервойСтроки, i).Range.text = Массив(i - номерПервогоСтолбца - 1, НомерСтроки)
            Next

        Next
        With Таблица.Borders
            .InsideLineStyle = 1
            .OutsideLineStyle = 1
        End With
    End Sub

    Sub ДобавитьСписокПоМетке(ДокументВорд As Object, Метка As String, Список As Object)

        Dim номерАбзаца As Integer
        номерАбзаца = 1
        For Each Параграф In ДокументВорд.Paragraphs

            If InStr(Параграф.Range.Text, Метка) > 0 Then
                Параграф.Range.Text = "1. " & Список(0, 0) & vbNewLine
                For i = 1 To UBound(Список, 2)
                    ДокументВорд.Paragraphs(номерАбзаца).Range.InsertAfter(i + 1 & ". " & Список(0, i) & vbNewLine)
                    Параграф = ДокументВорд.Paragraphs(номерАбзаца + 1)
                    номерАбзаца += 1
                Next

                Exit For
            End If
            номерАбзаца = номерАбзаца + 1
        Next

    End Sub

    Sub ДобавитьСписокПоМеткеСтрокой(ДокументВорд As Object, Метка As String, Список As Object, ПриложениеВорд As Object)

        Dim СписокВСтроке As String
        Dim otstup As Double
        Dim lefthId As Double
        Dim startRange
        Dim endRange

        For Each Параграф In ДокументВорд.Paragraphs
            If InStr(Параграф.Range.Text, Метка) > 0 Then
                Dim count As Integer = ДокументВорд.Range(End:=Параграф.Range.End).Paragraphs.Count
                startRange = Параграф.Range.Start
                lefthId = Параграф.Range.ParagraphFormat.LeftIndent
                otstup = Параграф.Range.ParagraphFormat.FirstLineIndent
                Параграф.Range.Select
                СписокВСтроке = "1. " & Список(0, 0) & vbNewLine
                For i = 1 To UBound(Список, 2)
                    СписокВСтроке = СписокВСтроке & i + 1 & ". " & Список(0, i) & vbNewLine
                Next
                Параграф.Range.Text = СписокВСтроке
                endRange = Параграф.Range.Start
                Параграф = ДокументВорд.Range(Start:=startRange, End:=endRange)
                Параграф.Select
                ПриложениеВорд.Selection.Range.ParagraphFormat.LeftIndent = lefthId
                ПриложениеВорд.Selection.Range.ParagraphFormat.FirstLineIndent = otstup
                Exit For
            End If
        Next

    End Sub

    Function НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд As Object, Метка As String, Optional Столбец As Integer = 1111, Optional строка As Integer = 1111) As Object
        Dim Таблица
        Dim h
        Таблица = ДокументВорд.Tables.Count
        For Each Таблица In ДокументВорд.Tables
            If Столбец = 1111 Or строка = 1111 Then
                For Each Ячейка In Таблица.Range.Cells
                    If InStr(Ячейка.Range.Text, Метка) > 0 Then
                        НайтиТаблицуПоМеткеИлиНеНайдена = Таблица
                        Exit Function
                    End If
                Next
            Else
                Try
                    h = Таблица.Cell(3, 2).Range.Text
                    If InStr(Таблица.Cell(строка, Столбец).Range.Text, Метка) > 0 Then
                        НайтиТаблицуПоМеткеИлиНеНайдена = Таблица
                        Exit Function
                    End If
                Catch ex As Exception

                End Try

            End If
        Next

        ReDim Таблица(0, 0)
        Таблица(0, 0) = "не найдена"
        НайтиТаблицуПоМеткеИлиНеНайдена = Таблица
    End Function

    Function НомерАбзацаПоМеткеИли999999(ДокументВорд As Object, Метка As String) As Integer
        For Each Параграф In ДокументВорд.Range.Paragraphs
            If InStr(Параграф.Range.Text, Метка) > 0 Then
                НомерАбзацаПоМеткеИли999999 = ДокументВорд.Range(End:=Параграф.Range.End).Paragraphs.Count
                Exit Function
            End If
        Next
        НомерАбзацаПоМеткеИли999999 = 999999
    End Function

    Function строкДоСледующейСтраницы(DOK As Object, номерАбзаца As Integer, ТекущаяСтраница As Integer)

        Dim Параграф As Object
        Dim КоличествоСтраниц, НомерТекущейСтраницы As Integer, стрДоСледующейСтраницы As Integer
        НомерТекущейСтраницы = DOK.Paragraphs(номерАбзаца).Range.Information(3)
        ТекущаяСтраница = НомерТекущейСтраницы
        стрДоСледующейСтраницы = 0
        КоличествоСтраниц = DOK.Range.Information(3)

        While НомерТекущейСтраницы < ТекущаяСтраница + 1
            'КоличествоСтраниц = DOK.Range.Information(3)
            Параграф = DOK.Paragraphs.Add
            стрДоСледующейСтраницы = стрДоСледующейСтраницы + 1
            НомерТекущейСтраницы = Параграф.Range.Information(3)
        End While

        строкДоСледующейСтраницы = стрДоСледующейСтраницы - 2

        While стрДоСледующейСтраницы > 0
            DOK.Paragraphs(стрДоСледующейСтраницы + номерАбзаца).Range.Delete
            стрДоСледующейСтраницы = стрДоСледующейСтраницы - 1
        End While


    End Function

    Sub СкопироватьТаблицуИзШаблона(ПриложениеВорд As Object, ДокументВорд As Object, ПутьКШаблону As String, НомерТаблицы As Integer)
        Dim Шаблон As Object

        Шаблон = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)
        Шаблон.Range.Copy
        ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
        Шаблон.Close(0)

    End Sub
    Sub СкопироватьДокументИзШаблона(ПриложениеВорд As Object, ДокументВорд As Object, ПутьКШаблону As String, Optional Область As Object = "В конец документа")
        Dim Шаблон As Object

        Шаблон = ПриложениеВорд.Documents.Open(ПутьКШаблону, ReadOnly:=True)
        Шаблон.Range.Copy
        Try
            Область = "В конец документа"
            ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
        Catch ex As Exception
            Область.PasteAndFormat(0)
        End Try
        Шаблон.Close(0)

    End Sub

    Sub ТаблицаУтверждаю(ПриложениеВорд As Object, ДокументВорд As Object, МеткаТаблицы As String, МеткаКонцаОсновногоРаздела As String, Optional КонецОсновногоРазделаТаблица As Boolean = False, Optional МеткаКонечнойТаблицы As String = "")
        Dim Таблица, Таблица2, Область
        Dim НомерАбзаца, счетчик, строкДоСтраницы2 As Integer

        НомерАбзаца = НомерАбзацаПоМеткеИли999999(ДокументВорд, МеткаТаблицы)


        If НомерАбзаца = 999999 Then
            Warning.content.Text = "Не найдена метка " & МеткаТаблицы & " , не удалось сформировать приказ"
            Warning.ShowDialog()
            ПриложениеВорд.Visible = True
            Exit Sub
        End If

        Таблица = НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, МеткаТаблицы, 1, 1)

        Try
            If Таблица(0, 0).ToString = "не найдена" Then
                Warning.content.Text = "Не найдена метка " & МеткаТаблицы & " , не удалось сформировать приказ"
                Warning.ShowDialog()
                ПриложениеВорд.Visible = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        'Exit Sub

        Таблица.Range.Cut

        ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete

        НомерАбзаца = НомерАбзацаПоМеткеИли999999(ДокументВорд, МеткаКонцаОсновногоРаздела)

        If НомерАбзаца = 999999 Then
            Warning.content.Text = "Не найдена метка " & МеткаКонцаОсновногоРаздела & " , не удалось сформировать приказ"
            Warning.ShowDialog()
            ПриложениеВорд.Visible = True
            Exit Sub
        End If


        ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete

        If Not КонецОсновногоРазделаТаблица Then
            While НомерАбзаца < ДокументВорд.Paragraphs.Count + 1
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete
            End While

            строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(ДокументВорд, НомерАбзаца - 1, ДокументВорд.Range.Information(3))

            If строкДоСтраницы2 < 4 Then
                ДокументВорд.Paragraphs(НомерАбзаца - 1).Range.InsertParagraphBefore
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                счетчик = ДокументВорд.Paragraphs.Count
                ДокументВорд.Paragraphs(счетчик).Range.Select
                ПриложениеВорд.Selection.PasteAndFormat(0)

                ДокументВорд.Paragraphs(НомерАбзаца - 1).Range.Select
                ПриложениеВорд.Selection.InsertBreak(Type:=7)

                НомерАбзаца = НомерАбзацаПоМеткеИли999999(ДокументВорд, МеткаТаблицы)
                If НомерАбзаца = 999999 Then
                    Warning.content.Text = "Не найдена метка  " & МеткаТаблицы & "  не удалось сформировать приказ"
                    Warning.ShowDialog()
                    ПриложениеВорд.Visible = True
                    Exit Sub
                End If

                ДокументВорд.Paragraphs(НомерАбзаца - 2).Range.InsertParagraphAfter
                ДокументВорд.Paragraphs(НомерАбзаца - 2).Range.InsertParagraphAfter

                НомерАбзаца = ДокументВорд.Paragraphs.Count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Select
                ПриложениеВорд.Selection.InsertBreak(Type:=7)
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete

            ElseIf строкДоСтраницы2 = 4 Then

                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                счетчик = ДокументВорд.Paragraphs.Count
                ДокументВорд.Paragraphs(счетчик).Range.Select
                ПриложениеВорд.Selection.PasteAndFormat(0)

                НомерАбзаца = ДокументВорд.Paragraphs.count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete
                НомерАбзаца = ДокументВорд.Paragraphs.count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete

            Else

                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                счетчик = ДокументВорд.Paragraphs.Count
                ДокументВорд.Paragraphs(счетчик).Range.Select
                ПриложениеВорд.Selection.PasteAndFormat(0)

                НомерАбзаца = ДокументВорд.Paragraphs.count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete
                НомерАбзаца = ДокументВорд.Paragraphs.count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete

                НомерАбзаца = ДокументВорд.Paragraphs.Count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Select
                ПриложениеВорд.Selection.InsertBreak(Type:=7)
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete

            End If


        Else

            While НомерАбзаца < ДокументВорд.Paragraphs.Count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete
            End While

            строкДоСтраницы2 = МСВорд.строкДоСледующейСтраницы(ДокументВорд, НомерАбзаца - 1, ДокументВорд.Range.Information(3)) + 1

            If строкДоСтраницы2 < 4 Then

                Таблица2 = НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, МеткаКонечнойТаблицы, 1, 1)
                Try
                    If Таблица(0, 0).ToString = "не найдена" Then
                        Warning.content.Text = "Не найдена метка " & МеткаТаблицы & " , не удалось сформировать приказ"
                        Warning.ShowDialog()
                        ПриложениеВорд.Visible = True
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try


                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
                Таблица = НайтиТаблицуПоМеткеИлиНеНайдена(ДокументВорд, МеткаТаблицы, 1, 1)
                Область = Таблица2.Range
                Область.SetRange(Start:=Область.Start,
        End:=ДокументВорд.Bookmarks("\EndOfDoc").Range.End)
                Область.Select
                Область.Cut
                НомерАбзаца = ДокументВорд.Paragraphs.Count
                ДокументВорд.Paragraphs(НомерАбзаца).Range.Delete
                ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)
                ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
                ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

            ElseIf строкДоСтраницы2 = 4 Then
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
                ДокументВорд.Paragraphs.Add
            Else

                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Paragraphs.Add
                ДокументВорд.Bookmarks("\EndOfDoc").Range.PasteAndFormat(0)
                ДокументВорд.Bookmarks("\EndOfDoc").Range.InsertBreak(Type:=7)

            End If

        End If



    End Sub

    Sub НайтиИУдалитьСтрокуТаблицыПоМеткеИлиОшибка(Таблица As Object, Метка As Object)
        Try
            If Таблица(0, 0) = "не найдена" Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        For Each Строка In Таблица.Rows
            For Each ячейка In Строка.Cells
                If InStr(ячейка.Range.Text, Метка) > 0 Then
                    Строка.Delete
                End If
            Next
        Next

    End Sub

    Function НомерСтрокиТаблицыПоМеткеПереборомЯчеекСтолбцаИли11111(Таблица As Object, Метка As Object, НомерСтолбца As Integer) As Integer
        Try
            If Таблица(0, 0) = "не найдена" Then
                НомерСтрокиТаблицыПоМеткеПереборомЯчеекСтолбцаИли11111 = 11111
                Exit Function
            End If
        Catch ex As Exception

        End Try

        For НомерСтроки = 1 To Таблица.Rows.Count
            Try
                If InStr(Таблица.Cell(НомерСтроки, НомерСтолбца).Range.text, Метка) > 0 Then
                    НомерСтрокиТаблицыПоМеткеПереборомЯчеекСтолбцаИли11111 = НомерСтроки
                    Exit Function
                End If
            Catch ex As Exception

            End Try

            НомерСтроки += 1
        Next
        НомерСтрокиТаблицыПоМеткеПереборомЯчеекСтолбцаИли11111 = 11111

    End Function

    Function НомерЯчейкиТаблицыПоМеткеПереборомВсехЯчеекИли11111(Таблица As Object, Метка As Object) As Object
        Dim Координаты
        ReDim Координаты(2, UBound(Метка))
        Try
            If Таблица(0, 0) = "не найдена" Then
                НомерЯчейкиТаблицыПоМеткеПереборомВсехЯчеекИли11111 = 11111
                Exit Function
            End If
        Catch ex As Exception

        End Try

        For НомерМетки = 0 To UBound(Метка)
            Координаты(0, НомерМетки) = Метка(НомерМетки)
        Next

        For НомерСтроки = 1 To Таблица.Rows.Count
            For НомерСтолбца = 1 To Таблица.Columns.Count
                For НомерМетки = 0 To UBound(Метка)
                    Try
                        If InStr(Таблица.Cell(НомерСтроки, НомерСтолбца).Range.text, Метка(НомерМетки)) > 0 Then
                            Координаты(1, НомерМетки) = НомерСтроки
                            Координаты(2, НомерМетки) = НомерСтолбца
                        End If
                    Catch ex As Exception

                    End Try
                Next
            Next
        Next
        НомерЯчейкиТаблицыПоМеткеПереборомВсехЯчеекИли11111 = Координаты

    End Function

End Module
