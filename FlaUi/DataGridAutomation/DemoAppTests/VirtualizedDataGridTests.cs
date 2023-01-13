﻿namespace DemoAppTests
{
    [TestClass]
    public class VirtualizedDataGridTests
    {
        /// <summary>
        /// DataGrid virtualization is enabled, which is the default WPF behavior.
        /// </summary>
        private const string VirtualizedDataGridAid = "RecycledDataGrid";

        /// <summary>
        /// DataGrid virtualization has been explicitly turned off,
        /// which means a WPF control is created for every row.
        /// </summary>
        private const string StandardDataGridAid = "StandardDataGrid";

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void DataGridRowsThrows()
        {
            var lastName = string.Empty;

            using (var context = new Context(new DemoAppWrapper(), Constants.VirtualizedDataGridAid))
            {
                try
                {
                    var gridRow = context.DataGrid.Select(context.LastIndex);
                    gridRow.ScrollIntoView();

                    // Index was outside the bounds of the array.
                    // ... Because: context.DataGrid.Rows = 10 <<< which is the virtualized count
                    lastName = context.DataGrid.Rows[context.LastIndex].Cells[0].Value;

                }
                finally
                {
                    WriteDetails(context, lastName);
                }
            }
        }

        [TestMethod]
        public void GridRowValueWorks()
        {
            var lastName = string.Empty;

            using (var context = new Context(new DemoAppWrapper(), Constants.VirtualizedDataGridAid))
            {
                try
                {
                    var gridRow = context.DataGrid.Select(context.LastIndex);
                    gridRow.ScrollIntoView();

                    lastName = gridRow.Cells[0].Value;

                    Assert.AreEqual(
                        "VirtualWidgets-511",
                        lastName);
                }
                finally
                {
                    WriteDetails(context, lastName);
                }
            }
        }

        private void WriteDetails(Context context, string lastName)
        {
            this.TestContext.WriteLine("GridCount={0}, GridViewCount={1}, LastIndex={2}, LastName={3}",
                context.GridCount,
                context.GridViewCount,
                context.LastIndex,
                lastName);
        }
    }
}
