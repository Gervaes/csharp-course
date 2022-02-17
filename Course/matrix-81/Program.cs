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
            foreach (int line in mat) {
                Console.WriteLine(line);
            }

            //Console.WriteLine();
            //Console.WriteLine("Main diagonal:");

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