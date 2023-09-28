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
        Me.container = New System.Windows.Forms.Panel()
        Me.header = New System.Windows.Forms.ToolStrip()
        Me.newStudent = New System.Windows.Forms.ToolStripButton()
        Me.studentsList = New System.Windows.Forms.ToolStripButton()
        Me.everyone = New System.Windows.Forms.ToolStripButton()
        Me.allInfo = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.container)
        Me.SplitContainer1.Panel2.Controls.Add(Me.header)
        Me.SplitContainer1.Size = New System.Drawing.Size(1899, 691)
        Me.SplitContainer1.SplitterDistance = 45
        Me.SplitContainer1.TabIndex = 7
        '
        'container
        '
        Me.container.AutoSize = True
        Me.container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.container.Location = New System.Drawing.Point(0, 47)
        Me.container.Name = "container"
        Me.container.Size = New System.Drawing.Size(1899, 644)
        Me.container.TabIndex = 7
        '
        'header
        '
        Me.header.AllowMerge = False
        Me.header.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.header.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newStudent, Me.studentsList, Me.everyone, Me.allInfo})
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
End Class
