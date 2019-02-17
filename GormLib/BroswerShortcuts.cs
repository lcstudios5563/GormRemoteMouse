using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace GormLib
{
    public static class BroswerShortcuts
    {
        private static InputSimulator _inputSimulator = new InputSimulator();

        public static void NewTab() {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_T);
        }

        public static void CloseTab()
        {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_W);
        }

        public static void OpenClosedTab()
        {
            List<VirtualKeyCode> modifierKeyCodes = new List<VirtualKeyCode>();
            modifierKeyCodes.Add(VirtualKeyCode.CONTROL);
            modifierKeyCodes.Add(VirtualKeyCode.SHIFT);
            _inputSimulator.Keyboard.ModifiedKeyStroke(modifierKeyCodes, VirtualKeyCode.VK_T);
        }

        public static void AddressBar() {
            _inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.VK_D);
        }

        public static void NextTab() {
            List<VirtualKeyCode> modifierKeyCodes = new List<VirtualKeyCode>();
            modifierKeyCodes.Add(VirtualKeyCode.CONTROL);
            _inputSimulator.Keyboard.ModifiedKeyStroke(modifierKeyCodes, VirtualKeyCode.TAB);
        }

        public static void PreviousTab()
        {
            List<VirtualKeyCode>  modifierKeyCodes = new List<VirtualKeyCode>();
            modifierKeyCodes.Add(VirtualKeyCode.CONTROL);
            modifierKeyCodes.Add(VirtualKeyCode.SHIFT);
            _inputSimulator.Keyboard.ModifiedKeyStroke(modifierKeyCodes, VirtualKeyCode.TAB);
        }

    }
}
