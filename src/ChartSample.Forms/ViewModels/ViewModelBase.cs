using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace WinFormsMvvmSample.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Dispatcher Dispatcher { get; set; }

        protected bool SetProperty<T>(ref T field,
            T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            var h = this.PropertyChanged;
            if (h == null) return true;
            if (Dispatcher != null)
            {
                Dispatcher.Invoke(
                    () => h.Invoke(this, new PropertyChangedEventArgs(propertyName))
                );
            }
            else
            {
                h.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            return true;
        }

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
