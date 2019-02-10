using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GormLib.Bluetooth
{
    public abstract class AbstractBluetoothHandler
    {
        protected Guid _guid = new Guid("1e9276ca-904e-4cb3-89a4-fd879958d639");
        protected BluetoothClient _bluetoothClient;
    }
}
