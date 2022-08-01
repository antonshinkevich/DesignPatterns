using MoreLinq;
using NUnit.Framework;

public class SingletonDatabase
{
    private Dictionary<string, int> capitals;
    private static int instanceCount;
    public static int Count => instanceCount;

    public SingletonDatabase()
    {
        capitals = File.ReadAllLines(
                Path.Combine(
                    new FileInfo(typeof(SingletonDatabase).Assembly.Location)
                        .DirectoryName,
                    "capitals.txt"))
            .Batch(2)
            .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
    }

    public int GetPopulation(string city)
    {
        return capitals[city];
    }

    private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
    {
        instanceCount++;
        return new SingletonDatabase();
    });

    public static SingletonDatabase Instance => instance.Value;
}

[TestFixture]
public class SingletonTexts
{
    [Test]
    public void IsSingletonTest()
    {
        var db = SingletonDatabase.Instance;
        var db2 = SingletonDatabase.Instance;
        Assert.That(db, Is.SameAs(db2));
        Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
    }
}
