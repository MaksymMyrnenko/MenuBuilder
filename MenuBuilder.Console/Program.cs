using MenuBuilder.Menus;
using MenuBuilder.MenuActions;
using MenuBuilder.Library.Navigation;

namespace MenuBuilder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize FlowController
            var flowController = new FlowController();

            // Create the main Numerical Menu
            var mainMenu = new Menu<int>("Main Menu", () => new List<IMenuOption>
            {
                new MenuOption("Textual Menu From File", new NavigateAction(() =>
                    CreateFileMenu(flowController, "Textual Menu From File", @"C:\Code\MenuBuilder\MenuBuilder\Test_Menu_FIles"))),
                new MenuOption("Alphabetical Menu", new NavigateAction(() =>
                    CreateAlphabeticalMenu(flowController))),
                new MenuOption("Exit from the app", new ExitAction())
            });

            flowController.NavigateTo(mainMenu);

            // Start the app
            RunApp(flowController);
        }

        private static void RunApp(FlowController flowController)
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                flowController.CurrentMenu.Display();

                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                flowController.CurrentMenu.SelectOption(input);

                Console.WriteLine("Press Esc to exit or any key to continue...");
                key = Console.ReadKey(intercept: true).Key;
            } while (key != ConsoleKey.Escape);
        }

        private static void CreateFileMenu(FlowController flowController, string title, string folderPath)
        {
            var fileMenu = new Menu<string>(title, () =>
            {
                var options = new List<IMenuOption>();
                var files = Directory.GetFiles(folderPath);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    options.Add(new MenuOption(fileName, new MenuAction(() =>
                    {
                        Console.Clear();
                        Console.WriteLine($"Contents of {fileName}:\n");
                        Console.WriteLine(File.ReadAllText(file));
                        Console.WriteLine("\nPress any key to return to the file list...");
                        Console.ReadKey();
                    })));
                }
                options.Add(new MenuOption("Go back", new NavigateBackAction(flowController)));
                return options;
            });

            flowController.NavigateTo(fileMenu);
        }

        private static void CreateAlphabeticalMenu(FlowController flowController)
        {
            var alphabeticalMenu = new Menu<char>("Alphabetical Menu", () => new List<IMenuOption>
            {
                new MenuOption("Numerical Menu", new NavigateAction(() =>
                    CreateNumericalSubMenu(flowController))),
                new MenuOption("OptionPrintHello", new MenuAction(() =>
                {
                    Console.Clear();
                    Console.WriteLine("Hello");
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                })),
                new MenuOption("Go back", new NavigateBackAction(flowController))
            });

            flowController.NavigateTo(alphabeticalMenu);
        }

        private static void CreateNumericalSubMenu(FlowController flowController)
        {
            var random = new Random(); // Random number generator
            var numericalSubMenu = new Menu<int>("Numerical Submenu", () =>
            {
                var options = new List<IMenuOption>();

                // Dynamically generate options with random numbers
                for (int i = 1; i <= 3; i++) // For example, generate 3 random options
                {
                    var randomNumber = random.Next(1, 100); // Random number between 1 and 100
                    options.Add(new MenuOption($"Random Number: {randomNumber}", new MenuAction(() =>
                    {
                        Console.Clear();
                        Console.WriteLine($"You selected the random number: {randomNumber}");
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                    })));
                }

                options.Add(new MenuOption("Go back", new NavigateBackAction(flowController))); // Add "Go Back" option
                return options;
            });

            flowController.NavigateTo(numericalSubMenu); // Navigate to this menu
        }


        private static void PrintRandomNumber()
        {
            var random = new Random();
            Console.Clear();
            Console.WriteLine($"Random Number: {random.Next(1, 101)}");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}
