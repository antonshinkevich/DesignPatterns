using Decorator;

// 1st example
var cb = new CodeBuilder();
cb.AppendLine("class Foo")
    .AppendLine("{")
    .AppendLine("}");
Console.WriteLine(cb);

// 2nd example
var circle = new Circle(2);
Console.WriteLine(circle.AsString);
var redCircle = new ColorShape(circle, "red");
Console.WriteLine(redCircle.AsString);
var redTransparentCircle = new TransparentShape(redCircle, 0.5f);
Console.WriteLine(redTransparentCircle.AsString);