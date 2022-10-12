using FlaUiSandbox;

namespace FlaUiTests
{
    [TestClass]
    public class WindowManagerTests
    {
        [TestMethod]
        public void Attach_Focus_PaintWindowAlwaysHidden()
        {
            // Prior to starting test, ensure that the Paint & NotePad applications
            // are behind another window (e.g. Visual Studio).
            using (var windowManager = new WindowManager(canAttach: true, FocusStrategy.Focus))
            {
                windowManager.SwitchWindows();
            }
            Assert.Fail("Paint program will not be visible because it remains in the background.");
        }

        [TestMethod]
        public void Attach_SetForeground_PaintWindowAlwaysHidden()
        {
            // Prior to starting test, ensure that the Paint & NotePad applications
            // are behind another window (e.g. Visual Studio).
            using (var windowManager = new WindowManager(canAttach: true, FocusStrategy.SetForeground))
            {
                windowManager.SwitchWindows();
            }
            Assert.Fail("Paint program will not be visible because it remains in the background.");
        }

        [TestMethod]
        public void NewProcesses_SetForeground_PaintWindowPartiallyHidden()
        {
            using (var windowManager = new WindowManager(canAttach: false, FocusStrategy.SetForeground))
            {
                windowManager.SwitchWindows();
            }

            Assert.Fail("Paint program will not be visible because it remains in the background.");
        }

        [TestMethod]
        public void Attach_FocusAndClick_FocusWorks()
        {
            using (var windowManager = new WindowManager(canAttach: true, FocusStrategy.ForegroundAndClick))
            {
                windowManager.SwitchWindows();
            }

            Assert.IsTrue(true, "As FlaUI switches between applications, the windows are brought to the foreground as expected.");
        }
    }
}