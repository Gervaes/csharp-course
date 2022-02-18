using System;
using board;

namespace game
{
    internal class ChessGame {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;

        public ChessGame() {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            PutPieces();
        }

        public void makeMove(Position origin, Position destination) { 
            Piece piece = Board.takePiece(origin);
            piece.incrementMovement();
            Piece capturedPiece = Board.takePiece(destination);
            Board.PutPiece(piece, destination);
        }

        private void PutPieces() {
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 1).toPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 2).toPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('d', 2).toPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 2).toPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 1).toPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());

            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).toPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).toPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).toPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).toPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).toPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
