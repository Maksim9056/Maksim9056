namespace Камень_ножницы_бумага4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var player = new Class1();
            char responsee;
            Console.WriteLine("Would uou to play game of rock,scisorse (y or n)?");
            responsee = Convert.ToChar(Console.ReadLine());  

            while(player.validateSelection(responsee)== false)
                    {
                Console.WriteLine("Invalid Input . Please re-enter your selection ");
                responsee=Convert.ToChar(Console.ReadLine());
                if (responsee == 'Y' ||| responsee == 'y')
                {
                    Console.Clear();
                 
                    Console.WriteLine("God bay");
                    Console.ReadLine();
                }
            }
        }
    }
}