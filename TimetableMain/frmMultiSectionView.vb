Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class frmMultiSectionView
    Dim cn As New SqlConnection
    Private Sub frmMultiSectionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ECollegeDataSet.Section' table. You can move, or remove it, as needed.
        Me.SectionTableAdapter.Fill(Me.ECollegeDataSet.Section)

    End Sub

    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        TextBox1.Text = ""
        For Each x In ListBox1.SelectedItems
            If TextBox1.Text = "" Then
                TextBox1.Text = x(0).ToString
            Else
                TextBox1.Text = TextBox1.Text & ", " & x(0).ToString
            End If
        Next

        Dim sqry = "SELECT Section_Id, TT_Day, TT_Period FROM M_Time_Table WHERE (Section_Id IN (" & TextBox1.Text & "))"
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(sqry, cn)
        Dim ad As SqlDataReader
        ad = cmd.ExecuteReader
        Do While ad.Read
            frmMain.TTAdd(ad.Item("TT_Day"), ad.Item("TT_Period"), "X")
        Loop
        cn.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 0 To frmMain.TableLayoutPanel1.Controls.Count - 1
            frmMain.TableLayoutPanel1.Controls.Item(i).Text = ""
        Next
    End Sub
End Class