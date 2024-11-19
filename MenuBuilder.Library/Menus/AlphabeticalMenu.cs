using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBuilder
{
    public class AlphabeticalMenu : IMenu
    {
        public string Title { get; private set; }
        public List<IMenuOption> Options { get; private set; }

        public AlphabeticalMenu(string title, List<IMenuOption> options)
        {
            Title = title;
            Options = options;
        }

        public void Display()
        {
            Console.WriteLine(Title);
            for (int i = 0; i < Options.Count; i++)
            {
                Console.WriteLine($"{(char)('A' + i)} - {Options[i].Label}");
            }
        }

        public void SelectOption(string input)
        {
            if (input.Length == 1 && char.IsLetter(input[0]))
            {
                int index = char.ToUpper(input[0]) - 'A';
                if (index >= 0 && index < Options.Count)
                {
                    Options[index].PerformAction();
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
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
