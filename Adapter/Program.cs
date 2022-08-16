using System.Security.Principal;
using System.Text;
using System.Xml.Serialization;
using Adapter;
using Autofac;
using Autofac.Features.Metadata;

var demo = new Demo();
demo.DrawPoints();
demo.DrawPoints();
Console.WriteLine("\n\n");

var stats = new CountryStats();
stats.Capitals.Add("France", "Paris");

var xs = new XmlSerializer(typeof(CountryStats));
var sb = new StringBuilder();
var sw = new StringWriter(sb);
xs.Serialize(sw, stats);

var newStats = (CountryStats)xs.Deserialize(
    new StringReader(sb.ToString()));
Console.WriteLine(newStats.Capitals["France"]);

// 3rd example
var b = new ContainerBuilder();
b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name", "Save");
b.RegisterAdapter<Meta<ICommand>, Button>(
    cmd => new Button(cmd.Value, (string) cmd.Metadata["Name"]));

b.RegisterType<Editor>();
using var c = b.Build();
var editor = c.Resolve<Editor>();
editor.ClickAll();

foreach (var btn in editor.Buttons)
{
    btn.PrintMe();
}

// homework
var square = new Square
{
    Side = 11
};

var rectangle = new SquareToRectangleAdapter(square);
Console.WriteLine(rectangle.Area());
