namespace МАТРИЦА_4_НА_4_БЕЗ_ПЛАВУЮЩЕЙ_ТОЧКИ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Програма для вычесления обратной матрицы ");
            int a;
            int b;
            int c;
            //1 РЯД
            int d;
            int e;
            int f;
            //2 РЯД
            int g;
            int h;
            int i;
            // 3РЯД 
            int j;
            int k;
            int l;
            int resua;
            int resua2;
            int finalresual;
            int тр1;
            Console.WriteLine("Ввидите числа  первой обратной матрицы 4 вертикальной СТРОКИ матрицы");
            a = Convert.ToInt32(Console.ReadLine());
            d = Convert.ToInt32(Console.ReadLine()); // b = Convert.ToDouble(Console.ReadLine());
            g = Convert.ToInt32(Console.ReadLine());       //c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа второй вертикальной СТРОКИ  матрицы");
            b = Convert.ToInt32(Console.ReadLine());//d= Convert.ToDouble(Console.ReadLine());
            e = Convert.ToInt32(Console.ReadLine());
            h = Convert.ToInt32(Console.ReadLine()); //f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа ТРЕТИЙ строки вертикальной СТРОКИ  матрицы");
            c = Convert.ToInt32(Console.ReadLine());//g = Convert.ToDouble(Console.ReadLine());
            f = Convert.ToInt32(Console.ReadLine()); //h = Convert.ToDouble(Console.ReadLine());
            i = Convert.ToInt32(Console.ReadLine());
            resua = a * e * i + d * c * h + b * g * f;
            resua2 = c * e * g + f * h * a + b * d * i;
            finalresual = resua - resua2;
            Console.WriteLine($"РЕЗУЛЬТАТ {finalresual}");

            int _a;
            int _b;
            int _c;
            //1 РЯД
            int _d;
            int _e;
            int _f;
            //2 РЯД
            int _g;
            int _h;
            int _i;
            // 3РЯД 

            int _resua;
            int _resua2;
            int _finalresual;
            int тр2;
            Console.WriteLine("Ввидите числа 4 столбца обратной матрицы для 2 дельты вертекально СТРОКИ матрицы");
            _a = Convert.ToInt32(Console.ReadLine());
            _d = Convert.ToInt32(Console.ReadLine());
            _g = Convert.ToInt32(Console.ReadLine());//_c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа 4 столбца обратной матрицы об вертекально СТРОКИ  матрицы");
            _b = Convert.ToInt32(Console.ReadLine());//_d = Convert.ToDouble(Console.ReadLine());
            _e = Convert.ToInt32(Console.ReadLine());
            _h = Convert.ToInt32(Console.ReadLine()); //_f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа ТРЕТИЙ строки вертекальноСТРОКИ  матрицы");
            _c = Convert.ToInt32(Console.ReadLine());   //_g = Convert.ToDouble(Console.ReadLine());
            _f = Convert.ToInt32(Console.ReadLine());     //_h = Convert.ToDouble(Console.ReadLine());
            _i = Convert.ToInt32(Console.ReadLine());
            _resua = _a * _e * _i + _d * _c * _h + _b * _g * _f;
            _resua2 = _c * _e * _g + _f * _h * _a + _b * _d * _i;
            _finalresual = _resua - _resua2;
            Console.WriteLine($"РЕЗУЛЬТАТ матрицы  {_finalresual} ");

            int х;
            int z;
            int q;
            //1 РЯД
            int d2;
            int e2;
            int f2;
            //2 РЯД
            int g2;
            int h2;
            int i2;
            // 3РЯД 

            int _resua1;
            int _resua3;
            int _finalresual1;
            int тр3;
            Console.WriteLine("Ввидите числа  вертекально СТРОКИ матрицы");
            х = Convert.ToInt32(Console.ReadLine());
            d2 = Convert.ToInt32(Console.ReadLine());
            g2 = Convert.ToInt32(Console.ReadLine());//_c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа 4 столбца обратной матрицы  вертекальной строки  матрицы");
            z = Convert.ToInt32(Console.ReadLine());//_d = Convert.ToDouble(Console.ReadLine());
            e2 = Convert.ToInt32(Console.ReadLine());
            h2 = Convert.ToInt32(Console.ReadLine()); //_f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа ТРЕТИЙ строки вертекальной СТРОКИ  матрицы");
            q = Convert.ToInt32(Console.ReadLine());   //_g = Convert.ToDouble(Console.ReadLine());
            f2 = Convert.ToInt32(Console.ReadLine());     //_h = Convert.ToDouble(Console.ReadLine());
            i2 = Convert.ToInt32(Console.ReadLine());
            _resua1 = х * e2 * i2 + d2 * q * h2 + z * g2 * f2;
            _resua3 = q * e2 * g2 + f2 * h2 * х + z * d2 * i2;
            _finalresual1 = _resua1 - _resua3;
            Console.WriteLine($"РЕЗУЛЬТАТ для  2 расчета {_finalresual1} ");

            int _х;
            int _z;
            int _q;
            //1 РЯД
            int _d2;
            int _e2;
            int _f2;
            //2 РЯД
            int _g2;
            int _h2;
            int _i2;
            // 3РЯД 

            int результа1;
            int результат2;
            int финальныйрезультат;
            int тр4;
            Console.WriteLine("Ввидите числа  вертекально СТРОКИ матрицы");
            _х = Convert.ToInt32(Console.ReadLine());
            _d2 = Convert.ToInt32(Console.ReadLine());
            _g2 = Convert.ToInt32(Console.ReadLine());//_c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа 4 столбца обратной вертекальной строки  матрицы");
            _z = Convert.ToInt32(Console.ReadLine());//_d = Convert.ToDouble(Console.ReadLine());
            _e2 = Convert.ToInt32(Console.ReadLine());
            _h2 = Convert.ToInt32(Console.ReadLine()); //_f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ввидите числа ТРЕТИЙ строки обратной вертекальной СТРОКИ  матрицы");
            _q = Convert.ToInt32(Console.ReadLine());   //_g = Convert.ToDouble(Console.ReadLine());
            _f2 = Convert.ToInt32(Console.ReadLine());     //_h = Convert.ToDouble(Console.ReadLine());
            _i2 = Convert.ToInt32(Console.ReadLine());
            результа1 = _х * -e2 * _i2 + _d2 * _q * _h2 + _z * _g2 * _f2;
            результат2 = _q * _e2 * g2 + _f2 * _h2 * _х + _z * _d2 * _i2;
            финальныйрезультат = _resua1 - _resua3;
            Console.WriteLine($"РЕЗУЛЬТАТ 3для расчета {финальныйрезультат} ");

            //double _х2;
            //double _z2;
            //double _q2;
            ////1 РЯД
            //double _d3;
            //double _e3;
            //double _f3;
            ////2 РЯД
            //double _g3;
            //double _h3;
            //double _i3;
            //// 3РЯД 

            //double _результа1;
            //double _результат2;
            //double _финальныйрезультат;
            //double тр5;
            //Console.WriteLine("Ввидите числа  вертекально СТРОКИ матрицы");
            //_х2 = Convert.ToDouble(Console.ReadLine());
            //_d3 = Convert.ToDouble(Console.ReadLine());
            //_g3 = Convert.ToDouble(Console.ReadLine());//_c = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Ввидите числа 4 столбца  вертекальной строки  матрицы");
            //_z2 = Convert.ToDouble(Console.ReadLine());//_d = Convert.ToDouble(Console.ReadLine());
            //_e3 = Convert.ToDouble(Console.ReadLine());
            //_h3 = Convert.ToDouble(Console.ReadLine()); //_f = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Ввидите числа ТРЕТИЙ строки вертекальной СТРОКИ  матрицы");
            //_q2 = Convert.ToDouble(Console.ReadLine());   //_g = Convert.ToDouble(Console.ReadLine());
            //_f3 = Convert.ToDouble(Console.ReadLine());     //_h = Convert.ToDouble(Console.ReadLine());
            //_i3 = Convert.ToDouble(Console.ReadLine());
            //_результа1 = _х2 * _e3 * _i3 + _d3 * _q2 * _h3 + _z2 * _g3 * _f3;
            //_результат2 = _q2 * _e2 * _g3 + _f3 * _h3 * _х2+ _z2 * _d3 * _i3;
            //_финальныйрезультат = _resua1 - _resua3;
            //Console.WriteLine($"РЕЗУЛЬТАТ 3для расчета {_финальныйрезультат} ");


            тр1 = finalresual / _finalresual;
            тр2 = _finalresual / _finalresual1;
            тр3 = _finalresual1 / финальныйрезультат;

            Console.WriteLine($"Первый x раввен {тр1}");
            Console.WriteLine($"Второй y равен{тр2}");
            Console.WriteLine($"Третий z равен{тр3}");
        }
    }
}