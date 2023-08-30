<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class РедакторГруппы
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
        Me.Сохранить = New System.Windows.Forms.Button()
        Me.НоваяГруппаДатаНачалаЗанятий = New System.Windows.Forms.DateTimePicker()
        Me.ДатаВДиплома = New System.Windows.Forms.DateTimePicker()
        Me.ДатаВыдачиУд = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.РегНомерДиплома = New System.Windows.Forms.TextBox()
        Me.НомерДиплома = New System.Windows.Forms.TextBox()
        Me.РегНомерУд = New System.Windows.Forms.TextBox()
        Me.НомерУд = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.НомерПротоколаИА = New System.Windows.Forms.TextBox()
        Me.BtnFocus = New System.Windows.Forms.Button()
        Me.Сообщение = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.НоваяГруппаКонецЗанятий = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.НоваяГруппаНомер = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ДатаВСвид = New System.Windows.Forms.DateTimePicker()
        Me.РегНомерСвид = New System.Windows.Forms.TextBox()
        Me.НомерСвид = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.LabelФинансирование = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.LabelМодуль10 = New System.Windows.Forms.Label()
        Me.LabelМодуль9 = New System.Windows.Forms.Label()
        Me.LabelМодуль8 = New System.Windows.Forms.Label()
        Me.LabelМодуль7 = New System.Windows.Forms.Label()
        Me.LabelМодуль6 = New System.Windows.Forms.Label()
        Me.LabelМодуль5 = New System.Windows.Forms.Label()
        Me.LabelМодуль4 = New System.Windows.Forms.Label()
        Me.LabelМодуль3 = New System.Windows.Forms.Label()
        Me.LabelМодуль2 = New System.Windows.Forms.Label()
        Me.LabelМодуль1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.НоваяГруппаУровеньКвалификации = New System.Windows.Forms.ComboBox()
        Me.НоваяГруппаФормаОбучения = New System.Windows.Forms.ComboBox()
        Me.НоваяГруппаПрограмма = New System.Windows.Forms.ComboBox()
        Me.НоваяГруппаСпециальность = New System.Windows.Forms.ComboBox()
        Me.НоваяГруппаОтветственныйКуратор = New System.Windows.Forms.ComboBox()
        Me.НоваягруппаОтветственныйЗаПрактику = New System.Windows.Forms.ComboBox()
        Me.Модуль1 = New System.Windows.Forms.ComboBox()
        Me.Модуль10 = New System.Windows.Forms.ComboBox()
        Me.Модуль9 = New System.Windows.Forms.ComboBox()
        Me.Модуль8 = New System.Windows.Forms.ComboBox()
        Me.Модуль7 = New System.Windows.Forms.ComboBox()
        Me.Модуль6 = New System.Windows.Forms.ComboBox()
        Me.Модуль5 = New System.Windows.Forms.ComboBox()
        Me.Модуль4 = New System.Windows.Forms.ComboBox()
        Me.Модуль3 = New System.Windows.Forms.ComboBox()
        Me.Модуль2 = New System.Windows.Forms.ComboBox()
        Me.Квалификация = New System.Windows.Forms.ComboBox()
        Me.НоваяГруппаФинансирование = New System.Windows.Forms.ComboBox()
        Me.versProgs = New System.Windows.Forms.Button()
        Me.НоваяГруппаКоличествоЧасов = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Сохранить
        '
        Me.Сохранить.BackColor = System.Drawing.SystemColors.MenuBar
        Me.Сохранить.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Сохранить.Location = New System.Drawing.Point(2, 842)
        Me.Сохранить.Name = "Сохранить"
        Me.Сохранить.Size = New System.Drawing.Size(904, 36)
        Me.Сохранить.TabIndex = 35
        Me.Сохранить.Text = "Сохранить"
        Me.Сохранить.UseVisualStyleBackColor = False
        '
        'НоваяГруппаДатаНачалаЗанятий
        '
        Me.НоваяГруппаДатаНачалаЗанятий.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.НоваяГруппаДатаНачалаЗанятий.Location = New System.Drawing.Point(337, 146)
        Me.НоваяГруппаДатаНачалаЗанятий.Name = "НоваяГруппаДатаНачалаЗанятий"
        Me.НоваяГруппаДатаНачалаЗанятий.Size = New System.Drawing.Size(546, 20)
        Me.НоваяГруппаДатаНачалаЗанятий.TabIndex = 3
        Me.НоваяГруппаДатаНачалаЗанятий.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'ДатаВДиплома
        '
        Me.ДатаВДиплома.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаВДиплома.Location = New System.Drawing.Point(337, 458)
        Me.ДатаВДиплома.Name = "ДатаВДиплома"
        Me.ДатаВДиплома.Size = New System.Drawing.Size(546, 20)
        Me.ДатаВДиплома.TabIndex = 16
        Me.ДатаВДиплома.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'ДатаВыдачиУд
        '
        Me.ДатаВыдачиУд.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаВыдачиУд.Location = New System.Drawing.Point(337, 383)
        Me.ДатаВыдачиУд.Name = "ДатаВыдачиУд"
        Me.ДатаВыдачиУд.Size = New System.Drawing.Size(546, 20)
        Me.ДатаВыдачиУд.TabIndex = 13
        Me.ДатаВыдачиУд.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 460)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(165, 18)
        Me.Label28.TabIndex = 122
        Me.Label28.Text = "Дата выдачи диплома"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 438)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(245, 18)
        Me.Label29.TabIndex = 121
        Me.Label29.Text = "Регистрационный номер диплома"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label30.Location = New System.Drawing.Point(12, 416)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(177, 18)
        Me.Label30.TabIndex = 120
        Me.Label30.Text = "Серия и номер диплома"
        '
        'РегНомерДиплома
        '
        Me.РегНомерДиплома.Location = New System.Drawing.Point(337, 436)
        Me.РегНомерДиплома.Name = "РегНомерДиплома"
        Me.РегНомерДиплома.Size = New System.Drawing.Size(546, 20)
        Me.РегНомерДиплома.TabIndex = 15
        '
        'НомерДиплома
        '
        Me.НомерДиплома.Location = New System.Drawing.Point(337, 414)
        Me.НомерДиплома.Name = "НомерДиплома"
        Me.НомерДиплома.Size = New System.Drawing.Size(546, 20)
        Me.НомерДиплома.TabIndex = 14
        '
        'РегНомерУд
        '
        Me.РегНомерУд.Location = New System.Drawing.Point(337, 361)
        Me.РегНомерУд.Name = "РегНомерУд"
        Me.РегНомерУд.Size = New System.Drawing.Size(546, 20)
        Me.РегНомерУд.TabIndex = 12
        '
        'НомерУд
        '
        Me.НомерУд.Location = New System.Drawing.Point(337, 339)
        Me.НомерУд.Name = "НомерУд"
        Me.НомерУд.Size = New System.Drawing.Size(546, 20)
        Me.НомерУд.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 387)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(208, 18)
        Me.Label22.TabIndex = 119
        Me.Label22.Text = "Дата выдачи удостоверения"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label23.Location = New System.Drawing.Point(12, 365)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(288, 18)
        Me.Label23.TabIndex = 118
        Me.Label23.Text = "Регистрационный номер удостоверения"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label24.Location = New System.Drawing.Point(12, 341)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(220, 18)
        Me.Label24.TabIndex = 117
        Me.Label24.Text = "Серия и номер удостоверения"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label21.Location = New System.Drawing.Point(12, 201)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(158, 18)
        Me.Label21.TabIndex = 107
        Me.Label21.Text = "Номер протокола ИА"
        '
        'НомерПротоколаИА
        '
        Me.НомерПротоколаИА.Location = New System.Drawing.Point(337, 199)
        Me.НомерПротоколаИА.Name = "НомерПротоколаИА"
        Me.НомерПротоколаИА.Size = New System.Drawing.Size(546, 20)
        Me.НомерПротоколаИА.TabIndex = 5
        '
        'BtnFocus
        '
        Me.BtnFocus.Location = New System.Drawing.Point(202, 108)
        Me.BtnFocus.Name = "BtnFocus"
        Me.BtnFocus.Size = New System.Drawing.Size(75, 23)
        Me.BtnFocus.TabIndex = 116
        Me.BtnFocus.Text = "Button1"
        Me.BtnFocus.UseVisualStyleBackColor = True
        Me.BtnFocus.Visible = False
        '
        'Сообщение
        '
        Me.Сообщение.AutoSize = True
        Me.Сообщение.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Сообщение.Location = New System.Drawing.Point(12, 63)
        Me.Сообщение.Name = "Сообщение"
        Me.Сообщение.Size = New System.Drawing.Size(45, 13)
        Me.Сообщение.TabIndex = 109
        Me.Сообщение.Text = "Label20"
        Me.Сообщение.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 311)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(202, 18)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Ответственный за практику"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 291)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(175, 18)
        Me.Label8.TabIndex = 114
        Me.Label8.Text = "Ответственный куратор"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 269)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 18)
        Me.Label7.TabIndex = 113
        Me.Label7.Text = "Количество часов"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 18)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Специальность"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 18)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Программа"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 18)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Дата окончания занятий"
        '
        'НоваяГруппаКонецЗанятий
        '
        Me.НоваяГруппаКонецЗанятий.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.НоваяГруппаКонецЗанятий.Location = New System.Drawing.Point(337, 168)
        Me.НоваяГруппаКонецЗанятий.Name = "НоваяГруппаКонецЗанятий"
        Me.НоваяГруппаКонецЗанятий.Size = New System.Drawing.Size(546, 20)
        Me.НоваяГруппаКонецЗанятий.TabIndex = 4
        Me.НоваяГруппаКонецЗанятий.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 18)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Дата начала занятий"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 18)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Форма обучения"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 18)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Номер"
        '
        'НоваяГруппаНомер
        '
        Me.НоваяГруппаНомер.Location = New System.Drawing.Point(337, 94)
        Me.НоваяГруппаНомер.Name = "НоваяГруппаНомер"
        Me.НоваяГруппаНомер.Size = New System.Drawing.Size(546, 20)
        Me.НоваяГруппаНомер.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 327)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(893, 10)
        Me.GroupBox1.TabIndex = 123
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(2, 401)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(893, 10)
        Me.GroupBox2.TabIndex = 125
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(2, 476)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(893, 10)
        Me.GroupBox3.TabIndex = 126
        Me.GroupBox3.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Location = New System.Drawing.Point(2, 186)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(893, 10)
        Me.GroupBox7.TabIndex = 124
        Me.GroupBox7.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Location = New System.Drawing.Point(2, 134)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(893, 10)
        Me.GroupBox8.TabIndex = 127
        Me.GroupBox8.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 820)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(112, 18)
        Me.Label31.TabIndex = 159
        Me.Label31.Text = "Квалификация"
        '
        'ДатаВСвид
        '
        Me.ДатаВСвид.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ДатаВСвид.Location = New System.Drawing.Point(337, 532)
        Me.ДатаВСвид.Name = "ДатаВСвид"
        Me.ДатаВСвид.Size = New System.Drawing.Size(546, 20)
        Me.ДатаВСвид.TabIndex = 19
        Me.ДатаВСвид.Value = New Date(1753, 1, 1, 0, 0, 0, 0)
        '
        'РегНомерСвид
        '
        Me.РегНомерСвид.Location = New System.Drawing.Point(337, 511)
        Me.РегНомерСвид.Name = "РегНомерСвид"
        Me.РегНомерСвид.Size = New System.Drawing.Size(546, 20)
        Me.РегНомерСвид.TabIndex = 18
        '
        'НомерСвид
        '
        Me.НомерСвид.Location = New System.Drawing.Point(337, 489)
        Me.НомерСвид.Name = "НомерСвид"
        Me.НомерСвид.Size = New System.Drawing.Size(546, 20)
        Me.НомерСвид.TabIndex = 17
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 534)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(207, 18)
        Me.Label25.TabIndex = 158
        Me.Label25.Text = "Дата выдачи свидетельства"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label26.Location = New System.Drawing.Point(12, 513)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(287, 18)
        Me.Label26.TabIndex = 157
        Me.Label26.Text = "Регистрационный номер свидетельства"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 491)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(219, 18)
        Me.Label27.TabIndex = 156
        Me.Label27.Text = "Серия и номер свидетельства"
        '
        'LabelФинансирование
        '
        Me.LabelФинансирование.AutoSize = True
        Me.LabelФинансирование.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelФинансирование.Location = New System.Drawing.Point(12, 799)
        Me.LabelФинансирование.Name = "LabelФинансирование"
        Me.LabelФинансирование.Size = New System.Drawing.Size(126, 18)
        Me.LabelФинансирование.TabIndex = 140
        Me.LabelФинансирование.Text = "Финансирование"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 76)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(173, 18)
        Me.Label20.TabIndex = 142
        Me.Label20.Text = "Уровень квалификации"
        '
        'LabelМодуль10
        '
        Me.LabelМодуль10.AutoSize = True
        Me.LabelМодуль10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль10.Location = New System.Drawing.Point(12, 760)
        Me.LabelМодуль10.Name = "LabelМодуль10"
        Me.LabelМодуль10.Size = New System.Drawing.Size(83, 18)
        Me.LabelМодуль10.TabIndex = 147
        Me.LabelМодуль10.Text = "Модуль 10"
        '
        'LabelМодуль9
        '
        Me.LabelМодуль9.AutoSize = True
        Me.LabelМодуль9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль9.Location = New System.Drawing.Point(12, 739)
        Me.LabelМодуль9.Name = "LabelМодуль9"
        Me.LabelМодуль9.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль9.TabIndex = 146
        Me.LabelМодуль9.Text = "Модуль 9"
        '
        'LabelМодуль8
        '
        Me.LabelМодуль8.AutoSize = True
        Me.LabelМодуль8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль8.Location = New System.Drawing.Point(12, 718)
        Me.LabelМодуль8.Name = "LabelМодуль8"
        Me.LabelМодуль8.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль8.TabIndex = 145
        Me.LabelМодуль8.Text = "Модуль 8"
        '
        'LabelМодуль7
        '
        Me.LabelМодуль7.AutoSize = True
        Me.LabelМодуль7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль7.Location = New System.Drawing.Point(12, 697)
        Me.LabelМодуль7.Name = "LabelМодуль7"
        Me.LabelМодуль7.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль7.TabIndex = 144
        Me.LabelМодуль7.Text = "Модуль 7"
        '
        'LabelМодуль6
        '
        Me.LabelМодуль6.AutoSize = True
        Me.LabelМодуль6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль6.Location = New System.Drawing.Point(12, 676)
        Me.LabelМодуль6.Name = "LabelМодуль6"
        Me.LabelМодуль6.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль6.TabIndex = 155
        Me.LabelМодуль6.Text = "Модуль 6"
        '
        'LabelМодуль5
        '
        Me.LabelМодуль5.AutoSize = True
        Me.LabelМодуль5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль5.Location = New System.Drawing.Point(12, 655)
        Me.LabelМодуль5.Name = "LabelМодуль5"
        Me.LabelМодуль5.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль5.TabIndex = 154
        Me.LabelМодуль5.Text = "Модуль 5"
        '
        'LabelМодуль4
        '
        Me.LabelМодуль4.AutoSize = True
        Me.LabelМодуль4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль4.Location = New System.Drawing.Point(12, 634)
        Me.LabelМодуль4.Name = "LabelМодуль4"
        Me.LabelМодуль4.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль4.TabIndex = 153
        Me.LabelМодуль4.Text = "Модуль 4"
        '
        'LabelМодуль3
        '
        Me.LabelМодуль3.AutoSize = True
        Me.LabelМодуль3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль3.Location = New System.Drawing.Point(12, 613)
        Me.LabelМодуль3.Name = "LabelМодуль3"
        Me.LabelМодуль3.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль3.TabIndex = 152
        Me.LabelМодуль3.Text = "Модуль 3"
        '
        'LabelМодуль2
        '
        Me.LabelМодуль2.AutoSize = True
        Me.LabelМодуль2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль2.Location = New System.Drawing.Point(12, 592)
        Me.LabelМодуль2.Name = "LabelМодуль2"
        Me.LabelМодуль2.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль2.TabIndex = 151
        Me.LabelМодуль2.Text = "Модуль 2"
        '
        'LabelМодуль1
        '
        Me.LabelМодуль1.AutoSize = True
        Me.LabelМодуль1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelМодуль1.Location = New System.Drawing.Point(12, 571)
        Me.LabelМодуль1.Name = "LabelМодуль1"
        Me.LabelМодуль1.Size = New System.Drawing.Size(75, 18)
        Me.LabelМодуль1.TabIndex = 150
        Me.LabelМодуль1.Text = "Модуль 1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(2, 550)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(893, 10)
        Me.GroupBox4.TabIndex = 160
        Me.GroupBox4.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Location = New System.Drawing.Point(2, 781)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(893, 10)
        Me.GroupBox6.TabIndex = 166
        Me.GroupBox6.TabStop = False
        '
        'НоваяГруппаУровеньКвалификации
        '
        Me.НоваяГруппаУровеньКвалификации.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НоваяГруппаУровеньКвалификации.FormattingEnabled = True
        Me.НоваяГруппаУровеньКвалификации.ItemHeight = 13
        Me.НоваяГруппаУровеньКвалификации.Location = New System.Drawing.Point(337, 72)
        Me.НоваяГруппаУровеньКвалификации.Name = "НоваяГруппаУровеньКвалификации"
        Me.НоваяГруппаУровеньКвалификации.Size = New System.Drawing.Size(546, 21)
        Me.НоваяГруппаУровеньКвалификации.TabIndex = 167
        '
        'НоваяГруппаФормаОбучения
        '
        Me.НоваяГруппаФормаОбучения.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НоваяГруппаФормаОбучения.FormattingEnabled = True
        Me.НоваяГруппаФормаОбучения.ItemHeight = 13
        Me.НоваяГруппаФормаОбучения.Location = New System.Drawing.Point(337, 115)
        Me.НоваяГруппаФормаОбучения.Name = "НоваяГруппаФормаОбучения"
        Me.НоваяГруппаФормаОбучения.Size = New System.Drawing.Size(546, 21)
        Me.НоваяГруппаФормаОбучения.TabIndex = 168
        '
        'НоваяГруппаПрограмма
        '
        Me.НоваяГруппаПрограмма.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НоваяГруппаПрограмма.FormattingEnabled = True
        Me.НоваяГруппаПрограмма.ItemHeight = 13
        Me.НоваяГруппаПрограмма.Location = New System.Drawing.Point(337, 221)
        Me.НоваяГруппаПрограмма.Name = "НоваяГруппаПрограмма"
        Me.НоваяГруппаПрограмма.Size = New System.Drawing.Size(546, 21)
        Me.НоваяГруппаПрограмма.TabIndex = 169
        '
        'НоваяГруппаСпециальность
        '
        Me.НоваяГруппаСпециальность.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НоваяГруппаСпециальность.FormattingEnabled = True
        Me.НоваяГруппаСпециальность.ItemHeight = 13
        Me.НоваяГруппаСпециальность.Location = New System.Drawing.Point(337, 243)
        Me.НоваяГруппаСпециальность.Name = "НоваяГруппаСпециальность"
        Me.НоваяГруппаСпециальность.Size = New System.Drawing.Size(546, 21)
        Me.НоваяГруппаСпециальность.TabIndex = 170
        '
        'НоваяГруппаОтветственныйКуратор
        '
        Me.НоваяГруппаОтветственныйКуратор.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НоваяГруппаОтветственныйКуратор.FormattingEnabled = True
        Me.НоваяГруппаОтветственныйКуратор.ItemHeight = 13
        Me.НоваяГруппаОтветственныйКуратор.Location = New System.Drawing.Point(337, 287)
        Me.НоваяГруппаОтветственныйКуратор.Name = "НоваяГруппаОтветственныйКуратор"
        Me.НоваяГруппаОтветственныйКуратор.Size = New System.Drawing.Size(546, 21)
        Me.НоваяГруппаОтветственныйКуратор.TabIndex = 172
        '
        'НоваягруппаОтветственныйЗаПрактику
        '
        Me.НоваягруппаОтветственныйЗаПрактику.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НоваягруппаОтветственныйЗаПрактику.FormattingEnabled = True
        Me.НоваягруппаОтветственныйЗаПрактику.ItemHeight = 13
        Me.НоваягруппаОтветственныйЗаПрактику.Location = New System.Drawing.Point(337, 309)
        Me.НоваягруппаОтветственныйЗаПрактику.Name = "НоваягруппаОтветственныйЗаПрактику"
        Me.НоваягруппаОтветственныйЗаПрактику.Size = New System.Drawing.Size(546, 21)
        Me.НоваягруппаОтветственныйЗаПрактику.TabIndex = 173
        '
        'Модуль1
        '
        Me.Модуль1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль1.FormattingEnabled = True
        Me.Модуль1.ItemHeight = 13
        Me.Модуль1.Location = New System.Drawing.Point(337, 564)
        Me.Модуль1.Name = "Модуль1"
        Me.Модуль1.Size = New System.Drawing.Size(546, 21)
        Me.Модуль1.TabIndex = 174
        '
        'Модуль10
        '
        Me.Модуль10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль10.FormattingEnabled = True
        Me.Модуль10.ItemHeight = 13
        Me.Модуль10.Location = New System.Drawing.Point(337, 762)
        Me.Модуль10.Name = "Модуль10"
        Me.Модуль10.Size = New System.Drawing.Size(546, 21)
        Me.Модуль10.TabIndex = 183
        '
        'Модуль9
        '
        Me.Модуль9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль9.FormattingEnabled = True
        Me.Модуль9.ItemHeight = 13
        Me.Модуль9.Location = New System.Drawing.Point(337, 740)
        Me.Модуль9.Name = "Модуль9"
        Me.Модуль9.Size = New System.Drawing.Size(546, 21)
        Me.Модуль9.TabIndex = 182
        '
        'Модуль8
        '
        Me.Модуль8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль8.FormattingEnabled = True
        Me.Модуль8.ItemHeight = 13
        Me.Модуль8.Location = New System.Drawing.Point(337, 718)
        Me.Модуль8.Name = "Модуль8"
        Me.Модуль8.Size = New System.Drawing.Size(546, 21)
        Me.Модуль8.TabIndex = 181
        '
        'Модуль7
        '
        Me.Модуль7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль7.FormattingEnabled = True
        Me.Модуль7.ItemHeight = 13
        Me.Модуль7.Location = New System.Drawing.Point(337, 696)
        Me.Модуль7.Name = "Модуль7"
        Me.Модуль7.Size = New System.Drawing.Size(546, 21)
        Me.Модуль7.TabIndex = 180
        '
        'Модуль6
        '
        Me.Модуль6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль6.FormattingEnabled = True
        Me.Модуль6.ItemHeight = 13
        Me.Модуль6.Location = New System.Drawing.Point(337, 674)
        Me.Модуль6.Name = "Модуль6"
        Me.Модуль6.Size = New System.Drawing.Size(546, 21)
        Me.Модуль6.TabIndex = 179
        '
        'Модуль5
        '
        Me.Модуль5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль5.FormattingEnabled = True
        Me.Модуль5.ItemHeight = 13
        Me.Модуль5.Location = New System.Drawing.Point(337, 652)
        Me.Модуль5.Name = "Модуль5"
        Me.Модуль5.Size = New System.Drawing.Size(546, 21)
        Me.Модуль5.TabIndex = 178
        '
        'Модуль4
        '
        Me.Модуль4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль4.FormattingEnabled = True
        Me.Модуль4.ItemHeight = 13
        Me.Модуль4.Location = New System.Drawing.Point(337, 630)
        Me.Модуль4.Name = "Модуль4"
        Me.Модуль4.Size = New System.Drawing.Size(546, 21)
        Me.Модуль4.TabIndex = 177
        '
        'Модуль3
        '
        Me.Модуль3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль3.FormattingEnabled = True
        Me.Модуль3.ItemHeight = 13
        Me.Модуль3.Location = New System.Drawing.Point(337, 608)
        Me.Модуль3.Name = "Модуль3"
        Me.Модуль3.Size = New System.Drawing.Size(546, 21)
        Me.Модуль3.TabIndex = 176
        '
        'Модуль2
        '
        Me.Модуль2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Модуль2.FormattingEnabled = True
        Me.Модуль2.ItemHeight = 13
        Me.Модуль2.Location = New System.Drawing.Point(337, 586)
        Me.Модуль2.Name = "Модуль2"
        Me.Модуль2.Size = New System.Drawing.Size(546, 21)
        Me.Модуль2.TabIndex = 175
        '
        'Квалификация
        '
        Me.Квалификация.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Квалификация.FormattingEnabled = True
        Me.Квалификация.ItemHeight = 13
        Me.Квалификация.Location = New System.Drawing.Point(337, 818)
        Me.Квалификация.Name = "Квалификация"
        Me.Квалификация.Size = New System.Drawing.Size(546, 21)
        Me.Квалификация.TabIndex = 185
        '
        'НоваяГруппаФинансирование
        '
        Me.НоваяГруппаФинансирование.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.НоваяГруппаФинансирование.FormattingEnabled = True
        Me.НоваяГруппаФинансирование.ItemHeight = 13
        Me.НоваяГруппаФинансирование.Location = New System.Drawing.Point(337, 796)
        Me.НоваяГруппаФинансирование.Name = "НоваяГруппаФинансирование"
        Me.НоваяГруппаФинансирование.Size = New System.Drawing.Size(546, 21)
        Me.НоваяГруппаФинансирование.TabIndex = 184
        '
        'versProgs
        '
        Me.versProgs.Location = New System.Drawing.Point(227, 221)
        Me.versProgs.Name = "versProgs"
        Me.versProgs.Size = New System.Drawing.Size(104, 21)
        Me.versProgs.TabIndex = 186
        Me.versProgs.Text = "расширенный"
        Me.versProgs.UseVisualStyleBackColor = True
        '
        'НоваяГруппаКоличествоЧасов
        '
        Me.НоваяГруппаКоличествоЧасов.Location = New System.Drawing.Point(337, 266)
        Me.НоваяГруппаКоличествоЧасов.Name = "НоваяГруппаКоличествоЧасов"
        Me.НоваяГруппаКоличествоЧасов.ReadOnly = True
        Me.НоваяГруппаКоличествоЧасов.Size = New System.Drawing.Size(546, 20)
        Me.НоваяГруппаКоличествоЧасов.TabIndex = 187
        '
        'РедакторГруппы
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 880)
        Me.Controls.Add(Me.НоваяГруппаКоличествоЧасов)
        Me.Controls.Add(Me.versProgs)
        Me.Controls.Add(Me.Квалификация)
        Me.Controls.Add(Me.НоваяГруппаФинансирование)
        Me.Controls.Add(Me.Модуль10)
        Me.Controls.Add(Me.Модуль9)
        Me.Controls.Add(Me.Модуль8)
        Me.Controls.Add(Me.Модуль7)
        Me.Controls.Add(Me.Модуль6)
        Me.Controls.Add(Me.Модуль5)
        Me.Controls.Add(Me.Модуль4)
        Me.Controls.Add(Me.Модуль3)
        Me.Controls.Add(Me.Модуль2)
        Me.Controls.Add(Me.Модуль1)
        Me.Controls.Add(Me.НоваягруппаОтветственныйЗаПрактику)
        Me.Controls.Add(Me.НоваяГруппаОтветственныйКуратор)
        Me.Controls.Add(Me.НоваяГруппаСпециальность)
        Me.Controls.Add(Me.НоваяГруппаПрограмма)
        Me.Controls.Add(Me.НоваяГруппаФормаОбучения)
        Me.Controls.Add(Me.НоваяГруппаУровеньКвалификации)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.ДатаВСвид)
        Me.Controls.Add(Me.РегНомерСвид)
        Me.Controls.Add(Me.НомерСвид)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.LabelФинансирование)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.LabelМодуль10)
        Me.Controls.Add(Me.LabelМодуль9)
        Me.Controls.Add(Me.LabelМодуль8)
        Me.Controls.Add(Me.LabelМодуль7)
        Me.Controls.Add(Me.LabelМодуль6)
        Me.Controls.Add(Me.LabelМодуль5)
        Me.Controls.Add(Me.LabelМодуль4)
        Me.Controls.Add(Me.LabelМодуль3)
        Me.Controls.Add(Me.LabelМодуль2)
        Me.Controls.Add(Me.LabelМодуль1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.НоваяГруппаДатаНачалаЗанятий)
        Me.Controls.Add(Me.ДатаВДиплома)
        Me.Controls.Add(Me.ДатаВыдачиУд)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.РегНомерДиплома)
        Me.Controls.Add(Me.НомерДиплома)
        Me.Controls.Add(Me.РегНомерУд)
        Me.Controls.Add(Me.НомерУд)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.НомерПротоколаИА)
        Me.Controls.Add(Me.BtnFocus)
        Me.Controls.Add(Me.Сообщение)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.НоваяГруппаКонецЗанятий)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.НоваяГруппаНомер)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.Сохранить)
        Me.KeyPreview = True
        Me.Name = "РедакторГруппы"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Сохранить As Button
    Friend WithEvents НоваяГруппаДатаНачалаЗанятий As DateTimePicker
    Friend WithEvents ДатаВДиплома As DateTimePicker
    Friend WithEvents ДатаВыдачиУд As DateTimePicker
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents РегНомерДиплома As TextBox
    Friend WithEvents НомерДиплома As TextBox
    Friend WithEvents РегНомерУд As TextBox
    Friend WithEvents НомерУд As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents НомерПротоколаИА As TextBox
    Friend WithEvents BtnFocus As Button
    Friend WithEvents Сообщение As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents НоваяГруппаКонецЗанятий As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents НоваяГруппаНомер As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label31 As Label
    Friend WithEvents ДатаВСвид As DateTimePicker
    Friend WithEvents РегНомерСвид As TextBox
    Friend WithEvents НомерСвид As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents LabelФинансирование As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents LabelМодуль10 As Label
    Friend WithEvents LabelМодуль9 As Label
    Friend WithEvents LabelМодуль8 As Label
    Friend WithEvents LabelМодуль7 As Label
    Friend WithEvents LabelМодуль6 As Label
    Friend WithEvents LabelМодуль5 As Label
    Friend WithEvents LabelМодуль4 As Label
    Friend WithEvents LabelМодуль3 As Label
    Friend WithEvents LabelМодуль2 As Label
    Friend WithEvents LabelМодуль1 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents НоваяГруппаУровеньКвалификации As ComboBox
    Friend WithEvents НоваяГруппаФормаОбучения As ComboBox
    Friend WithEvents НоваяГруппаПрограмма As ComboBox
    Friend WithEvents НоваяГруппаСпециальность As ComboBox
    Friend WithEvents НоваяГруппаОтветственныйКуратор As ComboBox
    Friend WithEvents НоваягруппаОтветственныйЗаПрактику As ComboBox
    Friend WithEvents Модуль1 As ComboBox
    Friend WithEvents Модуль10 As ComboBox
    Friend WithEvents Модуль9 As ComboBox
    Friend WithEvents Модуль8 As ComboBox
    Friend WithEvents Модуль7 As ComboBox
    Friend WithEvents Модуль6 As ComboBox
    Friend WithEvents Модуль5 As ComboBox
    Friend WithEvents Модуль4 As ComboBox
    Friend WithEvents Модуль3 As ComboBox
    Friend WithEvents Модуль2 As ComboBox
    Friend WithEvents Квалификация As ComboBox
    Friend WithEvents НоваяГруппаФинансирование As ComboBox
    Friend WithEvents versProgs As Button
    Friend WithEvents НоваяГруппаКоличествоЧасов As TextBox
End Class
