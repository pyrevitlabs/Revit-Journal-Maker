' revit_journal_maker generated journal
' 0:< 'C 11-Aug-2017 09:46:08.896;

Dim Jrn
Set Jrn = CrsJournalScript
' Adding debug options'
'Jrn.Directive "DebugMode", "PerformAutomaticActionInErrorDialog", 1
'Jrn.Directive "DebugMode", "PermissiveJournal", 1
test


Sub test()
Set fs = CreateObject("Scripting.FileSystemObject")
Set a = fs.CreateTextFile("testfile.txt", True)
a.WriteLine("This is a test.")
a.Close
End Sub
' Closing model
' Jrn.Command "SystemMenu" , "Quit the application; prompts to save projects , ID_APP_EXIT"
' Jrn.Data "TaskDialogResult" , "Do you want to save changes to Untitled?", "No", "IDNO"
' The following example requires that Option Infer be set to On. 
