' BLANK LINE
'
Dim Jrn
Set Jrn = CrsJournalScript
Dim sFileName

InputFile = "famlist_rfa.txt"
Set fso = CreateObject("Scripting.FileSystemObject")

If fso.FileExists (InputFile) Then
    Set f = fso.OpenTextFile(InputFile, 1)
    ' Browser Deactivate
    Do While f.AtEndOfStream <> True
        sFileName = f.ReadLine

        OpenFile sFileName
        AddParameter "Design Supply Airflow", "Mechanical - Airflow", "Mechanical", "Instance"
        RemoveParameter "Design Supply Airflow (default)"
        SaveFile
        CloseFile
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

''
'' Begin Custom Functions.
''
Sub AddParameter(sParameter, sSharedParameterGroup, sFamilyGroup, sInstance) ''/*{{{*/
    ' AddParameter
    '
    ' ARGS:
    '   STRING  : sParameter                    =       Parameter Name to add
    '   STRING  : sSharedParameterGroup         =       Group in Shared parameter file
    '                                                   sParameter can be found
    '   STRING  : sFamilyGoup                   =       A string representing the parameter
    '                                                   group should be placed in.
    '   STRING  : sInstance                     =       A string representing the type;
    '                                                   "Instance"  or  "Type"
    '
    ' EX: AddParameter "Design Supply Airflow", "Mechanical - Airflow", "Mechanical", "Instance"
    '
    ' By:       John Kaul
    '           09.15.15
        Jrn.Command "Internal" , "Modify predefined types for this family , ID_FAMILY_TYPE"
        Jrn.PushButton "Modal , Family Types , Dialog_Family_FamilyType" _
                 , "Add..., Control_Family_NewFamParam"
        Jrn.RadioButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "Shared parameter, Control_Revit_ExternalParam"
        Jrn.PushButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "Select..., Control_Revit_ExternalParamSelect"
        Jrn.ComboBox "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                 , "Control_Revit_ParameterGroup" _
                 , "SelEndOk" , sSharedParameterGroup
        Jrn.ComboBox "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                 , "Control_Revit_ParameterGroup" _
                 , "Select" , sSharedParameterGroup
        Jrn.ListBox "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                 , "Control_Revit_Parameters" _
                 , "Select" , sParameter
        Jrn.PushButton "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                 , "OK, IDOK"
        Jrn.ComboBox "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "Control_Revit_ParamGroup" _
                 , "Select" , sFamilyGroup
        Jrn.RadioButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , sInstance & ", Control_Revit_Radio" & sInstance
        Jrn.PushButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "OK, IDOK"
        Jrn.Data "Transaction Successful"  _
                , "New param"
        Jrn.PushButton "Modal , Family Types , Dialog_Family_FamilyType" _
                 , "OK, IDOK"
        Jrn.Data "Transaction Successful"  _
                , "Family Types"
End Sub ''/*}}}*/

Sub RemoveParameter(sParameter) ''/*{{{*/
    ' RemoveParameter
    '   Removes a parameter.
    '
    ' ARGS:
    '   STRING  :       sParameter      =       Paramter name to remove
    '
    ' EX: RemoveParameter "Design Supply Airflow (default)"
    '
    ' By:       John Kaul
    '           09.15.15
    Jrn.Command "Internal" , "Modify predefined types for this family , ID_FAMILY_TYPE"
    Jrn.Grid "Control; Modal , Family Types , Dialog_Family_FamilyType; Control_Family_TypeGrid" _
        , "Selection" , ""
    Jrn.Grid "Control; Modal , Family Types , Dialog_Family_FamilyType; Control_Family_TypeGrid" _
        , "MoveCurrentCell" , sParameter , "ValueCol"
    Jrn.PushButton "Modal , Family Types , Dialog_Family_FamilyType" _
        , "Remove, Control_Family_DeleteFamParam"
    Jrn.Data "TaskDialogResult"  _
        , "Delete family parameter?",  _
        "Yes", "IDYES"
    Jrn.Data "Transaction Successful"  _
        , "Delete param"
    Jrn.PushButton "Modal , Family Types , Dialog_Family_FamilyType" _
        , "OK, IDOK"
    Jrn.Data "Transaction Successful"  _
        , "Family Types"
End Sub ''/*}}}*/

Sub OpenFile(sNamePath) ''/*{{{*/
    ' OpenFile
    '   Opens file
    '
    '  ARGS:
    '   STRING  :       sNamePath       = path + filename
    '
    ' By:       John Kaul
    '           09.15.15
    Jrn.Command "Internal" , "Open an existing project , ID_REVIT_FILE_OPEN"
    Jrn.Data "File Name" _
        , "IDOK", sNamePath
End Sub ''/*}}}*/

Sub SaveFile()  ''/*{{{*/
    ' SaveFile
    '   Saves a file
    '
    ' By:       John Kaul
    '           09.15.15
    Jrn.Command "Internal" , "Save the active project , ID_REVIT_FILE_SAVE"
    Jrn.Command "Menu" , "Close the active project , ID_REVIT_FILE_CLOSE"
End Sub ''/*}}}*/

Sub CloseFile() ''/*{{{*/
    ' CloseFile
    '   Closes a file
    '
    ' By:       John Kaul
    '           09.15.15
    Jrn.Command "Menu" , "Close the active project , ID_REVIT_FILE_CLOSE"
End Sub ''/*}}}*/


Sub MapToSharedParameter(sExistParameter, sMappedParameter, sSharedParameterGroup, sFamilyGroup, sInstance) ''/*{{{*/
    ' MapToSharedParameter
    '
    ' ARGS:
    '   STRING  : sExistParameter               =       Parameter Name to modify
    '   STRING  : sMappedParameter              =       Parameter to map to
    '   STRING  : sSharedParameterGroup         =       Group in Shared parameter file
    '                                                   sParameter can be found
    '   STRING  : sFamilyGoup                   =       A string representing the parameter
    '                                                   group should be placed in.
    '   STRING  : sInstance                     =       A string representing the type;
    '                                                   "Instance"  or  "Type"
    '
    ' EX: ModifyParameter "Voltage", "Voltage", "Electrical", "Electrical", "Type"
    '
    ' By:       John Kaul
    '           09.17.15
        Jrn.Command "Internal" , "Modify predefined types for this family , ID_FAMILY_TYPE"
        Jrn.Grid "Control; Modal , Family Types , Dialog_Family_FamilyType; Control_Family_TypeGrid" _
                , "Selection" , ""
        Jrn.Grid "Control; Modal , Family Types , Dialog_Family_FamilyType; Control_Family_TypeGrid" _
                , "MoveCurrentCell" , sExistParameter , "NameCol"
        Jrn.PushButton "Modal , Family Types , Dialog_Family_FamilyType" _
                , "Modify..., Control_Family_EditFamParam"
        Jrn.RadioButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                , "Shared parameter, Control_Revit_ExternalParam"
        Jrn.PushButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                , "Select..., Control_Revit_ExternalParamSelect"
        Jrn.ComboBox "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                , "Control_Revit_ParameterGroup" _
                , "SelEndOk" , sSharedParameterGroup
        Jrn.ComboBox "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                , "Control_Revit_ParameterGroup" _
                , "Select" , sSharedParameterGroup
        Jrn.ListBox "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                , "Control_Revit_Parameters" _
                , "Select" , sMappedParameter
        Jrn.PushButton "Modal , Shared Parameters , Dialog_Revit_ExternalParamImport" _
                , "OK, IDOK"
        Jrn.ComboBox "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "Control_Revit_ParamGroup" _
                 , "Select" , sFamilyGroup
        Jrn.RadioButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , sInstance & ", Control_Revit_Radio" & sInstance
        Jrn.PushButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "OK, IDOK"
        Jrn.Data "Transaction Successful"  _
                , "New param"
        Jrn.Push "Modal , Family Types , Dialog_Family_FamilyType" _
                 , "OK, IDOK"
        Jrn.Data "Transaction Successful"  _
                , "Family Types"
End Sub ''/*}}}*/

Sub MapToFamilyParameter(sExistParameter, sFamilyGroup, sInstance) ''/*{{{*/
    ' MapToFamilyParameter
    '
    ' ARGS:
    '   STRING  : sExistParameter               =       Parameter Name to modfiy
    '   STRING  : sFamilyGoup                   =       A string representing the parameter
    '                                                   group should be placed in.
    '   STRING  : sInstance                     =       A string representing the type;
    '                                                   "Instance"  or  "Type"
    '
    ' EX: MapToFamilyParameter "Voltage", "Electrical", "Type"
    '
    ' By:       John Kaul
    '           09.17.15
        Jrn.Command "Internal" , "Modify predefined types for this family , ID_FAMILY_TYPE"
        Jrn.Grid "Control; Modal , Family Types , Dialog_Family_FamilyType; Control_Family_TypeGrid" _
                , "Selection" , ""
        Jrn.Grid "Control; Modal , Family Types , Dialog_Family_FamilyType; Control_Family_TypeGrid" _
                , "MoveCurrentCell" , sExistParameter , "NameCol"
        Jrn.PushButton "Modal , Family Types , Dialog_Family_FamilyType" _
                , "Modify..., Control_Family_EditFamParam"
        Jrn.RadioButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                , "Family parameter, Control_Revit_FamilyParam"
        Jrn.ComboBox "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "Control_Revit_ParamGroup" _
                 , "Select" , sFamilyGroup
        Jrn.RadioButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , sInstance & ", Control_Revit_Radio" & sInstance
        Jrn.PushButton "Modal , Parameter Properties , Dialog_Revit_ParamPropertiesFamily" _
                 , "OK, IDOK"
        Jrn.Data "Transaction Successful"  _
                , "New param"
        Jrn.PushButton "Modal , Family Types , Dialog_Family_FamilyType" _
                 , "OK, IDOK"
        Jrn.Data "Transaction Successful"  _
                , "Family Types"
End Sub ''/*}}}*/
 
