## Revit Journal VBScript Object:

```
Dim Jrn
Set Jrn = CrsJournalScript
```

VBScript object type is `ICRSXJournal` but can't find any documentation on it.


### Functions are defined in:

`Utility.dll @ C:\Program Files\Autodesk\Revit <version>\Utility.dll`

------
### Collected Docs on Exported Functions:

#### Activate(string, string)

#### AddInEvent(string, string)

#### AppButtonEvent(bool, string)

#### Browser(string, string)

#### CheckBox(string, string, bool)

#### CheckComboBox(string, string, string, string)

#### Close(string, string)

#### ComboBox(string, string, string, string)

#### Command(string, string)

#### DHtmlEvent(string, string, string)

#### Data(string, list)

`Jrn.Data "APIStringStringMapJournalData", data_count, [key_string, value_string]`

#### DateTimeCtrl(string, string, string, string)

#### Directive(string, list)

#### DropFiles(string, string)

#### DropToView(string, string, string, int, int)

#### DynamicCommand(string, unsigned int, string)

#### Edit(string, string, string, string)

#### FabricationPartBrowser(string, string)

#### FamilyBrowser(string, string)

#### Grid(string, string, list)

#### GridRow(string, string, string, string, string)

#### HostedByLinksView(string)

#### InfoCenterEvent(string, string)

#### Key(unsigned int, string, unsigned int)

#### LButtonDblClk(unsigned int, int, int)

#### LButtonDown(unsigned int, int, int)

#### LButtonUp(unsigned int, int, int)

#### ListBox(string, string, string, string)

#### ListCtrl(string, string, string, string)

#### MButtonDblClk(unsigned int, int, int)

#### MButtonDown(unsigned int, int, int)

#### MButtonUp(unsigned int, int, int)

#### Maximize(void)

#### Minimize(void)

#### MouseMove(unsigned int, int, int)

#### Navigate(string)

#### OptionBarKey(unsigned int, string, string)

#### PerfCheck(string)

#### PropPageActivate(string)

#### PropertiesPalette(string)

#### PushButton(string, string)

#### RButtonDblClk(unsigned int, int, int)

#### RButtonDown(unsigned int, int, int)

#### RButtonUp(unsigned int, int, int)

#### RadioButton(string, string)

#### RangeSliderCtrl(string, string, string, string)

#### Restore(void)

#### RibbonEvent(string)

#### SBButtonDown(string, string)

#### SBButtonUp(string, string)

#### SBMotion(string, double, double, double, double, double, double)

#### SBRest(string)

#### SBTrayAction(string, string)

#### Scroll(unsigned int, unsigned int, int, int)

#### Size(unsigned int, int, int)

#### SliderCtrl(string, string, string, string)

#### SystemBrowser(string, string, unsigned int)

#### TabCtrl(string, string, string, string)

#### TreeCtrl(string, string, string, string)

#### Wheel(unsigned int, unsigned int, int, int)

#### WidgetEvent(string, string)

#### XBrowser(string, string, string, string)
