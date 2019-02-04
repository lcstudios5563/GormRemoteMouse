using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GormLib.MessageModel;
using System.Threading;

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
            LogHelper.Info("BluetoothListener started");
            _bluetoothClient = _bluetoothListener.AcceptBluetoothClient();
            LogHelper.Info(
                string.Format("{0} connected", 
                _bluetoothClient.GetRemoteMachineName(_bluetoothListener.LocalEndPoint.Address)));

            Stream stream = _bluetoothClient.GetStream();

            while (_bluetoothClient.Client.Connected == true)
            {
                try
                {
                    Message message = new Message();
                    message.Deserialize(stream);

                }
                catch (Exception e)
                {
                    LogHelper.Error(string.Format("Client disconnected, {0}", e.ToString()));
                }

            }
            LogHelper.Warn(string.Format("Client disconnected"));
            _bluetoothListener.Stop();
            _bluetoothClient.Dispose();
            
        }

    }
}
