'
'added arrange windows and zoom all - smc 03/10/2003
'update for 2010 - modify save as command - smc 2/25/2009
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
 Jrn.RibbonEvent "TabActivated:Annotate"
 Jrn.Command "Ribbon" , "Modify Linear Dimension Styles , ID_SETTINGS_DIMENSIONS_LINEAR"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark" , "ValueCol" , "Diagonal" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark Line Weight" , "ValueCol" , "2" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Witness Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Witness Line Extension" , "ValueCol" , "1/32" , "4" , "4"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Dimension Line Extension" , "ValueCol" , "0" , "1" , "1"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Font" , "ValueCol" , "Arial Narrow" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Background" , "ValueCol" , "Transparent" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "No"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "LButtonDblClk" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "Yes"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
 Jrn.PushButton "Modal , Type Properties , IDD_SYMBOL_ATTRIB" _
         , "OK, IDOK"
Jrn.Data "Transaction Successful"  _
        , "Modify type attributes"
 Jrn.MouseMove    0 ,     73 ,     46
 Jrn.Command "Ribbon" , "Modify Angular Dimension Styles , ID_SETTINGS_DIMENSIONS_ANGULAR"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark" , "ValueCol" , "Arrowhead" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark Line Weight" , "ValueCol" , "2" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Dimension Line Extension" , "ValueCol" , "0" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Flipped Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Flipped Dimension Line Extension" , "ValueCol" , "0" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Flipped Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Snap Distance" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Dimension Line Snap Distance" , "ValueCol" , ".25" , "3" , "3"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Snap Distance" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Witness Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Witness Line Extension" , "ValueCol" , "1/64" , "4" , "4"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Witness Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Font" , "ValueCol" , "Arial Narrow" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Background" , "ValueCol" , "Transparent" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "No"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "LButtonDblClk" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "Yes"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
 Jrn.PushButton "Modal , Type Properties , IDD_SYMBOL_ATTRIB" _
         , "OK, IDOK"
Jrn.Data "Transaction Successful"  _
        , "Modify type attributes"
 Jrn.MouseMove    0 ,     74 ,     16
 Jrn.Command "Ribbon" , "Modify Radial Dimension Styles , ID_SETTINGS_DIMENSIONS_RADIAL"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark" , "ValueCol" , "Arrowhead" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark Line Weight" , "ValueCol" , "2" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Dimension Line Extension" , "ValueCol" , "0" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Flipped Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Flipped Dimension Line Extension" , "ValueCol" , "0" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Flipped Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Font" , "ValueCol" , "Arial Narrow" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Background" , "ValueCol" , "Transparent" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "No"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "Yes"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Mark Size" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Center Marks" , "ValueCol" , "No"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "LButtonDblClk" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Center Marks" , "ValueCol" , "Yes"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Mark Size" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Center Mark Size" , "ValueCol" , "1/32" , "4" , "4"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Mark Size" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Radius Symbol Location" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Radius Symbol Location" , "ValueCol" , "None" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Radius Symbol Location" , "ValueCol"
 Jrn.PushButton "Modal , Type Properties , IDD_SYMBOL_ATTRIB" _
         , "OK, IDOK"
Jrn.Data "Transaction Successful"  _
        , "Modify type attributes"
 Jrn.MouseMove    0 ,     70 ,      6
 Jrn.Command "Ribbon" , "Modify Diameter Dimension Styles , ID_SETTINGS_DIMENSIONS_DIAMETER"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark" , "ValueCol" , "Arrowhead" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Tick Mark Line Weight" , "ValueCol" , "2" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Tick Mark Line Weight" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Dimension Line Extension" , "ValueCol" , "0" , "1" , "1"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Flipped Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Flipped Dimension Line Extension" , "ValueCol" , "0" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Flipped Dimension Line Extension" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Font" , "ValueCol" , "Arial Narrow" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Font" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Text Background" , "ValueCol" , "Transparent" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Text Background" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "No"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Suppress Spaces" , "ValueCol" , "Yes"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Suppress Spaces" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Center Marks" , "ValueCol" , "No"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "LButtonDblClk" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Center Marks" , "ValueCol" , "Yes"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Marks" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Mark Size" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Center Mark Size" , "ValueCol" , "1/32" , "4" , "4"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Center Mark Size" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "Selection" , ""
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Diameter Symbol Location" , "ValueCol"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "PartialEdit" , "Diameter Symbol Location" , "ValueCol" , "None" , "0" , "0"
Jrn.Grid "Control; Modal , Type Properties , IDD_SYMBOL_ATTRIB; IDC_SYMBOL_GRID" _
        , "MoveCurrentCell" , "Diameter Symbol Location" , "ValueCol"
 Jrn.PushButton "Modal , Type Properties , IDD_SYMBOL_ATTRIB" _
         , "OK, IDOK"
Jrn.Data "Transaction Successful"  _
        , "Modify type attributes"
'********
		  Jrn.MouseMove    0 ,     292 ,    5
		  
 Jrn.Command "Internal" , " , ID_REVIT_SAVE_AS_FAMILY"
  Jrn.Data "File Name"  , "IDOK", namepath

  Jrn.Command "Menu" , "Close the active project , ID_REVIT_FILE_CLOSE"


End Sub

