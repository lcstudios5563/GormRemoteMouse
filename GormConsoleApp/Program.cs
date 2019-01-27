//using InputControlsLib;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InTheHand.Net.Bluetooth;
using GormLib;

namespace GormConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            while (true)
            {
                Console.WriteLine("Moving Mouse");
                Mouse.MoveMouse(10, 10);
                Thread.Sleep(1000);
            }

            //BluetoothClient client = new BluetoothClient();
            //List<string> items = new List<string>();
            //BluetoothDeviceInfo[] devices = client.DiscoverDevicesInRange();
            //foreach (BluetoothDeviceInfo d in devices)
            //{
            //    items.Add(d.DeviceName);
            //}
            //serverCode();
            //while (true)
            //{

            //}


            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static void serverCode() {
            Guid serviceClass;
            serviceClass = BluetoothService.SerialPort;
            var lsnr = new BluetoothListener(serviceClass);
            lsnr.Start();
        }


    }
}
