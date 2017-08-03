<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSubjects
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbSchool = New System.Windows.Forms.ComboBox()
        Me.cbDept = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkLab = New System.Windows.Forms.CheckBox()
        Me.txtP = New System.Windows.Forms.TextBox()
        Me.txtT = New System.Windows.Forms.TextBox()
        Me.txtL = New System.Windows.Forms.TextBox()
        Me.txtSubjectName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubjectCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvSubject = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvSubject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 492)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSchool)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbDept)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkLab)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtP)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtT)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSubjectName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSubjectCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvSubject)
        Me.SplitContainer1.Size = New System.Drawing.Size(929, 492)
        Me.SplitContainer1.SplitterDistance = 111
        Me.SplitContainer1.TabIndex = 1
        '
        'cbSchool
        '
        Me.cbSchool.DisplayMember = "Name"
        Me.cbSchool.FormattingEnabled = True
        Me.cbSchool.Location = New System.Drawing.Point(48, 27)
        Me.cbSchool.Name = "cbSchool"
        Me.cbSchool.Size = New System.Drawing.Size(102, 21)
        Me.cbSchool.TabIndex = 23
        Me.cbSchool.ValueMember = "Name"
        '
        'cbDept
        '
        Me.cbDept.FormattingEnabled = True
        Me.cbDept.Location = New System.Drawing.Point(48, 72)
        Me.cbDept.Name = "cbDept"
        Me.cbDept.Size = New System.Drawing.Size(287, 21)
        Me.cbDept.TabIndex = 22
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(848, 78)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 26)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "DELETE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(848, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 26)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "UPDATE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(848, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 26)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "ADD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(816, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "P"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(779, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "T"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(745, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "L"
        '
        'chkLab
        '
        Me.chkLab.AutoSize = True
        Me.chkLab.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLab.Location = New System.Drawing.Point(668, 40)
        Me.chkLab.Name = "chkLab"
        Me.chkLab.Size = New System.Drawing.Size(65, 21)
        Me.chkLab.TabIndex = 15
        Me.chkLab.Text = "Is Lab"
        Me.chkLab.UseVisualStyleBackColor = True
        '
        'txtP
        '
        Me.txtP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtP.Location = New System.Drawing.Point(809, 72)
        Me.txtP.Name = "txtP"
        Me.txtP.Size = New System.Drawing.Size(29, 23)
        Me.txtP.TabIndex = 14
        Me.txtP.Text = "0"
        Me.txtP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtT
        '
        Me.txtT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT.Location = New System.Drawing.Point(774, 72)
        Me.txtT.Name = "txtT"
        Me.txtT.Size = New System.Drawing.Size(29, 23)
        Me.txtT.TabIndex = 13
        Me.txtT.Text = "1"
        Me.txtT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtL
        '
        Me.txtL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtL.Location = New System.Drawing.Point(739, 72)
        Me.txtL.Name = "txtL"
        Me.txtL.Size = New System.Drawing.Size(29, 23)
        Me.txtL.TabIndex = 12
        Me.txtL.Text = "3"
        Me.txtL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSubjectName
        '
        Me.txtSubjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubjectName.Location = New System.Drawing.Point(356, 72)
        Me.txtSubjectName.Name = "txtSubjectName"
        Me.txtSubjectName.Size = New System.Drawing.Size(377, 23)
        Me.txtSubjectName.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(353, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Subject Name"
        '
        'txtSubjectCode
        '
        Me.txtSubjectCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubjectCode.Location = New System.Drawing.Point(356, 25)
        Me.txtSubjectCode.Name = "txtSubjectCode"
        Me.txtSubjectCode.Size = New System.Drawing.Size(80, 23)
        Me.txtSubjectCode.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(353, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Code"
        '
        'dgvSubject
        '
        Me.dgvSubject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubject.Location = New System.Drawing.Point(0, 0)
        Me.dgvSubject.Name = "dgvSubject"
        Me.dgvSubject.Size = New System.Drawing.Size(929, 377)
        Me.dgvSubject.TabIndex = 0
        '
        'frmSubjects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 492)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Splitter1)
        Me.Name = "frmSubjects"
        Me.Text = "frmSubjects"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvSubject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents chkLab As CheckBox
    Friend WithEvents txtP As TextBox
    Friend WithEvents txtT As TextBox
    Friend WithEvents txtL As TextBox
    Friend WithEvents txtSubjectName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSubjectCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbDept As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvSubject As DataGridView
    Friend WithEvents cbSchool As ComboBox
End Class
