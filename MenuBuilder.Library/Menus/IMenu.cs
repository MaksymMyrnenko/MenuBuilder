namespace MenuBuilder
{
    public interface IMenu
    {
        string Title { get; }
        void DisplayOptions();
        void SelectOption(string input);
        void AddOption(IMenuOption option);
    }
}
