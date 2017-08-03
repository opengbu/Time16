Imports System.Data.SqlClient
Imports System.IO
'Imports Microsoft.Office.Interop

Imports System.Xml
Imports System.Xml.XPath
Imports System.Data
'Imports System.Data.SQLite


Public Class frmXMLBased
    Dim ts(7, 9) As String
    Dim str As String = ""
    Dim tblFooter As String = ""
    Dim indxSubj As String = ""
    Dim pagePath As String = "C:\Users\awasthi\DropboxGmail\Dropbox\Public\timetables\"
    Dim facid = 0
    Dim _clsName As String = ""
    Dim docstr As String = ""
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TimetableDataSet.Section' table. You can move, or remove it, as needed.
        Me.SectionTableAdapter.Fill(Me.TimetableDataSet.Section)
        Me.M_RoomTableAdapter.Fill(Me.TimetableDataSet.M_Room)
        Me.TeacherTableAdapter.Fill(Me.TimetableDataSet.Teacher)
    End Sub
    Sub GetHTML(ByVal facid As Integer, ByVal typecode As Integer)
        Array.Clear(ts, 0, 72)
        If facid = 0 Then Exit Sub
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn

        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        If typecode = 1 Then
            cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, Room, Batch_Id,name FROM dbo.V_Timetable_2013 " _
        & "WHERE Faculty_Id = @ID;"
            cmd.Parameters.Add("@ID", SqlDbType.Int)
            cmd.Parameters("@ID").Value = facid
        Else
            If typecode = 3 Then
                cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, abr, name,room,islab, batch_id FROM dbo.V_Timetable_2013 " _
            & "WHERE Section_Id = @ID ORDER BY batch_id;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            Else
                cmd.CommandText = "SELECT  TT_Day, TT_Period, Subject_Code, Section_Name, abr, name,room, batch_id FROM dbo.V_Timetable_2013 " _
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
                    If chkShowFacultyName.Checked Then _abr = "(" & rd.Item("abr").ToString.Trim + ")"
                    If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                        If rd.Item("IsLab") Then
                            tsval = (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                        Else
                            tsval = (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & vbCrLf & _abr + _room
                        End If

                        If rd.Item("Batch_Id") = 1 Then tsval = tsval + vbLf
                        If rd.Item("Batch_Id") = 2 Then tsval = vbLf + tsval
                        If rd.Item("Batch_Id") = 0 Then tsval = " " + vbLf + tsval + vbLf + " "

                    Else
                        If rd.Item("IsLab") Then
                            tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & vbNewLine & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                        Else
                            tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & vbLf & _abr + _room
                        End If
                    End If
                    'If rd.Item("IsLab") Then tsval = "<span class='lab'>" & tsval & "</span>"
                    ts.SetValue(tsval, rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If

            End If


        End While
        ts(0, 1) = "09:30-10:30"
        ts(0, 2) = "10:30-11:30"
        ts(0, 3) = "11:30-12:30"
        ts(0, 4) = "12:30-01:30"
        ts(0, 5) = "01:30-02:30"
        ts(0, 6) = "02:30-03:30"
        ts(0, 7) = "03:30-04:30"
        ts(0, 8) = "04:30-05:30"
        ts(1, 0) = "MON"
        ts(2, 0) = "TUE"
        ts(3, 0) = "WED"
        ts(4, 0) = "THU"
        ts(5, 0) = "FRI"
        ts(6, 0) = "SAT"
    End Sub
    Sub GetHTML1(ByVal facid As Integer, ByVal typecode As Integer)
        Array.Clear(ts, 0, 72)

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
                cmd.CommandText = "SELECT  csf_id,TT_Day, TT_Period, Subject_Code, Section_Name, abr, name,room,islab, batch_id FROM dbo.V_Timetable_2013 " _
            & "WHERE Section_Id = @ID ORDER BY batch_id;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            Else
                cmd.CommandText = "SELECT csf_id, TT_Day, TT_Period, Subject_Code, Section_Name, abr, name,room, batch_id FROM dbo.V_Timetable_2013 " _
            & "WHERE Room_Id = @ID;"
                cmd.Parameters.Add("@ID", SqlDbType.Int)
                cmd.Parameters("@ID").Value = facid
            End If

        End If
        Dim cmd2 As New SqlCommand
        Dim rd2 As SqlDataReader
        cmd2.CommandText = "SELECT  abbr as abr, name FROM LoadShareView " _
            & "WHERE csf_id = @ID1;"
        cmd2.Parameters.Add("@ID1", SqlDbType.Int)


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
                ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & rd.Item("Room"), rd.Item("TT_Day"), rd.Item("TT_Period"))
            Else
                If typecode = 2 Then
                    ts.SetValue(rd.Item("room"), 0, 0)
                    tsval =
                    ts.SetValue((rd.Item("Subject_Code") & " " & LTP) & vbCrLf & _clsName & vbCrLf & "(" & rd.Item("abr") + ")" + rd.Item("name"), rd.Item("TT_Day"), rd.Item("TT_Period"))
                Else
                    _abr = ""
                    _room = ""
                    ts.SetValue(_clsName, 0, 0)
                    If chkShowRoom.Checked Then _room = rd.Item("room").ToString.Trim
                    If chkShowFacultyName.Checked Then
                        _abr = "(" & rd.Item("abr").ToString.Trim + ")" '+ "<br/>"
                        cmd2.Parameters("@ID1").Value = rd.Item("csf_id").ToString.Trim
                        cmd2.Connection = cn2
                        cn2.Open()
                        rd2 = cmd2.ExecuteReader()
                        While (rd2.Read)
                            _abr = _abr + "+(" + rd2("abr") + ")"
                        End While
                        rd2 = Nothing
                        cn2.Close()

                    End If
                    If ts(rd.Item("TT_Day"), rd.Item("TT_Period")) Is Nothing Then
                        tsval = (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                        If rd.Item("Batch_Id") = 1 Then tsval = tsval + "<hr>"
                        If rd.Item("Batch_Id") = 2 Then tsval = "<hr>" + tsval
                    Else
                        'If rd.Item("IsLab") Then
                        '    tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & "<hr>" & (rd.Item("Subject_Code") & " " & LTP)  & _abr + _room
                        'Else
                        tsval = ts(rd.Item("TT_Day"), rd.Item("TT_Period")) & (rd.Item("Subject_Code").ToString.Trim & " " & LTP) & _abr + _room
                        'End If
                    End If
                    If rd.Item("IsLab") Then tsval = "<span class='lab'>" & tsval & "</span>"
                    ts.SetValue(tsval, rd.Item("TT_Day"), rd.Item("TT_Period"))
                End If

            End If


        End While
        ts(0, 1) = "09:30-10:30"
        ts(0, 2) = "10:30-11:30"
        ts(0, 3) = "11:30-12:30"
        ts(0, 4) = "12:30-01:30"
        ts(0, 5) = "01:30-02:30"
        ts(0, 6) = "02:30-03:30"
        ts(0, 7) = "03:30-04:30"
        ts(0, 8) = "04:30-05:30"
        ts(1, 0) = "MON"
        ts(2, 0) = "TUE"
        ts(3, 0) = "WED"
        ts(4, 0) = "THU"
        ts(5, 0) = "FRI"
        ts(6, 0) = "SAT"
    End Sub
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
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load ORDER BY Name"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn
        cn.Open()

        Dim cmd As New SqlCommand(sQry3, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        'Dim currsection As Integer
        'Private setColumnRowRange As Microsoft.Office.Tools.Excel.NamedRange
        Dim i As Integer = 1
        While (rd.Read)
            'currsection = rd("section_id")
            'GetHTML(currsection, 3)
            '' MsgBox(currsection)
            'oSheet = oBook.Worksheets(i)
            ''oSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            ''xlWorkSheet.PageSetup.Orientation =
            'oSheet.name = rd("name").ToString.Trim.ToUpper
            'oSheet.Range("A2").Resize(7, 9).Value = ts
            'oSheet.Range("B2").Resize(7, 8).columnwidth = 16
            'oSheet.Range("A3").Resize(6, 9).rowheight = 42
            'oSheet.Range("A2").Resize(7, 9).font.size = 8
            'oSheet.Range("A2").Resize(7, 9).cells.VerticalAlignment = Excel.XlVAlign.xlVAlignJustify
            'oSheet.Range("A2").Resize(7, 9).cells.wraptext = False
            'oSheet.Range("A2").Resize(7, 9).cells.EntireColumn.autofit()

            'oBorder = oSheet.Range("A2").Resize(7, 9).cells.borders

            'oBorder.LineStyle = Excel.XlLineStyle.xlContinuous
            'oBorder.Weight = 2D

            ' oSheet.Range("A2").Resize(8, 10).Border = 1
            'oSheet.Range("A2").Resize(7, 9).BorderAround(LineStyle:=Excel.XlLineStyle.xlContinuous, Weight:=Excel.XlBorderWeight.xlThin)
            'i = i + 1
            'oSheet = oBook.Worksheets.Add(After:=oBook.Worksheets(i))
            'Exit While
        End While


        'Private Sub SetColumnAndRowSizes()
        '    setColumnRowRange = Me.Controls.AddNamedRange(Me.Range("C3", "E6"), "setColumnRowRange")
        '    Me.setColumnRowRange.ColumnWidth = 20
        '    Me.setColumnRowRange.RowHeight = 25
        '    setColumnRowRange.Select()
        'End Sub


        'Save the Workbook and quit Excel.
        oBook.SaveAs(pagePath & "timetable.xls")
        oSheet = Nothing
        oBook = Nothing
        oExcel.Quit()
        oExcel = Nothing
        GC.Collect()

    End Sub
    Sub GetPage(ByVal Facid As Integer, ByVal typecode As Integer)

        Dim strp As String = ""
        If typecode = 3 Then
            strp += "<p><table style='border:0'><tr><td><img height='78'src='gbu100.png' width='79'></td><td class='style1'>"
            strp += "<span class='style2'>GAUTAM BUDDHA UNIVERSITY<br></span>Greater Noida, UP, India<br><br>"
            strp += "<span class='style3'>Session 2013-2014 (Odd Semester )</span></td></tr>"
            'strp += "<tr><td class='style4' colspan='2'>" + ts(0, 0) + "</td></tr></table></p>"
            getCSF(Facid)
        End If
        If typecode = 4 Then
            GetHTML(Facid, 3)
        Else
            GetHTML(Facid, typecode)
        End If

        str = ""
        If chkShowHeader.Checked Then str = strp
        str += "<html><head><title id='tMain'>Timetables :: 2013-2014</title><link href='StyleSheet.css' rel='stylesheet' type='text/css' /></head>"
        str += "<body><table>"
        ts(0, 1) = "09:30-10:30"
        ts(0, 2) = "10:30-11:30"
        ts(0, 3) = "11:30-12:30"
        ts(0, 4) = "12:30-01:30"
        ts(0, 5) = "01:30-02:30"
        ts(0, 6) = "02:30-03:30"
        ts(0, 7) = "03:30-04:30"
        ts(0, 8) = "04:30-05:30"
        ts(1, 0) = "MON"
        ts(2, 0) = "TUE"
        ts(3, 0) = "WED"
        ts(4, 0) = "THU"
        ts(5, 0) = "FRI"
        ts(6, 0) = "SAT"
        For i = 0 To 6
            str += "<tr>"
            For j = 0 To 8
                str += "<td class='tttd'>" + ts(i, j) + "</td>"
            Next
            str += "</tr>"
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



    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex <> -1 Then
            tblFooter = ""
            GetPage(ComboBox1.SelectedValue, 1)
        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex <> -1 Then
            tblFooter = ""
            GetPage(ComboBox2.SelectedValue, 2)
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex <> -1 Then
            tblFooter = ""
            getCSF(ComboBox3.SelectedValue)
            GetPage(ComboBox3.SelectedValue, 3)

        End If
    End Sub

    Private Sub getCSF(ByVal SectionId As Integer)
        'SessionId = 10
        ' Dim sQry = "SELECT distinct csf_id,subject_code,abr,id,name,l_load,L,T,P from V_section_subject_Faculty_1 WHERE (section_id=" & SectionId & ") AND (session_id = " & SessionId & ")"
        'Dim sQry = "SELECT distinct csf_id,subject_code,abr,id,name,l_load,L,T,P from V_section_subject_Faculty_1 WHERE (section_id=" & SectionId & ")"
        'Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, abr,Teacher_name as name,l_load,L,T,P from CSF_View_with_Load WHERE (section_id=" & SectionId & ")"
        Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, [Faculty_Id], abr,Teacher_name as name from CSF_View_with_Load WHERE (section_id=" & SectionId & ")"

        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.conn

        cn.Open()
        Dim cn2 As New SqlConnection
        cn2.ConnectionString = My.Settings.conn

        cn2.Open()
        Dim faclink As String = ""
        Dim shareFac As String = ""
        Dim cmd As New SqlCommand(sQry, cn)
        Dim rd As SqlDataReader
        'cmd.Parameters.Add(1)
        Dim cmd3 As New SqlCommand
        Dim rd3 As SqlDataReader
        cmd3.CommandText = "SELECT  abbr as abr, name FROM LoadShareView " _
            & "WHERE csf_id = @ID1;"
        cmd3.Parameters.Add("@ID1", SqlDbType.Int)

        rd = cmd.ExecuteReader
        tblFooter = ""
        tblFooter += "<table id='tFooter'>"
        While (rd.Read)
            tblFooter += "<tr>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += rd.Item("csf_id").ToString
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += rd.Item("subject_code").ToString
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += rd.Item("subject").ToString
            tblFooter += "</td>"
            tblFooter += "<td class='ttcsf'>"
            tblFooter += " "
            tblFooter += "</td>"

            'Faculty Page Link ########333
            faclink = "<a href='"
            faclink += "tt_1_" + rd.Item("Faculty_Id").ToString.Trim + ".htm"
            faclink += "'>"
            faclink += rd.Item("abr").ToString
            faclink += "</a>"
            '############################33


            tblFooter += "<td class='ttcsf'>("
            'tblFooter += rd.Item("abr").ToString &
            tblFooter += faclink
            tblFooter += ") " & rd.Item("name").ToString

            '#################3333SHARE WITH

            cmd3.Parameters("@ID1").Value = rd.Item("csf_id").ToString.Trim
            cmd3.Connection = cn2
            If cn2.State <> 1 Then cn2.Open()
            rd3 = cmd3.ExecuteReader()
            While (rd3.Read)
                shareFac = shareFac + "+(" + rd3("abr") + ")" + rd3("name")
            End While
            rd3 = Nothing
            cn2.Close()
            '#####################33
            tblFooter += shareFac & "</td>"
            shareFac = ""
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
            tblFooter += "<td class='ttcsf'>"
            tblFooter += " "
            tblFooter += "</td>"
            'tblFooter += "<td class='ttcsf'>"
            'tblFooter += rd.Item("L").ToString
            'tblFooter += "</td>"
            'tblFooter += "<td class='ttcsf'>"
            'tblFooter += rd.Item("T").ToString
            'tblFooter += "</td>"
            'tblFooter += "<td class='ttcsf'>"
            'tblFooter += rd.Item("P").ToString
            'tblFooter += "</td>"
            'tblFooter += "<td class='ttcsf'>"
            'tblFooter += rd.Item("l_load").ToString
            'tblFooter += "</td>"
            tblFooter += "</tr>"
        End While
        tblFooter += "</table>"

        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Private Sub MakeIndexf()

        'Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, abr,Teacher_name as name,l_load,L,T,P from CSF_View_with_Load"
        Dim sQry1 = "SELECT distinct Subject_Id, subject_code, subject_name as subject From CSF_View_with_Load order by subject_code"
        Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load order by name"
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load order by name"


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
        Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load ORDER BY Teacher_name"
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load ORDER BY name"

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

        'Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, abr,Teacher_name as name,l_load,L,T,P from CSF_View_with_Load"
        'Dim sQry1 = "SELECT distinct Subject_Id, subject_code, subject_name as subject From CSF_View_with_Load"
        'Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load"
        'Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load"
        Dim sQry1 = "SELECT distinct Subject_Id, subject_code, subject_name as subject From CSF_View_with_Load  ORDER BY subject_code"
        Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load  ORDER BY Teacher_name"
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load ORDER BY Name"

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
            GetPage(rd.Item("section_Id").ToString.Trim, 3)
            indxSubj += "<li>"
            indxSubj += "<a href='"
            indxSubj += "tt_3_" + rd.Item("section_Id").ToString + ".htm"
            indxSubj += "'>"
            indxSubj += rd.Item("name").ToString
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
    End Sub
    Private Sub MakeIndexsd()

        'Dim sQry = "SELECT distinct csf_id,subject_code, subject_name as subject, abr,Teacher_name as name,l_load,L,T,P from CSF_View_with_Load"
        Dim sQry1 = "SELECT distinct Subject_Id, subject_code, subject_name as subject From CSF_View_with_Load  ORDER BY subject_code"
        Dim sQry2 = "SELECT distinct Faculty_Id, abr,Teacher_name as name from CSF_View_with_Load  ORDER BY Teacher_name"
        Dim sQry3 = "SELECT distinct  Section_Id, Name from CSF_View_with_Load ORDER BY Name"


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
            indxSubj += "tt_3_" + rd.Item("section_Id").ToString + ".htm"
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
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        MakeIndexf()
        MakeIndexr()
        MakeIndexs()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'docstr = ""
        'MakeIndexsd()
        'Dim w As StreamWriter
        'w = File.CreateText("d:\Timtables.doc")
        'w.Write(docstr)
        'w.Flush()
        'w.Close()
        doExcel()


    End Sub


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        WebBrowser1.ShowSaveAsDialog()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim arrSelect As New ArrayList
    '    Dim strConnection As String = "data source= D:\awa.db"
    '    Dim strQuery As String = "SELECT * FROM Teacher"
    '    Dim strRecord As String = ""
    '    arrSelect = SelectSQL(strConnection, strQuery)
    '    If arrSelect IsNot Nothing Then
    '        For Each value As Array In arrSelect
    '            strRecord = ""
    '            For j As Integer = 0 To value.Length - 1
    '                strRecord &= value(j) & "|"
    '            Next
    '            MsgBox(strRecord)
    '        Next
    '    End If
    'End Sub

    'Function SelectSQL(ByVal strConn As String, ByVal strCommand As String) As ArrayList
    '    Try
    '        Dim SQLconnect As New SQLite.SQLiteConnection()
    '        Dim SQLcommand As New SQLite.SQLiteCommand
    '        SQLconnect.ConnectionString = strConn
    '        SQLconnect.Open()
    '        SQLcommand = SQLconnect.CreateCommand
    '        SQLcommand.CommandText = strCommand
    '        Dim SQLreader As SQLite.SQLiteDataReader = SQLcommand.ExecuteReader()
    '        Dim listLoc As New ArrayList
    '        Dim nc As Integer = SQLreader.FieldCount
    '        Dim arrLoc() As Object
    '        While SQLreader.Read()
    '            ReDim arrLoc(nc - 1)
    '            For j As Integer = 0 To nc - 1
    '                arrLoc(j) = SQLreader.Item(j)
    '            Next
    '            listLoc.Add(arrLoc)
    '        End While
    '        SQLcommand.Dispose()
    '        SQLconnect.Close()
    '        Return listLoc
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function
End Class
