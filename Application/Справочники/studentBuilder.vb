Module studentBuilder

    Sub build()

        Dim array
        array = StudentsList.studentsInfo
        Try
            newStudent.snils.Text = addMask.addMask(array(1, 0)).ToString
        Catch ex As Exception
            Warning.content.Text = "Ошибка. Некорректный СНИЛС в базе. Необходима ручная проверка базы!"
            Exit Sub
            newStudent.Close()
            openForm(Warning)
        End Try

        newStudent.secondName.Text = array(2, 0).ToString
        newStudent.Имя.Text = array(3, 0).ToString
        newStudent.Отчество.Text = array(4, 0).ToString
        Try
            newStudent.birthDate.Value = array(5, 0)
        Catch ex As Exception

        End Try
        newStudent.Пол.Text = array(6, 0).ToString
        newStudent.УровеньОбразования.Text = array(7, 0).ToString
        newStudent.Образование.Text = array(8, 0).ToString
        newStudent.СерияДокументаООбразовании.Text = array(9, 0).ToString
        newStudent.НомерДокументаООбразовании.Text = array(10, 0).ToString
        newStudent.ФамилияВДокОбОбразовании.Text = array(11, 0).ToString
        newStudent.АдресРегистрации.Text = array(12, 0).ToString
        Try
            newStudent.Телефон.Text = array(13, 0).ToString
        Catch ex As Exception

        End Try
        newStudent.Гражданство.Text = array(14, 0).ToString
        newStudent.ДУЛ.Text = array(15, 0).ToString
        newStudent.СерияДУЛ.Text = array(16, 0).ToString
        newStudent.НомерДУЛ.Text = array(17, 0).ToString
        newStudent.Email.Text = array(19, 0).ToString
        Try
            newStudent.dateDUL.Value = array(22, 0).ToString
        Catch ex As Exception

        End Try

        newStudent.КемВыданДУЛ.Text = array(21, 0).ToString
        newStudent.doo_vid_dok.Text = array(23, 0).ToString

    End Sub

End Module
