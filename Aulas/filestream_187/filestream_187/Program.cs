using System.IO;

string path = @"C:\Users\eoger\Desktop\Projetos\C#\file1.txt";
FileStream fs = null;
StreamReader sr = null;

try
{
    fs = new FileStream(path, FileMode.Open);
    sr = new StreamReader(fs);

    //sr = File.OpenText(path);

    while(!sr.EndOfStream) {
        string line = sr.ReadLine();
        Console.WriteLine(line);
    }

} catch (IOException e) {

} finally { 
    if(sr != null) sr.Close();
    if(fs != null) fs.Close();
}
