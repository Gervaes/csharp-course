using board;
using System.Threading;

namespace game
{
    internal class Pawn : Piece
    {
        private ChessGame Game;

        public Pawn(Board board, Color color, ChessGame game) : base(board, color) {
            this.Game = game;
        }

        public override string ToString() {
            return "P";
        }

        private bool EnemyExists(Position pos) {
            Piece piece = Board.Piece(pos);
            return piece != null && piece.Color != Color;
        }

        public bool Free(Position pos) { 
            return Board.Piece(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White) {
                position.defineValues(Position.Row - 1, Position.Column);
                if (Board.CheckValidPosition(position) && Free(position)) {
                    mat[position.Row, position.Column] = true;
                }
                position.defineValues(Position.Row - 2, Position.Column);
                if (Board.CheckValidPosition(position) && Free(position) && moveQuantity == 0) {
                    mat[position.Row, position.Column] = true;
                }
                position.defineValues(Position.Row - 1, Position.Column - 1);
                if (Board.CheckValidPosition(position) && EnemyExists(position)) {
                    mat[position.Row, position.Column] = true;
                }
                position.defineValues(Position.Row - 1, Position.Column + 1);
                if (Board.CheckValidPosition(position) && EnemyExists(position)) {
                    mat[position.Row, position.Column] = true;
                }

                //en passant
                if (Position.Row == 3) {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    Position right = new Position(Position.Row, Position.Column + 1);

                    if(Board.CheckValidPosition(left) && EnemyExists(left) && Board.Piece(left) == Game.EnPassantCandidate) {
                        mat[left.Row - 1, left.Column] = true;
                    }
                    if (Board.CheckValidPosition(right) && EnemyExists(right) && Board.Piece(right) == Game.EnPassantCandidate) {
                        mat[right.Row - 1, right.Column] = true;
                    }
                }

            } else {
                position.defineValues(Position.Row + 1, Position.Column);
                if (Board.CheckValidPosition(position) && Free(position)) {
                    mat[position.Row, position.Column] = true;
                }
                position.defineValues(Position.Row + 2, Position.Column);
                if (Board.CheckValidPosition(position) && Free(position) && moveQuantity == 0) {
                    mat[position.Row, position.Column] = true;
                }
                position.defineValues(Position.Row + 1, Position.Column - 1);
                if (Board.CheckValidPosition(position) && EnemyExists(position)) {
                    mat[position.Row, position.Column] = true;
                }
                position.defineValues(Position.Row + 1, Position.Column + 1);
                if (Board.CheckValidPosition(position) && EnemyExists(position)) {
                    mat[position.Row, position.Column] = true;
                }

                //en passant
                if (Position.Row == 4) {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    Position right = new Position(Position.Row, Position.Column + 1);

                    if (Board.CheckValidPosition(left) && EnemyExists(left) && Board.Piece(left) == Game.EnPassantCandidate) {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    if (Board.CheckValidPosition(right) && EnemyExists(right) && Board.Piece(right) == Game.EnPassantCandidate) {
                        mat[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
