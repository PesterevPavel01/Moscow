<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class НастройкаПоискаСлушателей
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
        Me.Снилс = New System.Windows.Forms.CheckBox()
        Me.Фамилия = New System.Windows.Forms.CheckBox()
        Me.Имя = New System.Windows.Forms.CheckBox()
        Me.Отчество = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Снилс
        '
        Me.Снилс.AutoSize = True
        Me.Снилс.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Снилс.Location = New System.Drawing.Point(16, 2)
        Me.Снилс.Margin = New System.Windows.Forms.Padding(5)
        Me.Снилс.Name = "Снилс"
        Me.Снилс.Size = New System.Drawing.Size(77, 25)
        Me.Снилс.TabIndex = 0
        Me.Снилс.Text = "Снилс"
        Me.Снилс.UseVisualStyleBackColor = True
        '
        'Фамилия
        '
        Me.Фамилия.AutoSize = True
        Me.Фамилия.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Фамилия.Location = New System.Drawing.Point(16, 32)
        Me.Фамилия.Margin = New System.Windows.Forms.Padding(5)
        Me.Фамилия.Name = "Фамилия"
        Me.Фамилия.Size = New System.Drawing.Size(101, 25)
        Me.Фамилия.TabIndex = 1
        Me.Фамилия.Text = "Фамилия"
        Me.Фамилия.UseVisualStyleBackColor = True
        '
        'Имя
        '
        Me.Имя.AutoSize = True
        Me.Имя.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Имя.Location = New System.Drawing.Point(16, 62)
        Me.Имя.Margin = New System.Windows.Forms.Padding(5)
        Me.Имя.Name = "Имя"
        Me.Имя.Size = New System.Drawing.Size(63, 25)
        Me.Имя.TabIndex = 2
        Me.Имя.Text = "Имя"
        Me.Имя.UseVisualStyleBackColor = True
        '
        'Отчество
        '
        Me.Отчество.AutoSize = True
        Me.Отчество.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Отчество.Location = New System.Drawing.Point(16, 92)
        Me.Отчество.Margin = New System.Windows.Forms.Padding(5)
        Me.Отчество.Name = "Отчество"
        Me.Отчество.Size = New System.Drawing.Size(102, 25)
        Me.Отчество.TabIndex = 3
        Me.Отчество.Text = "Отчество"
        Me.Отчество.UseVisualStyleBackColor = True
        '
        'НастройкаПоискаСлушателей
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 122)
        Me.Controls.Add(Me.Отчество)
        Me.Controls.Add(Me.Имя)
        Me.Controls.Add(Me.Фамилия)
        Me.Controls.Add(Me.Снилс)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "НастройкаПоискаСлушателей"
        Me.Text = "Настройка поиска слушателей"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Снилс As CheckBox
    Friend WithEvents Фамилия As CheckBox
    Friend WithEvents Имя As CheckBox
    Friend WithEvents Отчество As CheckBox
End Class
