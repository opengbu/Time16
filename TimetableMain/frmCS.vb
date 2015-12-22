Imports System.Data.SqlClient

Public Class frmCS

    Private Sub frmCSF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim schoolname As String = Module1._school
        ' schoolname = "all"
        Try

            If schoolname = "all" Then
                Me.ProgramTableAdapter1.Fill(ECollegeDataSet.Program)
            Else
                Me.ProgramTableAdapter1.FillBy(ECollegeDataSet.Program, schoolname)
            End If


            cbsession.DisplayMember = "name".Trim()
            cbsession.ValueMember = "Id"
            cbsession.DataSource = bsProgram
            cbSession.Invalidate()
            'My.Settings.ProgramFilter = False


            If schoolname = "all" Then
                Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)
            Else
                Me.SectionTableAdapter.FillBy(Me.ECollegeDataSet.Section, Me.cbsession.SelectedValue)
            End If

            Try
                cbsession.SelectedValue = _currentSession
                ComboBox1.SelectedValue = _currentSection
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try


        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim fSub As New frmSubjectQuick
        fSub.ShowDialog()
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        Me.ComboBox2.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sQry As String = ""
        sQry = "INSERT INTO [CourseStructure] (ProgramId, CouseId,semester) VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.ComboBox2.Text.Trim & "'," & _currentSemester & ")"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        cn.Open()

        Dim cmd As New SqlCommand(sQry, cn)
        cmd.ExecuteNonQuery()

        If cn.State = ConnectionState.Open Then cn.Close()
        ComboBox1.Focus()
        'UpdateDataGrid()

    End Sub


    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        frmCopyStructure.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        SubjectBindingSource.Sort = "Name"
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        SubjectBindingSource.Sort = "code"
    End Sub
    Private Sub cbsession_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbsession.SelectedIndexChanged
        If cbsession.SelectedIndex = -1 Then Exit Sub
        Try
            Me.SectionTableAdapter.FillBy(Me.ECollegeDataSet.Section, cbsession.SelectedValue)
            ComboBox1.Focus()
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Me.ComboBox1.Invalidate()
    End Sub

    Private Sub ComboBox1_GotFocus(sender As Object, e As EventArgs) Handles ComboBox1.GotFocus
        If ComboBox1.SelectedIndex = -1 Then Exit Sub
        UpdateDataGrid()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        UpdateDataGrid()
    End Sub

    Private Sub UpdateDataGrid()
        Try
            Me.V_CourseStructureTableAdapter.FillBySemester(Me.ECollegeDataSet.V_CourseStructure, ComboBox1.SelectedValue, _currentSemester)
            Me.DataGridView1.Invalidate()
            Me.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            Try
                DeleteCourse(ComboBox1.SelectedValue, DataGridView1.SelectedRows(0).Cells(1).Value)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class