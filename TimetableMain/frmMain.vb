Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Net

Public Class frmMain
    Dim cn As New SqlConnection
    Private _isSwap As Boolean = False
    Private _isCut As Boolean = False
    Private _Batch As Integer = 0
    Private _school As String = ""
    Private _csf As Integer = 0
    Private _atag As String = "Lecture"
    Private _duration As Integer = 1
    Private _section As Integer = 0
    Private _room As Integer = 0
    Private _TTIdCopy = 0
    Private _sectionCopy = 0
    Private _TTDayCopy = 0
    Private _TTPeriodCopy = 0
    Private _currrow As Integer = 0
    Private _currFacId As String = "0"
    Private _currFacId2 As Integer = 0
    Private beforeDel As Integer = 0
    Private TTFillBothColor(7, 11) As Integer
    Private TTFillFacColor(7, 11) As Integer
    Private TTFillRoomColor(7, 11) As Integer
    Private _colorMode As Boolean = True
    Private _pathToImport As String = "D:\Timetables2014"
    Dim disession As SessionData
    Private url As Object = "http://172.25.5.15/tt/upload.php"


    Sub TTAdd(ByVal day As Integer, ByVal period As Integer, ByVal value As String)
        TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).Text = TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).Text.Trim & vbCrLf & value
    End Sub
    Sub TTFacAdd(ByVal day As Integer, ByVal period As Integer, ByVal sectionid As Integer)
        If Not (TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).BackColor = Color.Silver) Then
            If sectionid = _section Then
                TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).BackColor = Color.SkyBlue
            Else
                TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).BackColor = Color.LightBlue
            End If
        Else
            If sectionid = _section Then
                TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).BackColor = Color.SlateGray
            Else
                TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).BackColor = Color.Gray

            End If
        End If
    End Sub
    Sub TTRoomAdd(ByVal day As Integer, ByVal period As Integer)
        TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).BackColor = Color.Silver
    End Sub
    Sub TTLockColor(ByVal day As Integer, ByVal period As Integer)
        TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).BackColor = Color.Red
        TableLayoutPanel1.GetControlFromPosition(period - 1, day - 1).Text = "LOCK"
    End Sub
    Sub LoadLockTT(ByVal secid As Integer)
        ' Array.Clear(TTFillRoomColor, 0, 63)
        'For i = 0 To TableLayoutPanel1.Controls.Count - 1
        'TableLayoutPanel1.Controls.Item(i).BackColor = Color.White
        'Next
        Dim sQry = "SELECT TTDay, TTPeriod FROM [Lock_Slots_forDept] WHERE (SessionId = " & _Session & ") and (Sectionid=" & secid & ")"
        Dim cmd As New SqlCommand(sQry)
        Dim ad As SqlDataReader
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd.Connection = cn
        ad = cmd.ExecuteReader()
        Do While ad.Read
            TTLockColor(ad.Item("TTDay"), ad.Item("TTPeriod"))
            TTFillRoomColor.SetValue(1, ad.Item("TTDay"), ad.Item("TTPeriod"))
        Loop
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub
    Sub LoadRoomTT(ByVal RoomId As Integer)
        Array.Clear(TTFillRoomColor, 0, 63)
        For i = 0 To TableLayoutPanel1.Controls.Count - 1
            TableLayoutPanel1.Controls.Item(i).BackColor = Color.White
        Next
        'Dim sQry = "SELECT TT_Day, TT_Period FROM [V_TimeTable_2013] WHERE (TimeTableId = " & My.Settings.TTid & ") and (Room_id=" & RoomId & ")"
        'Removing View Access. Now direct from table
        Dim sQry = "SELECT TT_Day, TT_Period FROM [M_Time_Table] WHERE (TimeTableId = " & My.Settings.TTid & ") and (Room_id=" & RoomId & ")"
        Dim cmd As New SqlCommand(sQry)
        Dim ad As SqlDataReader
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd.Connection = cn
        ad = cmd.ExecuteReader()
        Do While ad.Read
            TTRoomAdd(ad.Item("TT_Day"), ad.Item("TT_Period"))
            TTFillRoomColor.SetValue(1, ad.Item("TT_Day"), ad.Item("TT_Period"))
        Loop
        If cn.State = ConnectionState.Open Then cn.Close()
        LoadLockTT(_currentSection)
    End Sub

    'Sub LoadFacTT(ByVal FacultyId As String, Optional FacultyId2 As Integer = 0)
    Sub LoadFacTT(ByVal FacultyId As String, Optional FacultyId2 As Integer = 0, Optional csf_id As Integer = 0)
        FacultyId = _currFacId
        FacultyId2 = _currFacId2
        For i = 0 To TableLayoutPanel1.Controls.Count - 1
            If Not _colorMode Then
                TableLayoutPanel1.Controls.Item(i).BackColor = Color.White
            Else
                If Not (TableLayoutPanel1.Controls.Item(i).BackColor = Color.Silver) Then
                    TableLayoutPanel1.Controls.Item(i).BackColor = Color.White

                End If
            End If

        Next

        ' Dim sQry = "SELECT TT_Day, TT_Period, section_id FROM [V_TimeTable_2013] WHERE  (id IN (" & FacultyId & "))"
        Dim sQry = "Select TT_Day, TT_Period, section_id,faculty_id FROM M_Time_Table,CSF_Faculty
                    where faculty_id in (" & FacultyId & ") And CSF_Faculty.csf_id = M_Time_Table.CSF_Id"



        Dim cmd As New SqlCommand(sQry)

        Dim ad As SqlDataReader
        If cn.State = ConnectionState.Open Then cn.Close()
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        cmd.Connection = cn
        ad = cmd.ExecuteReader()
        Do While ad.Read
            TTFacAdd(ad.Item("TT_Day"), ad.Item("TT_Period"), ad.Item("Section_Id"))
            TTFillFacColor.SetValue(1, ad.Item("TT_Day"), ad.Item("TT_Period"))
        Loop
        If cn.State = ConnectionState.Open Then cn.Close()
    End Sub

    Sub LoadTT(ByVal SectionId As Integer)
        For i = 0 To TableLayoutPanel1.Controls.Count - 1
            TableLayoutPanel1.Controls.Item(i).Text = ""
        Next

        ' Dim sQry = "Select distinct TimeTableId, Section_Id, TT_Day, TT_Period, CSF_Id, Room_Id, Batch_Id, Abr_n As abr, 
        'Subject_Code, Subject, IsLab, Section_Name, Semester, Room, Group_Id  
        'From [V_TimeTable_2013] WHERE (TimeTableId = " & My.Settings.TTid & ") And (Section_id=" & SectionId & ")"
        Dim sQry = "SELECT DISTINCT 
        dbo.M_Time_Table.TimeTableId, dbo.M_Time_Table.Section_Id, dbo.M_Time_Table.TT_Day,dbo.M_Time_Table.TT_Period, 
        dbo.M_Time_Table.CSF_Id, dbo.M_Time_Table.Room_Id, dbo.M_Time_Table.Batch_Id, dbo.CSF_View.Teacher_Id AS Id, 
        dbo.CSF_View.Teacher_Name AS name, dbo.CSF_View.abbr AS abr, dbo.CSF_View.Subject_Code, 
        dbo.CSF_View.Subject_Name AS subject, dbo.CSF_View.IsLab, dbo.CSF_View.Name AS Section_Name, dbo.CSF_View.Semester, 
        CASE WHEN dbo.M_Room.Name IS NULL THEN ' ' ELSE dbo.M_Room.Name END AS Room, 
        dbo.M_Time_Table.Section_Group_Id AS Group_Id, dbo.CSF_View.Teacher_Id AS Faculty_Id, dbo.CSF_View.ProgramName, 
        dbo.CSF_View.school, dbo.M_Time_Table.ActivityTag, dbo.CSF_View.Teacher_Id2,dbo.CSF_View.Teacher_Name2, 
        dbo.CSF_View.abbr2, dbo.M_Time_Table.ContGroupCode, dbo.CSF_View.P, dbo.CSF_View.L, dbo.CSF_View.T
                         FROM  dbo.M_Time_Table INNER JOIN
                         dbo.CSF_View ON dbo.M_Time_Table.CSF_Id = dbo.CSF_View.CSF_Id LEFT OUTER JOIN
                         dbo.M_Room ON dbo.M_Time_Table.Room_Id = dbo.M_Room.room_Id
                         WHERE (TimeTableId = " & My.Settings.TTid & ") And (CSF_View.Section_id=" & SectionId & ")"
        Dim cmd As New SqlCommand(sQry)
        'SqlCommand cmd = new SqlCommand(sQry, GlobalCnx); 
        Dim ad As SqlDataReader
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        cmd.Connection = cn
        ad = cmd.ExecuteReader()
        Do While ad.Read
            If ad.Item("Batch_Id") <> 0 Then
                TTAdd(ad.Item("TT_Day"), ad.Item("TT_Period"), ad.Item("Subject_Code").ToString.Trim & " [" & ad.Item("ABR").ToString.Trim & "][" & ad.Item("rOOM").ToString.Trim & "][" & ad.Item("Batch_id").ToString.Trim & "]")
            Else
                TTAdd(ad.Item("TT_Day"), ad.Item("TT_Period"), ad.Item("Subject_Code").ToString.Trim & " [" & ad.Item("ABR").ToString.Trim & "][" & ad.Item("rOOM").ToString.Trim & "]")
            End If

        Loop

        If cn.State = ConnectionState.Open Then cn.Close()
        If cbSession.SelectedIndex = -1 Then Exit Sub
        ' disession = cbSession.SelectedItem
        'CSFUpdate(ToolStripComboBox2.ComboBox.SelectedValue, disession.Get_Id1)
        _section = cbSection.ComboBox.SelectedValue
        _currentSection = cbSection.ComboBox.SelectedValue

    End Sub

    Sub LoadTTAt(ByVal day As Integer, ByVal period As Integer, ByVal SectionId As Integer)
        LoadTT(SectionId)
    End Sub

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        LoginForm1.Close()
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn.ConnectionString = My.Settings.eCollegeConnectionString1

        If My.Settings.Username = "admin" Then ActionAdminMenu.Visible = True
        If My.Settings.Username = "admin" Then ActionsAutoMenu.Visible = True
        ' ToolStripMenuItem5.Text = My.Settings.Username.ToUpper


        Dim t As TimeTable = New TimeTable
        _Session = t.Session
        _SessionName = t.SessionName


        Me.Text = ApplicationName & " (" & _Session & "::" & _SessionName & ")"


        ' frmCourseStructure.ShowDialog()
        Dim schoolname As String = Module1._school
        ' schoolname = "all"
        userinfo.Text = UCase(schoolname)
        If UCase(schoolname.Trim) = "ALL" Then
            cbSchool.Visible = True
            ShowSchool()
        End If
        PaintForm(schoolname)

        'LoadLockTT(_currentSection)

    End Sub

    Private Sub PaintForm(schoolname As String)
        Try
            If schoolname = "all" Then
                Me.ProgramTableAdapter1.Fill(ECollegeDataSet.Program)
                Me.ActionAdminMenu.Enabled = True
            Else
                Me.ProgramTableAdapter1.FillBy(ECollegeDataSet.Program, schoolname)
            End If

            cbSession.ComboBox.DisplayMember = "name".Trim()
            cbSession.ComboBox.ValueMember = "Id"
            cbSession.ComboBox.DataSource = bsProgram
            cbSession.Invalidate()
            'My.Settings.ProgramFilter = False


            _Batch = 0
            bsSection.Filter = "ShowTimeTable=1"
            cbSection.ComboBox.DisplayMember = "name".Trim()
            cbSection.ComboBox.ValueMember = "Id"
            cbSection.ComboBox.DataSource = bsSection
            cbSection.Invalidate()
            _section = cbSection.ComboBox.SelectedValue
            _currentSection = cbSection.ComboBox.SelectedValue
            _currentSession = cbSession.ComboBox.SelectedValue
            CSFUpdate(_section)
            LoadTT(_section)
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ShowSchool()

        'TODO: This line of code loads data into the 'ECollegeDataSet.School' table. You can move, or remove it, as needed.
        Dim cmd As New SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim dts As New DataTable
        ' cn.ConnectionString = ("Data Source=NIMO-HP\SQLEXPRESS;Initial Catalog=FYP_db;Integrated Security=True")

        cmd.Connection = cn
        cmd.CommandText = "Select * from M_School"
        cmd.CommandType = CommandType.Text
        adapter.SelectCommand = cmd
        adapter.Fill(dts)
        cbSchool.DataSource = dts
        cbSchool.ValueMember = "Code"
        cbSchool.DisplayMember = "Code"
    End Sub

    Private Sub ToolStripComboBox2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CSFUpdate(cbSection.SelectedItem)
        _section = cbSection.SelectedItem
        LoadTT(cbSection.SelectedItem)
    End Sub

    Private Sub TTCellClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox2.Click, TextBox3.Click, TextBox4.Click, TextBox5.Click, TextBox6.Click, TextBox7.Click, TextBox8.Click, TextBox9.Click, TextBox10.Click, TextBox11.Click, TextBox12.Click, TextBox13.Click, TextBox14.Click, TextBox15.Click, TextBox16.Click, TextBox17.Click, TextBox18.Click, TextBox19.Click, TextBox20.Click, TextBox21.Click, TextBox22.Click, TextBox23.Click, TextBox24.Click, TextBox25.Click, TextBox26.Click, TextBox27.Click, TextBox28.Click, TextBox29.Click, TextBox30.Click, TextBox31.Click, TextBox32.Click, TextBox33.Click, TextBox34.Click, TextBox35.Click, TextBox36.Click, TextBox37.Click, TextBox38.Click, TextBox39.Click, TextBox40.Click, TextBox41.Click, TextBox42.Click, TextBox43.Click, TextBox44.Click, TextBox45.Click, TextBox46.Click, TextBox47.Click, TextBox48.Click, TextBox49.Click, TextBox50.Click, TextBox51.Click, TextBox52.Click, TextBox53.Click, TextBox54.Click, TextBox55.Click, TextBox56.Click, TextBox57.Click, TextBox58.Click, TextBox59.Click, TextBox60.Click, TextBox61.Click, TextBox62.Click, TextBox63.Click, TextBox64.Click, TextBox65.Click, TextBox66.Click, TextBox67.Click, TextBox68.Click, TextBox69.Click, TextBox70.Click, TextBox71.Click, TextBox72.Click, TextBox73.Click, TextBox74.Click, TextBox75.Click, TextBox76.Click, TextBox77.Click
        'TextBox1.GotFocus,
        RoomUpdate(sender)

        'MsgBox(e.ToString)
        '_TTIdCopy = My.Settings.TTid
        '_sectionCopy = _section
        '_TTDayCopy = TableLayoutPanel1.GetRow(sender.name) + 1
        '_TTPeriodCopy = TableLayoutPanel1.GetColumn(sender.name) + 1
        'DirectCast(sender, TextBox).SelectAll()
    End Sub

    Sub RoomUpdate(ByVal sender As Object)
        Dim ts As New Timesheet

        Dim da = TableLayoutPanel1.GetRow(sender) + 1
        Dim pr = TableLayoutPanel1.GetColumn(sender) + 1
        CheckRoomSchool()
        If _school = "NONE" Then
            ts.RoomUpdate(da, pr, DataGridView1)
        Else
            ts.RoomUpdate(da, pr, _school, DataGridView1)
        End If
    End Sub

    Sub CSFUpdate(ByVal SectionId As Integer)
        Dim sQry = "Select distinct csf_id,subject_code,abr_n As abr,cast(Teacher_id_n As varchar(10)) As id,Teacher_name As Name,l_load,L,T,P,LA,TA,PA,IsLab,subject_name As Subject  from CSF_View_with_Load WHERE SessionId=" & _Session & " AND (section_id=" & SectionId & ")"

        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            Dim ad As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            ad.Fill(ds)
            If ds.Tables.Count > 0 Then
                CSFList.DataSource = ds.Tables(0)
                CSFList.ClearSelection()
                CSFList.Rows(_currrow).Selected = True
            End If
        Catch ex As Exception

        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try


    End Sub

    Private Sub EditTT(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.DoubleClick, TextBox2.DoubleClick, TextBox3.DoubleClick, TextBox4.DoubleClick, TextBox5.DoubleClick, TextBox6.DoubleClick, TextBox7.DoubleClick, TextBox8.DoubleClick, TextBox9.DoubleClick, TextBox10.DoubleClick, TextBox11.DoubleClick, TextBox12.DoubleClick, TextBox13.DoubleClick, TextBox14.DoubleClick, TextBox15.DoubleClick, TextBox16.DoubleClick, TextBox17.DoubleClick, TextBox18.DoubleClick, TextBox19.DoubleClick, TextBox20.DoubleClick, TextBox21.DoubleClick, TextBox22.DoubleClick, TextBox23.DoubleClick, TextBox24.DoubleClick, TextBox25.DoubleClick, TextBox26.DoubleClick, TextBox27.DoubleClick, TextBox28.DoubleClick, TextBox29.DoubleClick, TextBox30.DoubleClick, TextBox31.DoubleClick, TextBox32.DoubleClick, TextBox33.DoubleClick, TextBox34.DoubleClick, TextBox35.DoubleClick, TextBox36.DoubleClick, TextBox37.DoubleClick, TextBox38.DoubleClick, TextBox39.DoubleClick, TextBox40.DoubleClick, TextBox41.DoubleClick, TextBox42.DoubleClick, TextBox43.DoubleClick, TextBox44.DoubleClick, TextBox45.DoubleClick, TextBox46.DoubleClick, TextBox47.DoubleClick, TextBox48.DoubleClick, TextBox49.DoubleClick, TextBox50.DoubleClick, TextBox51.DoubleClick, TextBox52.DoubleClick, TextBox53.DoubleClick, TextBox54.DoubleClick, TextBox55.DoubleClick, TextBox56.DoubleClick, TextBox57.DoubleClick, TextBox58.DoubleClick, TextBox59.DoubleClick, TextBox60.DoubleClick, TextBox61.DoubleClick, TextBox62.DoubleClick, TextBox63.DoubleClick, TextBox64.DoubleClick, TextBox65.DoubleClick, TextBox66.DoubleClick, TextBox67.DoubleClick, TextBox68.DoubleClick, TextBox69.DoubleClick, TextBox70.DoubleClick, TextBox71.DoubleClick, TextBox72.DoubleClick, TextBox73.DoubleClick, TextBox74.DoubleClick, TextBox75.DoubleClick, TextBox76.DoubleClick, TextBox77.DoubleClick
        Dim TTDay = TableLayoutPanel1.GetRow(sender) + 1
        Dim TTPeriod = TableLayoutPanel1.GetColumn(sender) + 1
        InsertTTCell(TTDay, TTPeriod)
    End Sub

    Sub InsertTTCell(TTDay, TTPeriod)
        Dim TTId As Integer = My.Settings.TTid
        Dim Sectionid As Integer = _section
        Dim ATAG As String = _atag
        Dim CSF_ID As Integer = _csf
        Dim RooM_ID As Integer = _room
        Dim BATCHID As Integer = _Batch
        Dim ISDEL As Integer = 0
        Dim sQry As String = ""
        Dim uid = My.Settings.Username
        If TableLayoutPanel1.GetControlFromPosition(TTPeriod - 1, TTDay - 1).BackColor = Color.Red Then Exit Sub
        If CSF_ID = 0 Then Exit Sub
        'If CheckBox1.Checked = True Then
        'sQry = "INSERT INTO  M_Time_Table  (TimeTableId, Section_Id, TT_Day, TT_Period, CSF_Id, Room_Id, Batch_Id, Section_Group_Id, MergeCSF, ActivityTag)"
        'sQry = sQry & "Select  " & TTId & " As TimeTableId ,   " & Sectionid & " As Section_Id,   " & TTDay & " As TT_Day,   " & TTPeriod & " As TT_Period, CSF_Id, Room_Id, Batch_Id, Section_Group_Id,MergeCSF,ActivityTag "
        'sQry = sQry & "FROM M_Time_Table "
        'sQry = sQry & "WHERE (TimeTableId = " & _TTIdCopy & ") And (Section_Id = " & _sectionCopy & ") And (TT_Day = " & _TTDayCopy & ") And (TT_Period = " & _TTPeriodCopy & ")"
        '
        'Else
        sQry = "Exec Timetablemanager @by=" & uid & " ,@session=" & _Session & " ,@TTId=" & TTId & ",@TTDay=" & TTDay & ",@TTPeriod=" & TTPeriod & ",@Sectionid=" & Sectionid & ",@CSF_ID= " & CSF_ID & ", @RooM_ID=" & RooM_ID & ",@BATCHID=" & BATCHID & ",@ISDEL=" & ISDEL & ",@atag=" & ATAG & ",@duration=" & _duration
        'MsgBox(sQry)
        'End If
        'Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(sQry, cn)

        cmd.ExecuteNonQuery()
        If cn.State = ConnectionState.Open Then cn.Close()
        'CSFList.Rows(_currrow).Cells(5).Value = CSFList.Rows(_currrow).Cells(5).Value + 1
        beforeDel = _currrow
        'CSFUpdate(cbSection.ComboBox.SelectedValue, disession.Get_Id1)
        CSFUpdate(cbSection.ComboBox.SelectedValue)
        'MsgBox(beforeDel)
        CSFList.ClearSelection()
        'CSFList.Rows(beforeDel).Selected = True
        Me.CSFList.Rows(beforeDel).Selected = True
        CSFList.FirstDisplayedScrollingRowIndex = beforeDel
        CSFList.CurrentCell = CSFList.Rows(beforeDel).Cells(0)

        ' CSFList.CurrentCell = CSFList.Rows(0).Cells(0)
        _Batch = 0
        UpdateBatchRadio()
        LoadTTAt(TTDay, TTPeriod, Sectionid)
        TTFacAdd(TTDay, TTPeriod, Sectionid)
        conflicts.ListFacConflict()
    End Sub



    Sub SetDefaultRoom()
        Dim TTId As Integer = My.Settings.TTid
        Dim sQry As String = ""
        sQry = "Update [M_time_table] "
        sQry = sQry & " Set Room_Id=" & _room
        sQry = sQry & " WHERE (TimeTableId = " & TTId & ") And (Section_Id = " & _section & ")  And (Batch_Id = 0) "
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(sQry, cn)
        cmd.ExecuteNonQuery()
        If cn.State = ConnectionState.Open Then cn.Close()
        LoadTT(_section)
    End Sub

    Sub DeleteTT(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown, TextBox4.KeyDown, TextBox5.KeyDown, TextBox6.KeyDown, TextBox7.KeyDown, TextBox8.KeyDown, TextBox9.KeyDown, TextBox10.KeyDown, TextBox11.KeyDown, TextBox12.KeyDown, TextBox13.KeyDown, TextBox14.KeyDown, TextBox15.KeyDown, TextBox16.KeyDown, TextBox17.KeyDown, TextBox18.KeyDown, TextBox19.KeyDown, TextBox20.KeyDown, TextBox21.KeyDown, TextBox22.KeyDown, TextBox23.KeyDown, TextBox24.KeyDown, TextBox25.KeyDown, TextBox26.KeyDown, TextBox27.KeyDown, TextBox28.KeyDown, TextBox29.KeyDown, TextBox30.KeyDown, TextBox31.KeyDown, TextBox32.KeyDown, TextBox33.KeyDown, TextBox34.KeyDown, TextBox35.KeyDown, TextBox36.KeyDown, TextBox37.KeyDown, TextBox38.KeyDown, TextBox39.KeyDown, TextBox40.KeyDown, TextBox41.KeyDown, TextBox42.KeyDown, TextBox43.KeyDown, TextBox44.KeyDown, TextBox45.KeyDown, TextBox46.KeyDown, TextBox47.KeyDown, TextBox48.KeyDown, TextBox49.KeyDown, TextBox50.KeyDown, TextBox51.KeyDown, TextBox52.KeyDown, TextBox53.KeyDown, TextBox54.KeyDown, TextBox55.KeyDown, TextBox56.KeyDown, TextBox57.KeyDown, TextBox58.KeyDown, TextBox59.KeyDown, TextBox60.KeyDown, TextBox61.KeyDown, TextBox62.KeyDown, TextBox63.KeyDown, TextBox64.KeyDown, TextBox65.KeyDown, TextBox66.KeyDown, TextBox67.KeyDown, TextBox68.KeyDown, TextBox69.KeyDown, TextBox70.KeyDown, TextBox71.KeyDown, TextBox72.KeyDown, TextBox73.KeyDown, TextBox74.KeyDown, TextBox75.KeyDown, TextBox76.KeyDown, TextBox77.KeyDown
        Dim result As Windows.Forms.DialogResult
        If e.KeyData = Keys.Delete Then
            'If CheckBox1.Checked = True Then
            '_TTIdCopy = My.Settings.TTid
            '_sectionCopy = _section
            '_TTDayCopy = TableLayoutPanel1.GetRow(sender) + 1
            '_TTPeriodCopy = TableLayoutPanel1.GetColumn(sender) + 1
            ' Else

            If My.Settings.DeleteConfirm = True Then
                    result = MessageBox.Show("Are you sure To delete?", "Time Table 2010", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                Else
                    result = Windows.Forms.DialogResult.Yes
                End If
                If result = Windows.Forms.DialogResult.Yes Then
                    Dim TTId As Integer = My.Settings.TTid
                Dim uid = My.Settings.Username
                Dim TTDay = TableLayoutPanel1.GetRow(sender) + 1
                    Dim TTPeriod = TableLayoutPanel1.GetColumn(sender) + 1
                    TableLayoutPanel1.GetControlFromPosition(TTPeriod - 1, TTDay - 1).BackColor = Color.White
                    Dim Sectionid As Integer = _section
                    Dim CSF_ID As Integer = _csf
                    Dim RooM_ID As Integer = _room
                    Dim BATCHID As Integer = _Batch
                    Dim ISDEL As Integer = 1
                Dim sQry = "Exec Timetablemanager @by=" & uid & " ,@session=" & _Session & " , @TTId=" & TTId & ",@TTDay=" & TTDay & ",@TTPeriod=" & TTPeriod & ",@Sectionid=" & Sectionid & ",@CSF_ID= " & CSF_ID & ", @RooM_ID=" & RooM_ID & ",@BATCHID=" & BATCHID & ",@ISDEL=" & ISDEL & ",@duration=" & _duration
                'Dim cn As New SqlConnection
                cn.ConnectionString = My.Settings.eCollegeConnectionString1
                    cn.Open()
                    Dim cmd As New SqlCommand(sQry, cn)
                    cmd.ExecuteNonQuery()
                    If cn.State = ConnectionState.Open Then cn.Close()
                    LoadTT(_section)

                    beforeDel = _currrow
                    'CSFUpdate(cbSection.ComboBox.SelectedValue, disession.Get_Id1)
                    CSFUpdate(cbSection.ComboBox.SelectedValue)
                    CSFList.ClearSelection()
                    Me.CSFList.Rows(beforeDel).Selected = True

                    CSFList.FirstDisplayedScrollingRowIndex = beforeDel
                    CSFList.CurrentCell = CSFList.Rows(beforeDel).Cells(0)
                    ''''''''''''''''''''''''''''''''''''''''''''''
                Else
                    Exit Sub
                End If
                ' End If
            End If
        CSFList.Refresh()
        Me.Refresh()
        conflicts.ListFacConflict()
    End Sub

    Private Sub CSFList_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CSFList.CellEndEdit
        Dim sQry As String = ""
        If (e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8) Then
            Try
                sQry = "UPDATE Subject Set L=" & CSFList(6, e.RowIndex).Value & ", T=" & CSFList(7, e.RowIndex).Value & ", P=" & CSFList(8, e.RowIndex).Value & " WHERE (Code = '" & CSFList(1, e.RowIndex).Value & "')"
                'Dim cn As New SqlConnection
                cn.ConnectionString = My.Settings.eCollegeConnectionString1
                cn.Open()
                ' MsgBox(sQry)
                Dim cmd As New SqlCommand(sQry, cn)
                cmd.ExecuteNonQuery()
                If cn.State = ConnectionState.Open Then cn.Close()
            Catch ex As Exception

            End Try

        End If
        If (e.ColumnIndex = 9 Or e.ColumnIndex = 10 Or e.ColumnIndex = 11) Then
            Try
                sQry = "UPDATE CSF SET LA=" & CSFList(9, e.RowIndex).Value & ", TA=" & CSFList(10, e.RowIndex).Value & ", PA=" & CSFList(11, e.RowIndex).Value & " WHERE (CSF_Id = '" & CSFList(0, e.RowIndex).Value & "')"
                'Dim cn As New SqlConnection
                cn.ConnectionString = My.Settings.eCollegeConnectionString1
                cn.Open()
                ' MsgBox(sQry)
                Dim cmd As New SqlCommand(sQry, cn)
                cmd.ExecuteNonQuery()
                If cn.State = ConnectionState.Open Then cn.Close()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub CSFList_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles CSFList.DataBindingComplete
        'CSFList.Rows(_currrow).Selected = True
        ColorCSFLTP()

    End Sub

    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FillByToolStripButton.Click
        Try
            ' Me.M_SessionTableAdapter.FillBy(Me.ECollegeDataSet1.M_Session)
            MessageBox.Show("Err:1")
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        LoadRoomTT(DataGridView1.Item(0, e.RowIndex).Value)
        _room = DataGridView1.Item(0, e.RowIndex).Value
        ToolStripLabel1.Text = "Current Room selected: " & DataGridView1.Item(1, e.RowIndex).Value
    End Sub

    Private Sub FillBy2ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' Me.M_SectionTableAdapter.FillBy2(Me.ECollegeDataSet.M_Section)
            MessageBox.Show("err:2")
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BatchF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchF.CheckedChanged
        _Batch = 0
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        _Batch = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        _Batch = 2
    End Sub
    Private Sub CSFList_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CSFList.RowEnter
        CSFSelect(e)
    End Sub
    Private Sub CSFList_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles CSFList.RowHeaderMouseClick

        CSFSelect(e)
    End Sub
    Private Sub CSFSelect(ByVal e As Object)
        _currrow = e.RowIndex
        _csf = CSFList.Item(0, e.RowIndex).Value
        Dim _atagTmp = CSFList.Item(12, e.RowIndex).Value
        If _atagTmp Then
            _atag = "Lab"
            _duration = CSFList.Item(8, e.RowIndex).Value
        Else
            _atag = "Lecture"
            _duration = 1
        End If
        tsLTPLabel.Text = _atag
        _currFacId = CSFList.Item(3, e.RowIndex).Value
        ToolStripTextBox1.Text = _csf
        LoadRoomTT(_room)
        ' MsgBox(_currFacId)
        ' MsgBox(_currFacId2)
        LoadFacTT(_currFacId, _currFacId2)
        LoadLockTT(_currentSection)
    End Sub

    Private Sub CSFList_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles CSFList.RowHeaderMouseDoubleClick

        Try
            _currrow = e.RowIndex
            _currentcsf = CSFList.Item(0, e.RowIndex).Value
            _currentfacids = CSFList.Item(3, e.RowIndex).Value
            _currentSection = cbSection.ComboBox.SelectedValue
            _currentSession = cbSession.ComboBox.SelectedValue
            ' MsgBox(_currentSession)
            Dim res = FRMcsfupdate.ShowDialog()
            If res = Windows.Forms.DialogResult.OK Then CSFUpdate(_section)
            If cbSession.SelectedIndex = -1 Then Exit Sub

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub ColorCSFLTP()
        Dim dr As DataGridViewRow
        For Each dr In CSFList.Rows
            Try
                Dim val1 As Integer = dr.Cells(5).Value
                Dim val3 As Integer = dr.Cells(8).Value
                Dim val2 As Integer = dr.Cells(9).Value + dr.Cells(10).Value + dr.Cells(11).Value
                If val1 = val2 Then dr.DefaultCellStyle.BackColor = Color.LightGreen
                If val1 > val2 Then dr.DefaultCellStyle.BackColor = Color.LightPink
                Dim font As Font = dr.DefaultCellStyle.Font
                If val3 > 0 Then dr.DefaultCellStyle.Font = New Font(font, System.Drawing.FontStyle.Bold)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub CheckTeacherConflictsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTeacherConflictsToolStripMenuItem.Click
        conflicts.ListFacConflict()
        conflicts.Show()

    End Sub

    Private Sub CheckRoomConflictsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckRoomConflictsToolStripMenuItem.Click
        conflicts.ListRoomConflict()
        conflicts.Show()

    End Sub

    Private Sub SetDefaultRoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetDefaultRoomToolStripMenuItem.Click
        SetDefaultRoom()
    End Sub

    Private Sub TeachersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TeachersToolStripMenuItem.Click
        'Dim fEmp As New frmEmployee
        Dim fEmp As New frmTeacher
        fEmp.ShowDialog()
    End Sub

    'Private Sub SubjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim fSub As New frmSubject
    '    fSub.ShowDialog()
    'End Sub

    Private Sub SectionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SectionsToolStripMenuItem.Click
        Dim fSec As New frmSection
        fSec.ShowDialog()
    End Sub

    Private Sub CSFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CSFToolStripMenuItem.Click
        Try
            _currentcsf = -1
            _currentSection = cbSection.ComboBox.SelectedValue
            Dim res = FRMcsfupdate.ShowDialog()
            If res = Windows.Forms.DialogResult.OK Then CSFUpdate(_section)
            If cbSession.SelectedIndex = -1 Then Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Dim fcsf As New frmCSF
        'fcsf.ShowDialog()
    End Sub

    Private Sub RoomsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomsToolStripMenuItem.Click
        Dim froom As New frmRoom
        froom.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Form1_Load(Nothing, Nothing)
    End Sub


    Private Sub SelctBatchG1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelctBatchG1ToolStripMenuItem.Click
        _Batch = 1
        UpdateBatchRadio()
    End Sub

    Private Sub SelectBatchG2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectBatchG2ToolStripMenuItem.Click
        _Batch = 2
        UpdateBatchRadio()
    End Sub
    Private Sub UpdateBatchRadio()
        If _Batch = 0 Then BatchF.Checked = True
        If _Batch = 1 Then RadioButton1.Checked = True
        If _Batch = 2 Then RadioButton2.Checked = True
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        _Batch = 0
        UpdateBatchRadio()

    End Sub

    Private Sub TimetablesPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimetablesPreviewToolStripMenuItem.Click
        GetPreview()
    End Sub




    Private Sub PublishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PublishToolStripMenuItem.Click
        'Dim DBSchema As New sq
        Dim DBTableNames As New DataTable
        Dim ds As New DataSet
        'Dim DBTableRow As DataRow
        Dim SQLString As String
        SQLString = "Select * from V_Timetable_2013"
        ' Dim cmd As SqlCommand
        Dim DbConnection As New SqlConnection
        DbConnection.ConnectionString = My.Settings.eCollegeConnectionString1
        Dim ad As New SqlDataAdapter
        ad.SelectCommand = New SqlCommand(SQLString, DbConnection)
        Dim dbc As SqlCommandBuilder
        dbc = New SqlCommandBuilder(ad)
        Try
            ad.Fill(ds)
        Catch eror As Exception
            MessageBox.Show(eror.Message)
        Finally
            dbc.Dispose()
            ad.Dispose()
            DbConnection.Close()
        End Try

        Try
            ds.WriteXml("D:\BackUp.xml")
            ds.WriteXmlSchema("D:\BackUp.xsd")
        Catch
        End Try

    End Sub



    Private Sub ExportTeacherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportTeacherToolStripMenuItem.Click
        Dim q1 As String = "SELECT distinct [name] FROM [Teacher]"
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(q1, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim Str As String = """" & "Teacher" & """"
        While rd.Read
            Str += vbNewLine & """" & rd(0) & """"
        End While
        cn.Close()
        Dim w As StreamWriter
        w = File.CreateText(_pathToImport & "\gbu2014_teachers.csv")
        w.Write(Str)
        w.Flush()
        w.Close()

    End Sub

    Private Sub ExportSubjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSubjectToolStripMenuItem.Click
        Dim q1 As String = "SELECT distinct [name] FROM [Subject]"
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(q1, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim Str As String = """" & "Subject" & """"
        While rd.Read
            Str += vbNewLine & """" & rd(0) & """"
        End While
        cn.Close()
        Dim w As StreamWriter
        w = File.CreateText(_pathToImport & "\gbu2014_subjects.csv")
        w.Write(Str)
        w.Flush()
        w.Close()
    End Sub

    Private Sub ExportSectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportSectionsToolStripMenuItem.Click
        Dim q1 As String = "SELECT * FROM [Section]"
        ' MsgBox(q1)
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(q1, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim Str As String = """Year"",""Number of Students per Year"",""Group"",""Number of Students per Group"",""Subgroup"",""Number of Students per Subgroup"""

        ' """Year","Number of Students per Year","Group","Number of Students per Group","Subgroup","Number of Students per Subgroup"""
        While rd.Read
            If rd(8) = 1 Then Str += vbNewLine & """" & rd(1).ToString.Trim & """," & """" & 60 & """," & """" & "" & """," & """" & "" & """," & """" & "" & """," & """" & "" & """"
            If rd(8) = 2 Then
                Str += vbNewLine & """" & rd(1).ToString.Trim & """," & """" & 60 & """," & """" & rd(1).ToString.Trim & "-G1" & """," & """" & 30 & """," & """" & "" & """," & """" & "" & """"
                Str += vbNewLine & """" & rd(1).ToString.Trim & """," & """" & 60 & """," & """" & rd(1).ToString.Trim & "-G2" & """," & """" & 30 & """," & """" & "" & """," & """" & "" & """"
            End If
        End While
        cn.Close()
        Dim w As StreamWriter
        w = File.CreateText(_pathToImport & "\gbu2014_students.csv")
        w.Write(Str)
        w.Flush()
        w.Close()
    End Sub

    Private Sub ExportRoomsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportRoomsToolStripMenuItem.Click
        Dim q1 As String = "SELECT * FROM [M_Room]"
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(q1, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim Str As String = """Room"",""Room Capacity"",""Building"""
        ' """Year","Number of Students per Year","Group","Number of Students per Group","Subgroup","Number of Students per Subgroup"""
        While rd.Read
            Str += vbNewLine & """" & rd(1).ToString.Trim & """," & """" & rd(4) & """," & """" & rd(7) & """"
        End While
        cn.Close()
        Dim w As StreamWriter
        w = File.CreateText(_pathToImport & "\gbu2014_rooms_and_buildings.csv")
        w.Write(Str)
        w.Flush()
        w.Close()
    End Sub

    Private Sub ExportCSFToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportCSFToolStripMenuItem.Click
        Dim q1 As String = "SELECT [Name],[Subject_Code],[Teacher_Name],* FROM [CSF_View]"
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(q1, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim Str As String = """Students Sets"",""Subject"",""Teachers"",""Activity Tags"",""Total Duration"",""Split Duration"",""Min Days"",""Weight"",""Consecutive"""
        '"""Students Sets"",""Subject"",""Teachers"",""Activity Tags"",""Total Duration"","Split Duration"",""Min Days"",""Weight"",""Consecutive"""
        ' """Year","Number of Students per Year","Group","Number of Students per Group","Subgroup","Number of Students per Subgroup"""
        While rd.Read
            Str += vbNewLine & """" & rd(0).ToString.Trim & """," & """" & rd(1).ToString.Trim & """," & """" & rd(2) & """," & """" & "Lecture" & """," & 3 & ",""""," & 1 & "," & ","
        End While
        cn.Close()
        Dim w As StreamWriter
        w = File.CreateText(_pathToImport & "\gbu2014_activities.csv")
        w.Write(Str)
        w.Flush()
        w.Close()
    End Sub



    Private Sub ImportNWToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportNWToolStripMenuItem.Click
        ' MsgBox("Automatic Timetable Not Functional in this version")
        Dim fITT As New frmImportTimetable
        fITT.ShowDialog()
    End Sub

    Private Sub ExportActivitiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportActivitiesToolStripMenuItem.Click
        'Dim q1 As String = "SELECT [Name],[Subject_Code],[Teacher_Name],* FROM [TIMETABLE_JAN2014.MDF].[dbo].[CSF_View]"
        Dim q1 As String = "SELECT  [Name], [Subject_Code], [Teacher_Name], [Subject_Id], [L], [T], [P]  FROM [CSF_View] where sessionid=" & _Session

        'SELECT   Section_Id, Subject_Code, Faculty_Id, Subject_ID, CreationDate, IsRemoved, LA, TA, PA
        'FROM(CSF)

        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(q1, cn)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim Str As String = """Students Sets"",""Subject"",""Teachers"",""Activity Tags"",""Total Duration"",""Split Duration"",""Min Days"",""Weight"",""Consecutive"""
        '"""Students Sets"",""Subject"",""Teachers"",""Activity Tags"",""Total Duration"","Split Duration"",""Min Days"",""Weight"",""Consecutive"""
        ' """Year","Number of Students per Year","Group","Number of Students per Group","Subgroup","Number of Students per Subgroup"""
        While rd.Read
            If rd(4) > 0 Then Str += vbNewLine & """" & rd(0).ToString.Trim & """," & """" & rd(1).ToString.Trim & """," & """" & rd(2) & """," & """" & "Lecture" & """," & rd(4) & ",""""," & 1 & "," & ","
            If rd(5) > 0 Then
                If rd(5) = 1 Then Str += vbNewLine & """" & rd(0).ToString.Trim & """," & """" & rd(1).ToString.Trim & """," & """" & rd(2) & """," & """" & "Tutorial" & """," & rd(5) & ",""""," & 1 & "," & ","
                If rd(5) = 2 Then
                    Str += vbNewLine & """" & rd(0).ToString.Trim & "-G1" & """," & """" & rd(1).ToString.Trim & """," & """" & rd(2) & """," & """" & "Tutorial" & """," & 1 & ",""""," & 1 & "," & ","
                    Str += vbNewLine & """" & rd(0).ToString.Trim & "-G2" & """," & """" & rd(1).ToString.Trim & """," & """" & rd(2) & """," & """" & "Tutorial" & """," & 1 & ",""""," & 1 & "," & ","
                End If
            End If
            If rd(6) > 0 Then Str += vbNewLine & """" & rd(0).ToString.Trim & """," & """" & rd(1).ToString.Trim & """," & """" & rd(2) & """," & """" & "Lab" & """," & rd(6) & ",""2""," & 1 & "," & ","
        End While
        cn.Close()
        Dim w As StreamWriter
        w = File.CreateText(_pathToImport & "\gbu2014_activities.csv")
        w.Write(Str)
        w.Flush()
        w.Close()
    End Sub


    Private Sub CheckRoomSchool()
        If rSOBT.Checked Then _school = "SOBT"
        If rSOE.Checked Then _school = "SOE"
        If rICT.Checked Then _school = "SOICT"
        If rSOM.Checked Then _school = "SOM"
        If rSOVSAS.Checked Then _school = "SOVSAS"
        If rSOHSS.Checked Then _school = "SOHSS"
        If rSOBSC.Checked Then _school = "SOBSC"
        If rSOLJ.Checked Then _school = "SOLJ"
        If rAll.Checked Then _school = "NONE"
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        'MsgBox(DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value)
        LoadRoomTT(DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value)
        _room = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        ToolStripLabel1.Text = "Current Room selected: " & DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value
    End Sub

    Private Sub TableLayoutPanel1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TableLayoutPanel1.MouseClick
        Dim TTDay = TableLayoutPanel1.GetRow(sender) + 1
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show()
            MsgBox(TTDay)
        End If
    End Sub



    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        GetPreview()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click

        _TTIdCopy = My.Settings.TTid
        _sectionCopy = _section
        _TTDayCopy = TableLayoutPanel1.GetRow(ContextMenuStrip1.SourceControl) + 1
        _TTPeriodCopy = TableLayoutPanel1.GetColumn(ContextMenuStrip1.SourceControl) + 1
        _isCut = False
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem1.Click
        sender = ContextMenuStrip1.SourceControl
        Dim TTId As Integer = My.Settings.TTid
        Dim TTDay = TableLayoutPanel1.GetRow(sender) + 1
        Dim TTPeriod = TableLayoutPanel1.GetColumn(sender) + 1
        Dim Sectionid As Integer = _section
        Dim ATAG As String = _atag
        Dim CSF_ID As Integer = _csf
        Dim RooM_ID As Integer = _room
        Dim BATCHID As Integer = _Batch
        Dim ISDEL As Integer = 0
        Dim sQry As String = ""
        Dim sQry2 As String = "DELETE FROM M_Time_Table WHERE (TimeTableId = " & _TTIdCopy & ") And (Section_Id = " & _sectionCopy & ") And (TT_Day = " & _TTDayCopy & ") And (TT_Period = " & _TTPeriodCopy & ")"
        If CSF_ID = 0 Then Exit Sub
        'If CheckBox1.Checked = True Then
        sQry = "INSERT INTO  M_Time_Table  (TimeTableId, Section_Id, TT_Day, TT_Period, CSF_Id, Room_Id, Batch_Id, Section_Group_Id, MergeCSF, ActivityTag,UpdatedBy,sessionId)"
        sQry = sQry & "SELECT  " & TTId & " as TimeTableId ,   " & Sectionid & " as Section_Id,   " & TTDay & " as TT_Day,   " & TTPeriod & " as TT_Period, CSF_Id, Room_Id, Batch_Id, Section_Group_Id,MergeCSF,ActivityTag,UpdatedBy,sessionId "
        sQry = sQry & "FROM M_Time_Table "
        sQry = sQry & "WHERE (TimeTableId = " & _TTIdCopy & ") And (Section_Id = " & _sectionCopy & ") And (TT_Day = " & _TTDayCopy & ") And (TT_Period = " & _TTPeriodCopy & ")"

        'Else
        '    sQry = "Exec Timetablemanager @TTId=" & TTId & ",@TTDay=" & TTDay & ",@TTPeriod=" & TTPeriod & ",@Sectionid=" & Sectionid & ",@CSF_ID= " & CSF_ID & ", @RooM_ID=" & RooM_ID & ",@BATCHID=" & BATCHID & ",@ISDEL=" & ISDEL & ",@atag=" & ATAG & ",@duration=" & _duration
        'End If
        'Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        Dim cmd As New SqlCommand(sQry, cn)
        Dim cmd2 As New SqlCommand(sQry2, cn)
        cmd.ExecuteNonQuery()
        If _isCut Then
            cmd2.ExecuteNonQuery()
        End If
        If cn.State = ConnectionState.Open Then cn.Close()
        'CSFList.Rows(_currrow).Cells(5).Value = CSFList.Rows(_currrow).Cells(5).Value + 1
        beforeDel = _currrow
        'CSFUpdate(cbSection.ComboBox.SelectedValue, disession.Get_Id1)
        CSFUpdate(cbSection.ComboBox.SelectedValue)
        'MsgBox(beforeDel)
        CSFList.ClearSelection()
        'CSFList.Rows(beforeDel).Selected = True
        Me.CSFList.Rows(beforeDel).Selected = True
        CSFList.FirstDisplayedScrollingRowIndex = beforeDel
        CSFList.CurrentCell = CSFList.Rows(beforeDel).Cells(0)

        ' CSFList.CurrentCell = CSFList.Rows(0).Cells(0)
        _Batch = 0
        UpdateBatchRadio()
        LoadTTAt(TTDay, TTPeriod, Sectionid)
        TTFacAdd(TTDay, TTPeriod, Sectionid)
        conflicts.ListFacConflict()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        'CUT
        _TTIdCopy = My.Settings.TTid
        _sectionCopy = _section
        _TTDayCopy = TableLayoutPanel1.GetRow(ContextMenuStrip1.SourceControl) + 1
        _TTPeriodCopy = TableLayoutPanel1.GetColumn(ContextMenuStrip1.SourceControl) + 1
        _isCut = True
    End Sub

    Private Sub SwapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwapToolStripMenuItem.Click
        'Swap (i,j)
        If _isSwap Then
            Dim iTTDay = _TTDayCopy
            Dim iTTPeriod = _TTPeriodCopy
            _TTDayCopy = TableLayoutPanel1.GetRow(ContextMenuStrip1.SourceControl) + 1
            _TTPeriodCopy = TableLayoutPanel1.GetColumn(ContextMenuStrip1.SourceControl) + 1
            Swap(iTTDay, iTTPeriod, _TTDayCopy, _TTPeriodCopy)
            SwapToolStripMenuItem.Text = "Select to Swap."
            _isSwap = False
        Else
            SwapToolStripMenuItem.Text = "Swap Here."
            _isSwap = True
            _TTIdCopy = My.Settings.TTid
            _sectionCopy = _section
            _TTDayCopy = TableLayoutPanel1.GetRow(ContextMenuStrip1.SourceControl) + 1
            _TTPeriodCopy = TableLayoutPanel1.GetColumn(ContextMenuStrip1.SourceControl) + 1
        End If


    End Sub
    Private Sub Swap(iDay As Integer, iPeriod As Integer, jDay As Integer, jPeriod As Integer)
        Dim sQry, sQry1, sQry2
        Dim transaction As SqlTransaction

        sQry = "UPDate  M_Time_Table SET TT_Day=0, TT_Period=0"
        sQry = sQry & "WHERE (TimeTableId = " & _TTIdCopy & ") And (Section_Id = " & _sectionCopy & ") And (TT_Day = " & iDay & ") And (TT_Period = " & iPeriod & ")"

        sQry1 = "UPDate  M_Time_Table SET TT_Day=" & iDay & ", TT_Period=" & iPeriod
        sQry1 = sQry1 & "WHERE (TimeTableId = " & _TTIdCopy & ") And (Section_Id = " & _sectionCopy & ") And (TT_Day = " & jDay & ") And (TT_Period = " & jPeriod & ")"

        sQry2 = "UPDate  M_Time_Table SET TT_Day=" & jDay & ", TT_Period=" & jPeriod
        sQry2 = sQry2 & "WHERE (TimeTableId = " & _TTIdCopy & ") And (Section_Id = " & _sectionCopy & ") And (TT_Day = 0) And (TT_Period = 0)"

        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        cn.Open()
        transaction = cn.BeginTransaction("SampleTransaction")
        Dim cmd As New SqlCommand(sQry, cn)
        Dim cmd1 As New SqlCommand(sQry1, cn)
        Dim cmd2 As New SqlCommand(sQry2, cn)
        cmd.Transaction = transaction
        cmd1.Transaction = transaction
        cmd2.Transaction = transaction
        Try
            cmd.ExecuteNonQuery()
            cmd1.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()

            transaction.Commit()
        Catch ex As Exception
            MsgBox(ex.Message)
            Try
                transaction.Rollback()

            Catch ex2 As Exception
                ' This catch block will handle any errors that may have occurred 
                ' on the server that would cause the rollback to fail, such as 
                ' a closed connection.
                'Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                MsgBox("  Message: {0}", ex2.Message)
            End Try
        End Try

        If cn.State = ConnectionState.Open Then cn.Close()
        'CSFList.Rows(_currrow).Cells(5).Value = CSFList.Rows(_currrow).Cells(5).Value + 1
        beforeDel = _currrow
        'CSFUpdate(cbSection.ComboBox.SelectedValue, disession.Get_Id1)
        CSFUpdate(cbSection.ComboBox.SelectedValue)
        'MsgBox(beforeDel)
        CSFList.ClearSelection()
        'CSFList.Rows(beforeDel).Selected = True
        Me.CSFList.Rows(beforeDel).Selected = True
        CSFList.FirstDisplayedScrollingRowIndex = beforeDel
        CSFList.CurrentCell = CSFList.Rows(beforeDel).Cells(0)

        ' CSFList.CurrentCell = CSFList.Rows(0).Cells(0)
        _Batch = 0
        UpdateBatchRadio()
        LoadTTAt(iDay, iPeriod, _sectionCopy)
        TTFacAdd(iDay, iPeriod, _sectionCopy)
        conflicts.ListFacConflict()
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        Dim result
        sender = ContextMenuStrip1.SourceControl
        If My.Settings.DeleteConfirm = True Then
            result = MessageBox.Show("Are you sure to delete?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        Else
            result = Windows.Forms.DialogResult.Yes
        End If
        If result = Windows.Forms.DialogResult.Yes Then
            Dim TTId As Integer = My.Settings.TTid

            Dim TTDay = TableLayoutPanel1.GetRow(sender) + 1
            Dim TTPeriod = TableLayoutPanel1.GetColumn(sender) + 1
            TableLayoutPanel1.GetControlFromPosition(TTPeriod - 1, TTDay - 1).BackColor = Color.White
            Dim Sectionid As Integer = _section
            Dim CSF_ID As Integer = _csf
            Dim RooM_ID As Integer = _room
            Dim BATCHID As Integer = _Batch
            Dim ISDEL As Integer = 1
            Dim sQry = "Exec Timetablemanager @by=" & My.Settings.Username & " ,@session=" & _Session & " ,@TTId=" & TTId & ",@TTDay=" & TTDay & ",@TTPeriod=" & TTPeriod & ",@Sectionid=" & Sectionid & ",@CSF_ID= " & CSF_ID & ", @RooM_ID=" & RooM_ID & ",@BATCHID=" & BATCHID & ",@ISDEL=" & ISDEL & ",@duration=" & _duration
            'Dim cn As New SqlConnection
            cn.ConnectionString = My.Settings.eCollegeConnectionString1
            cn.Open()
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.ExecuteNonQuery()
            If cn.State = ConnectionState.Open Then cn.Close()
            LoadTT(_section)

            beforeDel = _currrow
            'CSFUpdate(cbSection.ComboBox.SelectedValue, disession.Get_Id1)
            CSFUpdate(cbSection.ComboBox.SelectedValue)
            CSFList.ClearSelection()
            Me.CSFList.Rows(beforeDel).Selected = True

            CSFList.FirstDisplayedScrollingRowIndex = beforeDel
            CSFList.CurrentCell = CSFList.Rows(beforeDel).Cells(0)
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim c As New frmMultiSectionView
        c.Show()
    End Sub


    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        UploadThisTimetable()
    End Sub

    Private Sub UploadThisTimetable()
        ' TimetableView.Form1.doSection(7)
        Dim tup As New TTUpload
        tup.doSection(_section)
        'tup.UploadNow()
        tup.UploadNow2()

    End Sub


    Private Sub cbSection_GotFocus(sender As Object, e As EventArgs) Handles cbSection.GotFocus
        If cbSection.SelectedIndex = -1 Then Exit Sub
        Try
            CSFUpdate(cbSection.ComboBox.SelectedValue)
            _section = cbSection.ComboBox.SelectedValue
            _currentSection = _section
            LoadTT(cbSection.ComboBox.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSection.SelectedIndexChanged
        If cbSection.SelectedItem Is Nothing Then Exit Sub
        Try
            CSFUpdate(cbSection.ComboBox.SelectedValue)
            _section = cbSection.ComboBox.SelectedValue
            _currentSection = _section
            LoadTT(cbSection.ComboBox.SelectedValue)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub




    Private Sub FillByToolStripButton1_Click(sender As Object, e As EventArgs) Handles FillByToolStripButton1.Click
        Try
            Me.ProgramTableAdapter1.FillBy(Me.ECollegeDataSet.Program, SchoolToolStripTextBox.Text)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            _currentcsf = -1
            _currentSection = cbSection.ComboBox.SelectedValue
            _currentSession = cbSession.ComboBox.SelectedValue

            Dim res = FRMcsfnew.ShowDialog()
            If res = Windows.Forms.DialogResult.OK Then CSFUpdate(_section)
            If cbSession.SelectedIndex = -1 Then Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub TTCellClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox1.GotFocus, TextBox2.Click, TextBox3.Click, TextBox4.Click, TextBox5.Click, TextBox6.Click, TextBox7.Click, TextBox8.Click, TextBox9.Click, TextBox10.Click, TextBox11.Click, TextBox12.Click, TextBox13.Click, TextBox14.Click, TextBox15.Click, TextBox16.Click, TextBox17.Click, TextBox18.Click, TextBox19.Click, TextBox20.Click, TextBox21.Click, TextBox22.Click, TextBox23.Click, TextBox24.Click, TextBox25.Click, TextBox26.Click, TextBox27.Click, TextBox28.Click, TextBox29.Click, TextBox30.Click, TextBox31.Click, TextBox32.Click, TextBox33.Click, TextBox34.Click, TextBox35.Click, TextBox36.Click, TextBox37.Click, TextBox38.Click, TextBox39.Click, TextBox40.Click, TextBox41.Click, TextBox42.Click, TextBox43.Click, TextBox44.Click, TextBox45.Click, TextBox46.Click, TextBox47.Click, TextBox48.Click, TextBox49.Click, TextBox50.Click, TextBox51.Click, TextBox52.Click, TextBox53.Click, TextBox54.Click, TextBox55.Click, TextBox56.Click, TextBox57.Click, TextBox58.Click, TextBox59.Click, TextBox60.Click, TextBox61.Click, TextBox62.Click, TextBox63.Click, TextBox64.Click, TextBox65.Click, TextBox66.Click, TextBox67.Click, TextBox68.Click, TextBox69.Click, TextBox70.Click
    '    Dim msg = WeekdayName(TableLayoutPanel1.GetRow(sender) + 1) & " (" & TableLayoutPanel1.GetColumn(sender) + 1 & ")"
    '    RoomUpdate(sender)
    '    ToolTip1.Show(msg, sender)
    'End Sub

    'Sub ShowHint(sender As Object, e As EventArgs) Handles TextBox1.MouseHover, TextBox2.MouseHover, TextBox3.MouseHover, TextBox4.MouseHover, TextBox5.MouseHover, TextBox6.MouseHover, TextBox7.MouseHover, TextBox8.MouseHover, TextBox9.MouseHover, TextBox10.MouseHover, TextBox11.MouseHover, TextBox12.MouseHover, TextBox13.MouseHover, TextBox14.MouseHover, TextBox15.MouseHover, TextBox16.MouseHover, TextBox17.MouseHover, TextBox18.MouseHover, TextBox19.MouseHover, TextBox20.MouseHover, TextBox21.MouseHover, TextBox22.MouseHover, TextBox23.MouseHover, TextBox24.MouseHover, TextBox25.MouseHover, TextBox26.MouseHover, TextBox27.MouseHover, TextBox28.MouseHover, TextBox29.MouseHover, TextBox30.MouseHover, TextBox31.MouseHover, TextBox32.MouseHover, TextBox33.MouseHover, TextBox34.MouseHover, TextBox35.MouseHover, TextBox36.MouseHover, TextBox37.MouseHover, TextBox38.MouseHover, TextBox39.MouseHover, TextBox40.MouseHover, TextBox41.MouseHover, TextBox42.MouseHover, TextBox43.MouseHover, TextBox44.MouseHover, TextBox45.MouseHover, TextBox46.MouseHover, TextBox47.MouseHover, TextBox48.MouseHover, TextBox49.MouseHover, TextBox50.MouseHover, TextBox51.MouseHover, TextBox52.MouseHover, TextBox53.MouseHover, TextBox54.MouseHover, TextBox55.MouseHover, TextBox56.MouseHover, TextBox57.MouseHover, TextBox58.MouseHover, TextBox59.MouseHover, TextBox60.MouseHover, TextBox61.MouseHover, TextBox62.MouseHover, TextBox63.MouseHover, TextBox64.MouseHover, TextBox65.MouseHover, TextBox66.MouseHover, TextBox67.MouseHover, TextBox68.MouseHover, TextBox69.MouseHover, TextBox70.MouseHover
    '    Dim msg = WeekdayName(TableLayoutPanel1.GetRow(sender) + 1) & " (" & TableLayoutPanel1.GetColumn(sender) + 1 & ")"
    '    ToolTip1.Show(msg, sender)
    'End Sub
    Sub ShowHint(sender As Object, e As EventArgs) Handles TextBox1.MouseEnter, TextBox2.MouseEnter, TextBox3.MouseEnter, TextBox4.MouseEnter, TextBox5.MouseEnter, TextBox6.MouseEnter, TextBox7.MouseEnter, TextBox8.MouseEnter, TextBox9.MouseEnter, TextBox10.MouseEnter, TextBox11.MouseEnter, TextBox12.MouseEnter, TextBox13.MouseEnter, TextBox14.MouseEnter, TextBox15.MouseEnter, TextBox16.MouseEnter, TextBox17.MouseEnter, TextBox18.MouseEnter, TextBox19.MouseEnter, TextBox20.MouseEnter, TextBox21.MouseEnter, TextBox22.MouseEnter, TextBox23.MouseEnter, TextBox24.MouseEnter, TextBox25.MouseEnter, TextBox26.MouseEnter, TextBox27.MouseEnter, TextBox28.MouseEnter, TextBox29.MouseEnter, TextBox30.MouseEnter, TextBox31.MouseEnter, TextBox32.MouseEnter, TextBox33.MouseEnter, TextBox34.MouseEnter, TextBox35.MouseEnter, TextBox36.MouseEnter, TextBox37.MouseEnter, TextBox38.MouseEnter, TextBox39.MouseEnter, TextBox40.MouseEnter, TextBox41.MouseEnter, TextBox42.MouseEnter, TextBox43.MouseEnter, TextBox44.MouseEnter, TextBox45.MouseEnter, TextBox46.MouseEnter, TextBox47.MouseEnter, TextBox48.MouseEnter, TextBox49.MouseEnter, TextBox50.MouseEnter, TextBox51.MouseEnter, TextBox52.MouseEnter, TextBox53.MouseEnter, TextBox54.MouseEnter, TextBox55.MouseEnter, TextBox56.MouseEnter, TextBox57.MouseEnter, TextBox58.MouseEnter, TextBox59.MouseEnter, TextBox60.MouseEnter, TextBox61.MouseEnter, TextBox62.MouseEnter, TextBox63.MouseEnter, TextBox64.MouseEnter, TextBox65.MouseEnter, TextBox66.MouseEnter, TextBox67.MouseEnter, TextBox68.MouseEnter, TextBox69.MouseEnter, TextBox70.MouseEnter, TextBox71.MouseEnter, TextBox72.MouseEnter, TextBox73.MouseEnter, TextBox74.MouseEnter, TextBox75.MouseEnter, TextBox76.MouseEnter, TextBox77.MouseEnter
        Dim msg = WeekdayName(TableLayoutPanel1.GetRow(sender) + 1,, FirstDayOfWeek.Monday) & " (" & PeriodToTime(TableLayoutPanel1.GetColumn(sender) + 1) & ")"

        ToolTip1.Show(msg, sender, 1000)
        tslDayTime.Text = msg
        ToolTip1.Show(msg, sender, 1000)
    End Sub

    Private Function PeriodToTime(n As Integer)
        Dim TimeString
        If n > 5 Then
            TimeString = Str((7 + n) Mod 12) + ":30"
        Else
            TimeString = Str((7 + n)) + ":30"
        End If

        Return TimeString
    End Function

    Private Sub SchoolRoom(sender As Object, e As EventArgs) Handles rSOE.CheckedChanged, rSOBSC.CheckedChanged, rSOBT.CheckedChanged, rSOHSS.CheckedChanged, rSOLJ.CheckedChanged, rSOM.CheckedChanged, rSOVSAS.CheckedChanged, rICT.CheckedChanged, rAll.CheckedChanged
        Dim ts As New Timesheet
        'CheckRoomSchool()

        _school = sender.text.trim

        ToolStripTextBox1.Text = _school

        If _school = "All" Then
            ts.RoomUpdate(0, 0, DataGridView1)
        Else
            ts.RoomUpdate(0, 0, _school, DataGridView1)
        End If
    End Sub

    'Private Sub FacultyWiseAllocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacultyWiseAllocationToolStripMenuItem.Click
    '    frmFacultyWiseAllocation.ShowDialog()
    'End Sub


    Private Sub ColorModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorModeToolStripMenuItem.Click
        _colorMode = Not _colorMode
    End Sub

    Private Sub UploadPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadPDFToolStripMenuItem.Click
        Dim tup As New TTUpload
        OpenFileDialog1.DefaultExt = "pdf"
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            tup.PDFUpload(_section, OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub UploadLocalPortalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadLocalPortalToolStripMenuItem.Click
        UploadThisTimetable()
    End Sub

    Private Sub QuickInsertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickInsertToolStripMenuItem.Click
        Try
            '    _currentcsf = -1
            _currentSection = cbSection.ComboBox.SelectedValue
            _currentSession = cbSession.ComboBox.SelectedValue

            Dim TTDay = TableLayoutPanel1.GetRow(ContextMenuStrip1.SourceControl) + 1
            Dim TTPeriod = TableLayoutPanel1.GetColumn(ContextMenuStrip1.SourceControl) + 1

            Dim options = New frmQuickInsert

            Dim res = options.ShowDialog()
            If Res = Windows.Forms.DialogResult.OK Then
                _csf = options._currentcsf
                InsertTTCell(TTDay, TTPeriod)
            End If
            If cbSession.SelectedIndex = -1 Then Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbSession_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSession.SelectedIndexChanged
        ' If cbSession.SelectedIndex = -1 Then Exit Sub
        Try
            _currentSession = cbSession.ComboBox.SelectedValue
            Me.SectionTableAdapter.FillBy1(Me.ECollegeDataSet.Section, _currentSession)

            cbSection.Focus()
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ConvertToSQLITEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToSQLITEToolStripMenuItem.Click
        Process.Start(GetAppDataPath() & "/OpenGBU/SQLTOLITE/Converter.exe")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim fSub As New frmSubjects
        fSub.ShowDialog()
    End Sub



    Private Sub SendEmailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendEmailsToolStripMenuItem.Click
        SendEmail()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    LoadLockTT(7)
    'End Sub

    Private Sub cbSchool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSchool.SelectedIndexChanged
        Me.ProgramTableAdapter1.FillBy(ECollegeDataSet.Program, cbSchool.SelectedValue)
        cbSection.Invalidate()

        'PaintForm("all")
        ' MsgBox(cbSchool.SelectedValue)
        ''Dim dtdep As DataTable = New DataTable()
        'Dim sqlqry As String = "select Id, '(' + Code + ') ' + name as depname from M_Department Where SchoolCode='" & cbSchool.SelectedValue.ToString & "';"
        ''Dim adap1 As SqlDataAdapter = New SqlDataAdapter(sqlqry, cn)
        ''adap1.Fill(dtdep)
        ''cbDept.DisplayMember = "depname"
        ''cbDept.ValueMember = "Id"
        ''cbDept.DataSource = dtdep(0)
        ''cbDept.Focus()
        '' Me.ProgramTableAdapter.Fill(Me.ECollegeDataSet.Program)
        'Dim cmd As New SqlCommand
        'Dim adapter As New SqlDataAdapter
        'Dim dtd As New DataTable
        '' cn.ConnectionString = ("Data Source=NIMO-HP\SQLEXPRESS;Initial Catalog=FYP_db;Integrated Security=True")

        'cmd.Connection = cn
        'cmd.CommandText = sqlqry
        'cmd.CommandType = CommandType.Text
        'adapter.SelectCommand = cmd
        'adapter.Fill(dtd)
        'cbDept.DataSource = dtd
        'cbDept.ValueMember = "Id"
        'cbDept.DisplayMember = "depname"
    End Sub

    Private Sub FacultyLoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacultyLoadToolStripMenuItem.Click
        ' frmFacultyLoad.ShowDialog()
        MsgBox("Not Implemented yet.")
    End Sub
    Function GetAppDataPath() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
    End Function

    Private Sub UpdateAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateAppToolStripMenuItem.Click
        Dim myWebClient As New WebClient()
        ' Dim fileName As String = GetAppDataPath() & "\varun.db"
        Dim fileName As String = "D:\Timetables2014\varun.db"
        If My.Computer.FileSystem.FileExists(fileName) Then
            System.Net.ServicePointManager.Expect100Continue = False
            Dim responseArray As Byte() = myWebClient.UploadFile("http://gbuonline.in/timetable/uploaddb.php", fileName)
            MsgBox(responseArray.ToString())

        Else
            MsgBox("Update File First.")
        End If

    End Sub



    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        TimeTableManager.Preference.ShowDialog()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        frmChangePass.ShowDialog()
    End Sub

    Private Sub AddNewProgramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewProgramToolStripMenuItem.Click
        Dim fSub As New frmPrograms
        fSub.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs)
        CreateDatatable()
    End Sub

    Private Sub CreateDatatable()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")
        For i As Integer = 0 To 10
            dt.Rows.Add()
            dt.Rows(i)(0) = i
            dt.Rows(i)(1) = i & "-Sample"
        Next
        Dim _json As String = GetJson(dt)
    End Sub

    Private Function GetJson(ByVal dt As DataTable) As String
        ' Dim Jserializer As New System.Web.Web.Script.Serialization.JavaScriptSerializer()
        Dim rowsList As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next
            rowsList.Add(row)
        Next
        ' Return Jserializer.Serialize(rowsList)
    End Function
End Class
'Public Sub restore(ByVal dat As Date, Optional ByVal Encrypt As Boolean = False, Optional ByVal key As String = "")
'    frmMain.ActiveForm.Text = "Waiting"
'    Try
'        Shell("""..\\gzip.exe"" -drqf """ & Dest & "\Backup\" & dat.Month & "-" & dat.Day & "-" & dat.Year & """", , True)
'    Catch e As Exception
'        MessageBox.Show("No Restore folder on " & dat & " in your " & Dest & " Folder")
'        Exit Sub
'    End Try
'    Dim name As String
'    Dir = Dest & "\Backup\" & dat.Month & "-" & dat.Day & "-" & dat.Year
'    Call connection()
'    DBConnection.Open()
'    Dim DBSchema As New OleDb.OleDbSchemaGuid
'    Dim DBTableNames As New DataTable
'    DBTableNames = DBConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
'    Dim DBTableRow As DataRow
'    Dim SQLString As String
'    'DBDataSet.Clear()
'    DBNewDS.ReadXmlSchema(Dir & "/BackUp.xsd")
'    DBNewDS.ReadXml(Dir & "/BackUp.xml")
'    DBDataSet.Clear()
'    DBDataSet.Merge(DBNewDS, True)
'    For Each DBTableRow In DBTableNames.Rows
'        If DBTableRow.Item("TABLE_TYPE") = "TABLE" Then
'            name = CStr(DBTableRow.Item("TABLE_NAME"))
'            SQLString = "Select * from " & name
'            DBDataAdapter.SelectCommand = New OleDb.OleDbCommand(SQLString, DBConnection)
'            ' get data from the database and put them in memory
'            Try
'                Dim DBUpdateCommand As New OleDb.OleDbCommandBuilder(DBDataAdapter)
'                DBDataAdapter.Update(DBDataSet, name)
'            Catch eror As Exception
'                MessageBox.Show(eror.Message & ".source=" & eror.Source & "in table" & name)
'            Finally
'                DBDataAdapter.Dispose()
'                DBConnection.Close()
'            End Try
'        End If
'    Next
'    Try
'        Shell("""..\\gzip.exe"" -rqf """ & Dest & "\Backup\" & dat.Month & "-" & dat.Day & "-" & dat.Year & """", , True)
'    Catch e As Exception
'        MessageBox.Show("No Restore folder on " & dat & " in your " & Dest & " Folder")
'        Exit Sub
'    End Try
'    frmMain.ActiveForm.Text = "Alfa Restore"