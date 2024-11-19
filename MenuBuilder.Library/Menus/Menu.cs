namespace MenuBuilder.Menus
{
    public class Menu<T> : IMenu
    {
        public string Title { get; }
        public Func<List<IMenuOption>> OptionsGenerator { get; }
        private List<IMenuOption> _options;

        public List<IMenuOption> Options => _options;

        public Menu(string title, Func<List<IMenuOption>> optionsGenerator)
        {
            Title = title;
            OptionsGenerator = optionsGenerator;
            _options = OptionsGenerator.Invoke();
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine(Title);

            if (typeof(T) == typeof(string))
            {
                foreach (var option in _options)
                {
                    Console.WriteLine(option.Label);
                }
            }
            else if (typeof(T) == typeof(char))
            {
                char letter = 'A';
                foreach (var option in _options)
                {
                    Console.WriteLine($"{letter++}. {option.Label}");
                }
            }
            else
            {
                int index = 1;
                foreach (var option in _options)
                {
                    Console.WriteLine($"{index++}. {option.Label}");
                }
            }
        }

        public void AddOption(IMenuOption option)
        {
            _options.Add(option);
        }

        public void SelectOption(string input)
        {
            if (typeof(T) == typeof(string))
            {
                var option = _options.Find(o => o.Label.Equals(input, StringComparison.OrdinalIgnoreCase));
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
            else if (typeof(T) == typeof(char))
            {
                if (input.Length == 1 && char.IsLetter(input[0]))
                {
                    int index = char.ToUpper(input[0]) - 'A';
                    if (index >= 0 && index < _options.Count)
                    {
                        _options[index].PerformAction();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Press any key to return to the menu...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
            else
            {
                if (int.TryParse(input, out int index) && index > 0 && index <= _options.Count)
                {
                    _options[index - 1].PerformAction();
                }
                else
                {
                    Console.WriteLine("Invalid option. Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}