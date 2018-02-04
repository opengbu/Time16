<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrograms
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbSchool = New System.Windows.Forms.ComboBox()
        Me.dgvPrograms = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkIsActive = New System.Windows.Forms.CheckBox()
        Me.txtProgram = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProgCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvPrograms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkIsActive)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtProgram)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtProgCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSchool)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvPrograms)
        Me.SplitContainer1.Size = New System.Drawing.Size(901, 481)
        Me.SplitContainer1.SplitterDistance = 123
        Me.SplitContainer1.TabIndex = 0
        '
        'cbSchool
        '
        Me.cbSchool.DisplayMember = "Name"
        Me.cbSchool.FormattingEnabled = True
        Me.cbSchool.Location = New System.Drawing.Point(41, 12)
        Me.cbSchool.Name = "cbSchool"
        Me.cbSchool.Size = New System.Drawing.Size(102, 21)
        Me.cbSchool.TabIndex = 24
        Me.cbSchool.ValueMember = "Name"
        '
        'dgvPrograms
        '
        Me.dgvPrograms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrograms.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrograms.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrograms.Name = "dgvPrograms"
        Me.dgvPrograms.Size = New System.Drawing.Size(901, 354)
        Me.dgvPrograms.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(671, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 26)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "DELETE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(671, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 26)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "UPDATE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(671, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 26)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "ADD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkIsActive
        '
        Me.chkIsActive.AutoSize = True
        Me.chkIsActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Location = New System.Drawing.Point(491, 34)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Size = New System.Drawing.Size(65, 21)
        Me.chkIsActive.TabIndex = 29
        Me.chkIsActive.Text = "Is Lab"
        Me.chkIsActive.UseVisualStyleBackColor = True
        '
        'txtProgram
        '
        Me.txtProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgram.Location = New System.Drawing.Point(179, 66)
        Me.txtProgram.Name = "txtProgram"
        Me.txtProgram.Size = New System.Drawing.Size(377, 23)
        Me.txtProgram.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(176, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Program Name"
        '
        'txtProgCode
        '
        Me.txtProgCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProgCode.Location = New System.Drawing.Point(179, 20)
        Me.txtProgCode.Name = "txtProgCode"
        Me.txtProgCode.Size = New System.Drawing.Size(80, 23)
        Me.txtProgCode.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Code"
        '
        'frmPrograms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 481)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmPrograms"
        Me.Text = "frmPrograms"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvPrograms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents dgvPrograms As DataGridView
    Friend WithEvents cbSchool As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents txtProgram As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtProgCode As TextBox
    Friend WithEvents Label1 As Label
End Class
