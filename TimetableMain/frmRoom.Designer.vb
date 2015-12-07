<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoom
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MRoomBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ECollegeDataSet = New TimeTableManager.eCollegeDataSet()
        Me.M_RoomTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.M_RoomTableAdapter()
        Me.SchoolBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SchoolTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SchoolTableAdapter()
        Me.RoomIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CapacityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsLabDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RoomTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuildingDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MRoomBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchoolBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(846, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel1.Text = "SAVE"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripLabel2.Text = "REFRESH"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 350)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(846, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoomIdDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.RowsDataGridViewTextBoxColumn, Me.ColsDataGridViewTextBoxColumn, Me.CapacityDataGridViewTextBoxColumn, Me.IsLabDataGridViewCheckBoxColumn, Me.RoomTypeDataGridViewTextBoxColumn, Me.BuildingDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.MRoomBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(846, 325)
        Me.DataGridView1.TabIndex = 2
        '
        'MRoomBindingSource
        '
        Me.MRoomBindingSource.DataMember = "M_Room"
        Me.MRoomBindingSource.DataSource = Me.ECollegeDataSet
        '
        'ECollegeDataSet
        '
        Me.ECollegeDataSet.DataSetName = "eCollegeDataSet"
        Me.ECollegeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'M_RoomTableAdapter
        '
        Me.M_RoomTableAdapter.ClearBeforeFill = True
        '
        'SchoolBindingSource
        '
        Me.SchoolBindingSource.DataMember = "School"
        Me.SchoolBindingSource.DataSource = Me.ECollegeDataSet
        '
        'SchoolTableAdapter
        '
        Me.SchoolTableAdapter.ClearBeforeFill = True
        '
        'RoomIdDataGridViewTextBoxColumn
        '
        Me.RoomIdDataGridViewTextBoxColumn.DataPropertyName = "room_Id"
        Me.RoomIdDataGridViewTextBoxColumn.HeaderText = "room_Id"
        Me.RoomIdDataGridViewTextBoxColumn.Name = "RoomIdDataGridViewTextBoxColumn"
        Me.RoomIdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        '
        'RowsDataGridViewTextBoxColumn
        '
        Me.RowsDataGridViewTextBoxColumn.DataPropertyName = "Rows"
        Me.RowsDataGridViewTextBoxColumn.HeaderText = "Rows"
        Me.RowsDataGridViewTextBoxColumn.Name = "RowsDataGridViewTextBoxColumn"
        '
        'ColsDataGridViewTextBoxColumn
        '
        Me.ColsDataGridViewTextBoxColumn.DataPropertyName = "Cols"
        Me.ColsDataGridViewTextBoxColumn.HeaderText = "Cols"
        Me.ColsDataGridViewTextBoxColumn.Name = "ColsDataGridViewTextBoxColumn"
        '
        'CapacityDataGridViewTextBoxColumn
        '
        Me.CapacityDataGridViewTextBoxColumn.DataPropertyName = "Capacity"
        Me.CapacityDataGridViewTextBoxColumn.HeaderText = "Capacity"
        Me.CapacityDataGridViewTextBoxColumn.Name = "CapacityDataGridViewTextBoxColumn"
        '
        'IsLabDataGridViewCheckBoxColumn
        '
        Me.IsLabDataGridViewCheckBoxColumn.DataPropertyName = "IsLab"
        Me.IsLabDataGridViewCheckBoxColumn.HeaderText = "IsLab"
        Me.IsLabDataGridViewCheckBoxColumn.Name = "IsLabDataGridViewCheckBoxColumn"
        '
        'RoomTypeDataGridViewTextBoxColumn
        '
        Me.RoomTypeDataGridViewTextBoxColumn.DataPropertyName = "RoomType"
        Me.RoomTypeDataGridViewTextBoxColumn.HeaderText = "RoomType"
        Me.RoomTypeDataGridViewTextBoxColumn.Name = "RoomTypeDataGridViewTextBoxColumn"
        '
        'BuildingDataGridViewTextBoxColumn
        '
        Me.BuildingDataGridViewTextBoxColumn.DataPropertyName = "Building"
        Me.BuildingDataGridViewTextBoxColumn.HeaderText = "Building"
        Me.BuildingDataGridViewTextBoxColumn.Name = "BuildingDataGridViewTextBoxColumn"
        Me.BuildingDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'frmRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 372)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmRoom"
        Me.Text = "Timetable :: Rooms"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MRoomBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchoolBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ECollegeDataSet As TimeTableManager.eCollegeDataSet
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents MRoomBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents M_RoomTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.M_RoomTableAdapter
    Friend WithEvents SchoolBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SchoolTableAdapter As TimeTableManager.eCollegeDataSetTableAdapters.SchoolTableAdapter
    Friend WithEvents RoomIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RowsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CapacityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsLabDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RoomTypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildingDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
