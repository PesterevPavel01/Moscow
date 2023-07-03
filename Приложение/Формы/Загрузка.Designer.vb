<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Загрузка
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Выполнение = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Приложение загружается"
        '
        'Выполнение
        '
        Me.Выполнение.Location = New System.Drawing.Point(2, 12)
        Me.Выполнение.Name = "Выполнение"
        Me.Выполнение.Size = New System.Drawing.Size(303, 11)
        Me.Выполнение.TabIndex = 130
        '
        'Загрузка
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 144)
        Me.Controls.Add(Me.Выполнение)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Загрузка"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Система учета"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Выполнение As ProgressBar
End Class
