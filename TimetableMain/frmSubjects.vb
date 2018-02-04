Imports System.Data.SqlClient

Public Class frmSubjects
    Dim cmd As SqlCommand
    Dim adapt As SqlDataAdapter
    Dim ID As Integer = 0
    Dim myDataTable As DataTable
    Dim searchmode As Boolean = False

    Private Sub frmSubjects_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'ECollegeDataSet.School' table. You can move, or remove it, as needed.
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dts As New DataTable
        ' cn.ConnectionString = ("Data Source=NIMO-HP\SQLEXPRESS;Initial Catalog=FYP_db;Integrated Security=True")

        cmd.Connection = cn
        cmd.CommandText = "Select * from M_School"
        cmd.CommandType = CommandType.Text
        adapter.SelectCommand = cmd
        adapter.Fill(dts)
        cbSchool.DataSource = dts
        cbSchool.ValueMember = "Code"
        cbSchool.DisplayMember = "Code"
    End Sub

    Private Sub DisplayData()
        Dim dt As DataTable = New DataTable()
        myDataTable = dt
        Dim adap As SqlDataAdapter = New SqlDataAdapter("select * from Subject where dept='" & cbDept.SelectedValue.ToString & "' order by Id DESC", cn)
        adap.Fill(dt)
        dgvSubject.DataSource = dt
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubject.CellClick
        If (txtSubjectCode.DataBindings.Count > 0) Then
            txtSubjectCode.DataBindings.RemoveAt(0)
            txtSubjectName.DataBindings.RemoveAt(0)
            txtL.DataBindings.RemoveAt(0)
            txtP.DataBindings.RemoveAt(0)
            txtT.DataBindings.RemoveAt(0)
            chkLab.DataBindings.RemoveAt(0)
        End If
        Try
            If e.RowIndex <> -1 Then
                txtSubjectCode.DataBindings.Add(New Binding("Text", dgvSubject(1, e.RowIndex), "Value", False))
                txtSubjectName.DataBindings.Add(New Binding("Text", dgvSubject(2, e.RowIndex), "Value", False))
                chkLab.DataBindings.Add(New Binding("Checked", dgvSubject(3, e.RowIndex), "Value", False))
                txtL.DataBindings.Add(New Binding("Text", dgvSubject(4, e.RowIndex), "Value", False))
                txtT.DataBindings.Add(New Binding("Text", dgvSubject(5, e.RowIndex), "Value", False))
                txtP.DataBindings.Add(New Binding("Text", dgvSubject(6, e.RowIndex), "Value", False))
                ID = Convert.ToInt32(dgvSubject.Rows(e.RowIndex).Cells(0).Value.ToString())
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtSubjectCode.Text <> "" And txtSubjectCode.Text <> "" Then
            cmd = New SqlCommand("UPDATE [Subject]
   SET [code] = @code
      ,[name] = @name
      ,[IsLab] = @Lab
      ,[L] = @L
      ,[T] = @T
      ,[P] = @P
      ,[dept] = @dept
       where ID=@id", cn)
            cn.Open()
            cmd.Parameters.AddWithValue("@id", ID)
            cmd.Parameters.AddWithValue("@code", txtSubjectCode.Text)
            cmd.Parameters.AddWithValue("@name", txtSubjectName.Text)
            cmd.Parameters.AddWithValue("@lab", chkLab.Checked)
            cmd.Parameters.AddWithValue("@L", txtL.Text)
            cmd.Parameters.AddWithValue("@T", txtT.Text)
            cmd.Parameters.AddWithValue("@P", txtP.Text)
            cmd.Parameters.AddWithValue("@dept", cbDept.SelectedValue)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Record Updated Successfully")
            cn.Close()
            DisplayData()
            ClearData()
        Else
            MessageBox.Show("Please Select Record to Update")
        End If

    End Sub

    Private Sub ClearData()
        txtSubjectCode.Text = ""
        txtSubjectName.Text = ""
        txtL.Text = ""
        txtT.Text = ""
        txtP.Text = ""
        chkLab.Checked = False


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim deptid = cbDept.SelectedValue

        If txtSubjectCode.Text <> "" And txtSubjectCode.Text <> "" Then
            cmd = New SqlCommand("INSERT INTO [dbo].[Subject]
           ([code]
           ,[name]
           ,[IsLab]
           ,[L]
           ,[T]
           ,[P]
           ,[dept])
     VALUES (@code,@name,@lab,@L,@T,@P,@deptid)", cn)
            cn.Open()
            cmd.Parameters.AddWithValue("@code", txtSubjectCode.Text)
            cmd.Parameters.AddWithValue("@name", txtSubjectName.Text)
            cmd.Parameters.AddWithValue("@lab", chkLab.Checked)
            cmd.Parameters.AddWithValue("@L", txtL.Text)
            cmd.Parameters.AddWithValue("@T", txtT.Text)
            cmd.Parameters.AddWithValue("@P", txtP.Text)
            cmd.Parameters.AddWithValue("@deptid", deptid)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Record Added Successfully")
            cn.Close()
            DisplayData()
            ClearData()
        Else
            MessageBox.Show("Please Select Record to Update")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ID <> 0 Then
            cmd = New SqlCommand("DELETE FROM [Subject] where ID=@id", cn)
            cn.Open()
            cmd.Parameters.AddWithValue("@id", ID)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Record Deleted Successfully")
            cn.Close()
            DisplayData()
            ClearData()
        Else
            MessageBox.Show("Please Select Record to Delete.")
        End If
    End Sub

    Private Sub txtSubjectCode_TextChanged(sender As Object, e As EventArgs) Handles txtSubjectCode.TextChanged
        If searchmode Then
            Dim myDataView As New DataView(myDataTable)
            myDataView.RowFilter = "Code LIKE '%" & txtSubjectCode.Text & "%'"
            myDataView.Sort = "Code"
            dgvSubject.DataSource = myDataView

        End If
        ' dgvSubject.DataBind()
    End Sub

    Private Sub txtSubjectName_TextChanged(sender As Object, e As EventArgs) Handles txtSubjectName.TextChanged

        If searchmode Then
            Dim myDataView As New DataView(myDataTable)
            myDataView.RowFilter = "Name LIKE '%" & txtSubjectName.Text & "%'"
            myDataView.Sort = "Name"
            dgvSubject.DataSource = myDataView

        End If
        ' dgvSubject.DataBind()

    End Sub


    Private Sub cbDept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDept.SelectedIndexChanged
        DisplayData()
    End Sub

    Private Sub txtSubjectCode_Enter(sender As Object, e As EventArgs) Handles txtSubjectCode.Enter
        searchmode = True
    End Sub

    Private Sub txtSubjectName_Enter(sender As Object, e As EventArgs) Handles txtSubjectName.Enter
        searchmode = True
    End Sub



    Private Sub txtSubjectCode_Leave(sender As Object, e As EventArgs) Handles txtSubjectCode.Leave
        searchmode = False
    End Sub

    Private Sub txtSubjectName_Leave(sender As Object, e As EventArgs) Handles txtSubjectName.Leave
        searchmode = False
    End Sub

    Private Sub cbSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSchool.SelectedIndexChanged
        'Dim dtdep As DataTable = New DataTable()
        Dim sqlqry As String = "select Id, '(' + Code + ') ' + name as depname from M_Department Where SchoolCode='" & cbSchool.SelectedValue.ToString & "';"
        'Dim adap1 As SqlDataAdapter = New SqlDataAdapter(sqlqry, cn)
        'adap1.Fill(dtdep)
        'cbDept.DisplayMember = "depname"
        'cbDept.ValueMember = "Id"
        'cbDept.DataSource = dtdep(0)
        'cbDept.Focus()
        ' Me.ProgramTableAdapter.Fill(Me.ECollegeDataSet.Program)
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dtd As New DataTable
        ' cn.ConnectionString = ("Data Source=NIMO-HP\SQLEXPRESS;Initial Catalog=FYP_db;Integrated Security=True")

        cmd.Connection = cn
        cmd.CommandText = sqlqry
        cmd.CommandType = CommandType.Text
        adapter.SelectCommand = cmd
        adapter.Fill(dtd)
        cbDept.DataSource = dtd
        cbDept.ValueMember = "Id"
        cbDept.DisplayMember = "depname"
    End Sub
End Class