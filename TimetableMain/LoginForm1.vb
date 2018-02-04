'Imports System.IO
'Imports System.Net
'Imports Novell.Directory.Ldap
'Imports ImapX
'Imports ImapX.Authentication
Imports System.Deployment.Application

Public Class LoginForm1
    Dim group As String = ",ou=faculty,"
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.


    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'appVer.Text = My.Application.Info.Version.ToString
        Dim myVersion As New Version

        If ApplicationDeployment.IsNetworkDeployed Then
            myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion
        End If
        appVer.Text = myVersion.ToString
        UsernameTextBox.Text = My.Settings.Username
        PasswordTextBox.Text = My.Settings.Password

        ''  Label1.BackColor = Color.Transparent
        ' UsernameLabel.BackColor = Color.Transparent
        ' PasswordLabel.BackColor = Color.Transparent
        Try
            Dim t As TimeTable = New TimeTable
            Me.lblSession.Text = t.SessionName
        Catch ex As Exception

        End Try



        Dim MachineName = Environment.UserName
        'MsgBox(MachineName)

    End Sub
    'Private Sub bLogin_Click(sender As Object, e As EventArgs) Handles bLogin.Click
    '    If txtUserName.Text <> "" And txtPassword.Text <> "" Then
    '        If ValidateLogin_AD(txtUserName.Text.Trim, txtPassword.Text.Trim, "172.25.5.10", 389, group & "dc=gbu,dc=ac,dc=in", "(uid=*)") Then
    '            _school = GetSchool(txtUserName.Text.Trim)
    '            Me.Hide()
    '            frmMain.Show()
    '        Else
    '            MsgBox("Login Failed.")
    '        End If

    '    Else
    '        MsgBox("Username/Password Missing.")
    '        Exit Sub
    '    End If
    'End Sub
    Private Sub bLogin_Click(sender As Object, e As EventArgs) Handles bLogin.Click
        If txtUserName.Text <> "" And txtPassword.Text <> "" Then
            If ValidateLogin_Email(txtUserName.Text.Trim, txtPassword.Text.Trim) Then
                _school = GetSchool(txtUserName.Text.Trim)
                Me.Hide()
                frmMain.Show()
            Else
                MsgBox("Login Failed.")
            End If

        Else
            MsgBox("Username/Password Missing.")
            Exit Sub
        End If
    End Sub

    Private Function ValidateLogin_Email(trim1 As String, trim2 As String) As Boolean

        'Dim MyImapClient = New ImapClient
        ''Dim ssl As ImapX.SslProtocols = If((Me.cmbEncryption.SelectedIndex = 0), SslProtocols.None, If((Me.cmbEncryption.SelectedIndex = 1), SslProtocols.Default, SslProtocols.Tls))

        'MyImapClient.Host = "mail1.gbu.ac.in"
        'MyImapClient.Port = 143
        'MyImapClient.SslProtocol = start System.Security.Authentication.SslProtocols.Tls
        'MyImapClient.ValidateServerCertificate = False
        'MyImapClient.Connect()
        'MyImapClient.Credentials = New PlainCredentials("amitkawasthi@gbu.ac.in", "dyapm5mx")
        'MsgBox(MyImapClient.Login)


        Throw New NotImplementedException()
    End Function

    Public Shared Function ValidateLogin_AD(ByVal UserName As String, ByVal Password As String, Server As String, Port As Integer, searchBase As String, searchFilter As String) As Boolean
        'Dim UserName1 = "uid=" & UserName & ",cn=faculty,ou=Groups,dc=gbu,dc=ac,dc=in"
        'Dim UserName1 = "uid=" & UserName & Form1.group & "ou=Groups,dc=gbu,dc=ac,dc=in"
        Dim UserName1 = "uid=" & UserName & ",ou=faculty,dc=gbu,dc=ac,dc=in"
        'UserName = "uid=" & UserName & searchBase
        '  Dim ldapconnection As LdapConnection = New LdapConnection()
        Dim Success As Boolean = False
        Try
            '    ldapconnection.Connect(Server, Port)
            '     ldapconnection.Bind(UserName1, Password)
            '  Dim lsc As LdapSearchResults
            '    lsc = ldapconnection.Search(searchBase, LdapConnection.SCOPE_SUB, searchFilter, Nothing, False)
            '  Success = ldapconnection.Connected
        Catch ex As Exception
            '   If ldapconnection.Connected Then
            '   MsgBox("Invalid Credential.")
            '  Else
            '  MsgBox(ex.Message)
            ' End If

        End Try
        Return Success
    End Function

    'Private Sub rbFaculty_CheckedChanged(sender As Object, e As EventArgs)
    '    If rbFaculty.Checked Then group = ",ou=faculty,"
    'End Sub

    'Private Sub rbStudent_CheckedChanged(sender As Object, e As EventArgs)
    '    If rbStudent.Checked Then group = ",ou=student,"
    'End Sub

    Private Sub OK_Click_1(sender As Object, e As EventArgs) Handles cmdOK.Click
        If ValidateLoginByEmail(Me.UsernameTextBox.Text.Trim, Me.PasswordTextBox.Text.Trim) Then
            Me.Hide()

            frmMain.Show()
            My.Settings.Username = UsernameTextBox.Text
            My.Settings.Password = PasswordTextBox.Text
            My.Settings.Save()
        Else
            MsgBox("Correct User Password combination required.")
        End If
    End Sub

    Private Sub Cancel_Click_1(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub lblSession_Click(sender As Object, e As EventArgs) Handles lblSession.Click

    End Sub
End Class
