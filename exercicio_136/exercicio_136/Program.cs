using exercicio_136.Entities;
using exercicio_136.Entities.Enums;
using System.Globalization;

List<Shape> shapes = new List<Shape>();

Console.Write("Enter the number of shapes: ");
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++) {
    Console.WriteLine($"Shape #{i+1} data:");
    Console.Write("Rectangle or Circle (r/c): ");
    char shapeType = char.Parse(Console.ReadLine());
    Console.Write("Color (Black/Blue/Red): ");
    Color shapeColor = Enum.Parse<Color>(Console.ReadLine());

    if(shapeType == 'r') {
        Console.Write("Width: ");
        double shapeWidth = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Height: ");
        double shapeHeight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        shapes.Add(new Rectangle(shapeWidth, shapeHeight, shapeColor));
    } else if(shapeType == 'c'){
        Console.Write("Radius: ");
        double shapeRadius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        shapes.Add(new Circle(shapeRadius, shapeColor));
    }
}

Console.WriteLine();
Console.WriteLine("SHAPE AREAS:");

foreach (Shape shape in shapes) {
    Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));    
}