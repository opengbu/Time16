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
            Dim cn As New SqlConnection With {
                .ConnectionString = My.Settings.eCollegeConnectionString1
            }
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
            Dim data, data1 As String
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            Try
                Data = dgvCourse.Item(0, dgvCourse.CurrentRow.Index).Value.ToString
                data1 = dgvCourse.Item(1, dgvCourse.CurrentRow.Index).Value.ToString
                Dim csfid As Integer = 0
                sQry = "Exec InsertCSf " _
                                        & " @facid=" & Me.ComboBox3.SelectedValue _
                                        & ", @sectionid=" & Me.ComboBox1.SelectedValue _
                                        & ", @subjectid=" & data _
                                        & ", @subjectcode=" & data1 _
                                        & ", @L=" & Me.nLA.Value _
                                        & ", @T=" & Me.nTA.Value _
                                        & ", @P=" & Me.nPA.Value _
                                        & ", @sessionid=" & _Session

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
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            Dim sQry As String = ""
            sQry = "  SELECT distinct Teacher_name_n, csf_id FROM CSF_View WHERE (Section_Id = @sid) AND (Subject_Id = @subid) and SessionId=@sessid"

            Dim cmd As New SqlCommand
            cmd.CommandText = sQry
            cmd.Connection = cn
            cmd.Parameters.Add("@sid", SqlDbType.Int)
            cmd.Parameters("@sid").Value = SectionId
            cmd.Parameters.Add("@sessid", SqlDbType.Int)
            cmd.Parameters("@sessid").Value = _Session

            cmd.Parameters.Add("@subid", SqlDbType.BigInt)
            cmd.Parameters("@subid").Value = SubjectId
            cn.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)

            dgvFacultyAssigned.DataSource = ds.Tables(0)
            dgvFacultyAssigned.Invalidate()


            ListBox3.DataSource = ds.Tables(0)
            ListBox3.ValueMember = ds.Tables(0).Columns(1).ColumnName
            ListBox3.DisplayMember = ds.Tables(0).Columns(0).ColumnName

        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub PrintAllErrs(ByVal dataSet As DataSet)
        Dim rowsInError() As DataRow
        Dim table As DataTable
        Dim i As Integer
        Dim column As DataColumn
        For Each table In dataSet.Tables
            ' Test if the table has errors. If not, skip it.
            If table.HasErrors Then
                ' Get an array of all rows with errors.
                rowsInError = table.GetErrors()
                ' Print the error of each column in each row.
                For i = 0 To rowsInError.GetUpperBound(0)
                    For Each column In table.Columns
                        Console.WriteLine(column.ColumnName,
                rowsInError(i).GetColumnError(column))
                    Next
                    ' Clear the row errors
                    rowsInError(i).ClearErrors()
                Next i
            End If
        Next
    End Sub

    Private Sub csfupdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = Button8
        ' Button8.DialogResult = System.Windows.Forms.DialogResult.OK

        'TODO: This line of code loads data into the 'ECollegeDataSet3.CourseStructure' table. You can move, or remove it, as needed.
        'TODO: This line of code loads data into the 'ECollegeDataSet3.Teacher' table. You can move, or remove it, as needed.
        Me.TeacherTableAdapter1.Fill(Me.ECollegeDataSet3.Teacher)
        'TODO: This line of code loads data into the 'ECollegeDataSet3.Section' table. You can move, or remove it, as needed.
        Me.SectionTableAdapter1.Fill(Me.ECollegeDataSet3.Section)
        'TODO: This line of code loads data into the 'ECollegeDataSet4.Section' table. You can move, or remove it, as needed.
        'Me.SectionTableAdapter1.Fill(Me.ECollegeDataSet4.Section)
        'Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)
        Me.ComboBox1.Enabled = False

        Try
            ComboBox1.SelectedValue = _currentSection
            _currentSemester = _Session Mod 2

            lblSemester.Text = _currentSemester
        Catch ex As Exception

        End Try

        'TODO: This line of code loads data into the 'ECollegeDataSet.Teacher' table. You can move, or remove it, as needed.
        '  Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)

        Try
            V_CourseStructureTableAdapter1.FillBySemester(ECollegeDataSet3.V_CourseStructure, _currentSection, _currentSemester)


        Catch ex As Exception
            'PrintAllErrs(ECollegeDataSet)
            ' MsgBox(ex.Message)
        End Try
        Array.Clear(facidlist, 0, 5)
        If _currentcsf <> -1 Then
            _csf = _currentcsf
            Me.TextBox1.Text = _csf
            Me.pfac.Text = _currentfacids.Trim
        End If
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
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
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
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
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


    'Private Sub Button1_Click(sender As Object, e As EventArgs) 
    '    Dim fSub As New frmCS
    '    fSub.ShowDialog()
    '    V_CourseStructureTableAdapter1.FillBySemester(ECollegeDataSet3.V_CourseStructure, _currentSection, _currentSemester)
    '    'ListBox1.Invalidate()
    '    ' ListBox2.Invalidate()
    '    'Me.Refresh()
    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fSub As New frmTeacher
        fSub.ShowDialog()
        Me.TeacherTableAdapter1.Fill(Me.ECollegeDataSet3.Teacher)
        Me.ComboBox3.Invalidate()
        Me.Refresh()
    End Sub

    'Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
    '    GetFacultyBy(_currentSection, ListBox2.SelectedValue)
    'End Sub

    'Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
    '    GetFacultyBy(_currentSection, ListBox1.SelectedValue)
    'End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sQRy As String
        Dim cn As New SqlConnection
        Dim data, data1 As String
        Try
            data = dgvCourse.Item(0, dgvCourse.CurrentRow.Index).Value.ToString
            data1 = dgvCourse.Item(1, dgvCourse.CurrentRow.Index).Value.ToString
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            Dim csfid As Integer = 0
            sQRy = "Exec InsertCSf " _
                                    & " @facid=" & Me.ComboBox3.SelectedValue _
                                    & ", @sectionid=" & Me.ComboBox1.SelectedValue _
                                    & ", @subjectid=" & data _
                                    & ", @subjectcode=" & data1 _
                                    & ", @L=" & Me.nLA.Value _
                                    & ", @T=" & Me.nTA.Value _
                                    & ", @P=" & Me.nPA.Value _
                                    & ", @SessionId=" & _Session

            cn.Open()
            Dim cmd As New SqlCommand(sQRy, cn)
            csfid = cmd.ExecuteScalar()
        Catch ex As Exception
            MsgBox(Err.Description & "::" & sQRy)
        Finally
            cn.Close()
        End Try
        TextBox2.Focus()
        GetFacultyBy(_currentSection, data.Trim)
        ListBox3.Invalidate()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text.Trim > 0 Then
            Dim sqry As String
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
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
        Dim data As String = dgvCourse.Item(0, dgvCourse.CurrentRow.Index).Value.ToString
        GetFacultyBy(_currentSection, data.Trim)
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
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
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
                Dim data As String = dgvCourse.Item(0, dgvCourse.CurrentRow.Index).Value.ToString
                GetFacultyBy(_currentSection, data.Trim)
                ListBox3.Invalidate()
            End If

        Catch ex As Exception
        Finally
           
            cn.Close()
        End Try

        
    End Sub

    Private Sub doMultiDelete()
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
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
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
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
        Dim data As String = dgvCourse.Item(0, dgvCourse.CurrentRow.Index).Value.ToString
        GetFacultyBy(_currentSection, data.Trim)
        ListBox3.Invalidate()
    End Sub

    Private Sub dgvCourse_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCourse.SelectionChanged
        Try
            Dim data As String = dgvCourse.Item(0, dgvCourse.CurrentRow.Index).Value.ToString
            GetFacultyBy(_currentSection, data.Trim)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Contains(" ") Then TextBox2.Text = TextBox2.Text.Replace(" ", String.Empty)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim sQry As String = ""
            sQry = "INSERT INTO [CourseStructure] (ProgramId, CouseId,semester,SessionId) VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.TextBox2.Text.Trim & "'," & _currentSemester & "," & _Session & ")"

            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            cn.Open()

            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()

            If cn.State = ConnectionState.Open Then cn.Close()
            TextBox2.Focus()
            V_CourseStructureTableAdapter1.FillBySemester(ECollegeDataSet3.V_CourseStructure, _currentSection, _currentSemester)
            'dgvCourse.Invalidate()
        Catch ex As Exception

            Dim f As New frmSubjects
            f.ShowDialog()


        End Try

    End Sub

    Private Sub dgvCourse_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvCourse.KeyDown
        If e.KeyCode = Keys.Delete Then
            Try
                DeleteCourse(Me.ComboBox1.SelectedValue, dgvCourse.SelectedRows(0).Cells(1).Value)
                V_CourseStructureTableAdapter1.FillBySemester(ECollegeDataSet3.V_CourseStructure, _currentSection, _currentSemester)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class
