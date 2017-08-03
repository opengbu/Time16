<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveLocalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadOnlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UploadAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacultyTimetabelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassSectionTimetablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkSign = New System.Windows.Forms.CheckBox()
        Me.txtMaxP = New System.Windows.Forms.TextBox()
        Me.SectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimetableDataSet = New TimetableView.TimetableDataSet()
        Me.chkLTP = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkMerge = New System.Windows.Forms.CheckBox()
        Me.chkShowHeader = New System.Windows.Forms.CheckBox()
        Me.chkShowFacultyName = New System.Windows.Forms.CheckBox()
        Me.chkShowRoom = New System.Windows.Forms.CheckBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.MRoomBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TeacherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TeacherTableAdapter = New TimetableView.TimetableDataSetTableAdapters.TeacherTableAdapter()
        Me.M_RoomTableAdapter = New TimetableView.TimetableDataSetTableAdapters.M_RoomTableAdapter()
        Me.SectionTableAdapter = New TimetableView.TimetableDataSetTableAdapters.SectionTableAdapter()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(964, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.SaveLocalToolStripMenuItem, Me.UploadOnlineToolStripMenuItem, Me.ToolStripSeparator2, Me.UploadAllToolStripMenuItem, Me.ExportToExcelToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(147, 6)
        '
        'SaveLocalToolStripMenuItem
        '
        Me.SaveLocalToolStripMenuItem.Name = "SaveLocalToolStripMenuItem"
        Me.SaveLocalToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SaveLocalToolStripMenuItem.Text = "Save Local ..."
        '
        'UploadOnlineToolStripMenuItem
        '
        Me.UploadOnlineToolStripMenuItem.Name = "UploadOnlineToolStripMenuItem"
        Me.UploadOnlineToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UploadOnlineToolStripMenuItem.Text = "Upload Online"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(147, 6)
        '
        'UploadAllToolStripMenuItem
        '
        Me.UploadAllToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacultyTimetabelsToolStripMenuItem, Me.ClassSectionTimetablesToolStripMenuItem})
        Me.UploadAllToolStripMenuItem.Name = "UploadAllToolStripMenuItem"
        Me.UploadAllToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UploadAllToolStripMenuItem.Text = "Upload all "
        '
        'FacultyTimetabelsToolStripMenuItem
        '
        Me.FacultyTimetabelsToolStripMenuItem.Name = "FacultyTimetabelsToolStripMenuItem"
        Me.FacultyTimetabelsToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.FacultyTimetabelsToolStripMenuItem.Text = "Faculty Timetabels"
        '
        'ClassSectionTimetablesToolStripMenuItem
        '
        Me.ClassSectionTimetablesToolStripMenuItem.Name = "ClassSectionTimetablesToolStripMenuItem"
        Me.ClassSectionTimetablesToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ClassSectionTimetablesToolStripMenuItem.Text = "Class/Section Timetables"
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export to Excel"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripButton4, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(964, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripLabel2.Text = "Faculty Load "
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripButton4.Text = "Upload Current"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripLabel1.Text = "Print"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 491)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkSign)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMaxP)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkLTP)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkMerge)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(964, 442)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 3
        '
        'chkSign
        '
        Me.chkSign.AutoSize = True
        Me.chkSign.Enabled = False
        Me.chkSign.Location = New System.Drawing.Point(51, 291)
        Me.chkSign.Name = "chkSign"
        Me.chkSign.Size = New System.Drawing.Size(71, 17)
        Me.chkSign.TabIndex = 10
        Me.chkSign.Text = "Signature"
        Me.chkSign.UseVisualStyleBackColor = True
        '
        'txtMaxP
        '
        Me.txtMaxP.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SectionBindingSource, "MaxPeriod", True))
        Me.txtMaxP.Location = New System.Drawing.Point(199, 4)
        Me.txtMaxP.Name = "txtMaxP"
        Me.txtMaxP.ReadOnly = True
        Me.txtMaxP.Size = New System.Drawing.Size(37, 20)
        Me.txtMaxP.TabIndex = 9
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
        'chkLTP
        '
        Me.chkLTP.AutoSize = True
        Me.chkLTP.Location = New System.Drawing.Point(49, 158)
        Me.chkLTP.Name = "chkLTP"
        Me.chkLTP.Size = New System.Drawing.Size(159, 17)
        Me.chkLTP.TabIndex = 8
        Me.chkLTP.Text = "Show LTP (Hours Required)"
        Me.chkLTP.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(30, 327)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(206, 76)
        Me.TextBox1.TabIndex = 7
        '
        'chkMerge
        '
        Me.chkMerge.AutoSize = True
        Me.chkMerge.Checked = True
        Me.chkMerge.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMerge.Enabled = False
        Me.chkMerge.Location = New System.Drawing.Point(51, 268)
        Me.chkMerge.Name = "chkMerge"
        Me.chkMerge.Size = New System.Drawing.Size(108, 17)
        Me.chkMerge.TabIndex = 6
        Me.chkMerge.Text = "Merge Labs Slots"
        Me.chkMerge.UseVisualStyleBackColor = True
        '
        'chkShowHeader
        '
        Me.chkShowHeader.AutoSize = True
        Me.chkShowHeader.Enabled = False
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
        Me.chkShowFacultyName.Enabled = False
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
        Me.chkShowRoom.Enabled = False
        Me.chkShowRoom.Location = New System.Drawing.Point(49, 181)
        Me.chkShowRoom.Name = "chkShowRoom"
        Me.chkShowRoom.Size = New System.Drawing.Size(157, 17)
        Me.chkShowRoom.TabIndex = 3
        Me.chkShowRoom.Text = "Show Room in Section T.T."
        Me.chkShowRoom.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox3.DataSource = Me.SectionBindingSource
        Me.ComboBox3.DisplayMember = "Name"
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(29, 104)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(207, 28)
        Me.ComboBox3.TabIndex = 2
        Me.ComboBox3.ValueMember = "Id"
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
        Me.WebBrowser1.Size = New System.Drawing.Size(700, 442)
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
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(721, 491)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(231, 23)
        Me.ProgressBar1.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 513)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
    Friend WithEvents chkShowFacultyName As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowRoom As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowHeader As System.Windows.Forms.CheckBox
    Friend WithEvents chkMerge As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chkLTP As System.Windows.Forms.CheckBox
    Friend WithEvents txtMaxP As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkSign As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveLocalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadOnlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UploadAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacultyTimetabelsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ClassSectionTimetablesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
End Class
