using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace GormLib
{
    public static class KeyCommands
    {
        private static InputSimulator _inputSimulator = new InputSimulator();

        public static void Tab()
        {
            SendKeys.SendWait("{TAB}");
        }

        public static void TabShift()
        {
            SendKeys.SendWait("+{TAB}");
        }

        public static void AltTab()
        {
            SendKeys.SendWait("%{TAB}");
        }

        public static void AltTabShift()
        {
            SendKeys.SendWait("%+{TAB}");
        }

        public static void LockScreen() {
            //_inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_L);
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
        }

        public static void Shutdown()
        {
            System.Diagnostics.Process.Start("shutdown","-s");
        }

        public static void Restart()
        {
            System.Diagnostics.Process.Start("shutdown", "-r");
        }

        public static void LogOff()
        {
            System.Diagnostics.Process.Start("shutdown", "-l");
        }

        public static void Hibernate()
        {
            System.Diagnostics.Process.Start("shutdown", "-h");
        }

        public static void Desktop()
        {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_D);
        }

        public static void CloseWindow()
        {
            SendKeys.SendWait("(%{F4})");
        }

        //public static void CtrlAltDel() {
        //    // Cant be done https://stackoverflow.com/questions/33726436/how-can-i-simulate-ctrl-alt-del
        //    throw new NotImplementedException();
        //}

        public static void Esc() {
            SendKeys.SendWait("{ESC}");
        }

        public static void Enter()
        {
            SendKeys.SendWait("{ENTER}");
        }

        public static void Backspace() {
            SendKeys.SendWait("{BACKSPACE}");
        }

        public static void Left()
        {
            SendKeys.SendWait("{LEFT}");
        }

        public static void Up()
        {
            SendKeys.SendWait("{UP}");
        }

        public static void Down()
        {
            SendKeys.SendWait("{DOWN}");
        }

        public static void Right()
        {
            SendKeys.SendWait("{RIGHT}");
        }
    }
}
