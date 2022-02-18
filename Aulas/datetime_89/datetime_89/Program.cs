using System.Globalization;

DateTime d1 = DateTime.Now;
Console.WriteLine(d1);
Console.WriteLine(d1.Ticks);

DateTime d2 = new DateTime(2022, 12, 21);
Console.WriteLine(d2);
DateTime d3 = new DateTime(2022, 12, 21, 20, 45, 03);
Console.WriteLine(d3);
DateTime d4 = new DateTime(2022, 12, 21, 20, 45, 03, 500);
Console.WriteLine(d4);

DateTime d5 = DateTime.Now;
Console.WriteLine(d5);
DateTime d6 = DateTime.Today;
Console.WriteLine(d6);
DateTime d7 = DateTime.UtcNow;
Console.WriteLine(d7);

DateTime d8 = DateTime.Parse("2000-08-15");
Console.WriteLine(d8);
DateTime d9 = DateTime.Parse("2000-08-15");
Console.WriteLine(d9);
DateTime d10 = DateTime.Parse("15/08/2000");
Console.WriteLine(d10);

DateTime d11 = DateTime.ParseExact("15/08/2000 13:05:58", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
Console.WriteLine(d11);