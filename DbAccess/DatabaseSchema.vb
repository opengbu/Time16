Imports System.Text
Imports System.Collections.Generic
Imports System

Namespace DbAccess
	''' <summary>
	''' Contains the entire database schema
	''' </summary>
	Public Class DatabaseSchema
		Public Tables As New List(Of TableSchema)()
		Public Views As New List(Of ViewSchema)()
	End Class
End Namespace