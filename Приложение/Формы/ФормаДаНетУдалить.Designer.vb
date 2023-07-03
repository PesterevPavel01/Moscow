<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ФормаДаНетУдалить
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.КнопкаНет = New System.Windows.Forms.Button()
        Me.КнопкаДа = New System.Windows.Forms.Button()
        Me.текстДаНет = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'КнопкаНет
        '
        Me.КнопкаНет.FlatAppearance.BorderSize = 0
        Me.КнопкаНет.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнопкаНет.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнопкаНет.Location = New System.Drawing.Point(252, 78)
        Me.КнопкаНет.Name = "КнопкаНет"
        Me.КнопкаНет.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнопкаНет.Size = New System.Drawing.Size(290, 36)
        Me.КнопкаНет.TabIndex = 11
        Me.КнопкаНет.Text = "Нет"
        Me.КнопкаНет.UseVisualStyleBackColor = True
        '
        'КнопкаДа
        '
        Me.КнопкаДа.FlatAppearance.BorderSize = 0
        Me.КнопкаДа.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнопкаДа.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнопкаДа.Location = New System.Drawing.Point(-3, 78)
        Me.КнопкаДа.Name = "КнопкаДа"
        Me.КнопкаДа.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнопкаДа.Size = New System.Drawing.Size(249, 36)
        Me.КнопкаДа.TabIndex = 10
        Me.КнопкаДа.Text = "Да"
        Me.КнопкаДа.UseVisualStyleBackColor = True
        '
        'текстДаНет
        '
        Me.текстДаНет.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.текстДаНет.Location = New System.Drawing.Point(-6, 9)
        Me.текстДаНет.Name = "текстДаНет"
        Me.текстДаНет.Size = New System.Drawing.Size(548, 66)
        Me.текстДаНет.TabIndex = 12
        Me.текстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"
        Me.текстДаНет.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ФормаДаНетУдалить
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 119)
        Me.Controls.Add(Me.текстДаНет)
        Me.Controls.Add(Me.КнопкаНет)
        Me.Controls.Add(Me.КнопкаДа)
        Me.KeyPreview = True
        Me.Name = "ФормаДаНетУдалить"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Удалить элемент"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents КнопкаНет As Button
    Friend WithEvents КнопкаДа As Button
    Friend WithEvents текстДаНет As Label
End Class
