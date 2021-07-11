using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using System.Windows.Threading;
using WinFormsMvvmSample.ViewModels;

namespace ChartSample.Forms.BindHelpers
{
    public sealed class BindingListAsync<T> : BindingList<T>
    {
        private readonly Dispatcher _dispatcher;

        public BindingListAsync(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            _dispatcher.Invoke( () => base.OnListChanged(e));
        }

        public void Reset(IEnumerable<T> dataList)
        {
            this.Clear();
            foreach (var data in dataList)
            {
                this.Add(data);
            }
        }
    }
}