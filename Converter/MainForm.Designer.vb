Namespace Converter
	Partial Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label1 = New System.Windows.Forms.Label()
			Me.txtSqlAddress = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.txtSQLitePath = New System.Windows.Forms.TextBox()
			Me.btnBrowseSQLitePath = New System.Windows.Forms.Button()
			Me.btnStart = New System.Windows.Forms.Button()
			Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
			Me.label3 = New System.Windows.Forms.Label()
			Me.cboDatabases = New System.Windows.Forms.ComboBox()
			Me.btnSet = New System.Windows.Forms.Button()
			Me.pbrProgress = New System.Windows.Forms.ProgressBar()
			Me.lblMessage = New System.Windows.Forms.Label()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.cbxEncrypt = New System.Windows.Forms.CheckBox()
			Me.txtPassword = New System.Windows.Forms.TextBox()
			Me.cbxIntegrated = New System.Windows.Forms.CheckBox()
			Me.txtUserDB = New System.Windows.Forms.TextBox()
			Me.txtPassDB = New System.Windows.Forms.TextBox()
			Me.lblUser = New System.Windows.Forms.Label()
			Me.lblPassword = New System.Windows.Forms.Label()
			Me.cbxTriggers = New System.Windows.Forms.CheckBox()
			Me.cbxCreateViews = New System.Windows.Forms.CheckBox()
			Me.button1 = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 20)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(106, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "SQL Server Address:"
			' 
			' txtSqlAddress
			' 
			Me.txtSqlAddress.Location = New System.Drawing.Point(154, 17)
			Me.txtSqlAddress.Name = "txtSqlAddress"
			Me.txtSqlAddress.Size = New System.Drawing.Size(429, 20)
			Me.txtSqlAddress.TabIndex = 1
			Me.txtSqlAddress.Text = "10.10.32.10"
			AddHandler Me.txtSqlAddress.TextChanged, New System.EventHandler(AddressOf Me.txtSqlAddress_TextChanged)
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 101)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(135, 13)
			Me.label2.TabIndex = 10
			Me.label2.Text = "SQLite Database File Path:"
			' 
			' txtSQLitePath
			' 
			Me.txtSQLitePath.Location = New System.Drawing.Point(154, 98)
			Me.txtSQLitePath.Name = "txtSQLitePath"
			Me.txtSQLitePath.Size = New System.Drawing.Size(429, 20)
			Me.txtSQLitePath.TabIndex = 11
			Me.txtSQLitePath.Text = "D:\Timetables2014\varun.db"
			AddHandler Me.txtSQLitePath.TextChanged, New System.EventHandler(AddressOf Me.txtSQLitePath_TextChanged)
			' 
			' btnBrowseSQLitePath
			' 
			Me.btnBrowseSQLitePath.Location = New System.Drawing.Point(589, 96)
			Me.btnBrowseSQLitePath.Name = "btnBrowseSQLitePath"
			Me.btnBrowseSQLitePath.Size = New System.Drawing.Size(75, 23)
			Me.btnBrowseSQLitePath.TabIndex = 12
			Me.btnBrowseSQLitePath.Text = "Browse..."
			Me.btnBrowseSQLitePath.UseVisualStyleBackColor = True
			AddHandler Me.btnBrowseSQLitePath.Click, New System.EventHandler(AddressOf Me.btnBrowseSQLitePath_Click)
			' 
			' btnStart
			' 
			Me.btnStart.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)), System.Windows.Forms.AnchorStyles))
			Me.btnStart.Location = New System.Drawing.Point(365, 216)
			Me.btnStart.Name = "btnStart"
			Me.btnStart.Size = New System.Drawing.Size(198, 23)
			Me.btnStart.TabIndex = 17
			Me.btnStart.Text = "Start The Conversion Process"
			Me.btnStart.UseVisualStyleBackColor = True
			AddHandler Me.btnStart.Click, New System.EventHandler(AddressOf Me.btnStart_Click)
			' 
			' saveFileDialog1
			' 
			Me.saveFileDialog1.DefaultExt = "db"
			Me.saveFileDialog1.Filter = "SQLite Files|*.db|All Files|*.*"
			Me.saveFileDialog1.RestoreDirectory = True
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 46)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(58, 13)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Select DB:"
			' 
			' cboDatabases
			' 
			Me.cboDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
			Me.cboDatabases.Enabled = False
			Me.cboDatabases.FormattingEnabled = True
			Me.cboDatabases.Location = New System.Drawing.Point(154, 43)
			Me.cboDatabases.Name = "cboDatabases"
			Me.cboDatabases.Size = New System.Drawing.Size(429, 21)
			Me.cboDatabases.TabIndex = 4
			Me.cboDatabases.Text = "TIMETABLE_JAN2015"
			AddHandler Me.cboDatabases.SelectedIndexChanged, New System.EventHandler(AddressOf Me.cboDatabases_SelectedIndexChanged)
			' 
			' btnSet
			' 
			Me.btnSet.Location = New System.Drawing.Point(589, 15)
			Me.btnSet.Name = "btnSet"
			Me.btnSet.Size = New System.Drawing.Size(75, 23)
			Me.btnSet.TabIndex = 2
			Me.btnSet.Text = "Set"
			Me.btnSet.UseVisualStyleBackColor = True
			AddHandler Me.btnSet.Click, New System.EventHandler(AddressOf Me.btnSet_Click)
			' 
			' pbrProgress
			' 
			Me.pbrProgress.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)), System.Windows.Forms.AnchorStyles))
			Me.pbrProgress.Location = New System.Drawing.Point(12, 195)
			Me.pbrProgress.Name = "pbrProgress"
			Me.pbrProgress.Size = New System.Drawing.Size(652, 18)
			Me.pbrProgress.TabIndex = 16
			' 
			' lblMessage
			' 
			Me.lblMessage.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)), System.Windows.Forms.AnchorStyles))
			Me.lblMessage.Location = New System.Drawing.Point(12, 177)
			Me.lblMessage.Name = "lblMessage"
			Me.lblMessage.Size = New System.Drawing.Size(529, 13)
			Me.lblMessage.TabIndex = 15
			Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.Location = New System.Drawing.Point(569, 216)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(95, 23)
			Me.btnCancel.TabIndex = 18
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
			AddHandler Me.btnCancel.Click, New System.EventHandler(AddressOf Me.btnCancel_Click)
			' 
			' cbxEncrypt
			' 
			Me.cbxEncrypt.AutoSize = True
			Me.cbxEncrypt.Location = New System.Drawing.Point(15, 127)
			Me.cbxEncrypt.Name = "cbxEncrypt"
			Me.cbxEncrypt.Size = New System.Drawing.Size(127, 17)
			Me.cbxEncrypt.TabIndex = 13
			Me.cbxEncrypt.Text = "Encryption password:"
			Me.cbxEncrypt.UseVisualStyleBackColor = True
			AddHandler Me.cbxEncrypt.CheckedChanged, New System.EventHandler(AddressOf Me.cbxEncrypt_CheckedChanged)
			' 
			' txtPassword
			' 
			Me.txtPassword.Location = New System.Drawing.Point(154, 125)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.PasswordChar = "*"C
			Me.txtPassword.Size = New System.Drawing.Size(197, 20)
			Me.txtPassword.TabIndex = 14
			AddHandler Me.txtPassword.TextChanged, New System.EventHandler(AddressOf Me.txtPassword_TextChanged)
			' 
			' cbxIntegrated
			' 
			Me.cbxIntegrated.Location = New System.Drawing.Point(15, 71)
			Me.cbxIntegrated.Name = "cbxIntegrated"
			Me.cbxIntegrated.Size = New System.Drawing.Size(130, 21)
			Me.cbxIntegrated.TabIndex = 5
			Me.cbxIntegrated.Text = "Integrated security"
			Me.cbxIntegrated.UseVisualStyleBackColor = True
			AddHandler Me.cbxIntegrated.CheckedChanged, New System.EventHandler(AddressOf Me.ChkIntegratedCheckedChanged)
			' 
			' txtUserDB
			' 
			Me.txtUserDB.Location = New System.Drawing.Point(189, 71)
			Me.txtUserDB.Name = "txtUserDB"
			Me.txtUserDB.Size = New System.Drawing.Size(100, 20)
			Me.txtUserDB.TabIndex = 7
			Me.txtUserDB.Text = "sa"
			Me.txtUserDB.Visible = False
			' 
			' txtPassDB
			' 
			Me.txtPassDB.Location = New System.Drawing.Point(354, 71)
			Me.txtPassDB.Name = "txtPassDB"
			Me.txtPassDB.PasswordChar = "*"C
			Me.txtPassDB.Size = New System.Drawing.Size(113, 20)
			Me.txtPassDB.TabIndex = 9
			Me.txtPassDB.Text = "12345"
			Me.txtPassDB.Visible = False
			' 
			' lblUser
			' 
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New System.Drawing.Point(151, 74)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New System.Drawing.Size(32, 13)
			Me.lblUser.TabIndex = 6
			Me.lblUser.Text = "User:"
			Me.lblUser.Visible = False
			' 
			' lblPassword
			' 
			Me.lblPassword.AutoSize = True
			Me.lblPassword.Location = New System.Drawing.Point(295, 74)
			Me.lblPassword.Name = "lblPassword"
			Me.lblPassword.Size = New System.Drawing.Size(56, 13)
			Me.lblPassword.TabIndex = 8
			Me.lblPassword.Text = "Password:"
			Me.lblPassword.Visible = False
			' 
			' cbxTriggers
			' 
			Me.cbxTriggers.AutoSize = True
			Me.cbxTriggers.Location = New System.Drawing.Point(15, 151)
			Me.cbxTriggers.Name = "cbxTriggers"
			Me.cbxTriggers.Size = New System.Drawing.Size(201, 17)
			Me.cbxTriggers.TabIndex = 19
			Me.cbxTriggers.Text = "Create triggers enforcing foreign keys"
			Me.cbxTriggers.UseVisualStyleBackColor = True
			' 
			' cbxCreateViews
			' 
			Me.cbxCreateViews.AutoSize = True
			Me.cbxCreateViews.Location = New System.Drawing.Point(222, 151)
			Me.cbxCreateViews.Name = "cbxCreateViews"
			Me.cbxCreateViews.Size = New System.Drawing.Size(249, 17)
			Me.cbxCreateViews.TabIndex = 20
			Me.cbxCreateViews.Text = "Try to create views (works only in simple cases)"
			Me.cbxCreateViews.UseVisualStyleBackColor = True
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(15, 216)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(75, 23)
			Me.button1.TabIndex = 21
			Me.button1.Text = "Upload"
			Me.button1.UseVisualStyleBackColor = True
			AddHandler Me.button1.Click, New System.EventHandler(AddressOf Me.button1_Click)
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(676, 242)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.cbxCreateViews)
			Me.Controls.Add(Me.cbxTriggers)
			Me.Controls.Add(Me.txtPassDB)
			Me.Controls.Add(Me.txtUserDB)
			Me.Controls.Add(Me.cbxIntegrated)
			Me.Controls.Add(Me.txtPassword)
			Me.Controls.Add(Me.cbxEncrypt)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.lblMessage)
			Me.Controls.Add(Me.pbrProgress)
			Me.Controls.Add(Me.btnSet)
			Me.Controls.Add(Me.cboDatabases)
			Me.Controls.Add(Me.lblPassword)
			Me.Controls.Add(Me.lblUser)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.btnStart)
			Me.Controls.Add(Me.btnBrowseSQLitePath)
			Me.Controls.Add(Me.txtSQLitePath)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.txtSqlAddress)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.Name = "MainForm"
			Me.Text = "SQL Server To SQLite DB Converter"
			AddHandler Me.FormClosing, New System.Windows.Forms.FormClosingEventHandler(AddressOf Me.MainForm_FormClosing)
			AddHandler Me.Load, New System.EventHandler(AddressOf Me.MainForm_Load)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		Private lblPassword As System.Windows.Forms.Label
		Private lblUser As System.Windows.Forms.Label
		Private txtPassDB As System.Windows.Forms.TextBox
		Private txtUserDB As System.Windows.Forms.TextBox
		Private cbxIntegrated As System.Windows.Forms.CheckBox

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private txtSqlAddress As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private txtSQLitePath As System.Windows.Forms.TextBox
		Private btnBrowseSQLitePath As System.Windows.Forms.Button
		Private btnStart As System.Windows.Forms.Button
		Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
		Private label3 As System.Windows.Forms.Label
		Private cboDatabases As System.Windows.Forms.ComboBox
		Private btnSet As System.Windows.Forms.Button
		Private pbrProgress As System.Windows.Forms.ProgressBar
		Private lblMessage As System.Windows.Forms.Label
		Private btnCancel As System.Windows.Forms.Button
		Private cbxEncrypt As System.Windows.Forms.CheckBox
		Private txtPassword As System.Windows.Forms.TextBox
		Private cbxTriggers As System.Windows.Forms.CheckBox
		Private cbxCreateViews As System.Windows.Forms.CheckBox
		Private button1 As System.Windows.Forms.Button
	End Class
End Namespace