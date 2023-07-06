<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class РедакторСлушателя
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Телефон = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ДатаРождения = New System.Windows.Forms.DateTimePicker()
        Me.Отчество = New System.Windows.Forms.TextBox()
        Me.BtnFocus = New System.Windows.Forms.Button()
        Me.Сообщение = New System.Windows.Forms.Label()
        Me.НомерДУЛ = New System.Windows.Forms.TextBox()
        Me.СерияДУЛ = New System.Windows.Forms.TextBox()
        Me.АдресРегистрации = New System.Windows.Forms.TextBox()
        Me.ФамилияВДокОбОбразовании = New System.Windows.Forms.TextBox()
        Me.НомерДокументаООбразовании = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.СерияДокументаООбразовании = New System.Windows.Forms.TextBox()
        Me.Образование = New System.Windows.Forms.TextBox()
        Me.Фамилия = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Имя = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Снилс = New System.Windows.Forms.TextBox()
        Me.Сохранить = New System.Windows.Forms.Button()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.label = New System.Windows.Forms.Label()
        Me.ДатаНаправленияРосздравнвдзора = New System.Windows.Forms.DateTimePicker()
        Me.НомерНаправленияРосздравнадзора = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ДатаВыдачиДУЛ = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.КемВыданДУЛ = New System.Windows.Forms.TextBox()
        Me.ValidOn = New System.Windows.Forms.CheckBox()
        Me.Пол = New System.Windows.Forms.ComboBox()
        Me.УровеньОбразования = New System.Windows.Forms.ComboBox()
        Me.Гражданство = New System.Windows.Forms.ComboBox()
        Me.ДУЛ = New System.Windows.Forms.ComboBox()
        Me.ИсточникФин = New System.Windows.Forms.ComboBox()
        Me.НаправившаяОрг = New System.Windows.Forms.ComboBox()
        Me.doo_vid_dok = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(231, 286)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Телефон
        '
        Me.Телефон.Location = New System.Drawing.Point(253, 343)
        Me.Телефон.Name = "Телефон"
        Me.Телефон.Size = New System.Drawing.Size(534, 20)
        Me.Телефон.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label18.Location = New System.Drawing.Point(2, 265)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(124, 16)
        Me.Label18.TabIndex = 162
        Me.Label18.Text = "Номер документа"
        '
        'ДатаРождения
        '
        Me.ДатаРождения.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаРождения.Location = New System.Drawing.Point(253, 110)
        Me.ДатаРождения.Name = "ДатаРождения"
        Me.ДатаРождения.Size = New System.Drawing.Size(534, 20)
        Me.ДатаРождения.TabIndex = 5
        Me.ДатаРождения.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'Отчество
        '
        Me.Отчество.Location = New System.Drawing.Point(253, 88)
        Me.Отчество.Name = "Отчество"
        Me.Отчество.Size = New System.Drawing.Size(534, 20)
        Me.Отчество.TabIndex = 4
        '
        'BtnFocus
        '
        Me.BtnFocus.Location = New System.Drawing.Point(62, 4)
        Me.BtnFocus.Name = "BtnFocus"
        Me.BtnFocus.Size = New System.Drawing.Size(75, 23)
        Me.BtnFocus.TabIndex = 159
        Me.BtnFocus.Text = "Button1"
        Me.BtnFocus.UseVisualStyleBackColor = True
        Me.BtnFocus.Visible = False
        '
        'Сообщение
        '
        Me.Сообщение.AutoSize = True
        Me.Сообщение.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Сообщение.Location = New System.Drawing.Point(27, 9)
        Me.Сообщение.Name = "Сообщение"
        Me.Сообщение.Size = New System.Drawing.Size(45, 13)
        Me.Сообщение.TabIndex = 158
        Me.Сообщение.Text = "Label20"
        Me.Сообщение.Visible = False
        '
        'НомерДУЛ
        '
        Me.НомерДУЛ.Location = New System.Drawing.Point(253, 469)
        Me.НомерДУЛ.Name = "НомерДУЛ"
        Me.НомерДУЛ.Size = New System.Drawing.Size(534, 20)
        Me.НомерДУЛ.TabIndex = 20
        '
        'СерияДУЛ
        '
        Me.СерияДУЛ.Location = New System.Drawing.Point(253, 447)
        Me.СерияДУЛ.Name = "СерияДУЛ"
        Me.СерияДУЛ.Size = New System.Drawing.Size(534, 20)
        Me.СерияДУЛ.TabIndex = 19
        '
        'АдресРегистрации
        '
        Me.АдресРегистрации.Location = New System.Drawing.Point(253, 321)
        Me.АдресРегистрации.Name = "АдресРегистрации"
        Me.АдресРегистрации.Size = New System.Drawing.Size(534, 20)
        Me.АдресРегистрации.TabIndex = 14
        '
        'ФамилияВДокОбОбразовании
        '
        Me.ФамилияВДокОбОбразовании.Location = New System.Drawing.Point(253, 283)
        Me.ФамилияВДокОбОбразовании.Name = "ФамилияВДокОбОбразовании"
        Me.ФамилияВДокОбОбразовании.Size = New System.Drawing.Size(534, 20)
        Me.ФамилияВДокОбОбразовании.TabIndex = 13
        '
        'НомерДокументаООбразовании
        '
        Me.НомерДокументаООбразовании.Location = New System.Drawing.Point(253, 261)
        Me.НомерДокументаООбразовании.Name = "НомерДокументаООбразовании"
        Me.НомерДокументаООбразовании.Size = New System.Drawing.Size(534, 20)
        Me.НомерДокументаООбразовании.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label19.Location = New System.Drawing.Point(4, 578)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(185, 16)
        Me.Label19.TabIndex = 148
        Me.Label19.Text = "Направившая организация"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 556)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(186, 16)
        Me.Label17.TabIndex = 147
        Me.Label17.Text = "Источник финансирования"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 473)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 16)
        Me.Label16.TabIndex = 146
        Me.Label16.Text = "Номер документа"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.Location = New System.Drawing.Point(4, 451)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 16)
        Me.Label15.TabIndex = 145
        Me.Label15.Text = "Серия документа"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.Location = New System.Drawing.Point(4, 430)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(226, 15)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "Документ, удостоверяющий личность"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 407)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 16)
        Me.Label13.TabIndex = 143
        Me.Label13.Text = "Гражданство"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 365)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(146, 16)
        Me.Label12.TabIndex = 142
        Me.Label12.Text = "Контактный телефон"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 325)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 16)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "Адрес регистрации"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 287)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 16)
        Me.Label10.TabIndex = 140
        Me.Label10.Text = "Фамилия в документе"
        '
        'СерияДокументаООбразовании
        '
        Me.СерияДокументаООбразовании.Location = New System.Drawing.Point(253, 239)
        Me.СерияДокументаООбразовании.Name = "СерияДокументаООбразовании"
        Me.СерияДокументаООбразовании.Size = New System.Drawing.Size(534, 20)
        Me.СерияДокументаООбразовании.TabIndex = 10
        '
        'Образование
        '
        Me.Образование.Location = New System.Drawing.Point(253, 194)
        Me.Образование.Name = "Образование"
        Me.Образование.Size = New System.Drawing.Size(534, 20)
        Me.Образование.TabIndex = 8
        '
        'Фамилия
        '
        Me.Фамилия.Location = New System.Drawing.Point(253, 44)
        Me.Фамилия.Name = "Фамилия"
        Me.Фамилия.Size = New System.Drawing.Size(534, 20)
        Me.Фамилия.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 243)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 16)
        Me.Label9.TabIndex = 135
        Me.Label9.Text = "Серия документа"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(228, 16)
        Me.Label8.TabIndex = 134
        Me.Label8.Text = "Образование (наименование ОО)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 176)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 16)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Уровень образования"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "Пол"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "Дата рождения"
        '
        'Имя
        '
        Me.Имя.Location = New System.Drawing.Point(253, 66)
        Me.Имя.Name = "Имя"
        Me.Имя.Size = New System.Drawing.Size(534, 20)
        Me.Имя.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Отчество"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 16)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Имя"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Фамилия"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Снилс"
        '
        'Снилс
        '
        Me.Снилс.Location = New System.Drawing.Point(253, 22)
        Me.Снилс.Name = "Снилс"
        Me.Снилс.Size = New System.Drawing.Size(534, 20)
        Me.Снилс.TabIndex = 1
        '
        'Сохранить
        '
        Me.Сохранить.BackColor = System.Drawing.SystemColors.MenuBar
        Me.Сохранить.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Сохранить.Location = New System.Drawing.Point(5, 652)
        Me.Сохранить.Name = "Сохранить"
        Me.Сохранить.Size = New System.Drawing.Size(782, 40)
        Me.Сохранить.TabIndex = 25
        Me.Сохранить.Text = "Сохранить"
        Me.Сохранить.UseVisualStyleBackColor = False
        '
        'Email
        '
        Me.Email.Location = New System.Drawing.Point(253, 365)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(534, 20)
        Me.Email.TabIndex = 16
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label.Location = New System.Drawing.Point(4, 346)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(45, 16)
        Me.label.TabIndex = 176
        Me.label.Text = "E-mail"
        '
        'ДатаНаправленияРосздравнвдзора
        '
        Me.ДатаНаправленияРосздравнвдзора.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаНаправленияРосздравнвдзора.Location = New System.Drawing.Point(253, 714)
        Me.ДатаНаправленияРосздравнвдзора.Name = "ДатаНаправленияРосздравнвдзора"
        Me.ДатаНаправленияРосздравнвдзора.Size = New System.Drawing.Size(534, 20)
        Me.ДатаНаправленияРосздравнвдзора.TabIndex = 24
        Me.ДатаНаправленияРосздравнвдзора.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.ДатаНаправленияРосздравнвдзора.Visible = False
        '
        'НомерНаправленияРосздравнадзора
        '
        Me.НомерНаправленияРосздравнадзора.Location = New System.Drawing.Point(253, 736)
        Me.НомерНаправленияРосздравнадзора.Name = "НомерНаправленияРосздравнадзора"
        Me.НомерНаправленияРосздравнадзора.Size = New System.Drawing.Size(534, 20)
        Me.НомерНаправленияРосздравнадзора.TabIndex = 25
        Me.НомерНаправленияРосздравнадзора.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.Location = New System.Drawing.Point(4, 741)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(232, 15)
        Me.Label20.TabIndex = 180
        Me.Label20.Text = "Номер направления Росздравнадзора"
        Me.Label20.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label21.Location = New System.Drawing.Point(4, 718)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(223, 15)
        Me.Label21.TabIndex = 179
        Me.Label21.Text = "Дата направления Росздравнадзора"
        Me.Label21.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 495)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(76, 16)
        Me.Label25.TabIndex = 185
        Me.Label25.Text = "Кем выдан"
        '
        'ДатаВыдачиДУЛ
        '
        Me.ДатаВыдачиДУЛ.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаВыдачиДУЛ.Location = New System.Drawing.Point(253, 513)
        Me.ДатаВыдачиДУЛ.Name = "ДатаВыдачиДУЛ"
        Me.ДатаВыдачиДУЛ.Size = New System.Drawing.Size(534, 20)
        Me.ДатаВыдачиДУЛ.TabIndex = 22
        Me.ДатаВыдачиДУЛ.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label26.Location = New System.Drawing.Point(4, 517)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 16)
        Me.Label26.TabIndex = 187
        Me.Label26.Text = "Когда выдан"
        '
        'КемВыданДУЛ
        '
        Me.КемВыданДУЛ.Location = New System.Drawing.Point(253, 491)
        Me.КемВыданДУЛ.Name = "КемВыданДУЛ"
        Me.КемВыданДУЛ.Size = New System.Drawing.Size(534, 20)
        Me.КемВыданДУЛ.TabIndex = 21
        '
        'ValidOn
        '
        Me.ValidOn.AutoSize = True
        Me.ValidOn.Checked = True
        Me.ValidOn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ValidOn.Location = New System.Drawing.Point(231, 22)
        Me.ValidOn.Name = "ValidOn"
        Me.ValidOn.Size = New System.Drawing.Size(15, 14)
        Me.ValidOn.TabIndex = 0
        Me.ValidOn.UseVisualStyleBackColor = True
        '
        'Пол
        '
        Me.Пол.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Пол.FormattingEnabled = True
        Me.Пол.ItemHeight = 13
        Me.Пол.Location = New System.Drawing.Point(253, 131)
        Me.Пол.Name = "Пол"
        Me.Пол.Size = New System.Drawing.Size(534, 21)
        Me.Пол.TabIndex = 6
        '
        'УровеньОбразования
        '
        Me.УровеньОбразования.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.УровеньОбразования.FormattingEnabled = True
        Me.УровеньОбразования.ItemHeight = 13
        Me.УровеньОбразования.Location = New System.Drawing.Point(253, 171)
        Me.УровеньОбразования.Name = "УровеньОбразования"
        Me.УровеньОбразования.Size = New System.Drawing.Size(534, 21)
        Me.УровеньОбразования.TabIndex = 7
        '
        'Гражданство
        '
        Me.Гражданство.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Гражданство.FormattingEnabled = True
        Me.Гражданство.ItemHeight = 13
        Me.Гражданство.Location = New System.Drawing.Point(253, 402)
        Me.Гражданство.Name = "Гражданство"
        Me.Гражданство.Size = New System.Drawing.Size(534, 21)
        Me.Гражданство.TabIndex = 17
        '
        'ДУЛ
        '
        Me.ДУЛ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ДУЛ.FormattingEnabled = True
        Me.ДУЛ.ItemHeight = 13
        Me.ДУЛ.Location = New System.Drawing.Point(253, 424)
        Me.ДУЛ.Name = "ДУЛ"
        Me.ДУЛ.Size = New System.Drawing.Size(534, 21)
        Me.ДУЛ.TabIndex = 18
        '
        'ИсточникФин
        '
        Me.ИсточникФин.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ИсточникФин.FormattingEnabled = True
        Me.ИсточникФин.ItemHeight = 13
        Me.ИсточникФин.Location = New System.Drawing.Point(253, 552)
        Me.ИсточникФин.Name = "ИсточникФин"
        Me.ИсточникФин.Size = New System.Drawing.Size(534, 21)
        Me.ИсточникФин.TabIndex = 23
        '
        'НаправившаяОрг
        '
        Me.НаправившаяОрг.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НаправившаяОрг.FormattingEnabled = True
        Me.НаправившаяОрг.ItemHeight = 13
        Me.НаправившаяОрг.Location = New System.Drawing.Point(253, 574)
        Me.НаправившаяОрг.Name = "НаправившаяОрг"
        Me.НаправившаяОрг.Size = New System.Drawing.Size(534, 21)
        Me.НаправившаяОрг.TabIndex = 24
        '
        'doo_vid_dok
        '
        Me.doo_vid_dok.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.doo_vid_dok.FormattingEnabled = True
        Me.doo_vid_dok.ItemHeight = 13
        Me.doo_vid_dok.Location = New System.Drawing.Point(253, 216)
        Me.doo_vid_dok.Name = "doo_vid_dok"
        Me.doo_vid_dok.Size = New System.Drawing.Size(534, 21)
        Me.doo_vid_dok.TabIndex = 9
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 220)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(208, 16)
        Me.Label22.TabIndex = 188
        Me.Label22.Text = "Вид документа о образовании"
        '
        'РедакторСлушателя
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 693)
        Me.Controls.Add(Me.doo_vid_dok)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.НаправившаяОрг)
        Me.Controls.Add(Me.ИсточникФин)
        Me.Controls.Add(Me.ДУЛ)
        Me.Controls.Add(Me.Гражданство)
        Me.Controls.Add(Me.УровеньОбразования)
        Me.Controls.Add(Me.Пол)
        Me.Controls.Add(Me.ValidOn)
        Me.Controls.Add(Me.КемВыданДУЛ)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.ДатаВыдачиДУЛ)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.ДатаНаправленияРосздравнвдзора)
        Me.Controls.Add(Me.НомерНаправленияРосздравнадзора)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Телефон)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ДатаРождения)
        Me.Controls.Add(Me.Отчество)
        Me.Controls.Add(Me.BtnFocus)
        Me.Controls.Add(Me.Сообщение)
        Me.Controls.Add(Me.НомерДУЛ)
        Me.Controls.Add(Me.СерияДУЛ)
        Me.Controls.Add(Me.АдресРегистрации)
        Me.Controls.Add(Me.ФамилияВДокОбОбразовании)
        Me.Controls.Add(Me.НомерДокументаООбразовании)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.СерияДокументаООбразовании)
        Me.Controls.Add(Me.Образование)
        Me.Controls.Add(Me.Фамилия)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Имя)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Снилс)
        Me.Controls.Add(Me.Сохранить)
        Me.KeyPreview = True
        Me.Name = "РедакторСлушателя"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Телефон As MaskedTextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents ДатаРождения As DateTimePicker
    Friend WithEvents Отчество As TextBox
    Friend WithEvents BtnFocus As Button
    Friend WithEvents Сообщение As Label
    Friend WithEvents НомерДУЛ As TextBox
    Friend WithEvents СерияДУЛ As TextBox
    Friend WithEvents АдресРегистрации As TextBox
    Friend WithEvents ФамилияВДокОбОбразовании As TextBox
    Friend WithEvents НомерДокументаООбразовании As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents СерияДокументаООбразовании As TextBox
    Friend WithEvents Образование As TextBox
    Friend WithEvents Фамилия As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Имя As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Снилс As TextBox
    Friend WithEvents Сохранить As Button
    Friend WithEvents Email As TextBox
    Friend WithEvents label As Label
    Friend WithEvents ДатаНаправленияРосздравнвдзора As DateTimePicker
    Friend WithEvents НомерНаправленияРосздравнадзора As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents ДатаВыдачиДУЛ As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents КемВыданДУЛ As TextBox
    Friend WithEvents ValidOn As CheckBox
    Friend WithEvents Пол As ComboBox
    Friend WithEvents УровеньОбразования As ComboBox
    Friend WithEvents Гражданство As ComboBox
    Friend WithEvents ДУЛ As ComboBox
    Friend WithEvents ИсточникФин As ComboBox
    Friend WithEvents НаправившаяОрг As ComboBox
    Friend WithEvents doo_vid_dok As ComboBox
    Friend WithEvents Label22 As Label
End Class
