<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.tbFileName = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnBrowse = New System.Windows.Forms.Button()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.tbConnection = New System.Windows.Forms.TextBox()
		Me.tbTable = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cbDeleteFirst = New System.Windows.Forms.CheckBox()
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
		Me.Label8 = New System.Windows.Forms.Label()
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
		Me.cbCreateTable = New System.Windows.Forms.CheckBox()
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
		Me.Label17 = New System.Windows.Forms.Label()
		Me.tbRegex = New System.Windows.Forms.TextBox()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.tbDateFormat = New System.Windows.Forms.TextBox()
		Me.SuspendLayout()
		'
		'tbFileName
		'
		Me.tbFileName.Location = New System.Drawing.Point(82, 4)
		Me.tbFileName.Name = "tbFileName"
		Me.tbFileName.Size = New System.Drawing.Size(195, 20)
		Me.tbFileName.TabIndex = 0
		Me.tbFileName.Text = "C:\Visual Studio Projects\CourtReminders\ScheduledTasks\importCases\calcases.txt"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(53, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Input File:"
		'
		'btnBrowse
		'
		Me.btnBrowse.Location = New System.Drawing.Point(283, 2)
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
		Me.Label2.Location = New System.Drawing.Point(12, 72)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(64, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Connection:"
		'
		'tbConnection
		'
		Me.tbConnection.Location = New System.Drawing.Point(82, 69)
		Me.tbConnection.Name = "tbConnection"
		Me.tbConnection.Size = New System.Drawing.Size(462, 20)
		Me.tbConnection.TabIndex = 3
		Me.tbConnection.Text = "Data Source=vmdevsql03;Initial Catalog=CourtReminder;Integrated Security=True"
		'
		'tbTable
		'
		Me.tbTable.Location = New System.Drawing.Point(82, 48)
		Me.tbTable.Name = "tbTable"
		Me.tbTable.Size = New System.Drawing.Size(140, 20)
		Me.tbTable.TabIndex = 5
		Me.tbTable.Text = "CourtAppearancesInput"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(13, 51)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(37, 13)
		Me.Label3.TabIndex = 6
		Me.Label3.Text = "Table:"
		'
		'cbDeleteFirst
		'
		Me.cbDeleteFirst.AutoSize = True
		Me.cbDeleteFirst.Location = New System.Drawing.Point(498, 45)
		Me.cbDeleteFirst.Name = "cbDeleteFirst"
		Me.cbDeleteFirst.Size = New System.Drawing.Size(80, 17)
		Me.cbDeleteFirst.TabIndex = 7
		Me.cbDeleteFirst.Text = "Clear Table"
		Me.cbDeleteFirst.UseVisualStyleBackColor = True
		'
		'btnImport
		'
		Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.btnImport.Location = New System.Drawing.Point(7, 514)
		Me.btnImport.Name = "btnImport"
		Me.btnImport.Size = New System.Drawing.Size(101, 38)
		Me.btnImport.TabIndex = 8
		Me.btnImport.Text = "Do Import!"
		Me.btnImport.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(12, 230)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(74, 13)
		Me.Label4.TabIndex = 10
		Me.Label4.Text = "Per row script:"
		'
		'tbProcessRow
		'
		Me.tbProcessRow.Location = New System.Drawing.Point(88, 227)
		Me.tbProcessRow.Name = "tbProcessRow"
		Me.tbProcessRow.Size = New System.Drawing.Size(110, 20)
		Me.tbProcessRow.TabIndex = 9
		Me.tbProcessRow.Text = "C:\Visual Studio Projects\CourtReminders\ScheduledTasks\importCases\ParseName.vb"
		'
		'tbPriKeys
		'
		Me.tbPriKeys.Location = New System.Drawing.Point(337, 48)
		Me.tbPriKeys.Name = "tbPriKeys"
		Me.tbPriKeys.Size = New System.Drawing.Size(140, 20)
		Me.tbPriKeys.TabIndex = 11
		Me.tbPriKeys.Text = "CaseNumber,CaseType"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(258, 51)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(73, 13)
		Me.Label5.TabIndex = 12
		Me.Label5.Text = "Unique Col(s):"
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
		Me.tbBatchSize.Location = New System.Drawing.Point(227, 115)
		Me.tbBatchSize.Name = "tbBatchSize"
		Me.tbBatchSize.Size = New System.Drawing.Size(50, 20)
		Me.tbBatchSize.TabIndex = 13
		Me.tbBatchSize.Text = "100"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(160, 118)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(61, 13)
		Me.Label6.TabIndex = 14
		Me.Label6.Text = "Batch Size:"
		'
		'lblRunInfo
		'
		Me.lblRunInfo.AutoSize = True
		Me.lblRunInfo.Location = New System.Drawing.Point(307, 115)
		Me.lblRunInfo.Name = "lblRunInfo"
		Me.lblRunInfo.Size = New System.Drawing.Size(489, 312)
		Me.lblRunInfo.TabIndex = 15
		Me.lblRunInfo.Text = resources.GetString("lblRunInfo.Text")
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(12, 172)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(95, 13)
		Me.Label7.TabIndex = 17
		Me.Label7.Text = "Whole table script:"
		'
		'tbProcessTable
		'
		Me.tbProcessTable.Location = New System.Drawing.Point(125, 169)
		Me.tbProcessTable.Name = "tbProcessTable"
		Me.tbProcessTable.Size = New System.Drawing.Size(152, 20)
		Me.tbProcessTable.TabIndex = 16
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(395, 9)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(50, 13)
		Me.Label8.TabIndex = 19
		Me.Label8.Text = "Delimiter:"
		'
		'tbDelimiter
		'
		Me.tbDelimiter.Location = New System.Drawing.Point(451, 6)
		Me.tbDelimiter.Name = "tbDelimiter"
		Me.tbDelimiter.Size = New System.Drawing.Size(26, 20)
		Me.tbDelimiter.TabIndex = 18
		Me.tbDelimiter.Text = "TAB"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Location = New System.Drawing.Point(12, 94)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(50, 13)
		Me.Label9.TabIndex = 21
		Me.Label9.Text = "Columns:"
		'
		'tbColList
		'
		Me.tbColList.Location = New System.Drawing.Point(82, 91)
		Me.tbColList.Name = "tbColList"
		Me.tbColList.Size = New System.Drawing.Size(462, 20)
		Me.tbColList.TabIndex = 20
		Me.tbColList.Text = "CaseNumber,CaseType,CitationNumber,CourtDate,Session,CourtRoom,CalendarType,name," &
	"DOB,Race,Gender,OffenseCode,Description,OfficerWitnessType,OfficerAgency,Officer" &
	"Number,OfficerName,OfficerCity"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Location = New System.Drawing.Point(12, 118)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(53, 13)
		Me.Label10.TabIndex = 23
		Me.Label10.Text = "Skip First:"
		'
		'tbSkipRows
		'
		Me.tbSkipRows.Location = New System.Drawing.Point(82, 115)
		Me.tbSkipRows.Name = "tbSkipRows"
		Me.tbSkipRows.Size = New System.Drawing.Size(26, 20)
		Me.tbSkipRows.TabIndex = 22
		Me.tbSkipRows.Text = "1"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Location = New System.Drawing.Point(111, 118)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(34, 13)
		Me.Label11.TabIndex = 24
		Me.Label11.Text = "Rows"
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(202, 225)
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
		Me.Button2.Location = New System.Drawing.Point(680, 46)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(130, 23)
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
		Me.Label12.Location = New System.Drawing.Point(483, 9)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(135, 13)
		Me.Label12.TabIndex = 27
		Me.Label12.Text = "(for tab character use TAB)"
		'
		'cbCreateTable
		'
		Me.cbCreateTable.AutoSize = True
		Me.cbCreateTable.Location = New System.Drawing.Point(498, 25)
		Me.cbCreateTable.Name = "cbCreateTable"
		Me.cbCreateTable.Size = New System.Drawing.Size(132, 17)
		Me.cbCreateTable.TabIndex = 28
		Me.cbCreateTable.Text = "Create Table if missing"
		Me.cbCreateTable.UseVisualStyleBackColor = True
		'
		'tbLimitingSQL
		'
		Me.tbLimitingSQL.Location = New System.Drawing.Point(160, 292)
		Me.tbLimitingSQL.Multiline = True
		Me.tbLimitingSQL.Name = "tbLimitingSQL"
		Me.tbLimitingSQL.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.tbLimitingSQL.Size = New System.Drawing.Size(141, 58)
		Me.tbLimitingSQL.TabIndex = 29
		Me.tbLimitingSQL.Text = "courtDate > getDate() -2"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Location = New System.Drawing.Point(10, 292)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(105, 39)
		Me.Label13.TabIndex = 30
		Me.Label13.Text = "Limiting SQL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  ex: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  recdate > getDate()" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(12, 355)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(133, 26)
		Me.Label14.TabIndex = 32
		Me.Label14.Text = "SQL statements executed " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "after the import is complete"
		'
		'tbSQLCompleted
		'
		Me.tbSQLCompleted.Location = New System.Drawing.Point(160, 355)
		Me.tbSQLCompleted.Multiline = True
		Me.tbSQLCompleted.Name = "tbSQLCompleted"
		Me.tbSQLCompleted.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
		Me.tbSQLCompleted.Size = New System.Drawing.Size(141, 58)
		Me.tbSQLCompleted.TabIndex = 31
		Me.tbSQLCompleted.Text = "courtDate > getDate() -2"
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(680, 9)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(130, 23)
		Me.Button3.TabIndex = 33
		Me.Button3.Text = "Load a config"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'cbDT
		'
		Me.cbDT.AutoSize = True
		Me.cbDT.Checked = True
		Me.cbDT.CheckState = System.Windows.Forms.CheckState.Checked
		Me.cbDT.Location = New System.Drawing.Point(10, 269)
		Me.cbDT.Name = "cbDT"
		Me.cbDT.Size = New System.Drawing.Size(235, 17)
		Me.cbDT.TabIndex = 34
		Me.cbDT.Text = "Automaticaly set DateUpdated/DateCreated"
		Me.cbDT.UseVisualStyleBackColor = True
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Location = New System.Drawing.Point(13, 197)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(103, 13)
		Me.Label15.TabIndex = 36
		Me.Label15.Text = "Process Input script:"
		'
		'tbProcessInputFilescript
		'
		Me.tbProcessInputFilescript.Location = New System.Drawing.Point(125, 194)
		Me.tbProcessInputFilescript.Name = "tbProcessInputFilescript"
		Me.tbProcessInputFilescript.Size = New System.Drawing.Size(152, 20)
		Me.tbProcessInputFilescript.TabIndex = 35
		'
		'cbQuietMode
		'
		Me.cbQuietMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cbQuietMode.AutoSize = True
		Me.cbQuietMode.Location = New System.Drawing.Point(114, 535)
		Me.cbQuietMode.Name = "cbQuietMode"
		Me.cbQuietMode.Size = New System.Drawing.Size(176, 17)
		Me.cbQuietMode.TabIndex = 37
		Me.cbQuietMode.Text = "Quiet mode (command line only)"
		Me.cbQuietMode.UseVisualStyleBackColor = True
		'
		'cbWindowMode
		'
		Me.cbWindowMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cbWindowMode.AutoSize = True
		Me.cbWindowMode.Location = New System.Drawing.Point(114, 513)
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
		Me.cbBlankNull.Location = New System.Drawing.Point(10, 252)
		Me.cbBlankNull.Name = "cbBlankNull"
		Me.cbBlankNull.Size = New System.Drawing.Size(159, 17)
		Me.cbBlankNull.TabIndex = 39
		Me.cbBlankNull.Text = "Set Blank fields equal to null"
		Me.cbBlankNull.UseVisualStyleBackColor = True
		'
		'ddFileType
		'
		Me.ddFileType.FormattingEnabled = True
		Me.ddFileType.Items.AddRange(New Object() {"Auto", "csv", "excel", "json"})
		Me.ddFileType.Location = New System.Drawing.Point(99, 26)
		Me.ddFileType.Name = "ddFileType"
		Me.ddFileType.Size = New System.Drawing.Size(121, 21)
		Me.ddFileType.TabIndex = 40
		Me.ddFileType.Text = "Auto"
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Location = New System.Drawing.Point(13, 29)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(80, 13)
		Me.Label16.TabIndex = 41
		Me.Label16.Text = "Input File Type:"
		'
		'Button4
		'
		Me.Button4.Location = New System.Drawing.Point(680, 84)
		Me.Button4.Name = "Button4"
		Me.Button4.Size = New System.Drawing.Size(130, 23)
		Me.Button4.TabIndex = 42
		Me.Button4.Text = "Preview Data"
		Me.Button4.UseVisualStyleBackColor = True
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.Location = New System.Drawing.Point(12, 146)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(81, 13)
		Me.Label17.TabIndex = 44
		Me.Label17.Text = "Regex Capture:"
		'
		'tbRegex
		'
		Me.tbRegex.Location = New System.Drawing.Point(125, 143)
		Me.tbRegex.Name = "tbRegex"
		Me.tbRegex.Size = New System.Drawing.Size(152, 20)
		Me.tbRegex.TabIndex = 43
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Location = New System.Drawing.Point(25, 432)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(106, 13)
		Me.Label18.TabIndex = 46
		Me.Label18.Text = "Custom Date Format:"
		'
		'tbDateFormat
		'
		Me.tbDateFormat.Location = New System.Drawing.Point(138, 429)
		Me.tbDateFormat.Name = "tbDateFormat"
		Me.tbDateFormat.Size = New System.Drawing.Size(152, 20)
		Me.tbDateFormat.TabIndex = 45
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(881, 563)
		Me.Controls.Add(Me.Label18)
		Me.Controls.Add(Me.tbDateFormat)
		Me.Controls.Add(Me.Label17)
		Me.Controls.Add(Me.tbRegex)
		Me.Controls.Add(Me.Button4)
		Me.Controls.Add(Me.Label16)
		Me.Controls.Add(Me.ddFileType)
		Me.Controls.Add(Me.cbBlankNull)
		Me.Controls.Add(Me.cbWindowMode)
		Me.Controls.Add(Me.cbQuietMode)
		Me.Controls.Add(Me.Label15)
		Me.Controls.Add(Me.tbProcessInputFilescript)
		Me.Controls.Add(Me.cbDT)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.Label14)
		Me.Controls.Add(Me.tbSQLCompleted)
		Me.Controls.Add(Me.Label13)
		Me.Controls.Add(Me.tbLimitingSQL)
		Me.Controls.Add(Me.cbCreateTable)
		Me.Controls.Add(Me.Label12)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.tbSkipRows)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.tbColList)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.tbDelimiter)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.tbProcessTable)
		Me.Controls.Add(Me.lblRunInfo)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.tbBatchSize)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.tbPriKeys)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.tbProcessRow)
		Me.Controls.Add(Me.btnImport)
		Me.Controls.Add(Me.cbDeleteFirst)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.tbTable)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.tbConnection)
		Me.Controls.Add(Me.btnBrowse)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.tbFileName)
		Me.Name = "Form1"
		Me.Text = "Form1"
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
    Friend WithEvents cbDeleteFirst As System.Windows.Forms.CheckBox
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents cbCreateTable As System.Windows.Forms.CheckBox
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
	Friend WithEvents Label17 As Label
	Friend WithEvents tbRegex As TextBox
	Friend WithEvents Label18 As Label
	Friend WithEvents tbDateFormat As TextBox
End Class
