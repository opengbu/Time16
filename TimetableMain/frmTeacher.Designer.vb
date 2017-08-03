<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeacher
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.frmTeacher_Menu_Filter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSchoolFacultyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvTeacher = New System.Windows.Forms.DataGridView()
        Me.VCourseStructureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ECollegeDataSet = New TimeTableManager.eCollegeDataSet()
        Me.SubjectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CSFViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SectionTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter()
        Me.SectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SubjectTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblEditMessage = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btResetNew = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btFrmTeacher_Update = New System.Windows.Forms.Button()
        Me.btFrmTeacher_Save = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAbbr = New System.Windows.Forms.TextBox()
        Me.txtFacultyName = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rb_Faculty_Status_Both = New System.Windows.Forms.RadioButton()
        Me.rb_Faculty_Status_Guest = New System.Windows.Forms.RadioButton()
        Me.rb_Faculty_Status_Regular = New System.Windows.Forms.RadioButton()
        Me.chkDept_NO = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDept = New System.Windows.Forms.ComboBox()
        Me.cbSchool = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvTeacher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VCourseStructureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSFViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 490)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(878, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.frmTeacher_Menu_Filter, Me.ShowSchoolFacultyToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(878, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'frmTeacher_Menu_Filter
        '
        Me.frmTeacher_Menu_Filter.Name = "frmTeacher_Menu_Filter"
        Me.frmTeacher_Menu_Filter.Size = New System.Drawing.Size(106, 20)
        Me.frmTeacher_Menu_Filter.Text = "Show All Faculty"
        '
        'ShowSchoolFacultyToolStripMenuItem
        '
        Me.ShowSchoolFacultyToolStripMenuItem.Name = "ShowSchoolFacultyToolStripMenuItem"
        Me.ShowSchoolFacultyToolStripMenuItem.Size = New System.Drawing.Size(128, 20)
        Me.ShowSchoolFacultyToolStripMenuItem.Text = "Show School Faculty"
        '
        'dgvTeacher
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvTeacher.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTeacher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvTeacher.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvTeacher.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTeacher.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTeacher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTeacher.Location = New System.Drawing.Point(0, 0)
        Me.dgvTeacher.Name = "dgvTeacher"
        Me.dgvTeacher.ReadOnly = True
        Me.dgvTeacher.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvTeacher.RowHeadersWidth = 50
        Me.dgvTeacher.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTeacher.RowTemplate.Height = 25
        Me.dgvTeacher.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTeacher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTeacher.Size = New System.Drawing.Size(878, 321)
        Me.dgvTeacher.TabIndex = 0
        Me.dgvTeacher.TabStop = False
        '
        'VCourseStructureBindingSource
        '
        Me.VCourseStructureBindingSource.DataMember = "V_CourseStructure"
        Me.VCourseStructureBindingSource.DataSource = Me.ECollegeDataSet
        '
        'ECollegeDataSet
        '
        Me.ECollegeDataSet.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SubjectBindingSource
        '
        Me.SubjectBindingSource.DataMember = "Subject"
        Me.SubjectBindingSource.DataSource = Me.ECollegeDataSet
        '
        'CSFViewBindingSource
        '
        Me.CSFViewBindingSource.DataMember = "CSF_View"
        Me.CSFViewBindingSource.DataSource = Me.ECollegeDataSet
        '
        'SectionTableAdapter
        '
        Me.SectionTableAdapter.ClearBeforeFill = True
        '
        'SectionBindingSource
        '
        Me.SectionBindingSource.DataMember = "Section"
        Me.SectionBindingSource.DataSource = Me.ECollegeDataSet
        '
        'SubjectTableAdapter
        '
        Me.SubjectTableAdapter.ClearBeforeFill = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblEditMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkDept_NO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbDept)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSchool)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvTeacher)
        Me.SplitContainer1.Size = New System.Drawing.Size(878, 466)
        Me.SplitContainer1.SplitterDistance = 141
        Me.SplitContainer1.TabIndex = 7
        '
        'lblEditMessage
        '
        Me.lblEditMessage.AutoSize = True
        Me.lblEditMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditMessage.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditMessage.Location = New System.Drawing.Point(23, 117)
        Me.lblEditMessage.Name = "lblEditMessage"
        Me.lblEditMessage.Size = New System.Drawing.Size(433, 17)
        Me.lblEditMessage.TabIndex = 29
        Me.lblEditMessage.Text = "To Update or Delete any record - Double click that record."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.btResetNew)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtId)
        Me.GroupBox2.Controls.Add(Me.btFrmTeacher_Update)
        Me.GroupBox2.Controls.Add(Me.btFrmTeacher_Save)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtAbbr)
        Me.GroupBox2.Controls.Add(Me.txtFacultyName)
        Me.GroupBox2.Location = New System.Drawing.Point(293, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(363, 115)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(161, 81)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(135, 26)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Delete Selected Row"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'btResetNew
        '
        Me.btResetNew.Location = New System.Drawing.Point(296, 81)
        Me.btResetNew.Name = "btResetNew"
        Me.btResetNew.Size = New System.Drawing.Size(57, 26)
        Me.btResetNew.TabIndex = 27
        Me.btResetNew.Text = "Go Back"
        Me.btResetNew.UseVisualStyleBackColor = True
        Me.btResetNew.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Id"
        '
        'txtId
        '
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(266, 49)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(87, 20)
        Me.txtId.TabIndex = 25
        '
        'btFrmTeacher_Update
        '
        Me.btFrmTeacher_Update.Location = New System.Drawing.Point(26, 81)
        Me.btFrmTeacher_Update.Name = "btFrmTeacher_Update"
        Me.btFrmTeacher_Update.Size = New System.Drawing.Size(135, 26)
        Me.btFrmTeacher_Update.TabIndex = 24
        Me.btFrmTeacher_Update.Text = "Update Selected Row"
        Me.btFrmTeacher_Update.UseVisualStyleBackColor = True
        Me.btFrmTeacher_Update.Visible = False
        '
        'btFrmTeacher_Save
        '
        Me.btFrmTeacher_Save.Location = New System.Drawing.Point(218, 81)
        Me.btFrmTeacher_Save.Name = "btFrmTeacher_Save"
        Me.btFrmTeacher_Save.Size = New System.Drawing.Size(135, 26)
        Me.btFrmTeacher_Save.TabIndex = 23
        Me.btFrmTeacher_Save.Text = "Save New"
        Me.btFrmTeacher_Save.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Abbr."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Faculty Name"
        '
        'txtAbbr
        '
        Me.txtAbbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbbr.Location = New System.Drawing.Point(77, 47)
        Me.txtAbbr.Name = "txtAbbr"
        Me.txtAbbr.Size = New System.Drawing.Size(56, 23)
        Me.txtAbbr.TabIndex = 20
        '
        'txtFacultyName
        '
        Me.txtFacultyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacultyName.Location = New System.Drawing.Point(77, 17)
        Me.txtFacultyName.Name = "txtFacultyName"
        Me.txtFacultyName.Size = New System.Drawing.Size(276, 23)
        Me.txtFacultyName.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_Faculty_Status_Both)
        Me.GroupBox1.Controls.Add(Me.rb_Faculty_Status_Guest)
        Me.GroupBox1.Controls.Add(Me.rb_Faculty_Status_Regular)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 100)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'rb_Faculty_Status_Both
        '
        Me.rb_Faculty_Status_Both.AutoSize = True
        Me.rb_Faculty_Status_Both.Checked = True
        Me.rb_Faculty_Status_Both.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rb_Faculty_Status_Both.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_Faculty_Status_Both.Location = New System.Drawing.Point(10, 73)
        Me.rb_Faculty_Status_Both.Name = "rb_Faculty_Status_Both"
        Me.rb_Faculty_Status_Both.Size = New System.Drawing.Size(239, 23)
        Me.rb_Faculty_Status_Both.TabIndex = 19
        Me.rb_Faculty_Status_Both.TabStop = True
        Me.rb_Faculty_Status_Both.Text = "Combind Both Regular + Guest"
        Me.rb_Faculty_Status_Both.UseVisualStyleBackColor = True
        '
        'rb_Faculty_Status_Guest
        '
        Me.rb_Faculty_Status_Guest.AutoSize = True
        Me.rb_Faculty_Status_Guest.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rb_Faculty_Status_Guest.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_Faculty_Status_Guest.Location = New System.Drawing.Point(10, 43)
        Me.rb_Faculty_Status_Guest.Name = "rb_Faculty_Status_Guest"
        Me.rb_Faculty_Status_Guest.Size = New System.Drawing.Size(123, 23)
        Me.rb_Faculty_Status_Guest.TabIndex = 18
        Me.rb_Faculty_Status_Guest.Text = "Guest Faculty"
        Me.rb_Faculty_Status_Guest.UseVisualStyleBackColor = True
        '
        'rb_Faculty_Status_Regular
        '
        Me.rb_Faculty_Status_Regular.AutoSize = True
        Me.rb_Faculty_Status_Regular.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rb_Faculty_Status_Regular.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_Faculty_Status_Regular.Location = New System.Drawing.Point(10, 14)
        Me.rb_Faculty_Status_Regular.Name = "rb_Faculty_Status_Regular"
        Me.rb_Faculty_Status_Regular.Size = New System.Drawing.Size(134, 23)
        Me.rb_Faculty_Status_Regular.TabIndex = 17
        Me.rb_Faculty_Status_Regular.Text = "Regular Faculty"
        Me.rb_Faculty_Status_Regular.UseVisualStyleBackColor = True
        '
        'chkDept_NO
        '
        Me.chkDept_NO.AutoSize = True
        Me.chkDept_NO.Checked = True
        Me.chkDept_NO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDept_NO.Enabled = False
        Me.chkDept_NO.Location = New System.Drawing.Point(663, 97)
        Me.chkDept_NO.Name = "chkDept_NO"
        Me.chkDept_NO.Size = New System.Drawing.Size(40, 17)
        Me.chkDept_NO.TabIndex = 8
        Me.chkDept_NO.Text = "No"
        Me.chkDept_NO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(660, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Department"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(660, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "School"
        '
        'cbDept
        '
        Me.cbDept.Enabled = False
        Me.cbDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDept.FormattingEnabled = True
        Me.cbDept.Location = New System.Drawing.Point(663, 68)
        Me.cbDept.Name = "cbDept"
        Me.cbDept.Size = New System.Drawing.Size(210, 24)
        Me.cbDept.TabIndex = 5
        '
        'cbSchool
        '
        Me.cbSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSchool.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSchool.FormattingEnabled = True
        Me.cbSchool.Items.AddRange(New Object() {"SOE", "SOICT", "SOBT", "SOVSAS", "SOM", "SOLJ", "SOHSS", "SOBSC"})
        Me.cbSchool.Location = New System.Drawing.Point(663, 26)
        Me.cbSchool.Name = "cbSchool"
        Me.cbSchool.Size = New System.Drawing.Size(149, 24)
        Me.cbSchool.TabIndex = 4
        '
        'frmTeacher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 512)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmTeacher"
        Me.Text = "frmTeacher"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvTeacher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VCourseStructureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSFViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents frmTeacher_Menu_Filter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvTeacher As System.Windows.Forms.DataGridView
    Friend WithEvents VCourseStructureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ECollegeDataSet As TimeTableManager.eCollegeDataSet
    Friend WithEvents SubjectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CSFViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SectionTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter
    Friend WithEvents SectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubjectTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cbDept As System.Windows.Forms.ComboBox
    Friend WithEvents cbSchool As System.Windows.Forms.ComboBox
    Friend WithEvents chkDept_NO As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEditMessage As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btResetNew As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents btFrmTeacher_Update As System.Windows.Forms.Button
    Friend WithEvents btFrmTeacher_Save As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAbbr As System.Windows.Forms.TextBox
    Friend WithEvents txtFacultyName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_Faculty_Status_Both As System.Windows.Forms.RadioButton
    Friend WithEvents rb_Faculty_Status_Guest As System.Windows.Forms.RadioButton
    Friend WithEvents rb_Faculty_Status_Regular As System.Windows.Forms.RadioButton
    Friend WithEvents ShowSchoolFacultyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
