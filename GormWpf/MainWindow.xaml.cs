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
using GormLib.MessageNS;
using GormLibWpf;
using System.Net.Sockets;
using GormLibWpf.ViewModel;
using MahApps.Metro.Controls;

namespace GormWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new MainWindowViewModel();
            DataContext = _mainWindowViewModel;

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = _mainWindowViewModel.Title;
        }
    }
}
