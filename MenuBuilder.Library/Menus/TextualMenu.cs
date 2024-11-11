using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBuilder
{
    public class TextualMenu : IMenu
    {
        public string Title { get; private set; }
        public List<IMenuOption> Options { get; private set; }

        public TextualMenu(string title, List<IMenuOption> options)
        {
            Title = title;
            Options = options;
        }

        public void Display()
        {
            Console.WriteLine(Title);
            foreach (var option in Options)
            {
                Console.WriteLine($"- {option.Label}");
            }
        }

        public void SelectOption(string input)
        {
            var selectedOption = Options.Find(option => option.Label.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (selectedOption != null)
            {
                selectedOption.PerformAction();
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
