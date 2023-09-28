
Imports WindowsApp2.Student

Module QueryString

    Dim sqlString As String

    Public Function group__deleteFromGroupList(kodGroup As String)
        sqlString = "DELETE FROM group_list WHERE Kod = " & kodGroup
        Return sqlString
    End Function

    Public Function group__loadKodGroup(numberGroup As String, year As String)
        sqlString = "SELECT Код FROM `group` WHERE Номер='" & numberGroup & "' AND Year(ДатаНЗ) = " & year
        Return sqlString
    End Function

    Public Function studentsList__loadStudentsList(columnSort As String, arg As String) As String

        Dim mameSortCol As String = ""

        Select Case columnSort
            Case "snils"
                mameSortCol = "Снилс"
            Case "nameStudent"
                mameSortCol = "Имя"
            Case "secName"
                mameSortCol = "Фамилия"

        End Select

        sqlString = "SELECT Код, Снилс, Фамилия, Имя, Отчество FROM students ORDER BY " & mameSortCol & arg

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

        sqlString = "SELECT name FROM position WHERE kod=" + kod

        Return sqlString

    End Function

    Public Function formOrder__loadKodDolj(name As String) As String

        sqlString = "SELECT position FROM worker WHERE name='" + name + "' LIMIT 1"

        Return sqlString

    End Function

    Public Function studentList__studentListInGroup(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(LEFT(students.Снилс, 3), '-', RIGHT(LEFT(students.Снилс, 6), 3), '-', RIGHT(LEFT(students.Снилс, 9), 3), '-', RIGHT(students.Снилс, 2)) AS Снилс,
                      students.Фамилия,
                      students.Имя,
                      IFNULL(students.Отчество, ' ') AS Отчество,
                      students.ДатаРождения,
                      napr_organization.name AS Организация,
                      fin_source.name AS Финансирование
                    FROM group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                      LEFT JOIN napr_organization
                        ON organization = napr_organization.kod
                      LEFT JOIN fin_source
                        ON fin_source.kod = group_list.source_financing 
                    WHERE group_list.Kod = " & kodGroup & " 
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function dopusk_loadListStudents(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                      program.name,
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
                      LEFT JOIN program
                        ON `group`.kod_program=program.kod
                    WHERE `group`.Код=" & kodGroup & "
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function loadListStudents(kodGroup As String) As String

        sqlString = "SELECT
                      CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')),
                      program.name,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас
                    FROM (group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс)
                      INNER JOIN `group`
                        ON group_list.kod = `group`.Код
                      LEFT JOIN program
                        ON kod_program=program.kod
                    WHERE `group`.Код=" & kodGroup & "
                    ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function expulsion__loadProgram(kodGroup As String) As String

        sqlString = "SELECT
                      program.name
                    FROM `group`
                      INNER JOIN program
                    ON `group`.kod_program = program.kod
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
                      program.name,
                      ДатаВыдачиУд,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас
                    FROM `group`
                      INNER JOIN group_list
                        ON group_list.kod = `group`.Код
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                      LEFT JOIN program
                      ON `group`.kod_program = program.kod
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
                      doo_doc_type.name,
                      Квалификация,
                      КолЧас,
                      ДатаНЗ,
                      program.name
                    FROM (group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс)
                      INNER JOIN `group`
                        ON group_list.kod = `group`.Код
                      LEFT JOIN program 
                        ON program.kod=kod_program
                      LEFT JOIN doo_doc_type
                        ON doo_doc_type.kod=students.doo_doc_type
                    WHERE `group`.Код = " & kodGroup & " ORDER BY students.Фамилия"

        Return sqlString

    End Function

    Public Function accountingBook__loadListSvidFRDO(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT  
                      group_list.НомерСвид,
                      ДатаВыдачиСвид,
                      group_list.РегНомерСвид,
                      program.name,
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
                    LEFT JOIN program
                    ON kod_program=program.kod
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
                      program.name,
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
                    LEFT JOIN program
                    ON kod_program=program.kod
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
                      program.name,
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
                    LEFT JOIN program
                    ON kod_program=program.kod
                        WHERE `group`.ОсновнойДокумент= 'Удостоверение'   
                    AND NOT ISNULL(group_list.РегНомерУд) AND group_list.РегНомерУд<>0 
                    AND ДатаВыдачиУд BETWEEN '" & dateStart & "' and  '" & dateEnd & " ' 
                    ORDER BY group_list.РегНомерУд"

        Return sqlString

    End Function

    Public Function accountingBook__loadListSvid(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT  
                    group_list.РегНомерСвид, group_list.НомерСвид,`group`.Номер, Фамилия,Имя, Отчество, program.name, КолЧас, ДатаКЗ, ДатаВыдачиСвид 
                    FROM (group_list INNER JOIN students On group_list.students = students.Снилс) 
                    INNER JOIN `group` 
                        ON group_list.Kod = `group`.Код
                    LEFT JOIN program
                        ON kod_program=program.kod
                    WHERE  `group`.ОсновнойДокумент= 'Свидетельство' AND NOT ISNULL(group_list.РегНомерСвид) AND group_list.РегНомерСвид<>0 AND ДатаВыдачиСвид BETWEEN '" & dateStart & "' and  '" & dateEnd & " '  and ОсновнойДокумент= 'Свидетельство' ORDER BY group_list.РегНомерСвид"

        Return sqlString

    End Function

    Public Function accountingBook__loadListDip(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT group_list.РегНомерДиплома, group_list.НомерДиплома,`group`.Номер, Фамилия,Имя, Отчество, program.name, КолЧас, ДатаКЗ, ДатаВыдачиДиплома 
                    FROM (group_list INNER JOIN students On group_list.students = students.Снилс) 
                    INNER JOIN `group` 
                        ON group_list.Kod = `group`.Код 
                    LEFT JOIN program
                        ON kod_program=program.kod
                    WHERE `group`.ОсновнойДокумент= 'Диплом' AND NOT ISNULL(group_list.РегНомерДиплома) AND group_list.РегНомерДиплома<>0 AND group_list.РегНомерДиплома<>0 AND ДатаВыдачиДиплома BETWEEN '" & dateStart & "' and  '" & dateEnd & " '  and ОсновнойДокумент= 'Диплом' ORDER BY group_list.РегНомерДиплома"

        Return sqlString

    End Function

    Public Function accountingBook__loadListUd(dateStart As String, dateEnd As String) As String

        sqlString = "SELECT  group_list.РегНомерУд, group_list.НомерУд,`group`.Номер, Фамилия,Имя, Отчество, program.name, КолЧас, ДатаКЗ, ДатаВыдачиУд FROM (group_list INNER JOIN students On group_list.students = students.Снилс) INNER JOIN `group` On group_list.Kod = `group`.Код 
                     LEFT JOIN program
                      ON kod_program=program.kod
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

    Public Function formList__loadList(name As String) As String

        sqlString = "SELECT * FROM " + tableIdentificated.nameTable(name)

        Return sqlString

    End Function

    Public Function formList__loadPrograms() As String

        sqlString = "SELECT name, date, kod FROM program ORDER BY name"

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
                      program.name,
                      `group`.Спец
                    FROM (group_list
                      INNER JOIN students
                        ON group_list.students = students.Снилс
                      INNER JOIN `group`
                        ON group_list.kod = `group`.Код
                      LEFT JOIN program 
                      ON `group`.kod_program = program.kod
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
                      program.name,
                      `group`.ДатаНЗ  
                    FROM `group`
                      INNER JOIN program
                        ON `group`.kod_program = program.kod 
                    WHERE Код =" & kodGroup

        Return sqlString

    End Function

    Public Function blanki_loadProgram(kodGroup) As String

        sqlString = "SELECT
                      program.name
                    FROM `group`
                      INNER JOIN program
                        ON `group`.kod_program = program.kod 
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
                    FROM worker_report
                      INNER JOIN (SELECT
                          `group`.Код,
                          Номер
                        FROM `group`
                        WHERE `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "') groupTbl
                        ON worker_report.kod = groupTbl.Код
                      INNER JOIN worker
                        ON worker_report.worker = worker.kod
                      WHERE worker.kod=" + kodWorker + "
                      GROUP BY groupTbl.Код
                      ORDER BY groupTbl.Номер"

        Return sqlString

    End Function

    Public Function pednagrExtended__loadListWorker(DateStart As String, DateEnd As String) As String

        sqlString = "SELECT
                      worker.kod,
                      name
                    FROM worker_report
                      INNER JOIN (SELECT
                          `group`.Код,
                          Номер
                        FROM `group`
                        WHERE `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "') groupTbl
                        ON worker_report.kod = groupTbl.Код
                      INNER JOIN worker
                        ON worker_report.worker = worker.kod
                      GROUP BY worker"

        Return sqlString

    End Function

    Public Function workerReportLoad(DateStart As String, DateEnd As String) As String

        sqlString = " SELECT
                      ПреподавательСписокВнебюджет,
                      СуммаЧасовБ,
                      СуммаЧасовВБ
                    FROM (SELECT
                        worker.name AS ПреподавательСписокВнебюджет,
                        IFNULL(СуммаЧасовВБ,0) AS СуммаЧасовВБ
                      FROM worker
                        LEFT JOIN (SELECT
                            worker_report.worker AS Преподаватель1,
                            SUM(IFNULL(worker_report.lectures,0)
                              + IFNULL(worker_report.practical,0)
                              + IFNULL(worker_report.stimulating,0)
                              + IFNULL(worker_report.consultation,0)
                              + IFNULL(PA,0)
                              + IFNULL(IA,0)
                            ) AS СуммаЧасовВБ
                          FROM worker_report
                            INNER JOIN `group`
                              ON `group`.Код = worker_report.kod
                          WHERE `group`.Финансирование = 'внебюджет'
                          AND `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "'
                          GROUP BY worker_report.worker) AS Внебюджет
                          ON Внебюджет.Преподаватель1 = worker.kod) AS СводВнебюджет
                      INNER JOIN (SELECT
                          worker.name AS ПреподавательСписокБюджет,
                          IFNULL(СуммаЧасовБ,0) AS СуммаЧасовБ
                        FROM worker
                          LEFT JOIN (SELECT
                              worker_report.worker AS Преподаватель1,
                              SUM(IFNULL(worker_report.lectures,0)
                                + IFNULL(worker_report.practical,0)
                                + IFNULL(worker_report.stimulating,0)
                                + IFNULL(worker_report.consultation,0)
                                + IFNULL(PA,0)
                                + IFNULL(IA,0)
                            ) AS СуммаЧасовБ
                            FROM worker_report
                              INNER JOIN `group`
                                ON `group`.Код = worker_report.kod
                            WHERE `group`.Финансирование = 'бюджет'
                            AND `group`.ДатаНЗ BETWEEN '" + DateStart + "' AND '" + DateEnd + "'
                            GROUP BY worker_report.worker) AS Бюджет
                            ON Бюджет.Преподаватель1 = worker.kod) AS СводБюджет
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
            Warning.content.Text = "Неверно указан номер последнего столбца таблицы"
            Warning.ShowDialog()
            Exit Sub
        End If

        If Not UBound(massTypes, 2) = numberLastColumn - numberFirstColumn Then
            Warning.content.Text = "Неверно указаны имена столбцов"
            Warning.ShowDialog()
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

                        sqlStringSecondPart += "(SELECT kod FROM worker WHERE worker.name=" + Chr(39) & dataGridTbl.Rows(i).Cells(numberFirstColumn + счетчикСтолбцов).Value & Chr(39) & " LIMIT 1 ), "

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

    Public Function wr__loadProgram(kodGroup As String) As String

        sqlString = "SELECT
                      'Программа' As Показатель,
                      program.name As Значение
                    FROM `group`
                      INNER JOIN program
                        ON `group`.kod_program = program.kod
                    WHERE Код= " & kodGroup

        Return sqlString

    End Function
    Public Function wr__loadModulsAndHours(kodGroup As String) As String

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
                     WHERE program.kod = (SELECT group.kod_program FROM `group` WHERE Код= " + kodGroup + " LIMIT 1)
                     ORDER BY modul_number"

        Return sqlString

    End Function

    Public Function wr__loadHours(kodGroup As String) As String

        sqlString = "SELECT * FROM
                    (
                    SELECT
                      type_class.name As Показатель,
                      progs_type_hours.hours As Значение,
                      '' As Введено,
                      '' As Остаток
                    FROM progs_type_hours
                      INNER JOIN type_class
                        ON progs_type_hours.type = type_class.kod
                      INNER JOIN `group`
                        ON progs_type_hours.kod_prog = `group`.kod_program
                    WHERE `group`.Код =" & kodGroup + "
                    ORDER BY number
                    ) AS types"

        Return sqlString

    End Function

    Public Function workerReport__load(kodGroup As String) As String

        sqlString = " SELECT
                      worker.name,
                      worker_report.lectures,
                      worker_report.practical,
                      worker_report.stimulating,
                      worker_report.consultation,
                      worker_report.PA,
                      worker_report.IA
                    FROM worker_report
                      INNER JOIN worker
                        ON worker_report.worker = worker.kod
                        WHERE worker_report.kod= " & kodGroup & " ORDER BY worker.name"

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

    Public Function SqlString__insertSlush(structSlushatel As strStudent)

        Dim part1, part2, part3 As String

        part1 = "(Снилс, Фамилия, Имя, Отчество, ДатаРождения, Пол, УОбразования, doo_doc_type, НаимДОО, СерияДОО, НомерДОО, ФамилияДОО, АРег, Телефон, Гражданство, ДУЛ, СерияДУЛ, НомерДУЛ,ДатаРегистрации, Почта, ДУЛКемВыдан,ДУЛДатаВыдачи ) "

        part2 = "(" & Chr(39) & structSlushatel.snils & Chr(39) & ",
                 " & Chr(39) & structSlushatel.lastName & Chr(39) & ",
                 " & Chr(39) & structSlushatel.name & Chr(39) & ",
                 " & Chr(39) & structSlushatel.secondName & Chr(39) & ",
                 " & Chr(39) & structSlushatel.birthDay & Chr(39) & ",
                 " & Chr(39) & structSlushatel.gender & Chr(39) & ",
                 " & Chr(39) & structSlushatel.educationLevel & Chr(39) & "
                 ,(SELECT MAX(kod) FROM doo_doc_type WHERE name=
                 " & Chr(39) & structSlushatel.doo_doc_type & Chr(39) & "
                 LIMIT 1) ," & Chr(39) & structSlushatel.education & Chr(39) & "
                 ," & Chr(39) & structSlushatel.seriesDOO & Chr(39) & "
                 ," & Chr(39) & structSlushatel.numberDOO & Chr(39) & "
                 ," & Chr(39) & structSlushatel.lastNameDOO & Chr(39) & "
                 ," & Chr(39) & structSlushatel.adress & Chr(39) & "
                 ," & Chr(39) & structSlushatel.telephone & Chr(39) & "
                 ," & Chr(39) & structSlushatel.citizenship & Chr(39) & "
                 ," & Chr(39) & structSlushatel.dUL & Chr(39) & "
                 ," & Chr(39) & structSlushatel.seriesDUL & Chr(39) & "
                 ," & Chr(39) & structSlushatel.numberDUL & Chr(39)

        part3 = "," & Chr(39) & structSlushatel.dateReg & Chr(39) & "
                , " & Chr(39) & structSlushatel.email & Chr(39) & "
                , " & Chr(39) & structSlushatel.autorDUL & Chr(39) & ","

        If structSlushatel.dateDUL = "null" Then
            part3 += "null)"
        Else part3 += Chr(39) & structSlushatel.dateDUL & Chr(39) & " ) "
        End If

        sqlString = "INSERT INTO students " & part1 & "  VALUES " & part2 & part3

        Return sqlString

    End Function

    Public Function SqlString__updateSlush(structSlushatel As strStudent)

        Dim part1 As String, part2 As String, part3 As String, part4 As String

        part1 = "Снилс=" & Chr(39) & structSlushatel.snils & Chr(39) & ", Фамилия=" & Chr(39) & structSlushatel.secondName & Chr(39) & ", Имя=" & Chr(39) & structSlushatel.name & Chr(39) & ", Отчество=" & Chr(39) & structSlushatel.lastName & Chr(39) & ", ДатаРождения=" & Chr(39) & structSlushatel.birthDay & Chr(39) & ", Пол=" & Chr(39) & structSlushatel.gender & Chr(39)

        part2 = ", УОбразования=" & Chr(39) & structSlushatel.educationLevel & Chr(39) & ", doo_doc_type= (SELECT kod FROM doo_doc_type WHERE name=" & Chr(39) & structSlushatel.doo_doc_type & Chr(39) & " LIMIT 1), НаимДОО=" & Chr(39) & structSlushatel.education & Chr(39) & ", СерияДОО=" & Chr(39) & structSlushatel.seriesDOO & Chr(39) & ", НомерДОО=" & Chr(39) & structSlushatel.numberDOO & Chr(39) & ", ФамилияДОО=" & Chr(39) & structSlushatel.lastNameDOO & Chr(39)

        part3 = ",АРег=" & Chr(39) & structSlushatel.adress & Chr(39) & ", Телефон=" & Chr(39) & structSlushatel.telephone & Chr(39) & ", Гражданство=" & Chr(39) & structSlushatel.citizenship & Chr(39) & ", ДУЛ=" & Chr(39) & structSlushatel.dUL & Chr(39) & ", СерияДУЛ=" & Chr(39) & structSlushatel.seriesDUL & Chr(39) & ", НомерДУЛ=" & Chr(39) & structSlushatel.numberDUL & Chr(39)

        part4 = ", ДатаРегистрации=" & Chr(39) & structSlushatel.dateReg & Chr(39) & ", Почта=" & Chr(39) & structSlushatel.email & Chr(39) & ", ДУЛКемВыдан=" & Chr(39) & structSlushatel.autorDUL & Chr(39)

        If structSlushatel.dateDUL = "null" Then
            part4 += ", ДУЛДатаВыдачи=null"
        Else
            part4 += ", ДУЛДатаВыдачи=" & Chr(39) & structSlushatel.dateDUL & Chr(39)
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

    Public Function updateOrgAndFinEveryone(groupNumber As String, currentFinancing As String, currentOrganization As String)

        sqlString = "UPDATE group_list
                    SET organization = (SELECT
                            kod
                          FROM napr_organization
                          WHERE name = '" + currentOrganization + "' LIMIT 1),
                        source_financing = (SELECT
                            kod
                          FROM fin_source
                          WHERE name = '" + currentFinancing + "' LIMIT 1)
                    WHERE Kod=" + groupNumber

        Return sqlString

    End Function

    Public Function loadFinancing()

        sqlString = "SELECT name FROM fin_source ORDER BY name"

        Return sqlString

    End Function

    Public Function loadOrganization()

        sqlString = "SELECT name FROM napr_organization ORDER BY name"

        Return sqlString

    End Function

    Public Function loadIstFinans()

        sqlString = "SELECT name FROM fin_source ORDER BY kod"

        Return sqlString

    End Function

    Public Function loadDokUL()

        sqlString = "SELECT name FROM doc_ul ORDER BY kod"

        Return sqlString

    End Function

    Public Function loadNationality()

        sqlString = "SELECT name FROM nationality ORDER BY kod"

        Return sqlString

    End Function

    Public Function loadDooCountry()

        sqlString = "SELECT name FROM DOO_country ORDER BY kod"

        Return sqlString

    End Function

    Public Function loadDooVidDok()

        sqlString = "SELECT name FROM doo_doc_type ORDER BY name"

        Return sqlString

    End Function
    Public Function loadUrovenObr()

        sqlString = "SELECT name FROM education_level ORDER BY kod"

        Return sqlString

    End Function
    Public Function loadGender()

        sqlString = "SELECT gender FROM gender ORDER BY kod"

        Return sqlString

    End Function

    Public Function load_prepod() As String

        sqlString = "SELECT name FROM worker WHERE in_list=1"

        Return sqlString

    End Function

    Public Function load_studentsAndOrg(kodGroup As String) As String

        sqlString = "SELECT
                      result.student,
                      napr_organization.name AS organization,
                      fin_source.name AS financing
                    FROM (SELECT
                        CONCAT(students.Фамилия, ' ', students.Имя, ' ', IFNULL(students.Отчество, ' ')) AS student,
                        group_list.organization,
                        group_list.source_financing
                      FROM group_list
                        INNER JOIN students
                          ON group_list.students = students.Снилс
                      WHERE group_list.kod = " & kodGroup & "
                      ORDER BY students.Фамилия) AS result
                      LEFT JOIN napr_organization
                        ON result.organization = napr_organization.kod
                      LEFT JOIN fin_source
                        ON result.source_financing = fin_source.kod
                    ORDER BY result.student"

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
                      students.ДатаРегистрации,
                      students.Почта,
                      students.СтранаДОО,
                      students.ДУЛКемВыдан,
                      students.ДУЛДатаВыдачи,
                      doo_doc_type.name AS vid_doo
                    FROM students
                      LEFT JOIN doo_doc_type
                        ON students.doo_doc_type=doo_doc_type.kod
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
                                  program.name,
                                  ДатаВыдачиДиплома,
                                  ДатаНЗ,
                                  ДатаКЗ,
                                  КолЧас,
                                  Квалификация,
                                  НомерПротоколаИА,
                                  worker.name AS Куратор
                                FROM (group_list
                                  INNER JOIN students
                                    ON group_list.students = students.Снилс)
                                  INNER JOIN `group`
                                    ON group_list.kod = `group`.Код
                                      LEFT JOIN worker
                                    ON worker.kod = Куратор
                                      LEFT JOIN program
                                    ON program.kod = kod_program
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
                                  program.name,
                                  ДатаВыдачиУд,
                                  ДатаНЗ,
                                  ДатаКЗ,
                                  КолЧас,
                                  Квалификация,
                                  НомерПротоколаИА,
                                  worker.name AS Куратор
                                FROM (group_list
                                  INNER JOIN students
                                    ON group_list.students = students.Снилс)
                                  INNER JOIN `group`
                                    ON group_list.kod = `group`.Код
                                  LEFT JOIN worker
                                    ON worker.kod=Куратор
                                  LEFT JOIN program
                                    ON program.kod = kod_program
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
                                      program.name,
                                      ДатаВыдачиСвид,
                                      ДатаНЗ,
                                      ДатаКЗ,
                                      КолЧас,
                                      Квалификация,
                                      НомерПротоколаИА,
                                      worker.name AS Куратор
                                    FROM (group_list
                                      INNER JOIN students
                                        ON group_list.students = students.Снилс)
                                      INNER JOIN `group`
                                        ON group_list.kod = `group`.Код
                                      LEFT JOIN worker
                                        ON worker.kod = Куратор
                                      LEFT JOIN program
                                        ON program.kod = kod_program
                                WHERE `group`.Код = " + kod + "
                                ORDER BY students.Фамилия"
        Return sqlString

    End Function

    Public Function load_prog_kurator(kod As String) As String

        sqlString = " SELECT
                                      program.name,
                                      worker.name
                                    FROM (SELECT
                                        `group`.kod_program,
                                        `group`.Куратор
                                      FROM `group`
                                      WHERE Код =" + kod + ") AS gr
                                      LEFT JOIN worker
                                        ON gr.Куратор = kod
                                      LEFT JOIN program
                                        ON gr.kod_program = program.kod"
        Return sqlString

    End Function

    Public Function load_spr_group(ur_kval As String, sort As String, Optional year As String = "0") As String

        sort = sort.Replace("Программа", "program.name")

        sqlString = ""

        sqlString = "SELECT
                      tbl1.Код,
                      tbl1.Номер,
                      program.name,
                      worker.name,
                      tbl1.ДатаНЗ,
                      tbl1.ДатаКЗ
                    FROM (SELECT
                        `group`.Код,
                        `group`.Номер,
                        `group`.kod_program AS prog,
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
                    LEFT JOIN worker
                        ON Куратор=kod
                    LEFT JOIN program
                        ON tbl1.prog = program.kod
                    ORDER BY " + sort

        Return sqlString

    End Function

    Public Function formList__loadGroup(ur_kval As String, sort As String, col_search As String, text As String, Optional year As String = "0") As String

        col_search = col_search.Replace("Программа", "tbl1.program")

        sqlString = ""

        sqlString = "SELECT
                    tbl1.Код,
                    tbl1.Номер,
                    tbl1.program AS Программа,
                    name As Куратор,
                    tbl1.ДатаНЗ,
                    tbl1.ДатаКЗ
                    FROM
                    (SELECT
                      Код,
                      Номер,
                      program.name as program,
                      worker.name,
                      ДатаНЗ,
                      ДатаКЗ,
                      Спец,
                      Квалификация,
                      Финансирование
                    FROM `group`
                    LEFT JOIN program
                      ON `group`.kod_program=program.kod
                    LEFT JOIN
                        worker
                    ON Куратор=worker.kod
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

        col_search = col_search.Replace("Программа", "program.name")

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
                      program.name AS Программа,
                      worker.name As Куратор,
                      ДатаНЗ,
                      ДатаКЗ,
                      Спец,
                      Квалификация,
                      Финансирование
                    FROM `group`
                    LEFT JOIN program
                      ON `group`.kod_program=program.kod
                    LEFT JOIN
                        worker
                    ON Куратор=worker.kod
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
                               ON progs_mods_hours.kod_prog = `group`.kod_program
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
                      INNER JOIN program
                        ON progs_mods_hours.kod_prog = program.kod
                      INNER JOIN `group`
                        ON `group`.kod_program = program.kod
                    WHERE `group`.Код = " + kod_group

        Return sqlString

    End Function

    Public Function selectSpravka_moduls_hours(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      moduls.name,
                      progs_mods_hours.hours
                    FROM `group`
                      INNER JOIN program
                        ON `group`.kod_program = program.kod
                      INNER JOIN progs_mods_hours
                        ON progs_mods_hours.kod_prog = program.kod
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                    WHERE `group`.Код =" + kod_group + " AND moduls.name <> 'Итоговая аттестация'
                    ORDER BY modul_number"

        Return sqlString

    End Function

    Public Function selectSpravkaIA_group(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      program.name,
                      skill_level.name_padej,
                      Финансирование,
                      ДатаНЗ,
                      ДатаКЗ,
                      КолЧас
                    FROM `group`
                      INNER JOIN skill_level
                        ON `group`.УровеньКвалификации = skill_level.name
                      LEFT JOIN program
                        ON `group`.kod_program = program.kod
                    WHERE `group`.Код =" + kod_group

        Return sqlString

    End Function
    Public Function spravka__groupData(kod_group As String) As String

        sqlString = ""

        sqlString = "SELECT
                      program.name,
                      skill_level.name_padej,
                      Финансирование,
                      ДатаНЗ,
                      ДатаКЗ
                    FROM `group`
                      INNER JOIN skill_level
                        ON `group`.УровеньКвалификации = skill_level.name
                      LEFT JOIN program
                        ON `group`.kod_program = program.kod
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
                      program.name,
                      skill_level.name_padej,
                      Финансирование,
                      ДатаКЗ
                    FROM `group`
                      INNER JOIN skill_level
                        ON `group`.УровеньКвалификации = skill_level.name
                        LEFT JOIN program 
                        ON `group`.kod_program = program.kod
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
                      program.name,
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
                    worker AS s0
                        ON s0.kod=Куратор
                    LEFT JOIN
                    worker AS s00
                        ON s00.kod=ОтвЗаПракт
                    LEFT JOIN worker AS s1
                        ON gr.modul1 = s1.kod
                    LEFT JOIN worker AS s2
                        ON gr.modul2 = s2.kod
                    LEFT JOIN worker AS s3
                        ON gr.modul3 = s3.kod
                    LEFT JOIN worker AS s4
                        ON gr.modul4 = s4.kod
                    LEFT JOIN worker AS s5
                        ON gr.modul5 = s5.kod
                    LEFT JOIN worker AS s6
                        ON gr.modul6 = s6.kod
                    LEFT JOIN worker AS s7
                        ON gr.modul7 = s7.kod
                    LEFT JOIN worker AS s8
                        ON gr.modul8 = s8.kod
                    LEFT JOIN worker AS s9
                        ON gr.modul9 = s9.kod
                    LEFT JOIN worker AS s10
                        ON gr.modul10 = s10.kod
                    LEFT JOIN program
                        ON gr.kod_program = program.kod"

        Return sqlString

    End Function

    Public Function selectNumberHours() As String

        sqlString = ""

        sqlString = "Select * FROM number_hours "

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
                      program.name,
                      `group`.КолЧас,
                      `group`.НомерДиплома,
                      `group`.РегНомерДиплома,
                      `group`.ДатаВыдачиДиплома,
                      `group`.УровеньКвалификации
                    FROM progs_mods_hours
                      INNER JOIN moduls
                        ON progs_mods_hours.kod_modul = moduls.kod
                      CROSS JOIN `group`
                      INNER JOIN program
                        ON `group`.kod_program = program.kod
                        AND progs_mods_hours.kod_prog = program.kod
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
                      program.name,
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
                      INNER JOIN program
                        ON `group`.kod_program = program.kod
                        AND progs_mods_hours.kod_prog = program.kod
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
                                  program.name AS Программа,
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
                                  gr.kod_program

                                FROM (SELECT
                                    *
                                  FROM `group`
                                  WHERE Код = " + kod_gr + ") AS gr
                                  LEFT JOIN worker AS s0
                                    ON gr.Куратор = s0.kod
                                  LEFT JOIN worker AS s00
                                    ON gr.ОтвЗаПракт = s00.kod
                                  LEFT JOIN worker AS s1
                                    ON gr.modul1 = s1.kod
                                  LEFT JOIN worker AS s2
                                    ON gr.modul2 = s2.kod
                                  LEFT JOIN worker AS s3
                                    ON gr.modul3 = s3.kod
                                  LEFT JOIN worker AS s4
                                    ON gr.modul4 = s4.kod
                                  LEFT JOIN worker AS s5
                                    ON gr.modul5 = s5.kod
                                  LEFT JOIN worker AS s6
                                    ON gr.modul6 = s6.kod
                                  LEFT JOIN worker AS s7
                                    ON gr.modul7 = s7.kod
                                  LEFT JOIN worker AS s8
                                    ON gr.modul8 = s8.kod
                                  LEFT JOIN worker AS s9
                                    ON gr.modul9 = s9.kod
                                  LEFT JOIN worker AS s10
                                    ON gr.modul10 = s10.kod
                                  LEFT JOIN program
                                    ON gr.kod_program = program.kod"

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
                                        ON gr.kod_program = progs_mods_hours.kod_prog
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
                                      INNER JOIN worker AS s1
                                        ON `group`.modul1 = s1.kod
                                      LEFT JOIN worker AS s2
                                        ON `group`.modul2 = s2.kod
                                      LEFT JOIN worker AS s3
                                        ON `group`.modul3 = s3.kod
                                      LEFT JOIN worker AS s4
                                        ON `group`.modul4 = s4.kod
                                      LEFT JOIN worker AS s5
                                        ON `group`.modul5 = s5.kod
                                      LEFT JOIN worker AS s6
                                        ON `group`.modul6 = s6.kod
                                      LEFT JOIN worker AS s7
                                        ON `group`.modul7 = s7.kod
                                      LEFT JOIN worker AS s8
                                        ON `group`.modul8 = s8.kod
                                      LEFT JOIN worker AS s9
                                        ON `group`.modul9 = s9.kod
                                      LEFT JOIN worker AS s10
                                        ON `group`.modul10 = s10.kod
                                        WHERE `group`.Код=" + kod_gr
        Return sqlString

    End Function

    Public Function SQLString_managerOrder(dateStart As String, dateEnd As String)

        sqlString = "CALL managerOrder('" + dateStart + "','" + dateEnd + "')"

        Return sqlString

    End Function

    Public Function SQLString_OtchetRMANPO(dateStart As String, dateEnd As String)

        sqlString = "CALL orderRMANPO('" + dateStart + "','" + dateEnd + "')"
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
                    "        IFNULL(program.name, '') AS Программа,
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
                          program
                          ON tblGroup.kod_program=program.kod
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


    Public Function SQLString_organizationOrder(dateStart As String, dateEnd As String)

        sqlString = " CALL organizationOrder('" + dateStart + "','" + dateEnd + "')"

        Return sqlString

    End Function

    Public Function SQLString_OtchetBud_Vbud(dateStart As String, dateEnd As String, argument As String)

        Select Case argument
            Case "полный"
                sqlString = "CALL VBOrder_full('" + dateStart + "','" + dateEnd + "')"
            Case "внебюджет"
                sqlString = "CALL VBOrder_partial('" + dateStart + "','" + dateEnd + "','Платное обучение')"
            Case "бюджет"
                sqlString = "CALL VBOrder_partial('" + dateStart + "','" + dateEnd + "','Федеральный бюджет')"
        End Select

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

        Select Case sortColumn

            Case "snils"
                sortColumn = "Снилс"

            Case "nameStudent"
                sortColumn = "Имя"

            Case "secName"
                sortColumn = "Фамилия"

        End Select

        Select Case searchColumn
            Case "Куратор"
                searchColumn = "name"
        End Select


        sortColumn += interfaceMod.sortType(sortSettsStudents.sortSetts.flagSortUp)

        If nameTable = "Группа" Or nameTable = "`group`" Then

            If includeUK Then
                sqlString = load_spr_group_search(GroupList.swichCvalification.activeType, sortColumn, searchColumn, searchValue, GroupList.yearSpravochnikGr.Text)
            Else
                sqlString = formList__loadGroup(GroupList.swichCvalification.activeType, sortColumn, searchColumn, searchValue, GroupList.yearSpravochnikGr.Text)
            End If

        Else

            sqlString = "SELECT " & nameColumns & " FROM " & nameTable & " WHERE  (((" & searchColumn & ") LIKE " & Chr(39) & searchValue & "%" & Chr(39) & " )) ORDER BY " & sortColumn

        End If

        ChMass = MainForm.mySqlConnect.loadMySqlToArray(sqlString, 1)
        ChMass = arrayMethod.removeEmpty(ChMass)

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
                      program.name as Программа,
                      YEAR(ДатаНЗ),
                      Код
                    FROM `group`
                    LEFT JOIN 
                    program ON `group`.kod_program = program.kod
                    WHERE Номер <> ''
                    AND ДатаКЗ >'" & MainForm.mySqlConnect.dateToFormatMySQL(Date.Now.AddMonths(-6)) & "'"

        If includeUK Then

            If MainForm.orderCvalif = MainForm.PP Then
                sqlString &= " AND УровеньКвалификации = 'профессиональная переподготовка'"
            ElseIf MainForm.orderCvalif = MainForm.PK Then
                sqlString &= " AND УровеньКвалификации = 'повышение квалификации'"
            ElseIf MainForm.orderCvalif = MainForm.PO Then
                sqlString &= " AND УровеньКвалификации = 'профессиональное обучение'"
            ElseIf MainForm.orderCvalif = MainForm.PK_PP Then
                sqlString &= " AND (УровеньКвалификации = 'профессиональная переподготовка' OR УровеньКвалификации = 'повышение квалификации')"
            End If

        End If

        If Not nameSearchColumn = "None" Then

            sqlString &= " AND " + nameSearchColumn + " LIKE "
            If valInApostrophes Then
                sqlString += "'" + searchValue + "%'"
            Else
                sqlString += searchValue
            End If

        End If

        If List.sortColumn <> -1 Then

            If (List.resultList.Columns(List.sortColumn).Text = "Группа" Or List.resultList.Columns(List.sortColumn).Text = "Номер") And MainForm.orderCvalif = MainForm.PK Then
                sqlString &= " ORDER BY Номер"
                If List.sort = List.poUb Then
                    sqlString &= " DESC"
                End If
            Else
                sqlString &= " ORDER BY program.name"
            End If
        Else
            sqlString &= " ORDER BY program.name"
        End If



        Return sqlString

    End Function

    Public Function ProgramPoUKvalifikLimit1(UrovenKvalifik As String)

        sqlString = ""

        If UrovenKvalifik = "" Then

            sqlString = "SELECT 
                            name 
                        FROM program 
                        GROUP BY program.name 
                        ORDER BY name"

        Else
            sqlString = " SELECT
                           program.name,
                            MAX(date),
                            MAX(program.kod)
                                 FROM
                         (SELECT 
                         skill_level.kod
                                From skill_level
                             WHERE skill_level.name = '" + UrovenKvalifik + "'
                             ) AS tbl1
                           INNER JOIN program
                             ON tbl1.kod = program.skill_level
                          GROUP BY program.name
                         ORDER BY name"
        End If

        Return sqlString

    End Function

    Public Function ProgramPoUKvalifik(UrovenKvalifik As String, Optional text As String = "no")

        sqlString = ""

        If UrovenKvalifik = "" Then
            sqlString = "SELECT name,date,kod FROM program ORDER BY name"
        Else
            sqlString = " SELECT" +
                          " program.name,
                            date,
                            program.kod
                                FROM
                         (SELECT 
                         skill_level.kod
                               FROM skill_level
                             WHERE skill_level.name = '" + UrovenKvalifik + "'
                             ) AS tbl1
                           INNER Join program
                             On tbl1.kod = program.skill_level"
            If Not text = "no" Then
                sqlString += " WHERE name LIKE '" + text + "%'"
            End If
            sqlString += " ORDER BY name"
        End If
        Return sqlString

    End Function


    Public Function SQLString_OtchetMassDataSlush(DateNach As String, DateKon As String)

        sqlString = ""

        sqlString = " SELECT
                          students.Код,
                          students.Снилс,
                          students.Фамилия,
                          students.Отчество,
                          students.Имя,
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
                          tbl1.financing,
                          students.ДатаРегистрации
                        FROM (SELECT
                            group_list.students,
                            name AS financing
                          FROM `group`
                            INNER JOIN group_list
                              ON `group`.Код = group_list.kod
                            LEFT JOIN financing
                              ON group_list.source_financing = financing.kod" +
                          " WHERE `group`.ДатаКЗ BETWEEN '" + DateNach + "' And '" + DateKon + "'" +
                          " ) AS tbl1
                          INNER JOIN students
                            ON tbl1.students = students.Снилс"

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
                      Номер as 'Номер группы',
                      program.name as Программа,
                      ДатаНЗ as 'Дата начала',
                      ДатаКЗ as 'Дата окончания'
                    FROM `group`
                      INNER JOIN group_list
                        ON `group`.Код = group_list.kod
                      LEFT JOIN program 
                        ON `group`.kod_program=program.kod
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
            ", Спец=" & Chr(39) & gruppa.speciality & Chr(39) &
            ",kod_program=" & gruppa.kodProgram &
            ",КолЧас=" & numberHours & ", Куратор=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.kurator & Chr(39) & " LIMIT 1)" &
            ", ОтвЗаПракт=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.otvZaPraktiku & Chr(39) & " LIMIT 1)" &
            ", датаСоздания=" & Chr(39) & dataString & Chr(39)

        part2 = ", modul1=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul1 & Chr(39) & " LIMIT 1), modul2=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul2 & Chr(39) & " LIMIT 1)
            , modul3=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul3 & Chr(39) & " LIMIT 1), modul4=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul4 & Chr(39) & " LIMIT 1)
            , modul5=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul5 & Chr(39) & " LIMIT 1), modul6=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul6 & Chr(39) & " LIMIT 1)
            , modul7=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul7 & Chr(39) & " LIMIT 1), modul8=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul8 & Chr(39) & " LIMIT 1)
            , modul9=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul9 & Chr(39) & " LIMIT 1), modul10=(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul10 & Chr(39) & " LIMIT 1)"

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
            ", Квалификация=" & Chr(39) & gruppa.qualification & Chr(39) & ", ОсновнойДокумент=" & Chr(39) & gruppa.mainDocument & Chr(39)

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
        part2 = part2 & " , " & Chr(39) & gruppa.dataKZ & Chr(39) & " , " & Chr(39) & gruppa.speciality & Chr(39)

        part1 = part1 & "kod_program,КолЧас,"
        part2 = part2 & " , " & gruppa.kodProgram & " , " & gruppa.kolChasov

        part1 = part1 & "Куратор,ОтвЗаПракт,"
        part2 = part2 & " , (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.kurator & Chr(39) & " LIMIT 1) ,(SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.otvZaPraktiku & Chr(39) & "  LIMIT 1)"

        part1 = part1 & "датаСоздания, modul1,"
        part2 = part2 & " , " & Chr(39) & DataString & Chr(39) & " , (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul1 & Chr(39) & " LIMIT 1)"

        part1 = part1 & "modul2,modul3,"
        part2 = part2 & " , (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul2 & Chr(39) & " LIMIT 1) , (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul3 & Chr(39) & " LIMIT 1)"

        part1 = part1 & "modul4,modul5,modul6,modul7,modul8,modul9,modul10,"
        part2 = part2 & " , (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul4 & Chr(39) & " LIMIT 1) , (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul5 & Chr(39) & " LIMIT 1), (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul6 & Chr(39) & " LIMIT 1), (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul7 & Chr(39) & " LIMIT 1), (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul8 & Chr(39) & " LIMIT 1), (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul9 & Chr(39) & " LIMIT 1), (SELECT worker.kod FROM worker WHERE name=" & Chr(39) & gruppa.modul10 & Chr(39) & " LIMIT 1)"

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
        part2 &= " , " & Chr(39) & gruppa.qualification & Chr(39) & " , " & Chr(39) & gruppa.mainDocument & Chr(39) + ")"

        sqlString = "INSERT INTO `group` " & part1 & "  VALUES " & part2

        Return sqlString

    End Function

    Public Function updateSlushatel(studentData As Student.strStudent) As String

        Dim sqlString As String = ""

        sqlString = "Снилс=" & Chr(39) & studentData.snils & Chr(39) &
            ", Фамилия=" & Chr(39) & studentData.lastName & Chr(39) &
            ", Имя=" & Chr(39) & studentData.name & Chr(39) &
            ", Отчество=" & Chr(39) & studentData.secondName & Chr(39) &
            ", ДатаРождения=" & Chr(39) & studentData.birthDay & Chr(39) &
            ", Пол=" & Chr(39) & studentData.gender & Chr(39) &
            ", УОбразования=" & Chr(39) & studentData.educationLevel & Chr(39) &
            ", НаимДОО=" & Chr(39) & studentData.education & Chr(39) &
            ", СерияДОО=" & Chr(39) & studentData.seriesDOO & Chr(39) &
            ", НомерДОО=" & Chr(39) & studentData.numberDOO & Chr(39) &
            ", ФамилияДОО=" & Chr(39) & studentData.lastNameDOO & Chr(39) &
            ",АРег=" & Chr(39) & studentData.adress & Chr(39) &
            ", Телефон=" & Chr(39) & studentData.telephone & Chr(39) &
            ", Гражданство=" & Chr(39) & studentData.citizenship & Chr(39) &
            ", ДУЛ=" & Chr(39) & studentData.dUL & Chr(39) &
            ", СерияДУЛ=" & Chr(39) & studentData.seriesDUL & Chr(39) &
            ", НомерДУЛ=" & Chr(39) & studentData.numberDUL & Chr(39) &
            ", ДатаРегистрации=" & Chr(39) & studentData.dateReg & Chr(39) &
            ", Почта=" & Chr(39) & studentData.email & Chr(39) &
            ", ДУЛКемВыдан=" & Chr(39) & studentData.autorDUL & Chr(39)

        If studentData.dateDUL = "null" Or studentData.dateDUL.Trim = "" Then
            sqlString += ", ДУЛДатаВыдачи=" + studentData.dateDUL
        Else
            sqlString += ", ДУЛДатаВыдачи=" & Chr(39) & studentData.dateDUL & Chr(39)
        End If

        sqlString += ", doo_doc_type=(SELECT MAX(kod) FROM doo_doc_type WHERE name = '" & studentData.doo_doc_type & "' LIMIT 1)"


        sqlString = "UPDATE students SET " & sqlString & " WHERE Снилс =" & Chr(39) & studentData.prevSnils & Chr(39)

        Return sqlString

    End Function


    Public Function insertIntoSlushatel(slushatel As Student.strStudent) As String

        Dim part1, part2 As String
        Dim sqlString, ДатаВыдачиДул As String

        sqlString = ""


        part1 = "(Снилс,"
        part2 = "(" & Chr(39) & addMask.deleteMask(slushatel.snils) & Chr(39)
        part1 = +"Фамилия, Имя, Отчество,"
        part2 = +"," & Chr(39) & slushatel.secondName & Chr(39) & "," & Chr(39) & slushatel.name & Chr(39) & "," & Chr(39) & slushatel.lastName & Chr(39)
        part1 = +"ДатаРождения, Пол, УОбразования,"
        part2 = +"," & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.birthDay) & Chr(39) & "," & Chr(39) & slushatel.gender & Chr(39) & "," & Chr(39) & slushatel.educationLevel & Chr(39)
        part1 = +"НаимДОО, СерияДОО, НомерДОО,"
        part2 = +"," & Chr(39) & slushatel.education & Chr(39) & "," & Chr(39) & slushatel.seriesDOO & Chr(39) & "," & Chr(39) & slushatel.numberDOO & Chr(39) &
        part1 = +"ФамилияДОО, АРег, Телефон,"
        part2 = +"," & Chr(39) & slushatel.lastNameDOO & Chr(39) & "," & Chr(39) & slushatel.adress & Chr(39) & "," & Chr(39) & slushatel.telephone & Chr(39) &
        part1 = +"Гражданство, ДУЛ, СерияДУЛ, НомерДУЛ,"
        part2 = +"," & Chr(39) & slushatel.citizenship & Chr(39) & "," & Chr(39) & slushatel.dUL & Chr(39) & "," & Chr(39) & slushatel.seriesDUL & Chr(39) & "," & Chr(39) & slushatel.numberDUL & Chr(39)
        part1 = +" ДатаРегистрации, Почта,"
        part2 = +" , " & Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.dateReg) & Chr(39) & " , " & Chr(39) & slushatel.email & Chr(39) &
        part1 = +"ДУЛКемВыдан,ДУЛДатаВыдачи ) "
        part2 = +", " & Chr(39) & slushatel.autorDUL & Chr(39) & ", "

        If slushatel.dateDUL = "null" Then
            part2 += ДатаВыдачиДул & " ) "
        Else part2 += Chr(39) & MainForm.mySqlConnect.dateToFormatMySQL(slushatel.dateDUL) & Chr(39) & " ) "
        End If


        sqlString = "INSERT INTO students " & part1 & "  VALUES " & part2
        Return sqlString

    End Function


End Module
