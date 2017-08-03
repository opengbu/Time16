<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacultyLoad
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbSchools = New System.Windows.Forms.ComboBox()
        Me.SchoolBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ECollegeDataSet = New TimeTableManager.eCollegeDataSet()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CSFTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.CSFTableTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.CSFTableTableAdapter()
        Me.SchoolBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SchoolTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SchoolTableAdapter()
        Me.FillByToolStrip = New System.Windows.Forms.ToolStrip()
        Me.Param1ToolStripLabel = New System.Windows.Forms.ToolStripLabel()
        Me.Param1ToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.FillByToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CSFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FacultyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubjectNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SectionNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SchoolBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CSFTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FillByToolStrip.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSchools)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(875, 467)
        Me.SplitContainer1.SplitterDistance = 99
        Me.SplitContainer1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(611, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "School Filter"
        '
        'cbSchools
        '
        Me.cbSchools.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SchoolBindingSource1, "Name", True))
        Me.cbSchools.DataSource = Me.SchoolBindingSource1
        Me.cbSchools.DisplayMember = "Name"
        Me.cbSchools.FormattingEnabled = True
        Me.cbSchools.Location = New System.Drawing.Point(697, 69)
        Me.cbSchools.Name = "cbSchools"
        Me.cbSchools.Size = New System.Drawing.Size(121, 21)
        Me.cbSchools.TabIndex = 0
        Me.cbSchools.ValueMember = "Name"
        '
        'SchoolBindingSource1
        '
        Me.SchoolBindingSource1.DataMember = "School"
        Me.SchoolBindingSource1.DataSource = Me.ECollegeDataSet
        '
        'ECollegeDataSet
        '
        Me.ECollegeDataSet.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CSFDataGridViewTextBoxColumn, Me.FacultyDataGridViewTextBoxColumn, Me.SubjectCodeDataGridViewTextBoxColumn, Me.SubjectNameDataGridViewTextBoxColumn, Me.SectionNameDataGridViewTextBoxColumn, Me.LDataGridViewTextBoxColumn, Me.TDataGridViewTextBoxColumn, Me.PDataGridViewTextBoxColumn, Me.LADataGridViewTextBoxColumn, Me.TADataGridViewTextBoxColumn, Me.PADataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.CSFTableBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(875, 364)
        Me.DataGridView1.TabIndex = 0
        '
        'CSFTableBindingSource
        '
        Me.CSFTableBindingSource.DataMember = "CSFTable"
        Me.CSFTableBindingSource.DataSource = Me.BindingSource1
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = Me.ECollegeDataSet
        Me.BindingSource1.Position = 0
        '
        'CSFTableTableAdapter
        '
        Me.CSFTableTableAdapter.ClearBeforeFill = True
        '
        'SchoolBindingSource
        '
        Me.SchoolBindingSource.DataMember = "School"
        Me.SchoolBindingSource.DataSource = Me.BindingSource1
        '
        'SchoolTableAdapter
        '
        Me.SchoolTableAdapter.ClearBeforeFill = True
        '
        'FillByToolStrip
        '
        Me.FillByToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Param1ToolStripLabel, Me.Param1ToolStripTextBox, Me.FillByToolStripButton})
        Me.FillByToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.FillByToolStrip.Name = "FillByToolStrip"
        Me.FillByToolStrip.Size = New System.Drawing.Size(875, 25)
        Me.FillByToolStrip.TabIndex = 1
        Me.FillByToolStrip.Text = "FillByToolStrip"
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
        'CSFDataGridViewTextBoxColumn
        '
        Me.CSFDataGridViewTextBoxColumn.DataPropertyName = "CSF"
        Me.CSFDataGridViewTextBoxColumn.HeaderText = "CSF"
        Me.CSFDataGridViewTextBoxColumn.Name = "CSFDataGridViewTextBoxColumn"
        Me.CSFDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FacultyDataGridViewTextBoxColumn
        '
        Me.FacultyDataGridViewTextBoxColumn.DataPropertyName = "Faculty"
        Me.FacultyDataGridViewTextBoxColumn.HeaderText = "Faculty"
        Me.FacultyDataGridViewTextBoxColumn.Name = "FacultyDataGridViewTextBoxColumn"
        '
        'SubjectCodeDataGridViewTextBoxColumn
        '
        Me.SubjectCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SubjectCodeDataGridViewTextBoxColumn.DataPropertyName = "Subject_Code"
        Me.SubjectCodeDataGridViewTextBoxColumn.HeaderText = "Subject_Code"
        Me.SubjectCodeDataGridViewTextBoxColumn.Name = "SubjectCodeDataGridViewTextBoxColumn"
        Me.SubjectCodeDataGridViewTextBoxColumn.Width = 99
        '
        'SubjectNameDataGridViewTextBoxColumn
        '
        Me.SubjectNameDataGridViewTextBoxColumn.DataPropertyName = "Subject_Name"
        Me.SubjectNameDataGridViewTextBoxColumn.HeaderText = "Subject_Name"
        Me.SubjectNameDataGridViewTextBoxColumn.Name = "SubjectNameDataGridViewTextBoxColumn"
        '
        'SectionNameDataGridViewTextBoxColumn
        '
        Me.SectionNameDataGridViewTextBoxColumn.DataPropertyName = "SectionName"
        Me.SectionNameDataGridViewTextBoxColumn.HeaderText = "SectionName"
        Me.SectionNameDataGridViewTextBoxColumn.Name = "SectionNameDataGridViewTextBoxColumn"
        '
        'LDataGridViewTextBoxColumn
        '
        Me.LDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LDataGridViewTextBoxColumn.DataPropertyName = "L"
        Me.LDataGridViewTextBoxColumn.HeaderText = "L"
        Me.LDataGridViewTextBoxColumn.Name = "LDataGridViewTextBoxColumn"
        Me.LDataGridViewTextBoxColumn.Width = 38
        '
        'TDataGridViewTextBoxColumn
        '
        Me.TDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TDataGridViewTextBoxColumn.DataPropertyName = "T"
        Me.TDataGridViewTextBoxColumn.HeaderText = "T"
        Me.TDataGridViewTextBoxColumn.Name = "TDataGridViewTextBoxColumn"
        Me.TDataGridViewTextBoxColumn.Width = 39
        '
        'PDataGridViewTextBoxColumn
        '
        Me.PDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PDataGridViewTextBoxColumn.DataPropertyName = "P"
        Me.PDataGridViewTextBoxColumn.HeaderText = "P"
        Me.PDataGridViewTextBoxColumn.Name = "PDataGridViewTextBoxColumn"
        Me.PDataGridViewTextBoxColumn.Width = 39
        '
        'LADataGridViewTextBoxColumn
        '
        Me.LADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LADataGridViewTextBoxColumn.DataPropertyName = "LA"
        Me.LADataGridViewTextBoxColumn.HeaderText = "LA"
        Me.LADataGridViewTextBoxColumn.Name = "LADataGridViewTextBoxColumn"
        Me.LADataGridViewTextBoxColumn.Width = 45
        '
        'TADataGridViewTextBoxColumn
        '
        Me.TADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TADataGridViewTextBoxColumn.DataPropertyName = "TA"
        Me.TADataGridViewTextBoxColumn.HeaderText = "TA"
        Me.TADataGridViewTextBoxColumn.Name = "TADataGridViewTextBoxColumn"
        Me.TADataGridViewTextBoxColumn.Width = 46
        '
        'PADataGridViewTextBoxColumn
        '
        Me.PADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PADataGridViewTextBoxColumn.DataPropertyName = "PA"
        Me.PADataGridViewTextBoxColumn.HeaderText = "PA"
        Me.PADataGridViewTextBoxColumn.Name = "PADataGridViewTextBoxColumn"
        Me.PADataGridViewTextBoxColumn.Width = 46
        '
        'frmFacultyLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 467)
        Me.Controls.Add(Me.FillByToolStrip)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmFacultyLoad"
        Me.Text = "Faculty Load"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SchoolBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CSFTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FillByToolStrip.ResumeLayout(False)
        Me.FillByToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents ECollegeDataSet As eCollegeDataSet
    Friend WithEvents CSFTableBindingSource As BindingSource
    Friend WithEvents CSFTableTableAdapter As eCollegeDataSetTableAdapters.CSFTableTableAdapter
    Friend WithEvents Label1 As Label
    Friend WithEvents cbSchools As ComboBox
    Friend WithEvents SchoolBindingSource As BindingSource
    Friend WithEvents SchoolTableAdapter As eCollegeDataSetTableAdapters.SchoolTableAdapter
    Friend WithEvents SchoolBindingSource1 As BindingSource
    Friend WithEvents FillByToolStrip As ToolStrip
    Friend WithEvents Param1ToolStripLabel As ToolStripLabel
    Friend WithEvents Param1ToolStripTextBox As ToolStripTextBox
    Friend WithEvents FillByToolStripButton As ToolStripButton
    Friend WithEvents CSFDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FacultyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SubjectCodeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SubjectNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SectionNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
