
namespace Screenshotter
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    public class Camera
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        public static void ClickClick(int pId, string screenshotPath)
        {
            var bitmap = CaptureApplicationScreenshot(pId);
            bitmap.Save(screenshotPath, ImageFormat.Png);
        }

        public static Bitmap CaptureApplicationScreenshot(int pId)
        {
            var proc = Process.GetProcessById(pId);
            var hWnd = proc.MainWindowHandle;

            var window = new ProcessWindow(proc);
            window.Focus();

            Rect rc;
            GetWindowRect(hWnd, out rc);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hWnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }
    }
}