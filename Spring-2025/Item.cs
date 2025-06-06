using System;
using System.Threading.Tasks;

public class Item
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int Effect { get; set; } 
    public int Duration { get; set; } 

    public Item(string name, ItemType type, int effect, int duration)
    {
        Name = name;
        Type = type;
        Effect = effect;
        Duration = duration;
    }

    public async Task UseAsync(Pet pet, PetStat stat)
    {
        Console.WriteLine($"{Name} uses for {Duration} seconds ");
        await Task.Delay(Duration * 1000);
        pet.IncreaseStat(stat, Effect);
        Console.WriteLine($"{pet.Name}'s {stat} level increased by {Effect} ");
    }
}
