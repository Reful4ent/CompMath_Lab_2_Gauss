




using CompMath_Lab_2;

float[,] matrix;
float[] result;
Matrix.CreateMatrix(3,out matrix,out result);
Matrix.PrintMatrix(matrix,result);

Console.WriteLine();
GaussMethod.GaussWOElement(matrix, result);
