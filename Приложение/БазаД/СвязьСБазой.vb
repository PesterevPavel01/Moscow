Module СвязьСБазой

    Sub СвязьСБазой(СтрокаЗапроса As String)
        Dim Path As String
        Dim Rs As New ADODB.Recordset
        Dim connDB As New ADODB.Connection


        Path = Запуск.АдрессЛичнойКопииБазы

        connDB = CreateObject("ADODB.Connection")
        connDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;data source= " & Path

        connDB.Open()

        On Error GoTo Oshibka

        Rs = connDB.Execute(СтрокаЗапроса)

        connDB.Close()

        GoTo Konec
Oshibka:

        MsgBox("База данных не найдена, проверьте путь в настройках")

Konec:



    End Sub




End Module
