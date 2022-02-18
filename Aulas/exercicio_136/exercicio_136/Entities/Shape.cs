using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercicio_136.Entities.Enums;

namespace exercicio_136.Entities
{
    abstract class Shape {
        public Color Color { get; set; }

        public Shape() { }
        public Shape(Color color) { 
            Color = color;
        }

        public abstract double Area();
    }
}
