using board;

namespace game {
    internal class King : Piece {

        private ChessGame Game;
        
        public King(Board board, Color color, ChessGame game) : base(board, color) { 
            this.Game = game;
        }

        public override string ToString() {
            return "K";
        }

        private bool CanMove(Position pos) {
            Piece piece = Board.Piece(pos);
            return piece == null || piece.Color != Color;
        }

        public bool RookCastleTest(Position position) {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.moveQuantity == 0;
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

            //castle
            if(moveQuantity == 0 && !Game.Check) {
                //short
                Position posT1 = new Position(Position.Row, Position.Column + 3);
                if(RookCastleTest(posT1)) {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if(Board.Piece(p1) == null && Board.Piece(p2) == null) {
                        mat[p1.Row, p1.Column + 1] = true;
                    }
                }
                //long
                Position posT2 = new Position(Position.Row, Position.Column - 4);
                if (RookCastleTest(posT1)) {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null) {
                        mat[p1.Row, p1.Column - 1] = true;
                    }
                }
            }

            return mat;
        }
    }
}
