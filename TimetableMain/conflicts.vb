Imports System.Data.SqlClient

Public Class conflicts
    Private dataMode As Boolean = True
    Sub ListRoomConflict()
        dataMode = False
        Dim sqlQry = "SELECT Room_id, RTRIM(Room) AS Room, TT_Day, TT_Period" _
                     & " FROM (SELECT COUNT(*) AS cnt,Room_id, Room, TT_Day, TT_Period" _
                     & " FROM [V_TimeTable_2013] WHERE (TimeTableId = " & My.Settings.TTid & ") GROUP BY Room_id,TT_Day, TT_Period, Room) AS derivedtbl_1" _
                     & " WHERE(cnt > 1) ORDER BY Room"

        Dim cn As New SqlConnection

        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(sqlQry, cn)
        Dim ad As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        ad.Fill(ds)
        Try
            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then Exit Sub
        Catch ex As Exception

        End Try

        dgConflict.DataSource = ds.Tables(0)
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Sub ListFacConflict()
        dataMode = True
        Dim sqlQry = "SELECT id, Abr, Name ,  TT_Day, TT_Period" _
           & " FROM (SELECT COUNT(*) AS cnt, id,Abr, Name ,  TT_Day, TT_Period" _
           & " FROM [V_TimeTable_2013] WHERE (TimeTableId = " & My.Settings.TTid & ")  AND (Id <> 602) AND (Id <> 603) GROUP BY TT_Day, TT_Period, id,Abr,name) AS derivedtbl_1" _
           & " WHERE(cnt > 1) ORDER BY id desc"

        Dim cn As New SqlConnection

        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(sqlQry, cn)
        Dim ad As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        ad.Fill(ds)
        Try
            If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then Exit Sub
            dgConflict.DataSource = ds.Tables(0)
            dgConflict.Invalidate()
        Catch ex As Exception

        End Try


        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub

    'Private Sub dgConflict_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    MsgBox(e.RowIndex)
    '    Try
    '        If dataMode = 1 Then FacultySecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value, dgConflict.Item(4, e.RowIndex).Value)
    '        If dataMode = 0 Then RoomSecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(2, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value)
    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Private Sub dgConflict_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    MsgBox(e.RowIndex)
    '    Try
    '        If dataMode = 1 Then FacultySecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value, dgConflict.Item(4, e.RowIndex).Value)
    '        If dataMode = 0 Then RoomSecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(2, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value)
    '    Catch ex As Exception

    '    End Try

    'End Sub
    Sub FacultySecList(ByVal Id As Integer, ByVal ttday As Integer, ByVal ttperiod As Integer)
        'Dim SessionId As Integer = 8

        'Dim sQry = "SELECT distinct subject_code,name,l_load,section_name from V_section_subject_Faculty_1 WHERE (id=" & Id & ") AND (session_id = " & SessionId & ")"
        Dim sQry = "SELECT TimeTableId, CSF_Id,rtrim(Section_Name) as section_name, Subject_Code, Subject, IsLab from [V_Timetable_2013] WHERE (id=" & Id & ") AND (TT_DAY=" & ttday & ") AND (TT_peRIOD=" & ttperiod & ")"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        ' Dim sQry = "SELECT TimeTableId, Section_Id, TT_Day, TT_Period, CSF_Id, Room_Id, Batch_Id, Id, Name, Abr, Subject_Code, Subject, IsLab, Section_Name, Semester, Session_Id, Room, Group_Id, Dept, HOD, Section_Set  FROM [V_TimeTable_2013] WHERE (TimeTableId = " & My.Settings.TTid & ") and (Section_id=" & SectionId & ")"
        Dim cmd As New SqlCommand(sQry, cn)

        'cmd.Parameters.Add(1)
        Dim ad As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        ad.Fill(ds)
        FacultySection.DataSource = ds.Tables(0)
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Sub RoomSecList(ByVal Id As Integer, ByVal ttday As Integer, ByVal ttperiod As Integer)
        ' Dim sQry = "SELECT distinct Room, rtrim(Section_Name) as section_name, Abr, Name FROM [V_TimeTable_2013] " _
        '           & "WHERE (TimeTableId = " & My.Settings.TTid & ") AND (Room_Id = " & Id & ")"
        Dim sQry = "SELECT distinct Room, rtrim(Section_Name) as section_name, Abr, Name FROM [V_TimeTable_2013] " _
                   & "WHERE (TimeTableId = " & My.Settings.TTid & ") AND (Room_Id = " & Id & ") AND (TT_DAY=" & ttday & ") AND (TT_peRIOD=" & ttperiod & ")"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        ' Dim sQry = "SELECT TimeTableId, Section_Id, TT_Day, TT_Period, CSF_Id, Room_Id, Batch_Id, Id, Name, Abr, Subject_Code, Subject, IsLab, Section_Name, Semester, Session_Id, Room, Group_Id, Dept, HOD, Section_Set  FROM [V_TimeTable_2013] WHERE (TimeTableId = " & My.Settings.TTid & ") and (Section_id=" & SectionId & ")"
        Dim cmd As New SqlCommand(sQry, cn)

        'cmd.Parameters.Add(1)
        Dim ad As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        ad.Fill(ds)
        FacultySection.DataSource = ds.Tables(0)
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub

    Private Sub dgConflict_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgConflict.CellClick
        Try
            If dataMode Then
                FacultySecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value, dgConflict.Item(4, e.RowIndex).Value)
            Else
                RoomSecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(2, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value)
            End If

        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub dgConflict_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgConflict.CellEnter
        Try
            If dataMode Then
                FacultySecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value, dgConflict.Item(4, e.RowIndex).Value)
            Else
                RoomSecList(dgConflict.Item(0, e.RowIndex).Value, dgConflict.Item(2, e.RowIndex).Value, dgConflict.Item(3, e.RowIndex).Value)
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class