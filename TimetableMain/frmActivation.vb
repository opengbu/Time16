Imports System.Security.Cryptography
Public Class frmActivation

    Private Sub frmActivation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Year(Now)
    End Sub
    Private Function passwordEncryptSHA(ByVal password As String) As String
        Dim sha As New SHA1CryptoServiceProvider ' declare sha as a new SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte ' and here is a byte variable

        bytesToHash = System.Text.Encoding.ASCII.GetBytes(password) ' covert the password into ASCII code

        bytesToHash = sha.ComputeHash(bytesToHash) ' this is where the magic starts and the encryption begins

        Dim encPassword As String = ""

        For Each b As Byte In bytesToHash
            encPassword += b.ToString("x2")
        Next

        Return encPassword ' boom there goes the encrypted password!

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim password As String
        Dim passwordSHA As String

        password = TextBox1.Text ' give password the value of the password textbox

        Call passwordEncryptSHA(password) ' Lets call the first password encryption function for SHA1

        passwordSHA = passwordEncryptSHA(password) ' give the variable the returned SHA value

        ' finally we will display both values in the corresponding textboxes
        TextBox1.Text = passwordSHA
    End Sub
End Class