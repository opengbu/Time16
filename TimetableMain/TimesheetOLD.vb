Imports System.Data.SqlClient
Public Class Timesheet
    Dim sQry As String = ""
    Public Sub UpdateCSF(ByVal sub_code, ByVal sub_name)
        Try
            sQry = "INSERT INTO Subject ([code] ,[name])  VALUES ('" & sub_code & "' ,'" & sub_name & "' )"
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString
            cn.Open()
            ' MsgBox(sQry)
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub ImportFET(ByVal str As String)

        Try
            'TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students
            sQry = "INSERT INTO TimeTableImportFET (TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students,Batch)  VALUES ('" & str.Split(",")(0) & "' ,'" & str.Split(",")(1) & "' ,'" & str.Split(",")(2) & "' ,'" & str.Split(",")(3) & "' ,'" & str.Split(",")(4) & "' ,'" & str.Split(",")(5) & "','" & 0 & "')"
            If InStr(str.Split(",")(5), "G1") <> 0 Then
                sQry = "INSERT INTO TimeTableImportFET (TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students,Batch)  VALUES ('" & str.Split(",")(0) & "' ,'" & str.Split(",")(1) & "' ,'" & str.Split(",")(2) & "' ,'" & str.Split(",")(3) & "' ,'" & str.Split(",")(4) & "' ,'" & str.Split(",")(5).Substring(0, Len(str.Split(",")(5)) - 3) & "','" & 1 & "')"
            End If
            If InStr(str.Split(",")(5), "G2") <> 0 Then
                sQry = "INSERT INTO TimeTableImportFET (TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students,Batch)  VALUES ('" & str.Split(",")(0) & "' ,'" & str.Split(",")(1) & "' ,'" & str.Split(",")(2) & "' ,'" & str.Split(",")(3) & "' ,'" & str.Split(",")(4) & "' ,'" & str.Split(",")(5).Substring(0, Len(str.Split(",")(5)) - 3) & "','" & 2 & "')"
            End If

            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString
            cn.Open()
            ' MsgBox(sQry)
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then cn.Close()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)

        End Try
    End Sub

End Class

