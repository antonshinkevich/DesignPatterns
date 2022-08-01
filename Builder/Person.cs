namespace Builder;

public class Person
{
    // address
    public string StreetAddres, Postcode, City;

    // employment info
    public string CompanyName, Position;
    public int AnnualIncome;

    public override string ToString()
    {
        return $"{nameof(StreetAddres)}: {StreetAddres}, " +
               $"{nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, " +
               $"{nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, " +
               $"{nameof(AnnualIncome)}: {AnnualIncome}";
    }
}

public class PersonBuilder
{
    protected Person person;

    public PersonBuilder()
    {
        person = new Person();
    }

    public PersonBuilder(Person person)
    {
        this.person = person;
    }

    public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

    public static implicit operator Person(PersonBuilder pb) => pb.person;
    public PersonJobBuilder Works => new PersonJobBuilder(person);
}

public class PersonAddressBuilder : PersonBuilder
{
    public PersonAddressBuilder(Person person) : base(person)
    {
    }

    public PersonAddressBuilder At(string streetAddress)
    {
        person.StreetAddres = streetAddress;
        return this;
    }

    public PersonAddressBuilder WithPostcode(string postcode)
    {
        person.Postcode = postcode;
        return this;
    }

    public PersonAddressBuilder In(string city)
    {
        person.City = city;
        return this;
    }
}

public class PersonJobBuilder : PersonBuilder
{
    public PersonJobBuilder(Person person) : base(person)
    {
    }

    public PersonJobBuilder At(string streetAddress)
    {
        person.CompanyName = streetAddress;
        return this;
    }

    public PersonJobBuilder AsA(string position)
    {
        person.Position = position;
        return this;
    }

    public PersonJobBuilder Earning(int annualIncome)
    {
        person.AnnualIncome = annualIncome;
        return this;
    }
}
