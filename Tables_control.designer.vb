<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tables_control
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer_main = New System.Windows.Forms.SplitContainer()
        Me.DataGridTablesResult = New System.Windows.Forms.DataGridView()
        Me.SplitContainer_second = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer_first = New System.Windows.Forms.SplitContainer()
        Me.redactor_name_element_first = New System.Windows.Forms.TextBox()
        Me.redactor_element_first = New System.Windows.Forms.TextBox()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.redactor_name_element_second = New System.Windows.Forms.TextBox()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.redactor_element_second = New System.Windows.Forms.TextBox()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer_main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_main.Panel1.SuspendLayout()
        Me.SplitContainer_main.Panel2.SuspendLayout()
        Me.SplitContainer_main.SuspendLayout()
        CType(Me.DataGridTablesResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer_second, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_second.Panel1.SuspendLayout()
        Me.SplitContainer_second.Panel2.SuspendLayout()
        Me.SplitContainer_second.SuspendLayout()
        CType(Me.SplitContainer_first, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_first.Panel1.SuspendLayout()
        Me.SplitContainer_first.Panel2.SuspendLayout()
        Me.SplitContainer_first.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer_main
        '
        Me.SplitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer_main.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_main.Name = "SplitContainer_main"
        Me.SplitContainer_main.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_main.Panel1
        '
        Me.SplitContainer_main.Panel1.Controls.Add(Me.DataGridTablesResult)
        '
        'SplitContainer_main.Panel2
        '
        Me.SplitContainer_main.Panel2.Controls.Add(Me.SplitContainer_second)
        Me.SplitContainer_main.Panel2Collapsed = True
        Me.SplitContainer_main.Size = New System.Drawing.Size(668, 549)
        Me.SplitContainer_main.SplitterDistance = 360
        Me.SplitContainer_main.TabIndex = 0
        '
        'DataGridTablesResult
        '
        Me.DataGridTablesResult.AllowUserToAddRows = False
        Me.DataGridTablesResult.AllowUserToDeleteRows = False
        Me.DataGridTablesResult.AllowUserToOrderColumns = True
        Me.DataGridTablesResult.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridTablesResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridTablesResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridTablesResult.Location = New System.Drawing.Point(0, 0)
        Me.DataGridTablesResult.MultiSelect = False
        Me.DataGridTablesResult.Name = "DataGridTablesResult"
        Me.DataGridTablesResult.ReadOnly = True
        Me.DataGridTablesResult.RowHeadersVisible = False
        Me.DataGridTablesResult.RowHeadersWidth = 53
        Me.DataGridTablesResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridTablesResult.Size = New System.Drawing.Size(668, 549)
        Me.DataGridTablesResult.TabIndex = 36
        '
        'SplitContainer_second
        '
        Me.SplitContainer_second.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_second.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_second.Name = "SplitContainer_second"
        Me.SplitContainer_second.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_second.Panel1
        '
        Me.SplitContainer_second.Panel1.Controls.Add(Me.SplitContainer_first)
        '
        'SplitContainer_second.Panel2
        '
        Me.SplitContainer_second.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer_second.Panel2Collapsed = True
        Me.SplitContainer_second.Size = New System.Drawing.Size(668, 185)
        Me.SplitContainer_second.SplitterDistance = 25
        Me.SplitContainer_second.TabIndex = 0
        '
        'SplitContainer_first
        '
        Me.SplitContainer_first.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_first.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_first.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_first.Name = "SplitContainer_first"
        Me.SplitContainer_first.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_first.Panel1
        '
        Me.SplitContainer_first.Panel1.Controls.Add(Me.redactor_name_element_first)
        '
        'SplitContainer_first.Panel2
        '
        Me.SplitContainer_first.Panel2.Controls.Add(Me.redactor_element_first)
        Me.SplitContainer_first.Size = New System.Drawing.Size(668, 185)
        Me.SplitContainer_first.SplitterDistance = 25
        Me.SplitContainer_first.TabIndex = 0
        '
        'redactor_name_element_first
        '
        Me.redactor_name_element_first.Dock = System.Windows.Forms.DockStyle.Fill
        Me.redactor_name_element_first.Enabled = False
        Me.redactor_name_element_first.Location = New System.Drawing.Point(0, 0)
        Me.redactor_name_element_first.Multiline = True
        Me.redactor_name_element_first.Name = "redactor_name_element_first"
        Me.redactor_name_element_first.ReadOnly = True
        Me.redactor_name_element_first.Size = New System.Drawing.Size(668, 25)
        Me.redactor_name_element_first.TabIndex = 0
        '
        'redactor_element_first
        '
        Me.redactor_element_first.Dock = System.Windows.Forms.DockStyle.Fill
        Me.redactor_element_first.Location = New System.Drawing.Point(0, 0)
        Me.redactor_element_first.Multiline = True
        Me.redactor_element_first.Name = "redactor_element_first"
        Me.redactor_element_first.Size = New System.Drawing.Size(668, 156)
        Me.redactor_element_first.TabIndex = 1
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.redactor_name_element_second)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer5)
        Me.SplitContainer4.Size = New System.Drawing.Size(150, 46)
        Me.SplitContainer4.SplitterDistance = 25
        Me.SplitContainer4.TabIndex = 1
        '
        'redactor_name_element_second
        '
        Me.redactor_name_element_second.Dock = System.Windows.Forms.DockStyle.Fill
        Me.redactor_name_element_second.Enabled = False
        Me.redactor_name_element_second.Location = New System.Drawing.Point(0, 0)
        Me.redactor_name_element_second.Multiline = True
        Me.redactor_name_element_second.Name = "redactor_name_element_second"
        Me.redactor_name_element_second.ReadOnly = True
        Me.redactor_name_element_second.Size = New System.Drawing.Size(150, 25)
        Me.redactor_name_element_second.TabIndex = 1
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.redactor_element_second)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.SplitContainer6)
        Me.SplitContainer5.Panel2Collapsed = True
        Me.SplitContainer5.Size = New System.Drawing.Size(150, 25)
        Me.SplitContainer5.SplitterDistance = 25
        Me.SplitContainer5.TabIndex = 1
        '
        'redactor_element_second
        '
        Me.redactor_element_second.Dock = System.Windows.Forms.DockStyle.Fill
        Me.redactor_element_second.Location = New System.Drawing.Point(0, 0)
        Me.redactor_element_second.Multiline = True
        Me.redactor_element_second.Name = "redactor_element_second"
        Me.redactor_element_second.Size = New System.Drawing.Size(150, 50)
        Me.redactor_element_second.TabIndex = 1
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.TextBox5)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.TextBox6)
        Me.SplitContainer6.Size = New System.Drawing.Size(150, 54)
        Me.SplitContainer6.SplitterDistance = 25
        Me.SplitContainer6.TabIndex = 1
        '
        'TextBox5
        '
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Location = New System.Drawing.Point(0, 0)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(150, 25)
        Me.TextBox5.TabIndex = 1
        '
        'TextBox6
        '
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Location = New System.Drawing.Point(0, 0)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(150, 25)
        Me.TextBox6.TabIndex = 1
        '
        'Tables_control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer_main)
        Me.Name = "Tables_control"
        Me.Size = New System.Drawing.Size(668, 549)
        Me.SplitContainer_main.Panel1.ResumeLayout(False)
        Me.SplitContainer_main.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_main.ResumeLayout(False)
        CType(Me.DataGridTablesResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_second.Panel1.ResumeLayout(False)
        Me.SplitContainer_second.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_second, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_second.ResumeLayout(False)
        Me.SplitContainer_first.Panel1.ResumeLayout(False)
        Me.SplitContainer_first.Panel1.PerformLayout()
        Me.SplitContainer_first.Panel2.ResumeLayout(False)
        Me.SplitContainer_first.Panel2.PerformLayout()
        CType(Me.SplitContainer_first, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_first.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.Panel2.PerformLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer_main As SplitContainer
    Friend WithEvents SplitContainer_second As SplitContainer
    Friend WithEvents SplitContainer_first As SplitContainer
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents SplitContainer5 As SplitContainer
    Friend WithEvents SplitContainer6 As SplitContainer
    Friend WithEvents redactor_name_element_first As TextBox
    Friend WithEvents redactor_element_first As TextBox
    Friend WithEvents redactor_name_element_second As TextBox
    Friend WithEvents redactor_element_second As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents DataGridTablesResult As DataGridView
End Class
