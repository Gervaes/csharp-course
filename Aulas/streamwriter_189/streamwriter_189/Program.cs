

string sourcePath = @"C:\Users\eoger\Desktop\Projetos\C#\file1.txt";
string targetPath = @"C:\Users\eoger\Desktop\Projetos\C#\file2.txt";

try {
    string[] lines = File.ReadAllLines(sourcePath);

    using (StreamWriter sw = File.AppendText(targetPath)) {
        foreach (string line in lines) { 
            sw.WriteLine(line.ToUpper());
        }
    }

} catch (IOException e) {
    Console.WriteLine("An error occurred!");
    Console.WriteLine(e.Message);
}