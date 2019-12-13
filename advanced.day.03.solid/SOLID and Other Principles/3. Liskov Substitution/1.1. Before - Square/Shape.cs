namespace LiskovSubstitutionSquareBefore
{
    public abstract class Shape
    {
        public abstract decimal Area { get; }
    }

    public class Program
    {
        public static void Main()
        {
            var someClass = new SomeClass();

            var res1 = someClass.SomeMethodUsedByOtherDev(new Rectangle());

            var res2 = someClass.SomeMethodUsedByOtherDev(new Square());
        }
    }

    public class SomeClass
    {
        public decimal SomeMethodUsedByOtherDev(Rectangle rectangle)
        {
            rectangle.Height = 100;

            rectangle.Width = 200;

            return rectangle.Area;
        }
    }
}
