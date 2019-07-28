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
    public class UdpHandler
    {
        private int _port = 5563;
        private string _localIp4 = IpHelper.GetLocalIPAddress();


        public void Server(string address, int port)
        {
            LogHelper.Info("Ip Address: " + address);
            Heartbeat();

            byte[] data = new byte[Message.MessageSize];
            IPAddress localAddr = IPAddress.Parse(address);
            IPEndPoint ipep = new IPEndPoint(localAddr, port);
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("Waiting for a client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            //data = newsock.Receive(ref sender);

            //Console.WriteLine("Message received from {0}:", sender.ToString());
            //Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            //string welcome = "Welcome to my test server";
            //data = Encoding.ASCII.GetBytes(welcome);
            //newsock.Send(data, data.Length, sender);

            while (true)
            {
                data = newsock.Receive(ref sender);
                Message message = new Message();
                message.Deserialize(data);
                //Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
                //newsock.Send(data, data.Length, sender);
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
                        bool alreadyinuse = System.Net.NetworkInformation.IPGlobalProperties
                        .GetIPGlobalProperties()
                        .GetActiveUdpListeners()
                        .Any(p => p.Port == _port);

                        if (alreadyinuse)
                        {
                            //LogHelper.Info("Port open");
                        }
                        else {
                            LogHelper.Info("Port closed");
                        }
                        Thread.Sleep(10000);

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
