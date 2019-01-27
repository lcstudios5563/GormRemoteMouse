using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageModel.MessageHandlers
{
    public class HandlerMoveMouse : MessageBody
    {
        public override void ProcessMessage(Stream stream, int offset)
        {
            byte[] received = new byte[1024];
            int moveX = (short)stream.Read(received, offset, 4);
            offset = offset + 4;

            int moveY = (short)stream.Read(received, offset, 4);
            offset = offset + 4;

            Mouse.MoveMouse(moveX, moveY);
        }
    }
}
