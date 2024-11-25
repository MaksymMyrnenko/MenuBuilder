namespace MenuBuilder.Menus
{
    public class AlphabeticalMenu : Menu<char>
    {
        public AlphabeticalMenu(string title, List<IMenuOption> options)
            : base(title, options) { }

        public AlphabeticalMenu(string title, Func<List<IMenuOption>> optionsGenerator)
            : base(title, optionsGenerator) { }

        public override void DisplayOptions()
        {
            char letter = 'A';
            foreach (var option in Options)
            {
                Console.WriteLine($"{letter++}. {option.Label}");
            }
        }

        public override void SelectOption(string input)
        {
            if (input.Length == 1 && char.TryParse(input, out char optionLetter))
            {
                int index = optionLetter - 'A';
                if (index >= 0 && index < Options.Count)
                {
                    Options[index].PerformAction();
                    return;
                }
            }

            Console.WriteLine("Invalid option. Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
