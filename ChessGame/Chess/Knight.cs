using ChessGame.BoardEntities;

namespace ChessGame.Chess
{
    class Knight : Piece
    {
        public Board Board { get; set; }

        public Knight(Board board, string type, Colour colour)
            : base(board, type, colour)
        {
            Board = board;
        }

        public override List<Position> PossibleMoves(Position pos)
        {
            List<Position> moves = new List<Position>();
            Position testPos;

            // up left
            testPos = new Position(pos.Row - 2, pos.Col - 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }
            // up right
            testPos = new Position(pos.Row - 2, pos.Col + 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }
            // down left
            testPos = new Position(pos.Row + 2, pos.Col - 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }
            // down right
            testPos = new Position(pos.Row + 2, pos.Col + 1);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // left up
            testPos = new Position(pos.Row - 1, pos.Col - 2);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // right up
            testPos = new Position(pos.Row - 1, pos.Col + 2);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // left down
            testPos = new Position(pos.Row + 1, pos.Col - 2);
            if (Board.PositionExists(testPos))
            {
                if (!Board.ThereIsAPiece(testPos) || Board.IsEnemy(testPos, Colour))
                    moves.Add(testPos);
            }

            // right down
            testPos = new Position(pos.Row + 1, pos.Col + 2);
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
