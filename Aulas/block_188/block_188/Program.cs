using System.IO;

string path = @"C:\Users\eoger\Desktop\Projetos\C#\file1.txt";

try {
    using (FileStream fs = new FileStream(path, FileMode.Open)) {
            //using (StreamReader sr = File.OpenText(path))
            using (StreamReader sr = new StreamReader(fs)) {
            while (!sr.EndOfStream) {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
} catch (IOException e) {
    Console.WriteLine("An error occurred!");
    Console.WriteLine(e.Message);
}