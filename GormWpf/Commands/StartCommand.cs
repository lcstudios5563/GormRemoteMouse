using GormLib;
using GormLib.Bluetooth;
using GormLib.LoggerNS;
using GormLib.MessageNS;
using GormLib.TcpNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GormWpf.Commands
{
    public class StartCommand : ICommand
    {
        #pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            Task task = new Task(() =>
            {
                //BluetoothServerHandler bluetoothManager = new BluetoothServerHandler();
                //bluetoothManager.ServerStart();

                //TcpHandler tcpHandler = new TcpHandler();
                //tcpHandler.Start();

                UdpHandler s = new UdpHandler();
                s.Server(IpHelper.GetLocalIPAddress(), 5563);

            });
            task.Start();

           
        }
    }
}
