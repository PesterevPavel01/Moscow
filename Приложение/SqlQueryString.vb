Imports System.Xml
Imports Org.BouncyCastle.Utilities
Imports WindowsApp2.Worker

Public Class SqlQueryString
    Dim sqlString As String = ""

    Public Function delete_organization(kod As String) As String

        sqlString = "DELETE FROM napr_organization WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function delete_doljnost(kod As String) As String

        sqlString = "DELETE FROM doljnost WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function check_kod_doljnost(kod As String) As String

        sqlString = "SELECT
                      COUNT(sotrudnik.doljnost)
                    FROM sotrudnik
                    WHERE sotrudnik.doljnost = " + kod
        Return sqlString

    End Function

    Public Function check_kod_organization(kod As String) As String

        sqlString = "SELECT
                      COUNT(Код)
                    FROM students
                    WHERE НОрг =" + kod
        Return sqlString

    End Function

    Public Function load_kod_doljnost(doljnost As String) As String

        sqlString = "SELECT
                     kod
                     FROM 
                     doljnost
                     WHERE name='" + doljnost + "'"
        Return sqlString

    End Function

    Public Function load_kod_organization(organization As String) As String

        sqlString = "SELECT
                     kod
                     FROM 
                     napr_organization
                     WHERE name='" + organization + "'"
        Return sqlString

    End Function

    Public Function check_doljnost(doljnost As String) As String

        sqlString = "SELECT
                     COUNT(kod)
                     FROM 
                     doljnost
                     WHERE name='" + doljnost + "'"
        Return sqlString

    End Function

    Public Function check_organization(organization As String, full_name As String) As String

        sqlString = "SELECT
                     COUNT(kod)
                     FROM 
                     napr_organization
                     WHERE name='" + organization + "' AND full_name='" + full_name + "'"
        Return sqlString

    End Function

    Public Function update_organization(organization As String, kod As String, full_name As String) As String

        sqlString = "UPDATE napr_organization SET name='" + organization + "', full_name='" + full_name + "' WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function update_doljnost(doljnost As String, kod As String) As String

        sqlString = "UPDATE doljnost SET name='" + doljnost + "' WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function save_organization(organization As String, full_name As String) As String

        sqlString = "INSERT INTO napr_organization (name,full_name) VALUE ('" + organization + "','" + full_name + "')"
        Return sqlString

    End Function

    Public Function save_doljnost(doljnost As String) As String

        sqlString = "INSERT INTO doljnost (name) VALUE ('" + doljnost + "')"
        Return sqlString

    End Function

    Public Function load_list_doljnosti() As String

        sqlString = "SELECT
                      doljnost.name AS Должность,
                      doljnost.kod
                    FROM doljnost"
        Return sqlString

    End Function

    Public Function load_list_organization() As String

        sqlString = "SELECT
                      napr_organization.name AS Организация,
                      napr_organization.full_name AS 'Полное наименование',
                      napr_organization.kod
                    FROM napr_organization
                    ORDER BY napr_organization.name"
        Return sqlString

    End Function

    Public Function update_status_list(kod As String, status As String) As String

        sqlString = "UPDATE sotrudnik
                    SET in_list = " + status + "
                    WHERE kod = " + kod
        Return sqlString

    End Function

    Public Function removeWorker(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "DELETE FROM sotrudnik WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function checkWorker(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                    COUNT(tbl.Код)
                    FROM
                    (SELECT Код FROM `group` WHERE modul1=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul2=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul3=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul4=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul5=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul6=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul7=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul8=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul9=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE modul10=" + kod + "
                    UNION ALL 
                    SELECT Код FROM `group` WHERE Куратор=" + kod + "
                    UNION ALL 
                    SELECT ОтвЗаПракт FROM `group` WHERE ОтвЗаПракт=" + kod + "
                    ) AS tbl"
        Return sqlString

    End Function

    Public Function loadNumberWorker(worker_name As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT COUNT(kod) FROM
                    sotrudnik
                    WHERE name='" + worker_name + "'"
        Return sqlString

    End Function

    Public Function loadKodWorker(worker_name As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT MAX(kod) FROM
                    sotrudnik
                    WHERE name='" + worker_name + "'"
        Return sqlString

    End Function

    Public Function updateWorker(worker As Worker_structure, worker_type As String) As String
        Dim sqlString As String = ""
        sqlString = "UPDATE sotrudnik set name='" & worker.name & "',name_full='" & worker.name_full & "',name_pad='" & worker.name_pad & "',
                     doljnost=(SELECT kod FROM doljnost WHERE name='" & worker.worker_doljnost & "' LIMIT 1),
                     type_sotrudnik=(SELECT kod FROM kodirovka WHERE name='" & worker_type & "' LIMIT 1) WHERE kod=" & worker.kod
        Return sqlString

    End Function

    Public Function addWorker(worker As Worker_structure, worker_type As String) As String

        Dim sqlString As String = ""
        sqlString = "INSERT INTO sotrudnik (name, name_full, name_pad, doljnost, type_sotrudnik)
                        VALUES
                        (
                        '" + worker.name + "','" + worker.name_full + "','" + worker.name_pad + "',(SELECT kod FROM doljnost WHERE name='" + worker.worker_doljnost + "' LIMIT 1),(SELECT kod FROM kodirovka WHERE name='" + worker_type + "' LIMIT 1)  
                        )"
        Return sqlString

    End Function

    Public Function loadListDoljnost() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      name AS Имя 
                    FROM doljnost"
        Return sqlString

    End Function

    Public Function loadDefaultType() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      name 
                    FROM kodirovka WHERE kod=0"
        Return sqlString

    End Function

    Public Function loadListWorkerType() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      name 
                    FROM kodirovka"
        Return sqlString

    End Function

    Public Function loadWorker() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
sotrudnik.in_list,
                      sotrudnik.name AS Имя,
                      sotrudnik.name_full AS Полное,
                      sotrudnik.name_pad AS Склонение,
                      doljnost.name AS Должность,
                      kodirovka.name AS type,
                      sotrudnik.kod
                    FROM sotrudnik
                      LEFT JOIN doljnost
                        ON sotrudnik.doljnost = doljnost.kod
                      LEFT JOIN kodirovka 
                        ON sotrudnik.type_sotrudnik = kodirovka.kod
                      WHERE sotrudnik.name<>''"
        Return sqlString

    End Function

    Public Function selectModulInProg(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      COUNT(progs_mods_hours.kod_modul) AS expr1
                    FROM progs_mods_hours
                      INNER JOIN programm
                        ON progs_mods_hours.kod_prog = programm.kod
                    WHERE progs_mods_hours.kod_prog = " + kod
        Return sqlString

    End Function

    Public Function deleteModul(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "DELETE FROM progs_mods_hours WHERE kod_modul=" + kod + ";
                    DELETE FROM moduls WHERE kod=" + kod
        Return sqlString

    End Function
    Public Function updateModul(name As String, hours As String, kod As String) As String

        Dim sqlString As String = ""
        sqlString = "UPDATE moduls SET name='" + name + "',hours=" + hours + "
                    WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function insertModul(name As String, hours As String) As String

        Dim sqlString As String = ""
        sqlString = "INSERT IGNORE INTO moduls (name,hours)
                    VALUES('" + name + "'," + hours + ")"
        Return sqlString

    End Function
    Public Function updateModulnumber(listData As List(Of List(Of String)), kod_programm As Int16) As String

        Dim sqlString As String = ""
        sqlString = "ROLLBACK;
                    START TRANSACTION;
                    
                    UPDATE progs_mods_hours
                    SET modul_number = 0
                    WHERE  kod_modul=" + listData(0)(1) + "
                    AND kod_prog = " + Convert.ToString(kod_programm) + ";

                    UPDATE progs_mods_hours
                    SET modul_number = " + listData(0)(0) + "
                    WHERE  kod_modul=" + listData(1)(1) + "
                    AND kod_prog = " + Convert.ToString(kod_programm) + ";

                    UPDATE progs_mods_hours
                    SET modul_number = " + listData(1)(0) + "
                    WHERE  kod_modul=" + listData(0)(1) + "
                    AND kod_prog = " + Convert.ToString(kod_programm) + ";

                    COMMIT;"

        Return sqlString

    End Function
    Public Function selectNumberModulTop(kod_programm As Int16, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT 
                    tbl.m_number,
                    tb2.kod_modul
                    FROM 
                    (
                    SELECT
                    MAX(progs_mods_hours.modul_number) AS m_number
                    FROM progs_mods_hours
                    WHERE progs_mods_hours.kod_prog = " + Convert.ToString(kod_programm) + "
                    And modul_number < (SELECT progs_mods_hours.modul_number FROM progs_mods_hours 
                    INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_programm) + ") LIMIT 1) AS tbl
                    INNER JOIN 
                    (SELECT kod_modul,modul_number FROM progs_mods_hours WHERE kod_prog= " + Convert.ToString(kod_programm) + ") AS tb2
                    ON tbl.m_number=tb2.modul_number
                    UNION ALL 
                    SELECT progs_mods_hours.modul_number,
                    progs_mods_hours.kod_modul
                    FROM progs_mods_hours
                    INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_programm)
        Return sqlString

    End Function

    Public Function selectNumberModulButtom(kod_programm As Int16, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                    modul_number,
                    kod_modul
                    FROM 
                    progs_mods_hours
                    WHERE
                    kod_prog = " + Convert.ToString(kod_programm) + " AND
                    modul_number= 
                    (
                    SELECT
                    MIN(progs_mods_hours.modul_number)
                    FROM progs_mods_hours
                    WHERE progs_mods_hours.kod_prog = " + Convert.ToString(kod_programm) + "
                    And modul_number > (SELECT progs_mods_hours.modul_number FROM progs_mods_hours INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_programm) + " LIMIT 1) LIMIT 1)
                    UNION ALL 
                    SELECT progs_mods_hours.modul_number,
                    progs_mods_hours.kod_modul
                    FROM progs_mods_hours
                    INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_programm)
        Return sqlString

    End Function

    Public Function insertModulIntoProg(kod_programm As String, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = "INSERT IGNORE INTO progs_mods_hours (kod_prog,kod_modul,hours,modul_number)
                    SELECT " + kod_programm + "
                    ," + kod_modul + ",
                    (SELECT hours FROM moduls WHERE kod=" + kod_modul + "),
                    (SELECT IFNULL(MAX(modul_number),0)+1 FROM progs_mods_hours WHERE kod_prog=" + kod_programm + ")"
        Return sqlString

    End Function

    Public Function deleteModul_prog(kod As String, kod_prog As String) As String

        Dim sqlString As String = ""
        sqlString = "DELETE FROM progs_mods_hours WHERE kod_prog=" + kod_prog + " AND kod_modul=" + kod
        Return sqlString

    End Function
    Public Function deleteProgramm(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "DELETE FROM progs_mods_hours WHERE kod_prog=" + kod + ";DELETE FROM programm WHERE kod=" + kod + ";UPDATE `group` SET kod_programm = NULL WHERE kod_programm=" + kod
        Return sqlString

    End Function
    Public Function updateModulHours(hours As String, kod As String, kod_prog As String) As String

        Dim sqlString As String = ""
        sqlString = "UPDATE progs_mods_hours SET hours=" + hours + " WHERE kod_modul=" + kod + " AND kod_prog=" + kod_prog
        Return sqlString

    End Function

    Public Function updateProgramm(programm As String, kod As String) As String

        Dim sqlString As String = ""
        sqlString = "UPDATE programm SET name='" + programm + "' WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function loadLastKodProgramm(programm As String, ur_kvalif As String) As String

        Dim sqlString As String = ""
        sqlString = " SELECT" +
                    "     MAX(kod)" +
                    "         FROM" +
                    "         programm" +
                    "         WHERE name ='" + programm + "' AND uroven_kvalifik=" +
                    "   (SELECT kod FROM uroven_kvalifik WHERE name='" + ur_kvalif + "' LIMIT 1)"
        Return sqlString

    End Function

    Public Function loadLastKodModul(name As String) As String

        Dim sqlString As String = ""
        sqlString = " SELECT" +
                    "     MAX(kod)" +
                    "         FROM" +
                    "             moduls" +
                    "             WHERE name ='" + name + "'"
        Return sqlString

    End Function

    Public Function loadLastKodModulInProgramm(kod_programm As String, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = " SELECT" +
                    "     kod" +
                    "         FROM" +
                    "             progs_mods_hours" +
                    " WHERE kod_prog=" + kod_programm + " AND kod_modul=" + kod_modul
        Return sqlString

    End Function

    Public Function addProgramm(programm As String, ur_kvalif As String) As String

        Dim sqlString As String = ""
        sqlString = "INSERT IGNORE INTO programm (uroven_kvalifik, name, kod)
                      SELECT
                        uroven_kvalifik.kod,
                        '" + programm + "',
                        (SELECT
                            MAX(programm.kod)+1 AS expr1
                          FROM programm) AS expr1
                      FROM uroven_kvalifik
                      WHERE uroven_kvalifik.name = '" + ur_kvalif + "'"
        Return sqlString

    End Function

    Public Function update_insert_query(number_column As Int16, name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String) As String

        Dim queryString As String = ""

        If number_column = 1 Then

            queryString = "INSERT INTO " + name_table + " (" + db_element_first + ")
                           VALUES ('" + values_element_first + "')"

        ElseIf number_column = 2 Then

            queryString = "INSERT INTO " + name_table + " (" + db_element_first + "," + db_element_second + ")
                           VALUES ('" + values_element_first + "','" + values_element_second + "')"

        End If

        Return queryString

    End Function

    Public Function update_check_query(number_column As Int16, name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String) As String

        Dim queryString As String = ""

        If number_column = 1 Then

            queryString = "Select
                            COUNT(kod)
                           FROM
                            " + name_table + "
                           WHERE " + db_element_first + " ='" + values_element_first + "'"

        ElseIf number_column = 2 Then

            queryString = "Select
                            COUNT(kod)
                           FROM
                            " + name_table + "
                           WHERE " + db_element_first + " ='" + values_element_first + "' AND " + db_element_second + "='" + values_element_second + "'"

        End If

        Return queryString

    End Function

    Public Function update_update_query(number_column As Int16, name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String, kod As Int64) As String

        Dim queryString As String = ""

        If number_column = 1 Then

            queryString = "UPDATE " + name_table + " SET " + db_element_first + "='" + values_element_first + "' WHERE kod=" + Convert.ToString(kod)

        ElseIf number_column = 2 Then

            queryString = "UPDATE " + name_table + " Set " + db_element_first + "='" + values_element_first + "'," + db_element_second + "='" + values_element_second + "' WHERE kod=" + Convert.ToString(kod)

        End If

        Return queryString

    End Function

    Public Function update_load_kod_query(number_column As Int16, name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String) As String

        Dim queryString As String

        If number_column = 1 Then

            queryString = "SELECT
                            kod
                           FROM 
                            " + name_table + "
                           WHERE " + db_element_first + "='" + values_element_first + "'"

        ElseIf number_column = 2 Then

            queryString = "SELECT
                            kod
                           FROM 
                            " + name_table + "
                           WHERE " + db_element_first + "='" + values_element_first + "' 
                           AND " + db_element_second + "='" + values_element_second + "'"

        End If

        Return queryString

    End Function

    Public Function update_prog_insert_query(number_column As Int16, name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String, name_prog As String) As String

        Dim queryString As String = ""

        queryString = "INSERT INTO " + name_table + " (" + db_element_first + "," + db_element_second + ",uroven_kvalifik)
                       VALUES ('" + values_element_first + "',(SELECT kod FROM kol_chas WHERE name=" + values_element_second + " LIMIT 1)
                        ,(SELECT kod FROM uroven_kvalifik WHERE name = '" + name_prog + "' LIMIT 1))"

        Return queryString

    End Function
    Public Function update_typeProgs_update_query(kodProg As String, kodTypeProgs As String, value As String) As String

        Dim queryString As String = ""

        queryString = "UPDATE
                        progs_type_hours
                        set hours=" + value + "
                        WHERE kod_prog=" + kodProg + " 
                        AND type=" + kodTypeProgs

        Return queryString

    End Function

    Public Function update_typeProgs_check_query(kodProg As String, kodTypeProgs As String, newValues As String) As String

        Dim queryString As String = ""

        queryString = "SELECT
                          COUNT(progs_type_hours.kod_prog) 
                        FROM progs_type_hours
                        WHERE kod_prog=" + kodProg + " 
                        AND type=" + kodTypeProgs + " 
                        AND hours=" + newValues

        Return queryString

    End Function

    Public Function update_prog_check_query(name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String, name_prog As String) As String

        Dim queryString As String = ""

        queryString = "Select
                            COUNT(kod)
                           FROM
                            " + name_table + "
                           WHERE " + db_element_first + " ='" + values_element_first + "' AND " + db_element_second + "= 
                           (SELECT kod FROM kol_chas WHERE name=" + values_element_second + " LIMIT 1) AND uroven_kvalifik = 
                           (SELECT kod FROM uroven_kvalifik WHERE name = '" + name_prog + "' LIMIT 1)"

        Return queryString

    End Function

    Public Function update_prog_update_query(name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String, kod As Int64) As String

        Dim queryString As String = ""

        queryString = "UPDATE " + name_table + " Set " + db_element_first + "='" + values_element_first + "'," + db_element_second + "=
                        (SELECT kod FROM kol_chas WHERE name=" + values_element_second + " LIMIT 1) WHERE kod=" + Convert.ToString(kod)

        Return queryString

    End Function

    Public Function update_prog_load_kod_query(name_table As String, db_element_first As String, values_element_first As String, name_prog As String) As String

        Dim queryString As String

        queryString = "SELECT
                            IFNULL(MAX(kod),-1)
                           FROM 
                            " + name_table + "
                           WHERE " + db_element_first + "='" + values_element_first + "' 
                           AND uroven_kvalifik=(SELECT kod FROM uroven_kvalifik WHERE name = '" + name_prog + "' LIMIT 1)"

        Return queryString

    End Function

    Public Function update_delete_query(programm_on As Boolean, name_table As String, name_programm As String, remove_kod As Int64) As String

        Dim queryString As String = ""

        If programm_on Then

            queryString = "DELETE FROM " + name_table + " WHERE kod=" + Convert.ToString(remove_kod) + " 
                           AND uroven_kvalifik = (SELECT kod FROM uroven_kvalifik WHERE name = '" + name_programm + "' LIMIT 1)"

        Else

            queryString = "DELETE FROM " + name_table + " WHERE kod=" + Convert.ToString(remove_kod)

        End If


        Return queryString

    End Function

    Public Function program__loadModulKod(name As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                     moduls.kod
                     FROM moduls
                     WHERE name='" + name + "'"
        Return sqlString

    End Function
    Public Function program__loadModuls() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                     moduls.name AS Модуль,
                     moduls.hours AS Часы,
                     moduls.kod as Код
                     FROM moduls"
        Return sqlString

    End Function
    Public Function program__loadTypes(kodProgram As String) As String

        sqlString = ""
        sqlString = "SELECT
                      type_class.name AS Тип,
                      IFNULL(hours.hours,0) AS Часы,
                      type_class.kod AS Код
                    FROM type_class
                      LEFT JOIN 
                      (SELECT
                          progs_type_hours.hours,
                          progs_type_hours.type
                        FROM progs_type_hours
                          INNER JOIN programm
                            ON progs_type_hours.kod_prog = programm.kod
                          WHERE kod=" + kodProgram + ") AS hours
                        ON type_class.kod = hours.type"
        Return sqlString

    End Function

    Public Function program__loadTypeList() As String

        sqlString = ""
        sqlString = "SELECT 
                        type_class.name
                        FROM type_class
                        ORDER BY type_class.number"
        Return sqlString

    End Function

    Public Function program__loadHours(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT 
                        name
                        FROM kol_chas
                        ORDER BY name"
        Return sqlString

    End Function
    Public Function program__loadModulsAndHours(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                     moduls.name as Модуль,
                     progs_mods_hours.hours as Часы,
                     progs_mods_hours.kod_modul as Код
                     FROM progs_mods_hours
                     INNER JOIN programm
                     ON progs_mods_hours.kod_prog = programm.kod
                     INNER JOIN moduls
                     ON progs_mods_hours.kod_modul = moduls.kod
                     WHERE programm.kod =" + kod + "
                     ORDER BY modul_number"
        Return sqlString

    End Function

    Public Function load_sum_hours(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                     SUM(progs_mods_hours.hours) as Часы
                     FROM progs_mods_hours
                     INNER JOIN programm
                     ON progs_mods_hours.kod_prog = programm.kod
                     INNER JOIN moduls
                     ON progs_mods_hours.kod_modul = moduls.kod
                     WHERE programm.kod =" + kod + "
                     GROUP BY programm.kod"
        Return sqlString

    End Function

    Public Function program__loadProgramms(uroven_cval As String) As String

        Dim sqlString As String = ""

        sqlString = "SELECT
                      programm.name AS Наименование,
                      kol_chas.name AS Часы,
                      programm.kod,
                      programm.date AS 'дата создания'
                    FROM programm
                      INNER JOIN uroven_kvalifik
                        ON programm.uroven_kvalifik = uroven_kvalifik.kod
                      INNER JOIN kol_chas
                        ON programm.hours = kol_chas.kod
                    WHERE uroven_kvalifik.name = '" + uroven_cval + "' ORDER BY programm.name"
        Return sqlString

    End Function
    Public Function loadUrovenKvalifikacii() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM uroven_kvalifik WHERE visible=1"
        Return sqlString

    End Function

    Public Function loadForma_obuch() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM forma_obuch"
        Return sqlString

    End Function

    Public Function loadSpecialnost() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM specialnost ORDER BY name"
        Return sqlString

    End Function

    Public Function loadKolChasov() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM kol_chas ORDER BY kod"
        Return sqlString

    End Function

    Public Function loadKurator() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN kodirovka ON sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE kodirovka.name = 'сотрудник' AND sotrudnik.in_list=1 ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function loadDirector() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN kodirovka ON sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE kodirovka.name = 'директор' OR kodirovka.name = 'замдир' AND sotrudnik.in_list=1 ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function slushatelFio(groupp As String) As String

        Dim sqlString As String = ""
        sqlString = "Select 
                     CONCAT(students.Фамилия,' ',students.Имя,' ',IFNULL(students.Отчество,' ')) 
                     FROM group_list 
                     INNER JOIN students ON group_list.students = students.Снилс 
                     WHERE group_list.Kod = " & ААОсновная.prikazKodGroup & " 
                     ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function load_list_prepod() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN 
                     kodirovka 
                     ON 
                     sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE (kodirovka.name = 'сотрудник' OR kodirovka.name = 'преподаватель') AND sotrudnik.in_list=1  ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function load_ruk_staj() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN 
                     kodirovka 
                     ON 
                     sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE kodirovka.name = 'сотрудник' AND sotrudnik.in_list=1  ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function load_komissiya() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN 
                     kodirovka 
                     ON 
                     sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE (kodirovka.name = 'сотрудник' OR kodirovka.name = 'замдир') AND sotrudnik.in_list=1  ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function load_soglasovano() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN 
                     kodirovka 
                     ON 
                     sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE (kodirovka.name = 'согласование' OR kodirovka.name = 'замдир') AND sotrudnik.in_list=1  ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function load_ispolnitel() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN 
                     kodirovka 
                     ON 
                     sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE kodirovka.name = 'сотрудник' AND sotrudnik.in_list=1  ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function load_proeсt_vnosit() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN 
                     kodirovka 
                     ON 
                     sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE kodirovka.name = 'сотрудник' AND sotrudnik.in_list=1  ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function loadOtv_attestat() As String

        Dim sqlString As String = ""
        sqlString = "SELECT sotrudnik.name FROM sotrudnik
                     INNER JOIN 
                     kodirovka 
                     ON 
                     sotrudnik.type_sotrudnik = kodirovka.kod
                     WHERE kodirovka.name = 'сотрудник' AND sotrudnik.in_list=1  ORDER BY sotrudnik.name"
        Return sqlString

    End Function

    Public Function loadDirectorDoljnost() As String

        Dim sqlString As String = ""
        sqlString = "SELECT doljnost.name FROM doljnost
                     INNER JOIN kodirovka ON doljnost.type = kodirovka.kod
                     WHERE kodirovka.name = 'директор' ORDER BY doljnost.name"
        Return sqlString

    End Function

    Public Function loadDoljnosti() As String

        Dim sqlString As String = ""
        sqlString = "SELECT doljnost.name FROM doljnost"
        Return sqlString

    End Function

    Public Function loadFinansirovanie() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM finansirovanie ORDER BY name"
        Return sqlString

    End Function

    Public Function loadKvalifikaciya() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM kvalifikaciya ORDER BY name"
        Return sqlString

    End Function

    Public Function load_kol_chas(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      kol_chas.name
                    FROM programm
                      INNER JOIN kol_chas
                        ON programm.hours = kol_chas.kod
                    WHERE programm.kod = " + kod
        Return sqlString

    End Function

    Public Function loadKogProgramm(ur_kval As String, name_prog As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                    programm.kod,
                    IFNULL(kc.name, 0)
                    FROM(
                    SELECT
                      prog.name,
                      MAX(date) AS date
                    FROM (SELECT
                        uroven_kvalifik.kod
                      FROM uroven_kvalifik"

        If Not ur_kval = "" Then
            sqlString += " WHERE uroven_kvalifik.name = '" + ur_kval + "'"
        End If

        sqlString += " ) AS tbl1
                      INNER JOIN (SELECT * FROM programm WHERE programm.name='" + name_prog + "') AS prog
                        ON tbl1.kod = prog.uroven_kvalifik
                        GROUP BY prog.name
                        ) AS tbl
                    INNER JOIN programm
                    ON tbl.name=programm.name AND
                        tbl.date=programm.date
                    LEFT JOIN kol_chas kc 
                    ON programm.hours = kc.kod
                    ORDER BY programm.name"
        Return sqlString

    End Function

End Class
