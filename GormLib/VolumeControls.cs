using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace GormLib
{
    /// <summary>
    /// Static Class for controlling volume
    /// https://stackoverflow.com/questions/13139181/how-to-programmatically-set-the-system-volume
    /// </summary>
    public class VolumeControls
    {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public static void Mute()
        {
            IntPtr intPtr = Process.GetCurrentProcess().MainWindowHandle;
            SendMessageW(intPtr, WM_APPCOMMAND, intPtr,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }


        public static void VolDown()
        {
            IntPtr intPtr = Process.GetCurrentProcess().MainWindowHandle;
            SendMessageW(intPtr, WM_APPCOMMAND, intPtr,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public static void VolUp()
        {
            IntPtr intPtr = Process.GetCurrentProcess().MainWindowHandle;
            SendMessageW(intPtr, WM_APPCOMMAND, intPtr,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }
    }
}
