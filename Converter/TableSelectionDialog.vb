Imports DbAccess
Imports System.Windows.Forms
Imports System.Text
Imports System.Drawing
Imports System.Data
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System

Namespace Converter
	''' <summary>
	''' The dialog allows the user to select which tables to include in the 
	''' converstion process.
	''' </summary>
	Public Partial Class TableSelectionDialog
		Inherits Form
		#Region "Constructors"
		Public Sub New()
			InitializeComponent()
		End Sub
		#End Region

		#Region "Public Properties"
		''' <summary>
		''' Returns the list of included table schema objects.
		''' </summary>
		Public ReadOnly Property IncludedTables() As List(Of TableSchema)
			Get
				Dim res As New List(Of TableSchema)()
				For Each row As DataGridViewRow In grdTables.Rows
					Dim include As Boolean = CType(row.Cells(0).Value, Boolean)
					If include Then
						res.Add(CType(row.Tag, TableSchema))
					End If
				Next
				' foreach
				Return res
			End Get
		End Property
		#End Region

		#Region "Public Methods"
		''' <summary>
		''' Opens the table selection dialog and uses the specified schema list in order
		''' to update the tables grid.
		''' </summary>
		''' <param name="schema">The DB schema to display in the grid</param>
		''' <param name="owner">The owner form</param>
		''' <returns>dialog result according to user decision.</returns>
		Public Function ShowTables(schema As List(Of TableSchema), owner As IWin32Window) As DialogResult
			UpdateGuiFromSchema(schema)
			Return Me.ShowDialog(owner)
		End Function
		#End Region

		#Region "Event Handlers"
		Private Sub btnOK_Click(sender As Object, e As EventArgs)
			DialogResult = DialogResult.OK
		End Sub

		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			DialogResult = DialogResult.Cancel
		End Sub

		Private Sub btnDeselectAll_Click(sender As Object, e As EventArgs)
			For Each row As DataGridViewRow In grdTables.Rows
				' Uncheck the [V] for this row.
				row.Cells(0).Value = False
			Next
			' foreach
		End Sub

		Private Sub btnSelectAll_Click(sender As Object, e As EventArgs)
			For Each row As DataGridViewRow In grdTables.Rows
				' Check the [V] for this row.
				row.Cells(0).Value = True
			Next
			' foreach
		End Sub
		#End Region

		#Region "Private Methods"
		Private Sub UpdateGuiFromSchema(schema As List(Of TableSchema))
			grdTables.Rows.Clear()
			For Each table As TableSchema In schema
				grdTables.Rows.Add(True, table.TableName)
				grdTables.Rows(grdTables.Rows.Count - 1).Tag = table
			Next
			' foreach
		End Sub
		#End Region
	End Class
End Namespace