using System;
using board;
using game;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try
            {
                ChessGame game = new ChessGame();

                Screen.showBoard(game.Board);
            }
            catch (BoardException e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}