namespace MenuBuilder
{
    public class NumericMenu : IMenu
    {
        public string Title { get; private set; }
        public List<IMenuOption> Options { get; private set; }

        public NumericMenu(string title, List<IMenuOption> options)
        {
            Title = title;
            Options = options;
        }

        public void Display()
        {
            Console.WriteLine(Title);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Options[i].Label}");
            }
        }

        public void SelectOption(string input)
        {
            if (int.TryParse(input, out int index) && index > 0 && index <= Options.Count)
            {
                Options[index - 1].PerformAction();
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        public void AddOption(IMenuOption option)
        {
            Options.Add(option);
        }
    }
}
