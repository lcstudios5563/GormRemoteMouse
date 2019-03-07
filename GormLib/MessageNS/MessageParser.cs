using GormLib.MessageNS.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS
{
    public static class MessageParser
    {
        public static MessageBody Parse(MessageType messageType) {

            switch (messageType)
            {
                case MessageType.MoveMouse:
                    return new HandlerMoveMouse();
                case MessageType.LeftClick:
                    return new HandlerLeftClick();                   
                case MessageType.RightClick:
                    return new HandlerRightClick();
                case MessageType.VolUp:
                    return new HandlerVolUp();
                case MessageType.VolDown:
                    return new HandlerVolDown();
                case MessageType.VolMute:
                    return new HandlerVolMute();
                case MessageType.Tab:
                    return new HandlerTab();
                case MessageType.AltTab:
                    return new HandlerAltTab();
                case MessageType.LockScreen:
                    return new HandlerLockScreen();
                case MessageType.Shutdown:
                    return new HandlerShutdown();
                case MessageType.Desktop:
                    return new HandlerDesktop();
                case MessageType.CloseWindow:
                    return new HandlerCloseWindow();
                case MessageType.Esc:
                    return new HandlerEsc();
                case MessageType.Enter:
                    return new HandlerEnter();
                case MessageType.ArrowKeys:
                    return new HandlerArrowKeys();
                case MessageType.BrowserShortcuts:
                    return new HandlerBrowserShortcuts();
                case MessageType.Text:
                    return new HandlerBrowserShortcuts();
                default:
                    return null;

            }
        }
    }
}