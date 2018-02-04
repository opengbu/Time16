Imports System.Data.SqlClient

Public Class frmPrograms
    Dim cmd As SqlCommand
    Dim adapt As SqlDataAdapter
    Dim ID As Integer = 0
    Dim myDataTable As DataTable
    Dim searchmode As Boolean = False
    Private dt As New DataTable
    Dim adap As SqlDataAdapter
    Dim cmdBuilder As SqlCommandBuilder

    Private Sub frmPrograms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dts As New DataTable
        cmd.Connection = cn
        cmd.CommandText = "Select * from M_School"
        cmd.CommandType = CommandType.Text
        adapter.SelectCommand = cmd
        adapter.Fill(dts)
        cbSchool.DataSource = dts
        cbSchool.ValueMember = "Code"
        cbSchool.DisplayMember = "Code"
        'adap.UpdateCommand = ""
    End Sub

    Private Sub DisplayPrograms()
        myDataTable = dt
        myDataTable.Clear()
        adap = New SqlDataAdapter("SELECT id, Code, Name, IsActive,school FROM Program WHERE school='" & cbSchool.SelectedValue.ToString & "' order by Id DESC", cn)
        adap.Fill(dt)
        dgvPrograms.DataSource = dt
    End Sub

    Private Sub cbSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSchool.SelectedIndexChanged
        DisplayPrograms()
    End Sub



    Private Sub UpdateData(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrograms.CellEndEdit
        cmdBuilder = New SqlCommandBuilder(adap)
        adap.Update(dt)
    End Sub
End Class