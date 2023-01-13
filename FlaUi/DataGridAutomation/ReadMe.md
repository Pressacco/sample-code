# Read Me

The intent of this project is to have a sandbox application that can be used to discuss:

- > How do you reliably query a WPF `DataGrid` when virtualization has been enabled?
    - `DataGrid`'s default setting is: `VirtualizingStackPanel.VirtualizationMode="Recycling"`

## Solution

It appears that the problem can be addressed by using:

- `VirtualizedDataGridTests`
    - `TemplateColumnWorks()`

