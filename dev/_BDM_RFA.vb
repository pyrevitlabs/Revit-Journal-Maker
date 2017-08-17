'BD Mackey Consulting
'update for 2016
'
Dim Jrn
Set Jrn = CrsJournalScript
Dim Fname, filex



InputFile = "_BDM_famlist_rfa.txt"
  Set fso = CreateObject("Scripting.FileSystemObject")
If fso.FileExists (InputFile) Then
  Set f = fso.OpenTextFile(InputFile, 1)
  ' Browser Deactivate
  Do While f.AtEndOfStream <> True
    Fname = f.ReadLine
    set filex = fso.getfile(Fname)
    file = filex.name
    upgrade Fname, file
  Loop

  Jrn.Command "SystemMenu" , "Quit the application; prompts to save projects , ID_APP_EXIT"

Else

Jrn.Command "AccelKey" , "Create a new project , ID_FILE_NEW_CHOOSE_TEMPLATE"
  Jrn.ComboBox "Modal , New Project , Dialog_Revit_NewProject" _
         , "Control_Revit_TemplateCombo" _
         , "SelEndOk" , "<None>"
 Jrn.ComboBox "Modal , New Project , Dialog_Revit_NewProject" _
         , "Control_Revit_TemplateCombo" _
         , "Select" , "<None>"
 Jrn.PushButton "Modal , New Project , Dialog_Revit_NewProject" _
         , "OK, IDOK"
Jrn.Directive "DocSymbol"  _
        , "[Project1]"
Jrn.Data "TaskDialogResult"  _
        , "Which system of measurement do you want to use in your project?",  _
         "Imperial", "1001"
Jrn.Data "Transaction Successful"  _
        , "Create Type Previews"
Jrn.Directive "GlobalToProj"  _
        , "[Project1]", "Floor Plan: Level 1" _
 

Jrn.Command "Menu" , "Create a text object , ID_OBJECTS_TEXT_NOTE"
Jrn.MouseMove    0 ,    129 ,    123
Jrn.LButtonDown    1 ,    129 ,    123
Jrn.MouseMove    1 ,    129 ,    123
Jrn.LButtonUp    0 ,    129 ,    123
Jrn.MouseMove    0 ,     51 ,    213
Jrn.Command "DesignBar" , "Select objects to modify , ID_BUTTON_SELECT"
  Jrn.Data "EditRichText"            , "file " & InputFile & " is missing", 0, 0
  Jrn.Data "Transaction Successful"            , "Text"
Jrn.Command "Menu" , "Redraw everything as large as fits into window , ID_ZOOM_FIT"
End If

Sub upgrade(namepath, file)

Jrn.Command "Menu", "Open an existing project , 57601 , ID_Revit_FILE_OPEN"
  Jrn.Data "File Name" _
          , "IDOK", namepath
'********Insert custom information between lines

'********
 Jrn.MouseMove    0 ,     292 ,    5		  

 Jrn.Command "Internal" , " , ID_REVIT_SAVE_AS_FAMILY"
  Jrn.Data "File Name"  , "IDOK", namepath

  Jrn.Command "Menu" , "Close the active project , ID_REVIT_FILE_CLOSE"


End Sub

