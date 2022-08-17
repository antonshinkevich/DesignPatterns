namespace Decorator;

public interface ICreature
{
    public int Age { get; set; }
}

public interface IBird : ICreature
{
    new int Age { get; set; }
    void Fly();
}

public interface ILizard : ICreature
{
    void Crawl();
}

public class Bird : IBird
{
    public int Age { get; set; }

    public void Fly()
    {
        if (Age >= 10)
        {
            Console.WriteLine("I'm flying!");
        }
    }
}

public class Lizard : ILizard
{
    public int Age { get; set; }

    public void Crawl()
    {
        if (Age < 10)
        {
            Console.WriteLine("I'm crawling");
        }
    }
}

public class Dragon : IBird, ILizard
{
    private readonly IBird bird;
    private readonly ILizard lizard;

    public Dragon(IBird bird, ILizard lizard)
    {
        this.bird = bird;
        this.lizard = lizard;
    }

    public int Age
    {
        get => bird.Age;
        set => bird.Age = bird.Age = value;
    }

    public void Crawl()
    {
        lizard.Crawl();
    }

    public void Fly()
    {
        bird.Fly();
    }

    public void BreatheFire()
    {

    }
}
