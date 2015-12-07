<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSection
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
        Me.ECollegeDataSet = New TimeTableManager.eCollegeDataSet()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SectionTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAddSection = New System.Windows.Forms.Button()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.cbProgram = New System.Windows.Forms.ComboBox()
        Me.ProgramBS = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgramSectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgramBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SectionDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SemesterDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateofCreationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastEditDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreationDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Program = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShowTimeTableDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProgramTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.ProgramTableAdapter()
        Me.userinfo = New System.Windows.Forms.Label()
        Me.TableAdapterManager = New TimeTableManager.eCollegeDataSetTableAdapters.TableAdapterManager()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ProgramBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgramSectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgramBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SectionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ECollegeDataSet
        '
        Me.ECollegeDataSet.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(752, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.TimeTableManager.My.Resources.Resources.Save_6530
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripButton1.Text = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = Global.TimeTableManager.My.Resources.Resources.Open_6296
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripLabel2.Text = "REFRESH"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 366)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(752, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SectionBindingSource
        '
        Me.SectionBindingSource.DataMember = "Section"
        Me.SectionBindingSource.DataSource = Me.ECollegeDataSet
        '
        'SectionTableAdapter
        '
        Me.SectionTableAdapter.ClearBeforeFill = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAddSection)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSection)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbProgram)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.SectionDataGridView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(752, 341)
        Me.SplitContainer1.SplitterDistance = 98
        Me.SplitContainer1.TabIndex = 2
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(529, 23)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(146, 52)
        Me.btnEdit.TabIndex = 22
        Me.btnEdit.Text = "Enable Edit Mode"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAddSection
        '
        Me.btnAddSection.Location = New System.Drawing.Point(339, 52)
        Me.btnAddSection.Name = "btnAddSection"
        Me.btnAddSection.Size = New System.Drawing.Size(75, 23)
        Me.btnAddSection.TabIndex = 21
        Me.btnAddSection.Text = "Add Section"
        Me.btnAddSection.UseVisualStyleBackColor = True
        '
        'txtSection
        '
        Me.txtSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSection.Location = New System.Drawing.Point(180, 55)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(133, 20)
        Me.txtSection.TabIndex = 20
        '
        'cbProgram
        '
        Me.cbProgram.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ProgramBS, "Program", True))
        Me.cbProgram.DataSource = Me.ProgramBindingSource
        Me.cbProgram.DisplayMember = "Name"
        Me.cbProgram.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProgram.FormattingEnabled = True
        Me.cbProgram.ItemHeight = 16
        Me.cbProgram.Location = New System.Drawing.Point(35, 16)
        Me.cbProgram.MaxDropDownItems = 10
        Me.cbProgram.Name = "cbProgram"
        Me.cbProgram.Size = New System.Drawing.Size(278, 24)
        Me.cbProgram.TabIndex = 19
        Me.cbProgram.ValueMember = "Id"
        '
        'ProgramBS
        '
        Me.ProgramBS.DataSource = Me.ProgramSectionBindingSource
        '
        'ProgramSectionBindingSource
        '
        Me.ProgramSectionBindingSource.DataMember = "Program_Section"
        Me.ProgramSectionBindingSource.DataSource = Me.ProgramBindingSource
        '
        'ProgramBindingSource
        '
        Me.ProgramBindingSource.DataMember = "Program"
        Me.ProgramBindingSource.DataSource = Me.ECollegeDataSet
        '
        'SectionDataGridView
        '
        Me.SectionDataGridView.AutoGenerateColumns = False
        Me.SectionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SectionDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.SectionDataGridView.DataSource = Me.ProgramBS
        Me.SectionDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.SectionDataGridView.Name = "SectionDataGridView"
        Me.SectionDataGridView.Size = New System.Drawing.Size(752, 239)
        Me.SectionDataGridView.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Semester"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Semester"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Date_of_Creation"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Date_of_Creation"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "LastEditDate"
        Me.DataGridViewTextBoxColumn5.HeaderText = "LastEditDate"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CreationDate"
        Me.DataGridViewTextBoxColumn6.HeaderText = "CreationDate"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ShowTimeTable"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Enable"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ToolTipText = "Set 0 or 1"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Program"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Program"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "school"
        Me.DataGridViewTextBoxColumn9.HeaderText = "school"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.SemesterDataGridViewTextBoxColumn, Me.DateofCreationDataGridViewTextBoxColumn, Me.LastEditDateDataGridViewTextBoxColumn, Me.CreationDateDataGridViewTextBoxColumn, Me.Program, Me.ShowTimeTableDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.SectionBindingSource
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(259, 227)
        Me.DataGridView1.TabIndex = 3
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        '
        'SemesterDataGridViewTextBoxColumn
        '
        Me.SemesterDataGridViewTextBoxColumn.DataPropertyName = "Semester"
        Me.SemesterDataGridViewTextBoxColumn.HeaderText = "Semester"
        Me.SemesterDataGridViewTextBoxColumn.Name = "SemesterDataGridViewTextBoxColumn"
        '
        'DateofCreationDataGridViewTextBoxColumn
        '
        Me.DateofCreationDataGridViewTextBoxColumn.DataPropertyName = "Date_of_Creation"
        Me.DateofCreationDataGridViewTextBoxColumn.HeaderText = "Date_of_Creation"
        Me.DateofCreationDataGridViewTextBoxColumn.Name = "DateofCreationDataGridViewTextBoxColumn"
        Me.DateofCreationDataGridViewTextBoxColumn.Visible = False
        '
        'LastEditDateDataGridViewTextBoxColumn
        '
        Me.LastEditDateDataGridViewTextBoxColumn.DataPropertyName = "LastEditDate"
        Me.LastEditDateDataGridViewTextBoxColumn.HeaderText = "LastEditDate"
        Me.LastEditDateDataGridViewTextBoxColumn.Name = "LastEditDateDataGridViewTextBoxColumn"
        Me.LastEditDateDataGridViewTextBoxColumn.Visible = False
        '
        'CreationDateDataGridViewTextBoxColumn
        '
        Me.CreationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate"
        Me.CreationDateDataGridViewTextBoxColumn.HeaderText = "CreationDate"
        Me.CreationDateDataGridViewTextBoxColumn.Name = "CreationDateDataGridViewTextBoxColumn"
        Me.CreationDateDataGridViewTextBoxColumn.Visible = False
        '
        'Program
        '
        Me.Program.DataPropertyName = "Program"
        Me.Program.HeaderText = "Program"
        Me.Program.Name = "Program"
        Me.Program.Visible = False
        '
        'ShowTimeTableDataGridViewTextBoxColumn
        '
        Me.ShowTimeTableDataGridViewTextBoxColumn.DataPropertyName = "ShowTimeTable"
        Me.ShowTimeTableDataGridViewTextBoxColumn.HeaderText = "Enable"
        Me.ShowTimeTableDataGridViewTextBoxColumn.Name = "ShowTimeTableDataGridViewTextBoxColumn"
        Me.ShowTimeTableDataGridViewTextBoxColumn.ToolTipText = "Set 0 to disable"
        '
        'ProgramTableAdapter
        '
        Me.ProgramTableAdapter.ClearBeforeFill = True
        '
        'userinfo
        '
        Me.userinfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.userinfo.AutoSize = True
        Me.userinfo.Location = New System.Drawing.Point(701, 369)
        Me.userinfo.Name = "userinfo"
        Me.userinfo.Size = New System.Drawing.Size(39, 13)
        Me.userinfo.TabIndex = 3
        Me.userinfo.Text = "Label1"
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CourseStructureTableAdapter = Nothing
        Me.TableAdapterManager.L_Section_Subject_FacultyTableAdapter = Nothing
        Me.TableAdapterManager.M_RoomTableAdapter = Nothing
        Me.TableAdapterManager.M_SubjectTableAdapter = Nothing
        Me.TableAdapterManager.ProgramTableAdapter = Me.ProgramTableAdapter
        Me.TableAdapterManager.SchoolTableAdapter = Nothing
        Me.TableAdapterManager.SectionTableAdapter = Me.SectionTableAdapter
        Me.TableAdapterManager.SubjectTableAdapter = Nothing
        Me.TableAdapterManager.TeacherTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TimeTableManager.eCollegeDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.V_FacultyTableAdapter = Nothing
        '
        'frmSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 388)
        Me.Controls.Add(Me.userinfo)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmSection"
        Me.Text = "Timetable :: Sections"
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ProgramBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgramSectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgramBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SectionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ECollegeDataSet As TimeTableManager.eCollegeDataSet
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SectionTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SectionTableAdapter
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddSection As System.Windows.Forms.Button
    Friend WithEvents txtSection As System.Windows.Forms.TextBox
    Friend WithEvents cbProgram As System.Windows.Forms.ComboBox
    Friend WithEvents ProgramBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProgramTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.ProgramTableAdapter
    Friend WithEvents userinfo As System.Windows.Forms.Label
    Friend WithEvents ProgramBS As System.Windows.Forms.BindingSource
    Friend WithEvents ProgramSectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SectionDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TableAdapterManager As TimeTableManager.eCollegeDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SemesterDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateofCreationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastEditDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreationDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Program As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShowTimeTableDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
