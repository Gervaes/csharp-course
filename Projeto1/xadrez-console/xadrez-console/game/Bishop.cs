using board;

namespace game
{
    internal class Bishop : Piece
    {

        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //no
            position.defineValues(Position.Row - 1, Position.Column - 1);
            while (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    Console.WriteLine(Board.Piece(position));
                    Console.WriteLine(Board.Piece(position).Color);
                    break;
                }
                position.defineValues(position.Row - 1, position.Column - 1);
            }
            //ne
            position.defineValues(Position.Row - 1, Position.Column + 1);
            while (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.defineValues(position.Row - 1, position.Column + 1);
            }
            //se
            position.defineValues(Position.Row + 1, Position.Column + 1);
            while (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.defineValues(position.Row + 1, position.Column + 1);
            }
            //so
            position.defineValues(Position.Row + 1, Position.Column - 1);
            while (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.defineValues(position.Row + 1, position.Column - 1);
            }

            return mat;
        }
    }
}
