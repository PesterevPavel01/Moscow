<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tables_control
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer_main = New System.Windows.Forms.SplitContainer()
        Me.DataGridTablesResult = New System.Windows.Forms.DataGridView()
        Me.SplitContainer_second = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer_first = New System.Windows.Forms.SplitContainer()
        Me.redactor_name_element_first = New System.Windows.Forms.TextBox()
        Me.redactor_element_first = New System.Windows.Forms.TextBox()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.redactor_name_element_second = New System.Windows.Forms.TextBox()
        Me.panel_second_element = New System.Windows.Forms.Panel()
        Me.comboBox_second_element = New WindowsApp2.user_comboBox()
        Me.redactor_element_second = New System.Windows.Forms.TextBox()
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
        Me.panel_second_element.SuspendLayout()
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
        Me.SplitContainer_main.Size = New System.Drawing.Size(959, 549)
        Me.SplitContainer_main.SplitterDistance = 356
        Me.SplitContainer_main.TabIndex = 0
        '
        'DataGridTablesResult
        '
        Me.DataGridTablesResult.AllowUserToAddRows = False
        Me.DataGridTablesResult.AllowUserToDeleteRows = False
        Me.DataGridTablesResult.AllowUserToOrderColumns = True
        Me.DataGridTablesResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridTablesResult.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridTablesResult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridTablesResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridTablesResult.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridTablesResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridTablesResult.Location = New System.Drawing.Point(0, 0)
        Me.DataGridTablesResult.MultiSelect = False
        Me.DataGridTablesResult.Name = "DataGridTablesResult"
        Me.DataGridTablesResult.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridTablesResult.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridTablesResult.RowHeadersVisible = False
        Me.DataGridTablesResult.RowHeadersWidth = 53
        Me.DataGridTablesResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridTablesResult.Size = New System.Drawing.Size(959, 356)
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
        Me.SplitContainer_second.Size = New System.Drawing.Size(959, 189)
        Me.SplitContainer_second.SplitterDistance = 90
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
        Me.SplitContainer_first.Size = New System.Drawing.Size(959, 90)
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
        Me.redactor_name_element_first.Size = New System.Drawing.Size(959, 25)
        Me.redactor_name_element_first.TabIndex = 0
        '
        'redactor_element_first
        '
        Me.redactor_element_first.Dock = System.Windows.Forms.DockStyle.Fill
        Me.redactor_element_first.Location = New System.Drawing.Point(0, 0)
        Me.redactor_element_first.Multiline = True
        Me.redactor_element_first.Name = "redactor_element_first"
        Me.redactor_element_first.Size = New System.Drawing.Size(959, 61)
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
        Me.SplitContainer4.Panel2.Controls.Add(Me.panel_second_element)
        Me.SplitContainer4.Size = New System.Drawing.Size(959, 95)
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
        Me.redactor_name_element_second.Size = New System.Drawing.Size(959, 25)
        Me.redactor_name_element_second.TabIndex = 1
        '
        'panel_second_element
        '
        Me.panel_second_element.BackColor = System.Drawing.SystemColors.Window
        Me.panel_second_element.Controls.Add(Me.comboBox_second_element)
        Me.panel_second_element.Controls.Add(Me.redactor_element_second)
        Me.panel_second_element.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_second_element.Location = New System.Drawing.Point(0, 0)
        Me.panel_second_element.Name = "panel_second_element"
        Me.panel_second_element.Size = New System.Drawing.Size(959, 66)
        Me.panel_second_element.TabIndex = 0
        '
        'comboBox_second_element
        '
        Me.comboBox_second_element.BackColor = System.Drawing.SystemColors.Window
        Me.comboBox_second_element.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.comboBox_second_element.Location = New System.Drawing.Point(3, 20)
        Me.comboBox_second_element.Name = "comboBox_second_element"
        Me.comboBox_second_element.Size = New System.Drawing.Size(956, 43)
        Me.comboBox_second_element.TabIndex = 37
        '
        'redactor_element_second
        '
        Me.redactor_element_second.BackColor = System.Drawing.SystemColors.Window
        Me.redactor_element_second.Dock = System.Windows.Forms.DockStyle.Fill
        Me.redactor_element_second.Location = New System.Drawing.Point(0, 0)
        Me.redactor_element_second.Multiline = True
        Me.redactor_element_second.Name = "redactor_element_second"
        Me.redactor_element_second.Size = New System.Drawing.Size(959, 66)
        Me.redactor_element_second.TabIndex = 1
        '
        'Tables_control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer_main)
        Me.Name = "Tables_control"
        Me.Size = New System.Drawing.Size(959, 549)
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
        Me.panel_second_element.ResumeLayout(False)
        Me.panel_second_element.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer_main As SplitContainer
    Friend WithEvents SplitContainer_second As SplitContainer
    Friend WithEvents SplitContainer_first As SplitContainer
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents redactor_name_element_first As TextBox
    Friend WithEvents redactor_element_first As TextBox
    Friend WithEvents redactor_name_element_second As TextBox
    Friend WithEvents redactor_element_second As TextBox
    Friend WithEvents DataGridTablesResult As DataGridView
    Friend WithEvents panel_second_element As Panel
    Friend WithEvents comboBox_second_element As user_comboBox
End Class
