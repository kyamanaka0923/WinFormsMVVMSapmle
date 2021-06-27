using System.ComponentModel;
using WinFormsMvvmSample.ViewModels;

namespace WinFormsMvvmSample.Services
{
    public class MachineDataService : IMachineDataService
    {
        public BindingList<MainViewModelGrid> FindById(string id)
        {
            var machineDataDataGridSource = new BindingList<MainViewModelGrid>();
            machineDataDataGridSource.Add(new MainViewModelGrid("1", "aaa"));
            machineDataDataGridSource.Add(new MainViewModelGrid("2", "bbb"));
            machineDataDataGridSource.Add(new MainViewModelGrid("3", "ccc"));

            return machineDataDataGridSource;
        }
    }
}