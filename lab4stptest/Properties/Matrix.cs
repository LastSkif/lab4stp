using System;

namespace lab4stp 
{
	public class MyException : Exception
	{
		public MyException(string s) : base(s)
		{ }
	}
	public class Matrix
	{
		int[,] m;
		//Свойство для работы с числом строк.
		public int I { get; }
		//Свойство для работы с числом столбцов.
		public int J { get; }

		//Конструктор.
		public Matrix(int i, int j)
		{
			if (i <= 0)
				throw new MyException($"Недопустимое значение строки = { i }");
			if (j <= 0)
				throw new MyException($"Недопустимое значение столбца = { j }");
			I = i;
			J = j;
			m = new int[i, j];
		}

		//Индексатор для доступа к значениям компонентов матрицы.
		public int this[int i, int j]
		{
			get
			{
				if (i < 0 | i > I - 1)
					throw new MyException($"Неверное значение i = { i }");
				if (j < 0 | j > J - 1)
					throw new MyException($"Неверное значение j = { j }");
				return m[i, j];
			}
			set
			{
				if (i < 0 | i > I - 1)
					throw new MyException($"Неверное значение i = { i }");
				if (j < 0 | j > J - 1)
					throw new MyException($"Неверное значение j = { 0 }");
				m[i, j] = value;
			}
		}

		//Сложение матриц.
		public static Matrix operator +(Matrix a, Matrix b)
		{
			Matrix c = new Matrix(a.I, a.J);
			for (int i = 0; i < a.I; i++)
            {
				for (int j = 0; j < a.J; j++)
				{
					c[i, j] = a.m[i, j] + b.m[i, j];
				}
			}
			return c;
		}

		//Вычитание матриц.
		public static Matrix operator -(Matrix a, Matrix b)
		{
			Matrix c = new Matrix(a.I, a.J);
			for (int i = 0; i < a.I; i++)
            {
				for (int j = 0; j < a.J; j++)
				{
					c[i, j] = a.m[i, j] - b.m[i, j];
				}
			}
			return c;
		}

		//Умножение матриц.
		public static Matrix operator *(Matrix a, Matrix b)
		{
			if (a.J != b.I)
				throw new MyException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы");
			Matrix c = new Matrix(a.I, b.J);
			for (int i = 0; i < a.I; i++)
            {
				for (int j = 0; j < b.J; j++)
				{
					c[i, j] = 0;
					for (int k = 0; k < a.J; k++)
					{
						c[i, j] += a.m[i, k] * b.m[k, j];
					}
				}
			}
			return c;
		}

		//Равенство матриц
		public static bool operator ==(Matrix a, Matrix b)
		{
			bool q = true;
			for (int i = 0; i < a.I; i++)
				for (int j = 0; j < a.J; j++)
				{
					if (a[i, j] != b[i, j])
					{
						q = false; break;
					}
				}
			return q;
		}

		//Неравенство матриц
		public static bool operator !=(Matrix a, Matrix b)
		{

			return !(a == b);
		}

		//Поиск минимального элемента
		public static int Min(Matrix a)
        {
			int min = int.MaxValue;
			for (int i = 0; i < a.I; i++)
            {
				for (int j = 0; j < a.J; j++)
                {
					if (a[i, j] < min)
						min = a[i, j];
                }
			}
			return min;
		}

		//Преобразование в строку
		public static string MatrixToString(Matrix a)
        {
			string resultString = "{ ";
			for (int i = 0; i < a.I; i++)
			{
				resultString += "{ ";
				for (int j = 0; j < a.J; j++)
				{
					resultString += a[i, j].ToString();
					resultString += ", ";

				}
				resultString += "}, ";
			}
			resultString += "}";
			return resultString;
        }

		//Транспонирование матрицы
		public static Matrix Transp(Matrix a)
        {
			if (a.I != a.J)
				throw new MyException("Число строк и столбцов в матрице должно быть одинаково");
			Matrix b = new Matrix(a.I, a.J);
			for(int i = 0; i < a.I; i++)
            {
				for(int j = 0; j < a.J; j++)
                {
					b[i, j] = a[j, i];
                }
            }
			return b;
        }

		//Взятие числа строк
		public static int GetRows(Matrix a)
        {
			return a.I;
        }

		//Взятие числа столбцов
		public static int GetCols(Matrix a)
		{
			return a.J;
		}

		//Вывод значений компонентов на консоль.
		public void Show()
		{
			for (int i = 0; i < I; i++)
			{
				for (int j = 0; j < J; j++)
				{
					Console.Write("\t" + this[i, j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		public override bool Equals(object obj)
		{
			return (this as Matrix) == (obj as Matrix);
		}
	}
}
