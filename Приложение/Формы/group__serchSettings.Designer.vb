<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Group__serchSettings
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
        Me.Программа = New System.Windows.Forms.CheckBox()
        Me.Спец = New System.Windows.Forms.CheckBox()
        Me.Номер = New System.Windows.Forms.CheckBox()
        Me.Куратор = New System.Windows.Forms.CheckBox()
        Me.Квалификация = New System.Windows.Forms.CheckBox()
        Me.Финансирование = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Программа
        '
        Me.Программа.AutoSize = True
        Me.Программа.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Программа.Location = New System.Drawing.Point(16, 44)
        Me.Программа.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Программа.Name = "Программа"
        Me.Программа.Size = New System.Drawing.Size(116, 24)
        Me.Программа.TabIndex = 6
        Me.Программа.Text = "Программа"
        Me.Программа.UseVisualStyleBackColor = True
        '
        'Спец
        '
        Me.Спец.AutoSize = True
        Me.Спец.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Спец.Location = New System.Drawing.Point(16, 23)
        Me.Спец.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Спец.Name = "Спец"
        Me.Спец.Size = New System.Drawing.Size(143, 24)
        Me.Спец.TabIndex = 5
        Me.Спец.Text = "Специальность"
        Me.Спец.UseVisualStyleBackColor = True
        '
        'Номер
        '
        Me.Номер.AutoSize = True
        Me.Номер.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Номер.Location = New System.Drawing.Point(16, 2)
        Me.Номер.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Номер.Name = "Номер"
        Me.Номер.Size = New System.Drawing.Size(81, 24)
        Me.Номер.TabIndex = 4
        Me.Номер.Text = "Номер"
        Me.Номер.UseVisualStyleBackColor = True
        '
        'Куратор
        '
        Me.Куратор.AutoSize = True
        Me.Куратор.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Куратор.Location = New System.Drawing.Point(16, 65)
        Me.Куратор.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Куратор.Name = "Куратор"
        Me.Куратор.Size = New System.Drawing.Size(91, 24)
        Me.Куратор.TabIndex = 8
        Me.Куратор.Text = "Куратор"
        Me.Куратор.UseVisualStyleBackColor = True
        '
        'Квалификация
        '
        Me.Квалификация.AutoSize = True
        Me.Квалификация.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Квалификация.Location = New System.Drawing.Point(16, 86)
        Me.Квалификация.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Квалификация.Name = "Квалификация"
        Me.Квалификация.Size = New System.Drawing.Size(139, 24)
        Me.Квалификация.TabIndex = 9
        Me.Квалификация.Text = "Квалификация"
        Me.Квалификация.UseVisualStyleBackColor = True
        '
        'Финансирование
        '
        Me.Финансирование.AutoSize = True
        Me.Финансирование.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Финансирование.Location = New System.Drawing.Point(16, 107)
        Me.Финансирование.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Финансирование.Name = "Финансирование"
        Me.Финансирование.Size = New System.Drawing.Size(159, 24)
        Me.Финансирование.TabIndex = 10
        Me.Финансирование.Text = "Финансирование"
        Me.Финансирование.UseVisualStyleBackColor = True
        '
        'НастройкаПоискаГрупп
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 132)
        Me.Controls.Add(Me.Финансирование)
        Me.Controls.Add(Me.Квалификация)
        Me.Controls.Add(Me.Куратор)
        Me.Controls.Add(Me.Программа)
        Me.Controls.Add(Me.Спец)
        Me.Controls.Add(Me.Номер)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "НастройкаПоискаГрупп"
        Me.Text = "НастройкаПоискаГрупп"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Программа As CheckBox
    Friend WithEvents Спец As CheckBox
    Friend WithEvents Номер As CheckBox
    Friend WithEvents Куратор As CheckBox
    Friend WithEvents Квалификация As CheckBox
    Friend WithEvents Финансирование As CheckBox
End Class
