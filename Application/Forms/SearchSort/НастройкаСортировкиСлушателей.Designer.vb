﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sortSettsStudents
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sortSettsStudents))
        Me.nameStudent = New System.Windows.Forms.CheckBox()
        Me.secName = New System.Windows.Forms.CheckBox()
        Me.snils = New System.Windows.Forms.CheckBox()
        Me.sortUp = New System.Windows.Forms.PictureBox()
        Me.sortDown = New System.Windows.Forms.PictureBox()
        Me.sortDounFocus = New System.Windows.Forms.Button()
        Me.sortUpFocus = New System.Windows.Forms.Button()
        CType(Me.sortUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sortDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nameStudent
        '
        Me.nameStudent.AutoSize = True
        Me.nameStudent.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.nameStudent.Location = New System.Drawing.Point(16, 62)
        Me.nameStudent.Name = "nameStudent"
        Me.nameStudent.Size = New System.Drawing.Size(63, 25)
        Me.nameStudent.TabIndex = 2
        Me.nameStudent.Text = "Имя"
        Me.nameStudent.UseVisualStyleBackColor = True
        '
        'secName
        '
        Me.secName.AutoSize = True
        Me.secName.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.secName.Location = New System.Drawing.Point(16, 32)
        Me.secName.Name = "secName"
        Me.secName.Size = New System.Drawing.Size(101, 25)
        Me.secName.TabIndex = 1
        Me.secName.Text = "Фамилия"
        Me.secName.UseVisualStyleBackColor = True
        '
        'snils
        '
        Me.snils.AutoSize = True
        Me.snils.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.snils.Location = New System.Drawing.Point(16, 2)
        Me.snils.Name = "snils"
        Me.snils.Size = New System.Drawing.Size(77, 25)
        Me.snils.TabIndex = 0
        Me.snils.Text = "Снилс"
        Me.snils.UseVisualStyleBackColor = True
        '
        'sortUp
        '
        Me.sortUp.ErrorImage = Nothing
        Me.sortUp.Image = CType(resources.GetObject("sortUp.Image"), System.Drawing.Image)
        Me.sortUp.InitialImage = Nothing
        Me.sortUp.Location = New System.Drawing.Point(306, 12)
        Me.sortUp.Name = "sortUp"
        Me.sortUp.Size = New System.Drawing.Size(41, 41)
        Me.sortUp.TabIndex = 22
        Me.sortUp.TabStop = False
        '
        'sortDown
        '
        Me.sortDown.ErrorImage = Nothing
        Me.sortDown.Image = CType(resources.GetObject("sortDown.Image"), System.Drawing.Image)
        Me.sortDown.InitialImage = Nothing
        Me.sortDown.Location = New System.Drawing.Point(352, 12)
        Me.sortDown.Name = "sortDown"
        Me.sortDown.Size = New System.Drawing.Size(41, 41)
        Me.sortDown.TabIndex = 21
        Me.sortDown.TabStop = False
        '
        'sortDounFocus
        '
        Me.sortDounFocus.BackColor = System.Drawing.SystemColors.Control
        Me.sortDounFocus.FlatAppearance.BorderSize = 0
        Me.sortDounFocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sortDounFocus.Location = New System.Drawing.Point(352, 12)
        Me.sortDounFocus.Name = "sortDounFocus"
        Me.sortDounFocus.Size = New System.Drawing.Size(41, 41)
        Me.sortDounFocus.TabIndex = 4
        Me.sortDounFocus.UseVisualStyleBackColor = False
        '
        'sortUpFocus
        '
        Me.sortUpFocus.FlatAppearance.BorderSize = 0
        Me.sortUpFocus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sortUpFocus.Location = New System.Drawing.Point(305, 12)
        Me.sortUpFocus.Name = "sortUpFocus"
        Me.sortUpFocus.Size = New System.Drawing.Size(41, 41)
        Me.sortUpFocus.TabIndex = 3
        Me.sortUpFocus.UseVisualStyleBackColor = True
        '
        'sortSettsStudents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 89)
        Me.Controls.Add(Me.sortUp)
        Me.Controls.Add(Me.sortDown)
        Me.Controls.Add(Me.nameStudent)
        Me.Controls.Add(Me.secName)
        Me.Controls.Add(Me.snils)
        Me.Controls.Add(Me.sortDounFocus)
        Me.Controls.Add(Me.sortUpFocus)
        Me.KeyPreview = True
        Me.Name = "sortSettsStudents"
        Me.Text = "Выбор поля для сортировки"
        CType(Me.sortUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sortDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nameStudent As CheckBox
    Friend WithEvents secName As CheckBox
    Friend WithEvents snils As CheckBox
    Friend WithEvents sortUp As PictureBox
    Friend WithEvents sortDown As PictureBox
    Friend WithEvents sortDounFocus As Button
    Friend WithEvents sortUpFocus As Button
End Class
