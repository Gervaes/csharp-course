using System;
using System.Collections.Generic;
using board;

namespace game
{
    internal class ChessGame {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        private HashSet<Piece> Pieces = new HashSet<Piece>();
        private HashSet<Piece> Captured = new HashSet<Piece>();
        public bool Check { get; private set; }

        public ChessGame() {
            Board = new Board(8, 8);
            Turn = 1;
            Check = false;
            CurrentPlayer = Color.White;
            PutPieces();
        }

        public Piece MakeMove(Position origin, Position destination) { 
            Piece piece = Board.takePiece(origin);
            piece.incrementMovement();
            Piece capturedPiece = Board.takePiece(destination);
            Board.PutPiece(piece, destination);
            if(capturedPiece != null)
                Captured.Add(capturedPiece);

            return capturedPiece;
        }

        public void UnmakeMove(Position origin, Position destination, Piece capturedPiece) {
            Piece piece = Board.takePiece(destination);
            piece.decrementMovement();
            if (capturedPiece != null) { 
                Board.PutPiece(capturedPiece, destination);
                Captured.Remove(capturedPiece);
            }

            Board.PutPiece(piece, origin);
        }

        public void PlayTurn(Position origin, Position destination) {
            Piece capturedPiece = MakeMove(origin, destination);

            if (IsInCheck(CurrentPlayer)) {
                UnmakeMove(origin, destination, capturedPiece);
                throw new BoardException("This move puts you in check!");
            }

            if(IsInCheck(Adversary(CurrentPlayer)))
                Check = true;
            else
                Check = false;

            Turn++;
            ChangePlayer();
        }

        public void ValidateOrigin(Position position) { 
            if(Board.Piece(position) == null)
                throw new BoardException("There is no piece on that position");
            if (CurrentPlayer != Board.Piece(position).Color)
                throw new BoardException("This piece is not yours!");
            if (!Board.Piece(position).hasPossibleMoves())
                throw new BoardException("There is no possible moves for this piece!");
        }

        public void ValidateDestination(Position origin, Position destination) {
            if (!Board.Piece(origin).CanMoveTo(destination))
                throw new BoardException("Can't move to this position!");
        }

        private void ChangePlayer() { 
            if(CurrentPlayer == Color.White)
                CurrentPlayer = Color.Black;
            else
                CurrentPlayer = Color.White;
        }

        public HashSet<Piece> CapturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece piece in Captured) { 
                if(piece.Color == color)
                    aux.Add(piece);
            }

            return aux;
        }

        public HashSet<Piece> CurrentPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece piece in Pieces) {
                if (piece.Color == color)
                    aux.Add(piece);
            }

            aux.ExceptWith(CapturedPieces(color));

            return aux;
        }

        private Color Adversary(Color color) { 
            if(color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece King(Color color) {
            foreach (Piece piece in CurrentPieces(color)) {
                if(piece is King)
                    return piece;
            }
            return null;
        }

        public bool IsInCheck(Color color) {
            Piece k = King(color);
            if (k == null)
                throw new BoardException("There is no king in the board!");

            foreach (Piece piece in CurrentPieces(Adversary(color))) {
                bool[,] mat = piece.PossibleMoves();
                if(mat[k.Position.Row, k.Position.Column])
                    return true;
            }

            return false;
        }

        public void PutNewPiece(char column, int row, Piece piece) {
            Board.PutPiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }

        private void PutPieces() {
            PutNewPiece('c', 1, new Rook(Board, Color.White));
            PutNewPiece('c', 2, new Rook(Board, Color.White));
            PutNewPiece('d', 2, new Rook(Board, Color.White));
            PutNewPiece('e', 2, new Rook(Board, Color.White));
            PutNewPiece('e', 1, new Rook(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            PutNewPiece('c', 7, new Rook(Board, Color.Black));
            PutNewPiece('c', 8, new Rook(Board, Color.Black));
            PutNewPiece('d', 7, new Rook(Board, Color.Black));
            PutNewPiece('e', 7, new Rook(Board, Color.Black));
            PutNewPiece('e', 8, new Rook(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));

        }
    }
}
