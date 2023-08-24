Module ЗаполнитьРедакторГруппы

    Sub ЗаполнитьРедакторГруппы(НомерГруппы As String)
        Dim queryString As String

        queryString = loadGroup(СправочникГруппы.kod)

        СправочникГруппы.infoAboutGroup = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        СправочникГруппы.gruppaData.urKvalific = СправочникГруппы.infoAboutGroup(21, 0)
        РедакторГруппы.НоваяГруппаУровеньКвалификации.Text = СправочникГруппы.infoAboutGroup(21, 0)

        СправочникГруппы.gruppaData.number = СправочникГруппы.infoAboutGroup(1, 0)
        РедакторГруппы.НоваяГруппаНомер.Text = СправочникГруппы.infoAboutGroup(1, 0)

        СправочникГруппы.gruppaData.formaObuch = СправочникГруппы.infoAboutGroup(2, 0)
        РедакторГруппы.НоваяГруппаФормаОбучения.Text = СправочникГруппы.infoAboutGroup(2, 0)
        Try
            РедакторГруппы.НоваяГруппаДатаНачалаЗанятий.Value = СправочникГруппы.infoAboutGroup(3, 0)
        Catch ex As Exception

        End Try
        СправочникГруппы.gruppaData.dataNZ = СправочникГруппы.infoAboutGroup(3, 0)
        Try
            РедакторГруппы.НоваяГруппаКонецЗанятий.Value = СправочникГруппы.infoAboutGroup(4, 0)
        Catch ex As Exception

        End Try
        СправочникГруппы.gruppaData.dataKZ = СправочникГруппы.infoAboutGroup(4, 0)


        РедакторГруппы.НоваяГруппаСпециальность.Text = СправочникГруппы.infoAboutGroup(5, 0)
        СправочникГруппы.gruppaData.specialnost = СправочникГруппы.infoAboutGroup(5, 0)

        РедакторГруппы.НоваяГруппаПрограмма.Text = СправочникГруппы.infoAboutGroup(6, 0)
        СправочникГруппы.gruppaData.programma = СправочникГруппы.infoAboutGroup(6, 0)

        If IsNumeric(СправочникГруппы.infoAboutGroup(37, 0)) Then
            РедакторГруппы.setProgKod(Convert.ToInt64(СправочникГруппы.infoAboutGroup(37, 0)))
        End If
        РедакторГруппы.setflagAllListProgs(False)

        РедакторГруппы.НоваяГруппаОтветственныйКуратор.Text = СправочникГруппы.infoAboutGroup(8, 0)
        СправочникГруппы.gruppaData.kurator = СправочникГруппы.infoAboutGroup(8, 0)
        РедакторГруппы.НоваягруппаОтветственныйЗаПрактику.Text = СправочникГруппы.infoAboutGroup(9, 0)
        СправочникГруппы.gruppaData.otvZaPraktiku = СправочникГруппы.infoAboutGroup(9, 0)
        РедакторГруппы.Модуль1.Text = СправочникГруппы.infoAboutGroup(11, 0)
        СправочникГруппы.gruppaData.modul1 = СправочникГруппы.infoAboutGroup(11, 0)
        РедакторГруппы.Модуль2.Text = СправочникГруппы.infoAboutGroup(12, 0)
        СправочникГруппы.gruppaData.modul2 = СправочникГруппы.infoAboutGroup(12, 0)
        РедакторГруппы.Модуль3.Text = СправочникГруппы.infoAboutGroup(13, 0)
        СправочникГруппы.gruppaData.modul3 = СправочникГруппы.infoAboutGroup(13, 0)
        РедакторГруппы.Модуль4.Text = СправочникГруппы.infoAboutGroup(14, 0)
        СправочникГруппы.gruppaData.modul4 = СправочникГруппы.infoAboutGroup(14, 0)
        РедакторГруппы.Модуль5.Text = СправочникГруппы.infoAboutGroup(15, 0)
        СправочникГруппы.gruppaData.modul5 = СправочникГруппы.infoAboutGroup(15, 0)
        РедакторГруппы.Модуль6.Text = СправочникГруппы.infoAboutGroup(16, 0)
        СправочникГруппы.gruppaData.modul6 = СправочникГруппы.infoAboutGroup(16, 0)
        РедакторГруппы.Модуль7.Text = СправочникГруппы.infoAboutGroup(17, 0)
        СправочникГруппы.gruppaData.modul7 = СправочникГруппы.infoAboutGroup(17, 0)
        РедакторГруппы.Модуль8.Text = СправочникГруппы.infoAboutGroup(18, 0)
        СправочникГруппы.gruppaData.modul8 = СправочникГруппы.infoAboutGroup(18, 0)
        РедакторГруппы.Модуль9.Text = СправочникГруппы.infoAboutGroup(19, 0)
        СправочникГруппы.gruppaData.modul9 = СправочникГруппы.infoAboutGroup(19, 0)
        РедакторГруппы.Модуль10.Text = СправочникГруппы.infoAboutGroup(20, 0)
        СправочникГруппы.gruppaData.modul10 = СправочникГруппы.infoAboutGroup(20, 0)
        РедакторГруппы.НоваяГруппаФинансирование.Text = СправочникГруппы.infoAboutGroup(22, 0)
        СправочникГруппы.gruppaData.financir = СправочникГруппы.infoAboutGroup(22, 0)

        If СправочникГруппы.infoAboutGroup(21, 0) = "повышение квалификации" Then

            РедакторГруппы.НомерУд.Text = СправочникГруппы.infoAboutGroup(24, 0)

            If checkNumber(СправочникГруппы.infoAboutGroup(24, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.numberUd = СправочникГруппы.infoAboutGroup(24, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.numberUd = 0
            End If

            РедакторГруппы.РегНомерУд.Text = СправочникГруппы.infoAboutGroup(25, 0)

            If checkNumber(СправочникГруппы.infoAboutGroup(25, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.regNumberUd = СправочникГруппы.infoAboutGroup(25, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.regNumberUd = 0
            End If

            Try
                РедакторГруппы.ДатаВыдачиУд.Value = СправочникГруппы.infoAboutGroup(26, 0)
            Catch ex As Exception
            End Try

        ElseIf (СправочникГруппы.infoAboutGroup(21, 0) = "профессиональная переподготовка") Then
            РедакторГруппы.НомерДиплома.Text = СправочникГруппы.infoAboutGroup(27, 0)

            If checkNumber(СправочникГруппы.infoAboutGroup(27, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.numberD = СправочникГруппы.infoAboutGroup(27, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.numberD = 0
            End If

            РедакторГруппы.РегНомерДиплома.Text = СправочникГруппы.infoAboutGroup(28, 0)

            If checkNumber(СправочникГруппы.infoAboutGroup(28, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.regNumberD = СправочникГруппы.infoAboutGroup(28, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.regNumberD = 0
            End If

            Try
                РедакторГруппы.ДатаВДиплома.Value = СправочникГруппы.infoAboutGroup(29, 0)
            Catch ex As Exception

            End Try

            РедакторГруппы.НомерПротоколаИА.Text = СправочникГруппы.infoAboutGroup(23, 0)

            If checkNumber(СправочникГруппы.infoAboutGroup(23, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.numberIA = СправочникГруппы.infoAboutGroup(23, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.numberIA = 0
            End If

        ElseIf (СправочникГруппы.infoAboutGroup(21, 0) = "профессиональное обучение") Then

            РедакторГруппы.НомерСвид.Text = СправочникГруппы.infoAboutGroup(30, 0)



            If checkNumber(СправочникГруппы.infoAboutGroup(30, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.numberSv = СправочникГруппы.infoAboutGroup(30, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.numberSv = 0
            End If

            РедакторГруппы.РегНомерСвид.Text = СправочникГруппы.infoAboutGroup(31, 0)

            If checkNumber(СправочникГруппы.infoAboutGroup(31, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.regNumberSv = СправочникГруппы.infoAboutGroup(31, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.regNumberSv = 0
            End If


            Try
                РедакторГруппы.ДатаВСвид.Value = СправочникГруппы.infoAboutGroup(32, 0)
            Catch ex As Exception

            End Try

            РедакторГруппы.НомерПротоколаИА.Text = СправочникГруппы.infoAboutGroup(23, 0)

            If checkNumber(СправочникГруппы.infoAboutGroup(23, 0), "none", False) Then
                СправочникГруппы.gruppaData.numbersUDS.numberIA = СправочникГруппы.infoAboutGroup(23, 0)
            Else
                СправочникГруппы.gruppaData.numbersUDS.numberIA = 0
            End If

        End If

        РедакторГруппы.Квалификация.Text = СправочникГруппы.infoAboutGroup(33, 0)
        СправочникГруппы.gruppaData.kvalifikaciya = СправочникГруппы.infoAboutGroup(33, 0)
        СправочникГруппы.gruppaData.mainDocument = СправочникГруппы.infoAboutGroup(34, 0)

    End Sub

End Module
