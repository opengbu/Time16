Imports System.Data
Imports System.Data.SqlClient


Public Class frmTeacher
    Dim cn As New SqlConnection(My.Settings.eCollegeConnectionString1)
    Dim da As SqlDataAdapter
    Dim dt As DataTable
    Dim dv As DataView
    Dim _Faculty_School As String = "ALL"
    Dim _Faculty_Status As Integer = 0
    Dim _Current_Faculty_Id As Integer = 0
    Dim IsEditMode As Boolean = False
    Dim RestrciMode As Boolean = False


    Private Sub frmTeacher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_school = "SOICT"

        If _school <> "" Then _Faculty_School = _school
        cbSchool.Text = _school.Trim
        If _Faculty_School.ToUpper = "ALL" Then

            cbSchool.Text = "SOVSAS"
            cbSchool.Enabled = True
        Else
            cbSchool.Enabled = False
        End If
        ShowTeahers(_Faculty_School)
        dgvTeacher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub ShowTeahers(Optional ByVal School As String = "ALL", Optional ByVal Status As Integer = -1)
        If School = "ALL" Then
            If Status = -1 Then
                da = New SqlDataAdapter("Select [Id],[Name],[Abbr],[School],[Department], [Status] From Teacher", cn)
            Else
                da = New SqlDataAdapter("Select [Id],[Name],[Abbr],[School],[Department], [Status] From Teacher Where Status=" & Status, cn)
            End If

        Else
            If Status = -1 Then
                da = New SqlDataAdapter("Select [Id],[Name],[Abbr],[School],[Department], [Status] From Teacher WHERE School='" & School & "'", cn)
            Else
                da = New SqlDataAdapter("Select [Id],[Name],[Abbr],[School],[Department], [Status] From Teacher WHERE School='" & School & "' AND Status=" & Status, cn)
            End If

        End If

        dt = New DataTable()
        da.Fill(dt)
        dv = dt.DefaultView
        dgvTeacher.DataSource = dv

    End Sub


    Private Sub rb_Faculty_Status_Guest_CheckedChanged(sender As Object, e As EventArgs) Handles rb_Faculty_Status_Guest.CheckedChanged
        If rb_Faculty_Status_Guest.Checked Then _Faculty_Status = 1
        If Not IsEditMode Then ShowTeahers(_Faculty_School, _Faculty_Status)
    End Sub

    Private Sub rb_Faculty_Status_Regular_CheckedChanged(sender As Object, e As EventArgs) Handles rb_Faculty_Status_Regular.CheckedChanged
        If rb_Faculty_Status_Regular.Checked Then _Faculty_Status = 0
        If Not IsEditMode Then ShowTeahers(_Faculty_School, _Faculty_Status)
    End Sub

    Private Sub rb_Faculty_Status_Both_CheckedChanged(sender As Object, e As EventArgs) Handles rb_Faculty_Status_Both.CheckedChanged
        If rb_Faculty_Status_Guest.Checked Then _Faculty_Status = -1
        If Not IsEditMode Then ShowTeahers(_Faculty_School)
    End Sub

    Private Sub ResetEditMode(bit As Integer)
        If bit = 0 Then
            If RestrciMode Then
                lblEditMessage.Text = "In this mode you can not make any changes. To update select Show School Faculty from Top Menu."
            Else
                lblEditMessage.Text = "To Update or Delete any record - Double click that record."
            End If

            lblEditMessage.BackColor = Color.Transparent
            IsEditMode = False
            btFrmTeacher_Save.Visible = True
            btFrmTeacher_Update.Visible = False
            btResetNew.Visible = False
            Button1.Visible = False  ' For Button Delete
            ShowTeahers(_Faculty_School, _Faculty_Status)

        Else
            If RestrciMode Then
                MsgBox("Changes not Allowed. Select SHOW SCHOOL FACULTY from top menu to make any changes in your school.")
            End If
            lblEditMessage.Text = "You can go to previous state. Click GO BACK Button."
            lblEditMessage.BackColor = Color.Wheat
            IsEditMode = True
            btFrmTeacher_Save.Visible = False
            btFrmTeacher_Update.Visible = True
            btResetNew.Visible = True
            Button1.Visible = True
        End If
    End Sub

    Private Function GetAbbr(ByVal Word As String)
        Dim initials As String = ""
        Try
            Dim _words As String() = Word.Split()
            For Each _word As String In _words
                initials &= _word(0)
            Next
        Catch ex As Exception

        End Try
        Return initials
    End Function

    Private Sub txtFacultyName_TextChanged(sender As Object, e As EventArgs) Handles txtFacultyName.TextChanged
        txtAbbr.Text = GetAbbr(txtFacultyName.Text)
        If Not IsEditMode Then search()
    End Sub

    Private Sub btFrmTeacher_Save_Click(sender As Object, e As EventArgs) Handles btFrmTeacher_Save.Click
        Dim cmd As New SqlCommand
        Dim _Tname As String = txtFacultyName.Text.Trim
        Dim _Tabbr As String = txtAbbr.Text.Trim
        Dim _Tschool As String = ""
        Dim _Tdept As String = ""
        If chkDept_NO.Checked Then
            _Tdept = "NA"
        Else
            If cbDept.Text = "" Then
                MsgBox("Choose Department!")
                Exit Sub
            Else
                _Tdept = cbDept.Text.Trim
            End If

        End If

        If cbSchool.Text = "" Then
            MsgBox("Choose School!")
            Exit Sub
        Else
            _Tschool = cbSchool.Text.Trim()
        End If
        Dim _Tstatus As String = 0
        If _Faculty_Status = -1 Then
            MsgBox("Choose Teacher State - REGULAR or GUEST FACULTY Only!")
            Exit Sub
        Else
            _Tstatus = _Faculty_Status
        End If
        cmd.CommandText = "INSERT INTO TEACHER (name, abbr, school, department,status)" & _
                          "VALUES ('" & _Tname & "', '" & _Tabbr & "','" & _Tschool & "','" & _Tdept & "','" & _Tstatus & "')"
        cmd.Connection = cn

        If Not (cn.State = ConnectionState.Open) Then cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        ShowTeahers(_Faculty_School, _Faculty_Status)
    End Sub

    Private Sub dgvTeacher_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTeacher.CellContentDoubleClick
        If Not RestrciMode Then EnableEditMode()
    End Sub

    Private Sub dgvTeacher_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvTeacher.DataBindingComplete
        With dgvTeacher
            .Columns("Id").Visible = False
            .Columns("Status").Visible = False
        End With
        dgvTeacher.Refresh()
    End Sub

    Private Sub btFrmTeacher_Update_Click(sender As Object, e As EventArgs) Handles btFrmTeacher_Update.Click
        Dim cmd As New SqlCommand
        Dim _Tname As String = txtFacultyName.Text.Trim
        Dim _Tabbr As String = txtAbbr.Text.Trim
        Dim _Tschool As String = ""
        Dim _Tdept As String = ""
        Dim _TId As String = 0



        If txtId.Text = "" Then
            MsgBox("Which Faculty is to be updated? To select a teacher click on header before name.")
            Exit Sub
        Else
            _TId = Int(txtId.Text.Trim)
        End If


        'If String.IsNullOrEmpty(pd_first_name.Text.ToString().Trim) = True Then
        '    frmFirstName = DBNull.Value
        'Else
        '    frmFirstName = pd_first_name.Text
        'End If


        If chkDept_NO.Checked Then
            _Tdept = "NA"
        Else
            If cbDept.Text = "" Then
                MsgBox("Choose Department!")
                Exit Sub
            Else
                _Tdept = cbDept.Text.Trim
            End If

        End If

        If cbSchool.Text = "" Then
            MsgBox("Choose School!")
            Exit Sub
        Else
            _Tschool = cbSchool.Text.Trim()
        End If
        Dim _Tstatus As String = 0

        If _Faculty_Status = -1 Then
            MsgBox("Choose Teacher State - REGULAR or GUEST FACULTY Only!")
            Exit Sub
        Else
            _Tstatus = _Faculty_Status
        End If

        cmd.CommandText = "UPDATE TEACHER " & _
                          "SET name='" & _Tname & "', abbr='" & _Tabbr & "', school='" & _Tschool & "', department='" & _Tdept & "',status=" & _Tstatus & _
                          "WHERE Id=" & _TId

        cmd.Connection = cn

        If Not (cn.State = ConnectionState.Open) Then cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        ResetEditMode(0)
    End Sub

    Private Sub btResetNew_Click(sender As Object, e As EventArgs) Handles btResetNew.Click
        ResetEditMode(0)
    End Sub
    Private Sub search()
        Dim bs As New BindingSource
        dv.RowFilter = "name like '%" & txtFacultyName.Text.Trim & "%'"
        dgvTeacher.DataSource = dv
    End Sub

    Private Sub dgvTeacher_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvTeacher.RowHeaderMouseDoubleClick
        If Not RestrciMode Then EnableEditMode()
    End Sub

    Private Sub EnableEditMode()
        Try
            txtFacultyName.Text = dgvTeacher.CurrentRow.Cells.Item("name").Value
            txtAbbr.Text = dgvTeacher.CurrentRow.Cells.Item("abbr").Value
            txtId.Text = dgvTeacher.CurrentRow.Cells.Item("Id").Value
            cbSchool.Text = dgvTeacher.CurrentRow.Cells.Item("school").Value

            If IsDBNull(dgvTeacher.CurrentRow.Cells.Item("department").Value) Then
                cbDept.Text = String.Empty
            Else
                cbDept.Text = dgvTeacher.CurrentRow.Cells.Item("department").Value
            End If

            ResetEditMode(1)
            Select Case dgvTeacher.CurrentRow.Cells.Item("status").Value
                Case 0
                    rb_Faculty_Status_Regular.Checked = True

                Case 1
                    rb_Faculty_Status_Guest.Checked = True

                Case Else
                    rb_Faculty_Status_Regular.Checked = True

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
            ShowTeahers(_Faculty_School, _Faculty_Status)
        End Try
        search()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As New SqlCommand
        Dim _TId As Integer = 0
        Dim res As MsgBoxResult
        res = MsgBox("Are you sure to delete" + UCase(txtFacultyName.Text) + "?", MsgBoxStyle.YesNo)
        If res = MsgBoxResult.No Then
            Exit Sub
        End If

        If txtId.Text = "" Then
            MsgBox("Which Faculty is to be deleted? To select a teacher click on header before name.")
            Exit Sub
        Else
            _TId = Int(txtId.Text.Trim)
        End If

        cmd.CommandText = "DELETE FROM TEACHER WHERE Id=" & _TId

        cmd.Connection = cn

        If Not (cn.State = ConnectionState.Open) Then cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        ResetEditMode(0)
    End Sub

    Private Sub frmTeacher_Menu_Filter_Click(sender As Object, e As EventArgs) Handles frmTeacher_Menu_Filter.Click
        ResetEditMode(0)
        ShowTeahers(, _Faculty_Status)
        RestrciMode = True
        lblEditMessage.Text = "In this mode you can not make any changes. To update select Show School Faculty from Top Menu."
    End Sub

    Private Sub ShowSchoolFacultyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowSchoolFacultyToolStripMenuItem.Click
        'ShowTeahers(_school, _Faculty_Status)
        ShowTeahers(cbSchool.Text.Trim, _Faculty_Status)
        RestrciMode = False
        lblEditMessage.Text = "To Update or Delete any record - Double click that record."
    End Sub
End Class