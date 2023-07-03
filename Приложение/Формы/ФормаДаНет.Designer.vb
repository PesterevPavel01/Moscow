<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ФормаДаНет
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
        Me.КнопкаДа = New System.Windows.Forms.Button()
        Me.КнопкаНет = New System.Windows.Forms.Button()
        Me.ТекстДаНет = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'КнопкаДа
        '
        Me.КнопкаДа.FlatAppearance.BorderSize = 0
        Me.КнопкаДа.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнопкаДа.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнопкаДа.Location = New System.Drawing.Point(7, 128)
        Me.КнопкаДа.Name = "КнопкаДа"
        Me.КнопкаДа.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнопкаДа.Size = New System.Drawing.Size(371, 36)
        Me.КнопкаДа.TabIndex = 7
        Me.КнопкаДа.Text = "Да"
        Me.КнопкаДа.UseVisualStyleBackColor = True
        '
        'КнопкаНет
        '
        Me.КнопкаНет.FlatAppearance.BorderSize = 0
        Me.КнопкаНет.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнопкаНет.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнопкаНет.Location = New System.Drawing.Point(384, 128)
        Me.КнопкаНет.Name = "КнопкаНет"
        Me.КнопкаНет.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнопкаНет.Size = New System.Drawing.Size(389, 36)
        Me.КнопкаНет.TabIndex = 8
        Me.КнопкаНет.Text = "Нет"
        Me.КнопкаНет.UseVisualStyleBackColor = True
        '
        'ТекстДаНет
        '
        Me.ТекстДаНет.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ТекстДаНет.Location = New System.Drawing.Point(4, -1)
        Me.ТекстДаНет.Name = "ТекстДаНет"
        Me.ТекстДаНет.Size = New System.Drawing.Size(784, 93)
        Me.ТекстДаНет.TabIndex = 9
        Me.ТекстДаНет.Text = "Такая запись уже найдена. Заменить информацию в базе?"
        Me.ТекстДаНет.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ФормаДаНет
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 166)
        Me.Controls.Add(Me.ТекстДаНет)
        Me.Controls.Add(Me.КнопкаНет)
        Me.Controls.Add(Me.КнопкаДа)
        Me.KeyPreview = True
        Me.Name = "ФормаДаНет"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Совпадение"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents КнопкаДа As Button
    Friend WithEvents КнопкаНет As Button
    Friend WithEvents ТекстДаНет As Label
End Class
