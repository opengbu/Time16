<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickInsert
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.txtQISection = New System.Windows.Forms.TextBox()
        Me.cbQISubjectCode = New System.Windows.Forms.ComboBox()
        Me.cbQIFaculty = New System.Windows.Forms.ComboBox()
        Me.ECollegeDataSet = New TimeTableManager.eCollegeDataSet()
        Me.SubjectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SubjectTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.SubjectTableAdapter()
        Me.ECollegeDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TeacherBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TeacherTableAdapter = New TimeTableManager.eCollegeDataSetTableAdapters.TeacherTableAdapter()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ECollegeDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(283, 229)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'txtQISection
        '
        Me.txtQISection.Location = New System.Drawing.Point(45, 24)
        Me.txtQISection.Name = "txtQISection"
        Me.txtQISection.ReadOnly = True
        Me.txtQISection.Size = New System.Drawing.Size(132, 20)
        Me.txtQISection.TabIndex = 1
        '
        'cbQISubjectCode
        '
        Me.cbQISubjectCode.DataSource = Me.SubjectBindingSource
        Me.cbQISubjectCode.DisplayMember = "code"
        Me.cbQISubjectCode.FormattingEnabled = True
        Me.cbQISubjectCode.Location = New System.Drawing.Point(45, 72)
        Me.cbQISubjectCode.Name = "cbQISubjectCode"
        Me.cbQISubjectCode.Size = New System.Drawing.Size(132, 21)
        Me.cbQISubjectCode.TabIndex = 2
        Me.cbQISubjectCode.ValueMember = "id"
        '
        'cbQIFaculty
        '
        Me.cbQIFaculty.DataSource = Me.TeacherBindingSource
        Me.cbQIFaculty.DisplayMember = "name"
        Me.cbQIFaculty.FormattingEnabled = True
        Me.cbQIFaculty.Location = New System.Drawing.Point(45, 116)
        Me.cbQIFaculty.Name = "cbQIFaculty"
        Me.cbQIFaculty.Size = New System.Drawing.Size(346, 21)
        Me.cbQIFaculty.TabIndex = 3
        Me.cbQIFaculty.ValueMember = "id"
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
        'SubjectTableAdapter
        '
        Me.SubjectTableAdapter.ClearBeforeFill = True
        '
        'ECollegeDataSetBindingSource
        '
        Me.ECollegeDataSetBindingSource.DataSource = Me.ECollegeDataSet
        Me.ECollegeDataSetBindingSource.Position = 0
        '
        'TeacherBindingSource
        '
        Me.TeacherBindingSource.DataMember = "Teacher"
        Me.TeacherBindingSource.DataSource = Me.ECollegeDataSetBindingSource
        '
        'TeacherTableAdapter
        '
        Me.TeacherTableAdapter.ClearBeforeFill = True
        '
        'frmQuickInsert
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(441, 270)
        Me.Controls.Add(Me.cbQIFaculty)
        Me.Controls.Add(Me.cbQISubjectCode)
        Me.Controls.Add(Me.txtQISection)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuickInsert"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmQuickInsert"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.ECollegeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ECollegeDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TeacherBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtQISection As TextBox
    Friend WithEvents cbQISubjectCode As ComboBox
    Friend WithEvents cbQIFaculty As ComboBox
    Friend WithEvents ECollegeDataSet As eCollegeDataSet
    Friend WithEvents SubjectBindingSource As BindingSource
    Friend WithEvents SubjectTableAdapter As eCollegeDataSetTableAdapters.SubjectTableAdapter
    Friend WithEvents ECollegeDataSetBindingSource As BindingSource
    Friend WithEvents TeacherBindingSource As BindingSource
    Friend WithEvents TeacherTableAdapter As eCollegeDataSetTableAdapters.TeacherTableAdapter
End Class
