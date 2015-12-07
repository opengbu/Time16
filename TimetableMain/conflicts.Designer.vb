<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class conflicts
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.VTimeTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.V_TimeTableTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.V_TimeTableTableAdapter()
        Me.ECollegeDataSet3 = New TimeTableManager.eCollegeDataSet()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgConflict = New System.Windows.Forms.DataGridView()
        Me.FacultySection = New System.Windows.Forms.DataGridView()
        CType(Me.VTimeTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgConflict, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacultySection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VTimeTableBindingSource
        '
        Me.VTimeTableBindingSource.DataMember = "V_TimeTable"
        '
        'V_TimeTableTableAdapter
        '
        Me.V_TimeTableTableAdapter.ClearBeforeFill = True
        '
        'ECollegeDataSet3
        '
        Me.ECollegeDataSet3.DataSetName = "eCollegeDataSet3"
        Me.ECollegeDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgConflict)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.FacultySection)
        Me.SplitContainer1.Size = New System.Drawing.Size(884, 562)
        Me.SplitContainer1.SplitterDistance = 407
        Me.SplitContainer1.TabIndex = 11
        '
        'dgConflict
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgConflict.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgConflict.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgConflict.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgConflict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgConflict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgConflict.Location = New System.Drawing.Point(0, 0)
        Me.dgConflict.Name = "dgConflict"
        Me.dgConflict.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgConflict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgConflict.Size = New System.Drawing.Size(407, 562)
        Me.dgConflict.TabIndex = 10
        '
        'FacultySection
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FacultySection.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.FacultySection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.FacultySection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FacultySection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FacultySection.Location = New System.Drawing.Point(0, 0)
        Me.FacultySection.Name = "FacultySection"
        Me.FacultySection.RowHeadersWidth = 10
        Me.FacultySection.Size = New System.Drawing.Size(473, 562)
        Me.FacultySection.TabIndex = 11
        '
        'conflicts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 562)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "conflicts"
        Me.Opacity = 0.95R
        Me.Text = "conflicts"
        Me.TopMost = True
        CType(Me.VTimeTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgConflict, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacultySection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents VTimeTable As TimeTableManager.VTimeTable
    Friend WithEvents VTimeTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents V_TimeTableTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.V_TimeTableTableAdapter
    'TimeTableManager.VTimeTableTableAdapters.V_TimeTableTableAdapter
    Friend WithEvents ECollegeDataSet3 As TimeTableManager.eCollegeDataSet
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgConflict As System.Windows.Forms.DataGridView
    Friend WithEvents FacultySection As System.Windows.Forms.DataGridView
End Class
