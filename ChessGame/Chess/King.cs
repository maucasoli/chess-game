using ChessGame.BoardEntities;

namespace ChessGame.Chess
{
    class King : Piece
    {
        public Board Board { get; set; }

        public King(Board board, string type, Colour colour)
            : base(board, type, colour)
        {
            Board = board;
        }

        public override List<Position> PossibleMoves(Position pos)
        {
            List<Position> moves = new List<Position>();
            Position testPos;

            // up left
            testPos = new Position(pos.Row - 1, pos.Col - 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // up right
            testPos = new Position(pos.Row - 1, pos.Col + 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // down left
            testPos = new Position(pos.Row + 1, pos.Col - 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // down right
            testPos = new Position(pos.Row + 1, pos.Col + 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // up
            testPos = new Position(pos.Row, pos.Col - 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // down
            testPos = new Position(pos.Row, pos.Col + 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // left
            testPos = new Position(pos.Row - 1, pos.Col);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                moves.Add(testPos);
            }

            // right
            testPos = new Position(pos.Row + 1, pos.Col);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            return moves;
        }



        public override string ToString()
        {
            return base.ToString();
        }
    }
}
