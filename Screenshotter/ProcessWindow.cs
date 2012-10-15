
namespace Screenshotter
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    class ProcessWindow
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        private readonly IntPtr hWnd;

        public ProcessWindow (int pID) : this(Process.GetProcessById(pID)) { }

        public ProcessWindow(Process process)
        {
            hWnd = process.MainWindowHandle;
        }

        public void Focus()
        {
            ShowWindow(hWnd, SW_SHOWNORMAL); 
        }

        public void Minimize()
        {
            ShowWindow(hWnd, SW_SHOWMINIMIZED);
        }

        public void Maxinize()
        {
            ShowWindow(hWnd, SW_SHOWMAXIMIZED);
        }
    }
}
