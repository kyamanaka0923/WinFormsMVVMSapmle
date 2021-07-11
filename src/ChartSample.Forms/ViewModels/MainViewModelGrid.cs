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

        public string Id { get; }
        public string Name { get;}
        public bool Selected { get; set; }
    }
}