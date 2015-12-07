<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubjectQuick
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
        Me.txtSubjectCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubjectName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtL = New System.Windows.Forms.TextBox()
        Me.txtT = New System.Windows.Forms.TextBox()
        Me.txtP = New System.Windows.Forms.TextBox()
        Me.chkLab = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code"
        '
        'txtSubjectCode
        '
        Me.txtSubjectCode.Location = New System.Drawing.Point(37, 37)
        Me.txtSubjectCode.Name = "txtSubjectCode"
        Me.txtSubjectCode.Size = New System.Drawing.Size(128, 20)
        Me.txtSubjectCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Subject Name"
        '
        'txtSubjectName
        '
        Me.txtSubjectName.Location = New System.Drawing.Point(37, 90)
        Me.txtSubjectName.Name = "txtSubjectName"
        Me.txtSubjectName.Size = New System.Drawing.Size(289, 20)
        Me.txtSubjectName.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 174)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Quick Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtL
        '
        Me.txtL.Location = New System.Drawing.Point(39, 135)
        Me.txtL.Name = "txtL"
        Me.txtL.Size = New System.Drawing.Size(29, 20)
        Me.txtL.TabIndex = 4
        Me.txtL.Text = "3"
        '
        'txtT
        '
        Me.txtT.Location = New System.Drawing.Point(82, 135)
        Me.txtT.Name = "txtT"
        Me.txtT.Size = New System.Drawing.Size(29, 20)
        Me.txtT.TabIndex = 5
        Me.txtT.Text = "1"
        '
        'txtP
        '
        Me.txtP.Location = New System.Drawing.Point(127, 135)
        Me.txtP.Name = "txtP"
        Me.txtP.Size = New System.Drawing.Size(29, 20)
        Me.txtP.TabIndex = 6
        Me.txtP.Text = "0"
        '
        'chkLab
        '
        Me.chkLab.AutoSize = True
        Me.chkLab.Location = New System.Drawing.Point(227, 137)
        Me.chkLab.Name = "chkLab"
        Me.chkLab.Size = New System.Drawing.Size(55, 17)
        Me.chkLab.TabIndex = 7
        Me.chkLab.Text = "Is Lab"
        Me.chkLab.UseVisualStyleBackColor = True
        '
        'frmSubjectQuick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 209)
        Me.Controls.Add(Me.chkLab)
        Me.Controls.Add(Me.txtP)
        Me.Controls.Add(Me.txtT)
        Me.Controls.Add(Me.txtL)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSubjectName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSubjectCode)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmSubjectQuick"
        Me.Text = "Timetable :: Quick Subject"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSubjectCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSubjectName As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtL As System.Windows.Forms.TextBox
    Friend WithEvents txtT As System.Windows.Forms.TextBox
    Friend WithEvents txtP As System.Windows.Forms.TextBox
    Friend WithEvents chkLab As System.Windows.Forms.CheckBox
End Class
