using System;

namespace lab4stp
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1;
            a[0, 1] = 1;
            a[1, 0] = 2;
            a[1, 1] = 2;
            Matrix b = new Matrix(3, 3);
            Console.WriteLine(Matrix.MatrixToString(a));
        }
    }
}
