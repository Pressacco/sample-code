using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;

using System;
using System.Drawing;

namespace FlaUiSandbox
{
    public class Process : IDisposable
    {
        private readonly Application _application;
        private readonly UIA3Automation _automation;
        private readonly Window _window;

        private readonly Action<Application,Window> _setFocus;

        public Process(string fileName, bool canAttach, Action<Application, Window> setFocus)
        {
            if (canAttach)
            {
                _application = Application.Attach(fileName);
            }
            else
            {
                _application = Application.Launch(fileName);
            }

            _automation = new UIA3Automation();

            _window = Retry.WhileException(
                             () => _application.GetMainWindow(_automation)).Result ??
                         throw new InvalidOperationException(
                             $"Unable to attach to application. Name={fileName}");

            _setFocus = setFocus;
        }

        private void ReleaseUnmanagedResources()
        {
            _automation?.Dispose();
            _application?.Dispose();
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                _application.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Process()
        {
            Dispose(false);
        }

        #region Attempts

        #endregion

        public void Focus()
        {
            _setFocus(_application, _window);

            _window.DrawHighlight(
                blocking: true,
                color: Color.Blue,
                duration: TimeSpan.FromMilliseconds(500));
        }
    }
}
