Imports System.Data.SqlTypes
Imports WindowsApp2.Slushatel

Module QueryString
    Dim sqlString As String

    Public Function SqlString__updateSlushInListSlGroupp(snils As String, prevSnils As String)

        sqlString = " UPDATE СоставГрупп SET Слушатель = " & Chr(39) & snils & Chr(39) & " WHERE Слушатель = " & Chr(39) & prevSnils & Chr(39)
        Return sqlString

    End Function

    Public Function SqlString__insertIntoListGroupp(snils As String, kodGroupp As String)

        sqlString = "INSERT INTO СоставГрупп (Слушатель, Kod) VALUES ( " & Chr(39) & snils & Chr(39) & " , " & kodGroupp & ")"
        Return sqlString

    End Function

    Public Function SqlString__insertSlush(structSlushatel As strSlushatel)

        Dim Часть1 As String, Часть2 As String, Часть3 As String, Часть4 As String

        Часть1 = "(Снилс, Фамилия, Имя, Отчество, ДатаРождения, Пол, УОбразования, doo_vid_dok, НаимДОО, СерияДОО, НомерДОО, ФамилияДОО, АРег, Телефон, Гражданство, ДУЛ, СерияДУЛ, НомерДУЛ, ИФин, НОрг, НомерНапрРосздрав, ДатаНапрРосздрав, Специальность, ДатаРегистрации, Почта, ДУЛКемВыдан,ДУЛДатаВыдачи ) "

        Часть2 = "(" & Chr(39) & structSlushatel.snils & Chr(39) & ",
                 " & Chr(39) & structSlushatel.фамилия & Chr(39) & ",
                 " & Chr(39) & structSlushatel.имя & Chr(39) & ",
                 " & Chr(39) & structSlushatel.отчество & Chr(39) & ",
                 " & Chr(39) & structSlushatel.датаР & Chr(39) & ",
                 " & Chr(39) & structSlushatel.пол & Chr(39) & ",
                 " & Chr(39) & structSlushatel.уровеньОбразования & Chr(39) & "
                 ,(SELECT kod FROM doo_vid_dok WHERE name=
                 " & Chr(39) & structSlushatel.doo_vid_dok & Chr(39) & "
                 LIMIT 1) ," & Chr(39) & structSlushatel.образование & Chr(39) & "
                 ," & Chr(39) & structSlushatel.серияДокументаООбразовании & Chr(39) & "
                 ," & Chr(39) & structSlushatel.номерДокументаООбразовании & Chr(39) & "
                 ," & Chr(39) & structSlushatel.фамилияВДокОбОбразовании & Chr(39) & "
                 ," & Chr(39) & structSlushatel.адресРегистрации & Chr(39) & "
                 ," & Chr(39) & structSlushatel.телефон & Chr(39) & "
                 ," & Chr(39) & structSlushatel.гражданство & Chr(39) & "
                 ," & Chr(39) & structSlushatel.ДУЛ & Chr(39) & "
                 ," & Chr(39) & structSlushatel.серияДУЛ & Chr(39) & "
                 ," & Chr(39) & structSlushatel.номерДУЛ & Chr(39)

        Часть3 = "," & Chr(39) & structSlushatel.источникФин & Chr(39) & "
                , (SELECT kod FROM napr_organization WHERE name=" & Chr(39) & structSlushatel.направившаяОрг & Chr(39) & "
                LIMIT 1) , " & Chr(39) & structSlushatel.номерНаправленияРосздравнадзора & Chr(39) & "
                , " & Chr(39) & structSlushatel.датаНаправленияРосздравнвдзора & Chr(39) & "
                , " & Chr(39) & structSlushatel.специальностьСлушателя & Chr(39) & "
                , " & Chr(39) & structSlushatel.датаРег & Chr(39) & "
                , " & Chr(39) & structSlushatel.Email & Chr(39) & "
                , " & Chr(39) & structSlushatel.кемВыданДУЛ & Chr(39) & ","

        If structSlushatel.датаВыдачиДУЛ = "null" Then
            Часть3 += "null)"
        Else Часть3 += Chr(39) & structSlushatel.датаВыдачиДУЛ & Chr(39) & " ) "
        End If

        sqlString = "INSERT INTO Слушатель " & Часть1 & "  VALUES " & Часть2 & Часть3

        Return sqlString

    End Function

    Public Function SqlString__updateSlush(structSlushatel As strSlushatel)

        Dim Часть1 As String, Часть2 As String, Часть3 As String, Часть4 As String

        Часть1 = "Снилс=" & Chr(39) & structSlushatel.snils & Chr(39) & ", Фамилия=" & Chr(39) & structSlushatel.фамилия & Chr(39) & ", Имя=" & Chr(39) & structSlushatel.имя & Chr(39) & ", Отчество=" & Chr(39) & structSlushatel.отчество & Chr(39) & ", ДатаРождения=" & Chr(39) & structSlushatel.датаР & Chr(39) & ", Пол=" & Chr(39) & structSlushatel.пол & Chr(39)

        Часть2 = ", УОбразования=" & Chr(39) & structSlushatel.уровеньОбразования & Chr(39) & ", doo_vid_dok= (SELECT kod FROM doo_vid_dok WHERE name=" & Chr(39) & structSlushatel.doo_vid_dok & Chr(39) & " LIMIT 1), НаимДОО=" & Chr(39) & structSlushatel.образование & Chr(39) & ", СерияДОО=" & Chr(39) & structSlushatel.серияДокументаООбразовании & Chr(39) & ", НомерДОО=" & Chr(39) & structSlushatel.номерДокументаООбразовании & Chr(39) & ", ФамилияДОО=" & Chr(39) & structSlushatel.фамилияВДокОбОбразовании & Chr(39)

        Часть3 = ",АРег=" & Chr(39) & structSlushatel.адресРегистрации & Chr(39) & ", Телефон=" & Chr(39) & structSlushatel.телефон & Chr(39) & ", Гражданство=" & Chr(39) & structSlushatel.гражданство & Chr(39) & ", ДУЛ=" & Chr(39) & structSlushatel.ДУЛ & Chr(39) & ", СерияДУЛ=" & Chr(39) & structSlushatel.серияДУЛ & Chr(39) & ", НомерДУЛ=" & Chr(39) & structSlushatel.номерДУЛ & Chr(39)

        Часть4 = ",ИФин=" & Chr(39) & structSlushatel.источникФин & Chr(39) & ", НОрг= (SELECT kod FROM napr_organization WHERE name=" & Chr(39) & structSlushatel.направившаяОрг & Chr(39) & " LIMIT 1), НомерНапрРосздрав=" & Chr(39) & structSlushatel.номерНаправленияРосздравнадзора & Chr(39) & ", ДатаНапрРосздрав=" & Chr(39) & structSlushatel.датаНаправленияРосздравнвдзора & Chr(39) & ", Специальность=" & Chr(39) & structSlushatel.специальностьСлушателя & Chr(39) & ", ДатаРегистрации=" & Chr(39) & structSlushatel.датаРег & Chr(39) & ", Почта=" & Chr(39) & structSlushatel.Email & Chr(39) & ", ДУЛКемВыдан=" & Chr(39) & structSlushatel.кемВыданДУЛ & Chr(39)

        If structSlushatel.датаВыдачиДУЛ = "null" Then
            Часть4 += ", ДУЛДатаВыдачи=null"
        Else
            Часть4 += ", ДУЛДатаВыдачи=" & Chr(39) & structSlushatel.датаВыдачиДУЛ & Chr(39)
        End If

        sqlString = "UPDATE Слушатель SET " & Часть1 & Часть2 & Часть3 & Часть4 & " WHERE Снилс =" & Chr(39) & structSlushatel.snils & Chr(39)

        Return sqlString

    End Function

    Public Function SqlString__loadSlushList(snils As String)

        sqlString = "SELECT * FROM " & "Слушатель" & " WHERE " & "Снилс" & " = " & Chr(39) & snils & Chr(39)
        Return sqlString

    End Function

    Public Function SqlString__deleteSlushFromGrouppList(snils As String)

        sqlString = "DELETE FROM СоставГрупп WHERE Слушатель= " & Chr(39) & snils & Chr(39)
        Return sqlString

    End Function

    Public Function SqlString__deleteSlush(snils As String)

        sqlString = "DELETE FROM Слушатель WHERE Снилс= " & Chr(39) & snils & Chr(39)
        Return sqlString

    End Function

    Public Function loadNOrganization()

        sqlString = "SELECT name FROM napr_organization ORDER BY kod"
        Return sqlString

    End Function

    Public Function loadIstFinans()

        sqlString = "SELECT name FROM ist_finans ORDER BY kod"
        Return sqlString

    End Function

    Public Function loadDokUL()

        sqlString = "SELECT name FROM dok_UL ORDER BY kod"
        Return sqlString

    End Function

    Public Function loadGrajdanstvo()

        sqlString = "SELECT name FROM grajdanstvo ORDER BY kod"
        Return sqlString

    End Function

    Public Function loadDooCountry()

        sqlString = "SELECT name FROM DOO_country ORDER BY kod"
        Return sqlString

    End Function

    Public Function loadDooVidDok()

        sqlString = "SELECT name FROM doo_vid_dok ORDER BY name"
        Return sqlString

    End Function
    Public Function loadUrovenObr()

        sqlString = "SELECT name FROM uroven_obr ORDER BY kod"
        Return sqlString

    End Function
    Public Function loadPol()

        sqlString = "SELECT pol FROM pol ORDER BY kod"
        Return sqlString

    End Function

    Public Function load_prepod() As String

        sqlString = "SELECT name FROM sotrudnik WHERE in_list=1"
        Return sqlString

    End Function

    Public Function load_slushatel_and_org(kodGroup As String) As String

        sqlString = "SELECT
                      result.slush,
                      name AS napr_org,
                      result.ИФин
                    FROM (SELECT
                        CONCAT(слушатель.Фамилия, ' ', слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' ')) AS slush,
                        слушатель.НОрг,
                        ИФин
                      FROM составгрупп
                        INNER JOIN слушатель
                          ON составгрупп.слушатель = слушатель.Снилс
                      WHERE составгрупп.kod = " & kodGroup & "
                      ORDER BY слушатель.Фамилия) AS result

                      LEFT JOIN napr_organization
                        ON result.НОрг = kod
                        ORDER BY  result.slush"
        Return sqlString

    End Function

    Public Function load_slushatel(snils As String) As String
        Dim SqlString As String

        SqlString = "SELECT
                      слушатель.Код,
                      слушатель.Снилс,
                      слушатель.Фамилия,
                      слушатель.Имя,
                      слушатель.Отчество,
                      слушатель.ДатаРождения,
                      слушатель.Пол,
                      слушатель.УОбразования,
                      слушатель.НаимДОО,
                      слушатель.СерияДОО,
                      слушатель.НомерДОО,
                      слушатель.ФамилияДОО,
                      слушатель.АРег,
                      слушатель.Телефон,
                      слушатель.Гражданство,
                      слушатель.ДУЛ,
                      слушатель.СерияДУЛ,
                      слушатель.НомерДУЛ,
                      слушатель.ИФин,
                      napr_organization.name,
                      слушатель.НомерНапрРосздрав,
                      слушатель.ДатаНапрРосздрав,
                      слушатель.Специальность,
                      слушатель.ДатаРегистрации,
                      слушатель.ДатаОкончанияОбразованияПоДОО,
                      слушатель.Почта,
                      слушатель.СтранаДОО,
                      слушатель.ДУЛКемВыдан,
                      слушатель.ДУЛДатаВыдачи,
                      doo_vid_dok.name AS vid_doo
                    FROM слушатель
                      LEFT JOIN doo_vid_dok
                        ON слушатель.doo_vid_dok=doo_vid_dok.kod
                      INNER JOIN napr_organization
                        ON слушатель.НОрг = napr_organization.kod
                        WHERE слушатель.Снилс='" + snils + "'"
        Return SqlString

    End Function

    Public Function load_ppOk_group(kod As String) As String

        Dim sqlString As String = "SELECT
                                  CONCAT(слушатель.Фамилия, ' ', слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' ')),
                                  слушатель.Фамилия,
                                  CONCAT(слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' ')),
                                  слушатель.Снилс,
                                  группа.НомерДиплома,
                                  группа.РегНомерДиплома,
                                  группа.ОсновнойДокумент,
                                  Программа,
                                  ДатаВыдачиДиплома,
                                  ДатаНЗ,
                                  ДатаКЗ,
                                  КолЧас,
                                  Квалификация,
                                  НомерПротоколаИА,
                                  sotrudnik.name AS Куратор
                                FROM (составгрупп
                                  INNER JOIN слушатель
                                    ON составгрупп.слушатель = слушатель.Снилс)
                                  INNER JOIN группа
                                    ON составгрупп.kod = группа.Код
                                      LEFT JOIN sotrudnik
                                    ON sotrudnik.kod = Куратор
                                WHERE группа.Код = " + kod + "
                                ORDER BY слушатель.Фамилия"
        Return sqlString

    End Function

    Public Function load_pkOk_group(kod As String) As String

        Dim sqlString As String = "SELECT
                                  CONCAT(слушатель.Фамилия, ' ', слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' ')),
                                  слушатель.Фамилия,
                                  CONCAT(слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' ')),
                                  слушатель.Снилс,
                                  группа.НомерУд,
                                  группа.РегНомерУд,
                                  группа.ОсновнойДокумент,
                                  Программа,
                                  ДатаВыдачиУд,
                                  ДатаНЗ,
                                  ДатаКЗ,
                                  КолЧас,
                                  Квалификация,
                                  НомерПротоколаИА,
                                  sotrudnik.name AS Куратор
                                FROM (составгрупп
                                  INNER JOIN слушатель
                                    ON составгрупп.слушатель = слушатель.Снилс)
                                  INNER JOIN группа
                                    ON составгрупп.kod = группа.Код
                                  LEFT JOIN sotrudnik
                                    ON sotrudnik.kod=Куратор
                                WHERE группа.Код = " + kod + "
                                ORDER BY слушатель.Фамилия"
        Return sqlString

    End Function

    Public Function load_poOk_group(kod As String) As String

        Dim sqlString As String = "SELECT
                                  CONCAT(слушатель.Фамилия, ' ', слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' ')),
                                  слушатель.Фамилия,
                                  CONCAT(слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' ')),
                                  слушатель.Снилс,
                                  группа.НомерСвид,
                                  группа.РегНомерСвид,
                                  группа.ОсновнойДокумент,
                                  Программа,
                                  ДатаВыдачиСвид,
                                  ДатаНЗ,
                                  ДатаКЗ,
                                  КолЧас,
                                  Квалификация,
                                  НомерПротоколаИА,
                                  sotrudnik.name AS Куратор
                                FROM (составгрупп
                                  INNER JOIN слушатель
                                    ON составгрупп.слушатель = слушатель.Снилс)
                                  INNER JOIN группа
                                    ON составгрупп.kod = группа.Код
                                      LEFT JOIN sotrudnik
                                    ON sotrudnik.kod = Куратор
                                WHERE группа.Код = " + kod + "
                                ORDER BY слушатель.Фамилия"
        Return sqlString

    End Function

    Public Function load_prog_kurator(kod As String) As String

        Dim sqlString As String = " SELECT
                                      Программа,
                                      sotrudnik.name
                                    FROM (SELECT
                                        Программа,
                                        Куратор
                                      FROM группа
                                      WHERE Код = " + kod + ") AS gr
                                    LEFT JOIN sotrudnik
                                    ON gr.Куратор=kod"
        Return sqlString

    End Function

    Public Function load_spr_group(ur_kval As String, sort As String, Optional year As String = "0") As String

        Dim sqlString As String = ""

        sqlString = "SELECT
                    tbl1.Код,
                    tbl1.Номер,
                    tbl1.Программа,
                    name,
                    tbl1.ДатаНЗ,
                    tbl1.ДатаКЗ
                    FROM
                    (SELECT
                      Код,
                      Номер,
                      Программа,
                      Куратор,
                      ДатаНЗ,
                      ДатаКЗ
                    FROM группа
                    WHERE УровеньКвалификации = '" + ur_kval + "'"

        If year <> "0" Then
            sqlString += " AND YEAR(группа.ДатаНЗ) = '" + year + "'"
        End If

        sqlString += ") AS tbl1
                    LEFT JOIN
                    sotrudnik
                    ON Куратор=kod
                    ORDER BY " + sort

        Return sqlString

    End Function

    Public Function load_spr_group_search(ur_kval As String, sort As String, col_search As String, text As String, Optional year As String = "0") As String

        Dim sqlString As String = ""

        sqlString = "SELECT
                    tbl1.Код,
                    tbl1.Номер,
                    tbl1.Программа,
                    name,
                    tbl1.ДатаНЗ,
                    tbl1.ДатаКЗ
                    FROM
                    (SELECT
                      Код,
                      Номер,
                      Программа,
                      Куратор,
                      ДатаНЗ,
                      ДатаКЗ
                    FROM группа
                    WHERE УровеньКвалификации = '" + ur_kval + "'"

        If year <> "0" Then
            sqlString += " AND YEAR(группа.ДатаНЗ) = '" + year + "'"
        End If

        sqlString += "AND " & col_search & " LIKE " & Chr(39) & text & "%" & Chr(39)
        sqlString += ") AS tbl1
                    LEFT JOIN
                    sotrudnik
                    ON Куратор=kod
                    ORDER BY " + sort

        Return sqlString

    End Function


    Public Function select_moduls_ocenka(kod_group As String, modul_name As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT 
                      ocenka.Слушатель,
                      ocenka.mod1
                    FROM
                    (SELECT
                      " + Chr(64) + "I := " + Chr(64) + "I + 1 AS number,
                      tbl_mod.name
                    FROM (SELECT
                             moduls.name,
                             progs_mods_hours.modul_number
                           FROM progs_mods_hours
                             INNER JOIN moduls
                               ON progs_mods_hours.kod_modul = moduls.kod
                             INNER JOIN группа
                               ON progs_mods_hours.kod_prog = группа.kod_programm
                           WHERE группа.Код = " + kod_group + "
                           ORDER BY modul_number) AS tbl_mod,
                         (SELECT
                             " + Chr(64) + "I := 0) I) AS moduls
                    LEFT JOIN
                      (SELECT
                    1 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль1 AS mod1
                    FROM составгрупп WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    2 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль2 AS mod2
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    3 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль3 AS mod3
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    4 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль4 AS mod4
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    5 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль5 AS mod5
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    6 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль6 AS mod6
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    7 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль7 AS mod7
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    8 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль8 AS mod8
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    9 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль9 AS mod9
                    FROM составгрупп
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    10 AS number,
                    Слушатель,
                      составгрупп.ОценкаМодуль10 AS mod10
                    FROM составгрупп
                    WHERE Kod=" + kod_group + ") AS ocenka
                    ON moduls.number=ocenka.number
                    WHERE moduls.name='" + modul_name + "'
                    ORDER BY moduls.number"
        Return sqlString

    End Function

    Public Function select_moduls_count(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      COUNT(progs_mods_hours.kod_modul) AS expr1
                    FROM progs_mods_hours
                      INNER JOIN programma
                        ON progs_mods_hours.kod_prog = programma.kod
                      INNER JOIN группа
                        ON группа.kod_programm = programma.kod
                    WHERE группа.Код = " + kod_group
        Return sqlString

    End Function

    Public Function selectSpravka_moduls_hours(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      moduls.name,
                      progs_mods_hours.hours
                    FROM группа
                      INNER JOIN programma
                        ON группа.kod_programm = programma.kod
                      INNER JOIN progs_mods_hours
                        ON progs_mods_hours.kod_prog = programma.kod
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE группа.Код =" + kod_group + " AND moduls.name <> 'Итоговая аттестация'
                    ORDER BY modul_number"
        Return sqlString

    End Function

    Public Function selectSpravkaIA_group(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      Программа,
                      uroven_kvalifik.name_padej,
                      Финансирование,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас
                    FROM группа
                      INNER JOIN uroven_kvalifik
                        ON группа.УровеньКвалификации = uroven_kvalifik.name
                    WHERE группа.Код =" + kod_group
        Return sqlString

    End Function
    Public Function selectSpravka_group(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      Программа,
                      uroven_kvalifik.name_padej,
                      Финансирование,
                      ДатаНЗ,
                      ДатаКЗ
                    FROM группа
                      INNER JOIN uroven_kvalifik
                        ON группа.УровеньКвалификации = uroven_kvalifik.name
                    WHERE группа.Код =" + kod_group
        Return sqlString

    End Function
    Public Function selectDover_slush(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      CONCAT(слушатель.Фамилия, ' ', слушатель.Имя, ' ', IFNULL(слушатель.Отчество, ' '))
                    FROM составгрупп
                      INNER JOIN слушатель
                        ON составгрупп.слушатель = слушатель.Снилс
                    WHERE составгрупп.kod =" + kod_group + "
                    ORDER BY слушатель.Фамилия"
        Return sqlString

    End Function

    Public Function selectDover_kval(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      Программа,
                      uroven_kvalifik.name_padej,
                      Финансирование,
                      ДатаКЗ
                    FROM группа
                      INNER JOIN uroven_kvalifik
                        ON группа.УровеньКвалификации = uroven_kvalifik.name
                    WHERE группа.Код = " + kod_group
        Return sqlString

    End Function

    Public Function selectCol_otche_info(ДатаНачалаОтчета, ДатаКонцаОтчета) As String

        Dim sqlString As String = ""
        sqlString = "
                    SELECT
                      Код,
                      Номер,
                      ФормаО,
                      ДатаНЗ,
                      ДатаКЗ,
                      Спец,
                      Программа,
                      КолЧас,
                      s0.name AS Куратор,
                      s00.name AS ОтвЗаПракт,
                      ДатаСоздания,
                      s1.name,
                      s2.name,
                      s3.name,
                      s4.name,
                      s5.name,
                      s6.name,
                      s7.name,
                      s8.name,
                      s9.name,
                      s10.name,
                      УровеньКвалификации,
                      Финансирование
                    FROM (SELECT * FROM группа WHERE ДатаНЗ BETWEEN '" & ДатаНачалаОтчета & "' and '" & ДатаКонцаОтчета & " ') AS gr
                    LEFT JOIN
                    sotrudnik AS s0
                        ON s0.kod=Куратор
                    LEFT JOIN
                    sotrudnik AS s00
                        ON s00.kod=ОтвЗаПракт
                    LEFT JOIN sotrudnik AS s1
                        ON gr.modul1 = s1.kod
                    LEFT JOIN sotrudnik AS s2
                        ON gr.modul2 = s2.kod
                    LEFT JOIN sotrudnik AS s3
                        ON gr.modul3 = s3.kod
                    LEFT JOIN sotrudnik AS s4
                        ON gr.modul4 = s4.kod
                    LEFT JOIN sotrudnik AS s5
                        ON gr.modul5 = s5.kod
                    LEFT JOIN sotrudnik AS s6
                        ON gr.modul6 = s6.kod
                    LEFT JOIN sotrudnik AS s7
                        ON gr.modul7 = s7.kod
                    LEFT JOIN sotrudnik AS s8
                        ON gr.modul8 = s8.kod
                    LEFT JOIN sotrudnik AS s9
                        ON gr.modul9 = s9.kod
                    LEFT JOIN sotrudnik AS s10
                        ON gr.modul10 = s10.kod"
        Return sqlString

    End Function

    Public Function selectCol_chas() As String

        Dim sqlString As String = ""
        sqlString = "Select * FROM kol_chas "
        Return sqlString

    End Function

    Public Function updateSettings(name As String, value As String) As String

        Dim sqlString As String = ""
        sqlString = "UPDATE Settings Set value='" + value + "' WHERE name='" + name + "'"
        Return sqlString

    End Function

    Public Function loadSettings() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name,value FROM Settings
                    UNION ALL
                    SELECT kod,passwrd FROM passwords"
        Return sqlString

    End Function

    Public Function loadIA(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT  CONCAT(слушатель.Фамилия,' ',слушатель.Имя,' ',IFNULL(слушатель.Отчество,' ')) as 'ФИО', СоставГрупп.ИАТестирование as ИАТестирование, ИАПрактическиеНавыки as ИАПрактическиеНавыки, ИАИтог, Слушатель.Снилс FROM СоставГрупп INNER JOIN Слушатель ON СоставГрупп.Слушатель = Слушатель.Снилс WHERE СоставГрупп.Kod = " & kod_group & " ORDER BY Фамилия"
        Return sqlString

    End Function
    Public Function loadVedomost(kod_group As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT CONCAT(слушатель.Фамилия,' ',слушатель.Имя,' ',слушатель.Отчество), СоставГрупп.ОценкаМодуль1, ОценкаМодуль2, ОценкаМодуль3, ОценкаМодуль4, ОценкаМодуль5, ОценкаМодуль6, ОценкаМодуль7, ОценкаМодуль8, ОценкаМодуль9, ОценкаМодуль10, Слушатель.СНИЛС FROM СоставГрупп INNER JOIN Слушатель ON СоставГрупп.Слушатель = Слушатель.Снилс WHERE СоставГрупп.Kod = " & kod_group & " ORDER BY Фамилия"
        Return sqlString

    End Function
    Public Function selectMassForPrilDiplom(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      moduls.name,
                      progs_mods_hours.hours,
                      группа.ДатаНЗ,
                      группа.ДатаКЗ,
                      programma.name,
                      группа.КолЧас,
                      группа.НомерДиплома,
                      группа.РегНомерДиплома,
                      группа.ДатаВыдачиДиплома,
                      группа.УровеньКвалификации
                    FROM progs_mods_hours
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                      CROSS JOIN группа
                      INNER JOIN programma
                        ON группа.kod_programm = programma.kod
                        AND progs_mods_hours.kod_prog = programma.kod
                    WHERE группа.Код = " + kod + "
                    ORDER BY modul_number"
        Return sqlString

    End Function

    Public Function selectMassForPrilSvidetelstvo(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      moduls.name,
                      progs_mods_hours.hours,
                      группа.ДатаНЗ,
                      группа.ДатаКЗ,
                      programma.name,
                      группа.КолЧас,
                      группа.НомерСвид,
                      группа.РегНомерСвид,
                      группа.ДатаВыдачиСвид,
                      группа.НомерПротоколаИА,
                      группа.УровеньКвалификации
                    FROM progs_mods_hours
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                      CROSS JOIN группа
                      INNER JOIN programma
                        ON группа.kod_programm = programma.kod
                        AND progs_mods_hours.kod_prog = programma.kod
                    WHERE группа.Код = " + kod + "
                    ORDER BY modul_number"
        Return sqlString

    End Function
    Public Function loadgroupp(kod_gr As String)
        Dim sqlString As String = "SELECT
                                  gr.Код,
                                  gr.Номер,
                                  gr.ФормаО,
                                  gr.ДатаНЗ,
                                  gr.ДатаКЗ,
                                  gr.Спец,
                                  gr.Программа,
                                  gr.КолЧас,
                                  s0.name AS Куратор,
                                  s00.name AS ОтвЗаПракт,
                                  gr.ДатаСоздания,
                                  s1.name,
                                  s2.name,
                                  s3.name,
                                  s4.name,
                                  s5.name,
                                  s6.name,
                                  s7.name,
                                  s8.name,
                                  s9.name,
                                  s10.name,
                                  gr.УровеньКвалификации,
                                  gr.Финансирование,
                                  gr.НомерПротоколаИА,
                                  gr.НомерУд,
                                  gr.РегНомерУд,
                                  gr.ДатаВыдачиУд,
                                  gr.НомерДиплома,
                                  gr.РегНомерДиплома,
                                  gr.ДатаВыдачиДиплома,
                                  gr.НомерСвид,
                                  gr.РегНомерСвид,
                                  gr.ДатаВыдачиСвид,
                                  gr.Квалификация,
                                  gr.ОсновнойДокумент,
                                  gr.ДатаСпецЭкзамен,
                                  gr.НомерПротоколаСпецэкзамен,
                                  gr.kod_programm
                                FROM (SELECT
                                    *
                                  FROM группа
                                  WHERE Код = " + kod_gr + ") AS gr
                                  LEFT JOIN sotrudnik AS s0
                                    ON gr.Куратор = s0.kod
                                  LEFT JOIN sotrudnik AS s00
                                    ON gr.ОтвЗаПракт = s00.kod
                                  LEFT JOIN sotrudnik AS s1
                                    ON gr.modul1 = s1.kod
                                  LEFT JOIN sotrudnik AS s2
                                    ON gr.modul2 = s2.kod
                                  LEFT JOIN sotrudnik AS s3
                                    ON gr.modul3 = s3.kod
                                  LEFT JOIN sotrudnik AS s4
                                    ON gr.modul4 = s4.kod
                                  LEFT JOIN sotrudnik AS s5
                                    ON gr.modul5 = s5.kod
                                  LEFT JOIN sotrudnik AS s6
                                    ON gr.modul6 = s6.kod
                                  LEFT JOIN sotrudnik AS s7
                                    ON gr.modul7 = s7.kod
                                  LEFT JOIN sotrudnik AS s8
                                    ON gr.modul8 = s8.kod
                                  LEFT JOIN sotrudnik AS s9
                                    ON gr.modul9 = s9.kod
                                  LEFT JOIN sotrudnik AS s10
                                    ON gr.modul10 = s10.kod"
        Return sqlString
    End Function
    Public Function loadListModul(kod_gr As String)
        Dim sqlString As String = "SELECT
                                      moduls.name
                                    FROM (SELECT
                                        *
                                      FROM группа
                                      WHERE Код = " + kod_gr + ") AS gr
                                      INNER JOIN progs_mods_hours
                                        ON gr.kod_programm = progs_mods_hours.kod_prog
                                      INNER JOIN moduls
                                        ON progs_mods_hours.kod_modul = moduls.kod
                                    ORDER BY progs_mods_hours.modul_number"
        Return sqlString
    End Function

    Public Function loadListSotrudnicModul(kod_gr As String)
        Dim sqlString As String = "SELECT
                                      s1.name,
                                      s2.name,
                                      s3.name,
                                      s4.name,
                                      s5.name,
                                      s6.name,
                                      s7.name,
                                      s8.name,
                                      s9.name,
                                      s10.name
                                    FROM группа
                                      INNER JOIN sotrudnik AS s1
                                        ON группа.modul1 = s1.kod
                                      LEFT JOIN sotrudnik AS s2
                                        ON группа.modul2 = s2.kod
                                      LEFT JOIN sotrudnik AS s3
                                        ON группа.modul3 = s3.kod
                                      LEFT JOIN sotrudnik AS s4
                                        ON группа.modul4 = s4.kod
                                      LEFT JOIN sotrudnik AS s5
                                        ON группа.modul5 = s5.kod
                                      LEFT JOIN sotrudnik AS s6
                                        ON группа.modul6 = s6.kod
                                      LEFT JOIN sotrudnik AS s7
                                        ON группа.modul7 = s7.kod
                                      LEFT JOIN sotrudnik AS s8
                                        ON группа.modul8 = s8.kod
                                      LEFT JOIN sotrudnik AS s9
                                        ON группа.modul9 = s9.kod
                                      LEFT JOIN sotrudnik AS s10
                                        ON группа.modul10 = s10.kod
                                        WHERE группа.Код=" + kod_gr
        Return sqlString
    End Function

    Public Function SQLString_OtchetRuk(DateNach As String, DateKon As String)

        Dim sqlString As String = ""

        sqlString = "SELECT" +
                     "  Tbl_spec.Спец," +
                     "  Tbl_spec.Номер," +
                     "  Tbl_spec.Программа," +
                     "  Tbl_spec.КолЧас," +
                     "  Tbl_spec.period," +
                     "  Tbl_data_1.чел," +
                     "  IFNULL(Tbl_data_2.bud,0) AS Бюджет," +
                     "  Tbl_data_1.чел-IFNULL(Tbl_data_2.bud,0) AS Внебюджет," +
                     "  IF(Tbl_spec.Финансирование='бюджет',1,0) AS бюджет," +
                     "  IF(Tbl_spec.Финансирование='внебюджет',1,0) AS внебюджет," +
                     "  IFNULL(Tbl_data_2.bud,0)*Tbl_spec.КолЧас AS бюджет," +
                     "  (Tbl_data_1.чел - IFNULL(Tbl_data_2.bud,0))*Tbl_spec.КолЧас AS Внебюджет" +
                     " FROM (SELECT" +
                     "    Номер," +
                     "    Программа," +
                     "    Спец," +
                     "    КолЧас," +
                     "    Код," +
                     "    Финансирование," +
                     "    CONCAT(DAY(ДатаНЗ), '.', IF(MONTH(ДатаНЗ) < 10, CONCAT('0', MONTH(ДатаНЗ)), MONTH(ДатаНЗ)), '.', YEAR(ДатаНЗ), '-', DAY(ДатаКЗ), '.', IF(MONTH(ДатаКЗ) < 10, CONCAT('0', MONTH(ДатаКЗ)), MONTH(ДатаКЗ)), '.', YEAR(ДатаКЗ)) AS period" +
                     "  FROM группа" +
                     "  WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS Tbl_spec" +
                     "  INNER JOIN (SELECT" +
                     "      spec.Код," +
                     "      COUNT(слушатель) AS чел" +
                     "    FROM (SELECT" +
                     "        Код" +
                     "      FROM группа" +
                     "      WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                     "      INNER JOIN составгрупп" +
                     "        ON spec.Код = kod" +
                     "    GROUP BY spec.Код) AS Tbl_data_1" +
                     "    ON Tbl_data_1.Код = Tbl_spec.Код" +
                     "  LEFT JOIN  " +
                     "  (SELECT" +
                     "      sostav.Код," +
                     "      IFNULL(COUNT(slush.ИФин),0) AS bud" +
                     "    FROM (SELECT" +
                     "        spec.Код," +
                     "        слушатель" +
                     "      FROM (SELECT" +
                     "          Код" +
                     "        FROM группа" +
                     "        WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                     "        INNER JOIN составгрупп" +
                     "          ON spec.Код = kod) AS sostav" +
                     "      INNER JOIN (SELECT" +
                     "          Снилс," +
                     "          ИФин" +
                     "        FROM слушатель" +
                     "        WHERE ИФин = 'Федеральный бюджет') AS slush" +
                     "        ON slush.Снилс = sostav.слушатель" +
                     "        GROUP BY sostav.Код" +
                     "        ) AS Tbl_data_2" +
                     "    ON Tbl_data_2.Код = Tbl_spec.Код" +
                     " ORDER BY Tbl_spec.Спец,Tbl_spec.Программа DESC"

        Return sqlString
    End Function

    Public Function SQLString_OtchetRMANPO(DateNach As String, DateKon As String)

        Dim sqlString As String = ""

        sqlString = "SELECT
                    Tbl_spec.Спец,
                    Tbl_spec.Номер,
                    Tbl_spec.period,
                    Tbl_spec.Программа,
                    Tbl_data_1.чел,
                    Tbl_data_2.bud AS Бюджет,
                    Tbl_data_1.чел - Tbl_data_2.bud AS Внебюджет,
                    Tbl_org.НОрг,
                    Tbl_org.bud
                  FROM (SELECT
                      Номер,
                      Программа,
                      Спец,
                      КолЧас,
                      Код,
                      Финансирование,
                      CONCAT(IF(DAY(ДатаНЗ) < 10, CONCAT('0',DAY(ДатаНЗ)), DAY(ДатаНЗ)), '.', IF(MONTH(ДатаНЗ) < 10, CONCAT('0', MONTH(ДатаНЗ)), MONTH(ДатаНЗ)), '.', YEAR(ДатаНЗ), '-',IF(DAY(ДатаКЗ) < 10, CONCAT('0',DAY(ДатаКЗ)), DAY(ДатаКЗ)) , '.', IF(MONTH(ДатаКЗ) < 10, CONCAT('0', MONTH(ДатаКЗ)), MONTH(ДатаКЗ)), '.', YEAR(ДатаКЗ)) AS period
                    FROM группа" +
                          "  WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS Tbl_spec
                    INNER JOIN (SELECT
                        spec.Код,
                        COUNT(слушатель) AS чел
                      FROM (SELECT
                          Код
                        FROM группа" +
                          "  WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS spec
                        INNER JOIN составгрупп
                          ON spec.Код = kod
                      GROUP BY spec.Код) AS Tbl_data_1
                      ON Tbl_data_1.Код = Tbl_spec.Код
                    INNER JOIN (SELECT
                        sostav.Код,
                        COUNT(slush.ИФин) AS bud
                      FROM (SELECT
                          spec.Код,
                          слушатель
                        FROM (SELECT
                            Код
                          FROM группа" +
                          "  WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS spec
                          INNER JOIN составгрупп
                            ON spec.Код = kod) AS sostav
                        INNER JOIN (SELECT
                            Снилс,
                            ИФин
                          FROM слушатель
                          WHERE ИФин = 'Федеральный бюджет') AS slush
                          ON slush.Снилс = sostav.слушатель
                      GROUP BY sostav.Код) AS Tbl_data_2
                      ON Tbl_data_2.Код = Tbl_spec.Код
                    INNER JOIN (SELECT
                        sostav.Код,
                        full_name AS НОрг,
                        COUNT(slush.ИФин) AS bud
                      FROM (SELECT
                          spec.Код,
                          слушатель
                        FROM (SELECT
                            Код
                          FROM группа" +
                          "  WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS spec
                          INNER JOIN составгрупп
                            ON spec.Код = kod) AS sostav
                        INNER JOIN (SELECT
                            Снилс,
                            ИФин,
                            НОрг
                          FROM слушатель) AS slush
                          ON slush.Снилс = sostav.слушатель
                        LEFT JOIN napr_organization
                                ON slush.НОрг=kod
                      GROUP BY sostav.Код,
                               slush.НОрг) AS Tbl_org
                      ON Tbl_spec.Код = Tbl_org.Код
                ORDER BY Tbl_spec.Спец,Tbl_spec.Номер, Tbl_org.НОрг "

        Return sqlString
    End Function

    Public Function SQLString_OtchetKurs(DateNach As String, DateKon As String, Argument As String)

        Dim sqlString As String = ""

        sqlString = "SELECT"

        If Argument = "курс" Then
            sqlString += "  Tbl_spec.Программа As Курс,"
        Else
            sqlString += "  Tbl_spec.Спец As Специальность,"
        End If

        sqlString += "  SUM(Tbl_data_1.чел) As человек," +
                    "  MAX(Tbl_spec.КолЧас)," +
                    "  SUM(Tbl_spec.КолЧас * Tbl_data_1.чел) AS итого" +
                    " FROM(SELECT" +
                    "    Номер," +
                    "        IFNULL(Программа,'') AS Программа,
                             IFNULL(Спец,'') AS Спец,
                             КолЧас,
                             Код,
                             IFNULL(Финансирование,'')," +
                    "    CONCAT(Day(ДатаНЗ), '.', If(month(ДатаНЗ) < 10, CONCAT('0', month(ДатаНЗ)), month(ДатаНЗ)), '.', Year(ДатаНЗ), '-', Day(ДатаКЗ), '.', If(month(ДатаКЗ) < 10, CONCAT('0', month(ДатаКЗ)), month(ДатаКЗ)), '.', Year(ДатаКЗ)) AS period" +
                    "  From группа" +
                    " WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS Tbl_spec" +
                    "  INNER Join(SELECT" +
                    "      spec.Код," +
                    "      COUNT(слушатель) AS чел" +
                    "    FROM(SELECT" +
                    "        Код" +
                    "        From группа" +
                    " WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                    "      INNER Join составгрупп" +
                    "        On spec.Код = kod" +
                    "    GROUP BY spec.Код) AS Tbl_data_1" +
                    "    On Tbl_data_1.Код = Tbl_spec.Код"

        If Argument = "курс" Then
            sqlString += "   GROUP BY Курс " +
                    " ORDER BY Tbl_spec.Программа DESC"
        Else
            sqlString += " GROUP BY Специальность" +
                    " ORDER BY Tbl_spec.Спец DESC"
        End If

        Return sqlString
    End Function


    Public Function SQLString_OtchetOrg(DateNach As String, DateKon As String)

        Dim sqlString As String = ""

        sqlString = "SELECT 
                        name AS Организация,
                        result.Человек
                         FROM
                        ( SELECT" +
                    "       slush.НОрг," +
                    "       COUNT(slush.Снилс) AS Человек" +
                    "     FROM(SELECT" +
                    "         spec.Код," +
                    "         слушатель" +
                    "       FROM(SELECT" +
                    "           Код" +
                    "         From группа" +
                    "         WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                    "         INNER Join составгрупп" +
                    "           On spec.Код = kod) AS sostav" +
                    "       INNER Join (SELECT" +
                    "           Снилс," +
                    "           IFNULL(НОрг,'') AS НОрг" +
                    "         From слушатель" +
                    "         ) AS slush" +
                    "         ON slush.Снилс = sostav.слушатель" +
                    "     GROUP By slush.НОрг" +
                    " ORDER BY slush.НОрг) AS result

                    LEFT JOIN 

                    napr_organization
                    ON result.НОрг=kod"


        Return sqlString
    End Function

    Public Function SQLString_OtchetBud_Vbud(DateNach As String, DateKon As String, argument As String)

        Dim sqlString As String = ""

        sqlString = " SELECT 
                      gr.КолЧас часов,
                      sostav_chel.number_slush As слушателей,
                      tbl_slush.мужиков AS мужчин,
                      tbl_slush.старше_60 As старше_60,
                      gr.КолЧас * sostav_chel.number_slush As выполнено_часов,
                      gr.number_gr AS групп
                    FROM(SELECT
                        SUM(slush.пол) As мужиков,
                        SUM(slush.v_60) As старше_60,
                        sostav.КолЧас
                            FROM(SELECT
                          spec.Код,
                          spec.КолЧас,
                          слушатель
                        FROM(SELECT
                            Код,
                            КолЧас
                          From группа" +
                    "         WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'"
        sqlString += ") AS spec" +
                    "      INNER Join составгрупп
                            On spec.Код = kod) AS sostav
                        INNER Join(SELECT
                            Снилс,
                            If(Пол = 'женский', 0, 1) AS Пол,
                            If(If(month(Now()) >= month(ДатаРождения) And Day(Now()) >= Day(ДатаРождения), Year(Now()) >= Year(ДатаРождения), Year(Now()) >= Year(ДатаРождения) - 1) >= 60 And Пол = 'мужской', 1, 0) AS v_60
                          From слушатель"

        If argument = "бюджет" Then
            sqlString += "  WHERE ИФин = 'Федеральный бюджет'"
        ElseIf argument = "внебюджет" Then
            sqlString += "  WHERE ИФин = 'Платное обучение'"
        End If

        sqlString += " ) AS slush
                          On slush.Снилс = sostav.слушатель
                      GROUP BY sostav.КолЧас) AS tbl_slush
                      INNER Join
                    
                    (SELECT
                        tbl.КолЧас,
                        COUNT(gr) AS number_gr
                        FROM
                        (SELECT 
                            sostav.КолЧас,
                            sostav.Код AS gr
                          FROM (SELECT
                              spec.Код,
                              spec.КолЧас,
                              слушатель
                            FROM (SELECT
                                Код,
                                КолЧас
                              FROM группа" +
                    "         WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec"

        sqlString += "       INNER JOIN составгрупп
                                ON spec.Код = kod) AS sostav
                            INNER JOIN (SELECT
                                Снилс
                                FROM слушатель
                                "

        If argument = "бюджет" Then
            sqlString += "  WHERE ИФин = 'Федеральный бюджет'"
        ElseIf argument = "внебюджет" Then
            sqlString += "  WHERE ИФин = 'Платное обучение'"
        End If

        sqlString += "
                              ) AS slush
                              ON slush.Снилс = sostav.слушатель

                          GROUP BY sostav.Код) AS tbl 
                        GROUP BY tbl.КолЧас)
                      AS gr

                        On gr.КолЧас = tbl_slush.КолЧас
                      INNER Join(SELECT
                          COUNT(spec.Код) As number_slush,
                          spec.КолЧас
                            FROM(SELECT
                            Код,
                            КолЧас
                          From группа" +
                    "         WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'"

        sqlString += ") AS spec" +
                    "      INNER Join составгрупп
                            On spec.Код = kod
      INNER JOIN 
      (SELECT
          Снилс
        FROM слушатель "

        If argument = "бюджет" Then
            sqlString += "  WHERE ИФин = 'Федеральный бюджет'"
        ElseIf argument = "внебюджет" Then
            sqlString += "  WHERE ИФин = 'Платное обучение'"
        End If

        sqlString += " ) AS slush

        ON slush.Снилс = слушатель

    GROUP BY spec.КолЧас) AS sostav_chel

    ON tbl_slush.КолЧас = sostav_chel.КолЧас"


        Return sqlString
    End Function

    Public Function SQLString_SELECT_dateAndKvalGrupp(kod As Integer)
        Dim sqlString As String = ""

        sqlString = "SELECT" +
                    "   YEAR(ДатаКЗ) AS date," +
                    "   УровеньКвалификации AS Kval" +
                    " FROM группа" +
                    " WHERE Код =" & kod

        Return sqlString
    End Function

    Public Function SQLString_UpdateNumbersSGrupp(kod As Integer)
        Dim sqlString As String = ""

        sqlString = " UPDATE составгрупп set НомерУд=NULL,РегНомерУд=NULL ,РегНомерСвид=NULL ,НомерСвид=NULL,РегНомерДиплома=NULL,НомерДиплома=NULL WHERE Kod=" & kod

        Return sqlString
    End Function

    Public Function SQLString_loadGruppa()
        Dim sqlString As String = ""
        sqlString = " SELECT Номер, Программа, YEAR(ДатаНЗ),Код FROM Группа WHERE Номер <> " & Chr(39) & "" & Chr(39) & " AND ДатаКЗ > '" & ААОсновная.mySqlConnect.dateToFormatMySQL(Date.Now.AddMonths(-6)) & "'"

        If ААОсновная.prikazCvalif = ААОсновная.PP Then
            sqlString &= " AND УровеньКвалификации = 'профессиональная переподготовка'"
        ElseIf ААОсновная.prikazCvalif = ААОсновная.PK Then
            sqlString &= " AND УровеньКвалификации = 'повышение квалификации'"
        ElseIf ААОсновная.prikazCvalif = ААОсновная.PO Then
            sqlString &= " AND УровеньКвалификации = 'профессиональное обучение'"
        ElseIf ААОсновная.prikazCvalif = ААОсновная.PK_PP Then
            sqlString &= " AND (УровеньКвалификации = 'профессиональная переподготовка' OR УровеньКвалификации = 'повышение квалификации')"
        End If
        If ФормаСписок.sortColumn <> -1 Then

            If (ФормаСписок.ListViewСписок.Columns(ФормаСписок.sortColumn).Text = "Группа" Or ФормаСписок.ListViewСписок.Columns(ФормаСписок.sortColumn).Text = "Номер") And ААОсновная.prikazCvalif = ААОсновная.PK Then
                sqlString &= " ORDER BY Номер"
                If ФормаСписок.sort = ФормаСписок.PoUb Then
                    sqlString &= " DESC"
                End If
            Else
                sqlString &= " ORDER BY Программа"
            End If
        Else
            sqlString &= " ORDER BY Программа"
        End If
        Return sqlString
    End Function

    Public Function ProgrammPoUKvalifikLimit1(UrovenKvalifik As String)
        Dim sqlString As String = ""
        If UrovenKvalifik = "" Then
            sqlString = "SELECT name FROM programma GROUP BY programma.name ORDER BY name"
        Else
            sqlString = " SELECT" +
  " programma.name,
    MAX(date),
    MAX(programma.kod)" +
  "       FROM" +
" (SELECT " +
" uroven_kvalifik.kod" +
"        From uroven_kvalifik" +
"     WHERE uroven_kvalifik.name = '" + UrovenKvalifik + "'" +
"     ) AS tbl1" +
"   INNER Join programma" +
"     On tbl1.kod = programma.uroven_kvalifik
  GROUP BY programma.name" +
" ORDER BY name"
        End If
        Return sqlString

    End Function

    Public Function ProgrammPoUKvalifik(UrovenKvalifik As String)
        Dim sqlString As String = ""
        If UrovenKvalifik = "" Then
            sqlString = "SELECT name,date,kod FROM programma ORDER BY name"
        Else
            sqlString = " SELECT" +
  " programma.name,
    date,
    programma.kod" +
  "       FROM" +
" (SELECT " +
" uroven_kvalifik.kod" +
"        From uroven_kvalifik" +
"     WHERE uroven_kvalifik.name = '" + UrovenKvalifik + "'" +
"     ) AS tbl1" +
"   INNER Join programma" +
"     On tbl1.kod = programma.uroven_kvalifik" +
" ORDER BY name"
        End If
        Return sqlString

    End Function


    Public Function SQLString_OtchetMassDataSlush(DateNach As String, DateKon As String)
        Dim sqlString As String = ""
        sqlString = " SELECT" +
  " слушатель.Код," +
  " слушатель.Снилс," +
  " слушатель.Фамилия," +
  " слушатель.Отчество," +
  " слушатель.Имя," +
  " слушатель.ДатаРождения," +
  " слушатель.Пол," +
  " слушатель.УОбразования," +
  " слушатель.НаимДОО," +
  " слушатель.СерияДОО," +
  " слушатель.НомерДОО," +
  " слушатель.ФамилияДОО," +
  " слушатель.АРег," +
  " слушатель.Телефон," +
  " слушатель.Гражданство," +
  " слушатель.ДУЛ," +
  " слушатель.СерияДУЛ," +
  " слушатель.НомерДУЛ," +
  " слушатель.ИФин," +
  " слушатель.ДатаРегистрации" +
  " FROM" +
  " (" +
" SELECT " +
 "        составгрупп.Слушатель" +
" FROM группа" +
"   INNER JOIN составгрупп" +
"     ON группа.Код = составгрупп.Kod" +
"     WHERE группа.ДатаКЗ BETWEEN '" + DateNach + "' And '" + DateKon + "'" +
"     ) AS tbl1" +
"   INNER JOIN слушатель" +
"     ON tbl1.Слушатель = слушатель.Снилс"

        Return sqlString
    End Function


    Public Function SQLString_OtchetMassSlush(DateNach As String, DateKon As String)
        Dim sqlString As String = ""
        sqlString = "SELECT" +
  " составгрупп.Слушатель," +
  " составгрупп.Kod," +
  " gr.Номер" +
  " FROM (SELECT " +
  " Номер," +
  " код " +
  "   FROM группа " +
  "   WHERE группа.ДатаКЗ BETWEEN '2023/1/1 00:00:00' AND '2023/2/17 00:00:00') AS gr" +
  " INNER JOIN составгрупп" +
    " On gr.Код = составгрупп.Kod"

        Return sqlString
    End Function


    Public Function sprSlushTblGroup(Snils As String)
        Dim sqlString As String = ""
        sqlString = "Select Код, Номер, Программа, ДатаНЗ, ДатаКЗ FROM Группа INNER JOIN СоставГрупп On Группа.Код = СоставГрупп.Kod WHERE СоставГрупп.Слушатель = " & Chr(39) & Snils & Chr(39) + " ORDER BY ДатаНЗ"
        Return sqlString
    End Function

    Public Function SQLSTring_PKZayavlenie(kod As Integer)
        Dim sqlString As String = ""
        sqlString = "Select" +
  " слушатель.Фамилия," +
  " слушатель.Имя," +
  " слушатель.Отчество," +
  " слушатель.АРег," +
  " слушатель.Телефон," +
  " слушатель.Почта" +
" FROM слушатель" +
  " INNER JOIN составгрупп" +
    " On слушатель.Снилс = составгрупп.Слушатель" +
    " WHERE составгрупп.Kod = " & kod & "" +
      " ORDER BY Фамилия"

        Return sqlString
    End Function

    Public Function SQLSTring_KartSlushatel(kod As Integer)
        Dim sqlString As String = ""
        sqlString = "SELECT" +
  " слушатель.Фамилия," +
  " слушатель.Имя," +
  " слушатель.Отчество," +
  " слушатель.ДатаРождения," +
  " слушатель.НаимДОО," +
  " слушатель.ДатаОкончанияОбразованияПоДОО," +
  " слушатель.СерияДОО," +
  " слушатель.НомерДОО" +
" FROM слушатель" +
  " INNER JOIN составгрупп" +
    " ON слушатель.Снилс = составгрупп.Слушатель" +
    " WHERE составгрупп.Kod = " & kod & "" +
      " ORDER BY Фамилия"

        Return sqlString
    End Function


    Public Function updateGroup(gruppa As Gruppa.strGruppa) As String
        Dim sqlString As String = ""
        Dim КолЧас,
            DataString,
            ОсновнойДокумент,
            Часть1,
            Часть2,
            Часть3,
            Часть4 As String

        Dim НомераУДС

        If gruppa.urKvalific = "специальный экзамен" Then
            КолЧас = "null"
        Else
            КолЧас = gruppa.kolChasov
        End If

        DataString = ААОсновная.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)

        Часть1 = "Номер=" & Chr(39) & gruppa.number & Chr(39) &
            ", ФормаО=" & Chr(39) & gruppa.formaObuch & Chr(39) &
            ", ДатаНЗ=" & Chr(39) & gruppa.dataNZ & Chr(39) &
            ", ДатаКЗ=" & Chr(39) & gruppa.dataKZ & Chr(39) &
            ", Спец=" & Chr(39) & gruppa.specialnost & Chr(39) &
            ",kod_programm=" & gruppa.kodProgramm &
            ",Программа=" & Chr(39) & gruppa.programma & Chr(39) &
            ",КолЧас=" & КолЧас & ", Куратор=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.kurator & Chr(39) & " LIMIT 1)" &
            ", ОтвЗаПракт=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.otvZaPraktiku & Chr(39) & " LIMIT 1)" &
            ", датаСоздания=" & Chr(39) & DataString & Chr(39)

        Часть2 = ", modul1=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul1 & Chr(39) & " LIMIT 1), modul2=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul2 & Chr(39) & " LIMIT 1)
            , modul3=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul3 & Chr(39) & " LIMIT 1), modul4=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul4 & Chr(39) & " LIMIT 1)
            , modul5=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul5 & Chr(39) & " LIMIT 1), modul6=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul6 & Chr(39) & " LIMIT 1)
            , modul7=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul7 & Chr(39) & " LIMIT 1), modul8=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul8 & Chr(39) & " LIMIT 1)
            , modul9=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul9 & Chr(39) & " LIMIT 1), modul10=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul10 & Chr(39) & " LIMIT 1)"

        Часть3 = ", УровеньКвалификации=" & Chr(39) & gruppa.urKvalific & Chr(39) &
            ", Финансирование=" & Chr(39) & gruppa.financir & Chr(39) &
            ", НомерПротоколаИА=" & Chr(39) & gruppa.nomerProtIA & Chr(39) &
            ",НомерУд=" & gruppa.NumbersUDS(0, 0) &
            ", РегНомерУд=" & gruppa.NumbersUDS(0, 1) &
            ",ДатаВыдачиУд=" & Chr(39) & gruppa.dataVUd & Chr(39) &
            ",НомерДиплома=" & gruppa.NumbersUDS(0, 2) & ", РегНомерДиплома=" & gruppa.NumbersUDS(0, 3)

        Часть4 = ", ДатаВыдачиДиплома=" & Chr(39) & gruppa.dataVD & Chr(39) &
            ", НомерСвид=" & gruppa.NumbersUDS(0, 4) & ", РегНомерСвид=" & gruppa.NumbersUDS(0, 5) &
            ", ДатаВыдачиСвид=" & Chr(39) & gruppa.dataVSv & Chr(39) &
            ", Квалификация=" & Chr(39) & gruppa.kvalifikaciya & Chr(39) & ", ОсновнойДокумент=" & Chr(39) & gruppa.osnovnoyDok & Chr(39) &
            ", НомерПротоколаСпецэкзамен=" & Chr(39) & gruppa.nomerProtokolaSpec & Chr(39) &
            ",ДатаСпецЭкзамен=" & Chr(39) & gruppa.dataSpec & Chr(39)

        updateGroup = "UPDATE Группа SET " & Часть1 & Часть2 & Часть3 & Часть4 & " WHERE Код =" & gruppa.Kod

    End Function


    Public Function insertIntoGroup(gruppa As Gruppa.strGruppa) As String
        Dim sqlString As String = ""
        Dim КолЧас, DataString, Часть1, Часть2 As String

        DataString = ААОсновная.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)

        If gruppa.urKvalific = "специальный экзамен" Then
            КолЧас = "null"
        End If

        Часть1 = "(Номер,"
        Часть2 = "( " & Chr(39) & gruppa.number & Chr(39)

        Часть1 = Часть1 & "ФормаО,ДатаНЗ,"
        Часть2 = Часть2 & " , " & Chr(39) & gruppa.formaObuch & Chr(39) & " , " & Chr(39) & gruppa.dataNZ & Chr(39)

        Часть1 = Часть1 & "ДатаКЗ,Спец,"
        Часть2 = Часть2 & " , " & Chr(39) & gruppa.dataKZ & Chr(39) & " , " & Chr(39) & gruppa.specialnost & Chr(39)

        Часть1 = Часть1 & "kod_programm,Программа,КолЧас,"
        Часть2 = Часть2 & " , " & gruppa.kodProgramm & ", " & Chr(39) & gruppa.programma & Chr(39) & " , " & gruppa.kolChasov

        Часть1 = Часть1 & "Куратор,ОтвЗаПракт,"
        Часть2 = Часть2 & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.kurator & Chr(39) & " LIMIT 1) ,(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.otvZaPraktiku & Chr(39) & "  LIMIT 1)"

        Часть1 = Часть1 & "датаСоздания, modul1,"
        Часть2 = Часть2 & " , " & Chr(39) & DataString & Chr(39) & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul1 & Chr(39) & " LIMIT 1)"

        Часть1 = Часть1 & "modul2,modul3,"
        Часть2 = Часть2 & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul2 & Chr(39) & " LIMIT 1) , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul3 & Chr(39) & " LIMIT 1)"

        Часть1 = Часть1 & "modul4,modul5,modul6,modul7,modul8,modul9,modul10,"
        Часть2 = Часть2 & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul4 & Chr(39) & " LIMIT 1) , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul5 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul6 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul7 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul8 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul9 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul10 & Chr(39) & " LIMIT 1)"

        Часть1 = Часть1 & "уровеньКвалификации,"
        Часть2 = Часть2 & " , " & Chr(39) & gruppa.urKvalific & Chr(39)

        Часть1 = Часть1 & "Финансирование, НомерПротоколаИА,"
        Часть2 = Часть2 & " , " & Chr(39) & gruppa.financir & Chr(39) & " , " & Chr(39) & gruppa.nomerProtIA & Chr(39)

        Часть1 = Часть1 & "НомерУд, РегНомерУд, ДатаВыдачиУд,"
        Часть2 = Часть2 & " , " & gruppa.NumbersUDS(0, 0) & " , " & gruppa.NumbersUDS(0, 1) & " , " & Chr(39) & gruppa.dataVUd & Chr(39)

        Часть1 = Часть1 & "НомерДиплома, РегНомерДиплома,ДатаВыдачиДиплома,"
        Часть2 &= " , " & gruppa.NumbersUDS(0, 2) & " , " & gruppa.NumbersUDS(0, 3) & " , " & Chr(39) & gruppa.dataVD & Chr(39)

        Часть1 = Часть1 & " НомерСвид,РегНомерСвид, ДатаВыдачиСвид,"
        Часть2 &= " , " & gruppa.NumbersUDS(0, 4) & " , " & gruppa.NumbersUDS(0, 5) & " , " & Chr(39) & gruppa.dataVSv & Chr(39)

        Часть1 = Часть1 & "Квалификация, ОсновнойДокумент,"
        Часть2 &= " , " & Chr(39) & gruppa.kvalifikaciya & Chr(39) & " , " & Chr(39) & gruppa.osnovnoyDok & Chr(39)

        Часть1 = Часть1 & "ДатаСпецЭкзамен,НомерПротоколаСпецэкзамен)"
        Часть2 &= " , " & Chr(39) & gruppa.dataSpec & Chr(39) & " , " & Chr(39) & gruppa.nomerProtIA & Chr(39) & " )"

        sqlString = "INSERT INTO Группа " & Часть1 & "  VALUES " & Часть2
        insertIntoGroup = sqlString
    End Function

    Public Function updateSlushatel(slushatel As Slushatel.strSlushatel) As String

        Dim Часть1 As String, Часть2 As String, Часть3 As String, Часть4 As String
        Dim Data As String
        Dim sqlString As String = "", ДатаВыдачиДул, СтрокаЗапроса As String

        sqlString = "Снилс=" & Chr(39) & slushatel.snils & Chr(39) &
            ", Фамилия=" & Chr(39) & slushatel.фамилия & Chr(39) &
            ", Имя=" & Chr(39) & slushatel.имя & Chr(39) &
            ", Отчество=" & Chr(39) & slushatel.отчество & Chr(39) &
            ", ДатаРождения=" & Chr(39) & ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.датаР) & Chr(39) &
            ", Пол=" & Chr(39) & slushatel.пол & Chr(39) &
            ", УОбразования=" & Chr(39) & slushatel.уровеньОбразования & Chr(39) &
            ", НаимДОО=" & Chr(39) & slushatel.образование & Chr(39) &
            ", СерияДОО=" & Chr(39) & slushatel.серияДокументаООбразовании & Chr(39) &
            ", НомерДОО=" & Chr(39) & slushatel.номерДокументаООбразовании & Chr(39) &
            ", ФамилияДОО=" & Chr(39) & slushatel.фамилияВДокОбОбразовании & Chr(39) &
            ",АРег=" & Chr(39) & slushatel.адресРегистрации & Chr(39) &
            ", Телефон=" & Chr(39) & slushatel.телефон & Chr(39) &
            ", Гражданство=" & Chr(39) & slushatel.гражданство & Chr(39) &
            ", ДУЛ=" & Chr(39) & slushatel.ДУЛ & Chr(39) &
            ", СерияДУЛ=" & Chr(39) & slushatel.серияДУЛ & Chr(39) &
            ", НомерДУЛ=" & Chr(39) & slushatel.номерДУЛ & Chr(39) &
            ",ИФин=" & Chr(39) & slushatel.источникФин & Chr(39) &
            ", НОрг=(SELECT kod FROM napr_organization WHERE name=" & Chr(39) & slushatel.направившаяОрг & Chr(39) & ")" &
            ", НомерНапрРосздрав=" & Chr(39) & slushatel.номерНаправленияРосздравнадзора & Chr(39) &
            ", ДатаНапрРосздрав=" & Chr(39) & ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.датаНаправленияРосздравнвдзора) & Chr(39) &
            ", Специальность=" & Chr(39) & slushatel.специальностьСлушателя & Chr(39) &
            ", ДатаРегистрации=" & Chr(39) & ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.датаРег) & Chr(39) &
            ", Почта=" & Chr(39) & slushatel.Email & Chr(39) &
            ", ДУЛКемВыдан=" & Chr(39) & slushatel.кемВыданДУЛ & Chr(39) &
            ", doo_vid_dok=(SELECT kod FROM doo_vid_dok WHERE name = '" & slushatel.doo_vid_dok & "' LIMIT 1)"



        sqlString = "UPDATE Слушатель SET " & sqlString & " WHERE Снилс =" & Chr(39) & slushatel.старыйСнилс & Chr(39)
        updateSlushatel = sqlString


    End Function


    Public Function insertIntoSlushatel(slushatel As Slushatel.strSlushatel) As String

        Dim Часть1 As String, Часть2 As String, Часть3 As String, Часть4 As String
        Dim Data As String
        Dim sqlString As String, ДатаВыдачиДул, СтрокаЗапроса As String

        sqlString = ""


        Часть1 = "(Снилс,"
        Часть2 = "(" & Chr(39) & ДобавитьРубашку.УдалитьРубашку(slushatel.snils) & Chr(39)
        Часть1 = +"Фамилия, Имя, Отчество,"
        Часть2 = +"," & Chr(39) & slushatel.фамилия & Chr(39) & "," & Chr(39) & slushatel.имя & Chr(39) & "," & Chr(39) & slushatel.отчество & Chr(39)
        Часть1 = +"ДатаРождения, Пол, УОбразования,"
        Часть2 = +"," & Chr(39) & ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.датаР) & Chr(39) & "," & Chr(39) & slushatel.пол & Chr(39) & "," & Chr(39) & slushatel.уровеньОбразования & Chr(39)
        Часть1 = +"НаимДОО, СерияДОО, НомерДОО,"
        Часть2 = +"," & Chr(39) & slushatel.образование & Chr(39) & "," & Chr(39) & slushatel.серияДокументаООбразовании & Chr(39) & "," & Chr(39) & slushatel.номерДокументаООбразовании & Chr(39) &
        Часть1 = +"ФамилияДОО, АРег, Телефон,"
        Часть2 = +"," & Chr(39) & slushatel.фамилияВДокОбОбразовании & Chr(39) & "," & Chr(39) & slushatel.адресРегистрации & Chr(39) & "," & Chr(39) & slushatel.телефон & Chr(39) &
        Часть1 = +"Гражданство, ДУЛ, СерияДУЛ, НомерДУЛ,"
        Часть2 = +"," & Chr(39) & slushatel.гражданство & Chr(39) & "," & Chr(39) & slushatel.ДУЛ & Chr(39) & "," & Chr(39) & slushatel.серияДУЛ & Chr(39) & "," & Chr(39) & slushatel.номерДУЛ & Chr(39)
        Часть1 = +"ИФин, НОрг, НомерНапрРосздрав,"
        Часть2 = +"," & Chr(39) & slushatel.источникФин & Chr(39) & ",(SELECT kod FROM napr_organization WHERE name=" & Chr(39) & slushatel.направившаяОрг & Chr(39) & ") , " & Chr(39) & slushatel.номерНаправленияРосздравнадзора & Chr(39)
        Часть1 = +" ДатаНапрРосздрав,"
        Часть2 = +" , " & Chr(39) & ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.датаНаправленияРосздравнвдзора) & Chr(39) &
        Часть1 = +"Специальность, ДатаРегистрации, Почта,"
        Часть2 = +" , " & Chr(39) & slushatel.специальностьСлушателя & Chr(39) & " , " & Chr(39) & ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.датаРег) & Chr(39) & " , " & Chr(39) & slushatel.Email & Chr(39) &
        Часть1 = +"ДУЛКемВыдан,ДУЛДатаВыдачи ) "
        Часть2 = +", " & Chr(39) & slushatel.кемВыданДУЛ & Chr(39) & ", "

        If slushatel.датаВыдачиДУЛ = "null" Then
            Часть2 += ДатаВыдачиДул & " ) "
        Else Часть2 += Chr(39) & ААОсновная.mySqlConnect.dateToFormatMySQL(slushatel.датаВыдачиДУЛ) & Chr(39) & " ) "
        End If


        sqlString = "INSERT INTO Слушатель " & Часть1 & "  VALUES " & Часть2

    End Function


End Module
