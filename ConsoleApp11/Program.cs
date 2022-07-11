namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // задание 1


            Console.WriteLine("Введите квардрат корень числа");
            double i;
            string a;
            a = Console.ReadLine();
            if (int.TryParse(a, out int number))
            { i = Convert.ToInt32(a);


                if (i > 0)
                {
                    double s = Math.Sqrt(i);
                    Console.WriteLine(s);
                }
                else
                {
                    Console.WriteLine("Ошибка невозможно вычислить корень");
                }

            }
            else 
            { Console.WriteLine("Ошибка введено не число"); }

           
           
        }
    }
}