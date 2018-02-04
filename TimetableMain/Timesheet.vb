Imports System.Data.SqlClient
Public Class Timesheet
    Dim sQry As String = ""
    Public Sub UpdateCSF(ByVal sub_code, ByVal sub_name, L, T, P, isLab1)
        Try

            sQry = "INSERT INTO Subject ([code] ,[name],L,T,P)  VALUES ('" & sub_code & "' ,'" & sub_name & "'," & L & "," & T & "," & P & ")"
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
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
        Dim _room As String
        'If str.Split(",").Count = 5 Then
        '    _room = "VL-204"
        'Else
        _room = str.Split(",")(6)
        'End If
        Try
            'TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students
            sQry = "INSERT INTO TimeTableImportFET (TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students,Room,Batch)  VALUES ('" & str.Split(",")(0) & "' ,'" & str.Split(",")(1) & "' ,'" & str.Split(",")(2) & "' ,'" & str.Split(",")(3) & "' ,'" & str.Split(",")(4) & "' ,'" & str.Split(",")(5) & "','" & _room & "','" & 0 & "')"
            If InStr(str.Split(",")(5), "G1") <> 0 Then
                sQry = "INSERT INTO TimeTableImportFET (TeacherName, DayName, HourName, SubjectCode, ActivityTag,Room, Students,Batch)  VALUES ('" & str.Split(",")(0) & "' ,'" & str.Split(",")(1) & "' ,'" & str.Split(",")(2) & "' ,'" & str.Split(",")(3) & "' ,'" & str.Split(",")(4) & "','" & str.Split(",")(6) & "' ,'" & str.Split(",")(5).Substring(0, Len(str.Split(",")(5)) - 3) & "','" & 1 & "')"
            End If
            If InStr(str.Split(",")(5), "G2") <> 0 Then
                sQry = "INSERT INTO TimeTableImportFET (TeacherName, DayName, HourName, SubjectCode, ActivityTag,Room, Students,Batch)  VALUES ('" & str.Split(",")(0) & "' ,'" & str.Split(",")(1) & "' ,'" & str.Split(",")(2) & "' ,'" & str.Split(",")(3) & "' ,'" & str.Split(",")(4) & "', '" & str.Split(",")(6) & "' ,'" & str.Split(",")(5).Substring(0, Len(str.Split(",")(5)) - 3) & "','" & 2 & "')"
            End If

            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            cn.Open()
            ' MsgBox(sQry)
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()

            If cn.State = ConnectionState.Open Then cn.Close()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)

        End Try

    End Sub

    Sub ImportStart()
        Try
            Dim sqrydel
            sqrydel = "Delete From TimeTableImportFET"
            Dim rr
            rr = MsgBox("Sure to import", MsgBoxStyle.OkCancel)
            If rr = MsgBoxResult.Ok Then
                Dim cn As New SqlConnection
                cn.ConnectionString = My.Settings.eCollegeConnectionString1
                cn.Open()
                ' MsgBox(sQry)
                Dim cmd1 As New SqlCommand(sqrydel, cn)
                cmd1.ExecuteNonQuery()

                If cn.State = ConnectionState.Open Then cn.Close()
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)

        End Try
    End Sub
    Sub ImportFinal()
        Try
            Dim sqrydel
            'TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students
            sQry = "INSERT INTO M_Time_Table Select * From vImportFET"
            sqrydel = "Delete From M_time_table"
            Dim rr
            rr = MsgBox("Delete Previous Timetable", MsgBoxStyle.OkCancel)
            If rr = MsgBoxResult.Ok Then
                Dim cn As New SqlConnection
                cn.ConnectionString = My.Settings.eCollegeConnectionString1
                cn.Open()
                ' MsgBox(sQry)
                Dim cmd1 As New SqlCommand(sqrydel, cn)
                cmd1.ExecuteNonQuery()
                Dim cmd As New SqlCommand(sQry, cn)
                cmd.ExecuteNonQuery()

                If cn.State = ConnectionState.Open Then cn.Close()
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)

        End Try
    End Sub
    Sub ImportFinal(section)
        Try
            Dim sqrydel
            'TeacherName, DayName, HourName, SubjectCode, ActivityTag, Students
            sQry = "INSERT INTO M_Time_Table Select * From vImportFET where section_id=" & section
            sqrydel = "Delete From M_time_table where section_id=" & section
            Dim rr
            rr = MsgBox("Delete Previous Timetable", MsgBoxStyle.OkCancel)
            If rr = MsgBoxResult.Ok Then
                Dim cn As New SqlConnection
                cn.ConnectionString = My.Settings.eCollegeConnectionString1
                cn.Open()
                ' MsgBox(sQry)
                Dim cmd1 As New SqlCommand(sqrydel, cn)
                cmd1.ExecuteNonQuery()
                Dim cmd As New SqlCommand(sQry, cn)
                cmd.ExecuteNonQuery()

                If cn.State = ConnectionState.Open Then cn.Close()
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)

        End Try
    End Sub

    Sub RoomUpdate(i As Integer, j As Integer, dgv As DataGridView)
        'Dim da = TableLayoutPanel1.GetRow(sender) + 1
        'Dim pr = TableLayoutPanel1.GetColumn(sender) + 1
        Dim da = i
        Dim pr = j
        Dim sQry = ""
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1

        'If chkLabs.Checked = True Then
        'sQry = "SELECT room_id ,name  FROM M_Room where islab=1 and (roomtype<3) EXCEPT SELECT Room_Id,Room FROM V_TimeTable_2013 WHERE (TimeTableId = " & My.Settings.TTid & ") AND (TT_Day = " & da & ") AND (TT_Period = " & pr & ") order by Name"
        'Else
        sQry = "SELECT room_id ,name  FROM M_Room  where  (roomtype<3)  EXCEPT SELECT Room_Id,Room FROM V_TimeTable_2013 WHERE (TimeTableId = " & My.Settings.TTid & ") AND (TT_Day = " & da & ") AND (TT_Period = " & pr & ") order by Name"
        'End If
        'MsgBox(sQry)
        'Dim cn As New SqlConnection
        cn.Open()

        Dim cmd As New SqlCommand(sQry, cn)

        'cmd.Parameters.Add(1)
        Dim ad As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        ad.Fill(ds)
        dgv.DataSource = ds.Tables(0)
        dgv.Columns(0).Visible = False
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Sub RoomUpdate(i As Integer, j As Integer, school As String, dgv As DataGridView)
        'Dim da = TableLayoutPanel1.GetRow(sender) + 1
        'Dim pr = TableLayoutPanel1.GetColumn(sender) + 1
        Dim da = i
        Dim pr = j
        Dim sQry = ""
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1

        'If chkLabs.Checked = True Then
        'sQry = "SELECT room_id ,name  FROM M_Room where islab=1 and (roomtype<3) EXCEPT SELECT Room_Id,Room FROM V_TimeTable_2013 WHERE (TimeTableId = " & My.Settings.TTid & ") AND (TT_Day = " & da & ") AND (TT_Period = " & pr & ") order by Name"
        'Else
        sQry = "SELECT room_id ,name  FROM M_Room  where Building='" & school & "' and (roomtype<3)  EXCEPT SELECT Room_Id,Room FROM V_TimeTable_2013 WHERE (TimeTableId = " & My.Settings.TTid & ") AND (TT_Day = " & da & ") AND (TT_Period = " & pr & ") order by Name"
        'End If
        'MsgBox(sQry)
        'Dim cn As New SqlConnection
        cn.Open()

        Dim cmd As New SqlCommand(sQry, cn)

        'cmd.Parameters.Add(1)
        Dim ad As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            ad.Fill(ds)
            dgv.DataSource = ds.Tables(0)
            dgv.Columns(0).Visible = False
        Catch ex As Exception

        End Try
        
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Sub DeleteTTSlot(TTDay As Integer, TTPeriod As Integer, Sheet As Object, _section As Integer, _csf As Integer, _room As Integer, _Batch As Integer)
        Dim result
        If My.Settings.DeleteConfirm = True Then
            result = MessageBox.Show("Are you sure to delete?", "Time Table 2010", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Else
            result = Windows.Forms.DialogResult.Yes
        End If
        If result = Windows.Forms.DialogResult.Yes Then
            Dim TTId As Integer = My.Settings.TTid
            Sheet.GetControlFromPosition(TTPeriod - 1, TTDay - 1).BackColor = Color.White
            Dim Sectionid As Integer = _section
            Dim CSF_ID As Integer = _csf
            Dim RooM_ID As Integer = _room
            Dim BATCHID As Integer = _Batch
            Dim ISDEL As Integer = 1
            Dim sQry = "Exec Timetablemanager @TTId=" & TTId & ",@TTDay=" & TTDay & ",@TTPeriod=" & TTPeriod & ",@Sectionid=" & Sectionid & ",@CSF_ID= " & CSF_ID & ", @RooM_ID=" & RooM_ID & ",@BATCHID=" & BATCHID & ",@ISDEL=" & ISDEL
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then cn.Close()
        Else
            Exit Sub
        End If
    End Sub
End Class

