using FlaUI.Core.AutomationElements;

namespace DemoAppTests;

internal class Context : IDisposable
{
    internal DemoAppWrapper DemoApp { get; }
    internal AutomationElement? Element { get; set; }

    internal Grid? DataGrid { get; set; }
    internal DataGridView? GridView { get; set; }

    internal int GridCount { get; set; }
    internal int GridViewCount { get; set; }
    internal int LastIndex { get; set; }

    public Context(DemoAppWrapper demoAppWrapper)
    {
        DemoApp = demoAppWrapper;

        Element = DemoApp.GetAutomationElement("DataGridAid");
        DataGrid = Element.AsGrid();
        GridView = Element.AsDataGridView(); // only has access to "virtualized data"

        GridCount = DataGrid.RowCount;
        LastIndex = GridCount - 1;

        GridViewCount = GridView.Rows.Length;
    }

    public void Dispose()
    {
        GridView = null;
        DataGrid = null;
        Element = null;

        DemoApp?.Dispose();

        GridCount = -1;
        GridViewCount = -1;
        LastIndex = -1;
    }
}