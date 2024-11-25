namespace MenuBuilder.Menus
{
    public class NumericMenu : Menu<int>
    {
        public NumericMenu(string title, List<IMenuOption> options)
            : base(title, options) { }

        public NumericMenu(string title, Func<List<IMenuOption>> optionsGenerator)
            : base(title, optionsGenerator) { }

        public override void DisplayOptions()
        {
            int index = 1;
            foreach (var option in Options)
            {
                Console.WriteLine($"{index++}. {option.Label}");
            }
        }

        public override void SelectOption(string input)
        {
            if (int.TryParse(input, out int optionNumber) && optionNumber >= 1 && optionNumber <= Options.Count)
            {
                Options[optionNumber - 1].PerformAction();
            }
            else
            {
                Console.WriteLine("Invalid option. Press any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
