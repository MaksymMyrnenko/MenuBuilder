namespace MenuBuilder.Menus
{
    public abstract class Menu<T> : IMenu
    {

        public string Title { get; }
        private readonly List<IMenuOption> _options;
        protected readonly Func<List<IMenuOption>> OptionsGenerator;
        protected List<IMenuOption> Options => _options;

        public Menu(string title, List<IMenuOption> options)
        {
            Title = title;
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public Menu(string title, Func<List<IMenuOption>> optionsGenerator)
        {
            Title = title;
            OptionsGenerator = optionsGenerator ?? throw new ArgumentNullException(nameof(optionsGenerator));
            _options = OptionsGenerator.Invoke();
        }

        public abstract void DisplayOptions();
        public abstract void SelectOption(string input);

        public void AddOption(IMenuOption option)
        {
            _options.Add(option);
        }
    }
}