﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBetter
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBetter))
        Me.tbFileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbConnection = New System.Windows.Forms.TextBox()
        Me.tbTable = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbProcessRow = New System.Windows.Forms.TextBox()
        Me.tbPriKeys = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.WaitingMessage1 = New WaitingDialog.WaitingMessage()
        Me.tbBatchSize = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblRunInfo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbProcessTable = New System.Windows.Forms.TextBox()
        Me.tbDelimiter = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbColList = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbSkipRows = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbLimitingSQL = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbSQLCompleted = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cbDT = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbProcessInputFilescript = New System.Windows.Forms.TextBox()
        Me.cbQuietMode = New System.Windows.Forms.CheckBox()
        Me.cbWindowMode = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialogImportconfig = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.cbBlankNull = New System.Windows.Forms.CheckBox()
        Me.ddFileType = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tbRegex = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbDateFormat = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gbODBC = New System.Windows.Forms.GroupBox()
        Me.lblDefaultodbc = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.tbtestODBC = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tbODBCTable = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbODBCConnection = New System.Windows.Forms.TextBox()
        Me.gbExcel = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbWorkbookNum = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnTestExcel = New System.Windows.Forms.Button()
        Me.gbDelimiters = New System.Windows.Forms.GroupBox()
        Me.gbRegex = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ddConnectionType = New System.Windows.Forms.ComboBox()
        Me.cbDeleteFirst = New System.Windows.Forms.CheckBox()
        Me.cbCreateTable = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbScriptLang = New System.Windows.Forms.ComboBox()
        Me.cbScript = New System.Windows.Forms.ComboBox()
        Me.tbperRowValues = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.cbShowStack = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialogScriptSamp = New System.Windows.Forms.SaveFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbODBC.SuspendLayout()
        Me.gbExcel.SuspendLayout()
        Me.gbDelimiters.SuspendLayout()
        Me.gbRegex.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbFileName
        '
        Me.tbFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFileName.Location = New System.Drawing.Point(92, 19)
        Me.tbFileName.Name = "tbFileName"
        Me.tbFileName.Size = New System.Drawing.Size(489, 20)
        Me.tbFileName.TabIndex = 0
        Me.tbFileName.Text = "C:\Visual Studio Projects\CourtReminders\ScheduledTasks\importCases\calcases.txt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Input File:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(587, 19)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "CSV Files|*.csv|All files (*.*)|*.*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Connection String:"
        '
        'tbConnection
        '
        Me.tbConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbConnection.Location = New System.Drawing.Point(106, 16)
        Me.tbConnection.Name = "tbConnection"
        Me.tbConnection.Size = New System.Drawing.Size(538, 20)
        Me.tbConnection.TabIndex = 3
        Me.tbConnection.Text = "Data Source=vmdevsql03;Initial Catalog=CourtReminder;Integrated Security=True"
        '
        'tbTable
        '
        Me.tbTable.Location = New System.Drawing.Point(106, 64)
        Me.tbTable.Name = "tbTable"
        Me.tbTable.Size = New System.Drawing.Size(140, 20)
        Me.tbTable.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Destination Table:"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(7, 572)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(101, 38)
        Me.btnImport.TabIndex = 8
        Me.btnImport.Text = "Do Import!"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Per row script:"
        '
        'tbProcessRow
        '
        Me.tbProcessRow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbProcessRow.Location = New System.Drawing.Point(126, 41)
        Me.tbProcessRow.Name = "tbProcessRow"
        Me.tbProcessRow.Size = New System.Drawing.Size(324, 20)
        Me.tbProcessRow.TabIndex = 9
        '
        'tbPriKeys
        '
        Me.tbPriKeys.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPriKeys.Location = New System.Drawing.Point(106, 137)
        Me.tbPriKeys.Name = "tbPriKeys"
        Me.tbPriKeys.Size = New System.Drawing.Size(493, 20)
        Me.tbPriKeys.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Unique Col(s):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'WaitingMessage1
        '
        Me.WaitingMessage1.dialogueType = WaitingDialog.WaitDialogueType.WaitingDlg
        Me.WaitingMessage1.DisplayedText = "text"
        Me.WaitingMessage1.icon = Nothing
        Me.WaitingMessage1.Progress = 0
        Me.WaitingMessage1.TerminateThreadOnCancel = True
        Me.WaitingMessage1.topText = "Please wait...."
        '
        'tbBatchSize
        '
        Me.tbBatchSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbBatchSize.Location = New System.Drawing.Point(86, 492)
        Me.tbBatchSize.Name = "tbBatchSize"
        Me.tbBatchSize.Size = New System.Drawing.Size(50, 20)
        Me.tbBatchSize.TabIndex = 13
        Me.tbBatchSize.Text = "100"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 495)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Batch Size:"
        '
        'lblRunInfo
        '
        Me.lblRunInfo.AutoSize = True
        Me.lblRunInfo.Location = New System.Drawing.Point(3, 0)
        Me.lblRunInfo.Name = "lblRunInfo"
        Me.lblRunInfo.Size = New System.Drawing.Size(489, 312)
        Me.lblRunInfo.TabIndex = 15
        Me.lblRunInfo.Text = resources.GetString("lblRunInfo.Text")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Whole table script:"
        '
        'tbProcessTable
        '
        Me.tbProcessTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbProcessTable.Location = New System.Drawing.Point(126, 67)
        Me.tbProcessTable.Name = "tbProcessTable"
        Me.tbProcessTable.Size = New System.Drawing.Size(324, 20)
        Me.tbProcessTable.TabIndex = 16
        '
        'tbDelimiter
        '
        Me.tbDelimiter.Location = New System.Drawing.Point(6, 19)
        Me.tbDelimiter.Name = "tbDelimiter"
        Me.tbDelimiter.Size = New System.Drawing.Size(26, 20)
        Me.tbDelimiter.TabIndex = 18
        Me.tbDelimiter.Text = ","
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Columns:"
        '
        'tbColList
        '
        Me.tbColList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbColList.Location = New System.Drawing.Point(106, 109)
        Me.tbColList.Name = "tbColList"
        Me.tbColList.Size = New System.Drawing.Size(493, 20)
        Me.tbColList.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Skip First:"
        '
        'tbSkipRows
        '
        Me.tbSkipRows.Location = New System.Drawing.Point(92, 70)
        Me.tbSkipRows.Name = "tbSkipRows"
        Me.tbSkipRows.Size = New System.Drawing.Size(26, 20)
        Me.tbSkipRows.TabIndex = 22
        Me.tbSkipRows.Text = "1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(121, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Rows"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(466, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        Me.OpenFileDialog2.Filter = "VB Files|*.vb|CS Files|*.cs"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(667, 572)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 40)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Save Import config"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Config file|*.config|Text file|*.txt"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(38, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(135, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "(for tab character use TAB)"
        '
        'tbLimitingSQL
        '
        Me.tbLimitingSQL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLimitingSQL.Location = New System.Drawing.Point(163, 135)
        Me.tbLimitingSQL.Multiline = True
        Me.tbLimitingSQL.Name = "tbLimitingSQL"
        Me.tbLimitingSQL.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.tbLimitingSQL.Size = New System.Drawing.Size(365, 126)
        Me.tbLimitingSQL.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 135)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 39)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Limiting SQL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  ex: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  recdate > getDate()" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 303)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 26)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "SQL statements executed " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "after the import is complete"
        '
        'tbSQLCompleted
        '
        Me.tbSQLCompleted.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSQLCompleted.Location = New System.Drawing.Point(164, 303)
        Me.tbSQLCompleted.Multiline = True
        Me.tbSQLCompleted.Name = "tbSQLCompleted"
        Me.tbSQLCompleted.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.tbSQLCompleted.Size = New System.Drawing.Size(364, 130)
        Me.tbSQLCompleted.TabIndex = 31
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(531, 572)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 40)
        Me.Button3.TabIndex = 33
        Me.Button3.Text = "Load a config"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cbDT
        '
        Me.cbDT.AutoSize = True
        Me.cbDT.Checked = True
        Me.cbDT.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbDT.Location = New System.Drawing.Point(12, 227)
        Me.cbDT.Name = "cbDT"
        Me.cbDT.Size = New System.Drawing.Size(235, 17)
        Me.cbDT.TabIndex = 34
        Me.cbDT.Text = "Automaticaly set DateUpdated/DateCreated"
        Me.cbDT.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Process Input script:"
        '
        'tbProcessInputFilescript
        '
        Me.tbProcessInputFilescript.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbProcessInputFilescript.Location = New System.Drawing.Point(126, 92)
        Me.tbProcessInputFilescript.Name = "tbProcessInputFilescript"
        Me.tbProcessInputFilescript.Size = New System.Drawing.Size(324, 20)
        Me.tbProcessInputFilescript.TabIndex = 35
        '
        'cbQuietMode
        '
        Me.cbQuietMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbQuietMode.AutoSize = True
        Me.cbQuietMode.Location = New System.Drawing.Point(114, 585)
        Me.cbQuietMode.Name = "cbQuietMode"
        Me.cbQuietMode.Size = New System.Drawing.Size(296, 17)
        Me.cbQuietMode.TabIndex = 37
        Me.cbQuietMode.Text = "Quiet mode (command line only, suppresses progress bar)"
        Me.cbQuietMode.UseVisualStyleBackColor = True
        '
        'cbWindowMode
        '
        Me.cbWindowMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbWindowMode.AutoSize = True
        Me.cbWindowMode.Location = New System.Drawing.Point(114, 569)
        Me.cbWindowMode.Name = "cbWindowMode"
        Me.cbWindowMode.Size = New System.Drawing.Size(183, 17)
        Me.cbWindowMode.TabIndex = 38
        Me.cbWindowMode.Text = "Window mode (shows this dialog)"
        Me.cbWindowMode.UseVisualStyleBackColor = True
        '
        'OpenFileDialogImportconfig
        '
        Me.OpenFileDialogImportconfig.Filter = "config Files|*.config|Text Files|*.txt|All Files|*.*"
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.FileName = "OpenFileDialog1"
        Me.OpenFileDialog3.Filter = "CSV Files|*.csv|All files (*.*)|*.*"
        '
        'cbBlankNull
        '
        Me.cbBlankNull.AutoSize = True
        Me.cbBlankNull.Checked = True
        Me.cbBlankNull.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBlankNull.Location = New System.Drawing.Point(12, 210)
        Me.cbBlankNull.Name = "cbBlankNull"
        Me.cbBlankNull.Size = New System.Drawing.Size(159, 17)
        Me.cbBlankNull.TabIndex = 39
        Me.cbBlankNull.Text = "Set Blank fields equal to null"
        Me.cbBlankNull.UseVisualStyleBackColor = True
        '
        'ddFileType
        '
        Me.ddFileType.FormattingEnabled = True
        Me.ddFileType.Items.AddRange(New Object() {"Auto", "csv", "excel", "odbc", "json", "regex"})
        Me.ddFileType.Location = New System.Drawing.Point(92, 45)
        Me.ddFileType.Name = "ddFileType"
        Me.ddFileType.Size = New System.Drawing.Size(121, 21)
        Me.ddFileType.TabIndex = 40
        Me.ddFileType.Text = "Auto"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 13)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Input File Type:"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(420, 572)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(105, 40)
        Me.Button4.TabIndex = 42
        Me.Button4.Text = "Preview Data"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'tbRegex
        '
        Me.tbRegex.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbRegex.Location = New System.Drawing.Point(6, 19)
        Me.tbRegex.Multiline = True
        Me.tbRegex.Name = "tbRegex"
        Me.tbRegex.Size = New System.Drawing.Size(723, 72)
        Me.tbRegex.TabIndex = 43
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 274)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 13)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "Custom Date Format:"
        '
        'tbDateFormat
        '
        Me.tbDateFormat.Location = New System.Drawing.Point(122, 271)
        Me.tbDateFormat.Name = "tbDateFormat"
        Me.tbDateFormat.Size = New System.Drawing.Size(152, 20)
        Me.tbDateFormat.TabIndex = 45
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(7, 9)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(790, 557)
        Me.TabControl1.TabIndex = 47
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbODBC)
        Me.TabPage1.Controls.Add(Me.gbExcel)
        Me.TabPage1.Controls.Add(Me.gbDelimiters)
        Me.TabPage1.Controls.Add(Me.gbRegex)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.tbFileName)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btnBrowse)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.ddFileType)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.tbBatchSize)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.tbSkipRows)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(782, 531)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Source"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gbODBC
        '
        Me.gbODBC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbODBC.Controls.Add(Me.lblDefaultodbc)
        Me.gbODBC.Controls.Add(Me.Label30)
        Me.gbODBC.Controls.Add(Me.tbtestODBC)
        Me.gbODBC.Controls.Add(Me.Label29)
        Me.gbODBC.Controls.Add(Me.Label28)
        Me.gbODBC.Controls.Add(Me.tbODBCTable)
        Me.gbODBC.Controls.Add(Me.Label27)
        Me.gbODBC.Controls.Add(Me.tbODBCConnection)
        Me.gbODBC.Location = New System.Drawing.Point(9, 220)
        Me.gbODBC.Name = "gbODBC"
        Me.gbODBC.Size = New System.Drawing.Size(751, 99)
        Me.gbODBC.TabIndex = 53
        Me.gbODBC.TabStop = False
        Me.gbODBC.Text = "ODBC Options"
        '
        'lblDefaultodbc
        '
        Me.lblDefaultodbc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDefaultodbc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDefaultodbc.Location = New System.Drawing.Point(104, 35)
        Me.lblDefaultodbc.Name = "lblDefaultodbc"
        Me.lblDefaultodbc.ReadOnly = True
        Me.lblDefaultodbc.Size = New System.Drawing.Size(538, 13)
        Me.lblDefaultodbc.TabIndex = 53
        Me.lblDefaultodbc.TabStop = False
        Me.lblDefaultodbc.Text = "def"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label30.Location = New System.Drawing.Point(6, 71)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(88, 13)
        Me.Label30.TabIndex = 52
        Me.Label30.Text = "Select Statement"
        '
        'tbtestODBC
        '
        Me.tbtestODBC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbtestODBC.Location = New System.Drawing.Point(605, 70)
        Me.tbtestODBC.Name = "tbtestODBC"
        Me.tbtestODBC.Size = New System.Drawing.Size(140, 23)
        Me.tbtestODBC.TabIndex = 50
        Me.tbtestODBC.Text = "Test ODBC Connection"
        Me.tbtestODBC.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label29.Location = New System.Drawing.Point(466, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(48, 13)
        Me.Label29.TabIndex = 50
        Me.Label29.Text = "*optional"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label28.Location = New System.Drawing.Point(6, 54)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(77, 13)
        Me.Label28.TabIndex = 49
        Me.Label28.Text = "Table Name or"
        '
        'tbODBCTable
        '
        Me.tbODBCTable.AcceptsReturn = True
        Me.tbODBCTable.AcceptsTab = True
        Me.tbODBCTable.AllowDrop = True
        Me.tbODBCTable.Location = New System.Drawing.Point(103, 51)
        Me.tbODBCTable.Multiline = True
        Me.tbODBCTable.Name = "tbODBCTable"
        Me.tbODBCTable.Size = New System.Drawing.Size(400, 42)
        Me.tbODBCTable.TabIndex = 48
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label27.Location = New System.Drawing.Point(6, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(91, 13)
        Me.Label27.TabIndex = 47
        Me.Label27.Text = "Connection String"
        '
        'tbODBCConnection
        '
        Me.tbODBCConnection.Location = New System.Drawing.Point(103, 13)
        Me.tbODBCConnection.Name = "tbODBCConnection"
        Me.tbODBCConnection.Size = New System.Drawing.Size(357, 20)
        Me.tbODBCConnection.TabIndex = 46
        '
        'gbExcel
        '
        Me.gbExcel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbExcel.Controls.Add(Me.Label21)
        Me.gbExcel.Controls.Add(Me.tbWorkbookNum)
        Me.gbExcel.Controls.Add(Me.Label22)
        Me.gbExcel.Controls.Add(Me.btnTestExcel)
        Me.gbExcel.Location = New System.Drawing.Point(9, 149)
        Me.gbExcel.Name = "gbExcel"
        Me.gbExcel.Size = New System.Drawing.Size(751, 65)
        Me.gbExcel.TabIndex = 52
        Me.gbExcel.TabStop = False
        Me.gbExcel.Text = "Excel Options"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label21.Location = New System.Drawing.Point(6, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(80, 13)
        Me.Label21.TabIndex = 47
        Me.Label21.Text = "Workbook num"
        '
        'tbWorkbookNum
        '
        Me.tbWorkbookNum.Location = New System.Drawing.Point(9, 32)
        Me.tbWorkbookNum.Name = "tbWorkbookNum"
        Me.tbWorkbookNum.Size = New System.Drawing.Size(26, 20)
        Me.tbWorkbookNum.TabIndex = 46
        Me.tbWorkbookNum.Text = "-1"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(41, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(133, 13)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "(-1 to import all workbooks)"
        '
        'btnTestExcel
        '
        Me.btnTestExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTestExcel.Location = New System.Drawing.Point(627, 35)
        Me.btnTestExcel.Name = "btnTestExcel"
        Me.btnTestExcel.Size = New System.Drawing.Size(118, 23)
        Me.btnTestExcel.TabIndex = 49
        Me.btnTestExcel.Text = "Test Excel Drivers"
        Me.btnTestExcel.UseVisualStyleBackColor = True
        '
        'gbDelimiters
        '
        Me.gbDelimiters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDelimiters.Controls.Add(Me.tbDelimiter)
        Me.gbDelimiters.Controls.Add(Me.Label12)
        Me.gbDelimiters.Location = New System.Drawing.Point(9, 96)
        Me.gbDelimiters.Name = "gbDelimiters"
        Me.gbDelimiters.Size = New System.Drawing.Size(751, 49)
        Me.gbDelimiters.TabIndex = 51
        Me.gbDelimiters.TabStop = False
        Me.gbDelimiters.Text = "Delimiters"
        '
        'gbRegex
        '
        Me.gbRegex.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRegex.Controls.Add(Me.Label17)
        Me.gbRegex.Controls.Add(Me.tbRegex)
        Me.gbRegex.Location = New System.Drawing.Point(9, 325)
        Me.gbRegex.Name = "gbRegex"
        Me.gbRegex.Size = New System.Drawing.Size(751, 146)
        Me.gbRegex.TabIndex = 50
        Me.gbRegex.TabStop = False
        Me.gbRegex.Text = "Regular Expression"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label17.Location = New System.Drawing.Point(6, 94)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(475, 39)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Ex (named capture is the input Column Name): " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\s(?<IDNumber>\d\d\w\w\s\d\d\d\d" &
    "\d\d)\s\s(?<name>.{26})(?<citation>.{7})\s\s\s(?<Date>.{6})"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(142, 495)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(190, 13)
        Me.Label20.TabIndex = 45
        Me.Label20.Text = "Number of rows are processed at once"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.ddConnectionType)
        Me.TabPage2.Controls.Add(Me.cbDeleteFirst)
        Me.TabPage2.Controls.Add(Me.cbCreateTable)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.tbColList)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.cbBlankNull)
        Me.TabPage2.Controls.Add(Me.tbConnection)
        Me.TabPage2.Controls.Add(Me.tbDateFormat)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.tbTable)
        Me.TabPage2.Controls.Add(Me.cbDT)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.tbPriKeys)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(782, 531)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Destination"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(632, 125)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 13)
        Me.Label24.TabIndex = 54
        Me.Label24.Text = "Comma Delimited Lists"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(47, 160)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(313, 13)
        Me.Label23.TabIndex = 53
        Me.Label23.Text = "Unique Identifiers indicate which rows will be updated vs inserted"
        '
        'ddConnectionType
        '
        Me.ddConnectionType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ddConnectionType.FormattingEnabled = True
        Me.ddConnectionType.Items.AddRange(New Object() {"SQL", "SQLite", "MySql", "Oracle"})
        Me.ddConnectionType.Location = New System.Drawing.Point(659, 16)
        Me.ddConnectionType.Name = "ddConnectionType"
        Me.ddConnectionType.Size = New System.Drawing.Size(85, 21)
        Me.ddConnectionType.TabIndex = 52
        Me.ddConnectionType.Text = "SQL"
        '
        'cbDeleteFirst
        '
        Me.cbDeleteFirst.AutoSize = True
        Me.cbDeleteFirst.Location = New System.Drawing.Point(16, 360)
        Me.cbDeleteFirst.Name = "cbDeleteFirst"
        Me.cbDeleteFirst.Size = New System.Drawing.Size(80, 17)
        Me.cbDeleteFirst.TabIndex = 50
        Me.cbDeleteFirst.Text = "Clear Table"
        Me.cbDeleteFirst.UseVisualStyleBackColor = True
        '
        'cbCreateTable
        '
        Me.cbCreateTable.AutoSize = True
        Me.cbCreateTable.Location = New System.Drawing.Point(16, 340)
        Me.cbCreateTable.Name = "cbCreateTable"
        Me.cbCreateTable.Size = New System.Drawing.Size(132, 17)
        Me.cbCreateTable.TabIndex = 51
        Me.cbCreateTable.Text = "Create Table if missing"
        Me.cbCreateTable.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(106, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(538, 13)
        Me.TextBox1.TabIndex = 49
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Data Source=SERVER;Initial Catalog=DATABASE;Integrated Security=True"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(47, 42)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 13)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "Example:    "
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label32)
        Me.TabPage3.Controls.Add(Me.Label31)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.tbperRowValues)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Button7)
        Me.TabPage3.Controls.Add(Me.Button6)
        Me.TabPage3.Controls.Add(Me.Button5)
        Me.TabPage3.Controls.Add(Me.tbSQLCompleted)
        Me.TabPage3.Controls.Add(Me.tbProcessRow)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.tbProcessTable)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.tbProcessInputFilescript)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.tbLimitingSQL)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(782, 531)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Scripts"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(13, 367)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(112, 39)
        Me.Label32.TabIndex = 48
        Me.Label32.Text = "Also run on the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DESTINATION after" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the import is complete."
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(15, 197)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(122, 52)
        Me.Label31.TabIndex = 47
        Me.Label31.Text = "This script is run on the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DESTINATION to limit " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the amount of checking " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for l" &
    "arge data moves."
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.cbScriptLang)
        Me.GroupBox1.Controls.Add(Me.cbScript)
        Me.GroupBox1.Location = New System.Drawing.Point(549, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 137)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generate Samples"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 54)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 13)
        Me.Label26.TabIndex = 48
        Me.Label26.Text = "Script Lang:"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(75, 93)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(92, 24)
        Me.Button8.TabIndex = 42
        Me.Button8.Text = "Generate Stub"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 27)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 47
        Me.Label25.Text = "Script Type:"
        '
        'cbScriptLang
        '
        Me.cbScriptLang.FormattingEnabled = True
        Me.cbScriptLang.Items.AddRange(New Object() {"C#", "VB"})
        Me.cbScriptLang.Location = New System.Drawing.Point(76, 54)
        Me.cbScriptLang.Name = "cbScriptLang"
        Me.cbScriptLang.Size = New System.Drawing.Size(121, 21)
        Me.cbScriptLang.TabIndex = 44
        Me.cbScriptLang.Text = "C#"
        '
        'cbScript
        '
        Me.cbScript.FormattingEnabled = True
        Me.cbScript.Items.AddRange(New Object() {"Per Row Value (pre-insert)", "Per Row", "Whole Table", "Entire Input"})
        Me.cbScript.Location = New System.Drawing.Point(76, 24)
        Me.cbScript.Name = "cbScript"
        Me.cbScript.Size = New System.Drawing.Size(121, 21)
        Me.cbScript.TabIndex = 45
        Me.cbScript.Text = "Per Row Value (pre-insert)"
        '
        'tbperRowValues
        '
        Me.tbperRowValues.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbperRowValues.Location = New System.Drawing.Point(126, 15)
        Me.tbperRowValues.Name = "tbperRowValues"
        Me.tbperRowValues.Size = New System.Drawing.Size(324, 20)
        Me.tbperRowValues.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Per row Values script:"
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Location = New System.Drawing.Point(466, 13)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 41
        Me.Button7.Text = "Browse"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(466, 65)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 38
        Me.Button6.Text = "Browse"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(466, 91)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 37
        Me.Button5.Text = "Browse"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.AutoScroll = True
        Me.TabPage4.Controls.Add(Me.lblRunInfo)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(782, 531)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Help"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'cbShowStack
        '
        Me.cbShowStack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbShowStack.AutoSize = True
        Me.cbShowStack.Location = New System.Drawing.Point(114, 600)
        Me.cbShowStack.Name = "cbShowStack"
        Me.cbShowStack.Size = New System.Drawing.Size(148, 17)
        Me.cbShowStack.TabIndex = 48
        Me.cbShowStack.Text = "Show Stacktrace in errors"
        Me.cbShowStack.UseVisualStyleBackColor = True
        '
        'FormBetter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 621)
        Me.Controls.Add(Me.cbShowStack)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cbWindowMode)
        Me.Controls.Add(Me.cbQuietMode)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnImport)
        Me.Name = "FormBetter"
        Me.Text = "Data Importer"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbODBC.ResumeLayout(False)
        Me.gbODBC.PerformLayout()
        Me.gbExcel.ResumeLayout(False)
        Me.gbExcel.PerformLayout()
        Me.gbDelimiters.ResumeLayout(False)
        Me.gbDelimiters.PerformLayout()
        Me.gbRegex.ResumeLayout(False)
        Me.gbRegex.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbFileName As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents btnBrowse As System.Windows.Forms.Button
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents tbConnection As System.Windows.Forms.TextBox
	Friend WithEvents tbTable As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents btnImport As System.Windows.Forms.Button
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents tbProcessRow As System.Windows.Forms.TextBox
	Friend WithEvents tbPriKeys As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents WaitingMessage1 As WaitingDialog.WaitingMessage
	Friend WithEvents tbBatchSize As System.Windows.Forms.TextBox
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents lblRunInfo As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents tbProcessTable As System.Windows.Forms.TextBox
	Friend WithEvents tbDelimiter As System.Windows.Forms.TextBox
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents tbColList As System.Windows.Forms.TextBox
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents tbSkipRows As System.Windows.Forms.TextBox
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents tbLimitingSQL As System.Windows.Forms.TextBox
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents Label14 As Label
	Friend WithEvents tbSQLCompleted As TextBox
	Friend WithEvents Button3 As Button
	Friend WithEvents cbDT As CheckBox
	Friend WithEvents Label15 As Label
	Friend WithEvents tbProcessInputFilescript As TextBox
	Friend WithEvents cbQuietMode As CheckBox
	Friend WithEvents cbWindowMode As CheckBox
	Friend WithEvents OpenFileDialogImportconfig As OpenFileDialog
	Friend WithEvents OpenFileDialog3 As OpenFileDialog
	Friend WithEvents cbBlankNull As CheckBox
	Friend WithEvents ddFileType As ComboBox
	Friend WithEvents Label16 As Label
	Friend WithEvents Button4 As Button
	Friend WithEvents tbRegex As TextBox
	Friend WithEvents Label18 As Label
	Friend WithEvents tbDateFormat As TextBox
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents TabPage2 As TabPage
	Friend WithEvents TabPage3 As TabPage
	Friend WithEvents Button6 As Button
	Friend WithEvents Button5 As Button
	Friend WithEvents TabPage4 As TabPage
	Friend WithEvents Label19 As Label
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents cbDeleteFirst As CheckBox
	Friend WithEvents cbCreateTable As CheckBox
	Friend WithEvents Label20 As Label
	Friend WithEvents Label21 As Label
	Friend WithEvents tbWorkbookNum As TextBox
	Friend WithEvents Label22 As Label
	Friend WithEvents ddConnectionType As ComboBox
	Friend WithEvents btnTestExcel As Button
	Friend WithEvents Label24 As Label
	Friend WithEvents Label23 As Label
	Friend WithEvents gbRegex As GroupBox
	Friend WithEvents Label17 As Label
	Friend WithEvents gbDelimiters As GroupBox
	Friend WithEvents gbExcel As GroupBox
	Friend WithEvents cbShowStack As CheckBox
    Friend WithEvents tbperRowValues As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents cbScriptLang As ComboBox
    Friend WithEvents cbScript As ComboBox
    Friend WithEvents SaveFileDialogScriptSamp As SaveFileDialog
    Friend WithEvents gbODBC As GroupBox
    Friend WithEvents Label28 As Label
    Friend WithEvents tbODBCTable As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents tbODBCConnection As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents tbtestODBC As Button
    Friend WithEvents lblDefaultodbc As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
End Class
