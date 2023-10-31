<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(List))
        Me.searchValue = New System.Windows.Forms.TextBox()
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.pkOn = New System.Windows.Forms.ToolStripButton()
        Me.poOn = New System.Windows.Forms.ToolStripButton()
        Me.ppOn = New System.Windows.Forms.ToolStripButton()
        Me.resultList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mainContainer = New System.Windows.Forms.SplitContainer()
        Me.header.SuspendLayout()
        CType(Me.mainContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainContainer.Panel1.SuspendLayout()
        Me.mainContainer.Panel2.SuspendLayout()
        Me.mainContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'searchValue
        '
        Me.searchValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchValue.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.searchValue.Location = New System.Drawing.Point(0, 3)
        Me.searchValue.Name = "searchValue"
        Me.searchValue.Size = New System.Drawing.Size(876, 27)
        Me.searchValue.TabIndex = 2
        '
        'header
        '
        Me.header.AutoSize = False
        Me.header.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pkOn, Me.poOn, Me.ppOn})
        Me.header.Location = New System.Drawing.Point(8, 8)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(876, 45)
        Me.header.TabIndex = 4
        Me.header.Text = "ToolStrip1"
        Me.header.Visible = False
        '
        'pkOn
        '
        Me.pkOn.AutoSize = False
        Me.pkOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.pkOn.Image = CType(resources.GetObject("pkOn.Image"), System.Drawing.Image)
        Me.pkOn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.pkOn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.pkOn.Name = "pkOn"
        Me.pkOn.Size = New System.Drawing.Size(46, 44)
        Me.pkOn.Text = "ToolStripButton1"
        '
        'poOn
        '
        Me.poOn.AutoSize = False
        Me.poOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.poOn.Image = CType(resources.GetObject("poOn.Image"), System.Drawing.Image)
        Me.poOn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.poOn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.poOn.Name = "poOn"
        Me.poOn.Size = New System.Drawing.Size(46, 44)
        Me.poOn.Text = "ToolStripButton1"
        '
        'ppOn
        '
        Me.ppOn.AutoSize = False
        Me.ppOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ppOn.Image = CType(resources.GetObject("ppOn.Image"), System.Drawing.Image)
        Me.ppOn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ppOn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ppOn.Name = "ppOn"
        Me.ppOn.Size = New System.Drawing.Size(46, 44)
        Me.ppOn.Text = "ToolStripButton1"
        '
        'resultList
        '
        Me.resultList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.resultList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.resultList.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!)
        Me.resultList.FullRowSelect = True
        Me.resultList.GridLines = True
        Me.resultList.HideSelection = False
        Me.resultList.Location = New System.Drawing.Point(0, 0)
        Me.resultList.MultiSelect = False
        Me.resultList.Name = "resultList"
        Me.resultList.Size = New System.Drawing.Size(876, 712)
        Me.resultList.TabIndex = 1
        Me.resultList.UseCompatibleStateImageBehavior = False
        Me.resultList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Номер"
        Me.ColumnHeader1.Width = 114
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Наименование"
        Me.ColumnHeader2.Width = 620
        '
        'mainContainer
        '
        Me.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.mainContainer.Location = New System.Drawing.Point(8, 8)
        Me.mainContainer.Name = "mainContainer"
        Me.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'mainContainer.Panel1
        '
        Me.mainContainer.Panel1.Controls.Add(Me.searchValue)
        '
        'mainContainer.Panel2
        '
        Me.mainContainer.Panel2.Controls.Add(Me.resultList)
        Me.mainContainer.Size = New System.Drawing.Size(876, 748)
        Me.mainContainer.SplitterDistance = 32
        Me.mainContainer.TabIndex = 5
        '
        'List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 764)
        Me.Controls.Add(Me.mainContainer)
        Me.Controls.Add(Me.header)
        Me.KeyPreview = True
        Me.Name = "List"
        Me.Padding = New System.Windows.Forms.Padding(8)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Список"
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        Me.mainContainer.Panel1.ResumeLayout(False)
        Me.mainContainer.Panel1.PerformLayout()
        Me.mainContainer.Panel2.ResumeLayout(False)
        CType(Me.mainContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents searchValue As TextBox
    Friend WithEvents header As ToolStrip
    Friend WithEvents pkOn As ToolStripButton
    Friend WithEvents poOn As ToolStripButton
    Friend WithEvents ppOn As ToolStripButton
    Friend WithEvents resultList As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents mainContainer As SplitContainer
End Class
