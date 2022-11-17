using System.Xml.Serialization;
using xml_;

namespace xml_
{
    using System;
    using System.Numerics;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    //public class Person
    //{
    //    //        public string Name { get; set; } = "Undefined";
        //        public int Age { get; set; }
        //        public string Пол { get; set;}


        //        public Person() { }
        //        public Person(string name, int age,string пол)
        //        {
        //            Name = name;
        //            Age = age;
        //            Пол= пол;
        //        }   public bool validateRespomse(char responsE)
        //        { 
        //     if (Char.ToUpper(responsE) != 'Y' && Char.ToUpper(responsE) != 'N')

        //                return true;
        //                return false;

        //}
        //    }
        //    }




        internal class Program
        {
            static void Main(string[] args)

            {

                Class1 person = new Class1();


                char responseE;

                Console.WriteLine("Сыграли бы вы в игру «камень-ножницы» (y или n)?");
                responseE = Convert.ToChar(Console.ReadLine());

                if (responseE == 'Y' || responseE == 'y')

                {

                    //person.Start();
                   

                }






            }
        }
    }

