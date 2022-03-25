using System;

namespace FP2021
{
    class Program
    {
        static void Main(string[] args)
        {
            matrix();
        }

        /// <summary>
        /// maxim matrice cu 1
        /// </summary>
        private static void matrix()
        {
            int[,] M = ReadMatrix();
            int[,] S = new int[M.GetLength(0), M.GetLength(1)];
            for (int i = 0; i < M.GetLength(0); i++)
            {
                S[i, 0] = M[i, 0];
            }
            for (int j = 0; j < M.GetLength(1); j++)
            {
                S[0, j] = M[0, j];
            }
            int min1 = 0;
            int min2 = 0;
            int min3 = 0;
            int min4 = 0;

            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if (M[i, j] == 0)
                        S[i, j] = M[i, j];
                    if (M[i, j] == 1)
                    {
                        min1 = S[i, j - 1];
                        min2 = S[i - 1, j];
                        min3 = min(min1, min2);
                        min4 = S[i - 1, j - 1];
                        
                        S[i, j] = min(min3, min4) + 1;
                        
                    }
                }
            }


        }

        private static int min(int min1, int min2)
        {
            if (min1 >= min2)
                return min1;
            else
                return min2;
        }

        private static int[,] ReadMatrix()
        {
            int[,] matrix;

            string line;
            line = Console.ReadLine();
            char[] sep = { ' ', '\n', '\t', ',', ';' };
            int linii, coloane;
            string[] tokens;

            tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            linii = int.Parse(tokens[0]);
            coloane = int.Parse(tokens[1]);

            matrix = new int[linii, coloane];

            for (int i = 0; i < linii; i++)
            {
                line = Console.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < coloane; j++)
                {
                    matrix[i, j] = int.Parse(tokens[j]);
                }
            }

            return matrix;
        }
    }
}
