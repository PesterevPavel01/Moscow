<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ААОсновная
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ААОсновная))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pageProgs = New System.Windows.Forms.TabPage()
        Me.password = New System.Windows.Forms.MaskedTextBox()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.programms_tbl_parent = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.comboBoxProgramms = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripAddProg = New System.Windows.Forms.ToolStripButton()
        Me.progsIndicator = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.SplitModulsInProg = New System.Windows.Forms.SplitContainer()
        Me.dataGridModuls = New System.Windows.Forms.DataGridView()
        Me.red_moduls = New System.Windows.Forms.TextBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripTop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripBottom = New System.Windows.Forms.ToolStripButton()
        Me.addMidulInGroupp = New System.Windows.Forms.ToolStripButton()
        Me.modulInProgsIndicator = New System.Windows.Forms.ToolStripButton()
        Me.tbl_moduls_sum_hours = New System.Windows.Forms.ToolStripTextBox()
        Me.SplitContainerModuls = New System.Windows.Forms.SplitContainer()
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
        Me.PanelSetts = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Согласовано2ДолжностьПУ = New System.Windows.Forms.TextBox()
        Me.ПоискСлушателейПоУм = New System.Windows.Forms.ComboBox()
        Me.Согласовано2ПУ = New System.Windows.Forms.TextBox()
        Me.ПоискГруппПоУм = New System.Windows.Forms.ComboBox()
        Me.Согласовано1ДолжностьПУ = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Согласовано1ПУ = New System.Windows.Forms.TextBox()
        Me.НастройкаСортировкиСлушателей = New System.Windows.Forms.ComboBox()
        Me.ДиректорДолжность = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ДиректорФИО = New System.Windows.Forms.TextBox()
        Me.НастройкаСортировкиГрупп = New System.Windows.Forms.ComboBox()
        Me.КоличествоСтрокВТаблице = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ChРМАНПО = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.КнигаДипломовФРДО = New System.Windows.Forms.Button()
        Me.КнигаУчетаУдостоверенийФРДО = New System.Windows.Forms.Button()
        Me.КнигаСвидетельствФРДО = New System.Windows.Forms.Button()
        Me.ОтчетПеднагрузка = New System.Windows.Forms.CheckBox()
        Me.КнигаУчетаСвидетельств = New System.Windows.Forms.Button()
        Me.СводПоОрганиз = New System.Windows.Forms.CheckBox()
        Me.КнигаУчетаДипломов = New System.Windows.Forms.Button()
        Me.БюджетВбюдж = New System.Windows.Forms.CheckBox()
        Me.КнигаУчетаУдостоверений = New System.Windows.Forms.Button()
        Me.ChСводПоКурсам = New System.Windows.Forms.CheckBox()
        Me.СводПоСпец = New System.Windows.Forms.CheckBox()
        Me.ДатаНачалаОтчета = New System.Windows.Forms.DateTimePicker()
        Me.ОтчетРуководителя = New System.Windows.Forms.CheckBox()
        Me.ДатаКонцаОтчета = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.СправкаОбОкончании = New System.Windows.Forms.Button()
        Me.СправкаОбОбучении = New System.Windows.Forms.Button()
        Me.ПП_Ведомость = New System.Windows.Forms.Button()
        Me.ВедомостьПромежуточнойАттестации = New System.Windows.Forms.Button()
        Me.ДоверенностьПолученияБланковСлушателей = New System.Windows.Forms.Button()
        Me.ДоверенностьПолученияБланков = New System.Windows.Forms.Button()
        Me.Ведомость_слушателиИорганизации = New System.Windows.Forms.Button()
        Me.ПО_Свидетельство = New System.Windows.Forms.Button()
        Me.Карточка_слушателя = New System.Windows.Forms.Button()
        Me.ПП_Заявление = New System.Windows.Forms.Button()
        Me.ПК_Заявление = New System.Windows.Forms.Button()
        Me.ПП_ПриложениеКдиплому = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ПриказОЗачислении_Доп = New System.Windows.Forms.Button()
        Me.ПК_Окончание_уд = New System.Windows.Forms.Button()
        Me.ПО_Окончание = New System.Windows.Forms.Button()
        Me.ПП_Окончание = New System.Windows.Forms.Button()
        Me.ПК_Окончание = New System.Windows.Forms.Button()
        Me.ПП_ДопускКИА = New System.Windows.Forms.Button()
        Me.ПО_ДопускКИА = New System.Windows.Forms.Button()
        Me.ПК_Отчисление = New System.Windows.Forms.Button()
        Me.ПО_Практика = New System.Windows.Forms.Button()
        Me.ПП_Практика = New System.Windows.Forms.Button()
        Me.ПО_Зачисление = New System.Windows.Forms.Button()
        Me.ППЗачисление = New System.Windows.Forms.Button()
        Me.ПриказОЗачислении = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.СправочникГруппыПП = New System.Windows.Forms.Button()
        Me.СправочникГруппыПО = New System.Windows.Forms.Button()
        Me.Педнагрузка = New System.Windows.Forms.Button()
        Me.Ведомость = New System.Windows.Forms.Button()
        Me.КнопкаСоздатьГруппу = New System.Windows.Forms.Button()
        Me.ДобавитьСлушателя = New System.Windows.Forms.Button()
        Me.СправочникСлушатели = New System.Windows.Forms.Button()
        Me.СправочникГруппыПК = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ИтоговаяАттествцияОценки = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
        Me.ImageList40 = New System.Windows.Forms.ImageList(Me.components)
        Me.pageProgs.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.SplitModulsInProg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitModulsInProg.Panel1.SuspendLayout()
        Me.SplitModulsInProg.Panel2.SuspendLayout()
        Me.SplitModulsInProg.SuspendLayout()
        CType(Me.dataGridModuls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.SplitContainerModuls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerModuls.Panel1.SuspendLayout()
        Me.SplitContainerModuls.Panel2.SuspendLayout()
        Me.SplitContainerModuls.SuspendLayout()
        CType(Me.DataGridAllModuls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutAddNewModul.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.PanelSetts.SuspendLayout()
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
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "file_Exel.png")
        Me.ImageList1.Images.SetKeyName(1, "настройки2.png")
        Me.ImageList1.Images.SetKeyName(2, "word.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-загрузка-обновлений-50.png")
        Me.ImageList1.Images.SetKeyName(4, "Главная.png")
        Me.ImageList1.Images.SetKeyName(5, "Бланк!.png")
        Me.ImageList1.Images.SetKeyName(6, "Сортировка.png")
        Me.ImageList1.Images.SetKeyName(7, "Лупа.png")
        Me.ImageList1.Images.SetKeyName(8, "red.png")
        Me.ImageList1.Images.SetKeyName(9, "зеленый.png")
        Me.ImageList1.Images.SetKeyName(10, "file_icon_129474.png")
        Me.ImageList1.Images.SetKeyName(11, "note_list_icon_124054.ico")
        Me.ImageList1.Images.SetKeyName(12, "black.png")
        Me.ImageList1.Images.SetKeyName(13, "green.png")
        Me.ImageList1.Images.SetKeyName(14, "other.png")
        Me.ImageList1.Images.SetKeyName(15, "other2.png")
        Me.ImageList1.Images.SetKeyName(16, "other3.png")
        Me.ImageList1.Images.SetKeyName(17, "Прочее.png")
        Me.ImageList1.Images.SetKeyName(18, "other.png")
        Me.ImageList1.Images.SetKeyName(19, "Settings.png")
        Me.ImageList1.Images.SetKeyName(20, "Home.png")
        Me.ImageList1.Images.SetKeyName(21, "ok.png")
        Me.ImageList1.Images.SetKeyName(22, "okGr.png")
        '
        'pageProgs
        '
        Me.pageProgs.Controls.Add(Me.password)
        Me.pageProgs.Controls.Add(Me.SplitContainer4)
        Me.pageProgs.ImageIndex = 11
        Me.pageProgs.Location = New System.Drawing.Point(4, 27)
        Me.pageProgs.Name = "pageProgs"
        Me.pageProgs.Padding = New System.Windows.Forms.Padding(3)
        Me.pageProgs.Size = New System.Drawing.Size(1352, 836)
        Me.pageProgs.TabIndex = 7
        Me.pageProgs.Text = "Программа"
        Me.pageProgs.UseVisualStyleBackColor = True
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(3, 3)
        Me.password.Name = "password"
        Me.password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password.Size = New System.Drawing.Size(556, 22)
        Me.password.TabIndex = 37
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.programms_tbl_parent)
        Me.SplitContainer4.Panel1.Controls.Add(Me.ToolStrip2)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer5)
        Me.SplitContainer4.Size = New System.Drawing.Size(1346, 830)
        Me.SplitContainer4.SplitterDistance = 558
        Me.SplitContainer4.TabIndex = 36
        Me.SplitContainer4.Visible = False
        '
        'programms_tbl_parent
        '
        Me.programms_tbl_parent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.programms_tbl_parent.Location = New System.Drawing.Point(0, 48)
        Me.programms_tbl_parent.Name = "programms_tbl_parent"
        Me.programms_tbl_parent.Size = New System.Drawing.Size(558, 782)
        Me.programms_tbl_parent.TabIndex = 2
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.comboBoxProgramms, Me.ToolStripAddProg, Me.progsIndicator})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(558, 48)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripLabel1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(147, 45)
        Me.ToolStripLabel1.Text = "Уровень квалификации"
        '
        'comboBoxProgramms
        '
        Me.comboBoxProgramms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxProgramms.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
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
        Me.SplitContainer5.Panel1.Controls.Add(Me.SplitModulsInProg)
        Me.SplitContainer5.Panel1.Controls.Add(Me.ToolStrip3)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.SplitContainerModuls)
        Me.SplitContainer5.Panel2.Controls.Add(Me.ToolStrip4)
        Me.SplitContainer5.Size = New System.Drawing.Size(784, 830)
        Me.SplitContainer5.SplitterDistance = 436
        Me.SplitContainer5.TabIndex = 37
        '
        'SplitModulsInProg
        '
        Me.SplitModulsInProg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitModulsInProg.Location = New System.Drawing.Point(0, 0)
        Me.SplitModulsInProg.Name = "SplitModulsInProg"
        Me.SplitModulsInProg.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitModulsInProg.Panel1
        '
        Me.SplitModulsInProg.Panel1.Controls.Add(Me.dataGridModuls)
        '
        'SplitModulsInProg.Panel2
        '
        Me.SplitModulsInProg.Panel2.Controls.Add(Me.red_moduls)
        Me.SplitModulsInProg.Panel2Collapsed = True
        Me.SplitModulsInProg.Size = New System.Drawing.Size(390, 830)
        Me.SplitModulsInProg.SplitterDistance = 803
        Me.SplitModulsInProg.TabIndex = 4
        '
        'dataGridModuls
        '
        Me.dataGridModuls.AllowUserToAddRows = False
        Me.dataGridModuls.AllowUserToDeleteRows = False
        Me.dataGridModuls.AllowUserToOrderColumns = True
        Me.dataGridModuls.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dataGridModuls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridModuls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridModuls.Location = New System.Drawing.Point(0, 0)
        Me.dataGridModuls.MultiSelect = False
        Me.dataGridModuls.Name = "dataGridModuls"
        Me.dataGridModuls.ReadOnly = True
        Me.dataGridModuls.RowHeadersVisible = False
        Me.dataGridModuls.RowHeadersWidth = 53
        Me.dataGridModuls.Size = New System.Drawing.Size(390, 830)
        Me.dataGridModuls.TabIndex = 34
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
        'ToolStrip3
        '
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTop, Me.ToolStripBottom, Me.addMidulInGroupp, Me.modulInProgsIndicator, Me.tbl_moduls_sum_hours})
        Me.ToolStrip3.Location = New System.Drawing.Point(390, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(46, 830)
        Me.ToolStrip3.TabIndex = 3
        Me.ToolStrip3.Text = "ToolStrip3"
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
        Me.tbl_moduls_sum_hours.BackColor = System.Drawing.Color.White
        Me.tbl_moduls_sum_hours.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbl_moduls_sum_hours.Enabled = False
        Me.tbl_moduls_sum_hours.Font = New System.Drawing.Font("Microsoft YaHei", 16.0!, System.Drawing.FontStyle.Bold)
        Me.tbl_moduls_sum_hours.Name = "tbl_moduls_sum_hours"
        Me.tbl_moduls_sum_hours.ReadOnly = True
        Me.tbl_moduls_sum_hours.Size = New System.Drawing.Size(41, 29)
        Me.tbl_moduls_sum_hours.Text = "0"
        '
        'SplitContainerModuls
        '
        Me.SplitContainerModuls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerModuls.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerModuls.Name = "SplitContainerModuls"
        Me.SplitContainerModuls.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerModuls.Panel1
        '
        Me.SplitContainerModuls.Panel1.Controls.Add(Me.DataGridAllModuls)
        '
        'SplitContainerModuls.Panel2
        '
        Me.SplitContainerModuls.Panel2.Controls.Add(Me.TableLayoutAddNewModul)
        Me.SplitContainerModuls.Panel2Collapsed = True
        Me.SplitContainerModuls.Size = New System.Drawing.Size(298, 830)
        Me.SplitContainerModuls.SplitterDistance = 676
        Me.SplitContainerModuls.TabIndex = 4
        '
        'DataGridAllModuls
        '
        Me.DataGridAllModuls.AllowUserToAddRows = False
        Me.DataGridAllModuls.AllowUserToDeleteRows = False
        Me.DataGridAllModuls.AllowUserToOrderColumns = True
        Me.DataGridAllModuls.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridAllModuls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridAllModuls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridAllModuls.Location = New System.Drawing.Point(0, 0)
        Me.DataGridAllModuls.MultiSelect = False
        Me.DataGridAllModuls.Name = "DataGridAllModuls"
        Me.DataGridAllModuls.ReadOnly = True
        Me.DataGridAllModuls.RowHeadersVisible = False
        Me.DataGridAllModuls.RowHeadersWidth = 53
        Me.DataGridAllModuls.Size = New System.Drawing.Size(298, 830)
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
        Me.ToolStrip4.Location = New System.Drawing.Point(298, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(46, 830)
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
        Me.TabPage5.Controls.Add(Me.PanelSetts)
        Me.TabPage5.ImageIndex = 19
        Me.TabPage5.Location = New System.Drawing.Point(4, 27)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1352, 836)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Настройки"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'passwrdSetts
        '
        Me.passwrdSetts.Location = New System.Drawing.Point(3, 3)
        Me.passwrdSetts.Name = "passwrdSetts"
        Me.passwrdSetts.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwrdSetts.Size = New System.Drawing.Size(556, 22)
        Me.passwrdSetts.TabIndex = 54
        '
        'PanelSetts
        '
        Me.PanelSetts.Controls.Add(Me.Label7)
        Me.PanelSetts.Controls.Add(Me.Согласовано2ДолжностьПУ)
        Me.PanelSetts.Controls.Add(Me.ПоискСлушателейПоУм)
        Me.PanelSetts.Controls.Add(Me.Согласовано2ПУ)
        Me.PanelSetts.Controls.Add(Me.ПоискГруппПоУм)
        Me.PanelSetts.Controls.Add(Me.Согласовано1ДолжностьПУ)
        Me.PanelSetts.Controls.Add(Me.Label8)
        Me.PanelSetts.Controls.Add(Me.Согласовано1ПУ)
        Me.PanelSetts.Controls.Add(Me.НастройкаСортировкиСлушателей)
        Me.PanelSetts.Controls.Add(Me.ДиректорДолжность)
        Me.PanelSetts.Controls.Add(Me.Label10)
        Me.PanelSetts.Controls.Add(Me.ДиректорФИО)
        Me.PanelSetts.Controls.Add(Me.НастройкаСортировкиГрупп)
        Me.PanelSetts.Controls.Add(Me.КоличествоСтрокВТаблице)
        Me.PanelSetts.Controls.Add(Me.Label9)
        Me.PanelSetts.Controls.Add(Me.Label16)
        Me.PanelSetts.Controls.Add(Me.Label11)
        Me.PanelSetts.Controls.Add(Me.Label17)
        Me.PanelSetts.Controls.Add(Me.Label12)
        Me.PanelSetts.Controls.Add(Me.Label15)
        Me.PanelSetts.Controls.Add(Me.Label13)
        Me.PanelSetts.Controls.Add(Me.Label14)
        Me.PanelSetts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSetts.Location = New System.Drawing.Point(0, 0)
        Me.PanelSetts.Name = "PanelSetts"
        Me.PanelSetts.Size = New System.Drawing.Size(1352, 836)
        Me.PanelSetts.TabIndex = 53
        Me.PanelSetts.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(321, 18)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Параметр поиска слушателей по умолчанию"
        '
        'Согласовано2ДолжностьПУ
        '
        Me.Согласовано2ДолжностьПУ.Location = New System.Drawing.Point(479, 293)
        Me.Согласовано2ДолжностьПУ.Name = "Согласовано2ДолжностьПУ"
        Me.Согласовано2ДолжностьПУ.Size = New System.Drawing.Size(808, 22)
        Me.Согласовано2ДолжностьПУ.TabIndex = 52
        '
        'ПоискСлушателейПоУм
        '
        Me.ПоискСлушателейПоУм.FormattingEnabled = True
        Me.ПоискСлушателейПоУм.Items.AddRange(New Object() {"Снилс", "Фамилия", "Имя", "Отчество"})
        Me.ПоискСлушателейПоУм.Location = New System.Drawing.Point(479, 9)
        Me.ПоискСлушателейПоУм.Name = "ПоискСлушателейПоУм"
        Me.ПоискСлушателейПоУм.Size = New System.Drawing.Size(808, 24)
        Me.ПоискСлушателейПоУм.TabIndex = 31
        '
        'Согласовано2ПУ
        '
        Me.Согласовано2ПУ.Location = New System.Drawing.Point(479, 265)
        Me.Согласовано2ПУ.Name = "Согласовано2ПУ"
        Me.Согласовано2ПУ.Size = New System.Drawing.Size(808, 22)
        Me.Согласовано2ПУ.TabIndex = 50
        '
        'ПоискГруппПоУм
        '
        Me.ПоискГруппПоУм.AutoCompleteCustomSource.AddRange(New String() {"Номер", "Специальность", "Программа"})
        Me.ПоискГруппПоУм.FormattingEnabled = True
        Me.ПоискГруппПоУм.Items.AddRange(New Object() {"Номер", "Программа", "Специальность"})
        Me.ПоискГруппПоУм.Location = New System.Drawing.Point(479, 38)
        Me.ПоискГруппПоУм.Name = "ПоискГруппПоУм"
        Me.ПоискГруппПоУм.Size = New System.Drawing.Size(808, 24)
        Me.ПоискГруппПоУм.TabIndex = 33
        '
        'Согласовано1ДолжностьПУ
        '
        Me.Согласовано1ДолжностьПУ.Location = New System.Drawing.Point(479, 237)
        Me.Согласовано1ДолжностьПУ.Name = "Согласовано1ДолжностьПУ"
        Me.Согласовано1ДолжностьПУ.Size = New System.Drawing.Size(808, 22)
        Me.Согласовано1ДолжностьПУ.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(275, 18)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Параметр поиска групп по умолчанию"
        '
        'Согласовано1ПУ
        '
        Me.Согласовано1ПУ.Location = New System.Drawing.Point(479, 209)
        Me.Согласовано1ПУ.Name = "Согласовано1ПУ"
        Me.Согласовано1ПУ.Size = New System.Drawing.Size(808, 22)
        Me.Согласовано1ПУ.TabIndex = 46
        '
        'НастройкаСортировкиСлушателей
        '
        Me.НастройкаСортировкиСлушателей.FormattingEnabled = True
        Me.НастройкаСортировкиСлушателей.Items.AddRange(New Object() {"Снилс", "Фамилия", "Имя"})
        Me.НастройкаСортировкиСлушателей.Location = New System.Drawing.Point(479, 67)
        Me.НастройкаСортировкиСлушателей.Name = "НастройкаСортировкиСлушателей"
        Me.НастройкаСортировкиСлушателей.Size = New System.Drawing.Size(808, 24)
        Me.НастройкаСортировкиСлушателей.TabIndex = 35
        '
        'ДиректорДолжность
        '
        Me.ДиректорДолжность.Location = New System.Drawing.Point(479, 181)
        Me.ДиректорДолжность.Name = "ДиректорДолжность"
        Me.ДиректорДолжность.Size = New System.Drawing.Size(808, 22)
        Me.ДиректорДолжность.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(353, 18)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Параметр сортировки слушателей по умолчанию"
        '
        'ДиректорФИО
        '
        Me.ДиректорФИО.Location = New System.Drawing.Point(479, 153)
        Me.ДиректорФИО.Name = "ДиректорФИО"
        Me.ДиректорФИО.Size = New System.Drawing.Size(808, 22)
        Me.ДиректорФИО.TabIndex = 42
        '
        'НастройкаСортировкиГрупп
        '
        Me.НастройкаСортировкиГрупп.AutoCompleteCustomSource.AddRange(New String() {"Номер", "Специальность", "Программа"})
        Me.НастройкаСортировкиГрупп.FormattingEnabled = True
        Me.НастройкаСортировкиГрупп.Items.AddRange(New Object() {"Номер", "Программа", "Специальность"})
        Me.НастройкаСортировкиГрупп.Location = New System.Drawing.Point(479, 96)
        Me.НастройкаСортировкиГрупп.Name = "НастройкаСортировкиГрупп"
        Me.НастройкаСортировкиГрупп.Size = New System.Drawing.Size(808, 24)
        Me.НастройкаСортировкиГрупп.TabIndex = 37
        '
        'КоличествоСтрокВТаблице
        '
        Me.КоличествоСтрокВТаблице.Location = New System.Drawing.Point(479, 125)
        Me.КоличествоСтрокВТаблице.Name = "КоличествоСтрокВТаблице"
        Me.КоличествоСтрокВТаблице.Size = New System.Drawing.Size(808, 22)
        Me.КоличествоСтрокВТаблице.TabIndex = 40
        Me.КоличествоСтрокВТаблице.Text = "1000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(307, 18)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Параметр сортировки групп по умолчанию"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 293)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(186, 18)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Согласовано Должность"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(351, 18)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Количество отображаемых строк в справочнике"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 265)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 18)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Согласовано"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 153)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 18)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Директор ФИО"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 237)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(186, 18)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Согласовано Должность"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(161, 18)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Директор Должность"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 209)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 18)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Согласовано"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ChРМАНПО)
        Me.TabPage4.Controls.Add(Me.Button1)
        Me.TabPage4.Controls.Add(Me.КнигаДипломовФРДО)
        Me.TabPage4.Controls.Add(Me.КнигаУчетаУдостоверенийФРДО)
        Me.TabPage4.Controls.Add(Me.КнигаСвидетельствФРДО)
        Me.TabPage4.Controls.Add(Me.ОтчетПеднагрузка)
        Me.TabPage4.Controls.Add(Me.КнигаУчетаСвидетельств)
        Me.TabPage4.Controls.Add(Me.СводПоОрганиз)
        Me.TabPage4.Controls.Add(Me.КнигаУчетаДипломов)
        Me.TabPage4.Controls.Add(Me.БюджетВбюдж)
        Me.TabPage4.Controls.Add(Me.КнигаУчетаУдостоверений)
        Me.TabPage4.Controls.Add(Me.ChСводПоКурсам)
        Me.TabPage4.Controls.Add(Me.СводПоСпец)
        Me.TabPage4.Controls.Add(Me.ДатаНачалаОтчета)
        Me.TabPage4.Controls.Add(Me.ОтчетРуководителя)
        Me.TabPage4.Controls.Add(Me.ДатаКонцаОтчета)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.GroupBox6)
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Controls.Add(Me.GroupBox7)
        Me.TabPage4.ImageIndex = 0
        Me.TabPage4.Location = New System.Drawing.Point(4, 27)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1352, 836)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Отчеты"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ChРМАНПО
        '
        Me.ChРМАНПО.AutoSize = True
        Me.ChРМАНПО.Location = New System.Drawing.Point(18, 215)
        Me.ChРМАНПО.Name = "ChРМАНПО"
        Me.ChРМАНПО.Size = New System.Drawing.Size(85, 20)
        Me.ChРМАНПО.TabIndex = 9
        Me.ChРМАНПО.Text = "РМАНПО"
        Me.ChРМАНПО.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(8, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(155, 41)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Сформировать"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'КнигаДипломовФРДО
        '
        Me.КнигаДипломовФРДО.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.КнигаДипломовФРДО.FlatAppearance.BorderSize = 0
        Me.КнигаДипломовФРДО.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнигаДипломовФРДО.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.КнигаДипломовФРДО.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаДипломовФРДО.Location = New System.Drawing.Point(8, 567)
        Me.КнигаДипломовФРДО.Name = "КнигаДипломовФРДО"
        Me.КнигаДипломовФРДО.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнигаДипломовФРДО.Size = New System.Drawing.Size(1252, 50)
        Me.КнигаДипломовФРДО.TabIndex = 14
        Me.КнигаДипломовФРДО.Text = "Книга учета выданных дипломов ФРДО"
        Me.КнигаДипломовФРДО.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаДипломовФРДО.UseVisualStyleBackColor = True
        '
        'КнигаУчетаУдостоверенийФРДО
        '
        Me.КнигаУчетаУдостоверенийФРДО.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.КнигаУчетаУдостоверенийФРДО.FlatAppearance.BorderSize = 0
        Me.КнигаУчетаУдостоверенийФРДО.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнигаУчетаУдостоверенийФРДО.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.КнигаУчетаУдостоверенийФРДО.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаУдостоверенийФРДО.Location = New System.Drawing.Point(8, 514)
        Me.КнигаУчетаУдостоверенийФРДО.Name = "КнигаУчетаУдостоверенийФРДО"
        Me.КнигаУчетаУдостоверенийФРДО.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнигаУчетаУдостоверенийФРДО.Size = New System.Drawing.Size(1252, 50)
        Me.КнигаУчетаУдостоверенийФРДО.TabIndex = 13
        Me.КнигаУчетаУдостоверенийФРДО.Text = "Книга учета выданных удостоверений ФРДО"
        Me.КнигаУчетаУдостоверенийФРДО.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаУдостоверенийФРДО.UseVisualStyleBackColor = True
        '
        'КнигаСвидетельствФРДО
        '
        Me.КнигаСвидетельствФРДО.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.КнигаСвидетельствФРДО.FlatAppearance.BorderSize = 0
        Me.КнигаСвидетельствФРДО.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнигаСвидетельствФРДО.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.КнигаСвидетельствФРДО.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаСвидетельствФРДО.Location = New System.Drawing.Point(8, 620)
        Me.КнигаСвидетельствФРДО.Name = "КнигаСвидетельствФРДО"
        Me.КнигаСвидетельствФРДО.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнигаСвидетельствФРДО.Size = New System.Drawing.Size(1252, 50)
        Me.КнигаСвидетельствФРДО.TabIndex = 15
        Me.КнигаСвидетельствФРДО.Text = "Книга учета выданных свидетельств ФРДО"
        Me.КнигаСвидетельствФРДО.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаСвидетельствФРДО.UseVisualStyleBackColor = True
        '
        'ОтчетПеднагрузка
        '
        Me.ОтчетПеднагрузка.AutoSize = True
        Me.ОтчетПеднагрузка.Location = New System.Drawing.Point(18, 189)
        Me.ОтчетПеднагрузка.Name = "ОтчетПеднагрузка"
        Me.ОтчетПеднагрузка.Size = New System.Drawing.Size(113, 20)
        Me.ОтчетПеднагрузка.TabIndex = 8
        Me.ОтчетПеднагрузка.Text = "Педнагрузка"
        Me.ОтчетПеднагрузка.UseVisualStyleBackColor = True
        '
        'КнигаУчетаСвидетельств
        '
        Me.КнигаУчетаСвидетельств.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.КнигаУчетаСвидетельств.FlatAppearance.BorderSize = 0
        Me.КнигаУчетаСвидетельств.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнигаУчетаСвидетельств.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.КнигаУчетаСвидетельств.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаСвидетельств.Location = New System.Drawing.Point(4, 427)
        Me.КнигаУчетаСвидетельств.Name = "КнигаУчетаСвидетельств"
        Me.КнигаУчетаСвидетельств.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнигаУчетаСвидетельств.Size = New System.Drawing.Size(1256, 50)
        Me.КнигаУчетаСвидетельств.TabIndex = 12
        Me.КнигаУчетаСвидетельств.Text = "Книга учёта выданных свидетельств"
        Me.КнигаУчетаСвидетельств.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаСвидетельств.UseVisualStyleBackColor = True
        '
        'СводПоОрганиз
        '
        Me.СводПоОрганиз.AutoSize = True
        Me.СводПоОрганиз.Location = New System.Drawing.Point(18, 137)
        Me.СводПоОрганиз.Name = "СводПоОрганиз"
        Me.СводПоОрганиз.Size = New System.Drawing.Size(175, 20)
        Me.СводПоОрганиз.TabIndex = 6
        Me.СводПоОрганиз.Text = "Свод по организациям"
        Me.СводПоОрганиз.UseVisualStyleBackColor = True
        '
        'КнигаУчетаДипломов
        '
        Me.КнигаУчетаДипломов.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.КнигаУчетаДипломов.FlatAppearance.BorderSize = 0
        Me.КнигаУчетаДипломов.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнигаУчетаДипломов.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.КнигаУчетаДипломов.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаДипломов.Location = New System.Drawing.Point(4, 374)
        Me.КнигаУчетаДипломов.Name = "КнигаУчетаДипломов"
        Me.КнигаУчетаДипломов.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнигаУчетаДипломов.Size = New System.Drawing.Size(1256, 50)
        Me.КнигаУчетаДипломов.TabIndex = 11
        Me.КнигаУчетаДипломов.Text = "Книга учёта выданных дипломов"
        Me.КнигаУчетаДипломов.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаДипломов.UseVisualStyleBackColor = True
        '
        'БюджетВбюдж
        '
        Me.БюджетВбюдж.AutoSize = True
        Me.БюджетВбюдж.Location = New System.Drawing.Point(18, 163)
        Me.БюджетВбюдж.Name = "БюджетВбюдж"
        Me.БюджетВбюдж.Size = New System.Drawing.Size(156, 20)
        Me.БюджетВбюдж.TabIndex = 7
        Me.БюджетВбюдж.Text = "Бюджет/Внебюджет"
        Me.БюджетВбюдж.UseVisualStyleBackColor = True
        '
        'КнигаУчетаУдостоверений
        '
        Me.КнигаУчетаУдостоверений.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.КнигаУчетаУдостоверений.FlatAppearance.BorderSize = 0
        Me.КнигаУчетаУдостоверений.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнигаУчетаУдостоверений.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.КнигаУчетаУдостоверений.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаУдостоверений.Location = New System.Drawing.Point(4, 321)
        Me.КнигаУчетаУдостоверений.Name = "КнигаУчетаУдостоверений"
        Me.КнигаУчетаУдостоверений.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнигаУчетаУдостоверений.Size = New System.Drawing.Size(1256, 50)
        Me.КнигаУчетаУдостоверений.TabIndex = 10
        Me.КнигаУчетаУдостоверений.Text = "Книга учета выданных удостоверений"
        Me.КнигаУчетаУдостоверений.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнигаУчетаУдостоверений.UseVisualStyleBackColor = True
        '
        'ChСводПоКурсам
        '
        Me.ChСводПоКурсам.AutoSize = True
        Me.ChСводПоКурсам.Location = New System.Drawing.Point(18, 85)
        Me.ChСводПоКурсам.Name = "ChСводПоКурсам"
        Me.ChСводПоКурсам.Size = New System.Drawing.Size(128, 20)
        Me.ChСводПоКурсам.TabIndex = 4
        Me.ChСводПоКурсам.Text = "Свод по курсам"
        Me.ChСводПоКурсам.UseVisualStyleBackColor = True
        '
        'СводПоСпец
        '
        Me.СводПоСпец.AutoSize = True
        Me.СводПоСпец.Location = New System.Drawing.Point(18, 111)
        Me.СводПоСпец.Name = "СводПоСпец"
        Me.СводПоСпец.Size = New System.Drawing.Size(189, 20)
        Me.СводПоСпец.TabIndex = 5
        Me.СводПоСпец.Text = "Свод по специальностям"
        Me.СводПоСпец.UseVisualStyleBackColor = True
        '
        'ДатаНачалаОтчета
        '
        Me.ДатаНачалаОтчета.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаНачалаОтчета.Location = New System.Drawing.Point(82, 7)
        Me.ДатаНачалаОтчета.Name = "ДатаНачалаОтчета"
        Me.ДатаНачалаОтчета.Size = New System.Drawing.Size(105, 22)
        Me.ДатаНачалаОтчета.TabIndex = 1
        '
        'ОтчетРуководителя
        '
        Me.ОтчетРуководителя.AutoSize = True
        Me.ОтчетРуководителя.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ОтчетРуководителя.FlatAppearance.BorderSize = 2
        Me.ОтчетРуководителя.Location = New System.Drawing.Point(18, 61)
        Me.ОтчетРуководителя.Name = "ОтчетРуководителя"
        Me.ОтчетРуководителя.Size = New System.Drawing.Size(162, 20)
        Me.ОтчетРуководителя.TabIndex = 3
        Me.ОтчетРуководителя.Text = "Отчет руководителя"
        Me.ОтчетРуководителя.UseVisualStyleBackColor = False
        '
        'ДатаКонцаОтчета
        '
        Me.ДатаКонцаОтчета.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаКонцаОтчета.Location = New System.Drawing.Point(214, 7)
        Me.ДатаКонцаОтчета.Name = "ДатаКонцаОтчета"
        Me.ДатаКонцаОтчета.Size = New System.Drawing.Size(101, 22)
        Me.ДатаКонцаОтчета.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Период с:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(189, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "по"
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 312)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1343, 178)
        Me.GroupBox6.TabIndex = 120
        Me.GroupBox6.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 47)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1343, 248)
        Me.GroupBox5.TabIndex = 119
        Me.GroupBox5.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 504)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1343, 178)
        Me.GroupBox7.TabIndex = 121
        Me.GroupBox7.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.СправкаОбОкончании)
        Me.TabPage2.Controls.Add(Me.СправкаОбОбучении)
        Me.TabPage2.Controls.Add(Me.ПП_Ведомость)
        Me.TabPage2.Controls.Add(Me.ВедомостьПромежуточнойАттестации)
        Me.TabPage2.Controls.Add(Me.ДоверенностьПолученияБланковСлушателей)
        Me.TabPage2.Controls.Add(Me.ДоверенностьПолученияБланков)
        Me.TabPage2.Controls.Add(Me.Ведомость_слушателиИорганизации)
        Me.TabPage2.Controls.Add(Me.ПО_Свидетельство)
        Me.TabPage2.Controls.Add(Me.Карточка_слушателя)
        Me.TabPage2.Controls.Add(Me.ПП_Заявление)
        Me.TabPage2.Controls.Add(Me.ПК_Заявление)
        Me.TabPage2.Controls.Add(Me.ПП_ПриложениеКдиплому)
        Me.TabPage2.ImageIndex = 5
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1352, 836)
        Me.TabPage2.TabIndex = 5
        Me.TabPage2.Text = "Бланки"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'СправкаОбОкончании
        '
        Me.СправкаОбОкончании.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.СправкаОбОкончании.FlatAppearance.BorderSize = 0
        Me.СправкаОбОкончании.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.СправкаОбОкончании.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СправкаОбОкончании.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправкаОбОкончании.Location = New System.Drawing.Point(3, 432)
        Me.СправкаОбОкончании.Name = "СправкаОбОкончании"
        Me.СправкаОбОкончании.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.СправкаОбОкончании.Size = New System.Drawing.Size(1240, 36)
        Me.СправкаОбОкончании.TabIndex = 12
        Me.СправкаОбОкончании.Text = "Справка об окончании без ИА"
        Me.СправкаОбОкончании.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправкаОбОкончании.UseVisualStyleBackColor = True
        '
        'СправкаОбОбучении
        '
        Me.СправкаОбОбучении.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.СправкаОбОбучении.FlatAppearance.BorderSize = 0
        Me.СправкаОбОбучении.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.СправкаОбОбучении.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СправкаОбОбучении.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправкаОбОбучении.Location = New System.Drawing.Point(3, 393)
        Me.СправкаОбОбучении.Name = "СправкаОбОбучении"
        Me.СправкаОбОбучении.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.СправкаОбОбучении.Size = New System.Drawing.Size(1240, 36)
        Me.СправкаОбОбучении.TabIndex = 11
        Me.СправкаОбОбучении.Text = "Справка об обучении"
        Me.СправкаОбОбучении.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправкаОбОбучении.UseVisualStyleBackColor = True
        '
        'ПП_Ведомость
        '
        Me.ПП_Ведомость.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПП_Ведомость.FlatAppearance.BorderSize = 0
        Me.ПП_Ведомость.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПП_Ведомость.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПП_Ведомость.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Ведомость.Location = New System.Drawing.Point(3, 354)
        Me.ПП_Ведомость.Name = "ПП_Ведомость"
        Me.ПП_Ведомость.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПП_Ведомость.Size = New System.Drawing.Size(1240, 36)
        Me.ПП_Ведомость.TabIndex = 10
        Me.ПП_Ведомость.Text = "ПП_Ведомость промежуточной аттестации"
        Me.ПП_Ведомость.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Ведомость.UseVisualStyleBackColor = True
        '
        'ВедомостьПромежуточнойАттестации
        '
        Me.ВедомостьПромежуточнойАттестации.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ВедомостьПромежуточнойАттестации.FlatAppearance.BorderSize = 0
        Me.ВедомостьПромежуточнойАттестации.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ВедомостьПромежуточнойАттестации.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ВедомостьПромежуточнойАттестации.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ВедомостьПромежуточнойАттестации.Location = New System.Drawing.Point(3, 315)
        Me.ВедомостьПромежуточнойАттестации.Name = "ВедомостьПромежуточнойАттестации"
        Me.ВедомостьПромежуточнойАттестации.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ВедомостьПромежуточнойАттестации.Size = New System.Drawing.Size(1240, 36)
        Me.ВедомостьПромежуточнойАттестации.TabIndex = 9
        Me.ВедомостьПромежуточнойАттестации.Text = "ПО_Ведомость промежуточной аттестации"
        Me.ВедомостьПромежуточнойАттестации.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ВедомостьПромежуточнойАттестации.UseVisualStyleBackColor = True
        '
        'ДоверенностьПолученияБланковСлушателей
        '
        Me.ДоверенностьПолученияБланковСлушателей.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ДоверенностьПолученияБланковСлушателей.FlatAppearance.BorderSize = 0
        Me.ДоверенностьПолученияБланковСлушателей.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ДоверенностьПолученияБланковСлушателей.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ДоверенностьПолученияБланковСлушателей.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДоверенностьПолученияБланковСлушателей.Location = New System.Drawing.Point(3, 276)
        Me.ДоверенностьПолученияБланковСлушателей.Name = "ДоверенностьПолученияБланковСлушателей"
        Me.ДоверенностьПолученияБланковСлушателей.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ДоверенностьПолученияБланковСлушателей.Size = New System.Drawing.Size(1240, 36)
        Me.ДоверенностьПолученияБланковСлушателей.TabIndex = 8
        Me.ДоверенностьПолученияБланковСлушателей.Text = "Доверенность получения бланков на отдельных слушателей"
        Me.ДоверенностьПолученияБланковСлушателей.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДоверенностьПолученияБланковСлушателей.UseVisualStyleBackColor = True
        '
        'ДоверенностьПолученияБланков
        '
        Me.ДоверенностьПолученияБланков.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ДоверенностьПолученияБланков.FlatAppearance.BorderSize = 0
        Me.ДоверенностьПолученияБланков.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ДоверенностьПолученияБланков.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ДоверенностьПолученияБланков.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДоверенностьПолученияБланков.Location = New System.Drawing.Point(3, 237)
        Me.ДоверенностьПолученияБланков.Name = "ДоверенностьПолученияБланков"
        Me.ДоверенностьПолученияБланков.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ДоверенностьПолученияБланков.Size = New System.Drawing.Size(1240, 36)
        Me.ДоверенностьПолученияБланков.TabIndex = 7
        Me.ДоверенностьПолученияБланков.Text = "Доверенность получения бланков на группу"
        Me.ДоверенностьПолученияБланков.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДоверенностьПолученияБланков.UseVisualStyleBackColor = True
        '
        'Ведомость_слушателиИорганизации
        '
        Me.Ведомость_слушателиИорганизации.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Ведомость_слушателиИорганизации.FlatAppearance.BorderSize = 0
        Me.Ведомость_слушателиИорганизации.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ведомость_слушателиИорганизации.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Ведомость_слушателиИорганизации.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Ведомость_слушателиИорганизации.Location = New System.Drawing.Point(3, 198)
        Me.Ведомость_слушателиИорганизации.Name = "Ведомость_слушателиИорганизации"
        Me.Ведомость_слушателиИорганизации.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ведомость_слушателиИорганизации.Size = New System.Drawing.Size(1240, 36)
        Me.Ведомость_слушателиИорганизации.TabIndex = 6
        Me.Ведомость_слушателиИорганизации.Text = "Ведомость слушатели и организации"
        Me.Ведомость_слушателиИорганизации.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Ведомость_слушателиИорганизации.UseVisualStyleBackColor = True
        '
        'ПО_Свидетельство
        '
        Me.ПО_Свидетельство.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПО_Свидетельство.FlatAppearance.BorderSize = 0
        Me.ПО_Свидетельство.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПО_Свидетельство.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПО_Свидетельство.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Свидетельство.Location = New System.Drawing.Point(3, 42)
        Me.ПО_Свидетельство.Name = "ПО_Свидетельство"
        Me.ПО_Свидетельство.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПО_Свидетельство.Size = New System.Drawing.Size(1240, 36)
        Me.ПО_Свидетельство.TabIndex = 2
        Me.ПО_Свидетельство.Text = "ПО_Свидетельство"
        Me.ПО_Свидетельство.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Свидетельство.UseVisualStyleBackColor = True
        '
        'Карточка_слушателя
        '
        Me.Карточка_слушателя.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Карточка_слушателя.FlatAppearance.BorderSize = 0
        Me.Карточка_слушателя.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Карточка_слушателя.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Карточка_слушателя.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Карточка_слушателя.Location = New System.Drawing.Point(3, 159)
        Me.Карточка_слушателя.Name = "Карточка_слушателя"
        Me.Карточка_слушателя.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Карточка_слушателя.Size = New System.Drawing.Size(1240, 36)
        Me.Карточка_слушателя.TabIndex = 5
        Me.Карточка_слушателя.Text = "Карточка_слушателя"
        Me.Карточка_слушателя.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Карточка_слушателя.UseVisualStyleBackColor = True
        '
        'ПП_Заявление
        '
        Me.ПП_Заявление.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПП_Заявление.FlatAppearance.BorderSize = 0
        Me.ПП_Заявление.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПП_Заявление.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПП_Заявление.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Заявление.Location = New System.Drawing.Point(3, 120)
        Me.ПП_Заявление.Name = "ПП_Заявление"
        Me.ПП_Заявление.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПП_Заявление.Size = New System.Drawing.Size(1240, 36)
        Me.ПП_Заявление.TabIndex = 4
        Me.ПП_Заявление.Text = "ПП_Заявление"
        Me.ПП_Заявление.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Заявление.UseVisualStyleBackColor = True
        '
        'ПК_Заявление
        '
        Me.ПК_Заявление.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПК_Заявление.FlatAppearance.BorderSize = 0
        Me.ПК_Заявление.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПК_Заявление.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПК_Заявление.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Заявление.Location = New System.Drawing.Point(3, 81)
        Me.ПК_Заявление.Name = "ПК_Заявление"
        Me.ПК_Заявление.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПК_Заявление.Size = New System.Drawing.Size(1240, 36)
        Me.ПК_Заявление.TabIndex = 3
        Me.ПК_Заявление.Text = "ПК_Заявление"
        Me.ПК_Заявление.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Заявление.UseVisualStyleBackColor = True
        '
        'ПП_ПриложениеКдиплому
        '
        Me.ПП_ПриложениеКдиплому.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПП_ПриложениеКдиплому.FlatAppearance.BorderSize = 0
        Me.ПП_ПриложениеКдиплому.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПП_ПриложениеКдиплому.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПП_ПриложениеКдиплому.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_ПриложениеКдиплому.Location = New System.Drawing.Point(3, 3)
        Me.ПП_ПриложениеКдиплому.Name = "ПП_ПриложениеКдиплому"
        Me.ПП_ПриложениеКдиплому.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПП_ПриложениеКдиплому.Size = New System.Drawing.Size(1240, 36)
        Me.ПП_ПриложениеКдиплому.TabIndex = 1
        Me.ПП_ПриложениеКдиплому.Text = "ПП_Приложение к диплому"
        Me.ПП_ПриложениеКдиплому.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_ПриложениеКдиплому.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ПриказОЗачислении_Доп)
        Me.TabPage3.Controls.Add(Me.ПК_Окончание_уд)
        Me.TabPage3.Controls.Add(Me.ПО_Окончание)
        Me.TabPage3.Controls.Add(Me.ПП_Окончание)
        Me.TabPage3.Controls.Add(Me.ПК_Окончание)
        Me.TabPage3.Controls.Add(Me.ПП_ДопускКИА)
        Me.TabPage3.Controls.Add(Me.ПО_ДопускКИА)
        Me.TabPage3.Controls.Add(Me.ПК_Отчисление)
        Me.TabPage3.Controls.Add(Me.ПО_Практика)
        Me.TabPage3.Controls.Add(Me.ПП_Практика)
        Me.TabPage3.Controls.Add(Me.ПО_Зачисление)
        Me.TabPage3.Controls.Add(Me.ППЗачисление)
        Me.TabPage3.Controls.Add(Me.ПриказОЗачислении)
        Me.TabPage3.ImageIndex = 2
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1352, 836)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Приказы"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ПриказОЗачислении_Доп
        '
        Me.ПриказОЗачислении_Доп.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПриказОЗачислении_Доп.FlatAppearance.BorderSize = 0
        Me.ПриказОЗачислении_Доп.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПриказОЗачислении_Доп.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПриказОЗачислении_Доп.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПриказОЗачислении_Доп.Location = New System.Drawing.Point(3, 42)
        Me.ПриказОЗачислении_Доп.Name = "ПриказОЗачислении_Доп"
        Me.ПриказОЗачислении_Доп.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПриказОЗачислении_Доп.Size = New System.Drawing.Size(1240, 36)
        Me.ПриказОЗачислении_Доп.TabIndex = 2
        Me.ПриказОЗачислении_Доп.Text = "ПК_Зачисление доп"
        Me.ПриказОЗачислении_Доп.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПриказОЗачислении_Доп.UseVisualStyleBackColor = True
        '
        'ПК_Окончание_уд
        '
        Me.ПК_Окончание_уд.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПК_Окончание_уд.FlatAppearance.BorderSize = 0
        Me.ПК_Окончание_уд.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПК_Окончание_уд.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПК_Окончание_уд.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Окончание_уд.Location = New System.Drawing.Point(0, 470)
        Me.ПК_Окончание_уд.Name = "ПК_Окончание_уд"
        Me.ПК_Окончание_уд.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПК_Окончание_уд.Size = New System.Drawing.Size(1240, 36)
        Me.ПК_Окончание_уд.TabIndex = 13
        Me.ПК_Окончание_уд.Text = "ПК_Окончание_уд"
        Me.ПК_Окончание_уд.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Окончание_уд.UseVisualStyleBackColor = True
        '
        'ПО_Окончание
        '
        Me.ПО_Окончание.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПО_Окончание.FlatAppearance.BorderSize = 0
        Me.ПО_Окончание.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПО_Окончание.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПО_Окончание.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Окончание.Location = New System.Drawing.Point(3, 431)
        Me.ПО_Окончание.Name = "ПО_Окончание"
        Me.ПО_Окончание.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПО_Окончание.Size = New System.Drawing.Size(1240, 36)
        Me.ПО_Окончание.TabIndex = 12
        Me.ПО_Окончание.Text = "ПО_Окончание"
        Me.ПО_Окончание.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Окончание.UseVisualStyleBackColor = True
        '
        'ПП_Окончание
        '
        Me.ПП_Окончание.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПП_Окончание.FlatAppearance.BorderSize = 0
        Me.ПП_Окончание.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПП_Окончание.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПП_Окончание.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Окончание.Location = New System.Drawing.Point(3, 274)
        Me.ПП_Окончание.Name = "ПП_Окончание"
        Me.ПП_Окончание.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПП_Окончание.Size = New System.Drawing.Size(1240, 36)
        Me.ПП_Окончание.TabIndex = 8
        Me.ПП_Окончание.Text = "ПП_Окончание"
        Me.ПП_Окончание.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Окончание.UseVisualStyleBackColor = True
        '
        'ПК_Окончание
        '
        Me.ПК_Окончание.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПК_Окончание.FlatAppearance.BorderSize = 0
        Me.ПК_Окончание.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПК_Окончание.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПК_Окончание.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Окончание.Location = New System.Drawing.Point(3, 120)
        Me.ПК_Окончание.Name = "ПК_Окончание"
        Me.ПК_Окончание.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПК_Окончание.Size = New System.Drawing.Size(1240, 36)
        Me.ПК_Окончание.TabIndex = 4
        Me.ПК_Окончание.Text = "ПК_Окончание"
        Me.ПК_Окончание.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Окончание.UseVisualStyleBackColor = True
        '
        'ПП_ДопускКИА
        '
        Me.ПП_ДопускКИА.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПП_ДопускКИА.FlatAppearance.BorderSize = 0
        Me.ПП_ДопускКИА.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПП_ДопускКИА.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПП_ДопускКИА.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_ДопускКИА.Location = New System.Drawing.Point(3, 235)
        Me.ПП_ДопускКИА.Name = "ПП_ДопускКИА"
        Me.ПП_ДопускКИА.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПП_ДопускКИА.Size = New System.Drawing.Size(1240, 36)
        Me.ПП_ДопускКИА.TabIndex = 7
        Me.ПП_ДопускКИА.Text = "ПП_Допуск к ИА"
        Me.ПП_ДопускКИА.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_ДопускКИА.UseVisualStyleBackColor = True
        '
        'ПО_ДопускКИА
        '
        Me.ПО_ДопускКИА.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПО_ДопускКИА.FlatAppearance.BorderSize = 0
        Me.ПО_ДопускКИА.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПО_ДопускКИА.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПО_ДопускКИА.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_ДопускКИА.Location = New System.Drawing.Point(3, 392)
        Me.ПО_ДопускКИА.Name = "ПО_ДопускКИА"
        Me.ПО_ДопускКИА.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПО_ДопускКИА.Size = New System.Drawing.Size(1240, 36)
        Me.ПО_ДопускКИА.TabIndex = 11
        Me.ПО_ДопускКИА.Text = "ПО_Допуск к ИА"
        Me.ПО_ДопускКИА.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_ДопускКИА.UseVisualStyleBackColor = True
        '
        'ПК_Отчисление
        '
        Me.ПК_Отчисление.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПК_Отчисление.FlatAppearance.BorderSize = 0
        Me.ПК_Отчисление.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПК_Отчисление.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПК_Отчисление.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Отчисление.Location = New System.Drawing.Point(3, 78)
        Me.ПК_Отчисление.Name = "ПК_Отчисление"
        Me.ПК_Отчисление.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПК_Отчисление.Size = New System.Drawing.Size(1240, 36)
        Me.ПК_Отчисление.TabIndex = 3
        Me.ПК_Отчисление.Text = "ПК_Отчисление"
        Me.ПК_Отчисление.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПК_Отчисление.UseVisualStyleBackColor = True
        '
        'ПО_Практика
        '
        Me.ПО_Практика.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПО_Практика.FlatAppearance.BorderSize = 0
        Me.ПО_Практика.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПО_Практика.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПО_Практика.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Практика.Location = New System.Drawing.Point(3, 353)
        Me.ПО_Практика.Name = "ПО_Практика"
        Me.ПО_Практика.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПО_Практика.Size = New System.Drawing.Size(1240, 36)
        Me.ПО_Практика.TabIndex = 10
        Me.ПО_Практика.Text = "ПО_Практика"
        Me.ПО_Практика.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Практика.UseVisualStyleBackColor = True
        '
        'ПП_Практика
        '
        Me.ПП_Практика.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПП_Практика.FlatAppearance.BorderSize = 0
        Me.ПП_Практика.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПП_Практика.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПП_Практика.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Практика.Location = New System.Drawing.Point(3, 197)
        Me.ПП_Практика.Name = "ПП_Практика"
        Me.ПП_Практика.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПП_Практика.Size = New System.Drawing.Size(1240, 36)
        Me.ПП_Практика.TabIndex = 6
        Me.ПП_Практика.Text = "ПП_Практика"
        Me.ПП_Практика.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПП_Практика.UseVisualStyleBackColor = True
        '
        'ПО_Зачисление
        '
        Me.ПО_Зачисление.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПО_Зачисление.FlatAppearance.BorderSize = 0
        Me.ПО_Зачисление.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПО_Зачисление.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПО_Зачисление.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Зачисление.Location = New System.Drawing.Point(3, 314)
        Me.ПО_Зачисление.Name = "ПО_Зачисление"
        Me.ПО_Зачисление.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПО_Зачисление.Size = New System.Drawing.Size(1240, 36)
        Me.ПО_Зачисление.TabIndex = 9
        Me.ПО_Зачисление.Text = "ПО_Зачисление"
        Me.ПО_Зачисление.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПО_Зачисление.UseVisualStyleBackColor = True
        '
        'ППЗачисление
        '
        Me.ППЗачисление.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ППЗачисление.FlatAppearance.BorderSize = 0
        Me.ППЗачисление.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ППЗачисление.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ППЗачисление.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ППЗачисление.Location = New System.Drawing.Point(3, 158)
        Me.ППЗачисление.Name = "ППЗачисление"
        Me.ППЗачисление.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ППЗачисление.Size = New System.Drawing.Size(1240, 36)
        Me.ППЗачисление.TabIndex = 5
        Me.ППЗачисление.Text = "ПП_Зачисление"
        Me.ППЗачисление.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ППЗачисление.UseVisualStyleBackColor = True
        '
        'ПриказОЗачислении
        '
        Me.ПриказОЗачислении.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ПриказОЗачислении.FlatAppearance.BorderSize = 0
        Me.ПриказОЗачислении.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ПриказОЗачислении.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ПриказОЗачислении.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПриказОЗачислении.Location = New System.Drawing.Point(3, 3)
        Me.ПриказОЗачислении.Name = "ПриказОЗачислении"
        Me.ПриказОЗачислении.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ПриказОЗачислении.Size = New System.Drawing.Size(1240, 36)
        Me.ПриказОЗачислении.TabIndex = 1
        Me.ПриказОЗачислении.Text = "ПК_Зачисление"
        Me.ПриказОЗачислении.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ПриказОЗачислении.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage1.Controls.Add(Me.СправочникГруппыПП)
        Me.TabPage1.Controls.Add(Me.СправочникГруппыПО)
        Me.TabPage1.Controls.Add(Me.Педнагрузка)
        Me.TabPage1.Controls.Add(Me.Ведомость)
        Me.TabPage1.Controls.Add(Me.КнопкаСоздатьГруппу)
        Me.TabPage1.Controls.Add(Me.ДобавитьСлушателя)
        Me.TabPage1.Controls.Add(Me.СправочникСлушатели)
        Me.TabPage1.Controls.Add(Me.СправочникГруппыПК)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.ИтоговаяАттествцияОценки)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.ImageIndex = 20
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1352, 836)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Главная"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'СправочникГруппыПП
        '
        Me.СправочникГруппыПП.BackColor = System.Drawing.Color.Transparent
        Me.СправочникГруппыПП.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.СправочникГруппыПП.FlatAppearance.BorderSize = 0
        Me.СправочникГруппыПП.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.СправочникГруппыПП.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СправочникГруппыПП.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникГруппыПП.Location = New System.Drawing.Point(20, 68)
        Me.СправочникГруппыПП.Name = "СправочникГруппыПП"
        Me.СправочникГруппыПП.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.СправочникГруппыПП.Size = New System.Drawing.Size(1240, 50)
        Me.СправочникГруппыПП.TabIndex = 2
        Me.СправочникГруппыПП.Text = "Профессиональная переподготовка"
        Me.СправочникГруппыПП.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникГруппыПП.UseVisualStyleBackColor = False
        '
        'СправочникГруппыПО
        '
        Me.СправочникГруппыПО.BackColor = System.Drawing.Color.Transparent
        Me.СправочникГруппыПО.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.СправочникГруппыПО.FlatAppearance.BorderSize = 0
        Me.СправочникГруппыПО.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.СправочникГруппыПО.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СправочникГруппыПО.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникГруппыПО.Location = New System.Drawing.Point(20, 121)
        Me.СправочникГруппыПО.Name = "СправочникГруппыПО"
        Me.СправочникГруппыПО.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.СправочникГруппыПО.Size = New System.Drawing.Size(1240, 50)
        Me.СправочникГруппыПО.TabIndex = 3
        Me.СправочникГруппыПО.Text = "Профессиональное обучение"
        Me.СправочникГруппыПО.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникГруппыПО.UseVisualStyleBackColor = False
        '
        'Педнагрузка
        '
        Me.Педнагрузка.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Педнагрузка.FlatAppearance.BorderSize = 0
        Me.Педнагрузка.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Педнагрузка.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Педнагрузка.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Педнагрузка.Location = New System.Drawing.Point(20, 658)
        Me.Педнагрузка.Name = "Педнагрузка"
        Me.Педнагрузка.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Педнагрузка.Size = New System.Drawing.Size(1240, 50)
        Me.Педнагрузка.TabIndex = 9
        Me.Педнагрузка.Text = "Педнагрузка"
        Me.Педнагрузка.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Педнагрузка.UseVisualStyleBackColor = True
        '
        'Ведомость
        '
        Me.Ведомость.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Ведомость.FlatAppearance.BorderSize = 0
        Me.Ведомость.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Ведомость.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Ведомость.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Ведомость.Location = New System.Drawing.Point(20, 552)
        Me.Ведомость.Name = "Ведомость"
        Me.Ведомость.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ведомость.Size = New System.Drawing.Size(1240, 50)
        Me.Ведомость.TabIndex = 7
        Me.Ведомость.Text = "Ведомость"
        Me.Ведомость.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Ведомость.UseVisualStyleBackColor = True
        '
        'КнопкаСоздатьГруппу
        '
        Me.КнопкаСоздатьГруппу.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.КнопкаСоздатьГруппу.FlatAppearance.BorderSize = 0
        Me.КнопкаСоздатьГруппу.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.КнопкаСоздатьГруппу.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.КнопкаСоздатьГруппу.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнопкаСоздатьГруппу.Location = New System.Drawing.Point(20, 174)
        Me.КнопкаСоздатьГруппу.Name = "КнопкаСоздатьГруппу"
        Me.КнопкаСоздатьГруппу.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.КнопкаСоздатьГруппу.Size = New System.Drawing.Size(1240, 50)
        Me.КнопкаСоздатьГруппу.TabIndex = 4
        Me.КнопкаСоздатьГруппу.Text = "Создать группу"
        Me.КнопкаСоздатьГруппу.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.КнопкаСоздатьГруппу.UseVisualStyleBackColor = True
        '
        'ДобавитьСлушателя
        '
        Me.ДобавитьСлушателя.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ДобавитьСлушателя.FlatAppearance.BorderSize = 0
        Me.ДобавитьСлушателя.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ДобавитьСлушателя.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ДобавитьСлушателя.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДобавитьСлушателя.Location = New System.Drawing.Point(20, 393)
        Me.ДобавитьСлушателя.Name = "ДобавитьСлушателя"
        Me.ДобавитьСлушателя.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ДобавитьСлушателя.Size = New System.Drawing.Size(1240, 50)
        Me.ДобавитьСлушателя.TabIndex = 6
        Me.ДобавитьСлушателя.Text = "Добавить нового слушателя"
        Me.ДобавитьСлушателя.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДобавитьСлушателя.UseVisualStyleBackColor = True
        '
        'СправочникСлушатели
        '
        Me.СправочникСлушатели.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.СправочникСлушатели.FlatAppearance.BorderSize = 0
        Me.СправочникСлушатели.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.СправочникСлушатели.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СправочникСлушатели.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникСлушатели.Location = New System.Drawing.Point(20, 340)
        Me.СправочникСлушатели.Name = "СправочникСлушатели"
        Me.СправочникСлушатели.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.СправочникСлушатели.Size = New System.Drawing.Size(1240, 50)
        Me.СправочникСлушатели.TabIndex = 5
        Me.СправочникСлушатели.Text = "Открыть справочник Слушатели"
        Me.СправочникСлушатели.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникСлушатели.UseVisualStyleBackColor = True
        '
        'СправочникГруппыПК
        '
        Me.СправочникГруппыПК.BackColor = System.Drawing.Color.Transparent
        Me.СправочникГруппыПК.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.СправочникГруппыПК.FlatAppearance.BorderSize = 0
        Me.СправочникГруппыПК.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.СправочникГруппыПК.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СправочникГруппыПК.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникГруппыПК.Location = New System.Drawing.Point(20, 15)
        Me.СправочникГруппыПК.Name = "СправочникГруппыПК"
        Me.СправочникГруппыПК.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.СправочникГруппыПК.Size = New System.Drawing.Size(1240, 50)
        Me.СправочникГруппыПК.TabIndex = 1
        Me.СправочникГруппыПК.Text = "Повышение квалификации"
        Me.СправочникГруппыПК.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.СправочникГруппыПК.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1332, 299)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(20, 768)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 328)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1332, 174)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'ИтоговаяАттествцияОценки
        '
        Me.ИтоговаяАттествцияОценки.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ИтоговаяАттествцияОценки.FlatAppearance.BorderSize = 0
        Me.ИтоговаяАттествцияОценки.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ИтоговаяАттествцияОценки.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ИтоговаяАттествцияОценки.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ИтоговаяАттествцияОценки.Location = New System.Drawing.Point(20, 605)
        Me.ИтоговаяАттествцияОценки.Name = "ИтоговаяАттествцияОценки"
        Me.ИтоговаяАттествцияОценки.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ИтоговаяАттествцияОценки.Size = New System.Drawing.Size(1240, 50)
        Me.ИтоговаяАттествцияОценки.TabIndex = 8
        Me.ИтоговаяАттествцияОценки.Text = "Итоговая аттестация"
        Me.ИтоговаяАттествцияОценки.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ИтоговаяАттествцияОценки.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 536)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1332, 174)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
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
        Me.TabControlOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabControlOther.ImageList = Me.ImageList1
        Me.TabControlOther.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TabControlOther.Location = New System.Drawing.Point(0, 0)
        Me.TabControlOther.Name = "TabControlOther"
        Me.TabControlOther.SelectedIndex = 0
        Me.TabControlOther.Size = New System.Drawing.Size(1360, 867)
        Me.TabControlOther.TabIndex = 0
        '
        'Other
        '
        Me.Other.Controls.Add(Me.passwordOther)
        Me.Other.Controls.Add(Me.SplitContainerOther)
        Me.Other.ImageIndex = 18
        Me.Other.Location = New System.Drawing.Point(4, 27)
        Me.Other.Name = "Other"
        Me.Other.Size = New System.Drawing.Size(1352, 836)
        Me.Other.TabIndex = 8
        Me.Other.Text = "Прочее"
        Me.Other.UseVisualStyleBackColor = True
        '
        'passwordOther
        '
        Me.passwordOther.Location = New System.Drawing.Point(3, 3)
        Me.passwordOther.Name = "passwordOther"
        Me.passwordOther.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwordOther.Size = New System.Drawing.Size(556, 22)
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
        Me.SplitContainerOther.Size = New System.Drawing.Size(1352, 836)
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
        Me.Panel_main.Size = New System.Drawing.Size(1352, 788)
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
        Me.SplitContainerOtherList.Size = New System.Drawing.Size(1352, 788)
        Me.SplitContainerOtherList.SplitterDistance = 26
        Me.SplitContainerOtherList.TabIndex = 4
        '
        'DataGridView_list
        '
        Me.DataGridView_list.AllowUserToAddRows = False
        Me.DataGridView_list.AllowUserToDeleteRows = False
        Me.DataGridView_list.AllowUserToOrderColumns = True
        Me.DataGridView_list.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_list.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.checkBox, Me.FIO, Me.FIO_full, Me.FIO_pad, Me.Doljnost, Me.type, Me.kod})
        Me.DataGridView_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_list.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_list.MultiSelect = False
        Me.DataGridView_list.Name = "DataGridView_list"
        Me.DataGridView_list.ReadOnly = True
        Me.DataGridView_list.RowHeadersVisible = False
        Me.DataGridView_list.RowHeadersWidth = 53
        Me.DataGridView_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_list.Size = New System.Drawing.Size(1352, 788)
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
        Me.spravka.Size = New System.Drawing.Size(144, 0)
        Me.spravka.TabIndex = 44
        Me.spravka.Text = "Укажите ФИО в формате Фамилия И.О."
        '
        'worker_type
        '
        Me.worker_type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.worker_type.FormattingEnabled = True
        Me.worker_type.ItemHeight = 16
        Me.worker_type.Location = New System.Drawing.Point(3, 117)
        Me.worker_type.Name = "worker_type"
        Me.worker_type.Size = New System.Drawing.Size(144, 24)
        Me.worker_type.TabIndex = 1004
        '
        'worker_dolgnost
        '
        Me.worker_dolgnost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_dolgnost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.worker_dolgnost.FormattingEnabled = True
        Me.worker_dolgnost.ItemHeight = 16
        Me.worker_dolgnost.Location = New System.Drawing.Point(3, 87)
        Me.worker_dolgnost.Name = "worker_dolgnost"
        Me.worker_dolgnost.Size = New System.Drawing.Size(144, 24)
        Me.worker_dolgnost.TabIndex = 1003
        '
        'worker_name_pad
        '
        Me.worker_name_pad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_name_pad.Location = New System.Drawing.Point(3, 59)
        Me.worker_name_pad.Multiline = True
        Me.worker_name_pad.Name = "worker_name_pad"
        Me.worker_name_pad.Size = New System.Drawing.Size(144, 22)
        Me.worker_name_pad.TabIndex = 1002
        '
        'worker_name_full
        '
        Me.worker_name_full.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_name_full.Location = New System.Drawing.Point(3, 31)
        Me.worker_name_full.Multiline = True
        Me.worker_name_full.Name = "worker_name_full"
        Me.worker_name_full.Size = New System.Drawing.Size(144, 22)
        Me.worker_name_full.TabIndex = 1001
        '
        'worker_name
        '
        Me.worker_name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.worker_name.Location = New System.Drawing.Point(3, 3)
        Me.worker_name.Multiline = True
        Me.worker_name.Name = "worker_name"
        Me.worker_name.Size = New System.Drawing.Size(144, 22)
        Me.worker_name.TabIndex = 1000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStrip_name_list, Me.other_add, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1352, 48)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ToolStripLabel2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(56, 45)
        Me.ToolStripLabel2.Text = "таблица"
        '
        'ToolStrip_name_list
        '
        Me.ToolStrip_name_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStrip_name_list.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
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
        'ImageList40
        '
        Me.ImageList40.ImageStream = CType(resources.GetObject("ImageList40.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList40.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList40.Images.SetKeyName(0, "green.png")
        Me.ImageList40.Images.SetKeyName(1, "black.png")
        Me.ImageList40.Images.SetKeyName(2, "ok.png")
        Me.ImageList40.Images.SetKeyName(3, "okGr.png")
        '
        'ААОсновная
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1360, 867)
        Me.Controls.Add(Me.TabControlOther)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "ААОсновная"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ФГБУ ДПО ВУНМЦ Минздрава России"
        Me.pageProgs.ResumeLayout(False)
        Me.pageProgs.PerformLayout()
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.Panel2.PerformLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.SplitModulsInProg.Panel1.ResumeLayout(False)
        Me.SplitModulsInProg.Panel2.ResumeLayout(False)
        Me.SplitModulsInProg.Panel2.PerformLayout()
        CType(Me.SplitModulsInProg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitModulsInProg.ResumeLayout(False)
        CType(Me.dataGridModuls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.SplitContainerModuls.Panel1.ResumeLayout(False)
        Me.SplitContainerModuls.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerModuls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerModuls.ResumeLayout(False)
        CType(Me.DataGridAllModuls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutAddNewModul.ResumeLayout(False)
        Me.TableLayoutAddNewModul.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.PanelSetts.ResumeLayout(False)
        Me.PanelSetts.PerformLayout()
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
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents pageProgs As TabPage
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents comboBoxProgramms As ToolStripComboBox
    Private WithEvents ToolStripAddProg As ToolStripButton
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents SplitModulsInProg As SplitContainer
    Private WithEvents dataGridModuls As DataGridView
    Friend WithEvents ToolStrip3 As ToolStrip
    Private WithEvents ToolStripTop As ToolStripButton
    Private WithEvents ToolStripBottom As ToolStripButton
    Private WithEvents addMidulInGroupp As ToolStripButton
    Friend WithEvents SplitContainerModuls As SplitContainer
    Private WithEvents DataGridAllModuls As DataGridView
    Friend WithEvents ToolStrip4 As ToolStrip
    Private WithEvents ToolStripAddModul As ToolStripButton
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Согласовано2ДолжностьПУ As TextBox
    Friend WithEvents Согласовано2ПУ As TextBox
    Friend WithEvents Согласовано1ДолжностьПУ As TextBox
    Friend WithEvents Согласовано1ПУ As TextBox
    Friend WithEvents ДиректорДолжность As TextBox
    Friend WithEvents ДиректорФИО As TextBox
    Friend WithEvents КоличествоСтрокВТаблице As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents НастройкаСортировкиГрупп As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents НастройкаСортировкиСлушателей As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ПоискГруппПоУм As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ПоискСлушателейПоУм As ComboBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents ChРМАНПО As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents КнигаДипломовФРДО As Button
    Friend WithEvents КнигаУчетаУдостоверенийФРДО As Button
    Friend WithEvents КнигаСвидетельствФРДО As Button
    Friend WithEvents ОтчетПеднагрузка As CheckBox
    Friend WithEvents КнигаУчетаСвидетельств As Button
    Friend WithEvents СводПоОрганиз As CheckBox
    Friend WithEvents КнигаУчетаДипломов As Button
    Friend WithEvents БюджетВбюдж As CheckBox
    Friend WithEvents КнигаУчетаУдостоверений As Button
    Friend WithEvents ChСводПоКурсам As CheckBox
    Friend WithEvents СводПоСпец As CheckBox
    Friend WithEvents ДатаНачалаОтчета As DateTimePicker
    Friend WithEvents ОтчетРуководителя As CheckBox
    Friend WithEvents ДатаКонцаОтчета As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents СправкаОбОкончании As Button
    Friend WithEvents СправкаОбОбучении As Button
    Friend WithEvents ПП_Ведомость As Button
    Friend WithEvents ВедомостьПромежуточнойАттестации As Button
    Friend WithEvents ДоверенностьПолученияБланковСлушателей As Button
    Friend WithEvents ДоверенностьПолученияБланков As Button
    Friend WithEvents Ведомость_слушателиИорганизации As Button
    Friend WithEvents ПО_Свидетельство As Button
    Friend WithEvents Карточка_слушателя As Button
    Friend WithEvents ПП_Заявление As Button
    Friend WithEvents ПК_Заявление As Button
    Friend WithEvents ПП_ПриложениеКдиплому As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents ПК_Окончание_уд As Button
    Friend WithEvents ПО_Окончание As Button
    Friend WithEvents ПП_Окончание As Button
    Friend WithEvents ПК_Окончание As Button
    Friend WithEvents ПП_ДопускКИА As Button
    Friend WithEvents ПО_ДопускКИА As Button
    Friend WithEvents ПК_Отчисление As Button
    Friend WithEvents ПО_Практика As Button
    Friend WithEvents ПП_Практика As Button
    Friend WithEvents ПО_Зачисление As Button
    Friend WithEvents ППЗачисление As Button
    Friend WithEvents ПриказОЗачислении As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents СправочникГруппыПП As Button
    Friend WithEvents СправочникГруппыПО As Button
    Friend WithEvents Педнагрузка As Button
    Friend WithEvents ИтоговаяАттествцияОценки As Button
    Friend WithEvents Ведомость As Button
    Friend WithEvents КнопкаСоздатьГруппу As Button
    Friend WithEvents ДобавитьСлушателя As Button
    Friend WithEvents СправочникСлушатели As Button
    Friend WithEvents СправочникГруппыПК As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
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
    Friend WithEvents ПриказОЗачислении_Доп As Button
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
    Friend WithEvents ImageList40 As ImageList
    Friend WithEvents passwrdSetts As MaskedTextBox
    Friend WithEvents PanelSetts As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStrip_name_list As ToolStripComboBox
    Private WithEvents other_add As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Panel_main As Panel
    Friend WithEvents programms_tbl_parent As Panel
    Friend WithEvents tbl_moduls_sum_hours As ToolStripTextBox
End Class
