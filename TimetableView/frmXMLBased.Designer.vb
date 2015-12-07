<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXMLBased
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmXMLBased))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkShowHeader = New System.Windows.Forms.CheckBox()
        Me.chkShowFacultyName = New System.Windows.Forms.CheckBox()
        Me.chkShowRoom = New System.Windows.Forms.CheckBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.SectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimetableDataSet = New TimetableView.TimetableDataSet()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.MRoomBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TeacherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TeacherTableAdapter = New TimetableView.TimetableDataSetTableAdapters.TeacherTableAdapter()
        Me.M_RoomTableAdapter = New TimetableView.TimetableDataSetTableAdapters.M_RoomTableAdapter()
        Me.SectionTableAdapter = New TimetableView.TimetableDataSetTableAdapters.SectionTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimetableDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MRoomBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(964, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(964, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(31, 22)
        Me.ToolStripLabel1.Text = "Save"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(128, 22)
        Me.ToolStripButton1.Text = "Make Faculty Index"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripButton2.Text = "Export to .doc"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 442)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(964, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkShowHeader)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkShowFacultyName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkShowRoom)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Size = New System.Drawing.Size(964, 393)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 3
        '
        'chkShowHeader
        '
        Me.chkShowHeader.AutoSize = True
        Me.chkShowHeader.Checked = True
        Me.chkShowHeader.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowHeader.Location = New System.Drawing.Point(51, 245)
        Me.chkShowHeader.Name = "chkShowHeader"
        Me.chkShowHeader.Size = New System.Drawing.Size(91, 17)
        Me.chkShowHeader.TabIndex = 5
        Me.chkShowHeader.Text = "Show Header"
        Me.chkShowHeader.UseVisualStyleBackColor = True
        '
        'chkShowFacultyName
        '
        Me.chkShowFacultyName.AutoSize = True
        Me.chkShowFacultyName.Checked = True
        Me.chkShowFacultyName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowFacultyName.Location = New System.Drawing.Point(49, 213)
        Me.chkShowFacultyName.Name = "chkShowFacultyName"
        Me.chkShowFacultyName.Size = New System.Drawing.Size(163, 17)
        Me.chkShowFacultyName.TabIndex = 4
        Me.chkShowFacultyName.Text = "Show Faculty in Section T.T."
        Me.chkShowFacultyName.UseVisualStyleBackColor = True
        '
        'chkShowRoom
        '
        Me.chkShowRoom.AutoSize = True
        Me.chkShowRoom.Checked = True
        Me.chkShowRoom.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowRoom.Location = New System.Drawing.Point(49, 181)
        Me.chkShowRoom.Name = "chkShowRoom"
        Me.chkShowRoom.Size = New System.Drawing.Size(157, 17)
        Me.chkShowRoom.TabIndex = 3
        Me.chkShowRoom.Text = "Show Room in Section T.T."
        Me.chkShowRoom.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.DataSource = Me.SectionBindingSource
        Me.ComboBox3.DisplayMember = "Name"
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(29, 104)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(207, 28)
        Me.ComboBox3.TabIndex = 2
        Me.ComboBox3.ValueMember = "Id"
        '
        'SectionBindingSource
        '
        Me.SectionBindingSource.DataMember = "Section"
        Me.SectionBindingSource.DataSource = Me.TimetableDataSet
        '
        'TimetableDataSet
        '
        Me.TimetableDataSet.DataSetName = "TimetableDataSet"
        Me.TimetableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComboBox2
        '
        Me.ComboBox2.DataSource = Me.MRoomBindingSource
        Me.ComboBox2.DisplayMember = "Name"
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(29, 67)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(207, 28)
        Me.ComboBox2.TabIndex = 1
        Me.ComboBox2.ValueMember = "room_Id"
        '
        'MRoomBindingSource
        '
        Me.MRoomBindingSource.DataMember = "M_Room"
        Me.MRoomBindingSource.DataSource = Me.TimetableDataSet
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.TeacherBindingSource
        Me.ComboBox1.DisplayMember = "name"
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(29, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(207, 28)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.ValueMember = "id"
        '
        'TeacherBindingSource
        '
        Me.TeacherBindingSource.DataMember = "Teacher"
        Me.TeacherBindingSource.DataSource = Me.TimetableDataSet
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(700, 393)
        Me.WebBrowser1.TabIndex = 4
        '
        'TeacherTableAdapter
        '
        Me.TeacherTableAdapter.ClearBeforeFill = True
        '
        'M_RoomTableAdapter
        '
        Me.M_RoomTableAdapter.ClearBeforeFill = True
        '
        'SectionTableAdapter
        '
        Me.SectionTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(66, 309)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmXMLBased
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 464)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmXMLBased"
        Me.Text = "Form1"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.SectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimetableDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MRoomBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents TimetableDataSet As TimetableView.TimetableDataSet
    Friend WithEvents TeacherBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TeacherTableAdapter As TimetableView.TimetableDataSetTableAdapters.TeacherTableAdapter
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents MRoomBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents M_RoomTableAdapter As TimetableView.TimetableDataSetTableAdapters.M_RoomTableAdapter
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents SectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SectionTableAdapter As TimetableView.TimetableDataSetTableAdapters.SectionTableAdapter
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkShowFacultyName As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowRoom As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowHeader As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
