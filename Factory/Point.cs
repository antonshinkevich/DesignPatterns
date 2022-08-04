namespace Factory;

public class Point
{
    private double x, y;

    // Private ctor
    private Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        // Fabric method
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}
