Namespace Converter
	Partial Class ViewFailureDialog
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
			Me.txtSQL = New System.Windows.Forms.TextBox()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CType((177), Byte)))
			Me.label1.ForeColor = System.Drawing.Color.Red
			Me.label1.Location = New System.Drawing.Point(9, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(491, 30)
			Me.label1.TabIndex = 0
			Me.label1.Text = "View syntax cannot be transferred automatically to SQLite. Please edit the view d" + "efinition or press Cancel to discard the view from the generated SQLite database" + "."
			' 
			' txtSQL
			' 
			Me.txtSQL.Location = New System.Drawing.Point(12, 45)
			Me.txtSQL.Multiline = True
			Me.txtSQL.Name = "txtSQL"
			Me.txtSQL.Size = New System.Drawing.Size(488, 125)
			Me.txtSQL.TabIndex = 1
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(425, 181)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 2
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
			AddHandler Me.btnCancel.Click, New System.EventHandler(AddressOf Me.btnCancel_Click)
			' 
			' btnOK
			' 
			Me.btnOK.Location = New System.Drawing.Point(344, 181)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(75, 23)
			Me.btnOK.TabIndex = 3
			Me.btnOK.Text = "OK"
			Me.btnOK.UseVisualStyleBackColor = True
			AddHandler Me.btnOK.Click, New System.EventHandler(AddressOf Me.btnOK_Click)
			' 
			' ViewFailureDialog
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(515, 216)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.txtSQL)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "ViewFailureDialog"
			Me.ShowIcon = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private txtSQL As System.Windows.Forms.TextBox
		Private btnCancel As System.Windows.Forms.Button
		Private btnOK As System.Windows.Forms.Button
	End Class
End Namespace