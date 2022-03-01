using System.Collections.Generic;

SortedSet<int> a = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
SortedSet<int> b = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

Console.WriteLine("A:");
PrintCollection(a);
Console.WriteLine("B:");
PrintCollection(b);

//union
SortedSet<int> c = new SortedSet<int>(a);
c.UnionWith(b);

Console.WriteLine("union:");
PrintCollection(c);

//intersection
SortedSet<int> d = new SortedSet<int>(a);
d.IntersectWith(b);

Console.WriteLine("intersection:");
PrintCollection(d);

//difference
SortedSet<int> e = new SortedSet<int>(a);
e.ExceptWith(b);

Console.WriteLine("C:");
PrintCollection(e);


static void PrintCollection<T>(IEnumerable<T> collection) {
    foreach (T item in collection) {
        Console.Write($"{item} ");
    }
    Console.WriteLine();
}