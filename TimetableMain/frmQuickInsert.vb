Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frmQuickInsert
    Public _currentcsf = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        AddSubjectFacultySection()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmQuickInsert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQISection.Text = _currentSection
        'TODO: This line of code loads data into the 'ECollegeDataSet.Teacher' table. You can move, or remove it, as needed.
        Me.TeacherTableAdapter.Fill(Me.ECollegeDataSet.Teacher)
        'TODO: This line of code loads data into the 'ECollegeDataSet.Subject' table. You can move, or remove it, as needed.
        Me.SubjectTableAdapter.Fill(Me.ECollegeDataSet.Subject)

    End Sub

    Private Sub AddSubjectFacultySection()

        Dim sQry As String = ""
        sQry = "IF NOT EXISTS (SELECT * FROM [CourseStructure] WHERE CouseId = '" & Me.cbQISubjectCode.Text.Trim & "' AND ProgramId=" & Me.txtQISection.Text.Trim & ") INSERT INTO [CourseStructure] (ProgramId, CouseId,semester) VALUES (" & Me.txtQISection.Text.Trim & " ,'" & Me.cbQISubjectCode.Text.Trim & "'," & _currentSemester & ")"
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        cn.Open()

        Dim cmd1 As New SqlCommand(sQry, cn)
        Try
            'MsgBox(sQry)
            cmd1.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()
        'Dim sQRy1 As String
        ' Dim csfid As Integer
        'Try
        'sQRy1 = "Exec InsertCSf " _
        '                           & " @facid=" &
        '                           & ", @=" &
        '                           & ", @=" &
        ' '                          & ", @='" &
        '                          & "', @L=0, @T=0, @P=0;"

        ' Dim cmd1 As New SqlCommand(sQRy1, cn)
        '  MsgBox(sQRy1)
        ' csfid = cmd1.ExecuteScalar()
        ' MsgBox(csfid)
        Try
            Dim query As String = "InsertCSf"
            Dim ID As Integer
            '    Dim connect As String = "Server=.\SQLExpress;Database=Northwind;Trusted_Connection=Yes;"
            Using cn
                Using cmd As New SqlCommand(query, cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@facid", Me.cbQIFaculty.SelectedValue)
                    cmd.Parameters.AddWithValue("@sectionid", txtQISection.Text.Trim)
                    cmd.Parameters.AddWithValue("@subjectid", Me.cbQISubjectCode.SelectedValue)
                    cmd.Parameters.AddWithValue("@subjectcode", Me.cbQISubjectCode.Text.Trim)
                    cmd.Parameters.AddWithValue("@L", 0)
                    cmd.Parameters.AddWithValue("@T", 0)
                    cmd.Parameters.AddWithValue("@P", 0)
                    cmd.Parameters.Add("@csfid", SqlDbType.Int, 0, "csfid")
                    cmd.Parameters("@csfid").Direction = ParameterDirection.Output
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    ID = cmd.Parameters("@csfid").Value
                End Using
            End Using
            'If Not IsDBNull(ID) Then 
            _currentcsf = ID
        Catch ex As Exception
            MsgBox("Select CSF from above list.")
            ' MsgBox(Err.Description)
        Finally
            cn.Close()
        End Try
    End Sub

End Class
