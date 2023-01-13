namespace DemoAppTests
{
    internal static class Constants
    {
        /// <summary>
        /// DataGrid virtualization has been explicitly turned off,
        /// which means a WPF control is created for every row.
        /// </summary>
        internal const string StandardDataGridAid = "StandardDataGrid";

        /// <summary>
        /// DataGrid virtualization is enabled, which is the default WPF behavior.
        /// </summary>
        internal const string VirtualizedDataGridAid = "VirtualDataGrid";

        /// <summary>
        /// Virtualization + Template Column
        /// </summary>
        internal const string TemplateDataGridAid = "TemplateDataGrid";
    }
}
