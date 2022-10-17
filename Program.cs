namespace Камень_ножницы_бумага_игра
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int CheckUserWin = random.Next(3);
            int computerChoice = CheckUserWin;
            Console.WriteLine(computerChoice);
            Console.WriteLine("1.Камень");
            Console.WriteLine("2.Ножницы");
            Console.WriteLine("3.Бумага");
            Console.Write("Ваш выбор? — ");
            string Using = Console.ReadLine();

            if (int.TryParse(Using, out int Player))


                Console.WriteLine($"Прошло проверку на число {Using} !");

            else

                Console.WriteLine($"Ошибка {Using} не является числом !");
            
            
            Console.WriteLine($" Компьютер:{computerChoice}");
            Console.Write($"Игрок:{Player}");
            Console.WriteLine();
           
            switch (Player)
            {
                case 1:
                    Console.WriteLine($"Камень против ", computerChoice);

                    if (Player == Player && computerChoice == computerChoice)
                        Console.WriteLine("Ты победил");
                    else if (Player == Player && computerChoice == computerChoice)
                    Console.WriteLine("Ты проиграл");
                    else
                        Console.WriteLine("Ничья");
               
                    break;
                case 2:
                    Console.WriteLine($"Ножницы против ", computerChoice);

                    if (Player != Player && computerChoice == computerChoice)
                        Console.WriteLine("Ты победил");
                    else if (Player != Player && computerChoice == computerChoice)
                        Console.WriteLine("Ты проиграл");
                    else
                        Console.WriteLine("Ничья");
                 

                    break;
                case 3:
                    Console.WriteLine($" Бумага против", computerChoice);

                    if (Player != Player && computerChoice == computerChoice)
                        Console.WriteLine("Ты победил");
                    else if (Player != Player && computerChoice == computerChoice)
                        Console.WriteLine("Ты проиграл");
                    else
                        Console.WriteLine("Ничья");
                     

                    break;
            }
    }
}
    }