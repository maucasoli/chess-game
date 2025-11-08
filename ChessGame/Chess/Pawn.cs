using ChessGame.BoardEntities;

namespace ChessGame.Chess
{
    class Pawn : Piece
    {
        public Board Board { get; set; }

        public Pawn(Board board, string type, Colour colour)
            : base(board, type, colour)
        {
            Board = board;
        }

        public override List<Position> PossibleMoves(Position pos)
        {
            List<Position> moves = new List<Position>();

            int direction = Colour == Colour.White ? -1 : 1;
            int newRow = pos.Row + direction;

            // diagonal left
            Position diagLeft = new Position(newRow, pos.Col - 1);
            if (Board.PositionExists(diagLeft) && Board.IsEnemy(diagLeft, Colour))
            {
                moves.Add(diagLeft);
            }

            // front
            Position frontPos = new Position(newRow, pos.Col);
            if (Board.PositionExists(frontPos) && !Board.ThereIsAPiece(frontPos))
            {
                moves.Add(frontPos);
            }

            // diagonal right
            Position diagRight = new Position(newRow, pos.Col + 1);
            if (Board.PositionExists(diagRight) && Board.IsEnemy(diagRight, Colour))
            {
                moves.Add(diagRight);
            }

            // 1st move
            if (Colour == Colour.Black)
            {
                Position oneAhead = new Position(pos.Row + 1, pos.Col);
                Position twoAhead = new Position(pos.Row + 2, pos.Col);
                if (pos.Row == 1 && !Board.ThereIsAPiece(oneAhead) && !Board.ThereIsAPiece(twoAhead)) {
                    moves.Add(twoAhead);
                }
            } else // white
            {
                Position oneAhead = new Position(pos.Row - 1, pos.Col);
                Position twoAhead = new Position(pos.Row - 2, pos.Col);
                if (pos.Row == 6 && !Board.ThereIsAPiece(oneAhead) && !Board.ThereIsAPiece(twoAhead)) {
                    moves.Add(twoAhead);
                }
            }

                return moves;
        }



        public override string ToString()
        {
            return base.ToString();
        }
    }
}
