using System.Text;

namespace ZooApp;

public abstract class Animal
{
    public string Name { get; }
    public int Age { get; }

    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract string Kind { get; }

    public abstract string MakeSound();

    public override string ToString()
    {
        return $"{Kind} {Name}, {Age} р. — {MakeSound()}";
    }
}

public class Lion : Animal
{
    public Lion(string name, int age)
        : base(name, age)
    {
    }

    public override string Kind => "Лев";

    public override string MakeSound()
    {
        return "Р-р-р!";
    }
}

public class Elephant : Animal
{
    public Elephant(string name, int age)
        : base(name, age)
    {
    }

    public override string Kind => "Слон";

    public override string MakeSound()
    {
        return "Ту-ру-ру!";
    }
}

public class Parrot : Animal
{
    public Parrot(string name, int age)
        : base(name, age)
    {
    }

    public override string Kind => "Папуга";

    public override string MakeSound()
    {
        return "Привіт!";
    }
}

public class Zoo
{
    public List<Animal> Animals { get; } = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }

    public int RemoveOlderThan(int maxAge)
    {
        return Animals.RemoveAll(animal => animal.Age > maxAge);
    }

    public void PrintAnimals()
    {
        if (Animals.Count == 0)
        {
            Console.WriteLine("Зоопарк порожній");
            return;
        }

        for (int i = 0; i < Animals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Animals[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Zoo zoo = new Zoo();
        zoo.AddAnimal(new Lion("Сімба", 12));
        zoo.AddAnimal(new Lion("Нала", 8));
        zoo.AddAnimal(new Elephant("Дамбо", 25));
        zoo.AddAnimal(new Elephant("Елла", 6));
        zoo.AddAnimal(new Parrot("Кеша", 3));
        zoo.AddAnimal(new Parrot("Ара", 15));

        Console.WriteLine("Усі тварини:");
        zoo.PrintAnimals();

        int n = 10;
        zoo.RemoveOlderThan(n);

        Console.WriteLine();
        Console.WriteLine($"Після видалення тварин старших за {n}:");
        zoo.PrintAnimals();
    }
}
