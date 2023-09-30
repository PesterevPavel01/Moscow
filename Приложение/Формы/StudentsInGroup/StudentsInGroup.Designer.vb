<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentsInGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentsInGroup))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.mainConteiner = New System.Windows.Forms.SplitContainer()
        Me.container = New System.Windows.Forms.Panel()
        Me.panelOrders = New System.Windows.Forms.Panel()
        Me.toolOrders = New System.Windows.Forms.ToolStrip()
        Me.closePanelOrders = New System.Windows.Forms.ToolStripButton()
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.newStudent = New System.Windows.Forms.ToolStripButton()
        Me.studentsList = New System.Windows.Forms.ToolStripButton()
        Me.everyone = New System.Windows.Forms.ToolStripButton()
        Me.allInfo = New System.Windows.Forms.ToolStripButton()
        Me.orders = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.mainConteiner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainConteiner.Panel1.SuspendLayout()
        Me.mainConteiner.Panel2.SuspendLayout()
        Me.mainConteiner.SuspendLayout()
        Me.toolOrders.SuspendLayout()
        Me.header.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(5, 5)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainer1.Panel1Collapsed = True
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.mainConteiner)
        Me.SplitContainer1.Panel2.Controls.Add(Me.header)
        Me.SplitContainer1.Size = New System.Drawing.Size(1899, 691)
        Me.SplitContainer1.SplitterDistance = 45
        Me.SplitContainer1.TabIndex = 7
        '
        'mainConteiner
        '
        Me.mainConteiner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainConteiner.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.mainConteiner.Location = New System.Drawing.Point(0, 47)
        Me.mainConteiner.Name = "mainConteiner"
        '
        'mainConteiner.Panel1
        '
        Me.mainConteiner.Panel1.Controls.Add(Me.container)
        '
        'mainConteiner.Panel2
        '
        Me.mainConteiner.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.mainConteiner.Panel2.Controls.Add(Me.panelOrders)
        Me.mainConteiner.Panel2.Controls.Add(Me.toolOrders)
        Me.mainConteiner.Panel2Collapsed = True
        Me.mainConteiner.Size = New System.Drawing.Size(1899, 644)
        Me.mainConteiner.SplitterDistance = 1397
        Me.mainConteiner.TabIndex = 14
        '
        'container
        '
        Me.container.AutoSize = True
        Me.container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.container.Location = New System.Drawing.Point(0, 0)
        Me.container.Name = "container"
        Me.container.Size = New System.Drawing.Size(1899, 644)
        Me.container.TabIndex = 7
        '
        'panelOrders
        '
        Me.panelOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelOrders.Location = New System.Drawing.Point(0, 29)
        Me.panelOrders.Name = "panelOrders"
        Me.panelOrders.Size = New System.Drawing.Size(498, 615)
        Me.panelOrders.TabIndex = 16
        '
        'toolOrders
        '
        Me.toolOrders.AllowMerge = False
        Me.toolOrders.BackColor = System.Drawing.SystemColors.Window
        Me.toolOrders.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolOrders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.closePanelOrders})
        Me.toolOrders.Location = New System.Drawing.Point(0, 0)
        Me.toolOrders.Name = "toolOrders"
        Me.toolOrders.Size = New System.Drawing.Size(498, 29)
        Me.toolOrders.TabIndex = 15
        Me.toolOrders.TabStop = True
        '
        'closePanelOrders
        '
        Me.closePanelOrders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.closePanelOrders.Image = CType(resources.GetObject("closePanelOrders.Image"), System.Drawing.Image)
        Me.closePanelOrders.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.closePanelOrders.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.closePanelOrders.Name = "closePanelOrders"
        Me.closePanelOrders.Size = New System.Drawing.Size(26, 26)
        Me.closePanelOrders.Text = "документы"
        Me.closePanelOrders.ToolTipText = "документы"
        '
        'header
        '
        Me.header.AllowMerge = False
        Me.header.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.header.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newStudent, Me.studentsList, Me.everyone, Me.allInfo, Me.orders})
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1899, 47)
        Me.header.TabIndex = 6
        Me.header.Text = "ToolStrip1"
        '
        'newStudent
        '
        Me.newStudent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.newStudent.Image = CType(resources.GetObject("newStudent.Image"), System.Drawing.Image)
        Me.newStudent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.newStudent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.newStudent.Name = "newStudent"
        Me.newStudent.Size = New System.Drawing.Size(44, 44)
        Me.newStudent.Text = "Новый"
        '
        'studentsList
        '
        Me.studentsList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.studentsList.Image = CType(resources.GetObject("studentsList.Image"), System.Drawing.Image)
        Me.studentsList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.studentsList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.studentsList.Name = "studentsList"
        Me.studentsList.Size = New System.Drawing.Size(44, 44)
        Me.studentsList.Text = "Слушатели"
        '
        'everyone
        '
        Me.everyone.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.everyone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.everyone.Image = CType(resources.GetObject("everyone.Image"), System.Drawing.Image)
        Me.everyone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.everyone.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.everyone.Name = "everyone"
        Me.everyone.Size = New System.Drawing.Size(44, 44)
        Me.everyone.Text = "Прочее"
        Me.everyone.ToolTipText = "распространить на всех"
        Me.everyone.Visible = False
        '
        'allInfo
        '
        Me.allInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.allInfo.Image = CType(resources.GetObject("allInfo.Image"), System.Drawing.Image)
        Me.allInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.allInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.allInfo.Name = "allInfo"
        Me.allInfo.Size = New System.Drawing.Size(44, 44)
        Me.allInfo.Text = "информация о группе"
        Me.allInfo.ToolTipText = "информация о группе"
        '
        'orders
        '
        Me.orders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.orders.Image = CType(resources.GetObject("orders.Image"), System.Drawing.Image)
        Me.orders.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.orders.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.orders.Name = "orders"
        Me.orders.Size = New System.Drawing.Size(44, 44)
        Me.orders.Text = "документы"
        Me.orders.ToolTipText = "документы"
        '
        'StudentsInGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1909, 701)
        Me.Controls.Add(Me.SplitContainer1)
        Me.KeyPreview = True
        Me.Name = "StudentsInGroup"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form2"
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.mainConteiner.Panel1.ResumeLayout(False)
        Me.mainConteiner.Panel1.PerformLayout()
        Me.mainConteiner.Panel2.ResumeLayout(False)
        Me.mainConteiner.Panel2.PerformLayout()
        CType(Me.mainConteiner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainConteiner.ResumeLayout(False)
        Me.toolOrders.ResumeLayout(False)
        Me.toolOrders.PerformLayout()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents header As ToolStrip
    Friend WithEvents allInfo As ToolStripButton
    Friend WithEvents studentsList As ToolStripButton
    Friend WithEvents newStudent As ToolStripButton
    Friend WithEvents container As Panel
    Friend WithEvents everyone As ToolStripButton
    Friend WithEvents orders As ToolStripButton
    Friend WithEvents mainConteiner As SplitContainer
    Friend WithEvents toolOrders As ToolStrip
    Friend WithEvents panelOrders As Panel
    Friend WithEvents closePanelOrders As ToolStripButton
End Class
