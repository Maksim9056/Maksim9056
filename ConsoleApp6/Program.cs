namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Програма для вычесления обратной матрицы ");
            int a11;
            int a21;
            int a31;
            //1 РЯД
            int a12;
            int a22;
            int a32;
            //2 РЯД
            int a13;
            int a23;
            int a33;
            // 3РЯД 
            //int j;
            //int k;
            //int l;
            int rez1;
            int rez2;
            int rez3;
            int rez4;
            int rez5;
            int rez6;
            int all1;
            int all2;
            int finalresual;
            int тр1;
            Console.WriteLine("Ввидите числа  первой обратной матрицы 4 вертикальной СТРОКИ матрицы");
            a11 = Convert.ToInt32(Console.ReadLine());
            a21= Convert.ToInt32(Console.ReadLine()); // b = Convert.ToDouble(Console.ReadLine());
            a31 = Convert.ToInt32(Console.ReadLine());       //c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа второй вертикальной СТРОКИ  матрицы");
            a12 = Convert.ToInt32(Console.ReadLine());//d= Convert.ToDouble(Console.ReadLine());
            a22 = Convert.ToInt32(Console.ReadLine());
            a32 = Convert.ToInt32(Console.ReadLine()); //f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа ТРЕТИЙ строки вертикальной СТРОКИ  матрицы");
            a13 = Convert.ToInt32(Console.ReadLine());//g = Convert.ToDouble(Console.ReadLine());
            a23 = Convert.ToInt32(Console.ReadLine()); //h = Convert.ToDouble(Console.ReadLine());
            a33 = Convert.ToInt32(Console.ReadLine());
            rez1 = a11*a22*a33;
            Console.WriteLine($"1значения{rez1}");
            rez2 = a32*a13*a21;
            Console.WriteLine($"1значения{rez2}");
            rez3 = a12*a31*a23;
            Console.WriteLine($"1значения{rez3}");
            rez4 = a13*a22*a31;
            Console.WriteLine($"1значения{rez4}");
            rez5 = a23*a32*a11;
            Console.WriteLine($"1значения{rez5}");
            rez6 = a12*a21*a33;
            Console.WriteLine($"1значения{rez6}");
            all1 = rez1+rez2+rez3;
            Console.WriteLine($"1значения{all1}");
            all2 = rez4 + rez5 + rez6;
            Console.WriteLine($"1значения{all2}");
            finalresual = all1 - all2;
            Console.WriteLine($"РЕЗУЛЬТАТ {finalresual}");

        }
    }
}