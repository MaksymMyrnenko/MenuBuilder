namespace MenuBuilder.Menus
{
    public class TextualMenu : Menu<string>
    {
        public TextualMenu(string title, List<IMenuOption> options)
            : base(title, options) { }

        public TextualMenu(string title, Func<List<IMenuOption>> optionsGenerator)
            : base(title, optionsGenerator) { }

        public override void DisplayOptions()
        {
            foreach (var option in Options)
            {
                Console.WriteLine(option.Label);
            }
        }

        public override void SelectOption(string input)
        {
            var option = Options.Find(o => o.Label.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (option != null)
            {
                option.PerformAction();
            }
            else
            {
                Console.WriteLine("Invalid option. Press any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
