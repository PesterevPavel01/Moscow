Imports System.Threading
Module ЗаписьИнформацииДляОтчетаExcell
    Public НомерВБв As Integer
    Public НомерОРук As Integer
    Public adress As String
    Public Массив
    Public счетБюджет As Integer, счетСлушателей As Integer

    Sub CreateRMANPO(Excell As Object, WBook As Object, listData As List(Of List(Of String)), Специальности As Object, Группы As Object, month As String)
        Dim Шаблон, Wsor
        Dim Строка, spec, Val_A As String
        Dim count, countEnd As Integer, СчетчикСтрок As Integer
        Dim ПутьКШаблону, ПутьККаталогуСРесурсами As String
        Dim sum_d, sum_e, sum_f As Int64
        Val_A = ""
        sum_d = 0
        sum_e = 0
        sum_f = 0
        ПутьККаталогуСРесурсами = Вспомогательный.ПутьККаталогуСРесурсами()
        ПутьКШаблону = ПутьККаталогуСРесурсами & "Шаблоны\Отчёт_РМАНПО.xlsx"

        Шаблон = Excell.Workbooks.Open(ПутьКШаблону, ReadOnly:=True)
        Шаблон.Worksheets(1).copy(before:=WBook.Worksheets(1))
        Шаблон.Close

        Wsor = WBook.Worksheets(1)
        Wsor.Name = "РМАНПО"
        СчетчикСтрок = 7
        count = 0

        'Excell.Visible = True

        For Each Row In listData

            If Row(0) <> spec Then
                Строка = "A" & СчетчикСтрок
                If Row(0) <> "Без специальности" Then
                    Wsor.Range(Строка).Value = "Специальность " + Row(0)
                Else
                    Wsor.Range(Строка).Value = Row(0)
                End If
                Строка += ":H" & СчетчикСтрок
                Wsor.Range(Строка).Merge
                СчетчикСтрок += 1
            End If

            If Val_A <> Row(1) Then

                If count <> 0 And countEnd <> 0 And countEnd > count Then
                    Строка = "A" & count & ":A" & countEnd
                    Wsor.Range(Строка).Merge
                    'Wsor.Range(Строка).WrapText = True
                    Строка = "B" & count & ":B" & countEnd
                    Wsor.Range(Строка).Merge
                    Строка = "C" & count & ":C" & countEnd
                    Wsor.Range(Строка).Merge
                    Строка = "D" & count & ":D" & countEnd
                    Wsor.Range(Строка).Merge
                    Строка = "E" & count & ":E" & countEnd
                    Wsor.Range(Строка).Merge
                    Строка = "F" & count & ":F" & countEnd
                    Wsor.Range(Строка).Merge
                End If

                count = СчетчикСтрок

                Val_A = Row(1)
                Строка = "A" & СчетчикСтрок
                Wsor.Range(Строка).Value = Row(1)

                Строка = "B" & СчетчикСтрок
                Wsor.Range(Строка).Value = Row(2)

                Строка = "C" & СчетчикСтрок
                Wsor.Range(Строка).Value = Row(3)

                Строка = "D" & СчетчикСтрок
                Wsor.Range(Строка).Value = Row(4)
                sum_d += Convert.ToInt64(Row(4))

                Строка = "E" & СчетчикСтрок
                Wsor.Range(Строка).Value = Row(5)
                sum_e += Convert.ToInt64(Row(5))

                Строка = "F" & СчетчикСтрок
                Wsor.Range(Строка).Value = Row(6)
                sum_f += Convert.ToInt64(Row(6))

            Else
                countEnd = СчетчикСтрок
            End If

            Строка = "G" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(7)

            Строка = "H" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(8)

            СчетчикСтрок += 1
            spec = Row(0)
        Next

        ' Для объединения последней группы

        If count <> 0 And countEnd <> 0 And countEnd > count Then
            Строка = "A" & count & ":A" & countEnd
            Wsor.Range(Строка).Merge
            'Wsor.Range(Строка).WrapText = True
            Строка = "B" & count & ":B" & countEnd
            Wsor.Range(Строка).Merge
            Строка = "C" & count & ":C" & countEnd
            Wsor.Range(Строка).Merge
            Строка = "D" & count & ":D" & countEnd
            Wsor.Range(Строка).Merge
            Строка = "E" & count & ":E" & countEnd
            Wsor.Range(Строка).Merge
            Строка = "F" & count & ":F" & countEnd
            Wsor.Range(Строка).Merge
        End If

        Строка = "C" & СчетчикСтрок
        Wsor.Range(Строка).Value = "ИТОГО за " + month
        Строка = "D" & СчетчикСтрок
        Wsor.Range(Строка).Value = Convert.ToString(sum_d)
        Строка = "E" & СчетчикСтрок
        Wsor.Range(Строка).Value = Convert.ToString(sum_e)
        Строка = "F" & СчетчикСтрок
        Wsor.Range(Строка).Value = Convert.ToString(sum_f)
        Строка = "H" & СчетчикСтрок
        Wsor.Range(Строка).Value = Convert.ToString(sum_d)

        Строка = "A7:H" & СчетчикСтрок
        With Wsor.Range(Строка)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .WrapText = True
            .Borders.LineStyle = True
            .VerticalAlignment = -4108
            '.EntireColumn.AutoFit
        End With

        Wsor.Activate

    End Sub

    Sub СозданиеОтчетаРуководителя(Wsor As Object, listData As List(Of List(Of String)), Специальности As Object, Группы As Object)
        Dim Строка, spec As String
        Dim массивЗнач
        Dim Счетчик As Integer, Счетчик2 As Integer, СчетчикСтрок As Integer, Индик As Integer, name As String

        ЗаписьИнформацииДляОтчетаExcell.Массив = Массив

        ReDim массивЗнач(1, 10)

        массивЗнач(0, 0) = "№ Гр"
        массивЗнач(0, 1) = "Курс"
        массивЗнач(0, 2) = "Кол-во часов"
        массивЗнач(0, 3) = "Период обучения"
        массивЗнач(0, 4) = "Количество человек"
        массивЗнач(0, 5) = ""
        массивЗнач(0, 6) = ""
        массивЗнач(0, 7) = "Кол-во групп"
        массивЗнач(0, 8) = ""
        массивЗнач(0, 9) = "Кол-во выполн."
        массивЗнач(0, 10) = ""

        массивЗнач(1, 0) = ""
        массивЗнач(1, 1) = ""
        массивЗнач(1, 2) = ""
        массивЗнач(1, 3) = ""
        массивЗнач(1, 4) = "Всего"
        массивЗнач(1, 5) = "Бюджет"
        массивЗнач(1, 6) = "Внебюджет"
        массивЗнач(1, 7) = "Бюджет"
        массивЗнач(1, 8) = "Внебюджет"
        массивЗнач(1, 9) = "Бюджет"
        массивЗнач(1, 10) = "Внебюджет"

        Wsor.Range("A1").Resize(2, 11) = массивЗнач
        With Wsor.Range("A1").Resize(2, 11)
            .Font.Bold = True
        End With

        Wsor.Range("A1:A2").Merge
        Wsor.Range("B1:B2").Merge
        Wsor.Range("C1:C2").Merge
        Wsor.Range("D1:D2").Merge
        Wsor.Range("E1:G1").Merge
        Wsor.Range("H1:I1").Merge
        Wsor.Range("J1:K1").Merge

        СчетчикСтрок = 3

        For Each Row In listData
            If Row(0) <> spec Then
                Строка = "A" & СчетчикСтрок
                Wsor.Range(Строка).Value = Row(0)
                Строка += ":K" & СчетчикСтрок
                Wsor.Range(Строка).Merge
                СчетчикСтрок += 1
            End If

            Строка = "A" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(1)

            Строка = "B" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(2)

            Строка = "C" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(3)

            Строка = "D" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(4)

            Строка = "E" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(5)

            Строка = "F" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(6)

            Строка = "G" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(7)

            Строка = "H" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(8)

            Строка = "I" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(9)

            Строка = "J" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(10)

            Строка = "K" & СчетчикСтрок
            Wsor.Range(Строка).Value = Row(11)

            СчетчикСтрок += 1
            spec = Row(0)
        Next


        Строка = "A1:K" & СчетчикСтрок - 1
        With Wsor.Range(Строка)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .VerticalAlignment = -4108
            .EntireColumn.AutoFit
        End With

        Wsor.Activate

    End Sub

    Sub СозданиеСводаПоКурсамСпециальностям(WSOR As Object, listData As Object, Критерий As String)
        Dim Строка As String
        Dim НаВывод As Object
        Dim Слушатели As Integer, Наименование As String
        Dim Часы As Object
        Dim Счетчик As Integer, Счетчик2 As Integer, СчетчикСтрок As Integer, Индик As Integer, Столбец As Integer
        ЗаписьИнформацииДляОтчетаExcell.Массив = Массив
        If Критерий = "СводПоКурсам" Then
            Столбец = 6
            Наименование = "Курс"
        End If
        If Критерий = "СводПоСпециальностям" Then
            Столбец = 5
            Наименование = "Специальность"
        End If

        СчетчикСтрок = 2
        Счетчик = 0

        ReDim НаВывод(0, 3)
        НаВывод(0, 0) = Наименование
        НаВывод(0, 1) = "Количество человек"
        НаВывод(0, 2) = "Количество часов"
        НаВывод(0, 3) = "Итого"

        WSOR.Range("A1").Resize(1, 4) = НаВывод
        With WSOR.Range("A1").Resize(1, 4)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .Font.Bold = True
        End With

        WSOR.Range("A2").Resize(UBound(listData, 1) + 1, UBound(listData, 2) + 1) = listData

        With WSOR.Range("A2").Resize(UBound(listData, 1) + 1, UBound(listData, 2) + 1)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .WrapText = False
            .Orientation = 0
            .Font.Bold = True
            .EntireColumn.AutoFit
        End With

        WSOR.Activate

    End Sub


    Sub СозданиеСводаПоОрганизациям(WSOR As Object, Массив As Object)
        Dim ДляВывода As Object


        ReDim ДляВывода(0, 1)
        ДляВывода(0, 0) = "Организация"
        ДляВывода(0, 1) = "Количество человек"

        WSOR.Range("A1").Resize(1, 2) = ДляВывода
        With WSOR.Range("A1").Resize(1, 2)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True
            .Font.Bold = True

        End With

        Массив = перевернутьмассив(Массив)
        WSOR.Range("A2").Resize(UBound(Массив, 1) + 1, 2) = Массив

        With WSOR.Range("A2").Resize(UBound(Массив, 1) + 1, 2)
            .Font.Name = "Times New Roman"
            .Font.Size = 11
            .HorizontalAlignment = -4131
            .EntireColumn.AutoFit
            .Borders.LineStyle = True


        End With

        WSOR.Activate
    End Sub


    Sub СозданиеОтчетаБюджетВнебюджет(WSOR As Object, МассивОтчета As Object, часы As Object)
        Dim stat As Boolean = False
        Dim Шаблон
        Dim Бюджет
        Dim Внебюджет
        Dim Итог
        Dim Счетчик As Integer, Счетчик2 As Integer, Счетчик3 As Integer, Счетчик4 As Integer, КоличествоГрупп As Integer, КоличествоСлушателей As Integer, КоличествоМужчин As Integer, КоличествоМужчинЗа60 As Integer, Возраст As Integer
        Dim Критерий As String, Ячейка As String
        Dim ДатаРождения As Date
        Dim СуммаБюджет, СуммаВнеБюджет, СуммаИтог As Double
        Dim listData As List(Of List(Of String)) = МассивОтчета(0)
        Dim listDataB As List(Of List(Of String)) = МассивОтчета(1)
        Dim listDataVB As List(Of List(Of String)) = МассивОтчета(2)

        WSOR.Cells(1, 1) = "БЮДЖЕТ"
        WSOR.Cells(11, 1) = "ВНЕБЮДЖЕТ"
        WSOR.Cells(21, 1) = "ИТОГО"

        Счетчик2 = 0

        While Счетчик2 <= 2
            With WSOR.Cells((Счетчик2 * 10 + 1), (Счетчик + 1))
                .Font.Name = "Times New Roman"
                .Font.Size = 11
                .HorizontalAlignment = -4131
                .EntireColumn.AutoFit
                .WrapText = False
                .Orientation = 0
                .Font.Bold = True
                .EntireColumn.AutoFit

            End With
            Счетчик2 = Счетчик2 + 1
        End While

        Счетчик = 0
        ReDim Шаблон(5, UBound(часы, 2) + 2)

        While Счетчик <= UBound(часы, 2)

            Шаблон(0, Счетчик + 1) = часы(1, Счетчик) & " час."

            Счетчик = Счетчик + 1
        End While

        Шаблон(0, Счетчик + 1) = "ИТОГО"
        Шаблон(1, 0) = "Кол-во человек"
        Шаблон(2, 0) = "из них мужчин"
        Шаблон(3, 0) = "из них старше 60 лет"
        Шаблон(4, 0) = "выполнено часов"
        Шаблон(5, 0) = "кол-во групп"



        Счетчик2 = 0

        While Счетчик2 <= 2
            Ячейка = "A" & Счетчик2 * 10 + 2
            WSOR.Range(Ячейка).Resize(6, UBound(часы, 2) + 3) = Шаблон

            With WSOR.Range(Ячейка).Resize(6, UBound(часы, 2) + 3)
                .Font.Name = "Times New Roman"
                .Font.Size = 11
                .HorizontalAlignment = -4131
                .EntireColumn.AutoFit
                .Borders.LineStyle = True
                .WrapText = False
                .Orientation = 0
                .Font.Bold = True
                .EntireColumn.AutoFit
            End With
            Счетчик2 = Счетчик2 + 1
        End While


        ReDim Бюджет(4, UBound(часы, 2) + 1)
        ReDim Внебюджет(4, UBound(часы, 2) + 1)
        ReDim Итог(4, UBound(часы, 2) + 1)
        Счетчик2 = 0


        While Счетчик2 <= 2
            If Счетчик2 = 0 Then Критерий = "бюджет"
            If Счетчик2 = 1 Then Критерий = "внебюджет"

            Счетчик = 0
            While Счетчик <= UBound(часы, 2)

                If Счетчик2 = 0 Then
                    For Each List As List(Of String) In listDataB
                        If List(0) = часы(1, Счетчик) Then
                            Бюджет(0, Счетчик) = List(1)
                            Бюджет(1, Счетчик) = List(2)
                            Бюджет(2, Счетчик) = List(3)
                            Бюджет(3, Счетчик) = List(4)
                            Бюджет(4, Счетчик) = List(5)
                        End If
                    Next
                ElseIf Счетчик2 = 1 Then
                    For Each ListVB As List(Of String) In listDataVB
                        If ListVB(0) = часы(1, Счетчик) Then
                            Внебюджет(0, Счетчик) = ListVB(1)
                            Внебюджет(1, Счетчик) = ListVB(2)
                            Внебюджет(2, Счетчик) = ListVB(3)
                            Внебюджет(3, Счетчик) = ListVB(4)
                            Внебюджет(4, Счетчик) = ListVB(5)
                        End If
                    Next
                Else
                    For Each List As List(Of String) In listData
                        If List(0) = часы(1, Счетчик) Then
                            Итог(0, Счетчик) = List(1)
                            Итог(1, Счетчик) = List(2)
                            Итог(2, Счетчик) = List(3)
                            Итог(3, Счетчик) = List(4)
                            Итог(4, Счетчик) = List(5)
                        End If
                    Next
                End If

                Счетчик = Счетчик + 1
            End While

            Счетчик2 = Счетчик2 + 1

        End While

        Счетчик2 = 0
        Счетчик4 = UBound(Бюджет, 1)
        While Счетчик2 <= UBound(Бюджет, 1)
            СуммаИтог = 0
            СуммаВнеБюджет = 0
            СуммаБюджет = 0
            Счетчик = 0
            While Счетчик <= UBound(Бюджет, 2)
                Счетчик3 = UBound(Бюджет, 2)
                If Счетчик = UBound(Бюджет, 2) Then
                    Внебюджет(Счетчик2, Счетчик) = Convert.ToString(СуммаВнеБюджет)
                    Бюджет(Счетчик2, Счетчик) = Convert.ToString(СуммаБюджет)
                    Итог(Счетчик2, Счетчик) = Convert.ToString(СуммаИтог)
                Else
                    If Strings.Trim(Внебюджет(Счетчик2, Счетчик)) = "" Then
                        Внебюджет(Счетчик2, Счетчик) = 0
                    End If
                    If Strings.Trim(Бюджет(Счетчик2, Счетчик)) = "" Then
                        Бюджет(Счетчик2, Счетчик) = 0
                    End If
                    If Strings.Trim(Итог(Счетчик2, Счетчик)) = "" Then
                        Итог(Счетчик2, Счетчик) = 0
                    End If
                    СуммаВнеБюджет = СуммаВнеБюджет + Convert.ToDouble(Внебюджет(Счетчик2, Счетчик))
                    СуммаБюджет = СуммаБюджет + Convert.ToDouble(Бюджет(Счетчик2, Счетчик))
                    СуммаИтог = СуммаИтог + Convert.ToDouble(Итог(Счетчик2, Счетчик))
                End If

                Счетчик = Счетчик + 1

            End While

            Счетчик2 = Счетчик2 + 1
        End While

        WSOR.Range("B3").Resize(5, UBound(Бюджет, 2) + 1) = Бюджет

        WSOR.Range("B13").Resize(5, UBound(Бюджет, 2) + 1) = Внебюджет

        WSOR.Range("B23").Resize(5, UBound(Бюджет, 2) + 1) = Итог

        WSOR.Activate
    End Sub




    Sub ПодсчетСлушателейВгруппе(номерГруппы As String)

        Dim СчетчикСтрок As Integer, Счетчик As Integer
        счетСлушателей = 0
        СчетчикСтрок = 0
        Счетчик = 0
        While СчетчикСтрок <= UBound(Массив, 2)

            If номерГруппы = Массив(1, СчетчикСтрок) Then

                Счетчик = Счетчик + 1

                If Массив(18, СчетчикСтрок) = "Федеральный бюджет" Then

                    счетБюджет = счетБюджет + 1

                End If



            End If

            СчетчикСтрок = СчетчикСтрок + 1
        End While

        счетСлушателей = Счетчик
    End Sub

    Sub test(Wb As Object)

        Dim WSOR

        WSOR = Wb.Worksheets(1)
        WSOR.Range("A1") = "Сработало"


    End Sub


End Module
