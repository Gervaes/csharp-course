using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course {
    internal class Calculator {
        public static void Triple(int origin, out int result) {
            result = origin * 3;
        }

        /*
        
        public static void Triple(ref int x) {
            x = x * 3;
        }

        public static int Sum(params int[] nums) { 
            int sum = 0;

            for (int i = 0; i < nums.Length; i++) { 
                sum += nums[i];
            }

            return sum;
        }
        */

    }
}

/*

int a = 10;
            int triple;
            Calculator.Triple(a, out triple);
            Console.WriteLine(a);
            Console.WriteLine(triple);


int a = 10;
            Calculator.Triple(ref a);
            Console.WriteLine(a);
 
 int s1 = Calculator.Sum(2, 3 );
            int s2 = Calculator.Sum(2, 3, 4);

            Console.WriteLine(s1);
            Console.WriteLine(s2);
 
 */