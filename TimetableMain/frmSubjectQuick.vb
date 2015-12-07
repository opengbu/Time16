Public Class frmSubjectQuick
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim t = New Timesheet()
        t.UpdateCSF(Me.txtSubjectCode.Text.Trim, Me.txtSubjectName.Text.Trim, Val(Me.txtL.Text.Trim), Val(Me.txtT.Text.Trim), Val(Me.txtP.Text.Trim), chkLab.Checked)
        Me.txtSubjectCode.Focus()
    End Sub
End Class