using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Threading;
using Castle.Core.Internal;
using ChartSample.Forms.BindHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WinFormsMvvmSample.Services;
using WinFormsMvvmSample.ViewModels;

namespace ChartSampleTests.ViewModelsTests
{
    [TestClass]
    public class MainViewModelTest
    {

        [TestMethod]
        public void SaveTest_OKが返却された時の動きを確認()
        {
            var messageServiceMock = new Mock<IMessageService>();
            var machineDataServiceMock = new Mock<IMachineDataService>();

            var viewModel = new MainViewModel(messageServiceMock.Object, machineDataServiceMock.Object, Dispatcher.CurrentDispatcher);

            messageServiceMock.Setup(x => x.QuestionMessage(It.IsAny<string>())).Returns(DialogResult.OK);

            viewModel.AaaTextBoxText.IsNullOrEmpty();

            viewModel.Save();

            viewModel.AaaTextBoxText.Is("Saved!");

        }

        [TestMethod]
        public void SaveTest_Cancelが返却された時の動きを確認()
        {
            var messageServiceMock = new Mock<IMessageService>();

            var machineDataServiceMock = new Mock<IMachineDataService>();

            var viewModel = new MainViewModel(messageServiceMock.Object, machineDataServiceMock.Object, Dispatcher.CurrentDispatcher);

            messageServiceMock.Setup(x => x.QuestionMessage(It.IsAny<string>())).Returns(DialogResult.Cancel);

            viewModel.AaaTextBoxText.IsNullOrEmpty();

            viewModel.Save();

            viewModel.AaaTextBoxText.Is("");

        }

        [TestMethod]
        public void UpdateTest()
        {
            var messageServiceMock = new Mock<IMessageService>();

            var machineDataServiceMock = new Mock<IMachineDataService>();

            var viewModel = new MainViewModel(messageServiceMock.Object, machineDataServiceMock.Object, Dispatcher.CurrentDispatcher);
            machineDataServiceMock.Setup(x => x.FindById(It.IsAny<string>())).Returns(
                new List<MainViewModelGrid>()
                {
                    new MainViewModelGrid("1", "aaa", false),
                    new MainViewModelGrid("2", "aaa", true),
                    new MainViewModelGrid("3", "ccc", false)
                }
            );

            viewModel.Update();

            viewModel.AaaTextBoxText.Is("AAA updated!");
            viewModel.MachineDataGridSource.Count.Is(3);


        }
        
    }
}