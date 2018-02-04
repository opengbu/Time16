Imports System.Data.SqlClient

Public Class frmCSF
    Dim _filter As Boolean = True
    Dim _crrsec As Integer = 1
    Friend cn As New SqlConnection
    Private Sub frmCSF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        Me.SchoolTableAdapter.Fill(Me.ECollegeDataSet.School)
        ECollegeDataSet.EnforceConstraints = False
        Me.CSF_ViewTableAdapter.Fill(Me.ECollegeDataSet.CSF_View)
        Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)
        Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, ComboBox1.Text.Trim)
        Me.dgvCSF.Invalidate()
        V_CourseStructureTableAdapter.Fill(ECollegeDataSet.V_CourseStructure, Me.ComboBox1.SelectedValue)
        cbCSSubject.Invalidate()
        Me.Refresh()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        NewSave()
    End Sub

    Private Sub OldSave()
        Dim sQry As String = ""
        If TextBox1.Text.Trim > 0 Then
            If (chkF2.Checked) Then
                sQry = "Exec UpdateCSF @csfid=" & TextBox1.Text.Trim & ",@facid=" & Me.ComboBox3.SelectedValue & ", @facid2=" & Me.cbFaculty2.SelectedValue
            Else
                sQry = "Exec UpdateCSF @csfid=" & TextBox1.Text.Trim & ",@facid=" & Me.ComboBox3.SelectedValue
            End If

            Dim cn As New SqlConnection

            cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then cn.Close()
        Else
            If (chkF2.Checked) Then
                sQry = "INSERT INTO [CSF] ([Section_Id],[Subject_Id] ,[Subject_Code],[Faculty_Id],[IsRemoved],[LA],[TA],[PA],[Faculty_Id2]) VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.cbCSSubject.SelectedValue & "' ,'" & Me.cbCSSubject.Text.Trim & "' ," & Me.ComboBox3.SelectedValue & ",0," & Me.nLA.Value & " ," & Me.nTA.Value & " ," & Me.nPA.Value & "," & Me.cbFaculty2.SelectedValue & ")"
            Else
                sQry = "INSERT INTO [CSF] ([Section_Id],[Subject_Id] ,[Subject_Code],[Faculty_Id],[IsRemoved],[LA],[TA],[PA]) VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.cbCSSubject.SelectedValue & "' ,'" & Me.cbCSSubject.Text.Trim & "' ," & Me.ComboBox3.SelectedValue & ",0," & Me.nLA.Value & " ," & Me.nTA.Value & " ," & Me.nPA.Value & ")"
            End If

            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then cn.Close()
        End If
        ComboBox1.Focus()
        Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, ComboBox1.Text.Trim)
        Me.dgvCSF.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = 0
    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillByToolStripButton.Click
        Try
            Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, Param1ToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Param1ToolStripTextBox.Text = ComboBox1.Text.Trim
        Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, Param1ToolStripTextBox.Text)
        Me.dgvCSF.Invalidate()
        V_CourseStructureTableAdapter.Fill(ECollegeDataSet.V_CourseStructure, Me.ComboBox1.SelectedValue)
        cbCSSubject.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim fSub As New frmSubjectQuick
        fSub.ShowDialog()
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        Me.cbCSSubject.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim fSub As New frmEmployee
        fSub.ShowDialog()
        Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
        Me.ComboBox3.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        _filter = Not _filter
        If _filter Then
            Me.cbCSSubject.DataSource = BindingSource1
            Me.cbCSSubject.DisplayMember = "subject_code"
            Me.cbCSSubject.ValueMember = "id"
            Me.cbCSSubject1.DataSource = BindingSource1
            Me.cbCSSubject1.DisplayMember = "subject_name"
            Me.nLA.DataBindings.Clear()
            Me.nLA.DataBindings.Add("Value", BindingSource1, "L")
            Me.nTA.DataBindings.Clear()
            Me.nTA.DataBindings.Add("Value", BindingSource1, "T")
            Me.nPA.DataBindings.Clear()
            Me.nPA.DataBindings.Add("Value", BindingSource1, "P")
            Button5.Text = "Remove Filter"
        Else
            Me.cbCSSubject.DataSource = SubjectBindingSource
            Me.cbCSSubject.DisplayMember = "code"
            Me.cbCSSubject.ValueMember = "id"
            Me.cbCSSubject1.DataSource = SubjectBindingSource
            Me.cbCSSubject1.DisplayMember = "name"
            Me.nLA.DataBindings.Clear()
            Me.nLA.DataBindings.Add("Value", SubjectBindingSource, "L")
            Me.nTA.DataBindings.Clear()
            Me.nTA.DataBindings.Add("Value", SubjectBindingSource, "T")
            Me.nPA.DataBindings.Clear()
            Me.nPA.DataBindings.Add("Value", SubjectBindingSource, "P")

            'Me.nLA.DataBindings.Clear()
            'Me.nLA.DataBindings.Add(New Binding("Value", SubjectBindingSource, "L", True, DataSourceUpdateMode.OnPropertyChanged))

            Button5.Text = "Filter Subjecs"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = 0 Then
            Button6.Visible = False
            Button7.Visible = False
        Else
            Button6.Visible = True
            Button7.Visible = True
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim sQry As String = ""

        If chkF2.Checked Then
            sQry = "Delete From [CSF_Faculty] Where CSF_ID=" & Val(TextBox1.Text) & " and faculty_id=" & Me.ComboBox3.SelectedValue
        Else
            sQry = "Delete From [CSF] Where CSF_ID=" & Val(TextBox1.Text)
        End If


        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()

        Dim cmd As New SqlCommand(sQry, cn)
        ' MsgBox(sQry)
        cmd.ExecuteNonQuery()
        If cn.State = ConnectionState.Open Then cn.Close()

        ComboBox1.Focus()
        TextBox1.Text = 0
        Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, Param1ToolStripTextBox.Text)
        Me.dgvCSF.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub chkF2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkF2.CheckedChanged
        'cbFaculty2.Visible = chkF2.Checked

    End Sub

    Private Sub FillByToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles FillByToolStripButton1.Click
        Try
            Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, Param1ToolStripTextBox1.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
   
    Private Sub dgvCSF_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCSF.CellContentClick
        TextBox1.Text = dgvCSF.CurrentRow.Cells(0).Value
        pfac.Text = dgvCSF.CurrentRow.Cells(8).Value
    End Sub

    Private Sub NewSave()

        If Val(TextBox1.Text) = 0 Then

            Try
                Dim csfid As Integer = 0
                Dim sQry As String = "Exec InsertCSf " _
                                        & " @facid=" & Me.ComboBox3.SelectedValue _
                                        & ", @sectionid=" & Me.ComboBox1.SelectedValue _
                                        & ", @subjectid=" & Me.cbCSSubject.SelectedValue _
                                        & ", @subjectcode=" & Me.cbCSSubject.Text.Trim _
                                        & ", @L=" & Me.nLA.Value _
                                        & ", @T=" & Me.nTA.Value _
                                        & ", @P=" & Me.nPA.Value

                cn.Open()
                Dim cmd As New SqlCommand(sQry, cn)
                csfid = cmd.ExecuteScalar()
            Catch ex As Exception

            Finally
                cn.Close()
            End Try
        Else
            MsgBox("You have selected some CSF Id. Do you want add additional Faculty?")
        End If

        ComboBox1.Focus()
        Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, ComboBox1.Text.Trim)
        Me.dgvCSF.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If InStr(pfac.Text, "'") = 0 Then
            If Val(TextBox1.Text) > 0 Then
                Try
                    Dim sQry As String = "Exec UpdateCSF @csfid=" & TextBox1.Text.Trim & ",@facid=" & Me.ComboBox3.SelectedValue & ", @pfacid=" & Val(pfac.Text)
                    cn.Open()
                    Dim cmd As New SqlCommand(sQry, cn)
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception

                End Try
            Else
                MsgBox("Select Some CSF ID First.")
            End If
        Else
            MsgBox("Choose Single Faculty Only.")
        End If
        ComboBox1.Focus()
        Me.CSF_ViewTableAdapter.FillBy(Me.ECollegeDataSet.CSF_View, ComboBox1.Text.Trim)
        Me.dgvCSF.Invalidate()
        Me.Refresh()
    End Sub
End Class