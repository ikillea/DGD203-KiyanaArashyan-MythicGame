using System;

/// <summary>
/// The Game class handles the introduction and serves as the starting point of the player's journey.
/// It transitions the player to the map for exploration and gameplay.
/// </summary>
public class Game
{
    /// <summary>
    /// Starts the game, provides an introduction, and transitions to the map.
    /// </summary>
    public void Start()
    {
        // Clear the console to ensure a clean display for the introduction
        Console.Clear();

        // Display a welcoming header for the game world
        Console.WriteLine("=====================================");
        Console.WriteLine("      Welcome to the World of Eldoria");
        Console.WriteLine("=====================================");

        // Provide a brief narrative about the game setting
        Console.WriteLine("The land of Eldoria is filled with mysteries, challenges, and treasures.");
        Console.WriteLine("Your adventure begins now. Step forward and discover its secrets!");
        Console.WriteLine();

        // Prompt the player to proceed
        Console.WriteLine("Press Enter to embark on your journey...");
        Console.ReadLine();

        // Initialize the game map for exploration
        Map gameMap = new Map();

        // Transition to the map to continue gameplay
        gameMap.LoadMap();
    }
}
