namespace ChainOfResponsibility;

public class Creature
{
    public string Name;
    public int Attack, Defense;

    public Creature(string name, int attack, int defense)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
    }
}

public class CreatureModifier
{
    protected Creature creature;
    protected CreatureModifier next; // singly linked list

    public CreatureModifier(Creature creature)
    {
        this.creature = creature;
    }

    public void Add(CreatureModifier m)
    {
        if (next != null)
        {
            next.Add(m);
        }
        else
        {
            next = m;
        }
    }

    public virtual void Handle() => next?.Handle();
}

class DoubleAttackModifier : CreatureModifier
{
    public DoubleAttackModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
        Console.WriteLine($"Doubling {creature.Name}'s attack");
        creature.Attack *= 2;
        base.Handle();
    }
}

class IncreaseDefenseModifier : CreatureModifier
{
    public IncreaseDefenseModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
        if (creature.Attack <= 2)
        {
            Console.WriteLine($"Increasing {creature.Name}'s defense");
            creature.Defense++;
        }

        base.Handle();
    }
}

class NoBonusesModifier : CreatureModifier
{
    public NoBonusesModifier(Creature creature) : base(creature)
    {
    }

    public override void Handle()
    {
    }
}
