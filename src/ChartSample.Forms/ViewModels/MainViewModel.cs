using System;
using System.ComponentModel;
using System.Windows.Forms;
using ChartSample.Forms.BindHelpers;
using WinFormsMvvmSample.Services;

namespace WinFormsMvvmSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessageService _messageService;
        private readonly IMachineDataService _machineDataService;

        public MainViewModel(IMessageService messageService, IMachineDataService machineDataService)
        {
            _messageService = messageService;
            _machineDataService = machineDataService;
        }
        public string MyTextBoxText { get; set; }

        private string _aaaATextBoxText = "";

        private DateTime _startDatePickerValue = DateTime.Today;
        private DateTime _endDatePickerValue = DateTime.Today;
        public BindingList<MainViewModelGrid> MachineDataGridSource { get; set; }
        = new BindingList<MainViewModelGrid>();

        public string AaaTextBoxText
        {
            get => _aaaATextBoxText;

            set => SetProperty(ref _aaaATextBoxText, value);
        }

        public DateTime StartDateTimeValue
        {
            get => _startDatePickerValue;
            set => SetProperty(ref _startDatePickerValue, value);
        }
        public DateTime EndDateTimeValue
        {
            get => _endDatePickerValue;
            set => SetProperty(ref _endDatePickerValue, value);
        }

        public void Update()
        {
            AaaTextBoxText = "AAA updated!";
            StartDateTimeValue = DateTime.Today;
            EndDateTimeValue = StartDateTimeValue.AddDays(1);
            MachineDataGridSource = _machineDataService.FindById(AaaTextBoxText);
        }

        public void Save()
        {
            if (_messageService.QuestionMessage("保存しますか?") != DialogResult.OK)
            {
                return;
            }

            AaaTextBoxText = "Saved!";
        }

    }
}