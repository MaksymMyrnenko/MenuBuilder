using MenuBuilder.Library.Navigation;

namespace MenuBuilder.MenuActions
{
    public class NavigateBackAction : IAction
    {
        private readonly FlowController _flowController;

        public NavigateBackAction(FlowController flowController)
        {
            _flowController = flowController;
        }

        public void Execute()
        {
            _flowController.NavigateBack();
        }
    }
}
