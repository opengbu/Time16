Imports System.Data.SqlClient
Imports System.DirectoryServices
Imports System.Net.Mail
Imports System.Net
Imports System

Module Module1
    Public _school As String
    Public Sub GetPreview()
        Dim c As New TimetableView.Form1
        'Dim c As New Form1
        c.Show()
    End Sub

    Public Sub GetSQLiteConvert()

    End Sub
    Public Sub SendEmail()
        Try
            Dim Smtp_Server As New SmtpClient()
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("dicgbu@gmail.com", "tuajlkkl")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("dicgbu@gmail.com")
            e_mail.To.Add("awasthi.amitk@gmail.com")
            e_mail.Subject = "Timetable Updated!"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Please check your timetable. Some change may be there."
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub
    Public Sub DeleteCourse(progid, courid)
        Dim sQry As String = ""
        sQry = "DELETE FROM [CourseStructure] WHERE ProgramId=@pid AND CouseId=@cid"
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        Dim cmd As New SqlCommand(sQry, cn)
        cmd.Parameters.Add("@pid", SqlDbType.Int)
        cmd.Parameters("@pid").Value = progid

        cmd.Parameters.Add("@cid", SqlDbType.VarChar)
        cmd.Parameters("@cid").Value = courid

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Function GetFacultyById(Id As Integer)
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        GetFacultyById = ""
        Try

            Dim sQry As String = ""
            sQry = "SELECT  name FROM Teacher WHERE  (id = @Id)"

            Dim cmd As New SqlCommand(sQry, cn)
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters("@id").Value = Id
            cn.Open()
            Dim rd As SqlDataReader
            rd = cmd.ExecuteReader
            While rd.Read
                GetFacultyById = rd(0).ToString
            End While

        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Function

    Function GetSchool(ldapuser As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        GetSchool = ""
        Try
            Dim sQry As String = ""
            sQry = "SELECT  uid,school FROM [user] WHERE  (ldapuser=@ldapuser)"
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.Parameters.Add("@ldapuser", SqlDbType.NVarChar)
            cmd.Parameters("@ldapuser").Value = ldapuser
            cn.Open()
            Dim rd As SqlDataReader
            rd = cmd.ExecuteReader
            If rd.Read Then
                _school = rd("school").ToString.Trim
                'MsgBox(_school)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        GetSchool = _school
    End Function



    'Public Function ValidateLogin_AD(ByVal UserName As String, ByVal Password As String) As Boolean
    '    Dim Success As Boolean = False

    '    Dim ldapServerName As String
    '    ldapServerName = "172.25.5.10:389"

    '    Dim path As DirectoryEntry = New DirectoryEntry("ldap://" & ldapServerName, "uid=amitkawasthi,cn=faculty,ou=Groups,dc=gbu,dc=ac,dc=in", "a1234", AuthenticationTypes.Anonymous)

    '    Try
    '        Dim connected As Object = path.NativeObject
    '        Success = True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Success = False
    '    End Try
    '    Dim Searcher As New System.DirectoryServices.DirectorySearcher(path)
    '    Searcher.SearchScope = DirectoryServices.SearchScope.Subtree

    '    Try
    '        Dim Results As System.DirectoryServices.SearchResult = Searcher.FindOne
    '        Success = Not (Results Is Nothing)
    '    Catch e As Exception
    '        MsgBox(e.Message)
    '        Success = False
    '    End Try
    '    MsgBox(Success)

    '    Return Success
    'End Function

    Public Function ValidateLoginByEmail(uid As String, pwd As String) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        ValidateLoginByEmail = False
        Try
            Dim sQry As String = ""
            sQry = "SELECT  uid,school FROM [user] WHERE  (uid = @Id) and (pwd=@pw)"
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar)
            cmd.Parameters("@id").Value = uid.Trim
            cmd.Parameters.Add("@pw", SqlDbType.VarChar)
            cmd.Parameters("@pw").Value = pwd.Trim
            cn.Open()
            Dim rd As SqlDataReader
            rd = cmd.ExecuteReader
            If rd.Read Then
                _school = rd("school").ToString.Trim
                'MsgBox(_school)
                ValidateLoginByEmail = True
            Else
                ValidateLoginByEmail = False
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        Return ValidateLoginByEmail
    End Function

    Public Function ChangePassword(uid As String, pwd As String) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = My.Settings.eCollegeConnectionString
        ChangePassword = False
        Try
            Dim sQry As String = ""
            sQry = "UPDATE [user] SET pwd=@pw WHERE (uid = @Id)"
            Dim cmd As New SqlCommand(sQry, cn)
            cmd.Parameters.Add("@id", SqlDbType.VarChar)
            cmd.Parameters("@id").Value = uid.Trim
            cmd.Parameters.Add("@pw", SqlDbType.VarChar)
            cmd.Parameters("@pw").Value = pwd.Trim
            cn.Open()
            ChangePassword = cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        Return ChangePassword
    End Function

End Module
