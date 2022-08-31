// Second example

namespace Proxy;

public interface IBitmap
{
    void Draw();
}

public class Bitmap : IBitmap
{
    private readonly string filename;
    public Bitmap(string filename)
    {
        this.filename = filename;
        Console.WriteLine($"Loading image from {filename}...");
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing image {filename}");
    }
}

public class LazyBitmap : IBitmap
{
    private readonly string filename;
    private Bitmap bitmap;

    public LazyBitmap(string filrename)
    {
        this.filename = filrename;
    }

    public void Draw()
    {
        if (bitmap == null)
        {
            bitmap = new Bitmap(filename);
        }

        bitmap.Draw();
    }
}
