Imports System.Net
Imports DbAccess
Imports System.IO
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.Drawing
Imports System.Data
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Reflection
Imports System

Namespace Converter

	Public Partial Class MainForm
		Inherits Form
		Private HttpUpload As [Boolean] = False
		#Region "Constructor"
		Public Sub New()
			InitializeComponent()
		End Sub
		#End Region

		#Region "Event Handler"
		Private Sub btnBrowseSQLitePath_Click(sender As Object, e As EventArgs)
			Dim res As DialogResult = saveFileDialog1.ShowDialog(Me)
			If res = DialogResult.Cancel Then
				Return
			End If

			Dim fpath As String = saveFileDialog1.FileName
			txtSQLitePath.Text = fpath
			pbrProgress.Value = 0
			lblMessage.Text = String.Empty
		End Sub

		Private Sub cboDatabases_SelectedIndexChanged(sender As Object, e As EventArgs)

			'  'pbrProgress.Value = 0;
			'  'lblMessage.Text = string.Empty;
		End Sub

		Private Sub btnSet_Click(sender As Object, e As EventArgs)
			Try
				Dim constr As String
				'if (cbxIntegrated.Checked) {
				'	constr = GetSqlServerConnectionString(txtSqlAddress.Text, "master");
				'} else {
				'	constr = GetSqlServerConnectionString(txtSqlAddress.Text, "master", txtUserDB.Text, txtPassDB.Text);
				'}
				constr = Properties.Settings.[Default].myconn

				UpdateSensitivity()
				pbrProgress.Value = 0
				lblMessage.Text = String.Empty
			Catch ex As Exception
				MessageBox.Show(Me, ex.Message, "Failed To Connect", MessageBoxButtons.OK, MessageBoxIcon.[Error])
			End Try
			' catch
		End Sub

		Private Sub txtSQLitePath_TextChanged(sender As Object, e As EventArgs)
			UpdateSensitivity()
		End Sub

		Private Sub MainForm_Load(sender As Object, e As EventArgs)
			UpdateSensitivity()

			Dim version As String = Assembly.GetExecutingAssembly().GetName().Version.ToString()
			Me.Text = "SQL Server To SQLite DB Converter (" + version + ")"
			btnStart.Enabled = True
		End Sub

		Private Sub txtSqlAddress_TextChanged(sender As Object, e As EventArgs)
			UpdateSensitivity()
		End Sub

		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			SqlServerToSQLite.CancelConversion()
		End Sub

		Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs)
			If SqlServerToSQLite.IsActive Then
				SqlServerToSQLite.CancelConversion()
				_shouldExit = True
				e.Cancel = True
			Else
				e.Cancel = False
			End If
		End Sub

		Private Sub cbxEncrypt_CheckedChanged(sender As Object, e As EventArgs)
			UpdateSensitivity()
		End Sub

		Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs)
			UpdateSensitivity()
		End Sub

		Private Sub ChkIntegratedCheckedChanged(sender As Object, e As EventArgs)
			If cbxIntegrated.Checked Then
				lblPassword.Visible = False
				lblUser.Visible = False
				txtPassDB.Visible = False
				txtUserDB.Visible = False
			Else
				lblPassword.Visible = True
				lblUser.Visible = True
				txtPassDB.Visible = True
				txtUserDB.Visible = True
			End If
		End Sub

		Private Sub btnStart_Click(sender As Object, e As EventArgs)
			Dim sqlConnString As String
			'if (cbxIntegrated.Checked) {
			'	sqlConnString = GetSqlServerConnectionString(txtSqlAddress.Text, (string)cboDatabases.SelectedItem);
			'} else {
			'	sqlConnString = GetSqlServerConnectionString(txtSqlAddress.Text, (string)cboDatabases.SelectedItem, txtUserDB.Text, txtPassDB.Text);
			'}
			sqlConnString = Properties.Settings.[Default].myconn
			Dim createViews As Boolean = cbxCreateViews.Checked

			Dim sqlitePath As String = txtSQLitePath.Text.Trim()
			Me.Cursor = Cursors.WaitCursor


			Dim handler As New SqlConversionHandler()
				' Allow the user to select which tables to include by showing him the 
				' table selection dialog.
			Dim selectionHandler As New SqlTableSelectionHandler()


			Dim viewFailureHandler As New FailedViewDefinitionHandler()

			Dim password As String = txtPassword.Text.Trim()
			If Not cbxEncrypt.Checked Then
				password = Nothing
			End If
			SqlServerToSQLite.ConvertSqlServerToSQLiteDatabase(sqlConnString, sqlitePath, password, handler, selectionHandler, viewFailureHandler, _
				cbxTriggers.Checked, createViews)
		End Sub

		#End Region

		#Region "Private Methods"
		Private Sub UpdateSensitivity()
			If txtSQLitePath.Text.Trim().Length > 0 AndAlso cboDatabases.Enabled AndAlso (Not cbxEncrypt.Checked OrElse txtPassword.Text.Trim().Length > 0) Then
				btnStart.Enabled = True AndAlso Not SqlServerToSQLite.IsActive
			Else
				btnStart.Enabled = False
			End If

			btnSet.Enabled = txtSqlAddress.Text.Trim().Length > 0 AndAlso Not SqlServerToSQLite.IsActive
			btnCancel.Visible = SqlServerToSQLite.IsActive
			txtSqlAddress.Enabled = Not SqlServerToSQLite.IsActive
			txtSQLitePath.Enabled = Not SqlServerToSQLite.IsActive
			btnBrowseSQLitePath.Enabled = Not SqlServerToSQLite.IsActive
			cbxEncrypt.Enabled = Not SqlServerToSQLite.IsActive
			cboDatabases.Enabled = cboDatabases.Items.Count > 0 AndAlso Not SqlServerToSQLite.IsActive
			txtPassword.Enabled = cbxEncrypt.Checked AndAlso cbxEncrypt.Enabled
			cbxIntegrated.Enabled = Not SqlServerToSQLite.IsActive
			cbxCreateViews.Enabled = Not SqlServerToSQLite.IsActive
			cbxTriggers.Enabled = Not SqlServerToSQLite.IsActive
			txtPassDB.Enabled = Not SqlServerToSQLite.IsActive
			txtUserDB.Enabled = Not SqlServerToSQLite.IsActive
		End Sub

		Private Shared Function GetSqlServerConnectionString(address As String, db As String) As String
			Dim res As String = "Data Source=" + address.Trim() + ";Initial Catalog=" + db.Trim() + ";Integrated Security=SSPI;"
			Return res
		End Function
		Private Shared Function GetSqlServerConnectionString(address As String, db As String, user As String, pass As String) As String
			Dim res As String = "Data Source=" + address.Trim() + ";Initial Catalog=" + db.Trim() + ";User ID=" + user.Trim() + ";Password=" + pass.Trim()
			Return res
		End Function
		#End Region

		#Region "Private Variables"
		Private _shouldExit As Boolean = False
		#End Region

		Private Sub button1_Click(sender As Object, e As EventArgs)
			Dim wpcred As New NetworkCredential("amitkawasthi", "z1234")
			'  WebProxy wp = new WebProxy("http://172.25.6.6");
			' wp.Credentials = wpcred;
			Using client As New WebClient()
				Try
					'  client.Proxy = wp;
					client.UploadFile("http://www.gbuonline.in/timetable/uploaddb.php", "D:/Timetables2014/varun.db")
					HttpUpload = True
				Catch ex As Exception
					HttpUpload = False
					MessageBox.Show(ex.Message)
				End Try
				If HttpUpload Then
					MessageBox.Show("Updated")
				Else
					MessageBox.Show("Not Updated")

				End If
			End Using
		End Sub
	End Class
End Namespace