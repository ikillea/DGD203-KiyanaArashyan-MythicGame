using System;
using System.Collections.Generic;

/// <summary>
/// The Map class handles navigation, location interactions, and game progress.
/// It manages visited locations, collected crystals, and the activation of the final device.
/// </summary>
public class Map
{
    private Inventory inventory = new Inventory(); // Player's inventory manager
    private SaveSystem saveSystem = new SaveSystem(); // Game save and load manager
    private HashSet<string> visitedLocations = new HashSet<string>(); // Tracks visited locations
    private HashSet<string> collectedCrystals = new HashSet<string>(); // Tracks collected crystals

    /// <summary>
    /// Displays the map menu and allows the player to explore locations.
    /// </summary>
    public void LoadMap()
    {
        bool exitToMenu = false;

        while (!exitToMenu) // Repeat until the player decides to return to the main menu
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("  Welcome to the Magical Land of Faeloria  ");
            Console.WriteLine("=====================================");

            // Display available locations based on progress
            if (!visitedLocations.Contains("Whispering Woods"))
                Console.WriteLine("1. Enter the Whispering Woods.");
            if (!visitedLocations.Contains("Obsidian Rift") || !collectedCrystals.Contains("Crystal of Shadow"))
                Console.WriteLine("2. Explore the Obsidian Rift.");
            if (!visitedLocations.Contains("Shimmering Lake") || !collectedCrystals.Contains("Crystal of Balance"))
                Console.WriteLine("3. Visit the Shimmering Lake.");
            Console.WriteLine("4. Activate the Eclipserion (Final Device).");
            Console.WriteLine("5. Show Inventory.");
            Console.WriteLine("6. Save Game.");
            Console.WriteLine("7. Load Game.");
            Console.WriteLine("8. Return to the Main Menu.");
            Console.Write("\nWhere would you like to go? ");

            string choice = Console.ReadLine(); // Read user input

            switch (choice)
            {
                case "1":
                    HandleLocation("Whispering Woods", WhisperingWoods);
                    break;
                case "2":
                    HandleLocation("Obsidian Rift", ObsidianRift);
                    break;
                case "3":
                    HandleLocation("Shimmering Lake", ShimmeringLake);
                    break;
                case "4":
                    ActivateEclipserion();
                    break;
                case "5":
                    inventory.ShowInventory();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                case "6":
                    SaveGame();
                    break;
                case "7":
                    LoadGame();
                    break;
                case "8":
                    exitToMenu = true;
                    Console.WriteLine("\nReturning to the main menu...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    /// <summary>
    /// Handles interactions with a specific location.
    /// </summary>
    private void HandleLocation(string locationName, Action locationAction)
    {
        if (visitedLocations.Contains(locationName))
        {
            Console.WriteLine($"You have already visited {locationName}. Nothing remains here.");
        }
        else
        {
            locationAction.Invoke();
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    /// <summary>
    /// Logic for exploring the Whispering Woods.
    /// </summary>
    private void WhisperingWoods()
    {
        Console.Clear();
        Console.WriteLine("*** Whispering Woods ***");
        Console.WriteLine("You step into the mystical Whispering Woods...");
        Console.WriteLine("The forest hums with life, its ancient secrets whispering through the trees.");
        Console.WriteLine("Deeper in, you find a locked chest with a riddle carved into it:");
        Console.WriteLine("\"I speak without a mouth and hear without ears. What am I?\"");
        Console.Write("\nYour answer: ");

        string answer = Console.ReadLine()?.ToLower();

        if (answer == "echo")
        {
            Console.WriteLine("\nThe chest opens, revealing the Crystal of Light!");
            inventory.AddItem("Crystal of Light");
            collectedCrystals.Add("Crystal of Light");
            visitedLocations.Add("Whispering Woods");
        }
        else
        {
            Console.WriteLine("\nThe chest remains locked. Perhaps you’ll try again later.");
        }
    }

    /// <summary>
    /// Logic for exploring the Obsidian Rift.
    /// </summary>
    private void ObsidianRift()
    {
        Console.Clear();
        Console.WriteLine("*** Obsidian Rift ***");
        Console.WriteLine("The canyon looms dark and foreboding...");
        Console.WriteLine("Kael, the dark guardian, blocks your way.");
        Console.Write("\nWill you fight him? (yes/no): ");

        string choice = Console.ReadLine()?.ToLower();

        if (choice == "yes")
        {
            Console.WriteLine("\nYou defeat Kael after a fierce battle!");
            Console.WriteLine("You retrieve the Crystal of Shadow.");
            inventory.AddItem("Crystal of Shadow");
            collectedCrystals.Add("Crystal of Shadow");
            visitedLocations.Add("Obsidian Rift");
        }
        else
        {
            Console.WriteLine("\nKael smirks and steps aside, daring you to return stronger.");
        }
    }

    /// <summary>
    /// Logic for exploring the Shimmering Lake.
    /// </summary>
    private void ShimmeringLake()
    {
        Console.Clear();
        Console.WriteLine("*** Shimmering Lake ***");
        Console.WriteLine("The lake glows under the moonlight...");
        Console.Write("\nDo you follow the glowing path? (yes/no): ");

        string choice = Console.ReadLine()?.ToLower();

        if (choice == "yes")
        {
            Console.WriteLine("\nYou find the Crystal of Balance at the end of the magical path.");
            inventory.AddItem("Crystal of Balance");
            collectedCrystals.Add("Crystal of Balance");
            visitedLocations.Add("Shimmering Lake");
        }
        else
        {
            Console.WriteLine("\nYou hesitate and decide to stay ashore.");
        }
    }

    /// <summary>
    /// Activates the final device, Eclipserion, and displays the victory message if all crystals are collected.
    /// </summary>
    private void ActivateEclipserion()
    {
        Console.Clear();
        Console.WriteLine("*** Eclipserion ***");
        Console.WriteLine("The ancient device glows faintly, awaiting the three crystals.");
        Console.WriteLine();

        // Check if all crystals are collected
        if (collectedCrystals.Contains("Crystal of Light") &&
            collectedCrystals.Contains("Crystal of Shadow") &&
            collectedCrystals.Contains("Crystal of Balance"))
        {
            Console.WriteLine("You place the crystals into the device...");
            Console.WriteLine("The device hums, glowing brightly as it restores balance to Faeloria.");
            Console.WriteLine();

            // Eye-catching victory message
            Console.WriteLine("===============================================");
            Console.WriteLine("             CONGRATULATIONS!                 ");
            Console.WriteLine("    YOU HAVE RESTORED BALANCE TO FAELORIA!    ");
            Console.WriteLine("===============================================");
            Console.WriteLine("     Thank you for playing Mystic Explorer!   ");
            Console.WriteLine("===============================================");
            Console.WriteLine();

            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("You do not have all the required crystals.");
            Console.WriteLine("Return when you have collected Light, Shadow, and Balance.");
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Saves the current game state.
    /// </summary>
    private void SaveGame()
    {
        saveSystem.SaveGame(
            "Map",
            inventory.GetInventoryAsString(),
            string.Join(",", collectedCrystals),
            string.Join(",", visitedLocations)
        );
        Console.WriteLine("\nGame saved successfully. Press Enter to continue...");
        Console.ReadLine();
    }

    /// <summary>
    /// Loads a previously saved game state.
    /// </summary>
    private void LoadGame()
    {
        var (location, savedInventory, savedCrystals, savedLocations) = saveSystem.LoadGame();

        if (location != null && savedInventory != null)
        {
            inventory.LoadInventoryFromString(savedInventory);
            collectedCrystals = new HashSet<string>(savedCrystals?.Split(',') ?? Array.Empty<string>());
            visitedLocations = new HashSet<string>(savedLocations?.Split(',') ?? Array.Empty<string>());
            Console.WriteLine("\nGame loaded successfully. Press Enter to continue...");
        }
        else
        {
            Console.WriteLine("\nNo save file found. Press Enter to continue...");
        }
        Console.ReadLine();
    }
}
