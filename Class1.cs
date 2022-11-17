using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace xml_
{
    internal class Class1
    {
        public string Name { get; set; } = "Undefined";
        public int Age { get; set; }
        public string Пол { get; set; }


        public Class1() { }
        public Class1(string name, int age, string пол)
        {
            Name = name;
            Age = age;
            Пол = пол;
        }
        public bool validateRespomse(char responsE)
        {
            if (Char.ToUpper(responsE) != 'Y' && Char.ToUpper(responsE) != 'N')

                return true;
            return false;
        }

        public void Start()
        {
            Class1 person = new Class1();
            Console.WriteLine("Ввидите имя");
            person.Name = Console.ReadLine();
            Console.WriteLine("Ввидите возраст");
            person.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("M ИЛИ Ж");
            person.Пол = Console.ReadLine();
            if (person.Пол == "М" || person.Пол == "Ж")
                Console.WriteLine($"Пол:{person.Пол}");
            else
                Console.WriteLine($"{person.Пол} не выбран повторите снова");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Class1));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {

                xmlSerializer.Serialize(fs, person);
                Console.WriteLine("Объект церилизирован");

            }
            FileInfo.ReferenceEquals(xmlSerializer, person);

            //Console.WriteLine(FileInfo.ReferenceEquals);



        }

    }
    
}
