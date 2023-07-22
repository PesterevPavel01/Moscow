﻿Module ЗаполнитьРедакторГруппы

    Sub ЗаполнитьРедакторГруппы(НомерГруппы As String)
        Dim queryString As String

        queryString = loadGroup(СправочникГруппы.kod)

        СправочникГруппы.ИнформацияОГруппе = ЗагрузитьИзБазы.ЗагрузитьИзБазы(queryString)

        СправочникГруппы.gruppaData.urKvalific = СправочникГруппы.ИнформацияОГруппе(21, 0)
        РедакторГруппы.НоваяГруппаУровеньКвалификации.Text = СправочникГруппы.ИнформацияОГруппе(21, 0)

        СправочникГруппы.gruppaData.number = СправочникГруппы.ИнформацияОГруппе(1, 0)
        РедакторГруппы.НоваяГруппаНомер.Text = СправочникГруппы.ИнформацияОГруппе(1, 0)

        СправочникГруппы.gruppaData.formaObuch = СправочникГруппы.ИнформацияОГруппе(2, 0)
        РедакторГруппы.НоваяГруппаФормаОбучения.Text = СправочникГруппы.ИнформацияОГруппе(2, 0)
        Try
            РедакторГруппы.НоваяГруппаДатаНачалаЗанятий.Value = СправочникГруппы.ИнформацияОГруппе(3, 0)
        Catch ex As Exception

        End Try
        СправочникГруппы.gruppaData.dataNZ = СправочникГруппы.ИнформацияОГруппе(3, 0)
        Try
            РедакторГруппы.НоваяГруппаКонецЗанятий.Value = СправочникГруппы.ИнформацияОГруппе(4, 0)
        Catch ex As Exception

        End Try
        СправочникГруппы.gruppaData.dataKZ = СправочникГруппы.ИнформацияОГруппе(4, 0)


        РедакторГруппы.НоваяГруппаСпециальность.Text = СправочникГруппы.ИнформацияОГруппе(5, 0)
        СправочникГруппы.gruppaData.specialnost = СправочникГруппы.ИнформацияОГруппе(5, 0)

        РедакторГруппы.НоваяГруппаПрограмма.Text = СправочникГруппы.ИнформацияОГруппе(6, 0)
        СправочникГруппы.gruppaData.programma = СправочникГруппы.ИнформацияОГруппе(6, 0)

        If IsNumeric(СправочникГруппы.ИнформацияОГруппе(37, 0)) Then
            РедакторГруппы.setProgKod(Convert.ToInt64(СправочникГруппы.ИнформацияОГруппе(37, 0)))
        End If
        РедакторГруппы.setflagAllListProgs(False)

        'РедакторГруппы.НоваяГруппаКоличествоЧасов.Text = СправочникГруппы.ИнформацияОГруппе(7, 0)
        'СправочникГруппы.gruppaData.kolChasov = СправочникГруппы.ИнформацияОГруппе(7, 0)
        РедакторГруппы.НоваяГруппаОтветственныйКуратор.Text = СправочникГруппы.ИнформацияОГруппе(8, 0)
        СправочникГруппы.gruppaData.kurator = СправочникГруппы.ИнформацияОГруппе(8, 0)
        РедакторГруппы.НоваягруппаОтветственныйЗаПрактику.Text = СправочникГруппы.ИнформацияОГруппе(9, 0)
        СправочникГруппы.gruppaData.otvZaPraktiku = СправочникГруппы.ИнформацияОГруппе(9, 0)
        РедакторГруппы.Модуль1.Text = СправочникГруппы.ИнформацияОГруппе(11, 0)
        СправочникГруппы.gruppaData.modul1 = СправочникГруппы.ИнформацияОГруппе(11, 0)
        РедакторГруппы.Модуль2.Text = СправочникГруппы.ИнформацияОГруппе(12, 0)
        СправочникГруппы.gruppaData.modul2 = СправочникГруппы.ИнформацияОГруппе(12, 0)
        РедакторГруппы.Модуль3.Text = СправочникГруппы.ИнформацияОГруппе(13, 0)
        СправочникГруппы.gruppaData.modul3 = СправочникГруппы.ИнформацияОГруппе(13, 0)
        РедакторГруппы.Модуль4.Text = СправочникГруппы.ИнформацияОГруппе(14, 0)
        СправочникГруппы.gruppaData.modul4 = СправочникГруппы.ИнформацияОГруппе(14, 0)
        РедакторГруппы.Модуль5.Text = СправочникГруппы.ИнформацияОГруппе(15, 0)
        СправочникГруппы.gruppaData.modul5 = СправочникГруппы.ИнформацияОГруппе(15, 0)
        РедакторГруппы.Модуль6.Text = СправочникГруппы.ИнформацияОГруппе(16, 0)
        СправочникГруппы.gruppaData.modul6 = СправочникГруппы.ИнформацияОГруппе(16, 0)
        РедакторГруппы.Модуль7.Text = СправочникГруппы.ИнформацияОГруппе(17, 0)
        СправочникГруппы.gruppaData.modul7 = СправочникГруппы.ИнформацияОГруппе(17, 0)
        РедакторГруппы.Модуль8.Text = СправочникГруппы.ИнформацияОГруппе(18, 0)
        СправочникГруппы.gruppaData.modul8 = СправочникГруппы.ИнформацияОГруппе(18, 0)
        РедакторГруппы.Модуль9.Text = СправочникГруппы.ИнформацияОГруппе(19, 0)
        СправочникГруппы.gruppaData.modul9 = СправочникГруппы.ИнформацияОГруппе(19, 0)
        РедакторГруппы.Модуль10.Text = СправочникГруппы.ИнформацияОГруппе(20, 0)
        СправочникГруппы.gruppaData.modul10 = СправочникГруппы.ИнформацияОГруппе(20, 0)
        РедакторГруппы.НоваяГруппаФинансирование.Text = СправочникГруппы.ИнформацияОГруппе(22, 0)
        СправочникГруппы.gruppaData.financir = СправочникГруппы.ИнформацияОГруппе(22, 0)

        If СправочникГруппы.ИнформацияОГруппе(21, 0) = "повышение квалификации" Then

            РедакторГруппы.НомерУд.Text = СправочникГруппы.ИнформацияОГруппе(24, 0)
            СправочникГруппы.gruppaData.nomerUd = СправочникГруппы.ИнформацияОГруппе(24, 0)
            РедакторГруппы.РегНомерУд.Text = СправочникГруппы.ИнформацияОГруппе(25, 0)
            СправочникГруппы.gruppaData.regNomerUd = СправочникГруппы.ИнформацияОГруппе(25, 0)
            Try
                РедакторГруппы.ДатаВыдачиУд.Value = СправочникГруппы.ИнформацияОГруппе(26, 0)
            Catch ex As Exception
            End Try

        ElseIf (СправочникГруппы.ИнформацияОГруппе(21, 0) = "профессиональная переподготовка") Then
            РедакторГруппы.НомерДиплома.Text = СправочникГруппы.ИнформацияОГруппе(27, 0)
            СправочникГруппы.gruppaData.nomerDiploma = СправочникГруппы.ИнформацияОГруппе(27, 0)
            РедакторГруппы.РегНомерДиплома.Text = СправочникГруппы.ИнформацияОГруппе(28, 0)
            СправочникГруппы.gruppaData.regNomerDiploma = СправочникГруппы.ИнформацияОГруппе(28, 0)
            Try
                РедакторГруппы.ДатаВДиплома.Value = СправочникГруппы.ИнформацияОГруппе(29, 0)
            Catch ex As Exception

            End Try
            РедакторГруппы.НомерПротоколаИА.Text = СправочникГруппы.ИнформацияОГруппе(23, 0)
            СправочникГруппы.gruppaData.nomerProtIA = СправочникГруппы.ИнформацияОГруппе(23, 0)

        ElseIf (СправочникГруппы.ИнформацияОГруппе(21, 0) = "профессиональное обучение") Then
            РедакторГруппы.НомерСвид.Text = СправочникГруппы.ИнформацияОГруппе(30, 0)
            СправочникГруппы.gruppaData.nomerSvid = СправочникГруппы.ИнформацияОГруппе(30, 0)
            РедакторГруппы.РегНомерСвид.Text = СправочникГруппы.ИнформацияОГруппе(31, 0)
            СправочникГруппы.gruppaData.nomerSvid = СправочникГруппы.ИнформацияОГруппе(31, 0)
            Try
                РедакторГруппы.ДатаВСвид.Value = СправочникГруппы.ИнформацияОГруппе(32, 0)
            Catch ex As Exception

            End Try
            РедакторГруппы.НомерПротоколаИА.Text = СправочникГруппы.ИнформацияОГруппе(23, 0)
            СправочникГруппы.gruppaData.nomerProtIA = СправочникГруппы.ИнформацияОГруппе(23, 0)
        ElseIf (СправочникГруппы.ИнформацияОГруппе(21, 0) = "специальный экзамен") Then
            РедакторГруппы.НомерПротоколаСпецэкзамен.Text = СправочникГруппы.ИнформацияОГруппе(36, 0)
            СправочникГруппы.gruppaData.nomerProtokolaSpec = СправочникГруппы.ИнформацияОГруппе(36, 0)
            Try
                РедакторГруппы.ДатаСпецэкзамен.Value = СправочникГруппы.ИнформацияОГруппе(35, 0)
            Catch ex As Exception

            End Try
        End If
        РедакторГруппы.Квалификация.Text = СправочникГруппы.ИнформацияОГруппе(33, 0)
        СправочникГруппы.gruppaData.kvalifikaciya = СправочникГруппы.ИнформацияОГруппе(33, 0)
        СправочникГруппы.gruppaData.osnovnoyDok = СправочникГруппы.ИнформацияОГруппе(34, 0)

    End Sub

End Module
