<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GradesIA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GradesIA))
        Me.ЗагрузитьИнформацию = New System.Windows.Forms.Button()
        Me.resultTable = New System.Windows.Forms.DataGridView()
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.save = New System.Windows.Forms.ToolStripButton()
        Me.groupNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.Номер = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ФИО = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ИАТест = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ИАПрактНав = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ИАИтог = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.resultTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        Me.SuspendLayout()
        '
        'ЗагрузитьИнформацию
        '
        Me.ЗагрузитьИнформацию.BackColor = System.Drawing.Color.Transparent
        Me.ЗагрузитьИнформацию.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ЗагрузитьИнформацию.FlatAppearance.BorderSize = 0
        Me.ЗагрузитьИнформацию.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ЗагрузитьИнформацию.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ЗагрузитьИнформацию.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ЗагрузитьИнформацию.Location = New System.Drawing.Point(42, 376)
        Me.ЗагрузитьИнформацию.Name = "ЗагрузитьИнформацию"
        Me.ЗагрузитьИнформацию.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ЗагрузитьИнформацию.Size = New System.Drawing.Size(200, 50)
        Me.ЗагрузитьИнформацию.TabIndex = 7
        Me.ЗагрузитьИнформацию.Text = "Загрузить"
        Me.ЗагрузитьИнформацию.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ЗагрузитьИнформацию.UseVisualStyleBackColor = False
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
        Me.resultTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Номер, Me.ФИО, Me.ИАТест, Me.ИАПрактНав, Me.ИАИтог})
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
        Me.resultTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.resultTable.Location = New System.Drawing.Point(0, 51)
        Me.resultTable.MultiSelect = False
        Me.resultTable.Name = "resultTable"
        Me.resultTable.RowHeadersVisible = False
        Me.resultTable.Size = New System.Drawing.Size(1378, 786)
        Me.resultTable.TabIndex = 9
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
        Me.header.Size = New System.Drawing.Size(1378, 51)
        Me.header.TabIndex = 22
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
        Me.ФИО.Width = 300
        '
        'ИАТест
        '
        Me.ИАТест.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ИАТест.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ИАТест.HeaderText = "ИА тестирование"
        Me.ИАТест.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", "зачтено", "незачтено"})
        Me.ИАТест.Name = "ИАТест"
        Me.ИАТест.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ИАТест.Width = 200
        '
        'ИАПрактНав
        '
        Me.ИАПрактНав.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ИАПрактНав.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ИАПрактНав.HeaderText = "ИА практ. навыки"
        Me.ИАПрактНав.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", "зачтено", "незачтено"})
        Me.ИАПрактНав.Name = "ИАПрактНав"
        Me.ИАПрактНав.Width = 200
        '
        'ИАИтог
        '
        Me.ИАИтог.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ИАИтог.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ИАИтог.HeaderText = "ИА итог"
        Me.ИАИтог.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", "зачтено", "незачтено"})
        Me.ИАИтог.Name = "ИАИтог"
        Me.ИАИтог.Width = 200
        '
        'GradesIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1378, 837)
        Me.Controls.Add(Me.resultTable)
        Me.Controls.Add(Me.ЗагрузитьИнформацию)
        Me.Controls.Add(Me.header)
        Me.KeyPreview = True
        Me.Name = "GradesIA"
        Me.Text = "Оценки ИА"
        CType(Me.resultTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ЗагрузитьИнформацию As Button
    Friend WithEvents resultTable As DataGridView
    Friend WithEvents header As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Private WithEvents save As ToolStripButton
    Friend WithEvents groupNumber As ToolStripTextBox
    Friend WithEvents Номер As DataGridViewTextBoxColumn
    Friend WithEvents ФИО As DataGridViewTextBoxColumn
    Friend WithEvents ИАТест As DataGridViewComboBoxColumn
    Friend WithEvents ИАПрактНав As DataGridViewComboBoxColumn
    Friend WithEvents ИАИтог As DataGridViewComboBoxColumn
End Class
