
Imports MySql.Data.Authentication
Imports WindowsApp2.Slushatel

Module QueryString

    Dim sqlString As String

    Public Function studentsList__loadStudentsList(columnSort As String, arg As String) As String

        sqlString = "SELECT Код, Снилс, Фамилия, Имя, Отчество FROM students ORDER BY " & columnSort & arg

        Return sqlString

    End Function

    Public Function formOrder__loadStudentsList(kodGroup As String) As String

        sqlString = "SELECT 
                    CONCAT(students.Фамилия,' ',students.Имя,' ',IFNULL(students.Отчество,' ')) 
                    FROM group_list 
                    INNER JOIN students 
                    ON group_list.students = students.Снилс 
                    WHERE group_list.Kod = " & kodGroup & " 
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function formOrder__loadNameDolj(kod As String) As String

        sqlString = "SELECT name FROM doljnost WHERE kod=" + kod

        Return sqlString

    End Function

    Public Function formOrder__loadKodDolj(name As String) As String

        sqlString = "SELECT doljnost FROM sotrudnik WHERE name='" + name + "' LIMIT 1"

        Return sqlString

    End Function

    Public Function studentList__studentListInGroup(kodGroup As String) As String

        sqlString = "SELECT 
                    students.Снилс,
                    students.Фамилия,
                    students.Имя,
                    IFNULL(students.Отчество,' '),
                    students.ДатаРождения 
                    FROM group_list 
                    INNER JOIN students 
                    ON group_list.students = students.Снилс 
                    WHERE group_list.Kod = " & kodGroup & " 
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function dopusk_loadListStudents(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                      programm.name,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас,
                      ИАТестирование,
                      ИАПрактическиеНавыки,
                      ИАИтог,
                      НомерПротоколаИА
                    FROM (group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс)
                      INNER JOIN `group`
                        ON group_list.kod = `group`.Код
                      LEFT JOIN programm
                        ON `group`.kod_programm=programm.kod
                    WHERE `group`.Код=" & kodGroup & "
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function loadListStudents(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                      programm.name,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас
                    FROM (group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс)
                      INNER JOIN `group`
                        ON group_list.kod = `group`.Код
                      LEFT JOIN programm
                        ON kod_programm=programm.kod
                    WHERE `group`.Код=" & kodGroup & "
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function expulsion__loadProgramm(kodGroup As String) As String

        sqlString = "SELECT
                      programm.name
                    FROM `group`
                      INNER JOIN programm
                    ON `group`.kod_programm = programm.kod
                    WHERE `group`.Код=" & kodGroup

        Return sqlString

    End Function

    Public Function poPpEnd__loadShortListStudents(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' '))
                    FROM group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                    WHERE group_list.kod =" & kodGroup & " ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function pkEnd__loadShortListStudents(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                      'зачтено'
                    FROM group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                    WHERE group_list.kod =" & kodGroup & " ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function pkEnd__insertNumbers(group As Object, type As String, kodGroup As String) As List(Of String)

        Dim counter As Integer
        Dim queryString As String
        Dim listSQLString As New List(Of String)

        counter = 0

        While counter <= UBound(group, 2)

            If type = "Удостоверение" Then
                queryString = "UPDATE group_list SET НомерУд = " & group(4, 0) + counter & " , РегНомерУд= " & group(5, 0) + counter & ", НомерСвид=0, РегНомерСвид=0, НомерДиплома=0, РегНомерДиплома=0  WHERE Kod = " & kodGroup & " AND students = " & Chr(39) & group(3, counter) & Chr(39)
            ElseIf type = "Свидетельство" Then
                queryString = "UPDATE group_list SET НомерУд = 0 , РегНомерУд= 0, НомерСвид = " & group(4, 0) + counter & " , РегНомерСвид= " & group(5, 0) + counter & ", НомерДиплома=0, РегНомерДиплома=0 WHERE Kod = " & kodGroup & " AND students = " & Chr(39) & group(3, counter) & Chr(39)
            ElseIf type = "Диплом" Then
                queryString = "UPDATE group_list SET НомерУд = 0 , РегНомерУд= 0,НомерСвид=0, РегНомерСвид=0, НомерДиплома = " & group(4, 0) + counter & " , РегНомерДиплома= " & group(5, 0) + counter & " WHERE Kod = " & kodGroup & " AND students = " & Chr(39) & group(3, counter) & Chr(39)
            End If
            listSQLString.Add(queryString)
            counter = counter + 1
        End While

        Return listSQLString

    End Function
    Public Function pkEndUd__loadListStudents(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(students.Фамилия ,' ', students.Имя ,' ', IFNULL(students.Отчество,' ')),
                      students.Фамилия,
                      CONCAT(students.Имя , ' ' , IFNULL(students.Отчество, ' ')),
                      students.Снилс,
                      `group`.НомерУд,
                      `group`.РегНомерУд,
                      `group`.ОсновнойДокумент,
                      programm.name,
                      ДатаВыдачиУд,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас
                    FROM `group`
                      INNER JOIN group_list
                        ON group_list.kod = `group`.Код
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                      LEFT JOIN programm
                      ON `group`.kod_programm = programm.kod
                    WHERE `group`.Код = " & kodGroup & " ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function poSvid__loadListSvid(kodGroup As String) As String

        sqlString = "SELECT
                      students.Фамилия,
                      students.Имя,
                      IFNULL(students.Отчество, ' '),
                      students.ДатаРождения,
                      ОценкаМодуль1,
                      ОценкаМодуль2,
                      ОценкаМодуль3,
                      ОценкаМодуль4,
                      ОценкаМодуль5,
                      ОценкаМодуль6,
                      ОценкаМодуль7,
                      ОценкаМодуль8,
                      ОценкаМодуль9,
                      ОценкаМодуль10,
                      ИАПрактическиеНавыки,
                      ИАИтог,
                      group_list.РегНомерСвид,
                      `group`.ДатаВыдачиСвид,
                      `group`.ДатаКЗ,
                      НаимДОО,
                      Квалификация,
                      КолЧас,
                      ДатаНЗ,
                      programm.name
                    FROM (group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс)
                      INNER JOIN `group`
                        ON group_list.kod = `group`.Код
                      LEFT JOIN programm 
                        ON programm.kod=kod_programm
                    WHERE `group`.Код = " & kodGroup & " ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function accountingBook__loadListSvidFRDO(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT  
                      group_list.НомерСвид,
                      ДатаВыдачиСвид,
                      group_list.РегНомерСвид,
                      programm.name,
                      students.УОбразования,
                      ФамилияДОО,
                      СерияДОО,
                      НомерДОО,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас,
                      Фамилия,
                      Имя,
                      Отчество,
                      ДатаРождения,
                      Пол,
                      Снилс,
                      ФормаО,
                      ИФин,
                      Гражданство                    
                    FROM (
                    group_list 
                    INNER JOIN students 
                    ON group_list.students = students.Снилс) 
                    INNER JOIN `group` 
                    ON group_list.Kod = `group`.Код 
                    LEFT JOIN programm
                    ON kod_programm=programm.kod
                    WHERE  
                    `group`.ОсновнойДокумент= 'Свидетельство' 
                    AND NOT ISNULL(group_list.РегНомерСвид) 
                    AND group_list.РегНомерСвид<>0 
                    AND ДатаВыдачиСвид BETWEEN '" & dateStart & "' AND  '" & dateEnd & " ' 
                    AND ОсновнойДокумент= 'Свидетельство' 
                    ORDER BY group_list.РегНомерСвид"

        Return sqlString

    End Function

    Public Function accountingBook__loadListDipFRDO(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT 
                      group_list.НомерДиплома,
                      ДатаВыдачиДиплома,
                      group_list.РегНомерДиплома,
                      programm.name,
                      students.УОбразования,
                      ФамилияДОО,
                      СерияДОО,
                      НомерДОО,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас,
                      Фамилия,
                      Имя,
                      Отчество,
                      ДатаРождения,
                      Пол,
                      Снилс,
                      ФормаО,
                      ИФин,
                      Гражданство
                    FROM (
                    group_list 
                    INNER JOIN students 
                    ON group_list.students = students.Снилс) 
                    INNER JOIN `group` 
                    ON group_list.Kod = `group`.Код 
                    LEFT JOIN programm
                    ON kod_programm=programm.kod
                    WHERE 
                    `group`.ОсновнойДокумент= 'Диплом'  
                    AND NOT ISNULL(group_list.РегНомерДиплома) 
                    AND group_list.РегНомерДиплома<>0 
                    AND ДатаВыдачиДиплома BETWEEN '" & dateStart & "' and  '" & dateEnd & " ' 
                    AND ОсновнойДокумент= 'Диплом' 
                    ORDER BY group_list.РегНомерДиплома"

        Return sqlString

    End Function

    Public Function accountingBook__loadListUdFRDO(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT 
                      group_list.НомерУд,
                      ДатаВыдачиУд,
                      group_list.РегНомерУд,
                      programm.name,
                      students.УОбразования,
                      ФамилияДОО,
                      СерияДОО,
                      НомерДОО,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас,
                      Фамилия,
                      Имя,
                      Отчество,
                      ДатаРождения,
                      Пол,
                      Снилс,
                      ФормаО,
                      ИФин,
                      Гражданство                    
                    FROM (
                    group_list 
                    INNER JOIN 
                    students 
                    ON group_list.students = students.Снилс)
                    INNER JOIN `group` 
                    ON group_list.Kod = `group`.Код 
                    LEFT JOIN programm
                    ON kod_programm=programm.kod
                        WHERE `group`.ОсновнойДокумент= 'Удостоверение'   
                    AND NOT ISNULL(group_list.РегНомерУд) AND group_list.РегНомерУд<>0 
                    AND ДатаВыдачиУд BETWEEN '" & dateStart & "' and  '" & dateEnd & " ' 
                    ORDER BY group_list.РегНомерУд"

        Return sqlString

    End Function

    Public Function accountingBook__loadListSvid(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT  
                    group_list.РегНомерСвид, group_list.НомерСвид,`group`.Номер, Фамилия,Имя, Отчество, programm.name, КолЧас, ДатаКЗ, ДатаВыдачиСвид 
                    FROM (group_list INNER JOIN students On group_list.students = students.Снилс) 
                    INNER JOIN `group` 
                        ON group_list.Kod = `group`.Код
                    LEFT JOIN programm
                        ON kod_programm=programm.kod
                    WHERE  `group`.ОсновнойДокумент= 'Свидетельство' AND NOT ISNULL(group_list.РегНомерСвид) AND group_list.РегНомерСвид<>0 AND ДатаВыдачиСвид BETWEEN '" & dateStart & "' and  '" & dateEnd & " '  and ОсновнойДокумент= 'Свидетельство' ORDER BY group_list.РегНомерСвид"

        Return sqlString

    End Function

    Public Function accountingBook__loadListDip(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT group_list.РегНомерДиплома, group_list.НомерДиплома,`group`.Номер, Фамилия,Имя, Отчество, programm.name, КолЧас, ДатаКЗ, ДатаВыдачиДиплома 
                    FROM (group_list INNER JOIN students On group_list.students = students.Снилс) 
                    INNER JOIN `group` 
                        ON group_list.Kod = `group`.Код 
                    LEFT JOIN programm
                        ON kod_programm=programm.kod
                    WHERE `group`.ОсновнойДокумент= 'Диплом' AND NOT ISNULL(group_list.РегНомерДиплома) AND group_list.РегНомерДиплома<>0 AND group_list.РегНомерДиплома<>0 AND ДатаВыдачиДиплома BETWEEN '" & dateStart & "' and  '" & dateEnd & " '  and ОсновнойДокумент= 'Диплом' ORDER BY group_list.РегНомерДиплома"

        Return sqlString

    End Function

    Public Function accountingBook__loadListUd(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT  group_list.РегНомерУд, group_list.НомерУд,`group`.Номер, Фамилия,Имя, Отчество, programm.name, КолЧас, ДатаКЗ, ДатаВыдачиУд FROM (group_list INNER JOIN students On group_list.students = students.Снилс) INNER JOIN `group` On group_list.Kod = `group`.Код 
                     LEFT JOIN programm
                      ON kod_programm=programm.kod
                     WHERE `group`.ОсновнойДокумент= 'Удостоверение' AND NOT ISNULL(group_list.РегНомерУд) AND group_list.РегНомерУд<>0 AND ДатаВыдачиУд BETWEEN '" & dateStart & "' and  '" & dateEnd & " ' ORDER BY group_list.РегНомерУд"

        Return sqlString

    End Function

    Public Function formList__checkGroup(kodGroup As String) As String

        sqlString = "SELECT students FROM group_list WHERE Kod= " & kodGroup

        Return sqlString

    End Function

    Public Function formList__loadOtvOrSlush(kodGroup As String) As String

        sqlString = "SELECT group_list.Группа, CONCAT(students.Фамилия,' ',students.Имя,' ',IFNULL(students.Отчество,' ')) FROM group_list INNER JOIN students ON group_list.students = students.Снилс WHERE group_list.Kod = " & kodGroup & " ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function formList__loadProfLevel(nameTbl As String) As String

        sqlString = "SELECT Уровень FROM " & nameTbl & " ORDER BY Уровень"

        Return sqlString

    End Function
    Public Function formList__loadKodGroup(dateStr As String) As String

        sqlString = "SELECT * FROM `group` WHERE ДатаНЗ > '" & dateStr & "'"

        Return sqlString

    End Function

    Public Function formList__loadKodGroupPP() As String

        sqlString = "SELECT Код FROM `group` WHERE УровеньКвалификации = 'профессиональная переподготовка'"

        Return sqlString

    End Function

    Public Function formList__loadProgramms() As String

        sqlString = "SELECT name, date, kod FROM programm ORDER BY name"

        Return sqlString

    End Function

    Public Function redactorFormListGroup__loadData(groupKod As String) As String

        sqlString = "SELECT students.Снилс, students.Фамилия, students.Имя, IFNULL(students.Отчество,' '), students.ДатаРождения FROM group_list INNER JOIN students ON group_list.students = students.Снилс WHERE group_list.Kod = " & groupKod & " ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function redactorGroup__deketeGroupInGroup(gruppaNumber As String, gruppaYearNZ As String) As String

        sqlString = "DELETE FROM `group` WHERE Номер= " & Chr(39) & gruppaNumber & Chr(39) & " AND Year(ДатаНЗ)=" & gruppaYearNZ

        Return sqlString

    End Function

    Public Function redactorGroup__deleteGroupInGroupList(gruppaNumber As String, gruppaYearNZ As String) As String

        sqlString = " DELETE FROM group_list WHERE Kod = (SELECT Код FROM `group` WHERE Номер= " & Chr(39) & gruppaNumber & Chr(39) & " AND Year(ДатаНЗ)=" & gruppaYearNZ & " LIMIT 1)"

        Return sqlString

    End Function

    Public Function redactorGroup__updateGroupList(gruppaNumber As String, gruppaYearNZ As String) As String

        sqlString = " UPDATE group_list SET `group` = " & Chr(39) & gruppaNumber & Chr(39) & " WHERE gruppa_kod = (SELECT Код FROM `group` WHERE Номер= " & Chr(39) & gruppaNumber & Chr(39) & " AND Year(ДатаНЗ)=" & gruppaYearNZ & " LIMIT 1)"

        Return sqlString

    End Function

    Public Function vedomPromAtt__loadListSlush(kodGroup As String) As String

        sqlString = "SELECT CONCAT(students.Фамилия,' ',students.Имя,' ',IFNULL(students.Отчество,' ')), students.Снилс  FROM group_list INNER JOIN students ON group_list.students = students.Снилс WHERE group_list.Kod= " & kodGroup & " ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function oVedom__updateOcenki(argument As String()) As String

        sqlString = "UPDATE group_list SET ОценкаМодуль1= " & Chr(39) & argument(0) & Chr(39) & "
                    ,ОценкаМодуль2= " & Chr(39) & argument(1) & Chr(39) & "
                    ,ОценкаМодуль3= " & Chr(39) & argument(2) & Chr(39) & "
                    ,ОценкаМодуль4= " & Chr(39) & argument(3) & Chr(39) & "
                    ,ОценкаМодуль5= " & Chr(39) & argument(4) & Chr(39) & "
                    ,ОценкаМодуль6= " & Chr(39) & argument(5) & Chr(39) & "
                    ,ОценкаМодуль7= " & Chr(39) & argument(6) & Chr(39) & "
                    ,ОценкаМодуль8= " & Chr(39) & argument(7) & Chr(39) & "
                    ,ОценкаМодуль9= " & Chr(39) & argument(8) & Chr(39) & "
                    ,ОценкаМодуль10= " & Chr(39) & argument(9) & Chr(39) & "
                    WHERE group_list.students = " & Chr(39) & argument(10) & Chr(39) & "
                    AND group_list.Kod = " & argument(11)

        Return sqlString

    End Function

    Public Function oVedom__checkStudent(kodGroup As String, snils As String) As String

        sqlString = "SELECT group_list.students FROM group_list WHERE group_list.students = " & Chr(39) & snils & Chr(39) & " AND group_list.Kod = " & kodGroup

        Return sqlString

    End Function

    Public Function ia__updateResult(kodGroup As String, snils As String, testVal As String, practicVal As String, resultVal As String) As String

        sqlString = "UPDATE group_list SET ИАТестирование= " & Chr(39) & testVal & ",ИАПрактическиеНавыки= " & Chr(39) & practicVal & Chr(39) & ",ИАИтог= " & Chr(39) & resultVal & Chr(39) & " WHERE group_list.students = " & Chr(39) & snils & Chr(39) & "  AND group_list.Kod = " & kodGroup

        Return sqlString

    End Function

    Public Function prilDiplomLoadData(kodGroup As String) As String

        sqlString = "SELECT
                      students.Фамилия,
                      students.Имя,
                      IFNULL(students.Отчество, ' '),
                      students.ДатаРождения,
                      ОценкаМодуль1,
                      ОценкаМодуль2,
                      ОценкаМодуль3,
                      ОценкаМодуль4,
                      ОценкаМодуль5,
                      ОценкаМодуль6,
                      ОценкаМодуль7,
                      ОценкаМодуль8,
                      ОценкаМодуль9,
                      ОценкаМодуль10,
                      ИАПрактическиеНавыки,
                      ИАИтог,
                      group_list.НомерДиплома,
                      `group`.ДатаВыдачиДиплома,
                      `group`.ДатаКЗ,
                      НаимДОО,
                      Квалификация,
                      КолЧас,
                      ДатаНЗ,
                      programm.name,
                      `group`.Спец
                    FROM (group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                      INNER JOIN `group`
                        ON group_list.kod = `group`.Код
                      LEFT JOIN programm 
                      ON `group`.kod_programm = programm.kod
                        )
                    WHERE `group`.Код =" & kodGroup & " ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function blanki_loadSlush(kodGroup As String) As String

        sqlString = "SELECT students FROM group_list WHERE Kod =" & kodGroup

        Return sqlString

    End Function

    Public Function blanki_loadSpesh(kodGroup As String) As String

        sqlString = "SELECT Спец FROM `group` WHERE Код =" & kodGroup

        Return sqlString

    End Function

    Public Function blanki_loadProgAndDateTFromGroup(kodGroup As String) As String

        sqlString = "SELECT
                      programm.name,
                      `group`.ДатаНЗ  
                    FROM `group`
                      INNER JOIN programm
                        ON `group`.kod_programm = programm.kod 
                    WHERE Код =" & kodGroup

        Return sqlString

    End Function

    Public Function blanki_loadProgram(kodGroup) As String

        sqlString = "SELECT
                      programm.name
                    FROM `group`
                      INNER JOIN programm
                        ON `group`.kod_programm = programm.kod 
                    WHERE Код =" & kodGroup

        Return sqlString

    End Function

    Public Function updateNumbersInGroup(number As String, regNumber As String, kodGroup As String, snils As String) As String

        sqlString = "UPDATE group_list Set НомерУд = " & number & " , РегНомерУд= " & regNumber & " WHERE Kod = " & kodGroup & " And students = " & Chr(39) & snils & Chr(39)

        Return sqlString

    End Function

    Public Function checkGroup(kodGroup As String) As String

        sqlString = "Select Код FROM `group` WHERE Код = " & kodGroup

        Return sqlString

    End Function
    Public Function pednagrExtended__loadListWorkerData(DateStart As String, DateEnd As String, kodWorker As String) As String

        sqlString = "SELECT
                      groupTbl.Номер,
                      SUM(IFNULL(lectures,0)) AS lectures,
                      SUM(IFNULL(practical,0)) AS practical,
                      SUM(IFNULL(stimulating,0)) AS stimulating,
                      SUM(IFNULL(consultation,0)) AS consultation,
                      SUM(IFNULL(PA,0)) AS PA,
                      SUM(IFNULL(IA,0)) AS IA,
                      SUM(IFNULL(IA,0))+SUM(IFNULL(lectures,0)) +SUM(IFNULL(practical,0))+SUM(IFNULL(stimulating,0))+SUM(IFNULL(consultation,0))+SUM(IFNULL(PA,0))
                    FROM pednagruzka
                      INNER JOIN (SELECT
                          `group`.Код,
                          Номер
                        FROM `group`
                        WHERE `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "') groupTbl
                        ON pednagruzka.kod = groupTbl.Код
                      INNER JOIN sotrudnik
                        ON pednagruzka.worker = sotrudnik.kod
                      WHERE sotrudnik.kod=" + kodWorker + "
                      GROUP BY groupTbl.Код
                      ORDER BY groupTbl.Номер"

        Return sqlString

    End Function

    Public Function pednagrExtended__loadListWorker(DateStart As String, DateEnd As String) As String

        sqlString = "SELECT
                      sotrudnik.kod,
                      name
                    FROM pednagruzka
                      INNER JOIN (SELECT
                          `group`.Код,
                          Номер
                        FROM `group`
                        WHERE `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "') groupTbl
                        ON pednagruzka.kod = groupTbl.Код
                      INNER JOIN sotrudnik
                        ON pednagruzka.worker = sotrudnik.kod
                      GROUP BY worker"

        Return sqlString

    End Function

    Public Function pednagruzkaloadOtchet(DateStart As String, DateEnd As String) As String

        sqlString = " SELECT
                      ПреподавательСписокВнебюджет,
                      СуммаЧасовБ,
                      СуммаЧасовВБ
                    FROM (SELECT
                        sotrudnik.name AS ПреподавательСписокВнебюджет,
                        IFNULL(СуммаЧасовВБ,0) AS СуммаЧасовВБ
                      FROM sotrudnik
                        LEFT JOIN (SELECT
                            pednagruzka.worker AS Преподаватель1,
                            SUM(IFNULL(pednagruzka.lectures,0)
                              + IFNULL(pednagruzka.practical,0)
                              + IFNULL(pednagruzka.stimulating,0)
                              + IFNULL(pednagruzka.consultation,0)
                              + IFNULL(PA,0)
                              + IFNULL(IA,0)
                            ) AS СуммаЧасовВБ
                          FROM pednagruzka
                            INNER JOIN `group`
                              ON `group`.Код = pednagruzka.kod
                          WHERE `group`.Финансирование = 'внебюджет'
                          AND `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "'
                          GROUP BY pednagruzka.worker) AS Внебюджет
                          ON Внебюджет.Преподаватель1 = sotrudnik.kod) AS СводВнебюджет
                      INNER JOIN (SELECT
                          sotrudnik.name AS ПреподавательСписокБюджет,
                          IFNULL(СуммаЧасовБ,0) AS СуммаЧасовБ
                        FROM sotrudnik
                          LEFT JOIN (SELECT
                              pednagruzka.worker AS Преподаватель1,
                              SUM(IFNULL(pednagruzka.lectures,0)
                                + IFNULL(pednagruzka.practical,0)
                                + IFNULL(pednagruzka.stimulating,0)
                                + IFNULL(pednagruzka.consultation,0)
                                + IFNULL(PA,0)
                                + IFNULL(IA,0)
                            ) AS СуммаЧасовБ
                            FROM pednagruzka
                              INNER JOIN `group`
                                ON `group`.Код = pednagruzka.kod
                            WHERE `group`.Финансирование = 'бюджет'
                            AND `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "'
                            GROUP BY pednagruzka.worker) AS Бюджет
                            ON Бюджет.Преподаватель1 = sotrudnik.kod) AS СводБюджет
                        ON СводБюджет.ПреподавательСписокБюджет = СводВнебюджет.ПреподавательСписокВнебюджет
                    WHERE СуммаЧасовБ > 0
                    OR СуммаЧасовВБ > 0"

        Return sqlString

    End Function

    Public Sub datagridInsertRowIntoDB(dataGridTbl As DataGridView, nameTbl As String, massValues As Object, massTypes As Object, numberFirstColumn As Integer, numberLastColumn As Integer)

        Dim fio, tranzitMass
        Dim sqlStringSecondPart As String
        Dim countRows, countQueryStr As Integer

        countRows = dataGridTbl.Rows.Count
        countRows = UBound(massTypes, 2)

        If numberLastColumn > dataGridTbl.Columns.Count Then
            предупреждение.текст.Text = "Неверно указан номер последнего столбца таблицы"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        If Not UBound(massTypes, 2) = numberLastColumn - numberFirstColumn Then
            предупреждение.текст.Text = "Неверно указаны имена столбцов"
            предупреждение.ShowDialog()
            Exit Sub
        End If

        InsertIntoDataBase.argumentClear()
        InsertIntoDataBase.argument.nameTable = nameTbl
        InsertIntoDataBase.argument.firstName = massValues(0)
        InsertIntoDataBase.argument.firstValue = Convert.ToString(massValues(1))

        InsertIntoDataBase.deleteFromDB_NumberArg()

        fio = dataGridTbl.Rows.Count - 1
        ReDim tranzitMass(dataGridTbl.Rows.Count - 1)

        countQueryStr = 0

        For i = 0 To dataGridTbl.Rows.Count - 1

            sqlString = ""
            sqlStringSecondPart = ""
            countQueryStr += 1

            If IsNothing(dataGridTbl.Rows(i).Cells(0).Value) Then

                countQueryStr -= 1

                Continue For

            End If

            sqlString = "INSERT INTO " & nameTbl & " ( " & massValues(0) & " , "

            For счетчикСтолбцов = 0 To UBound(massTypes, 2)

                sqlString = sqlString & massTypes(0, счетчикСтолбцов) & " , "

                If massTypes(1, счетчикСтолбцов) = "String" Then

                    If massTypes(0, счетчикСтолбцов) = "worker" Then

                        sqlStringSecondPart += "(SELECT kod FROM sotrudnik WHERE sotrudnik.name=" + Chr(39) & dataGridTbl.Rows(i).Cells(numberFirstColumn + счетчикСтолбцов).Value & Chr(39) & " LIMIT 1 ), "

                    Else

                        sqlStringSecondPart += Chr(39) & dataGridTbl.Rows(i).Cells(numberFirstColumn + счетчикСтолбцов).Value & Chr(39) & " , "

                    End If

                Else
                    If IsNothing(dataGridTbl.Rows(i).Cells(numberFirstColumn + счетчикСтолбцов).Value) Or Trim(dataGridTbl.Rows(i).Cells(numberFirstColumn + счетчикСтолбцов).Value) = "" Then
                        sqlStringSecondPart = sqlStringSecondPart & " 0 , "
                    Else
                        sqlStringSecondPart = sqlStringSecondPart & dataGridTbl.Rows(i).Cells(numberFirstColumn + счетчикСтолбцов).Value.Replace(",", ".") & " , "
                    End If
                End If
            Next

            sqlString = Strings.Left(sqlString, Strings.Len(sqlString) - 2) & ") VALUES ( " & Chr(39) & massValues(1) & Chr(39) & " , " & Strings.Left(sqlStringSecondPart, Strings.Len(sqlStringSecondPart) - 2) & ")"

            MainForm.mySqlConnect.sendQuery(sqlString, 1)

        Next

    End Sub

    Public Function pednagruzka__loadProgramm(kodGroup As String) As String

        sqlString = "SELECT
                      'Программа' As Показатель,
                      programm.name As Значение
                    FROM `group`
                      INNER JOIN programm
                        ON `group`.kod_programm = programm.kod
                    WHERE Код= " & kodGroup + "
                    UNION ALL
                    SELECT * FROM
                    (
                    SELECT
                      type_class.name,
                      progs_type_hours.hours
                    FROM progs_type_hours
                      INNER JOIN type_class
                        ON progs_type_hours.type = type_class.kod
                      INNER JOIN `group`
                        ON progs_type_hours.kod_prog = `group`.kod_programm
                    WHERE `group`.Код =" & kodGroup + "
                    ORDER BY number
                    ) AS types"

        Return sqlString

    End Function

    Public Function pednagruzka__load(kodGroup As String) As String

        sqlString = " SELECT
                      sotrudnik.name,
                      pednagruzka.lectures,
                      pednagruzka.practical,
                      pednagruzka.stimulating,
                      pednagruzka.consultation,
                      pednagruzka.PA,
                      pednagruzka.IA
                    FROM pednagruzka
                      INNER JOIN sotrudnik
                        ON pednagruzka.worker = sotrudnik.kod
                        WHERE pednagruzka.kod= " & kodGroup & " ORDER BY sotrudnik.name"

        Return sqlString

    End Function

    Public Function SqlString__updateSlushInListSlGroupp(snils As String, prevSnils As String)

        sqlString = " UPDATE group_list SET students = " & Chr(39) & snils & Chr(39) & " WHERE students = " & Chr(39) & prevSnils & Chr(39)

        Return sqlString

    End Function

    Public Function SqlString__insertIntoListGroupp(snils As String, kodGroupp As String)

        sqlString = "INSERT INTO group_list (students, Kod) VALUES ( " & Chr(39) & snils & Chr(39) & " , " & kodGroupp & ")"

        Return sqlString

    End Function

    Public Function SqlString__insertSlush(structSlushatel As strSlushatel)

        Dim part1, part2, part3 As String

        part1 = "(Снилс, Фамилия, Имя, Отчество, ДатаРождения, Пол, УОбразования, doo_vid_dok, НаимДОО, СерияДОО, НомерДОО, ФамилияДОО, АРег, Телефон, Гражданство, ДУЛ, СерияДУЛ, НомерДУЛ, ИФин, НОрг, НомерНапрРосздрав, ДатаНапрРосздрав, Специальность, ДатаРегистрации, Почта, ДУЛКемВыдан,ДУЛДатаВыдачи ) "

        part2 = "(" & Chr(39) & structSlushatel.snils & Chr(39) & ",
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

        part3 = "," & Chr(39) & structSlushatel.источникФин & Chr(39) & "
                , (SELECT kod FROM napr_organization WHERE name=" & Chr(39) & structSlushatel.направившаяОрг & Chr(39) & "
                LIMIT 1) , " & Chr(39) & structSlushatel.номерНаправленияРосздравнадзора & Chr(39) & "
                , " & Chr(39) & structSlushatel.датаНаправленияРосздравнвдзора & Chr(39) & "
                , " & Chr(39) & structSlushatel.специальностьСлушателя & Chr(39) & "
                , " & Chr(39) & structSlushatel.датаРег & Chr(39) & "
                , " & Chr(39) & structSlushatel.Email & Chr(39) & "
                , " & Chr(39) & structSlushatel.кемВыданДУЛ & Chr(39) & ","

        If structSlushatel.датаВыдачиДУЛ = "null" Then
            part3 += "null)"
        Else part3 += Chr(39) & structSlushatel.датаВыдачиДУЛ & Chr(39) & " ) "
        End If

        sqlString = "INSERT INTO students " & part1 & "  VALUES " & part2 & part3

        Return sqlString

    End Function

    Public Function SqlString__updateSlush(structSlushatel As strSlushatel)

        Dim part1 As String, part2 As String, part3 As String, part4 As String

        part1 = "Снилс=" & Chr(39) & structSlushatel.snils & Chr(39) & ", Фамилия=" & Chr(39) & structSlushatel.фамилия & Chr(39) & ", Имя=" & Chr(39) & structSlushatel.имя & Chr(39) & ", Отчество=" & Chr(39) & structSlushatel.отчество & Chr(39) & ", ДатаРождения=" & Chr(39) & structSlushatel.датаР & Chr(39) & ", Пол=" & Chr(39) & structSlushatel.пол & Chr(39)

        part2 = ", УОбразования=" & Chr(39) & structSlushatel.уровеньОбразования & Chr(39) & ", doo_vid_dok= (SELECT kod FROM doo_vid_dok WHERE name=" & Chr(39) & structSlushatel.doo_vid_dok & Chr(39) & " LIMIT 1), НаимДОО=" & Chr(39) & structSlushatel.образование & Chr(39) & ", СерияДОО=" & Chr(39) & structSlushatel.серияДокументаООбразовании & Chr(39) & ", НомерДОО=" & Chr(39) & structSlushatel.номерДокументаООбразовании & Chr(39) & ", ФамилияДОО=" & Chr(39) & structSlushatel.фамилияВДокОбОбразовании & Chr(39)

        part3 = ",АРег=" & Chr(39) & structSlushatel.адресРегистрации & Chr(39) & ", Телефон=" & Chr(39) & structSlushatel.телефон & Chr(39) & ", Гражданство=" & Chr(39) & structSlushatel.гражданство & Chr(39) & ", ДУЛ=" & Chr(39) & structSlushatel.ДУЛ & Chr(39) & ", СерияДУЛ=" & Chr(39) & structSlushatel.серияДУЛ & Chr(39) & ", НомерДУЛ=" & Chr(39) & structSlushatel.номерДУЛ & Chr(39)

        part4 = ",ИФин=" & Chr(39) & structSlushatel.источникФин & Chr(39) & ", НОрг= (SELECT kod FROM napr_organization WHERE name=" & Chr(39) & structSlushatel.направившаяОрг & Chr(39) & " LIMIT 1), НомерНапрРосздрав=" & Chr(39) & structSlushatel.номерНаправленияРосздравнадзора & Chr(39) & ", ДатаНапрРосздрав=" & Chr(39) & structSlushatel.датаНаправленияРосздравнвдзора & Chr(39) & ", Специальность=" & Chr(39) & structSlushatel.специальностьСлушателя & Chr(39) & ", ДатаРегистрации=" & Chr(39) & structSlushatel.датаРег & Chr(39) & ", Почта=" & Chr(39) & structSlushatel.Email & Chr(39) & ", ДУЛКемВыдан=" & Chr(39) & structSlushatel.кемВыданДУЛ & Chr(39)

        If structSlushatel.датаВыдачиДУЛ = "null" Then
            part4 += ", ДУЛДатаВыдачи=null"
        Else
            part4 += ", ДУЛДатаВыдачи=" & Chr(39) & structSlushatel.датаВыдачиДУЛ & Chr(39)
        End If

        sqlString = "UPDATE students SET " & part1 & part2 & part3 & part4 & " WHERE Снилс =" & Chr(39) & structSlushatel.snils & Chr(39)

        Return sqlString

    End Function

    Public Function SqlString__loadSlushList(snils As String)

        sqlString = "SELECT * FROM " & "students" & " WHERE " & "Снилс" & " = " & Chr(39) & snils & Chr(39)

        Return sqlString

    End Function

    Public Function SqlString__deleteSlushFromGrouppList(snils As String)

        sqlString = "DELETE FROM group_list WHERE students= " & Chr(39) & snils & Chr(39)

        Return sqlString

    End Function

    Public Function SqlString__deleteSlush(snils As String)

        sqlString = "DELETE FROM students WHERE Снилс= " & Chr(39) & snils & Chr(39)

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
                        CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')) AS slush,
                        students.НОрг,
                        ИФин
                      FROM group_list
                        INNER JOIN students
                          ON group_list.students = students.Снилс
                      WHERE group_list.kod = " & kodGroup & "
                      ORDER BY students.Фамилия) AS result

                      LEFT JOIN napr_organization
                        ON result.НОрг = kod
                        ORDER BY  result.slush"

        Return sqlString

    End Function

    Public Function load_slushatel(snils As String) As String

        sqlString = ""

        sqlString = "SELECT
                      students.Код,
                      students.Снилс,
                      students.Фамилия,
                      students.Имя,
                      students.Отчество,
                      students.ДатаРождения,
                      students.Пол,
                      students.УОбразования,
                      students.НаимДОО,
                      students.СерияДОО,
                      students.НомерДОО,
                      students.ФамилияДОО,
                      students.АРег,
                      students.Телефон,
                      students.Гражданство,
                      students.ДУЛ,
                      students.СерияДУЛ,
                      students.НомерДУЛ,
                      students.ИФин,
                      napr_organization.name,
                      students.НомерНапрРосздрав,
                      students.ДатаНапрРосздрав,
                      students.Специальность,
                      students.ДатаРегистрации,
                      students.ДатаОкончанияОбразованияПоДОО,
                      students.Почта,
                      students.СтранаДОО,
                      students.ДУЛКемВыдан,
                      students.ДУЛДатаВыдачи,
                      doo_vid_dok.name AS vid_doo
                    FROM students
                      LEFT JOIN doo_vid_dok
                        ON students.doo_vid_dok=doo_vid_dok.kod
                      INNER JOIN napr_organization
                        ON students.НОрг = napr_organization.kod
                        WHERE students.Снилс='" + snils + "'"

        Return sqlString

    End Function

    Public Function load_ppOk_group(kod As String) As String

        sqlString = "SELECT
                                  CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                                  students.Фамилия,
                                  CONCAT(students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                                  students.Снилс,
                                  `group`.НомерДиплома,
                                  `group`.РегНомерДиплома,
                                  `group`.ОсновнойДокумент,
                                  programm.name,
                                  ДатаВыдачиДиплома,
                                  ДатаНЗ,
                                  ДатаКЗ,
                                  КолЧас,
                                  Квалификация,
                                  НомерПротоколаИА,
                                  sotrudnik.name AS Куратор
                                FROM (group_list
                                  INNER JOIN students
                                    ON group_list.students = students.Снилс)
                                  INNER JOIN `group`
                                    ON group_list.kod = `group`.Код
                                      LEFT JOIN sotrudnik
                                    ON sotrudnik.kod = Куратор
                                      LEFT JOIN programm
                                    ON programm.kod = kod_programm
                                WHERE `group`.Код = " + kod + "
                                ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function load_pkOk_group(kod As String) As String

        sqlString = "SELECT
                                  CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                                  students.Фамилия,
                                  CONCAT(students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                                  students.Снилс,
                                  `group`.НомерУд,
                                  `group`.РегНомерУд,
                                  `group`.ОсновнойДокумент,
                                  programm.name,
                                  ДатаВыдачиУд,
                                  ДатаНЗ,
                                  ДатаКЗ,
                                  КолЧас,
                                  Квалификация,
                                  НомерПротоколаИА,
                                  sotrudnik.name AS Куратор
                                FROM (group_list
                                  INNER JOIN students
                                    ON group_list.students = students.Снилс)
                                  INNER JOIN `group`
                                    ON group_list.kod = `group`.Код
                                  LEFT JOIN sotrudnik
                                    ON sotrudnik.kod=Куратор
                                  LEFT JOIN programm
                                    ON programm.kod = kod_programm
                                WHERE `group`.Код = " + kod + "
                                ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function load_poOk_group(kod As String) As String

        sqlString = "SELECT
                                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                                      students.Фамилия,
                                      CONCAT(students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                                      students.Снилс,
                                      `group`.НомерСвид,
                                      `group`.РегНомерСвид,
                                      `group`.ОсновнойДокумент,
                                      programm.name,
                                      ДатаВыдачиСвид,
                                      ДатаНЗ,
                                      ДатаКЗ,
                                      КолЧас,
                                      Квалификация,
                                      НомерПротоколаИА,
                                      sotrudnik.name AS Куратор
                                    FROM (group_list
                                      INNER JOIN students
                                        ON group_list.students = students.Снилс)
                                      INNER JOIN `group`
                                        ON group_list.kod = `group`.Код
                                      LEFT JOIN sotrudnik
                                        ON sotrudnik.kod = Куратор
                                      LEFT JOIN programm
                                        ON programm.kod = kod_programm
                                WHERE `group`.Код = " + kod + "
                                ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function load_prog_kurator(kod As String) As String

        sqlString = " SELECT
                                      programm.name,
                                      sotrudnik.name
                                    FROM (SELECT
                                        `group`.kod_programm,
                                        `group`.Куратор
                                      FROM `group`
                                      WHERE Код =" + kod + ") AS gr
                                      LEFT JOIN sotrudnik
                                        ON gr.Куратор = kod
                                      LEFT JOIN programm
                                        ON gr.kod_programm = programm.kod"
        Return sqlString

    End Function

    Public Function load_spr_group(ur_kval As String, sort As String, Optional year As String = "0") As String

        sort = sort.Replace("Программа", "programm.name")

        sqlString = ""

        sqlString = "SELECT
                      tbl1.Код,
                      tbl1.Номер,
                      programm.name,
                      sotrudnik.name,
                      tbl1.ДатаНЗ,
                      tbl1.ДатаКЗ
                    FROM (SELECT
                        `group`.Код,
                        `group`.Номер,
                        `group`.kod_programm AS prog,
                        `group`.Куратор,
                        `group`.ДатаНЗ,
                        `group`.ДатаКЗ,
                        `group`.Спец
                      FROM `group`
                      WHERE `group`.УровеньКвалификации = '" + ur_kval + "'"

        If year <> "0" Then
            sqlString += " AND YEAR(`group`.ДатаНЗ) = '" + year + "'"
        End If

        sqlString += ") AS tbl1
                    LEFT JOIN sotrudnik
                        ON Куратор=kod
                    LEFT JOIN programm
                        ON tbl1.prog = programm.kod
                    ORDER BY " + sort

        Return sqlString

    End Function

    Public Function formList__loadGroup(ur_kval As String, sort As String, col_search As String, text As String, Optional year As String = "0") As String

        col_search = col_search.Replace("Программа", "programm.name")

        sqlString = ""

        sqlString = "SELECT
                    tbl1.Код,
                    tbl1.Номер,
                    tbl1.Программа,
                    Куратор,
                    tbl1.ДатаНЗ,
                    tbl1.ДатаКЗ
                    FROM
                    (SELECT
                      Код,
                      Номер,
                      programm.name AS Программа,
                      sotrudnik.name As Куратор,
                      ДатаНЗ,
                      ДатаКЗ,
                      Спец
                    FROM `group`
                    LEFT JOIN programm
                      ON `group`.kod_programm=programm.kod
                    LEFT JOIN
                        sotrudnik
                    ON Куратор=sotrudnik.kod
                    WHERE УровеньКвалификации = '" + ur_kval + "'"

        If year <> "0" Then
            sqlString += " AND YEAR(`group`.ДатаНЗ) = '" + year + "'"
        End If
        sqlString += ") AS tbl1
                    WHERE " & col_search & " LIKE " & Chr(39) & text & "%" & Chr(39) &
                    " ORDER BY " + sort

        Return sqlString

    End Function

    Public Function load_spr_group_search(ur_kval As String, sort As String, col_search As String, text As String, Optional year As String = "0") As String

        col_search = col_search.Replace("Программа", "programm.name")

        sqlString = ""

        sqlString = "SELECT
                    tbl1.Код,
                    tbl1.Номер,
                    tbl1.Программа,
                    Куратор,
                    tbl1.ДатаНЗ,
                    tbl1.ДатаКЗ
                    FROM
                    (SELECT
                      Код,
                      Номер,
                      programm.name AS Программа,
                      sotrudnik.name As Куратор,
                      ДатаНЗ,
                      ДатаКЗ,
                      Спец
                    FROM `group`
                    LEFT JOIN programm
                      ON `group`.kod_programm=programm.kod
                    LEFT JOIN
                        sotrudnik
                    ON Куратор=sotrudnik.kod
                    WHERE УровеньКвалификации = '" + ur_kval + "'"

        If year <> "0" Then
            sqlString += " AND YEAR(`group`.ДатаНЗ) = '" + year + "'"
        End If
        sqlString += ") AS tbl1
                    WHERE " & col_search & " LIKE " & Chr(39) & text & "%" & Chr(39) &
                    " ORDER BY " + sort

        Return sqlString

    End Function

    Public Function select_moduls_ocenka(kod_group As String, modul_name As String) As String

        sqlString = ""

        sqlString = "SELECT 
                      ocenka.students,
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
                             INNER JOIN `group`
                               ON progs_mods_hours.kod_prog = `group`.kod_programm
                           WHERE `group`.Код = " + kod_group + "
                           ORDER BY modul_number) AS tbl_mod,
                         (SELECT
                             " + Chr(64) + "I := 0) I) AS moduls
                    LEFT JOIN
                      (SELECT
                    1 AS number,
                    students,
                      group_list.ОценкаМодуль1 AS mod1
                    FROM group_list WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    2 AS number,
                    students,
                      group_list.ОценкаМодуль2 AS mod2
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    3 AS number,
                    students,
                      group_list.ОценкаМодуль3 AS mod3
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    4 AS number,
                    students,
                      group_list.ОценкаМодуль4 AS mod4
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    5 AS number,
                    students,
                      group_list.ОценкаМодуль5 AS mod5
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    6 AS number,
                    students,
                      group_list.ОценкаМодуль6 AS mod6
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    7 AS number,
                    students,
                      group_list.ОценкаМодуль7 AS mod7
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    8 AS number,
                    students,
                      group_list.ОценкаМодуль8 AS mod8
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    9 AS number,
                    students,
                      group_list.ОценкаМодуль9 AS mod9
                    FROM group_list
                    WHERE Kod=" + kod_group + "
                    UNION ALL 
                    SELECT
                    10 AS number,
                    students,
                      group_list.ОценкаМодуль10 AS mod10
                    FROM group_list
                    WHERE Kod=" + kod_group + ") AS ocenka
                    ON moduls.number=ocenka.number
                    WHERE moduls.name='" + modul_name + "'
                    ORDER BY moduls.number"

        Return sqlString

    End Function

    Public Function select_moduls_count(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      COUNT(progs_mods_hours.kod_modul) AS expr1
                    FROM progs_mods_hours
                      INNER JOIN programm
                        ON progs_mods_hours.kod_prog = programm.kod
                      INNER JOIN `group`
                        ON `group`.kod_programm = programm.kod
                    WHERE `group`.Код = " + kod_group

        Return sqlString

    End Function

    Public Function selectSpravka_moduls_hours(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      moduls.name,
                      progs_mods_hours.hours
                    FROM `group`
                      INNER JOIN programm
                        ON `group`.kod_programm = programm.kod
                      INNER JOIN progs_mods_hours
                        ON progs_mods_hours.kod_prog = programm.kod
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE `group`.Код =" + kod_group + " AND moduls.name <> 'Итоговая аттестация'
                    ORDER BY modul_number"

        Return sqlString

    End Function

    Public Function selectSpravkaIA_group(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      programm.name,
                      uroven_kvalifik.name_padej,
                      Финансирование,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас
                    FROM `group`
                      INNER JOIN uroven_kvalifik
                        ON `group`.УровеньКвалификации = uroven_kvalifik.name
                      LEFT JOIN programm
                        ON `group`.kod_programm = programm.kod
                    WHERE `group`.Код =" + kod_group

        Return sqlString

    End Function
    Public Function spravka__groupData(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      programm.name,
                      uroven_kvalifik.name_padej,
                      Финансирование,
                      ДатаНЗ,
                      ДатаКЗ
                    FROM `group`
                      INNER JOIN uroven_kvalifik
                        ON `group`.УровеньКвалификации = uroven_kvalifik.name
                      LEFT JOIN programm
                        ON `group`.kod_programm = programm.kod
                    WHERE `group`.Код =" + kod_group

        Return sqlString

    End Function
    Public Function selectDover_slush(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' '))
                    FROM group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                    WHERE group_list.kod =" + kod_group + "
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function selectDoverKval(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      programm.name,
                      uroven_kvalifik.name_padej,
                      Финансирование,
                      ДатаКЗ
                    FROM `group`
                      INNER JOIN uroven_kvalifik
                        ON `group`.УровеньКвалификации = uroven_kvalifik.name
                        LEFT JOIN programm 
                        ON `group`.kod_programm = programm.kod
                    WHERE `group`.Код =" + kod_group

        Return sqlString

    End Function

    Public Function selectCol_otchet_info(ДатаНачалаОтчета, ДатаКонцаОтчета) As String

        sqlString = ""

        sqlString = "
                    SELECT
                      Код,
                      Номер,
                      ФормаО,
                      ДатаНЗ,
                      ДатаКЗ,
                      Спец,
                      programm.name,
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
                    FROM (SELECT * FROM `group` WHERE ДатаНЗ BETWEEN '" & ДатаНачалаОтчета & "' and '" & ДатаКонцаОтчета & " ') AS gr
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
                        ON gr.modul10 = s10.kod
                    LEFT JOIN programm
                        ON gr.kod_programm = programm.kod"

        Return sqlString

    End Function

    Public Function selectCol_chas() As String

        sqlString = ""

        sqlString = "Select * FROM kol_chas "

        Return sqlString

    End Function

    Public Function updateSettings(name As String, value As String) As String

        sqlString = ""

        sqlString = "UPDATE Settings Set value='" + value + "' WHERE name='" + name + "'"

        Return sqlString

    End Function

    Public Function loadSettings() As String

        sqlString = ""

        sqlString = "SELECT name,value FROM Settings
                    UNION ALL
                    SELECT kod,passwrd FROM passwords"

        Return sqlString

    End Function

    Public Function loadIA(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT  CONCAT(students.Фамилия,' ',students.Имя,' ',IFNULL(students.Отчество,' ')) as 'ФИО', group_list.ИАТестирование as ИАТестирование, ИАПрактическиеНавыки as ИАПрактическиеНавыки, ИАИтог, students.Снилс FROM group_list INNER JOIN students ON group_list.students = students.Снилс WHERE group_list.Kod = " & kod_group & " ORDER BY Фамилия"

        Return sqlString

    End Function
    Public Function loadVedomost(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT CONCAT(students.Фамилия,' ',students.Имя,' ',students.Отчество), group_list.ОценкаМодуль1, ОценкаМодуль2, ОценкаМодуль3, ОценкаМодуль4, ОценкаМодуль5, ОценкаМодуль6, ОценкаМодуль7, ОценкаМодуль8, ОценкаМодуль9, ОценкаМодуль10, students.СНИЛС FROM group_list INNER JOIN students ON group_list.students = students.Снилс WHERE group_list.Kod = " & kod_group & " ORDER BY Фамилия"

        Return sqlString

    End Function
    Public Function selectMassForPrilDiplom(kod As String) As String

        sqlString = ""

        sqlString = "SELECT
                      moduls.name,
                      progs_mods_hours.hours,
                      `group`.ДатаНЗ,
                      `group`.ДатаКЗ,
                      programm.name,
                      `group`.КолЧас,
                      `group`.НомерДиплома,
                      `group`.РегНомерДиплома,
                      `group`.ДатаВыдачиДиплома,
                      `group`.УровеньКвалификации
                    FROM progs_mods_hours
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                      CROSS JOIN `group`
                      INNER JOIN programm
                        ON `group`.kod_programm = programm.kod
                        AND progs_mods_hours.kod_prog = programm.kod
                    WHERE `group`.Код = " + kod + "
                    ORDER BY modul_number"

        Return sqlString

    End Function

    Public Function selectMassForPrilSvidetelstvo(kod As String) As String

        sqlString = ""

        sqlString = "SELECT
                      moduls.name,
                      progs_mods_hours.hours,
                      `group`.ДатаНЗ,
                      `group`.ДатаКЗ,
                      programm.name,
                      `group`.КолЧас,
                      `group`.НомерСвид,
                      `group`.РегНомерСвид,
                      `group`.ДатаВыдачиСвид,
                      `group`.НомерПротоколаИА,
                      `group`.УровеньКвалификации
                    FROM progs_mods_hours
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                      CROSS JOIN `group`
                      INNER JOIN programm
                        ON `group`.kod_programm = programm.kod
                        AND progs_mods_hours.kod_prog = programm.kod
                    WHERE `group`.Код = " + kod + "
                    ORDER BY modul_number"

        Return sqlString

    End Function
    Public Function loadGroup(kod_gr As String)

        sqlString = "SELECT
                                  gr.Код,
                                  gr.Номер,
                                  gr.ФормаО,
                                  gr.ДатаНЗ,
                                  gr.ДатаКЗ,
                                  gr.Спец,
                                  programm.name AS Программа,
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
                                  FROM `group`
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
                                    ON gr.modul10 = s10.kod
                                  LEFT JOIN programm
                                    ON gr.kod_programm = programm.kod"

        Return sqlString

    End Function
    Public Function loadListModul(kod_gr As String)
        sqlString = "SELECT
                                      moduls.name
                                    FROM (SELECT
                                        *
                                      FROM `group`
                                      WHERE Код = " + kod_gr + ") AS gr
                                      INNER JOIN progs_mods_hours
                                        ON gr.kod_programm = progs_mods_hours.kod_prog
                                      INNER JOIN moduls
                                        ON progs_mods_hours.kod_modul = moduls.kod
                                    ORDER BY progs_mods_hours.modul_number"

        Return sqlString

    End Function

    Public Function loadListSotrudnicModul(kod_gr As String)

        sqlString = "SELECT
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
                                    FROM `group`
                                      INNER JOIN sotrudnik AS s1
                                        ON `group`.modul1 = s1.kod
                                      LEFT JOIN sotrudnik AS s2
                                        ON `group`.modul2 = s2.kod
                                      LEFT JOIN sotrudnik AS s3
                                        ON `group`.modul3 = s3.kod
                                      LEFT JOIN sotrudnik AS s4
                                        ON `group`.modul4 = s4.kod
                                      LEFT JOIN sotrudnik AS s5
                                        ON `group`.modul5 = s5.kod
                                      LEFT JOIN sotrudnik AS s6
                                        ON `group`.modul6 = s6.kod
                                      LEFT JOIN sotrudnik AS s7
                                        ON `group`.modul7 = s7.kod
                                      LEFT JOIN sotrudnik AS s8
                                        ON `group`.modul8 = s8.kod
                                      LEFT JOIN sotrudnik AS s9
                                        ON `group`.modul9 = s9.kod
                                      LEFT JOIN sotrudnik AS s10
                                        ON `group`.modul10 = s10.kod
                                        WHERE `group`.Код=" + kod_gr
        Return sqlString

    End Function

    Public Function SQLString_OtchetRuk(DateNach As String, DateKon As String)

        sqlString = ""

        sqlString = "SELECT" +
                     "  Tbl_spec.Спец," +
                     "  Tbl_spec.Номер," +
                     "  Tbl_spec.programm," +
                     "  Tbl_spec.КолЧас," +
                     "  Tbl_spec.period," +
                     "  Tbl_data_1.чел," +
                     "  IFNULL(Tbl_data_2.bud,0) AS Бюджет," +
                     "  Tbl_data_1.чел-IFNULL(Tbl_data_2.bud,0) AS Внебюджет," +
                     "  IF(Tbl_spec.Финансирование='бюджет',1,0) AS бюджет," +
                     "  IF(Tbl_spec.Финансирование='внебюджет',1,0) AS внебюджет," +
                     "  IFNULL(Tbl_data_2.bud,0)*Tbl_spec.КолЧас AS бюджет," +
                     "  (Tbl_data_1.чел - IFNULL(Tbl_data_2.bud,0))*Tbl_spec.КолЧас AS Внебюджет" +
                     " FROM
                     (
                        SELECT 
                        tblGroup.Номер,
                        programm.name AS programm,
                        tblGroup.Спец,
                        tblGroup.КолЧас,
                        tblGroup.Код,
                        tblGroup.Финансирование,
                        tblGroup.period
                        FROM
                        (
                          SELECT" +
                     "    Номер," +
                     "    kod_programm," +
                     "    Спец," +
                     "    КолЧас," +
                     "    Код," +
                     "    Финансирование," +
                     "    CONCAT(DAY(ДатаНЗ), '.', IF(MONTH(ДатаНЗ) < 10, CONCAT('0', MONTH(ДатаНЗ)), MONTH(ДатаНЗ)), '.', YEAR(ДатаНЗ), '-', DAY(ДатаКЗ), '.', IF(MONTH(ДатаКЗ) < 10, CONCAT('0', MONTH(ДатаКЗ)), MONTH(ДатаКЗ)), '.', YEAR(ДатаКЗ)) AS period" +
                     "  FROM `group`" +
                     "  WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'
                     ) AS tblGroup
                        LEFT JOIN
                        programm
                        ON tblGroup.kod_programm=kod
                     ) AS Tbl_spec" +
                     "  INNER JOIN (SELECT" +
                     "      spec.Код," +
                     "      COUNT(students) AS чел" +
                     "    FROM (SELECT" +
                     "        Код" +
                     "      FROM `group`" +
                     "      WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                     "      INNER JOIN group_list" +
                     "        ON spec.Код = kod" +
                     "    GROUP BY spec.Код) AS Tbl_data_1" +
                     "    ON Tbl_data_1.Код = Tbl_spec.Код" +
                     "  LEFT JOIN  " +
                     "  (SELECT" +
                     "      sostav.Код," +
                     "      IFNULL(COUNT(slush.ИФин),0) AS bud" +
                     "    FROM (SELECT" +
                     "        spec.Код," +
                     "        students" +
                     "      FROM (SELECT" +
                     "          Код" +
                     "        FROM `group`" +
                     "        WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                     "        INNER JOIN group_list" +
                     "          ON spec.Код = kod) AS sostav" +
                     "      INNER JOIN (SELECT" +
                     "          Снилс," +
                     "          ИФин" +
                     "        FROM students" +
                     "        WHERE ИФин = 'Федеральный бюджет') AS slush" +
                     "        ON slush.Снилс = sostav.students" +
                     "        GROUP BY sostav.Код" +
                     "        ) AS Tbl_data_2" +
                     "    ON Tbl_data_2.Код = Tbl_spec.Код" +
                     " ORDER BY Tbl_spec.Спец,Tbl_spec.programm DESC"

        Return sqlString

    End Function

    Public Function SQLString_OtchetRMANPO(DateNach As String, DateKon As String)

        sqlString = ""

        sqlString = "SELECT
                    Tbl_spec.Спец,
                    Tbl_spec.Номер,
                    Tbl_spec.period,
                    programm.name,
                    Tbl_data_1.чел,
                    Tbl_data_2.bud AS Бюджет,
                    Tbl_data_1.чел - Tbl_data_2.bud AS Внебюджет,
                    Tbl_org.НОрг,
                    Tbl_org.bud
                  FROM (SELECT
                      Номер,
                      kod_programm,
                      Спец,
                      КолЧас,
                      Код,
                      Финансирование,
                      CONCAT(IF(DAY(ДатаНЗ) < 10, CONCAT('0',DAY(ДатаНЗ)), DAY(ДатаНЗ)), '.', IF(MONTH(ДатаНЗ) < 10, CONCAT('0', MONTH(ДатаНЗ)), MONTH(ДатаНЗ)), '.', YEAR(ДатаНЗ), '-',IF(DAY(ДатаКЗ) < 10, CONCAT('0',DAY(ДатаКЗ)), DAY(ДатаКЗ)) , '.', IF(MONTH(ДатаКЗ) < 10, CONCAT('0', MONTH(ДатаКЗ)), MONTH(ДатаКЗ)), '.', YEAR(ДатаКЗ)) AS period
                    FROM `group`" +
                          "  WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS Tbl_spec

                      LEFT JOIN
                  programm
                  ON 
                  Tbl_spec.kod_programm=programm.kod

                    INNER JOIN (SELECT
                        spec.Код,
                        COUNT(students) AS чел
                      FROM (SELECT
                          Код
                        FROM `group`" +
                          "  WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS spec
                        INNER JOIN group_list
                          ON spec.Код = kod
                      GROUP BY spec.Код) AS Tbl_data_1
                      ON Tbl_data_1.Код = Tbl_spec.Код
                    INNER JOIN (SELECT
                        sostav.Код,
                        COUNT(slush.ИФин) AS bud
                      FROM (SELECT
                          spec.Код,
                          students
                        FROM (SELECT
                            Код
                          FROM `group`" +
                          "  WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS spec
                          INNER JOIN group_list
                            ON spec.Код = kod) AS sostav
                        INNER JOIN (SELECT
                            Снилс,
                            ИФин
                          FROM students
                          WHERE ИФин = 'Федеральный бюджет') AS slush
                          ON slush.Снилс = sostav.students
                      GROUP BY sostav.Код) AS Tbl_data_2
                      ON Tbl_data_2.Код = Tbl_spec.Код
                    INNER JOIN (SELECT
                        sostav.Код,
                        full_name AS НОрг,
                        COUNT(slush.ИФин) AS bud
                      FROM (SELECT
                          spec.Код,
                          students
                        FROM (SELECT
                            Код
                          FROM `group`" +
                          "  WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'" +
                    ") AS spec
                          INNER JOIN group_list
                            ON spec.Код = kod) AS sostav
                        INNER JOIN (SELECT
                            Снилс,
                            ИФин,
                            НОрг
                          FROM students) AS slush
                          ON slush.Снилс = sostav.students
                        LEFT JOIN napr_organization
                                ON slush.НОрг=kod
                      GROUP BY sostav.Код,
                               slush.НОрг) AS Tbl_org
                      ON Tbl_spec.Код = Tbl_org.Код
                ORDER BY Tbl_spec.Спец,Tbl_spec.Номер, Tbl_org.НОрг "

        Return sqlString

    End Function

    Public Function SQLString_OtchetKurs(DateNach As String, DateKon As String, Argument As String)

        sqlString = ""

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
                    "        IFNULL(programm.name, '') AS Программа,
                             IFNULL(Спец,'') AS Спец,
                             КолЧас,
                             Код,
                             IFNULL(Финансирование,'')," +
                    "    CONCAT(Day(ДатаНЗ), '.', If(month(ДатаНЗ) < 10, CONCAT('0', month(ДатаНЗ)), month(ДатаНЗ)), '.', Year(ДатаНЗ), '-', Day(ДатаКЗ), '.', If(month(ДатаКЗ) < 10, CONCAT('0', month(ДатаКЗ)), month(ДатаКЗ)), '.', Year(ДатаКЗ)) AS period" +
                    " FROM 
                    (SELECT
                      *
                      FROM
                    `group`" +
                    " WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'
                    ) AS tblGroup
                      LEFT JOIN 
                          programm
                          ON tblGroup.kod_programm=programm.kod
                    ) AS Tbl_spec" +
                    "  INNER JOIN (SELECT" +
                    "      spec.Код," +
                    "      COUNT(students) AS чел" +
                    "    FROM(SELECT" +
                    "        Код" +
                    "        From `group`" +
                    " WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                    "      INNER Join group_list" +
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

        sqlString = ""

        sqlString = "SELECT 
                        name AS Организация,
                        result.Человек
                         FROM
                        ( SELECT" +
                    "       slush.НОрг," +
                    "       COUNT(slush.Снилс) AS Человек" +
                    "     FROM(SELECT" +
                    "         spec.Код," +
                    "         students" +
                    "       FROM(SELECT" +
                    "           Код" +
                    "         From `group`" +
                    "         WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec" +
                    "         INNER Join group_list" +
                    "           On spec.Код = kod) AS sostav" +
                    "       INNER Join (SELECT" +
                    "           Снилс," +
                    "           IFNULL(НОрг,'') AS НОрг" +
                    "         From students" +
                    "         ) AS slush" +
                    "         ON slush.Снилс = sostav.students" +
                    "     GROUP By slush.НОрг" +
                    " ORDER BY slush.НОрг) AS result

                    LEFT JOIN 

                    napr_organization
                    ON result.НОрг=kod"


        Return sqlString

    End Function

    Public Function SQLString_OtchetBud_Vbud(DateNach As String, DateKon As String, argument As String)

        sqlString = ""

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
                          students
                        FROM(SELECT
                            Код,
                            КолЧас
                          From `group`" +
                    "         WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'"
        sqlString += ") AS spec" +
                    "      INNER Join group_list
                            On spec.Код = kod) AS sostav
                        INNER Join(SELECT
                            Снилс,
                            If(Пол = 'женский', 0, 1) AS Пол,
                            If(If(month(Now()) >= month(ДатаРождения) And Day(Now()) >= Day(ДатаРождения), Year(Now()) >= Year(ДатаРождения), Year(Now()) >= Year(ДатаРождения) - 1) >= 60 And Пол = 'мужской', 1, 0) AS v_60
                          From students"

        If argument = "бюджет" Then
            sqlString += "  WHERE ИФин = 'Федеральный бюджет'"
        ElseIf argument = "внебюджет" Then
            sqlString += "  WHERE ИФин = 'Платное обучение'"
        End If

        sqlString += " ) AS slush
                          On slush.Снилс = sostav.students
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
                              students
                            FROM (SELECT
                                Код,
                                КолЧас
                              FROM `group`" +
                    "         WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "') AS spec"

        sqlString += "       INNER JOIN group_list
                                ON spec.Код = kod) AS sostav
                            INNER JOIN (SELECT
                                Снилс
                                FROM students
                                "

        If argument = "бюджет" Then
            sqlString += "  WHERE ИФин = 'Федеральный бюджет'"
        ElseIf argument = "внебюджет" Then
            sqlString += "  WHERE ИФин = 'Платное обучение'"
        End If

        sqlString += "
                              ) AS slush
                              ON slush.Снилс = sostav.students

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
                          From `group`" +
                    "         WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' AND '" + DateKon + "'"

        sqlString += ") AS spec" +
                    "      INNER Join group_list
                            On spec.Код = kod
      INNER JOIN 
      (SELECT
          Снилс
        FROM students "

        If argument = "бюджет" Then
            sqlString += "  WHERE ИФин = 'Федеральный бюджет'"
        ElseIf argument = "внебюджет" Then
            sqlString += "  WHERE ИФин = 'Платное обучение'"
        End If

        sqlString += " ) AS slush

        ON slush.Снилс = students

    GROUP BY spec.КолЧас) AS sostav_chel

    ON tbl_slush.КолЧас = sostav_chel.КолЧас"


        Return sqlString

    End Function

    Public Function SQLString_SELECT_dateAndKvalGrupp(kod As Integer)

        sqlString = ""

        sqlString = "SELECT" +
                    "   YEAR(ДатаКЗ) AS date," +
                    "   УровеньКвалификации AS Kval" +
                    " FROM `group`" +
                    " WHERE Код =" & kod

        Return sqlString

    End Function



    Function sqlSearch(searchValue As String, nameTable As String, nameColumns As String, searchColumn As String, sortColumn As String, Optional includeUK As Boolean = False) As Object

        Dim ChMass As Object
        Dim Dlina As Integer
        Dim counter As Integer
        Dlina = Len(searchValue)

        counter = 0

        If nameTable = "Группа" Or nameTable = "`group`" Then

            If includeUK Then
                sqlString = load_spr_group_search(СправочникГруппы.СГУровеньКвалификации.Text, sortColumn, searchColumn, searchValue, СправочникГруппы.yearSpravochnikGr.Text)
            Else
                sqlString = formList__loadGroup(СправочникГруппы.СГУровеньКвалификации.Text, sortColumn, searchColumn, searchValue, СправочникГруппы.yearSpravochnikGr.Text)
            End If

        Else

            sqlString = "SELECT " & nameColumns & " FROM " & nameTable & " WHERE  (((" & searchColumn & ") LIKE " & Chr(39) & searchValue & "%" & Chr(39) & " )) ORDER BY " & sortColumn

        End If

        ChMass = MainForm.mySqlConnect.loadMySqlToArray(sqlString, 1)
        ChMass = УбратьПустотыВМассиве.УбратьПустотыВМассиве(ChMass)

        sqlSearch = ChMass

    End Function

    Public Function SQLString_UpdateNumbersSGrupp(kod As Integer)

        sqlString = ""

        sqlString = " UPDATE group_list set НомерУд=NULL,РегНомерУд=NULL ,РегНомерСвид=NULL ,НомерСвид=NULL,РегНомерДиплома=NULL,НомерДиплома=NULL WHERE Kod=" & kod

        Return sqlString

    End Function

    Public Function SQLString_loadGruppa(Optional includeUK As Boolean = True, Optional nameSearchColumn As String = "None", Optional searchValue As String = "None", Optional valInApostrophes As Boolean = True)

        sqlString = ""
        sqlString = "SELECT
                      Номер,
                      programm.name as Программа,
                      YEAR(ДатаНЗ),
                      Код
                    FROM `group`
                    LEFT JOIN 
                    programm ON `group`.kod_programm = programm.kod
                    WHERE Номер <> ''
                    AND ДатаКЗ >'" & MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.AddMonths(-6)) & "'"

        If includeUK Then

            If MainForm.prikazCvalif = MainForm.PP Then
                sqlString &= " AND УровеньКвалификации = 'профессиональная переподготовка'"
            ElseIf MainForm.prikazCvalif = MainForm.PK Then
                sqlString &= " AND УровеньКвалификации = 'повышение квалификации'"
            ElseIf MainForm.prikazCvalif = MainForm.PO Then
                sqlString &= " AND УровеньКвалификации = 'профессиональное обучение'"
            ElseIf MainForm.prikazCvalif = MainForm.PK_PP Then
                sqlString &= " AND (УровеньКвалификации = 'профессиональная переподготовка' OR УровеньКвалификации = 'повышение квалификации')"
            End If

        End If

        If Not nameSearchColumn = "None" Then

            sqlString &= " AND " + nameSearchColumn + " LIKE "
            If valInApostrophes Then
                sqlString += "'%" + searchValue + "%'"
            Else
                sqlString += searchValue
            End If

        End If

        If ФормаСписок.sortColumn <> -1 Then

            If (ФормаСписок.ListViewСписок.Columns(ФормаСписок.sortColumn).Text = "Группа" Or ФормаСписок.ListViewСписок.Columns(ФормаСписок.sortColumn).Text = "Номер") And MainForm.prikazCvalif = MainForm.PK Then
                sqlString &= " ORDER BY Номер"
                If ФормаСписок.sort = ФормаСписок.poUb Then
                    sqlString &= " DESC"
                End If
            Else
                sqlString &= " ORDER BY programm.name"
            End If
        Else
            sqlString &= " ORDER BY programm.name"
        End If



        Return sqlString

    End Function

    Public Function ProgrammPoUKvalifikLimit1(UrovenKvalifik As String)

        sqlString = ""

        If UrovenKvalifik = "" Then

            sqlString = "SELECT 
                            name 
                        FROM programm 
                        GROUP BY programm.name 
                        ORDER BY name"

        Else
            sqlString = " SELECT
                           Programm.name,
                            MAX(date),
                            MAX(Programm.kod)
                                 FROM
                         (SELECT 
                         uroven_kvalifik.kod
                                From uroven_kvalifik
                             WHERE uroven_kvalifik.name = '" + UrovenKvalifik + "'
                             ) AS tbl1
                           INNER Join programm
                             ON tbl1.kod = programm.uroven_kvalifik
                          GROUP BY programm.name
                         ORDER BY name"
        End If

        Return sqlString

    End Function

    Public Function ProgrammPoUKvalifik(UrovenKvalifik As String)

        sqlString = ""

        If UrovenKvalifik = "" Then
            sqlString = "SELECT name,date,kod FROM programm ORDER BY name"
        Else
            sqlString = " SELECT" +
                          " programm.name,
                            date,
                            programm.kod
                                FROM
                         (SELECT 
                         uroven_kvalifik.kod
                               FROM uroven_kvalifik
                             WHERE uroven_kvalifik.name = '" + UrovenKvalifik + "'
                             ) AS tbl1
                           INNER Join programm
                             On tbl1.kod = programm.uroven_kvalifik
                        ORDER BY name"
        End If
        Return sqlString

    End Function


    Public Function SQLString_OtchetMassDataSlush(DateNach As String, DateKon As String)

        sqlString = ""

        sqlString = " SELECT" +
  " students.Код," +
  " students.Снилс," +
  " students.Фамилия," +
  " students.Отчество," +
  " students.Имя," +
  " students.ДатаРождения," +
  " students.Пол," +
  " students.УОбразования," +
  " students.НаимДОО," +
  " students.СерияДОО," +
  " students.НомерДОО," +
  " students.ФамилияДОО," +
  " students.АРег," +
  " students.Телефон," +
  " students.Гражданство," +
  " students.ДУЛ," +
  " students.СерияДУЛ," +
  " students.НомерДУЛ," +
  " students.ИФин," +
  " students.ДатаРегистрации" +
  " FROM" +
  " (" +
" SELECT " +
 "        group_list.students" +
" FROM `group`" +
"   INNER JOIN group_list" +
"     ON `group`.Код = group_list.Kod" +
"     WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' And '" + DateKon + "'" +
"     ) AS tbl1" +
"   INNER JOIN students" +
"     ON tbl1.students = students.Снилс"

        Return sqlString

    End Function


    Public Function SQLString_OtchetMassSlush(DateNach As String, DateKon As String)
        sqlString = ""

        sqlString = "SELECT" +
  " group_list.students," +
  " group_list.Kod," +
  " gr.Номер" +
  " FROM (SELECT " +
  " Номер," +
  " код " +
  "   FROM `group` " +
  "   WHERE `group`.ДатаКЗ BETWEEN '2023/1/1 00:00:00' AND '2023/2/17 00:00:00') AS gr" +
  " INNER JOIN group_list" +
    " On gr.Код = group_list.Kod"

        Return sqlString
    End Function


    Public Function sprSlushTblGroup(Snils As String)

        sqlString = ""

        sqlString = "SELECT
                      Код,
                      Номер,
                      programm.name,
                      ДатаНЗ,
                      ДатаКЗ
                    FROM `group`
                      INNER JOIN group_list
                        ON `group`.Код = group_list.kod
                      LEFT JOIN programm 
                        ON `group`.kod_programm=programm.kod
                    WHERE group_list.students = " & Chr(39) & Snils & Chr(39) + "
                    ORDER BY ДатаНЗ"

        Return sqlString

    End Function

    Public Function SQLSTring_PKZayavlenie(kod As Integer)

        sqlString = ""
        sqlString = "Select" +
                  " students.Фамилия," +
                  " students.Имя," +
                  " students.Отчество," +
                  " students.АРег," +
                  " students.Телефон," +
                  " students.Почта" +
                " FROM students" +
                  " INNER JOIN group_list" +
                    " On students.Снилс = group_list.students" +
                    " WHERE group_list.Kod = " & kod & "" +
                      " ORDER BY Фамилия"

        Return sqlString

    End Function

    Public Function SQLSTring_KartSlushatel(kod As Integer)

        sqlString = ""

        sqlString = "SELECT" +
                  " students.Фамилия," +
                  " students.Имя," +
                  " students.Отчество," +
                  " students.ДатаРождения," +
                  " students.НаимДОО," +
                  " students.ДатаОкончанияОбразованияПоДОО," +
                  " students.СерияДОО," +
                  " students.НомерДОО" +
                " FROM students" +
                  " INNER JOIN group_list" +
                    " ON students.Снилс = group_list.students" +
                    " WHERE group_list.Kod = " & kod & "" +
                      " ORDER BY Фамилия"

        Return sqlString

    End Function

    Public Function updateGroup(gruppa As Group.strGruppa) As String

        Dim numberHours,
            dataString,
            part1,
            part2,
            part3,
            part4 As String

        sqlString = ""
        numberHours = gruppa.kolChasov

        dataString = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)

        part1 = "Номер=" & Chr(39) & gruppa.number & Chr(39) &
            ", ФормаО=" & Chr(39) & gruppa.formaObuch & Chr(39) &
            ", ДатаНЗ=" & Chr(39) & gruppa.dataNZ & Chr(39) &
            ", ДатаКЗ=" & Chr(39) & gruppa.dataKZ & Chr(39) &
            ", Спец=" & Chr(39) & gruppa.specialnost & Chr(39) &
            ",kod_programm=" & gruppa.kodProgramm &
            ",КолЧас=" & numberHours & ", Куратор=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.kurator & Chr(39) & " LIMIT 1)" &
            ", ОтвЗаПракт=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.otvZaPraktiku & Chr(39) & " LIMIT 1)" &
            ", датаСоздания=" & Chr(39) & dataString & Chr(39)

        part2 = ", modul1=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul1 & Chr(39) & " LIMIT 1), modul2=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul2 & Chr(39) & " LIMIT 1)
            , modul3=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul3 & Chr(39) & " LIMIT 1), modul4=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul4 & Chr(39) & " LIMIT 1)
            , modul5=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul5 & Chr(39) & " LIMIT 1), modul6=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul6 & Chr(39) & " LIMIT 1)
            , modul7=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul7 & Chr(39) & " LIMIT 1), modul8=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul8 & Chr(39) & " LIMIT 1)
            , modul9=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul9 & Chr(39) & " LIMIT 1), modul10=(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul10 & Chr(39) & " LIMIT 1)"

        part3 = ", УровеньКвалификации=" & Chr(39) & gruppa.urKvalific & Chr(39) &
            ", Финансирование=" & Chr(39) & gruppa.financir & Chr(39) &
            ", НомерПротоколаИА=" & Chr(39) & gruppa.numbersUDS.numberIA & Chr(39) &
            ",НомерУд=" & gruppa.numbersUDS.numberUd &
            ", РегНомерУд=" & gruppa.numbersUDS.regNumberUd &
            ",ДатаВыдачиУд=" & Chr(39) & gruppa.dataVUd & Chr(39) &
            ",НомерДиплома=" & gruppa.numbersUDS.numberD & ", РегНомерДиплома=" & gruppa.numbersUDS.regNumberD

        part4 = ", ДатаВыдачиДиплома=" & Chr(39) & gruppa.dataVD & Chr(39) &
            ", НомерСвид=" & gruppa.numbersUDS.numberSv & ", РегНомерСвид=" & gruppa.numbersUDS.regNumberSv &
            ", ДатаВыдачиСвид=" & Chr(39) & gruppa.dataVSv & Chr(39) &
            ", Квалификация=" & Chr(39) & gruppa.kvalifikaciya & Chr(39) & ", ОсновнойДокумент=" & Chr(39) & gruppa.mainDocument & Chr(39)

        Return "UPDATE `group` SET " & part1 & part2 & part3 & part4 & " WHERE Код =" & gruppa.Kod

    End Function


    Public Function insertIntoGroup(gruppa As Group.strGruppa) As String

        Dim numberHours, DataString, part1, part2 As String

        sqlString = ""
        DataString = MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.ToShortDateString)

        If gruppa.urKvalific = "специальный экзамен" Then
            numberHours = "null"
        End If

        part1 = "(Номер,"
        part2 = "( " & Chr(39) & gruppa.number & Chr(39)

        part1 = part1 & "ФормаО,ДатаНЗ,"
        part2 = part2 & " , " & Chr(39) & gruppa.formaObuch & Chr(39) & " , " & Chr(39) & gruppa.dataNZ & Chr(39)

        part1 = part1 & "ДатаКЗ,Спец,"
        part2 = part2 & " , " & Chr(39) & gruppa.dataKZ & Chr(39) & " , " & Chr(39) & gruppa.specialnost & Chr(39)

        part1 = part1 & "kod_programm,КолЧас,"
        part2 = part2 & " , " & gruppa.kodProgramm & " , " & gruppa.kolChasov

        part1 = part1 & "Куратор,ОтвЗаПракт,"
        part2 = part2 & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.kurator & Chr(39) & " LIMIT 1) ,(SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.otvZaPraktiku & Chr(39) & "  LIMIT 1)"

        part1 = part1 & "датаСоздания, modul1,"
        part2 = part2 & " , " & Chr(39) & DataString & Chr(39) & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul1 & Chr(39) & " LIMIT 1)"

        part1 = part1 & "modul2,modul3,"
        part2 = part2 & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul2 & Chr(39) & " LIMIT 1) , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul3 & Chr(39) & " LIMIT 1)"

        part1 = part1 & "modul4,modul5,modul6,modul7,modul8,modul9,modul10,"
        part2 = part2 & " , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul4 & Chr(39) & " LIMIT 1) , (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul5 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul6 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul7 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul8 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul9 & Chr(39) & " LIMIT 1), (SELECT sotrudnik.kod FROM sotrudnik WHERE name=" & Chr(39) & gruppa.modul10 & Chr(39) & " LIMIT 1)"

        part1 = part1 & "уровеньКвалификации,"
        part2 = part2 & " , " & Chr(39) & gruppa.urKvalific & Chr(39)

        part1 = part1 & "Финансирование, НомерПротоколаИА,"
        part2 = part2 & " , " & Chr(39) & gruppa.financir & Chr(39) & " , " & Chr(39) & gruppa.numbersUDS.numberIA & Chr(39)

        part1 = part1 & "НомерУд, РегНомерУд, ДатаВыдачиУд,"
        part2 = part2 & " , " & gruppa.numbersUDS.numberUd & " , " & gruppa.numbersUDS.regNumberUd & " , " & Chr(39) & gruppa.dataVUd & Chr(39)

        part1 = part1 & "НомерДиплома, РегНомерДиплома,ДатаВыдачиДиплома,"
        part2 &= " , " & gruppa.numbersUDS.numberD & " , " & gruppa.numbersUDS.regNumberD & " , " & Chr(39) & gruppa.dataVD & Chr(39)

        part1 = part1 & " НомерСвид,РегНомерСвид, ДатаВыдачиСвид,"
        part2 &= " , " & gruppa.numbersUDS.numberSv & " , " & gruppa.numbersUDS.regNumberSv & " , " & Chr(39) & gruppa.dataVSv & Chr(39)

        part1 = part1 & "Квалификация, ОсновнойДокумент)"
        part2 &= " , " & Chr(39) & gruppa.kvalifikaciya & Chr(39) & " , " & Chr(39) & gruppa.mainDocument & Chr(39) + ")"

        sqlString = "INSERT INTO `group` " & part1 & "  VALUES " & part2

        Return sqlString

    End Function

    Public Function updateSlushatel(slushatel As Slushatel.strSlushatel) As String

        Dim sqlString As String = "", ДатаВыдачиДул, СтрокаЗапроса As String

        sqlString = "Снилс=" & Chr(39) & slushatel.snils & Chr(39) &
            ", Фамилия=" & Chr(39) & slushatel.фамилия & Chr(39) &
            ", Имя=" & Chr(39) & slushatel.имя & Chr(39) &
            ", Отчество=" & Chr(39) & slushatel.отчество & Chr(39) &
            ", ДатаРождения=" & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.датаР) & Chr(39) &
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
            ", ДатаНапрРосздрав=" & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.датаНаправленияРосздравнвдзора) & Chr(39) &
            ", Специальность=" & Chr(39) & slushatel.специальностьСлушателя & Chr(39) &
            ", ДатаРегистрации=" & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.датаРег) & Chr(39) &
            ", Почта=" & Chr(39) & slushatel.Email & Chr(39) &
            ", ДУЛКемВыдан=" & Chr(39) & slushatel.кемВыданДУЛ & Chr(39) &
            ", doo_vid_dok=(SELECT kod FROM doo_vid_dok WHERE name = '" & slushatel.doo_vid_dok & "' LIMIT 1)"


        sqlString = "UPDATE students SET " & sqlString & " WHERE Снилс =" & Chr(39) & slushatel.старыйСнилс & Chr(39)

        Return sqlString

    End Function


    Public Function insertIntoSlushatel(slushatel As Slushatel.strSlushatel) As String

        Dim part1, part2 As String
        Dim sqlString, ДатаВыдачиДул As String

        sqlString = ""


        part1 = "(Снилс,"
        part2 = "(" & Chr(39) & ДобавитьРубашку.УдалитьРубашку(slushatel.snils) & Chr(39)
        part1 = +"Фамилия, Имя, Отчество,"
        part2 = +"," & Chr(39) & slushatel.фамилия & Chr(39) & "," & Chr(39) & slushatel.имя & Chr(39) & "," & Chr(39) & slushatel.отчество & Chr(39)
        part1 = +"ДатаРождения, Пол, УОбразования,"
        part2 = +"," & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.датаР) & Chr(39) & "," & Chr(39) & slushatel.пол & Chr(39) & "," & Chr(39) & slushatel.уровеньОбразования & Chr(39)
        part1 = +"НаимДОО, СерияДОО, НомерДОО,"
        part2 = +"," & Chr(39) & slushatel.образование & Chr(39) & "," & Chr(39) & slushatel.серияДокументаООбразовании & Chr(39) & "," & Chr(39) & slushatel.номерДокументаООбразовании & Chr(39) &
        part1 = +"ФамилияДОО, АРег, Телефон,"
        part2 = +"," & Chr(39) & slushatel.фамилияВДокОбОбразовании & Chr(39) & "," & Chr(39) & slushatel.адресРегистрации & Chr(39) & "," & Chr(39) & slushatel.телефон & Chr(39) &
        part1 = +"Гражданство, ДУЛ, СерияДУЛ, НомерДУЛ,"
        part2 = +"," & Chr(39) & slushatel.гражданство & Chr(39) & "," & Chr(39) & slushatel.ДУЛ & Chr(39) & "," & Chr(39) & slushatel.серияДУЛ & Chr(39) & "," & Chr(39) & slushatel.номерДУЛ & Chr(39)
        part1 = +"ИФин, НОрг, НомерНапрРосздрав,"
        part2 = +"," & Chr(39) & slushatel.источникФин & Chr(39) & ",(SELECT kod FROM napr_organization WHERE name=" & Chr(39) & slushatel.направившаяОрг & Chr(39) & ") , " & Chr(39) & slushatel.номерНаправленияРосздравнадзора & Chr(39)
        part1 = +" ДатаНапрРосздрав,"
        part2 = +" , " & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.датаНаправленияРосздравнвдзора) & Chr(39) &
        part1 = +"Специальность, ДатаРегистрации, Почта,"
        part2 = +" , " & Chr(39) & slushatel.специальностьСлушателя & Chr(39) & " , " & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.датаРег) & Chr(39) & " , " & Chr(39) & slushatel.Email & Chr(39) &
        part1 = +"ДУЛКемВыдан,ДУЛДатаВыдачи ) "
        part2 = +", " & Chr(39) & slushatel.кемВыданДУЛ & Chr(39) & ", "

        If slushatel.датаВыдачиДУЛ = "null" Then
            part2 += ДатаВыдачиДул & " ) "
        Else part2 += Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.датаВыдачиДУЛ) & Chr(39) & " ) "
        End If


        sqlString = "INSERT INTO students " & part1 & "  VALUES " & part2
        Return sqlString

    End Function


End Module
