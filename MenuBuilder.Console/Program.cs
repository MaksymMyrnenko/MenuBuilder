using MenuBuilder.MenuActions;
using MenuBuilder.Library.Navigation;
using MenuBuilder.Menus;

namespace MenuBuilder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var flowController = new FlowController();

            var mainMenu = new NumericMenu("Main Menu", new List<IMenuOption>
            {
                new MenuOption("Textual Menu From File", new NavigateAction(() =>
                    CreateFileMenu(flowController, "Textual Menu From File", @"C:\Code\MenuBuilder\MenuBuilder\Test_Menu_FIles"))),
                new MenuOption("Alphabetical Menu", new NavigateAction(() =>
                    CreateAlphabeticalMenu(flowController))),
                new MenuOption("Exit from the app", new ExitAction())
            });

            flowController.NavigateTo(mainMenu);

            RunApp(flowController);
        }

        private static void RunApp(FlowController flowController)
        {
            do
            {
                Console.Clear();
                flowController.CurrentMenu.DisplayOptions();

                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                flowController.CurrentMenu.SelectOption(input);
            } while (true);
        }

        private static void CreateFileMenu(FlowController flowController, string title, string folderPath)
        {
            var fileMenu = new TextualMenu(title, () =>
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
            var alphabeticalMenu = new AlphabeticalMenu("Alphabetical Menu", new List<IMenuOption>
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
            var random = new Random();
            var numericalSubMenu = new NumericMenu("Numerical Submenu", () =>
            {
                var options = new List<IMenuOption>();

                for (int i = 1; i <= 3; i++)
                {
                    var randomNumber = random.Next(1, 100);
                    options.Add(new MenuOption($"Random Number: {randomNumber}", new MenuAction(() =>
                    {
                        Console.Clear();
                        Console.WriteLine($"You selected the random number: {randomNumber}");
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                    })));
                }

                options.Add(new MenuOption("Go back", new NavigateBackAction(flowController)));
                return options;
            });

            flowController.NavigateTo(numericalSubMenu);
        }
    }
}