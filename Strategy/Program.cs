using Strategy;


// 1st example (dynamic strategy)
var textProcessor = new TextProcessor();
textProcessor.SetOutFormat(OutputFormat.Markdown);
textProcessor.AppendList(new []{"foo", "bar", "bax"});
Console.WriteLine(textProcessor);

textProcessor.Clear();
textProcessor.SetOutFormat(OutputFormat.Html);
textProcessor.AppendList(new[] { "foo", "bar", "bax" });
Console.WriteLine(textProcessor);