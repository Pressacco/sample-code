using System;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;

namespace FlaUiSandbox
{
    public class WindowManager : IDisposable
    {
        private readonly Process _notePad;
        private readonly Process _msPaint; 

        public WindowManager(bool canAttach, Action<Application, Window> setFocus)
        {
            _notePad = new Process("notepad.exe", canAttach, setFocus);
            _msPaint = new Process("mspaint.exe", canAttach, setFocus);
        }

        public void SwitchWindows()
        {
            _notePad.Focus();
            _msPaint.Focus();
            _notePad.Focus();
            _msPaint.Focus();
        }

        private void ReleaseUnmanagedResources()
        {
            _notePad?.Dispose();
            _msPaint?.Dispose();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~WindowManager()
        {
            ReleaseUnmanagedResources();
        }
    }
}
