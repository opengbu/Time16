Public Class frmFacultyLoad
    Private Sub frmFacultyLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ECollegeDataSet.School' table. You can move, or remove it, as needed.
        Me.SchoolTableAdapter.Fill(Me.ECollegeDataSet.School)
        'TODO: This line of code loads data into the 'ECollegeDataSet.CSFTable' table. You can move, or remove it, as needed.

        Try
            Me.CSFTableTableAdapter.Fill(Me.ECollegeDataSet.CSFTable)
        Catch ex As Exception

        End Try
    End Sub



    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs) Handles FillByToolStripButton.Click
        Try
            Me.CSFTableTableAdapter.FillBy(Me.ECollegeDataSet.CSFTable, Param1ToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cbSchools_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSchools.SelectedIndexChanged
        Try
            Me.CSFTableTableAdapter.FillBy(Me.ECollegeDataSet.CSFTable, cbSchools.SelectedValue.ToString.Trim)
        Catch ex As Exception

        End Try
    End Sub
End Class