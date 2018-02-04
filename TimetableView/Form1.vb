Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
'Imports MyFTP
'Imports MyFTP.ftp
'Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop

Public Class Form1
    Dim uctSign As String = "<br/><br/><div><img src='sign.png' width='150'><br/> University Cordinator, Timetables</div>"
    Private _Timetable_Code As Integer = 0
    Dim currFileName As String = ""
    Dim selCom3Changed As Boolean = False
    Dim maxP As Integer = 11
    Dim maxD As Integer = 7
    Dim r(9) As String
    Dim tsExcel(7, 11) As String
    Dim tsHTML(7, 11) As String
    Dim tsHTML2(7, 11) As String
    Dim MyHTMLString As String
    Dim tShowHide(7, 11) As Integer
    Dim tShowHide2(7, 11) As Integer
    Dim IsRowSpan As Boolean = False
    Dim ts(7, 11) As String
    Dim tsb(7, 11) As Integer
    Dim ts1(7, 11) As String
    Dim ts2(7, 11) As String
    Dim tss(7, 11) As Integer
    Dim tsd(7, 11) As Integer
    Dim tsd2(7, 11) As Integer
    Dim str As String = ""
    Dim tblFooter As String = ""
    Dim indxSubj As String = ""
    'Dim pagePath As String = "C:\xampp\htdocs\Timetables2014\" '"D:\Timetables2014\"
    Dim pagePath As String = Path.GetTempPath() '  "D:\Timetables2014\"
    Dim facid = 0
    Dim _clsCode As String = ""
    Dim _clsName As String = ""
    Dim docstr As String = ""

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SectionTableAdapter.Fill(Me.TimetableDataSet.Section)
        Me.M_RoomTableAdapter.Fill(Me.TimetableDataSet.M_Room)
        Me.TeacherTableAdapter.Fill(Me.TimetableDataSet.Teacher)


    End Sub

    Sub GetHTML(ByVal facid As Integer, ByVal typecode As Integer)
        Array.Clear(ts, 0, 88)
        Array.Clear(ts2, 0, 88)
        Array.Clear(tss, 0, 88)
        Array.Clear(tsd, 0, 88)
        If facid = 0 Then Exit Sub
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        If typecode = 1 Then
            cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, Room, Batch_Id,name,ContGroupCode,P FROM dbo.V_Timetable_2013 " _
        & "WHERE Faculty_Id = @ID OR (TEACHER_ID2 = @ID);"
            cmd.Parameters.Add("@ID", SqlDbType.Int)
            cmd.Parameters("@ID").Value = facid
        Else
            If typecode = 3 Then
                cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name,  " _
            & " abr_n AS abr, name,room,islab, batch_id,ContGroupCode,P FROM dbo.V_Timetable_2013 " _
            & "WHERE Section_Id = @ID ORDER BY batch_id;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            Else
                cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, " _
            & " abr_n AS abr, name,room, batch_id,ContGroupCode,P FROM dbo.V_Timetable_2013 " _
            & "WHERE Room_Id = @ID;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            End If

        End If



        cmd.Connection = cn
        cn.Open()
        rd = cmd.ExecuteReader()
        Dim LTP As String
        Dim tsval As String = ""
        Dim _abr, _room As String
        While (rd.Read)
            Dim d As Integer
            Dim p As Integer
            Dim loc As Integer
            If chkMerge.Checked Then
                d = rd.Item("TT_Day")
                p = rd.Item("TT_Period")
                loc = rd.Item("ContGroupCode")
                'tss
                tss.SetValue(d * 10 + p - loc, d, p)


            End If

            Select Case rd.Item("Batch_Id")
                Case 1
                    LTP = "[G1]"
                    If chkMerge.Checked Then tsd.SetValue(rd.Item("P"), d, p)
                Case 2
                    LTP = "[G2]"
                    If chkMerge.Checked Then tsd2.SetValue(rd.Item("P"), d, p)
                Case Else
                    LTP = ""
                    If chkMerge.Checked Then
                        tsd.SetValue(rd.Item("P"), d, p)
                        tsd2.SetValue(rd.Item("P"), d, p)

                    End If
            End Select

            _clsName = rd.Item("section_name").ToString.Trim
            If typecode = 1 Then
                ts.SetValue(rd.Item("name"), 0, 0)
                If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                    ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & rd.Item("Room"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                Else
                    ts.SetValue(ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<BR>" & (rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & rd.Item("Room"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If



            Else
                If typecode = 2 Then
                    ts.SetValue(rd.Item("room"), 0, 0)

                    If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                        ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & "(" & rd.Item("abr") + ")" + rd.Item("name"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        ts.SetValue(ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<BR>" & (rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & "(" & rd.Item("abr") + ")" + rd.Item("name"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If
                Else
                    _abr = ""
                    _room = ""
                    ts.SetValue(_clsName, 0, 0)
                    If chkShowRoom.Checked Then _room = " " & rd.Item("room").ToString.Trim
                    If chkShowFacultyName.Checked Then _abr = " [" & rd.Item("abr").ToString.Trim + "] "
                    If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                        If rd.Item("IsLab") Then
                            tsval = rd.Item("Subject_Code").ToString.Trim & " " & LTP & _abr + _room.Trim
                        Else
                            tsval = rd.Item("Subject_Code").ToString.Trim & " " & LTP & "<br/>" & _abr + _room.Trim + "<br/>"
                        End If


                        '"<table class='TTCell'><tr><td>"CS182 [G1] [AGD] IP-104</td></tr><tr><td>ME102 [G2] [SAT]  Workshop</td></tr></table>"
                        '   If rd.Item("Batch_Id") = 1 Then tsval = vbLf + tsval
                        '  If rd.Item("Batch_Id") = 2 Then tsval = tsval
                        ' If rd.Item("Batch_Id") = 0 Then tsval = " " + vbLf + tsval + vbLf + " "

                    Else
                        If rd.Item("IsLab") Then
                            tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                            'tsval = "<table class='TTCell'><tr><td>" & ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "</td></tr><tr><td>" & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room & "</td></tr></table>"
                        Else
                            tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & "<br/>" & _abr + _room
                        End If
                    End If
                    'If rd.Item("IsLab") Then tsval = "<span class='lab'>" & tsval & "</span>"
                    ts.SetValue(tsval, rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If

            End If


        End While
        daytime()

    End Sub
    Sub GetHTML1(ByVal facid As Integer, ByVal typecode As Integer)
        Array.Clear(ts, 0, 88)
        Array.Clear(ts2, 0, 88)
        Array.Clear(tss, 0, 88)
        Array.Clear(tsd, 0, 88)

        If facid = 0 Then Exit Sub
        Dim cn As New SqlConnection
        Dim cn2 As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        cn2.ConnectionString = My.Settings.conn
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        If typecode = 1 Then
            cmd.CommandText = "SELECT  csf_id, TT_Day, TT_Period, Subject_Code, Section_Name, Room, Batch_Id,name FROM dbo.V_Timetable_2013 " _
        & "WHERE Faculty_Id = @ID;"
            cmd.Parameters.Add("@ID", SqlDbType.Int)
            cmd.Parameters("@ID").Value = facid
        Else
            If typecode = 3 Then
                cmd.CommandText = "SELECT  csf_id,TT_Day, TT_Period, Subject_Code, Section_Name, " _
            & " abr_n as abr, name,room,islab, batch_id FROM dbo.V_Timetable_2013 " _
            & "WHERE Section_Id = @ID ORDER BY batch_id;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            Else
                cmd.CommandText = "SELECT csf_id, TT_Day, TT_Period, Subject_Code, Section_Name," _
            & " abr_n as abr, name,room, batch_id FROM dbo.V_Timetable_2013 " _
            & "WHERE Room_Id = @ID;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            End If

        End If
        'Dim cmd2 As New SqlCommand
        'Dim rd2 As SqlDataReader
        'cmd2.CommandText = "SELECT  abbr as abr, name FROM LoadShareView " _
        '    & "WHERE csf_id = @ID1;"
        'cmd2.Parameters.Add("@ID1", SqlDbType.Int)


        cmd.Connection = cn
        cn.Open()
        rd = cmd.ExecuteReader()
        Dim LTP As String
        Dim tsval As String = ""
        Dim _abr, _room As String

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
            If typecode = 1 Then
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


            Else
                If typecode = 2 Then
                    ts.SetValue(rd.Item("room"), 0, 0)
                    ' tsval =
                    If Not ts(rd.Item("TT_Day"), rd.Item("TT_Period")) = Nothing Then
                        ts.SetValue(ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<br></br>" & (rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & "(" & rd.Item("abr") + ")" + rd.Item("name"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        'ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & rd.Item("Room"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                        ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & "(" & rd.Item("abr") + ")" + rd.Item("name"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If



                Else
                    _abr = ""
                    _room = ""
                    ts.SetValue(_clsName, 0, 0)
                    If chkShowRoom.Checked Then _room = rd.Item("room").ToString.Trim
                    If chkShowFacultyName.Checked Then
                        _abr = "(" & rd.Item("abr").ToString.Trim + ")" '+ "<br/>"
                        'cmd2.Parameters("@ID1").Value = rd.Item("csf_id").ToString.Trim
                        'cmd2.Connection = cn2
                        'cn2.Open()
                        'rd2 = cmd2.ExecuteReader()
                        'While (rd2.Read)
                        '    _abr = _abr + "+(" + rd2("abr") + ")"
                        'End While
                        'rd2 = Nothing
                        'cn2.Close()

                    End If
                    If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                        tsval = (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                        If rd.Item("Batch_Id") = 1 Then tsval = tsval + "<hr>"
                        If rd.Item("Batch_Id") = 2 Then tsval = "<hr>" + tsval
                    Else
                        If rd.Item("IsLab") Then
                            tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<hr>" & (rd.Item("Subject_Code") & " " & LTP) & _abr + _room
                        Else
                            tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                        End If
                    End If
                    If rd.Item("IsLab") Then tsval = "<span class='lab'>" & tsval & "</span>"
                    ts.SetValue(tsval, rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If

            End If
        End While
        daytime()
    End Sub
    Public Function SessionName() As String
        Dim _SessionName As String = ""
        Dim sql As String =
         "Select Title From Session Where CurrentActive=1"

        Using conn As New SqlConnection(My.Settings.conn)
            Dim cmd As New SqlCommand(sql, conn)
            Try
                conn.Open()
                _SessionName = Convert.ToString(cmd.ExecuteScalar())
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return _SessionName

    End Function

    Sub doExcel()
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim oBorder As Object

        'Start a new workbook in Excel.
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Add
        oBorder = oExcel.cells.Borders
        'Create an array with 3 columns and 100 rows.
        'Dim DataArray(7, 9) As Object
        'Dim r As Integer
        'For r = 0 To 7
        '    DataArray(r, 0) = "ORD" & Format(r + 1, "0000")
        '    DataArray(r, 1) = Rnd() * 1000
        '    DataArray(r, 2) = DataArray(r, 1) * 0.07
        'Next
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load Where SessionID=" & Session().ToString & " ORDER BY Name"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        cn.Open()

        Dim cmd As New SqlCommand(sQry3, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim currsection As Integer
        'Private setColumnRowRange As Microsoft.Office.Tools.Excel.NamedRange
        Dim i As Integer = 1
        While (rd.Read)
            currsection = rd("section_id")
            GetExcelArray(currsection, 3)
            ' MsgBox(currsection)
            oSheet = oBook.Worksheets(i)
            ''''''''''' '  oSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            'xlWorkSheet.PageSetup.Orientation =
            oSheet.name = rd("name").ToString.Trim.ToUpper
            oSheet.Range("A2").Resize(7, 9).Value = tsExcel
            oSheet.Range("B2").Resize(7, 8).columnwidth = 20
            oSheet.Range("A3").Resize(6, 9).rowheight = 35
            oSheet.Range("A2").Resize(7, 9).font.size = 8
            '''''''''''''oSheet.Range("A2").Resize(7, 9).cells.VerticalAlignment = Excel.XlVAlign.xlVAlignJustify
            oSheet.Range("A2").Resize(7, 9).cells.wraptext = False
            oSheet.Range("A2").Resize(7, 9).cells.EntireColumn.autofit()
            '  oSheet.Range("A2").Resize(7, 9).MergeCell = True

            oBorder = oSheet.Range("A2").Resize(7, 9).cells.borders

            ''''''''''''''oBorder.LineStyle = Excel.XlLineStyle.xlContinuous
            oBorder.Weight = 2D

            ' oSheet.Range("A2").Resize(8, 10).Border = 1
            '''''''''''''''oSheet.Range("A2").Resize(7, 9).BorderAround(LineStyle:=Excel.XlLineStyle.xlContinuous, Weight:=Excel.XlBorderWeight.xlThin)
            i = i + 1
            oSheet = oBook.Worksheets.Add(After:=oBook.Worksheets(i))
            ' Exit While
        End While


        'Private Sub SetColumnAndRowSizes()
        '    setColumnRowRange = Me.Controls.AddNamedRange(Me.Range("C3", "E6"), "setColumnRowRange")
        '    Me.setColumnRowRange.ColumnWidth = 20
        '    Me.setColumnRowRange.RowHeight = 25
        '    setColumnRowRange.Select()
        'End Sub


        'Save the Workbook and quit Excel.
        oBook.SaveAs(pagePath & "timetable.xlsx")
        oSheet = Nothing
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        GC.Collect()

    End Sub
    Sub GetPage(ByVal Facid As Integer, ByVal typecode As Integer)
        Try
            Dim strp As String = ""
            If typecode = 3 Then
                strp += "<p><table style='border:0'><tr><td><img height='78'src='gbu100.png' width='79'></td><td class='style1'>"
                strp += "<span class='style2'>GAUTAM BUDDHA UNIVERSITY<br></span>Greater Noida, UP, India<br><br>"
                strp += "<span class='style3'>Session " & SessionName() & " (Odd Semester )</span></td></tr>"
                'strp += "<tr><td class='style4' colspan='2'>" + ts(0, 0) + "</td></tr></table></p>"
                getCSF(Facid)
            End If
            If typecode = 4 Then
                GetHTML1(Facid, 3)
            Else
                GetHTML1(Facid, typecode)
            End If

            str = ""
            If chkShowHeader.Checked Then str = strp
            str += "<html><head><title id='tMain'>Timetables :: " & SessionName() & "</title> " _
                & "<style>" & My.Resources.screencss & "</style>" _
                & "<link href='print.css' rel='stylesheet' type='text/css' media='print' />" _
                & "</head>"
            str += "<body><table>"
            daytime()
            For i = 0 To maxD
                str += "<tr>"
                For j = 0 To maxP
                    If tsd(i, j) = 0 Then
                        str += "<td class='tttd'>" + ts(i, j) + "</td>"
                    Else
                        If tss(i, j) = 0 Then
                            'str += "<td class='tttd'>" + ts(i, j) + ":" + tss(i, j).ToString + "</td>"
                            str += "<td class='tttd' colspan='" + tsd(i, j).ToString + "'>" + ts(i, j) + "</td>"
                            j = j + tsd(i, j) - 1
                        Else
                            'str += "<td class='tttd' colspan='" + tss(i, j).ToString + "'>" + ts(i, j) + "</td>"
                        End If

                    End If

                Next
                str += "</tr>"
            Next
            str += "</table>" + "<div>" + tblFooter + "</div>" + "<div class='Weblink'>SAVE PAPER: This timetable is available at http://portal.gbuonline.in/timetables </div>"
            If chkSign.Checked Then str += uctSign
            str += "</body></html>"

            'If typecode = 4 Then
            docstr += str & "<br><br><br>" & ts(0, 0) & "<br>"
            'End If
            Dim w As StreamWriter
            w = File.CreateText(pagePath + "tt_" + typecode.ToString + "_" + Facid.ToString + ".htm")
            w.Write(str)
            w.Flush()
            w.Close()
            Me.WebBrowser1.Navigate(pagePath + "tt_" + typecode.ToString + "_" + Facid.ToString + ".htm")
        Catch ex As Exception

        End Try
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        _Timetable_Code = 1
        If ComboBox1.SelectedIndex <> -1 Then
            tblFooter = ""
            WebBrowser1.DocumentText = GetTimetableByFacultyId(ComboBox1.SelectedValue)
        End If

        If WebBrowser1.ReadyState = WebBrowserReadyState.Loaded Then WebBrowser1.Refresh()
    End Sub

    'Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
    '    Dim Document As HtmlDocument = WebBrowser1.Document
    '    Dim Head As HtmlElement = Document.GetElementsByTagName("head")(0)
    '    Dim SelectedStyle As HtmlElement = Document.CreateElement("style")
    '    Dim NativeSelectedStyle = SelectedStyle.DomElement
    '    NativeSelectedStyle.type = "text/css"
    '    ' NativeSelectedStyle.innerHTML = ".dashedBorder { ... }" throws an error
    '    NativeSelectedStyle.styleSheet.cssText = My.Resources.screencss
    '    Head.AppendChild(SelectedStyle)
    '    'MessageBox.Show(SelectedStyle.OuterHtml)
    'End Sub


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        _Timetable_Code = 2
        If ComboBox2.SelectedIndex <> -1 Then
            tblFooter = ""
            GetPage(ComboBox2.SelectedValue, 2)
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        _Timetable_Code = 3
        doSection(ComboBox3.SelectedValue)




    End Sub
    Private Sub doSection(sid As Integer)
        GetHTML3(sid, 3)
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
                For K = 0 To Val(txtMaxP.Text)
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
        TextBox1.Text = str11
        MyHTMLString = str11
        MyPage(sid)
    End Sub

    Private Sub getCSF(ByVal SectionId As Integer)
        Dim _Session = Session()
        Dim _SessionName = SessionName()

        Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject,L,T,P, " _
                   & " abr_n as abr,Teacher_name_n as name, " _
                   & " [TEACHER_ID_n] AS ID2 from CSF_View_with_Load WHERE (section_id=" & SectionId & ") AND SessionID=" & Session().ToString

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
            If chkLTP.Checked Then
                tblFooter += "<td class='ttcsf'>"
                tblFooter += rd.Item("L").ToString
                tblFooter += "</td>"
                tblFooter += "<td class='ttcsf'>"
                tblFooter += rd.Item("T").ToString
                tblFooter += "</td>"
                tblFooter += "<td class='ttcsf'>"
                tblFooter += rd.Item("P").ToString
                tblFooter += "</td>"
            End If
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
                faclink += "<a href='"
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
    Private Sub MakeIndexf()

        'Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, abr,Teacher_name as name,l_load,L,T,P from CSF_View_with_Load"
        Dim sQry1 = "SELECT distinct Subject_Id, subject_code, subject_name as subject From CSF_View_with_Load where SessionID=" & Session().ToString & " order by subject_code"
        'Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load order by name"
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load where SessionID=" & Session().ToString & " order by name"
        Dim sQry2 = "SELECT distinct id as Faculty_Id, abbr as abr, name,school from Teacher order by name"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        cn.Open()

        Dim cmd As New SqlCommand(sQry2, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        tblFooter = ""


        indxSubj = "<head><base target='main'></head>"
        indxSubj += "<ul>"
        While (rd.Read)
            GetPage(rd.Item("Faculty_Id").ToString.Trim, 1)
            indxSubj += "<li>"
            indxSubj += "<a href='"
            indxSubj += "tt_1_" + rd.Item("Faculty_Id").ToString.Trim + ".htm"
            indxSubj += "'>"
            indxSubj += rd.Item("name").ToString + "  [" + rd.Item("abr").ToString + "]"
            indxSubj += "</a>"
            indxSubj += "</li>"
        End While
        indxSubj += "</ul>"
        Dim w As StreamWriter
        w = File.CreateText(pagePath + "index_fac.htm")
        w.Write(indxSubj)
        w.Flush()
        w.Close()
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Private Sub MakeIndexr()

        'Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, abr,Teacher_name as name,l_load,L,T,P from CSF_View_with_Load"
        Dim sQry1 = "SELECT distinct room_Id, name From m_room ORDER BY name"
        Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load where SessionID=" & Session().ToString & " ORDER BY Teacher_name"
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load Where SessionID=" & Session().ToString & " ORDER BY name"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        cn.Open()

        Dim cmd As New SqlCommand(sQry1, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        tblFooter = ""


        indxSubj = "<head><base target='main'></head>"
        indxSubj += "<ul>"
        While (rd.Read)
            GetPage(rd.Item("room_Id").ToString.Trim, 2)
            indxSubj += "<li>"
            indxSubj += "<a href='"
            indxSubj += "tt_2_" + rd.Item("room_Id").ToString + ".htm"
            indxSubj += "'>"
            indxSubj += rd.Item("name").ToString
            indxSubj += "</a>"
            indxSubj += "</li>"
        End While
        indxSubj += "</ul>"
        Dim w As StreamWriter
        w = File.CreateText(pagePath + "index_room.htm")
        w.Write(indxSubj)
        w.Flush()
        w.Close()
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Private Sub MakeIndexs()

        Try
            Dim sQry3 = "SELECT distinct  school,Id as section_id, Name,ProgramName from V_Program Where showTimetable=1 ORDER BY school,Name"
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.conn
            cn.Open()
            Dim schoolName As String = ""
            Dim cmd As New SqlCommand(sQry3, cn)
            Dim rd As SqlDataReader
            rd = cmd.ExecuteReader
            tblFooter = ""
            indxSubj = "<head><base target='main'></head>"
            ' indxSubj += "<h2>" & schoolName & "</h2>"
            indxSubj += "<ul>"
            While (rd.Read)
                'MsgBox(rd.Item("section_Id").ToString.Trim)
                'GetPage(rd.Item("section_Id").ToString.Trim, 3)
                doSection(rd.Item("section_Id"))
                If Not IsDBNull(rd.Item("school")) Then
                    If Not (schoolName = rd.Item("school")) Then
                        schoolName = rd.Item("school")
                        indxSubj += "</ul>"
                        indxSubj += "<h2>" & schoolName & "</h2>"
                        indxSubj += "<ul>"
                    End If
                Else
                    schoolName = "~"
                    indxSubj += "</ul>"
                    indxSubj += "<h2>" & schoolName & "</h2>"
                    indxSubj += "<ul>"
                End If

                indxSubj += "<li>"
                indxSubj += "<a title='" & rd.Item("ProgramName").ToString & "' href='"
                'indxSubj += "tt_3_" + rd.Item("section_Id").ToString + ".htm"
                indxSubj += "route.htm?type=3&id=" + rd.Item("section_Id").ToString
                indxSubj += "'>"
                indxSubj += rd.Item("name").ToString '& "<br/>(" & rd.Item("ProgramName").ToString & ")"
                indxSubj += "</a>"
                indxSubj += "</li>"
            End While
            indxSubj += "</ul>"
            Dim w As StreamWriter
            w = File.CreateText(pagePath + "index_sec.htm")
            w.Write(indxSubj)
            w.Flush()
            w.Close()
            If cn.State = ConnectionState.Open Then cn.Close()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub MakeIndexsd()

        'Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, abr,Teacher_name as name,l_load,L,T,P from CSF_View_with_Load"
        Dim sQry1 = "SELECT distinct Subject_Id, subject_code, subject_name as subject From CSF_View_with_Load where SessionID=" & Session().ToString & "  ORDER BY subject_code"
        Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load  where SessionID=" & Session().ToString & " ORDER BY Teacher_name"
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load where SessionID=" & Session().ToString & " ORDER BY Name"


        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        cn.Open()

        Dim cmd As New SqlCommand(sQry3, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        tblFooter = ""

        indxSubj = "<head><base target='main'></head>"
        indxSubj += "<ul>"
        While (rd.Read)
            GetPage(rd.Item("section_Id").ToString.Trim, 4)
            indxSubj += "<li>"
            indxSubj += "<a href='"
            'indxSubj += "tt_3_" + rd.Item("section_Id").ToString + ".php"
            indxSubj += "route.php?type=3&id=" + rd.Item("section_Id").ToString
            indxSubj += "'>"
            indxSubj += rd.Item("name").ToString
            indxSubj += "</a>"
            indxSubj += "</li>"
        End While
        indxSubj += "</ul>"
        'Dim w As StreamWriter
        'w = File.CreateText(pagePath + "index_sec.htm")
        'w.Write(indxSubj)
        'w.Flush()
        'w.Close()
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    'MakeIndexf()
    ' MakeIndexr()
    ' MakeIndexs()
    'LoadChart()
    'End Sub





    Sub GetPageNew(ByVal Facid As Integer, ByVal typecode As Integer)
        Try
            Dim strp As String = ""
            If typecode = 3 Then
                strp += "<p><table style='border:0'><tr><td><img height='78'src='gbu100.png' width='79'></td><td class='style1'>"
                strp += "<span class='style2'>GAUTAM BUDDHA UNIVERSITY<br></span>Greater Noida, UP, India<br><br>"
                strp += "<span class='style3'>Session " & SessionName() & "</span></td></tr>"
                'strp += "<tr><td class='style4' colspan='2'>" + ts(0, 0) + "</td></tr></table></p>"
                getCSF(Facid)
            End If
            If typecode = 4 Then
                GetHTML2(Facid, 3)
            Else
                GetHTML2(Facid, typecode)
            End If
            Dim tmstr = ""
            Dim tmint As Integer = 8
            str = ""
            If chkShowHeader.Checked Then str = strp
            str += "<html><head><title id='tMain'>Timetables :: " & SessionName() & "</title> " _
                & "<link href='StyleSheet.css' rel='stylesheet' type='text/css' media='screen'/>" _
                & "<link href='print.css' rel='stylesheet' type='text/css' media='print' />" _
                & "</head>"
            str += "<body><table>"
            daytime()
            Dim Bstr As String = ""
            For i = 0 To maxD
                str += "<tr>"
                tmint = 7
                tmstr = ""
                For j = 0 To maxP
                    If j = 0 Or i = 0 Then
                        str += "<td class='tttd' rowspan='2'>" + ts(i, j) + "</td>"
                    Else
                        If tsb(i, j) = 0 Then
                            str += "<td class='tttd' rowspan='2'>" + ts2(i, j) + "</td>"
                            tmint = tmint - 1
                        Else
                            If tss(i, j) = 0 Then
                                'str += "<td class='tttd'>" + ts(i, j) + ":" + tss(i, j).ToString + "</td>"
                                'str += "<td class='tttd' rowspan='1' colspan='" + tsd(i, j).ToString + "'>" + ts1(i, j) + "</td>"
                                tmstr += "<td>" & ts2(i, j) & "</td>"
                                j = j + tsd(i, j) - 1
                            Else
                                'str += "<td class='tttd' colspan='" + tss(i, j).ToString + "'>" + ts(i, j) + "</td>"
                            End If

                        End If

                    End If

                Next
                str += "</tr>"
                str += "<tr>"
                str += tmstr
                str += "</tr>"
                tmstr = ""
            Next
            str += "</table>" + "<div>" + tblFooter + "</div>" + "</body></html>"

            'If typecode = 4 Then
            docstr += str & "<br><br><br>" & ts(0, 0) & "<br>"
            'End If
            Dim w As StreamWriter
            w = File.CreateText(pagePath + "tt_" + typecode.ToString + "_" + Facid.ToString + ".htm")
            w.Write(str)
            w.Flush()
            w.Close()
            Me.WebBrowser1.Navigate(pagePath + "tt_" + typecode.ToString + "_" + Facid.ToString + ".htm")
        Catch ex As Exception

        End Try




    End Sub

    Sub GetHTML2(ByVal facid As Integer, ByVal typecode As Integer)
        Array.Clear(ts, 0, 88)
        Array.Clear(tsb, 0, 88)
        Array.Clear(ts2, 0, 88)
        Array.Clear(ts1, 0, 88)
        Array.Clear(tss, 0, 88)
        Array.Clear(tsd, 0, 88)
        If facid = 0 Then Exit Sub
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        If typecode = 1 Then
            cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, Room, Batch_Id,name,ContGroupCode,P FROM dbo.V_Timetable_2013 " _
        & "WHERE Faculty_Id = @ID;"
            cmd.Parameters.Add("@ID", SqlDbType.Int)
            cmd.Parameters("@ID").Value = facid
        Else
            If typecode = 3 Then
                cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, abr, name,room,islab, batch_id,ContGroupCode,P FROM dbo.V_Timetable_2013 " _
            & "WHERE Section_Id = @ID ORDER BY batch_id;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            Else
                cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, abr, name,room, batch_id,ContGroupCode,P FROM dbo.V_Timetable_2013 " _
            & "WHERE Room_Id = @ID;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            End If

        End If



        cmd.Connection = cn
        cn.Open()
        rd = cmd.ExecuteReader()
        Dim LTP As String
        Dim tsval As String = ""
        Dim _abr, _room As String
        While (rd.Read)
            ' If chkMerge.Checked Then
            Dim d As Integer = rd.Item("TT_Day")
            Dim p As Integer = rd.Item("TT_Period")
            Dim loc As Integer = rd.Item("ContGroupCode")
            'tss
            tss.SetValue(d * 10 + p - loc, d, p)
            tsd.SetValue(rd.Item("P"), d, p)
            'End If

            Select Case rd.Item("Batch_Id")
                Case 1
                    LTP = "[G1]"
                    tsb.SetValue(1, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    tsd.SetValue(rd.Item("P"), d, p)
                Case 2
                    LTP = "[G2]"
                    tsb.SetValue(2, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    tsd2.SetValue(rd.Item("P"), d, p)
                Case Else
                    LTP = ""
                    tsb.SetValue(0, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    tsd.SetValue(rd.Item("P"), d, p)
                    tsd2.SetValue(rd.Item("P"), d, p)
            End Select

            _clsName = rd.Item("section_name").ToString.Trim
            If typecode = 1 Then
                ts.SetValue(rd.Item("name"), 0, 0)
                If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                    ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & rd.Item("Room"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                Else
                    ts.SetValue(ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<BR>" & (rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & rd.Item("Room"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If



            Else
                If typecode = 2 Then
                    ts.SetValue(rd.Item("room"), 0, 0)

                    If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                        ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & "(" & rd.Item("abr") + ")" + rd.Item("name"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        ts.SetValue(ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<BR>" & (rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & "(" & rd.Item("abr") + ")" + rd.Item("name"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If
                Else
                    _abr = ""
                    _room = ""
                    ts.SetValue(_clsName, 0, 0)
                    'tsb.SetValue(Val(rd.Item("Batch_Id").ToString.Trim), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    'If Val(rd.Item("Batch_Id").ToString) <> 2 Then
                    '    ts2.SetValue(rd.Item("Subject_Code").ToString.Trim & " " & LTP & _abr + _room.Trim, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    'Else
                    '    ts1.SetValue(rd.Item("Subject_Code").ToString.Trim & " " & LTP & _abr + _room.Trim, rd.Item("TT_Day"), rd.Item("TT_Period"))

                    'End If



                    If chkShowRoom.Checked Then _room = " " & rd.Item("room").ToString.Trim
                    If chkShowFacultyName.Checked Then _abr = " [" & rd.Item("abr").ToString.Trim + "] "
                    'If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                    '    If rd.Item("IsLab") Then
                    '        tsval = rd.Item("Subject_Code").ToString.Trim & " " & LTP & _abr + _room.Trim
                    '    Else
                    '        tsval = rd.Item("Subject_Code").ToString.Trim & " " & LTP & "<br/>" & _abr + _room.Trim + "<br/>"
                    '    End If


                    '    '"<table class='TTCell'><tr><td>"CS182 [G1] [AGD] IP-104</td></tr><tr><td>ME102 [G2] [SAT]  Workshop</td></tr></table>"
                    '    '   If rd.Item("Batch_Id") = 1 Then tsval = vbLf + tsval
                    '    '  If rd.Item("Batch_Id") = 2 Then tsval = tsval
                    '    ' If rd.Item("Batch_Id") = 0 Then tsval = " " + vbLf + tsval + vbLf + " "

                    'Else
                    '    If rd.Item("IsLab") Then
                    '        tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                    '        'tsval = "<table class='TTCell'><tr><td>" & ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "</td></tr><tr><td>" & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room & "</td></tr></table>"
                    '    Else
                    '        tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & "<br/>" & _abr + _room
                    '    End If
                    'End If
                    tsb.SetValue(rd.Item("Batch_Id"), rd.Item("TT_Day"), rd.Item("TT_Period"))

                    If rd.Item("Batch_Id") = 2 Then
                        ts2.SetValue(rd.Item("Subject_Code").ToString.Trim & " " & LTP & _abr + _room.Trim, rd.Item("TT_Day"), rd.Item("TT_Period"))
                        tsd2.SetValue(rd.Item("p"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        ts1.SetValue(rd.Item("Subject_Code").ToString.Trim & " " & LTP & _abr + _room.Trim, rd.Item("TT_Day"), rd.Item("TT_Period"))
                        'tsb.SetValue(0, rd.Item("TT_Day"), rd.Item("TT_Period"))
                        tsd.SetValue(rd.Item("p"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If

                    'If rd.Item("IsLab") Then tsval = "<span class='lab'>" & tsval & "</span>"
                    ts.SetValue(tsval, rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If

            End If


        End While
        daytime()
    End Sub

    Sub GetHTML3(ByVal facid As Integer, ByVal typecode As Integer)

        'Dim _labroom
        For i = 0 To maxD
            r(8) = ""
        Next
        Array.Clear(tsHTML, 0, 88)
        Array.Clear(tShowHide, 0, 88)
        If facid = 0 Then Exit Sub

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        Dim cmd As New SqlCommand
        Dim rd17 As SqlDataReader

        cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name,  " _
            & " Abr_n as abr, name,room, " _
                            & "islab, batch_id,ContGroupCode,P,ProgramName,semester " _
                            & "FROM dbo.V_Timetable_2013 " _
                            & "WHERE Section_Id = @ID ORDER BY batch_id;"
        cmd.Parameters.Add("@ID", SqlDbType.Int)
        cmd.Parameters("@ID").Value = facid

        cmd.Connection = cn
        cn.Open()
        rd17 = cmd.ExecuteReader()
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
        While (rd17.Read)


            Dim d As Integer = rd17.Item("TT_Day")
            Dim p As Integer = rd17.Item("TT_Period")
            Dim loc As Integer = rd17.Item("ContGroupCode")
            Dim sem As Integer

            _clsCode = rd17.Item("section_name").ToString.Trim
            sem = Int(rd17.Item("semester"))
            If Now.Month < 6 Or Now.Month = 12 Then sem = sem + 1


            _clsName = rd17.Item("ProgramName").ToString.Trim & "(Semester - " & sem & ")"
            _abr = "(" & rd17.Item("abr") & ")"
            _room = rd17.Item("room")


            If rd17.Item("Batch_Id") = 0 Then
                tmpstr1 = rd17.Item("Subject_Code").ToString.Trim & " " & _abr + _room.Trim
                tmpstr = rd17.Item("Subject_Code").ToString.Trim & " " & _abr + "<br/>" & _room.Trim

                If rd17.Item("P") < 2 Then
                    If Not (tsHTML(rd17.Item("TT_Day"), rd17.Item("TT_Period")) = "<td rowspan=2 class='tttd'></td>") Then
                        tmpstr = tsHTML(rd17.Item("TT_Day"), rd17.Item("TT_Period")).Substring(27, tsHTML(rd17.Item("TT_Day"), rd17.Item("TT_Period")).Length - 32) & "<br/>" & tmpstr
                    End If
                    tsHTML.SetValue("<td class='tttd' " & "rowspan=2" & ">" & tmpstr & "</td>", rd17.Item("TT_Day"), rd17.Item("TT_Period"))
                Else
                    tsHTML.SetValue("<td class='LongCell' " & "colspan=" & rd17.Item("P").ToString & " rowspan=2" & ">" & tmpstr1 & "</td>", rd17.Item("TT_Day"), rd17.Item("TT_Period"))
                End If
                tsd.SetValue(rd17.Item("P"), d, p)
                tsHTML2.SetValue("", rd17.Item("TT_Day"), rd17.Item("TT_Period"))
            Else
                IsRowSpan = True
                r(d) = " rowspan=2"
                If rd17.Item("Batch_Id") = 1 Then
                    tsd.SetValue(rd17.Item("P"), d, p)
                    tmpstr = rd17.Item("Subject_Code").ToString.Trim & " G1" & _abr + _room.Trim
                    If rd17.Item("P") < 2 Then
                        tsHTML.SetValue("<td class='TuteCell' class='tttd'>" & tmpstr & "</td>", rd17.Item("TT_Day"), rd17.Item("TT_Period"))
                    Else
                        tsHTML.SetValue("<td bgcolor='#F0F0F0' class='LongCell'" & " colspan=" & rd17.Item("P").ToString & "><span>" & tmpstr & "</span></td>", rd17.Item("TT_Day"), rd17.Item("TT_Period"))
                    End If
                    tsHTML2(d, p) = "<td class='tttd'></td>"
                Else
                    tsd2.SetValue(rd17.Item("P"), d, p)
                    tmpstr = rd17.Item("Subject_Code").ToString.Trim & "G2" & _abr + _room.Trim
                    If tsHTML(d, p) = "<td rowspan=2 class='tttd'></td>" Then tsHTML(d, p) = "<td class='tttd'></td>"
                    If rd17.Item("P") < 2 Then
                        tsHTML2.SetValue("<td class='TuteCell'>" & tmpstr & "</td>", rd17.Item("TT_Day"), rd17.Item("TT_Period"))
                    Else
                        tsHTML2.SetValue("<td bgcolor='#F0FFFF' class='LongCell'" & " colspan=" & rd17.Item("P").ToString & "><span>" & tmpstr & "</span></td>", rd17.Item("TT_Day"), rd17.Item("TT_Period"))
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
        tsHTML(0, 11) = "<td>06:30-07:30</td>"
        tsHTML(1, 0) = "<td class='tttd' " & r(1) & ">MON</td>"
        tsHTML(2, 0) = "<td class='tttd' " & r(2) & ">TUE</td>"
        tsHTML(3, 0) = "<td class='tttd' " & r(3) & ">WED</td>"
        tsHTML(4, 0) = "<td class='tttd' " & r(4) & ">THU</td>"
        tsHTML(5, 0) = "<td class='tttd' " & r(5) & ">FRI</td>"
        tsHTML(6, 0) = "<td class='tttd' " & r(6) & ">SAT</td>"
        tsHTML(7, 0) = "<td class='tttd' " & r(7) & ">SUN</td>"
    End Sub
    Sub MyPage(facid)

        Try
            Dim strp As String = ""
            strp += "<div><table><tr><td><img height='78'src='gbu100.png' width='79'></td><td class='style1'>"
            strp += "<span class='style2'>GAUTAM BUDDHA UNIVERSITY<br></span>Greater Noida, UP, India<br><br>"
            strp += "<span class='style3'>Session " & SessionName() & "</span></td></tr>"
            getCSF(facid)
            str = ""
            '  If chkShowHeader.Checked Then str = strp
            str = "<html><head><title id='tMain'>Timetables :: " & SessionName() & "</title> " _
                & "<style>" & My.Resources.screencss & "</style>" _
                & "<link href='print.css' rel='stylesheet' type='text/css' media='print' />" _
                & "</head>"
            str += "<body>"
            If chkShowHeader.Checked Then str += strp + "</table></div>"
            'str += "<tr><td border=1 colspan=2>" & "<span class='section'>" + _clsName + "</span>" & "</td></tr>"
            'THIS LINE IS JUST NOW FOR TEST

            str += "<section id=""timetable"" class=""card"">"
            str += "<div class=""page-header""><h2>"
            str += _clsName
            str += "</h2></div>"
            str += MyHTMLString
            str += "</section>"
            str += "<section id=""facultycodes"" class=""card""><div id=""lead"">Faculty Codes</div>" + tblFooter + "</section>"
            If chkSign.Checked Then str += uctSign
            str += "</body></html>"
            'If typecode = 4 Then
            docstr += str & "<br><br><br>" & ts(0, 0) & "<br>"
            'End If
            Dim w As StreamWriter
            currFileName = "tt_" + "3" + "_" + facid.ToString.TrimEnd + ".htm"
            w = File.CreateText(pagePath + currFileName)
            w.Write(str)
            w.Flush()
            w.Close()
            Me.WebBrowser1.Navigate(pagePath + currFileName)
            _clsName = "-"
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try




    End Sub
    Sub LoadChart()
        Try
            Dim mystr As String = ""
            Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.conn
            Dim cmd As New SqlCommand
            Dim rd As SqlDataReader
            Dim _school As String = ""
            'cmd.CommandText = "SELECT  * FROM View_RHL ORDER by [name]"
            cmd.CommandText = "SELECT  * FROM View_RHL_with_School ORDER by [school],[department],[name]"

            cmd.Connection = cn
            cn.Open()
            rd = cmd.ExecuteReader()
            mystr = "<html><head><title id='tMain'>Timetables :: 2013-2014</title> " _
                    & "<link href='StyleSheet.css' rel='stylesheet' type='text/css' media='screen'/>" _
                    & "<link href='print.css' rel='stylesheet' type='text/css' media='print' />" _
                    & "</head><body>"

            mystr = "<table border=1><tr><td  class='NormalCell'> School </td><td  class='NormalCell'> Faculty Name </td><td  class='NormalCell'> Individual Load </td><td  class='NormalCell'> - </td><td  class='NormalCell'> - </td></tr>"
            While (rd.Read)
                _school = "~"
                'mystr += "<tr><td class='NormalCell'>" & rd.Item(3).ToString.ToUpper & "</td><td class='NormalCell'>" & rd.Item(4) & "</td><td class='NormalCell'>" & rd.Item(5) & "</td><td class='NormalCell'>" & rd.Item(4) + rd.Item(5) & "</td></tr>"
                If Not IsDBNull(rd.Item(0)) Then _school = rd.Item(0)
                mystr += "<tr><td class='NormalCell'>" & _school & "</td><td class='NormalCell'>" & rd.Item(3).ToString.ToUpper & "</td><td class='NormalCell'>" & rd.Item(4) & "</td><td class='NormalCell'>-</td><td class='NormalCell'>-</td></tr>"
            End While
            mystr += "</table></body></html>"
            rd.Close()
            cn.Close()
            Dim w As StreamWriter
            w = File.CreateText(pagePath + "tt_load.htm")
            w.Write(mystr)
            w.Flush()
            w.Close()
            Me.WebBrowser1.Navigate(pagePath + "tt_load.htm")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Sub GetExcelArray(ByVal facid As Integer, ByVal typecode As Integer)

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

        cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, CASE WHEN ABBR2 IS NOT NULL " _
            & "THEN Abr + ',' + ABBR2 ELSE ABR END AS abr, name,room, " _
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
                tsHTML(i, j) = ""
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
            If Now().Month < 6 Or Now().Month = 12 Then sem = sem + 1
            _clsName = rd.Item("ProgramName").ToString.Trim & "(Semester - " & sem & ")"
            _abr = "(" & rd.Item("abr") & ")"
            _room = rd.Item("room")


            If rd.Item("Batch_Id") = 0 Then
                tmpstr1 = rd.Item("Subject_Code").ToString.Trim & " " & _abr + _room.Trim
                tmpstr = rd.Item("Subject_Code").ToString.Trim & " " & _abr & vbNewLine & _room.Trim

                If rd.Item("P") < 2 Then
                    tsHTML.SetValue(tmpstr, rd.Item("TT_Day"), rd.Item("TT_Period"))
                Else
                    tsHTML.SetValue(tmpstr1, rd.Item("TT_Day"), rd.Item("TT_Period"))
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
                        tsHTML.SetValue("[T] " & tmpstr, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        tsHTML.SetValue("[P] " & tmpstr, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If
                    tsHTML2(d, p) = ""
                Else
                    tsd2.SetValue(rd.Item("P"), d, p)
                    tmpstr = rd.Item("Subject_Code").ToString.Trim & "G2" & _abr + _room.Trim
                    If tsHTML(d, p) = "" Then tsHTML(d, p) = ""
                    If rd.Item("P") < 2 Then
                        tsHTML2.SetValue("[T] " & tmpstr, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    Else
                        tsHTML2.SetValue("[P] " & tmpstr, rd.Item("TT_Day"), rd.Item("TT_Period"))
                    End If

                End If
            End If
        End While

        tsHTML(0, 0) = _clsCode
        daytime()

        For mmm = 0 To 6
            For nnn = 0 To 8
                tsExcel(mmm, nnn) = tsHTML(mmm, nnn) + vbLf + tsHTML2(mmm, nnn)
            Next
        Next
    End Sub



    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        LoadChart()
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
        ts(0, 11) = "06:30-07:30"
        ts(1, 0) = "MON"
        ts(2, 0) = "TUE"
        ts(3, 0) = "WED"
        ts(4, 0) = "THU"
        ts(5, 0) = "FRI"
        ts(6, 0) = "SAT"
        ts(7, 0) = "SUN"
    End Sub


    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If currFileName = "" Then
            MsgBox("No timetable is selected.")
        Else
            Dim ftpclient = New ftp("ftp://172.25.5.15", "awasthi", "tuajlkkl")
            Try
                ftpclient.upload("\var\www\html\timetables\2015\E\" + currFileName, pagePath + currFileName)

            Catch ex As Exception
                MsgBox(Err.Description)
            End Try
        End If

    End Sub



    Private Sub SaveLocalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveLocalToolStripMenuItem.Click
        Dim filename As String = pagePath + "tt_" + _Timetable_Code.ToString.Trim + "_" + ComboBox1.SelectedValue.ToString.Trim + ".htm"
        WriteToFile(WebBrowser1.DocumentText, filename)
    End Sub

    Private Sub UploadOnlineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadOnlineToolStripMenuItem.Click
        Dim filename As String = "tt_" + _Timetable_Code.ToString.Trim + "_" + ComboBox1.SelectedValue.ToString.Trim + ".htm"
        'Path name is not required.
        WriteToFile(WebBrowser1.DocumentText, filename, True)
    End Sub

    Private Sub FacultyTimetabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacultyTimetabelsToolStripMenuItem.Click
        Try
            Dim filename As String = ""
            Dim cnt As String = ""
            Dim TotalUploads = TeacherBindingSource.Count
            ProgressBar1.Maximum = TotalUploads
            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            Dim dv As DataView = CType(TeacherBindingSource.List, DataView)
            Dim dt As DataTable = dv.ToTable()
            For Each row In dt.Rows
                cnt = ""
                If Not (row("Id").ToString = "") Then
                    'Dim filename As String = "tt_" + _Timetable_Code.ToString.Trim + "_" + ComboBox1.SelectedValue.ToString.Trim + ".htm"
                    filename = "tt_" + "1_" + row("Id").ToString + ".htm"
                    cnt = GetTimetableByFacultyId(row("Id"))
                    WriteToFile(cnt, filename, True)
                    ProgressBar1.Increment(1)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & vbCr & Err.Description & vbCrLf & Err.Number)
        Finally
            ' MsgBox("Try Proxy Disable.")
        End Try

        MsgBox("Done.")
    End Sub

    Private Sub ClassSectionTimetablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassSectionTimetablesToolStripMenuItem.Click
        Try
            Dim filename As String = ""
            Dim cnt As String = ""
            Dim TotalUploads = SectionBindingSource.Count
            ProgressBar1.Maximum = TotalUploads
            ProgressBar1.Minimum = 1
            ProgressBar1.Value = 1
            Dim dv As DataView = CType(SectionBindingSource.List, DataView)
            Dim dt As DataTable = dv.ToTable()
            For Each row In dt.Rows
                cnt = ""
                If Not (row("Id").ToString = "") Then
                    'Dim filename As String = "tt_" + _Timetable_Code.ToString.Trim + "_" + ComboBox1.SelectedValue.ToString.Trim + ".htm"
                    filename = "tt_" + "3_" + row("Id").ToString + ".htm"
                    ' cnt = GetTimetableByFacultyId(row("Id"))
                    doSection(row("Id"))
                    UploadOnline2(filename)
                    ' WriteToFile(cnt, filename, True)
                    ProgressBar1.Increment(1)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & vbCr & Err.Description & vbCrLf & Err.Number)
        Finally
            ' MsgBox("Try Proxy Disable.")
        End Try

        MsgBox("Done.")
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        doExcel()
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Dim webBrowserForPrinting As WebBrowser = WebBrowser1

        ' Print the document now that it is fully loaded.
        'WebBrowser1.Print()
        webBrowserForPrinting.ShowPrintPreviewDialog()

        'MessageBox.Show("print")
        ' Dispose the WebBrowser now that the task is complete. 
        'webBrowserForPrinting.Dispose()
    End Sub

    Sub UploadOnline2(ByVal currFileName As String)
        Dim tmppath As String = Path.GetTempPath()

        If currFileName = "" Then
            MsgBox("No timetable is selected.")
        Else
            ' Dim currFileNamerev As String = currFileName.Split(".")(0) + "_" + Now.Ticks.ToString + ".htm"
            If (currFileName.Contains("/")) Then
                currFileName = tmppath + currFileName
            End If
            Try
                HttpUpload("http://172.25.5.15/tt/upload.php", currFileName)
                HttpUpload("http://gbuonline.in/timetables/upload.php", currFileName)
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
End Class
