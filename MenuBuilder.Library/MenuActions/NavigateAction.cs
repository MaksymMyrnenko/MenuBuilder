using System;
using MenuBuilder;

namespace MenuBuilder.MenuActions
{
    public class NavigateAction : IAction
    {
        private readonly Action _navigateToMenu;

        public NavigateAction(Action navigateToMenu)
        {
            _navigateToMenu = navigateToMenu ?? throw new ArgumentNullException(nameof(navigateToMenu));
        }

        public void Execute()
        {
            _navigateToMenu.Invoke();
        }
    }
}
