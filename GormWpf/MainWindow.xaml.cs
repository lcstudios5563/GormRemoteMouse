using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Threading;
using GormLib;
using System.IO;
using GormLib.MessageModel;

namespace GormWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Thread blueToothServerConnectThread = new Thread(new ThreadStart(serverConnectThread));
            blueToothServerConnectThread.Start();
        }

        private void serverConnectThread() {
            Guid guid;
            guid = new Guid("1e9276ca-904e-4cb3-89a4-fd879958d639");
            BluetoothListener bluetoothListener = new BluetoothListener(guid);
            bluetoothListener.Start();

            BluetoothClient bluetoothClient = bluetoothListener.AcceptBluetoothClient();

            this.Dispatcher.Invoke(new Action(() =>
            {
                updateGui("Client connected");
            }));

            Stream stream = bluetoothClient.GetStream();
            while (true)
            {
                Message message = new Message();
                message.Deserialize(stream);
                //byte[] received = new byte[1024];
                //stream.Read(received,0, received.Length);
            }

            // BluetoothManager bluetoothManager = new BluetoothManager();
        }

        public void updateGui(string text) {
            textbox1.AppendText(text);
        }
    }
}
