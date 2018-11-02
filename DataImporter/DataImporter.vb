Imports System.Net
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Reflection
Imports System.ComponentModel
Imports System.Globalization
Imports System.Data.OleDb

Public Class DataImporter
	Inherits Component

	Public Event ProcessingComplete(sender As Object, e As System.EventArgs)
	Public Event ProcessingCanceled(sender As Object, e As System.EventArgs)
	Public Event errorEvent(ex As Exception)

#Region "properties"

	Public errorList As String = ""
	Public statusList As String = ""
	Public insertCount As Integer = 0
	Public updateCount As Integer = 0
	Public deleteCount As Integer = 0
	Public currentline As Integer = 0

	Public Property tableName As String
	Public Property fileName As String
	Public Property deleteExisting As Boolean = False
	Public Property blankIsNull As Boolean = True
	Public Property createIfMissing As Boolean = False
	Public Property uniqueIdentifierColumns As String = Nothing
	Public Property limitingQuery As String = Nothing
	Public Property completedSQL As String = Nothing
	Public Property columnNames As String = Nothing
	Public Property simulate As Boolean = False
	Public Property outputTable As DataTable = Nothing
	Public Property regExCapture As String = Nothing
	Public Property showstackTrace As Boolean = False

	Private regexMatches As MatchCollection = Nothing
	Private _regexColumnCapture As Regex
	Private ReadOnly Property regexColumnCapture As Regex
		Get
			If _regexColumnCapture Is Nothing Then
				_regexColumnCapture = New Regex(regExCapture,
	RegexOptions.CultureInvariant _
	Or RegexOptions.Compiled
	)
			End If
			Return _regexColumnCapture
		End Get
	End Property
	Private regexColtoGroup As New Hashtable

	Private _connectionType As String = Nothing
	''' <summary>
	''' Sets the type of database bein written to.
	''' </summary>
	''' <returns></returns>
	Public Property connectionType As String
		Get
			Return _connectionType
		End Get
		Set(value As String)
			_connectionType = value
			If connectionString IsNot Nothing Then
				connectionString = connectionString
			End If
		End Set
	End Property
	Public Property connectionString As String
		Set(value As String)
			Try
				Dim myconnType As String = connectionType
				If String.IsNullOrWhiteSpace(myconnType) Then myconnType = "SQL"
				myconnType = myconnType.ToLower().Replace("client", "").Replace("helper", "")
				Dim tmpHelper As BaseClasses.BaseHelper = BaseClasses.DataBase.createHelper(myconnType & "helper")
				If value = "" AndAlso connectionType.ToLower() = "sqlite" Then
					value = BaseClasses.DataBase.defaultSqliteString
				End If
				connection = tmpHelper.createConnection(value)
			Catch ex As Exception
				logerror(ex, "Error creating connection")
			End Try
		End Set
		Get
			If connection Is Nothing Then Return Nothing
			Return connection.ConnectionString
		End Get
	End Property
	Private _dbconnecection As Common.DbConnection
	Public WithEvents WaitingMessage1 As WaitingDialog.WaitingMessage
	Public Property connection As Common.DbConnection
		Set(value As Common.DbConnection)
			_dbconnecection = value
			_sqlhelper = Nothing
		End Set
		Get
			Return _dbconnecection
		End Get
	End Property
	Public Property delimiter As String = ","
	Public Property processRowScriptFile As String = Nothing
	Public Property processInputScriptFile As String = Nothing
	Public Property processTableScript As String = Nothing
	Public Property batchsize As Integer = 50
	Public Property skipRows As Integer = 0
	Public Property excelWorksheetNumber As Integer = 0
	Public Property hideProgress As Boolean = False
	Public Property setCreatedDate As Boolean = True
	Public Property rowVals As String()
	Public importStartedDate As DateTime
	Public Property fileFormat As Format = Format.Auto
	Public Property dateFormats As String() = New String() {"dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "yyyyMMdd"}

	Private _mydateFormats As String = ""
	Public Property dateFormatList As String
		Get
			Return _mydateFormats
		End Get
		Set(value As String)
			_mydateFormats = value
			If Not String.IsNullOrWhiteSpace(value) Then _
				dateFormats = _mydateFormats.Split(",")
		End Set
	End Property


	Public ReadOnly Property isFilenameURL As Boolean
		Get
			If fileName.ToLower().StartsWith("http") Then Return True
			Return False
		End Get
	End Property

	Private _frm As Form
	Public Property parentfrm As Form
		Get
			Return _frm
		End Get
		Set(value As Form)
			_frm = value
			WaitingMessage1 = Nothing
			If value IsNot Nothing Then
				WaitingMessage1 = New WaitingDialog.WaitingMessage
				WaitingMessage1.dialogueType = WaitingDialog.WaitDialogueType.ProgressDlg
				WaitingMessage1.progressbar.Maximum = 100
			End If
		End Set
	End Property

#End Region

#Region "Progress, Status and logs"

	Public Sub updateStatus(message As String, Optional progress As Integer = -1, Optional total As Integer = 0)
		If WaitingMessage1 IsNot Nothing Then
			If total > 0 Then
				WaitingMessage1.Progress = 100 * (progress / total)
				WaitingMessage1.DisplayedText = "Reading line: " & progress & " out of " & total
			Else
				WaitingMessage1.DisplayedText = message
			End If
		Else
			If Not hideProgress Then ShowPercentProgress(message, progress, total)
		End If
	End Sub

	Public Shared Sub ShowPercentProgress(message As String, Optional currElementIndex As Integer = -1, Optional totalElementCount As Integer = -1, Optional showAsPercentage As Boolean = False, Optional progressLen As Integer = 40)
		If currElementIndex < 0 OrElse currElementIndex >= totalElementCount Then
			Console.WriteLine(message)
			Return
		End If
		Dim percent As Integer = (100 * (currElementIndex + 1)) \ totalElementCount
		Dim outStr As String = "<"
		For i As Integer = 0 To progressLen
			If (i * (100 / progressLen)) <= percent Then
				outStr &= "#"
			Else
				outStr &= "-"
			End If
		Next
		outStr &= ">"
		If showAsPercentage Then
			consoleWrite(String.Format(vbCr & "{0}{1}% " & outStr, message, percent.ToString().PadLeft(3)))
		Else
			consoleWrite(String.Format(vbCr & "{0} {1}/{2}" & outStr, message, currElementIndex.ToString().PadLeft(totalElementCount.ToString.Length), totalElementCount))
		End If

		If currElementIndex = totalElementCount - 1 Then
			consoleWrite(Environment.NewLine)
		End If
	End Sub

	Public Shared Sub consoleWrite(m As String)
		Console.Write(m)
	End Sub

	Public Shared Sub consoleWriteError(m As String)
		Console.Error.Write(m)
	End Sub

	Public Sub logerror(ex As Exception, Optional Message As String = "", Optional rownum As Integer = -1)
		If rownum = -1 Then rownum = currentline
		Dim errorMsg As String = ex.Message
		If showstackTrace Then errorMsg &= vbCrLf & "StackTrace:" & vbCrLf & ex.StackTrace
		If ex.InnerException IsNot Nothing Then
			errorMsg &= " Inner Exception: " & ex.InnerException.Message
			errorMsg &= vbCrLf & "StackTrace:" & vbCrLf & ex.InnerException.StackTrace
		End If

		errorList &= String.Format("{0}:{1} {2}", fileName, rownum, Message) & vbCrLf & errorMsg & vbCrLf
		If WaitingMessage1 Is Nothing Then
			consoleWriteError(String.Format("{0}:{1} {2}", fileName, rownum, Message) & vbCrLf & errorMsg + vbCrLf)
		End If
		RaiseEvent errorEvent(ex)
	End Sub

#End Region

#Region "Script Handler"

	Private assmHT As New Hashtable
	Private InstanceHT As New Hashtable
	Public Function runscriptfile(filename As String, args() As Object, Optional methodname As String = "ProcessRow.process") As Boolean
		If filename IsNot Nothing AndAlso filename.Length > 0 Then
			Dim Proc As CSScriptLibrary.MethodDelegate
			Try
				If Not assmHT.ContainsKey(filename) Then
					If filename.EndsWith(".vb") Then
						Dim folder As String = Assembly.GetExecutingAssembly().Location
						folder = folder.Substring(0, folder.LastIndexOf("\")) & "\CSSCodeProvider.dll"
						CSScriptLibrary.CSScript.GlobalSettings.UseAlternativeCompiler = folder
					End If
					Try
						Dim asm As Assembly = CSScriptLibrary.CSScript.Load(processRowScriptFile)
						assmHT(filename) = asm
						Dim instance = asm.CreateInstance(methodname.Split(".")(0))
						If (instance IsNot Nothing) Then _
							InstanceHT.Add(filename, instance)

					Catch ex As Exception
						assmHT(filename) = False
						logerror(ex, "Error compiling script file : " & filename)
					End Try
				End If
				If assmHT(filename).ToString() <> "False" Then
					Dim asm As Assembly = assmHT(filename)
					Proc = asm.GetStaticMethod(methodname, args)
					If Proc.Method.IsStatic Then
						Proc.Invoke(args)
					Else
						Proc = Nothing
					End If
					If Proc Is Nothing Then

						If (InstanceHT.Contains(filename)) Then
							Dim instance = InstanceHT(filename)
							Dim m As MethodInfo = instance.GetType().GetMethod(methodname.Split(".")(1))
							m.Invoke(instance, args)
						End If
					End If

				End If
			Catch ex As Exception
				'If ex.TargetSite Is Nothing OrElse Not ex.TargetSite.IsStatic Then
				'    logerror(New Exception("The method 'ProcessRow.process' must be declared static/shared."), "The proper format for the script file is: class ProcessRow " & vbCrLf & "public shared function process(row as DataRow, d as Object) as boolean" & vbCrLf & "...")
				'Else
				logerror(ex, "Error running compiled script: " & filename)
				'End If
			End Try
		End If
		Return True
	End Function

#End Region

	Private _sqlhelper As BaseClasses.BaseHelper
	Public ReadOnly Property sqlhelper As BaseClasses.BaseHelper
		Get
			If _sqlhelper Is Nothing Then
				_sqlhelper = BaseClasses.DataBase.createHelper(connection)
				_sqlhelper.createAdaptorsWithoutPrimaryKeys = True
			End If
			Return _sqlhelper
		End Get
	End Property


#Region "Parse File"

	Public Shared Function ParseDelimited(input As String, Optional delimiter As String = ",") As String()
		Dim parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(New IO.StringReader(input))
		parser.HasFieldsEnclosedInQuotes = True
		parser.SetDelimiters(delimiter)
		If Not parser.EndOfData Then
			Return parser.ReadFields()
		End If
		Return New String() {}

	End Function

	Public Function UploadTableFilename(tableName As String, fileName As String, Optional deleteExisting As Boolean = False, Optional uniqueIdentifierColumns As String = Nothing, Optional columnNames As String = Nothing, Optional createIfMissing As Boolean = True) As Boolean
		Me.tableName = tableName
		Me.fileName = fileName
		Me.deleteExisting = deleteExisting
		Me.uniqueIdentifierColumns = uniqueIdentifierColumns
		Me.columnNames = columnNames
		Me.createIfMissing = createIfMissing

		Return UploadTableFilename()
	End Function

	Public Function Import() As Boolean
		Return UploadTableFilename()
	End Function

	Public Function UploadTableFilename() As Boolean
		If WaitingMessage1 IsNot Nothing Then
			WaitingMessage1.waitFunction(AddressOf UploadTableFilenameWorker, "Importing Data", parentfrm)
		Else
			UploadTableFilenameWorker()
			RaiseEvent ProcessingComplete(Me, New EventArgs)
		End If
		Return True
	End Function

	Public Function UploadTableFilenameWorker() As Boolean
		Try
			updateStatus("Reading File: " & fileName)
			If fileFormat = Format.Auto Then
				fileFormat = Format.csv
				If fileName.ToLower.EndsWith("json") Then fileFormat = Format.json
				If Not String.IsNullOrWhiteSpace(regExCapture) Then fileFormat = Format.regex
			End If

			Dim inputTable As DataTable = Nothing
			Try
				inputTable = ConvertExcelToTable(fileName, excelWorksheetNumber)
				fileFormat = Format.excel
			Catch ex As Exception

			End Try


			If isFilenameURL Or File.Exists(fileName) Then _
			Return UploadTable(tableName, deleteExisting, uniqueIdentifierColumns, columnNames, createIfMissing, inputTable)
			Return False
		Catch ex As Exception
			logerror(ex, "An unexpected error occurred.")
		End Try

	End Function

	Private Function doDelete(tablename As String) As Integer
		deleteCount = sqlhelper.FetchSingleValue("select count(*) from " & tablename)
		sqlhelper.ExecuteNonQuery("delete from " & tablename)
		Return deleteCount
	End Function

	Enum Format
		Auto = 0
		csv = 1
		json = 2
		excel = 3
		regex = 4
	End Enum

	Dim parser As Microsoft.VisualBasic.FileIO.TextFieldParser
	Dim jsonList As New List(Of Hashtable)

	Private Function createParser(fileContents As String) As Microsoft.VisualBasic.FileIO.TextFieldParser
		fileContents = fileContents.Replace(vbCrLf, vbLf).Replace(vbCr, vbLf)
		Dim myparser As Microsoft.VisualBasic.FileIO.TextFieldParser
		myparser = New Microsoft.VisualBasic.FileIO.TextFieldParser(New IO.StringReader(fileContents))
		myparser.HasFieldsEnclosedInQuotes = True
		myparser.SetDelimiters(delimiter)
		Return myparser
	End Function


	Public Function simulateBatch() As DataTable
		simulate = True
		outputTable = New DataTable()
		UploadTableFilename()
		Return outputTable
	End Function

	Private Function UploadTable(tableName As String, Optional deleteExisting As Boolean = False, Optional uniqueIdentifierColumns As String = Nothing, Optional columnNames As String = Nothing, Optional createIfMissing As Boolean = True, Optional inputTable As DataTable = Nothing) As Boolean
		currentline = 0
		insertCount = 0
		updateCount = 0
		deleteCount = 0
		importStartedDate = Date.Now


		Dim max As Integer = 100
		Dim dt As DataTable

		If simulate AndAlso outputTable Is Nothing Then
			outputTable = New DataTable()
		End If
		If outputTable IsNot Nothing Then dt = outputTable
		If dt Is Nothing Then dt = New DataTable()
		Dim editCols As String()
		Dim uniqueCols As String() = Nothing
		Dim i As Integer = 0
		Dim fileContents As String = ""
		If inputTable Is Nothing Then
			If isFilenameURL Then
				fileContents = getURLContents(fileName)
			Else
				Using Str As New System.IO.StreamReader(fileName)
					fileContents = Str.ReadToEnd()
				End Using
			End If
		End If

		If inputTable IsNot Nothing Then
			If inputTable.Rows.Count = 0 Then
				Throw New Exception("File " & fileName & " was read and has no contents.")
			End If
			fileFormat = Format.excel
			runscriptfile(processInputScriptFile, New Object() {inputTable, Me}, "ProcessRow.inputFile")
		Else
			runscriptfile(processInputScriptFile, New Object() {fileContents, Me}, "ProcessRow.inputFile")
		End If

		'Create the parsers/ list the lines etc here
		If fileFormat = Format.csv Then

			parser = createParser(fileContents)
			If parser.EndOfData Then Return False
			max = fileContents.Split(vbLf).Length
		ElseIf fileFormat = Format.json Then
			jsonList = Json.JsonConvert.DeserializeObject(Of List(Of Hashtable))(fileContents)
			If jsonList.Count = 0 Then Return False
			max = jsonList.Count
		ElseIf fileFormat = Format.excel Then
			max = inputTable.Rows.Count
		ElseIf fileFormat = Format.regex Then
			If String.IsNullOrWhiteSpace(regExCapture) Then
				Throw New Exception("You must define a capture expression if the input type is Regual Expression")
			End If
			regexMatches = regexColumnCapture.Matches(fileContents)
			max = regexMatches.Count
		End If

		Try
			If deleteExisting And Not simulate Then
				doDelete(tableName)
			End If
		Catch ex As Exception

		End Try

		If columnNames IsNot Nothing AndAlso columnNames.Length > 0 Then
			editCols = ParseDelimited(columnNames)
		Else
			If fileFormat = Format.csv Then editCols = parser.ReadFields()
			If fileFormat = Format.json Then
				ReDim editCols(jsonList(0).Keys.Count)
				jsonList(0).Keys.CopyTo(editCols, 0)
			End If
			If fileFormat = Format.excel Then
				Dim colList As New List(Of String)
				For Each col As DataColumn In inputTable.Columns
					colList.Add(inputTable.Rows(0)(col).ToString())
				Next
				editCols = colList.ToArray()
			End If
			i = 1
			If fileFormat = Format.regex Then
				Dim tmpCols As New List(Of String)
				For Each groupname As String In regexColumnCapture.GetGroupNames()
					If groupname <> "0" Then tmpCols.Add(groupname)
				Next
				editCols = tmpCols.ToArray()
			End If
		End If

		If fileFormat = Format.excel Then
			inputTable.TableName = tableName
			Dim colindex As Integer = 0
			Dim remList As New List(Of String)
			For Each coname As String In editCols
				If inputTable.Columns.Count <= colindex Then
					logerror(New Exception("There is no colum number: " + colindex.ToString() + " in the source file. Not importing column: " + coname))
					remList.Add(coname)
				Else
					If coname <> "" Then inputTable.Columns(colindex).ColumnName = coname
				End If
				colindex += 1
			Next
			Dim colList As New List(Of String)
			For Each col As DataColumn In inputTable.Columns
				colList.Add(col.ColumnName)
			Next
			editCols = colList.ToArray()
			While inputTable.Columns.Count > colindex
				inputTable.Columns.RemoveAt(inputTable.Columns.Count - 1)
			End While
		End If

		'Loop through all of the fields in the file.  
		'If any lines are corrupt, report an error and continue parsing.  

		Try
			sqlhelper.FillDataTable("select top 1  * from " & tableName, dt)
		Catch ex As Exception
			If Not simulate Then
				If createIfMissing AndAlso fileFormat = Format.json Then createTableFromJsonString(fileContents, tableName)
				If createIfMissing AndAlso fileFormat = Format.csv Then createTableFromCSVCols(fileContents, editCols, tableName)
				If createIfMissing AndAlso fileFormat = Format.regex Then createTableFromRegexCols(fileContents, editCols, tableName)
				If createIfMissing AndAlso fileFormat = Format.excel Then createTableFromExcelInputTbl(inputTable, tableName)
				sqlhelper.FillDataTable("select top 1 * from " & tableName, dt)
			End If
		End Try

		If limitingQuery Is Nothing Then limitingQuery = ""
		limitingQuery = limitingQuery.Trim()
		If uniqueIdentifierColumns IsNot Nothing AndAlso uniqueIdentifierColumns.Trim().Length > 0 Then
			uniqueCols = ParseDelimited(uniqueIdentifierColumns)
			' TODO: Currently this fetches the entire table for de-duplication this should be done perBatch size and select just the unique cols
			If limitingQuery <> "" Then
				If Not limitingQuery.ToLower().StartsWith("where ") Then
					limitingQuery = " where " & limitingQuery
				End If
				sqlhelper.FillDataTable("select * from " & tableName & limitingQuery, dt)
			Else
				'sqlhelper.FillDataTable("select * from " & tableName, dt)
			End If

		End If
		Dim colLst As New List(Of String)
		For j As Integer = 0 To editCols.Length - 1
			If editCols(j) IsNot Nothing Then
				Dim origCol As String = editCols(j)
				editCols(j) = editCols(j).ToLower()
				If Not dt.Columns.Contains(editCols(j)) Then
					editCols(j) = stripColName(editCols(j))
				End If
				If dt.Columns.Contains(editCols(j)) Then
					colLst.Add(editCols(j))
				End If
				If fileFormat = Format.regex Then regexColtoGroup(editCols(j)) = origCol
			End If
		Next

		'editCols = colLst.ToArray
		Dim dv As New DataView(dt)
		Dim count As Integer = 0


		updateStatus("Import in progress")

		Dim da As System.Data.Common.DbDataAdapter
		da = sqlhelper.Adaptor(dt.TableName)
		da.ContinueUpdateOnError = True

		i = -1
		While (fileFormat = Format.csv AndAlso Not parser.EndOfData) _
			OrElse (fileFormat = Format.json AndAlso jsonList.Count > i + 1) _
			OrElse (fileFormat = Format.excel AndAlso inputTable.Rows.Count > i + 1) _
			OrElse (fileFormat = Format.regex AndAlso regexMatches.Count > i + 1)
			Try
				i += 1
				Dim ht As Hashtable = Nothing
				currentline = i
				If currentline >= skipRows Then
					If fileFormat = Format.csv Then
						currentline = parser.LineNumber
						rowVals = parser.ReadFields()
						If Not rowVals.Length = 0 Then
							ht = New Hashtable
							For j As Integer = 0 To editCols.Length - 1
								If rowVals.Length < j Then
									logerror(New Exception("Not enough value in row for all parms"), "The row did not have enough values for item:" & editCols(j), currentline)
								Else
									ht(editCols(j)) = rowVals(j)
								End If
							Next
						End If
					ElseIf fileFormat = Format.regex Then
						ht = New Hashtable
						For j As Integer = 0 To editCols.Length - 1
							ht(editCols(j)) = regexMatches(i).Groups(regexColtoGroup(editCols(j))).Value.Trim()
						Next
					ElseIf fileFormat = Format.json Then
						ht = jsonList(i)
					ElseIf fileFormat = Format.excel Then
						ht = New Hashtable
						For j As Integer = 0 To editCols.Length - 1
							If (inputTable.Columns.Contains(editCols(j))) Then
								ht(editCols(j)) = inputTable.Rows(i)(editCols(j))
							Else
								ht(editCols(j)) = DBNull.Value
							End If
						Next
					End If

					updateStatus("Reading record: ", currentline, max)
					If ht IsNot Nothing Then
						Dim newRow As DataRow = dt.NewRow
						If uniqueCols IsNot Nothing Then
							Dim queryStr As String = ""
							Dim sqlqueryStr As String = ""
							Dim sqlqueryParms As New List(Of Object)
							For Each col As String In uniqueCols
								col = col.ToLower
								'For j As Integer = 0 To editCols.Length - 1
								'    If col = editCols(j) Then
								If ht(col) IsNot Nothing Then
									Dim parm = parseRowVal(newRow, col, ht(col))
									If parm Is DBNull.Value OrElse parm Is Nothing Then
										queryStr &= String.Format("{0} is NULL  AND ", col)
										sqlqueryStr &= String.Format("{0} is NULL AND ", col)
									Else
										queryStr &= String.Format("{0} = '{1}' AND ", col, EscapeLikeValue(parm))
										sqlqueryStr &= String.Format("{0} = @{0} AND ", col)
										sqlqueryParms.Add(parm)
									End If
								End If
								'Exit For
								'    End If
								'Next
							Next
							If queryStr.Length > 0 Then
								queryStr = queryStr.Substring(0, queryStr.Length - 5)
								sqlqueryStr = sqlqueryStr.Substring(0, sqlqueryStr.Length - 5)
								If limitingQuery = "" Then
									sqlhelper.FillDataTable("select * from " & tableName & " where " & sqlqueryStr, dt, sqlqueryParms.ToArray())
								End If
							End If

							If queryStr.Length > 0 Then
								dv.RowFilter = queryStr
								If dv.Count > 0 Then
									newRow = dv(0).Row
								End If

							End If
						End If

						If newRow IsNot Nothing Then
							'newRow.BeginEdit()
							For j As Integer = 0 To editCols.Length - 1
								If (colLst.Contains(editCols(j))) Then
									setRowValue(newRow, editCols(j), ht(editCols(j)))
								End If
							Next
							If newRow.RowState = DataRowState.Detached Then
								Try
									dt.Rows.Add(newRow)
								Catch ex As Exception
									logerror(ex, "Error adding row to datatable:" & newRow.RowError)
								End Try
							End If
						End If
						runscriptfile(processRowScriptFile, New Object() {newRow, Me})
					End If
					' Include code here to handle the row. 
				Else
					If fileFormat = Format.csv Then parser.ReadFields()
				End If
			Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
				logerror(ex, "Malformed input file")
			End Try
			count += 1
			If count = batchsize Then
				Try
					updateCounts(dt)
					runscriptfile(processTableScript, New Object() {dt, Me}, "ProcessRow.inputTable")
					If simulate Then
						Return True
					Else
						da.Update(dt)
					End If
				Catch ex As Exception
					logerror(ex, "Error updating database")
				End Try
				count = 0
			End If
		End While

		updateCounts(dt)

		Try
			da.Update(dt)
		Catch ex As Exception
			logerror(ex, "Error updating database")
		End Try

		setStatusSummary()
		If simulate Then Return True
		Try
			If (completedSQL IsNot Nothing AndAlso completedSQL <> "") Then
				sqlhelper.ExecuteNonQuery(completedSQL)
			End If
		Catch ex As Exception
			logerror(ex, "Error executing compleatedSQL after import")
		End Try

		If dt.GetErrors().Length > 0 Then
			Dim errorRows = dt.GetErrors()
			statusList &= "Error Rows:  " & dt.GetErrors().Length & vbCrLf
			logerror(New Exception(dt.GetErrors()(0).RowError), "There are " & dt.GetErrors().Length & " Rows with errors durring the insert/update process.")
			For Each row In errorRows
				Dim colerrors = getColErrors(row)
				'For Each col In row.GetColumnsInError()
				'	colerrors &= col.ColumnName & " : " & row.GetColumnError(row.Table.Columns.IndexOf(col)) & vbCrLf
				'Next
				logerror(New Exception(colerrors), "Row number: " & dt.Rows.IndexOf(row) & " Has error: " & row.RowError, dt.Rows.IndexOf(row))
			Next


		End If

		Return True

	End Function

	Private Function setStatusSummary() As Boolean
		Try
			statusList &= "Table:         " & tableName & vbCrLf
			statusList &= "Updated Rows:  " & updateCount & vbCrLf
			statusList &= "Inserted Rows: " & insertCount & vbCrLf
			statusList &= "Deleted Rows:  " & deleteCount & vbCrLf
			Return True
		Catch ex As Exception
			Return False
		End Try
	End Function

	Private Function EscapeLikeValue(value As String) As String
		Dim sb As New System.Text.StringBuilder(value.Length)
		For i As Integer = 0 To value.Length - 1
			Dim c As Char = value(i)
			Select Case c
				Case "]"c, "["c, "%"c, "*"c
					sb.Append("[").Append(c).Append("]")
					Exit Select
				Case "'"c
					sb.Append("''")
					Exit Select
				Case Else
					sb.Append(c)
					Exit Select
			End Select
		Next
		Return sb.ToString()
	End Function


	Public Function getColErrors(dr As DataRow) As String
		Dim assembly__1 As Assembly = Assembly.LoadFrom("C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Data.dll")
		Dim type As Type = assembly__1.[GetType]("System.Data.ConstraintEnumerator")
		Dim out = ""
		For Each column As DataColumn In dr.Table.Columns
			Dim columnType As Type = column.[GetType]()
			Dim bfInternal As BindingFlags = BindingFlags.Instance Or BindingFlags.NonPublic

			Dim flag As Boolean = False
			If Not column.AllowDBNull Then
				Dim m_IsNotAllowDBNullViolated As MethodInfo = columnType.GetMethod("IsNotAllowDBNullViolated", bfInternal)
				flag = CBool(m_IsNotAllowDBNullViolated.Invoke(column, Nothing))
				If flag Then
					out &= "DBnull violated  --> ColumnName: " + column.ColumnName + ", tableName: " + column.Table.TableName
				End If
			End If
			If column.MaxLength >= 0 Then
				Dim m_IsMaxLengthViolated As MethodInfo = columnType.GetMethod("IsMaxLengthViolated", bfInternal)
				flag = CBool(m_IsMaxLengthViolated.Invoke(column, Nothing))
				If flag Then
					out &= "MaxLength violated --> ColumnName: " + column.ColumnName + ", tableName: " + column.Table.TableName
				End If
			End If
		Next
		Return out
	End Function

	Private Function updateCounts(dt As DataTable) As Boolean
		Dim dv As New DataView(dt)
		dv.RowStateFilter = DataViewRowState.Added
		insertCount += dv.Count
		If setCreatedDate AndAlso dt.Columns.Contains("datecreated") Then
			For Each rv In dv
				rv("datecreated") = importStartedDate
			Next
		End If
		dv.RowStateFilter = DataViewRowState.ModifiedCurrent
		updateCount += dv.Count
		If setCreatedDate AndAlso dt.Columns.Contains("dateupdated") Then
			For Each rv In dv
				rv("dateupdated") = importStartedDate
			Next
		End If
		dv.RowStateFilter = DataViewRowState.CurrentRows
		Return True

	End Function

	Private Shared Function hasColumnChanged(stringComparison As StringComparison, ignoreWhitespace As Boolean, row As DataRow, col As DataColumn) As Boolean
		Dim isEqual As Boolean = True
		If row(col, DataRowVersion.Original) IsNot DBNull.Value AndAlso row(col, DataRowVersion.Current) IsNot DBNull.Value Then
			If ignoreWhitespace Then
				isEqual = row(col, DataRowVersion.Original).ToString().Trim().Equals(row(col, DataRowVersion.Current).ToString().Trim(), stringComparison)
			Else
				isEqual = row(col, DataRowVersion.Original).ToString().Equals(row(col, DataRowVersion.Current).ToString(), stringComparison)
			End If
		Else
			isEqual = row(col, DataRowVersion.Original).Equals(row(col, DataRowVersion.Current))
		End If

		Return Not isEqual
	End Function

	Public Function stripColName(colname As String) As String
		colname = colname.ToLower
		colname = colname.Replace(" ", "_")
		colname = Regex.Replace(colname, "[^A-Za-z0-9_]+", "")
		Return colname
	End Function

	Public Function parseRowVal(row As DataRow, colname As String, value As Object) As Object
		If Not row.Table.Columns.Contains(colname) Then
			Throw New Exception("The destination table does not contain column: " & colname)
		End If
		Return parseTypeVal(row.Table.Columns(colname).DataType, value)
	End Function

	Public Function parseTypeVal(t As Type, value As Object) As Object
		Dim svalue = value.ToString.ToLower()
		If blankIsNull AndAlso svalue = "" Then Return DBNull.Value
		If value Is Nothing OrElse svalue = "null" Then
			Return DBNull.Value
		ElseIf value Is t Then
			Return value
		ElseIf t Is GetType(Boolean) Then
			If svalue = "false" Then Return False
			If svalue = "0" Then Return False
			If svalue = "1" Then Return True
			If svalue = "true" Then Return True
			Return Boolean.Parse(value)
		ElseIf t Is GetType(DateTime) Then
			Dim d As DateTime
			If DateTime.TryParse(value, d) Then
				Return d
			ElseIf DateTime.TryParseExact(value, dateFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, d) Then
				Return d
			Else
				If value.ToString().Trim() = "" Then Return DBNull.Value
				'Return DateTime.Parse(value.ToString())  'If there was a string that was not the correct date format return an error if it wasn't an empty string.
			End If
			'If DateTime.TryParseExact(value, New String() {"", ""}, CultureInfo.InvariantCulture, d) Then
			'    row(colname) = d
			'End If
		'ElseIf t Is GetType(Decimal) Then
		'	Return Decimal.Parse(value.ToString())
		'ElseIf t Is GetType(Integer) Then
		'	Return Integer.Parse(value.ToString())
		End If

		Dim parse = t.GetMethod("Parse", New Type() {GetType(String)})
		If parse IsNot Nothing Then
			Return parse.Invoke(Nothing, New Object() {value.ToString()})
		End If

		Dim Converter = TypeDescriptor.GetConverter(t)
		Return Converter.ConvertFrom(value.ToString())

	End Function

	Public Function setRowValue(row As DataRow, colname As String, value As Object) As Boolean
		Try
			Dim checkval As Boolean = False
			Dim initialVal As Object = Nothing
			If row.RowState = DataRowState.Unchanged Then
				checkval = True
				initialVal = row(colname)
			End If

			row(colname) = parseRowVal(row, colname, value)

			If checkval Then
				If row.RowState = DataRowState.Modified Then
					If initialVal IsNot DBNull.Value AndAlso row(colname) IsNot DBNull.Value AndAlso initialVal = row(colname) Then
						row.RejectChanges()
					ElseIf initialVal Is DBNull.Value AndAlso row(colname) Is DBNull.Value Then
						row.RejectChanges()
					End If
				End If
			End If
			Return True
		Catch ex As Exception
			If value Is Nothing Then value = "Null"
			logerror(ex, "Error setting column:" & colname & " Value:" & value.ToString())
		End Try
		Return False
	End Function

	Public Function createTableFromJsonString(jsonString As String, tablename As String) As Boolean
		Dim list As New List(Of Hashtable)
		Dim tempT As New DataTable

		Try
			sqlhelper.FillDataTable("select top 1 * from " & tablename, tempT)
		Catch ex As Exception
			Try
				updateStatus("Creating table: " & tablename)
				list = Json.JsonConvert.DeserializeObject(Of List(Of Hashtable))(jsonString)
				If list.Count > 0 Then
					Dim i As Integer = 0
					Dim ht As Hashtable

					Dim dt As New DataTable
					dt.TableName = tablename
					For Each key As String In list(0).Keys
						i = 0
						ht = list(i)
						Dim val As Object = ht(key)
						Dim len As Integer = 20
						While i < list.Count AndAlso val Is Nothing
							ht = list(i)
							val = ht(key)
							i += 1
						End While
						If TypeOf val Is Json.Linq.JArray OrElse TypeOf val Is Json.Linq.JObject Then
							val = val.ToString
						End If
						If val IsNot Nothing Then
							Dim dc As New DataColumn
							dc.ColumnName = key
							dc.DataType = val.GetType
							If TypeOf val Is String Then
								For Each ht In list
									If ht(key) IsNot Nothing AndAlso ht(key).ToString().Length > len Then
										len = ht(key).ToString.Length
									End If
								Next
								Try
									dc.MaxLength = len * 4
								Catch ex2 As Exception

								End Try

							End If
							dt.Columns.Add(dc)
						Else
							dt.Columns.Add(key)
						End If
					Next
					Dim prikeys() As String = uniqueIdentifierColumns.Split(",")
					Dim priCols(prikeys.Length - 1) As DataColumn
					For y As Integer = 0 To prikeys.Length - 1
						priCols(y) = dt.Columns(prikeys(y))
					Next
					dt.PrimaryKey = priCols
					sqlhelper.checkAndCreateTable(dt)
				End If
			Catch ex1 As Exception
				logerror(ex1)
			End Try
			Return True
		End Try
		Return False
	End Function

	Public Function createTableFromJsonFile(filename As String, Optional tablename As String = Nothing) As Boolean
		If filename.EndsWith(".json") Then
			filename = filename.ToLower
			If tablename Is Nothing Then
				tablename = filename.Substring(filename.LastIndexOf("\") + 1).Replace(".json", "")
			End If
			Return createTableFromJsonString(System.IO.File.ReadAllText(filename), tablename)
		End If
		Return False
	End Function

	Private Sub parseIntoTable(fileContents As String, editCols As String(), ByRef dt As DataTable, Optional parseAllData As Boolean = False)
		Dim parser = createParser(fileContents)
		Dim i = -1

		While Not parser.EndOfData
			i += 1
			If Not parseAllData AndAlso i > batchsize Then Return
			Dim ht As Hashtable = Nothing
			If i >= skipRows Then
				rowVals = parser.ReadFields()
				If Not rowVals.Length = 0 Then
					ht = New Hashtable
					For j As Integer = 0 To editCols.Length - 1
						If rowVals.Length > j Then
							ht(editCols(j)) = rowVals(j)
						End If
					Next
				End If

				If ht IsNot Nothing Then
					Dim newRow As DataRow = dt.NewRow

					If newRow IsNot Nothing Then
						'newRow.BeginEdit()
						For j As Integer = 0 To editCols.Length - 1
							setRowValue(newRow, editCols(j), ht(editCols(j)))
						Next
						If newRow.RowState = DataRowState.Detached Then
							Try
								dt.Rows.Add(newRow)
							Catch ex As Exception

							End Try
						End If
					End If
					runscriptfile(processRowScriptFile, New Object() {newRow, Me})
				End If
			Else
				' Include code here to handle the row. 
				parser.ReadFields()
			End If

		End While

	End Sub

	''' <summary>
	''' This function just converts the regex matches to a csv format and does the import from there. This is not efficient but is only used when a table is being created.
	''' </summary>
	''' <param name="fileContents"></param>
	''' <param name="editCols"></param>
	''' <param name="tablename"></param>
	''' <returns></returns>
	Public Function createTableFromRegexCols(fileContents As String, editCols As String(), tablename As String) As Boolean
		Dim outcontents As String = ""
		For Each col In editCols
			outcontents &= col & ","
		Next
		outcontents = outcontents.TrimEnd(CChar(",")) & vbCrLf

		For Each m In regexMatches
			Dim line As String = ""
			For Each g In editCols
				line &= m.Groups(g).Value.Trim() & ","
			Next
			outcontents &= line.TrimEnd(CChar(",")) & vbCrLf
		Next

		Return createTableFromCSVCols(outcontents, editCols, tablename)
	End Function

	Public Function createTableFromCSVCols(fileContents As String, editCols As String(), tablename As String) As Boolean
		Dim dt As New DataTable
		updateStatus("Creating table: " & tablename)
		For Each col As String In editCols
			dt.Columns.Add(col)
		Next
		Dim typelist As New List(Of Type)

		parseIntoTable(fileContents, editCols, dt)
		For Each col As DataColumn In dt.Columns
			Dim t = GetType(Boolean)
			Try
				For Each r As DataRow In dt.Rows
					parseTypeVal(t, r(col))
				Next
			Catch ex As Exception
				t = GetType(Int32)
				Try
					For Each r As DataRow In dt.Rows
						parseTypeVal(t, r(col))
					Next
				Catch ex1 As Exception
					t = GetType(Double)
					Try
						For Each r As DataRow In dt.Rows
							parseTypeVal(t, r(col))
						Next
					Catch ex2 As Exception
						Try
							t = GetType(DateTime)
							For Each r As DataRow In dt.Rows
								parseTypeVal(t, r(col))
							Next

						Catch ex3 As Exception
							t = GetType(String)
						End Try
					End Try

				End Try
			End Try
			typelist.Add(t)
		Next

		dt = New DataTable(tablename)

		Dim i As Integer = 0
		For Each col As String In editCols
			dt.Columns.Add(col, typelist(i))
			i += 1
		Next
		parseIntoTable(fileContents, editCols, dt, True)

		For Each col As DataColumn In dt.Columns
			If col.DataType Is GetType(String) Then
				Dim maxlen As Integer = -1
				For Each r As DataRow In dt.Rows
					If maxlen < r(col).ToString().Length Then maxlen = r(col).ToString().Length
				Next
				If maxlen > -1 Then maxlen = maxlen * 1.5
				col.MaxLength = maxlen
			End If
		Next
		CreateIDCol(dt)
		Return sqlhelper.checkAndCreateTable(dt)

	End Function

	Private Sub CreateIDCol(dt As DataTable)
		If dt.Columns("id") Is Nothing Then
			Dim col As DataColumn = dt.Columns.Add("ID", GetType(Int32))
			col.AutoIncrement = True
			col.AutoIncrementSeed = -1
			col.AutoIncrementStep = -1
			For Each r In dt.Rows
				r("ID") = dt.Rows.IndexOf(r)
			Next
			col.SetOrdinal(0)
			col.ReadOnly = True
			col.AllowDBNull = False
			dt.PrimaryKey = New DataColumn() {col}
		End If
	End Sub

	Public Function createTableFromExcelInputTbl(dt As DataTable, tablename As String) As Boolean
		updateStatus("Creating table: " & tablename)

		For Each col As DataColumn In dt.Columns
			If col.DataType Is GetType(String) Then
				Dim maxlen As Integer = -1
				For Each r As DataRow In dt.Rows
					If maxlen < r(col).ToString().Length Then maxlen = r(col).ToString().Length
				Next
				If maxlen > -1 Then maxlen = maxlen * 1.5
				col.MaxLength = maxlen
			End If
		Next
		CreateIDCol(dt)
		Return sqlhelper.checkAndCreateTable(dt)
	End Function
#End Region



	'Public Property geoCodeServiceURL As String = "http://nominatim.openstreetmap.org/search?format=jsonv2&polygon=0&addressdetails=0&q="
	'Public Property latRegex As String = "lat\""\s*\:\s*\""(?<lat>.*?)\"""
	'Public Property lonRegex As String = "lon\""\s*\:\s*\""(?<lon>.*?)\"""

	Public Property geoCodeServiceURL As String = "https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyBVi40EbEoia9CEJXuZyyMIQLngT6k14_k&sensor=true_or_false&address="
	'Public Property geoCodeServiceURL As String = "http://www.datasciencetoolkit.org/maps/api/geocode/json?sensor=false&address="
	'Public Property geoCodeServiceURL As String = "http://nominatim.openstreetmap.org/search?format=jsonv2&polygon=0&addressdetails=0&q="
	Public Property latRegex As String = "lat\""\s*\:\s*(?<lat>.*)"
	Public Property lonRegex As String = "lng\""\s*\:\s*(?<lon>.*)"

	Public Function getLatLon(address As String) As Double()
		Try
			Dim r As HttpWebRequest = CType(HttpWebRequest.Create((geoCodeServiceURL & address)), HttpWebRequest)

			r.Method = "GET"
			Dim res As WebResponse = r.GetResponse
			Dim InputText As String = New StreamReader(res.GetResponseStream()).ReadToEnd()
			Dim lat As Double = New Regex(latRegex).Matches(InputText)(0).Groups("lat").ToString().Replace(",", "").Trim()
			Dim lon As Double = New Regex(lonRegex).Matches(InputText)(0).Groups("lon").ToString().Replace(",", "").Trim()
			Return New Double() {lat, lon}
		Catch ex As Exception

		End Try
		Return Nothing

	End Function

	Private Sub InitializeComponent()
		Me.WaitingMessage1 = New WaitingDialog.WaitingMessage()
		'
		'WaitingMessage1
		'
		Me.WaitingMessage1.dialogueType = WaitingDialog.WaitDialogueType.WaitingDlg
		Me.WaitingMessage1.DisplayedText = "text"
		Me.WaitingMessage1.icon = Nothing
		Me.WaitingMessage1.Progress = 0
		Me.WaitingMessage1.TerminateThreadOnCancel = True
		Me.WaitingMessage1.topText = "Please wait...."

	End Sub

	Private Sub WaitingMessage1_ProcessCanceled(sender As Object, e As System.EventArgs) Handles WaitingMessage1.ProcessCanceled
		setStatusSummary()
		RaiseEvent ProcessingComplete(Me, e)
	End Sub

	Private Sub WaitingMessage1_ProcessFinishedSucessfully(sender As Object, e As System.EventArgs) Handles WaitingMessage1.ProcessFinishedSucessfully
		RaiseEvent ProcessingComplete(Me, e)
	End Sub

#Region "Read configs"


	Public Sub ParseJsonField(ByRef row As DataRow, fieldname As String)
		Dim dt As DataTable = row.Table
		If dt.Columns.Contains(fieldname) Then
			Dim r As Regex = New Regex("\""(?<name>.*?)\""\s*\:\s*\""(?<val>.*?)\""",
				RegexOptions.IgnoreCase _
				Or RegexOptions.Multiline _
				Or RegexOptions.CultureInvariant _
				Or RegexOptions.Compiled
				)
			For Each m As Match In r.Matches(row(fieldname).ToString())
				Dim colname As String = Regex.Replace(m.Groups("name").ToString(), "[^A-Za-z0-9]+", "")
				If dt.Columns.Contains(colname) Then
					setRowValue(row, colname, m.Groups("val").ToString())
				End If

			Next
		End If
	End Sub

	Public Function readConfigs(filename As String, Optional argv As String() = Nothing) As argResults
		If argv Is Nothing Then argv = New String() {}
		argv = parseConfigs(filename, argv)
		Return setfromArgs(argv)
	End Function

	Public Shared Function parseConfigs(filename As String, Optional argv As String() = Nothing) As String()
		If argv Is Nothing Then argv = New String() {}
		Dim contents As String = System.IO.File.ReadAllText(filename)
		contents = contents.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ").Replace("  ", " ")
		Dim parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(New IO.StringReader(contents))
		parser.HasFieldsEnclosedInQuotes = True
		parser.SetDelimiters(" ")
		Dim newArgs() As String = parser.ReadFields()
		Dim startLen As Integer = newArgs.Length
		If argv.Length > 1 Then
			ReDim Preserve newArgs(newArgs.Length + argv.Length - 1)
			argv.CopyTo(newArgs, startLen)
		End If

		Return newArgs

	End Function

	Public Function setfromArgs(argv As String()) As argResults
		Dim retval As argResults = argResults.normal
		For i As Integer = 0 To argv.Length - 1
			Dim arg As String = argv(i).ToLower()
			If arg.StartsWith("/") Then
				arg = arg.Trim("/")
				If arg = "?" Then
					writeHelp()
					retval = argResults.writeHelp
				ElseIf arg = "c" Then
					Me.connectionString = argv(i + 1)
				ElseIf arg = "ct" Then
					Me.connectionType = argv(i + 1)
				ElseIf arg = "f" Then
					Me.fileName = argv(i + 1)
				ElseIf arg = "t" Then
					Me.tableName = argv(i + 1)
				ElseIf arg = "p" Then
					Me.uniqueIdentifierColumns = argv(i + 1)
				ElseIf arg = "s" Then
					Me.processRowScriptFile = argv(i + 1)
				ElseIf arg = "st" Then
					Me.processTableScript = argv(i + 1)
				ElseIf arg = "si" Then
					Me.processInputScriptFile = argv(i + 1)
				ElseIf arg = "d" Then
					Me.deleteExisting = True
					If argv.Length > i AndAlso argv(i + 1) = "0" Then Me.deleteExisting = False
				ElseIf arg = "b" Then
					Me.batchsize = argv(i + 1)
				ElseIf arg = "n" Then
					Me.createIfMissing = True
					If argv.Length > i + 1 AndAlso argv(i + 1) = "0" Then Me.createIfMissing = False
				ElseIf arg = "q" Then
					Me.hideProgress = True
					If argv.Length > i + 1 AndAlso argv(i + 1) = "0" Then Me.hideProgress = False
				ElseIf arg = "dt" Then
					Me.setCreatedDate = True
					If argv.Length > i + 1 AndAlso argv(i + 1) = "0" Then Me.setCreatedDate = False
				ElseIf arg = "nullblank" Then
					Me.blankIsNull = True
					If argv.Length > i + 1 AndAlso argv(i + 1) = "0" Then Me.setCreatedDate = False
				ElseIf arg = "cols" Then
					Me.columnNames = argv(i + 1)
				ElseIf arg = "lim" Then
					Me.limitingQuery = argv(i + 1)
				ElseIf arg = "compsql" Then
					Me.completedSQL = argv(i + 1)
				ElseIf arg = "w" Then
					retval = argResults.asForm
				ElseIf arg = "delim" Then
					Dim delimChar As String = argv(i + 1)
					If delimChar.ToLower = "tab" Then delimChar = vbTab
					Me.delimiter = delimChar
				ElseIf arg = "regex" Then
					Me.regExCapture = argv(i + 1)
				ElseIf arg = "skip" Then
					Me.skipRows = argv(i + 1)
				ElseIf arg = "stack" Then
					Me.showstackTrace = True
					If argv.Length > i + 1 AndAlso argv(i + 1) = "0" Then Me.showstackTrace = False
				ElseIf arg = "dateform" Then
					Me.dateFormatList = argv(i + 1)
				ElseIf arg = "excelworksheet" Then
					Me.excelWorksheetNumber = argv(i + 1)
				ElseIf arg = "format" Then
					If argv.Length > i + 1 Then
						Dim format As String = argv(i + 1).ToLower()
						If format = "auto" Then Me.fileFormat = DataImporter.Format.Auto
						If format = "json" Then Me.fileFormat = DataImporter.Format.json
						If format = "csv" Then Me.fileFormat = DataImporter.Format.csv
						If format = "excel" Then Me.fileFormat = DataImporter.Format.excel
						If format = "regex" Then Me.fileFormat = DataImporter.Format.regex
					End If

				End If
			End If
		Next
		Return retval
	End Function

	Public Enum argResults
		normal
		asForm
		writeHelp
	End Enum

#End Region

#Region "Excel handelers"


	Public Shared Function ConvertExcelToTable(excelFilePath As String, Optional worksheetNumber As Integer = -1) As DataTable
		If Not File.Exists(excelFilePath) Then
			Throw New FileNotFoundException(excelFilePath)
		End If

		' connection string
		Dim cnnStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;IMEX=1;HDR=NO""", excelFilePath)
		If excelFilePath.ToLower().EndsWith("xlsx") Then
			cnnStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=NO""", excelFilePath)
		End If
		'Dim cnnStr = [String].Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", excelFilePath)
		Dim cnn = New OleDbConnection(cnnStr)

		' get schema, then data
		Dim dt = New DataTable()
		Try
			cnn.Open()
			Dim schemaTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
			If schemaTable.Rows.Count <= worksheetNumber Then
				Throw New ArgumentException("The worksheet number provided cannot be found in the spreadsheet")
			End If
			If worksheetNumber < 0 Then
				For i = 0 To schemaTable.Rows.Count
					Dim worksheet As String = schemaTable.Rows(worksheetNumber)("table_name").ToString().Replace("'", "")
					Dim sql As String = [String].Format("select * from [{0}]", worksheet)
					Dim da = New OleDbDataAdapter(sql, cnn)
					da.Fill(dt)
				Next
			Else
				Dim worksheet As String = schemaTable.Rows(worksheetNumber)("table_name").ToString().Replace("'", "")
				Dim sql As String = [String].Format("select * from [{0}]", worksheet)
				Dim da = New OleDbDataAdapter(sql, cnn)
				da.Fill(dt)
			End If
		Catch e As Exception
			' ???
			Throw e
		Finally
			' free resources
			cnn.Close()
		End Try
		Return dt
	End Function

#End Region

	Public Function testExcell() As Boolean
		Dim filename As String = "test.xls"
		System.IO.File.Create(filename)
		Dim cnnStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;IMEX=1;HDR=NO""", filename)
		'Dim cnnStr = [String].Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", excelFilePath)
		Dim cnn = New OleDbConnection(cnnStr)

		' get schema, then data
		Dim dt = New DataTable()
		Try
			cnn.Open()
		Catch e As Exception
			System.IO.File.Delete(filename)
			Return False
		End Try
		System.IO.File.Delete(filename)
		Return True

	End Function

	Private Function getURLContents(ByVal url As String) As String
		Dim options As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.Multiline Or RegexOptions.CultureInvariant Or RegexOptions.IgnorePatternWhitespace Or RegexOptions.Compiled

		Dim objwebclient As New System.Net.WebClient
		objwebclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
		Dim objUTF8 As New System.Text.UTF8Encoding
		Dim starttime As DateTime = Now
		If Not url.Contains("http://") AndAlso Not url.Contains("https://") Then
			url = "http://" & url
		End If
		updateStatus("Getting contents of url: " & url)

		Try
			Return objUTF8.GetString(objwebclient.DownloadData(url))
		Catch ex As Exception
			logerror(ex, "Error getting data from: " & url)
			Return ""
		End Try
	End Function


End Class

