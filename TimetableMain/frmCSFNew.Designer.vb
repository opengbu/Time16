<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMcsfnew
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Delete_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.VCourseStructureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ECollegeDataSet = New TimeTableManager.eCollegeDataSet()
        Me.SectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.SubjectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.TeacherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SectionTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter()
        Me.SubjectTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter()
        Me.TeacherTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.TeacherTableAdapter()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nPA = New System.Windows.Forms.NumericUpDown()
        Me.nTA = New System.Windows.Forms.NumericUpDown()
        Me.nLA = New System.Windows.Forms.NumericUpDown()
        Me.pfac = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.V_CourseStructureTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.V_CourseStructureTableAdapter()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox3 = New System.Windows.Forms.ListBox()
        Me.ECollegeDataSet2 = New TimeTableManager.eCollegeDataSet()
        Me.ECollegeDataSet1 = New TimeTableManager.eCollegeDataSet()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.VCourseStructureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nPA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nTA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nLA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.63547!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.36453!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Delete_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(371, 427)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(287, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(139, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Partial Delete"
        Me.Button2.Visible = False
        '
        'Delete_Button
        '
        Me.Delete_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Delete_Button.Location = New System.Drawing.Point(81, 3)
        Me.Delete_Button.Name = "Delete_Button"
        Me.Delete_Button.Size = New System.Drawing.Size(52, 23)
        Me.Delete_Button.TabIndex = 2
        Me.Delete_Button.Text = "Delete"
        Me.Delete_Button.Visible = False
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(72, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Add/Update"
        Me.OK_Button.Visible = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(232, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(48, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(201, 17)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "New Class Subject Faculty Allocation"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.VCourseStructureBindingSource, "Section_Id", True))
        Me.ComboBox1.DataSource = Me.SectionBindingSource
        Me.ComboBox1.DisplayMember = "Name"
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(72, 26)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 24)
        Me.ComboBox1.TabIndex = 2
        Me.ComboBox1.ValueMember = "Id"
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
        'SectionBindingSource
        '
        Me.SectionBindingSource.DataMember = "Section"
        Me.SectionBindingSource.DataSource = Me.ECollegeDataSet
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Subject"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(373, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Select Faculty Member"
        '
        'ComboBox2
        '
        Me.ComboBox2.DataSource = Me.VCourseStructureBindingSource
        Me.ComboBox2.DisplayMember = "Subject_Code"
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(371, 21)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(281, 24)
        Me.ComboBox2.TabIndex = 6
        Me.ComboBox2.ValueMember = "id"
        '
        'SubjectBindingSource
        '
        Me.SubjectBindingSource.DataMember = "Subject"
        Me.SubjectBindingSource.DataSource = Me.ECollegeDataSet
        '
        'ComboBox3
        '
        Me.ComboBox3.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TeacherBindingSource, "id", True))
        Me.ComboBox3.DataSource = Me.TeacherBindingSource
        Me.ComboBox3.DisplayMember = "name"
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(374, 88)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(232, 24)
        Me.ComboBox3.TabIndex = 7
        Me.ComboBox3.ValueMember = "Id"
        '
        'TeacherBindingSource
        '
        Me.TeacherBindingSource.DataMember = "Teacher"
        Me.TeacherBindingSource.DataSource = Me.ECollegeDataSet
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(309, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(58, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Text = "0"
        '
        'SectionTableAdapter
        '
        Me.SectionTableAdapter.ClearBeforeFill = True
        '
        'SubjectTableAdapter
        '
        Me.SubjectTableAdapter.ClearBeforeFill = True
        '
        'TeacherTableAdapter
        '
        Me.TeacherTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(353, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "L  :  T  :  P"
        Me.Label4.Visible = False
        '
        'nPA
        '
        Me.nPA.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.SubjectBindingSource, "P", True))
        Me.nPA.Location = New System.Drawing.Point(618, 51)
        Me.nPA.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nPA.Name = "nPA"
        Me.nPA.Size = New System.Drawing.Size(34, 20)
        Me.nPA.TabIndex = 17
        Me.nPA.Visible = False
        '
        'nTA
        '
        Me.nTA.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.SubjectBindingSource, "T", True))
        Me.nTA.Location = New System.Drawing.Point(560, 51)
        Me.nTA.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nTA.Name = "nTA"
        Me.nTA.Size = New System.Drawing.Size(35, 20)
        Me.nTA.TabIndex = 16
        Me.nTA.Value = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nTA.Visible = False
        '
        'nLA
        '
        Me.nLA.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.SubjectBindingSource, "L", True))
        Me.nLA.Location = New System.Drawing.Point(514, 51)
        Me.nLA.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.nLA.Name = "nLA"
        Me.nLA.Size = New System.Drawing.Size(38, 20)
        Me.nLA.TabIndex = 15
        Me.nLA.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nLA.Visible = False
        '
        'pfac
        '
        Me.pfac.Location = New System.Drawing.Point(453, 26)
        Me.pfac.Name = "pfac"
        Me.pfac.Size = New System.Drawing.Size(197, 20)
        Me.pfac.TabIndex = 25
        Me.pfac.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(22, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(314, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Edit Course Structure"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(609, 89)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(41, 23)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "Add New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(262, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "CSF ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(393, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Faculty ID"
        Me.Label6.Visible = False
        '
        'V_CourseStructureTableAdapter
        '
        Me.V_CourseStructureTableAdapter.ClearBeforeFill = True
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.DataSource = Me.VCourseStructureBindingSource
        Me.ListBox1.DisplayMember = "Subject_Code"
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(22, 117)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(78, 290)
        Me.ListBox1.TabIndex = 30
        Me.ListBox1.ValueMember = "id"
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.DataSource = Me.VCourseStructureBindingSource
        Me.ListBox2.DisplayMember = "Subject_Name"
        Me.ListBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Location = New System.Drawing.Point(99, 117)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(237, 290)
        Me.ListBox2.TabIndex = 31
        Me.ListBox2.ValueMember = "id"
        '
        'ListBox3
        '
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(374, 273)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(276, 134)
        Me.ListBox3.TabIndex = 32
        '
        'ECollegeDataSet2
        '
        Me.ECollegeDataSet2.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ECollegeDataSet1
        '
        Me.ECollegeDataSet1.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(374, 157)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(276, 23)
        Me.Button4.TabIndex = 33
        Me.Button4.Text = "Assign Faculty to subject"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(374, 187)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(276, 23)
        Me.Button5.TabIndex = 34
        Me.Button5.Text = "Add faculty- Combind with selected faculty."
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(376, 217)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(276, 23)
        Me.Button6.TabIndex = 35
        Me.Button6.Text = "Delete Faculty Assignment"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Location = New System.Drawing.Point(145, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(359, 273)
        Me.GroupBox1.TabIndex = 36
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
        'FRMcsfnew
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(670, 468)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ListBox3)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pfac)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nPA)
        Me.Controls.Add(Me.nTA)
        Me.Controls.Add(Me.nLA)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRMcsfnew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "csfupdate"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.VCourseStructureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nPA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nTA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nLA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ECollegeDataSet As TimeTableManager.eCollegeDataSet
    Friend WithEvents SectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SectionTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter
    Friend WithEvents SubjectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubjectTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter
    Friend WithEvents TeacherBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TeacherTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.TeacherTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nPA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nTA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nLA As System.Windows.Forms.NumericUpDown
    Friend WithEvents pfac As System.Windows.Forms.TextBox
    Friend WithEvents Delete_Button As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents VCourseStructureBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_CourseStructureTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.V_CourseStructureTableAdapter
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ECollegeDataSet1 As TimeTableManager.eCollegeDataSet
    Friend WithEvents ECollegeDataSet2 As TimeTableManager.eCollegeDataSet
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button

End Class
