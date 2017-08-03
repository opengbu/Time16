<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCSF
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pfac = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.SchoolBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ECollegeDataSet = New TimeTableManager.eCollegeDataSet()
        Me.chkF2 = New System.Windows.Forms.CheckBox()
        Me.cbFaculty2 = New System.Windows.Forms.ComboBox()
        Me.TeacherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TeacherBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbCSSubject1 = New System.Windows.Forms.ComboBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nPA = New System.Windows.Forms.NumericUpDown()
        Me.nTA = New System.Windows.Forms.NumericUpDown()
        Me.nLA = New System.Windows.Forms.NumericUpDown()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCSSubject = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvCSF = New System.Windows.Forms.DataGridView()
        Me.CSFIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsLabDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abr_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Teacher_Id_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TeacherNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CSFViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SubjectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SectionTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter()
        Me.SubjectTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter()
        Me.TeacherTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.TeacherTableAdapter()
        Me.CSF_ViewTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.CSF_ViewTableAdapter()
        Me.FillByToolStrip = New System.Windows.Forms.ToolStrip()
        Me.Param1ToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.Param1ToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.FillByToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.V_CourseStructureTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.V_CourseStructureTableAdapter()
        Me.FillByToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Param1ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Param1ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.FillByToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.SchoolTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SchoolTableAdapter()
        Me.ECollegeDataSet1 = New TimeTableManager.eCollegeDataSet()
        Me.CSFView1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CSF_View1TableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.CSF_View1TableAdapter()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SchoolBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeacherBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nPA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nTA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nLA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCSF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSFViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FillByToolStrip.SuspendLayout()
        Me.FillByToolStrip1.SuspendLayout()
        CType(Me.ECollegeDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSFView1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 448)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(987, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(987, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pfac)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkF2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbFaculty2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbCSSubject1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.nPA)
        Me.SplitContainer1.Panel1.Controls.Add(Me.nTA)
        Me.SplitContainer1.Panel1.Controls.Add(Me.nLA)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbCSSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvCSF)
        Me.SplitContainer1.Size = New System.Drawing.Size(987, 423)
        Me.SplitContainer1.SplitterDistance = 212
        Me.SplitContainer1.TabIndex = 2
        '
        'pfac
        '
        Me.pfac.Location = New System.Drawing.Point(16, 350)
        Me.pfac.Name = "pfac"
        Me.pfac.Size = New System.Drawing.Size(97, 20)
        Me.pfac.TabIndex = 24
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(119, 320)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(86, 23)
        Me.Button7.TabIndex = 23
        Me.Button7.Text = "Add Faculty"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DataSource = Me.SchoolBindingSource
        Me.ComboBox2.DisplayMember = "Name"
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(93, 5)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(115, 21)
        Me.ComboBox2.TabIndex = 22
        Me.ComboBox2.ValueMember = "Name"
        '
        'SchoolBindingSource
        '
        Me.SchoolBindingSource.DataMember = "School"
        Me.SchoolBindingSource.DataSource = Me.ECollegeDataSet
        '
        'ECollegeDataSet
        '
        Me.ECollegeDataSet.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkF2
        '
        Me.chkF2.AutoSize = True
        Me.chkF2.Location = New System.Drawing.Point(12, 253)
        Me.chkF2.Name = "chkF2"
        Me.chkF2.Size = New System.Drawing.Size(165, 17)
        Me.chkF2.TabIndex = 21
        Me.chkF2.Text = "Partial Selecte Faculty Delete"
        Me.chkF2.UseVisualStyleBackColor = True
        '
        'cbFaculty2
        '
        Me.cbFaculty2.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TeacherBindingSource, "id", True))
        Me.cbFaculty2.DataSource = Me.TeacherBindingSource1
        Me.cbFaculty2.DisplayMember = "name"
        Me.cbFaculty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFaculty2.FormattingEnabled = True
        Me.cbFaculty2.Location = New System.Drawing.Point(40, 233)
        Me.cbFaculty2.Name = "cbFaculty2"
        Me.cbFaculty2.Size = New System.Drawing.Size(169, 23)
        Me.cbFaculty2.TabIndex = 20
        Me.cbFaculty2.ValueMember = "id"
        Me.cbFaculty2.Visible = False
        '
        'TeacherBindingSource
        '
        Me.TeacherBindingSource.DataMember = "Teacher"
        Me.TeacherBindingSource.DataSource = Me.ECollegeDataSet
        '
        'TeacherBindingSource1
        '
        Me.TeacherBindingSource1.DataMember = "Teacher"
        Me.TeacherBindingSource1.DataSource = Me.ECollegeDataSet
        '
        'cbCSSubject1
        '
        Me.cbCSSubject1.DataSource = Me.BindingSource1
        Me.cbCSSubject1.DisplayMember = "Subject_Name"
        Me.cbCSSubject1.FormattingEnabled = True
        Me.cbCSSubject1.Location = New System.Drawing.Point(12, 144)
        Me.cbCSSubject1.Name = "cbCSSubject1"
        Me.cbCSSubject1.Size = New System.Drawing.Size(196, 21)
        Me.cbCSSubject1.TabIndex = 19
        '
        'BindingSource1
        '
        Me.BindingSource1.DataMember = "V_CourseStructure"
        Me.BindingSource1.DataSource = Me.ECollegeDataSet
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(16, 320)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(97, 23)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "Delete CSF::"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(88, 93)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(89, 23)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Remove Filter"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 371)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "L                  T                 P"
        '
        'nPA
        '
        Me.nPA.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "P", True))
        Me.nPA.Location = New System.Drawing.Point(134, 389)
        Me.nPA.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nPA.Name = "nPA"
        Me.nPA.Size = New System.Drawing.Size(36, 20)
        Me.nPA.TabIndex = 13
        '
        'nTA
        '
        Me.nTA.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "T", True))
        Me.nTA.Location = New System.Drawing.Point(76, 389)
        Me.nTA.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.nTA.Name = "nTA"
        Me.nTA.Size = New System.Drawing.Size(37, 20)
        Me.nTA.TabIndex = 12
        Me.nTA.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'nLA
        '
        Me.nLA.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "L", True))
        Me.nLA.Location = New System.Drawing.Point(16, 389)
        Me.nLA.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.nLA.Name = "nLA"
        Me.nLA.Size = New System.Drawing.Size(40, 20)
        Me.nLA.TabIndex = 11
        Me.nLA.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(183, 178)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 20)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(183, 94)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(22, 20)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "+"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "New Entry"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 294)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(112, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "0"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(130, 292)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Add CSF"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox3.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TeacherBindingSource, "id", True))
        Me.ComboBox3.DataSource = Me.TeacherBindingSource
        Me.ComboBox3.DisplayMember = "name"
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(12, 204)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(197, 23)
        Me.ComboBox3.TabIndex = 5
        Me.ComboBox3.ValueMember = "id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Faculty"
        '
        'cbCSSubject
        '
        Me.cbCSSubject.DataSource = Me.BindingSource1
        Me.cbCSSubject.DisplayMember = "Subject_Code"
        Me.cbCSSubject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCSSubject.FormattingEnabled = True
        Me.cbCSSubject.Location = New System.Drawing.Point(12, 118)
        Me.cbCSSubject.Name = "cbCSSubject"
        Me.cbCSSubject.Size = New System.Drawing.Size(197, 23)
        Me.cbCSSubject.TabIndex = 3
        Me.cbCSSubject.ValueMember = "id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Subject"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Section"
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.SectionBindingSource
        Me.ComboBox1.DisplayMember = "Name"
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.ItemHeight = 15
        Me.ComboBox1.Location = New System.Drawing.Point(12, 62)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(197, 23)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.ValueMember = "Id"
        '
        'SectionBindingSource
        '
        Me.SectionBindingSource.DataMember = "Section"
        Me.SectionBindingSource.DataSource = Me.ECollegeDataSet
        '
        'dgvCSF
        '
        Me.dgvCSF.AutoGenerateColumns = False
        Me.dgvCSF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvCSF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCSF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CSFIdDataGridViewTextBoxColumn, Me.SubjectCodeDataGridViewTextBoxColumn, Me.SubjectNameDataGridViewTextBoxColumn, Me.IsLabDataGridViewCheckBoxColumn, Me.LDataGridViewTextBoxColumn, Me.TDataGridViewTextBoxColumn, Me.PDataGridViewTextBoxColumn, Me.Abr_n, Me.Teacher_Id_n, Me.TeacherNameDataGridViewTextBoxColumn})
        Me.dgvCSF.DataSource = Me.CSFViewBindingSource
        Me.dgvCSF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCSF.Location = New System.Drawing.Point(0, 0)
        Me.dgvCSF.Name = "dgvCSF"
        Me.dgvCSF.Size = New System.Drawing.Size(771, 423)
        Me.dgvCSF.TabIndex = 0
        '
        'CSFIdDataGridViewTextBoxColumn
        '
        Me.CSFIdDataGridViewTextBoxColumn.DataPropertyName = "CSF_Id"
        Me.CSFIdDataGridViewTextBoxColumn.HeaderText = "CSF_Id"
        Me.CSFIdDataGridViewTextBoxColumn.Name = "CSFIdDataGridViewTextBoxColumn"
        Me.CSFIdDataGridViewTextBoxColumn.Width = 21
        '
        'SubjectCodeDataGridViewTextBoxColumn
        '
        Me.SubjectCodeDataGridViewTextBoxColumn.DataPropertyName = "Subject_Code"
        Me.SubjectCodeDataGridViewTextBoxColumn.HeaderText = "Subject_Code"
        Me.SubjectCodeDataGridViewTextBoxColumn.Name = "SubjectCodeDataGridViewTextBoxColumn"
        Me.SubjectCodeDataGridViewTextBoxColumn.Width = 21
        '
        'SubjectNameDataGridViewTextBoxColumn
        '
        Me.SubjectNameDataGridViewTextBoxColumn.DataPropertyName = "Subject_Name"
        Me.SubjectNameDataGridViewTextBoxColumn.HeaderText = "Subject_Name"
        Me.SubjectNameDataGridViewTextBoxColumn.Name = "SubjectNameDataGridViewTextBoxColumn"
        Me.SubjectNameDataGridViewTextBoxColumn.Width = 21
        '
        'IsLabDataGridViewCheckBoxColumn
        '
        Me.IsLabDataGridViewCheckBoxColumn.DataPropertyName = "IsLab"
        Me.IsLabDataGridViewCheckBoxColumn.HeaderText = "IsLab"
        Me.IsLabDataGridViewCheckBoxColumn.Name = "IsLabDataGridViewCheckBoxColumn"
        Me.IsLabDataGridViewCheckBoxColumn.Width = 21
        '
        'LDataGridViewTextBoxColumn
        '
        Me.LDataGridViewTextBoxColumn.DataPropertyName = "L"
        Me.LDataGridViewTextBoxColumn.HeaderText = "L"
        Me.LDataGridViewTextBoxColumn.Name = "LDataGridViewTextBoxColumn"
        Me.LDataGridViewTextBoxColumn.Width = 21
        '
        'TDataGridViewTextBoxColumn
        '
        Me.TDataGridViewTextBoxColumn.DataPropertyName = "T"
        Me.TDataGridViewTextBoxColumn.HeaderText = "T"
        Me.TDataGridViewTextBoxColumn.Name = "TDataGridViewTextBoxColumn"
        Me.TDataGridViewTextBoxColumn.Width = 21
        '
        'PDataGridViewTextBoxColumn
        '
        Me.PDataGridViewTextBoxColumn.DataPropertyName = "P"
        Me.PDataGridViewTextBoxColumn.HeaderText = "P"
        Me.PDataGridViewTextBoxColumn.Name = "PDataGridViewTextBoxColumn"
        Me.PDataGridViewTextBoxColumn.Width = 21
        '
        'Abr_n
        '
        Me.Abr_n.DataPropertyName = "Abr_n"
        Me.Abr_n.HeaderText = "ABR"
        Me.Abr_n.Name = "Abr_n"
        Me.Abr_n.ReadOnly = True
        Me.Abr_n.Width = 21
        '
        'Teacher_Id_n
        '
        Me.Teacher_Id_n.DataPropertyName = "Teacher_Id_n"
        Me.Teacher_Id_n.HeaderText = "Teacher_Id_n"
        Me.Teacher_Id_n.Name = "Teacher_Id_n"
        Me.Teacher_Id_n.ReadOnly = True
        Me.Teacher_Id_n.Width = 21
        '
        'TeacherNameDataGridViewTextBoxColumn
        '
        Me.TeacherNameDataGridViewTextBoxColumn.DataPropertyName = "Teacher_name_n"
        Me.TeacherNameDataGridViewTextBoxColumn.HeaderText = "Teacher_Name"
        Me.TeacherNameDataGridViewTextBoxColumn.Name = "TeacherNameDataGridViewTextBoxColumn"
        Me.TeacherNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.TeacherNameDataGridViewTextBoxColumn.Width = 21
        '
        'CSFViewBindingSource
        '
        Me.CSFViewBindingSource.DataMember = "CSF_View"
        Me.CSFViewBindingSource.DataSource = Me.ECollegeDataSet
        '
        'SubjectBindingSource
        '
        Me.SubjectBindingSource.DataMember = "Subject"
        Me.SubjectBindingSource.DataSource = Me.ECollegeDataSet
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
        'CSF_ViewTableAdapter
        '
        Me.CSF_ViewTableAdapter.ClearBeforeFill = True
        '
        'FillByToolStrip
        '
        Me.FillByToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FillByToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.FillByToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Param1ToolStripLabel, Me.Param1ToolStripTextBox, Me.FillByToolStripButton})
        Me.FillByToolStrip.Location = New System.Drawing.Point(0, 423)
        Me.FillByToolStrip.Name = "FillByToolStrip"
        Me.FillByToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.FillByToolStrip.Size = New System.Drawing.Size(987, 25)
        Me.FillByToolStrip.TabIndex = 3
        Me.FillByToolStrip.Text = "FillByToolStrip"
        Me.FillByToolStrip.Visible = False
        '
        'Param1ToolStripLabel
        '
        Me.Param1ToolStripLabel.Name = "Param1ToolStripLabel"
        Me.Param1ToolStripLabel.Size = New System.Drawing.Size(50, 22)
        Me.Param1ToolStripLabel.Text = "Param1:"
        '
        'Param1ToolStripTextBox
        '
        Me.Param1ToolStripTextBox.Name = "Param1ToolStripTextBox"
        Me.Param1ToolStripTextBox.Size = New System.Drawing.Size(100, 25)
        '
        'FillByToolStripButton
        '
        Me.FillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FillByToolStripButton.Name = "FillByToolStripButton"
        Me.FillByToolStripButton.Size = New System.Drawing.Size(39, 22)
        Me.FillByToolStripButton.Text = "FillBy"
        '
        'V_CourseStructureTableAdapter
        '
        Me.V_CourseStructureTableAdapter.ClearBeforeFill = True
        '
        'FillByToolStrip1
        '
        Me.FillByToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Param1ToolStripLabel1, Me.Param1ToolStripTextBox1, Me.FillByToolStripButton1})
        Me.FillByToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.FillByToolStrip1.Name = "FillByToolStrip1"
        Me.FillByToolStrip1.Size = New System.Drawing.Size(987, 25)
        Me.FillByToolStrip1.TabIndex = 4
        Me.FillByToolStrip1.Text = "FillByToolStrip1"
        Me.FillByToolStrip1.Visible = False
        '
        'Param1ToolStripLabel1
        '
        Me.Param1ToolStripLabel1.Name = "Param1ToolStripLabel1"
        Me.Param1ToolStripLabel1.Size = New System.Drawing.Size(50, 22)
        Me.Param1ToolStripLabel1.Text = "Param1:"
        '
        'Param1ToolStripTextBox1
        '
        Me.Param1ToolStripTextBox1.Name = "Param1ToolStripTextBox1"
        Me.Param1ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
        '
        'FillByToolStripButton1
        '
        Me.FillByToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FillByToolStripButton1.Name = "FillByToolStripButton1"
        Me.FillByToolStripButton1.Size = New System.Drawing.Size(39, 22)
        Me.FillByToolStripButton1.Text = "FillBy"
        '
        'SchoolTableAdapter
        '
        Me.SchoolTableAdapter.ClearBeforeFill = True
        '
        'ECollegeDataSet1
        '
        Me.ECollegeDataSet1.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CSFView1BindingSource
        '
        Me.CSFView1BindingSource.DataMember = "CSF_View1"
        Me.CSFView1BindingSource.DataSource = Me.ECollegeDataSet1
        '
        'CSF_View1TableAdapter
        '
        Me.CSF_View1TableAdapter.ClearBeforeFill = True
        '
        'frmCSF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 470)
        Me.Controls.Add(Me.FillByToolStrip)
        Me.Controls.Add(Me.FillByToolStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmCSF"
        Me.Text = "frmCSF"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SchoolBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeacherBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nPA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nTA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nLA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCSF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSFViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FillByToolStrip.ResumeLayout(False)
        Me.FillByToolStrip.PerformLayout()
        Me.FillByToolStrip1.ResumeLayout(False)
        Me.FillByToolStrip1.PerformLayout()
        CType(Me.ECollegeDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSFView1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCSSubject As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCSF As System.Windows.Forms.DataGridView
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectionIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FacultyIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsRemovedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SubjectIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TeacherIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ECollegeDataSet As TimeTableManager.eCollegeDataSet
    Friend WithEvents SectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SectionTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter
    Friend WithEvents SubjectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubjectTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter
    Friend WithEvents TeacherBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TeacherTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.TeacherTableAdapter
    Friend WithEvents CSFViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CSF_ViewTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.CSF_ViewTableAdapter
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents FillByToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents Param1ToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Param1ToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FillByToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nPA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nTA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nLA As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents V_CourseStructureTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.V_CourseStructureTableAdapter
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents cbCSSubject1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbFaculty2 As System.Windows.Forms.ComboBox
    Friend WithEvents TeacherBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents chkF2 As System.Windows.Forms.CheckBox
    Friend WithEvents FillByToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Param1ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Param1ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FillByToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents SchoolBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SchoolTableAdapter
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents CSFView1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ECollegeDataSet1 As TimeTableManager.eCollegeDataSet
    Friend WithEvents CSF_View1TableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.CSF_View1TableAdapter
    Friend WithEvents pfac As System.Windows.Forms.TextBox
    Friend WithEvents CSFIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubjectCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubjectNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsLabDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abr_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Teacher_Id_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TeacherNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
