Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Text

Public Class TTUpload
    Dim uctSign As String = "<br/><br/><div><img src='sign.png' width='150'><br/> University Cordinator, Timetables</div>"
    Dim currFileName As String = ""
    Dim selCom3Changed As Boolean = False
    Dim maxP As Integer = 10
    Dim maxD As Integer = 7
    Dim r(9) As String
    Dim tsExcel(7, 10) As String
    Dim tsHTML(7, 10) As String
    Dim tsHTML2(7, 10) As String
    Dim MyHTMLString As String
    Dim tShowHide(7, 10) As Integer
    Dim tShowHide2(7, 10) As Integer
    Dim IsRowSpan As Boolean = False
    Dim ts(7, 10) As String
    Dim tsb(7, 10) As Integer
    Dim ts1(7, 10) As String
    Dim ts2(7, 10) As String
    Dim tss(7, 10) As Integer
    Dim tsd(7, 10) As Integer
    Dim tsd2(7, 10) As Integer
    Dim str As String = ""
    Dim tblFooter As String = ""
    Dim indxSubj As String = ""
    'Dim pagePath As String = "C:\xampp\htdocs\Timetables2014\" '"D:\Timetables2014\"
    Dim pagePath As String = "D:\Timetables2014\"
    Dim facid = 0
    Dim _clsCode As String = ""
    Dim _clsName As String = ""
    Dim docstr As String = ""
    Dim tmpMaxP As String = 8

    Sub doSection(sid As Integer)
        'MsgBox("From do section")
        GetHTML3(sid, 3)
        'MsgBox("From do section :  Get HTML Call")
        Dim str11, str12
        str11 = "<table>"
        For i = 0 To maxD
            str11 += "<tr>"
            str12 = "<tr>"
            For j = 0 To maxP
                str11 += tsHTML(i, j)
                If tsd(i, j) > 1 Then j = j + tsd(i, j) - 1
            Next
            If i <> 0 Then
                For K = 0 To Val(tmpMaxP)
                    If Not (r(i) = " rowspan=2" And K = 0) Then str12 += tsHTML2(i, K)
                    If tsd2(i, K) > 1 Then K = K + tsd2(i, K) - 1
                Next
            End If
            str11 += "</tr>"
            str12 += "</tr>"
            If str12 = "<tr></tr>" Then
                str11 += "<tr><td></td></tr>"
            Else
                str11 += str12
            End If

        Next
        str11 += "</table>"
        'TextBox1.Text = str11
        MyHTMLString = str11
        'MsgBox("From do section :  Get HTML Call:MaypageCall")
        MyPage(sid)
    End Sub

    Private Sub GetHTML3(ByVal facid As Integer, ByVal typecode As Integer)
        'Dim _labroom
        For i = 0 To maxD
            r(8) = ""
        Next
        Array.Clear(tsHTML, 0, 80)
        Array.Clear(tShowHide, 0, 80)
        If facid = 0 Then Exit Sub

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn


        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader

        cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name,  " _
            & " Abr_n as abr, name,room, " _
                            & "islab, batch_id,ContGroupCode,P,ProgramName,semester " _
                            & "FROM dbo.V_Timetable_2013 " _
                            & "WHERE Section_Id = @ID ORDER BY batch_id;"
        cmd.Parameters.Add("@ID", SqlDbType.Int)
        cmd.Parameters("@ID").Value = facid

        cmd.Connection = cn
        cn.Open()
        rd = cmd.ExecuteReader()
        ' Dim LTP As String
        Dim tsval As String = ""
        Dim _abr, _room As String
        For i = 0 To maxD
            For j = 0 To maxP
                tsd(i, j) = 1
                tsd2(i, j) = 1
                tsHTML(i, j) = "<td rowspan=2 class='tttd'></td>"
                tsHTML2(i, j) = "" ' "<td  class='tttd'></td>"
            Next
        Next

        Dim tmpstr = ""
        Dim tmpstr1 = ""
        While (rd.Read)


            Dim d As Integer = rd.Item("TT_Day")
            Dim p As Integer = rd.Item("TT_Period")
            Dim loc As Integer = rd.Item("ContGroupCode")
            Dim sem As Integer

            _clsCode = rd.Item("section_name").ToString.Trim
            sem = Int(rd.Item("semester"))
            If Now.Month < 6 Or Now.Month = 12 Then sem = sem + 1


            _clsName = rd.Item("ProgramName").ToString.Trim & "(Semester - " & sem & ")"
            _abr = "(" & rd.Item("abr") & ")"
            _room = rd.Item("room")


            If rd.Item("Batch_Id") = 0 Then
                tmpstr1 = rd.Item("Subject_Code").ToString.Trim & " " & _abr + _room.Trim
                tmpstr = rd.Item("Subject_Code").ToString.Trim & " " & _abr + "<br/>" & _room.Trim

                If rd.Item("P") < 2 Then
                    If Not (tsHTML(rd.Item("TT_Day"), rd.Item("TT_Period")) = "<td rowspan=2 class='tttd'></td>") Then
                        tmpstr = tsHTML(rd.Item("TT_Day"), rd.Item("TT_Period")).Substring(27, tsHTML(rd.Item("TT_Day"), rd.Item("TT_Period")).Length - 32) & "<br/>" & tmpstr
                    End If
                    tsHTML.SetValue("<td class='tttd' " & "rowspan=2" & ">" & tmpstr & "</td>", rd.Item("TT_Day"), rd.Item("TT_Period"))
                Else
                    tsHTML.SetValue("<td class='LongCell' " & "colspan=" & rd.Item("P").ToString & " rowspan=2" & ">" & tmpstr1 & "</td>", rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If
                tsd.SetValue(rd.Item("P"), d, p)
                tsHTML2.SetValue("", rd.Item("TT_Day"), rd.Item("TT_Period"))
            Else
                IsRowSpan = True
                r(d) = " rowspan=2"
                If rd.Item("Batch_Id") = 1 Then
                    tsd.SetValue(rd.Item("P"), d, p)
                    tmpstr = rd.Item("Subject_Code").ToString.Trim & " G1" & _abr + _room.Trim
                    If rd.Item("P") < 2 Then
                        tsHTML.SetValue("<td class='TuteCell' class='tttd'>" & tmpstr & "</td>", rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        tsHTML.SetValue("<td bgcolor='#F0F0F0' class='LongCell'" & " colspan=" & rd.Item("P").ToString & "><span>" & tmpstr & "</span></td>", rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If
                    tsHTML2(d, p) = "<td class='tttd'></td>"
                Else
                    tsd2.SetValue(rd.Item("P"), d, p)
                    tmpstr = rd.Item("Subject_Code").ToString.Trim & "G2" & _abr + _room.Trim
                    If tsHTML(d, p) = "<td rowspan=2 class='tttd'></td>" Then tsHTML(d, p) = "<td class='tttd'></td>"
                    If rd.Item("P") < 2 Then
                        tsHTML2.SetValue("<td class='TuteCell'>" & tmpstr & "</td>", rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        tsHTML2.SetValue("<td bgcolor='#F0FFFF' class='LongCell'" & " colspan=" & rd.Item("P").ToString & "><span>" & tmpstr & "</span></td>", rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If

                End If
            End If
        End While

        tsHTML(0, 0) = "<td>" & _clsCode & "</td>"
        tsHTML(0, 1) = "<td>08:30-09:30</td>"
        tsHTML(0, 2) = "<td>09:30-10:30</td>"
        tsHTML(0, 3) = "<td>10:30-11:30</td>"
        tsHTML(0, 4) = "<td>11:30-12:30</td>"
        tsHTML(0, 5) = "<td>12:30-01:30</td>"
        tsHTML(0, 6) = "<td>01:30-02:30</td>"
        tsHTML(0, 7) = "<td>02:30-03:30</td>"
        tsHTML(0, 8) = "<td>03:30-04:30</td>"
        tsHTML(0, 9) = "<td>04:30-05:30</td>"
        tsHTML(0, 10) = "<td>05:30-06:30</td>"
        tsHTML(1, 0) = "<td class='tttd' " & r(1) & ">MON</td>"
        tsHTML(2, 0) = "<td class='tttd' " & r(2) & ">TUE</td>"
        tsHTML(3, 0) = "<td class='tttd' " & r(3) & ">WED</td>"
        tsHTML(4, 0) = "<td class='tttd' " & r(4) & ">THU</td>"
        tsHTML(5, 0) = "<td class='tttd' " & r(5) & ">FRI</td>"
        tsHTML(6, 0) = "<td class='tttd' " & r(6) & ">SAT</td>"
        tsHTML(7, 0) = "<td class='tttd' " & r(7) & ">SUN</td>"
    End Sub
    Private Sub MyPage(sid As Integer)
        'MsgBox("From do section :  Get HTML Call MyPage")
        Try
            Dim strp As String = ""
            strp += "<div><table style='border:0'><tr><td><img height='78'src='gbu100.png' width='79'></td><td class='style1'>"
            strp += "<span class='style2'>GAUTAM BUDDHA UNIVERSITY<br></span>Greater Noida, UP, India<br><br>"
            strp += "<span class='style3'>Session 2014-2015 (Odd Semester )</span></td></tr>"
            '   MsgBox("From getcsf")
            getCSF(sid)
            str = ""
            '  If chkShowHeader.Checked Then str = strp
            str = "<html><head><title id='tMain'>Timetables :: 2014-2015</title> " _
                & "<link href='common/stylesheet.css' rel='stylesheet' type='text/css' media='screen'/>" _
                & "<link href='common/print.css' rel='stylesheet' type='text/css' media='print' />" _
                & "</head><body>"
            'If chkShowHeader.Checked Then str += strp + "</table></div>"
            'str += "<tr><td border=1 colspan=2>" & "<span class='section'>" + _clsName + "</span>" & "</td></tr>"
            'THIS LINE IS JUST NOW FOR TEST

            str += "<section id=""timetable"" class=""card"">"
            str += "<div class=""page-header""><h2>"
            str += _clsName
            str += "</h2></div>"
            str += MyHTMLString
            str += "</section>"
            str += "<section id=""facultycodes"" class=""card""><div id=""lead"">Faculty Codes</div>" + tblFooter + "</section>"
            'If chkSign.Checked Then str += uctSign
            str += "</body></html>"
            'If typecode = 4 Then
            docstr += str & "<br><br><br>" & ts(0, 0) & "<br>"
            'End If
            Dim w As StreamWriter
            currFileName = "tt_" + "3" + "_" + sid.ToString.TrimEnd + ".htm"
            '  MsgBox(currFileName)
            w = File.CreateText(pagePath + currFileName)
            w.Write(str)
            w.Flush()
            w.Close()
            'Me.WebBrowser1.Navigate(pagePath + currFileName)
            _clsName = "-"
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub getCSF(SectionId As Object)
        Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject,L,T,P, " _
                           & " abr_n as abr,Teacher_name_n as name, " _
                           & " [TEACHER_ID_n] AS ID2 from CSF_View_with_Load WHERE (section_id=" & SectionId & ")"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn

        cn.Open()
        Dim faclink As String = ""
        Dim shareFac As String = ""
        Dim cmd As New SqlCommand(sQry, cn)
        Dim rd As SqlDataReader
        Dim tmplink() As String
        Dim tmpabr() As String


        rd = cmd.ExecuteReader
        tblFooter = ""
        tblFooter += "<table id='tFooter'>"
        While (rd.Read)
            tblFooter += "<tr>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += rd.Item("csf_id").ToString
            tblFooter += "</td>"
            'If chkLTP.Checked Then
            '    tblFooter += "<td class='ttcsf'>"
            '    tblFooter += rd.Item("L").ToString
            '    tblFooter += "</td>"
            '    tblFooter += "<td class='ttcsf'>"
            '    tblFooter += rd.Item("T").ToString
            '    tblFooter += "</td>"
            '    tblFooter += "<td class='ttcsf'>"
            '    tblFooter += rd.Item("P").ToString
            '    tblFooter += "</td>"
            'End If
            tblFooter += "<td class='ttcsf'>"
            tblFooter += rd.Item("subject_code").ToString
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += rd.Item("subject").ToString
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += " "
            tblFooter += "</td>"

            tmplink = rd.Item("Id2").ToString.Split(",")
            tmpabr = rd.Item("abr").ToString.Split(",")
            faclink = ""
            For iiii = 0 To tmplink.Length - 1
                faclink += "<a href='/timetables/2015/E/"
                faclink += "tt_1_" + tmplink(iiii).Trim + ".htm"
                faclink += "'>"
                faclink += tmpabr(iiii).Trim
                faclink += "</a>"
                If Not (iiii = tmplink.Length - 1) Then faclink += ", "
            Next


            tblFooter += "<td class='ttcsf'>("
            tblFooter += faclink
            tblFooter += ") " & rd.Item("name").ToString
            tblFooter += shareFac & "</td>"
            shareFac = ""
            ' tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += " "
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += " "
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += " "
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += " "
            tblFooter += "</td>"
            tblFooter += "</tr>"
        End While
        tblFooter += "</table>"

        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Sub UploadNow()

        If currFileName = "" Then
            MsgBox("No timetable is selected.")
        Else
            Dim ftpclient = New ftp("ftp://172.25.5.15", "awasthi", "tuajlkkl")
            Dim currFileNamerev As String = currFileName.Split(".")(0) + "_" + Now.Ticks.ToString + ".htm"
            Try
                ftpclient.download("\timetables\2015\E\" + currFileName, "D:\Timetables2014\tmp.htm")
                ftpclient.upload("\timetables\2015\E\rev\" + currFileNamerev, "D:\Timetables2014\tmp.htm")
            Catch ex As Exception

            End Try
            Try
                ftpclient.upload("\timetables\2015\E\" + currFileName, pagePath + currFileName)
            Catch ex As Exception
                MsgBox(Err.Description)
            End Try
        End If

        'If currFileName = "" Then
        '    MsgBox("No timetable is selected.")
        'Else
        '    Dim ftpclient = New ftp("ftp://172.25.5.15", "awasthi", "tuajlkkl")
        '    Try
        '        ftpclient.upload("\var\www\html\timetables\2015\E\" + currFileName, pagePath + currFileName)

        '    Catch ex As Exception
        '        MsgBox(Err.Description)
        '    End Try
        'End If
    End Sub

    Sub UploadNow2()
        If currFileName = "" Then
            MsgBox("No timetable is selected.")
        Else
            Dim currFileNamerev As String = currFileName.Split(".")(0) + "_" + Now.Ticks.ToString + ".htm"
            Try
                HttpUpload("http://172.25.5.15/tt/upload.php", pagePath + currFileName)
                HttpUpload("http://gbuonline.in/timetables/upload.php", pagePath + currFileName)
            Catch ex As Exception
                MsgBox(Err.Description)
            End Try
        End If
    End Sub

    Sub HttpUpload(url, filename)
        Dim Fileuri As String
        Using we As New WebClient

            Dim responseArray As Byte()
            responseArray = we.UploadFile(url, filename)
            Fileuri = System.Text.Encoding.ASCII.GetString(responseArray)
            'MsgBox(Fileuri)
            'Dim response As String
            'response = Encoding.UTF8.GetString(responseArray)
        End Using
    End Sub
    Sub PDFUpload(_section, filename)
        currFileName = "tt_" + "3" + "_" + _section.ToString.Trim + ".pdf"
        Dim ftpclient = New ftp("ftp://172.25.5.15", "awasthi", "tuajlkkl")
        Try
            ftpclient.upload("\var\www\html\timetables\2015\E\" + currFileName, filename)

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

End Class
