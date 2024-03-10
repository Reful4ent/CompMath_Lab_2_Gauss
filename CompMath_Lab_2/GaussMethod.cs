using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompMath_Lab_2
{
    public static class GaussMethod
    {
        /// <summary>
        /// Метод Гауса без выбора главного элемента
        /// </summary>
        /// <param name="mainMatrix"></param>
        /// <param name="freeMembers"></param>
        public static void GaussWOElement(float[,] mainMatrix, float[] freeMembers)
        {
            if (mainMatrix[0,0] == 0)
                ChangeLines(mainMatrix, freeMembers);
            for (int i = 0; i < mainMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = i+1; j < mainMatrix.GetUpperBound(0) + 1; j++)
                {
                    float number = (mainMatrix[j, i] / mainMatrix[i, i]);
                    for (int k = i; k < mainMatrix.GetUpperBound(1) + 1; k++)
                        mainMatrix[j,k] -= mainMatrix[i, k] * number;
                    freeMembers[j] -= freeMembers[i] * number;
                }
            }
            ReverseMotion(mainMatrix, freeMembers);
        }



        /// <summary>
        /// Если первый элемент в первой  строке нулевой - делаем замену
        /// </summary>
        /// <param name="mainMatrix"></param>
        /// <param name="freeMembers"></param>
        public static void ChangeLines(float[,] mainMatrix, float[] freeMembers)
        {
            float[] temp = new float[mainMatrix.GetUpperBound(0)+1];
            float tempElement;
            for (int i = 1;i < mainMatrix.GetUpperBound(0) + 1; i++)
            {
                if (mainMatrix[i,0] != 0)
                {
                    for(int j = 0; j< mainMatrix.GetUpperBound(1) +1; j++)
                        temp[j] = mainMatrix[i,j];
                    tempElement = freeMembers[i];
                    for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                        mainMatrix[i, j] = mainMatrix[0, j];
                    freeMembers[i] = freeMembers[0];
                    for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                        mainMatrix[0, j] = temp[j];
                    freeMembers[0] = tempElement;
                    break;
                }

            }

        }



        /// <summary>
        /// Обратный ход для метода Гауса
        /// </summary>
        /// <param name="mainMatrix"></param>
        /// <param name="freeMembers"></param>
        private static void ReverseMotion(float[,] mainMatrix, float[]freeMembers)
        {
            float sum = 0;
            for(int i = mainMatrix.GetUpperBound(0);i >= 0; i--)
            {
                for (int j = mainMatrix.GetUpperBound(1); j > i; j--)
                    sum += mainMatrix[i, j] * freeMembers[j];
                freeMembers[i] = 1 / mainMatrix[i, i]*(freeMembers[i]-sum);
            }

            //В свободных членах - ответ, в матрице 1 - искомый икс
            for (int i = 0; i < mainMatrix.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < mainMatrix.GetUpperBound(1) + 1; j++)
                {
                    if (i == j)
                        mainMatrix[i, j] = 1;
                    else mainMatrix[i, j] = 0;
                }
            }
            Matrix.PrintMatrix(mainMatrix,freeMembers);
        }
        
    }
}