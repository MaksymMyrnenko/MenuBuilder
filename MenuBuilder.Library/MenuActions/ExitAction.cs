namespace MenuBuilder.MenuActions
{
    public class ExitAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Exiting the application...");
            Environment.Exit(0);
            
        }
    }
}
