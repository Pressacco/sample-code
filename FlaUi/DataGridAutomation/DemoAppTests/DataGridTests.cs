using System.Runtime.CompilerServices;

namespace DemoAppTests
{
    [TestClass]
    public class DataGridTests
    {
        public TestContext TestContext { get; set; }

        private Context Context { get; set; }
      

       [TestInitialize()]
        public void Setup()
        {
            this.Context = new Context(new DemoAppWrapper());
        }

        [TestCleanup]
        public void TearDown()
        {
            // giver tester a chance to see the results
            Thread.Sleep(TimeSpan.FromSeconds(4));

            this.Context.Dispose();
        }

        [TestMethod]
        public void LastDataGridRowWillThrow()
        {
            var lastName = string.Empty;

            try
            {
                var gridRow = Context.DataGrid.Select(Context.LastIndex);
                gridRow.ScrollIntoView();

                lastName = Context.DataGrid.Rows[Context.LastIndex].Cells[0].Value;
            }
            catch (Exception exception)
            {
                this.TestContext.WriteLine("ERROR:" + exception.Message);
            }
            finally
            {
                this.TestContext.WriteLine("GridCount={0}, GridViewCount={1}, LastIndex={2}, LastName={3}",
                    Context.GridCount,
                    Context.GridViewCount,
                    Context.LastIndex,
                    lastName);
            }
        }
    }
}