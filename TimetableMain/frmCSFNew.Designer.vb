<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRMcsfnew
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Delete_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ECollegeDataSet3 = New TimeTableManager.eCollegeDataSet()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.TeacherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nPA = New System.Windows.Forms.NumericUpDown()
        Me.nTA = New System.Windows.Forms.NumericUpDown()
        Me.nLA = New System.Windows.Forms.NumericUpDown()
        Me.pfac = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.dgvCourse = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsLabDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SemesterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VCourseStructureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SectionTableAdapter1 = New TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter()
        Me.TeacherTableAdapter1 = New TimeTableManager.eCollegeDataSetTableAdapters.TeacherTableAdapter()
        Me.V_CourseStructureTableAdapter1 = New TimeTableManager.eCollegeDataSetTableAdapters.V_CourseStructureTableAdapter()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nPA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nTA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nLA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCourse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VCourseStructureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.63547!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.36453!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Delete_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(557, 427)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(287, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(127, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Partial Delete"
        Me.Button2.Visible = False
        '
        'Delete_Button
        '
        Me.Delete_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Delete_Button.Location = New System.Drawing.Point(75, 3)
        Me.Delete_Button.Name = "Delete_Button"
        Me.Delete_Button.Size = New System.Drawing.Size(46, 23)
        Me.Delete_Button.TabIndex = 7
        Me.Delete_Button.Text = "Delete"
        Me.Delete_Button.Visible = False
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(66, 23)
        Me.OK_Button.TabIndex = 6
        Me.OK_Button.Text = "Add/Update"
        Me.OK_Button.Visible = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(226, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(48, 23)
        Me.Cancel_Button.TabIndex = 5
        Me.Cancel_Button.Text = "Cancel"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(201, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "New Class Subject Faculty Allocation"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.SectionBindingSource
        Me.ComboBox1.DisplayMember = "Name"
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(72, 26)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 24)
        Me.ComboBox1.TabIndex = 13
        Me.ComboBox1.ValueMember = "Id"
        '
        'SectionBindingSource
        '
        Me.SectionBindingSource.DataMember = "Section"
        Me.SectionBindingSource.DataSource = Me.ECollegeDataSet3
        '
        'ECollegeDataSet3
        '
        Me.ECollegeDataSet3.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Class"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(553, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Select Faculty Member"
        '
        'ComboBox3
        '
        Me.ComboBox3.DataSource = Me.TeacherBindingSource
        Me.ComboBox3.DisplayMember = "name"
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(554, 81)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox3.TabIndex = 1
        Me.ComboBox3.ValueMember = "Id"
        '
        'TeacherBindingSource
        '
        Me.TeacherBindingSource.DataMember = "Teacher"
        Me.TeacherBindingSource.DataSource = Me.ECollegeDataSet3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(772, 239)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(58, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(533, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "L  :  T  :  P"
        Me.Label4.Visible = False
        '
        'nPA
        '
        Me.nPA.Location = New System.Drawing.Point(798, 44)
        Me.nPA.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nPA.Name = "nPA"
        Me.nPA.Size = New System.Drawing.Size(34, 20)
        Me.nPA.TabIndex = 17
        Me.nPA.Visible = False
        '
        'nTA
        '
        Me.nTA.Location = New System.Drawing.Point(740, 44)
        Me.nTA.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nTA.Name = "nTA"
        Me.nTA.Size = New System.Drawing.Size(35, 20)
        Me.nTA.TabIndex = 16
        Me.nTA.Value = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nTA.Visible = False
        '
        'nLA
        '
        Me.nLA.Location = New System.Drawing.Point(694, 44)
        Me.nLA.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.nLA.Name = "nLA"
        Me.nLA.Size = New System.Drawing.Size(38, 20)
        Me.nLA.TabIndex = 15
        Me.nLA.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nLA.Visible = False
        '
        'pfac
        '
        Me.pfac.Location = New System.Drawing.Point(633, 19)
        Me.pfac.Name = "pfac"
        Me.pfac.Size = New System.Drawing.Size(197, 20)
        Me.pfac.TabIndex = 25
        Me.pfac.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(789, 82)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(41, 23)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "Add New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(725, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "CSF ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(573, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Faculty ID"
        Me.Label6.Visible = False
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(554, 266)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(276, 134)
        Me.ListBox3.TabIndex = 32
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(554, 150)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(276, 23)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "Assign Faculty to subject"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(554, 180)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(276, 23)
        Me.Button5.TabIndex = 3
        Me.Button5.Text = "Add faculty- Combind with selected faculty."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(556, 210)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(276, 23)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Delete Faculty Assignment"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Location = New System.Drawing.Point(238, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(375, 273)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Faculty to unassign."
        Me.GroupBox1.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(229, 11)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(114, 23)
        Me.Button7.TabIndex = 0
        Me.Button7.Text = "Delete Selected."
        Me.Button7.UseVisualStyleBackColor = True
        '
        'dgvCourse
        '
        Me.dgvCourse.AllowUserToAddRows = False
        Me.dgvCourse.AllowUserToDeleteRows = False
        Me.dgvCourse.AllowUserToResizeColumns = False
        Me.dgvCourse.AllowUserToResizeRows = False
        Me.dgvCourse.AutoGenerateColumns = False
        Me.dgvCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCourse.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.IsLabDataGridViewCheckBoxColumn, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.SemesterDataGridViewTextBoxColumn})
        Me.dgvCourse.DataSource = Me.VCourseStructureBindingSource
        Me.dgvCourse.Location = New System.Drawing.Point(24, 116)
        Me.dgvCourse.Name = "dgvCourse"
        Me.dgvCourse.ReadOnly = True
        Me.dgvCourse.RowHeadersVisible = False
        Me.dgvCourse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCourse.Size = New System.Drawing.Size(477, 337)
        Me.dgvCourse.TabIndex = 37
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 2
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Width = 2
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Subject_Code"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Code"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 75
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Subject_Name"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Subject"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'IsLabDataGridViewCheckBoxColumn
        '
        Me.IsLabDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IsLabDataGridViewCheckBoxColumn.DataPropertyName = "IsLab"
        Me.IsLabDataGridViewCheckBoxColumn.HeaderText = "IsLab"
        Me.IsLabDataGridViewCheckBoxColumn.Name = "IsLabDataGridViewCheckBoxColumn"
        Me.IsLabDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsLabDataGridViewCheckBoxColumn.Width = 39
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "L"
        Me.DataGridViewTextBoxColumn4.HeaderText = "L"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 38
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "T"
        Me.DataGridViewTextBoxColumn5.HeaderText = "T"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 39
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "P"
        Me.DataGridViewTextBoxColumn6.HeaderText = "P"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 39
        '
        'SemesterDataGridViewTextBoxColumn
        '
        Me.SemesterDataGridViewTextBoxColumn.DataPropertyName = "semester"
        Me.SemesterDataGridViewTextBoxColumn.HeaderText = "semester"
        Me.SemesterDataGridViewTextBoxColumn.Name = "SemesterDataGridViewTextBoxColumn"
        Me.SemesterDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VCourseStructureBindingSource
        '
        Me.VCourseStructureBindingSource.DataMember = "V_CourseStructure"
        Me.VCourseStructureBindingSource.DataSource = Me.ECollegeDataSet3
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.AcceptsTab = True
        Me.TextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Location = New System.Drawing.Point(165, 90)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(160, 20)
        Me.TextBox2.TabIndex = 0
        '
        'Button8
        '
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button8.Location = New System.Drawing.Point(331, 90)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(85, 20)
        Me.Button8.TabIndex = 39
        Me.Button8.Text = "Add Course"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'SectionTableAdapter1
        '
        Me.SectionTableAdapter1.ClearBeforeFill = True
        '
        'TeacherTableAdapter1
        '
        Me.TeacherTableAdapter1.ClearBeforeFill = True
        '
        'V_CourseStructureTableAdapter1
        '
        Me.V_CourseStructureTableAdapter1.ClearBeforeFill = True
        '
        'FRMcsfnew
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(856, 468)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.pfac)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nPA)
        Me.Controls.Add(Me.nTA)
        Me.Controls.Add(Me.nLA)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.dgvCourse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRMcsfnew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "csfupdate"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nPA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nTA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nLA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvCourse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VCourseStructureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ECollegeDataSet As TimeTableManager.eCollegeDataSet
    Friend WithEvents SectionTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter
    Friend WithEvents SubjectTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter
    Friend WithEvents TeacherTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.TeacherTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nPA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nTA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nLA As System.Windows.Forms.NumericUpDown
    Friend WithEvents pfac As System.Windows.Forms.TextBox
    Friend WithEvents Delete_Button As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents V_CourseStructureTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.V_CourseStructureTableAdapter
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ECollegeDataSet1 As TimeTableManager.eCollegeDataSet
    Friend WithEvents ECollegeDataSet2 As TimeTableManager.eCollegeDataSet
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents dgvCourse As DataGridView
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SubjectCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SubjectNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button8 As Button
    Friend WithEvents ECollegeDataSet3 As eCollegeDataSet
    Friend WithEvents SectionBindingSource As BindingSource
    Friend WithEvents SectionTableAdapter1 As eCollegeDataSetTableAdapters.SectionTableAdapter
    Friend WithEvents TeacherBindingSource As BindingSource
    Friend WithEvents TeacherTableAdapter1 As eCollegeDataSetTableAdapters.TeacherTableAdapter
    Friend WithEvents VCourseStructureBindingSource As BindingSource
    Friend WithEvents V_CourseStructureTableAdapter1 As eCollegeDataSetTableAdapters.V_CourseStructureTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents IsLabDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents SemesterDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
