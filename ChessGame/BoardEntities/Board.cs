using ChessGame.Chess;

namespace ChessGame.BoardEntities
{
    class Board
    {
        public Piece[,] Grid { get; set; }
        private List<Piece> CapturedByBlack = new List<Piece>();
        private List<Piece> CapturedByWhite = new List<Piece>();

        public Board()
        {
            Grid = new Piece[8, 8];
            SetupBoard();
        }

        private void SetupBoard()
        {
            // Black
            Grid[0, 0] = new Rook(this, "R", Colour.Black);
            Grid[0, 1] = new Knight(this, "N", Colour.Black);
            Grid[0, 2] = new Bishop(this, "B", Colour.Black);
            Grid[0, 3] = new Queen(this, "Q", Colour.Black);
            Grid[0, 4] = new King(this, "K", Colour.Black);
            Grid[0, 5] = new Bishop(this, "B", Colour.Black);
            Grid[0, 6] = new Knight(this, "N", Colour.Black);
            Grid[0, 7] = new Rook(this, "R", Colour.Black);
            for (int row = 0; row < 8; row++)
            {
                Grid[1, row] = new Pawn(this, "P", Colour.Black);
            }

            // White
            for (int row = 0; row < 8; row++)
            {
                Grid[6, row] = new Pawn(this, "P", Colour.White);
            }
            Grid[7, 0] = new Rook(this, "R", Colour.White);
            Grid[7, 1] = new Knight(this, "N", Colour.White);
            Grid[7, 2] = new Bishop(this, "B", Colour.White);
            Grid[7, 3] = new Queen(this, "Q", Colour.White);
            Grid[7, 4] = new King(this, "K", Colour.White);
            Grid[7, 5] = new Bishop(this, "B", Colour.White);
            Grid[7, 6] = new Knight(this, "N", Colour.White);
            Grid[7, 7] = new Rook(this, "R", Colour.White);

        }

        public Piece GetPiece(Position pos)
        {
            return Grid[pos.Row, pos.Col];
        }

        public void PrintBoard(List<Position> highlights = null)
        {
            for (int row = 0; row < 8; row++)
            {
                Console.Write(8 - row + " | ");

                for (int col = 0; col < 8; col++)
                {
                    Piece piece = Grid[row, col];
                    bool isHighlighted = highlights != null && highlights.Any(p => p.Row == row && p.Col == col);

                    if (isHighlighted)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.Write(piece != null ? piece.ToString() + " " : ". ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.WriteLine("   ----------------");
            Console.WriteLine("    a b c d e f g h");

            Console.Write("\nCaptured by black: [");
            foreach (Piece p in CapturedByBlack) Console.Write($"{p} , ");
            Console.Write("]\nCaptured by white: [");
            foreach (Piece p in CapturedByWhite) Console.Write($"{p} , ");
            Console.WriteLine("]");
        }


        public bool validPosition(Position pos)
        {
            if (pos.Row >= 0 && pos.Row < 8 && pos.Col >= 0 && pos.Col < 8)
            {
                if (Grid[pos.Row, pos.Col] != null) {
                    return true;
                }
                Console.WriteLine("Invalid position.");
                return false; 
            }
            else
            {
                Console.WriteLine("Invalid position.");
                return false;
            }
        }

        public void PlacePiece(Piece piece, Position pos, Position newPos, List<Position> moves)
        {
            bool invalidMove = true;
            foreach (Position move in moves)
            {
                if (newPos.Row == move.Row && newPos.Col == move.Col)
                {
                    if (IsEnemy(newPos, GetPiece(pos).Colour))
                    {
                        Piece enemy = GetPiece(newPos);
                        if (enemy.Colour == Colour.Black) CapturedByWhite.Add(enemy);
                        else CapturedByBlack.Add(enemy);
                    }

                    Grid[pos.Row, pos.Col] = null;
                    Grid[newPos.Row, newPos.Col] = piece;
                    invalidMove = false;
                    break;
                }

            }
            if (invalidMove) Console.WriteLine("Invalid move.\n");
        }


        public Piece RemovedPiece(Position pos)
        {
            // out of grid
            if (!PositionExists(pos))
            {
                throw new BoardException("Invalid position.");
            }

            // nothing to remove
            if (Grid[pos.Row, pos.Col] == null)
            {
                return null;
            }

            Piece removedPiece = Grid[pos.Row, pos.Col];


            return removedPiece;
        }


        public bool PositionExists(Position pos)
        {
            int row = pos.Row;
            int col = pos.Col;

            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }


        public bool ThereIsAPiece(Position pos)
        {
            if (!PositionExists(pos))
            {
                throw new BoardException("Invalid position.");
            }

            return Grid[pos.Row, pos.Col] != null;
        }


        public bool IsEnemy(Position targetPos, Colour myColour)
        {
            Piece target = GetPiece(targetPos);
            return target != null && target.Colour != myColour;
        }

    }
}
