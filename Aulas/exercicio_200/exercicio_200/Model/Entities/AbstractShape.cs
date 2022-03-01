using exercicio_200.Model.Enums;

namespace exercicio_200.Model.Entities
{
    abstract class AbstractShape : IShape {
        public Color Color { get; set; }

        public abstract double Area();
    }
}
