Module updateGroupRedactor

    Sub update(groupNumber As String)

        Dim queryString As String

        queryString = loadGroup(GroupList.kod)

        GroupList.infoAboutGroup = MainForm.mySqlConnect.loadMySqlToArray(queryString, 1)

        GroupList.gruppaData.urKvalific = GroupList.infoAboutGroup(21, 0)

        'newGroup.НоваяГруппаУровеньКвалификации.Text = GroupList.infoAboutGroup(21, 0)

        GroupList.gruppaData.number = GroupList.infoAboutGroup(1, 0)
        newGroup.НоваяГруппаНомер.Text = GroupList.infoAboutGroup(1, 0)

        GroupList.gruppaData.formaObuch = GroupList.infoAboutGroup(2, 0)
        newGroup.НоваяГруппаФормаОбучения.Text = GroupList.infoAboutGroup(2, 0)
        Try
            newGroup.НоваяГруппаДатаНачалаЗанятий.Value = GroupList.infoAboutGroup(3, 0)
        Catch ex As Exception

        End Try
        GroupList.gruppaData.dataNZ = GroupList.infoAboutGroup(3, 0)
        Try
            newGroup.НоваяГруппаКонецЗанятий.Value = GroupList.infoAboutGroup(4, 0)
        Catch ex As Exception

        End Try
        GroupList.gruppaData.dataKZ = GroupList.infoAboutGroup(4, 0)


        newGroup.НоваяГруппаСпециальность.Text = GroupList.infoAboutGroup(5, 0)
        GroupList.gruppaData.speciality = GroupList.infoAboutGroup(5, 0)

        newGroup.НоваяГруппаОтветственныйКуратор.Text = GroupList.infoAboutGroup(8, 0)
        GroupList.gruppaData.kurator = GroupList.infoAboutGroup(8, 0)
        newGroup.НоваягруппаОтветственныйЗаПрактику.Text = GroupList.infoAboutGroup(9, 0)
        GroupList.gruppaData.otvZaPraktiku = GroupList.infoAboutGroup(9, 0)
        GroupList.gruppaData.financir = GroupList.infoAboutGroup(22, 0)

        If GroupList.infoAboutGroup(21, 0) = "повышение квалификации" Then

            newGroup.НомерУд.Text = GroupList.infoAboutGroup(24, 0)

            If checkNumber(GroupList.infoAboutGroup(24, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.numberUd = GroupList.infoAboutGroup(24, 0)
            Else
                GroupList.gruppaData.numbersUDS.numberUd = 0
            End If

            newGroup.РегНомерУд.Text = GroupList.infoAboutGroup(25, 0)

            If checkNumber(GroupList.infoAboutGroup(25, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.regNumberUd = GroupList.infoAboutGroup(25, 0)
            Else
                GroupList.gruppaData.numbersUDS.regNumberUd = 0
            End If

            Try
                newGroup.ДатаВыдачиУд.Value = GroupList.infoAboutGroup(26, 0)
            Catch ex As Exception
            End Try

        ElseIf (GroupList.infoAboutGroup(21, 0) = "профессиональная переподготовка") Then

            newGroup.НомерДиплома.Text = GroupList.infoAboutGroup(27, 0)

            If checkNumber(GroupList.infoAboutGroup(27, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.numberD = GroupList.infoAboutGroup(27, 0)
            Else
                GroupList.gruppaData.numbersUDS.numberD = 0
            End If

            newGroup.РегНомерДиплома.Text = GroupList.infoAboutGroup(28, 0)

            If checkNumber(GroupList.infoAboutGroup(28, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.regNumberD = GroupList.infoAboutGroup(28, 0)
            Else
                GroupList.gruppaData.numbersUDS.regNumberD = 0
            End If

            Try
                newGroup.ДатаВДиплома.Value = GroupList.infoAboutGroup(29, 0)
            Catch ex As Exception

            End Try

            newGroup.НоваяГруппаНомерПротоколаИА.Text = GroupList.infoAboutGroup(23, 0)

            If checkNumber(GroupList.infoAboutGroup(23, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.numberIA = GroupList.infoAboutGroup(23, 0)
            Else
                GroupList.gruppaData.numbersUDS.numberIA = 0
            End If

        ElseIf (GroupList.infoAboutGroup(21, 0) = "профессиональное обучение") Then

            newGroup.НомерСвид.Text = GroupList.infoAboutGroup(30, 0)

            If checkNumber(GroupList.infoAboutGroup(30, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.numberSv = GroupList.infoAboutGroup(30, 0)
            Else
                GroupList.gruppaData.numbersUDS.numberSv = 0
            End If

            newGroup.РегНомерСвид.Text = GroupList.infoAboutGroup(31, 0)

            If checkNumber(GroupList.infoAboutGroup(31, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.regNumberSv = GroupList.infoAboutGroup(31, 0)
            Else
                GroupList.gruppaData.numbersUDS.regNumberSv = 0
            End If

            Try
                newGroup.ДатаВСвид.Value = GroupList.infoAboutGroup(32, 0)
            Catch ex As Exception

            End Try

            newGroup.НоваяГруппаНомерПротоколаИА.Text = GroupList.infoAboutGroup(23, 0)

            If checkNumber(GroupList.infoAboutGroup(23, 0), "none", False) Then
                GroupList.gruppaData.numbersUDS.numberIA = GroupList.infoAboutGroup(23, 0)
            Else
                GroupList.gruppaData.numbersUDS.numberIA = 0
            End If

        End If

        newGroup.НоваяГруппаПрограмма.Text = GroupList.infoAboutGroup(6, 0)
        Dim pr As String = GroupList.infoAboutGroup(6, 0)
        pr = newGroup.НоваяГруппаПрограмма.Text
        GroupList.gruppaData.program = GroupList.infoAboutGroup(6, 0)


        If IsNumeric(GroupList.infoAboutGroup(35, 0)) Then
            newGroup.setProgKod(Convert.ToInt64(GroupList.infoAboutGroup(35, 0)))
        End If

        newGroup.setflagAllListProgs(False)

        newGroup.Модуль1.Text = GroupList.infoAboutGroup(11, 0)
        GroupList.gruppaData.modul1 = GroupList.infoAboutGroup(11, 0)
        newGroup.Модуль2.Text = GroupList.infoAboutGroup(12, 0)
        GroupList.gruppaData.modul2 = GroupList.infoAboutGroup(12, 0)
        newGroup.Модуль3.Text = GroupList.infoAboutGroup(13, 0)
        GroupList.gruppaData.modul3 = GroupList.infoAboutGroup(13, 0)
        newGroup.Модуль4.Text = GroupList.infoAboutGroup(14, 0)
        GroupList.gruppaData.modul4 = GroupList.infoAboutGroup(14, 0)
        newGroup.Модуль5.Text = GroupList.infoAboutGroup(15, 0)
        GroupList.gruppaData.modul5 = GroupList.infoAboutGroup(15, 0)
        newGroup.Модуль6.Text = GroupList.infoAboutGroup(16, 0)
        GroupList.gruppaData.modul6 = GroupList.infoAboutGroup(16, 0)
        newGroup.Модуль7.Text = GroupList.infoAboutGroup(17, 0)
        GroupList.gruppaData.modul7 = GroupList.infoAboutGroup(17, 0)
        newGroup.Модуль8.Text = GroupList.infoAboutGroup(18, 0)
        GroupList.gruppaData.modul8 = GroupList.infoAboutGroup(18, 0)
        newGroup.Модуль9.Text = GroupList.infoAboutGroup(19, 0)
        GroupList.gruppaData.modul9 = GroupList.infoAboutGroup(19, 0)
        newGroup.Модуль10.Text = GroupList.infoAboutGroup(20, 0)
        GroupList.gruppaData.modul10 = GroupList.infoAboutGroup(20, 0)
        newGroup.НоваяГруппаФинансирование.Text = GroupList.infoAboutGroup(22, 0)

        newGroup.Квалификация.Text = GroupList.infoAboutGroup(33, 0)
        GroupList.gruppaData.qualification = GroupList.infoAboutGroup(33, 0)
        GroupList.gruppaData.mainDocument = GroupList.infoAboutGroup(34, 0)

    End Sub

End Module
