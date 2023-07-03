Imports System.Threading

Module ЗагрузитьИзБазы

    Public Function ЗагрузитьИзБазы(СтрокаЗапроса As String) As Object


        ЗагрузитьИзБазы = ААОсновная.mySqlConnect.ЗагрузитьИзБДMySQLвМассив(СтрокаЗапроса, 1)

    End Function

End Module
