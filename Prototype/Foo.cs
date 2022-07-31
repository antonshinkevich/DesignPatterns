using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

[Serializable]
public class Foo
{
    public uint Stuff;
    public string Whatever;
    public Bar Bar;

    public override string ToString()
    {
        return $"{nameof(Stuff)}: {Stuff}, " +
               $"{nameof(Whatever)}: {Whatever}" + 
               $"{nameof(Bar)}: {Bar}";
    }
}

[Serializable]
public class Bar
{
    public uint Value;

    public override string ToString()
    {
        return $"{nameof(Value)}: {Value}";
    }
}

public static class ExtensionsMethods
{
    public static T DeepCopy<T>(this T self)
    {
        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            var copy = (T)formatter.Deserialize(stream);
            return copy;
        }
    }

    public static T DeepCopyXml<T>(this T self)
    {
        using (var ms = new MemoryStream())
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            s.Serialize(ms, self);
            ms.Position = 0;
            return (T)s.Deserialize(ms);
        }
    }
}
