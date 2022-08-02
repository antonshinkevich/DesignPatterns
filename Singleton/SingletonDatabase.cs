using MoreLinq;
using NUnit.Framework;

namespace Singleton;

public interface IDatabase
{
    int GetPopulation(string city);
}

public class SingletonDatabase : IDatabase
{
    private Dictionary<string, int> capitals;
    private static int instanceCount;
    public static int Count => instanceCount;

    private SingletonDatabase()
    {
        capitals = File.ReadAllLines(
                Path.Combine(
                    new FileInfo(typeof(SingletonDatabase).Assembly.Location)
                        .DirectoryName ?? string.Empty,
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

public class SingletonRecordFinder
{
    public int TotalPopulation(IEnumerable<string> names)
    {
        return names.Sum(name => SingletonDatabase.Instance.GetPopulation(name));
    }
}

public class ConfigurableRecordFinder
{
    private readonly IDatabase _database;

    public ConfigurableRecordFinder(IDatabase database)
    {
        _database = database;
    }

    public int TotalPopulation(IEnumerable<string> names)
    {
        return names.Sum(name => _database.GetPopulation(name));
    }
}

public class DummyDatabase : IDatabase
{
    public int GetPopulation(string city)
    {
        return new Dictionary<string, int>
        {
            ["alpha"] = 1,
            ["beta"] = 2,
            ["gamma"] = 3
        }[city];
    }
}

[TestFixture]
public class SingletonTests
{
    [Test]
    public void IsSingletonTest()
    {
        var db = SingletonDatabase.Instance;
        var db2 = SingletonDatabase.Instance;
        Assert.That(db, Is.SameAs(db2));
        Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
    }

    [Test]
    public void SingletonTotalPopulationTest() // not unit test actually
    {
        var rf = new SingletonRecordFinder();
        var names = new[] { "Tokyo", "Mexico City" };
        var tp = rf.TotalPopulation(names);
        Assert.That(tp, Is.EqualTo(37_435_191 + 21_671_908));
    }

    [Test]
    public void DependentTotalPopulationTest()
    {
        var db = new DummyDatabase();
        var rf = new ConfigurableRecordFinder(db);
        Assert.That(
            rf.TotalPopulation(new[] { "alpha", "gamma" }),
            Is.EqualTo(4));
    }
}
