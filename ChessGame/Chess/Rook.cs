using ChessGame.BoardEntities;

namespace ChessGame.Chess
{
    class Rook : Piece
    {
        public Board Board { get; set; }
        public Colour Colour { get; set; }

        public Rook(Board board, string type, Colour colour)
            : base(board, type, colour)
        {
            Board = board;
            Colour = colour;
        }

        public override List<Position> PossibleMoves(Position pos)
        {
            List<Position> moves = new List<Position>();

            // up
            for (int row = pos.Row - 1; row >= 0; row--)
            {
                Position testPos = new Position(row, pos.Col);
                if (Board.Grid[row, pos.Col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row, pos.Col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }
            }
            // down
            for (int row = pos.Row + 1; row < 8; row++)
            {
                Position testPos = new Position(row, pos.Col);
                if (Board.Grid[row, pos.Col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row, pos.Col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }
            }
            // left
            for (int col = pos.Col - 1; col >= 0; col--)
            {
                Position testPos = new Position(pos.Row, col);
                if (Board.Grid[pos.Row, col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[pos.Row, col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }
            }
            // right
            for (int col = pos.Col + 1; col < 8; col++)
            {
                Position testPos = new Position(pos.Row, col);
                if (Board.Grid[pos.Row, col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[pos.Row, col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
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
