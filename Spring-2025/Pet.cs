using System;
using System.Threading.Tasks;

public class Pet
{
    public string Name { get; private set; }
    public PetType Type { get; private set; }
    public int Hunger { get; private set; } = 50;
    public int Sleep { get; private set; } = 50;
    public int Fun { get; private set; } = 50;

    public bool HasLeft { get; private set; } = false;

    public event Action<Pet> OnPetLeftHome;

    public Pet(string name, PetType type)
    {
        Name = name;
        Type = type;
    }

    public async void StartStatDecrease()
    {
        while (!HasLeft)
        {
            await Task.Delay(3000);

            DecreaseStat(PetStat.Hunger, 1);
            DecreaseStat(PetStat.Sleep, 1);
            DecreaseStat(PetStat.Fun, 1);

            if (Hunger <= 0 || Sleep <= 0 || Fun <= 0)
            {
                HasLeft = true;
                Console.WriteLine($"{Name} left home!");
                OnPetLeftHome?.Invoke(this);
            }
        }
    }

    public void DecreaseStat(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Hunger: Hunger = Math.Max(0, Hunger - amount); break;
            case PetStat.Sleep: Sleep = Math.Max(0, Sleep - amount); break;
            case PetStat.Fun: Fun = Math.Max(0, Fun - amount); break;
        }
    }

    public void IncreaseStat(PetStat stat, int amount)
    {
        switch (stat)
        {
            case PetStat.Hunger: Hunger = Math.Min(100, Hunger + amount); break;
            case PetStat.Sleep: Sleep = Math.Min(100, Sleep + amount); break;
            case PetStat.Fun: Fun = Math.Min(100, Fun + amount); break;
        }
    }
}
