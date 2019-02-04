using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageModel.MessageHandlers
{
    public class HandlerLeftClick : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            Mouse.DoLeftClick();
        }
    }
}
