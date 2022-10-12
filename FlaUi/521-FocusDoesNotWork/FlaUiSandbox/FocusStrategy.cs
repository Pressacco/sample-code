using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;

namespace FlaUiSandbox
{
    public static class FocusStrategy
    {
        public static void Focus(Application application, Window window)
        {
            Wait.UntilResponsive(application.MainWindowHandle);
            window.Focus();
        }

        public static void SetForeground(Application application, Window window)
        {
            Wait.UntilResponsive(application.MainWindowHandle);
            window.SetForeground();
        }

        public static void ForegroundAndClick(Application application, Window window)
        {
            Wait.UntilResponsive(application.MainWindowHandle);
            window.SetForeground();
            window.Click();
        }
    }
}
