using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GormLib.MessageNS.MessageHandlers
{
    public class HandlerText : MessageBody
    {
        public override void ProcessMessage(byte[] received, int offset)
        {
            byte[] byteStr = new byte[Message.MessageSize - offset];
            received.CopyTo(byteStr, offset);
            string strReceived = Encoding.ASCII.GetString(byteStr);
            SendKeys.SendWait(strReceived);
        }
    }
}
