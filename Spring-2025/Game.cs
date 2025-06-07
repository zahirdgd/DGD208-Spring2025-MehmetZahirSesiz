using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Game
{
    private List<Pet> pets = new List<Pet>();
    private List<Item> items = new List<Item>();
    private string playerName = "Mehmet Zahir SESIZ";
    private string studentNumber = "225040047";

    public Game()
    {
        InitializePets();
        InitializeItems();
    }

    public void Start()
    {
        while (true)
        {
            var menu = new Menu("Main Menu", new List<string>
            {
                "View Animals Status",
                "Use Item",
                "Creator Information",
                "Exit"
            });

            int choice = menu.GetChoice();
            switch (choice)
            {
                case 1: ShowPets(); break;
                case 2: UseItem(); break;
                case 3: ShowCreatorInfo(); break;
                case 4: return;
                default: Console.WriteLine("Invalid Selection!"); break;
            }
        }
    }

    private void InitializePets()
    {
        var cat = new Pet("Honda", PetType.Cat);
        var penguin = new Pet("Zai", PetType.Penguin);
        var rabbit = new Pet("Kivros", PetType.Rabbit);
        var dog = new Pet("Thomas", PetType.Dog);

        cat.OnPetLeftHome += PetLeftHome;
        penguin.OnPetLeftHome += PetLeftHome;
        rabbit.OnPetLeftHome += PetLeftHome;
        dog.OnPetLeftHome += PetLeftHome;

        pets.AddRange(new[] { cat, penguin, rabbit, dog });

        pets.ForEach(p => p.StartStatDecrease());
    }

    private void InitializeItems()
    {
        items.Add(new Item("Animal Food", ItemType.Food, 20, 2));
        items.Add(new Item("Ball", ItemType.Toy, 15, 1));
        items.Add(new Item("Bed", ItemType.Bed, 25, 3));
    }

    private void ShowPets()
    {
        if (!pets.Any())
        {
            Console.WriteLine("there are no animals left");
            return;
        }

        Console.WriteLine("--- PETS ---");
        foreach (var pet in pets)
        {
            Console.WriteLine($"{pet.Name} ({pet.Type}) | Hunger: {pet.Hunger}, Sleep: {pet.Sleep}, Fun: {pet.Fun}");
        }
    }

    private async void UseItem()
    {
        if (!pets.Any())
        {
            Console.WriteLine("there are no animals left");
            return;
        }

        Console.WriteLine("Which animal would you like to use the item for?");
        for (int i = 0; i < pets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pets[i].Name}");
        }
        if (int.TryParse(Console.ReadLine(), out int petChoice) && petChoice > 0 && petChoice <= pets.Count)
        {
            var pet = pets[petChoice - 1];

            Console.WriteLine("Items:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Name}");
            }

            if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= items.Count)
            {
                var item = items[itemChoice - 1];
                PetStat statToIncrease = DetermineStat(item.Type);
                await item.UseAsync(pet, statToIncrease);
            }
        }
    }

    private PetStat DetermineStat(ItemType type)
    {
        return type switch
        {
            ItemType.Food => PetStat.Hunger,
            ItemType.Bed => PetStat.Sleep,
            ItemType.Toy => PetStat.Fun,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void ShowCreatorInfo()
    {
        Console.WriteLine($"Creator: {playerName}, Student Number: {studentNumber}");
    }

    private void PetLeftHome(Pet pet)
    {
        pets.Remove(pet);
    }
}
