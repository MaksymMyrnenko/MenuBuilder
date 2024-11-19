using System;
using System.Collections.Generic;
using MenuBuilder.MenuOptions;
using MenuBuilder.Menus;

namespace MenuBuilder
{
    public class BuildMenu
    {
        public IMenu CreateMenu(MenuType menuType, string title, Func<List<IMenuOption>> optionsGenerator)
        {
            return menuType switch
            {
                MenuType.Numeric => new Menu<int>(title, optionsGenerator),
                MenuType.Alphabetical => new Menu<char>(title, optionsGenerator),
                MenuType.Textual => new Menu<string>(title, optionsGenerator),
                _ => throw new ArgumentException("Invalid menu type")
            };
        }

        public IMenuOption CreateMenuOption(string label, IAction action = null, IMenu subMenu = null)
        {
            return new MenuOption(label, action, subMenu);
        }
    }
}
