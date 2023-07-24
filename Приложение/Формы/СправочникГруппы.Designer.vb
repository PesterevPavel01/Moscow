<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class СправочникГруппы
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(СправочникГруппы))
        Me.ListViewСписокГрупп = New System.Windows.Forms.ListView()
        Me.Номер = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Группа = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Программа = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Куратор = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Начало = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Конец = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.СтрокаПоиска = New System.Windows.Forms.TextBox()
        Me.BtnFocus = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.СГУровеньКвалификации = New System.Windows.Forms.ComboBox()
        Me.yearSpravochnikGr = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListViewСписокГрупп
        '
        Me.ListViewСписокГрупп.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewСписокГрупп.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewСписокГрупп.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Номер, Me.Группа, Me.Программа, Me.Куратор, Me.Начало, Me.Конец})
        Me.ListViewСписокГрупп.Font = New System.Drawing.Font("Microsoft YaHei", 11.0!)
        Me.ListViewСписокГрупп.FullRowSelect = True
        Me.ListViewСписокГрупп.GridLines = True
        Me.ListViewСписокГрупп.HideSelection = False
        Me.ListViewСписокГрупп.Location = New System.Drawing.Point(3, 66)
        Me.ListViewСписокГрупп.Name = "ListViewСписокГрупп"
        Me.ListViewСписокГрупп.Size = New System.Drawing.Size(1311, 879)
        Me.ListViewСписокГрупп.TabIndex = 1
        Me.ListViewСписокГрупп.UseCompatibleStateImageBehavior = False
        Me.ListViewСписокГрупп.View = System.Windows.Forms.View.Details
        '
        'Номер
        '
        Me.Номер.Text = "Код"
        Me.Номер.Width = 50
        '
        'Группа
        '
        Me.Группа.Text = "Группа"
        Me.Группа.Width = 200
        '
        'Программа
        '
        Me.Программа.Text = "Программа"
        Me.Программа.Width = 500
        '
        'Куратор
        '
        Me.Куратор.Text = "Ответственный куратор"
        Me.Куратор.Width = 300
        '
        'Начало
        '
        Me.Начало.Text = "Дата начала"
        Me.Начало.Width = 120
        '
        'Конец
        '
        Me.Конец.Text = "Дата окончания"
        Me.Конец.Width = 140
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Поиск"
        '
        'СтрокаПоиска
        '
        Me.СтрокаПоиска.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СтрокаПоиска.Location = New System.Drawing.Point(44, 31)
        Me.СтрокаПоиска.Name = "СтрокаПоиска"
        Me.СтрокаПоиска.Size = New System.Drawing.Size(690, 29)
        Me.СтрокаПоиска.TabIndex = 2
        '
        'BtnFocus
        '
        Me.BtnFocus.ImageList = Me.ImageList1
        Me.BtnFocus.Location = New System.Drawing.Point(627, 147)
        Me.BtnFocus.Name = "BtnFocus"
        Me.BtnFocus.Size = New System.Drawing.Size(75, 23)
        Me.BtnFocus.TabIndex = 13
        Me.BtnFocus.Text = "Button2"
        Me.BtnFocus.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "file_Exel.png")
        Me.ImageList1.Images.SetKeyName(1, "настройки2.png")
        Me.ImageList1.Images.SetKeyName(2, "word.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-загрузка-обновлений-50.png")
        Me.ImageList1.Images.SetKeyName(4, "Главная.png")
        Me.ImageList1.Images.SetKeyName(5, "Бланк!.png")
        Me.ImageList1.Images.SetKeyName(6, "Лупа.png")
        Me.ImageList1.Images.SetKeyName(7, "Сортировка35.png")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(12, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label3.Location = New System.Drawing.Point(100, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Сортировка35.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(5, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(740, 31)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 28)
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'СГУровеньКвалификации
        '
        Me.СГУровеньКвалификации.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.СГУровеньКвалификации.FormattingEnabled = True
        Me.СГУровеньКвалификации.Items.AddRange(New Object() {"профессиональная переподготовка", "профессиональное обучение", "повышение квалификации"})
        Me.СГУровеньКвалификации.Location = New System.Drawing.Point(774, 31)
        Me.СГУровеньКвалификации.Name = "СГУровеньКвалификации"
        Me.СГУровеньКвалификации.Size = New System.Drawing.Size(378, 29)
        Me.СГУровеньКвалификации.TabIndex = 18
        '
        'yearSpravochnikGr
        '
        Me.yearSpravochnikGr.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.yearSpravochnikGr.FormattingEnabled = True
        Me.yearSpravochnikGr.Items.AddRange(New Object() {"2021", "2022", "2023", "2024"})
        Me.yearSpravochnikGr.Location = New System.Drawing.Point(1158, 31)
        Me.yearSpravochnikGr.Name = "yearSpravochnikGr"
        Me.yearSpravochnikGr.Size = New System.Drawing.Size(113, 29)
        Me.yearSpravochnikGr.TabIndex = 19
        Me.yearSpravochnikGr.Text = "2023"
        '
        'СправочникГруппы
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1315, 947)
        Me.Controls.Add(Me.yearSpravochnikGr)
        Me.Controls.Add(Me.ListViewСписокГрупп)
        Me.Controls.Add(Me.СГУровеньКвалификации)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnFocus)
        Me.Controls.Add(Me.СтрокаПоиска)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(12, 80)
        Me.Name = "СправочникГруппы"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Справочник Группы"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListViewСписокГрупп As ListView
    Friend WithEvents Номер As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents СтрокаПоиска As TextBox
    Friend WithEvents BtnFocus As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Группа As ColumnHeader
    Friend WithEvents Программа As ColumnHeader
    Friend WithEvents Куратор As ColumnHeader
    Friend WithEvents Начало As ColumnHeader
    Friend WithEvents Конец As ColumnHeader
    Friend WithEvents СГУровеньКвалификации As ComboBox
    Friend WithEvents yearSpravochnikGr As ComboBox
End Class
