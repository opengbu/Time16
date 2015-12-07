Imports System.Data.SqlClient
Public Class frmCopyStructure

    Private Sub frmCopyStructure_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ECollegeDataSet.Section' table. You can move, or remove it, as needed.
        Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Dim sQry = "INSERT INTO [Coursestructure] SELECT @toPrgId as ProgramId, CouseId,remark From [Coursestructure] AS CourseStructureTmp WHERE ProgramId=@prgid"
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.Parameters.Add("@toPrgId", SqlDbType.Int)
            cmd.Parameters("@toPrgId").Value = ComboBox2.SelectedValue
            cmd.Parameters.Add("@prgid", SqlDbType.Int)
            cmd.Parameters("@prgid").Value = ComboBox1.SelectedValue
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Dispose()
    End Sub
End Class