using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GormLib.MessageModel;

namespace GormLib
{
    public class BluetoothManager
    {
        BluetoothListener _bluetoothListener;
        BluetoothClient _bluetoothClient;

        public BluetoothManager() {
            Guid guid;
            guid = new Guid("1e9276ca-904e-4cb3-89a4-fd879958d639");
            _bluetoothListener = new BluetoothListener(guid);
            _bluetoothListener.Start();
            _bluetoothClient = _bluetoothListener.AcceptBluetoothClient();

            Stream stream = _bluetoothClient.GetStream();
            while (true)
            {
                Message message = new Message();
                message.Deserialize(stream);
                //byte[] received = new byte[1024];
                //stream.Read(received,0, received.Length);
            }
        }

        /// <summary>
        /// waits until device is connected.
        /// </summary>
        private void AcceptBluetoothClient() {
            
        }
    }
}
