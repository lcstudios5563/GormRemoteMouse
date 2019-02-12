using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS.MessageHandlers
{
    public class HandlerArrowKeys : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            short direction = BitConverter.ToInt16(received, offset);
            switch (direction)
            {

                default:
                    KeyCommands.Left();
                    break;
                case 1:
                    KeyCommands.Up();
                    break;
                case 2:
                    KeyCommands.Down();
                    break;
                case 3:
                    KeyCommands.Right();
                    break;
            }
        }
    }
}
