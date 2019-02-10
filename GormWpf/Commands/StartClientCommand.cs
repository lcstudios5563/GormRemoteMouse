using GormLib;
using GormLib.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GormLibWpf.Commands
{
    public class StartClientCommand : ICommand
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
                BluetoothClientHandler bluetoothManager = new BluetoothClientHandler();
                bluetoothManager.ClientStart();
            });
            task.Start();
        }
    }
}

