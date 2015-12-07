<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports
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
        Me.CSF_View_with_LoadBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimetableDataSet = New TimetableView.TimetableDataSet()
        Me.CSF_View_with_LoadTableAdapter = New TimetableView.TimetableDataSetTableAdapters.CSF_View_with_LoadTableAdapter()
        CType(Me.CSF_View_with_LoadBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimetableDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CSF_View_with_LoadBindingSource
        '
        Me.CSF_View_with_LoadBindingSource.DataMember = "CSF_View_with_Load"
        Me.CSF_View_with_LoadBindingSource.DataSource = Me.TimetableDataSet
        '
        'TimetableDataSet
        '
        Me.TimetableDataSet.DataSetName = "TimetableDataSet"
        Me.TimetableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CSF_View_with_LoadTableAdapter
        '
        Me.CSF_View_with_LoadTableAdapter.ClearBeforeFill = True
        '
        'Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 458)
        Me.Name = "Reports"
        Me.Text = "Reports"
        CType(Me.CSF_View_with_LoadBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimetableDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CSF_View_with_LoadBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimetableDataSet As TimetableView.TimetableDataSet
    Friend WithEvents CSF_View_with_LoadTableAdapter As TimetableView.TimetableDataSetTableAdapters.CSF_View_with_LoadTableAdapter
End Class
