using System.IO;
using System.Globalization;

string sourcePath = @"C:\Users\eoger\Desktop\Projetos\C#\Aulas\exercicio_192\files\sales.txt";
string targetPath = @"C:\Users\eoger\Desktop\Projetos\C#\Aulas\exercicio_192\files\out\summary.csv";

try {
    using (StreamWriter sw = File.AppendText(targetPath)) {
        using (StreamReader sr = File.OpenText(sourcePath)) {
            while (!sr.EndOfStream) {
                string[] line = sr.ReadLine().Split(",");
                sw.WriteLine($"{line[0]},{(double.Parse(line[1], CultureInfo.InvariantCulture) *int.Parse(line[2])).ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}
catch (IOException e)
{
    Console.WriteLine("An error occurred!");
    Console.WriteLine(e.Message);
}