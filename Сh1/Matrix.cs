using System;

namespace Lab1
{
    // класс с операциями над матрицами
    class Matrix
    {
        // поле для матрицы
        int[,] matrix;

        public Matrix()
        {
            this.GetMatrixFromConsole();
        }

        public Matrix(int row, int column)
        {
            matrix = new int[row, column];
        }

        int rowsCount;
        int columnsCount;

        // метод для получения матрицы из консоли
        private void GetMatrixFromConsole()
        {
            Console.Write("Количество строк матрицы: ");
            rowsCount = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов матрицы: ");
            columnsCount = int.Parse(Console.ReadLine());

            matrix = new int[rowsCount, columnsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    Console.Write("[{0},{1}] = ", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
        }
        // метод для печати матрицы в консоль
        public void PrintMatrix()
        {
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // метод для печати матрицы в консоль
        // перегрузка
        public static void PrintMatrix(Matrix matrixA)
        {
            for (int i = 0; i < matrixA.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.matrix.GetLength(1); j++)
                {
                    Console.Write(matrixA.matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        
        // метод для умножения матриц
        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.columnsCount != matrixB.rowsCount)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            Matrix matrixC = new Matrix(matrixA.rowsCount, matrixB.columnsCount);

            for (int i = 0; i < matrixA.rowsCount; i++)
            {
                for (int j = 0; j < matrixB.columnsCount; j++)
                {
                    matrixC.matrix[i, j] = 0;

                    for (int k = 0; k < matrixA.columnsCount; k++)
                    {
                        matrixC.matrix[i, j] += matrixA.matrix[i, k] * matrixB.matrix[k, j];
                    }
                }
            }

            return matrixC;
        }
        // метод для умножения матрицы на число
        public static Matrix operator *(Matrix matrixA, int t)
        {
            for (int i = 0; i < matrixA.rowsCount; i++)
            {
                for (int j = 0; j < matrixA.columnsCount; j++)
                {
                    matrixA.matrix[i, j] *= t;
                }
            }
            return matrixA;
        }
        // метод для сложения матриц
        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            Matrix matrixC = matrixB;
            for (int i = 0; i < matrixA.rowsCount; i++)
            {
                for (int j = 0; j < matrixB.columnsCount; j++)
                {
                    matrixC.matrix[i, j] = matrixA.matrix[i, j] + matrixB.matrix[i, j];
                }
            }
            return matrixC;

        }
        // метод для вычитания матриц
        public static Matrix operator -(Matrix matrixA, Matrix matrixB)
        {
            Matrix matrixC = matrixB;
            for (int i = 0; i < matrixA.rowsCount; i++)
            {
                for (int j = 0; j < matrixB.columnsCount; j++)
                {
                    matrixC.matrix[i, j] = matrixA.matrix[i, j] - matrixB.matrix[i, j];
                }
            }
            return matrixC;

        }
        // метод для транспонирования матрицы
        public void Transpose()
        {
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = i; j < columnsCount; j++)
                {
                    int tmp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = tmp;
                }
            }
        }
    }
}
