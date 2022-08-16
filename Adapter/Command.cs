namespace Adapter;

public interface ICommand
{
    void Execute();
}

public class SaveCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Saving current file");
    }
}

public class OpenCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Opening file");
    }
}

public class Button
{
    private ICommand command;
    private string name;

    public Button(ICommand command, string name)
    {
        this.command = command;
        this.name = name;
    }

    public void Click()
    {
        command.Execute();
    }

    public void PrintMe()
    {
        Console.WriteLine($"I am a button called {name}");
    }
}

public class Editor
{
    public IEnumerable<Button> Buttons { get; }

    public Editor(IEnumerable<Button> buttons)
    {
        Buttons = buttons;
    }

    public void ClickAll()
    {
        foreach (var button in Buttons)
        {
            button.Click();
        }
    }
}
