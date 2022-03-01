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
        public Piece EnPassantCandidate { get; private set; }

        public ChessGame() {
            Board = new Board(8, 8);
            Turn = 1;
            Check = false;
            CurrentPlayer = Color.White;
            EnPassantCandidate = null;
            PutPieces();
        }

        public Piece MakeMove(Position origin, Position destination) { 
            Piece piece = Board.takePiece(origin);
            piece.incrementMovement();
            Piece capturedPiece = Board.takePiece(destination);
            Board.PutPiece(piece, destination);
            if(capturedPiece != null)
                Captured.Add(capturedPiece);

            //short castle
            if(piece is King && destination.Column == origin.Column + 2) {
                Position rookOrigin = new Position(origin.Row, origin.Column + 3);
                Position rookDestination = new Position(origin.Row, origin.Column + 1);
                Piece rook = Board.takePiece(rookOrigin);
                rook.incrementMovement();
                Board.PutPiece(rook, rookDestination);
            }

            //long castle
            if (piece is King && destination.Column == origin.Column - 2) {
                Position rookOrigin = new Position(origin.Row, origin.Column - 4);
                Position rookDestination = new Position(origin.Row, origin.Column - 1);
                Piece rook = Board.takePiece(rookOrigin);
                rook.incrementMovement();
                Board.PutPiece(rook, rookDestination);
            }

            //Console.WriteLine($"making move: {piece} from {origin} to {destination}");

            //en passant
            if (piece is Pawn && destination.Column != origin.Column && capturedPiece == null) {
                Position pawnPosition;
                if (piece.Color == Color.White) { 
                    pawnPosition = new Position(destination.Row + 1, destination.Column);
                } else {
                    pawnPosition = new Position(destination.Row - 1, destination.Column);
                }

                capturedPiece = Board.takePiece(pawnPosition);
                Captured.Add(capturedPiece);
            }

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

            
            //short castle
            if (piece is King && destination.Column == origin.Column + 2) {
                Position rookOrigin = new Position(origin.Column, origin.Column + 3);
                Position rookDestination = new Position(origin.Column, origin.Column + 1);
                Piece rook = Board.takePiece(rookDestination);
                rook.decrementMovement();
                Board.PutPiece(rook, rookOrigin);
            }

            //long castle
            if (piece is King && destination.Column == origin.Column - 2)
            {
                Position rookOrigin = new Position(origin.Column, origin.Column - 4);
                Position rookDestination = new Position(origin.Column, origin.Column - 1);
                Piece rook = Board.takePiece(rookDestination);
                rook.decrementMovement();
                Board.PutPiece(rook, rookOrigin);
            }

            //Console.WriteLine($"unmaking move: {piece} from {destination} to {origin}");

            if(piece is Pawn) {
                if (origin.Column != destination.Column && capturedPiece == EnPassantCandidate) { 
                    Piece pawn = Board.takePiece(destination);
                    Position pawnPosition;

                    if (piece.Color == Color.White)
                        pawnPosition = new Position(3, destination.Column);
                    else
                        pawnPosition = new Position(4, destination.Column);

                    Board.PutPiece(pawn, pawnPosition);
                }
            }

        }

        public void PlayTurn(Position origin, Position destination) {
            Piece capturedPiece = MakeMove(origin, destination);

            if (IsInCheck(CurrentPlayer)) {
                UnmakeMove(origin, destination, capturedPiece);
                throw new BoardException("This move puts you in check!");
            }

            Piece p = Board.Piece(destination);

            //promotion
            if(p is Pawn) {
                if ((p.Color == Color.White && destination.Row == 0) || (p.Color == Color.Black && destination.Row == 7)) { 
                    p = Board.Piece(destination);
                    Pieces.Remove(p);
                    Piece queen = new Queen(Board, p.Color);
                    Board.PutPiece(queen, destination);
                    Pieces.Add(queen);
                }
            }


            if (IsInCheck(Adversary(CurrentPlayer)))
                Check = true;
            else
                Check = false;


            if (IsCheckMate(Adversary(CurrentPlayer)))
                Finished = true;
            else {
                Turn++;
                ChangePlayer();
            }

            //en passant
            if (p is Pawn && (destination.Row == origin.Row - 2 || destination.Row == origin.Row + 2))
                EnPassantCandidate = p;
            else
                EnPassantCandidate = null;

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
            if (!Board.Piece(origin).PossibleMove(destination))
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
            Console.WriteLine("checou cor");
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
                Console.WriteLine($"checking {piece}s moves...");
                bool[,] mat = piece.PossibleMoves();
                if(mat[k.Position.Row, k.Position.Column])
                    return true;
            }

            return false;
        }

        public bool IsCheckMate(Color color) { 
            if(!IsInCheck(color))
                return false;

            foreach (Piece piece in CurrentPieces(color)) {
                bool[,] mat = piece.PossibleMoves();
                for (int i = 0; i < Board.Rows; i++) {
                    for (int j = 0; j < Board.Columns; j++) {
                        if(mat[i,j]) {
                            Position destination = new Position(i,j);
                            Position aux = piece.Position;
                            Piece capturedPiece = MakeMove(piece.Position, destination);
                            //Console.WriteLine($"makemove: {piece} from {piece.Position} to {destination}");
                            bool testCheck = IsInCheck(color);
                            //Console.WriteLine($"unmakemove: {piece} from {piece.Position} to {destination}");
                            UnmakeMove(aux, destination, capturedPiece);
                            if (!testCheck)
                                return false;
                        }
                    }
                }
            }

            return true;
        }

        public void PutNewPiece(char column, int row, Piece piece) {
            Board.PutPiece(piece, new ChessPosition(column, row).toPosition());
            Pieces.Add(piece);
        }

        private void PutPieces() {
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('b', 1, new Knight(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White, this));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('g', 1, new Knight(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('h', 2, new Pawn(Board, Color.White, this));

            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('b', 8, new Knight(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('g', 8, new Knight(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black, this));
        }
    }
}
