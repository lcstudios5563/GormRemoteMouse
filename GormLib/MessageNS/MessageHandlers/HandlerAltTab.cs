using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS.MessageHandlers
{
    public class HandlerAltTab : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            bool useShift = BitConverter.ToBoolean(received, offset);
            if (useShift)
            {
                KeyCommands.AltTabShift();
            }
            else {
                KeyCommands.AltTab();
            }
            
        }
    }
}
