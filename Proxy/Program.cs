using Proxy;

// First example
ICar car = new CarProxy(new Driver(12));
car.Drive();
Console.WriteLine('\n');

// Second example
static void DrawImage(Bitmap img)
{
    Console.WriteLine("About to draw image");
    img.Draw();
    Console.WriteLine("Done drawing image");
}

var img = new Bitmap("paint.bmp");
DrawImage(img);

// Third example
var c = new Creature();
c.Agility = 12;
int n = c.Agility;