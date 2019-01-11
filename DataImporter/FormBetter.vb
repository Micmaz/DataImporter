Public Class FormBetter
	Public WithEvents di As New DataImporter

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblRunInfo.Text = Module1.helpMsg().Trim()
        setvals(di)
    End Sub

#Region "Save/Load Configs & set DataImporter from form vals"

    Private Function setupDI() As Boolean
        If Not System.IO.File.Exists(tbFileName.Text) Then
            If Not tbFileName.Text.StartsWith("http") Then
                MsgBox("You uneed to select a valid input file.")
                Return False
            End If

        End If
        If di IsNot Nothing Then
            If di.WaitingMessage1 IsNot Nothing Then
                di.WaitingMessage1.Dispose()
            End If
            di.Dispose()
        End If
        di = New DataImporter()

        di.statusList = ""
        di.connectionType = ddConnectionType.Text
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
        di.processValuesScriptFile = tbperRowValues.Text
        di.processRowScriptFile = tbProcessRow.Text
        di.processTableScript = tbProcessTable.Text
        di.processInputScriptFile = tbProcessInputFilescript.Text
        di.completedSQL = tbSQLCompleted.Text
        di.batchsize = tbBatchSize.Text
        di.regExCapture = tbRegex.Text
        di.dateFormatList = tbDateFormat.Text
        di.showstackTrace = cbShowStack.Checked

        Dim format As String = ddFileType.Text.ToLower()
        If format = "auto" Then di.fileFormat = DataImporter.Format.Auto
        If format = "json" Then di.fileFormat = DataImporter.Format.json
        If format = "csv" Then di.fileFormat = DataImporter.Format.csv
        If format = "excel" Then di.fileFormat = DataImporter.Format.excel
        If format = "regex" Then di.fileFormat = DataImporter.Format.regex
        di.parentfrm = Me
        Return True
    End Function

    Public Sub setvals(di As DataImporter)
        ddConnectionType.Text = di.connectionType
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
        tbperRowValues.Text = di.processValuesScriptFile
        tbProcessRow.Text = di.processRowScriptFile
        tbProcessTable.Text = di.processTableScript
        tbProcessInputFilescript.Text = di.processInputScriptFile
        tbSQLCompleted.Text = di.completedSQL
        tbBatchSize.Text = di.batchsize
        tbRegex.Text = di.regExCapture
        tbDateFormat.Text = di.dateFormatList
        cbShowStack.Checked = di.showstackTrace

        ddFileType.Text = "Auto"
        If di.fileFormat = DataImporter.Format.json Then ddFileType.Text = "json"
        If di.fileFormat = DataImporter.Format.csv Then ddFileType.Text = "csv"
        If di.fileFormat = DataImporter.Format.excel Then ddFileType.Text = "excel"
        If di.fileFormat = DataImporter.Format.regex Then ddFileType.Text = "regex"
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim filename As String = SaveFileDialog1.FileName
            Dim output As String = ""
            output &= getConfigLine("CT", ddConnectionType)
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
            output &= getConfigLine("SV", tbperRowValues)
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
            If cbShowStack.Checked Then output &= "/STACK" & vbCrLf
            If cbWindowMode.Checked Then output &= "/W" & vbCrLf

            System.IO.File.WriteAllText(filename, output)
            MsgBox("You can now call this export with:" & vbCrLf & " DataImporter.exe " & filename)
        End If
    End Sub



    Function getConfigLine(configVal As String, tb As Windows.Forms.Control) As String
        If tb.Text.Length > 0 AndAlso Not tb.Text = "0" Then
            Dim val As String = tb.Text
            If val = vbTab Then val = "TAB"
            Return "/" & configVal.Trim("/") & " """ & val & """" & vbCrLf
        End If
        Return ""
    End Function



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

#End Region

#Region "Button Clicks"
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbProcessRow.Text = OpenFileDialog2.FileName
        End If
    End Sub

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbProcessTable.Text = OpenFileDialog2.FileName
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbProcessInputFilescript.Text = OpenFileDialog2.FileName
        End If
    End Sub

    Private Sub btnTestExcel_Click(sender As Object, e As EventArgs) Handles btnTestExcel.Click
        MessageBox.Show(di.testExcell())
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbperRowValues.Text = OpenFileDialog2.FileName
        End If
    End Sub
#End Region

#Region "Generate Test Scripts"

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If cbScriptLang.Text <> "" AndAlso cbScriptLang.Text <> "" Then
            Dim isvb As Boolean = False
            If cbScriptLang.Text = "C#" Then
                SaveFileDialogScriptSamp.Filter = "C# Script File|*.cs"
            Else
                isvb = True
                SaveFileDialogScriptSamp.Filter = "VB Script File|*.vb"
            End If

            If SaveFileDialogScriptSamp.ShowDialog() = DialogResult.OK Then
                Dim methodName As String = "processValues"
                Dim scr = ""
                If cbScript.SelectedIndex = 0 Then
                    scr = generateStub("processValues", "ht,d", "HashTable,Object", isVB:=isvb)
                End If
                If cbScript.SelectedIndex = 1 Then
                    scr = generateStub("process", "row,d", "DataRow,Object", isVB:=isvb)
                End If
                If cbScript.SelectedIndex = 2 Then
                    scr = generateStub("processTable", "table,d", "DataTable,Object", isVB:=isvb)
                End If
                If cbScript.SelectedIndex = 3 Then
                    scr = generateStub("inputFile", "fileContents,d", "String,Object", isVB:=isvb)
                End If
                System.IO.File.WriteAllText(SaveFileDialogScriptSamp.FileName, scr)
            End If
        End If

    End Sub


    Private Shared vbTypes As List(Of String) = New List(Of String) From {"Boolean", "Integer", "String", "Object"}
    Private Shared csTypes As List(Of String) = New List(Of String) From {"bool", "int", "string", "object"}

    Private Shared Function VBToCSTypes(inType As String) As String
        inType = inType.Trim()
        If vbTypes.IndexOf(inType) > -1 Then
            Return csTypes(vbTypes.IndexOf(inType))
        End If
        Return inType
    End Function
    Private Shared Function CSToVBTypes(inType As String) As String
        inType = inType.Trim()
        If csTypes.IndexOf(inType) > -1 Then
            Return vbTypes(csTypes.IndexOf(inType))
        End If
        Return inType
    End Function


    Public Shared Function generateStub(Optional methodName As String = "process", Optional argList As String = "row,d", Optional argTypes As String = "DataRow,object", Optional ClassName As String = "ProcessRow", Optional returnType As String = "bool", Optional isVB As Boolean = False) As String
        Dim ret = ""
        Dim argStr = ""
        Dim argListArr = argList.Split(",")
        Dim argTypeArr = argTypes.Split(",")
        If isVB Then
            returnType = CSToVBTypes(returnType)
        Else
            returnType = VBToCSTypes(returnType)
        End If
        For i = 0 To argListArr.Count - 1
            If isVB Then
                argStr &= " " & argListArr(i) & " as " & CSToVBTypes(argTypeArr(i)) & ","
            Else
                argStr &= " " & argTypeArr(i) & " " & VBToCSTypes(argListArr(i)) & ","
            End If
        Next
        argStr = argStr.Trim(",").Trim()
        If isVB Then

            ret &= "Imports System
Imports System.Windows.Forms
Imports System.Data
Imports DataImporter
Imports System.Collections

class " & ClassName & "
    public shared function " & methodName & "(" & argStr & ") as " & returnType & "
        'Place Code Here
	end function

End class
"
        Else

            ret &= "using System
using System.Windows.Forms
using System.Data
using DataImporter
using System.Collections

class " & ClassName & "
{
    public static " & returnType & " " & methodName & "(" & argStr & ")
    {
        //Place Code Here
	}
}
"
        End If
        Return ret
    End Function

#End Region

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

    Private Sub ddFileType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddFileType.SelectedIndexChanged
        gbDelimiters.Visible = False
        gbExcel.Visible = False
        gbRegex.Visible = False
        Select Case ddFileType.Text.ToLower()
            Case "auto"
                gbDelimiters.Visible = True
                gbExcel.Visible = True
                gbRegex.Visible = True
            Case "excel"
                gbExcel.Visible = True
            Case "csv"
                gbDelimiters.Visible = True
            Case "regex"
                gbRegex.Visible = True
        End Select
    End Sub


End Class
