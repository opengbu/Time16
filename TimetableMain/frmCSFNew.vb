Imports System.Windows.Forms
Imports System.Data.SqlClient


Public Class FRMcsfnew
    Private _section As Integer
    Private _csf As Integer
    Dim facidlist(5) As Integer
    Dim RBUTTON(5) As RadioButton
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim sQry As String = ""
        If TextBox1.Text.Trim > 0 Then
            ''sQry = "Exec UpdateCSF @csfid=" & TextBox1.Text.Trim & ",@facid=" & Me.ComboBox3.SelectedValue
            'sQry = "Update CSF Set Faculty_Id=@facid WHERE (csf_id = @csfid)"
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString
            Dim pfacid As Integer
            pfacid = GetFaculty()
            Try
                sQry = "Exec UpdateCSF @csfid=" & TextBox1.Text.Trim & ",@facid=" & Me.ComboBox3.SelectedValue & ", @pfacid=" & pfacid
                cn.Open()
                Dim cmd As New SqlCommand(sQry, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
            Finally
                cn.Close()
            End Try
        Else
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString
            Try
                Dim csfid As Integer = 0
                sQry = "Exec InsertCSf " _
                                        & " @facid=" & Me.ComboBox3.SelectedValue _
                                        & ", @sectionid=" & Me.ComboBox1.SelectedValue _
                                        & ", @subjectid=" & Me.ComboBox2.SelectedValue _
                                        & ", @subjectcode=" & Me.ComboBox2.Text.Trim _
                                        & ", @L=" & Me.nLA.Value _
                                        & ", @T=" & Me.nTA.Value _
                                        & ", @P=" & Me.nPA.Value

                cn.Open()
                Dim cmd As New SqlCommand(sQry, cn)
                csfid = cmd.ExecuteScalar()
            Catch ex As Exception
                MsgBox(Err.Description)
            Finally
                cn.Close()
            End Try

        End If
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        'For j = 1 To 5
        '    Me.Controls.Remove(RBUTTON(j))
        'Next
        Array.Clear(RBUTTON, 0, 5)
        Me.Dispose()
    End Sub

    Private Sub FRMcsfupdate_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        For j = 1 To 5
            Me.Controls.Remove(RBUTTON(j))
        Next
        frmMain.CSFList.Refresh()
        frmMain.CSFList.Invalidate()

    End Sub
    Public Sub GetFacultyBy(SectionId As Integer, SubjectId As Int32)
        If SubjectId = 0 Then Exit Sub
        Dim cn As New SqlConnection
        Try
            cn.ConnectionString = My.Settings.eCollegeConnectionString
            Dim sQry As String = ""
            sQry = "  SELECT distinct Teacher_name_n, csf_id FROM CSF_View WHERE (Section_Id = @sid) AND (Subject_Id = @subid)"

            Dim cmd As New SqlCommand
            cmd.CommandText = sQry
            cmd.Connection = cn
            cmd.Parameters.Add("@sid", SqlDbType.Int)
            cmd.Parameters("@sid").Value = SectionId
            cmd.Parameters.Add("@subid", SqlDbType.BigInt)
            cmd.Parameters("@subid").Value = SubjectId
            cn.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            ListBox3.DataSource = ds.Tables(0)
            ListBox3.ValueMember = ds.Tables(0).Columns(1).ColumnName
            ListBox3.DisplayMember = ds.Tables(0).Columns(0).ColumnName

        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub csfupdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)
        Me.ComboBox1.Enabled = False
        Try
            ComboBox1.SelectedValue = _currentSection
        Catch ex As Exception

        End Try

        'TODO: This line of code loads data into the 'ECollegeDataSet.Teacher' table. You can move, or remove it, as needed.
        Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)

        V_CourseStructureTableAdapter.Fill(ECollegeDataSet.V_CourseStructure, _currentSection)
        Array.Clear(facidlist, 0, 5)
        'If _currentcsf <> -1 Then
        '    _csf = _currentcsf
        '    Me.TextBox1.Text = _csf
        '    Me.pfac.Text = _currentfacids.Trim

        'End If
        'Try
        '    Dim i As Integer = 0
        '    For Each y In _currentfacids.Split(",")
        '        'Next
        '        i = i + 1
        '        'For y As Integer = 1 To 7 Step 1
        '        RBUTTON(i) = New RadioButton
        '        RBUTTON(i).Name = "RadioButton" & Convert.ToString(i)
        '        RBUTTON(i).Left = 400
        '        RBUTTON(i).Width = 300
        '        RBUTTON(i).Top = 50 + i * 35
        '        facidlist.SetValue(Convert.ToInt16(y), i)
        '        RBUTTON(i).Text = "Update " & GetFacultyById(Convert.ToInt16(y))
        '        'RBUTTON.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        '        'RBUTTON.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '        'RBUTTON.UseVisualStyleBackColor = True
        '        Controls.Add(RBUTTON(i))
        '    Next
        '    i = i + 1
        '    RBUTTON(i) = New RadioButton
        '    RBUTTON(i).Name = "RadioButton0"
        '    RBUTTON(i).Left = 400
        '    RBUTTON(i).Width = 300
        '    RBUTTON(i).Top = 50 + i * 35
        '    RBUTTON(i).Text = "Add New Faculty"
        '    Controls.Add(RBUTTON(i))
        '    RBUTTON(i).Select()

        'Catch ex As Exception
        '    ' MsgBox(Err.Description)
        'End Try
    End Sub


    'Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    '    pfac.Enabled = Not pfac.Enabled
    '    If Me.CheckBox1.Checked Then
    '        Me.ComboBox1.Enabled = True
    '        Me.TextBox1.Text = 0
    '    Else
    '        Me.ComboBox1.Enabled = False
    '        Me.TextBox1.Text = _csf
    '    End If

    'End Sub

    'Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
    '    _section = ComboBox1.SelectedValue
    'End Sub

    Private Function GetFaculty() As Integer
        GetFaculty = 0
        Dim radios = GroupBox1.Controls.OfType(Of RadioButton).AsQueryable()
        Dim i As Integer = 0
        For Each r As RadioButton In radios
            i = i + 1
            If r.Checked Then
                GetFaculty = facidlist(i)
            End If
        Next
    End Function

    Private Sub Delete_Button_Click(sender As Object, e As EventArgs) Handles Delete_Button.Click
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        Try
            Dim sQry As String = ""

            'If chkF2.Checked Then
            'sQry = "Delete From [CSF_Faculty] Where CSF_ID=" & Val(TextBox1.Text) & " and faculty_id=" & Me.ComboBox3.SelectedValue
            'Else
            sQry = "Delete From [CSF] Where CSF_ID=" & Val(TextBox1.Text)
            'End If
            cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        Try
            Dim sQry As String = ""
            'If chkF2.Checked Then
            Dim pfacid As Integer
            pfacid = GetFaculty()
            sQry = "Delete From [CSF_Faculty] Where CSF_ID=" & Val(TextBox1.Text) & " and faculty_id=" & pfacid
            'Else
            'sQry = "Delete From [CSF] Where CSF_ID=" & Val(TextBox1.Text)
            'End If
            cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Dispose()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fSub As New frmCS
        fSub.ShowDialog()
        V_CourseStructureTableAdapter.Fill(ECollegeDataSet.V_CourseStructure, _currentSection)
        ListBox1.Invalidate()
        ListBox2.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fSub As New frmEmployee
        fSub.ShowDialog()
        Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
        Me.ComboBox3.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        GetFacultyBy(_currentSection, ListBox2.SelectedValue)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        GetFacultyBy(_currentSection, ListBox1.SelectedValue)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sQRy As String
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        Try
            Dim csfid As Integer = 0
            sQRy = "Exec InsertCSf " _
                                    & " @facid=" & Me.ComboBox3.SelectedValue _
                                    & ", @sectionid=" & Me.ComboBox1.SelectedValue _
                                    & ", @subjectid=" & Me.ComboBox2.SelectedValue _
                                    & ", @subjectcode=" & Me.ComboBox2.Text.Trim _
                                    & ", @L=" & Me.nLA.Value _
                                    & ", @T=" & Me.nTA.Value _
                                    & ", @P=" & Me.nPA.Value

            cn.Open()
            Dim cmd As New SqlCommand(sQRy, cn)
            csfid = cmd.ExecuteScalar()
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            cn.Close()
        End Try
        GetFacultyBy(_currentSection, ListBox2.SelectedValue)
        ListBox3.Invalidate()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text.Trim > 0 Then
            Dim sqry As String
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString
            Dim pfacid As Integer
            pfacid = GetFaculty()
            Try
                sqry = "Exec UpdateCSF @csfid=" & TextBox1.Text.Trim & ",@facid=" & Me.ComboBox3.SelectedValue & ", @pfacid=" & pfacid
                cn.Open()
                Dim cmd As New SqlCommand(sqry, cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
            Finally
                cn.Close()
            End Try
        Else
            MsgBox("Select Faculty!")
        End If
        GetFacultyBy(_currentSection, ListBox2.SelectedValue)
        ListBox3.Invalidate()
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        Try
            TextBox1.Text = ListBox3.SelectedValue
        Catch ex As Exception

        End Try

        'MsgBox(ListBox3.Text.ToString)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        Try
            If ListBox3.Text.ToString.Split(",").Count > 1 Then
                doMultiDelete()
            Else
                Dim sQry As String = ""

                'If chkF2.Checked Then
                'sQry = "Delete From [CSF_Faculty] Where CSF_ID=" & Val(TextBox1.Text) & " and faculty_id=" & Me.ComboBox3.SelectedValue
                'Else
                sQry = "Delete From [CSF] Where CSF_ID=" & Val(TextBox1.Text)
                'End If
                cn.Open()
                Dim cmd As New SqlCommand(sQry, cn)
                cmd.ExecuteNonQuery()
                GetFacultyBy(_currentSection, ListBox2.SelectedValue)
                ListBox3.Invalidate()
            End If

        Catch ex As Exception
        Finally
           
            cn.Close()
        End Try

        
    End Sub

    Private Sub doMultiDelete()
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        Dim sQry As String = ""
        sQry = "SELECT TOP(20) csf_id, faculty_id FROM CSF_Faculty WHERE (csf_id =" + TextBox1.Text.ToString.Trim + ")"
        'sQry = "SELECT distinct Teacher_name_n, Teacher_Id_n, csf_id FROM CSF_View WHERE (Section_Id =" + SectionId + ") AND (Subject_Id =" + SubjectId + ")"

        Dim cmd As New SqlCommand
        cmd.CommandText = sQry
        cmd.Connection = cn

        'cmd.Parameters.Add("@sid", SqlDbType.Int)
        'cmd.Parameters("@sid").Value = SectionId

        'cmd.Parameters.Add("@subid", SqlDbType.BigInt)
        'cmd.Parameters("@subid").Value = SubjectId
        GroupBox1.Visible = True
        cn.Open()
        Array.Clear(facidlist, 0, 5)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim i As Integer = 0
        While rd.Read
            Dim rdo As New RadioButton
            i = i + 1
            rdo.Name = "RadioButton" & i
            rdo.Text = GetFacultyById(rd(1)) & Str(rd(1))
            facidlist.SetValue(Convert.ToInt16(rd(1)), i)
            rdo.Location = New Point(10, 27 * (i + 1))
            GroupBox1.Controls.Add(rdo)

        End While
        cn.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        Try
            Dim sQry As String = ""
            'If chkF2.Checked Then
            Dim pfacid As Integer
            pfacid = GetFaculty()

            sQry = "Delete From [CSF_Faculty] Where CSF_ID=" & Val(TextBox1.Text) & " and faculty_id=" & pfacid
            'Else
            'sQry = "Delete From [CSF] Where CSF_ID=" & Val(TextBox1.Text)
            'End If
            cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        GroupBox1.Visible = False
        GetFacultyBy(_currentSection, ListBox2.SelectedValue)
        ListBox3.Invalidate()
    End Sub
End Class
