using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompMath_Lab_2
{
    public static class Matrix
    {



        public static void CreateMatrix(int size, out int[,] mainMatrix, out int[,] ansMatrix)
        {
            mainMatrix = new int[size, size];
            ansMatrix = new int[size, 1];
            FillMatrix(ref mainMatrix,ref ansMatrix);
        }

        private static void FillMatrix(ref int[,] mainMatrix, ref int[,] ansMatrix)
        {
            //GetUpperBound(0) + 1;    // количество строк
            //GetUpperBound(1) + 1;;        // количество столбцов
            for (int i = 0; i < mainMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                {
                    mainMatrix[i,j] = Convert.ToInt32( Console.ReadLine());
                }
            }
            for(int i = 0; i < mainMatrix.GetUpperBound(0) + 1; i++)
                ansMatrix[i,0] = Convert.ToInt32(Console.ReadLine());
        }

        public static void PrintMatrix(int[,] mainMatrix,int[,] ansMatrix)
        {
            for(int i=0; i< mainMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(mainMatrix[i, j] + " ");
                }
                Console.Write("\t" + ansMatrix[i, 0]);
                Console.WriteLine();
            }
        }
    }
}
