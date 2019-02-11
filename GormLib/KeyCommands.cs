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
        private static List<VirtualKeyCode> _modifierKeyCodes = new List<VirtualKeyCode>();
        private static List<VirtualKeyCode> _virtualKeyCodes = new List<VirtualKeyCode>();

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
            CtrlAltDel();
            Enter();
        }

        public static void Shutdown()
        {
            CtrlAltDel();
            TabShift();
            Enter();
        }

        public static void Desktop()
        {
            throw new NotImplementedException();
        }

        public static void CtrlAltDel() {
            //SendKeys.SendWait("^%{DEL}");
            _modifierKeyCodes = new List<VirtualKeyCode>();
            _modifierKeyCodes.Add(VirtualKeyCode.CONTROL);
            _modifierKeyCodes.Add(VirtualKeyCode.RMENU);

            _virtualKeyCodes = new List<VirtualKeyCode>();
            _virtualKeyCodes.Add(VirtualKeyCode.DELETE);

            _inputSimulator.Keyboard.ModifiedKeyStroke(_modifierKeyCodes, _virtualKeyCodes);
        }

        public static void Esc() {
            SendKeys.SendWait("{ESC}");
        }

        public static void Enter()
        {
            SendKeys.SendWait("{ENTER}");
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
