using board;

namespace game
{
    internal class Rook : Piece
    {

        public Rook(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            //acima
            position.defineValues(Position.Row - 1, Position.Column);
            while(Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color) {
                    break;
                }
                position.Row--;
            }
            //direita
            position.defineValues(Position.Row, Position.Column + 1);
            while (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column++;
            }
            //abaixo
            position.defineValues(Position.Row + 1, Position.Column);
            while (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Row++;
            }
            //esquerda
            position.defineValues(Position.Row, Position.Column - 1);
            while (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column--;
            }

            return mat;
        }
    }
}
