using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            int nRows, mRows, nColumns, mColumns;
            Console.WriteLine("First matrix:");
            Console.Write("Input number of rows: ");
            nRows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input number of columns: ");
            nColumns = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Second matrix: ");
            Console.Write("Input number of rows: ");
            mRows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input number of columns: ");
            mColumns = Convert.ToInt32(Console.ReadLine());

            MatrixMultiplier multiplier = new MatrixMultiplier(new int[nRows, nColumns], new int[mRows, mColumns]);

            multiplier.GenerateFirstMatrix(nRows, nColumns);
            multiplier.GenerateSecondMatrix(mRows, mColumns);

            if (!multiplier.CheckMultiply())
            {
                Console.WriteLine("Wrong size of matrix");
                return;
            }

            List<Thread> threads = new List<Thread>();

            for(int i = 0; i < nRows; i++)
            {
                for(int j = 0; j < mColumns; j++)
                {
                    threads.Add(new Thread(()=>multiplier.MultiplyElement(i, j)));
                }
            }

            foreach(var n in threads)
            {
                n.Start();
            }

            foreach (var n in threads)
            {
                n.Join();
            }

            for (int i = 0; i < multiplier.Result.GetLength(0); i++)
            {
                Console.WriteLine();
                for(int j = 0; j < multiplier.Result.GetLength(1); j++)
                {
                    Console.Write(multiplier.Result[i, j]);
                }
            }
        }
    }
}
