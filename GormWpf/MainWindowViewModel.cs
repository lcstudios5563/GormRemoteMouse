using GormLib;
using GormLibWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GormLibWpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StatusUpdate> _statusUpdates = new ObservableCollection<StatusUpdate>();
        public ObservableCollection<StatusUpdate> StatusUpdates
        {
            get { return _statusUpdates; }
            set => Set(ref _statusUpdates, value);
        }

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
                StatusUpdates.Add(new Model.StatusUpdate
                {
                    Title = title,
                    Description = description,
                    DateTime = DateTime.Now
                });

                if (StatusUpdates.Count > 100)
                {
                    StatusUpdates.RemoveAt(0);
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
