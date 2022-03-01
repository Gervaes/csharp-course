using System.IO;
using System.Collections.Generic;
using icomparable_202.Entities;

string path = @"C:\Users\eoger\Desktop\Projetos\C#\Aulas\icomparable_202\files\in.csv";

try {
    using (StreamReader sr = File.OpenText(path)) {
        List<Employee> list = new List<Employee>();
        while (!sr.EndOfStream) { 
            list.Add(new Employee(sr.ReadLine()));
        }

        list.Sort();
        foreach (Employee emp in list) {
            Console.WriteLine(emp);
        }
    }

} catch (IOException e) {
    Console.WriteLine("An error occurred");
    Console.WriteLine(e.Message);
}