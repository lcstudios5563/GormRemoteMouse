using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS.MessageHandlers
{
    public class HandlerBackspace : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            KeyCommands.Backspace();
        }
    }
}
