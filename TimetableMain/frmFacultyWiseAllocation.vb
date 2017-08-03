Imports System.Data.SqlClient

Public Class frmFacultyWiseAllocation

    Private Sub frmCSF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim schoolname As String = Module1._school
        TeacherTableAdapter.Fill(ECollegeDataSet.Teacher)
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


        ComboBox1.Focus()
        Me.CSF_ViewTableAdapter.FillByFacultyId(Me.ECollegeDataSet.CSF_View, ComboBox3.SelectedValue)
        Me.V_CourseStructureTableAdapter.FillBySemester(Me.ECollegeDataSet.V_CourseStructure, Me.ComboBox1.SelectedValue, _currentSemester)
        Me.DataGridView1.Invalidate()

        Me.Refresh()


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim fSub As New frmSubjectQuick
        fSub.ShowDialog()
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        Me.ComboBox2.Invalidate()
        Me.Refresh()
    End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Dim fSub As New frmEmployee
    '    fSub.ShowDialog()
    '    Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
    '    Me.ComboBox3.Invalidate()
    '    Me.Refresh()
    'End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sQry As String = ""
        'If TextBox1.Text.Trim > 0 Then
        'sQry = "Exec UpdateCSF @csfid=" & TextBox1.Text.Trim & ",@facid=" & Me.ComboBox3.SelectedValue
        'Dim cn As New SqlConnection
        'cn.ConnectionString = My.Settings.eCollegeConnectionString
        'cn.Open()
        '' MsgBox(sQry)
        'Dim cmd As New SqlCommand(sQry, cn)
        'cmd.ExecuteNonQuery()
        'If cn.State = ConnectionState.Open Then cn.Close()
        ' Else

        'sQry = "INSERT INTO [L_Section_Subject_Faculty] ([Section_Id] ,[Subject_Code],[Faculty_Id],[IsRemoved],[Assign_Date] ,[SessionID])         VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.ComboBox2.SelectedValue & "' ," & Me.ComboBox3.SelectedValue & ",0 ,Current_timestamp  ,11 )"
        ' sQry = "INSERT INTO [CourseStructure] (ProgramId, CouseId) VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.ComboBox2.Text.Trim & "')"
        sQry = "IF NOT EXISTS (SELECT * FROM [CourseStructure] WHERE CouseId = '" & Me.ComboBox2.Text.Trim & "' AND ProgramId=" & Me.ComboBox1.SelectedValue & ") INSERT INTO [CourseStructure] (ProgramId, CouseId) VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.ComboBox2.Text.Trim & "')"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        cn.Open()

        Dim cmd As New SqlCommand(sQry, cn)
        ' MsgBox(sQry)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


        Dim sQRy1 As String
        'Dim cn As New SqlConnection
        'cn.ConnectionString = My.Settings.eCollegeConnectionString
        Try
            Dim csfid As Integer = 0
            sQRy1 = "Exec InsertCSf " _
                                    & " @facid=" & Me.ComboBox3.SelectedValue _
                                    & ", @sectionid=" & Me.ComboBox1.SelectedValue _
                                    & ", @subjectid=" & Me.ComboBox2.SelectedValue _
                                    & ", @subjectcode=" & Me.ComboBox2.Text.Trim _
                                    & ", @L=" & Me.nLA.Value _
                                    & ", @T=" & Me.nTA.Value _
                                    & ", @P=" & Me.nPA.Value

            Dim cmd1 As New SqlCommand(sQRy1, cn)

            csfid = cmd1.ExecuteScalar()
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            cn.Close()
        End Try
        
        If cn.State = ConnectionState.Open Then cn.Close()
        ComboBox1.Focus()

        Me.CSF_ViewTableAdapter.FillByFacultyId(Me.ECollegeDataSet.CSF_View, ComboBox3.SelectedValue)
        Me.V_CourseStructureTableAdapter.FillBySemester(Me.ECollegeDataSet.V_CourseStructure, Me.ComboBox1.SelectedValue, _currentSemester)

        Me.DataGridView1.Invalidate()

        Me.Refresh()

    End Sub


    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        frmCopyStructure.ShowDialog()

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
            'Me.SectionTableAdapter.FillBy1(Me.ECollegeDataSet.Section, cbSession.ComboBox.SelectedValue)
            ComboBox1.Focus()
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Me.ComboBox1.Invalidate()

    End Sub

    Private Sub ComboBox1_GotFocus(sender As Object, e As EventArgs) Handles ComboBox1.GotFocus

        If ComboBox1.SelectedIndex = -1 Then Exit Sub
        'Try
        '    CSFUpdate(cbSection.ComboBox.SelectedValue)
        '    _section = cbSection.ComboBox.SelectedValue
        '    _currentSection = _section
        '    LoadTT(cbSection.ComboBox.SelectedValue)
        'Catch ex As Exception

        'End Try

        '  Try
        ' Me.V_CourseStructureTableAdapter.Fill(Me.ECollegeDataSet.V_CourseStructure, ComboBox1.SelectedValue)
        ' Me.DataGridView1.Invalidate()
        ' Me.Refresh()
        ' Catch ex As Exception

        '  End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ' Me.V_CourseStructureTableAdapter.Fill(Me.ECollegeDataSet.V_CourseStructure, ComboBox1.SelectedValue)
            Me.V_CourseStructureTableAdapter.FillBySemester(Me.ECollegeDataSet.V_CourseStructure, Me.ComboBox1.SelectedValue, _currentSemester)
            Me.DataGridView1.Invalidate()
            Me.Refresh()


            ComboBox1.Focus()

            'Me.CSF_ViewTableAdapter.FillByFacultyId(Me.ECollegeDataSet.CSF_View, ComboBox3.SelectedValue)


            'Me.DataGridView1.Invalidate()

            'Me.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillBy2ToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            ' Me.CSF_ViewTableAdapter.FillBy2(Me.ECollegeDataSet.CSF_View)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex = -1 Then Exit Sub
        Try
            Me.CSF_ViewTableAdapter.FillByFacultyId(Me.ECollegeDataSet.CSF_View, ComboBox3.SelectedValue)
            'Me.SectionTableAdapter.FillBy1(Me.ECollegeDataSet.Section, cbSession.ComboBox.SelectedValue)
            ComboBox1.Focus()
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Me.ComboBox3.Invalidate()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class