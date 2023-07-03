<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class АОценкиИА
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
        Me.ЗагрузитьИнформацию = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.НомерГруппы = New System.Windows.Forms.TextBox()
        Me.ТаблицаОценкиИА = New System.Windows.Forms.DataGridView()
        Me.Номер = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ФИО = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ИАТест = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ИАПрактНав = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ИАИтог = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Сохранить = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.ТаблицаОценкиИА, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Группа"
        '
        'НомерГруппы
        '
        Me.НомерГруппы.Location = New System.Drawing.Point(52, 11)
        Me.НомерГруппы.Name = "НомерГруппы"
        Me.НомерГруппы.ReadOnly = True
        Me.НомерГруппы.Size = New System.Drawing.Size(294, 20)
        Me.НомерГруппы.TabIndex = 6
        '
        'ТаблицаОценкиИА
        '
        Me.ТаблицаОценкиИА.AllowUserToAddRows = False
        Me.ТаблицаОценкиИА.AllowUserToDeleteRows = False
        Me.ТаблицаОценкиИА.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ТаблицаОценкиИА.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ТаблицаОценкиИА.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ТаблицаОценкиИА.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Номер, Me.ФИО, Me.ИАТест, Me.ИАПрактНав, Me.ИАИтог})
        Me.ТаблицаОценкиИА.Location = New System.Drawing.Point(2, 41)
        Me.ТаблицаОценкиИА.Name = "ТаблицаОценкиИА"
        Me.ТаблицаОценкиИА.Size = New System.Drawing.Size(726, 795)
        Me.ТаблицаОценкиИА.TabIndex = 9
        '
        'Номер
        '
        Me.Номер.HeaderText = "Номер"
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
        'ИАТест
        '
        Me.ИАТест.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ИАТест.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ИАТест.HeaderText = "ИА тестирование"
        Me.ИАТест.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", "зачтено", "незачтено"})
        Me.ИАТест.Name = "ИАТест"
        Me.ИАТест.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ИАТест.Width = 120
        '
        'ИАПрактНав
        '
        Me.ИАПрактНав.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ИАПрактНав.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ИАПрактНав.HeaderText = "ИА практ. навыки"
        Me.ИАПрактНав.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", "зачтено", "незачтено"})
        Me.ИАПрактНав.Name = "ИАПрактНав"
        Me.ИАПрактНав.Width = 120
        '
        'ИАИтог
        '
        Me.ИАИтог.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ИАИтог.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ИАИтог.HeaderText = "ИА итог"
        Me.ИАИтог.Items.AddRange(New Object() {"отлично", "хорошо", "удовл.", "неудовл.", "зачтено", "незачтено"})
        Me.ИАИтог.Name = "ИАИтог"
        Me.ИАИтог.Width = 120
        '
        'Сохранить
        '
        Me.Сохранить.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Сохранить.BackColor = System.Drawing.Color.Transparent
        Me.Сохранить.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Сохранить.FlatAppearance.BorderSize = 0
        Me.Сохранить.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Сохранить.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Сохранить.Location = New System.Drawing.Point(562, 4)
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
        Me.Button1.Location = New System.Drawing.Point(388, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'АОценкиИА
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 837)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Сохранить)
        Me.Controls.Add(Me.ТаблицаОценкиИА)
        Me.Controls.Add(Me.ЗагрузитьИнформацию)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.НомерГруппы)
        Me.KeyPreview = True
        Me.Name = "АОценкиИА"
        Me.Text = "Оценки ИА"
        CType(Me.ТаблицаОценкиИА, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ЗагрузитьИнформацию As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents НомерГруппы As TextBox
    Friend WithEvents ТаблицаОценкиИА As DataGridView
    Friend WithEvents Сохранить As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Номер As DataGridViewTextBoxColumn
    Friend WithEvents ФИО As DataGridViewTextBoxColumn
    Friend WithEvents ИАТест As DataGridViewComboBoxColumn
    Friend WithEvents ИАПрактНав As DataGridViewComboBoxColumn
    Friend WithEvents ИАИтог As DataGridViewComboBoxColumn
End Class
