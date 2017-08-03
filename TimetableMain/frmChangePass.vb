Public Class frmChangePass
    Private Sub btnChangePass_Click(sender As Object, e As EventArgs) Handles btnChangePass.Click
        If tNewPass.Text.Trim = tConfirmPass.Text.Trim Then
            If ValidateLoginByEmail(My.Settings.Username, tOldPass.Text.Trim) Then
                ChangePassword(My.Settings.Username, tNewPass.Text.Trim)
                Me.Hide()
            Else
                MsgBox("Correct Old Password is required.")
                tNewPass.Focus()

            End If
        End If
    End Sub

    Private Sub frmChangePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = My.Settings.Username

    End Sub
End Class