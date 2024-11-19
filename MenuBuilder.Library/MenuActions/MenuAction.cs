using MenuBuilder;

public class MenuAction : IAction
{
    private readonly Action _action;
    private readonly string _message;

    public MenuAction(Action action)
    {
        _action = action;
    }

    public MenuAction(string message)
    {
        _message = message;
        _action = () => Console.WriteLine(message);
    }

    public void Execute()
    {
        _action?.Invoke();
    }
}
