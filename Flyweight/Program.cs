using Flyweight;

// 1st example
var user = new User("Sam Smith");
var user2 = new User("Jane Smith");

Console.WriteLine(user.FullName);
Console.WriteLine(user2.FullName);
Console.WriteLine(User.CountOfStrings + "\n");

// 2nd example
var ft = new FormattedText("This is a brave new world");
ft.Capitalize(10, 15);
Console.WriteLine(ft);

var bft = new BetterFormattedText("This is a brave new world");
bft.GetRange(10, 15).Capitalize = true;
Console.WriteLine(bft);

// homework
var sentence = new Sentence("hello world");
sentence[1].Capitalize = true;
Console.WriteLine(sentence); // writes "hello WORLD"
