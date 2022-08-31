namespace Proxy;

public class Creature
{
    private readonly Property<int> agility =
        new Property<int>(10, nameof(Agility));

    public int Agility
    {
        get => agility.Value;
        set => agility.Value = value;
    }

    public class Property<T> where T : new()
    {
        private T value;
        private readonly string name;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                Console.WriteLine($"Assigning {value} to {name}");
                this.value = value;
            }
        }

        public Property() : this(default(T))
        {

        }

        public Property(T value, string name = "")
        {
            this.value = value;
            this.name = name;
        }

        public static implicit operator T(Property<T> p)
        {
            return p.Value;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value);
        }
    }
}
