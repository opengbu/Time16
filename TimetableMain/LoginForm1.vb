
Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If ValidateLoginByEmail(Me.UsernameTextBox.Text.Trim, Me.PasswordTextBox.Text.Trim) Then
            frmMain.Show()
            Me.Hide()
        Else
            MsgBox("Correct User Password combination required.")
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        appVer.Text = My.Application.Info.Version.ToString


        Label1.BackColor = Color.Transparent
        UsernameLabel.BackColor = Color.Transparent
        PasswordLabel.BackColor = Color.Transparent

        Dim MachineName = Environment.UserName
        'MsgBox(MachineName)

    End Sub

  
End Class
