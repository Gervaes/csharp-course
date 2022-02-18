using board;

namespace xadrez_console {
    class Screen {
        public static void showBoard(Board board) {
            for (int i = 0; i < board.Rows; i++) {
                Console.Write($"{8-i} ");
                for (int j = 0; j < board.Columns; j++) {
                    if(board.Piece(i, j) == null)
                        Console.Write($"- ");
                    else
                        Screen.showPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void showPiece(Piece piece) {
            if (piece.Color == Color.White)
                Console.Write($"{piece} ");
            else if (piece.Color == Color.Black) {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{piece} ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
