using System;

/// <summary>
/// The Menu class manages the main menu of the game,
/// allowing players to start a new game, view credits, or exit the application.
/// </summary>
public class Menu
{
    /// <summary>
    /// Displays the main menu to the player and processes their input.
    /// </summary>
    public void ShowMenu()
    {
        while (true) // Keep the menu running until the player chooses to exit
        {
            // Clear the console for a fresh display
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("       Welcome to Mystic Explorer!   ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Start a New Game");
            Console.WriteLine("2. View Credits");
            Console.WriteLine("3. Exit");
            Console.Write("\nEnter your choice: "); // Prompt the player for input

            // Read the player's choice
            string choice = Console.ReadLine();

            // Process the player's choice
            switch (choice)
            {
                case "1":
                    StartNewGame(); // Start a new game
                    break;
                case "2":
                    ShowCredits(); // Display credits
                    break;
                case "3":
                    ExitGame(); // Exit the game
                    return; // Exit the menu loop
                default:
                    Console.WriteLine("\nInvalid choice. Press Enter to try again."); // Handle invalid input
                    Console.ReadLine();
                    break;
            }
        }
    }

    /// <summary>
    /// Initializes and starts a new game session.
    /// </summary>
    private void StartNewGame()
    {
        Console.Clear();
        Console.WriteLine("Initializing a new game...");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        // Create an instance of the Game class and start the game
        Game newGame = new Game();
        newGame.Start();
    }

    /// <summary>
    /// Displays the credits, acknowledging contributors and resources.
    /// </summary>
    private void ShowCredits()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine("           Mystic Explorer           ");
        Console.WriteLine("=====================================");
        Console.WriteLine("Developed by: Kiyana Arashyan");
        Console.WriteLine("Special thanks to:");
        Console.WriteLine("- DGD203 Class");
        Console.WriteLine("- ChatGPT (used as a debugging and brainstorming tool)");
        Console.WriteLine("\nPress Enter to return to the main menu.");
        Console.ReadLine(); // Wait for the player to return
    }

    /// <summary>
    /// Exits the game with a farewell message.
    /// </summary>
    private void ExitGame()
    {
        Console.Clear();
        Console.WriteLine("=====================================");
        Console.WriteLine("        Thank you for playing!       ");
        Console.WriteLine("        Goodbye and see you soon!    ");
        Console.WriteLine("=====================================");
        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();

        // Exit the application gracefully
        Environment.Exit(0);
    }
}
