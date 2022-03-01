using System;
using System.IO;

Console.Write("Enter the file full path: ");
string path = Console.ReadLine();

Dictionary<string, int> votes = new Dictionary<string, int>();

try {
    using (StreamReader sr = File.OpenText(path)) {
        while (!sr.EndOfStream) {
            string[] line = sr.ReadLine().Split(",");
            votes[line[0]] = votes.ContainsKey(line[0]) ? int.Parse(line[1]) + votes[line[0]] : int.Parse(line[1]);
        }

        foreach (KeyValuePair<string, int> voteCount in votes) {
            Console.WriteLine($"{voteCount.Key}: {voteCount.Value}");
        }
    }

} catch (IOException e) {
    Console.WriteLine(e.Message);
}