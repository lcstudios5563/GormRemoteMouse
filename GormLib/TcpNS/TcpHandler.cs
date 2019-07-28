using GormLib.LoggerNS;
using GormLib.MessageNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GormLib.TcpNS
{
    /// <summary>
    /// Start a tcp listner to parse byte messages
    /// tutorial https://www.youtube.com/watch?v=29y4X65ZUwE
    /// </summary>
    public class TcpHandler
    {
        private int _port = 5563;
        private string _localIp4 = IpHelper.GetLocalIPAddress();
        public void Start() {
            try
            {
                // "192.168.1.75"
                IPAddress localAddr = IPAddress.Parse(_localIp4);
                TcpListener tcpListener = new TcpListener(localAddr, _port);
                LogHelper.Info("Ip Address: " + _localIp4);
                Heartbeat();

                while (true)
                {
                    tcpListener.Start();
                    //LogHelper.Info("TcpListener started.");
                    //Program blocks on Accept() until a client connects.
                    Socket soTcp = tcpListener.AcceptSocket();
                    //LogHelper.Info("SampleClient is connected through TCP.");

                    Byte[] received = new Byte[Message.MessageSize];
                    int bytesReceived = soTcp.Receive(received, received.Length, 0);
                    Message message = new Message();
                    message.Deserialize(received);
                    //String dataReceived = System.Text.Encoding.ASCII.GetString(received);
                    //LogHelper.Info(dataReceived);


                    //String returningString = "The Server got your message through TCP: " + dataReceived;
                    //Byte[] returningByte = System.Text.Encoding.ASCII.GetBytes(returningString.ToCharArray());                   
                    //Returning a confirmation string back to the client.
                    //soTcp.Send(returningByte, returningByte.Length, 0);
                    tcpListener.Stop();
                }
            }
            catch (Exception e)
            {

                LogHelper.Info(e.ToString());
                throw e;
            }

        }

        private void Heartbeat()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        using (TcpClient tcpClient = new TcpClient())
                        {
                            try
                            {
                                tcpClient.Connect(_localIp4, _port);
                                LogHelper.Info("Port open");
                            }
                            catch (Exception)
                            {
                                LogHelper.Info("Port closed");
                            }
                            Thread.Sleep(10000);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Port closed");
                    }
                }

            });
            task.Start();
        }
    }
}
