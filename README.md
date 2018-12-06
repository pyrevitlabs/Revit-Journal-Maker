[![PyPi](https://img.shields.io/pypi/v/rjm.svg)](https://pypi.org/project/rjm)

# Revit Journal Maker

python libray for writing/reading journal files for Autodesk Revit

## Writing Journals

``` python
import rjm
journal_maker = rjm.JournalMaker(permissive=True)

# creating a new model (template_name is optional)
journal_maker.new_model(template_name='My Template')

# creating a new template model (template_name is optional)
journal_maker.new_template(template_name='My Template for Templates')

# creating other types
journal_maker.new_family(base_rft_file)
journal_maker.new_conceptual_mass(base_rft_file)
journal_maker.new_titleblock(base_rft_file)
journal_maker.new_annotation(base_rft_file)

# opening workshared model
journal_maker.open_workshared_model(model_full_path,
                                    central=False,
                                    detached=True,
                                    keep_worksets=True,
                                    audit=False,
                                    show_workset_config=1)

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

# execute dynamo definition
journal_maker.execute_dynamo_definition(definition_path='C:/testdef.dyn',
                                      show_ui=True,
                                      shutdown=True)

# load a family
journal_maker.import_family(RFA_file_path)

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
journal_reader = rjm.JournalReader(active_journal_file)

# checking to see if the journal has crashed and stopped
journal_reader.is_stopped()
```
