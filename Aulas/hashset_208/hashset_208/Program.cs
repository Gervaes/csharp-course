using System.Collections.Generic;

HashSet<string> set = new HashSet<string>();

set.Add("TV");
set.Add("Notebook");
set.Add("Tablet");

Console.WriteLine(set.Contains("Notebook"));

foreach (string item in set) {
    Console.WriteLine(item);
}