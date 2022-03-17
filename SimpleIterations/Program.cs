using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIterations
{
    class Program
    {
        static void Main(string[] args)
        {
			double[][] a = { new double[] { 20.9, 1.2, 2.1, 0.9 }, new double[] { 1.2, 21.2, 1.5, 2.5 }, new double[] { 2.1, 1.5, 19.8, 1.3 }, new double[] { 0.9, 2.5, 1.3, 32.1 } };
			double[] y = new double[] { 21.7, 27.46, 28.76, 49.72 };
			double[] x;
			x = iter(a, y, 4);

			for (int i = 0; i < 4; i++)
			{
				Console.Write(x[i].ToString()+"\t");
			}
			Console.Write("\n");

			Console.ReadKey();

		}

		static double[] iter(double[][] a, double[] y, int n)
		{
			double[] res = new double[n];
			int i, j;


			for (i = 0; i < n; i++)
			{
				res[i] = y[i] / a[i][i];
			}

			double eps = 0.0001;
			double[] Xn = new double[n];

			do
			{
				for (i = 0; i < n; i++)
				{
					Xn[i] = y[i] / a[i][i];
					for (j = 0; j < n; j++)
					{
						if (i == j)
							continue;
						else
						{
							Xn[i] -= a[i][j] / a[i][i] * res[j];
						}
					}
				}

				bool flag = true;
				for (i = 0; i < n - 1; i++)
				{
					if (Math.Abs(Xn[i] - res[i]) > eps)
					{
						flag = false;
						break;
					}
				}

				for (i = 0; i < n; i++)
				{
					res[i] = Xn[i];
				}
				if (flag)
					break;
			} while (true);

			return res;
		}

	}
}
