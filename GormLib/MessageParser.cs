using GormLib.MessageModel;
using GormLib.MessageModel.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib
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
                default:
                    return null;

            }
        }
    }
}
