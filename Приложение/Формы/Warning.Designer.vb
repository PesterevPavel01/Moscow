<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Warning
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
        Me.Ok = New System.Windows.Forms.Button()
        Me.content = New System.Windows.Forms.Label()
        Me.TextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Ok
        '
        Me.Ok.Location = New System.Drawing.Point(12, 100)
        Me.Ok.Name = "Ok"
        Me.Ok.Size = New System.Drawing.Size(437, 35)
        Me.Ok.TabIndex = 0
        Me.Ok.Text = "Ok"
        Me.Ok.UseVisualStyleBackColor = True
        '
        'текст
        '
        Me.content.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.content.Location = New System.Drawing.Point(0, -1)
        Me.content.Name = "текст"
        Me.content.Size = New System.Drawing.Size(461, 98)
        Me.content.TabIndex = 1
        Me.content.Text = "Необходимо заполнить все обязательные поля!"
        Me.content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox
        '
        Me.TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBox.Location = New System.Drawing.Point(12, 3)
        Me.TextBox.Multiline = True
        Me.TextBox.Name = "TextBox"
        Me.TextBox.ReadOnly = True
        Me.TextBox.Size = New System.Drawing.Size(437, 94)
        Me.TextBox.TabIndex = 165
        Me.TextBox.Visible = False
        '
        'предупреждение
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 141)
        Me.Controls.Add(Me.TextBox)
        Me.Controls.Add(Me.content)
        Me.Controls.Add(Me.Ok)
        Me.Name = "предупреждение"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Внимание"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Ok As Button
    Friend WithEvents content As Label
    Friend WithEvents TextBox As TextBox
End Class
