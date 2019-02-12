using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS.MessageHandlers
{
    public class HandlerTab : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            bool useShift = BitConverter.ToBoolean(received, offset);
            if (useShift)
            {
                KeyCommands.TabShift();
            }
            else
            {
                KeyCommands.Tab();
            }
        }
    }
}
