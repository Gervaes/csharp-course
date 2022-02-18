
namespace board
{
    internal class Piece {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int moveQuantity { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color) {
            this.Position = null;
            this.Board = board;
            this.Color = color;
            this.moveQuantity = 0;
        }

        public void incrementMovement() {
            moveQuantity++;
        }
    }
}
