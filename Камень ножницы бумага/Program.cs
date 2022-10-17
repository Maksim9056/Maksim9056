namespace тест
{
    internal class Program
    {
        public enum CheckUserWin
        {
            PlayerChoice = 0,

            computerChoice = 1,
        }

        abstract class Player
        {
            public abstract CheckUserWin Act();
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int i;
            i = rnd.Next(1);
           Console.WriteLine(i);


            


        }
    }
}