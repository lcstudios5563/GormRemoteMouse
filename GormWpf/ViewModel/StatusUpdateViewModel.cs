using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GormLibWpf.ViewModel
{
    public class StatusUpdateViewModel : INotifyPropertyChanged
    {
        private string _title;
        private DateTime _dateTime;
        private string _description;

        public string Title
        {
            get { return _title; }
            set => Set(ref _title, value);
        }

        public DateTime DateTime
        {
            get { return _dateTime; }
            set => Set(ref _dateTime, value);
        }

        public string Description
        {
            get { return _description; }
            set => Set(ref _description, value);
        }

        #region NotifyPropertyChanged
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) { return false; }
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
