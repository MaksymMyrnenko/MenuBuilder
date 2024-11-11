using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBuilder
{
    public class BuildMenu
    {
        public IMenu CreateMenu(string menuType, string title, List<IMenuOption> options)
        {
            return menuType switch
            {
                "Numeric" => new NumericMenu(title, options),
                "Alphabetical" => new AlphabeticalMenu(title, options),
                "Textual" => new TextualMenu(title, options),
                _ => throw new ArgumentException("Invalid menu type.")
            };
        }

        public IMenuOption CreateMenuOption(string label, IAction action, IMenu subMenu = null)
        {
            return new MenuOption(label, action, subMenu);
        }
    }
}
