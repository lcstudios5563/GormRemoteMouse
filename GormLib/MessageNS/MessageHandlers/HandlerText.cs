using GormLib.LoggerNS;
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
            try
            {
                byte[] byteStr = new byte[Message.MessageSize - offset];
                Buffer.BlockCopy(received, offset, byteStr, 0, byteStr.Length);
                string strReceived = Encoding.ASCII.GetString(byteStr);
                SendKeys.SendWait(strReceived);
            }
            catch (Exception e)
            {

                LogHelper.Error(e.ToString());
            }

        }
    }
}
