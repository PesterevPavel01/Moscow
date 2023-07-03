<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class СписокСлушателейВГруппе
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
        Me.ListViewСписокСлушателей = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Прочее = New System.Windows.Forms.Button()
        Me.ДобавитьВГруппу = New System.Windows.Forms.Button()
        Me.ДобавитьВгруппуНового = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewСписокСлушателей
        '
        Me.ListViewСписокСлушателей.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.ListViewСписокСлушателей.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewСписокСлушателей.FullRowSelect = True
        Me.ListViewСписокСлушателей.GridLines = True
        Me.ListViewСписокСлушателей.HideSelection = False
        Me.ListViewСписокСлушателей.Location = New System.Drawing.Point(0, 0)
        Me.ListViewСписокСлушателей.Name = "ListViewСписокСлушателей"
        Me.ListViewСписокСлушателей.Size = New System.Drawing.Size(1121, 651)
        Me.ListViewСписокСлушателей.TabIndex = 4
        Me.ListViewСписокСлушателей.UseCompatibleStateImageBehavior = False
        Me.ListViewСписокСлушателей.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Номер"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "СНИЛС"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Фамилия"
        Me.ColumnHeader8.Width = 130
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Имя"
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Отчество"
        Me.ColumnHeader10.Width = 130
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Дата рождения"
        Me.ColumnHeader11.Width = 120
        '
        'Прочее
        '
        Me.Прочее.BackColor = System.Drawing.Color.Transparent
        Me.Прочее.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Прочее.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Прочее.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Прочее.Location = New System.Drawing.Point(0, 0)
        Me.Прочее.Name = "Прочее"
        Me.Прочее.Size = New System.Drawing.Size(439, 46)
        Me.Прочее.TabIndex = 5
        Me.Прочее.Text = "Прочее"
        Me.Прочее.UseVisualStyleBackColor = False
        '
        'ДобавитьВГруппу
        '
        Me.ДобавитьВГруппу.BackColor = System.Drawing.Color.Transparent
        Me.ДобавитьВГруппу.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ДобавитьВГруппу.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ДобавитьВГруппу.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ДобавитьВГруппу.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДобавитьВГруппу.Location = New System.Drawing.Point(0, 0)
        Me.ДобавитьВГруппу.Name = "ДобавитьВГруппу"
        Me.ДобавитьВГруппу.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ДобавитьВГруппу.Size = New System.Drawing.Size(340, 46)
        Me.ДобавитьВГруппу.TabIndex = 1
        Me.ДобавитьВГруппу.Text = "Добавить из списка"
        Me.ДобавитьВГруппу.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДобавитьВГруппу.UseVisualStyleBackColor = False
        '
        'ДобавитьВгруппуНового
        '
        Me.ДобавитьВгруппуНового.BackColor = System.Drawing.Color.Transparent
        Me.ДобавитьВгруппуНового.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ДобавитьВгруппуНового.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ДобавитьВгруппуНового.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ДобавитьВгруппуНового.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДобавитьВгруппуНового.Location = New System.Drawing.Point(0, 0)
        Me.ДобавитьВгруппуНового.Name = "ДобавитьВгруппуНового"
        Me.ДобавитьВгруппуНового.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ДобавитьВгруппуНового.Size = New System.Drawing.Size(334, 46)
        Me.ДобавитьВгруппуНового.TabIndex = 3
        Me.ДобавитьВгруппуНового.Text = "Добавить нового"
        Me.ДобавитьВгруппуНового.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ДобавитьВгруппуНового.UseVisualStyleBackColor = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewСписокСлушателей)
        Me.SplitContainer1.Size = New System.Drawing.Size(1121, 701)
        Me.SplitContainer1.SplitterDistance = 46
        Me.SplitContainer1.TabIndex = 7
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ДобавитьВГруппу)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1121, 46)
        Me.SplitContainer2.SplitterDistance = 340
        Me.SplitContainer2.TabIndex = 4
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ДобавитьВгруппуНового)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Прочее)
        Me.SplitContainer3.Size = New System.Drawing.Size(777, 46)
        Me.SplitContainer3.SplitterDistance = 334
        Me.SplitContainer3.TabIndex = 2
        '
        'СписокСлушателейВГруппе
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 701)
        Me.Controls.Add(Me.SplitContainer1)
        Me.KeyPreview = True
        Me.Name = "СписокСлушателейВГруппе"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form2"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewСписокСлушателей As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents Прочее As Button
    Friend WithEvents ДобавитьВГруппу As Button
    Friend WithEvents ДобавитьВгруппуНового As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
End Class
