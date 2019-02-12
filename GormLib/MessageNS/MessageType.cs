using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS
{
    public enum MessageType
    {
        Unknown,
        MoveMouse,
        LeftClick,
        RightClick,
        VolUp,
        VolDown,
        VolMute,
        Tab,
        AltTab,
        LockScreen,
        Shutdown,
        Desktop,
        CloseWindow,
        Esc,
        Enter,
        ArrowKeys,
        BrowserShortcuts
    }
}
