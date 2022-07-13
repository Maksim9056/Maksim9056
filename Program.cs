namespace ConsoleApp11
{
    internal class Program1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите число для вычисления корня:");

            string input = Console.ReadLine();

            if (double.TryParse(input, out double number))
            {
                {


                }
                if (number >= 0)
                {
                    double result = Math.Sqrt(number);
                    Console.WriteLine($"Квадратный корень числа {number} равен {result}");

                }
                else

                {
                    Console.WriteLine("Ошибка: корень отрицательного числа вычислить невозможно");

                }
            }
            else
            {
                Console.WriteLine($"Ошибка: {input} не является числом");
            }
        }
    }
}