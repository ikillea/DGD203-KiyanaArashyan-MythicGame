using System;

/// <summary>
/// The Program class serves as the entry point for the Mystic Explorer application.
/// It initializes the main menu and serves as the starting point of the game.
/// </summary>
class Program
{
    /// <summary>
    /// Main entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments (not used in this application).</param>
    static void Main(string[] args)
    {
        // Clear the console to ensure a clean display for the game
        Console.Clear();

        // Display a welcome banner for the game
        Console.WriteLine("=====================================");
        Console.WriteLine("       WELCOME TO MYSTIC EXPLORER    ");
        Console.WriteLine("=====================================\n");

        try
        {
            // Create an instance of the Menu class to display the main menu
            Menu mainMenu = new Menu();

            // Start the main menu interaction with the user
            mainMenu.ShowMenu();
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors during the game
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            // Display a closing message to the user after exiting the game
            Console.WriteLine("\nThank you for playing Mystic Explorer!");
        }
    }
}
