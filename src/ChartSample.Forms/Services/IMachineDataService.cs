using System.ComponentModel;
using WinFormsMvvmSample.ViewModels;

namespace WinFormsMvvmSample.Services
{
    public interface IMachineDataService
    {
        BindingList<MainViewModelGrid> FindById(string id);
    }
}