namespace WinFormsMvvmSample.ViewModels
{
    public class MainViewModelGrid
    {
        public MainViewModelGrid(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; set; }
    }
}