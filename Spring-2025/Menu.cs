using System;
using System.Collections.Generic;

public class Menu
{
    private string title;
    private List<string> options;

    public Menu(string title, List<string> options)
    {
        this.title = title;
        this.options = options;
    }

    public int GetChoice()
    {
        Console.WriteLine($"\n--- {title} ---");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        Console.Write("Select (1, 2, 3 or 4) : ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= options.Count)
        {
            return choice;
        }
        return -1;
    }
}
