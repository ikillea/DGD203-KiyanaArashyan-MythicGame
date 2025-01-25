using System;
using System.IO;

public class SaveSystem
{
    // Define the path for the save file
    private const string SaveFilePath = "savefile.txt";

    /// <summary>
    /// Saves the current game state to a file.
    /// </summary>
    /// <param name="currentLocation">The current location of the player in the game.</param>
    /// <param name="inventory">The player's current inventory as a string.</param>
    /// <param name="collectedCrystals">The crystals collected by the player.</param>
    /// <param name="visitedLocations">The locations visited by the player.</param>
    public void SaveGame(string currentLocation, string inventory, string collectedCrystals, string visitedLocations)
    {
        try
        {
            // Open a file for writing and save the game state
            using (StreamWriter writer = new StreamWriter(SaveFilePath))
            {
                writer.WriteLine(currentLocation);       // Save the current location
                writer.WriteLine(inventory);            // Save the inventory
                writer.WriteLine(collectedCrystals);    // Save collected crystals
                writer.WriteLine(visitedLocations);     // Save visited locations
            }
            Console.WriteLine("Game saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the game: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads the saved game state from a file.
    /// </summary>
    /// <returns>
    /// A tuple containing the current location, inventory, collected crystals, and visited locations.
    /// Returns null values if the save file is not found.
    /// </returns>
    public (string currentLocation, string inventory, string collectedCrystals, string visitedLocations) LoadGame()
    {
        if (!File.Exists(SaveFilePath))
        {
            Console.WriteLine("No save file found. Please start a new game.");
            return (null, null, null, null);
        }

        try
        {
            // Open the save file for reading and load the game state
            using (StreamReader reader = new StreamReader(SaveFilePath))
            {
                string currentLocation = reader.ReadLine();     // Read the current location
                string inventory = reader.ReadLine();          // Read the inventory
                string collectedCrystals = reader.ReadLine();  // Read collected crystals
                string visitedLocations = reader.ReadLine();   // Read visited locations

                Console.WriteLine("Game loaded successfully.");
                return (currentLocation, inventory, collectedCrystals, visitedLocations);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the game: {ex.Message}");
            return (null, null, null, null);
        }
    }
}
