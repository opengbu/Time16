Imports DbAccess
Imports System.Windows.Forms
Imports System.Text
Imports System.Drawing
Imports System.Data
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System

Namespace Converter
	Public Partial Class ViewFailureDialog
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Property View() As ViewSchema
			Get
				Return _view
			End Get
			Set
				_view = value
				Me.Text = "SQL Error: " + _view.ViewName
				txtSQL.Text = _view.ViewSQL
			End Set
		End Property

		Public ReadOnly Property ViewSQL() As String
			Get
				Return txtSQL.Text
			End Get
		End Property


		Private Sub btnOK_Click(sender As Object, e As EventArgs)
			Me.DialogResult = DialogResult.OK
		End Sub

		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			Me.DialogResult = DialogResult.Cancel
		End Sub

		Private _view As ViewSchema
	End Class
End Namespace