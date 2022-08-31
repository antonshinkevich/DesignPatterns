// First example

namespace Proxy;

public class Car : ICar
{
    public void Drive()
    {
        Console.WriteLine("Car being driven");
    }
}

public class CarProxy : ICar
{
    private Car car;
    private Driver driver;

    public CarProxy(Driver driver)
    {
        this.driver = driver;
        car = new Car();
    }

    public void Drive()
    {
        if (driver.Age >= 16)
        {
            car.Drive();
        }
        else
        {
            Console.WriteLine("Driver too young");
        }
    }
}

public class Driver
{
    public int Age { get; }

    public Driver(int age)
    {
        Age = age;
    }
}

public interface ICar
{
    public void Drive();
}