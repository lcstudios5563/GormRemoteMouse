using GormLib;
using GormLib.LoggerNS;
using GormWpf.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GormWpf.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Properties
        private ObservableCollection<StatusUpdateViewModel> _statusUpdates = new ObservableCollection<StatusUpdateViewModel>();
        public ObservableCollection<StatusUpdateViewModel> StatusUpdates
        {
            get { return _statusUpdates; }
            set => Set(ref _statusUpdates, value);
        }

        private StartCommand _startCommand = new StartCommand();
        public StartCommand StartCommand
        {
            get { return _startCommand; }
            set => Set(ref _startCommand, value);
        }

        private StartClientCommand _startClientCommand = new StartClientCommand();
        public StartClientCommand StartClientCommand
        {
            get { return _startClientCommand; }
            set => Set(ref _startClientCommand, value);
        }

        public string Title = "Gorm " + Assembly.GetExecutingAssembly().GetName().Version;
        #endregion

        #region Constructor
        public MainWindowViewModel() {
            LogHelper lh = new LogHelper();
            LogHelper.OnlogTextReceived += (a, b) => UpdateStatusGrid(a, b);
        }
        #endregion

        #region Methods
        public void UpdateStatusGrid(string title, string description)
        {
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (EventHandler)delegate
            {
                //StatusUpdates.Add(new StatusUpdateViewModel
                //{
                //    Title = title,
                //    Description = description,
                //    DateTime = DateTime.Now
                //});
                StatusUpdates.Insert(0, new StatusUpdateViewModel
                {
                    Title = title,
                    Description = description,
                    DateTime = DateTime.Now
                });
                if (StatusUpdates.Count > 100)
                {
                    StatusUpdates.RemoveAt(100);
                }
            }, null, null);
        }
        #endregion

        #region NotifyPropertyChanged
        protected bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = "")
        {
            if (field == null || EqualityComparer<T>.Default.Equals(field, value)) { return false; }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
