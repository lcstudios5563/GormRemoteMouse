using GormLib.LoggerNS;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.Bluetooth
{
    public class BluetoothClientHandler : AbstractBluetoothHandler
    {
        public BluetoothClientHandler() {
        }

        public void ClientStart()
        {
            LogHelper.Info("Client started");
            _bluetoothClient = new BluetoothClient();

            LogHelper.Info("Discovering devices");
            BluetoothDeviceInfo[] bluetoothDeviceInfoArray = _bluetoothClient.DiscoverDevicesInRange();
            List<string> deviceNames = new List<string>();
            foreach (var item in bluetoothDeviceInfoArray)
            {
                deviceNames.Add(item.DeviceName);
                LogHelper.Info("Device found " + item.DeviceName);
            }
            if (deviceNames.Count == 0)
            {
                LogHelper.Info("No Devices found ");
            }

            //TODO select correct device from bluetoothDeviceInfoArray
            _bluetoothClient.BeginConnect(bluetoothDeviceInfoArray[0].DeviceAddress, _guid,
                this.ClientCallback, _bluetoothClient);
        }

        public void ClientCallback(IAsyncResult result)
        {
            BluetoothClient bluetoothClient = (BluetoothClient)result.AsyncState;
            bluetoothClient.EndConnect(result);

            Stream stream = bluetoothClient.GetStream();
            stream.ReadTimeout = 1000;

            while (true)
            {
                throw new NotImplementedException();
            }
        }

    }
}
