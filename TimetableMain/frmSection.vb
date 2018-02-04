Imports System.Data.SqlClient

Public Class frmSection
    Dim _editMode As Boolean = False
    'Private dataGridView1 As New DataGridView()
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    'Private WithEvents reloadButton As New Button()
    'Private WithEvents submitButton As New Button()
    Dim schoolname As String = Module1._school
    Private Sub frmSection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        userinfo.Text = UCase(schoolname)

        'TODO: This line of code loads data into the 'ECollegeDataSet.Program' table. You can move, or remove it, as needed.
        If schoolname = "all" Then
            Me.ProgramTableAdapter.Fill(Me.ECollegeDataSet.Program)
        Else
            Me.ProgramTableAdapter.FillBy(Me.ECollegeDataSet.Program, schoolname)
        End If
        cbProgram.Refresh()

        'TODO: This line of code loads data into the 'ECollegeDataSet.Section' table. You can move, or remove it, as needed.
        Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)
        'TODO: This line of code loads data into the 'ECollegeDataSet.Subject' table. You can move, or remove it, as needed.
        ' Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        'Dim row As DataGridViewRow = Me.DataGridView1.RowTemplate
        'row.DefaultCellStyle.BackColor = Color.LightYellow
        'row.Height = 25
        'row.MinimumHeight = 20



        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData("Select * From Section Where Program=" & cbProgram.SelectedValue)

    End Sub

    Private Sub GetData(ByVal selectCommand As String)

        Try
            ' Specify a connection string. Replace the given value with a  
            ' valid connection string for a Northwind SQL Server sample 
            ' database accessible to your system. 
            Dim connectionString As String = _
                My.Settings.eCollegeConnectionString1

            ' Create a new data adapter based on the specified query. 
            Me.dataAdapter = New SqlDataAdapter(selectCommand, connectionString)

            ' Create a command builder to generate SQL update, insert, and 
            ' delete commands based on selectCommand. These are used to 
            ' update the database. 
            Dim commandBuilder As New SqlCommandBuilder(Me.dataAdapter)

            ' Populate a new data table and bind it to the BindingSource. 
            Dim table As New DataTable()
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            Me.dataAdapter.Fill(table)
            Me.bindingSource1.DataSource = table

            ' Resize the DataGridView columns to fit the newly loaded content. 
            ' Me.dataGridView1.AutoResizeColumns( _
            '    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
        Catch ex As SqlException
            MessageBox.Show("To run this example, replace the value of the " + _
                "connectionString variable with a connection string that is " + _
                "valid for your system.")
        End Try
    End Sub


    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click
        ' Reload the data from the database.
        GetData(Me.dataAdapter.SelectCommand.CommandText)
    End Sub

    Private Sub btnAddSection_Click(sender As Object, e As EventArgs) Handles btnAddSection.Click
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        Dim cmd As New SqlCommand
        cmd.CommandText = "Insert Into Section (Name, Semester, ShowTimeTable, Program) Values ('" & txtSection.Text.ToUpper & "',1,1," & cbProgram.SelectedValue & ")"
        cmd.Connection = cn
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        'GetData(Me.dataAdapter.SelectCommand.CommandText)
        Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)
    End Sub


    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If _editMode = False Then
            _editMode = Not _editMode

            txtSection.Enabled = False
            cbProgram.Enabled = False
            btnAddSection.Enabled = False
            Me.btnEdit.Text = "Disable Edit Mode"
            DataGridView1.Visible = True
            DataGridView1.Enabled = True
            DataGridView1.Dock = DockStyle.Fill
            SectionDataGridView.Visible = False
            GetData("Select * From Section Where Program=" & cbProgram.SelectedValue)
        Else
            _editMode = Not _editMode
            Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)

            txtSection.Enabled = True
            cbProgram.Enabled = True
            btnAddSection.Enabled = True
            Me.btnEdit.Text = "Enable Edit Mode"
            DataGridView1.Visible = False
            DataGridView1.Enabled = False
            DataGridView1.Dock = DockStyle.Fill
            SectionDataGridView.Visible = True
            GetData("Select * From Section Where Program=" & cbProgram.SelectedValue)

        End If

    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ' Update the database with the user's changes. 
        Me.dataAdapter.Update(CType(Me.bindingSource1.DataSource, DataTable))
        'Me.dataAdapter.Update(CType(Me.ProgramBS.DataSource, DataTable))
        GetData(Me.dataAdapter.SelectCommand.CommandText)
    End Sub
End Class