using System;
using System.Collections.Generic;
using MenuBuilder;

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
            Title = title ?? throw new ArgumentNullException(nameof(title));
            OptionsGenerator = optionsGenerator ?? throw new ArgumentNullException(nameof(optionsGenerator));
            _options = OptionsGenerator.Invoke() ?? new List<IMenuOption>();
        }

        public void Display()
        {
            Console.WriteLine($"\n{Title}");
            for (int i = 0; i < _options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_options[i].Label}");
            }
        }

        public void AddOption(IMenuOption option)
        {
            if (option == null) throw new ArgumentNullException(nameof(option));
            _options.Add(option);
        }

        public void RefreshOptions()
        {
            _options = OptionsGenerator.Invoke() ?? new List<IMenuOption>();
        }

        public void SelectOption(string input)
        {
            if (int.TryParse(input, out int index) && index >= 1 && index <= _options.Count)
            {
                _options[index - 1].PerformAction();
            }
            else
            {
                var option = _options.Find(o => o.Label.Equals(input, StringComparison.OrdinalIgnoreCase));
                if (option != null)
                {
                    option.PerformAction();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}
