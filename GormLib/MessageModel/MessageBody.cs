using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageModel
{
    public abstract class MessageBody
    {
        public abstract void ProcessMessage(byte[] received, int offset);
    }
}
