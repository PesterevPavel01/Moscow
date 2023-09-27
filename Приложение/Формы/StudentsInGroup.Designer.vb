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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.newStudent = New System.Windows.Forms.ToolStripButton()
        Me.studentsList = New System.Windows.Forms.ToolStripButton()
        Me.allInfo = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.SplitContainer1.Panel1Collapsed = True
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.container)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1903, 695)
        Me.SplitContainer1.SplitterDistance = 45
        Me.SplitContainer1.TabIndex = 7
        '
        'container
        '
        Me.container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.container.Location = New System.Drawing.Point(0, 47)
        Me.container.Name = "container"
        Me.container.Size = New System.Drawing.Size(1903, 648)
        Me.container.TabIndex = 7
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newStudent, Me.studentsList, Me.allInfo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1903, 47)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'allInfo
        '
        Me.allInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.allInfo.Image = CType(resources.GetObject("allInfo.Image"), System.Drawing.Image)
        Me.allInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.allInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.allInfo.Name = "allInfo"
        Me.allInfo.Size = New System.Drawing.Size(44, 44)
        Me.allInfo.Text = "Прочее"
        '
        'StudentsInGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1909, 701)
        Me.Controls.Add(Me.SplitContainer1)
        Me.KeyPreview = True
        Me.Name = "StudentsInGroup"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form2"
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents allInfo As ToolStripButton
    Friend WithEvents studentsList As ToolStripButton
    Friend WithEvents newStudent As ToolStripButton
    Friend WithEvents container As Panel
End Class
