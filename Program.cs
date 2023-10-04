using System;
using System.Drawing;
// Author Azubuike Ibe

namespace Shapes
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        
    }

    public class Shape
    {
        public string Color { get; set; }

        public Shape(string color) 
        {
            Color = color;
        }

        public override string ToString()
        {
            return $"Shape Color: {Color}";
        }

        public virtual void Translate(Vertex translation)
        {
            Color = $"Translated {Color} by X: {translation.X}, Y: {translation.Y}";
        }

    }


    public class Line : Shape
    {
        public int X { get; }
        public int Y { get; }
        public Vertex V { get; }

        public Line(int x, int y, string color) : base(color)
        {
            V = new Vertex(x, y);
        }


        public override void Translate(Vertex translation)
        {
            V.X += translation.X;
            V.Y += translation.Y;
        }

        public override string ToString()
        {
            return  $"Line - Color: {Color}" +
                    $"\nLine - Origin: {X}, {Y}" +
                    $"\nAfter Translation: {V.X}, {V.Y}";
                    
        }

    }

    public class Circle : Shape
    {
        public Vertex Origin { get; }
        public double Radius { get; }
        public int X { get; set; }
        public int Y { get; set; }

       

        public Circle(double radius, string color, int x, int y) : base(color)
        {
            Origin = new Vertex(x, y);
            Radius = radius;
        }

    
        public override string ToString()
        {
            return  $"Circle - Origin: ({X}, {Y})," +
                    $"\nAfter Translation: ({Origin.X}, {Origin.Y})," +
                    $"\nRadius: {Radius}," + 
                    $"\nColor: {Color}";
        }

        public override void Translate(Vertex translation)
        {
            Origin.X += translation.X;
            Origin.Y += translation.Y;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }




    }



    static class Test
    {
        static void Main(string[] args)
        {
            // Create a vertex object with coordinates (3, 4)
            Vertex vertex = new Vertex(3, 4);

            // Create a shape object with color red
            Shape shape = new Shape("Red");

            // Create a Line Object
            Line line = new Line(8, 15, "Green");

            // Create a Circle Object
            Circle cirlce = new Circle(10, "Blue", 15, 25);

            // Access and print the coordinates
            Console.WriteLine($"X: {vertex.X}, Y: {vertex.Y}");


            // Print initial Shape details
            Console.WriteLine(shape.ToString());

            // Translate the Shape
            shape.Translate(vertex);

            // Print Shape details after translation
            Console.WriteLine(shape.ToString());

            // Print the line Object
            Console.WriteLine(line.ToString());

            //Print Circle Object
            Console.WriteLine(cirlce.ToString());

        }
    }

}