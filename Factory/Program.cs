using Factory;

var point = Point.PointFactory.NewCartesianPoint(-1.4,3.2);
await Method();

// Async fabrics
async Task Method()
{
    var foo = new Foo();
    await foo.InitAsync();

    var foo2 = await Foo.CreateAsync();

    var foo3 = AsyncFactory.Create<Foo>();
}
