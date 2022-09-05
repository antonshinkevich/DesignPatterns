State state = State.OffHook, exitState = State.OnHook;
var queue = new Queue<int>(new []{0,1,2,0,0});

do
{
    Console.WriteLine($"The phone is currently {state}");
    Console.WriteLine("Select a trigger:");

    for (int i = 0; i < Demo.Rules[state].Count; ++i)
    {
        var (t, _) = Demo.Rules[state][i];
        Console.WriteLine($"{i}. {t}");
    }

    var input = queue.Dequeue();
    Console.WriteLine(input);

    var (_, s) = Demo.Rules[state][input];
    state = s;
} while (state != exitState);

Console.WriteLine("We are done using the phone");
