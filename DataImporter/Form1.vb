Public Class Form1
	Public WithEvents di As New DataImporter

	Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
		If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
			tbFileName.Text = OpenFileDialog1.FileName
		End If
	End Sub

	Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
		If setupDI() Then
			di.UploadTableFilename()
		End If
	End Sub

	Private Function setupDI() As Boolean
		If Not System.IO.File.Exists(tbFileName.Text) Then
			MsgBox("You uneed to select a valid input file.")
			Return False
		End If
		di = Nothing
		di = New DataImporter()

		di.statusList = ""

		di.connectionString = tbConnection.Text
		di.fileName = tbFileName.Text
		di.tableName = tbTable.Text

		di.columnNames = tbColList.Text
		di.uniqueIdentifierColumns = tbPriKeys.Text
		di.delimiter = tbDelimiter.Text
		If tbDelimiter.Text = "TAB" Then
			di.delimiter = vbTab
		End If
		di.skipRows = tbSkipRows.Text
		di.deleteExisting = cbDeleteFirst.Checked
		di.createIfMissing = cbCreateTable.Checked

		di.setCreatedDate = cbDT.Checked
		di.limitingQuery = tbLimitingSQL.Text
		di.processRowScriptFile = tbProcessRow.Text
		di.processTableScript = tbProcessTable.Text
		di.processInputScriptFile = tbProcessInputFilescript.Text
		di.completedSQL = tbSQLCompleted.Text
		di.batchsize = tbBatchSize.Text
		di.regExCapture = tbRegex.Text
		di.dateFormatList = tbDateFormat.Text

		Dim format As String = ddFileType.Text.ToLower()
		If format = "auto" Then di.fileFormat = DataImporter.Format.Auto
		If format = "json" Then di.fileFormat = DataImporter.Format.json
		If format = "csv" Then di.fileFormat = DataImporter.Format.csv
		If format = "excel" Then di.fileFormat = DataImporter.Format.excel
		di.parentfrm = Me
		Return True
	End Function

	Private Sub di_ProcessingComplete(sender As Object, e As System.EventArgs) Handles di.ProcessingComplete
		If di.errorList.Length > 0 Then
			If di.errorList.Length < 1000 Then
				MsgBox(di.errorList)
			Else
				Dim filename As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
				filename &= "/Errors_" & Date.Now.Ticks & ".txt"
				System.IO.File.WriteAllText(filename, di.errorList)
				MsgBox("Errors written out to: " & filename)
			End If
		End If

		If di.simulate Then
			Dim dt As DataTable = di.outputTable
			dt.Columns.Add("Row State").SetOrdinal(0)
			dt.Columns.Add("Row Count").SetOrdinal(0)
			Dim i As Integer = 0
			For Each r As DataRow In dt.Rows
				r("Row Count") = i
				r("Row State") = r.RowState.ToString()
				i += 1
			Next
			Dim dataprev As New DataPreview()
			dataprev.dt = dt
			dataprev.ShowDialog()
		Else
			MsgBox(di.statusList)
		End If

	End Sub


	Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		lblRunInfo.Text = Module1.helpMsg().Trim()
		setvals(di)
	End Sub


	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
			tbProcessRow.Text = OpenFileDialog2.FileName
		End If
	End Sub


	Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
		If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
			Dim filename As String = SaveFileDialog1.FileName
			Dim output As String = ""
			output &= getConfigLine("C", tbConnection)
			output &= getConfigLine("F", tbFileName)
			output &= getConfigLine("T", tbTable)
			output &= getConfigLine("COLS", tbColList)
			output &= getConfigLine("P", tbPriKeys)
			output &= getConfigLine("DELIM", tbDelimiter)
			output &= getConfigLine("SKIP", tbSkipRows)
			If cbDeleteFirst.Checked Then output &= "/D" & vbCrLf
			If cbCreateTable.Checked Then output &= "/N" & vbCrLf
			If Not cbDT.Checked Then output &= "/DT 0" & vbCrLf

			output &= getConfigLine("LIM", tbLimitingSQL)
			output &= getConfigLine("S", tbProcessRow)
			output &= getConfigLine("ST", tbProcessTable)
			output &= getConfigLine("SI", tbProcessInputFilescript)
			output &= getConfigLine("COMPSQL", tbSQLCompleted)
			output &= getConfigLine("B", tbBatchSize)
			output &= getConfigLine("REGEX", tbRegex)
			output &= getConfigLine("DATEFORM", tbDateFormat)

			If ddFileType.Text.ToLower() <> "auto" Then
				output &= "/FORMAT " & ddFileType.Text & vbCrLf
			End If

			If cbQuietMode.Checked Then output &= "/Q" & vbCrLf
			If cbWindowMode.Checked Then output &= "/W" & vbCrLf

			System.IO.File.WriteAllText(filename, output)
			MsgBox("You can now call this export with:" & vbCrLf & " DataImporter.exe " & filename)
		End If
	End Sub

	Function getConfigLine(configVal As String, tb As TextBox) As String
		If tb.Text.Length > 0 AndAlso Not tb.Text = "0" Then
			Dim val As String = tb.Text
			If val = vbTab Then val = "TAB"
			Return "/" & configVal.Trim("/") & " """ & val & """" & vbCrLf
		End If
		Return ""
	End Function

	Public Sub setvals(di As DataImporter)

		tbConnection.Text = di.connectionString
		tbFileName.Text = di.fileName
		tbTable.Text = di.tableName

		tbColList.Text = di.columnNames
		tbPriKeys.Text = di.uniqueIdentifierColumns
		tbDelimiter.Text = di.delimiter
		If di.delimiter = vbTab Then tbDelimiter.Text = "TAB"
		tbSkipRows.Text = di.skipRows
		cbDeleteFirst.Checked = di.deleteExisting
		cbCreateTable.Checked = di.createIfMissing

		cbBlankNull.Checked = di.blankIsNull
		cbDT.Checked = di.setCreatedDate
		tbLimitingSQL.Text = di.limitingQuery
		tbProcessRow.Text = di.processRowScriptFile
		tbProcessTable.Text = di.processTableScript
		tbProcessInputFilescript.Text = di.processInputScriptFile
		tbSQLCompleted.Text = di.completedSQL
		tbBatchSize.Text = di.batchsize
		tbRegex.Text = di.regExCapture
		tbDateFormat.Text = di.dateFormatList

		ddFileType.Text = "Auto"
		If di.fileFormat = DataImporter.Format.json Then ddFileType.Text = "json"
		If di.fileFormat = DataImporter.Format.csv Then ddFileType.Text = "csv"
		If di.fileFormat = DataImporter.Format.excel Then ddFileType.Text = "excel"
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		If OpenFileDialogImportconfig.ShowDialog() = Windows.Forms.DialogResult.OK Then
			Dim filename As String = OpenFileDialogImportconfig.FileName
			Dim diNew As New DataImporter()
			'Dim args = readconfigs(filename)
			'setfromArgs(diNew, args)
			diNew.readConfigs(filename)
			setvals(diNew)
		End If

	End Sub

	Private Sub Button4_Click(sender As Object, e As EventArgs)
		Dim dt As New DataTable
		If OpenFileDialog3.ShowDialog() Then
			dt = DataImporter.ConvertExcelToTable(OpenFileDialog3.FileName)
		End If
		Dim x = 1
	End Sub

	Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
		If setupDI() Then
			di.simulateBatch()
		End If

	End Sub

End Class
