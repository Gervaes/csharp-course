using System;
using System.Globalization;
using System.Collections.Generic;

namespace matrix_81 {
    class Program {
        public static void Main(string[] args) {
            string[] dimensions = Console.ReadLine().Split(" ");
            int m = int.Parse(dimensions[0]);
            int n = int.Parse(dimensions[1]);

            int[,] mat = new int[m, n];

            for (int i = 0; i < m; i++) {
                string[] line = Console.ReadLine().Split(" ");
                for (int j = 0; j < n; j++) {
                    mat[i, j] = int.Parse(line[j]);
                }
            }

            int target = int.Parse(Console.ReadLine());
            int[] targetIndex = new int[2];

            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if(mat[i,j] == target) {
                        Console.WriteLine($"Position {i},{j}:");
                        if (j - 1 >= 0)
                            Console.WriteLine($"Left: {mat[i, j - 1]}");
                        if (j + 1 < n)
                            Console.WriteLine($"Right: {mat[i, j + 1]}");
                        if (i - 1 >= 0)
                            Console.WriteLine($"Up: {mat[i - 1, j]}");
                        if (i + 1 >= 0)
                            Console.WriteLine($"Down: {mat[i + 1, j]}");
                    }
                }    
            }

            //int negCount = 0;
            //for (int i = 0; i < n; i++) {
            //    for (int j = 0; j < n; j++) {
            //        if (mat[i, j] < 0)
            //            negCount++;
            //        if (i == j)
            //            Console.Write($"{mat[i, j]} ");
            //    }
            //}
            //Console.WriteLine();
            //Console.WriteLine($"Negative numbers = {negCount}");
        }

    }
}