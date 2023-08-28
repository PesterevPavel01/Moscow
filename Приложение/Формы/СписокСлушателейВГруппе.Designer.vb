<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StudentList))
        Me.ListViewStudentsList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
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
        'ListViewStudentsList
        '
        Me.ListViewStudentsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.ListViewStudentsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewStudentsList.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListViewStudentsList.FullRowSelect = True
        Me.ListViewStudentsList.GridLines = True
        Me.ListViewStudentsList.HideSelection = False
        Me.ListViewStudentsList.Location = New System.Drawing.Point(0, 47)
        Me.ListViewStudentsList.MultiSelect = False
        Me.ListViewStudentsList.Name = "ListViewStudentsList"
        Me.ListViewStudentsList.Size = New System.Drawing.Size(1115, 648)
        Me.ListViewStudentsList.TabIndex = 4
        Me.ListViewStudentsList.UseCompatibleStateImageBehavior = False
        Me.ListViewStudentsList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Номер"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "СНИЛС"
        Me.ColumnHeader2.Width = 172
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Фамилия"
        Me.ColumnHeader8.Width = 250
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Имя"
        Me.ColumnHeader9.Width = 230
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Отчество"
        Me.ColumnHeader10.Width = 240
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Дата рождения"
        Me.ColumnHeader11.Width = 131
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewStudentsList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1115, 695)
        Me.SplitContainer1.SplitterDistance = 45
        Me.SplitContainer1.TabIndex = 7
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newStudent, Me.studentsList, Me.allInfo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1115, 47)
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
        'StudentList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 701)
        Me.Controls.Add(Me.SplitContainer1)
        Me.KeyPreview = True
        Me.Name = "StudentList"
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

    Friend WithEvents ListViewStudentsList As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents allInfo As ToolStripButton
    Friend WithEvents studentsList As ToolStripButton
    Friend WithEvents newStudent As ToolStripButton
End Class
