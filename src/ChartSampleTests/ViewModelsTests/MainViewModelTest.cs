using System.Runtime.InteropServices;
using System.Windows.Forms;
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

            var viewModel = new MainViewModel(messageServiceMock.Object, machineDataServiceMock.Object);

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

            var viewModel = new MainViewModel(messageServiceMock.Object, machineDataServiceMock.Object);

            messageServiceMock.Setup(x => x.QuestionMessage(It.IsAny<string>())).Returns(DialogResult.Cancel);

            viewModel.AaaTextBoxText.IsNullOrEmpty();

            viewModel.Save();

            viewModel.AaaTextBoxText.Is("");

        }
        
    }
}