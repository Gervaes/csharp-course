using board;

namespace game
{
    internal class Knight : Piece
    {

        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "k";
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
            

            position.defineValues(Position.Row - 1, Position.Column - 2);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            position.defineValues(Position.Row - 2, Position.Column - 1);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            position.defineValues(Position.Row - 2, Position.Column + 1);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            position.defineValues(Position.Row - 1, Position.Column + 2);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            position.defineValues(Position.Row + 1, Position.Column + 2);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            position.defineValues(Position.Row + 2, Position.Column + 1);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            position.defineValues(Position.Row + 2, Position.Column - 1);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            position.defineValues(Position.Row + 1, Position.Column - 2);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }

            return mat;
        }
    }
}
