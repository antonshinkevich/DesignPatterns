namespace Factory;

public interface IAsyncInit<T>
{
    Task<T> InitAsync();
}

public class Foo : IAsyncInit<Foo>
{
    public Foo()
    {
        // await Task.Delay(200);
    }

    public async Task<Foo> InitAsync()
    {
        await Task.Delay(200);
        return this;
    }

    public static async Task<Foo> CreateAsync()
    {
        var result = new Foo();
        return await result.InitAsync();
    }
}

public static class AsyncFactory
{
    public static async Task<T> Create<T>()
        where T : IAsyncInit<T>, new()
    {
        return await new T().InitAsync();
    }
}
