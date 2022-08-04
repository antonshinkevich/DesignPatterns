namespace Singleton;

public enum Subsystem
{
    Main, Backup
}

public class Printer
{
    private Printer()
    {

    }

    public static Printer Get(Subsystem ss)
    {
        if (instances.ContainsKey(ss))
        {
            return instances[ss];
        }

        var instance = new Printer();
        instances[ss] = instance;
        return instance;
    }

    private static readonly Dictionary<Subsystem, Printer> instances = new Dictionary<Subsystem, Printer>();
}
