<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sortSettsGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sortSettsGroup))
        Me.Программа = New System.Windows.Forms.CheckBox()
        Me.Спец = New System.Windows.Forms.CheckBox()
        Me.Номер = New System.Windows.Forms.CheckBox()
        Me.sortDown = New System.Windows.Forms.PictureBox()
        Me.sortUp = New System.Windows.Forms.PictureBox()
        Me.Куратор = New System.Windows.Forms.CheckBox()
        CType(Me.sortDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sortUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Программа
        '
        Me.Программа.AutoSize = True
        Me.Программа.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Программа.Location = New System.Drawing.Point(12, 46)
        Me.Программа.Name = "Программа"
        Me.Программа.Size = New System.Drawing.Size(120, 25)
        Me.Программа.TabIndex = 9
        Me.Программа.Text = "Программа"
        Me.Программа.UseVisualStyleBackColor = True
        '
        'Спец
        '
        Me.Спец.AutoSize = True
        Me.Спец.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Спец.Location = New System.Drawing.Point(12, 26)
        Me.Спец.Name = "Спец"
        Me.Спец.Size = New System.Drawing.Size(150, 25)
        Me.Спец.TabIndex = 8
        Me.Спец.Text = "Специальность"
        Me.Спец.UseVisualStyleBackColor = True
        '
        'Номер
        '
        Me.Номер.AutoSize = True
        Me.Номер.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Номер.Location = New System.Drawing.Point(12, 5)
        Me.Номер.Name = "Номер"
        Me.Номер.Size = New System.Drawing.Size(82, 25)
        Me.Номер.TabIndex = 7
        Me.Номер.Text = "Номер"
        Me.Номер.UseVisualStyleBackColor = True
        '
        'sortDown
        '
        Me.sortDown.ErrorImage = Nothing
        Me.sortDown.Image = CType(resources.GetObject("sortDown.Image"), System.Drawing.Image)
        Me.sortDown.InitialImage = Nothing
        Me.sortDown.Location = New System.Drawing.Point(371, 10)
        Me.sortDown.Name = "sortDown"
        Me.sortDown.Size = New System.Drawing.Size(41, 41)
        Me.sortDown.TabIndex = 19
        Me.sortDown.TabStop = False
        '
        'sortUp
        '
        Me.sortUp.ErrorImage = Nothing
        Me.sortUp.Image = CType(resources.GetObject("sortUp.Image"), System.Drawing.Image)
        Me.sortUp.InitialImage = Nothing
        Me.sortUp.Location = New System.Drawing.Point(328, 10)
        Me.sortUp.Name = "sortUp"
        Me.sortUp.Size = New System.Drawing.Size(41, 41)
        Me.sortUp.TabIndex = 20
        Me.sortUp.TabStop = False
        '
        'Куратор
        '
        Me.Куратор.AutoSize = True
        Me.Куратор.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Куратор.Location = New System.Drawing.Point(12, 66)
        Me.Куратор.Name = "Куратор"
        Me.Куратор.Size = New System.Drawing.Size(93, 25)
        Me.Куратор.TabIndex = 21
        Me.Куратор.Text = "Куратор"
        Me.Куратор.UseVisualStyleBackColor = True
        '
        'sortSettsGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 102)
        Me.Controls.Add(Me.Куратор)
        Me.Controls.Add(Me.sortUp)
        Me.Controls.Add(Me.sortDown)
        Me.Controls.Add(Me.Программа)
        Me.Controls.Add(Me.Спец)
        Me.Controls.Add(Me.Номер)
        Me.Name = "sortSettsGroup"
        Me.Text = "Выбор поля для сортировки"
        CType(Me.sortDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sortUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Программа As CheckBox
    Friend WithEvents Спец As CheckBox
    Friend WithEvents Номер As CheckBox
    Friend WithEvents sortDown As PictureBox
    Friend WithEvents sortUp As PictureBox
    Friend WithEvents Куратор As CheckBox
End Class
