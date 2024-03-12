using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompMath_Lab_2
{
    public static class PassingMethod
    {
        /// <summary>
        /// Метод прогонки для трехдиагональной матрицы
        /// Passing method for a tridiagonal matrix
        /// </summary>
        /// <param name="mainMatrix"></param>
        /// <param name="freeMembers"></param>
        public static void PassingIteration(float[,] mainMatrix, float[] freeMembers)
        {
            for (int i = 1; i< mainMatrix.GetUpperBound(0)+1; i++)
            {
                mainMatrix[i, i] -= mainMatrix[i, i - 1] * mainMatrix[i - 1, i] / (mainMatrix[i-1,i-1]);
                freeMembers[i] -= mainMatrix[i, i-1] * freeMembers[i - 1] / mainMatrix[i - 1, i - 1];
                mainMatrix[i, i - 1] = 0;
            }
            GaussMethod.ReverseMotion(mainMatrix, freeMembers);
        }
    }
}

