using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinFormsMvvmSample.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field,
            T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            var h = this.PropertyChanged;
            h?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
