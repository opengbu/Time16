Imports System.Text
Imports System.Collections.Generic
Imports System

Namespace DbAccess
	''' <summary>
	''' Describes a single view schema
	''' </summary>
	Public Class ViewSchema
		''' <summary>
		''' Contains the view name
		''' </summary>
		Public ViewName As String

		''' <summary>
		''' Contains the view SQL statement
		''' </summary>
		Public ViewSQL As String
	End Class
End Namespace