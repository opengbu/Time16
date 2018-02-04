Public Class mytest
    Private Sub mytest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ds As New DataSet
        Dim t As New TimeTable

        ds = t.TTCellBySectionId(6)
        DataGridView1.DataSource = ds.Tables(0)


    End Sub
End Class