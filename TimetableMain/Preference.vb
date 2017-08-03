Imports System.Windows.Forms

Public Class Preference

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        My.Settings.DeleteConfirm = Me.CheckBox1.Checked
        My.Settings.ProgramFilter = Me.prfFilterCourse.Checked
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Preference_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckBox1.Checked = My.Settings.DeleteConfirm
        Me.prfFilterCourse.Checked = My.Settings.ProgramFilter
        tProxyServer.Text = My.Settings.Proxy
        tProxyUser.Text = My.Settings.ProxyUser
        tProxyPassword.Text = My.Settings.ProxyPassword
    End Sub

    Private Sub bSaveProxy_Click(sender As Object, e As EventArgs) Handles bSaveProxy.Click
        My.Settings.Proxy = tProxyServer.Text.Trim
        My.Settings.ProxyUser = tProxyUser.Text.Trim
        My.Settings.ProxyPassword = tProxyPassword.Text
    End Sub
End Class
