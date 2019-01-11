Imports System.Xml.Linq

Module Module1

    Public Sub Main(argv() As String)

		Dim argc As Integer = argv.Count

		If argc = 0 Then
			Application.Run(New FormBetter())
		Else
            If argc >= 1 AndAlso System.IO.File.Exists(argv(0)) Then
				Dim newArgs() As String = DataImporter.parseConfigs(argv(0), argv)
				Main(newArgs)
				Exit Sub
            End If

			Dim di As New DataImporter
			Dim asform As Boolean = False
			Dim argret = di.setfromArgs(argv)
			If argret = DataImporter.argResults.writeHelp Then
				Exit Sub
			End If
			If argret = DataImporter.argResults.asForm Then
				Dim f = New FormBetter
				f.di = di
				Application.Run(f)
			Else
				If Not di.connectionString Is Nothing And Not di.tableName Is Nothing And Not di.fileName Is Nothing Then
					Try
						di.UploadTableFilename()
					Catch ex As Exception
						di.errorList &= String.Format("Table: {0}   File: {1}  key: {2}", di.tableName, di.fileName, di.uniqueIdentifierColumns) & vbCrLf
						di.errorList &= ex.Message & vbCrLf
						di.errorList &= ex.StackTrace & vbCrLf
					End Try
					If di.errorList.Length = 0 Then
						Console.WriteLine("There were no errors durring the export process.")
					Else
						Console.WriteLine("The following errors were reported durring the export process:")
						Console.WriteLine(di.errorList)
						Dim errfilename As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
						errfilename &= "/Errors_" & Date.Now.Ticks & ".txt"
						System.IO.File.WriteAllText(errfilename, di.errorList)
					End If
					Console.WriteLine(di.statusList)
				Else
					writeHelp()
				End If
			End If

		End If
    End Sub

    Public Sub writeHelp()
        Console.Write(helpMsg)
    End Sub

	Public Function helpMsg() As String
        Dim s As String = <![CDATA[
Usage: 
##ASM##
/C SQL_CONNECTION_STRING 
/F Imported_File_name Can be a file or a URL starting with http:// or https://
/T Imported_Table_Name 
[ /CT ] Connection_type can be sql,sqlite,oracle,mysql. Default is SQL for SQLserver
[ /FORMAT ] Usually infered from the extenstion. Can be auto,json,excel,csv,or text parsed with a regex

[ /COLS Comma_Delimited_Column_List ] (Only update listed columns)
[ /P Unique_col_list (if these values exist in the database the row will be updated) ]

[ /DELIM ] the delimiter for the file (defaults to ",")
[ /REGEX Reular expression capture ] Captures from text via regular expression. 
		All columns must be a named capture.
[ /EXCELWORKSHEET] The number of the excel worksheet to import (Starting at 0)
	-1 can be used to import all worksheets.
[ /SKIP Number_of_rows_to_skip ] (default 0)
[ /D ] Clear data table when the import starts
[ /N ] Create Table if missing

[ /NULLBLANK ] Sets the output row to null if the input is an empty string. Default is on  [0,1]
[ /DT ] Automatically set columns dateCreated and dateUpdated. Default is on  [0,1]
[ /LIM Sql where clause that limits which unique cols will be checked ex: "recordDate > getdate()-10" ]
        If a limit is not supplied it will select a row from the database based on unique col list
[ /SV Script_file_to_run_per_row_Values runs before de-duplication, takes a hashtable as an arg ]
[ /S Script_file_to_run_per_row ]
[ /ST Script_file_to_run_on_the_entire_table ]
[ /SI Script_file_to_run_on_the_input_file ]
[ /COMPSQL Sql statements executed after the import is complete 
        ex: "update mytable set createdDate=getdate() where createdDate is null;" ]
[ /B Batch_size (default 100)] 

[ /STACK ] show full stacktrace with errors (default is 0) [0,1]
[ /Q ] Quiet mode, hides progress [0,1]

[ /W show as a windows application. Parms are placed into the form fields. ]
[ /? ] (show this help) 

These commands can be in a seperate line seperated text file. 
The only argument is that text file. (Ex: ImportData configVals.txt)
        ]]>.Value.Replace("##ASM##", My.Application.Info.AssemblyName)

        Return s
    End Function




End Module
