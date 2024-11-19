namespace MenuBuilder
{
    public interface IMenuOption
    {
        string Label { get; }
        IAction Action { get; }
        IMenu SubMenu { get; }
        void PerformAction();
    }
}
