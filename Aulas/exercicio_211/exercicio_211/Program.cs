using System;
using System.IO;
using exercicio_211.Entities;

Console.Write("Enter the file full path: ");
string path = Console.ReadLine();

HashSet<LogRecord> set = new HashSet<LogRecord>();

try {
    using (StreamReader sr = File.OpenText(path)) {
        while (!sr.EndOfStream) { 
            string[] line = sr.ReadLine().Split(" ");
            set.Add(new LogRecord { Username = line[0], Instant = DateTime.Parse(line[1]) });
            Console.WriteLine($"{line[0]} {line[1]}");
        }

        Console.WriteLine($"Total users: {set.Count}");
    }

} catch (IOException e) {
    Console.WriteLine(e.Message);
}