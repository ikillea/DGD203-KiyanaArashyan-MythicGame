using System;
using System.Collections.Generic;

/// <summary>
/// The Inventory class manages the player's items, supporting operations such as
/// adding, checking, displaying, saving, and loading items.
/// </summary>
public class Inventory
{
    // Private list to store the inventory items
    private List<string> items = new List<string>();

    /// <summary>
    /// Adds an item to the inventory and confirms the addition.
    /// </summary>
    /// <param name="item">The name of the item to be added.</param>
    public void AddItem(string item)
    {
        items.Add(item); // Add the item to the list

        // Confirm the addition to the player
        Console.WriteLine("========================================");
        Console.WriteLine($"   SUCCESS: '{item}' has been added to your inventory!");
        Console.WriteLine("========================================\n");
    }

    /// <summary>
    /// Checks if a specific item exists in the inventory.
    /// </summary>
    /// <param name="item">The name of the item to check.</param>
    /// <returns>True if the item exists, otherwise false.</returns>
    public bool HasItem(string item)
    {
        return items.Contains(item); // Check for item presence in the list
    }

    /// <summary>
    /// Displays all items currently in the inventory.
    /// </summary>
    public void ShowInventory()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("           PLAYER INVENTORY");
        Console.WriteLine("========================================");

        if (items.Count == 0) // Check if the inventory is empty
        {
            Console.WriteLine("Your inventory is currently empty.");
        }
        else
        {
            Console.WriteLine("You have the following items:");
            foreach (string item in items)
            {
                Console.WriteLine($" - {item}");
            }
        }

        Console.WriteLine("========================================\n");
    }

    /// <summary>
    /// Converts the inventory items into a comma-separated string for saving.
    /// </summary>
    /// <returns>A string containing all inventory items, separated by commas.</returns>
    public string GetInventoryAsString()
    {
        return string.Join(",", items); // Combine items into a single string
    }

    /// <summary>
    /// Loads inventory items from a comma-separated string.
    /// </summary>
    /// <param name="inventoryData">The string containing saved inventory items.</param>
    public void LoadInventoryFromString(string inventoryData)
    {
        if (!string.IsNullOrEmpty(inventoryData)) // Ensure the data is valid
        {
            items = new List<string>(inventoryData.Split(',')); // Split and load items
            Console.WriteLine("========================================");
            Console.WriteLine("   SUCCESS: Inventory has been loaded!");
            Console.WriteLine("========================================\n");
        }
    }

    /// <summary>
    /// Clears all items from the inventory.
    /// </summary>
    public void ClearInventory()
    {
        items.Clear(); // Remove all items from the list

        Console.WriteLine("========================================");
        Console.WriteLine("   NOTICE: Inventory has been cleared.");
        Console.WriteLine("========================================\n");
    }
}
