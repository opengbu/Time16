Imports System.Data.SqlClient

Public Class DBUtilities
    Private _cn As New SqlConnection
    Public Sub New()
        Try
            _cn.ConnectionString = My.Settings.eCollegeConnectionString1
            _cn.Open()
        Catch ex As Exception
        End Try
    End Sub

    Public Function getConnection() As SqlConnection
        Return _cn
    End Function

    Public Sub ExecuteSQLStatement(SqlStatement As String)
        Try
            Dim cmd As SqlCommand = New SqlCommand(SqlStatement, _cn)
            cmd.ExecuteScalar()
        Catch ex As Exception

        End Try
    End Sub
End Class
