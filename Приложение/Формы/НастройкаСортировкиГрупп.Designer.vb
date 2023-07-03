<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class НастройкаСортировкиГрупп
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(НастройкаСортировкиГрупп))
        Me.Программа = New System.Windows.Forms.CheckBox()
        Me.Спец = New System.Windows.Forms.CheckBox()
        Me.Номер = New System.Windows.Forms.CheckBox()
        Me.ПоВозростанию = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Куратор = New System.Windows.Forms.CheckBox()
        CType(Me.ПоВозростанию, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Программа
        '
        Me.Программа.AutoSize = True
        Me.Программа.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Программа.Location = New System.Drawing.Point(12, 55)
        Me.Программа.Name = "Программа"
        Me.Программа.Size = New System.Drawing.Size(93, 19)
        Me.Программа.TabIndex = 9
        Me.Программа.Text = "Программа"
        Me.Программа.UseVisualStyleBackColor = True
        '
        'Спец
        '
        Me.Спец.AutoSize = True
        Me.Спец.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Спец.Location = New System.Drawing.Point(12, 30)
        Me.Спец.Name = "Спец"
        Me.Спец.Size = New System.Drawing.Size(117, 19)
        Me.Спец.TabIndex = 8
        Me.Спец.Text = "Специальность"
        Me.Спец.UseVisualStyleBackColor = True
        '
        'Номер
        '
        Me.Номер.AutoSize = True
        Me.Номер.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Номер.Location = New System.Drawing.Point(12, 5)
        Me.Номер.Name = "Номер"
        Me.Номер.Size = New System.Drawing.Size(65, 19)
        Me.Номер.TabIndex = 7
        Me.Номер.Text = "Номер"
        Me.Номер.UseVisualStyleBackColor = True
        '
        'ПоВозростанию
        '
        Me.ПоВозростанию.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ПоВозростанию.ErrorImage = Nothing
        Me.ПоВозростанию.Image = CType(resources.GetObject("ПоВозростанию.Image"), System.Drawing.Image)
        Me.ПоВозростанию.InitialImage = Nothing
        Me.ПоВозростанию.Location = New System.Drawing.Point(355, 12)
        Me.ПоВозростанию.Name = "ПоВозростанию"
        Me.ПоВозростанию.Size = New System.Drawing.Size(37, 37)
        Me.ПоВозростанию.TabIndex = 19
        Me.ПоВозростанию.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(312, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 37)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Куратор
        '
        Me.Куратор.AutoSize = True
        Me.Куратор.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Куратор.Location = New System.Drawing.Point(12, 80)
        Me.Куратор.Name = "Куратор"
        Me.Куратор.Size = New System.Drawing.Size(74, 19)
        Me.Куратор.TabIndex = 21
        Me.Куратор.Text = "Куратор"
        Me.Куратор.UseVisualStyleBackColor = True
        '
        'НастройкаСортировкиГрупп
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 102)
        Me.Controls.Add(Me.Куратор)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ПоВозростанию)
        Me.Controls.Add(Me.Программа)
        Me.Controls.Add(Me.Спец)
        Me.Controls.Add(Me.Номер)
        Me.Name = "НастройкаСортировкиГрупп"
        Me.Text = "Выбор поля для сортировки"
        CType(Me.ПоВозростанию, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Программа As CheckBox
    Friend WithEvents Спец As CheckBox
    Friend WithEvents Номер As CheckBox
    Friend WithEvents ПоВозростанию As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Куратор As CheckBox
End Class
