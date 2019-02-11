using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.MessageNS
{
    public class Message
    {
        public short MessageType;
        protected int _headerSize = 2;
        public MessageBody MessageBody;
        private int _messageSize = 10;
        protected byte[] _received;

        public int Deserialize(Stream stream) {
            _received = new byte[_messageSize];
            int bytesRead = 0;

            try
            {
                bytesRead = stream.Read(_received, 0, _received.Length);

                if (bytesRead == 0)
                {
                    return bytesRead;
                }
                MessageType = BitConverter.ToInt16(_received, 0);
                LogHelper.Info(string.Format("Message Type {0} received", MessageType.ToString()));

                MessageBody = MessageParser.Parse((MessageType)MessageType);
                MessageBody.ProcessMessage(_received, _headerSize);

                
            }
            catch (Exception e )
            {

                LogHelper.Error(e.ToString());
            }
            return bytesRead;
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
