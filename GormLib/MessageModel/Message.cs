using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                byte[] received = new byte[1024];
                var messageTypeInt = stream.Read(received, offset, 2);
                MessageType = (short)messageTypeInt;
                offset = offset + 2;

                MessageBody = MessageParser.Parse((MessageType)MessageType);
                MessageBody.ProcessMessage(stream, offset);

         
            }
            catch (Exception e )
            {

                Console.WriteLine(e.ToString());
            }

        }

    }
}
