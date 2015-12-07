Public Class Reports

    Private Sub Reports_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TimetableDataSet.CSF_View_with_Load' table. You can move, or remove it, as needed.
        Me.CSF_View_with_LoadTableAdapter.Fill(Me.TimetableDataSet.CSF_View_with_Load)


    End Sub
End Class