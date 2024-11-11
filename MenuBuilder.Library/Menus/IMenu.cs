using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBuilder
{
    public interface IMenu
    {
        string Title { get; }
        List<IMenuOption> Options { get; }
        void Display();
        void SelectOption(string input);
    }
}
