using GormLib.LoggerNS;
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
        static public int MessageSize = 10;

        public int Deserialize(Stream stream) {
            byte[] received = new byte[MessageSize];
            int bytesRead = 0;

            try
            {
                bytesRead = stream.Read(received, 0, received.Length);

                if (bytesRead == 0)
                {
                    return bytesRead;
                }
                MessageType = BitConverter.ToInt16(received, 0);
                LogHelper.Info(string.Format("Message Type {0} received", MessageType.ToString()));

                MessageBody = MessageParser.Parse((MessageType)MessageType);
                MessageBody.ProcessMessage(received, _headerSize);

                
            }
            catch (Exception e )
            {

                LogHelper.Error(e.ToString());
            }
            return bytesRead;
        }

        public void Deserialize(byte[] received)
        {
            try
            {
                MessageType = BitConverter.ToInt16(received, 0);
                LogHelper.Info(string.Format("Message Type {0} received", MessageType.ToString()));

                MessageBody = MessageParser.Parse((MessageType)MessageType);
                if (MessageBody != null)
                {
                    MessageBody.ProcessMessage(received, _headerSize);
                }
                

            }
            catch (Exception e)
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
