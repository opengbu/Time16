Imports System.Text
Imports System.Collections.Generic
Imports System

Namespace DbAccess
	Public Class IndexSchema
		Public IndexName As String

		Public IsUnique As Boolean

		Public Columns As List(Of IndexColumn)
	End Class

	Public Class IndexColumn
		Public ColumnName As String
		Public IsAscending As Boolean
	End Class
End Namespace