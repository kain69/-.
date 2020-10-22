using System;

namespace Lab1
{

    class Program
    {
        static void Main(string[] args)
        {

            /*int[,] a = MatrixOperator.GetMatrixFromConsole("A");
            int[,] b = MatrixOperator.GetMatrixFromConsole("B");
            int[,] c = MatrixOperator.GetMatrixFromConsole("C");*/

            Matrix matrixA = new Matrix();
            Matrix matrixB = new Matrix();
            Matrix matrixC = new Matrix();

            Console.WriteLine("Матрица A:");
            matrixA.PrintMatrix();

            Console.WriteLine("Матрица B:");
            matrixB.PrintMatrix();

            Console.WriteLine("Матрица C:");
            matrixC.PrintMatrix();

            /*int[,] At = MatrixOperator.Transpose(a);
            int[,] Ct = MatrixOperator.Transpose(c);
            int[,] B4 = MatrixOperator.MatrixMultInteger(b, 4);
            int[,] d = MatrixOperator.MatrixMinus(MatrixOperator.MatrixPlus(At, B4), MatrixOperator.MatrixMultInteger(Ct, 5));*/

            matrixA.Transpose();
            //matrixA.PrintMatrix();
            matrixC.Transpose();
            //matrixC.PrintMatrix();
            matrixB = matrixB * 4;
            //matrixB.PrintMatrix();


            Console.WriteLine();
            Console.WriteLine("Матрица D:");
            matrixA += matrixB;
            //matrixA.PrintMatrix();
            matrixC *= 5;
            //matrixC.PrintMatrix();
            matrixA -= matrixC;
            matrixA.PrintMatrix();
            Console.ReadLine();

        }
    }
}
