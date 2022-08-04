namespace Factory;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PersonFactory
{
    private static int factoryId = 0;

    public Person CreatePerson(string name)
    {
        return new Person()
        {
            Name = name,
            Id = factoryId++,
        };
    }
}
