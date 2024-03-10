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
        static float[,] matrixA = { { 10, 20, 30 },
                                    { 40, 80.00001F, 60 },
                                    { 5, -15, 25 },
                                   };
        static float[] ansA = { 60, 180.00001F, 15 };

        static float[,] matrixB = { { 1, 2, 15, 1 },
                                    { -1, 3, 2, 20 },
                                    { 10, 1, 1, 1 },
                                    { 2, 14, 3, -2 },
                                  };
        static float[] ansB = { 19, 24, 13, 17 };
        


        public static void CreateMatrix(int size, out float[,] mainMatrix, out float[] freeMembers)
        {
            mainMatrix = new float[size, size];
            freeMembers = new float[size];
            FillMatrix(ref mainMatrix,ref freeMembers);
        }

        private static void FillMatrix(ref float[,] mainMatrix, ref float[] freeMembers)
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
                freeMembers[i] = Convert.ToInt32(Console.ReadLine());
        }

        public static void PrintMatrix(float[,] mainMatrix, float[] ansMatrix)
        {
            for(int i=0; i< mainMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(mainMatrix[i, j] + " ");
                }
                Console.Write("\t" + ansMatrix[i]);
                Console.WriteLine();
            }
        }
    }
}
