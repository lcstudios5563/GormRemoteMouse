using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageModel
{
    public class Message
    {
        public short MessageType;
        public MessageBody MessageBody;

        public void Deserialize(Stream stream) {
            try
            {
                int offset = 0;
                byte[] received = new byte[10];

                stream.Read(received, 0, received.Length);
                //var receivedstring = Encoding.ASCII.GetString(received);
                //LogHelper.Info(receivedstring);
                //if (BitConverter.IsLittleEndian) Array.Reverse(received);
                if (received[0] == 0)
                {
                    return;
                }
                MessageType = BitConverter.ToInt16(received, 0);
                LogHelper.Info(string.Format("Message Type {0} received", MessageType.ToString()));
                offset = offset + 2;

                MessageBody = MessageParser.Parse((MessageType)MessageType);
                MessageBody.ProcessMessage(received, offset);


            }
            catch (Exception e )
            {

                LogHelper.Error(e.ToString());
            }

        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

    }
}
