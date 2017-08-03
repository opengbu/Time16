Imports System.Text
Imports System.Collections.Generic
Imports System

Namespace DbAccess
	Public Class TableSchema
		Public TableName As String

		Public TableSchemaName As String

		Public Columns As List(Of ColumnSchema)

		Public PrimaryKey As List(Of String)

		Public ForeignKeys As List(Of ForeignKeySchema)

		Public Indexes As List(Of IndexSchema)
	End Class
End Namespace