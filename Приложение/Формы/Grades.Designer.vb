<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Grades
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Grades))
        Me.resultTable = New System.Windows.Forms.DataGridView()
        Me.Номер = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ФИО = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Модуль1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль5 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль8 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль9 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Модуль10 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.save = New System.Windows.Forms.ToolStripButton()
        Me.groupNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.resultTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        Me.SuspendLayout()
        '
        'resultTable
        '
        Me.resultTable.AllowUserToAddRows = False
        Me.resultTable.AllowUserToDeleteRows = False
        Me.resultTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.resultTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.resultTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.resultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.resultTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Номер, Me.ФИО, Me.Модуль1, Me.Модуль2, Me.Модуль3, Me.Модуль4, Me.Модуль5, Me.Модуль6, Me.Модуль7, Me.Модуль8, Me.Модуль9, Me.Модуль10})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.resultTable.DefaultCellStyle = DataGridViewCellStyle2
        Me.resultTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.resultTable.Location = New System.Drawing.Point(0, 51)
        Me.resultTable.Name = "resultTable"
        Me.resultTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.resultTable.RowHeadersVisible = False
        Me.resultTable.Size = New System.Drawing.Size(1729, 776)
        Me.resultTable.TabIndex = 4
        '
        'Номер
        '
        Me.Номер.HeaderText = "№"
        Me.Номер.Name = "Номер"
        Me.Номер.ReadOnly = True
        Me.Номер.Width = 50
        '
        'ФИО
        '
        Me.ФИО.HeaderText = "ФИО"
        Me.ФИО.Name = "ФИО"
        Me.ФИО.ReadOnly = True
        Me.ФИО.Width = 250
        '
        'Модуль1
        '
        Me.Модуль1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль1.HeaderText = "Модуль1"
        Me.Модуль1.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль1.Name = "Модуль1"
        Me.Модуль1.Width = 120
        '
        'Модуль2
        '
        Me.Модуль2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль2.HeaderText = "Модуль2"
        Me.Модуль2.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль2.Name = "Модуль2"
        '
        'Модуль3
        '
        Me.Модуль3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль3.HeaderText = "Модуль3"
        Me.Модуль3.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль3.Name = "Модуль3"
        '
        'Модуль4
        '
        Me.Модуль4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль4.HeaderText = "Модуль4"
        Me.Модуль4.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль4.Name = "Модуль4"
        '
        'Модуль5
        '
        Me.Модуль5.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль5.HeaderText = "Модуль5"
        Me.Модуль5.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль5.Name = "Модуль5"
        '
        'Модуль6
        '
        Me.Модуль6.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль6.HeaderText = "Модуль6"
        Me.Модуль6.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль6.Name = "Модуль6"
        '
        'Модуль7
        '
        Me.Модуль7.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль7.HeaderText = "Модуль7"
        Me.Модуль7.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль7.Name = "Модуль7"
        '
        'Модуль8
        '
        Me.Модуль8.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль8.HeaderText = "Модуль8"
        Me.Модуль8.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль8.Name = "Модуль8"
        '
        'Модуль9
        '
        Me.Модуль9.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль9.HeaderText = "Модуль9"
        Me.Модуль9.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль9.Name = "Модуль9"
        '
        'Модуль10
        '
        Me.Модуль10.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Модуль10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Модуль10.HeaderText = "Модуль10"
        Me.Модуль10.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", " ", "зачтено", "незачтено"})
        Me.Модуль10.Name = "Модуль10"
        Me.Модуль10.Width = 110
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(54, 288)
        Me.Button2.Name = "Button2"
        Me.Button2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button2.Size = New System.Drawing.Size(291, 41)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Загрузить ведомость"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'header
        '
        Me.header.AutoSize = False
        Me.header.BackColor = System.Drawing.SystemColors.ControlLight
        Me.header.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.header.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.save, Me.groupNumber})
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Padding = New System.Windows.Forms.Padding(0)
        Me.header.Size = New System.Drawing.Size(1729, 51)
        Me.header.TabIndex = 21
        Me.header.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(65, 48)
        Me.ToolStripLabel1.Text = "Группа"
        '
        'save
        '
        Me.save.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.save.AutoSize = False
        Me.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.save.Image = CType(resources.GetObject("save.Image"), System.Drawing.Image)
        Me.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(48, 48)
        Me.save.Text = "toolStripButton2"
        '
        'groupNumber
        '
        Me.groupNumber.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.groupNumber.Name = "groupNumber"
        Me.groupNumber.Size = New System.Drawing.Size(380, 51)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(459, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Grades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1729, 827)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.resultTable)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.header)
        Me.KeyPreview = True
        Me.Name = "Grades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ведомость"
        CType(Me.resultTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents resultTable As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Номер As DataGridViewTextBoxColumn
    Friend WithEvents ФИО As DataGridViewTextBoxColumn
    Friend WithEvents Модуль1 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль2 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль3 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль4 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль5 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль6 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль7 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль8 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль9 As DataGridViewComboBoxColumn
    Friend WithEvents Модуль10 As DataGridViewComboBoxColumn
    Friend WithEvents header As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Private WithEvents save As ToolStripButton
    Friend WithEvents groupNumber As ToolStripTextBox
    Friend WithEvents Button1 As Button
End Class
