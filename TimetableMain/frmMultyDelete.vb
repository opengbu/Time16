Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmMultyDelete
    Dim csflist(10) As Integer
    Dim RBUTTON(10) As RadioButton

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        frmMain.DelCSFID = Getcsfid()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmMultyDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString1
        Dim sQry As String = ""
        sQry = "SELECT   M_Time_Table.CSF_Id, CSF.Subject_Code
                      FROM            M_Time_Table INNER JOIN
                      CSF ON M_Time_Table.CSF_Id = CSF.CSF_Id
                       WHERE (M_Time_Table.Section_Id = " & _currentSection & ") AND (M_Time_Table.TT_Day = " & frmMain.DelTTDay & ") AND (M_Time_Table.TT_Period = " & frmMain.DelTTPeriod & ")"
        'sQry = "SELECT distinct Teacher_name_n, Teacher_Id_n, csf_id FROM CSF_View WHERE (Section_Id =" + SectionId + ") AND (Subject_Id =" + SubjectId + ")"

        Dim cmd As New SqlCommand
        cmd.CommandText = sQry
        cmd.Connection = cn

        'cmd.Parameters.Add("@sid", SqlDbType.Int)
        'cmd.Parameters("@sid").Value = SectionId

        'cmd.Parameters.Add("@subid", SqlDbType.BigInt)
        'cmd.Parameters("@subid").Value = SubjectId
        cn.Open()
        Array.Clear(csflist, 0, 10)
        Dim rd As SqlDataReader
        rd = cmd.ExecuteReader
        Dim i As Integer = 0
        While rd.Read
            Dim rdo As New RadioButton
            i = i + 1
            rdo.Name = "RadioButton" & i
            rdo.Text = "Delete " & Convert.ToString(rd(1))
            csflist.SetValue(Convert.ToInt32(rd(0)), i)
            rdo.Location = New Point(10, 27 * (i + 1))
            Me.Controls.Add(rdo)
        End While
        cn.Close()
    End Sub

    Private Function Getcsfid() As Integer
        Getcsfid = 0
        Dim radios = Me.Controls.OfType(Of RadioButton).AsQueryable()
        Dim i As Integer = 0
        For Each r As RadioButton In radios
            i = i + 1
            If r.Checked Then
                Getcsfid = csflist(i)
            End If
        Next
    End Function
End Class
