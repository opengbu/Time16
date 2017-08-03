Imports log4net
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System
Imports Microsoft.VisualBasic


Namespace DbAccess
	''' <summary>
	''' This class is resposible to take a single SQL Server database
	''' and convert it to an SQLite database file.
	''' </summary>
	''' <remarks>The class knows how to convert table and index structures only.</remarks>
	Public Class SqlServerToSQLite
		#Region "Public Properties"
		''' <summary>
		''' Gets a value indicating whether this instance is active.
		''' </summary>
		''' <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
		Public Shared ReadOnly Property IsActive() As Boolean
			Get
				Return _isActive
			End Get
		End Property
		#End Region

		#Region "Public Methods"
		''' <summary>
		''' Cancels the conversion.
		''' </summary>
		Public Shared Sub CancelConversion()
			_cancelled = True
		End Sub

		''' <summary>
		''' This method takes as input the connection string to an SQL Server database
		''' and creates a corresponding SQLite database file with a schema derived from
		''' the SQL Server database.
		''' </summary>
		''' <param name="sqlServerConnString">The connection string to the SQL Server database.</param>
		''' <param name="sqlitePath">The path to the SQLite database file that needs to get created.</param>
		''' <param name="password">The password to use or NULL if no password should be used to encrypt the DB</param>
		''' <param name="handler">A handler delegate for progress notifications.</param>
		''' <param name="selectionHandler">The selection handler that allows the user to select which
		''' tables to convert</param>
		''' <remarks>The method continues asynchronously in the background and the caller returned
		''' immediatly.</remarks>
		Public Shared Sub ConvertSqlServerToSQLiteDatabase(sqlServerConnString As String, sqlitePath As String, password As String, handler As SqlConversionHandler, selectionHandler As SqlTableSelectionHandler, viewFailureHandler As FailedViewDefinitionHandler, _
			createTriggers As Boolean, createViews As Boolean)
			' Clear cancelled flag
			_cancelled = False

            ' catch
            Dim wc As New WaitCallback()
            ThreadPool.QueueUserWorkItem(wc)
		End Sub
		#End Region

		#Region "Private Methods"
		''' <summary>
		''' Do the entire process of first reading the SQL Server schema, creating a corresponding
		''' SQLite schema, and copying all rows from the SQL Server database to the SQLite database.
		''' </summary>
		''' <param name="sqlConnString">The SQL Server connection string</param>
		''' <param name="sqlitePath">The path to the generated SQLite database file</param>
		''' <param name="password">The password to use or NULL if no password should be used to encrypt the DB</param>
		''' <param name="handler">A handler to handle progress notifications.</param>
		''' <param name="selectionHandler">The selection handler which allows the user to select which tables to 
		''' convert.</param>
		Private Shared Sub ConvertSqlServerDatabaseToSQLiteFile(sqlConnString As String, sqlitePath As String, password As String, handler As SqlConversionHandler, selectionHandler As SqlTableSelectionHandler, viewFailureHandler As FailedViewDefinitionHandler, _
			createTriggers As Boolean, createViews As Boolean)
			' Delete the target file if it exists already.
			If File.Exists(sqlitePath) Then
				File.Delete(sqlitePath)
			End If

			' Read the schema of the SQL Server database into a memory structure
			Dim ds As DatabaseSchema = ReadSqlServerSchema(sqlConnString, handler, selectionHandler)

			' Create the SQLite database and apply the schema
			CreateSQLiteDatabase(sqlitePath, ds, password, handler, viewFailureHandler, createViews)

			' Copy all rows from SQL Server tables to the newly created SQLite database
			CopySqlServerRowsToSQLiteDB(sqlConnString, sqlitePath, ds.Tables, password, handler)

			' Add triggers based on foreign key constraints
			If createTriggers Then
				AddTriggersForForeignKeys(sqlitePath, ds.Tables, password, handler)
			End If

		End Sub

		''' <summary>
		''' Copies table rows from the SQL Server database to the SQLite database.
		''' </summary>
		''' <param name="sqlConnString">The SQL Server connection string</param>
		''' <param name="sqlitePath">The path to the SQLite database file.</param>
		''' <param name="schema">The schema of the SQL Server database.</param>
		''' <param name="password">The password to use for encrypting the file</param>
		''' <param name="handler">A handler to handle progress notifications.</param>
		Private Shared Sub CopySqlServerRowsToSQLiteDB(sqlConnString As String, sqlitePath As String, schema As List(Of TableSchema), password As String, handler As SqlConversionHandler)
			CheckCancelled()
			handler(False, True, 0, "Preparing to insert tables...")
			_log.Debug("preparing to insert tables ...")

			' Connect to the SQL Server database
			Using ssconn As New SqlConnection(sqlConnString)
				ssconn.Open()

				' Connect to the SQLite database next
				Dim sqliteConnString As String = CreateSQLiteConnectionString(sqlitePath, password)
				Using sqconn As New SQLiteConnection(sqliteConnString)
					sqconn.Open()

					' Go over all tables in the schema and copy their rows
					Dim i As Integer = 0
					While i < schema.Count
						Dim tx As SQLiteTransaction = sqconn.BeginTransaction()
						Try
							Dim tableQuery As String = BuildSqlServerTableQuery(schema(i))
							Dim query As New SqlCommand(tableQuery, ssconn)
							Using reader As SqlDataReader = query.ExecuteReader()
								Dim insert As SQLiteCommand = BuildSQLiteInsert(schema(i))
								Dim counter As Integer = 0
								While reader.Read()
									insert.Connection = sqconn
									insert.Transaction = tx
									Dim pnames As New List(Of String)()
									Dim j As Integer = 0
									While j < schema(i).Columns.Count
										Dim pname As String = "@" + GetNormalizedName(schema(i).Columns(j).ColumnName, pnames)
										insert.Parameters(pname).Value = CastValueForColumn(reader(j), schema(i).Columns(j))
										pnames.Add(pname)
										j += 1
									End While
									insert.ExecuteNonQuery()
									counter += 1
									If counter Mod 1000 = 0 Then
										CheckCancelled()
										tx.Commit()
										handler(False, True, CType((100.0 * i / schema.Count), Integer), "Added " + counter + " rows to table " + schema(i).TableName + " so far")
										tx = sqconn.BeginTransaction()
									End If
									' while
								End While
							End Using
							' using
							CheckCancelled()
							tx.Commit()

							handler(False, True, CType((100.0 * i / schema.Count), Integer), "Finished inserting rows for table " + schema(i).TableName)
							_log.Debug("finished inserting all rows for table [" + schema(i).TableName + "]")
						Catch ex As Exception
							_log.[Error]("unexpected exception", ex)
							tx.Rollback()
							Throw
							' catch
						End Try
						i += 1
					End While
					' using
				End Using
			End Using
			' using
		End Sub

		''' <summary>
		''' Used in order to adjust the value received from SQL Servr for the SQLite database.
		''' </summary>
		''' <param name="val">The value object</param>
		''' <param name="columnSchema">The corresponding column schema</param>
		''' <returns>SQLite adjusted value.</returns>
		Private Shared Function CastValueForColumn(val As Object, columnSchema As ColumnSchema) As Object
			If TypeOf val Is DBNull Then
				Return Nothing
			End If

			Dim dt As DbType = GetDbTypeOfColumn(columnSchema)

			Select Case dt
				Case DbType.Int32
					If TypeOf val Is Short Then
						Return CType(CType(val, Short), Integer)
					End If
					If TypeOf val Is Byte Then
						Return CType(CType(val, Byte), Integer)
					End If
					If TypeOf val Is Long Then
						Return CType(CType(val, Long), Integer)
					End If
					If TypeOf val Is Decimal Then
						Return CType(CType(val, Decimal), Integer)
					End If
					Exit Select

				Case DbType.Int16
					If TypeOf val Is Integer Then
						Return CType(CType(val, Integer), Short)
					End If
					If TypeOf val Is Byte Then
						Return CType(CType(val, Byte), Short)
					End If
					If TypeOf val Is Long Then
						Return CType(CType(val, Long), Short)
					End If
					If TypeOf val Is Decimal Then
						Return CType(CType(val, Decimal), Short)
					End If
					Exit Select

				Case DbType.Int64
					If TypeOf val Is Integer Then
						Return CType(CType(val, Integer), Long)
					End If
					If TypeOf val Is Short Then
						Return CType(CType(val, Short), Long)
					End If
					If TypeOf val Is Byte Then
						Return CType(CType(val, Byte), Long)
					End If
					If TypeOf val Is Decimal Then
						Return CType(CType(val, Decimal), Long)
					End If
					Exit Select

				Case DbType.[Single]
					If TypeOf val Is Double Then
						Return CType(CType(val, Double), Single)
					End If
					If TypeOf val Is Decimal Then
						Return CType(CType(val, Decimal), Single)
					End If
					Exit Select

				Case DbType.[Double]
					If TypeOf val Is Single Then
						Return CType(CType(val, Single), Double)
					End If
					If TypeOf val Is Double Then
						Return CType(val, Double)
					End If
					If TypeOf val Is Decimal Then
						Return CType(CType(val, Decimal), Double)
					End If
					Exit Select

				Case DbType.[String]
					If TypeOf val Is Guid Then
						Return (CType(val, Guid)).ToString()
					End If
					Exit Select

				Case DbType.Guid
					If TypeOf val Is String Then
						Return ParseStringAsGuid(CType(val, String))
					End If
					If TypeOf val Is Byte() Then
						Return ParseBlobAsGuid(CType(val, Byte()))
					End If
					Exit Select

				Case DbType.Binary, DbType.[Boolean], DbType.DateTime
					Exit Select
				Case Else

					_log.[Error]("argument exception - illegal database type")
					Throw New ArgumentException("Illegal database type [" + [Enum].GetName(GetType(DbType), dt) + "]")
			End Select
			' switch
			Return val
		End Function

		Private Shared Function ParseBlobAsGuid(blob As Byte()) As Guid
			Dim data As Byte() = blob
			If blob.Length > 16 Then
				data = New Byte(16) {}
				Dim i As Integer = 0
				While i < 16
					data(i) = blob(i)
					i += 1
				End While
			ElseIf blob.Length < 16 Then
				data = New Byte(16) {}
				Dim i As Integer = 0
				While i < blob.Length
					data(i) = blob(i)
					i += 1
				End While
			End If

			Return New Guid(data)
		End Function

		Private Shared Function ParseStringAsGuid(str As String) As Guid
			Try
				Return New Guid(str)
			Catch ex As Exception
				Return Guid.Empty
			End Try
			' catch
		End Function

		''' <summary>
		''' Creates a command object needed to insert values into a specific SQLite table.
		''' </summary>
		''' <param name="ts">The table schema object for the table.</param>
		''' <returns>A command object with the required functionality.</returns>
		Private Shared Function BuildSQLiteInsert(ts As TableSchema) As SQLiteCommand
			Dim res As New SQLiteCommand()

			Dim sb As New StringBuilder()
			sb.Append("INSERT INTO [" + ts.TableName + "] (")
			Dim i As Integer = 0
			While i < ts.Columns.Count
				sb.Append("[" + ts.Columns(i).ColumnName + "]")
				If i < ts.Columns.Count - 1 Then
					sb.Append(", ")
				End If
				i += 1
			End While
			' for
			sb.Append(") VALUES (")

			Dim pnames As New List(Of String)()
			Dim i As Integer = 0
			While i < ts.Columns.Count
				Dim pname As String = "@" + GetNormalizedName(ts.Columns(i).ColumnName, pnames)
				sb.Append(pname)
				If i < ts.Columns.Count - 1 Then
					sb.Append(", ")
				End If

				Dim dbType As DbType = GetDbTypeOfColumn(ts.Columns(i))
				Dim prm As New SQLiteParameter(pname, dbType, ts.Columns(i).ColumnName)
				res.Parameters.Add(prm)

				' Remember the parameter name in order to avoid duplicates
				pnames.Add(pname)
				i += 1
			End While
			' for
			sb.Append(")")
			res.CommandText = sb.ToString()
			res.CommandType = CommandType.Text
			Return res
		End Function

		''' <summary>
		''' Used in order to avoid breaking naming rules (e.g., when a table has
		''' a name in SQL Server that cannot be used as a basis for a matching index
		''' name in SQLite).
		''' </summary>
		''' <param name="str">The name to change if necessary</param>
		''' <param name="names">Used to avoid duplicate names</param>
		''' <returns>A normalized name</returns>
		Private Shared Function GetNormalizedName(str As String, names As List(Of String)) As String
			Dim sb As New StringBuilder()
			Dim i As Integer = 0
			While i < str.Length
				If [Char].IsLetterOrDigit(str(i)) OrElse str(i) = "_"C Then
					sb.Append(str(i))
				Else
					sb.Append("_")
				End If
				i += 1
			End While
			' for
			' Avoid returning duplicate name
			If names.Contains(sb.ToString()) Then
				Return GetNormalizedName(sb.ToString() + "_", names)
			Else
				Return sb.ToString()
			End If
		End Function

		''' <summary>
		''' Matches SQL Server types to general DB types
		''' </summary>
		''' <param name="cs">The column schema to use for the match</param>
		''' <returns>The matched DB type</returns>
		Private Shared Function GetDbTypeOfColumn(cs As ColumnSchema) As DbType
			If cs.ColumnType = "tinyint" Then
				Return DbType.[Byte]
			End If
			If cs.ColumnType = "int" Then
				Return DbType.Int32
			End If
			If cs.ColumnType = "smallint" Then
				Return DbType.Int16
			End If
			If cs.ColumnType = "bigint" Then
				Return DbType.Int64
			End If
			If cs.ColumnType = "bit" Then
				Return DbType.[Boolean]
			End If
			If cs.ColumnType = "nvarchar" OrElse cs.ColumnType = "varchar" OrElse cs.ColumnType = "text" OrElse cs.ColumnType = "ntext" Then
				Return DbType.[String]
			End If
			If cs.ColumnType = "float" Then
				Return DbType.[Double]
			End If
			If cs.ColumnType = "real" Then
				Return DbType.[Single]
			End If
			If cs.ColumnType = "blob" Then
				Return DbType.Binary
			End If
			If cs.ColumnType = "numeric" Then
				Return DbType.[Double]
			End If
			If cs.ColumnType = "timestamp" OrElse cs.ColumnType = "datetime" OrElse cs.ColumnType = "datetime2" OrElse cs.ColumnType = "date" OrElse cs.ColumnType = "time" Then
				Return DbType.DateTime
			End If
			If cs.ColumnType = "nchar" OrElse cs.ColumnType = "char" Then
				Return DbType.[String]
			End If
			If cs.ColumnType = "uniqueidentifier" OrElse cs.ColumnType = "guid" Then
				Return DbType.Guid
			End If
			If cs.ColumnType = "xml" Then
				Return DbType.[String]
			End If
			If cs.ColumnType = "sql_variant" Then
				Return DbType.[Object]
			End If
			If cs.ColumnType = "integer" Then
				Return DbType.Int64
			End If

			_log.[Error]("illegal db type found")
			Throw New ApplicationException("Illegal DB type found (" + cs.ColumnType + ")")
		End Function

		''' <summary>
		''' Builds a SELECT query for a specific table. Needed in the process of copying rows
		''' from the SQL Server database to the SQLite database.
		''' </summary>
		''' <param name="ts">The table schema of the table for which we need the query.</param>
		''' <returns>The SELECT query for the table.</returns>
		Private Shared Function BuildSqlServerTableQuery(ts As TableSchema) As String
			Dim sb As New StringBuilder()
			sb.Append("SELECT ")
			Dim i As Integer = 0
			While i < ts.Columns.Count
				sb.Append("[" + ts.Columns(i).ColumnName + "]")
				If i < ts.Columns.Count - 1 Then
					sb.Append(", ")
				End If
				i += 1
			End While
			' for
			sb.Append(" FROM " + ts.TableSchemaName + "." + "[" + ts.TableName + "]")
			Return sb.ToString()
		End Function

		''' <summary>
		''' Creates the SQLite database from the schema read from the SQL Server.
		''' </summary>
		''' <param name="sqlitePath">The path to the generated DB file.</param>
		''' <param name="schema">The schema of the SQL server database.</param>
		''' <param name="password">The password to use for encrypting the DB or null if non is needed.</param>
		''' <param name="handler">A handle for progress notifications.</param>
		Private Shared Sub CreateSQLiteDatabase(sqlitePath As String, schema As DatabaseSchema, password As String, handler As SqlConversionHandler, viewFailureHandler As FailedViewDefinitionHandler, createViews As Boolean)
			_log.Debug("Creating SQLite database...")

			' Create the SQLite database file
			SQLiteConnection.CreateFile(sqlitePath)

			_log.Debug("SQLite file was created successfully at [" + sqlitePath + "]")

			' Connect to the newly created database
			Dim sqliteConnString As String = CreateSQLiteConnectionString(sqlitePath, password)
			Using conn As New SQLiteConnection(sqliteConnString)
				conn.Open()

				' Create all tables in the new database
				Dim count As Integer = 0
				For Each dt As TableSchema In schema.Tables
					Try
						AddSQLiteTable(conn, dt)
					Catch ex As Exception
						_log.[Error]("AddSQLiteTable failed", ex)
						Throw
					End Try
					count += 1
					CheckCancelled()
					handler(False, True, CType((count * 50.0 / schema.Tables.Count), Integer), "Added table " + dt.TableName + " to the SQLite database")

					_log.Debug("added schema for SQLite table [" + dt.TableName + "]")
				Next
				' foreach
				' Create all views in the new database
				count = 0
				If createViews Then
					For Each vs As ViewSchema In schema.Views
						Try
							AddSQLiteView(conn, vs, viewFailureHandler)
						Catch ex As Exception
							_log.[Error]("AddSQLiteView failed", ex)
							Throw
						End Try
						' catch
						count += 1
						CheckCancelled()
						handler(False, True, 50 + CType((count * 50.0 / schema.Views.Count), Integer), "Added view " + vs.ViewName + " to the SQLite database")


						_log.Debug("added schema for SQLite view [" + vs.ViewName + "]")
						' foreach
					Next
					' if
				End If
			End Using
			' using
			_log.Debug("finished adding all table/view schemas for SQLite database")
		End Sub

		Private Shared Sub AddSQLiteView(conn As SQLiteConnection, vs As ViewSchema, handler As FailedViewDefinitionHandler)
			' Prepare a CREATE VIEW DDL statement
			Dim stmt As String = vs.ViewSQL
			_log.Info(vbLf & vbLf + stmt + vbLf & vbLf)

			' Execute the query in order to actually create the view.
			Dim tx As SQLiteTransaction = conn.BeginTransaction()
			Try
				Dim cmd As New SQLiteCommand(stmt, conn, tx)
				cmd.ExecuteNonQuery()

				tx.Commit()
			Catch ex As SQLiteException
				tx.Rollback()

				If handler IsNot Nothing Then
					Dim updated As New ViewSchema()
					updated.ViewName = vs.ViewName
					updated.ViewSQL = vs.ViewSQL

					' Ask the user to supply the new view definition SQL statement
					Dim sql As String = handler(updated)

					If sql Is Nothing Then
						Return
					Else
						' Discard the view
						' Try to re-create the view with the user-supplied view definition SQL
						updated.ViewSQL = sql
						AddSQLiteView(conn, updated, handler)
					End If
				Else
					Throw
				End If
			End Try
			' catch
		End Sub

		''' <summary>
		''' Creates the CREATE TABLE DDL for SQLite and a specific table.
		''' </summary>
		''' <param name="conn">The SQLite connection</param>
		''' <param name="dt">The table schema object for the table to be generated.</param>
		Private Shared Sub AddSQLiteTable(conn As SQLiteConnection, dt As TableSchema)
			' Prepare a CREATE TABLE DDL statement
			Dim stmt As String = BuildCreateTableQuery(dt)

			_log.Info(vbLf & vbLf + stmt + vbLf & vbLf)

			' Execute the query in order to actually create the table.
			Dim cmd As New SQLiteCommand(stmt, conn)
			cmd.ExecuteNonQuery()
		End Sub

		''' <summary>
		''' returns the CREATE TABLE DDL for creating the SQLite table from the specified
		''' table schema object.
		''' </summary>
		''' <param name="ts">The table schema object from which to create the SQL statement.</param>
		''' <returns>CREATE TABLE DDL for the specified table.</returns>
		Private Shared Function BuildCreateTableQuery(ts As TableSchema) As String
			Dim sb As New StringBuilder()

			sb.Append("CREATE TABLE [" + ts.TableName + "] (" & vbLf)

			Dim pkey As Boolean = False
			Dim i As Integer = 0
			While i < ts.Columns.Count
				Dim col As ColumnSchema = ts.Columns(i)
				Dim cline As String = BuildColumnStatement(col, ts, pkey)
				sb.Append(cline)
				If i < ts.Columns.Count - 1 Then
					sb.Append("," & vbLf)
				End If
				i += 1
			End While
			' foreach
			' add primary keys...
			If ts.PrimaryKey IsNot Nothing AndAlso (ts.PrimaryKey.Count > 0 And Not pkey) Then
				sb.Append("," & vbLf)
				sb.Append("    PRIMARY KEY (")
				Dim i As Integer = 0
				While i < ts.PrimaryKey.Count
					sb.Append("[" + ts.PrimaryKey(i) + "]")
					If i < ts.PrimaryKey.Count - 1 Then
						sb.Append(", ")
					End If
					i += 1
				End While
				' for
				sb.Append(")" & vbLf)
			Else
				sb.Append(vbLf)
			End If

			' add foreign keys...
			If ts.ForeignKeys.Count > 0 Then
				sb.Append("," & vbLf)
				Dim i As Integer = 0
				While i < ts.ForeignKeys.Count
					Dim foreignKey As ForeignKeySchema = ts.ForeignKeys(i)
					Dim stmt As String = String.Format("    FOREIGN KEY ([{0}])" & vbLf & "        REFERENCES [{1}]([{2}])", foreignKey.ColumnName, foreignKey.ForeignTableName, foreignKey.ForeignColumnName)

					sb.Append(stmt)
					If i < ts.ForeignKeys.Count - 1 Then
						sb.Append("," & vbLf)
					End If
					i += 1
					' for
				End While
			End If

			sb.Append(vbLf)
			sb.Append(");" & vbLf)

			' Create any relevant indexes
			If ts.Indexes IsNot Nothing Then
				Dim i As Integer = 0
				While i < ts.Indexes.Count
					Dim stmt As String = BuildCreateIndex(ts.TableName, ts.Indexes(i))
					sb.Append(stmt + ";" & vbLf)
					i += 1
					' for
				End While
			End If
			' if
			Dim query As String = sb.ToString()
			Return query
		End Function

		''' <summary>
		''' Creates a CREATE INDEX DDL for the specified table and index schema.
		''' </summary>
		''' <param name="tableName">The name of the indexed table.</param>
		''' <param name="indexSchema">The schema of the index object</param>
		''' <returns>A CREATE INDEX DDL (SQLite format).</returns>
		Private Shared Function BuildCreateIndex(tableName As String, indexSchema As IndexSchema) As String
			Dim sb As New StringBuilder()
			sb.Append("CREATE ")
			If indexSchema.IsUnique Then
				sb.Append("UNIQUE ")
			End If
			sb.Append("INDEX [" + tableName + "_" + indexSchema.IndexName + "]" & vbLf)
			sb.Append("ON [" + tableName + "]" & vbLf)
			sb.Append("(")
			Dim i As Integer = 0
			While i < indexSchema.Columns.Count
				sb.Append("[" + indexSchema.Columns(i).ColumnName + "]")
				If Not indexSchema.Columns(i).IsAscending Then
					sb.Append(" DESC")
				End If
				If i < indexSchema.Columns.Count - 1 Then
					sb.Append(", ")
				End If
				i += 1
			End While
			' for
			sb.Append(")")

			Return sb.ToString()
		End Function

		''' <summary>
		''' Used when creating the CREATE TABLE DDL. Creates a single row
		''' for the specified column.
		''' </summary>
		''' <param name="col">The column schema</param>
		''' <returns>A single column line to be inserted into the general CREATE TABLE DDL statement</returns>
		Private Shared Function BuildColumnStatement(col As ColumnSchema, ts As TableSchema, ByRef pkey As Boolean) As String
			Dim sb As New StringBuilder()
			sb.Append(vbTab & "[" + col.ColumnName + "]" & vbTab)

			' Special treatment for IDENTITY columns
			If col.IsIdentity Then
				If ts.PrimaryKey.Count = 1 AndAlso (col.ColumnType = "tinyint" OrElse col.ColumnType = "int" OrElse col.ColumnType = "smallint" OrElse col.ColumnType = "bigint" OrElse col.ColumnType = "integer") Then
					sb.Append("integer PRIMARY KEY AUTOINCREMENT")
					pkey = True
				Else
					sb.Append("integer")
				End If
			Else
				If col.ColumnType = "int" Then
					sb.Append("integer")
				Else
					sb.Append(col.ColumnType)
				End If
				If col.Length > 0 Then
					sb.Append("(" + col.Length + ")")
				End If
			End If
			If Not col.IsNullable Then
				sb.Append(" NOT NULL")
			End If

			If col.IsCaseSensitivite.HasValue AndAlso Not col.IsCaseSensitivite.Value Then
				sb.Append(" COLLATE NOCASE")
			End If

			Dim defval As String = StripParens(col.DefaultValue)
			defval = DiscardNational(defval)
			_log.Debug("DEFAULT VALUE BEFORE [" + col.DefaultValue + "] AFTER [" + defval + "]")
			If defval <> String.Empty AndAlso defval.ToUpper().Contains("GETDATE") Then
				_log.Debug("converted SQL Server GETDATE() to CURRENT_TIMESTAMP for column [" + col.ColumnName + "]")
				sb.Append(" DEFAULT (CURRENT_TIMESTAMP)")
			ElseIf defval <> String.Empty AndAlso IsValidDefaultValue(defval) Then
				sb.Append(" DEFAULT " + defval)
			End If

			Return sb.ToString()
		End Function

		''' <summary>
		''' Discards the national prefix if exists (e.g., N'sometext') which is not
		''' supported in SQLite.
		''' </summary>
		''' <param name="value">The value.</param>
		''' <returns></returns>
		Private Shared Function DiscardNational(value As String) As String
			Dim rx As New Regex("N\'([^\']*)\'")
			Dim m As Match = rx.Match(value)
			If m.Success Then
				Return m.Groups(1).Value
			Else
				Return value
			End If
		End Function

		''' <summary>
		''' Check if the DEFAULT clause is valid by SQLite standards
		''' </summary>
		''' <param name="value"></param>
		''' <returns></returns>
		Private Shared Function IsValidDefaultValue(value As String) As Boolean
			If IsSingleQuoted(value) Then
				Return True
			End If

			Dim testnum As Double
			If Not Double.TryParse(value, testnum) Then
				Return False
			End If
			Return True
		End Function

		Private Shared Function IsSingleQuoted(value As String) As Boolean
			value = value.Trim()
			If value.StartsWith("'") AndAlso value.EndsWith("'") Then
				Return True
			End If
			Return False
		End Function

		''' <summary>
		''' Strip any parentheses from the string.
		''' </summary>
		''' <param name="value">The string to strip</param>
		''' <returns>The stripped string</returns>
		Private Shared Function StripParens(value As String) As String
			Dim rx As New Regex("\(([^\)]*)\)")
			Dim m As Match = rx.Match(value)
			If Not m.Success Then
				Return value
			Else
				Return StripParens(m.Groups(1).Value)
			End If
		End Function

		''' <summary>
		''' Reads the entire SQL Server DB schema using the specified connection string.
		''' </summary>
		''' <param name="connString">The connection string used for reading SQL Server schema.</param>
		''' <param name="handler">A handler for progress notifications.</param>
		''' <param name="selectionHandler">The selection handler which allows the user to select 
		''' which tables to convert.</param>
		''' <returns>database schema objects for every table/view in the SQL Server database.</returns>
		Private Shared Function ReadSqlServerSchema(connString As String, handler As SqlConversionHandler, selectionHandler As SqlTableSelectionHandler) As DatabaseSchema
			' First step is to read the names of all tables in the database
			Dim tables As New List(Of TableSchema)()
			Using conn As New SqlConnection(connString)
				conn.Open()

				Dim tableNames As New List(Of String)()
				Dim tblschema As New List(Of String)()

				' This command will read the names of all tables in the database
				Dim cmd As New SqlCommand("select * from INFORMATION_SCHEMA.TABLES  where TABLE_TYPE = 'BASE TABLE'", conn)
				Using reader As SqlDataReader = cmd.ExecuteReader()
					While reader.Read()
						If reader("TABLE_NAME") = DBNull.Value Then
							Continue While
						End If
						If reader("TABLE_SCHEMA") = DBNull.Value Then
							Continue While
						End If
						tableNames.Add(CType(reader("TABLE_NAME"), String))
						tblschema.Add(CType(reader("TABLE_SCHEMA"), String))
						' while
					End While
				End Using
				' using
				' Next step is to use ADO APIs to query the schema of each table.
				Dim count As Integer = 0
				Dim i As Integer = 0
				While i < tableNames.Count
					Dim tname As String = tableNames(i)
					Dim tschma As String = tblschema(i)
					Dim ts As TableSchema = CreateTableSchema(conn, tname, tschma)
					CreateForeignKeySchema(conn, ts)
					tables.Add(ts)
					count += 1
					CheckCancelled()
					handler(False, True, CType((count * 50.0 / tableNames.Count), Integer), "Parsed table " + tname)

					_log.Debug("parsed table schema for [" + tname + "]")
					i += 1
					' foreach
				End While
			End Using
			' using
			_log.Debug("finished parsing all tables in SQL Server schema")

			' Allow the user a chance to select which tables to convert
			If selectionHandler IsNot Nothing Then
				Dim updated As List(Of TableSchema) = selectionHandler(tables)
				If updated IsNot Nothing Then
					tables = updated
				End If
			End If
			' if
			Dim removedbo As New Regex("dbo\.", RegexOptions.Compiled Or RegexOptions.IgnoreCase)

			' Continue and read all of the views in the database
			Dim views As New List(Of ViewSchema)()
			Using conn As New SqlConnection(connString)
				conn.Open()

				Dim cmd As New SqlCommand("SELECT TABLE_NAME, VIEW_DEFINITION  from INFORMATION_SCHEMA.VIEWS", conn)
				Using reader As SqlDataReader = cmd.ExecuteReader()
					Dim count As Integer = 0
					While reader.Read()
						Dim vs As New ViewSchema()

						If reader("TABLE_NAME") = DBNull.Value Then
							Continue While
						End If
						If reader("VIEW_DEFINITION") = DBNull.Value Then
							Continue While
						End If
						vs.ViewName = CType(reader("TABLE_NAME"), String)
						vs.ViewSQL = CType(reader("VIEW_DEFINITION"), String)

						' Remove all ".dbo" strings from the view definition
						vs.ViewSQL = removedbo.Replace(vs.ViewSQL, String.Empty)

						views.Add(vs)

						count += 1
						CheckCancelled()
						handler(False, True, 50 + CType((count * 50.0 / views.Count), Integer), "Parsed view " + vs.ViewName)

						_log.Debug("parsed view schema for [" + vs.ViewName + "]")
						' while
					End While
					' using
				End Using
			End Using
			' using
			Dim ds As New DatabaseSchema()
			ds.Tables = tables
			ds.Views = views
			Return ds
		End Function

		''' <summary>
		''' Convenience method for checking if the conversion progress needs to be cancelled.
		''' </summary>
		Private Shared Sub CheckCancelled()
			If _cancelled Then
				Throw New ApplicationException("User cancelled the conversion")
			End If
		End Sub

		''' <summary>
		''' Creates a TableSchema object using the specified SQL Server connection
		''' and the name of the table for which we need to create the schema.
		''' </summary>
		''' <param name="conn">The SQL Server connection to use</param>
		''' <param name="tableName">The name of the table for which we wants to create the table schema.</param>
		''' <returns>A table schema object that represents our knowledge of the table schema</returns>
		Private Shared Function CreateTableSchema(conn As SqlConnection, tableName As String, tschma As String) As TableSchema
			Dim res As New TableSchema()
			res.TableName = tableName
			res.TableSchemaName = tschma
			res.Columns = New List(Of ColumnSchema)()
			Dim cmd As New SqlCommand("SELECT COLUMN_NAME,COLUMN_DEFAULT,IS_NULLABLE,DATA_TYPE, " + " (columnproperty(object_id(TABLE_NAME), COLUMN_NAME, 'IsIdentity')) AS [IDENT], " + "CHARACTER_MAXIMUM_LENGTH AS CSIZE " + "FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "' ORDER BY " + "ORDINAL_POSITION ASC", conn)
			Using reader As SqlDataReader = cmd.ExecuteReader()
				While reader.Read()
					Dim tmp As Object = reader("COLUMN_NAME")
					If TypeOf tmp Is DBNull Then
						Continue While
					End If
					Dim colName As String = CType(reader("COLUMN_NAME"), String)

					tmp = reader("COLUMN_DEFAULT")
					Dim colDefault As String
					If TypeOf tmp Is DBNull Then
						colDefault = String.Empty
					Else
						colDefault = CType(tmp, String)
					End If

					tmp = reader("IS_NULLABLE")
					Dim isNullable As Boolean = (CType(tmp, String) = "YES")
					Dim dataType As String = CType(reader("DATA_TYPE"), String)
					Dim isIdentity As Boolean = False
					If reader("IDENT") <> DBNull.Value Then
						isIdentity = If((CType(reader("IDENT"), Integer)) = 1, True, False)
					End If
					Dim length As Integer = If(reader("CSIZE") <> DBNull.Value, Convert.ToInt32(reader("CSIZE")), 0)

					ValidateDataType(dataType)

					' Note that not all data type names need to be converted because
					' SQLite establishes type affinity by searching certain strings
					' in the type name. For example - everything containing the string
					' 'int' in its type name will be assigned an INTEGER affinity
					If dataType = "timestamp" Then
						dataType = "blob"
					ElseIf dataType = "datetime" OrElse dataType = "smalldatetime" OrElse dataType = "date" OrElse dataType = "datetime2" OrElse dataType = "time" Then
						dataType = "datetime"
					ElseIf dataType = "decimal" Then
						dataType = "numeric"
					ElseIf dataType = "money" OrElse dataType = "smallmoney" Then
						dataType = "numeric"
					ElseIf dataType = "binary" OrElse dataType = "varbinary" OrElse dataType = "image" Then
						dataType = "blob"
					ElseIf dataType = "tinyint" Then
						dataType = "smallint"
					ElseIf dataType = "bigint" Then
						dataType = "integer"
					ElseIf dataType = "sql_variant" Then
						dataType = "blob"
					ElseIf dataType = "xml" Then
						dataType = "varchar"
					ElseIf dataType = "uniqueidentifier" Then
						dataType = "guid"
					ElseIf dataType = "ntext" Then
						dataType = "text"
					ElseIf dataType = "nchar" Then
						dataType = "char"
					End If

					If dataType = "bit" OrElse dataType = "int" Then
						If colDefault = "('False')" Then
							colDefault = "(0)"
						ElseIf colDefault = "('True')" Then
							colDefault = "(1)"
						End If
					End If

					colDefault = FixDefaultValueString(colDefault)

					Dim col As New ColumnSchema()
					col.ColumnName = colName
					col.ColumnType = dataType
					col.Length = length
					col.IsNullable = isNullable
					col.IsIdentity = isIdentity
					col.DefaultValue = AdjustDefaultValue(colDefault)
					res.Columns.Add(col)
					' while
				End While
			End Using
			' using
			' Find PRIMARY KEY information
			Dim cmd2 As New SqlCommand("EXEC sp_pkeys '" + tableName + "'", conn)
			Using reader As SqlDataReader = cmd2.ExecuteReader()
				res.PrimaryKey = New List(Of String)()
				While reader.Read()
					Dim colName As String = CType(reader("COLUMN_NAME"), String)
					res.PrimaryKey.Add(colName)
					' while
				End While
			End Using
			' using
			' Find COLLATE information for all columns in the table
			Dim cmd4 As New SqlCommand("EXEC sp_tablecollations '" + tschma + "." + tableName + "'", conn)
			Using reader As SqlDataReader = cmd4.ExecuteReader()
				While reader.Read()
					Dim isCaseSensitive As System.Nullable(Of Boolean) = Nothing
					Dim colName As String = CType(reader("name"), String)
					If reader("tds_collation") <> DBNull.Value Then
						Dim mask As Byte() = CType(reader("tds_collation"), Byte())
						If (mask(2) And &H10) <> 0 Then
							isCaseSensitive = False
						Else
							isCaseSensitive = True
						End If
					End If
					' if
					If isCaseSensitive.HasValue Then
						' Update the corresponding column schema.
						For Each csc As ColumnSchema In res.Columns
							If csc.ColumnName = colName Then
								csc.IsCaseSensitivite = isCaseSensitive
								Exit For
							End If
							' foreach
						Next
						' if
					End If
					' while
				End While
			End Using
			' using
			Try
				' Find index information
				Dim cmd3 As New SqlCommand("exec sp_helpindex '" + tschma + "." + tableName + "'", conn)
				Using reader As SqlDataReader = cmd3.ExecuteReader()
					res.Indexes = New List(Of IndexSchema)()
					While reader.Read()
						Dim indexName As String = CType(reader("index_name"), String)
						Dim desc As String = CType(reader("index_description"), String)
						Dim keys As String = CType(reader("index_keys"), String)

						' Don't add the index if it is actually a primary key index
						If desc.Contains("primary key") Then
							Continue While
						End If

						Dim index As IndexSchema = BuildIndexSchema(indexName, desc, keys)
						res.Indexes.Add(index)
						' while
					End While
					' using
				End Using
			Catch ex As Exception
				_log.Warn("failed to read index information for table [" + tableName + "]")
			End Try
			' catch
			Return res
		End Function

		''' <summary>
		''' Small validation method to make sure we don't miss anything without getting
		''' an exception.
		''' </summary>
		''' <param name="dataType">The datatype to validate.</param>
		Private Shared Sub ValidateDataType(dataType As String)
			If dataType = "int" OrElse dataType = "smallint" OrElse dataType = "bit" OrElse dataType = "float" OrElse dataType = "real" OrElse dataType = "nvarchar" OrElse dataType = "varchar" OrElse dataType = "timestamp" OrElse dataType = "varbinary" OrElse dataType = "image" OrElse dataType = "text" OrElse dataType = "ntext" OrElse dataType = "bigint" OrElse dataType = "char" OrElse dataType = "numeric" OrElse dataType = "binary" OrElse dataType = "smalldatetime" OrElse dataType = "smallmoney" OrElse dataType = "money" OrElse dataType = "tinyint" OrElse dataType = "uniqueidentifier" OrElse dataType = "xml" OrElse dataType = "sql_variant" OrElse dataType = "datetime2" OrElse dataType = "date" OrElse dataType = "time" OrElse dataType = "decimal" OrElse dataType = "nchar" OrElse dataType = "datetime" Then
				Return
			End If
			Throw New ApplicationException("Validation failed for data type [" + dataType + "]")
		End Sub

		''' <summary>
		''' Does some necessary adjustments to a value string that appears in a column DEFAULT
		''' clause.
		''' </summary>
		''' <param name="colDefault">The original default value string (as read from SQL Server).</param>
		''' <returns>Adjusted DEFAULT value string (for SQLite)</returns>
		Private Shared Function FixDefaultValueString(colDefault As String) As String
			Dim replaced As Boolean = False
			Dim res As String = colDefault.Trim()

			' Find first/last indexes in which to search
			Dim first As Integer = -1
			Dim last As Integer = -1
			Dim i As Integer = 0
			While i < res.Length
				If res(i) = "'"C AndAlso first = -1 Then
					first = i
				End If
				If res(i) = "'"C AndAlso first <> -1 AndAlso i > last Then
					last = i
				End If
				i += 1
			End While
			' for
			If first <> -1 AndAlso last > first Then
				Return res.Substring(first, last - first + 1)
			End If

			Dim sb As New StringBuilder()
			Dim i As Integer = 0
			While i < res.Length
				If res(i) <> "("C AndAlso res(i) <> ")"C Then
					sb.Append(res(i))
					replaced = True
				End If
				i += 1
			End While
			If replaced Then
				Return "(" + sb.ToString() + ")"
			Else
				Return sb.ToString()
			End If
		End Function



		''' <summary>
		''' Add foreign key schema object from the specified components (Read from SQL Server).
		''' </summary>
		''' <param name="conn">The SQL Server connection to use</param>
		''' <param name="ts">The table schema to whom foreign key schema should be added to</param>
		Private Shared Sub CreateForeignKeySchema(conn As SqlConnection, ts As TableSchema)
			ts.ForeignKeys = New List(Of ForeignKeySchema)()

			Dim cmd As New SqlCommand("SELECT " + "  ColumnName = CU.COLUMN_NAME, " + "  ForeignTableName  = PK.TABLE_NAME, " + "  ForeignColumnName = PT.COLUMN_NAME, " + "  DeleteRule = C.DELETE_RULE, " + "  IsNullable = COL.IS_NULLABLE " + "FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C " + "INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME " + "INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME " + "INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME " + "INNER JOIN " + "  ( " + "    SELECT i1.TABLE_NAME, i2.COLUMN_NAME " + "    FROM  INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 " + "    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME " + "    WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY' " + "  ) " + "PT ON PT.TABLE_NAME = PK.TABLE_NAME " + "INNER JOIN INFORMATION_SCHEMA.COLUMNS AS COL ON CU.COLUMN_NAME = COL.COLUMN_NAME AND FK.TABLE_NAME = COL.TABLE_NAME " + "WHERE FK.Table_NAME='" + ts.TableName + "'", conn)

			Using reader As SqlDataReader = cmd.ExecuteReader()
				While reader.Read()
					Dim fkc As New ForeignKeySchema()
					fkc.ColumnName = CType(reader("ColumnName"), String)
					fkc.ForeignTableName = CType(reader("ForeignTableName"), String)
					fkc.ForeignColumnName = CType(reader("ForeignColumnName"), String)
					fkc.CascadeOnDelete = CType(reader("DeleteRule"), String) = "CASCADE"
					fkc.IsNullable = CType(reader("IsNullable"), String) = "YES"
					fkc.TableName = ts.TableName
					ts.ForeignKeys.Add(fkc)
				End While
			End Using
		End Sub

		''' <summary>
		''' Builds an index schema object from the specified components (Read from SQL Server).
		''' </summary>
		''' <param name="indexName">The name of the index</param>
		''' <param name="desc">The description of the index</param>
		''' <param name="keys">Key columns that are part of the index.</param>
		''' <returns>An index schema object that represents our knowledge of the index</returns>
		Private Shared Function BuildIndexSchema(indexName As String, desc As String, keys As String) As IndexSchema
			Dim res As New IndexSchema()
			res.IndexName = indexName

			' Determine if this is a unique index or not.
			Dim descParts As String() = desc.Split(","C)
			For Each p As String In descParts
				If p.Trim().Contains("unique") Then
					res.IsUnique = True
					Exit For
				End If
			Next
			' foreach
			' Get all key names and check if they are ASCENDING or DESCENDING
			res.Columns = New List(Of IndexColumn)()
			Dim keysParts As String() = keys.Split(","C)
			For Each p As String In keysParts
				Dim m As Match = _keyRx.Match(p.Trim())
				If Not m.Success Then
					Throw New ApplicationException("Illegal key name [" + p + "] in index [" + indexName + "]")
				End If

				Dim key As String = m.Groups(1).Value
				Dim ic As New IndexColumn()
				ic.ColumnName = key
				If m.Groups(2).Success Then
					ic.IsAscending = False
				Else
					ic.IsAscending = True
				End If

				res.Columns.Add(ic)
			Next
			' foreach
			Return res
		End Function

		''' <summary>
		''' More adjustments for the DEFAULT value clause.
		''' </summary>
		''' <param name="val">The value to adjust</param>
		''' <returns>Adjusted DEFAULT value string</returns>
		Private Shared Function AdjustDefaultValue(val As String) As String
			If val Is Nothing OrElse val = String.Empty Then
				Return val
			End If

			Dim m As Match = _defaultValueRx.Match(val)
			If m.Success Then
				Return m.Groups(1).Value
			End If
			Return val
		End Function

		''' <summary>
		''' Creates SQLite connection string from the specified DB file path.
		''' </summary>
		''' <param name="sqlitePath">The path to the SQLite database file.</param>
		''' <returns>SQLite connection string</returns>
		Private Shared Function CreateSQLiteConnectionString(sqlitePath As String, password As String) As String
			Dim builder As New SQLiteConnectionStringBuilder()
			builder.DataSource = sqlitePath
			If password IsNot Nothing Then
				builder.Password = password
			End If
			builder.PageSize = 4096
			builder.UseUTF16Encoding = True
			Dim connstring As String = builder.ConnectionString

			Return connstring
		End Function
		#End Region

		#Region "Trigger related"
		Private Shared Sub AddTriggersForForeignKeys(sqlitePath As String, schema As IEnumerable(Of TableSchema), password As String, handler As SqlConversionHandler)
			' Connect to the newly created database
			Dim sqliteConnString As String = CreateSQLiteConnectionString(sqlitePath, password)
			Using conn As New SQLiteConnection(sqliteConnString)
				conn.Open()
				' foreach
				For Each dt As TableSchema In schema
					Try
						AddTableTriggers(conn, dt)
					Catch ex As Exception
						_log.[Error]("AddTableTriggers failed", ex)
						Throw
					End Try

				Next
			End Using
			' using
			_log.Debug("finished adding triggers to schema")
		End Sub

		Private Shared Sub AddTableTriggers(conn As SQLiteConnection, dt As TableSchema)
			Dim triggers As IList(Of TriggerSchema) = TriggerBuilder.GetForeignKeyTriggers(dt)
			For Each trigger As TriggerSchema In triggers
				Dim cmd As New SQLiteCommand(WriteTriggerSchema(trigger), conn)
				cmd.ExecuteNonQuery()
			Next
		End Sub
		#End Region

		''' <summary>
		''' Gets a create script for the triggerSchema in sqlite syntax
		''' </summary>
		''' <param name="ts">Trigger to script</param>
		''' <returns>Executable script</returns>
		Public Shared Function WriteTriggerSchema(ts As TriggerSchema) As String
			Return "CREATE TRIGGER [" + ts.Name + "] " + ts.Type + " " + ts.[Event] + " ON [" + ts.Table + "] " + "BEGIN " + ts.Body + " END;"
		End Function

		#Region "Private Variables"
		Private Shared _isActive As Boolean = False
		Private Shared _cancelled As Boolean = False
		Private Shared _keyRx As New Regex("(([a-zA-Z_äöüÄÖÜß0-9\.]|(\s+))+)(\(\-\))?")
		Private Shared _defaultValueRx As New Regex("\(N(\'.*\')\)")
		Private Shared _log As ILog = LogManager.GetLogger(GetType(SqlServerToSQLite))
		#End Region
	End Class

	''' <summary>
	''' This handler is called whenever a progress is made in the conversion process.
	''' </summary>
	''' <param name="done">TRUE indicates that the entire conversion process is finished.</param>
	''' <param name="success">TRUE indicates that the current step finished successfully.</param>
	''' <param name="percent">Progress percent (0-100)</param>
	''' <param name="msg">A message that accompanies the progress.</param>
	Public Delegate Sub SqlConversionHandler(done As Boolean, success As Boolean, percent As Integer, msg As String)

	''' <summary>
	''' This handler allows the user to change which tables get converted from SQL Server
	''' to SQLite.
	''' </summary>
	''' <param name="schema">The original SQL Server DB schema</param>
	''' <returns>The same schema minus any table we don't want to convert.</returns>
	Public Delegate Function SqlTableSelectionHandler(schema As List(Of TableSchema)) As List(Of TableSchema)

	''' <summary>
	''' This handler is called in order to handle the case when copying the SQL Server view SQL
	''' statement is not enough and the user needs to either update the view definition himself
	''' or discard the view definition from the generated SQLite database.
	''' </summary>
	''' <param name="vs">The problematic view definition</param>
	''' <returns>The updated view definition, or NULL in case the view should be discarded</returns>
	Public Delegate Function FailedViewDefinitionHandler(vs As ViewSchema) As String
End Namespace