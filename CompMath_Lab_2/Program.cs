




using CompMath_Lab_2;

float[,] matrix;
float[] result;
Matrix.CreateMatrix(3,out matrix,out result);
Matrix.PrintMatrix(matrix,result);

//Console.WriteLine("Gauss");
//GaussMethod.GaussWOElement(matrix, result);
//GaussMethod.GaussWithElement(matrix, result);

Console.WriteLine("Simple");

SimpleIterations.SimpleMethod(matrix,result,0.0001F);
