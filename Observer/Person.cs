namespace Observer;

public class Person
{
    public event EventHandler<FallsIllEventArgs> FallsIll;

    public void CatchACold()
    {
        FallsIll?.Invoke(this, new FallsIllEventArgs
        {
            Address = "123 London Road"
        });
    }
}

public class FallsIllEventArgs : EventArgs
{
    public string Address;
}
