Imports System.Threading
Imports mySqlConnector
Module ЗаписьВБазу
    Public Ждать As Boolean = False
    Public УдалитьСовпадения As Boolean = False
    Public записано As Boolean = False
    Public ОшибкаПС As Boolean = False
    Public ОшибкаЗБ As Boolean = False
    Public РазрешениеЗаписиВОбщуюБазу As Boolean = True

    Sub ЗаписьВБазу(СтрокаЗапроса As String, Optional Таблица As String = "БезПроверки", Optional Критерий As String = "БезПроверки", Optional значениеКритерия As String = "Нет")
        Dim Совпадение As Boolean = False
        Dim СчетчикПереподключений As Integer = 0
        ОшибкаЗБ = False
        Совпадение = False

        If Not Таблица = "БезПроверки" Then

            If Not Критерий = "БезПроверки" Or значениеКритерия = "нет" Then

                Совпадение = ПроверкаСовпадений(Таблица, Критерий, значениеКритерия)

                If ОшибкаПС Then

                    Exit Sub

                End If

                If Совпадение Then

                    ФормаДаНет.ShowDialog()
                    Совпадение = False
                    If Not УдалитьСовпадения Then
                        НоваяГруппа.zakr = True
                        Exit Sub
                    End If

                End If

            Else
                MsgBox("Введи все критерии, необходимые для процедуры проверки совпадений")
                Exit Sub
            End If

        End If



        If УдалитьСовпадения Then

            УдалитьЗаписи(Таблица, Критерий, значениеКритерия)
            УдалитьСовпадения = False

        End If

        ААОсновная.mySqlConnect.ОтправитьВбдЗапись(СтрокаЗапроса, 1)

    End Sub

    Function ПроверкаСовпадений(Таблица As String, Критерий As String, значениеКритерия As String, Optional Критерий2 As String = "Not", Optional значениеКритерия2 As String = "Not", Optional Критерий3 As String = "Not", Optional значениеКритерия3 As String = "Not") As Boolean
        Dim СтрокаЗапроса As String
        Dim massiv

        If Критерий2 = "Not" Or значениеКритерия2 = "Not" Then

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & Chr(39) & значениеКритерия & Chr(39)

        ElseIf Критерий3 = "Not" Or значениеКритерия3 = "Not" Then

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & Chr(39) & значениеКритерия & Chr(39) & " AND " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39)

        Else

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & Chr(39) & значениеКритерия & Chr(39) & " And " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39) & " And " & Критерий3 & " = " & Chr(39) & значениеКритерия3 & Chr(39)

        End If

        massiv = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1)

        If massiv(0, 0).ToString = "нет записей" Then

            Return False

        End If

        Return True

    End Function
    Function ПроверкаСовпаденийЧислоДА_2(Таблица As String, Критерий As String, значениеКритерия As Integer, Optional Критерий2 As String = "Not", Optional значениеКритерия2 As String = "Not", Optional Критерий3 As String = "Not", Optional значениеКритерия3 As String = "Not") As Integer
        Dim СтрокаЗапроса As String
        Dim massiv
        Dim result As Integer = 0

        If Критерий2 = "Not" Or значениеКритерия2 = "Not" Then

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & значениеКритерия

        ElseIf Критерий3 = "Not" Or значениеКритерия3 = "Not" Then

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & значениеКритерия & " AND " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39)

        Else

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & значениеКритерия & " And " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39) & " And " & Критерий3 & " = " & Chr(39) & значениеКритерия3 & Chr(39)

        End If

        massiv = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1)

        If massiv(0, 0).ToString = "нет записей" Then

            Return 1

        End If

        Return 2

    End Function
    Function ПроверкаСовпаденийГруппа(Таблица As String, Критерий As String, значениеКритерия As String, Optional Критерий2 As String = "Not", Optional значениеКритерия2 As String = "Not", Optional Критерий3 As String = "Not", Optional значениеКритерия3 As String = "Not") As Boolean
        Dim СтрокаЗапроса As String
        Dim massiv

        If Критерий2 = "Not" Or значениеКритерия2 = "Not" Then

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & Chr(39) & значениеКритерия & Chr(39)

        ElseIf Критерий3 = "Not" Or значениеКритерия3 = "Not" Then

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & Chr(39) & значениеКритерия & Chr(39) & " AND " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39)

        Else

            СтрокаЗапроса = "SELECT * FROM " & Таблица & " WHERE " & Критерий & " = " & Chr(39) & значениеКритерия & Chr(39) & " And " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39) & " And " & Критерий3 & " = " & Chr(39) & значениеКритерия3 & Chr(39)

        End If

        massiv = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1)

        If massiv(0, 0).ToString = "нет записей" Then

            Return False

        End If

        Return True

    End Function

    Sub УдалитьЗаписи(Таблица As String, Критерий As String, значениеКритерия As String, Optional Критерий2 As String = "", Optional значениеКритерия2 As String = "")

        Dim СтрокаЗапроса As String
        Dim СчетчикПереподключений As Integer = 0

        СтрокаЗапроса = "DELETE FROM " & Таблица & " WHERE " & Критерий & " = " & Chr(39) & значениеКритерия & Chr(39)
        If Not Критерий2 = "" Then
            СтрокаЗапроса += " AND " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39)
        End If
        If Not ААОсновная.mySqlConnect.ОтправитьВбдЗапись(СтрокаЗапроса, 1) Then
            предупреждение.текст.Text = "не удалось удалить запись!"
            ОткрытьФорму(предупреждение)
        End If

    End Sub
    Sub УдалитьЗаписиСЧислом(Таблица As String, Критерий As String, значениеКритерия As Integer, Optional Критерий2 As String = "", Optional значениеКритерия2 As String = "")

        Dim СтрокаЗапроса As String
        Dim СчетчикПереподключений As Integer = 0

        СтрокаЗапроса = "DELETE FROM " & Таблица & " WHERE " & Критерий & " = " & значениеКритерия
        If Not Критерий2 = "" Then
            СтрокаЗапроса += " AND " & Критерий2 & " = " & Chr(39) & значениеКритерия2 & Chr(39)
        End If
        If Not ААОсновная.mySqlConnect.ОтправитьВбдЗапись(СтрокаЗапроса, 1) Then
            предупреждение.текст.Text = "не удалось удалить запись!"
            ОткрытьФорму(предупреждение)
        End If

    End Sub

End Module
