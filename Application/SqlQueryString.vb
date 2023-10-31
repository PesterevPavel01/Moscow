
Imports System.Xml
Imports WindowsApp2.Worker

Public Class SqlQueryString
    Dim sqlString As String = ""


    Public Function insertIntoGroupList(snils As String, kodGroup As String) As String
        sqlString = "INSERT INTO group_list (students, Kod ) VALUES ( " & Chr(39) & snils & Chr(39) & " , " & kodGroup & ")"
        Return sqlString
    End Function

    Public Function delete_organization(kod As String) As String

        sqlString = "DELETE FROM napr_organization WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function delete_position(kod As String) As String

        sqlString = "DELETE FROM position WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function check_kod_position(kod As String) As String

        sqlString = "SELECT
                      COUNT(worker.position)
                    FROM worker
                    WHERE worker.position = " + kod
        Return sqlString

    End Function

    Public Function check_kod_organization(kod As String) As String

        sqlString = "SELECT
                      COUNT(Код)
                    FROM students
                    WHERE НОрг =" + kod
        Return sqlString

    End Function

    Public Function load_kod_position(position As String) As String

        sqlString = "SELECT
                     kod
                     FROM 
                     position
                     WHERE name='" + position + "'"
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

    Public Function check_position(position As String) As String

        sqlString = "SELECT
                     COUNT(kod)
                     FROM 
                     position
                     WHERE name='" + position + "'"
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

    Public Function update_position(position As String, kod As String) As String

        sqlString = "UPDATE position SET name='" + position + "' WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function save_organization(organization As String, full_name As String) As String

        sqlString = "INSERT INTO napr_organization (name,full_name) VALUE ('" + organization + "','" + full_name + "')"
        Return sqlString

    End Function

    Public Function save_position(position As String) As String

        sqlString = "INSERT INTO position (name) VALUE ('" + position + "')"
        Return sqlString

    End Function

    Public Function load_list_positions() As String

        sqlString = "SELECT
                      position.name AS Должность,
                      position.kod
                    FROM position"
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

        sqlString = "UPDATE worker
                    SET in_list = " + status + "
                    WHERE kod = " + kod
        Return sqlString

    End Function

    Public Function removeWorker(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "DELETE FROM worker WHERE kod=" + kod
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
                    worker
                    WHERE name='" + worker_name + "'"
        Return sqlString

    End Function

    Public Function loadKodWorker(worker_name As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT MAX(kod) FROM
                    worker
                    WHERE name='" + worker_name + "'"
        Return sqlString

    End Function

    Public Function updateWorker(worker As Worker_structure, worker_type As String) As String
        Dim sqlString As String = ""
        sqlString = "UPDATE worker set name='" & worker.name & "',name_full='" & worker.name_full & "',name_pad='" & worker.name_pad & "',
                     position=(SELECT kod FROM position WHERE name='" & worker.worker_position & "' LIMIT 1),
                     type=(SELECT kod FROM encoding WHERE name='" & worker_type & "' LIMIT 1) WHERE kod=" & worker.kod
        Return sqlString

    End Function

    Public Function addWorker(worker As Worker_structure, worker_type As String) As String

        Dim sqlString As String = ""
        sqlString = "INSERT INTO worker (name, name_full, name_pad, position, type)
                        VALUES
                        (
                        '" + worker.name + "','" + worker.name_full + "','" + worker.name_pad + "',(SELECT kod FROM position WHERE name='" + worker.worker_position + "' LIMIT 1),(SELECT kod FROM 
                        encoding WHERE name='" + worker_type + "' LIMIT 1)  
                        )"
        Return sqlString

    End Function

    Public Function loadListPosition() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      name AS Имя 
                    FROM position"
        Return sqlString

    End Function

    Public Function loadDefaultType() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      name 
                    FROM encoding WHERE kod=0"
        Return sqlString

    End Function

    Public Function loadListWorkerType() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      name 
                    FROM encoding"
        Return sqlString

    End Function

    Public Function loadWorker() As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      worker.in_list,
                      worker.name AS Имя,
                      worker.name_full AS Полное,
                      worker.name_pad AS Склонение,
                      position.name AS Должность,
                      encoding.name AS type,
                      worker.kod
                    FROM worker
                      LEFT JOIN position
                        ON worker.position = position.kod
                      LEFT JOIN encoding 
                        ON worker.type = encoding.kod
                      WHERE worker.name<>''"
        Return sqlString

    End Function

    Public Function selectModulInProg(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      COUNT(progs_mods_hours.kod_modul) AS expr1
                    FROM progs_mods_hours
                      INNER JOIN program
                        ON progs_mods_hours.kod_prog = program.kod
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
    Public Function updateModulnumber(listData As List(Of List(Of String)), kod_program As Int16) As String

        Dim sqlString As String = ""
        sqlString = "ROLLBACK;
                    START TRANSACTION;
                    
                    UPDATE progs_mods_hours
                    SET modul_number = 0
                    WHERE  kod_modul=" + listData(0)(1) + "
                    AND kod_prog = " + Convert.ToString(kod_program) + ";

                    UPDATE progs_mods_hours
                    SET modul_number = " + listData(0)(0) + "
                    WHERE  kod_modul=" + listData(1)(1) + "
                    AND kod_prog = " + Convert.ToString(kod_program) + ";

                    UPDATE progs_mods_hours
                    SET modul_number = " + listData(1)(0) + "
                    WHERE  kod_modul=" + listData(0)(1) + "
                    AND kod_prog = " + Convert.ToString(kod_program) + ";

                    COMMIT;"

        Return sqlString

    End Function
    Public Function selectNumberModulTop(kod_program As Int16, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT 
                    tbl.m_number,
                    tb2.kod_modul
                    FROM 
                    (
                    SELECT
                    MAX(progs_mods_hours.modul_number) AS m_number
                    FROM progs_mods_hours
                    WHERE progs_mods_hours.kod_prog = " + Convert.ToString(kod_program) + "
                    And modul_number < (SELECT progs_mods_hours.modul_number FROM progs_mods_hours 
                    INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_program) + ") LIMIT 1) AS tbl
                    INNER JOIN 
                    (SELECT kod_modul,modul_number FROM progs_mods_hours WHERE kod_prog= " + Convert.ToString(kod_program) + ") AS tb2
                    ON tbl.m_number=tb2.modul_number
                    UNION ALL 
                    SELECT progs_mods_hours.modul_number,
                    progs_mods_hours.kod_modul
                    FROM progs_mods_hours
                    INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_program)
        Return sqlString

    End Function

    Public Function selectNumberModulButtom(kod_program As Int16, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                    modul_number,
                    kod_modul
                    FROM 
                    progs_mods_hours
                    WHERE
                    kod_prog = " + Convert.ToString(kod_program) + " AND
                    modul_number= 
                    (
                    SELECT
                    MIN(progs_mods_hours.modul_number)
                    FROM progs_mods_hours
                    WHERE progs_mods_hours.kod_prog = " + Convert.ToString(kod_program) + "
                    And modul_number > (SELECT progs_mods_hours.modul_number FROM progs_mods_hours INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_program) + " LIMIT 1) LIMIT 1)
                    UNION ALL 
                    SELECT progs_mods_hours.modul_number,
                    progs_mods_hours.kod_modul
                    FROM progs_mods_hours
                    INNER JOIN
                    moduls ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE moduls.kod=" + kod_modul + " AND progs_mods_hours.kod_prog = " + Convert.ToString(kod_program)
        Return sqlString

    End Function

    Public Function insertModulIntoProg(kod_program As String, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = "INSERT IGNORE INTO progs_mods_hours (kod_prog,kod_modul,hours,modul_number)
                    SELECT " + kod_program + "
                    ," + kod_modul + ",
                    (SELECT hours FROM moduls WHERE kod=" + kod_modul + "),
                    (SELECT IFNULL(MAX(modul_number),0)+1 FROM progs_mods_hours WHERE kod_prog=" + kod_program + ")"
        Return sqlString

    End Function

    Public Function deleteModul_prog(kod As String, kod_prog As String) As String

        Dim sqlString As String = ""
        sqlString = "DELETE FROM progs_mods_hours WHERE kod_prog=" + kod_prog + " AND kod_modul=" + kod
        Return sqlString

    End Function
    Public Function deleteProgram(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "DELETE FROM progs_mods_hours WHERE kod_prog=" + kod + ";DELETE FROM program WHERE kod=" + kod + ";UPDATE `group` SET kod_program = NULL WHERE kod_program=" + kod
        Return sqlString

    End Function
    Public Function updateModulHours(hours As String, kod As String, kod_prog As String) As String

        Dim sqlString As String = ""
        sqlString = "UPDATE progs_mods_hours SET hours=" + hours + " WHERE kod_modul=" + kod + " AND kod_prog=" + kod_prog
        Return sqlString

    End Function

    Public Function updateProgram(program As String, kod As String) As String

        Dim sqlString As String = ""
        sqlString = "UPDATE program SET name='" + program + "' WHERE kod=" + kod
        Return sqlString

    End Function

    Public Function loadLastKodProgram(program As String, ur_kvalif As String) As String

        Dim sqlString As String = ""
        sqlString = " SELECT" +
                    "     MAX(kod)" +
                    "         FROM" +
                    "         program" +
                    "         WHERE name ='" + program + "' AND skill_level=" +
                    "   (SELECT kod FROM skill_level WHERE name='" + ur_kvalif + "' LIMIT 1)"
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

    Public Function loadLastKodModulInProgram(kod_program As String, kod_modul As String) As String

        Dim sqlString As String = ""
        sqlString = " SELECT" +
                    "     kod" +
                    "         FROM" +
                    "             progs_mods_hours" +
                    " WHERE kod_prog=" + kod_program + " AND kod_modul=" + kod_modul
        Return sqlString

    End Function

    Public Function addProgram(program As String, ur_kvalif As String) As String

        Dim sqlString As String = ""
        sqlString = "INSERT IGNORE INTO program (skill_level, name, kod)
                      SELECT
                        skill_level.kod,
                        '" + program + "',
                        (SELECT
                            MAX(program.kod)+1 AS expr1
                          FROM program) AS expr1
                      FROM skill_level
                      WHERE skill_level.name = '" + ur_kvalif + "'"
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
    Public Function update_checkStudentsInGroup(snils As String)

        sqlString = "Select
                     COUNT(kod)
                     FROM
                     group_list
                     WHERE students=" + snils
        Return sqlString

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
    Public Function update_updateStudentsInGroup(values_element_first As String, values_element_second As String, snils As String, kodGroup As Int64) As String


        sqlString = "UPDATE group_list
                    SET source_financing = (SELECT
                        kod
                      FROM fin_source
                      WHERE name = '" + values_element_first + "'), organization = (SELECT
                        kod
                      FROM napr_organization
                      WHERE name = '" + values_element_second + "')
                    WHERE students = " + Convert.ToString(snils) + "
                    AND kod =" + Convert.ToString(kodGroup)
        Return sqlString

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

        queryString = "INSERT INTO " + name_table + " (" + db_element_first + "," + db_element_second + ",skill_level)
                       VALUES ('" + values_element_first + "',(SELECT kod FROM number_hours WHERE name=" + values_element_second + " LIMIT 1)
                        ,(SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1));
                       
                        INSERT INTO progs_type_hours 
                        SELECT *
                        FROM(
                            SELECT kod,1,0 FROM program 
                              WHERE program.name = '" + values_element_first + "' 
                              AND program.skill_level = 
                                (SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1) 
                              AND program.kod NOT IN (SELECT kod_prog FROM progs_type_hours)
                            LIMIT 1
                            ) AS tbl
                                UNION ALL
                           (SELECT kod,2,0 FROM program 
                            WHERE program.name = '" + values_element_first + "' 
                            AND program.skill_level = 
                                (SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1) 
                            AND program.kod NOT IN (SELECT kod_prog FROM progs_type_hours)
                           LIMIT 1)
                                UNION ALL
                           (SELECT kod,3,0 FROM program 
                            WHERE program.name = '" + values_element_first + "' 
                            AND program.skill_level = 
                                (SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1) 
                            AND program.kod NOT IN (SELECT kod_prog FROM progs_type_hours)
                           LIMIT 1)
                                UNION ALL
                           (SELECT kod,4,0 FROM program 
                            WHERE program.name = '" + values_element_first + "' 
                            AND program.skill_level = 
                                (SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1) 
                            AND program.kod NOT IN (SELECT kod_prog FROM progs_type_hours)
                           LIMIT 1)
                                UNION ALL
                           (SELECT kod,5,0 FROM program 
                            WHERE program.name = '" + values_element_first + "' 
                            AND program.skill_level = 
                                (SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1) 
                            AND program.kod NOT IN (SELECT kod_prog FROM progs_type_hours)
                           LIMIT 1)
                                UNION ALL
                           (SELECT kod,6,0 FROM program 
                            WHERE program.name = '" + values_element_first + "' 
                            AND program.skill_level = 
                                (SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1) 
                            AND program.kod NOT IN (SELECT kod_prog FROM progs_type_hours)
                           LIMIT 1)"

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
                           (SELECT kod FROM number_hours WHERE name=" + values_element_second + " LIMIT 1) AND skill_level = 
                           (SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1)"

        Return queryString

    End Function

    Public Function update_prog_update_query(name_table As String, db_element_first As String, values_element_first As String, db_element_second As String, values_element_second As String, kod As Int64) As String

        Dim queryString As String = ""

        queryString = "UPDATE " + name_table + " Set " + db_element_first + "='" + values_element_first + "'," + db_element_second + "=
                        (SELECT kod FROM number_hours WHERE name=" + values_element_second + " LIMIT 1) WHERE kod=" + Convert.ToString(kod)

        Return queryString

    End Function

    Public Function update_prog_load_kod_query(name_table As String, db_element_first As String, values_element_first As String, name_prog As String) As String

        Dim queryString As String

        queryString = "SELECT
                            IFNULL(MAX(kod),-1)
                           FROM 
                            " + name_table + "
                           WHERE " + db_element_first + "='" + values_element_first + "' 
                           AND skill_level=(SELECT kod FROM skill_level WHERE name = '" + name_prog + "' LIMIT 1)"

        Return queryString

    End Function

    Public Function programs__checkKodGrouppBusy(remove_kod As Int64) As String

        Dim queryString As String

        queryString = "SELECT COUNT(kod_program) FROM `group` WHERE kod_program=" + Convert.ToString(remove_kod)

        Return queryString

    End Function

    Public Function update_delete_query(program_on As Boolean, name_table As String, name_program As String, remove_kod As Int64) As String

        Dim queryString As String = ""

        If program_on Then

            queryString = "DELETE FROM progs_type_hours WHERE kod_prog=" + Convert.ToString(remove_kod) + ";
                           DELETE FROM progs_mods_hours WHERE kod_prog=" + Convert.ToString(remove_kod) + ";
                           DELETE FROM " + name_table + " WHERE kod=" + Convert.ToString(remove_kod) + " 
                           AND skill_level = (SELECT kod FROM skill_level WHERE name = '" + name_program + "' LIMIT 1);"

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
                          INNER JOIN program
                            ON progs_type_hours.kod_prog = program.kod
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
                        FROM number_hours
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
                     INNER JOIN program
                     ON progs_mods_hours.kod_prog = program.kod
                     INNER JOIN moduls
                     ON progs_mods_hours.kod_modul = moduls.kod
                     WHERE program.kod =" + kod + "
                     ORDER BY modul_number"
        Return sqlString

    End Function

    Public Function load_sum_hours(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                     SUM(progs_mods_hours.hours) as Часы
                     FROM progs_mods_hours
                     INNER JOIN program
                     ON progs_mods_hours.kod_prog = program.kod
                     INNER JOIN moduls
                     ON progs_mods_hours.kod_modul = moduls.kod
                     WHERE program.kod =" + kod + "
                     GROUP BY program.kod"
        Return sqlString

    End Function

    Public Function program__loadPrograms(uroven_cval As String) As String

        Dim sqlString As String = ""

        sqlString = "SELECT
                      program.name AS Наименование,
                      number_hours.name AS Часы,
                      program.kod,
                      program.date AS 'дата создания'
                    FROM program
                      INNER JOIN skill_level
                        ON program.skill_level = skill_level.kod
                      INNER JOIN number_hours
                        ON program.hours = number_hours.kod
                    WHERE skill_level.name = '" + uroven_cval + "' ORDER BY program.name"
        Return sqlString

    End Function
    Public Function loadUrovenKvalifikacii() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM skill_level WHERE visible=1"
        Return sqlString

    End Function

    Public Function loadFormEducation() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM form_education"
        Return sqlString

    End Function

    Public Function loadSpeciality() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM speciality ORDER BY name"
        Return sqlString

    End Function

    Public Function loadKolChasov() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM number_hours ORDER BY kod"
        Return sqlString

    End Function

    Public Function loadKurator() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN encoding ON worker.type = encoding.kod
                     WHERE encoding.name = 'сотрудник' AND worker.in_list=1 ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function loadDirector() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN encoding ON worker.type = encoding.kod
                     WHERE encoding.name = 'директор' OR encoding.name = 'замдир' AND worker.in_list=1 ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function slushatelFio(groupp As String) As String

        Dim sqlString As String = ""
        sqlString = "Select 
                     CONCAT(students.Фамилия,' ',students.Имя,' ',IFNULL(students.Отчество,' ')) 
                     FROM group_list 
                     INNER JOIN students ON group_list.students = students.Снилс 
                     WHERE group_list.Kod = " & MainForm.orderIdGroup & " 
                     ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function load_list_prepod() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN 
                     encoding 
                     ON 
                     worker.type = encoding.kod
                     WHERE (encoding.name = 'сотрудник' OR encoding.name = 'преподаватель') AND worker.in_list=1  ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function load_ruk_staj() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN 
                     encoding 
                     ON 
                     worker.type = encoding.kod
                     WHERE encoding.name = 'сотрудник' AND worker.in_list=1  ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function load_komissiya() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN 
                     encoding 
                     ON 
                     worker.type = encoding.kod
                     WHERE (encoding.name = 'сотрудник' OR encoding.name = 'замдир') AND worker.in_list=1  ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function load_soglasovano() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN 
                     encoding 
                     ON 
                     worker.type = encoding.kod
                     WHERE (encoding.name = 'согласование' OR encoding.name = 'замдир') AND worker.in_list=1  ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function load_ispolnitel() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN 
                     encoding 
                     ON 
                     worker.type = encoding.kod
                     WHERE encoding.name = 'сотрудник' AND worker.in_list=1  ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function load_proeсt_vnosit() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN 
                     encoding 
                     ON 
                     worker.type = encoding.kod
                     WHERE encoding.name = 'сотрудник' AND worker.in_list=1  ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function loadOtv_attestat() As String

        Dim sqlString As String = ""
        sqlString = "SELECT worker.name FROM worker
                     INNER JOIN 
                     encoding 
                     ON 
                     worker.type = encoding.kod
                     WHERE encoding.name = 'сотрудник' AND worker.in_list=1  ORDER BY worker.name"
        Return sqlString

    End Function

    Public Function loadDirectorPosition() As String

        Dim sqlString As String = ""
        sqlString = "SELECT position.name FROM position
                     INNER JOIN encoding ON position.type = encoding.kod
                     WHERE encoding.name = 'директор' ORDER BY position.name"
        Return sqlString

    End Function

    Public Function loadPositions() As String

        Dim sqlString As String = ""
        sqlString = "SELECT position.name FROM position"
        Return sqlString

    End Function

    Public Function loadFinansing() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM financing ORDER BY name"
        Return sqlString

    End Function

    Public Function loadQualification() As String

        Dim sqlString As String = ""
        sqlString = "SELECT name FROM qualification ORDER BY name"
        Return sqlString

    End Function

    Public Function loadNumberHours(kod As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                      number_hours.name
                    FROM program
                      INNER JOIN number_hours
                        ON program.hours = number_hours.kod
                    WHERE program.kod = " + kod
        Return sqlString

    End Function

    Public Function loadKogProgram(ur_kval As String, name_prog As String) As String

        Dim sqlString As String = ""
        sqlString = "SELECT
                    program.kod,
                    IFNULL(kc.name, 0)
                    FROM(
                    SELECT
                      prog.name,
                      MAX(date) AS date
                    FROM (SELECT
                        skill_level.kod
                      FROM skill_level"

        If Not ur_kval = "" Then
            sqlString += " WHERE skill_level.name = '" + ur_kval + "'"
        End If

        sqlString += " ) AS tbl1
                      INNER JOIN (SELECT * FROM program WHERE program.name='" + name_prog + "') AS prog
                        ON tbl1.kod = prog.skill_level
                        GROUP BY prog.name
                        ) AS tbl
                    INNER JOIN program
                    ON tbl.name=program.name AND
                        tbl.date=program.date
                    LEFT JOIN number_hours kc 
                    ON program.hours = kc.kod
                    ORDER BY program.name"
        Return sqlString

    End Function

End Class
