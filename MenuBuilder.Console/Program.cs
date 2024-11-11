// See https://aka.ms/new-console-template for more information
using MenuBuilder;
using MenuBuilder.Library.Navigation;
using System.Reflection.Emit;


class Program
{
    static void Main()
    {
        var flowController = new FlowController();

        // Define the options for the main menu
        var mainMenuOptions = new List<IMenuOption>
        {
            CreateMenuOption("Create Numeric Menu", flowController, null, CreateSubMenu("Numeric", flowController)),
            CreateMenuOption("Create Alphabetical Menu", flowController, null, CreateSubMenu("Alphabetical", flowController)),
            CreateMenuOption("Create Textual Menu", flowController, null, CreateSubMenu("Textual", flowController)),
            CreateMenuOption("Exit", flowController, new MenuAction(() => Environment.Exit(0)))
        };

        // Create the main menu with custom options
        var mainMenu = new NumericMenu("Main Menu", mainMenuOptions);

        // Initialize the flow controller with the main menu
        flowController.NavigateTo(mainMenu);

        ConsoleKey key;
        do
        {
            Console.Write("Select an option (or press 'B' to go back): ");
            string input = Console.ReadLine();

            if (input.Equals("B", StringComparison.OrdinalIgnoreCase))
            {
                flowController.NavigateBack();
            }
            else
            {
                flowController.CurrentMenu.SelectOption(input);
            }

            Console.WriteLine("Press Esc to exit or any key to continue...");
            key = Console.ReadKey(intercept: true).Key;

        } while (key != ConsoleKey.Escape);
    }

    private static IMenuOption CreateMenuOption(string label, FlowController flowController, IAction action = null, IMenu subMenu = null)
    {
        return new MenuOption(label, action, subMenu, flowController);
    }

    private static IMenu CreateSubMenu(string menuType, FlowController flowController)
    {
        Console.WriteLine("Enter the name for Option 1:");
        string option1Name = Console.ReadLine();
        Console.WriteLine("Enter the name for Option 2:");
        string option2Name = Console.ReadLine();

        var options = new List<IMenuOption>
    {
        CreateMenuOption(option1Name, flowController, new MenuAction(() => Console.WriteLine($"{option1Name} selected"))),
        CreateMenuOption(option2Name, flowController, new MenuAction(() => Console.WriteLine($"{option2Name} selected"))),
        
        // Make sure to pass the correct menuType to create a new submenu of the same type
        CreateMenuOption("Create New Submenu", flowController, null, CreateNestedSubMenu(menuType, flowController)),

        CreateMenuOption("Go Back", flowController, new MenuAction(() => flowController.NavigateBack()))
    };

        return menuType switch
        {
            "Numeric" => new NumericMenu($"{menuType} Submenu", options),
            "Alphabetical" => new AlphabeticalMenu($"{menuType} Submenu", options),
            "Textual" => new TextualMenu($"{menuType} Submenu", options),
            _ => throw new ArgumentException("Invalid menu type")
        };
    }

    private static IMenu CreateNestedSubMenu(string menuType, FlowController flowController)
    {
        Console.WriteLine("Creating a new submenu:");
        Console.WriteLine("Enter the name for Option 1:");
        string option1Name = Console.ReadLine();
        Console.WriteLine("Enter the name for Option 2:");
        string option2Name = Console.ReadLine();

        var options = new List<IMenuOption>
    {
        CreateMenuOption(option1Name, flowController, new MenuAction(() => Console.WriteLine($"{option1Name} selected"))),
        CreateMenuOption(option2Name, flowController, new MenuAction(() => Console.WriteLine($"{option2Name} selected"))),
        CreateMenuOption("Go Back", flowController, new MenuAction(() => flowController.NavigateBack()))
    };

        // Use the menuType to create the correct type of nested submenu
        return menuType switch
        {
            "Numeric" => new NumericMenu($"{menuType} Nested Submenu", options),
            "Alphabetical" => new AlphabeticalMenu($"{menuType} Nested Submenu", options),
            "Textual" => new TextualMenu($"{menuType} Nested Submenu", options),
            _ => throw new ArgumentException("Invalid menu type")
        };
    }
}