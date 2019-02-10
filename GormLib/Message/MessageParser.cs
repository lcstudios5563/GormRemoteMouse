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
                default:
                    return null;

            }
        }
    }
}
