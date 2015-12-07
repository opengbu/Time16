Imports System.Data.SqlClient
Imports System.IO

Module Timetable
    Dim ts(7, 10) As String
    Dim maxP As Integer = 10
    Dim maxD As Integer = 7
    Dim tsd(7, 10) As Integer
    Dim tss(7, 10) As Integer
    Dim docstr As String = ""

    Sub HTMLByFacultyId(ByVal Facid As Integer)
        Array.Clear(ts, 0, 88)
        Array.Clear(tss, 0, 88)
        Array.Clear(tsd, 0, 88)

        If Facid = 0 Then Exit Sub

        Dim cn As New SqlConnection
        '  Dim cn2 As New SqlConnection

        cn.ConnectionString = My.Settings.conn
        '  cn2.ConnectionString = My.Settings.conn

        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader

        cmd.CommandText = "SELECT  csf_id, TT_Day, TT_Period, Subject_Code, Section_Name, Room, Batch_Id,name FROM dbo.V_Timetable_2013 " _
                        & "WHERE Faculty_Id = @ID;"

        cmd.Parameters.Add("@ID", SqlDbType.Int)
        cmd.Parameters("@ID").Value = Facid

        cmd.Connection = cn
        cn.Open()
        rd = cmd.ExecuteReader()
        Dim LTP As String
        Dim tsval As String = ""
        Dim _clsName As String

        While (rd.Read)
            Select Case rd.Item("Batch_Id")
                Case 1
                    LTP = "[G1]"
                Case 2
                    LTP = "[G2]"
                Case Else
                    LTP = ""
            End Select
            _clsName = rd.Item("section_name").ToString.Trim

            ts.SetValue(rd.Item("name"), 0, 0)
            If Not ts(rd.Item("TT_Day"), rd.Item("TT_Period")) = Nothing Then
                If InStr(ts(rd.Item("TT_Day"), rd.Item("TT_Period")), rd.Item("Subject_Code").ToString.Trim) > 0 And InStr(ts(rd.Item("TT_Day"), rd.Item("TT_Period")), rd.Item("Room").ToString.Trim) > 0 Then
                    ts.SetValue(ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & ", <b>" & _clsName & "</b>", rd.Item("TT_Day"), rd.Item("TT_Period"))
                Else
                    ts.SetValue(ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<br></br>" & (rd.Item("Subject_Code") & " " & LTP) & vbCrLf & rd.Item("Room") & vbCrLf & _clsName, rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If
            Else
                ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & rd.Item("Room") & vbCrLf & _clsName, rd.Item("TT_Day"), rd.Item("TT_Period"))
            End If
        End While
    End Sub

    Function GetTimetableByFacultyId(ByVal Facid As Integer)
        Dim str = ""
        Try

            Dim strp As String = ""
            HTMLByFacultyId(Facid)

            Str = ""
            str += "<html><head><title id='tMain'>Timetables::" & Facid.ToString & "</title> " _
                & "<style>" & My.Resources.screencss & "</style>" _
                & "<link href='print.css' rel='stylesheet' type='text/css' media='print' />" _
                & "</head>"
            Str += "<body><table>"
            daytime()
            For i = 0 To maxD
                Str += "<tr>"
                For j = 0 To maxP
                    If tsd(i, j) = 0 Then
                        Str += "<td class='tttd'>" + ts(i, j) + "</td>"
                    Else
                        If tss(i, j) = 0 Then
                            'str += "<td class='tttd'>" + ts(i, j) + ":" + tss(i, j).ToString + "</td>"
                            Str += "<td class='tttd' colspan='" + tsd(i, j).ToString + "'>" + ts(i, j) + "</td>"
                            j = j + tsd(i, j) - 1
                        Else
                            'str += "<td class='tttd' colspan='" + tss(i, j).ToString + "'>" + ts(i, j) + "</td>"
                        End If

                    End If

                Next
                Str += "</tr>"
            Next
            Str += "</table>"
            '+ "<div>" + tblFooter + "</div>" + "<div class='Weblink'>SAVE PAPER: This timetable is available at http://portal.gbuonline.in/timetables </div>"
            Str += "</body></html>"

            ' docstr += str & "<br><br><br>" & ts(0, 0) & "<br>"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return str
    End Function
    Sub WriteToFile(ByVal content As String, ByVal filename As String, Optional ByVal Online As Boolean = False)
        Try
            Dim w As StreamWriter
            w = File.CreateText(filename)
            w.Write(content)
            w.Flush()
            w.Close()
            If Online Then UploadOnline(filename)
            'MsgBox(filename)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub daytime()
        ts(0, 1) = "08:30-09:30"
        ts(0, 2) = "09:30-10:30"
        ts(0, 3) = "10:30-11:30"
        ts(0, 4) = "11:30-12:30"
        ts(0, 5) = "12:30-01:30"
        ts(0, 6) = "01:30-02:30"
        ts(0, 7) = "02:30-03:30"
        ts(0, 8) = "03:30-04:30"
        ts(0, 9) = "04:30-05:30"
        ts(0, 10) = "05:30-06:30"
        ts(1, 0) = "MON"
        ts(2, 0) = "TUE"
        ts(3, 0) = "WED"
        ts(4, 0) = "THU"
        ts(5, 0) = "FRI"
        ts(6, 0) = "SAT"
        ts(7, 0) = "SUN"
    End Sub

    Function UploadOnline(ByVal filename As String)
        Dim tmppath As String = Path.GetTempPath()
        Try
            If filename = "" Then
                MsgBox("Nothing to do.")
            Else
                Dim ftpclient = New ftp("ftp://172.25.5.15", "awasthi", "tuajlkkl")
                'Dim currFileNamerev As String = filename.Split(".")(0) + "_" + Now.Ticks.ToString + ".htm"
                'Try
                '    'ftpclient.download("\timetables\2015\E\" + filename, tmppath + "tmp.htm")
                '    ftpclient.upload("\timetables\2015\E\rev\" + currFileNamerev, tmppath + "tmp.htm")
                'Catch ex As Exception

                'End Try
                If (filename.Contains("/")) Then
                    filename = tmppath + filename
                End If
                Try
                    ftpclient.upload("\timetables\2015\E\" + filename, filename)
                Catch ex As Exception
                    MsgBox(Err.Description)
                    Return "Error"
                End Try
            End If

        Catch ex As Exception

        End Try
        Return 1
    End Function

    

End Module
