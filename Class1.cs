using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Камень_ножницы_бумага4._1
{
    internal class Class1
    {
        public enum Hand
        {

            Rock = 1, Paper, Scissorc

        }
        public enum Outcome
        {
            Win, Lose, Tie
        }
        class УПРАВЛЕНИЕ
        {
            public Hand СomputerChoice { get; set; }
            public Hand PlayerChoice { get; set; }
            public char UserSelector { get; set; }


            public Hand getUserHand()
            {
                while (!validateSelection())
                    Console.Clear();
                Console.WriteLine("Invalid Inpit");
                Screen();
                UserSelector = Convert.ToChar(Console.ReadLine());
                {

                    switch (Char.ToUpper(UserSelector))
                    {
                        case 'R':
                            PlayerChoice = Hand.Rock;
                            break;
                        case 'P':
                            PlayerChoice = Hand.Paper;
                            break;
                        case 'S':
                            PlayerChoice = Hand.Scissorc;
                            break;
                        default:
                            throw new Exception("Unexpected");
                    }
                    return PlayerChoice;
                }

                  void PlayGame()
                {
                    bool gameOver = false;
                    var rand = new Random();
                    char responsE;
                    while (!gameOver)
                    {
                        Screen();

                        UserSelector = Convert.ToChar(Console.ReadLine());
                        getUserHand();
                        СomputerChoice = (Hand)rand.Next(1, 4);
                        Console.Clear();
                        Console.WriteLine(" Computer's Hand{0}", СomputerChoice);
                        Console.WriteLine("Player's Hand{0}", PlayerChoice);
                        if (DetermineWiner() == Outcome.Win)
                            Console.WriteLine("{0} beatse {1}. Player wins", PlayerChoice, СomputerChoice);
                        else if (DetermineWiner() == Outcome.Lose)

                            Console.WriteLine("{0} beatse {1}. Player wins", СomputerChoice, PlayerChoice);

                        else Console.WriteLine("it's a tie");
                        Console.WriteLine("\nWould you like to play another game (y or n)");
                        responsE = Convert.ToChar(Console.ReadLine());
                        while (validateRespomse(responsE) == false)
                        {
                            Console.WriteLine("Invalid input.Please re - enter you selection:");
                            responsE = Convert.ToChar(Console.ReadLine());
                        }
                    }

                    if (responsE == 'N' || responsE =='n')
                        gameOver = true;
                    Console.Clear();

                }
                   bool validateRespomse(char response)
                {
                    if (Char.ToUpper(response) != 'Y' && Char.ToUpper(response) != 'N')
                        return false;
                    return true;
                }
                 Outcome DetermineWiner()
                {

                    if (PlayerChoice == Hand.Scissorc && СomputerChoice == Hand.Paper)
                        return Outcome.Win;
                    else if (PlayerChoice == Hand.Rock && СomputerChoice == Hand.Scissorc)
                        return Outcome.Win;
                    else if (PlayerChoice == Hand.Paper && СomputerChoice == Hand.Rock)
                        return Outcome.Win;
                    else if (PlayerChoice == Hand.Scissorc && СomputerChoice == Hand.Rock)
                        return Outcome.Lose;
                    else if (PlayerChoice == Hand.Rock && СomputerChoice == Hand.Paper)
                        return Outcome.Lose;
                    else if (PlayerChoice == Hand.Paper && СomputerChoice == Hand.Scissorc)
                        return Outcome.Lose;
                    return Outcome.Tie;

                }
                  bool validateSelection()
                {
                    char value = Char.ToUpper(UserSelector);
                    if (value != 'R' && value != 'P' && value != 'S')
                        
                 return false;
                    return true;

                }

              //bool validateSelection()
              //  {
              //     char value = Char.ToUpper(UserSelector);
              //      if (value != 'R' && value != 'P' && value != 'S')
              //          return false;
              //      return true;
              //  }

                 void Screen()
                {
                    Console.WriteLine("r=Rock");
                    Console.WriteLine("P-Paper");
                    Console.WriteLine("S-Scissors");
                    Console.WriteLine("Please make your selection:");
                }

            }
        }
    } 
}
