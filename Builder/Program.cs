using Builder;

var words = new[] { "hello", "world" };
var builder = new HtmlBuilder("ul");
foreach (var word in words)
{
    builder.AddChild("li", word);
}

Console.WriteLine(builder.ToString());

// next example with fluent interface
var builder2 = new HtmlBuilder("ul");
builder2.AddChild("li", words[0]).AddChild("li", words[1]);

var builder3 = HtmlElement.Create("ul");
builder3.AddChild("li", "hello");
var element = builder3.Build();

HtmlElement element2 = HtmlElement.Create("ul").AddChild("li", "hello");
Console.WriteLine(element2);

// example with many builders
var pb = new PersonBuilder();
Person person = pb.Lives.At("123 Green Street").In("London").WithPostcode("SW12BC")
    .Works.At("Fabrickam").AsA("Engineer").Earning(123000);
Console.WriteLine(person + "\n\n");

// homework
var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
Console.WriteLine(cb);
