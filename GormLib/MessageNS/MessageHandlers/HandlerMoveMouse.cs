using GormLib.LoggerNS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS.MessageHandlers
{
    public class HandlerMoveMouse : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            int moveX = BitConverter.ToInt32(received, offset);
            offset = offset + 4;

            int moveY = BitConverter.ToInt32(received, offset);
            offset = offset + 4;

            LogHelper.Info(string.Format("moving X:{0}, Y:{1}", moveX, moveY));
            Mouse.MoveMouse(moveX, moveY);
        }
    }
}
