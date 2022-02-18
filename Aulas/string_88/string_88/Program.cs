string original = "abcde FGHIJ ABC abc DEFG     ";

Console.WriteLine($"Original: -{original}-");
Console.WriteLine($"ToUpper: -{original.ToUpper()}-");
Console.WriteLine($"ToLower: -{original.ToLower()}-");
Console.WriteLine($"Trim: -{original.Trim()}-");
Console.WriteLine($"IndexOf bc: -{original.IndexOf("bc")}-");
Console.WriteLine($"LastIndexOf bc: -{original.LastIndexOf("bc")}-");
Console.WriteLine($"Substring 3: -{original.Substring(3)}-");
Console.WriteLine($"Substring 3 5: -{original.Substring(3,5)}-");
Console.WriteLine($"Replace a x: -{original.Replace('a','x')}-");
Console.WriteLine($"Replace abc xy: -{original.Replace("abc", "xy")}-");
Console.WriteLine($"IsNullOrEmpty: -{String.IsNullOrEmpty(original)}-");
Console.WriteLine($"IsNullOrWhiteSpace: -{String.IsNullOrWhiteSpace(original)}-");

