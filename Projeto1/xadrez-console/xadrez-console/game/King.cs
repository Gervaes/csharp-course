using board;

namespace game {
    internal class King : Piece {
        
        public King(Board board, Color color) : base(board, color) { }

        public override string ToString() {
            return "K";
        }

        private bool CanMove(Position pos) {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves() {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            //acima
            Position position = new Position(0, 0);
            position.defineValues(Position.Row - 1, Position.Column);
            if (Board.CheckValidPosition(position) && CanMove(position)) {
                mat[position.Row, position.Column] = true;
            }
            //ne
            position.defineValues(Position.Row - 1, Position.Column + 1);
            if (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //direita
            position.defineValues(Position.Row, Position.Column + 1);
            if (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //se
            position.defineValues(Position.Row + 1, Position.Column + 1);
            if (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //abaixo
            position.defineValues(Position.Row + 1, Position.Column);
            if (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //so
            position.defineValues(Position.Row + 1, Position.Column - 1);
            if (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //esquerda
            position.defineValues(Position.Row, Position.Column - 1);
            if (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }
            //no
            position.defineValues(Position.Row - 1, Position.Column - 1);
            if (Board.CheckValidPosition(position) && CanMove(position))
            {
                mat[position.Row, position.Column] = true;
            }

            return mat;
        }
    }
}
