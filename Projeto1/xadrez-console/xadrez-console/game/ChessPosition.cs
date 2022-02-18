using System;
using board;

namespace game
{
    internal class ChessPosition {
        public int Row { get; set; }
        public char Column { get; set; }

        public ChessPosition(char column, int row) {
            this.Row = row;
            this.Column = column;
        }

        public override string ToString() {
            return $"{Column}{Row}";
        }

        public Position toPosition() {
            return new Position(8 - Row, Column - 'a');
        }
    }
}
