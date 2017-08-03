Imports System.Text
Imports System.Collections.Generic
Imports System

Namespace DbAccess
	''' <summary>
	''' Contains the schema of a single DB column.
	''' </summary>
	Public Class ColumnSchema
		Public ColumnName As String

		Public ColumnType As String

		Public Length As Integer

		Public IsNullable As Boolean

		Public DefaultValue As String

		Public IsIdentity As Boolean

		Public IsCaseSensitivite As System.Nullable(Of Boolean) = Nothing
	End Class
End Namespace