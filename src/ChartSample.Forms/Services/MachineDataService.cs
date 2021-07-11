using System.Collections.Generic;
using System.ComponentModel;
using WinFormsMvvmSample.ViewModels;

namespace WinFormsMvvmSample.Services
{
    public class MachineDataService : IMachineDataService
    {
        public IEnumerable<MainViewModelGrid> FindById(string id)
        {
            var machineDataDataGridSource = new List<MainViewModelGrid>
            {
                new MainViewModelGrid("1", "aaa", true),
                new MainViewModelGrid("2", "bbb", false),
                new MainViewModelGrid("3", "ccc", false)
            };

            return machineDataDataGridSource;
        }
    }
}