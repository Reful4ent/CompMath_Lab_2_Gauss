namespace CompMath_Lab_2
{
    public static class Matrix
    {
        /// <summary>
        /// For the TASK
        /// </summary>
        public static float[,] matrixA = { { 10, 20, 30 },
                                    { 40, 80.00001F, 60 },
                                    { 5, -15, 25 },
                                   };
        public static float[] ansA = { 60, 180.00001F, 15 };

        public static float[,] matrixB = { { 3, 1, 10 },
                                    { 14, 2, 3 },
                                    { 2, 12, 3 }
                                  };
        public static float[] ansB = { 18, 35, 31 };
        
        public static void CreateMatrix(int size, out float[,] mainMatrix, out float[] freeMembers)
        {
            mainMatrix = new float[size, size];
            freeMembers = new float[size];
            FillMatrix(ref mainMatrix,ref freeMembers);
        }

        private static void FillMatrix(ref float[,] mainMatrix, ref float[] freeMembers)
        {
            //GetUpperBound(0) + 1;    количество строк - number of rows
            //GetUpperBound(1) + 1;    количество столбцов - number of columns
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
                    Console.Write(mainMatrix[i, j]+" ");
                }
                Console.Write("\t\t\t");
                Console.Write("{0:f8}",ansMatrix[i]);
                Console.WriteLine();
            }
        }
    }
}
