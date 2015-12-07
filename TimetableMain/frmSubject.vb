Imports System.Data.SqlClient

Public Class frmSubject
    Private bindingSource1 As New BindingSource()
    Private dataAdapter As New SqlDataAdapter()
    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)
        Me.DataGridView1.DataSource = Me.bindingSource1
        GetData("Select * From Subject")
    End Sub

    Private Sub GetData(ByVal selectCommand As String)

        Try
            ' Specify a connection string. Replace the given value with a  
            ' valid connection string for a Northwind SQL Server sample 
            ' database accessible to your system. 
            Dim connectionString As String = _
                My.Settings.eCollegeConnectionString

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