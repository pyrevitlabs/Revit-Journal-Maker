# revit_journal_maker

python libray for writing/reading journal files for Autodesk Revit

## Writing Journals

``` python
import rjm
journal_maker = rjm.JournalMaker(permissive=True)

# opening workshared model
journal_maker.open_workshared_model(model_full_path,
									central=False,
									detached=True,
									keep_worksets=True,
									audit=False)

# opening non-workshared model
journal_maker.open_model(model_full_path)

# ignore missing links
journal_maker.ignore_missing_links()

# add custom entry to journal
journal_maker.add_custom_entry(journal_entry)

# execute an addon command
cmdata = {}     # dict of data to be passed to command in journal
journal_maker.execute_command(tab_name='Add-Ins',
                              panel_name='Panel Name',
                              command_module='Addon Application Namespace',
                              command_class='Command Classname',
                              command_data=cmdata)

# ask journal to export warnings using Revit UI
journal_maker.export_warnings(export_filepath)

# ask journal to purge unused warnings using Revit UI
journal_maker.purge_unused(pass_count=3)

# sync central model
journal_maker.sync_model(comment='comment string',
                         compact_central=True,
                         release_borrowed=True,
                         release_workset=True,
                         save_local=False)

# saving non-workshared model
journal_maker.save_model()

# closing model
journal_maker.close_model()

# finally
journal_maker.write_journal(journal_filepath)
```


## Reading Journals

Under Development

``` python
import rjm
journal_reader = rjm.JournalReader()
```
