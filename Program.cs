using System;
using System.IO;
using System.Linq;
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes();

var next = 1 + types
    .Where(t => t.Name.Contains("Writter"))
    .Select(t => t.Name.Replace("Writter", ""))
    .Select(t => int.TryParse(t, out int n) ? n : 0)
    .Max();

File.WriteAllText($"Writter{next}.cs",
    $$"""
        using System; 
        public class Writter{{next}}
        {
            public Writter{{next}}() { }
            public void Show()
            {
                Console.WriteLine(
                    this.GetType().Name
                );
            }
        }
    """
);

foreach (var type in types)
{
    if (!type.Name.Contains("Writter"))
        continue;

    var obj = Activator.CreateInstance(type);
    if (obj is null)
        continue;
    
    var method = type.GetMethod("Show");
    if (method is null)
        continue;
    
    method.Invoke(obj, null);
}

public class Writter1
{
    public Writter1() { }
    public void Show()
    {
        Console.WriteLine(
            this.GetType().Name
        );
    }
}