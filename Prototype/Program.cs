var john = new Person(new[] { "John", "Smith"}, new Address("London Road", 123));
// var jane = john; not working for reference types
var jane = (Person)john.Clone();
jane.Names[0] = "Jane";
jane.Address.HouseNumber = 333;
Console.WriteLine(john);
Console.WriteLine(jane);

var john2 = new PersonCtorCopy(new[] { "John", "Smith" }, new AddressCtorCopy("London Road", 123));
var jane2 = new PersonCtorCopy(john2);
jane2.Names[0] = "Jane";
jane2.Address.HouseNumber = 333;
Console.WriteLine(john2);
Console.WriteLine(jane2);

// new class example (serialization)
Foo foo = new Foo
{
    Stuff = 42,
    Whatever = "abc",
    Bar = new Bar{ Value = 321 }
};

var foo2 = foo.DeepCopy();
foo2.Whatever = "xyz";
foo2.Bar.Value = 1000;

Console.WriteLine(foo);
Console.WriteLine(foo2);

var johnEmployee = EmployeeFactory.NewMainOfficEmployee("John", 123);
Console.WriteLine(johnEmployee);
