using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Board {
        public int Rows { get; set; }
        public int Columns { get; set; }

        private Piece[,] Pieces;

        public Board(int rows, int columns) { 
            this.Rows = rows;
            this.Columns = columns;
            this.Pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column) { 
            return Pieces[row, column];
        }

        public Piece Piece(Position position) { 
            return Pieces[position.Row, position.Column];
        }

        public bool PieceExists(Position position) { 
            validPosition(position);
            return Piece(position) != null;
        }

        public void PutPiece(Piece piece, Position position) {
            if (PieceExists(position))
                throw new BoardException("There's already a piece in that position!");

            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece takePiece(Position position) {
            if (Piece(position) == null)
                return null;
            
            Piece aux = Piece(position);
            aux.Position = position;
            Pieces[position.Row, position.Column] = null;
            return aux;
        }

        public bool checkValidPosition(Position position) { 
            if(position.Row < 0 || position.Row > Rows || position.Column < 0 || position.Column > Columns)
                return false;
            return true;
        }

        public void validPosition(Position position) {
            if (!checkValidPosition(position))
                throw new BoardException("Invalid position!");
        }
    }
}
