using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GormLib.MessageNS;
using System.Threading;
using GormLib.LoggerNS;

namespace GormLib.Bluetooth
{
    public class BluetoothServerHandler : AbstractBluetoothHandler
    {
        BluetoothListener _bluetoothListener;

        public BluetoothServerHandler() {

        }

        public void ServerStart() {

            _bluetoothListener = new BluetoothListener(_guid);
            _bluetoothListener.Start();
            LogHelper.Info("Bluetooth Server started");
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

                    int bytesRead = message.Deserialize(stream);
                    if (bytesRead == 0)
                    {
                        // 0 bytes returned the client may have disconnected
                        ServerClose();
                    }

                }
                catch (Exception e)
                {
                    LogHelper.Error(e.ToString());
                }

            }
            ServerClose();
        }

        public void ServerClose() {
            LogHelper.Info (string.Format("Client disconnected, Stopping Server"));
            try
            {
                _bluetoothListener.Stop();
                _bluetoothClient.Dispose();
            }
            catch (Exception e)
            {

                LogHelper.Error(e.ToString());
            }
        }


    }
}
