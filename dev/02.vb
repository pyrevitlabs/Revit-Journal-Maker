' revit_journal_maker generated journal
' 0:< 'C 11-Aug-2017 09:46:08.896;


Dim Jrn
Set Jrn = CrsJournalScript

Set fs = CreateObject("Scripting.FileSystemObject")
Set a = fs.CreateTextFile("testfile.txt", True)

a.WriteLine(VarType(Jrn))

a.Close
