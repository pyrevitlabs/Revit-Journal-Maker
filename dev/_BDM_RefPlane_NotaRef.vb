'BD Mackey Consulting
'UPdated to include Audit
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

Jrn.Command "Menu" , "Create a new project , ID_FILE_NEW_CHOOSE_TEMPLATE"
  Jrn.RadioButton "Modal , New Project , Dialog_Revit_NewProject"            , "None, Control_Revit_RadioNoTemplate"
  Jrn.PushButton "Modal , New Project , Dialog_Revit_NewProject"            , "OK, IDOK"
  Jrn.PushButton "Modal , Select Initial Units , Dialog_Revit_SelectInitUnits"            , "Imperial, IDOK"


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

Jrn.Command "Menu", "Open an existing project , 57601 , ID_FILE_OPEN"
 Jrn.Command "Ribbon" , "Open an existing project , ID_REVIT_FILE_OPEN"
 Jrn.Data "FileOpenSubDialog"  _
         , "AuditCheckBox", "True"
 'Id : TaskDialog_Audit_Warning
 'CommonButtons : Yes, No
 'DefaultButton : Yes 
 Jrn.Data "TaskDialogResult"  _
         , "This operation can take a long time. Recommended use includes periodic maintenance of large files and preparation for upgrading to a new release. Do you want to continue?",  _
          "Yes", "IDYES"
  Jrn.Data "File Name" _
          , "IDOK", namepath
'********Insert custom information between lines

 Jrn.Command "Ribbon" , "Create a reference plane , ID_OBJECTS_CLINE"
 Jrn.PropertiesPalette "Activate"
 Jrn.Grid "Control; FormView , Properties , IDD_PROPERTIES_PALETTE; IDC_SYMBOL_GRID" _
         , "Selection" , ""
 Jrn.Grid "Control; FormView , Properties , IDD_PROPERTIES_PALETTE; IDC_SYMBOL_GRID" _
         , "MoveCurrentCell" , "  Is Reference" , "ValueCol"
 Jrn.Grid "Control; FormView , Properties , IDD_PROPERTIES_PALETTE; IDC_SYMBOL_GRID" _
         , "PartialEdit" , "  Is Reference" , "ValueCol" , "Not a Reference" , "0" , "0"
 Jrn.Grid "Control; FormView , Properties , IDD_PROPERTIES_PALETTE; IDC_SYMBOL_GRID" _
         , "MoveCurrentCell" , "  Is Reference" , "ValueCol"
 Jrn.PropertiesPalette "MouseLeave"
 Jrn.Data "Transaction Successful"  _
         , "Modify element attributes"
 Jrn.MouseMove    0 ,    227 ,    206
 Jrn.Command "AccelKey" , "Cancel the current operation , ID_CANCEL_EDITOR"

'********
 Jrn.MouseMove    0 ,     292 ,    5
		  
 Jrn.Command "Internal" , " , ID_REVIT_SAVE_AS_FAMILY"
  Jrn.Data "File Name"  , "IDOK", namepath

  Jrn.Command "Menu" , "Close the active project , ID_REVIT_FILE_CLOSE"


End Sub

