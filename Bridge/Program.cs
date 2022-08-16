using Autofac;

// 1st example
var raster = new RasterRenderer();
var vector = new VectorRenderer();
var circle = new Circle(raster, 5);
circle.Draw();
circle.Resize(3);
circle.Draw();

// with dependency injection
var cb = new ContainerBuilder();
cb.RegisterType<VectorRenderer>().As<IRenderer>();
cb.Register((c, p) => new Circle(
    c.Resolve<IRenderer>(),
    p.Positional<float>(0)));

using (var c = cb.Build())
{
    var circle2 = c.Resolve<Circle>(
        new PositionalParameter(0, 5.0f)
        );
    circle2.Draw();
    circle2.Resize(3);
    circle2.Draw();
}
