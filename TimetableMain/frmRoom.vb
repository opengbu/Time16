Imports System.Data.SqlClient

Public Class frmRoom
    'Private dataGridView1 As New DataGridView()
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    'Private WithEvents reloadButton As New Button()
    'Private WithEvents submitButton As New Button()
    Private Sub frmRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ECollegeDataSet.School' table. You can move, or remove it, as needed.
        Me.SchoolTableAdapter.Fill(Me.ECollegeDataSet.School)
        'TODO: This line of code loads data into the 'ECollegeDataSet.M_Room' table. You can move, or remove it, as needed.
        Me.M_RoomTableAdapter.Fill(Me.ECollegeDataSet.M_Room)
        'TODO: This line of code loads data into the 'ECollegeDataSet.Subject' table. You can move, or remove it, as needed.
        ' Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        'Dim row As DataGridViewRow = Me.DataGridView1.RowTemplate
        'row.DefaultCellStyle.BackColor = Color.LightYellow
        'row.Height = 25
        'row.MinimumHeight = 20
        Try
            Me.DataGridView1.DataSource = Me.bindingSource1
        Catch ex As Exception

        End Try

        GetData("Select * From M_Room")

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

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        ' Update the database with the user's changes. 
        Me.dataAdapter.Update(CType(Me.bindingSource1.DataSource, DataTable))
        GetData(Me.dataAdapter.SelectCommand.CommandText)
    End Sub

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel2.Click
        ' Reload the data from the database.
        GetData(Me.dataAdapter.SelectCommand.CommandText)
    End Sub
End Class