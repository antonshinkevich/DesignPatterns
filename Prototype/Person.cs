public class Person : ICloneable
{
    public string[] Names;
    public Address Address;

    public Person(string[] names, Address address)
    {
        Names = names;
        Address = address;
    }

    public override string ToString()
    {
        return $"{nameof(Names)}: {string.Join(' ', Names)}," +
               $" {nameof(Address)}: {Address}";
    }

    public object Clone()
    {
        return new Person(Names, (Address)Address.Clone());
    }
}

public class Address : ICloneable
{
    public string StreetName;
    public int HouseNumber;

    public Address(string streetName, int houseNumber)
    {
        StreetName = streetName;
        HouseNumber = houseNumber;
    }

    public override string ToString()
    {
        return $"{nameof(StreetName)} : {StreetName}, " +
               $"{nameof(HouseNumber)}: {HouseNumber}";
    }

    public object Clone()
    {
        return new Address(StreetName, HouseNumber);
    }
}

public class PersonCtorCopy
{
    public string[] Names;
    public AddressCtorCopy Address;

    public PersonCtorCopy(string[] names, AddressCtorCopy address)
    {
        Names = names;
        Address = address;
    }

    public PersonCtorCopy(PersonCtorCopy otherPerson)
    {
        Names = new string[otherPerson.Names.Length];
        Array.Copy(otherPerson.Names, Names, otherPerson.Names.Length);
        Address = new AddressCtorCopy(otherPerson.Address);
    }

    public override string ToString()
    {
        return $"{nameof(Names)}: {string.Join(' ', Names)}," +
               $" {nameof(Address)}: {Address}";
    }
}

public class AddressCtorCopy
{
    public string StreetName;
    public int HouseNumber;

    public AddressCtorCopy(string streetName, int houseNumber)
    {
        StreetName = streetName;
        HouseNumber = houseNumber;
    }

    public AddressCtorCopy(AddressCtorCopy otherPersonAddress)
    {
        StreetName = otherPersonAddress.StreetName;
        HouseNumber = otherPersonAddress.HouseNumber;
    }

    public override string ToString()
    {
        return $"{nameof(StreetName)} : {StreetName}, " +
               $"{nameof(HouseNumber)}: {HouseNumber}";
    }
}
