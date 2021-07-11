using System.Collections.Generic;
using System.ComponentModel;
using WinFormsMvvmSample.ViewModels;

namespace WinFormsMvvmSample.Services
{
    public interface IMachineDataService
    {
        IEnumerable<MainViewModelGrid> FindById(string id);
    }
}