using ChessGame.Chess;

namespace ChessGame.BoardEntities
{
    abstract class Piece
    {
        public Board Board { get; set; }
        public string Type { get; set; }

        public Colour Colour { get; set; }

        public Piece(Board board, string type, Colour colour)
        {
            Board = board;
            Type = type;
            Colour = colour;
        }

        public abstract List<Position> PossibleMoves(Position pos);

        public override string ToString()
        {
            return (Colour == Colour.White) ? GetWhiteSymbol() : GetBlackSymbol();
        }

        private string GetWhiteSymbol()
        {
            if (this is King) return "\u2654";
            if (this is Queen) return "\u2655";
            if (this is Rook) return "\u2656";
            if (this is Bishop) return "\u2657";
            if (this is Knight) return "\u2658";
            if (this is Pawn) return "\u2659";
            return " ";
        }

        private string GetBlackSymbol()
        {
            if (this is King) return "\u265A";
            if (this is Queen) return "\u265B";
            if (this is Rook) return "\u265C";
            if (this is Bishop) return "\u265D";
            if (this is Knight) return "\u265E";
            if (this is Pawn) return "\u265F";
            return " ";
        }

    }

}
