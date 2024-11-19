namespace MenuBuilder
{
    public interface IMenu
    {
        string Title { get; }
        List<IMenuOption> Options { get; }
        void Display();
        void SelectOption(string input);
        void AddOption(IMenuOption option);
    }
}
