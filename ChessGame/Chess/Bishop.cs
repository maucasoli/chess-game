using ChessGame.BoardEntities;

namespace ChessGame.Chess
{
    class Bishop : Piece
    {
        public Board Board { get; set; }

        public Bishop(Board board, string type, Colour colour)
            : base(board, type, colour)
        {
            Board = board;
        }

        public override List<Position> PossibleMoves(Position pos)
        {
            List<Position> moves = new List<Position>();
            Position testPos;

            // up left
            int row = pos.Row - 1;
            int col = pos.Col - 1;
            while (row >= 0 && col >= 0)
            {
                testPos = new Position(row, col);
                if (Board.Grid[row, col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row, col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }

                row--;
                col--;
            }

            // up right
            row = pos.Row - 1;
            col = pos.Col + 1;
            while (row >= 0 && col < 8)
            {
                testPos = new Position(row, col);
                if (Board.Grid[row, col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row, col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }

                row--;
                col++;
            }

            // down left
            row = pos.Row + 1;
            col = pos.Col - 1;
            while (row < 8 && col >= 0)
            {
                testPos = new Position(row, col);
                if (Board.Grid[row, col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row, col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }

                row++;
                col--;
            }

            // down right
            row = pos.Row + 1;
            col = pos.Col + 1;
            while (row < 8 && col < 8)
            {
                testPos = new Position(row, col);
                if (Board.Grid[row, col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row, col] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }

                row++;
                col++;
            }

            return moves;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
