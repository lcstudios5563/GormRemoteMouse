using GormLib;
using GormLib.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
            Task task = new Task(() => {
                BluetoothServerHandler bluetoothManager = new BluetoothServerHandler();
                bluetoothManager.ServerStart();
            });
            task.Start();
        }
    }
}
