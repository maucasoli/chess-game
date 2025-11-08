using ChessGame.BoardEntities;

namespace ChessGame.Chess
{
    public static class ChessHelper
    {
        public static Position ParseChessPosition(string input)
        {
            if (input.Length != 2)
                return null;

            char file = char.ToLower(input[0]); // letter a-h
            char rank = input[1]; // number 1-8

            if (file < 'a' || file > 'h' || rank < '1' || rank > '8')
                return null;

            int col = file - 'a';           // 'a' -> 0
            int row = 8 - (rank - '0');     // '8' -> 0

            return new Position(row, col);
        }

        public static string ToChessNotation(Position pos)
        {
            char file = (char)('a' + pos.Col);
            int rank = 8 - pos.Row;

            return $"{file}{rank}";
        }
    }
}

