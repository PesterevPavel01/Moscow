﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ВедомостьПеднагрузка))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.ПодписьИтого = New System.Windows.Forms.TextBox()
        Me.sumLectures = New System.Windows.Forms.TextBox()
        Me.sumPracticals = New System.Windows.Forms.TextBox()
        Me.sumStimul = New System.Windows.Forms.TextBox()
        Me.sumConsultations = New System.Windows.Forms.TextBox()
        Me.sumPA = New System.Windows.Forms.TextBox()
        Me.sumIA = New System.Windows.Forms.TextBox()
        Me.sumResult = New System.Windows.Forms.TextBox()
        Me.pednagr__splitContainerMain = New System.Windows.Forms.SplitContainer()
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.save = New System.Windows.Forms.ToolStripButton()
        Me.groupNumber = New System.Windows.Forms.ToolStripTextBox()
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        CType(Me.pednagr__mainTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pednagr__splitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pednagr__splitContainerMain.Panel1.SuspendLayout()
        Me.pednagr__splitContainerMain.Panel2.SuspendLayout()
        Me.pednagr__splitContainerMain.SuspendLayout()
        Me.header.SuspendLayout()
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
        Me.Label2.Location = New System.Drawing.Point(-275, -132)
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
        Me.pednagr__mainTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.pednagr__mainTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pednagr__mainTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.pednagr__mainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.pednagr__mainTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ФИО, Me.Лекции, Me.Практические, Me.Стимулирующие, Me.Консультация, Me.ПА, Me.ИА, Me.Итого})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pednagr__mainTable.DefaultCellStyle = DataGridViewCellStyle18
        Me.pednagr__mainTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pednagr__mainTable.Location = New System.Drawing.Point(0, 51)
        Me.pednagr__mainTable.Name = "pednagr__mainTable"
        Me.pednagr__mainTable.RowHeadersVisible = False
        Me.pednagr__mainTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.pednagr__mainTable.Size = New System.Drawing.Size(1275, 804)
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
        'ПодписьИтого
        '
        Me.ПодписьИтого.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ПодписьИтого.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ПодписьИтого.Enabled = False
        Me.ПодписьИтого.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ПодписьИтого.Location = New System.Drawing.Point(0, 822)
        Me.ПодписьИтого.Name = "ПодписьИтого"
        Me.ПодписьИтого.Size = New System.Drawing.Size(300, 29)
        Me.ПодписьИтого.TabIndex = 11
        Me.ПодписьИтого.Text = "ИТОГО"
        '
        'sumLectures
        '
        Me.sumLectures.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumLectures.Enabled = False
        Me.sumLectures.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumLectures.Location = New System.Drawing.Point(299, 822)
        Me.sumLectures.Name = "sumLectures"
        Me.sumLectures.Size = New System.Drawing.Size(120, 29)
        Me.sumLectures.TabIndex = 12
        '
        'sumPracticals
        '
        Me.sumPracticals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumPracticals.Enabled = False
        Me.sumPracticals.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sumPracticals.Location = New System.Drawing.Point(418, 822)
        Me.sumPracticals.Name = "sumPracticals"
        Me.sumPracticals.Size = New System.Drawing.Size(120, 29)
        Me.sumPracticals.TabIndex = 13
        '
        'sumStimul
        '
        Me.sumStimul.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumStimul.Enabled = False
        Me.sumStimul.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumStimul.Location = New System.Drawing.Point(537, 822)
        Me.sumStimul.Name = "sumStimul"
        Me.sumStimul.Size = New System.Drawing.Size(122, 29)
        Me.sumStimul.TabIndex = 14
        '
        'sumConsultations
        '
        Me.sumConsultations.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumConsultations.Enabled = False
        Me.sumConsultations.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumConsultations.Location = New System.Drawing.Point(658, 822)
        Me.sumConsultations.Name = "sumConsultations"
        Me.sumConsultations.Size = New System.Drawing.Size(144, 29)
        Me.sumConsultations.TabIndex = 15
        '
        'sumPA
        '
        Me.sumPA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumPA.Enabled = False
        Me.sumPA.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumPA.Location = New System.Drawing.Point(799, 822)
        Me.sumPA.Name = "sumPA"
        Me.sumPA.Size = New System.Drawing.Size(100, 29)
        Me.sumPA.TabIndex = 16
        '
        'sumIA
        '
        Me.sumIA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumIA.Enabled = False
        Me.sumIA.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumIA.Location = New System.Drawing.Point(898, 822)
        Me.sumIA.Name = "sumIA"
        Me.sumIA.Size = New System.Drawing.Size(100, 29)
        Me.sumIA.TabIndex = 17
        '
        'sumResult
        '
        Me.sumResult.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.sumResult.Enabled = False
        Me.sumResult.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.sumResult.Location = New System.Drawing.Point(997, 822)
        Me.sumResult.Name = "sumResult"
        Me.sumResult.Size = New System.Drawing.Size(126, 29)
        Me.sumResult.TabIndex = 18
        '
        'pednagr__splitContainerMain
        '
        Me.pednagr__splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pednagr__splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.pednagr__splitContainerMain.Location = New System.Drawing.Point(5, 0)
        Me.pednagr__splitContainerMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pednagr__splitContainerMain.Name = "pednagr__splitContainerMain"
        '
        'pednagr__splitContainerMain.Panel1
        '
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.pednagr__mainTable)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumPA)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.ПодписьИтого)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumConsultations)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumLectures)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumStimul)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumPracticals)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumIA)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.sumResult)
        Me.pednagr__splitContainerMain.Panel1.Controls.Add(Me.header)
        '
        'pednagr__splitContainerMain.Panel2
        '
        Me.pednagr__splitContainerMain.Panel2.Controls.Add(Me.pednagr_splitContainerInfo)
        Me.pednagr__splitContainerMain.Size = New System.Drawing.Size(1743, 855)
        Me.pednagr__splitContainerMain.SplitterDistance = 1275
        Me.pednagr__splitContainerMain.SplitterWidth = 1
        Me.pednagr__splitContainerMain.TabIndex = 20
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
        Me.header.Size = New System.Drawing.Size(1275, 51)
        Me.header.TabIndex = 20
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
        Me.pednagr_splitContainerInfo.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'pednagr_splitContainerInfo.Panel2
        '
        Me.pednagr_splitContainerInfo.Panel2.Controls.Add(Me.DataGridView2)
        Me.pednagr_splitContainerInfo.Size = New System.Drawing.Size(467, 855)
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
        Me.pednagr__infoTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.pednagr__infoTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pednagr__infoTable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.pednagr__infoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pednagr__infoTable.DefaultCellStyle = DataGridViewCellStyle20
        Me.pednagr__infoTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pednagr__infoTable.Location = New System.Drawing.Point(0, 51)
        Me.pednagr__infoTable.MultiSelect = False
        Me.pednagr__infoTable.Name = "pednagr__infoTable"
        Me.pednagr__infoTable.ReadOnly = True
        Me.pednagr__infoTable.RowHeadersVisible = False
        Me.pednagr__infoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.pednagr__infoTable.Size = New System.Drawing.Size(467, 306)
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
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView2.Size = New System.Drawing.Size(467, 497)
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
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle24
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
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.Size = New System.Drawing.Size(467, 51)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip2"
        '
        'ВедомостьПеднагрузка
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1753, 860)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Группа)
        Me.Controls.Add(Me.pednagr__splitContainerMain)
        Me.KeyPreview = True
        Me.Name = "ВедомостьПеднагрузка"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.Text = "Педнагрузка"
        CType(Me.pednagr__mainTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pednagr__splitContainerMain.Panel1.ResumeLayout(False)
        Me.pednagr__splitContainerMain.Panel1.PerformLayout()
        Me.pednagr__splitContainerMain.Panel2.ResumeLayout(False)
        CType(Me.pednagr__splitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pednagr__splitContainerMain.ResumeLayout(False)
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
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
    Friend WithEvents ПодписьИтого As TextBox
    Friend WithEvents sumLectures As TextBox
    Friend WithEvents sumPracticals As TextBox
    Friend WithEvents sumStimul As TextBox
    Friend WithEvents sumConsultations As TextBox
    Friend WithEvents sumPA As TextBox
    Friend WithEvents sumIA As TextBox
    Friend WithEvents sumResult As TextBox
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
    Friend WithEvents header As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Private WithEvents save As ToolStripButton
    Friend WithEvents groupNumber As ToolStripTextBox
    Friend WithEvents ToolStrip1 As ToolStrip
End Class
