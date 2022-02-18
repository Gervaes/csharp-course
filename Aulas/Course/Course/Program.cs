
/*
79: matrix

            double[,] mat = new double[2,3];
            Console.WriteLine(mat.Length);
            Console.WriteLine(mat.Rank);
            Console.WriteLine(mat.GetLength(0));
            Console.WriteLine(mat.GetLength(1));


77: lists

            List<string> list = new List<string>();

            list.Add("Maria");
            list.Add("Alex");
            list.Add("Bob");
            list.Add("Anna");

            list.Insert(2, "Marco");

            foreach (string s in list) {
                Console.WriteLine(s);
            }

            Console.WriteLine($"List Count: {list.Count}");

            string s1 = list.Find(x => x[0] == 'A');
            Console.WriteLine($"First A: {s1}");

            string s2 = list.FindLast(x => x[0] == 'A');
            Console.WriteLine($"Last A: {s2}");

            int pos1 = list.FindIndex(x => x[0] == 'A');
            Console.WriteLine($"First Position A: {pos1}");

            int pos2 = list.FindLastIndex(x => x[0] == 'A');
            Console.WriteLine($"Last Position A: {pos2}");

            Console.WriteLine("----------------------");
            List<string> list2 = list.FindAll(x => x.Length == 5);
            foreach (string s in list2) {
                Console.WriteLine(s);
            }

            //Console.WriteLine("----------------------");
            //list.Remove("Alex");
            //foreach (string s in list) {
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("----------------------");
            //list.RemoveAt(3);
            //foreach (string s in list) {
            //    Console.WriteLine(s);
            //}

            Console.WriteLine("----------------------");
            list.RemoveRange(2,2);
            foreach (string s in list) {
                Console.WriteLine(s);
            }

            Console.WriteLine("----------------------");
            list.RemoveAll(x => x[0] == 'M');
            foreach (string s in list) {
                Console.WriteLine(s);
            }


75: foreach

            string[] vect = new string[] { "Maria", "Alex", "Bob" };

            foreach (string obj in vect) {
                Console.WriteLine(obj);
            }
*/