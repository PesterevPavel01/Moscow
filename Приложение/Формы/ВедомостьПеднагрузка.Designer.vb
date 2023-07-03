<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ВедомостьПеднагрузка
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Группа = New System.Windows.Forms.TextBox()
        Me.ТаблицаВедомость = New System.Windows.Forms.DataGridView()
        Me.ФИО = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Лекции = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Практические = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Стимулирующие = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Консультация = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ПА = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ИА = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Итого = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.НомерГруппы = New System.Windows.Forms.TextBox()
        Me.ПодписьИтого = New System.Windows.Forms.TextBox()
        Me.ИтогоЛекции = New System.Windows.Forms.TextBox()
        Me.ИтогоПрактические = New System.Windows.Forms.TextBox()
        Me.ИтогоСтимулирующие = New System.Windows.Forms.TextBox()
        Me.ИтогоКонсультация = New System.Windows.Forms.TextBox()
        Me.ИтогоПА = New System.Windows.Forms.TextBox()
        Me.ИтогоИА = New System.Windows.Forms.TextBox()
        Me.ИтогоИтого = New System.Windows.Forms.TextBox()
        Me.Сохранить = New System.Windows.Forms.Button()
        CType(Me.ТаблицаВедомость, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(-280, -132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Группа"
        '
        'Группа
        '
        Me.Группа.Location = New System.Drawing.Point(-228, -133)
        Me.Группа.Name = "Группа"
        Me.Группа.Size = New System.Drawing.Size(294, 20)
        Me.Группа.TabIndex = 6
        '
        'ТаблицаВедомость
        '
        Me.ТаблицаВедомость.AllowUserToResizeColumns = False
        Me.ТаблицаВедомость.AllowUserToResizeRows = False
        Me.ТаблицаВедомость.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ТаблицаВедомость.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ТаблицаВедомость.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ТаблицаВедомость.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ФИО, Me.Лекции, Me.Практические, Me.Стимулирующие, Me.Консультация, Me.ПА, Me.ИА, Me.Итого})
        Me.ТаблицаВедомость.Location = New System.Drawing.Point(12, 38)
        Me.ТаблицаВедомость.Name = "ТаблицаВедомость"
        Me.ТаблицаВедомость.Size = New System.Drawing.Size(1158, 516)
        Me.ТаблицаВедомость.TabIndex = 7
        '
        'ФИО
        '
        Me.ФИО.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ФИО.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ФИО.HeaderText = "ФИО"
        Me.ФИО.Name = "ФИО"
        Me.ФИО.Width = 300
        '
        'Лекции
        '
        Me.Лекции.HeaderText = "Лекции"
        Me.Лекции.Name = "Лекции"
        Me.Лекции.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Лекции.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Лекции.Width = 120
        '
        'Практические
        '
        Me.Практические.HeaderText = "Практ. занятия"
        Me.Практические.Name = "Практические"
        Me.Практические.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Практические.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Практические.Width = 120
        '
        'Стимулирующие
        '
        Me.Стимулирующие.HeaderText = "Стимул. занятия"
        Me.Стимулирующие.Name = "Стимулирующие"
        Me.Стимулирующие.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Стимулирующие.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Стимулирующие.Width = 120
        '
        'Консультация
        '
        Me.Консультация.HeaderText = "Консультация"
        Me.Консультация.Name = "Консультация"
        Me.Консультация.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Консультация.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Консультация.Width = 120
        '
        'ПА
        '
        Me.ПА.HeaderText = "ПА"
        Me.ПА.Name = "ПА"
        Me.ПА.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ПА.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ИА
        '
        Me.ИА.HeaderText = "ИА"
        Me.ИА.Name = "ИА"
        Me.ИА.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ИА.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Итого
        '
        Me.Итого.HeaderText = "Итого нагрузка"
        Me.Итого.Name = "Итого"
        Me.Итого.ReadOnly = True
        Me.Итого.Width = 120
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Группа"
        '
        'НомерГруппы
        '
        Me.НомерГруппы.Location = New System.Drawing.Point(64, 13)
        Me.НомерГруппы.Name = "НомерГруппы"
        Me.НомерГруппы.ReadOnly = True
        Me.НомерГруппы.Size = New System.Drawing.Size(294, 20)
        Me.НомерГруппы.TabIndex = 9
        '
        'ПодписьИтого
        '
        Me.ПодписьИтого.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ПодписьИтого.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ПодписьИтого.Enabled = False
        Me.ПодписьИтого.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПодписьИтого.Location = New System.Drawing.Point(12, 553)
        Me.ПодписьИтого.Name = "ПодписьИтого"
        Me.ПодписьИтого.Size = New System.Drawing.Size(343, 24)
        Me.ПодписьИтого.TabIndex = 11
        Me.ПодписьИтого.Text = "ИТОГО"
        '
        'ИтогоЛекции
        '
        Me.ИтогоЛекции.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ИтогоЛекции.Enabled = False
        Me.ИтогоЛекции.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтогоЛекции.Location = New System.Drawing.Point(354, 553)
        Me.ИтогоЛекции.Name = "ИтогоЛекции"
        Me.ИтогоЛекции.Size = New System.Drawing.Size(120, 24)
        Me.ИтогоЛекции.TabIndex = 12
        '
        'ИтогоПрактические
        '
        Me.ИтогоПрактические.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ИтогоПрактические.Enabled = False
        Me.ИтогоПрактические.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтогоПрактические.Location = New System.Drawing.Point(473, 553)
        Me.ИтогоПрактические.Name = "ИтогоПрактические"
        Me.ИтогоПрактические.Size = New System.Drawing.Size(120, 24)
        Me.ИтогоПрактические.TabIndex = 13
        '
        'ИтогоСтимулирующие
        '
        Me.ИтогоСтимулирующие.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ИтогоСтимулирующие.Enabled = False
        Me.ИтогоСтимулирующие.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтогоСтимулирующие.Location = New System.Drawing.Point(592, 553)
        Me.ИтогоСтимулирующие.Name = "ИтогоСтимулирующие"
        Me.ИтогоСтимулирующие.Size = New System.Drawing.Size(122, 24)
        Me.ИтогоСтимулирующие.TabIndex = 14
        '
        'ИтогоКонсультация
        '
        Me.ИтогоКонсультация.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ИтогоКонсультация.Enabled = False
        Me.ИтогоКонсультация.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтогоКонсультация.Location = New System.Drawing.Point(713, 553)
        Me.ИтогоКонсультация.Name = "ИтогоКонсультация"
        Me.ИтогоКонсультация.Size = New System.Drawing.Size(122, 24)
        Me.ИтогоКонсультация.TabIndex = 15
        '
        'ИтогоПА
        '
        Me.ИтогоПА.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ИтогоПА.Enabled = False
        Me.ИтогоПА.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтогоПА.Location = New System.Drawing.Point(834, 553)
        Me.ИтогоПА.Name = "ИтогоПА"
        Me.ИтогоПА.Size = New System.Drawing.Size(100, 24)
        Me.ИтогоПА.TabIndex = 16
        '
        'ИтогоИА
        '
        Me.ИтогоИА.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ИтогоИА.Enabled = False
        Me.ИтогоИА.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтогоИА.Location = New System.Drawing.Point(933, 553)
        Me.ИтогоИА.Name = "ИтогоИА"
        Me.ИтогоИА.Size = New System.Drawing.Size(100, 24)
        Me.ИтогоИА.TabIndex = 17
        '
        'ИтогоИтого
        '
        Me.ИтогоИтого.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ИтогоИтого.Enabled = False
        Me.ИтогоИтого.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтогоИтого.Location = New System.Drawing.Point(1032, 553)
        Me.ИтогоИтого.Name = "ИтогоИтого"
        Me.ИтогоИтого.Size = New System.Drawing.Size(126, 24)
        Me.ИтогоИтого.TabIndex = 18
        '
        'Сохранить
        '
        Me.Сохранить.BackColor = System.Drawing.Color.Transparent
        Me.Сохранить.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Сохранить.FlatAppearance.BorderSize = 0
        Me.Сохранить.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Сохранить.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Сохранить.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Сохранить.Location = New System.Drawing.Point(933, 2)
        Me.Сохранить.Name = "Сохранить"
        Me.Сохранить.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Сохранить.Size = New System.Drawing.Size(226, 31)
        Me.Сохранить.TabIndex = 19
        Me.Сохранить.Text = "Сохранить"
        Me.Сохранить.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Сохранить.UseVisualStyleBackColor = False
        '
        'ВедомостьПеднагрузка
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 589)
        Me.Controls.Add(Me.Сохранить)
        Me.Controls.Add(Me.ИтогоИтого)
        Me.Controls.Add(Me.ИтогоИА)
        Me.Controls.Add(Me.ИтогоПА)
        Me.Controls.Add(Me.ИтогоКонсультация)
        Me.Controls.Add(Me.ИтогоСтимулирующие)
        Me.Controls.Add(Me.ИтогоПрактические)
        Me.Controls.Add(Me.ИтогоЛекции)
        Me.Controls.Add(Me.ПодписьИтого)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.НомерГруппы)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Группа)
        Me.Controls.Add(Me.ТаблицаВедомость)
        Me.KeyPreview = True
        Me.Name = "ВедомостьПеднагрузка"
        Me.Text = "Педнагрузка"
        CType(Me.ТаблицаВедомость, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Группа As TextBox
    Friend WithEvents ТаблицаВедомость As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents НомерГруппы As TextBox
    Friend WithEvents ФИО As DataGridViewComboBoxColumn
    Friend WithEvents Лекции As DataGridViewTextBoxColumn
    Friend WithEvents Практические As DataGridViewTextBoxColumn
    Friend WithEvents Стимулирующие As DataGridViewTextBoxColumn
    Friend WithEvents Консультация As DataGridViewTextBoxColumn
    Friend WithEvents ПА As DataGridViewTextBoxColumn
    Friend WithEvents ИА As DataGridViewTextBoxColumn
    Friend WithEvents Итого As DataGridViewTextBoxColumn
    Friend WithEvents ПодписьИтого As TextBox
    Friend WithEvents ИтогоЛекции As TextBox
    Friend WithEvents ИтогоПрактические As TextBox
    Friend WithEvents ИтогоСтимулирующие As TextBox
    Friend WithEvents ИтогоКонсультация As TextBox
    Friend WithEvents ИтогоПА As TextBox
    Friend WithEvents ИтогоИА As TextBox
    Friend WithEvents ИтогоИтого As TextBox
    Friend WithEvents Сохранить As Button
End Class
