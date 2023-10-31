<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class user_comboBox
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
        Me.my_ComboBox = New System.Windows.Forms.ComboBox()
        Me.panel_control = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'my_ComboBox
        '
        Me.my_ComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.my_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.my_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.my_ComboBox.DropDownWidth = 200
        Me.my_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.my_ComboBox.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.my_ComboBox.FormattingEnabled = True
        Me.my_ComboBox.Location = New System.Drawing.Point(0, 0)
        Me.my_ComboBox.Name = "my_ComboBox"
        Me.my_ComboBox.Size = New System.Drawing.Size(644, 29)
        Me.my_ComboBox.TabIndex = 0
        '
        'panel_control
        '
        Me.panel_control.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_control.Location = New System.Drawing.Point(0, 0)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(644, 43)
        Me.panel_control.TabIndex = 1
        '
        'user_comboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.my_ComboBox)
        Me.Controls.Add(Me.panel_control)
        Me.Name = "user_comboBox"
        Me.Size = New System.Drawing.Size(644, 43)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents my_ComboBox As ComboBox
    Friend WithEvents panel_control As Panel
End Class
