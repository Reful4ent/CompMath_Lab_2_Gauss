using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CompMath_Lab_2
{
    public static class SimpleIterations
    {
        public static void SimpleMethod(float[,] mainMatrix, float[] freeMembers,float accuracy)
        {
            float[] beta = new float[freeMembers.Length];
            float[,] alpha = new float[mainMatrix.GetUpperBound(0)+1,mainMatrix.GetUpperBound(1)+1]; 

            float[] prevX = new float[mainMatrix.GetUpperBound(1) + 1];
            float[] X = new float[mainMatrix.GetUpperBound(1)+1];

            for (int i = 0; i < mainMatrix.GetUpperBound(0) + 1; i++)
                prevX[i] = beta[i] = freeMembers[i] / mainMatrix[i, i];

            for (int i = 0;i < mainMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                {
                    if (i != j)
                        alpha[i, j] = -(mainMatrix[i, j] / mainMatrix[i, i]);
                    else alpha[i, j] = 0;
                }
            }

            int iterations = 0;
            float norm = 0;
            while (true)
            {
                if (CheckNorm(alpha,ref norm))
                {
                    Console.WriteLine("Не сходится");
                    break;
                }
                for (int i = 0; i < alpha.GetUpperBound(0) + 1; i++)
                {
                    float sum = 0;
                    for (int j = 0; j < alpha.GetUpperBound(1) + 1; j++)
                    {
                        if(i == j) continue;
                        sum += alpha[i, j] * prevX[j];
                    }
                    X[i] = beta[i] + sum;
                    Console.Write(X[i] + " ");
                }
                Console.WriteLine(iterations);
                System.Threading.Thread.Sleep(550);
                Console.WriteLine();
                if (norm<1/2)
                {
                    if(CheckStopCriterion(prevX, X, accuracy))
                        break;
                }
                else
                {
                    if (CheckStopWithNormm(prevX, X, accuracy, norm))
                        break;
                }
                for(int i = 0; i < X.Length; i++)
                    prevX[i] = X[i];
                iterations++;
            }
            Matrix.PrintMatrix(alpha, X);
        }

        

        private static bool CheckStopCriterion(float[] prevX, float[] X, float accuracy)
        {
            bool criterion = false;
            for (int i = 0; i< prevX.Length; i++)
            {
                if (Math.Abs(prevX[i] - X[i])<accuracy)
                    criterion = true;
                else return false;
            }
            return criterion;
        }

        private static bool CheckStopWithNormm(float[] prevX, float[] X, float accuracy,float norm)
        {
            bool criterion = false;
            for(int i = 0;i< prevX.Length;i++) 
            {
                if (Math.Abs(prevX[i] - X[i]) < (1 - norm) / norm * accuracy)
                    criterion = true;
                else return false;
            }
            return criterion;
        }

        private static bool CheckNorm(float[,] alpha,ref float norm)
        {
            float alphaNorm = 0;
            for (int i = 0; i < alpha.GetUpperBound(0)+1; i++)
                for (int j = 0; j < alpha.GetUpperBound(1) + 1; j++)
                    alphaNorm += (float)Math.Pow(alpha[i, j], 2);
            norm = alphaNorm = (float)Math.Sqrt(alphaNorm);
            return alphaNorm > 1;

        }
    }
}
