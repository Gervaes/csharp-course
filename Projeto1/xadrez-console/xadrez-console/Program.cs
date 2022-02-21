using System;
using board;
using game;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessGame game = new ChessGame();
               
                while (!game.Finished) {
                    try
                    {
                        Console.Clear();
                        Screen.ShowGame(game);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        game.ValidateOrigin(origin);

                        bool[,] possiblePositions = game.Board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.showBoard(game.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.readChessPosition().toPosition();
                        game.ValidateDestination(origin, destination);

                        game.PlayTurn(origin, destination);
                    }
                    catch (BoardException e) {
                        Console.WriteLine($"Error: {e.Message}");
                        Console.ReadLine();
                    }
                }
            }
            catch (BoardException e) {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}