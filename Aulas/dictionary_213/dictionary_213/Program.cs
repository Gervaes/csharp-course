using System.Collections.Generic;

Dictionary<string, string> cookies = new Dictionary<string, string>();

cookies["user"] = "Maria";
cookies["email"] = "maria@gmail.com";
cookies["phone"] = "997122342";
cookies["phone"] = "992296279";

Console.WriteLine(cookies["email"]);
Console.WriteLine(cookies["phone"]);

cookies.Remove("email");

if(cookies.ContainsKey("email"))
    Console.WriteLine(cookies["email"]);
else
    Console.WriteLine("Theres no email key");

Console.WriteLine($"Size: {cookies.Count}");

Console.WriteLine("ALL COOKIES");
foreach (KeyValuePair<string, string> item in cookies) {
    Console.WriteLine($"{item.Key}: {item.Value}");
}