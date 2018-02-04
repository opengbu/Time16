<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePass
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tOldPass = New System.Windows.Forms.TextBox()
        Me.tNewPass = New System.Windows.Forms.TextBox()
        Me.tConfirmPass = New System.Windows.Forms.TextBox()
        Me.btnChangePass = New System.Windows.Forms.Button()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Old Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "New Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Confirm Password"
        '
        'tOldPass
        '
        Me.tOldPass.Location = New System.Drawing.Point(170, 29)
        Me.tOldPass.Name = "tOldPass"
        Me.tOldPass.Size = New System.Drawing.Size(122, 20)
        Me.tOldPass.TabIndex = 3
        Me.tOldPass.UseSystemPasswordChar = True
        '
        'tNewPass
        '
        Me.tNewPass.Location = New System.Drawing.Point(170, 55)
        Me.tNewPass.Name = "tNewPass"
        Me.tNewPass.Size = New System.Drawing.Size(122, 20)
        Me.tNewPass.TabIndex = 4
        Me.tNewPass.UseSystemPasswordChar = True
        '
        'tConfirmPass
        '
        Me.tConfirmPass.Location = New System.Drawing.Point(170, 83)
        Me.tConfirmPass.Name = "tConfirmPass"
        Me.tConfirmPass.Size = New System.Drawing.Size(122, 20)
        Me.tConfirmPass.TabIndex = 5
        Me.tConfirmPass.UseSystemPasswordChar = True
        '
        'btnChangePass
        '
        Me.btnChangePass.Location = New System.Drawing.Point(110, 129)
        Me.btnChangePass.Name = "btnChangePass"
        Me.btnChangePass.Size = New System.Drawing.Size(146, 23)
        Me.btnChangePass.TabIndex = 6
        Me.btnChangePass.Text = "Change Password"
        Me.btnChangePass.UseVisualStyleBackColor = True
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(138, 9)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(57, 13)
        Me.lblUser.TabIndex = 7
        Me.lblUser.Text = "UserName"
        '
        'frmChangePass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 176)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.btnChangePass)
        Me.Controls.Add(Me.tConfirmPass)
        Me.Controls.Add(Me.tNewPass)
        Me.Controls.Add(Me.tOldPass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmChangePass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tOldPass As TextBox
    Friend WithEvents tNewPass As TextBox
    Friend WithEvents tConfirmPass As TextBox
    Friend WithEvents btnChangePass As Button
    Friend WithEvents lblUser As Label
End Class
