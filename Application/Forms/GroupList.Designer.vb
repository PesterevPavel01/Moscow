<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GroupList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GroupList))
        Me.groupListTable = New System.Windows.Forms.ListView()
        Me.Номер = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Группа = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Программа = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Куратор = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Начало = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Конец = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnFocus = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.sortSettings = New System.Windows.Forms.ToolStripButton()
        Me.searchSettings = New System.Windows.Forms.ToolStripButton()
        Me.searchRow = New System.Windows.Forms.ToolStripTextBox()
        Me.poOn = New System.Windows.Forms.ToolStripButton()
        Me.pkOn = New System.Windows.Forms.ToolStripButton()
        Me.ppOn = New System.Windows.Forms.ToolStripButton()
        Me.yearSpravochnikGr = New System.Windows.Forms.ToolStripComboBox()
        Me.header.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupListTable
        '
        Me.groupListTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.groupListTable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Номер, Me.Группа, Me.Программа, Me.Куратор, Me.Начало, Me.Конец})
        Me.groupListTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupListTable.Font = New System.Drawing.Font("Microsoft YaHei", 11.0!)
        Me.groupListTable.FullRowSelect = True
        Me.groupListTable.GridLines = True
        Me.groupListTable.HideSelection = False
        Me.groupListTable.Location = New System.Drawing.Point(5, 52)
        Me.groupListTable.Name = "groupListTable"
        Me.groupListTable.Size = New System.Drawing.Size(1305, 890)
        Me.groupListTable.TabIndex = 1
        Me.groupListTable.UseCompatibleStateImageBehavior = False
        Me.groupListTable.View = System.Windows.Forms.View.Details
        '
        'Номер
        '
        Me.Номер.Text = "Код"
        Me.Номер.Width = 50
        '
        'Группа
        '
        Me.Группа.Text = "Группа"
        Me.Группа.Width = 200
        '
        'Программа
        '
        Me.Программа.Text = "Программа"
        Me.Программа.Width = 500
        '
        'Куратор
        '
        Me.Куратор.Text = "Ответственный куратор"
        Me.Куратор.Width = 300
        '
        'Начало
        '
        Me.Начало.Text = "Дата начала"
        Me.Начало.Width = 120
        '
        'Конец
        '
        Me.Конец.Text = "Дата окончания"
        Me.Конец.Width = 140
        '
        'BtnFocus
        '
        Me.BtnFocus.ImageList = Me.ImageList1
        Me.BtnFocus.Location = New System.Drawing.Point(599, 111)
        Me.BtnFocus.Name = "BtnFocus"
        Me.BtnFocus.Size = New System.Drawing.Size(75, 23)
        Me.BtnFocus.TabIndex = 13
        Me.BtnFocus.Text = "Button2"
        Me.BtnFocus.UseVisualStyleBackColor = True
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
        Me.ImageList1.Images.SetKeyName(6, "Лупа.png")
        Me.ImageList1.Images.SetKeyName(7, "Сортировка35.png")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Сортировка35.png")
        '
        'header
        '
        Me.header.BackColor = System.Drawing.SystemColors.MenuBar
        Me.header.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sortSettings, Me.searchSettings, Me.searchRow, Me.poOn, Me.pkOn, Me.ppOn, Me.yearSpravochnikGr})
        Me.header.Location = New System.Drawing.Point(5, 5)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1305, 47)
        Me.header.TabIndex = 20
        Me.header.Text = "ToolStrip1"
        '
        'sortSettings
        '
        Me.sortSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sortSettings.Image = CType(resources.GetObject("sortSettings.Image"), System.Drawing.Image)
        Me.sortSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.sortSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sortSettings.Name = "sortSettings"
        Me.sortSettings.Size = New System.Drawing.Size(44, 44)
        Me.sortSettings.Text = "Настройка сортировки"
        '
        'searchSettings
        '
        Me.searchSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.searchSettings.Image = CType(resources.GetObject("searchSettings.Image"), System.Drawing.Image)
        Me.searchSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.searchSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.searchSettings.Name = "searchSettings"
        Me.searchSettings.Size = New System.Drawing.Size(44, 44)
        Me.searchSettings.Text = "Настройка поиска"
        '
        'searchRow
        '
        Me.searchRow.BackColor = System.Drawing.SystemColors.Window
        Me.searchRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.searchRow.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.searchRow.Name = "searchRow"
        Me.searchRow.Size = New System.Drawing.Size(400, 47)
        '
        'poOn
        '
        Me.poOn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.poOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.poOn.Image = CType(resources.GetObject("poOn.Image"), System.Drawing.Image)
        Me.poOn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.poOn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.poOn.Name = "poOn"
        Me.poOn.Size = New System.Drawing.Size(44, 44)
        Me.poOn.Text = "Настройка поиска"
        '
        'pkOn
        '
        Me.pkOn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.pkOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.pkOn.Image = CType(resources.GetObject("pkOn.Image"), System.Drawing.Image)
        Me.pkOn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.pkOn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pkOn.Name = "pkOn"
        Me.pkOn.Size = New System.Drawing.Size(44, 44)
        Me.pkOn.Text = "Настройка поиска"
        '
        'ppOn
        '
        Me.ppOn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ppOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ppOn.Image = CType(resources.GetObject("ppOn.Image"), System.Drawing.Image)
        Me.ppOn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ppOn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ppOn.Name = "ppOn"
        Me.ppOn.Size = New System.Drawing.Size(44, 44)
        Me.ppOn.Text = "Настройка поиска"
        '
        'yearSpravochnikGr
        '
        Me.yearSpravochnikGr.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.yearSpravochnikGr.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.yearSpravochnikGr.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.yearSpravochnikGr.Items.AddRange(New Object() {"2021", "2022", "2023", "2024", "2025", "2026"})
        Me.yearSpravochnikGr.Name = "yearSpravochnikGr"
        Me.yearSpravochnikGr.Size = New System.Drawing.Size(121, 47)
        '
        'GroupList
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1315, 947)
        Me.Controls.Add(Me.groupListTable)
        Me.Controls.Add(Me.BtnFocus)
        Me.Controls.Add(Me.header)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(12, 80)
        Me.Name = "GroupList"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Справочник Группы"
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents groupListTable As ListView
    Friend WithEvents Номер As ColumnHeader
    Friend WithEvents BtnFocus As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Группа As ColumnHeader
    Friend WithEvents Программа As ColumnHeader
    Friend WithEvents Куратор As ColumnHeader
    Friend WithEvents Начало As ColumnHeader
    Friend WithEvents Конец As ColumnHeader
    Friend WithEvents header As ToolStrip
    Friend WithEvents sortSettings As ToolStripButton
    Friend WithEvents searchSettings As ToolStripButton
    Friend WithEvents searchRow As ToolStripTextBox
    Friend WithEvents pkOn As ToolStripButton
    Friend WithEvents poOn As ToolStripButton
    Friend WithEvents ppOn As ToolStripButton
    Friend WithEvents yearSpravochnikGr As ToolStripComboBox
End Class
