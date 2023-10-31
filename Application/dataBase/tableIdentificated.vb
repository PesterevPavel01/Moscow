Module tableIdentificated
    Function nameTable(text As String) As String

        If text = "Квалификация" Then

            nameTable = "qualification"

        End If

        If text = "СтранаДОО" Then

            nameTable = "doo_country"

        End If

        If text = "НоваяГруппаФормаОбучения" Then

            nameTable = "form_education"

        End If

        If text = "ПОЗачисленииНомерГруппы" Or text = "Группа" Or text = "НомерГруппы" Or text = "Grades" Or text = "ГруппаОценкиИА" Then

            nameTable = "`group`"

        End If

        If text = "НоваяГруппаПрограмма" Then

            nameTable = "programa"

        End If

        If text = "НоваяГруппаСпециальность" Or text = "СпециальностьСлушателя" Then

            nameTable = "speciality"

        End If

        If text = "НоваяГруппаКоличествоЧасов" Then

            nameTable = "number_hours"

        End If

        If text = "НоваяГруппаОтветственныйКуратор" Then

            nameTable = "worker ORDER BY name"

        End If

        If text = "НоваягруппаОтветственныйЗаПрактику" Then

            nameTable = "worker ORDER BY name"

        End If

        If Left(text, 6) = "Модуль" Then

            nameTable = "worker ORDER BY name"

        End If

        If text = "Пол" Then

            nameTable = "gender"

        End If

        If text = "УровеньОбразования" Then

            nameTable = "education_level"

        End If

        If text = "ДУЛ" Then

            nameTable = "doc_ul"

        End If

        If text = "ИсточникФин" Then

            nameTable = "fin_source"

        End If
        If text = "Гражданство" Then

            nameTable = "nationality"

        End If

        If text = "НаправившаяОрг" Then

            nameTable = "napr_organization"

        End If

        If text = "НоваяГруппаУровеньКвалификации" Then

            nameTable = "skill_level"

        End If
        If text = "Ответственный" And BuildOrder.Label4.Text = "Слушатель(ФИО)" Then

            nameTable = "group_list"

        End If

        If text = "Ответственный" And BuildOrder.Label4.Text <> "Слушатель(ФИО)" Then

            nameTable = "worker ORDER BY name"

        End If

        If text = "НоваяГруппаФинансирование" Then

            nameTable = "financing"

        End If

        If text = "directorName" Or text = "СекретарьКомиссии" Or text = "ЗамПредседателя" Or text = "Комиссия3" Or text = "Комиссия2" Or text = "Утверждает" Or text = "РуководительСтажировки" Or text = "ПроектВносит" Or text = "Исполнитель" Or text = "Согласовано1" Or text = "Согласовано2" Or text = "Согласовано1ПУ" Or text = "Согласовано2ПУ" Then

            nameTable = "worker ORDER BY name"

        End If

        If text = "directorPosition" Or text = "СекретарьКомиссииДолжность" Or text = "ЗамПредседателяДолжность" Or text = "Комиссия3Должность" Or text = "Комиссия2Должность" Or text = "ОтветственныйДолжность" Or text = "ДолжностьРуководительСтажировки" Or text = "ПроектВноситДолжность" Or text = "ИсполнительДолжность" Or text = "Согласовано1Должность" Or text = "Согласовано1ДолжностьПУ" Or text = "Согласовано2Должность" Or text = "Согласовано2ДолжностьПУ" Or text = "УтверждаетДолжность" Then

            nameTable = "position"

        End If


    End Function



End Module
