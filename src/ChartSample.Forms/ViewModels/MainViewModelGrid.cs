using System.ComponentModel;

namespace WinFormsMvvmSample.ViewModels
{
    public class MainViewModelGrid
    {
        public MainViewModelGrid(string id, string name, bool selected)
        {
            Id = id;
            Name = name;
            Selected = selected;
        }

        [DisplayName("No.\naaa")]
        public string Id { get; }
        [DisplayName("名前")]
        public string Name { get;}
        [DisplayName("選択")]
        public bool Selected { get; set; }
    }
}