using System;
using System.IO;
using exercicio_212.Entities;

HashSet<User> a = new HashSet<User>();
HashSet<User> b = new HashSet<User>();
HashSet<User> c = new HashSet<User>();

int n;

Console.Write("How many students for course A? ");
n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++) {
    int code = int.Parse(Console.ReadLine());
    a.Add(new User { Code = code });
}

Console.Write("How many students for course B? ");
n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++) {
    int code = int.Parse(Console.ReadLine());
    b.Add(new User { Code = code });
}

Console.Write("How many students for course C? ");
n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++) {
    int code = int.Parse(Console.ReadLine());
    c.Add(new User { Code = code });
}

HashSet<User> d = new HashSet<User>(a);
d.UnionWith(b);
d.UnionWith(c);

Console.WriteLine();
Console.WriteLine($"Total students: {d.Count}");