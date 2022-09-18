namespace ConsoleApp111
{
    internal class Program1
    {
       
        
            static void Main(string[] args)
            {
                Console.WriteLine("Введите число для вычисления корня:"); // тут будет понятно что нужно ввести и для чего
                string input = Console.ReadLine(); // объявление и присваивание делаем в одной строке, так короче и проще

                if (double.TryParse(input, out double number)) // number используется дальше, как результат парсинга string -> double (не нужно еще раз делать парсинг Convert.ToInt32(a) и создавать ещё одну переменную)
                {
                    if (number >=- 0) // тут исправил на >=, т.к. корень 0 вычислить можно
                    {
                        double result = Math.Sqrt(number);
                        Console.WriteLine($"Квадратный корень числа {number} равен {result}"); // развёрнутый ответ 
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: корень отрицательного числа вычислить невозможно"); // так пользователю будет понятнее что не так
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка: {input} не является числом");
                }
            }





        }
        }
    

    

    

