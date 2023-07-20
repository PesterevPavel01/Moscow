﻿Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' Для MyApplication имеются следующие события:
    ' Startup: возникает при запуске приложения перед созданием начальной формы.
    ' Shutdown: возникает после закрытия всех форм приложения.  Это событие не создается, если происходит аварийное завершение работы приложения.
    ' UnhandledException: возникает, если в приложении обнаруживается необработанное исключение.
    ' StartupNextInstance: возникает при запуске приложения, допускающего одновременное выполнение только одного экземпляра, если это приложение уже активно. 
    ' NetworkAvailabilityChanged: возникает при изменении состояния подключения — при подключении или отключении.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

            Запуск.ЗапускПриложения()

        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown


        End Sub

    End Class
End Namespace
