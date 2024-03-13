using CompMath_Lab_2;

Console.WriteLine("-----Решение СЛАУ вида Ax = b-----");
Console.WriteLine("Для какой СЛАУ вы хотите найти решение?\n");
Console.WriteLine("1 - СЛАУ 1;");
Console.WriteLine("2 - СЛАУ 2;");
Console.WriteLine("3 - своя СЛАУ.\n");

Console.Write("СЛАУ: ");

int whatSLAE;
string _SLAE;

_SLAE = Console.ReadLine();

while(!int.TryParse(_SLAE, out whatSLAE) || whatSLAE < 1 || whatSLAE > 3)
{
    Console.WriteLine("Неверное значение.");
    Console.Write("СЛАУ: ");
    _SLAE = Console.ReadLine();
}
Console.Clear();

int whatMethod;
string _method;

switch (whatSLAE)
{
    case 1:
        Console.WriteLine("-----Решение СЛАУ 1-----");
        Matrix.PrintMatrix(Matrix.matrixA, Matrix.ansA);

        Console.WriteLine("\nКаким методом вы хотите решить данную СЛАУ?\n");
        Console.WriteLine("1 - метод Гаусса без выбора главного элемента;");
        Console.WriteLine("2 - метод Гаусса с выбором главного элемента.");
        Console.Write("Метод: ");

        _method = Console.ReadLine();
        while (!int.TryParse(_method, out whatMethod) || whatMethod < 1 || whatMethod > 2)
        {
            Console.WriteLine("Неверное значение.");
            Console.Write("Метод: ");
            _method = Console.ReadLine();
        }
        Console.Clear();

        switch (whatMethod)
        {
            case 1:
                Console.WriteLine("-----Метод Гаусса без выбора главного значения-----");
                Console.WriteLine("Исходная система уравнений:");
                Matrix.PrintMatrix(Matrix.matrixA, Matrix.ansA);
                Console.WriteLine("\nПреобразованные система уравнений:");
                GaussMethod.GaussWOElement(Matrix.matrixA, Matrix.ansA);
                break;
            case 2:
                Console.WriteLine("-----Метод Гаусса с выбором главного значения-----");
                Console.WriteLine("Исходная система уравнений:");
                Matrix.PrintMatrix(Matrix.matrixA, Matrix.ansA);
                Console.WriteLine("\nПреобразованная система уравнений:");
                GaussMethod.GaussWithElement(Matrix.matrixA, Matrix.ansA);
                break;
            default:
                Console.WriteLine("Выбран невозможный метод");
                break;
        }
        break;
    case 2:
        Console.WriteLine("-----Решение СЛАУ 2-----");
        Console.WriteLine("Данная СЛАУ решается методом простых итераций");
        Console.WriteLine("Но без преобразования СЛАУ сходимость итерационного процесса не гарантируется:");
        Console.WriteLine("\nИсходная система уравнений:");
        Matrix.PrintMatrix(Matrix.matrixB, Matrix.ansB);
        Console.WriteLine("\nПреобразованная система уравнений:");
        SimpleIterations.SimpleMethod(Matrix.matrixB, Matrix.ansB, 0.001F);

        Console.WriteLine("\nПосле преобразований вручную гарантируется сходимость итерационного процесса:");
        Console.WriteLine("\nПреобразованная вручную система уравнений:");
        Matrix.PrintMatrix(Matrix.matrixBMorph, Matrix.ansBMorph);
        Console.WriteLine("Тогда итерационный процесс сходится и получается:");
        SimpleIterations.SimpleMethod(Matrix.matrixBMorph, Matrix.ansBMorph, 0.001F);
        break;
    case 3:
        Console.WriteLine("-----Решение своей СЛАУ-----");

        Console.Write("Введите размерность матрицы: ");

        int size;
        string _size;

        _size = Console.ReadLine();
        while (!int.TryParse(_size, out size) || size < 2)
        {
            Console.WriteLine("Неверное значение.");
            Console.Write("Размерность: ");
            _size = Console.ReadLine();
        }
        Console.Clear();

        float[,] matrix;
        float[] result;
        Console.WriteLine("Запишите значения в СЛАУ (каждое число отдельно через Enter)");
        Console.WriteLine("Сначала числа матрицы (a_11, a_12, ..., a_nn), затем свободные члены (соотвествтенно строкам):");
        Matrix.CreateMatrix(size, out matrix, out result);
        Console.Clear();

        Matrix.PrintMatrix(matrix, result);
        Console.WriteLine("\nКаким методом вы хотите решить данную СЛАУ?\n");
        Console.WriteLine("1 - метод Гаусса без выбора главного элемента;");
        Console.WriteLine("2 - метод Гаусса с выбором главного элемента;");
        Console.WriteLine("3 - метод простых итераций;");
        Console.WriteLine("4 - метод прогонки (для трёхдиагональной матрицы).");
        Console.Write("Метод: ");

        _method = Console.ReadLine();
        while (!int.TryParse(_method, out whatMethod) || whatMethod < 1 || whatMethod > 4)
        {
            Console.WriteLine("Неверное значение.");
            Console.Write("Метод: ");
            _method = Console.ReadLine();
        }
        Console.Clear();

        switch (whatMethod)
        {
            case 1:
                Console.WriteLine("-----Метод Гаусса без выбора главного значения-----");
                Console.WriteLine("Исходная система уравнений:");
                Matrix.PrintMatrix(matrix, result);
                Console.WriteLine("\nПреобразованная система уравнений:");
                GaussMethod.GaussWOElement(matrix, result);
                break;
            case 2:
                Console.WriteLine("-----Метод Гаусса с выбором главного значения-----");
                Console.WriteLine("Исходная система уравнений:");
                Matrix.PrintMatrix(matrix, result);
                Console.WriteLine("\nПреобразованная система уравнений:");
                GaussMethod.GaussWithElement(matrix, result);
                break;
            case 3:
                Console.WriteLine("-----Метод простых итераций-----");
                Console.WriteLine("\nИсходная система уравнений:");
                Matrix.PrintMatrix(matrix, result);
                Console.WriteLine("\nПреобразованная система уравнений:");
                SimpleIterations.SimpleMethod(matrix, result, 0.001F);
                break;
            case 4:
                Console.WriteLine("-----Метод прогонки-----");
                Console.WriteLine("Исходная система уравнений:");
                Matrix.PrintMatrix(matrix, result);
                Console.WriteLine("\nПреобразованная система уравнений:");
                PassingMethod.PassingIteration(matrix, result);
                break;
            default:
                Console.WriteLine("Выбран невозможный метод");
                break;
        }

        break;
    default:
        Console.WriteLine("Выбрана невозможная СЛАУ");
        break;
}