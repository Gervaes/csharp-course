
namespace board
{
    abstract class Piece {
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

        public void decrementMovement() {
            moveQuantity--;
        }

        public bool hasPossibleMoves() {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Rows; i++) {
                for (int j = 0; j < Board.Columns; j++) {
                    if(mat[i,j])
                        return true;
                }
            }
            return false;
        }

        public bool PossibleMove(Position position) {
            return PossibleMoves()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
