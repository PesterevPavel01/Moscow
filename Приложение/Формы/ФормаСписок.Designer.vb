<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ФормаСписок
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
        Me.СтрокаПоиска = New System.Windows.Forms.TextBox()
        Me.ListViewСписок = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'СтрокаПоиска
        '
        Me.СтрокаПоиска.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.СтрокаПоиска.Location = New System.Drawing.Point(12, 12)
        Me.СтрокаПоиска.Name = "СтрокаПоиска"
        Me.СтрокаПоиска.Size = New System.Drawing.Size(868, 20)
        Me.СтрокаПоиска.TabIndex = 1
        '
        'ListViewСписок
        '
        Me.ListViewСписок.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewСписок.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewСписок.FullRowSelect = True
        Me.ListViewСписок.GridLines = True
        Me.ListViewСписок.HideSelection = False
        Me.ListViewСписок.Location = New System.Drawing.Point(12, 38)
        Me.ListViewСписок.MultiSelect = False
        Me.ListViewСписок.Name = "ListViewСписок"
        Me.ListViewСписок.Size = New System.Drawing.Size(868, 726)
        Me.ListViewСписок.TabIndex = 3
        Me.ListViewСписок.UseCompatibleStateImageBehavior = False
        Me.ListViewСписок.View = System.Windows.Forms.View.Details
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
        'ФормаСписок
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 776)
        Me.Controls.Add(Me.ListViewСписок)
        Me.Controls.Add(Me.СтрокаПоиска)
        Me.KeyPreview = True
        Me.Name = "ФормаСписок"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Список"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents СтрокаПоиска As TextBox
    Friend WithEvents ListViewСписок As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
