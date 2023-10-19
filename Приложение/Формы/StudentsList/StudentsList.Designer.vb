<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentsList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentsList))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListViewСписокСлушателей = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnFocus = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.insertIntoGroupList = New System.Windows.Forms.ToolStripButton()
        Me.sortSetts = New System.Windows.Forms.ToolStripButton()
        Me.searchSetts = New System.Windows.Forms.ToolStripButton()
        Me.searchRow = New System.Windows.Forms.ToolStripTextBox()
        Me.ССлушТаблицаИнфСлушателя = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.header.SuspendLayout()
        CType(Me.ССлушТаблицаИнфСлушателя, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListViewСписокСлушателей
        '
        Me.ListViewСписокСлушателей.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListViewСписокСлушателей.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewСписокСлушателей.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListViewСписокСлушателей.FullRowSelect = True
        Me.ListViewСписокСлушателей.GridLines = True
        Me.ListViewСписокСлушателей.HideSelection = False
        Me.ListViewСписокСлушателей.Location = New System.Drawing.Point(0, 47)
        Me.ListViewСписокСлушателей.Name = "ListViewСписокСлушателей"
        Me.ListViewСписокСлушателей.Size = New System.Drawing.Size(1317, 893)
        Me.ListViewСписокСлушателей.TabIndex = 1
        Me.ListViewСписокСлушателей.UseCompatibleStateImageBehavior = False
        Me.ListViewСписокСлушателей.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Номер"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "СНИЛС"
        Me.ColumnHeader6.Width = 300
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Фамилия"
        Me.ColumnHeader1.Width = 300
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Имя"
        Me.ColumnHeader2.Width = 300
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Отчество"
        Me.ColumnHeader3.Width = 300
        '
        'BtnFocus
        '
        Me.BtnFocus.Location = New System.Drawing.Point(1032, 2)
        Me.BtnFocus.Name = "BtnFocus"
        Me.BtnFocus.Size = New System.Drawing.Size(75, 23)
        Me.BtnFocus.TabIndex = 11
        Me.BtnFocus.Text = "Button2"
        Me.BtnFocus.UseVisualStyleBackColor = True
        Me.BtnFocus.Visible = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Сортировка35.png")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(5, 5)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListViewСписокСлушателей)
        Me.SplitContainer1.Panel1.Controls.Add(Me.header)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ССлушТаблицаИнфСлушателя)
        Me.SplitContainer1.Size = New System.Drawing.Size(1914, 940)
        Me.SplitContainer1.SplitterDistance = 1317
        Me.SplitContainer1.TabIndex = 20
        '
        'header
        '
        Me.header.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.header.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.insertIntoGroupList, Me.sortSetts, Me.searchSetts, Me.searchRow})
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1317, 47)
        Me.header.TabIndex = 4
        Me.header.Text = "ToolStrip1"
        '
        'insertIntoGroupList
        '
        Me.insertIntoGroupList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.insertIntoGroupList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.insertIntoGroupList.Image = CType(resources.GetObject("insertIntoGroupList.Image"), System.Drawing.Image)
        Me.insertIntoGroupList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.insertIntoGroupList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.insertIntoGroupList.Name = "insertIntoGroupList"
        Me.insertIntoGroupList.Size = New System.Drawing.Size(44, 44)
        Me.insertIntoGroupList.Text = "Добавить"
        Me.insertIntoGroupList.Visible = False
        '
        'sortSetts
        '
        Me.sortSetts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sortSetts.Image = CType(resources.GetObject("sortSetts.Image"), System.Drawing.Image)
        Me.sortSetts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.sortSetts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sortSetts.Name = "sortSetts"
        Me.sortSetts.Size = New System.Drawing.Size(44, 44)
        Me.sortSetts.Text = "Настройка сортировки"
        '
        'searchSetts
        '
        Me.searchSetts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.searchSetts.Image = CType(resources.GetObject("searchSetts.Image"), System.Drawing.Image)
        Me.searchSetts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.searchSetts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.searchSetts.Name = "searchSetts"
        Me.searchSetts.Size = New System.Drawing.Size(44, 44)
        Me.searchSetts.Text = "Настройка поиска"
        '
        'searchRow
        '
        Me.searchRow.BackColor = System.Drawing.SystemColors.Window
        Me.searchRow.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.searchRow.Name = "searchRow"
        Me.searchRow.Size = New System.Drawing.Size(400, 47)
        '
        'ССлушТаблицаИнфСлушателя
        '
        Me.ССлушТаблицаИнфСлушателя.AllowUserToAddRows = False
        Me.ССлушТаблицаИнфСлушателя.AllowUserToDeleteRows = False
        Me.ССлушТаблицаИнфСлушателя.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ССлушТаблицаИнфСлушателя.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ССлушТаблицаИнфСлушателя.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ССлушТаблицаИнфСлушателя.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ССлушТаблицаИнфСлушателя.DefaultCellStyle = DataGridViewCellStyle2
        Me.ССлушТаблицаИнфСлушателя.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ССлушТаблицаИнфСлушателя.Location = New System.Drawing.Point(0, 0)
        Me.ССлушТаблицаИнфСлушателя.Name = "ССлушТаблицаИнфСлушателя"
        Me.ССлушТаблицаИнфСлушателя.ReadOnly = True
        Me.ССлушТаблицаИнфСлушателя.RowHeadersVisible = False
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ССлушТаблицаИнфСлушателя.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.ССлушТаблицаИнфСлушателя.Size = New System.Drawing.Size(593, 940)
        Me.ССлушТаблицаИнфСлушателя.TabIndex = 1
        '
        'StudentsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 950)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BtnFocus)
        Me.KeyPreview = True
        Me.Name = "StudentsList"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Справочник ""Слушатели"""
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        CType(Me.ССлушТаблицаИнфСлушателя, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewСписокСлушателей As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents BtnFocus As Button
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ССлушТаблицаИнфСлушателя As DataGridView
    Friend WithEvents header As ToolStrip
    Friend WithEvents searchSetts As ToolStripButton
    Friend WithEvents searchRow As ToolStripTextBox
    Friend WithEvents insertIntoGroupList As ToolStripButton
    Friend WithEvents sortSetts As ToolStripButton
End Class
