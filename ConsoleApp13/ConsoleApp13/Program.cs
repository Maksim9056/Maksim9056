namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            double x;
            double y;
            double z;
            double sum;
            double REZ;
            double X = Convert.ToDouble(Console.ReadLine());
            double Y = Convert.ToDouble(Console.ReadLine());
            double Z = Convert.ToDouble(Console.ReadLine());

            sum = X + Y + Z;
            REZ = sum / sum;
            Console.WriteLine($"{REZ}");
        }
    }
}