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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ЗагрузитьИнформацию = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.groupNumber = New System.Windows.Forms.TextBox()
        Me.iaTAble = New System.Windows.Forms.DataGridView()
        Me.Номер = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ФИО = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ИАТест = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ИАПрактНав = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ИАИтог = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Сохранить = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.iaTAble, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(-2, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 21)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Группа"
        '
        'groupNumber
        '
        Me.groupNumber.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.groupNumber.Location = New System.Drawing.Point(69, 18)
        Me.groupNumber.Name = "groupNumber"
        Me.groupNumber.ReadOnly = True
        Me.groupNumber.Size = New System.Drawing.Size(406, 29)
        Me.groupNumber.TabIndex = 6
        '
        'ТаблицаОценкиИА
        '
        Me.iaTAble.AllowUserToAddRows = False
        Me.iaTAble.AllowUserToDeleteRows = False
        Me.iaTAble.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iaTAble.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.iaTAble.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.iaTAble.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.iaTAble.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.iaTAble.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Номер, Me.ФИО, Me.ИАТест, Me.ИАПрактНав, Me.ИАИтог})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.iaTAble.DefaultCellStyle = DataGridViewCellStyle4
        Me.iaTAble.Location = New System.Drawing.Point(2, 62)
        Me.iaTAble.Name = "ТаблицаОценкиИА"
        Me.iaTAble.RowHeadersVisible = False
        Me.iaTAble.Size = New System.Drawing.Size(1373, 774)
        Me.iaTAble.TabIndex = 9
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
        'Сохранить
        '
        Me.Сохранить.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Сохранить.BackColor = System.Drawing.Color.Transparent
        Me.Сохранить.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Сохранить.FlatAppearance.BorderSize = 0
        Me.Сохранить.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Сохранить.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Сохранить.Location = New System.Drawing.Point(1207, 17)
        Me.Сохранить.Name = "Сохранить"
        Me.Сохранить.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Сохранить.Size = New System.Drawing.Size(166, 31)
        Me.Сохранить.TabIndex = 10
        Me.Сохранить.Text = "Сохранить"
        Me.Сохранить.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Сохранить.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(683, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GradesIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1378, 837)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Сохранить)
        Me.Controls.Add(Me.iaTAble)
        Me.Controls.Add(Me.ЗагрузитьИнформацию)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.groupNumber)
        Me.KeyPreview = True
        Me.Name = "GradesIA"
        Me.Text = "Оценки ИА"
        CType(Me.iaTAble, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ЗагрузитьИнформацию As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents groupNumber As TextBox
    Friend WithEvents iaTAble As DataGridView
    Friend WithEvents Сохранить As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Номер As DataGridViewTextBoxColumn
    Friend WithEvents ФИО As DataGridViewTextBoxColumn
    Friend WithEvents ИАТест As DataGridViewComboBoxColumn
    Friend WithEvents ИАПрактНав As DataGridViewComboBoxColumn
    Friend WithEvents ИАИтог As DataGridViewComboBoxColumn
End Class
