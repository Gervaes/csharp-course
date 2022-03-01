using System.IO;

string sourcePath = @"C:\Users\eoger\Desktop\Projetos\C#\file1.txt";
string targetPath = @"C:\Users\eoger\Desktop\Projetos\C#\file2.txt";

try {
    FileInfo fileInfo = new FileInfo(sourcePath);
    fileInfo.CopyTo(targetPath);
    string[] lines = File.ReadAllLines(sourcePath);
    foreach (string line in lines) {
        Console.WriteLine(line);
    }

} catch (IOException e) {
    Console.WriteLine("An error ocurred");
    Console.WriteLine(e.Message);
}