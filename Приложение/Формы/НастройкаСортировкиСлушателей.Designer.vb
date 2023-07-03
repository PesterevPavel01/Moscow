<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class НастройкаСортировкиСлушателей
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(НастройкаСортировкиСлушателей))
        Me.Имя = New System.Windows.Forms.CheckBox()
        Me.Фамилия = New System.Windows.Forms.CheckBox()
        Me.Снилс = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ПоВозростанию = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ПоВозростанию, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Имя
        '
        Me.Имя.AutoSize = True
        Me.Имя.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Имя.Location = New System.Drawing.Point(12, 44)
        Me.Имя.Name = "Имя"
        Me.Имя.Size = New System.Drawing.Size(51, 19)
        Me.Имя.TabIndex = 5
        Me.Имя.Text = "Имя"
        Me.Имя.UseVisualStyleBackColor = True
        '
        'Фамилия
        '
        Me.Фамилия.AutoSize = True
        Me.Фамилия.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Фамилия.Location = New System.Drawing.Point(12, 28)
        Me.Фамилия.Name = "Фамилия"
        Me.Фамилия.Size = New System.Drawing.Size(81, 19)
        Me.Фамилия.TabIndex = 4
        Me.Фамилия.Text = "Фамилия"
        Me.Фамилия.UseVisualStyleBackColor = True
        '
        'Снилс
        '
        Me.Снилс.AutoSize = True
        Me.Снилс.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Снилс.Location = New System.Drawing.Point(12, 12)
        Me.Снилс.Name = "Снилс"
        Me.Снилс.Size = New System.Drawing.Size(61, 19)
        Me.Снилс.TabIndex = 3
        Me.Снилс.Text = "Снилс"
        Me.Снилс.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(312, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 37)
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
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
        Me.ПоВозростанию.TabIndex = 21
        Me.ПоВозростанию.TabStop = False
        '
        'НастройкаСортировкиСлушателей
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 81)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ПоВозростанию)
        Me.Controls.Add(Me.Имя)
        Me.Controls.Add(Me.Фамилия)
        Me.Controls.Add(Me.Снилс)
        Me.Name = "НастройкаСортировкиСлушателей"
        Me.Text = "Выбор поля для сортировки"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ПоВозростанию, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Имя As CheckBox
    Friend WithEvents Фамилия As CheckBox
    Friend WithEvents Снилс As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ПоВозростанию As PictureBox
End Class
