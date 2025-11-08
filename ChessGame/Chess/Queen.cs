using ChessGame.BoardEntities;

namespace ChessGame.Chess
{
    class Queen : Piece
    {
        public Board Board { get; set; }
        public Colour Colour { get; set; }

        public Queen(Board board, string type, Colour colour)
            : base(board, type, colour)
        {
            Board = board;
            Colour = colour;
        }

        public override List<Position> PossibleMoves(Position pos)
        {
            List<Position> moves = new List<Position>();

            Position testPos;

            // up
            for (int row_ = pos.Row - 1; row_ >= 0; row_--)
            {
                testPos = new Position(row_, pos.Col);
                if (Board.Grid[row_, pos.Col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row_, pos.Col] == null)
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
            for (int row_ = pos.Row + 1; row_ < 8; row_++)
            {
                testPos = new Position(row_, pos.Col);
                if (Board.Grid[row_, pos.Col] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[row_, pos.Col] == null)
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
            for (int col_ = pos.Col - 1; col_ >= 0; col_--)
            {
                testPos = new Position(pos.Row, col_);
                if (Board.Grid[pos.Row, col_] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[pos.Row, col_] == null)
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
            for (int col_ = pos.Col + 1; col_ < 8; col_++)
            {
                testPos = new Position(pos.Row, col_);
                if (Board.Grid[pos.Row, col_] != null && !Board.IsEnemy(testPos, Colour))
                {
                    break;
                }
                else if (Board.Grid[pos.Row, col_] == null)
                {
                    moves.Add(testPos);
                }
                else // enemy
                {
                    moves.Add(testPos);
                    break;
                }
            }

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
