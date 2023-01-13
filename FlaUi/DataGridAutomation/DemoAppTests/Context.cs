using FlaUI.Core.AutomationElements;

using FlaUI.Core;
using FlaUI.Core.Patterns;
using DataGridView = FlaUI.Core.AutomationElements.DataGridView;

namespace DemoAppTests;

internal class Context : IDisposable
{
    internal DemoAppWrapper DemoApp { get; }
    public string DataGridAid { get; }
    internal AutomationElement? Element { get; set; }

    internal Grid? DataGrid { get; set; }
    internal DataGridView? GridView { get; set; }

    internal IAutomationPattern<ITablePattern> GridTable{ get; set; }

    internal int GridCount { get; set; }
    internal int GridViewCount { get; set; }
    internal int LastIndex { get; set; }

    public Context(DemoAppWrapper demoAppWrapper, string dataGridAid)
    {
        DemoApp = demoAppWrapper;
        DataGridAid = dataGridAid;

        Element = DemoApp.GetAutomationElement(dataGridAid);
        DataGrid = Element.AsGrid();
        GridView = Element.AsDataGridView(); // only has access to "virtualized data"
        GridTable = DataGrid.Patterns.Table;

        GridCount = DataGrid.RowCount;
        LastIndex = GridCount - 1;

        GridViewCount = GridView.Rows.Length;
    }

    public void Dispose()
    {
        // giver tester a chance to see the results
        Thread.Sleep(TimeSpan.FromSeconds(4));

        GridView = null;
        DataGrid = null;
        Element = null;

        DemoApp?.Dispose();

        GridCount = -1;
        GridViewCount = -1;
        LastIndex = -1;
    }
}