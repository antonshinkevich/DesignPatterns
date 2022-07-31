[Serializable]
public class Employee
{
    public string Name;
    public AddressEmp Address;

    public Employee(string name, AddressEmp address)
    {
        Name = name;
        Address = address;
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}," +
               $"{nameof(Address)}: {Address}";
    }
}

[Serializable]
public class AddressEmp
{
    public string StreetAddress, City;
    public int Suite;

    public AddressEmp (string streetAddress, string city, int suite)
    {
        StreetAddress = streetAddress;
        City = city;
        Suite = suite;
    }

    public override string ToString()
    {
        return $"{nameof(StreetAddress)}: {StreetAddress}, " +
               $"{nameof(City)}: {City}, " +
               $"{nameof(Suite)}: {Suite}";
    }
}

public class EmployeeFactory
{
    private static Employee main =
        new Employee(null, new AddressEmp("123 East Dr", "London", 0));
    private static Employee aux =
        new Employee(null, new AddressEmp("321 West Dr", "Chicago", 0));

    private static Employee NewEmployee(Employee proto, string name, int suite)
    {
        var copy = proto.DeepCopy();
        copy.Name = name;
        copy.Address.Suite = suite;
        return copy;
    }

    public static Employee NewMainOfficEmployee
        (string name, int suite) => NewEmployee(main, name, suite);
    public static Employee NewAuxOfficEmployee
        (string name, int suite) => NewEmployee(aux, name, suite);
}
