Module ЗаполнитьРедакторСлушателя

    Sub ЗаполнитьРедакторСлушателя()
        Dim array
        array = studentsList.studentsInfo
        Try
            РедакторСлушателя.Снилс.Text = addMask.ДобавитьРубашку(array(1, 0)).ToString
        Catch ex As Exception
            Warning.content.Text = "Ошибка. Некорректный СНИЛС в базе. Необходима ручная проверка базы!"
            Exit Sub
            РедакторСлушателя.Close()
            openForm(Warning)
        End Try

        РедакторСлушателя.Фамилия.Text = array(2, 0).ToString
        РедакторСлушателя.Имя.Text = array(3, 0).ToString
        РедакторСлушателя.Отчество.Text = array(4, 0).ToString
        Try
            РедакторСлушателя.ДатаРождения.Value = array(5, 0)
        Catch ex As Exception

        End Try
        РедакторСлушателя.Пол.Text = array(6, 0).ToString
        РедакторСлушателя.УровеньОбразования.Text = array(7, 0).ToString
        РедакторСлушателя.Образование.Text = array(8, 0).ToString
        РедакторСлушателя.СерияДокументаООбразовании.Text = array(9, 0).ToString
        РедакторСлушателя.НомерДокументаООбразовании.Text = array(10, 0).ToString
        РедакторСлушателя.ФамилияВДокОбОбразовании.Text = array(11, 0).ToString
        РедакторСлушателя.АдресРегистрации.Text = array(12, 0).ToString
        Try
            РедакторСлушателя.Телефон.Text = array(13, 0).ToString
        Catch ex As Exception

        End Try
        РедакторСлушателя.Гражданство.Text = array(14, 0).ToString
        РедакторСлушателя.ДУЛ.Text = array(15, 0).ToString
        РедакторСлушателя.СерияДУЛ.Text = array(16, 0).ToString
        РедакторСлушателя.НомерДУЛ.Text = array(17, 0).ToString
        РедакторСлушателя.ИсточникФин.Text = array(18, 0).ToString
        РедакторСлушателя.НаправившаяОрг.Text = array(19, 0).ToString
        Try
            РедакторСлушателя.ДатаНаправленияРосздравнвдзора.Value = array(21, 0).ToString
        Catch ex As Exception

        End Try

        РедакторСлушателя.НомерНаправленияРосздравнадзора.Text = array(20, 0).ToString

        РедакторСлушателя.Email.Text = array(25, 0).ToString

        Try
            РедакторСлушателя.ДатаВыдачиДУЛ.Value = array(28, 0).ToString
        Catch ex As Exception

        End Try

        РедакторСлушателя.КемВыданДУЛ.Text = array(27, 0).ToString
        РедакторСлушателя.doo_vid_dok.Text = array(29, 0).ToString

    End Sub

End Module
