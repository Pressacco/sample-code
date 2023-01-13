namespace DemoAppTests
{
    using FlaUI.Core;
    using FlaUI.Core.AutomationElements;
    using FlaUI.Core.Conditions;
    using FlaUI.Core.Definitions;
    using FlaUI.Core.Tools;
    using FlaUI.UIA3;

    internal class DemoAppWrapper : IDisposable
    {
        private const string ExePath = @"..\..\..\..\..\DemoApp\bin\x64\Debug\net6.0-windows\DemoApp.exe";

        public DemoAppWrapper()
        {
            this.ConditionFactory = new ConditionFactory(new UIA3PropertyLibrary());

            this.AutomationBase = new UIA3Automation();
            this.AutomationBase.TransactionTimeout = TimeSpan.FromSeconds(20);
            this.AutomationBase.ConnectionTimeout = TimeSpan.FromSeconds(20);

            // Even though it is supported, do NOT call `Application.Attach(process)`
            // ... FlaUi v4.0.0 unexpectedly disposes of the provided Process when GetMainWindow() is called.
            this.Application = Application.Launch(ExePath);

            var result = Retry.WhileException(() => 
                this.Application.GetMainWindow(this.AutomationBase), TimeSpan.FromSeconds(5));

            this.Window = result.Result ?? throw new InvalidOperationException("Unable to attach to the application window.");
            this.Window.WaitUntilEnabled();
            this.Window.WaitUntilClickable();
        }
            
        private Application Application { get; init; }

        public Window Window { get; init; }

        private AutomationBase AutomationBase { get; init; }

        private ConditionFactory ConditionFactory { get; init; }

        public AutomationElement? GetAutomationElement(string automationId)
        {
            var result = Retry.WhileNull(
                () => this.Window.FindFirst(
                    TreeScope.Descendants,
                    ConditionFactory
                        .ByFrameworkType(FrameworkType.Wpf)
                        .And(ConditionFactory.ByAutomationId(automationId))),
                ignoreException: true,
                throwOnTimeout: false);

            if (!result.Success)
            {
                throw new InvalidOperationException($"Unable to find the requested automation element. Id={automationId}");
            }

            return result.Result;
        }

        public void Dispose()
        {
            this.Application?.Close();
            this.Application?.Dispose();
            this.AutomationBase?.Dispose();
        }
    }
}
