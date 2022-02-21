using board;
using game;
using System.Collections.Generic;

namespace xadrez_console {
    class Screen {

        public static void ShowGame(ChessGame game) {
            Screen.showBoard(game.Board);
            Console.WriteLine();
            ShowCapturedPieces(game);
            Console.WriteLine($"Turn: {game.Turn}");
            Console.WriteLine($"Waiting for {game.CurrentPlayer} to play...");

        }

        public static void ShowCapturedPieces(ChessGame game) {
            Console.WriteLine("Captrued Pieces: ");
            Console.Write("White: ");
            ShowSet(game.CapturedPieces(Color.White));
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ShowSet(game.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void ShowSet(HashSet<Piece> set) {
            Console.Write("[");
            foreach (Piece piece in set) {
                Console.Write($"{piece} ");
            }
            Console.WriteLine("]");
        }
        public static void showBoard(Board board) {
            for (int i = 0; i < board.Rows; i++) {
                Console.Write($"{8-i} ");
                for (int j = 0; j < board.Columns; j++) {
                    Screen.showPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void showBoard(Board board, bool[,] possiblePositions) {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Columns; j++) {
                    if (possiblePositions[i, j])
                        Console.BackgroundColor = newBackground;
                    else
                        Console.BackgroundColor = originalBackground;

                    Screen.showPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void showPiece(Piece piece) {

            if (piece == null)
            {
                Console.Write("- ");
            }
            else {

                if (piece.Color == Color.White)
                    Console.Write($"{piece} ");
                else if (piece.Color == Color.Black)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{piece} ");
                    Console.ForegroundColor = aux;
                }
            }
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char col = s[0];
            int row = int.Parse($"{s[1]}");

            return new ChessPosition(col, row);
        }
    }
}
