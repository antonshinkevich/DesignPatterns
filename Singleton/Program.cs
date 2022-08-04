using Singleton;

var db = SingletonDatabase.Instance;
var city = "Tokyo";
Console.WriteLine($"{city} has population {db.GetPopulation(city)}");

// Multiton Pattern
var primary = Printer.Get(Subsystem.Main);
var backup = Printer.Get(Subsystem.Backup);
var primaty2 = Printer.Get(Subsystem.Main);
Console.WriteLine(ReferenceEquals(primary, primaty2));