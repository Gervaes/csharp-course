using System;
using System.Globalization;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());

        int[,] mat = new int[n, n];

        for (int i = 0; i < n; i++) {
            string[] line = Console.ReadLine().Split(" ");
            for (int j = 0; j < n; j++) {
                mat[i, j] = int.Parse(line[j]);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Main diagonal:");

        int negCount = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i, j] < 0)
                    negCount++;
                if (i == j)
                    Console.Write($"{mat[i, j]} ");
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Negative numbers = {negCount}");
    }

}