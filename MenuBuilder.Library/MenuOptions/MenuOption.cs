using MenuBuilder.Library.Navigation;

namespace MenuBuilder
{
    public class MenuOption : IMenuOption
    {
        private readonly FlowController _flowController;

        public string Label { get; private set; }
        public IAction Action { get; private set; }
        public IMenu SubMenu { get; private set; }

        public MenuOption(string label, IAction action, IMenu subMenu = null, FlowController flowController = null)
        {
            Label = label;
            Action = action;
            SubMenu = subMenu;
            _flowController = flowController;
        }

        public void PerformAction()
        {
            if (SubMenu != null && _flowController != null)
            {
                _flowController.NavigateTo(SubMenu);
            }
            else
            {
                Action?.Execute();
            }
        }
    }
}
