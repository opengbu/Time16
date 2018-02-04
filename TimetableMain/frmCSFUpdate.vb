Imports System.Windows.Forms
Imports System.Data.SqlClient


Public Class FRMcsfupdate
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
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            'Dim cmd1 As New SqlCommand(sQry, cn)

            'cmd1.Parameters.Add("@facid", SqlDbType.Int)
            'cmd1.Parameters("@facid").Value = Me.ComboBox3.SelectedValue

            'cmd1.Parameters.Add("@csfid", SqlDbType.Int)
            'cmd1.Parameters("@csfid").Value = TextBox1.Text.Trim

            'cn.Open()
            '' MsgBox(sQry)
            ''Dim cmd As New SqlCommand(sQry, cn)
            'cmd1.ExecuteNonQuery()
            'If cn.State = ConnectionState.Open Then cn.Close()
            'cmd1.Dispose()
            'cn.Close()
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
            'sQry = "INSERT INTO [CSF] ([Section_Id] ,[Subject_Code],[Faculty_Id],[IsRemoved],[Assign_Date] ,[SessionID])         VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.ComboBox2.SelectedValue & "' ," & Me.ComboBox3.SelectedValue & ",0 ,Current_timestamp  ,11 )"
            'sQry = "INSERT INTO [CSF] ([Section_Id],[Subject_Id] ,[Subject_Code],[Faculty_Id],[IsRemoved],[LA],[TA],[PA]) VALUES (" & Me.ComboBox1.SelectedValue & " ,'" & Me.ComboBox2.SelectedValue & "' ,'" & Me.ComboBox2.Text.Trim & "' ," & Me.ComboBox3.SelectedValue & ",0," & Me.nLA.Value & " ," & Me.nTA.Value & " ," & Me.nPA.Value & ")"
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
      
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
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Dispose()
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
    End Sub

    Private Sub csfupdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ECollegeDataSet.Teacher' table. You can move, or remove it, as needed.
        '    Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
        'TODO: This line of code loads data into the 'ECollegeDataSet.Subject' table. You can move, or remove it, as needed.
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        'TODO: This line of code loads data into the 'ECollegeDataSet.Section' table. You can move, or remove it, as needed.
        Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)
        'TODO: This line of code loads data into the 'ECollegeDataSet.Teacher' table. You can move, or remove it, as needed.
        Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
        'TODO: This line of code loads data into the 'ECollegeDataSet5.V_Faculty' table. You can move, or remove it, as needed.
        'Me.DisplayRectangle'_FacultyTableAdapter.Fill(Me.ECollegeDataSet.V_Faculty)
        'TODO: This line of code loads data into the 'ECollegeDataSet5.M_Subject' table. You can move, or remove it, as needed.
        'Me.M_SubjectTableAdapter.Fill(Me.ECollegeDataSet5.M_Subject)
        Me.ComboBox1.Enabled = False
        ' _section = _currentSection
        ' Me.ComboBox1.SelectedValue = _section
        Try
            ComboBox1.SelectedValue = _currentSection
        Catch ex As Exception

        End Try

        If _currentcsf <> -1 Then
            _csf = _currentcsf
            Me.TextBox1.Text = _csf
            Me.pfac.Text = _currentfacids.Trim
            Array.Clear(facidlist, 0, 5)
        End If
        
        Try
            Dim i As Integer = 0
            For Each y In _currentfacids.Split(",")
                'Next
                i = i + 1
                'For y As Integer = 1 To 7 Step 1
                RBUTTON(i) = New RadioButton
                RBUTTON(i).Name = "RadioButton" & Convert.ToString(i)
                RBUTTON(i).Left = 400
                RBUTTON(i).Width = 300
                RBUTTON(i).Top = 50 + i * 35
                facidlist.SetValue(Convert.ToInt16(y), i)
                RBUTTON(i).Text = "Update " & GetFacultyById(Convert.ToInt16(y))
                'RBUTTON.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
                'RBUTTON.TextAlign = System.Drawing.ContentAlignment.TopCenter
                'RBUTTON.UseVisualStyleBackColor = True
                Controls.Add(RBUTTON(i))
            Next
            i = i + 1
            RBUTTON(i) = New RadioButton
            RBUTTON(i).Name = "RadioButton0"
            RBUTTON(i).Left = 400
            RBUTTON(i).Width = 300
            RBUTTON(i).Top = 50 + i * 35
            RBUTTON(i).Text = "Add New Faculty"
            Controls.Add(RBUTTON(i))
            RBUTTON(i).Select()

        Catch ex As Exception
            ' MsgBox(Err.Description)
        End Try
    End Sub

    

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        pfac.Enabled = Not pfac.Enabled
        If Me.CheckBox1.Checked Then
            Me.ComboBox1.Enabled = True
            Me.TextBox1.Text = 0
        Else
            Me.ComboBox1.Enabled = False
            Me.TextBox1.Text = _csf
        End If

    End Sub

    Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
        _section = ComboBox1.SelectedValue
    End Sub

    Private Function GetFaculty() As Integer
        GetFaculty = 0
        Dim radios = Controls.OfType(Of RadioButton).AsQueryable()
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
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Dispose()
    End Sub

  
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fSub As New frmSubjectQuick
        fSub.ShowDialog()
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        Me.ComboBox2.Invalidate()
        Me.Refresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fSub As New frmEmployee
        fSub.ShowDialog()
        Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
        Me.ComboBox3.Invalidate()
        Me.Refresh()
    End Sub
End Class
