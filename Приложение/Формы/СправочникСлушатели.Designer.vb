<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ФормаСправочникСлушатели
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ФормаСправочникСлушатели))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListViewСписокСлушателей = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.СтрокаПоиска = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFocus = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ДобавитьВГруппу = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ССлушТаблицаИнфСлушателя = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ССлушТаблицаИнфСлушателя, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListViewСписокСлушателей
        '
        Me.ListViewСписокСлушателей.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListViewСписокСлушателей.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewСписокСлушателей.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListViewСписокСлушателей.FullRowSelect = True
        Me.ListViewСписокСлушателей.GridLines = True
        Me.ListViewСписокСлушателей.HideSelection = False
        Me.ListViewСписокСлушателей.Location = New System.Drawing.Point(0, 0)
        Me.ListViewСписокСлушателей.Name = "ListViewСписокСлушателей"
        Me.ListViewСписокСлушателей.Size = New System.Drawing.Size(1320, 879)
        Me.ListViewСписокСлушателей.TabIndex = 1
        Me.ListViewСписокСлушателей.UseCompatibleStateImageBehavior = False
        Me.ListViewСписокСлушателей.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Номер"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "СНИЛС"
        Me.ColumnHeader6.Width = 300
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Фамилия"
        Me.ColumnHeader1.Width = 300
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Имя"
        Me.ColumnHeader2.Width = 300
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Отчество"
        Me.ColumnHeader3.Width = 300
        '
        'СтрокаПоиска
        '
        Me.СтрокаПоиска.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СтрокаПоиска.Location = New System.Drawing.Point(41, 34)
        Me.СтрокаПоиска.Name = "СтрокаПоиска"
        Me.СтрокаПоиска.Size = New System.Drawing.Size(648, 29)
        Me.СтрокаПоиска.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Поиск"
        '
        'BtnFocus
        '
        Me.BtnFocus.Location = New System.Drawing.Point(1032, 2)
        Me.BtnFocus.Name = "BtnFocus"
        Me.BtnFocus.Size = New System.Drawing.Size(75, 23)
        Me.BtnFocus.TabIndex = 11
        Me.BtnFocus.Text = "Button2"
        Me.BtnFocus.UseVisualStyleBackColor = True
        Me.BtnFocus.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(12, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'ДобавитьВГруппу
        '
        Me.ДобавитьВГруппу.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ДобавитьВГруппу.BackColor = System.Drawing.Color.Transparent
        Me.ДобавитьВГруппу.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ДобавитьВГруппу.FlatAppearance.BorderSize = 0
        Me.ДобавитьВГруппу.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ДобавитьВГруппу.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ДобавитьВГруппу.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ДобавитьВГруппу.Location = New System.Drawing.Point(1692, 4)
        Me.ДобавитьВГруппу.Name = "ДобавитьВГруппу"
        Me.ДобавитьВГруппу.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ДобавитьВГруппу.Size = New System.Drawing.Size(230, 64)
        Me.ДобавитьВГруппу.TabIndex = 15
        Me.ДобавитьВГруппу.Text = "Добавить в группу"
        Me.ДобавитьВГруппу.UseVisualStyleBackColor = False
        Me.ДобавитьВГруппу.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(5, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(923, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(402, 64)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Загрузить все записи"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label3.Location = New System.Drawing.Point(104, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(349, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Для отображения слушателей начните вводить данные для поиска"
        Me.Label3.Visible = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Сортировка35.png")
        '
        'PictureBox2
        '
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(695, 34)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 28)
        Me.PictureBox2.TabIndex = 18
        Me.PictureBox2.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(5, 69)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListViewСписокСлушателей)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ССлушТаблицаИнфСлушателя)
        Me.SplitContainer1.Size = New System.Drawing.Size(1917, 879)
        Me.SplitContainer1.SplitterDistance = 1320
        Me.SplitContainer1.TabIndex = 20
        '
        'ССлушТаблицаИнфСлушателя
        '
        Me.ССлушТаблицаИнфСлушателя.AllowUserToAddRows = False
        Me.ССлушТаблицаИнфСлушателя.AllowUserToDeleteRows = False
        Me.ССлушТаблицаИнфСлушателя.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ССлушТаблицаИнфСлушателя.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ССлушТаблицаИнфСлушателя.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ССлушТаблицаИнфСлушателя.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ССлушТаблицаИнфСлушателя.Location = New System.Drawing.Point(0, 0)
        Me.ССлушТаблицаИнфСлушателя.Name = "ССлушТаблицаИнфСлушателя"
        Me.ССлушТаблицаИнфСлушателя.ReadOnly = True
        Me.ССлушТаблицаИнфСлушателя.RowHeadersVisible = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ССлушТаблицаИнфСлушателя.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ССлушТаблицаИнфСлушателя.Size = New System.Drawing.Size(593, 879)
        Me.ССлушТаблицаИнфСлушателя.TabIndex = 1
        '
        'ФормаСправочникСлушатели
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 950)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ДобавитьВГруппу)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnFocus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.СтрокаПоиска)
        Me.KeyPreview = True
        Me.Name = "ФормаСправочникСлушатели"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Справочник ""Слушатели"""
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ССлушТаблицаИнфСлушателя, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListViewСписокСлушателей As ListView
    Friend WithEvents СтрокаПоиска As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents BtnFocus As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ДобавитьВГруппу As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ССлушТаблицаИнфСлушателя As DataGridView
End Class
