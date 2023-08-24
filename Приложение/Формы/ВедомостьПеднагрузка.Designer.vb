<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ВедомостьПеднагрузка
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Группа = New System.Windows.Forms.TextBox()
        Me.pednagr__mainTable = New System.Windows.Forms.DataGridView()
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
        Me.sumLectures = New System.Windows.Forms.TextBox()
        Me.sumPracticals = New System.Windows.Forms.TextBox()
        Me.sumStimul = New System.Windows.Forms.TextBox()
        Me.sumConsultations = New System.Windows.Forms.TextBox()
        Me.sumPA = New System.Windows.Forms.TextBox()
        Me.sumIA = New System.Windows.Forms.TextBox()
        Me.sumResult = New System.Windows.Forms.TextBox()
        Me.Сохранить = New System.Windows.Forms.Button()
        Me.pednagr__splitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.pednagr_splitContainerInfo = New System.Windows.Forms.SplitContainer()
        Me.pednagr__infoTable = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.pednagr__mainTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pednagr__splitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pednagr__splitContainerMain.Panel1.SuspendLayout()
        Me.pednagr__splitContainerMain.Panel2.SuspendLayout()
        Me.pednagr__splitContainerMain.SuspendLayout()
        CType(Me.pednagr_splitContainerInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pednagr_splitContainerInfo.Panel1.SuspendLayout()
        Me.pednagr_splitContainerInfo.Panel2.SuspendLayout()
        Me.pednagr_splitContainerInfo.SuspendLayout()
        CType(Me.pednagr__infoTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(-270, -122)
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
        'pednagr__mainTable
        '
        Me.pednagr__mainTable.AllowUserToResizeColumns = False
        Me.pednagr__mainTable.AllowUserToResizeRows = False
        Me.pednagr__mainTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pednagr__mainTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.pednagr__mainTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pednagr__mainTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.pednagr__mainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pednagr__mainTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ФИО, Me.Лекции, Me.Практические, Me.Стимулирующие, Me.Консультация, Me.ПА, Me.ИА, Me.Итого})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pednagr__mainTable.DefaultCellStyle = DataGridViewCellStyle10
        Me.pednagr__mainTable.Location = New System.Drawing.Point(0, 41)
        Me.pednagr__mainTable.Name = "pednagr__mainTable"
        Me.pednagr__mainTable.RowHeadersVisible = False
        Me.pednagr__mainTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.pednagr__mainTable.Size = New System.Drawing.Size(1235, 767)
        Me.pednagr__mainTable.TabIndex = 7
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
        Me.Консультация.Width = 140
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
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 21)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Группа"
        '
        'НомерГруппы
        '
        Me.НомерГруппы.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.НомерГруппы.Location = New System.Drawing.Point(83, 6)
        Me.НомерГруппы.Name = "НомерГруппы"
        Me.НомерГруппы.ReadOnly = True
        Me.НомерГруппы.Size = New System.Drawing.Size(379, 29)
        Me.НомерГруппы.TabIndex = 9
        '
        'ПодписьИтого
        '
        Me.ПодписьИтого.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ПодписьИтого.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ПодписьИтого.Enabled = False
        Me.ПодписьИтого.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ПодписьИтого.Location = New System.Drawing.Point(0, 807)
        Me.ПодписьИтого.Name = "ПодписьИтого"
        Me.ПодписьИтого.Size = New System.Drawing.Size(300, 29)
        Me.ПодписьИтого.TabIndex = 11
        Me.ПодписьИтого.Text = "ИТОГО"
        '
        'ИтогоЛекции
        '
        Me.sumLectures.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumLectures.Enabled = False
        Me.sumLectures.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumLectures.Location = New System.Drawing.Point(299, 807)
        Me.sumLectures.Name = "ИтогоЛекции"
        Me.sumLectures.Size = New System.Drawing.Size(120, 29)
        Me.sumLectures.TabIndex = 12
        '
        'ИтогоПрактические
        '
        Me.sumPracticals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumPracticals.Enabled = False
        Me.sumPracticals.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sumPracticals.Location = New System.Drawing.Point(418, 807)
        Me.sumPracticals.Name = "ИтогоПрактические"
        Me.sumPracticals.Size = New System.Drawing.Size(120, 29)
        Me.sumPracticals.TabIndex = 13
        '
        'ИтогоСтимулирующие
        '
        Me.sumStimul.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumStimul.Enabled = False
        Me.sumStimul.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumStimul.Location = New System.Drawing.Point(537, 807)
        Me.sumStimul.Name = "ИтогоСтимулирующие"
        Me.sumStimul.Size = New System.Drawing.Size(122, 29)
        Me.sumStimul.TabIndex = 14
        '
        'ИтогоКонсультация
        '
        Me.sumConsultations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumConsultations.Enabled = False
        Me.sumConsultations.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumConsultations.Location = New System.Drawing.Point(658, 807)
        Me.sumConsultations.Name = "ИтогоКонсультация"
        Me.sumConsultations.Size = New System.Drawing.Size(144, 29)
        Me.sumConsultations.TabIndex = 15
        '
        'ИтогоПА
        '
        Me.sumPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumPA.Enabled = False
        Me.sumPA.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumPA.Location = New System.Drawing.Point(799, 807)
        Me.sumPA.Name = "ИтогоПА"
        Me.sumPA.Size = New System.Drawing.Size(100, 29)
        Me.sumPA.TabIndex = 16
        '
        'ИтогоИА
        '
        Me.sumIA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumIA.Enabled = False
        Me.sumIA.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumIA.Location = New System.Drawing.Point(898, 807)
        Me.sumIA.Name = "ИтогоИА"
        Me.sumIA.Size = New System.Drawing.Size(100, 29)
        Me.sumIA.TabIndex = 17
        '
        'ИтогоИтого
        '
        Me.sumResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumResult.Enabled = False
        Me.sumResult.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumResult.Location = New System.Drawing.Point(997, 807)
        Me.sumResult.Name = "ИтогоИтого"
        Me.sumResult.Size = New System.Drawing.Size(126, 29)
        Me.sumResult.TabIndex = 18
        '
        'Сохранить
        '
        Me.Сохранить.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Сохранить.BackColor = System.Drawing.Color.Transparent
        Me.Сохранить.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Сохранить.FlatAppearance.BorderSize = 0
        Me.Сохранить.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Сохранить.Font = New System.Drawing.Font("Microsoft YaHei", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Сохранить.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Сохранить.Location = New System.Drawing.Point(1009, 6)
        Me.Сохранить.Name = "Сохранить"
        Me.Сохранить.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Сохранить.Size = New System.Drawing.Size(226, 31)
        Me.Сохранить.TabIndex = 19
        Me.Сохранить.Text = "Сохранить"
        Me.Сохранить.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Сохранить.UseVisualStyleBackColor = False
        '
        'pednagr__splitContainerMain
        '
        Me.pednagr__splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pednagr__splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.pednagr__splitContainerMain.Location = New System.Drawing.Point(10, 10)
        Me.pednagr__splitContainerMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pednagr__splitContainerMain.Name = "pednagr__splitContainerMain"
        '
        'pednagr__splitContainerMain.Panel1
        '
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.Сохранить)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.НомерГруппы)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.Label1)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.pednagr__mainTable)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumPA)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.ПодписьИтого)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumConsultations)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumLectures)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumStimul)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumPracticals)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumIA)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumResult)
        '
        'pednagr__splitContainerMain.Panel2
        '
        Me.pednagr__splitContainerMain.Panel2.Controls.Add(Me.pednagr_splitContainerInfo)
        Me.pednagr__splitContainerMain.Size = New System.Drawing.Size(1733, 840)
        Me.pednagr__splitContainerMain.SplitterDistance = 1238
        Me.pednagr__splitContainerMain.SplitterWidth = 1
        Me.pednagr__splitContainerMain.TabIndex = 20
        '
        'pednagr_splitContainerInfo
        '
        Me.pednagr_splitContainerInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pednagr_splitContainerInfo.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.pednagr_splitContainerInfo.Location = New System.Drawing.Point(0, 0)
        Me.pednagr_splitContainerInfo.Margin = New System.Windows.Forms.Padding(0)
        Me.pednagr_splitContainerInfo.Name = "pednagr_splitContainerInfo"
        Me.pednagr_splitContainerInfo.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'pednagr_splitContainerInfo.Panel1
        '
        Me.pednagr_splitContainerInfo.Panel1.Controls.Add(Me.pednagr__infoTable)
        '
        'pednagr_splitContainerInfo.Panel2
        '
        Me.pednagr_splitContainerInfo.Panel2.Controls.Add(Me.DataGridView2)
        Me.pednagr_splitContainerInfo.Size = New System.Drawing.Size(494, 840)
        Me.pednagr_splitContainerInfo.SplitterDistance = 357
        Me.pednagr_splitContainerInfo.SplitterWidth = 1
        Me.pednagr_splitContainerInfo.TabIndex = 0
        '
        'pednagr__infoTable
        '
        Me.pednagr__infoTable.AllowUserToAddRows = False
        Me.pednagr__infoTable.AllowUserToDeleteRows = False
        Me.pednagr__infoTable.AllowUserToResizeColumns = False
        Me.pednagr__infoTable.AllowUserToResizeRows = False
        Me.pednagr__infoTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pednagr__infoTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.pednagr__infoTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pednagr__infoTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.pednagr__infoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pednagr__infoTable.DefaultCellStyle = DataGridViewCellStyle12
        Me.pednagr__infoTable.Location = New System.Drawing.Point(0, 41)
        Me.pednagr__infoTable.MultiSelect = False
        Me.pednagr__infoTable.Name = "pednagr__infoTable"
        Me.pednagr__infoTable.ReadOnly = True
        Me.pednagr__infoTable.RowHeadersVisible = False
        Me.pednagr__infoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.pednagr__infoTable.Size = New System.Drawing.Size(494, 314)
        Me.pednagr__infoTable.TabIndex = 8
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView2.Size = New System.Drawing.Size(494, 482)
        Me.DataGridView2.TabIndex = 9
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridView1.Location = New System.Drawing.Point(3, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(289, 199)
        Me.DataGridView1.TabIndex = 20
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewComboBoxColumn1.HeaderText = "ФИО"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Width = 300
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Лекции"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Практ. занятия"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Стимул. занятия"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Консультация"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 140
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "ПА"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "ИА"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Итого нагрузка"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 120
        '
        'ВедомостьПеднагрузка
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1753, 860)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Группа)
        Me.Controls.Add(Me.pednagr__splitContainerMain)
        Me.KeyPreview = True
        Me.Name = "ВедомостьПеднагрузка"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Педнагрузка"
        CType(Me.pednagr__mainTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pednagr__splitContainerMain.Panel1.ResumeLayout(False)
        Me.pednagr__splitContainerMain.Panel1.PerformLayout()
        Me.pednagr__splitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.pednagr__splitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pednagr__splitContainerMain.ResumeLayout(False)
        Me.pednagr_splitContainerInfo.Panel1.ResumeLayout(False)
        Me.pednagr_splitContainerInfo.Panel2.ResumeLayout(False)
        CType(Me.pednagr_splitContainerInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pednagr_splitContainerInfo.ResumeLayout(False)
        CType(Me.pednagr__infoTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Группа As TextBox
    Friend WithEvents pednagr__mainTable As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents НомерГруппы As TextBox
    Friend WithEvents ПодписьИтого As TextBox
    Friend WithEvents sumLectures As TextBox
    Friend WithEvents sumPracticals As TextBox
    Friend WithEvents sumStimul As TextBox
    Friend WithEvents sumConsultations As TextBox
    Friend WithEvents sumPA As TextBox
    Friend WithEvents sumIA As TextBox
    Friend WithEvents sumResult As TextBox
    Friend WithEvents Сохранить As Button
    Friend WithEvents ФИО As DataGridViewComboBoxColumn
    Friend WithEvents Лекции As DataGridViewTextBoxColumn
    Friend WithEvents Практические As DataGridViewTextBoxColumn
    Friend WithEvents Стимулирующие As DataGridViewTextBoxColumn
    Friend WithEvents Консультация As DataGridViewTextBoxColumn
    Friend WithEvents ПА As DataGridViewTextBoxColumn
    Friend WithEvents ИА As DataGridViewTextBoxColumn
    Friend WithEvents Итого As DataGridViewTextBoxColumn
    Friend WithEvents pednagr__splitContainerMain As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents pednagr_splitContainerInfo As SplitContainer
    Friend WithEvents pednagr__infoTable As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
End Class
