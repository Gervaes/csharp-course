TimeSpan t1 = TimeSpan.MaxValue;
TimeSpan t2 = TimeSpan.MinValue;
TimeSpan t3 = TimeSpan.Zero;

Console.WriteLine(t1);
Console.WriteLine(t2);
Console.WriteLine(t3);

TimeSpan t4 = new TimeSpan(2, 3, 5, 7, 11);
Console.WriteLine($"Days: {t1.Days}");
Console.WriteLine($"Hours: {t1.Hours}");
Console.WriteLine($"Minutes: {t1.Minutes}");
Console.WriteLine($"Milliseconds: {t1.Milliseconds}");
Console.WriteLine($"Seconds: {t1.Seconds}");
Console.WriteLine($"Ticks: {t1.Ticks}");

Console.WriteLine();
Console.WriteLine($"TotalDays: {t1.TotalDays}");
Console.WriteLine($"TotalHours: {t1.TotalHours}");
Console.WriteLine($"TotalMinutes: {t1.TotalMinutes}");
Console.WriteLine($"TotalSeconds: {t1.TotalSeconds}");
Console.WriteLine($"TotalMilliseconds: {t1.TotalMilliseconds}");

TimeSpan t5 = new TimeSpan(1, 30, 10);
TimeSpan t6 = new TimeSpan(0, 10, 5);

Console.WriteLine();
Console.WriteLine(t5.Add(t6));
Console.WriteLine(t5.Subtract(t6));
Console.WriteLine(t6.Multiply(2.0));
Console.WriteLine(value: t2.Divide(2.0));