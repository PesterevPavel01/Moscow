<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.iconsList = New System.Windows.Forms.ImageList(Me.components)
        Me.pageProgs = New System.Windows.Forms.TabPage()
        Me.password = New System.Windows.Forms.MaskedTextBox()
        Me.programms__splitMainConteiner = New System.Windows.Forms.SplitContainer()
        Me.programs_tbl_parent = New System.Windows.Forms.Panel()
        Me.programs__panelProgs = New System.Windows.Forms.Panel()
        Me.toolStripProgram = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.comboBoxProgramms = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripAddProg = New System.Windows.Forms.ToolStripButton()
        Me.progsIndicator = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.programs__SplitContainerModulsType = New System.Windows.Forms.SplitContainer()
        Me.programms__SplitModulsInProg = New System.Windows.Forms.SplitContainer()
        Me.dataGridModulsInProgram = New System.Windows.Forms.DataGridView()
        Me.red_moduls = New System.Windows.Forms.TextBox()
        Me.programs__panelType = New System.Windows.Forms.Panel()
        Me.toolStripModulsInProg = New System.Windows.Forms.ToolStrip()
        Me.ToolStripTop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripBottom = New System.Windows.Forms.ToolStripButton()
        Me.addMidulInGroupp = New System.Windows.Forms.ToolStripButton()
        Me.modulInProgsIndicator = New System.Windows.Forms.ToolStripButton()
        Me.tbl_moduls_sum_hours = New System.Windows.Forms.ToolStripTextBox()
        Me.programms__SplitContainerModuls = New System.Windows.Forms.SplitContainer()
        Me.DataGridAllModuls = New System.Windows.Forms.DataGridView()
        Me.TableLayoutAddNewModul = New System.Windows.Forms.TableLayoutPanel()
        Me.newModAddHour = New System.Windows.Forms.TextBox()
        Me.newModAddName = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripAddModul = New System.Windows.Forms.ToolStripButton()
        Me.modulIndicator = New System.Windows.Forms.ToolStripButton()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.passwrdSetts = New System.Windows.Forms.MaskedTextBox()
        Me.panelSetts = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.booksFRDOSection = New System.Windows.Forms.GroupBox()
        Me.booksSection = New System.Windows.Forms.GroupBox()
        Me.reportSection = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.sekshionsBlanks = New System.Windows.Forms.Panel()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ordersPOSection = New System.Windows.Forms.GroupBox()
        Me.ordersPPSection = New System.Windows.Forms.GroupBox()
        Me.ordersPKSection = New System.Windows.Forms.GroupBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.groupListSection = New System.Windows.Forms.GroupBox()
        Me.studentsSection = New System.Windows.Forms.GroupBox()
        Me.gradesContainer = New System.Windows.Forms.GroupBox()
        Me.TabControlOther = New System.Windows.Forms.TabControl()
        Me.Other = New System.Windows.Forms.TabPage()
        Me.passwordOther = New System.Windows.Forms.MaskedTextBox()
        Me.SplitContainerOther = New System.Windows.Forms.SplitContainer()
        Me.Panel_main = New System.Windows.Forms.Panel()
        Me.SplitContainerOtherList = New System.Windows.Forms.SplitContainer()
        Me.DataGridView_list = New System.Windows.Forms.DataGridView()
        Me.checkBox = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIO_full = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIO_pad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Doljnost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel_worker = New System.Windows.Forms.Panel()
        Me.ButtonFK = New System.Windows.Forms.Button()
        Me.spravka = New System.Windows.Forms.TextBox()
        Me.worker_type = New System.Windows.Forms.ComboBox()
        Me.worker_dolgnost = New System.Windows.Forms.ComboBox()
        Me.worker_name_pad = New System.Windows.Forms.TextBox()
        Me.worker_name_full = New System.Windows.Forms.TextBox()
        Me.worker_name = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip_name_list = New System.Windows.Forms.ToolStripComboBox()
        Me.other_add = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.icons40pxList = New System.Windows.Forms.ImageList(Me.components)
        Me.pageProgs.SuspendLayout()
        CType(Me.programms__splitMainConteiner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.programms__splitMainConteiner.Panel1.SuspendLayout()
        Me.programms__splitMainConteiner.Panel2.SuspendLayout()
        Me.programms__splitMainConteiner.SuspendLayout()
        Me.programs_tbl_parent.SuspendLayout()
        Me.toolStripProgram.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.programs__SplitContainerModulsType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.programs__SplitContainerModulsType.Panel1.SuspendLayout()
        Me.programs__SplitContainerModulsType.Panel2.SuspendLayout()
        Me.programs__SplitContainerModulsType.SuspendLayout()
        CType(Me.programms__SplitModulsInProg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.programms__SplitModulsInProg.Panel1.SuspendLayout()
        Me.programms__SplitModulsInProg.Panel2.SuspendLayout()
        Me.programms__SplitModulsInProg.SuspendLayout()
        CType(Me.dataGridModulsInProgram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStripModulsInProg.SuspendLayout()
        CType(Me.programms__SplitContainerModuls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.programms__SplitContainerModuls.Panel1.SuspendLayout()
        Me.programms__SplitContainerModuls.Panel2.SuspendLayout()
        Me.programms__SplitContainerModuls.SuspendLayout()
        CType(Me.DataGridAllModuls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutAddNewModul.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.panelSetts.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControlOther.SuspendLayout()
        Me.Other.SuspendLayout()
        CType(Me.SplitContainerOther, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerOther.Panel1.SuspendLayout()
        Me.SplitContainerOther.SuspendLayout()
        Me.Panel_main.SuspendLayout()
        CType(Me.SplitContainerOtherList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerOtherList.Panel1.SuspendLayout()
        Me.SplitContainerOtherList.Panel2.SuspendLayout()
        Me.SplitContainerOtherList.SuspendLayout()
        CType(Me.DataGridView_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_worker.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'iconsList
        '
        Me.iconsList.ImageStream = CType(resources.GetObject("iconsList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iconsList.TransparentColor = System.Drawing.Color.Transparent
        Me.iconsList.Images.SetKeyName(0, "file_Exel.png")
        Me.iconsList.Images.SetKeyName(1, "настройки2.png")
        Me.iconsList.Images.SetKeyName(2, "word.png")
        Me.iconsList.Images.SetKeyName(3, "icons8-загрузка-обновлений-50.png")
        Me.iconsList.Images.SetKeyName(4, "Главная.png")
        Me.iconsList.Images.SetKeyName(5, "Бланк!.png")
        Me.iconsList.Images.SetKeyName(6, "Сортировка.png")
        Me.iconsList.Images.SetKeyName(7, "Лупа.png")
        Me.iconsList.Images.SetKeyName(8, "red.png")
        Me.iconsList.Images.SetKeyName(9, "зеленый.png")
        Me.iconsList.Images.SetKeyName(10, "file_icon_129474.png")
        Me.iconsList.Images.SetKeyName(11, "note_list_icon_124054.ico")
        Me.iconsList.Images.SetKeyName(12, "black.png")
        Me.iconsList.Images.SetKeyName(13, "green.png")
        Me.iconsList.Images.SetKeyName(14, "other.png")
        Me.iconsList.Images.SetKeyName(15, "other2.png")
        Me.iconsList.Images.SetKeyName(16, "other3.png")
        Me.iconsList.Images.SetKeyName(17, "Прочее.png")
        Me.iconsList.Images.SetKeyName(18, "other.png")
        Me.iconsList.Images.SetKeyName(19, "Settings.png")
        Me.iconsList.Images.SetKeyName(20, "Home.png")
        Me.iconsList.Images.SetKeyName(21, "ok.png")
        Me.iconsList.Images.SetKeyName(22, "okGr.png")
        '
        'pageProgs
        '
        Me.pageProgs.Controls.Add(Me.password)
        Me.pageProgs.Controls.Add(Me.programms__splitMainConteiner)
        Me.pageProgs.ImageIndex = 11
        Me.pageProgs.Location = New System.Drawing.Point(4, 29)
        Me.pageProgs.Name = "pageProgs"
        Me.pageProgs.Padding = New System.Windows.Forms.Padding(3)
        Me.pageProgs.Size = New System.Drawing.Size(1851, 931)
        Me.pageProgs.TabIndex = 7
        Me.pageProgs.Text = "Программа"
        Me.pageProgs.UseVisualStyleBackColor = True
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(3, 3)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password.Size = New System.Drawing.Size(556, 26)
        Me.password.TabIndex = 37
        '
        'programms__splitMainConteiner
        '
        Me.programms__splitMainConteiner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programms__splitMainConteiner.Location = New System.Drawing.Point(3, 3)
        Me.programms__splitMainConteiner.Name = "programms__splitMainConteiner"
        '
        'programms__splitMainConteiner.Panel1
        '
        Me.programms__splitMainConteiner.Panel1.Controls.Add(Me.programs_tbl_parent)
        Me.programms__splitMainConteiner.Panel1.Controls.Add(Me.toolStripProgram)
        '
        'programms__splitMainConteiner.Panel2
        '
        Me.programms__splitMainConteiner.Panel2.Controls.Add(Me.SplitContainer5)
        Me.programms__splitMainConteiner.Size = New System.Drawing.Size(1845, 925)
        Me.programms__splitMainConteiner.SplitterDistance = 764
        Me.programms__splitMainConteiner.TabIndex = 36
        Me.programms__splitMainConteiner.Visible = False
        '
        'programs_tbl_parent
        '
        Me.programs_tbl_parent.Controls.Add(Me.programs__panelProgs)
        Me.programs_tbl_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programs_tbl_parent.Location = New System.Drawing.Point(0, 48)
        Me.programs_tbl_parent.Name = "programs_tbl_parent"
        Me.programs_tbl_parent.Size = New System.Drawing.Size(764, 877)
        Me.programs_tbl_parent.TabIndex = 2
        '
        'programs__panelProgs
        '
        Me.programs__panelProgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.programs__panelProgs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programs__panelProgs.Location = New System.Drawing.Point(0, 0)
        Me.programs__panelProgs.Name = "programs__panelProgs"
        Me.programs__panelProgs.Size = New System.Drawing.Size(764, 877)
        Me.programs__panelProgs.TabIndex = 0
        '
        'toolStripProgram
        '
        Me.toolStripProgram.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStripProgram.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.comboBoxProgramms, Me.ToolStripAddProg, Me.progsIndicator})
        Me.toolStripProgram.Location = New System.Drawing.Point(0, 0)
        Me.toolStripProgram.Name = "toolStripProgram"
        Me.toolStripProgram.Size = New System.Drawing.Size(764, 48)
        Me.toolStripProgram.TabIndex = 1
        Me.toolStripProgram.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(198, 45)
        Me.ToolStripLabel1.Text = "Уровень квалификации"
        '
        'comboBoxProgramms
        '
        Me.comboBoxProgramms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxProgramms.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.comboBoxProgramms.Items.AddRange(New Object() {"повышение квалификации", "профессиональная переподготовка", "профессиональное обучение"})
        Me.comboBoxProgramms.Name = "comboBoxProgramms"
        Me.comboBoxProgramms.Size = New System.Drawing.Size(300, 48)
        '
        'ToolStripAddProg
        '
        Me.ToolStripAddProg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripAddProg.AutoSize = False
        Me.ToolStripAddProg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripAddProg.Image = Global.WindowsApp2.My.Resources.Resources.plus
        Me.ToolStripAddProg.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripAddProg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAddProg.Name = "ToolStripAddProg"
        Me.ToolStripAddProg.Size = New System.Drawing.Size(45, 45)
        Me.ToolStripAddProg.Text = "toolStripButton2"
        '
        'progsIndicator
        '
        Me.progsIndicator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.progsIndicator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.progsIndicator.Image = CType(resources.GetObject("progsIndicator.Image"), System.Drawing.Image)
        Me.progsIndicator.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.progsIndicator.Name = "progsIndicator"
        Me.progsIndicator.Size = New System.Drawing.Size(23, 45)
        Me.progsIndicator.Text = "ToolStripButton1"
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.programs__SplitContainerModulsType)
        Me.SplitContainer5.Panel1.Controls.Add(Me.toolStripModulsInProg)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.programms__SplitContainerModuls)
        Me.SplitContainer5.Panel2.Controls.Add(Me.ToolStrip4)
        Me.SplitContainer5.Size = New System.Drawing.Size(1077, 925)
        Me.SplitContainer5.SplitterDistance = 596
        Me.SplitContainer5.TabIndex = 37
        '
        'programs__SplitContainerModulsType
        '
        Me.programs__SplitContainerModulsType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programs__SplitContainerModulsType.Location = New System.Drawing.Point(0, 0)
        Me.programs__SplitContainerModulsType.Name = "programs__SplitContainerModulsType"
        Me.programs__SplitContainerModulsType.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'programs__SplitContainerModulsType.Panel1
        '
        Me.programs__SplitContainerModulsType.Panel1.Controls.Add(Me.programms__SplitModulsInProg)
        '
        'programs__SplitContainerModulsType.Panel2
        '
        Me.programs__SplitContainerModulsType.Panel2.Controls.Add(Me.programs__panelType)
        Me.programs__SplitContainerModulsType.Size = New System.Drawing.Size(550, 925)
        Me.programs__SplitContainerModulsType.SplitterDistance = 521
        Me.programs__SplitContainerModulsType.TabIndex = 5
        '
        'programms__SplitModulsInProg
        '
        Me.programms__SplitModulsInProg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programms__SplitModulsInProg.Location = New System.Drawing.Point(0, 0)
        Me.programms__SplitModulsInProg.Name = "programms__SplitModulsInProg"
        Me.programms__SplitModulsInProg.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'programms__SplitModulsInProg.Panel1
        '
        Me.programms__SplitModulsInProg.Panel1.Controls.Add(Me.dataGridModulsInProgram)
        '
        'programms__SplitModulsInProg.Panel2
        '
        Me.programms__SplitModulsInProg.Panel2.Controls.Add(Me.red_moduls)
        Me.programms__SplitModulsInProg.Panel2Collapsed = True
        Me.programms__SplitModulsInProg.Size = New System.Drawing.Size(550, 521)
        Me.programms__SplitModulsInProg.SplitterDistance = 285
        Me.programms__SplitModulsInProg.TabIndex = 4
        '
        'dataGridModulsInProgram
        '
        Me.dataGridModulsInProgram.AllowUserToAddRows = False
        Me.dataGridModulsInProgram.AllowUserToDeleteRows = False
        Me.dataGridModulsInProgram.AllowUserToOrderColumns = True
        Me.dataGridModulsInProgram.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridModulsInProgram.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridModulsInProgram.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridModulsInProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridModulsInProgram.DefaultCellStyle = DataGridViewCellStyle2
        Me.dataGridModulsInProgram.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridModulsInProgram.Location = New System.Drawing.Point(0, 0)
        Me.dataGridModulsInProgram.MultiSelect = False
        Me.dataGridModulsInProgram.Name = "dataGridModulsInProgram"
        Me.dataGridModulsInProgram.ReadOnly = True
        Me.dataGridModulsInProgram.RowHeadersVisible = False
        Me.dataGridModulsInProgram.RowHeadersWidth = 53
        Me.dataGridModulsInProgram.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dataGridModulsInProgram.Size = New System.Drawing.Size(550, 521)
        Me.dataGridModulsInProgram.TabIndex = 34
        '
        'red_moduls
        '
        Me.red_moduls.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock
        Me.red_moduls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.red_moduls.Location = New System.Drawing.Point(0, 0)
        Me.red_moduls.Multiline = True
        Me.red_moduls.Name = "red_moduls"
        Me.red_moduls.Size = New System.Drawing.Size(150, 46)
        Me.red_moduls.TabIndex = 14
        '
        'programs__panelType
        '
        Me.programs__panelType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.programs__panelType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programs__panelType.Location = New System.Drawing.Point(0, 0)
        Me.programs__panelType.Name = "programs__panelType"
        Me.programs__panelType.Size = New System.Drawing.Size(550, 400)
        Me.programs__panelType.TabIndex = 1
        '
        'toolStripModulsInProg
        '
        Me.toolStripModulsInProg.Dock = System.Windows.Forms.DockStyle.Right
        Me.toolStripModulsInProg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTop, Me.ToolStripBottom, Me.addMidulInGroupp, Me.modulInProgsIndicator, Me.tbl_moduls_sum_hours})
        Me.toolStripModulsInProg.Location = New System.Drawing.Point(550, 0)
        Me.toolStripModulsInProg.Name = "toolStripModulsInProg"
        Me.toolStripModulsInProg.Size = New System.Drawing.Size(46, 925)
        Me.toolStripModulsInProg.TabIndex = 3
        Me.toolStripModulsInProg.Text = "ToolStrip3"
        '
        'ToolStripTop
        '
        Me.ToolStripTop.AutoSize = False
        Me.ToolStripTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripTop.Image = Global.WindowsApp2.My.Resources.Resources.top
        Me.ToolStripTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripTop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripTop.Name = "ToolStripTop"
        Me.ToolStripTop.Size = New System.Drawing.Size(45, 45)
        Me.ToolStripTop.Text = "toolStripButton2"
        '
        'ToolStripBottom
        '
        Me.ToolStripBottom.AutoSize = False
        Me.ToolStripBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripBottom.Image = Global.WindowsApp2.My.Resources.Resources.bottom
        Me.ToolStripBottom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripBottom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripBottom.Name = "ToolStripBottom"
        Me.ToolStripBottom.Size = New System.Drawing.Size(45, 45)
        Me.ToolStripBottom.Text = "toolStripButton2"
        '
        'addMidulInGroupp
        '
        Me.addMidulInGroupp.AutoSize = False
        Me.addMidulInGroupp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.addMidulInGroupp.Image = Global.WindowsApp2.My.Resources.Resources.Group_7
        Me.addMidulInGroupp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.addMidulInGroupp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.addMidulInGroupp.Name = "addMidulInGroupp"
        Me.addMidulInGroupp.Size = New System.Drawing.Size(45, 45)
        Me.addMidulInGroupp.Text = "toolStripButton2"
        '
        'modulInProgsIndicator
        '
        Me.modulInProgsIndicator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.modulInProgsIndicator.Image = CType(resources.GetObject("modulInProgsIndicator.Image"), System.Drawing.Image)
        Me.modulInProgsIndicator.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.modulInProgsIndicator.Name = "modulInProgsIndicator"
        Me.modulInProgsIndicator.Size = New System.Drawing.Size(43, 20)
        Me.modulInProgsIndicator.Text = "ToolStripButton1"
        '
        'tbl_moduls_sum_hours
        '
        Me.tbl_moduls_sum_hours.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbl_moduls_sum_hours.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbl_moduls_sum_hours.Enabled = False
        Me.tbl_moduls_sum_hours.Font = New System.Drawing.Font("Microsoft YaHei", 16.0!, System.Drawing.FontStyle.Bold)
        Me.tbl_moduls_sum_hours.Name = "tbl_moduls_sum_hours"
        Me.tbl_moduls_sum_hours.ReadOnly = True
        Me.tbl_moduls_sum_hours.Size = New System.Drawing.Size(41, 29)
        Me.tbl_moduls_sum_hours.Text = "0"
        '
        'programms__SplitContainerModuls
        '
        Me.programms__SplitContainerModuls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programms__SplitContainerModuls.Location = New System.Drawing.Point(0, 0)
        Me.programms__SplitContainerModuls.Name = "programms__SplitContainerModuls"
        Me.programms__SplitContainerModuls.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'programms__SplitContainerModuls.Panel1
        '
        Me.programms__SplitContainerModuls.Panel1.Controls.Add(Me.DataGridAllModuls)
        '
        'programms__SplitContainerModuls.Panel2
        '
        Me.programms__SplitContainerModuls.Panel2.Controls.Add(Me.TableLayoutAddNewModul)
        Me.programms__SplitContainerModuls.Panel2Collapsed = True
        Me.programms__SplitContainerModuls.Size = New System.Drawing.Size(431, 925)
        Me.programms__SplitContainerModuls.SplitterDistance = 676
        Me.programms__SplitContainerModuls.TabIndex = 4
        '
        'DataGridAllModuls
        '
        Me.DataGridAllModuls.AllowUserToAddRows = False
        Me.DataGridAllModuls.AllowUserToDeleteRows = False
        Me.DataGridAllModuls.AllowUserToOrderColumns = True
        Me.DataGridAllModuls.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridAllModuls.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridAllModuls.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridAllModuls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridAllModuls.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridAllModuls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridAllModuls.Location = New System.Drawing.Point(0, 0)
        Me.DataGridAllModuls.MultiSelect = False
        Me.DataGridAllModuls.Name = "DataGridAllModuls"
        Me.DataGridAllModuls.ReadOnly = True
        Me.DataGridAllModuls.RowHeadersVisible = False
        Me.DataGridAllModuls.RowHeadersWidth = 53
        Me.DataGridAllModuls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridAllModuls.Size = New System.Drawing.Size(431, 925)
        Me.DataGridAllModuls.TabIndex = 35
        '
        'TableLayoutAddNewModul
        '
        Me.TableLayoutAddNewModul.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutAddNewModul.ColumnCount = 2
        Me.TableLayoutAddNewModul.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.73896!))
        Me.TableLayoutAddNewModul.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.26104!))
        Me.TableLayoutAddNewModul.Controls.Add(Me.newModAddHour, 1, 1)
        Me.TableLayoutAddNewModul.Controls.Add(Me.newModAddName, 0, 1)
        Me.TableLayoutAddNewModul.Controls.Add(Me.Button5, 1, 0)
        Me.TableLayoutAddNewModul.Controls.Add(Me.Button4, 0, 0)
        Me.TableLayoutAddNewModul.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutAddNewModul.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutAddNewModul.Name = "TableLayoutAddNewModul"
        Me.TableLayoutAddNewModul.RowCount = 2
        Me.TableLayoutAddNewModul.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutAddNewModul.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutAddNewModul.Size = New System.Drawing.Size(150, 46)
        Me.TableLayoutAddNewModul.TabIndex = 0
        '
        'newModAddHour
        '
        Me.newModAddHour.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock
        Me.newModAddHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.newModAddHour.Location = New System.Drawing.Point(129, 55)
        Me.newModAddHour.Multiline = True
        Me.newModAddHour.Name = "newModAddHour"
        Me.newModAddHour.Size = New System.Drawing.Size(17, 1)
        Me.newModAddHour.TabIndex = 39
        '
        'newModAddName
        '
        Me.newModAddName.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock
        Me.newModAddName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.newModAddName.Location = New System.Drawing.Point(4, 55)
        Me.newModAddName.Multiline = True
        Me.newModAddName.Name = "newModAddName"
        Me.newModAddName.Size = New System.Drawing.Size(118, 1)
        Me.newModAddName.TabIndex = 38
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(129, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button5.Size = New System.Drawing.Size(17, 44)
        Me.Button5.TabIndex = 37
        Me.Button5.Text = "Часы"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(4, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button4.Size = New System.Drawing.Size(118, 44)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "Наименование"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAddModul, Me.modulIndicator})
        Me.ToolStrip4.Location = New System.Drawing.Point(431, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(46, 925)
        Me.ToolStrip4.TabIndex = 3
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripAddModul
        '
        Me.ToolStripAddModul.AutoSize = False
        Me.ToolStripAddModul.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripAddModul.Image = Global.WindowsApp2.My.Resources.Resources.plus
        Me.ToolStripAddModul.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripAddModul.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAddModul.Name = "ToolStripAddModul"
        Me.ToolStripAddModul.Size = New System.Drawing.Size(45, 45)
        Me.ToolStripAddModul.Text = "toolStripButton2"
        '
        'modulIndicator
        '
        Me.modulIndicator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.modulIndicator.Image = CType(resources.GetObject("modulIndicator.Image"), System.Drawing.Image)
        Me.modulIndicator.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.modulIndicator.Name = "modulIndicator"
        Me.modulIndicator.Size = New System.Drawing.Size(43, 20)
        Me.modulIndicator.Text = "ToolStripButton2"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.passwrdSetts)
        Me.TabPage5.Controls.Add(Me.panelSetts)
        Me.TabPage5.ImageIndex = 19
        Me.TabPage5.Location = New System.Drawing.Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1851, 931)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Настройки"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'passwrdSetts
        '
        Me.passwrdSetts.Location = New System.Drawing.Point(8, 3)
        Me.passwrdSetts.Name = "passwrdSetts"
        Me.passwrdSetts.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwrdSetts.Size = New System.Drawing.Size(556, 26)
        Me.passwrdSetts.TabIndex = 54
        '
        'panelSetts
        '
        Me.panelSetts.Controls.Add(Me.Label7)
        Me.panelSetts.Controls.Add(Me.Label8)
        Me.panelSetts.Controls.Add(Me.Label10)
        Me.panelSetts.Controls.Add(Me.Label9)
        Me.panelSetts.Controls.Add(Me.Label16)
        Me.panelSetts.Controls.Add(Me.Label11)
        Me.panelSetts.Controls.Add(Me.Label17)
        Me.panelSetts.Controls.Add(Me.Label12)
        Me.panelSetts.Controls.Add(Me.Label15)
        Me.panelSetts.Controls.Add(Me.Label13)
        Me.panelSetts.Controls.Add(Me.Label14)
        Me.panelSetts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelSetts.Location = New System.Drawing.Point(0, 0)
        Me.panelSetts.Name = "panelSetts"
        Me.panelSetts.Size = New System.Drawing.Size(1851, 931)
        Me.panelSetts.TabIndex = 53
        Me.panelSetts.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(321, 18)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Параметр поиска слушателей по умолчанию"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(275, 18)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Параметр поиска групп по умолчанию"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(353, 18)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Параметр сортировки слушателей по умолчанию"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(307, 18)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Параметр сортировки групп по умолчанию"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 307)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(186, 18)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Согласовано Должность"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(351, 18)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Количество отображаемых строк в справочнике"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 279)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 18)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Согласовано"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 167)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 18)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Директор ФИО"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 251)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(186, 18)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Согласовано Должность"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 195)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(161, 18)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Директор Должность"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 223)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 18)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Согласовано"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.booksFRDOSection)
        Me.TabPage4.Controls.Add(Me.booksSection)
        Me.TabPage4.Controls.Add(Me.reportSection)
        Me.TabPage4.ImageIndex = 0
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1851, 931)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Отчеты"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Период с:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 20)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "по"
        '
        'booksFRDOSection
        '
        Me.booksFRDOSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.booksFRDOSection.Location = New System.Drawing.Point(3, 669)
        Me.booksFRDOSection.Name = "booksFRDOSection"
        Me.booksFRDOSection.Size = New System.Drawing.Size(1845, 178)
        Me.booksFRDOSection.TabIndex = 121
        Me.booksFRDOSection.TabStop = False
        '
        'booksSection
        '
        Me.booksSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.booksSection.Location = New System.Drawing.Point(3, 474)
        Me.booksSection.Name = "booksSection"
        Me.booksSection.Size = New System.Drawing.Size(1845, 178)
        Me.booksSection.TabIndex = 120
        Me.booksSection.TabStop = False
        '
        'reportSection
        '
        Me.reportSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reportSection.Location = New System.Drawing.Point(3, 53)
        Me.reportSection.Name = "reportSection"
        Me.reportSection.Size = New System.Drawing.Size(1845, 404)
        Me.reportSection.TabIndex = 119
        Me.reportSection.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.sekshionsBlanks)
        Me.TabPage2.ImageIndex = 5
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1851, 931)
        Me.TabPage2.TabIndex = 5
        Me.TabPage2.Text = "Бланки"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'sekshionsBlanks
        '
        Me.sekshionsBlanks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sekshionsBlanks.Location = New System.Drawing.Point(0, 0)
        Me.sekshionsBlanks.Name = "sekshionsBlanks"
        Me.sekshionsBlanks.Size = New System.Drawing.Size(1851, 931)
        Me.sekshionsBlanks.TabIndex = 13
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ordersPOSection)
        Me.TabPage3.Controls.Add(Me.ordersPPSection)
        Me.TabPage3.Controls.Add(Me.ordersPKSection)
        Me.TabPage3.ImageIndex = 2
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1851, 931)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Приказы"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ordersPOSection
        '
        Me.ordersPOSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ordersPOSection.Location = New System.Drawing.Point(14, 568)
        Me.ordersPOSection.Name = "ordersPOSection"
        Me.ordersPOSection.Size = New System.Drawing.Size(1831, 228)
        Me.ordersPOSection.TabIndex = 16
        Me.ordersPOSection.TabStop = False
        '
        'ordersPPSection
        '
        Me.ordersPPSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ordersPPSection.Location = New System.Drawing.Point(14, 321)
        Me.ordersPPSection.Name = "ordersPPSection"
        Me.ordersPPSection.Size = New System.Drawing.Size(1831, 228)
        Me.ordersPPSection.TabIndex = 15
        Me.ordersPPSection.TabStop = False
        '
        'ordersPKSection
        '
        Me.ordersPKSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ordersPKSection.Location = New System.Drawing.Point(14, 3)
        Me.ordersPKSection.Name = "ordersPKSection"
        Me.ordersPKSection.Size = New System.Drawing.Size(1831, 299)
        Me.ordersPKSection.TabIndex = 14
        Me.ordersPKSection.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage1.Controls.Add(Me.groupListSection)
        Me.TabPage1.Controls.Add(Me.studentsSection)
        Me.TabPage1.Controls.Add(Me.gradesContainer)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabPage1.ImageIndex = 20
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1851, 931)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Главная"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'groupListSection
        '
        Me.groupListSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupListSection.Location = New System.Drawing.Point(14, 3)
        Me.groupListSection.Name = "groupListSection"
        Me.groupListSection.Size = New System.Drawing.Size(1831, 299)
        Me.groupListSection.TabIndex = 4
        Me.groupListSection.TabStop = False
        '
        'studentsSection
        '
        Me.studentsSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.studentsSection.Location = New System.Drawing.Point(14, 328)
        Me.studentsSection.Name = "studentsSection"
        Me.studentsSection.Size = New System.Drawing.Size(1831, 174)
        Me.studentsSection.TabIndex = 5
        Me.studentsSection.TabStop = False
        '
        'gradesContainer
        '
        Me.gradesContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gradesContainer.Location = New System.Drawing.Point(14, 536)
        Me.gradesContainer.Name = "gradesContainer"
        Me.gradesContainer.Size = New System.Drawing.Size(1831, 226)
        Me.gradesContainer.TabIndex = 6
        Me.gradesContainer.TabStop = False
        '
        'TabControlOther
        '
        Me.TabControlOther.Controls.Add(Me.TabPage1)
        Me.TabControlOther.Controls.Add(Me.TabPage3)
        Me.TabControlOther.Controls.Add(Me.TabPage2)
        Me.TabControlOther.Controls.Add(Me.TabPage4)
        Me.TabControlOther.Controls.Add(Me.TabPage5)
        Me.TabControlOther.Controls.Add(Me.pageProgs)
        Me.TabControlOther.Controls.Add(Me.Other)
        Me.TabControlOther.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabControlOther.ImageList = Me.iconsList
        Me.TabControlOther.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TabControlOther.Location = New System.Drawing.Point(0, 0)
        Me.TabControlOther.Name = "TabControlOther"
        Me.TabControlOther.SelectedIndex = 0
        Me.TabControlOther.Size = New System.Drawing.Size(1859, 964)
        Me.TabControlOther.TabIndex = 0
        '
        'Other
        '
        Me.Other.Controls.Add(Me.passwordOther)
        Me.Other.Controls.Add(Me.SplitContainerOther)
        Me.Other.ImageIndex = 18
        Me.Other.Location = New System.Drawing.Point(4, 29)
        Me.Other.Name = "Other"
        Me.Other.Size = New System.Drawing.Size(1851, 931)
        Me.Other.TabIndex = 8
        Me.Other.Text = "Прочее"
        Me.Other.UseVisualStyleBackColor = True
        '
        'passwordOther
        '
        Me.passwordOther.Location = New System.Drawing.Point(3, 3)
        Me.passwordOther.Name = "passwordOther"
        Me.passwordOther.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordOther.Size = New System.Drawing.Size(556, 26)
        Me.passwordOther.TabIndex = 40
        '
        'SplitContainerOther
        '
        Me.SplitContainerOther.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerOther.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerOther.Name = "SplitContainerOther"
        '
        'SplitContainerOther.Panel1
        '
        Me.SplitContainerOther.Panel1.Controls.Add(Me.Panel_main)
        Me.SplitContainerOther.Panel1.Controls.Add(Me.ToolStrip1)
        Me.SplitContainerOther.Panel2Collapsed = True
        Me.SplitContainerOther.Size = New System.Drawing.Size(1851, 931)
        Me.SplitContainerOther.SplitterDistance = 748
        Me.SplitContainerOther.TabIndex = 41
        Me.SplitContainerOther.Visible = False
        '
        'Panel_main
        '
        Me.Panel_main.Controls.Add(Me.SplitContainerOtherList)
        Me.Panel_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_main.Location = New System.Drawing.Point(0, 48)
        Me.Panel_main.Name = "Panel_main"
        Me.Panel_main.Size = New System.Drawing.Size(1851, 883)
        Me.Panel_main.TabIndex = 5
        '
        'SplitContainerOtherList
        '
        Me.SplitContainerOtherList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerOtherList.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerOtherList.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerOtherList.Name = "SplitContainerOtherList"
        Me.SplitContainerOtherList.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerOtherList.Panel1
        '
        Me.SplitContainerOtherList.Panel1.Controls.Add(Me.DataGridView_list)
        Me.SplitContainerOtherList.Panel1MinSize = 26
        '
        'SplitContainerOtherList.Panel2
        '
        Me.SplitContainerOtherList.Panel2.Controls.Add(Me.panel_worker)
        Me.SplitContainerOtherList.Panel2Collapsed = True
        Me.SplitContainerOtherList.Panel2MinSize = 26
        Me.SplitContainerOtherList.Size = New System.Drawing.Size(1851, 883)
        Me.SplitContainerOtherList.SplitterDistance = 26
        Me.SplitContainerOtherList.TabIndex = 4
        '
        'DataGridView_list
        '
        Me.DataGridView_list.AllowUserToAddRows = False
        Me.DataGridView_list.AllowUserToDeleteRows = False
        Me.DataGridView_list.AllowUserToOrderColumns = True
        Me.DataGridView_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView_list.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_list.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_list.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.checkBox, Me.FIO, Me.FIO_full, Me.FIO_pad, Me.Doljnost, Me.type, Me.kod})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView_list.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_list.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_list.MultiSelect = False
        Me.DataGridView_list.Name = "DataGridView_list"
        Me.DataGridView_list.ReadOnly = True
        Me.DataGridView_list.RowHeadersVisible = False
        Me.DataGridView_list.RowHeadersWidth = 53
        Me.DataGridView_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_list.Size = New System.Drawing.Size(1851, 883)
        Me.DataGridView_list.TabIndex = 34
        Me.DataGridView_list.Visible = False
        '
        'checkBox
        '
        Me.checkBox.HeaderText = ""
        Me.checkBox.Name = "checkBox"
        Me.checkBox.ReadOnly = True
        '
        'FIO
        '
        Me.FIO.HeaderText = "ФИО"
        Me.FIO.Name = "FIO"
        Me.FIO.ReadOnly = True
        '
        'FIO_full
        '
        Me.FIO_full.HeaderText = "Фамилия Имя Отчество"
        Me.FIO_full.Name = "FIO_full"
        Me.FIO_full.ReadOnly = True
        '
        'FIO_pad
        '
        Me.FIO_pad.HeaderText = "Фамилия Имя Отчество РП"
        Me.FIO_pad.Name = "FIO_pad"
        Me.FIO_pad.ReadOnly = True
        '
        'Doljnost
        '
        Me.Doljnost.HeaderText = "Должность"
        Me.Doljnost.Name = "Doljnost"
        Me.Doljnost.ReadOnly = True
        '
        'type
        '
        Me.type.HeaderText = "Тип"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        '
        'kod
        '
        Me.kod.HeaderText = "Код"
        Me.kod.Name = "kod"
        Me.kod.ReadOnly = True
        Me.kod.Width = 5
        '
        'panel_worker
        '
        Me.panel_worker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel_worker.Controls.Add(Me.ButtonFK)
        Me.panel_worker.Controls.Add(Me.spravka)
        Me.panel_worker.Controls.Add(Me.worker_type)
        Me.panel_worker.Controls.Add(Me.worker_dolgnost)
        Me.panel_worker.Controls.Add(Me.worker_name_pad)
        Me.panel_worker.Controls.Add(Me.worker_name_full)
        Me.panel_worker.Controls.Add(Me.worker_name)
        Me.panel_worker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_worker.Location = New System.Drawing.Point(0, 0)
        Me.panel_worker.Name = "panel_worker"
        Me.panel_worker.Size = New System.Drawing.Size(150, 46)
        Me.panel_worker.TabIndex = 15
        '
        'ButtonFK
        '
        Me.ButtonFK.Location = New System.Drawing.Point(562, 59)
        Me.ButtonFK.Name = "ButtonFK"
        Me.ButtonFK.Size = New System.Drawing.Size(65, 22)
        Me.ButtonFK.TabIndex = 45
        Me.ButtonFK.Text = "ButtonFK"
        Me.ButtonFK.UseVisualStyleBackColor = True
        Me.ButtonFK.Visible = False
        '
        'spravka
        '
        Me.spravka.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spravka.Enabled = False
        Me.spravka.Location = New System.Drawing.Point(2, 147)
        Me.spravka.Multiline = True
        Me.spravka.Name = "spravka"
        Me.spravka.Size = New System.Drawing.Size(144, 1)
        Me.spravka.TabIndex = 44
        Me.spravka.Text = "Укажите ФИО в формате Фамилия И.О."
        '
        'worker_type
        '
        Me.worker_type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.worker_type.FormattingEnabled = True
        Me.worker_type.ItemHeight = 20
        Me.worker_type.Location = New System.Drawing.Point(3, 117)
        Me.worker_type.Name = "worker_type"
        Me.worker_type.Size = New System.Drawing.Size(144, 28)
        Me.worker_type.TabIndex = 1004
        '
        'worker_dolgnost
        '
        Me.worker_dolgnost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_dolgnost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.worker_dolgnost.FormattingEnabled = True
        Me.worker_dolgnost.ItemHeight = 20
        Me.worker_dolgnost.Location = New System.Drawing.Point(3, 87)
        Me.worker_dolgnost.Name = "worker_dolgnost"
        Me.worker_dolgnost.Size = New System.Drawing.Size(144, 28)
        Me.worker_dolgnost.TabIndex = 1003
        '
        'worker_name_pad
        '
        Me.worker_name_pad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_name_pad.Location = New System.Drawing.Point(3, 59)
        Me.worker_name_pad.Name = "worker_name_pad"
        Me.worker_name_pad.Size = New System.Drawing.Size(144, 26)
        Me.worker_name_pad.TabIndex = 1002
        '
        'worker_name_full
        '
        Me.worker_name_full.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_name_full.Location = New System.Drawing.Point(3, 31)
        Me.worker_name_full.Name = "worker_name_full"
        Me.worker_name_full.Size = New System.Drawing.Size(144, 26)
        Me.worker_name_full.TabIndex = 1001
        '
        'worker_name
        '
        Me.worker_name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_name.Location = New System.Drawing.Point(3, 3)
        Me.worker_name.Name = "worker_name"
        Me.worker_name.Size = New System.Drawing.Size(144, 26)
        Me.worker_name.TabIndex = 1000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStrip_name_list, Me.other_add, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1851, 48)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(74, 45)
        Me.ToolStripLabel2.Text = "таблица"
        '
        'ToolStrip_name_list
        '
        Me.ToolStrip_name_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStrip_name_list.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStrip_name_list.Items.AddRange(New Object() {"Преподаватели", "Должности", "Организации", "Образование"})
        Me.ToolStrip_name_list.Name = "ToolStrip_name_list"
        Me.ToolStrip_name_list.Size = New System.Drawing.Size(300, 48)
        '
        'other_add
        '
        Me.other_add.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.other_add.AutoSize = False
        Me.other_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.other_add.Image = Global.WindowsApp2.My.Resources.Resources.plus
        Me.other_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.other_add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.other_add.Name = "other_add"
        Me.other_add.Size = New System.Drawing.Size(45, 45)
        Me.other_add.Text = "Добавить запись"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.WindowsApp2.My.Resources.Resources.ok
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(44, 45)
        Me.ToolStripButton1.Text = "Изменить"
        '
        'icons40pxList
        '
        Me.icons40pxList.ImageStream = CType(resources.GetObject("icons40pxList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.icons40pxList.TransparentColor = System.Drawing.Color.Transparent
        Me.icons40pxList.Images.SetKeyName(0, "green.png")
        Me.icons40pxList.Images.SetKeyName(1, "black.png")
        Me.icons40pxList.Images.SetKeyName(2, "ok.png")
        Me.icons40pxList.Images.SetKeyName(3, "okGr.png")
        Me.icons40pxList.Images.SetKeyName(4, "PK.png")
        Me.icons40pxList.Images.SetKeyName(5, "PKGreen.png")
        Me.icons40pxList.Images.SetKeyName(6, "PP.png")
        Me.icons40pxList.Images.SetKeyName(7, "PPGreen.png")
        Me.icons40pxList.Images.SetKeyName(8, "PO.png")
        Me.icons40pxList.Images.SetKeyName(9, "POGreen.png")
        Me.icons40pxList.Images.SetKeyName(10, "deacnivate.png")
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1859, 964)
        Me.Controls.Add(Me.TabControlOther)
        Me.KeyPreview = True
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ФГБУ ДПО ВУНМЦ Минздрава России"
        Me.pageProgs.ResumeLayout(False)
        Me.pageProgs.PerformLayout()
        Me.programms__splitMainConteiner.Panel1.ResumeLayout(False)
        Me.programms__splitMainConteiner.Panel1.PerformLayout()
        Me.programms__splitMainConteiner.Panel2.ResumeLayout(False)
        CType(Me.programms__splitMainConteiner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.programms__splitMainConteiner.ResumeLayout(False)
        Me.programs_tbl_parent.ResumeLayout(False)
        Me.toolStripProgram.ResumeLayout(False)
        Me.toolStripProgram.PerformLayout()
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.Panel2.PerformLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.programs__SplitContainerModulsType.Panel1.ResumeLayout(False)
        Me.programs__SplitContainerModulsType.Panel2.ResumeLayout(False)
        CType(Me.programs__SplitContainerModulsType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.programs__SplitContainerModulsType.ResumeLayout(False)
        Me.programms__SplitModulsInProg.Panel1.ResumeLayout(False)
        Me.programms__SplitModulsInProg.Panel2.ResumeLayout(False)
        Me.programms__SplitModulsInProg.Panel2.PerformLayout()
        CType(Me.programms__SplitModulsInProg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.programms__SplitModulsInProg.ResumeLayout(False)
        CType(Me.dataGridModulsInProgram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStripModulsInProg.ResumeLayout(False)
        Me.toolStripModulsInProg.PerformLayout()
        Me.programms__SplitContainerModuls.Panel1.ResumeLayout(False)
        Me.programms__SplitContainerModuls.Panel2.ResumeLayout(False)
        CType(Me.programms__SplitContainerModuls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.programms__SplitContainerModuls.ResumeLayout(False)
        CType(Me.DataGridAllModuls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutAddNewModul.ResumeLayout(False)
        Me.TableLayoutAddNewModul.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.panelSetts.ResumeLayout(False)
        Me.panelSetts.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControlOther.ResumeLayout(False)
        Me.Other.ResumeLayout(False)
        Me.Other.PerformLayout()
        Me.SplitContainerOther.Panel1.ResumeLayout(False)
        Me.SplitContainerOther.Panel1.PerformLayout()
        CType(Me.SplitContainerOther, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerOther.ResumeLayout(False)
        Me.Panel_main.ResumeLayout(False)
        Me.SplitContainerOtherList.Panel1.ResumeLayout(False)
        Me.SplitContainerOtherList.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerOtherList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerOtherList.ResumeLayout(False)
        CType(Me.DataGridView_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_worker.ResumeLayout(False)
        Me.panel_worker.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents iconsList As ImageList
    Friend WithEvents pageProgs As TabPage
    Friend WithEvents programms__splitMainConteiner As SplitContainer
    Friend WithEvents toolStripProgram As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents comboBoxProgramms As ToolStripComboBox
    Private WithEvents ToolStripAddProg As ToolStripButton
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents programms__SplitModulsInProg As SplitContainer
    Public WithEvents dataGridModulsInProgram As DataGridView
    Friend WithEvents toolStripModulsInProg As ToolStrip
    Private WithEvents ToolStripTop As ToolStripButton
    Private WithEvents ToolStripBottom As ToolStripButton
    Private WithEvents addMidulInGroupp As ToolStripButton
    Friend WithEvents programms__SplitContainerModuls As SplitContainer
    Public WithEvents DataGridAllModuls As DataGridView
    Friend WithEvents ToolStrip4 As ToolStrip
    Private WithEvents ToolStripAddModul As ToolStripButton
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents reportSection As GroupBox
    Friend WithEvents booksSection As GroupBox
    Friend WithEvents booksFRDOSection As GroupBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents groupListSection As GroupBox
    Friend WithEvents studentsSection As GroupBox
    Friend WithEvents gradesContainer As GroupBox
    Friend WithEvents TabControlOther As TabControl
    Friend WithEvents red_moduls As TextBox
    Friend WithEvents TableLayoutAddNewModul As TableLayoutPanel
    Friend WithEvents Button4 As Button
    Friend WithEvents newModAddHour As TextBox
    Friend WithEvents newModAddName As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents password As MaskedTextBox
    Friend WithEvents progsIndicator As ToolStripButton
    Friend WithEvents modulInProgsIndicator As ToolStripButton
    Friend WithEvents modulIndicator As ToolStripButton
    Friend WithEvents Other As TabPage
    Friend WithEvents passwordOther As MaskedTextBox
    Friend WithEvents SplitContainerOther As SplitContainer
    Friend WithEvents SplitContainerOtherList As SplitContainer
    Friend WithEvents panel_worker As Panel
    Friend WithEvents worker_name_pad As TextBox
    Friend WithEvents worker_name_full As TextBox
    Friend WithEvents worker_name As TextBox
    Friend WithEvents worker_type As ComboBox
    Friend WithEvents worker_dolgnost As ComboBox
    Friend WithEvents spravka As TextBox
    Friend WithEvents ButtonFK As Button
    Friend WithEvents DataGridView_list As DataGridView
    Friend WithEvents checkBox As DataGridViewCheckBoxColumn
    Friend WithEvents FIO As DataGridViewTextBoxColumn
    Friend WithEvents FIO_full As DataGridViewTextBoxColumn
    Friend WithEvents FIO_pad As DataGridViewTextBoxColumn
    Friend WithEvents Doljnost As DataGridViewTextBoxColumn
    Friend WithEvents type As DataGridViewTextBoxColumn
    Friend WithEvents kod As DataGridViewTextBoxColumn
    Public WithEvents icons40pxList As ImageList
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStrip_name_list As ToolStripComboBox
    Private WithEvents other_add As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Panel_main As Panel
    Friend WithEvents programs_tbl_parent As Panel
    Friend WithEvents tbl_moduls_sum_hours As ToolStripTextBox
    Friend WithEvents programs__SplitContainerModulsType As SplitContainer
    Friend WithEvents programs__panelProgs As Panel
    Friend WithEvents programs__panelType As Panel
    Friend WithEvents panelSetts As Panel
    Friend WithEvents ordersPKSection As GroupBox
    Friend WithEvents ordersPPSection As GroupBox
    Friend WithEvents ordersPOSection As GroupBox
    Friend WithEvents sekshionsBlanks As Panel
    Friend WithEvents passwrdSetts As MaskedTextBox
End Class
