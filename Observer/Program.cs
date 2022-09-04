using Observer;

// First example
var person = new Person();
person.FallsIll += PersonFallsIll;
person.CatchACold();
person.FallsIll -= PersonFallsIll;

static void PersonFallsIll(object? sender, FallsIllEventArgs e)
{
    Console.WriteLine($"Call a doctor to {e.Address}");
}
